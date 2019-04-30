using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour {

    public AudioMixer audioMixer; // Variable for audio mixer

    public Dropdown resolutionDropdown;

    private Resolution[] resolutions; // Array of resolutions

    private void Start()
    {
        // Storing all screen resolutions (around the world current monitors) into the resolutions array
        resolutions = Screen.resolutions;

        // Clearing the options on resolution dropdown
        resolutionDropdown.ClearOptions();

        // This is a list not an array (the size of the list can be change but not for array) (this list is named screenResolution)
        List<string> screenResolutions = new List<string>();

        int currentResolutionIndex = 0;

        // Loop through on each element on the resolutions array
        for (int i = 0; i < resolutions.Length; i++)
        {
            // Creating a string of resolution option (since monitors has different width and height. 
            string optionOfScreenResolution = resolutions[i].width + " x " + resolutions[i].height;

            // Adding the option into the list (which is screenResolution)
            screenResolutions.Add(optionOfScreenResolution);

            //  If this resolution that is inside the array is equal to the actual current screen that player looking at
                        // Can't do this --> if(resolutions[i] == Screen.currentResolution), why?? cause it is unity.
                        // To solving the problem it needs to actually compare both width and height
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Adding the screen resolution list into resolution dropdown
        resolutionDropdown.AddOptions(screenResolutions);

        // the value that is on resolution dropdown is set to the current resolution
        resolutionDropdown.value = currentResolutionIndex;

        // refreshing the text, image and value on resolution dropdown --> the screen resolution will show up after this syntax is called. 
        resolutionDropdown.RefreshShownValue();
    }

    // Setting resolution
    public void setResolution(int resolutionIndex)
    {
        // storing the number of resolutions that are inside the dropdown to resolution. 
        Resolution resolution = resolutions[resolutionIndex];
        // Activating resolution
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Setting up volume
    public void SetVolume(float volume)
    {
        // Connecting the audio mixer that is named "Volume"    
        audioMixer.SetFloat("Volume", volume); 
    }

    // Allowing to set game quality
    public void setQuality(int qualityIndex)
    {
        // Connecting unity quality setting
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Allowing full screen
    public void setFullScreen(bool isFullscreen)
    {
        // If it is full screen --> full screen
        Screen.fullScreen = isFullscreen;
    }
}

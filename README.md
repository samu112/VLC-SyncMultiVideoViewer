<div id="top"></div>


<!-- PROJECT LOGO -->
<br />
<div align="center">


<h1 align="center">VLC-SyncMultiVideoViewer</h1>

  <p align="center">
    This is a simple program which lets you to play multiple videos in sync
    <br />
    <br />
    <img src="https://github.com/samu112/VLC-SyncMultiVideoViewer/blob/master/VLC-SyncMultiVideoViewer-Review.PNG?raw=true" alt="VLC-SyncMultiVideoViewer-Preview">
    <br />
    <br />
    <strong>Why would you want to use this?</strong>
    <br />
    <strong>E.g.</strong> On some university there are online classes and they upload multiple video feeds from the same class. One which shows the board, one which shows the slideshow and one which shows the teacher. With this program you can see them side by side or only the ones you want to watch. You can also mute any or unmute any of them.
    <br />
  </p>
  </br>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#used-nuget-packages">Used Nuget Packages</a></li>
        <li><a href="#used-project-types">Used Project Types</a></li>
      </ul>
    </li>
    <li>
      <a href="#functionalities">Functionalities</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
      </ul>
    </li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

<p>On some university there are online classes and they upload multiple video feeds from the same class.</p>
<ol>
<li>one which shows the board</li>
<li>one which shows the slideshow</li>
<li>and one which shows the teacher.</li>
</ol>
<p>One of my friends complained that it is really annoying to manually try to sync multiple videos. I started to look for solutions but couldn't really find any(only that in the VLC media player you should be able to do this, but after some reading I realized that for some time now it doesn't seem to work.)</p>
<p>So I spent a day creating a program to help him.</p>

<p align="right">(<a href="#top">back to top</a>)</p>



### Used Nuget Packages:

  * [LibVLCSharp.WinForms](https://www.nuget.org/packages/LibVLCSharp.WinForms)
  * [VideoLAN.LibVLC.Windows](https://www.nuget.org/packages/VideoLAN.LibVLC.Windows)


<p align="right">(<a href="#top">back to top</a>)</p>



### Used Project Types:
* Windows Form Application (.NET Core) - .NET 5

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- FUNCTIONALITIES -->
## Functionalities
<p><ins>Basics:</ins></p>
<ul>
  <li>You can add files and remove files</li>
  <li>When you press Start/Pause only the first video in the list will be shown, the others will be hidden.</li>
  <li>You can show the hidden videos by selecting their name and pressing the "ShowFile" button.</li>
  <li>When you close a video, it will still play in the background.</li>
  <li>When you close a video, it will still play in the background.</li>
  <li>You can change playback speed with the "speed bar".</li>
  <li>The "Stop" button will reset all videos.</li>
</ul>
<p><ins>Shortcuts when you are in a video player window:<ins></p>
<ul>
  <li>Press "F" to toggle fullscreen mode for selected video.</li>
  <li>Press "ESC" to exit fullscreen mode for selected video.</li>
  <li>Press "Space" to pause/resume every video.</li>
  <li>Use the "UP"/"Down" arrows to change the volume for selected video.</li>
  <li>Press "M" to toggle mute on selected video.</li>
</ul>
  
<p align="right">(<a href="#top">back to top</a>)</p>

  

<!-- GETTING STARTED -->
## Getting Started

<p>If you want to build it for yourself:</p>
  <ol>
<li>Clone or Download the Repository.</li>
<li>Open the "VLC-SyncMultiVideoViewer.sln" file in <a href="https://visualstudio.microsoft.com/">Visual Studio</a></li>
<li>Press F5 to build and start the project</li>
<li>Enjoy</li>
    </ol>
<p>If you just want to use it:</p>
  <ol>
<li>Go to the <a href="https://github.com/samu112/VLC-SyncMultiVideoViewer/releases">release page</a>.</li>
<li>Download the "VLC-SyncMultiVideoViewerExtractor.exe" file.</li>
<li>Run the downloaded "VLC-SyncMultiVideoViewerExtractor.exe" to extract the necessary files.</li>
<li>After the extraction finished run the program from the extraction folder with the "VLC-SyncMultiVideoViewer.exe" file.</li>
<li>Enjoy</li>
    </ol>



### Prerequisites


<p>If you want to build it:</p>
  <ol>
    <li>You need  <a href="https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019">Visual Studio 2019 version 16.9.2 or a later version</a>  with the <a href="https://docs.microsoft.com/en-us/archive/msdn-magazine/2016/april/net-core-net-goes-cross-platform-with-net-core">.NET Core cross-platform</a> development workload installed. The .NET 5.0 SDK is automatically installed when you select this workload.</li>
    <li>You also need the <a href="https://www.videolan.org/vlc/">VLC Media Player</a> installed.</li>
  </ol>
</p>

<p>If you just want to use it:
  <ol>
    <li>You need to install the <a href="https://dotnet.microsoft.com/en-us/download/dotnet/5.0">.NET 5.0 SDK</a>.</li>
    <li>You also need the <a href="https://www.videolan.org/vlc/">VLC Media Player</a> installed.</li>
  </ol>
</p>
<p align="right">(<a href="#top">back to top</a>)</p>


<!-- CONTACT -->
## Contact

Sámuel Léránt - lerantsamuel@gmail.com

Project Link: [https://github.com/samu112/VLC-SyncMultiVideoViewer](https://github.com/samu112/VLC-SyncMultiVideoViewer/)

<p align="right">(<a href="#top">back to top</a>)</p>




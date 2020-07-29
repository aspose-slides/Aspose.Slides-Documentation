---
title: Adding Audio Frame to Slide in Python
type: docs
weight: 10
url: /java/adding-audio-frame-to-slide-in-python/
---

## **Aspose.Slides - Adding Audio Frame to Slide**
To Add Audio Frame to Slide using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}



\# Create an instance of Presentation class

pres = self.Presentation

\# Get the first slide

sId = pres.getSlides().get_Item(0)

\# Load the wav sound file to stram

fstr=self.FileInputStream

file=self.File

fstr = fstr.file.new(self.dataDir + "Bass-Drum.wav")

\# Add Audio Frame

af = sId.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr)

\# Set Play Mode and Volume of the Audio

audioPlayModePreset=self.AudioPlayModePreset()

AudioVolumeMode=self.AudioVolumeMode()

af.setPlayMode(audioPlayModePreset.Auto)

af.setVolume(AudioVolumeMode.Loud)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.data_dir + "AudioFrameEmbed.pptx", save_format.Pptx)

print "Added audio frame to slide, please check the output file."



{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)

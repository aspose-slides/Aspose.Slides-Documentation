---
title: Add Video Frame to PowerPoint Slides in Python
linktitle: Adding Video Frame to Slide in Python
type: docs
weight: 40
url: /java/adding-video-frame-to-slide-in-python/
---

## **Aspose.Slides - Adding Video Frame to Slide**
To Add Video Frame to Slide using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 # Create an instance of Presentation class

pres = self.Presentation

\# Get the first slide

sId = pres.getSlides().get_Item(0)

\# Add Video Frame

vf = sId.getShapes().addVideoFrame(50, 150, 300, 150, self.dataDir + "Wildlife.mp4")

\# Set Play Mode and Volume of the Video

videoPlayModePreset=self.VideoPlayModePreset

audioVolumeMode=self.AudioVolumeMode

vf.setPlayMode(videoPlayModePreset.Auto)

vf.setVolume(audioVolumeMode.Loud)

\# Write the presentation as a PPTX file

save_format = self.SaveFormat

pres.save(self.dataDir + "VideoFrame.pptx", save_format.Pptx)

print "Added video frame to slide, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)

---
title: Add Active X Controls in Python
type: docs
weight: 10
url: /java/add-active-x-controls-in-python/
---

## **Aspose.Slides - Add Active X Controls**
To Add Active X Controls using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Create an instance of Presentation class

pres = self.Presentation()

\# Adding the Media Player ActiveX control

controlType = self.ControlType

pres.getSlides().get_Item(0).getControls().addControl(controlType.WindowsMediaPlayer, 100, 100, 400, 400)

\# Access the Media Player ActiveX control and set the video path

pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL" ,  dataDir + "Wildlife.mp4")

\# Write the presentation as a PPTX file

saveFormat = SaveFormat

pres.save(dataDir + "AddActiveX.pptx", saveFormat.Pptx)

print "Added ActiveX control, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)

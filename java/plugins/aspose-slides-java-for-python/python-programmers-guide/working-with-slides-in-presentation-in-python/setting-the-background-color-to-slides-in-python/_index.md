---
title: Setting the Background Color to Slides in Python
type: docs
weight: 100
url: /java/setting-the-background-color-to-slides-in-python/
---

## **Aspose.Slides - Setting the Background Color to Slides**
To Set the Background Color to Slides using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 def set_background_color_of_master_slide(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation()

\# Set the background color of the Master Slide to Forest Green

backgroundType = self.BackgroundType

fillType = self.FillType

color = self.Color

pres.getMasters().get_Item(0).getBackground().setType(backgroundType.OwnBackground)

pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(fillType.Solid)

pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(color.GREEN)

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "MasterBG.pptx", save_format.Pptx)

print "Set background color of master slide, please check the output file."

def set_background_color_of_normal_slide(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation()

\# Set the background color of the Normal slide to Blue

backgroundType = self.BackgroundType

fillType = self.FillType

color = self.Color

pres.getSlides().get_Item(0).getBackground().setType(backgroundType.OwnBackground)

pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(fillType.Solid)

pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(color.BLUE)

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "ContentBG.pptx", save_format.Pptx)

print "Set background color of normal slide, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)

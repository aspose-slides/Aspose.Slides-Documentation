---
title: Setting the Label Distance From Category Axis in Ruby
type: docs
weight: 90
url: /java/setting-the-label-distance-from-category-axis-in-ruby/
---

## **Aspose.Slides - Setting the Label Distance From Category Axis**
To Set the Label Distance From Category Axis using **Aspose.Slides Java for Ruby**, simply invoke **SetLabelDistance** module. Here you can see example code.

**Ruby Code**

```

 data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



\# Instantiate Presentation class that represents the presentation file

pres = Rjb::import('com.aspose.slides.Presentation').new

\# Access first slide

sld = pres.getSlides().get_Item(0)

\# Adding a chart on slide

ch = sld.getShapes().addChart(Rjb::import('com.aspose.slides.ChartType').ClusteredColumn, 20, 20, 500, 300)

\# Setting the position of label from axis

ch.getAxes().getHorizontalAxis().setLabelOffset(500)

\# Saving the presentation

pres.save(data_dir + "Position.pptx", Rjb::import('com.aspose.slides.SaveFormat').Pptx)

puts "Set label distance, please check the output file."

```
## **Download Running Code**
Download **Setting the Label Distance From Category Axis (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Charts/setlabeldistance.rb)

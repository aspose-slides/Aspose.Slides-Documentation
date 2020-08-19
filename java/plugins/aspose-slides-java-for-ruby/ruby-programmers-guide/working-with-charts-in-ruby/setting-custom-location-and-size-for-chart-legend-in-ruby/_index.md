---
title: Setting Custom Location and Size for Chart Legend in Ruby
type: docs
weight: 70
url: /java/setting-custom-location-and-size-for-chart-legend-in-ruby/
---

## **Aspose.Slides - Setting Custom Location and Size for Chart Legend**
To Set Custom Location and Size for Chart Legend using **Aspose.Slides Java for Ruby**, call **set_location_and_size** method of **ChartLegend** module. Here you can see example code.

**Ruby Code**

```

 def set_location_and_size()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Creating empty presentation

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Get reference of the slide

    slide = pres.getSlides().get_Item(0)

    # Add a clustered column chart on the slide

    chart = slide.getShapes().addChart(Rjb::import('com.aspose.slides.ChartType').ClusteredColumn, 50, 50, 500, 500)

    # Set Legend Properties

    chart.getLegend().setX(50 / chart.getWidth())

    chart.getLegend().setY (50 / chart.getHeight())

    chart.getLegend().setWidth(100 / chart.getWidth())

    chart.getLegend().setHeight(100 / chart.getHeight())

    # Saving the presentation

    save_format = Rjb::import('com.aspose.slides.SaveFormat')

    pres.save(data_dir + "Legend.pptx", save_format.Pptx)

    puts "Set custom location and size of chart legend, please check the output file."       

end 

```
## **Download Running Code**
Download **Setting Custom Location and Size for Chart Legend (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Charts/chartlegend.rb)

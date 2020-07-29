---
title: Adding Chart Series Overlap for Charts in Ruby
type: docs
weight: 10
url: /java/adding-chart-series-overlap-for-charts-in-ruby/
---

## **Aspose.Slides - Adding Chart Series Overlap for Charts**
To Add Chart Series Overlap for Charts using **Aspose.Slides Java for Ruby**, call **add_overlap_for_chart** method of **ChartSeries** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def add_overlap_for_chart()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Adding chart

    chart = pres.getSlides().get_Item(0).getShapes().addChart(Rjb::import('com.aspose.slides.ChartType').ClusteredColumn, 50, 50, 600, 400, true)

    series = chart.getChartData().getSeries()

    if series.get_Item(0).getOverlap() == 0

       # Setting series overlap

       series.get_Item(0).getParentSeriesGroup().setOverlap(-30)

    end

    # Saving the presentation

    pres.save(data_dir + "Overlap.pptx", Rjb::import('com.aspose.slides.SaveFormat').Pptx)

    puts "Added chart series overlap for charts, please check the output file."

end   

{{< /highlight >}}
## **Download Running Code**
Download **Adding Chart Series Overlap for Charts (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Charts/chartseries.rb)

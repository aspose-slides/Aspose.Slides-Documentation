---
title: Managing Different Properties of Charts in Ruby
type: docs
weight: 60
url: /java/managing-different-properties-of-charts-in-ruby/
---

## **Aspose.Slides - Setting the RotationX, RotationY and DepthPercents properties of 3D Chart.**
To Set the RotationX, RotationY and DepthPercents properties of 3D Chart using **Aspose.Slides Java for Ruby**, call **set_rotation_and_depth** method of **ChartProperties** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def set_rotation_and_depth()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Access first slide

    sld = pres.getSlides().get_Item(0)

    # Add chart with default data

    chart = sld.getShapes().addChart(Rjb::import('com.aspose.slides.ChartType').StackedColumn3D, 0, 0, 500, 500)

    # Getting the chart data worksheet

    fact = chart.getChartData().getChartDataWorkbook()

    # Delete default generated series and categories

    chart.getChartData().getSeries().clear()

    chart.getChartData().getCategories().clear()

    # Adding new series

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType())

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType())

    # Adding new categories

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Caetegoty 1"))

    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "Caetegoty 2"))

    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "Caetegoty 3"))

    # Set Rotation3D properties

    chart.getRotation3D().setRightAngleAxes(true)

    chart.getRotation3D().setRotationX(40)

    chart.getRotation3D().setRotationY(270)

    chart.getRotation3D().setDepthPercents(150)

    # Take first chart series

    series = chart.getChartData().getSeries().get_Item(0)

    # Populating series data

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 1, 1, 20))

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 2, 1, 50))

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 3, 1, 30))

    # Take second chart series

    series = chart.getChartData().getSeries().get_Item(1)

    # Populating series data

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 1, 2, 30))

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 2, 2, 10))

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 3, 2, 60))

    # Saving the presentation

    pres.save(data_dir + "3Drotation.pptx", Rjb::import('com.aspose.slides.SaveFormat').Pptx)

    puts "Done with rotation, please check the output file."

end   

{{< /highlight >}}
## **Aspose.Slides - Setting the GapWidth property of Chart Series**
To Set the GapWidth property of Chart Series using **Aspose.Slides Java for Ruby**, call **set_gapwidth** method of **ChartProperties** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 def set_gapwidth()

    data_dir = File.dirname(File.dirname(File.dirname(File.dirname(__FILE__)))) + '/data/'



    # Instantiate Presentation class that represents the presentation file

    pres = Rjb::import('com.aspose.slides.Presentation').new

    # Access first slide

    sld = pres.getSlides().get_Item(0)

    # Add chart with default data

    chart = sld.getShapes().addChart(Rjb::import('com.aspose.slides.ChartType').StackedColumn3D, 0, 0, 500, 500)

    # Getting the chart data worksheet

    fact = chart.getChartData().getChartDataWorkbook()

    # Delete default generated series and categories

    chart.getChartData().getSeries().clear()

    chart.getChartData().getCategories().clear()

    # Adding new series

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType())

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType())

    # Adding new categories

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Caetegoty 1"))

    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "Caetegoty 2"))

    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "Caetegoty 3"))

    # Take first chart series

    series = chart.getChartData().getSeries().get_Item(0)

    # Populating series data

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 1, 1, 20))

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 2, 1, 50))

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 3, 1, 30))

    # Take second chart series

    series = chart.getChartData().getSeries().get_Item(1)

    # Populating series data

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 1, 2, 30))

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 2, 2, 10))

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(0, 3, 2, 60))

    # Set GapWidth value

    series.getParentSeriesGroup().setGapWidth(75)

    # Saving the presentation

    pres.save(data_dir + "SetGapWidth.pptx", Rjb::import('com.aspose.slides.SaveFormat').Pptx)

    puts "Set Gapwidth property of chart series, please check the output file."

end   

{{< /highlight >}}
## **Download Running Code**
Download **Managing Different Properties of Charts (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_Ruby/lib/asposeslidesjava/Charts/chartproperties.rb)

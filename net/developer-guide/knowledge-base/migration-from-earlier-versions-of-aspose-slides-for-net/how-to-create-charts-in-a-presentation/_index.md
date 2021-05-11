---
title: How to Create Charts in a Presentation
type: docs
weight: 30
url: /net/how-to-create-charts-in-a-presentation/
---

{{% alert color="primary" %}} 

A new [Aspose.Slides for .NET API](/slides/net/) has been released and now this single product supports the capability to generate PowerPoint documents from scratch and editing the existing ones.

{{% /alert %}} 
## **Support for Legacy code**
In order to use the legacy code developed with Aspose.Slides for .NET versions earlier to 13.x, you need to make some minor changes in your code and the code will work as earlier. All the classes that were present in old Aspose.Slides for .NET under Aspose.Slide and Aspose.Slides.Pptx namespaces are now merged in single Aspose.Slides namespace. Please take a look over the following simple code snippet for creating a normal chart from scratch in presentation using legacy Aspose.Slides API and follow the steps describing how to migrate to new merged API.
## **Legacy Aspose.Slides for .NET approach**
```c#
 //Instantiate PresentationEx class that represents PPTX file
            using (PresentationEx pres = new PresentationEx())
            {

                //Access first slide
                SlideEx sld = pres.Slides[0];

                // Add chart with default data
                ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

                //Setting chart Title
                chart.ChartTitle.Text.Text = "Sample Title";
                chart.ChartTitle.Text.CenterText = true;
                chart.ChartTitle.Height = 20;
                chart.HasTitle = true;

                //Set first series to Show Values
                chart.ChartData.Series[0].Labels.ShowValue = true;

                //Setting the index of chart data sheet 
                int defaultWorksheetIndex = 0;

                //Getting the chart data worksheet
                ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

                //Delete default generated series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();
                int s = chart.ChartData.Series.Count;
                s = chart.ChartData.Categories.Count;

                //Adding new series
                chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

                //Adding new categories
                chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
                chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
                chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

                //Take first chart series
                ChartSeriesEx series = chart.ChartData.Series[0];

                //Now populating series data
                series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
                series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
                series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

                //Setting fill color for series
                series.Format.Fill.FillType = FillTypeEx.Solid;
                series.Format.Fill.SolidFillColor.Color = Color.Red;


                //Take second chart series
                series = chart.ChartData.Series[1];

                //Now populating series data
                series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
                series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
                series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

                //Setting fill color for series
                series.Format.Fill.FillType = FillTypeEx.Solid;
                series.Format.Fill.SolidFillColor.Color = Color.Green;


                //create custom labels for each of categories for new series

                //first label will be show Category name
                DataLabelEx lbl = new DataLabelEx(series);
                lbl.ShowCategoryName = true;
                lbl.Id = 0;
                series.Labels.Add(lbl);

                //Show series name for second label
                lbl = new DataLabelEx(series);
                lbl.ShowSeriesName = true;
                lbl.Id = 1;
                series.Labels.Add(lbl);

                //Show value for third label
                lbl = new DataLabelEx(series);
                lbl.ShowValue = true;
                lbl.ShowSeriesName = true;
                lbl.Separator = "/";
                lbl.Id = 2;
                series.Labels.Add(lbl);

                //Show value and custom text
                lbl = new DataLabelEx(series);
                lbl.TextFrame.Text = "My text";
                lbl.Id = 3;
                series.Labels.Add(lbl);

                //Save presentation with chart
                pres.Write(@"D:\AsposeChart.pptx");
            }
```



## **New Aspose.Slides for .NET 13.x approach**
```c#
//Instantiate Presentation class that represents PPTX file//Instantiate Presentation class that represents PPTX file
            Presentation pres = new Presentation();

            //Access first slide
            ISlide sld = pres.Slides[0];

            // Add chart with default data
            IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

            //Setting chart Title
            //chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
            chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
            chart.ChartTitle.Height = 20;
            chart.HasTitle = true;

            //Set first series to Show Values
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            //Setting the index of chart data sheet
            int defaultWorksheetIndex = 0;

            //Getting the chart data worksheet
            IChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

            //Delete default generated series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();
            int s = chart.ChartData.Series.Count;
            s = chart.ChartData.Categories.Count;

            //Adding new series
            chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

            //Adding new categories
            chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
            chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
            chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

            //Take first chart series
            IChartSeries series = chart.ChartData.Series[0];

            //Now populating series data

            series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
            series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

            //Setting fill color for series
            series.Format.Fill.FillType = FillType.Solid;
            series.Format.Fill.SolidFillColor.Color = Color.Red;


            //Take second chart series
            series = chart.ChartData.Series[1];

            //Now populating series data
            series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
            series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

            //Setting fill color for series
            series.Format.Fill.FillType = FillType.Solid;
            series.Format.Fill.SolidFillColor.Color = Color.Green;


            //create custom labels for each of categories for new series

            //first label will be show Category name
            IDataLabel lbl = series.DataPoints[0].Label;
            lbl.DataLabelFormat.ShowCategoryName = true;

            lbl = series.DataPoints[1].Label;
            lbl.DataLabelFormat.ShowSeriesName = true;

            //Show value for third label
            lbl = series.DataPoints[2].Label;
            lbl.DataLabelFormat.ShowValue = true;
            lbl.DataLabelFormat.ShowSeriesName = true;
            lbl.DataLabelFormat.Separator = "/";

            //Save presentation with chart
            pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Please take a look over the following simple code snippet for creating a scatterd chart from scratch in presentation using legacy Aspose.Slides API and how to achieve it with new merged API.

## **Legacy Aspose.Slides for .NET approach**
```c#
using (PresentationEx pres = new PresentationEx())
{

    SlideEx slide = pres.Slides[0];

    //Creating the default chart
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Getting the default chart data worksheet index
    int defaultWorksheetIndex = 0;

    //Accessing the chart data worksheet
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Delete demo series
    chart.ChartData.Series.Clear();

    //Add new series
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Take first chart series
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Add new point (1:3) there.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Add new point (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Edit the type of series
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Changing the chart series marker
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Take second chart series
    series = chart.ChartData.Series[1];

    //Add new point (5:2) there.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Add new point (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Add new point (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Add new point (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Changing the chart series marker
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **New Aspose.Slides for .NET 13.x approach**
```c#
 Presentation pres = new Presentation();

            ISlide slide = pres.Slides[0];

            //Creating the default chart
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

            //Getting the default chart data worksheet index
            int defaultWorksheetIndex = 0;

            //Accessing the chart data worksheet
            IChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

            //Delete demo series
            chart.ChartData.Series.Clear();

            //Add new series
            chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

            //Take first chart series
            IChartSeries series = chart.ChartData.Series[0];

            //Add new point (1:3) there.
            series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

            //Add new point (2:10)
            series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

            //Edit the type of series
            series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

            //Changing the chart series marker
            series.Marker.Size = 10;
            series.Marker.Symbol = MarkerStyleType.Star;

            //Take second chart series
            series = chart.ChartData.Series[1];

            //Add new point (5:2) there.
            series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

            //Add new point (3:1)
            series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

            //Add new point (2:2)
            series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

            //Add new point (5:1)
            series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

            //Changing the chart series marker
            series.Marker.Size = 10;
            series.Marker.Symbol = MarkerStyleType.Circle;

            pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```


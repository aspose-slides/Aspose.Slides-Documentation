---
title: Formatting Chart Entities in PHP
type: docs
weight: 50
url: /java/formatting-chart-entities-in-php/
---

## **Aspose.Slides - Formatting Chart Entities**
To Format Chart Entities using **Aspose.Slides Java for PHP**, simply invoke **FormattingChartEntities** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 # Instantiate Presentation class that represents the presentation file

$pres = new Presentation();

\# Accessing the first slide

$slide = $pres->getSlides()->get_Item(0);

\# Adding the sample chart

$chartType=new ChartType();

$chart = $slide->getShapes()->addChart($chartType->LineWithMarkers, 50, 50, 500, 400);

\# Setting Chart Titile

$chart.hasTitle(true);

$chart->getChartTitle()->addTextFrameForOverriding("");

$chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

$chartTitle->setText("Sample Chart");

$fillType=new FillType();

$color=new Color();

$nullableBool=new NullableBool();

$lineDashStyle=new LineDashStyle();

$chartTitle->getPortionFormat()->getFillFormat()->setFillType($fillType->Solid);

$chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($color->GRAY);

$chartTitle->getPortionFormat()->setFontHeight (20);

$chartTitle->getPortionFormat()->setFontBold($nullableBool->True);

$chartTitle->getPortionFormat()->setFontItalic($nullableBool->True);

\# Setting Major grid lines format for value axis

$chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType($fillType->Solid);

$chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color->BLUE);

$chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);

$chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle($lineDashStyle->DashDot);

\# Setting Minor grid lines format for value axis

$chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType($fillType->Solid);

$chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color->RED);

$chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

\# Setting value axis number format

$displayUnitType=new DisplayUnitType();

$chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource(false);

$chart->getAxes()->getVerticalAxis()->setDisplayUnit($displayUnitType->Thousands);

$chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");

\# Setting chart maximum, minimum values

$chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit(false);

$chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue(false);

$chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit(false);

$chart->getAxes()->getVerticalAxis()->isAutomaticMinValue(false);

$chart->getAxes()->getVerticalAxis()->setMaxValue(15);

$chart->getAxes()->getVerticalAxis()->setMinValue(-2);

$chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);

$chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);

\# Setting Value Axis Text Properties

$fontData=new FontData();

$presetColor=new PresetColor();

$txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();

$txtVal->setFontBold($nullableBool->True);

$txtVal->setFontHeight(16);

$txtVal->setFontItalic($nullableBool->True);

$txtVal->getFillFormat()->setFillType($fillType->Solid);

$txtVal->getFillFormat()->getSolidFillColor()->setColor(new Color($presetColor->DarkGreen));

$txtVal.setLatinFont(new FontData("Times New Roman"));

\# Setting value axis title

$chart->getAxes()->getVerticalAxis()->hasTitle(true);

$chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");

$valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

$valtitle->setText("Primary Axis");

$valtitle->getPortionFormat()->getFillFormat()->setFillType($fillType->Solid);

$valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($color->GRAY);

$valtitle->getPortionFormat()->setFontHeight(20);

$valtitle->getPortionFormat()->setFontBold($nullableBool->True);

$valtitle->getPortionFormat()->setFontItalic($nullableBool->True);

\# Setting Major grid lines format for Category axis

$chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType($fillType->Solid);

$chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color->GREEN);

$chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);

\# Setting Minor grid lines format for Category axis

$chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType($fillType->Solid);

$chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color->YELLOW);

$chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

#Setting Category Axis Text Properties

$txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();

$txtCat->setFontBold($nullableBool->True);

$txtCat->setFontHeight(16);

$txtCat->setFontItalic($nullableBool->True);

$txtCat->getFillFormat()->setFillType($fillType->Solid);

$txtCat->getFillFormat()->getSolidFillColor()->setColor($color->BLUE);

$txtCat.setLatinFont(new FontData("Arial"));

\# Setting Category Titile

$chart->getAxes()->getHorizontalAxis()->hasTitle(true);

$chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");

$catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

$catTitle->setText("Sample Category");

$catTitle->getPortionFormat()->getFillFormat()->setFillType($fillType->Solid);

$catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($color->GRAY);

$catTitle->getPortionFormat()->setFontHeight(20);

$catTitle->getPortionFormat()->setFontBold($nullableBool->True);

$catTitle->getPortionFormat()->setFontItalic($nullableBool->True);

\# Setting category axis lable position

$chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(Rjb::import('com.aspose.slides.TickLabelPositionType').Low);

\# Setting category axis lable rotation angle

$chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);

\# Setting Legends Text Properties

$txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();

$txtleg->setFontBold($nullableBool->True);

$txtleg->setFontHeight(16);

$txtleg->setFontItalic($nullableBool->True);

$txtleg->getFillFormat()->setFillType($fillType->Solid);

$txtleg->getFillFormat()->getSolidFillColor()->setColor(new Color($presetColor->DarkRed));

\# Set show chart legends without overlapping chart

$chart->getLegend().setOverlay(true);

#chart.ChartData.Series[0].PlotOnSecondAxis=true;

$chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);

\# Setting secondary value axis

$chart->getAxes()->getSecondaryVerticalAxis()->isVisible(true);

$chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(Rjb::import('com.aspose.slides.LineStyle').ThickBetweenThin);

$chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);

\# Setting secondary value axis Number format

$chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource(false);

$chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(Rjb::import('com.aspose.slides.DisplayUnitType').Hundreds);

$chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat ("0.0%");

\# Setting chart maximum, minimum values

$chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit(false);

$chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue(false);

$chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit(false);

$chart->getAxes()->getSecondaryVerticalAxis().isAutomaticMinValue(false);

$chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20);

$chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5);

$chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);

$chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);


\# Setting chart back wall color

$chart->getBackWall()->setThickness(1);

$chart->getBackWall()->getFormat()->getFill()->setFillType($fillType->Solid);

$chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor($color->ORANGE);

$chart->getFloor()->getFormat()->getFill()->setFillType($fillType->Solid);

$chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor($color->RED);

\# Setting Plot area color

$chart->getPlotArea()->getFormat()->getFill()->setFillType($fillType->Solid);

$chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new Color($presetColor->LightCyan));

\# Save Presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "FormattedChart.pptx", $save_format->Pptx);

print "Formatted chart entities, please check the output file.".PHP_EOL;

{{< /highlight >}}
## **Download Running Code**
Download **Formatting Chart Entities (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithCharts/FormattingChartEntities.php)

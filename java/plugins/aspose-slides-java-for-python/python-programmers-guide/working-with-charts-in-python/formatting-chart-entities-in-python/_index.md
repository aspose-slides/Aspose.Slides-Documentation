---
title: Formatting Chart Entities in Python
type: docs
weight: 50
url: /java/formatting-chart-entities-in-python/
---

## **Aspose.Slides - Formatting Chart Entities**
To Format Chart Entities using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Instantiate Presentation class that represents the presentation file

pres = self.Presentation()

\# Accessing the first slide

slide = pres.getSlides().get_Item(0)

\# Adding the sample chart

chartType=self.ChartType

chart = slide.getShapes().addChart(chartType.LineWithMarkers, 50, 50, 500, 400)

\# Setting Chart Titile

chart.hasTitle(True)

chart.getChartTitle().addTextFrameForOverriding("")

chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)

chartTitle.setText("Sample Chart")

fillType=self.FillType()

color=self.Color()

nullableBool=self.NullableBool()

lineDashStyle=self.LineDashStyle()

chartTitle.getPortionFormat().getFillFormat().setFillType(fillType.Solid)

chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(color.GRAY)

chartTitle.getPortionFormat().setFontHeight (20)

chartTitle.getPortionFormat().setFontBold(nullableBool.True)

chartTitle.getPortionFormat().setFontItalic(nullableBool.True)

\# Setting Major grid lines format for value axis

chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(fillType.Solid)

chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(color.BLUE)

chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(lineDashStyle.DashDot)

\# Setting Minor grid lines format for value axis

chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(fillType.Solid)

chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(color.RED)

chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

\# Setting value axis number format

displayUnitType=self.DisplayUnitType()

chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource(False)

chart.getAxes().getVerticalAxis().setDisplayUnit(displayUnitType.Thousands)

chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

\# Setting chart maximum, minimum values

chart.getAxes().getVerticalAxis().isAutomaticMajorUnit(False)

chart.getAxes().getVerticalAxis().isAutomaticMaxValue(False)

chart.getAxes().getVerticalAxis().isAutomaticMinorUnit(False)

chart.getAxes().getVerticalAxis().isAutomaticMinValue(False)

chart.getAxes().getVerticalAxis().setMaxValue(15)

chart.getAxes().getVerticalAxis().setMinValue(-2)

chart.getAxes().getVerticalAxis().setMinorUnit(0.5)

chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

\# Setting Value Axis Text Properties

fontData=self.FontData()

presetColor=self.PresetColor()

txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()

txtVal.setFontBold(nullableBool.True)

txtVal.setFontHeight(16)

txtVal.setFontItalic(nullableBool.True)

txtVal.getFillFormat().setFillType(fillType.Solid)

txtVal.getFillFormat().getSolidFillColor().setColor(self.Color(presetColor.DarkGreen))

txtVal.setLatinFont(self.FontData("Times self.Roman"))

\# Setting value axis title

chart.getAxes().getVerticalAxis().hasTitle(True)

chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")

valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)

valtitle.setText("Primary Axis")

valtitle.getPortionFormat().getFillFormat().setFillType(fillType.Solid)

valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(color.GRAY)

valtitle.getPortionFormat().setFontHeight(20)

valtitle.getPortionFormat().setFontBold(nullableBool.True)

valtitle.getPortionFormat().setFontItalic(nullableBool.True)

\# Setting Major grid lines format for Category axis

chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(fillType.Solid)

chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(color.GREEN)

chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

\# Setting Minor grid lines format for Category axis

chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(fillType.Solid)

chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(color.YELLOW)

chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

#Setting Category Axis Text Properties

txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()

txtCat.setFontBold(nullableBool.True)

txtCat.setFontHeight(16)

txtCat.setFontItalic(nullableBool.True)

txtCat.getFillFormat().setFillType(fillType.Solid)

txtCat.getFillFormat().getSolidFillColor().setColor(color.BLUE)

txtCat.setLatinFont(self.FontData("Arial"))

\# Setting Category Titile

chart.getAxes().getHorizontalAxis().hasTitle(True)

chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)

catTitle.setText("Sample Category")

catTitle.getPortionFormat().getFillFormat().setFillType(fillType.Solid)

catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(color.GRAY)

catTitle.getPortionFormat().setFontHeight(20)

catTitle.getPortionFormat().setFontBold(nullableBool.True)

catTitle.getPortionFormat().setFontItalic(nullableBool.True)

\# Setting category axis lable position

tickLabelPositionType = self.TickLabelPositionType()

chart.getAxes().getHorizontalAxis().setTickLabelPosition(tickLabelPositionType.Low)

\# Setting category axis lable rotation angle

chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

\# Setting Legends Text Properties

txtleg = chart.getLegend().getTextFormat().getPortionFormat()

txtleg.setFontBold(nullableBool.True)

txtleg.setFontHeight(16)

txtleg.setFontItalic(nullableBool.True)

txtleg.getFillFormat().setFillType(fillType.Solid)

txtleg.getFillFormat().getSolidFillColor().setColor(self.Color(presetColor.DarkRed))

\# Set show chart legends without overlapping chart

chart.getLegend().setOverlay(True)

#chart.ChartData.Series[0].PlotOnSecondAxis=True

chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)

\# Setting secondary value axis

lineStyle = self.LineStyle()

chart.getAxes().getSecondaryVerticalAxis().isVisible(True)

chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(lineStyle.ThickBetweenThin)

chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

\# Setting secondary value axis Number format

chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource(False)

displayUnitType=self.DisplayUnitType()

chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(displayUnitType.Hundreds)

chart.getAxes().getSecondaryVerticalAxis().setNumberFormat ("0.0%")

\# Setting chart maximum, minimum values

chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit(False)

chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue(False)

chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit(False)

chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue(False)

chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)

chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)

chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)

chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)


\# Setting chart back wall color

chart.getBackWall().setThickness(1)

chart.getBackWall().getFormat().getFill().setFillType(fillType.Solid)

chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(color.ORANGE)

chart.getFloor().getFormat().getFill().setFillType(fillType.Solid)

chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(color.RED)

\# Setting Plot area color

chart.getPlotArea().getFormat().getFill().setFillType(fillType.Solid)

chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(self.Color(presetColor.LightCyan))

\# Save Presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "FormattedChart.pptx", save_format.Pptx)

print "Formatted chart entities, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)

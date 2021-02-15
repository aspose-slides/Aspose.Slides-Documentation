---
title: Chart Formatting
type: docs
weight: 60
url: /java/chart-formatting/
---

## **Chart Entities Formatting**
Aspose.Slides for Java provides a simple API for managing different chart entities and formatting them using custom values:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (in this example we will use [ChartType.LineWithMarkers](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/ChartType)).
1. Access the chart Value Axis and set the following properties:
   1. Setting **Line format** for Value Axis Major Grid lines
   1. Setting **Line format** for Value Axis Minor Grid lines
   1. Setting **Number Format** for Value Axis
   1. Setting **Min, Max, Major and Minor units** for Value Axis
   1. Setting **Text Properties** for Value Axis data
   1. Setting **Title** for Value Axis
   1. Setting **Line Format** for Value Axis
1. Access the chart Category Axis and set the following properties:
   1. Setting **Line format** for Category Axis Major Grid lines
   1. Setting **Line format** for Category Axis Minor Grid lines
   1. Setting **Text Properties** for Category Axis data
   1. Setting **Title** for Category Axis
   1. Setting **Label Positioning** for Category Axis
   1. Setting **Rotation Angle** for Category Axis labels
1. Access the chart Legend and set the **Text Properties** for them
1. Set show chart Legends without overlapping chart
1. Access the chart **Secondary Value Axis** and set the following properties:
   1. Enable the Secondary **Value Axis**
   1. Setting **Line Format** for Secondary Value Axis
   1. Setting **Number Format** for Secondary Value Axis
   1. Setting **Min, Max, Major and Minor units** for Secondary Value Axis
1. Now plot the first chart series on Secondary Value Axis
1. Set the chart back wall fill color
1. Set the chart plot area fill color
1. Write the modified presentation to a PPTX file

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-FormattingChartEntities-FormattingChartEntities.java" >}}

The above code snipped will create a chart like the one shown below.

|![todo:image_alt_text](http://i.imgur.com/77YNJSx.png)|
| :- |
|**Figure: Formatted chart added to the slide**|


## **Set Font Properties for Chart**
 Aspose.Slides for Java provides support for setting the font related properties for the chart. Please follow the steps below for setting the font properties for chart. 

- Instantiate Presentation class object.
- Add chart on the slide.
- Set font height.
- Save modified presentation.

 Below sample example is given.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-FontPropertiesForChart-FontPropertiesForChart.java" >}}


## **Set Font Properties for Chart Data Table**
Aspose.Slides for Java provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. set chart table.
1. Set font height.
1. Save modified presentation.

 Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingFontPropertiesForTable-SettingFontPropertiesForTable.java" >}}



## **Set Number Format for Chart Data Cell**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers to set chart data cell number. This article explains how to set the chart data number format and possible options.

{{% /alert %}} 

Aspose.Slides for Java provides a simple API for managing chart data format:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses [ChartType.ClusteredColumn](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/ChartType)).
1. Set the preset number format from the possible preset values.
1. Traverse through the chart data cell in every chart series and set the chart data number format.
1. Save the presentation.
1. Set the custom number format.
1. Traverse through chart data cell inside every chart series and setting a different chart data number format.
1. Save the presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingNumberFormatForChartDataCell-SettingNumberFormatForChartDataCell.java" >}}

The above code snippet create a chart like the one shown below.

|![todo:image_alt_text](http://i.imgur.com/I3g8af5.png)|
| :- |
|**Figure: Sample chart with different number formats**|


| |**The possible preset number format values along with their preset index and that can be used are given below:**|
| :- | :- |

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |



## **Set Chart Rounded Borders**
Aspose.Slides for Java provides support for setting chart area. **IChart.HasRoundedCorners** and **Chart.HasRoundedCorners** properties have been added in Aspose.Slides. 

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. Set fill type and fill color of chart
1. Set round corner property True.
1. Save modified presentation.

 Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SupportForChartAreaRoundedBorders-SupportForChartAreaRoundedBorders.java" >}}





## **Get Chart Image**
Aspose.Slides for Java provides support for extracting image of specific chart. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-GetChartImage-GetChartImage.java" >}}

## **Hide Information from Chart**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for Java you can hide **Title, Vertical Axis, Horizontal Axis, Legend** and **Grid Lines** from chart. Below code example shows how to use these properties.


{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-HideInformationFromChart-HideInformationFromChart.java" >}}



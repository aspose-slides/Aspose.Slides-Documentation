---
title: Update Chart
type: docs
weight: 10
url: /java/update-chart/
---

## **Update Chart**
{{% alert color="primary" %}} 

Aspose.Slides for Java facilitates developers to update charts generated through Aspose.Slides or MS PowerPoint. This topic explains how developers can modify existing charts in slides using Aspose.Slides for Java.

{{% /alert %}} 

Please follow the steps below to update a chart in a slide:

- Open an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class containing chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find desired chart.
- Access the chart data worksheet.
- Modify the chart data series data by changing series values.
- Adding a new series and populating data inside it.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-UpdatingExistingChart-UpdatingExistingChart.java" >}}

|![todo:image_alt_text](http://i.imgur.com/900NBmE.png)|
| :- |
|**Figure: Chart in source presentation**|
The above code snippet modified the chart in the source presentation as shown below:

|![todo:image_alt_text](http://i.imgur.com/ZQ7K3dn.png)|
| :- |
|**Figure: Modified Chart**|

## **Set Data Range for Chart**
Please follow the steps below to update a chart in a slide:

- Open an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class containing chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find the desired chart.
- Access the chart data and set the range
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SetDataRangeForChart-SetDataRangeForChart.java" >}}


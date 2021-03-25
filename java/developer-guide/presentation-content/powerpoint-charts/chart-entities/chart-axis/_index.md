---
title: Chart Axis
type: docs
url: /java/chart-axis/
---

## **Set Type of Axis**
New methods **getCategoryAxisType()** and **setCategoryAxisType()** have been added to [IAxis](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IAxis) and [Axis](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Axis) classes. Below are the properties to determine category axis type.

- CategoryAxisType.Text - category axis type is Text
- CategoryAxisType.Date - category axis type is DateTime
  However, the CategoryAxisType.Auto is not supported at the moment.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ChangeTypeOfChartsCategoryAxis-ChangeTypeOfChartsCategoryAxis.java" >}}


## **Set Date Format of Axis**
Aspose.Slides for Java provides a simple API for setting date format for category axis value. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingDateFormatForCategoryAxis-SettingDateFormatForCategoryAxis.java" >}}


## **Set Unit Label of Axis**
Aspose.Slides for Java provides support for showing Display unit label on chart value axis. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ShowingDisplayUnitLabel-ShowingDisplayUnitLabel.java" >}}


## **Set Position of Axis**
Aspose.Slides for Java provides a simple API for setting Position axis in category or Value axis. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingPositionAxis-SettingPositionAxis.java" >}}

## **Set Rotation Angle of Axis Title**
Aspose.Slides for Java provides a simple API for setting rotation angle for chart axis title. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingRotationAngle-SettingRotationAngle.java" >}}

## **Get Actual Max Value of Vertical Axis**
Aspose.Slides for Java provides a simple API for getting value of vertical axis. 

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Get actual maximum value on the axis.
1. Get actual minimum value on the axis.
1. Get actual major unit of the axis.
1. Get actual minor unit of the axis.
1. Get actual major unit scale of the axis.
1. Get actual minor unit scale of the axis.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-GetValuesAndUnitScaleFromAxis-GetValuesAndUnitScaleFromAxis.java" >}}

## **Switch Data Over Axis**
A new property has been added which Swap the data over the axis. Data being charted on the X axis will move to the Y axis and vice versa. Below sample example is given.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SwitchChartRowColumns-SwitchChartRowColumns.java" >}}

---
title: Chart Axis
type: docs
url: /cpp/chart-axis/
---

## **Get Actual Max Value of Vertical Axis**
Aspose.Slides for C++ provides a simple API for getting value of vertical axis. 

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Get actual maximum value on the axis.
1. Get actual minimum value on the axis.
1. Get actual major unit of the axis.
1. Get actual minor unit of the axis.
1. Get actual major unit scale of the axis.
1. Get actual minor unit scale of the axis.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Charts-GetValuesAndUnitScaleFromAxis-GetValuesAndUnitScaleFromAxis.cs" >}}


## **Switch Data over Axis**
A new property has been added which Swap the data over the axis. Data being charted on the X axis will move to the Y axis and vice versa. Below sample example is given.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SwitchChartRowColumns-SwitchChartRowColumns.cpp" >}}


## **Change Category of Axis**
**CategoryAxisType** can be changed to Date or Text.However, **CategoryAxisType.Auto** is not supported at the moment. New property **CategoryAxisType** has been added to **IAxis** and Axis classes which specifies type of category axis.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeChartCategoryAxis-ChangeChartCategoryAxis.cpp" >}}


## **Set Date Format of Axis**
Aspose.Slides for C++ provides a simple API for setting date format for category axis value. Below sample example is given.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DateFormatForCategoryAxis-DateFormatForCategoryAxis.cpp" >}}

## **Set Unit Label of Axis**
Aspose.Slides for C++ provides support for showing Display unit label on chart value axis. Below sample example is given. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ShowDisplayUnitLabelOnChartValueAxis-ShowDisplayUnitLabelOnChartValueAxis.cpp" >}}

## **Set Position of Axis**
Aspose.Slides for C++ provides a simple API for setting Position axis in category or Value axis. Below sample example is given. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingPositionAxis-SettingPositionAxis.cpp" >}}

## **Set Rotation Angle of Axis Title**
Aspose.Slides for C++ provides a simple API for setting rotation angle for chart axis title. Below sample example is given.  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-VerticalAxisRotationAngle-VerticalAxisRotationAngle.cpp" >}}



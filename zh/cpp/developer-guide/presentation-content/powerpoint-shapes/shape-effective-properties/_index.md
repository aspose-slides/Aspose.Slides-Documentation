---
title: 形状有效属性
type: docs
weight: 50
url: /cpp/shape-effective-properties/
---

在本主题中，我们将讨论 **有效** 和 **本地** 属性。当我们在这些层次上直接设置值时

1. 在部分属性的部分幻灯片上。
1. 在布局或母版幻灯片上的原型形状文本样式中（如果部分的文本框形状有一个）。
1. 在演示文稿全局文本设置中。

那么这些值被称为 **本地** 值。在任何层次上，**本地** 值可以被定义或省略。但是最终当应用程序需要知道部分应该呈现为何种样子时，它使用 **有效** 值。您可以通过使用 **GetEffective()** 方法从本地格式获取有效值。

以下示例展示了如何获取有效值。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}

## **获取相机的有效属性**
Aspose.Slides for C++ 允许开发人员获取相机的有效属性。为此，Aspose.Slides 中添加了 **CameraEffectiveData** 类。CameraEffectiveData 类代表一个不可变对象，包含有效的相机属性。**CameraEffectiveData** 类的一个实例被用作 **ThreeDFormatEffectiveData** 类的一部分，该类是 ThreeDFormat 类的有效值对。

以下代码示例展示了如何获取相机的有效属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **获取灯光设备的有效属性**
Aspose.Slides for C++ 允许开发人员获取灯光设备的有效属性。为此，Aspose.Slides 中添加了 **LightRigEffectiveData** 类。LightRigEffectiveData 类代表一个不可变对象，包含有效的灯光设备属性。**LightRigEffectiveData** 类的一个实例被用作 **ThreeDFormatEffectiveData** 类的一部分，该类是 ThreeDFormat 类的有效值对。

以下代码示例展示了如何获取灯光设备的有效属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **获取斜切形状的有效属性**
Aspose.Slides for C++ 允许开发人员获取斜切形状的有效属性。为此，Aspose.Slides 中添加了 **ShapeBevelEffectiveData** 类。ShapeBevelEffectiveData 类代表一个不可变对象，包含有效形状的面浮雕属性。**ShapeBevelEffectiveData** 类的一个实例被用作 **ThreeDFormatEffectiveData** 类的一部分，该类是 ThreeDFormat 类的有效值对。

以下代码示例展示了如何获取斜切形状的有效属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **获取文本框的有效属性**
使用 Aspose.Slides for C++，您可以获取文本框的有效属性。为此，Aspose.Slides 中添加了 **TextFrameFormatEffectiveData** 类，该类包含有效的文本框格式属性。

以下代码示例展示了如何获取有效的文本框格式属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **获取文本样式的有效属性**
使用 Aspose.Slides for C++，您可以获取文本样式的有效属性。为此，Aspose.Slides 中添加了 **TextStyleEffectiveData** 类，该类包含有效的文本样式属性。

以下代码示例展示了如何获取有效的文本样式属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **获取有效的字体高度值**
使用 Aspose.Slides for C++，您可以获取字体高度的有效属性。以下是代码示例，演示在不同演示文稿结构层次设置本地字体高度值后，部分的有效字体高度值发生了改变。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **获取表格的有效填充格式**
使用 Aspose.Slides for C++，您可以获取不同表格逻辑部分的有效填充格式。为此，Aspose.Slides 中添加了 **IFillFormatEffectiveData** 接口，该接口包含有效的填充格式属性。请注意，单元格格式始终优先于行格式，行的优先级高于列，列的优先级高于整个表格。

因此，**CellFormatEffectiveData** 属性始终用于绘制表格。以下代码示例展示了如何获取不同表格逻辑部分的有效填充格式。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}
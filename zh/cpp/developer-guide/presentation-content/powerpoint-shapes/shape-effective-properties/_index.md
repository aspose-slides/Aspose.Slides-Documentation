---
title: 在 C++ 中从演示文稿获取形状的有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/cpp/shape-effective-properties/
keywords:
- 形状属性
- 相机属性
- 灯光装置
- 斜面形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何计算并应用形状有效属性，以实现精确的 PowerPoint 渲染。"
---

在本主题中，我们将讨论 **effective**（有效）和 **local**（本地）属性。当我们在以下层级直接设置值时

1. 在部分所在幻灯片上的部分属性。
1. 在布局或母版幻灯片上的原型形状文本样式（如果该部分的文本框形状拥有）。
1. 在演示文稿的全局文本设置中。

这些值称为 **local**（本地）值。 在任何层级，都可以定义或省略 **local** 值。 但最终当程序需要知道该部分应呈现的外观时，会使用 **effective**（有效）值。 可以通过从本地格式调用 **GetEffective()** 方法来获取有效值。

下面的示例展示了如何获取有效值。



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}


## **获取相机的有效属性**
Aspose.Slides for C++ 允许开发人员获取相机的有效属性。 为此，在 Aspose.Slides 中添加了 **CameraEffectiveData** 类。CameraEffectiveData 类表示一个不可变对象，包含有效的相机属性。**CameraEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 ThreeDFormat 类的有效值对。

下面的代码示例展示了如何获取相机的有效属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **获取灯光装置的有效属性**
Aspose.Slides for C++ 允许开发人员获取灯光装置（Light Rig）的有效属性。 为此，在 Aspose.Slides 中添加了 **LightRigEffectiveData** 类。LightRigEffectiveData 类表示一个不可变对象，包含有效的灯光装置属性。**LightRigEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 ThreeDFormat 类的有效值对。

下面的代码示例展示了如何获取灯光装置的有效属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **获取斜面形状的有效属性**
Aspose.Slides for C++ 允许开发人员获取斜面形状（Bevel Shape）的有效属性。 为此，在 Aspose.Slides 中添加了 **ShapeBevelEffectiveData** 类。ShapeBevelEffectiveData 类表示一个不可变对象，包含有效的形状面部浮雕属性。**ShapeBevelEffectiveData** 类的实例作为 **ThreeDFormatEffectiveData** 类的一部分使用，后者是 ThreeDFormat 类的有效值对。

下面的代码示例展示了如何获取斜面形状的有效属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **获取文本框的有效属性**
使用 Aspose.Slides for C++，您可以获取文本框的有效属性。 为此，在 Aspose.Slides 中添加了 **TextFrameFormatEffectiveData** 类，其中包含有效的文本框格式属性。

下面的代码示例展示了如何获取文本框的有效格式属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **获取文本样式的有效属性**
使用 Aspose.Slides for C++，您可以获取文本样式的有效属性。 为此，在 Aspose.Slides 中添加了 **TextStyleEffectiveData** 类，其中包含有效的文本样式属性。

下面的代码示例展示了如何获取文本样式的有效属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **获取有效的字体高度值**
使用 Aspose.Slides for C++，您可以获取字体高度的有效属性。 以下代码演示了在不同演示文稿结构层级上设置本地字体高度后，部分的有效字体高度值如何变化。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **获取表格的有效填充格式**
使用 Aspose.Slides for C++，您可以获取不同表格逻辑部分的有效填充格式。 为此，在 Aspose.Slides 中添加了 **IFillFormatEffectiveData** 接口，包含有效的填充格式属性。请注意，单元格格式始终优先于行格式，行格式优先于列格式，列格式又优先于整个表格。

因此最终始终使用 **CellFormatEffectiveData** 属性来绘制表格。下面的代码示例展示了如何获取不同表格逻辑部分的有效填充格式。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}

## **FAQ**

**我如何判断得到的是“快照”而不是“实时对象”，以及何时需要再次读取有效属性？**

EffectiveData 对象是计算值在调用时刻的不可变快照。如果您更改了形状的本地或继承设置，需要再次检索 EffectiveData 以获取更新后的值。

**更改布局/母版幻灯片会影响已经获取的有效属性吗？**

会，但只有在您再次读取它们后才会生效。已经获得的 EffectiveData 对象不会自行更新——在更改布局或母版后请重新请求。

**我可以通过 EffectiveData 修改值吗？**

不能。EffectiveData 是只读的。请在本地格式对象（形状/文本/3D 等）中进行更改，然后再次获取有效值。

**如果在形状层级、布局/母版以及全局设置中都未设置某属性，会怎样？**

有效值将由默认机制（PowerPoint/Aspose.Slides 默认值）决定。该解析后的值会成为 EffectiveData 快照的一部分。

**从有效的字体值，我能判断是哪一级提供了大小或字体吗？**

不能直接判断。EffectiveData 返回最终值。若需查找来源，请检查部分/段落/文本框的本地值以及布局/母版/演示文稿的文本样式，找出首次出现显式定义的层级。

**为什么 EffectiveData 值有时看起来与本地值相同？**

因为本地值最终成为了最终值（没有更高层级的继承参与）。在这种情况下，有效值与本地值相同。

**何时应使用有效属性，何时只使用本地属性？**

当您需要在所有继承应用后得到“渲染后”的结果（例如对齐颜色、缩进或尺寸）时，请使用 EffectiveData。如果您只需在特定层级修改格式，请修改本地属性，然后在需要时重新读取 EffectiveData 以验证结果。
---
title: 在 C++ 中为 PowerPoint 图表添加动画
linktitle: 动画图表
type: docs
weight: 80
url: /zh/cpp/animated-charts/
keywords:
- 图表
- 动画图表
- 图表动画
- 图表系列
- 图表类别
- 系列元素
- 类别元素
- 添加效果
- 效果类型
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中创建惊艳的动画图表。通过在 PPT 和 PPTX 文件中实现动态视觉效果提升演示文稿——立即开始吧。"
---

## **图表系列动画**
如果您想为图表系列添加动画，请按照下面列出的步骤编写代码：

1. 加载演示文稿。
2. 获取图表对象的引用。
3. 为系列添加动画。
4. 将演示文稿文件写入磁盘。

下面的示例中，我们对图表系列进行了动画处理。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **系列元素动画**
如果您想为系列元素添加动画，请按照下面列出的步骤编写代码：

1. 加载演示文稿。
2. 获取图表对象的引用。
3. 为系列元素添加动画。
4. 将演示文稿文件写入磁盘。

下面的示例中，我们对系列的元素进行了动画处理。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **图表类别动画**
如果您想为图表类别添加动画，请按照下面列出的步骤编写代码：

1. 加载演示文稿。
2. 获取图表对象的引用。
3. 为类别添加动画。
4. 将演示文稿文件写入磁盘。

下面的示例中，我们对图表类别进行了动画处理。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **类别元素动画**
如果您想为类别元素添加动画，请按照下面列出的步骤编写代码：

1. 加载演示文稿。
2. 获取图表对象的引用。
3. 为类别元素添加动画。
4. 将演示文稿文件写入磁盘。

下面的示例中，我们对类别元素进行了动画处理。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**是否支持与普通形状相同的不同效果类型（例如，进入、强调、退出）用于图表？**

是的。图表被视为形状，因此支持标准的动画效果类型，包括进入、强调和退出，并且可以通过幻灯片的时间轴和动画序列进行完整控制。

**我可以将图表动画与幻灯片切换结合使用吗？**

是的。[Transitions](/slides/zh/cpp/slide-transition/) 作用于幻灯片本身，而动画效果作用于幻灯片上的对象。您可以在同一个演示文稿中同时使用两者，并独立控制它们。

**将图表动画保存为 PPTX 时是否会保留？**

是的。当您[save to PPTX](/slides/zh/cpp/save-presentation/)时，所有动画效果及其顺序都会被保留，因为它们是演示文稿原生动画模型的一部分。

**我可以读取演示文稿中已有的图表动画并对其进行修改吗？**

是的。[API](https://reference.aspose.com/slides/cpp/aspose.slides.animation/) 提供对幻灯片时间轴、序列和效果的访问，允许您检查现有的图表动画并进行调整，而无需从头重新创建所有内容。

**我可以使用 Aspose.Slides 生成包含图表动画的视频吗？**

是的。您可以[export a presentation to video](/slides/zh/cpp/convert-powerpoint-to-video/) ，在保留动画的同时配置时间和其他导出设置，使生成的片段能够反映动画播放效果。
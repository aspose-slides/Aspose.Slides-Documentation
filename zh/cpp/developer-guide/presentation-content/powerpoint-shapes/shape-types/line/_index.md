---
title: 线
type: docs
weight: 50
url: /cpp/Line/
---

## **创建普通线**
要在演示文稿的选定幻灯片中添加简单的普通线，请按照以下步骤操作：

- 创建一个 [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/) 的实例。
- 通过使用其索引获得幻灯片的引用。
- 使用 [AddAutoShape](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addautoshape/index) 方法向 Shapes 对象添加一个线型自动形状。
- 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一条线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **创建箭头形状线**
Aspose.Slides for C++ 还允许开发者配置线的某些属性，使其看起来更具吸引力。请按照以下步骤配置线的几个属性，使其看起来像箭头：

- 创建一个 [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/) 的实例。
- 通过使用其索引获得幻灯片的引用。
- 使用 AddAutoShape 方法向 Shapes 对象添加一个线型自动形状。
- 将线条样式设置为 Aspose.Slides for C++ 提供的样式之一。
- 设置线条的宽度。
- 将线条的 [Dash Style](http://www.aspose.com/api/net/slides/aspose.slides/linedashstyle) 设置为 Aspose.Slides for C++ 提供的样式之一。
- 设置线的起点的 [Arrow Head Style](http://www.aspose.com/api/net/slides/aspose.slides/lineformat) 和长度。
- 设置线的终点的箭头样式和长度。
- 将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}
---
title: 在 C++ 中管理演示文稿备注
linktitle: 演示文稿备注
type: docs
weight: 110
url: /zh/cpp/presentation-notes/
keywords:
- 备注
- 备注幻灯片
- 添加备注
- 删除备注
- 备注样式
- 母版备注
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 定制演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提高工作效率。"
---
## **概述**

Aspose.Slides 支持从演示文稿中删除备注幻灯片。本文档将介绍此功能，包括如何删除备注以及如何对演示文稿中的备注幻灯片应用样式。Aspose.Slides 允许您删除任意幻灯片的备注，还可以对现有备注应用样式。开发者可以通过以下方式删除备注：

- 从演示文稿的特定幻灯片中删除备注。
- 从演示文稿的所有幻灯片中删除备注。

要读取或更改备注页尺寸、切换方向以及检查导出行为，请参阅[笔记页面大小](/slides/zh/cpp/notes-size/)。

## **从特定幻灯片删除备注**
可以按照下面的示例删除特定幻灯片的备注：

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **从所有幻灯片删除备注**
可以按照下面的示例删除演示文稿中所有幻灯片的备注：

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **添加备注样式**
已在 IMasterNotesSlide 接口和 MasterNotesSlide 类中添加了 NotesStyle 属性。此属性指定备注文本的样式。实现示例请参见下面的代码：

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **常见问题**

### 哪个 API 实体提供对特定幻灯片备注的访问？

备注通过幻灯片的备注管理器访问：该幻灯片拥有一个[NotesSlideManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/notesslidemanager/)和一个返回备注对象的[method](https://reference.aspose.com/slides/zh/cpp/aspose.slides/notesslidemanager/get_notesslide/)（如果没有备注，则返回`null`）。

### 在库支持的 PowerPoint 版本之间，备注支持是否存在差异？

该库面向广泛的 Microsoft PowerPoint 格式（97 及以后）以及 ODP；在这些格式中均支持备注，且不依赖于已安装的 PowerPoint 副本。
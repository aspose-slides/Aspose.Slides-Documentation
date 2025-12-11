---
title: 管理 C++ 演示文稿备注
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
description: "使用 Aspose.Slides for C++ 定制演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提高您的工作效率。"
---

## **添加和删除幻灯片备注**
Aspose.Slides 现在支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍删除备注以及从任意演示文稿中添加备注样式幻灯片的新功能。Aspose.Slides for C++ 提供了删除任意幻灯片备注以及为现有备注添加样式的功能。开发人员可以通过以下方式删除备注：

- 删除演示文稿中特定幻灯片的备注。
- 删除演示文稿中所有幻灯片的备注。

## **从特定幻灯片中删除备注**
可以按如下示例删除某些特定幻灯片的备注：

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **从所有幻灯片中删除备注**
可以按如下示例删除演示文稿中所有幻灯片的备注：

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **添加备注样式**
已在 IMasterNotesSlide 接口和 MasterNotesSlide 类中添加了 NotesStyle 属性。此属性指定备注文本的样式。以下示例演示了其实现。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **常见问题**

**哪个 API 实体提供对特定幻灯片备注的访问？**

备注通过幻灯片的备注管理器访问：幻灯片具有一个[NotesSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/)以及一个返回备注对象的[method](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/get_notesslide/)，如果没有备注则返回 `null`。

**在库支持的 PowerPoint 版本之间，备注支持是否存在差异？**

该库面向广泛的 Microsoft PowerPoint 格式（97‑至今）和 ODP；在这些格式中均支持备注，无需依赖已安装的 PowerPoint 副本。
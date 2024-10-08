---
title: 演示文稿备注
type: docs
weight: 110
url: /zh/cpp/presentation-notes/
keywords: "PowerPoint 演示文稿发言者备注"
---


## **添加和删除幻灯片备注**
Aspose.Slides 现在支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍这一新功能，移除备注以及从任何演示文稿中添加备注样式幻灯片。Aspose.Slides for C++ 提供了删除任何幻灯片备注的功能，并为现有备注添加样式。开发人员可以通过以下方式删除备注：

- 删除演示文稿某个特定幻灯片的备注。
- 删除演示文稿所有幻灯片的备注。

## **从特定幻灯片删除备注**
可以如下所示删除某个特定幻灯片的备注：

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **从所有幻灯片删除备注**
可以如下所示删除演示文稿所有幻灯片的备注：

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **添加备注样式**
NotesStyle 属性已被分别添加到 IMasterNotesSlide 接口和 MasterNotesSlide 类中。此属性指定备注文本的样式。实现示例如下所示。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}
---
title: 在 C++ 中管理簡報備註
linktitle: 簡報備註
type: docs
weight: 110
url: /zh-hant/cpp/presentation-notes/
keywords:
- 備註
- 備註投影片
- 新增備註
- 移除備註
- 備註樣式
- 主備註
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 自訂簡報備註。無縫操作 PowerPoint 與 OpenDocument 的備註，提升您的工作效率。"
---
## **概述**

Aspose.Slides 支援從簡報中移除備註投影片。本主題將介紹此功能，包括如何移除備註以及如何在簡報的備註投影片上套用樣式。Aspose.Slides 允許您從任何投影片移除備註，並對現有備註套用樣式。開發人員可透過以下方式移除備註：

- 從簡報的特定投影片中移除備註。
- 從簡報的所有投影片中移除備註。

如需閱讀或變更備註頁面尺寸、切換方向，以及檢查匯出行為，請參閱[Notes Page Size](/slides/zh-hant/cpp/notes-size/)。

## **從特定投影片移除備註**
以下範例示範如何移除特定投影片的備註：

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **從所有投影片移除備註**
以下範例示範如何移除簡報中所有投影片的備註：

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **新增備註樣式**
已在 IMasterNotesSlide 介面及 MasterNotesSlide 類別中加入 NotesStyle 屬性。此屬性指定備註文字的樣式。以下範例示範其實作方式。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### 哪個 API 實體提供對特定投影片備註的存取？

備註可透過投影片的備註管理器存取：投影片具備 [NotesSlideManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/notesslidemanager/) 以及可返回備註物件的 [method](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/notesslidemanager/get_notesslide/)，若無備註則返回 `null`。

### 在函式庫支援的 PowerPoint 版本之間，備註支援有何差異？

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版至更新版本）以及 ODP；在這些格式中皆支援備註，且不需依賴已安裝的 PowerPoint 版本。
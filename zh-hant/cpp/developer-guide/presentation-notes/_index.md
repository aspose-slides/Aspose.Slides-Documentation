---
title: 管理 C++ 簡報備註
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
description: "使用 Aspose.Slides for C++ 自訂簡報備註。無縫處理 PowerPoint 與 OpenDocument 的備註，提高您的工作效率。"
---
## **概述**

Aspose.Slides 支援從簡報中移除備註投影片。本文將介紹此功能，包括如何移除備註以及如何對簡報中的備註投影片套用樣式。Aspose.Slides 允許您從任何投影片移除備註，並對現有備註套用樣式。開發人員可以透過以下方式移除備註：

- 從簡報中的特定投影片移除備註。
- 從簡報中的所有投影片移除備註。

## **從特定投影片移除備註**
以下範例示範如何移除特定投影片的備註：

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **從所有投影片移除備註**
以下範例示範如何移除簡報中所有投影片的備註：

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **新增備註樣式**
已在 IMasterNotesSlide 介面與 MasterNotesSlide 類別中加入 NotesStyle 屬性。此屬性指定備註文字的樣式。以下範例示範其實作方式。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **常見問題**

**哪個 API 實體提供對特定投影片備註的存取？**

備註透過投影片的[NotesSlideManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/notesslidemanager/)以及[method](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/notesslidemanager/get_notesslide/)取得，返回備註物件，若無備註則為 `null`。

**在不同 PowerPoint 版本間，備註支援有差異嗎？**

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版至更新版）以及 ODP；備註在這些格式中皆受支援，且不依賴已安裝的 PowerPoint 版本。
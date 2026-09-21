---
title: 在 C++ 中編輯 PDF 文件
linktitle: 編輯 PDF
type: docs
weight: 65
url: /zh-hant/cpp/edit-pdf/
keywords:
- 編輯 PDF
- 取代 PDF 文字
- PDF 轉 PPTX
- PPTX 轉 PDF
- C++
- Aspose.Slides
description: "在 C++ 中透過將 PDF 匯入 Aspose.Slides、取代文字，並將修改後的簡報儲存回 PDF，以編輯 PDF 文件。"
---
## **概覽**

Aspose.Slides for C++ 允許您透過將 PDF 的頁面匯入為投影片、修改簡報，然後再匯出回 PDF 來編輯 PDF 內容。本文示範一個簡單的文字取代。簡報保留在記憶體中，因此儲存中間的 PPTX 檔案是可選的。

## **在 PDF 中取代文字**

使用[SlideCollection::AddFromPdf](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidecollection/addfrompdf/)來匯入頁面，使用[Presentation::ReplaceText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/replacetext/)來更新文字，並使用[Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/)匯出結果。

以下範例預期 `input.pdf` 在匯入後包含可編輯的文字「Draft」。它會將該文字取代為「Final」並寫入 `edited.pdf`。在匯入前清除初始投影片可防止輸出中出現額外的空白頁面。搜尋會以完整單字且大小寫相同的方式匹配；`nullptr` 表示不需要結果回呼。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

欲了解更多選項，請參閱[搜尋與取代文字](/slides/zh-hant/cpp/search-and-replace-text/)和[將 PowerPoint 轉換為 PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}
文字取代作用於匯入的文字，而非掃描影像內的文字。轉換可能會影響版面配置與格式，所以請檢查輸出，尤其是當取代文字比原始文字更長時。
{{% /alert %}}

## **常見問題**

**在匯出 PDF 之前，我需要先儲存 PPTX 檔案嗎？**

不需要。您可以在記憶體中編輯並匯出同一個簡報。僅在您希望在 PowerPoint 中繼續編輯時才儲存 PPTX 副本；請參閱[儲存簡報](/slides/zh-hant/cpp/save-presentation/)。

**為什麼有些文字可能未被變更？**

本範例以完整單字「Draft」且完全相同的大小寫進行匹配。以影像方式匯入的文字或分散於不同文字框的文字未必會符合搜尋條件。請檢查匯入的內容，並針對您的文件調整搜尋。
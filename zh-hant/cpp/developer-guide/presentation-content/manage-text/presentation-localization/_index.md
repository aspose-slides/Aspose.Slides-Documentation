---
title: 在 C++ 中自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/cpp/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 語言 ID
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中自動化 PowerPoint 與 OpenDocument 投影片本地化，並提供實用的程式碼範例與技巧，以加速全球部署。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 為簡報中的文字設定 `LanguageId`。它展示了如何開啟簡報、加入帶文字的圖形、為文字區段指派語言識別碼，並將結果儲存為 PPTX 檔案。

## **變更簡報與圖形文字的語言**
- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
- 使用其 Index 取得投影片的參考。
- 在投影片上加入矩形類型的 AutoShape。
- 向 TextFrame 新增一些文字。
- 設定文字的 Language Id。
- 將簡報寫入為 PPTX 檔案。

以下範例示範上述步驟的實作。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **常見問題**

**語言 ID 會觸發自動文字翻譯嗎？**

不會。Aspose.Slides 中的 [Language ID](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_languageid/) 用於儲存語言以供拼寫檢查與文法校對，但它不會翻譯或變更文字內容。它是 PowerPoint 所理解的校對中繼資料。

**語言 ID 會影響渲染時的連字符與換行嗎？**

在 Aspose.Slides 中，[Language ID](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_languageid/) 僅用於校對。連字符品質與換行主要取決於[適當的字型](/slides/zh-hant/cpp/powerpoint-fonts/)以及書寫系統的版面/換行設定。為確保正確呈現，請確保所需字型可用，設定[字型替代規則](/slides/zh-hant/cpp/font-substitution/)，或將[嵌入字型](/slides/zh-hant/cpp/embedded-font/)嵌入簡報中。

**我可以在同一段落內設定不同語言嗎？**

可以。 [Language ID](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_languageid/) 會套用於文字區段層級，因此單一段落可以混合多種語言，並具備各自的校對設定。
---
title: 在 .NET 中自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/net/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 語言 ID
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中自動化 PowerPoint 與 OpenDocument 投影片本地化，提供實用的 C# 程式碼範例與加速全球部署的技巧。"
---
## **概述**

本文說明如何使用 Aspose.Slides 為簡報中的文字設定 `LanguageId`。它展示了如何開啟簡報、加入帶文字的形狀、為文字區段指派語言識別碼，並將結果儲存為 PPTX 檔案。

## **變更簡報與形狀文字的語言**
- 建立[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)類別的實例。
- 透過索引取得投影片的參考。
- 在投影片上新增類型為 Rectangle 的 AutoShape。
- 在 TextFrame 中加入一些文字。
- 為文字設定 Language Id。
- 將簡報寫入為 PPTX 檔案。

以下範例示範上述步驟的實作。

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **常見問題**
**語言 ID 會觸發自動文字翻譯嗎？**

不會。Aspose.Slides 中的[LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/languageid/)用於儲存拼寫檢查與文法校正的語言，但不會翻譯或變更文字內容。它是 PowerPoint 用於校正的中繼資料。

**語言 ID 會影響渲染時的斷字與換行嗎？**

在 Aspose.Slides 中，[LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/languageid/)僅用於校正。斷字品質與換列主要取決於[適當字型](/slides/zh-hant/net/powerpoint-fonts/)的可用性以及書寫系統的版面配置/換行設定。為確保正確渲染，請提供所需字型、設定[字型替代規則](/slides/zh-hant/net/font-substitution/)，或將[嵌入字型](/slides/zh-hant/net/embedded-font/)加入簡報。

**我可以在同一段落中設定不同語言嗎？**

可以。[LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/languageid/) 會套用於文字區段層級，因此同一段落可混合多種語言，並使用不同的校正設定。
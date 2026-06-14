---
title: 在 .NET 中管理簡報的文字段落
linktitle: 文字段落
type: docs
weight: 70
url: /zh-hant/net/portion/
keywords:
- 文字段落
- 文字部份
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 簡報中管理文字段落，以提升效能與客製化。"
---
## **概述**

文字段落表示段落內的特定文字片段，允許您獨立於周圍內容操作該片段。 在 Aspose.Slides 中，當您需要取得文字片段的位置、僅對段落的一部分套用格式，或在更細緻的層級控制文字行為時，可使用 portion。

本文說明如何使用 `GetCoordinates()` 方法取得 portion 起始位置的座標。 同時也介紹常見的與 portion 相關的情境，例如對單一文字片段套用超連結、了解格式如何透過 portion、段落、文字框與主題的繼承而決定，以及處理指定字型不存在的情況。 另外也說明在同一段落內，不同 portion 可以設定不同的文字填充、顏色與透明度。

## **取得文字段落的座標**
**GetCoordinates()** 方法已新增至 IPortion 與 Portion 類別，可取得 portion 起始位置的座標：

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **常見問題**

**我可以只對單一段落中的部分文字套用超連結嗎？**

是的，您可以[指派超連結](/slides/zh-hant/net/manage-hyperlinks/)給單一 portion；只有該片段可點擊，整段文字不會被點擊。

**樣式繼承如何運作：Portion 會覆寫哪些設定，哪些是從 Paragraph/TextFrame 繼承的？**

Portion 級別的屬性擁有最高優先權。若在[Portion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/portion/)上未設定屬性，系統會從[Paragraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraph/)取得；若仍未設定，則會從[TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/theme/)樣式取得。

**如果在目標機器/伺服器上缺少 Portion 指定的字型，會發生什麼情況？**

會套用[字體替換規則](/slides/zh-hant/net/font-selection-sequence/)。文字可能會重新換行：度量、斷字與寬度皆可能變化，這會影響精確定位。

**我可以為單一 Portion 設定與段落其他文字不同的文字填充透明度或漸層嗎？**

可以，[Portion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/portion/)層級的文字顏色、填充與透明度可以與相鄰片段不同。
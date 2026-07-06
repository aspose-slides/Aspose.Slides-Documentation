---
title: 從 Python 簡報中取得文字區段邊界
linktitle: 區段邊界
type: docs
weight: 47
url: /zh-hant/python-net/portion-bounds/
keywords:
- 文字區段邊界
- 文字區段
- 文字部份
- 文字座標
- 文字位置
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 簡報中取得文字區段的邊界。"
---
## **概觀**

文字區段代表段落內的特定文字片段，讓您能獨立於周圍內容處理該片段。 在 Aspose.Slides 中，當您需要取得文字片段的邊界、僅對段落的一部分套用格式，或在更細緻的層面控制文字行為時，可使用區段。

本篇說明如何使用[Portion.get_rect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/get_rect/)取得區段的邊界矩形。也說明如何使用[Portion.get_coordinates](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/get_coordinates/)取得區段起始點的座標。除此之外，還介紹了常見的區段相關情境，例如對單一文字片段套用超連結、了解格式如何透過區段、段落、文字框與佈景主題的繼承而決定，以及處理指定字型不存在的情況。

## **取得文字區段的邊界**

使用[Portion.get_rect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/get_rect/)取得文字區段的邊界矩形：

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **取得文字區段的座標**

使用[Portion.get_coordinates](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/get_coordinates/)取得文字區段起始點的座標：

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **常見問題**

**我可以只對單一段落中的部分文字套用超連結嗎？**

是的，您可以[指派超連結](/slides/zh-hant/python-net/manage-hyperlinks/)到單獨的區段；只有該片段會變成可點擊，而不是整段文字。

**樣式繼承如何運作：區段會覆寫什麼，什麼則來自段落或文字框？**

區段層級的屬性具有最高優先權。如果在[Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/)上未設定某屬性，Aspose.Slides 會從[Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/)取得。若該層級仍未設定，則會使用[TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/theme/)的樣式。

**如果區段指定的字型在目標機器或伺服器上不存在，會發生什麼情況？**

會套用[字型替換規則](/slides/zh-hant/python-net/font-selection-sequence/)。文字可能會重新換行：度量、斷字與寬度都可能改變，這對精確定位非常重要。

**我可以為區段設定特定的文字填色透明度或漸層，而不影響段落的其他文字嗎？**

可以，位於[Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/)層級的文字顏色、填色與透明度可以與相鄰片段不同。
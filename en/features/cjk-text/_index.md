---
title: Work with Chinese, Japanese and Korean text
description: Lay out Chinese, Japanese and Korean text with suitable fonts and line breaks.
type: docs
url: /features/cjk-text/
weight: 860
feature_id: cjk-text
feature_group: text
translationKey: slides-feature-cjk-text
feature_catalogue_version: 3
feature_guides:
- /slides/net/text-formatting/
---

## **Overview**

Use East Asian font settings and text layout for Chinese, Japanese and Korean content. The text can flow between characters and follow punctuation line-breaking rules. Mixed East Asian and Latin text can use the font settings appropriate to each script.

## **Usage example**

This C# example puts Japanese and Latin text in a narrow text box and enables East Asian line breaking. It requires MS Gothic for the Japanese text and Arial for Latin text on the rendering host. The output is `cjk-text.pptx` with a PNG preview to check glyphs and wrapping.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 220, 280);
shape.AddTextFrame("日本語の文字とPowerPointの資料を表示します。改行と句読点を確認します。");
shape.TextFrame.TextFrameFormat.WrapText = NullableBool.True;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
shape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.EastAsianLineBreak = NullableBool.True;
paragraph.ParagraphFormat.LatinLineBreak = NullableBool.False;
var format = paragraph.Portions[0].PortionFormat;
format.EastAsianFont = new FontData("MS Gothic");
format.LatinFont = new FontData("Arial");
format.LanguageId = "ja-JP";
format.FontHeight = 24;
presentation.Save("cjk-text.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("cjk-text.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can Latin and East Asian text use different fonts in one portion?**

Yes. The text formatting can specify separate font choices for those scripts.

### **How do East Asian line-break rules affect text wrapping?**

They allow character-based wrapping while applying East Asian punctuation constraints. The text box width, font metrics and paragraph line-break settings all affect the final layout.

### **What should I check when CJK glyphs render as empty squares?**

Check that the selected East Asian font is available to the renderer and contains the required characters. Then check font fallback and rerender using the same environment as production.

## **Guides**

- [Format Presentation Text in .NET](/slides/net/text-formatting/)

Related feature: [Load fonts from a folder](/slides/features/custom-fonts/).

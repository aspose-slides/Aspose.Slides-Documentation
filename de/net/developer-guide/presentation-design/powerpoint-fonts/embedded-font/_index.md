---
title: Eingebettete Schriftart - PowerPoint C# API
linktitle: Eingebettete Schriftart
type: docs
weight: 40
url: /net/embedded-font/
keywords:
- schriften
- eingebettete schriften
- schriften hinzufügen
- PowerPoint
- präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Verwenden Sie eingebettete Schriften in PowerPoint-Präsentationen in C# oder .NET"
---

**Eingebettete Schriften in PowerPoint** sind nützlich, wenn Sie möchten, dass Ihre Präsentation auf jedem System oder Gerät korrekt angezeigt wird. Wenn Sie eine Drittanbieter- oder nicht standardmäßige Schriftart verwendet haben, weil Sie kreativ gearbeitet haben, haben Sie umso mehr Gründe, Ihre Schriftart einzubetten. Andernfalls (ohne eingebettete Schriften) können sich die Texte oder Zahlen auf Ihren Folien, das Layout, die Gestaltung usw. ändern oder in verwirrende Rechtecke verwandeln.

Die [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) Klasse, die [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/) Klasse, die [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) Klasse und ihre Schnittstellen enthalten die meisten Eigenschaften und Methoden, die Sie benötigen, um mit eingebetteten Schriften in PowerPoint-Präsentationen zu arbeiten.

## **Eingebettete Schriften aus der Präsentation abrufen oder entfernen**

Aspose.Slides bietet die [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) Methode (bereitgestellt durch die [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) Klasse), um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriften abzurufen (oder herauszufinden). Um Schriften zu entfernen, wird die [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) Methode (die von derselben Klasse bereitgestellt wird) verwendet.

Dieser C#-Code zeigt Ihnen, wie Sie eingebettete Schriften aus einer Präsentation abrufen und entfernen:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Rendert eine Folie mit einem Textfeld, das die eingebettete Schriftart "FunSized" verwendet
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Findet die Schriftart "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Entfernt die Schriftart "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Rendert die Präsentation; die Schriftart "Calibri" wird durch eine vorhandene ersetzt
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Speichert die Präsentation ohne die eingebettete Schriftart "Calibri" auf der Festplatte
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Eingebettete Schriften in die Präsentation einfügen**
Mit dem [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) Enum und zwei Überladungen der [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) Methode können Sie Ihre bevorzugte (Einbettungs-) Regel auswählen, um die Schriften in einer Präsentation einzubetten. Dieser C#-Code zeigt Ihnen, wie Sie Schriften in eine Präsentation einbetten und hinzufügen:

```c#
// Lädt die Präsentation
Presentation presentation = new Presentation("Fonts.pptx");

// Lädt die zu ersetzende Quellenschriftart
IFontData sourceFont = new FontData("Arial");


IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Speichert die Präsentation auf der Festplatte
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Eingebettete Schriften komprimieren**

Um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriften zu komprimieren und die Dateigröße zu reduzieren, bietet Aspose.Slides die [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) Methode (bereitgestellt durch die [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) Klasse).

Dieser C#-Code zeigt Ihnen, wie Sie eingebettete PowerPoint-Schriften komprimieren:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```
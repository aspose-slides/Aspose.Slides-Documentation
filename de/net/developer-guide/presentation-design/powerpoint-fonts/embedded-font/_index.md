---
title: Einbetten von Schriften in Präsentationen in .NET
linktitle: Schrift einbetten
type: docs
weight: 40
url: /de/net/embedded-font/
keywords:
- Schrift hinzufügen
- Schrift einbetten
- Schrift-Einbettung
- eingebettete Schrift abrufen
- eingebettete Schrift hinzufügen
- eingebettete Schrift entfernen
- eingebettete Schrift komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "TrueType-Schriften in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET einbetten, um eine genaue Darstellung auf allen Plattformen zu gewährleisten."
---

**Embedding fonts in PowerPoint** stellt sicher, dass Ihre Präsentation ihr beabsichtigtes Erscheinungsbild auf verschiedenen Systemen beibehält. Egal, ob Sie einzigartige Schriften für Kreativität oder Standardschriften verwenden, das Einbetten von Schriften verhindert Text- und Layoutstörungen.

Wenn Sie eine Drittanbieter- oder nicht-standardmäßige Schrift verwendet haben, weil Sie Ihrer Arbeit einen kreativen Touch verliehen haben, haben Sie noch mehr Gründe, die Schrift einzubetten. Andernfalls (ohne eingebettete Schriften) können die Texte oder Zahlen auf Ihren Folien, das Layout, die Formatierung usw. sich ändern oder in verwirrende Rechtecke umwandeln. 

Verwenden Sie die Klassen [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/) und [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), um eingebettete Schriften zu verwalten.

## **Abrufen und Entfernen eingebetteter Schriften**

Rufen Sie eingebettete Schriften aus einer Präsentation ab oder entfernen Sie sie mühelos mit den Methoden [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) und [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont).

Dieser C#‑Code zeigt, wie Sie eingebettete Schriften aus einer Präsentation abrufen und entfernen:
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Rendert eine Folie, die einen Textrahmen mit der eingebetteten "FunSized"-Schrift enthält
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Findet die Schrift "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Entfernt die Schrift "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Rendert die Präsentation; die Schrift "Calibri" wird durch eine vorhandene ersetzt
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Speichert die Präsentation ohne die eingebettete Schrift "Calibri" auf die Festplatte
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **Hinzufügen eingebetteter Schriften**

Mit dem Aufzählungstyp [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) und zwei Überladungen der Methode [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) können Sie die gewünschte Einbettungsregel auswählen, um Schriften in einer Präsentation einzubetten. Dieser C#‑Code zeigt, wie Sie Schriften einbetten und zur Präsentation hinzufügen:
```c#
 // Lädt die Präsentation
Presentation presentation = new Presentation("Fonts.pptx");

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


## **Komprimieren eingebetteter Schriften**

Optimieren Sie die Dateigröße, indem Sie eingebettete Schriften mit [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) komprimieren.

Beispielcode für die Komprimierung:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Wie kann ich erkennen, dass eine bestimmte Schrift in der Präsentation trotz Einbettung beim Rendern noch ersetzt wird?**

Prüfen Sie die [Substitutionsinformationen](/slides/de/net/font-substitution/) im Font‑Manager und die [Fallback‑/Substitutionsregeln](/slides/de/net/fallback-font/): Ist die Schrift nicht verfügbar oder eingeschränkt, wird eine Ersatzschrift verwendet.

**Lohnt es sich, Systemschriften wie Arial/Calibri einzubetten?**

In der Regel nicht – sie sind fast immer verfügbar. Für volle Portabilität in „dünnen“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriften) kann das Einbetten von Systemschriften jedoch das Risiko unerwarteter Ersetzungen ausschließen.
---
title: "Schriftarten in Präsentationen in .NET einbetten"
linktitle: "Schriftart einbetten"
type: docs
weight: 40
url: /de/net/embedded-font/
keywords:
- "Schriftart hinzufügen"
- "Schriftart einbetten"
- "Schriftarteinbettung"
- "Eingebettete Schriftart abrufen"
- "Eingebettete Schriftart hinzufügen"
- "Eingebettete Schriftart entfernen"
- "Eingebettete Schriftart komprimieren"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "TrueType-Schriftarten in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET einbetten, um ein genaues Rendering auf allen Plattformen zu gewährleisten."
---

**Einbetten von Schriftarten in PowerPoint** stellt sicher, dass Ihre Präsentation ihr beabsichtigtes Erscheinungsbild auf verschiedenen Systemen beibehält. Egal, ob Sie einzigartige Schriftarten für Kreativität oder Standard‑Schriftarten verwenden, das Einbetten von Schriftarten verhindert Text‑ und Layoutstörungen.

Wenn Sie eine Drittanbieter‑ oder nicht‑standardisierte Schriftart verwendet haben, weil Sie kreativ waren, haben Sie noch mehr Gründe, Ihre Schriftart einzubetten. Andernfalls (ohne eingebettete Schriftarten) können Texte oder Zahlen in Ihren Folien, das Layout, das Styling usw. sich ändern oder in verwirrende Rechtecke verwandeln.

Verwenden Sie die Klassen [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/) und [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) zur Verwaltung eingebetteter Schriftarten.

## **Abrufen und Entfernen eingebetteter Schriftarten**

Rufen Sie eingebettete Schriftarten aus einer Präsentation ab oder entfernen Sie sie mühelos mit den Methoden [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) und [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont).

Dieser C#‑Code zeigt, wie Sie eingebettete Schriftarten aus einer Präsentation abrufen und entfernen:
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Rendert eine Folie mit einem Textrahmen, der die eingebettete "FunSized"-Schrift verwendet
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

    // Speichert die Präsentation ohne die eingebettete Schriftart "Calibri" auf die Festplatte
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **Einbetten von Schriftarten**

Mit dem Aufzählungstyp [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) und zwei Überladungen der Methode [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) können Sie Ihre bevorzugte (Einbettungs‑)Regel auswählen, um die Schriftarten in einer Präsentation einzubetten. Dieser C#‑Code zeigt, wie Sie Schriftarten einbetten und einer Präsentation hinzufügen:
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

// Speichert die Präsentation auf die Festplatte
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```


## **Komprimieren eingebetteter Schriftarten**

Optimieren Sie die Dateigröße, indem Sie eingebettete Schriftarten mit [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) komprimieren.

Beispielcode für die Komprimierung:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Wie kann ich feststellen, dass eine bestimmte Schriftart in der Präsentation trotz Einbetten noch beim Rendern ersetzt wird?**

Prüfen Sie die [Substitutionsinformationen](/slides/de/net/font-substitution/) im Font‑Manager und die [Fallback‑/Substitutionsregeln](/slides/de/net/fallback-font/): Wenn die Schriftart nicht verfügbar oder eingeschränkt ist, wird ein Fallback verwendet.

**Lohnt es sich, „System‑“Schriftarten wie Arial/Calibri einzubetten?**

In der Regel nicht – sie sind fast immer verfügbar. Aber für volle Portabilität in „dünnen“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriftarten) kann das Einbetten von System‑Schriftarten das Risiko unerwarteter Substitutionen eliminieren.
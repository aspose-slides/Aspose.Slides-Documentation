---
title: Schriften in PowerPoint mit C# einbetten
linktitle: Schriften einbetten
type: docs
weight: 40
url: /de/net/embedded-font/
keywords:
- Schriften einbetten
- PowerPoint C#
- Schriften hinzufügen
- Präsentation
- Aspose.Slides für .NET
description: "Erfahren Sie, wie Sie Schriften in PowerPoint-Präsentationen mit C# und .NET einbetten, hinzufügen und verwalten"
---

**Schriftarten in PowerPoint einbetten** stellt sicher, dass Ihre Präsentation ihr vorgesehenes Erscheinungsbild auf verschiedenen Systemen beibehält. Egal, ob Sie kreative oder standardmäßige Schriftarten verwenden, das Einbetten verhindert Text‑ und Layoutstörungen.

Wenn Sie aus kreativen Gründen eine Drittanbieter‑ oder nicht‑standardmäßige Schriftart verwendet haben, haben Sie noch mehr Gründe, die Schriftart einzubetten. Ohne eingebettete Schriftarten können Texte oder Zahlen auf den Folien, das Layout, das Styling usw. sich ändern oder in verwirrende Rechtecke umwandeln.

Verwenden Sie die [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/) und [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)‑Klassen, um eingebettete Schriftarten zu verwalten.

## **Abrufen und Entfernen eingebetteter Schriftarten**

Rufen Sie eingebettete Schriftarten ab oder entfernen Sie sie mühelos aus einer Präsentation mit den Methoden [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) und [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont).

Dieser C#‑Code zeigt, wie Sie eingebettete Schriftarten aus einer Präsentation abrufen und entfernen:
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Rendert eine Folie, die einen Textrahmen enthält, der die eingebettete "FunSized"-Schrift verwendet
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

    // Speichert die Präsentation ohne eingebettete "Calibri"-Schrift auf dem Datenträger
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **Einbetten von Schriftarten hinzufügen**

Mit dem Enum [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) und zwei Überladungen der Methode [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) können Sie Ihre bevorzugte (Einbettungs‑)Regel auswählen, um Schriftarten in einer Präsentation einzubetten. Dieser C#‑Code zeigt, wie Sie Schriftarten einbetten und zu einer Präsentation hinzufügen:
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

// Speichert die Präsentation auf dem Datenträger
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

**Wie kann ich feststellen, dass eine bestimmte Schriftart in der Präsentation trotz Einbetten beim Rendern noch substituiert wird?**

Prüfen Sie die [substitution information](/slides/de/net/font-substitution/) im Font‑Manager und die [fallback/substitution rules](/slides/de/net/fallback-font/): Ist die Schriftart nicht verfügbar oder eingeschränkt, wird ein Ersatz verwendet.

**Lohnt es sich, „System“-Schriftarten wie Arial/Calibri einzubetten?**

In der Regel nein – sie sind fast immer verfügbar. Für volle Portabilität in „dünnen“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriftarten) kann das Einbetten von Systemschriftarten das Risiko unerwarteter Substitutionen jedoch eliminieren.
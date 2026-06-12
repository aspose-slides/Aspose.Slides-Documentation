---
title: Lettertypen insluiten in presentaties in .NET
linktitle: Lettertype insluiten
type: docs
weight: 40
url: /nl/net/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- lettertype insluiting
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Insluit TrueType-lettertypen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET, zodat de weergave op alle platformen nauwkeurig is."
---
## **Inleiding**

**Lettertypen insluiten in PowerPoint** zorgt ervoor dat uw presentatie er op verschillende systemen hetzelfde uitziet. Of u nu unieke lettertypen gebruikt voor creativiteit of standaardlettertypen, het insluiten van lettertypen voorkomt verstoringen van tekst en lay-out.

Als u een lettertype van een derde partij of een niet‑standaard lettertype hebt gebruikt omdat u creatief wilt zijn, heeft u nog meer reden om uw lettertype in te sluiten. Anders (zonder ingesloten lettertypen) kunnen de teksten of cijfers op uw dia's, de lay-out, opmaak, enz. veranderen of veranderen in verwarrende rechthoeken.

Gebruik de [FontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/nl/net/aspose.slides/fontdata/), en [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/) klassen om ingesloten lettertypen te beheren.

## **Ingesloten lettertypen ophalen en verwijderen**

Haal ingesloten lettertypen op of verwijder ze moeiteloos uit een presentatie met de [GetEmbeddedFonts](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getembeddedfonts) en [RemoveEmbeddedFont](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/removeembeddedfont) methoden.

Deze C#‑code laat zien hoe u ingesloten lettertypen uit een presentatie kunt ophalen en verwijderen:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Render een dia met een tekstkader dat het ingesloten "FunSized" lettertype gebruikt
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Vindt het lettertype "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Verwijdert het lettertype "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Render de presentatie; het lettertype "Calibri" wordt vervangen door een bestaand lettertype
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Slaat de presentatie op zonder het ingesloten "Calibri" lettertype naar schijf
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Ingesloten lettertypen toevoegen**

Met behulp van de [EmbedFontCharacters](https://reference.aspose.com/slides/nl/net/aspose.slides.export/embedfontcharacters/) enum en twee overloads van de [AddEmbeddedFont](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/addembeddedfont/) methode kunt u de gewenste (insluit‑)regel kiezen om lettertypen in een presentatie in te sluiten. Deze C#‑code laat zien hoe u lettertypen kunt insluiten en toevoegen aan een presentatie:

```c#
// Laadt de presentatie
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

// Slaat de presentatie op naar schijf
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Ingesloten lettertypen comprimeren**

Optimaliseer de bestandsgrootte door ingesloten lettertypen te comprimeren met [CompressEmbeddedFonts](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Voorbeeldcode voor compressie:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Hoe kan ik zien dat een specifiek lettertype in de presentatie nog steeds wordt vervangen tijdens het renderen ondanks insluiting?**

Bekijk de [substitutie‑informatie](/slides/nl/net/font-substitution/) in de font‑manager en de [fallback/substitutie‑regels](/slides/nl/net/fallback-font/): als het lettertype niet beschikbaar of beperkt is, wordt er een fallback gebruikt.

**Is het de moeite waard om 'systeem'‑lettertypen zoals Arial/Calibri in te sluiten?**

Meestal niet -- ze zijn bijna altijd beschikbaar. Maar voor volledige draagbaarheid in 'dunne' omgevingen (Docker, een Linux‑server zonder vooraf geïnstalleerde lettertypen) kan het insluiten van systeem‑lettertypen het risico op onverwachte substituties wegnemen.
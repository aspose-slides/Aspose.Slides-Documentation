---
title: PPT en PPTX converteren naar PDF in .NET [Geavanceerde functies inbegrepen]
linktitle: PowerPoint naar PDF
type: docs
weight: 40
url: /nl/net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint converteren
- presentatie converteren
- PowerPoint naar PDF
- presentatie naar PDF
- PPT naar PDF
- PPT converteren naar PDF
- PPTX naar PDF
- PPTX converteren naar PDF
- PowerPoint opslaan als PDF
- PPT opslaan als PDF
- PPTX opslaan als PDF
- PPT exporteren naar PDF
- PPTX exporteren naar PDF
- bijlage
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's in .NET met Aspose.Slides, inclusief snelle C#-codevoorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in C# biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te regelen, verborgen dia's kunt opnemen, PDF‑bestanden met een wachtwoord kunt beveiligen, lettertype‑substituties kunt detecteren, specifieke dia's kunt selecteren voor conversie en nalevingsnormen kunt toepassen op de uitvoer‑documenten.

## **PowerPoint naar PDF-conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met behulp van een [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑methode. De [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑klasse biedt de [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑methode die gewoonlijk wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides voor .NET voegt zijn API‑informatie en versienummer toe aan de uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF, vult Aspose.Slides het toepassingsveld in met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Let op** dat u Aspose.Slides niet kunt instrueren om deze informatie uit de uitvoer‑documenten te wijzigen of te verwijderen.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia's van een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waardoor de resulterende PDF’s nauw overeenkomen met de originele presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alineaopmaak
* Hyperlinks
* Koptekst en voettekst
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint-naar-PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het maximale kwaliteitsniveau.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia's op als PDF met behulp van de standaard exportinstellingen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse — die u in staat stellen om de resulterende PDF aan te passen, de PDF te beveiligen met een wachtwoord, of op te geven hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor rasterafbeeldingen definiëren, aangeven hoe metafiles behandeld moeten worden, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, beeldresolutie ingesteld op 300 DPI, metafiles opgeslagen als PNG, en Flate‑tekstcompressie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

> **Opmerking:** U kunt de weergavekwaliteit van tekstschaduwen en reflectie‑effecten verbeteren bij het converteren naar PDF door `PdfOptions.SufficientResolution` op een hogere waarde (bijv. `300`) in te stellen. Dit levert PDF‑output op die beter overeenkomt met het uiterlijk in Microsoft PowerPoint.

### **Automatisch afbeeldingscompressie selecteren**

Wanneer een presentatie veel foto’s of screenshots bevat, kan het verkleinen van de grootte van de geëxporteerde PDF het makkelijker maken om te e‑mailen of te downloaden. Stel [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) in op `true` om automatisch het meest geschikte compressie‑algoritme voor elke afbeelding te selecteren tijdens de PDF‑export.

Het volgende voorbeeld laadt een bestaande presentatie, schakelt automatische selectie van afbeeldingscompressie in, en slaat deze op als een PDF‑document. Alle andere PDF‑exportinstellingen behouden hun standaardwaarden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Deze optie selecteert een compressie‑algoritme voor elke afbeelding. Het verlagen van [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) vermindert de JPEG‑afbeeldingskwaliteit, terwijl het verlagen van [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) toestaat dat afbeeldingen worden downsampled naar een lagere resolutie, wat details kan verminderen. Het inschakelen van automatische compressieselectie verlaagt deze instellingen zelf niet.

Het selecteren van compressie‑algoritmen voor afbeeldingen vereist extra verwerkingstijd en geheugen. De grootte‑reductie hangt af van de afbeeldingen in de presentatie en de exportinstellingen; een vaste reductie is niet gegarandeerd voor elke presentatie.

### **Embedded OLE‑bestanden behouden als PDF‑bijlagen**

Als een presentatie een embedded Excel‑werkmap bevat, wilt u misschien dat PDF‑ontvangers zowel de gegevens van de werkmap kunnen raadplegen als de dia's bekijken. Stel [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) in op `true` om ingebedde OLE‑bestanden te behouden als bijlagen in de resulterende PDF.

De standaardwaarde is `false`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt op de PDF‑pagina weergegeven, maar het embedded bestand wordt niet als bijlage toegevoegd. Door de optie op `true` in te stellen, wordt het bestands‑data bovendien toegevoegd. De preview blijft een visuele weergave; de bijlage stelt ontvangers in staat het embedded bestand apart te openen of op te slaan. Het OLE‑object wordt geen interactieve Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die al een embedded Excel‑werkmap bevat en exporteert deze naar PDF met de werkmap als bijlage.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Om het resultaat te controleren:

1. Open de geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek de embedded werkmap.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze rechtstreeks als de viewer dat toestaat. De preview op de PDF‑pagina is gescheiden van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑normen leggen beperkingen op voor bijlagen: PDF/A‑1 verbiedt embedded bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, inclusief Excel‑werkboeken. Dit zijn vereisten van de normen, geen beperkingen die specifiek zijn voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑conformiteitinstelling en toont geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/)‑eigenschap van de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse gebruiken om de verborgen dia's als pagina’s in de resulterende PDF op te nemen.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief eventuele verborgen dia's.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint naar een met wachtwoord beveiligde PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF die wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Lettertype‑substituties detecteren**

Aspose.Slides biedt de [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/)‑eigenschap onder de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse, waardoor u lettertype‑substituties kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Het volgende voorbeeld exporteert een presentatie naar PDF en print waarschuwingen voor lettertype‑substituties naar de console. Een waarschuwing wordt alleen afgedrukt wanneer een niet‑beschikbaar lettertype tijdens de export wordt vervangen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
Voor meer informatie over lettertype‑substitutie, zie het artikel [Font Substitution](/slides/nl/net/font-substitution/).
{{% /alert %}}

### **Omgaan met lettertypen zonder een aparte vet‑typeface**

Een presentatie kan vette opmaak toepassen op tekst, zelfs wanneer het lettertype geen aparte vet‑typeface heeft. De tekst kan nog steeds vet lijken door synthetisch vet maken, waarbij de reguliere glyphs kunstmatig dikker worden gemaakt. Wanneer die tekst te zwaar oogt of anderszins afwijkt van het beoogde uiterlijk in PDF, probeer dan [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) in te stellen op `true`. Deze optie rendert de getroffen tekst als een bitmap tijdens de PDF‑export en kan het uiterlijk voor bepaalde lettertypen verbeteren. De standaardwaarde is `false`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vet opgemaakte tekst van hetzelfde lettertype, dat geen aparte vet‑typeface heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in, en exporteert deze naar PDF:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

De volgende voorbeeldweergaven tonen de output met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vette tekst zwaardere lijnen met de optie uitgeschakeld. Met de optie ingeschakeld zijn de lijnen lichter; de gewone tekst blijft onveranderd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`false`, de standaard) | Optie ingeschakeld (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In dit voorbeeld maakt het inschakelen van de optie alleen de vette tekst een bitmap: deze kan niet worden geselecteerd, gekopieerd of gezocht als tekst zonder OCR, en de randen lijken zachter bij 800 % zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die vet is opgemaakt wanneer het lettertype geen aparte vet‑typeface heeft. [Font substitution](/slides/nl/net/font-substitution/) selecteert in plaats daarvan een ander lettertype wanneer het originele niet beschikbaar is.

## **Selecte dia's van PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia's 1 en 3 van een presentatie naar PDF. De slidennummers in deze array beginnen bij één, en de invoerpresentatie moet minstens drie dia's bevatten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Het volgende voorbeeld kopieert de eerste dia van een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud zodat deze past en exporteert de enkele dia naar PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **PowerPoint naar PDF converteren in notities‑dia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de aantekeningen van elke dia onder de dia worden geplaatst. Gebruik een presentatie met spreker‑notities om het resultaat te zien.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Toegankelijkheid en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze C#‑code toont een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden produceert op basis van verschillende nalevingsnormen:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert color="info" title="Note" %}}
Aspose.Slides ondersteunt PDF‑conversie‑operaties, waardoor u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten — [PDF naar SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — worden ook ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe graphics zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke content en kunnen gemarkeerd worden als artefacten; alternatieve tekst wordt alleen voor de hele figuur geleverd.

## **Veelgestelde vragen**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk om de geconverteerde PDF met een wachtwoord te beveiligen?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe kan ik verborgen dia's opnemen in de PDF?**

Stel de [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/)‑eigenschap in de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse in op `true` om verborgen dia's op te nemen in de resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit behouden in de PDF?**

Ja, u kunt de beeldkwaliteit regelen door eigenschappen zoals [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) en [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) in de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse in te stellen om hoogwaardige beelden in uw PDF te waarborgen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat PDF‑bestanden te exporteren die voldoen aan verschillende normen, inclusief PDF/A1a, PDF/A1b en PDF/UA, waardoor uw documenten voldoen aan toegankelijkheids- en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides for .NET Documentatie](/slides/nl/net/)
- [Aspose.Slides for .NET API‑referentie](https://reference.aspose.com/slides/net/)
- [Aspose Gratis Online Converters](https://products.aspose.app/slides/conversion)

Related feature: [Presentaties exporteren naar PDF](/slides/nl/features/pdf-export/).
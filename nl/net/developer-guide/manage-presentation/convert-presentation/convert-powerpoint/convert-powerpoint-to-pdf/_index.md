---
title: Converteer PPT en PPTX naar PDF in .NET [Geavanceerde functies inbegrepen]
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

PowerPoint-presentaties (PPT, PPTX, ODP, enz.) omzetten naar PDF-formaat in C# biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay-out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF-documenten converteert, diverse opties gebruikt om de beeldkwaliteit te regelen, verborgen dia's opneemt, PDF-bestanden met een wachtwoord beveiligt, lettertypevervangingen detecteert, specifieke dia's voor conversie selecteert en conformiteitsnormen toepast op de uitvoerdocumenten.

## **PowerPoint naar PDF-conversies**

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam door als argument aan de [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met behulp van een [Opslaan](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑methode. De [Presentatie](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑klasse biedt de [Opslaan](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides voor .NET voegt zijn API‑informatie en versienummer toe aan de uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF, vult Aspose.Slides het veld Application met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren deze informatie te wijzigen of te verwijderen uit de uitvoerdocumenten.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Complete presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waarbij de resulterende PDF's nauwkeurig overeenkomen met de oorspronkelijke presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, onder andere:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Koppen en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint-naar-PDF-conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia's op als PDF met behulp van de standaard exportinstellingen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose biedt een gratis online [**PowerPoint naar PDF-converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie-naar-PDF-conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse—die u in staat stellen het resulterende PDF aan te passen, het PDF met een wachtwoord te beveiligen, of te specificeren hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen definiëren, opgeven hoe metafiles moeten worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

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

### **Automatisch afbeeldingscompressie selecteren**

Wanneer een presentatie veel foto’s of screenshots bevat, kan het verkleinen van de grootte van de geëxporteerde PDF het makkelijker maken om te e‑mailen of te downloaden. Stel [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) in op `true` om automatisch het meest geschikte compressie‑algoritme voor elke afbeelding te selecteren tijdens het PDF‑export.

Het volgende voorbeeld laadt een bestaande presentatie, schakelt automatische afbeeldingscompressie‑selectie in, en slaat deze op als PDF‑document. Alle andere PDF‑exportinstellingen behouden hun standaardwaarden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Deze optie kiest een compressie‑algoritme voor elke afbeelding. Het verlagen van [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) vermindert echter de JPEG‑beeldkwaliteit, terwijl het verlagen van [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) toestaat dat afbeeldingen worden verkleind naar een lagere resolutie, wat details kan verminderen. Het inschakelen van automatische compressie‑selectie verlaagd op zichzelf niet een van deze instellingen.

Het selecteren van afbeeldingscompressie‑algoritmen vereist extra verwerkingstijd en geheugen. De grootte‑reductie hangt af van de afbeeldingen in de presentatie en de exportinstellingen; een vaste reductie kan niet voor elke presentatie worden gegarandeerd.

### **Ingesloten OLE‑bestanden behouden als PDF‑bijlagen**

Als een presentatie een ingebed Excel-werkboek bevat, wilt u mogelijk dat PDF‑ontvangers zowel de gegevens van het werkboek als de dia's kunnen bekijken. Stel [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) in op `true` om ingesloten OLE‑bestanden te behouden als bijlagen in de resulterende PDF.

De standaardwaarde is `false`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt op de PDF‑pagina gerenderd, maar het ingesloten bestand wordt niet toegevoegd als bijlage. Het instellen van de optie op `true` voegt bovendien de bestandsdata toe. De voorbeeldweergave blijft een visuele representatie; de bijlage stelt ontvangers in staat het ingesloten bestand afzonderlijk te openen of op te slaan. Het OLE‑object wordt geen interactief Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die al een ingebed Excel‑werkboek bevat en exporteert deze naar PDF met het werkboek als bijlage.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Om het resultaat te controleren:

1. Open de geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek het ingesloten werkboek.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dat toestaat. De voorbeeldweergave op de PDF‑pagina is gescheiden van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑normen leggen beperkingen op aan bijlagen: PDF/A-1 verbiedt ingesloten bestanden, PDF/A-2 staat alleen PDF/A‑bijlagen toe, en PDF/A-3 staat andere bestandstypen toe, inclusief Excel‑werkboeken. Dit zijn vereisten van de normen, geen beperkingen die specifiek zijn voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑conformiteitsinstelling en toont geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de eigenschap [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) van de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse gebruiken om de verborgen dia's op te nemen als pagina's in de resulterende PDF.

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

Het volgende voorbeeld exporteert een presentatie naar een PDF die het wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Lettertypevervangingen detecteren**

Aspose.Slides biedt de eigenschap [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) onder de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse, waarmee u tijdens het presentatie-naar-PDF-conversieproces lettertypevervangingen kunt detecteren.

Het volgende voorbeeld exporteert een presentatie naar PDF en drukt lettertypevervangingswaarschuwingen af naar de console. Een waarschuwing wordt alleen weergegeven wanneer een niet‑beschikbaar lettertype tijdens de export wordt vervangen.

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
Voor meer informatie over lettertypevervanging, zie het artikel [Lettertypevervanging](/slides/nl/net/font-substitution/).
{{% /alert %}}

### **Lettertypen zonder aparte vetlettertype verwerken**

Een presentatie kan vette opmaak toepassen op tekst, zelfs wanneer het lettertype geen eigen vetlettertype heeft. De tekst kan toch vet lijken door synthetisch vet maken, waarbij de gewone glyphs kunstmatig worden verdikt. Wanneer die tekst te zwaar lijkt of anders afwijkt van de gewenste weergave in PDF, probeer dan [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) in te stellen op `true`. Deze optie rendert de betreffende tekst als een bitmap tijdens het PDF‑export en kan het uiterlijk voor bepaalde lettertypen verbeteren. De standaardwaarde is `false`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vet opgemaakte tekst toegepast op hetzelfde lettertype, dat geen aparte vetlettertype heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in, en exporteert deze naar PDF:

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

De volgende voorbeelden tonen de uitvoer met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vette tekst zwaardere lijnen wanneer de optie is uitgeschakeld. Met de optie ingeschakeld zijn de lijnen lichter; de gewone tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`false`, de standaard) | Optie ingeschakeld (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In dit voorbeeld maakt het inschakelen van de optie alleen de vette tekst een bitmap: deze kan niet worden geselecteerd, gekopieerd of als tekst worden doorzocht zonder OCR, en de randen verschijnen zachter bij 800% zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die vet is opgemaakt wanneer het lettertype geen aparte vetlettertype heeft. [Lettertypevervanging](/slides/nl/net/font-substitution/) selecteert in plaats daarvan een ander lettertype wanneer het oorspronkelijke niet beschikbaar is.

## **Selecteerde dia's uit PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia's 1 en 3 uit een presentatie naar PDF. De dianummers in deze array starten bij één, en de invoerpresentatie moet minstens drie dia's bevatten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Het volgende voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud om te passen en exporteert de enkele dia naar PDF.

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

## **PowerPoint naar PDF converteren in notities‑diaweergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de spreker‑notities van elke dia onder de dia worden geplaatst. Gebruik een presentatie met spreker‑notities om het resultaat te zien.

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

## **Toegankelijkheids‑ en conformiteitsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met behulp van een van deze conformiteitsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze C#‑code demonstreert een PowerPoint‑naar‑PDF-conversieproces dat meerdere PDF's genereert op basis van verschillende conformiteitsnormen:

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
U kunt [PDF naar HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—worden ook ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, grafieken en formules als één enkel object. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen gemarkeerd worden als artefacten; alternatieve tekst wordt alleen voor het hele object geleverd.

## **Veelgestelde vragen**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatically toepassen.

**Is het mogelijk om de geconverteerde PDF met een wachtwoord te beveiligen?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia's op in de PDF?**

Stel de eigenschap [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) in de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse in op `true` om verborgen dia's op te nemen in de resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen door eigenschappen zoals [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) en [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) in de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑klasse in te stellen om hoge‑kwaliteitsbeelden in uw PDF te garanderen.

**Ondersteunt Aspose.Slides PDF/A-conformiteitsnormen?**

Ja, Aspose.Slides stelt u in staat PDF's te exporteren die voldoen aan verschillende normen, waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan de eisen voor toegankelijkheid en archivering.

## **Aanvullende bronnen**

- [Aspose.Slides voor .NET-documentatie](/slides/nl/net/)
- [Aspose.Slides voor .NET API‑referentie](https://reference.aspose.com/slides/net/)
- [Aspose gratis online converters](https://products.aspose.app/slides/conversion)
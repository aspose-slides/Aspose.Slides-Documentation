---
title: Convert PPT en PPTX naar PDF in .NET [Geavanceerde functies inbegrepen]
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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's in .NET met Aspose.Slides, met snelle C# code‑voorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in C# biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te beheersen, verborgen dia’s kunt opnemen, PDF‑bestanden met een wachtwoord kunt beveiligen, lettertype‑substitutie kunt detecteren, specifieke dia’s voor conversie kunt selecteren en nalevingsnormen kunt toepassen op de uitvoerdocumenten.

## **PowerPoint‑naar‑PDF‑conversies**

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse en slaat u vervolgens de presentatie op als PDF met behulp van een [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) methode. De [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse biedt de [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) methode die meestal wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides voor .NET voegt zijn API‑informatie en versienummer toe aan uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld Application met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie uit uitvoerdocumenten te wijzigen of te verwijderen.
{{% /alert %}}

Aspose.Slides stelt u in staat te converteren:

* Volledige presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waardoor de resulterende PDF’s nauwkeurig overeenkomen met de originele presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Paragraafopmaak
* Hyperlinks
* Kop- en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op maximale kwaliteitsniveaus.

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

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) klasse—die u in staat stellen het resulterende PDF‑document aan te passen, het PDF‑bestand met een wachtwoord te beveiligen, of te bepalen hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteit instellen voor raster‑afbeeldingen, bepalen hoe metafiles worden verwerkt, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

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

### **Embedded OLE‑bestanden behouden als PDF‑bijlagen**

Als een presentatie een ingesloten Excel‑werkmap bevat, wilt u misschien dat PDF‑ontvangers zowel de gegevens van de werkmap kunnen bekijken als de dia's. Zet [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) op `true` om ingesloten OLE‑bestanden te behouden als bijlagen in het resulterende PDF.

De standaardwaarde is `false`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt getekend op de PDF‑pagina, maar het ingesloten bestand wordt niet opgenomen als bijlage. Door de optie op `true` te zetten, wordt bovendien de bestandsdata toegevoegd. De voorbeeldweergave blijft een visuele weergave; de bijlage stelt ontvangers in staat het ingesloten bestand apart te openen of op te slaan. Het OLE‑object wordt geen interactieve Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die al een ingesloten Excel‑werkmap bevat en exporteert deze naar PDF met de werkmap als bijlage.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Om het resultaat te controleren:

1. Open de geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek de ingesloten werkmap.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dit toestaat. De voorbeeldweergave op de PDF‑pagina is gescheiden van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑normen leggen beperkingen op aan bijlagen: PDF/A‑1 verbiedt ingesloten bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, waaronder Excel‑werkmappen. Dit zijn vereisten van de norm, niet beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en demonstreert geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de eigenschap [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) van de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) klasse gebruiken om de verborgen dia's op te nemen als pagina's in het resulterende PDF.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief eventuele verborgen dia's.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint naar een wachtwoordbeveiligde PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF die het wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken in hoge kwaliteit.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Lettertype‑substitutie detecteren**

Aspose.Slides biedt de eigenschap [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) onder de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) klasse, waarmee u lettertype‑substitutie kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Het volgende voorbeeld exporteert een presentatie naar PDF en print waarschuwingen voor lettertype‑substitutie naar de console. Een waarschuwing wordt alleen weergegeven wanneer een niet‑beschikbaar lettertype tijdens de export wordt vervangen.

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
Voor meer informatie over lettertype‑substitutie, zie het artikel [Lettertype‑substitutie](/slides/nl/net/font-substitution/).
{{% /alert %}} 

### **Lettertypen zonder eigen vet‑typeface behandelen**

Een presentatie kan vette opmaak toepassen op tekst zelfs als het lettertype geen eigen vet typeface heeft. De tekst kan nog steeds vet lijken door synthetische vetting, die de reguliere glyphs kunstmatig verdikt. Wanneer die tekst te zwaar lijkt of anderszins afwijkt van het beoogde uiterlijk in PDF, probeer dan [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) op `true` te zetten. Deze optie rendert de betreffende tekst als bitmap tijdens de PDF‑export en kan het uiterlijk voor bepaalde lettertypen verbeteren. De standaardwaarde is `false`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vet opgemaakte tekst op hetzelfde lettertype, dat geen eigen vet typeface heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in, en exporteert deze naar PDF:

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

De onderstaande voorbeeldweergaven tonen de uitvoer met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vetgedrukte tekst zwaardere streken wanneer de optie is uitgeschakeld. Met de optie ingeschakeld zijn de streken lichter; de gewone tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`false`, de standaard) | Optie ingeschakeld (`true`) |
|---|---|
| ![PDF met rasterisatie van niet‑ondersteunde lettertype‑stijl uitgeschakeld](unsupported-bold-disabled.png) | ![PDF met rasterisatie van niet‑ondersteunde lettertype‑stijl ingeschakeld](unsupported-bold-enabled.png) |

In dit voorbeeld zet het inschakelen van de optie alleen de vetgedrukte tekst om in een bitmap: deze kan niet worden geselecteerd, gekopieerd of als tekst worden doorzocht zonder OCR, en de randen lijken zachter bij 800 % zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die vet is opgemaakt wanneer het lettertype geen eigen vet typeface heeft. [Lettertype‑substitutie](/slides/nl/net/font-substitution/) selecteert in plaats daarvan een ander lettertype wanneer het originele niet beschikbaar is.

## **Geselecteerde dia's van PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia 1 en 3 uit een presentatie naar PDF. Dia‑nummers in deze array zijn één‑gebaseerd, en de invoerpresentatie moet minimaal drie dia's bevatten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Het volgende voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de inhoud van de dia zodat deze past en exporteert de enkele dia naar PDF.

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

## **PowerPoint naar PDF converteren in notitie‑dia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de aantekeningen van elke dia onder de dia worden geplaatst. Gebruik een presentatie met aantekeningen om het resultaat te zien.

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

## **Toegankelijkheids‑ en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze C#‑code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden oplevert op basis van verschillende nalevingsnormen:

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
Aspose.Slides ondersteunt PDF‑conversie‑bewerkingen, waardoor u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑bewerkingen naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—worden ook ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de hele figuur geleverd.

## **Veelgestelde vragen**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF‑bestand met een wachtwoord te beveiligen?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia's op in de PDF?**

Stel de eigenschap [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) in de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) klasse in op `true` om verborgen dia's op te nemen in het resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in het PDF behouden?**

Ja, u kunt de beeldkwaliteit beheersen door eigenschappen zoals [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) en [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) in de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) klasse in te stellen om ervoor te zorgen dat uw PDF beelden van hoge kwaliteit bevat.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat PDF’s te exporteren die voldoen aan verschillende normen, inclusief PDF/A1a, PDF/A1b, en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides voor .NET documentatie](/slides/nl/net/)
- [Aspose.Slides voor .NET API‑referentie](https://reference.aspose.com/slides/net/)
- [Aspose gratis online converters](https://products.aspose.app/slides/conversion)
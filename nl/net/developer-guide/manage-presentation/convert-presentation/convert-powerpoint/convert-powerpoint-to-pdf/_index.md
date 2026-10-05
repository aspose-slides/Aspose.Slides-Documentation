---
title: PPT en PPTX naar PDF converteren in .NET [Geavanceerde functies inbegrepen]
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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's in .NET met Aspose.Slides, met snelle C# code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

Het omzetten van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in C# biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te beheersen, verborgen dia’s opneemt, PDF‑bestanden met een wachtwoord beveiligt, lettertype‑vervangeningen detecteert, specifieke dia’s selecteert voor conversie en nalevingsstandaarden toepast op de uitvoer‑documenten.

## **PowerPoint naar PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class en slaat u vervolgens de presentatie op als PDF met behulp van een [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) methode. De [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class biedt de [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) methode die meestal wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides voor .NET voegt zijn API‑informatie en versienummer toe aan de uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF, vult Aspose.Slides het toepassingsveld in met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie te wijzigen of te verwijderen uit uitvoer‑documenten.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, zodat de resulterende PDF‑bestanden nauw aansluiten bij de originele presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Paragraafopmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de aangeleverde presentatie te converteren naar PDF met optimale instellingen op het hoogste kwaliteitsniveau.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia's op als PDF met behulp van de standaard exportinstellingen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live uitvoering van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides levert aangepaste opties – eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class – die u in staat stellen om het resulterende PDF aan te passen, het PDF te beveiligen met een wachtwoord, of op te geven hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteit voor raster‑afbeeldingen bepalen, opgeven hoe metabestanden moeten worden verwerkt, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, beeldresolutie ingesteld op 300 DPI, metabestanden opgeslagen als PNG, en Flate‑tekstcompressie.

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

### **Inbedding van OLE‑bestanden behouden als PDF‑bijlagen**

Als een presentatie een ingebedde Excel‑werkmap bevat, wilt u wellicht dat PDF‑ontvangers zowel de gegevens van de werkmap als de dia's kunnen bekijken. Stel [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) in op `true` om ingebedde OLE‑bestanden te behouden als bijlagen in het resulterende PDF.

De standaardwaarde is `false`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt op de PDF‑pagina weergegeven, maar het ingebedde bestand wordt niet als bijlage toegevoegd. Door de optie op `true` te zetten, wordt de bestandsdata bovendien toegevoegd. De preview blijft een visuele weergave; de bijlage laat ontvangers het ingebedde bestand afzonderlijk openen of opslaan. Het OLE‑object wordt niet een interactief Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die reeds een ingebedde Excel‑werkmap bevat en exporteert deze naar PDF met de werkmap als bijlage.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Om het resultaat te controleren:

1. Open het geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek de ingesloten werkmap.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dit toestaat. De preview op de PDF‑pagina is gescheiden van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑standaarden leggen beperkingen op voor bijlagen: PDF/A-1 verbiedt ingebedde bestanden, PDF/A-2 staat alleen PDF/A‑bijlagen toe, en PDF/A-3 staat andere bestandstypen toe, inclusief Excel‑werkboeken. Dit zijn vereisten van de standaarden, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld maakt gebruik van de standaard PDF‑nalevingsinstelling en demonstreert geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de eigenschap [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) van de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class gebruiken om de verborgen dia's als pagina's op te nemen in het resulterende PDF.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief alle verborgen dia's.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint naar een wachtwoord‑beveiligd PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF dat het wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Vervanging van lettertypen detecteren**

Aspose.Slides biedt de eigenschap [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) onder de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class, waarmee u tijdens het presentatie‑naar‑PDF‑conversieproces lettertype‑vervanging kunt detecteren.

Het volgende voorbeeld exporteert een presentatie naar PDF en schrijft waarschuwingen voor lettertype‑vervanging naar de console. Een waarschuwing wordt alleen weergegeven wanneer een niet‑beschikbaar lettertype wordt vervangen tijdens de export.

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
Voor meer informatie over lettertype‑vervanging, zie het artikel [Lettertype‑vervanging](/slides/nl/net/font-substitution/).
{{% /alert %}} 

## **Geselecteerde dia's uit PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia 1 en 3 uit een presentatie naar PDF. De dianummers in deze array beginnen bij één, en de invoerpresentatie moet minstens drie dia's bevatten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint naar PDF converteren met aangepaste diaformaat**

Het volgende voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een diaformaat van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud zodat deze past en exporteert de enkele dia naar PDF.

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

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de aantekeningen van elke spreker onder de dia worden geplaatst. Gebruik een presentatie die aantekeningen bevat om het resultaat te zien.

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

## **Toegankelijkheid en nalevingsstandaarden voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met elk van deze nalevingsstandaarden: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze C#‑code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden genereert op basis van verschillende nalevingsstandaarden:

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
Aspose.Slides ondersteunt PDF‑conversie‑operaties, zodat u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) en [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten —[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), en [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)— worden eveneens ondersteund.
{{% /alert %}}

> **Opmerking:** Bij exporteren naar PDF/UA behandelt Aspose.Slides complexe graphics zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet behouden als afzonderlijke inhoud en kunnen als artefacten gemarkeerd worden; alternatieve tekst wordt alleen voor de gehele figuur geleverd.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatic matig toepassen.

**Is het mogelijk om het geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe kan ik verborgen dia's opnemen in het PDF?**

Stel de eigenschap [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) in de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class in op `true` om verborgen dia's op te nemen in het resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in het PDF behouden?**

Ja, u kunt de beeldkwaliteit beheersen door eigenschappen zoals [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) en [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) in de [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) class in te stellen om hoogwaardige afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsstandaarden?**

Ja, Aspose.Slides stelt u in staat PDF's te exporteren die voldoen aan diverse standaarden, waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijksheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides voor .NET-documentatie](/slides/nl/net/)
- [Aspose.Slides voor .NET API‑referentie](https://reference.aspose.com/slides/net/)
- [Aspose gratis online converters](https://products.aspose.app/slides/conversion)
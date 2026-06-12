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
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF’s in .NET met Aspose.Slides, met snelle C# code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in C# biedt diverse voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te regelen, verborgen dia’s meeneemt, PDF‑bestanden met een wachtwoord beveiligt, lettertype‑substituties detecteert, specifieke dia’s selecteert voor conversie en nalevingsstandaarden toepast op de uitvoer‑documenten.

## **PowerPoint-naar-PDF-conversies**

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie te converteren naar PDF, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse en slaat u de presentatie vervolgens op als PDF met behulp van een [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) methode. De [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse biedt de [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides voor .NET voegt zijn API‑informatie en versienummer toe aan de output‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF, vult Aspose.Slides het Application‑veld in met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie uit de output‑documenten te wijzigen of te verwijderen.

{{% /alert %}}

Aspose.Slides maakt het mogelijk om:

* Complete presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waarbij de resulterende PDF‑bestanden nauw aansluiten bij de oorspronkelijke presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Koppen en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie te converteren naar PDF met optimale instellingen op het hoogste kwaliteitsniveau.

```c#
// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
using var presentation = new Presentation("PowerPoint.ppt");

// Sla de presentatie op als PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose biedt een gratis online **PowerPoint‑naar‑PDF‑converter** die het conversie‑proces van presentatie naar PDF demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen van de [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/) klasse—die u in staat stellen het resulterende PDF aan te passen, het PDF met een wachtwoord te beveiligen of te bepalen hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor rasterafbeeldingen definiëren, bepalen hoe metafiles verwerkt moeten worden, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, enzovoort.

```c#
 // Instantieer de PdfOptions-klasse.
 var pdfOptions = new PdfOptions
 {
     // Stel de kwaliteit in voor JPG-afbeeldingen.
     JpegQuality = 90,

     // Stel de DPI in voor afbeeldingen.
     SufficientResolution = 300,

     // Stel het gedrag in voor metafiles.
     SaveMetafilesAsPng = true,

     // Stel het tekstcompressieniveau in voor tekstuele inhoud.
     TextCompression = PdfTextCompression.Flate,

     // Definieer de PDF-nalevingsmodus.
     Compliance = PdfCompliance.Pdf15
 };

 // Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
 using var presentation = new Presentation("PowerPoint.pptx");

 // Sla de presentatie op als een PDF‑document.
 presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de [ShowHiddenSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/showhiddenslides/) eigenschap van de [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/) klasse gebruiken om de verborgen dia's als pagina's in het resulterende PDF op te nemen.

Deze C#‑code toont hoe u een PowerPoint‑presentatie kunt omzetten naar PDF met verborgen dia's inbegrepen:

```c#
 // Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
 using var presentation = new Presentation("PowerPoint.pptx");

 // Instantieer de PdfOptions-klasse.
 var pdfOptions = new PdfOptions();

 // Voeg verborgen dia's toe.
 pdfOptions.ShowHiddenSlides = true;

 // Sla de presentatie op als PDF.
 presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint naar wachtwoord‑beveiligde PDF converteren**

Deze C#‑code toont hoe u een PowerPoint‑presentatie kunt omzetten naar een wachtwoord‑beveiligde PDF met behulp van de beveiligingsparameters van de [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/) klasse:

```c#
// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
using var presentation = new Presentation("PowerPoint.pptx");

// Instantieer de PdfOptions-klasse.
var pdfOptions = new PdfOptions();

// Stel een PDF-wachtwoord en toegangsrechten in.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Sla de presentatie op als PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Lettertype‑substituties detecteren**

Aspose.Slides levert de [WarningCallback](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveoptions/warningcallback/) eigenschap onder de [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/) klasse, waarmee u lettertype‑substituties kunt detecteren tijdens het PowerPoint‑naar‑PDF‑conversieproces.

Deze C#‑code toont hoe u lettertype‑substituties kunt detecteren:

```c#
public static void Main()
{
    // Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt. 
    using var presentation = new Presentation("sample.pptx");

    // Stel de waarschuwingscallback in PDF-opties in.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Sla de presentatie op als PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementatie van de waarschuwingscallback.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Voor meer informatie over het ontvangen van callbacks voor lettertype‑substituties tijdens het renderen, zie [Getting Warning Callbacks for Fonts Substitution](/slides/nl/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Voor meer informatie over lettertype‑substitutie, zie het artikel [Font Substitution](/slides/nl/net/font-substitution/).

{{% /alert %}} 

## **Geselecteerde dia's uit PowerPoint naar PDF converteren**

Deze C#‑code toont hoe u alleen specifieke dia's uit een PowerPoint‑presentatie kunt converteren naar PDF:

```c#
// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
using var presentation = new Presentation("PowerPoint.pptx");

// Stel array van dia-nummers in.
int[] slides = { 1, 3 };

// Sla de presentatie op als PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze C#‑code toont hoe u een PowerPoint‑presentatie naar PDF converteert met een opgegeven dia‑grootte:

```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **PowerPoint naar PDF converteren in notities‑dia‑weergave**

Deze C#‑code toont hoe u een PowerPoint‑presentatie naar een PDF converteert die notities bevat:

```c#
// Laad een PowerPoint‑presentatie.
using var presentation = new Presentation("NotesFile.pptx");

// Configureer de PDF‑opties met notitie‑lay‑out.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Sla de presentatie op als PDF met notities.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Toegankelijkheid‑ en nalevingsstandaarden voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsstandaarden: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze C#‑code toont een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden genereert op basis van verschillende nalevingsstandaarden:

```c#
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides ondersteunt PDF‑conversie‑bewerkingen, waardoor u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/nl/net/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/nl/net/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/nl/net/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/nl/net/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversiebewerkingen naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/nl/net/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/nl/net/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/nl/net/conversion/pdf-to-xml/)—worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkel figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten gemarkeerd worden; alternatieve tekst wordt alleen voor het volledige figuur geleverd.

## **Veelgestelde vragen**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF te beveiligen met een wachtwoord?**

Absoluut. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/) klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia's op in het PDF?**

Stel de `ShowHiddenSlides`‑eigenschap in de [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/) klasse in op `true` om verborgen dia's op te nemen in het resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in het PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen door eigenschappen zoals `JpegQuality` en `SufficientResolution` in de [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/) klasse in te stellen zodat er hoge‑kwaliteit afbeeldingen in uw PDF verschijnen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsstandaarden?**

Ja, Aspose.Slides maakt het mogelijk PDF’s te exporteren die voldoen aan diverse standaarden, waaronder PDF/A1a, PDF/A1b en PDF/UA, waardoor uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides voor .NET Documentatie](/slides/nl/net/)
- [Aspose.Slides voor .NET API‑referentie](https://reference.aspose.com/slides/nl/net/)
- [Aspose gratis online converters](https://products.aspose.app/slides/nl/conversion)
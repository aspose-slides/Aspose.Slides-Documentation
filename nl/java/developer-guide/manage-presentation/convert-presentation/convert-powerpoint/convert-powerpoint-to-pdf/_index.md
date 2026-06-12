---
title: Converteer PPT en PPTX naar PDF in Java [Geavanceerde functies inbegrepen]
linktitle: PowerPoint naar PDF
type: docs
weight: 40
url: /nl/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF‑bestanden in Java met Aspose.Slides, voorzien van snelle code‑voorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in Java biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids toont hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te regelen, verborgen dia's kunt opnemen, PDF‑bestanden met een wachtwoord kunt beveiligen, lettertype‑vervangingen kunt detecteren, specifieke dia's voor conversie kunt selecteren en nalevingsnormen kunt toepassen op de uitvoer‑documenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met behulp van de `save`‑methode. De [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse biedt de `save`‑methode die gewoonlijk wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java voegt zijn API‑informatie en versienummer toe aan uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld Application met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Let op** dat u Aspose.Slides niet kunt instrueren om deze informatie uit de uitvoer‑documenten te wijzigen of te verwijderen.

{{% /alert %}}

Aspose.Slides maakt het mogelijk om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de resulterende PDF‑bestanden nauw aansluiten bij de originele presentaties. Elementen en attributen worden nauwkeurig weergegeven tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

```java
// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Sla de presentatie op als PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose biedt een gratis online [**PowerPoint naar PDF‑converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse — waarmee u het resulterende PDF kunt aanpassen, het PDF kunt vergrendelen met een wachtwoord, of kunt opgeven hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste convertiemogelijkheden kunt u uw gewenste kwaliteit instellen voor raster‑afbeeldingen, aangeven hoe metafiles behandeld moeten worden, een compressieniveau voor tekst bepalen, DPI voor afbeeldingen configureren, en meer.

Het onderstaande code‑voorbeeld toont hoe u een PowerPoint‑presentatie naar PDF kunt converteren met verschillende aangepaste opties.

```java
// Maak een instantie van de PdfOptions-klasse.
PdfOptions pdfOptions = new PdfOptions();

// Stel de kwaliteit in voor JPG-afbeeldingen.
pdfOptions.setJpegQuality((byte)90);

// Stel DPI in voor afbeeldingen.
pdfOptions.setSufficientResolution(300);

// Stel het gedrag in voor metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Stel het tekstcompressieniveau in voor tekstuele inhoud.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definieer de PDF-nalevingsmodus.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // Save the presentation as a PDF document.
    // Sla de presentatie op als een PDF-document.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)‑methode van de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia's als pagina's in het resulterende PDF op te nemen.

Deze code toont hoe u een PowerPoint‑presentatie naar PDF kunt converteren met inbegrepen verborgen dia's:

```java
// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Maak een instantie van de PdfOptions-klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Voeg verborgen dia's toe.
    pdfOptions.setShowHiddenSlides(true);

    // Sla de presentatie op als PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint naar PDF met wachtwoord beveiligen**

Deze code laat zien hoe u een PowerPoint‑presentatie kunt omzetten naar een wachtwoord‑beveiligde PDF met behulp van de beveiligingsparameters van de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse:

```java
// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Maak een instantie van de PdfOptions-klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Stel een PDF-wachtwoord en toegangsrechten in.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Sla de presentatie op als PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Lettertype‑vervangingen detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse, waardoor u lettertype‑vervangingen kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Deze code laat zien hoe u lettertype‑vervangingen kunt detecteren:

```java
public static void main(String[] args) {
    // Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
    Presentation presentation = new Presentation("sample.pptx");

    // Stel de waarschuwingcallback in bij de PDF-opties.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Sla de presentatie op als PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// Implementatie van de waarschuwingcallback.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Voor meer informatie over het ontvangen van callbacks voor lettertype‑vervangingen tijdens het render‑proces, zie [Getting Warning Callbacks for Fonts Substitution](/slides/nl/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Voor meer informatie over lettertype‑vervanging, zie het artikel [Font Substitution](/slides/nl/java/font-substitution/).

{{% /alert %}} 

## **Geselecteerde dia's in PowerPoint naar PDF converteren**

Deze code toont hoe u alleen specifieke dia's uit een PowerPoint‑presentatie naar PDF kunt converteren:

```java
// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Stel een array met dia-nummers in.
    int[] slides = { 1, 3 };

    // Sla de presentatie op als PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze code toont hoe u een PowerPoint‑presentatie naar PDF kunt converteren met een opgegeven dia‑grootte:

```java
float slideWidth = 612;
float slideHeight = 792;

// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Maak een nieuwe presentatie met een aangepaste dia-grootte.
Presentation resizedPresentation = new Presentation();

try {
    // Stel de aangepaste dia-grootte in.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // Kloon de eerste dia van de originele presentatie.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Sla de aangepaste presentatie op als PDF met notities.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint naar PDF in notitie‑dia‑weergave**

Deze code toont hoe u een PowerPoint‑presentatie naar een PDF kunt converteren dat notities bevat:

```java
// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Configureer de PDF-opties met notitie‑lay-out.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Sla de presentatie op als een PDF met notities.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Toegankelijkheids‑ en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met behulp van een van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze code toont een PowerPoint‑naar‑PDF‑conversieprocedure die meerdere PDF‑bestanden genereert op basis van verschillende nalevingsnormen:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides ondersteunt PDF‑conversie‑bewerkingen, waardoor u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt conversies uitvoeren zoals [PDF naar HTML](https://products.aspose.com/slides/nl/java/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/nl/java/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-png/). Andere PDF‑conversie‑bewerkingen naar gespecialiseerde formaten — [PDF naar SVG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/nl/java/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/nl/java/conversion/pdf-to-xml/) — worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe graphics zoals SmartArt, diagrammen en formules als één enkel figuur. Individuele pad‑elementen worden niet behouden als afzonderlijke inhoud en kunnen als artefacten gemarkeerd worden; alternatieve tekst wordt alleen voor het gehele figuur verstrekt.

## **Veelgestelde vragen**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk om de geconverteerde PDF met een wachtwoord te beveiligen?**

Zeker. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe kan ik verborgen dia's opnemen in de PDF?**

Gebruik de `setShowHiddenSlides`‑methode in de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse om verborgen dia's op te nemen in de resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen met methoden zoals `setJpegQuality` en `setSufficientResolution` in de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse om hoogwaardige afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides de PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat PDF‑bestanden te exporteren die voldoen aan [verschillende normen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiverings‑vereisten.

## **Aanvullende bronnen**

- [Aspose.Slides voor Java Documentatie](/slides/nl/java/)
- [Aspose.Slides voor Java API‑referentie](https://reference.aspose.com/slides/nl/java/)
- [Aspose gratis online converters](https://products.aspose.app/slides/nl/conversion)
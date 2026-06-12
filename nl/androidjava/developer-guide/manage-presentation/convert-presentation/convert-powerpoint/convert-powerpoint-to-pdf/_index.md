---
title: Converteer PPT en PPTX naar PDF op Android [Geavanceerde functies inbegrepen]
linktitle: PowerPoint naar PDF
type: docs
weight: 40
url: /nl/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's in Java met Aspose.Slides voor Android, met snelle code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) converteren naar PDF‑formaat op Android biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te beheersen, verborgen dia’s kunt opnemen, PDF‑bestanden met een wachtwoord kunt beveiligen, lettertypevervangingen kunt detecteren, specifieke dia’s kunt selecteren voor conversie en nalevingsnormen kunt toepassen op de uitvoerbestanden.

## **PowerPoint naar PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument door aan de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met behulp van de `save`‑methode. De [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse biedt de `save`‑methode die gewoonlijk wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java voegt zijn API‑informatie en versienummer toe aan uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het toepassingsveld met "*Aspose.Slides*" en het PDF‑producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie uit uitvoerdocumenten te wijzigen of te verwijderen.

{{% /alert %}}

Aspose.Slides staat u toe om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia’s uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de resulterende PDF’s nauw aansluiten bij de originele presentaties. Elementen en attributen worden nauwkeurig weergegeven in de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Koppen en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces maakt gebruik van standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

Deze code laat zien hoe u een presentatie (PPT, PPTX, ODP, enz.) naar PDF kunt converteren:

```java
// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand representeert.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Sla de presentatie op als PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose biedt een gratis online [**PowerPoint‑naar‑PDF‑converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse—die u in staat stellen het resulterende PDF aan te passen, het PDF te beveiligen met een wachtwoord, of te specificeren hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor rasterafbeeldingen definiëren, aangeven hoe metafiles moeten worden verwerkt, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

Het onderstaande code‑voorbeeld laat zien hoe u een PowerPoint‑presentatie naar PDF kunt converteren met verschillende aangepaste opties.

```java
// Instantieer de PdfOptions-klasse.
PdfOptions pdfOptions = new PdfOptions();

// Stel de kwaliteit in voor JPG-afbeeldingen.
pdfOptions.setJpegQuality((byte)90);

// Stel de DPI in voor afbeeldingen.
pdfOptions.setSufficientResolution(300);

/// Stel het gedrag voor metafiles in.
pdfOptions.setSaveMetafilesAsPng(true);

// Stel het tekstcompressieniveau in voor tekstuele inhoud.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definieer de PDF-nalevingsmodus.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand representeert.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Sla de presentatie op als PDF-document.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint naar PDF converteren met verborgen dia’s**

Als een presentatie verborgen dia’s bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)‑methode van de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia’s als pagina’s in het resulterende PDF op te nemen.

Deze code toont hoe u een PowerPoint‑presentatie naar PDF kunt converteren met meegebrachte verborgen dia’s:

```java
// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand representeert.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instantieer de PdfOptions-klasse.
    PdfOptions pdfOptions = new PdfOptions();

    // Voeg verborgen dia's toe.
    pdfOptions.setShowHiddenSlides(true);

    // Sla de presentatie op als PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint naar met wachtwoord beveiligde PDF converteren**

Deze code laat zien hoe u een PowerPoint‑presentatie kunt omzetten naar een met wachtwoord beveiligde PDF met behulp van de beveiligingsparameters uit de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse:

```java
// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand representeert.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instantieer de PdfOptions-klasse.
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

### **Lettertypevervangingen detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse, waarmee u lettertypevervangingen tijdens het presentatie‑naar‑PDF‑conversieproces kunt detecteren.

Deze code toont hoe u lettertypevervangingen kunt detecteren:

```java
public static void main(String[] args) {
    // Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand representeert.
    Presentation presentation = new Presentation("sample.pptx");

    // Stel de waarschuwing callback in voor PDF-opties.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Sla de presentatie op als PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementatie van de waarschuwing callback.
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

Voor meer informatie over lettertypevervanging, zie het artikel [Font Substitution](/slides/nl/androidjava/font-substitution/).

{{% /alert %}} 

## **Geselecteerde dia’s van PowerPoint naar PDF converteren**

Deze code laat zien hoe u alleen specifieke dia’s van een PowerPoint‑presentatie naar PDF kunt converteren:

```java
// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand representeert.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Stel array van dia-nummers in.
    int[] slides = { 1, 3 };

    // Sla de presentatie op als PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze code toont hoe u een PowerPoint‑presentatie naar PDF kunt converteren met een gespecificeerde dia‑grootte:

```java
float slideWidth = 612;
float slideHeight = 792;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand representeert.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Maak een nieuwe presentatie met een aangepaste dia-grootte.
Presentation resizedPresentation = new Presentation();

try {
    // Stel de aangepaste dia-grootte in.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Kloon de eerste dia van de oorspronkelijke presentatie.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Sla de aangepaste presentatie op als PDF met notities.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren in notitie‑diaweergave**

Deze code toont hoe u een PowerPoint‑presentatie naar een PDF kunt converteren dat notities bevat:

```java
// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand representeert.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Configureer de PDF-opties met notitie-indeling.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Sla de presentatie op als PDF met notities.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Toegankelijkheids‑ en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze code toont een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF’s genereert gebaseerd op verschillende nalevingsnormen:

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

Aspose.Slides ondersteunt PDF‑conversie‑operaties, waarmee u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt conversies uitvoeren van [PDF to HTML](https://products.aspose.com/slides/nl/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/nl/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-jpg/), en [PDF to PNG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-png/). Andere PDF‑conversie‑operaties naar gespecialiseerde formaten—[PDF to SVG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nl/java/conversion/pdf-to-tiff/), en [PDF to XML](https://products.aspose.com/slides/nl/java/conversion/pdf-to-xml/)—worden ook ondersteund.

{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één figuur. Individuele pad‑elementen worden niet behouden als aparte inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de gehele figuur verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatically toepassen.

**Is het mogelijk het geconverteerde PDF met een wachtwoord te beveiligen?**

Zeker. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia’s op in het PDF?**

Gebruik de `setShowHiddenSlides`‑methode in de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse om verborgen dia’s op te nemen in het resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in het PDF behouden?**

Ja, u kunt de beeldkwaliteit beheersen met methoden zoals `setJpegQuality` en `setSufficientResolution` in de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse om hoogwaardige afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat PDF’s te exporteren die voldoen aan verschillende normen, waaronder PDF/A1a, PDF/A1b en PDF/UA, waardoor uw documenten aan toegankelijkheids‑ en archiveringsvereisten voldoen.

## **Aanvullende bronnen**

- [Aspose.Slides voor Android via Java Documentatie](/slides/nl/androidjava/)
- [Aspose.Slides voor Android via Java API‑referentie](https://reference.aspose.com/slides/nl/androidjava/)
- [Aspose gratis online converters](https://products.aspose.app/slides/nl/conversion)
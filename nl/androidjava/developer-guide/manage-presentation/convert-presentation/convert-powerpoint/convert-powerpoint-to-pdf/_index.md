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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF-bestanden in Java met Aspose.Slides voor Android, inclusief snelle code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat op Android biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay-out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de afbeeldingskwaliteit te regelen, verborgen dia's meeneemt, PDF‑bestanden met een wachtwoord beveiligt, lettertype‑substituties detecteert, specifieke dia's selecteert voor conversie en nalevingsnormen toepast op de uitvoer‑documenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse en slaat u de presentatie vervolgens op als PDF met behulp van een `save`‑methode. De [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse biedt de `save`‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="OPMERKING"  color="warning"   %}} 

Aspose.Slides for Android via Java voegt zijn API‑informatie en versienummer toe aan uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld Application in met "*Aspose.Slides*" en het veld PDF Producer met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Let op** dat u Aspose.Slides niet kunt instrueren deze informatie te wijzigen of te verwijderen uit uitvoer‑documenten.

{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia’s uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de resulterende PDF’s nauwkeurig overeenkomen met de oorspronkelijke presentaties. Elementen en attributen worden correct gerenderd tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

Deze code laat zien hoe u een presentatie (PPT, PPTX, ODP, enz.) naar PDF converteert:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation‑klasse die een PowerPoint‑ of OpenDocument‑bestand voorstelt.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Sla de presentatie op als PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose biedt een gratis online [**PowerPoint naar PDF‑converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het conversieproces van presentatie naar PDF demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse — die u in staat stellen het resulterende PDF‑document aan te passen, het PDF te beveiligen met een wachtwoord of op te geven hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteit voor raster‑afbeeldingen definiëren, opgeven hoe metafiles behandeld moeten worden, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren en meer.

Het onderstaande code‑voorbeeld laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met verschillende aangepaste opties.

```java
import com.aspose.slides.*;

// Maak een instantie van de PdfOptions‑klasse.
PdfOptions pdfOptions = new PdfOptions();

// Stel de kwaliteit in voor JPG‑afbeeldingen.
pdfOptions.setJpegQuality((byte)90);

// Stel de DPI in voor afbeeldingen.
pdfOptions.setSufficientResolution(300);

/// Stel het gedrag in voor metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Stel het compressieniveau voor tekstinhoud in.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definieer de PDF‑nalevingsmodus.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Maak een instantie van de Presentation‑klasse die een PowerPoint‑ of OpenDocument‑bestand voorstelt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Sla de presentatie op als PDF‑document.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint naar PDF converteren met verborgen dia’s**

Als een presentatie verborgen dia’s bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)‑methode van de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia’s als pagina’s in het resulterende PDF op te nemen.

Deze code laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met verborgen dia’s inbegrepen:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand voorstelt.
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

### **PowerPoint naar wachtwoord‑beveiligde PDF converteren**

Deze code demonstreert hoe u een PowerPoint‑presentatie omzet naar een wachtwoord‑beveiligde PDF met behulp van de beveiligingsparameters van de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand voorstelt.
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

### **Lettertype‑substituties detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse, waarmee u lettertype‑substituties kunt detecteren tijdens het conversieproces van presentatie naar PDF.

Deze code laat zien hoe u lettertype‑substituties detecteert:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand voorstelt.
    Presentation presentation = new Presentation("sample.pptx");

    // Stel de waarschuwing callback in PDF-opties in.
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

{{%  alert color="info"  %}} 

Voor meer informatie over lettertype‑substituties, zie het artikel [Font Substitution](/slides/nl/androidjava/font-substitution/).

{{% /alert %}} 

## **Specifieke dia’s uit PowerPoint naar PDF converteren**

Deze code laat zien hoe u alleen bepaalde dia’s uit een PowerPoint‑presentatie naar PDF converteert:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand voorstelt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Stel een array van dia‑nummers in.
    int[] slides = { 1, 3 };

    // Sla de presentatie op als PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze code laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met een opgegeven dia‑grootte:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand voorstelt.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Maak een nieuwe presentatie met een aangepaste dia-grootte.
Presentation resizedPresentation = new Presentation();

try {
    // Stel de aangepaste dia-grootte in.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Kloon de eerste dia van de originele presentatie.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Verwijder de lege dia waarmee de nieuwe presentatie is aangemaakt.
    resizedPresentation.getSlides().removeAt(1);

    // Sla de aangepaste presentatie op als PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint naar PDF in notities‑dia‑view converteren**

Deze code laat zien hoe u een PowerPoint‑presentatie naar een PDF converteert die notities bevat:

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand voorstelt.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Stel de PDF-opties in met notitie‑indeling.
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

## **Toegankelijkheid en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document naar PDF exporteren volgens een van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden produceert op basis van verschillende nalevingsnormen:

```java
import com.aspose.slides.*;

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

{{% alert title="Opmerking" color="warning" %}} 

Aspose.Slides ondersteunt PDF‑conversie‑bewerkingen, waarmee u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/nl/java/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/nl/java/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-jpg/) en [PDF naar PNG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversies naar gespecialiseerde formaten — [PDF naar SVG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/nl/java/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/nl/java/conversion/pdf-to-xml/) — worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij export naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de gehele figuur verstrekt.

## **FAQ**

### Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatisch toepassen.

### Is het mogelijk het geconverteerde PDF te beveiligen met een wachtwoord?

Absoluut. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

### Hoe neem ik verborgen dia’s op in het PDF?

Gebruik de `setShowHiddenSlides`‑methode in de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse om verborgen dia’s op te nemen in het resulterende PDF.

### Kan Aspose.Slides een hoge beeldkwaliteit behouden in het PDF?

Ja, u kunt de beeldkwaliteit regelen met methoden zoals `setJpegQuality` en `setSufficientResolution` in de [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/)‑klasse om hoogwaardige afbeeldingen in uw PDF te garanderen.

### Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?

Ja, Aspose.Slides stelt u in staat PDF’s te exporteren die voldoen aan verschillende normen, waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides for Android via Java Documentatie](/slides/nl/androidjava/)
- [Aspose.Slides for Android via Java API‑referentie](https://reference.aspose.com/slides/nl/androidjava/)
- [Aspose gratis online converters](https://products.aspose.app/slides/nl/conversion)
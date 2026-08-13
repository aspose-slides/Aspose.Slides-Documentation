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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF-bestanden in Java met Aspose.Slides, inclusief snelle code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in Java biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behoud van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, diverse opties gebruikt om de beeldkwaliteit te regelen, verborgen dia’s opneemt, PDF‑bestanden met een wachtwoord beveiligt, lettertype‑substituties detecteert, specifieke dia’s selecteert voor conversie en nalevingsstandaarden toepast op de uitvoer‑documenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met een `save`‑methode. De [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse biedt de `save`‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="OPMERKING" color="warning" %}} 

Aspose.Slides for Java voegt zijn API‑informatie en versienummer toe aan uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het toepassingsveld in met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie uit uitvoer‑documenten te verwijderen of te wijzigen.

{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Hele presentaties naar PDF
* Specifieke dia’s uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de resulterende PDF‑bestanden nauwkeurig overeenkomen met de originele presentaties. Elementen en attributen worden correct gerenderd tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op de hoogste kwaliteitsniveaus.

De volgende code laat zien hoe u een presentatie (PPT, PPTX, ODP, enz.) naar PDF converteert:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Sla de presentatie op als PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert color="info" %}} 

Aspose biedt een gratis online **PowerPoint‑naar‑PDF‑converter**(https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het conversie‑proces van presentatie naar PDF demonstreert. U kunt een test uitvoeren met deze converter voor een live‑implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse — die u in staat stellen het resulterende PDF‑document aan te passen, het PDF te beveiligen met een wachtwoord of te bepalen hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw voorkeurskwaliteit voor rasterafbeeldingen definiëren, bepalen hoe metafiles worden verwerkt, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren en meer.

Het onderstaande code‑voorbeeld laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met verschillende aangepaste opties.

```java
import com.aspose.slides.*;

// Instantieer de PdfOptions-klasse.
PdfOptions pdfOptions = new PdfOptions();

// Stel de kwaliteit in voor JPG-afbeeldingen.
pdfOptions.setJpegQuality((byte)90);

// Stel DPI in voor afbeeldingen.
pdfOptions.setSufficientResolution(300);

// Stel het gedrag in voor metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Stel het tekstcompressieniveau in voor tekstinhoud.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definieer de PDF-compliance-modus.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // Sla de presentatie op als PDF-document.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint naar PDF converteren met verborgen dia’s**

Als een presentatie verborgen dia’s bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)‑methode van de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia’s op te nemen als pagina’s in het resulterende PDF‑document.

Deze code toont hoe u een PowerPoint‑presentatie naar PDF converteert met verborgen dia’s opgenomen:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
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

Deze code demonstreert hoe u een PowerPoint‑presentatie naar een met wachtwoord beveiligde PDF converteert met behulp van de beveiligingsparameters van de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
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

### **Lettertype‑substituties detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse, waarmee u lettertype‑substituties kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Deze code laat zien hoe u lettertype‑substituties detecteert:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
    Presentation presentation = new Presentation("sample.pptx");

    // Stel de waarschuwingscallback in PDF-opties in.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Sla de presentatie op als PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// Implementatie van de waarschuwingscallback.
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

{{%  alert color="info" %}} 

Voor meer informatie over het ontvangen van callbacks voor lettertype‑substituties tijdens het renderen, zie [Getting Warning Callbacks for Fonts Substitution](/slides/nl/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Voor meer informatie over lettertype‑substitutie, raadpleeg het artikel [Font Substitution](/slides/nl/java/font-substitution/).

{{% /alert %}} 

## **Geselecteerde dia’s in PowerPoint naar PDF converteren**

Deze code demonstreert hoe u alleen specifieke dia’s uit een PowerPoint‑presentatie naar PDF converteert:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Stel een array met dianummers in.
    int[] slides = { 1, 3 };

    // Sla de presentatie op als PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze code laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met een gespecificeerde dia‑grootte:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Maak een nieuwe presentatie met een aangepast diaformaat.
Presentation resizedPresentation = new Presentation();

try {
    // Stel het aangepaste diaformaat in.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // Kloon de eerste dia van de originele presentatie.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Verwijder de lege dia waarmee de nieuwe presentatie werd aangemaakt.
    resizedPresentation.getSlides().removeAt(1);

    // Sla de aangepaste presentatie op als PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren in notitie‑dia‑weergave**

Deze code toont hoe u een PowerPoint‑presentatie naar een PDF converteert dat notities bevat:

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Configureer de PDF-opties met notitie-layout.
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

## **Toegankelijkheid en nalevingsstandaarden voor PDF**

Aspose.Slides stelt u in staat om een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsstandaarden: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden genereert op basis van verschillende nalevingsstandaarden:

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

Aspose.Slides ondersteunt PDF‑conversie‑bewerkingen, zodat u PDF‑bestanden naar populaire bestandsformaten kunt converteren. U kunt [PDF naar HTML](https://products.aspose.com/slides/nl/java/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/nl/java/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-jpg/) en [PDF naar PNG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑bewerkingen naar gespecialiseerde formaten — [PDF naar SVG](https://products.aspose.com/slides/nl/java/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/nl/java/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/nl/java/conversion/pdf-to-xml/) — worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafische elementen zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet behouden als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de hele figuur verstrekt.

## **FAQ**

### Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatically toepassen.

### Is het mogelijk het geconverteerde PDF‑bestand met een wachtwoord te beveiligen?

Absoluut. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

### Hoe neem ik verborgen dia’s op in de PDF?

Gebruik de `setShowHiddenSlides`‑methode in de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse om verborgen dia’s op te nemen in het resulterende PDF‑document.

### Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?

Ja, u kunt de beeldkwaliteit regelen met methoden zoals `setJpegQuality` en `setSufficientResolution` in de [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/)‑klasse om hoogwaardige afbeeldingen in uw PDF te garanderen.

### Ondersteunt Aspose.Slides de PDF/A‑nalevingsstandaarden?

Ja, Aspose.Slides stelt u in staat om PDF‑bestanden te exporteren die voldoen aan [verschillende standaarden](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides for Java Documentatie](/slides/nl/java/)
- [Aspose.Slides for Java API‑referentie](https://reference.aspose.com/slides/nl/java/)
- [Aspose Gratis Online Converters](https://products.aspose.app/slides/nl/conversion)
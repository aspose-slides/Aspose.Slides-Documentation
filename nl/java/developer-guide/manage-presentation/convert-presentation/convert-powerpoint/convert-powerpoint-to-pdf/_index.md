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
- bijlage
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF‑bestanden in Java met Aspose.Slides, inclusief snelle code‑voorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in Java biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids toont hoe u presentaties naar PDF‑documenten converteert, diverse opties gebruikt om de afbeeldingskwaliteit te regelen, verborgen dia’s opneemt, PDF‑bestanden met een wachtwoord beveiligt, lettertype‑vervangingen detecteert, specifieke dia’s selecteert voor conversie en nalevingsstandaarden toepast op de uitvoer‑documenten.

## **PowerPoint naar PDF-conversies**

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam door als argument aan de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met behulp van de [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode. De [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑klasse biedt de [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java voegt zijn API‑informatie en versienummer toe aan de uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld Application met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren deze informatie te wijzigen of te verwijderen uit uitvoer‑documenten.
{{% /alert %}}

Aspose.Slides stelt u in staat om:

* Volledige presentaties naar PDF te converteren
* Specifieke dia’s uit een presentatie naar PDF te converteren

Aspose.Slides exporteert presentaties naar PDF, waardoor de resulterende PDF‑bestanden nauw aansluiten bij de oorspronkelijke presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, onder andere:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Koppen en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het maximum kwaliteitsniveau.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia’s op als PDF met behulp van de standaard exportinstellingen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose biedt een gratis online [**PowerPoint naar PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse — die u in staat stellen het resulterende PDF aan te passen, het PDF met een wachtwoord te beveiligen, of te specificeren hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen definiëren, bepalen hoe metabestanden moeten worden verwerkt, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ingesloten OLE‑bestanden behouden als PDF‑bijlagen**

Als een presentatie een ingebed Excel‑werkboek bevat, wilt u mogelijk dat PDF‑ontvangers de gegevens van het werkboek kunnen raadplegen naast het bekijken van de dia’s. Roep [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) aan met `true` om ingesloten OLE‑bestanden als bijlagen in het resulterende PDF te behouden.

De standaardwaarde is `false`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt op de PDF‑pagina weergegeven, maar het ingebedde bestand wordt niet opgenomen als bijlage. Als de optie op `true` wordt gezet, wordt de bestanddata bovendien bijgevoegd. De voorbeeldweergave blijft een visuele representatie; de bijlage laat ontvangers het ingebedde bestand apart openen of opslaan. Het OLE‑object wordt geen interactief Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die al een ingebed Excel‑werkboek bevat en exporteert deze naar PDF met het werkboek als bijlage.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Om het resultaat te controleren:

1. Open de geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek het ingebedde werkboek.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct indien de viewer het toestaat. De voorbeeldweergave op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑standaarden leggen beperkingen op aan bijlagen: PDF/A‑1 verbiedt ingesloten bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, waaronder Excel‑werkboeken. Dit zijn eisen van de standaarden, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en demonstreert geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia’s bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)‑methode van de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia’s op te nemen als pagina’s in het resulterende PDF.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint naar een wachtwoordbeveiligde PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF dat het wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Lettertype‑vervangingen detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse, waarmee u lettertype‑vervangingen kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Het volgende voorbeeld exporteert een presentatie naar PDF en print waarschuwingen voor lettertype‑vervangingen naar de console. Een waarschuwing wordt alleen afgedrukt wanneer een onbeschikbaar lettertype tijdens de export wordt vervangen.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Voor meer informatie over lettertype‑vervanging, zie het artikel [Lettertype‑vervanging](/slides/nl/java/font-substitution/).
{{% /alert %}} 

## **Geselecteerde dia's uit PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia’s 1 en 3 uit een presentatie naar PDF. Dia‑nummers in deze lijst beginnen bij één, en de invoerpresentatie moet minimaal drie dia’s bevatten.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Het volgende voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inches). Het schaalt de dia‑inhoud zodat deze past en exporteert de enkele dia naar PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Verwijder de lege dia die bij het aanmaken van de nieuwe presentatie is toegevoegd.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint naar PDF in notitie‑diaweergave converteren**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de spreker‑notities van elke dia onder de dia worden geplaatst. Gebruik een presentatie met spreker‑notities om het resultaat te zien.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Toegankelijkheids‑ en nalevingsstandaarden voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsstandaarden: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

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

{{% alert color="info" title="Note" %}}
Aspose.Slides ondersteunt PDF‑conversie‑operaties, waarmee u PDF‑bestanden naar populaire bestandsformaten kunt converteren. U kunt conversies uitvoeren van [PDF naar HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Andere PDF‑conversie‑operaties naar gespecialiseerde formaten — [PDF naar SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — worden ook ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkel figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen gemarkeerd worden als artefacten; alternatieve tekst wordt alleen voor het volledige figuur verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmeelmatig toepassen.

**Is het mogelijk om de geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia's op in de PDF?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) aan met `true` in de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse om verborgen dia's op te nemen in het resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit beheersen door methoden zoals [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) en [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) in de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse te gebruiken om hoogwaardige afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsstandaarden?**

Ja, Aspose.Slides stelt u in staat PDFs te exporteren die voldoen aan [diverse standaarden](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), inclusief PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides for Java Documentatie](/slides/nl/java/)
- [Aspose.Slides for Java API‑referentie](https://reference.aspose.com/slides/java/)
- [Aspose gratis online converters](https://products.aspose.app/slides/conversion)
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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's in Java met Aspose.Slides, inclusief snelle codevoorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) converteren naar PDF‑formaat in Java biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids toont hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te beheersen, verborgen dia’s opneemt, PDF‑bestanden met wachtwoord beveiligt, lettertypevervanging detecteert, specifieke dia’s selecteert voor conversie en nalevingsstandaarden toepast op de outputdocumenten.

## **PowerPoint‑naar‑PDF‑conversies**

Met Aspose.Slides kunt u presentaties in de volgende indelingen naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met behulp van een [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode. De [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑klasse biedt de [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java voegt zijn API‑informatie en versienummer toe aan uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het toepassingsveld in met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Note** dat u Aspose.Slides niet kunt instrueren om deze informatie uit uitvoerdocumenten te wijzigen of te verwijderen.

{{% /alert %}}

Aspose.Slides maakt het mogelijk om:

* Gehele presentaties naar PDF
* Specifieke dia’s van een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waarbij de resulterende PDF‑bestanden nauw aansluiten bij de originele presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, inclusief:

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

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia’s op als PDF met de standaard exportinstellingen.

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

Aspose biedt een gratis online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties – eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse – waarmee u het resulterende PDF‑bestand kunt aanpassen, het PDF‑bestand met een wachtwoord kunt beveiligen of kunt opgeven hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw voorkeurskwaliteit voor raster‑afbeeldingen definiëren, opgeven hoe metafiles moeten worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, enzovoort.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, beeldresolutie ingesteld op 300 DPI, metafiles opgeslagen als PNG en Flate‑tekstcompressie.

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

Bevat een presentatie een ingesloten Excel‑werkmap, wilt u wellicht dat PDF‑ontvangers de gegevens van de werkmap kunnen bekijken naast de dia’s. Roep [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) aan met `true` om ingesloten OLE‑bestanden te behouden als bijlagen in het resulterende PDF‑bestand.

De standaardwaarde is `false`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt weergegeven op de PDF‑pagina, maar het ingesloten bestand wordt niet toegevoegd als bijlage. Door de optie op `true` te zetten, wordt het bestand eveneens bijgevoegd. Het voorbeeld blijft een visuele representatie; de bijlage stelt ontvangers in staat het ingesloten bestand apart te openen of op te slaan. Het OLE‑object wordt niet een interactief Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die al een ingesloten Excel‑werkmap bevat en exporteert deze naar PDF met de werkmap als bijlage.

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

1. Open het geëxporteerde PDF‑bestand in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek de ingesloten werkmap.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dit toelaat. Het voorbeeld op de PDF‑pagina is gescheiden van de bijlage.

{{% alert color="info" title="Note" %}}

De PDF/A‑standaarden leggen beperkingen op voor bijlagen: PDF/A‑1 verbiedt ingesloten bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen, waaronder Excel‑werkboeken, toe. Dit zijn vereisten van de standaarden, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en demonstreert geen PDF/A‑export.

{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia’s**

Bevat een presentatie verborgen dia’s, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)‑methode van de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia’s als pagina’s in het resulterende PDF‑bestand op te nemen.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief eventuele verborgen dia’s.

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

### **PowerPoint naar een wachtwoordbeveiligd PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF die het wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

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

### **Lettertypevervanging detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse, waarmee u lettertypevervangingen tijdens het presentatie‑naar‑PDF‑conversieproces kunt detecteren.

Het volgende voorbeeld exporteert een presentatie naar PDF en toont waarschuwingen voor lettertypevervanging in de console. Een waarschuwing wordt alleen afgedrukt wanneer een niet‑beschikbaar lettertype wordt vervangen tijdens de export.

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

Voor meer informatie over lettertypevervanging, zie het artikel [Font Substitution](/slides/nl/java/font-substitution/).

{{% /alert %}} 

### **Omgaan met lettertypen zonder eigen vette variant**

Een presentatie kan vet opmaak toepassen op tekst, zelfs wanneer het lettertype geen eigen vette variant heeft. De tekst kan nog steeds vet lijken door synthetisch vetten, waarbij de reguliere glyphs kunstmatig worden verdikt. Wanneer die tekst te zwaar of anderszins niet overeenkomt met de gewenste weergave in PDF, kunt u de [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-)‑methode aanroepen met `true`. Deze optie rendert de betreffende tekst als bitmap tijdens de PDF‑export en kan de weergave verbeteren voor bepaalde lettertypen. De standaardwaarde is `false`.

De voorbeeldpresentatie bevat twee tekstvakken: één met reguliere tekst en één met vet op dezelfde lettertype, die geen eigen vette variant heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in en exporteert deze naar PDF:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

De volgende voorvertoningen tonen de uitkomst met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vette tekst zwaardere strepen wanneer de optie is uitgeschakeld. Met de optie ingeschakeld zijn de strepen lichter; de reguliere tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`false`, standaard) | Optie ingeschakeld (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In dit voorbeeld zet het inschakelen van de optie alleen de vette tekst om in een bitmap: deze kan niet worden geselecteerd, gekopieerd of doorzocht als tekst zonder OCR, en de randen verschijnen zachter bij 800 % zoom. De reguliere tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die als vet is opgemaakt wanneer het lettertype geen eigen vette variant heeft. [Font substitution](/slides/nl/java/font-substitution/) selecteert in plaats daarvan een ander lettertype wanneer het oorspronkelijke niet beschikbaar is.

## **Selectieve dia’s van PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia 1 en dia 3 van een presentatie naar PDF. De dia‑nummers in dit array zijn één‑gebaseerd, en de invoerpresentatie moet minstens drie dia’s bevatten.

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

Het volgende voorbeeld kopieert de eerste dia van een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud zodat deze past en exporteert de enkele dia naar PDF.

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

    // Verwijder de lege dia die bij het maken van de nieuwe presentatie is aangemaakt.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren in notitie‑dia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de notities van elke spreker onder de dia worden geplaatst. Gebruik een presentatie met spreker‑notities om het resultaat te zien.

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

Aspose.Slides stelt u in staat een conversie‑procedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsstandaarden: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF‑bestanden produceert op basis van verschillende nalevingsstandaarden:

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

Aspose.Slides ondersteunt PDF‑conversie‑operaties, waardoor u PDF‑bestanden kunt converteren naar populaire bestandsformaten. U kunt [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) en [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversies naar gespecialiseerde formaten—[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) en [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de volledige figuur verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF‑bestand met een wachtwoord te beveiligen?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe kan ik verborgen dia’s opnemen in de PDF?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) aan met `true` in de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse om verborgen dia’s in de resulterende PDF op te nemen.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit beheersen met methoden zoals [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) en [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) in de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse om hoge‑kwaliteit afbeeldingen in uw PDF te waarborgen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsstandaarden?**

Ja, Aspose.Slides stelt u in staat PDF‑bestanden te exporteren die voldoen aan [diverse standaarden](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides for Java Documentation](/slides/nl/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
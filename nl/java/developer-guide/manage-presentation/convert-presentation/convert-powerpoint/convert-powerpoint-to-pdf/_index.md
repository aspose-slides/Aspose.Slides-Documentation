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
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF’s in Java met Aspose.Slides, inclusief snelle code‑voorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

Het converteren van PowerPoint-presentaties (PPT, PPTX, ODP, enz.) naar PDF-formaat in Java biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay-out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF-documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te regelen, verborgen dia’s opneemt, PDF-bestanden met een wachtwoord beveiligt, lettertype-substitutie detecteert, specifieke dia’s selecteert voor conversie en compliance-standaarden toepast op de uitvoer-documenten.

## **PowerPoint-naar-PDF-conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten converteren naar PDF:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑klasse en slaat u de presentatie vervolgens op als PDF met behulp van de [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode. De [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑klasse biedt de [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java voegt zijn API-informatie en versienummer toe aan uitvoer-documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld Application met "*Aspose.Slides*" en het veld PDF Producer met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Note** dat u Aspose.Slides niet kunt instrueren om deze informatie te wijzigen of te verwijderen uit uitvoer-documenten.

{{% /alert %}}

Aspose.Slides maakt het mogelijk om:

* Volledige presentaties te converteren naar PDF
* Specifieke dia’s uit een presentatie te converteren naar PDF

Aspose.Slides exporteert presentaties naar PDF en zorgt ervoor dat de resulterende PDF’s nauwkeurig overeenkomen met de oorspronkelijke presentaties. Elementen en attributen worden correct weergegeven tijdens de conversie, waaronder:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea-opmaak
* Hyperlinks
* Kop- en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint-naar-PDF-conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op maximale kwaliteit.

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

Aspose biedt een gratis online [**PowerPoint-naar-PDF-converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie-naar-PDF-conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live-implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse — waarmee u het resulterende PDF kunt aanpassen, het PDF kunt beveiligen met een wachtwoord, of kunt aangeven hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie-opties kunt u uw gewenste kwaliteitsinstelling voor raster-afbeeldingen definiëren, aangeven hoe met metafiles moet worden omgegaan, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren en meer.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG-kwaliteit ingesteld op 90, resolutie van afbeeldingen ingesteld op 300 DPI, metafiles opgeslagen als PNG en Flate-tekstcompressie.

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

### **Automatisch beeldcompressie selecteren**

Wanneer een presentatie veel foto’s of schermafbeeldingen bevat, kan het verkleinen van de grootte van de geëxporteerde PDF het gemakkelijker maken om deze per e-mail te versturen of te downloaden. Roep [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) aan met `true` om automatisch het meest geschikte compressie-algoritme voor elke afbeelding te selecteren tijdens de PDF-export.

Het volgende voorbeeld laadt een bestaande presentatie, schakelt automatische beeldcompressie-selectie in en slaat deze op als PDF-document. Alle andere PDF-exportinstellingen behouden hun standaardwaarden.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Deze optie selecteert een compressie-algoritme voor elke afbeelding. Het verlagen van de waarde die aan [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) wordt doorgegeven, verlaagt de JPEG-beeldkwaliteit, terwijl het verlagen van de waarde die aan [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) wordt doorgegeven, toestaat dat afbeeldingen worden gereduceerd naar een lagere resolutie, wat details kan verminderen. Het inschakelen van automatische compressieselectie verlaagt zelf geen van deze instellingen.

Het selecteren van compressie-algoritmen voor afbeeldingen vereist extra verwerkingstijd en geheugen. De grootte-reductie hangt af van de afbeeldingen in de presentatie en de exportinstellingen; een vaste reductie is niet gegarandeerd voor elke presentatie.

### **Ingesloten OLE-bestanden behouden als PDF-bijlagen**

Bevat een presentatie een ingesloten Excel-werkmap, wilt u mogelijk dat PDF-ontvangers zowel de data van die werkmap als de dia’s kunnen bekijken. Roep [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) aan met `true` om ingesloten OLE-bestanden te behouden als bijlagen in het resulterende PDF.

De standaardwaarde is `false`: de preview-afbeelding of het pictogram van het OLE-object wordt gerenderd op de PDF-pagina, maar het ingesloten bestand wordt niet als bijlage toegevoegd. Het instellen van de optie op `true` voegt bovendien de bestandsdata toe. De preview blijft een visuele weergave; de bijlage stelt ontvangers in staat het ingesloten bestand apart te openen of op te slaan. Het OLE-object wordt niet een interactieve Excel-werkblad op de PDF-pagina.

Het volgende voorbeeld laadt een presentatie die reeds een ingesloten Excel-werkmap bevat en exporteert deze naar PDF met de werkmap als bijlage.

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

1. Open het geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**-paneel van de viewer en zoek de ingesloten werkmap.
3. Sla de bijlage op en open deze in Excel om de data te inspecteren, of open deze direct als de viewer dit toelaat. De preview op de PDF-pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}

De PDF/A-normen stellen beperkingen aan bijlagen: PDF/A-1 verbiedt ingesloten bestanden, PDF/A-2 staat alleen PDF/A-bijlagen toe, en PDF/A-3 staat andere bestandstypen toe, waaronder Excel-werkboeken. Dit zijn vereisten van de normen, geen beperkingen die specifiek aan Aspose.Slides zijn verbonden. Dit voorbeeld gebruikt de standaard PDF-compliance-instelling en demonstreert geen PDF/A-export.

{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia’s**

Bevat een presentatie verborgen dia’s, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)‑methode van de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia’s als pagina’s in het resulterende PDF op te nemen.

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

### **Lettertype-substitutie detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse, waarmee u lettertype-substitutie kunt detecteren tijdens het presentatie-naar-PDF-conversieproces.

Het volgende voorbeeld exporteert een presentatie naar PDF en schrijft waarschuwingen over lettertype-substitutie naar de console. Een waarschuwing wordt alleen afgedrukt wanneer een niet-beschikbaar lettertype tijdens de export wordt vervangen.

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

Voor meer informatie over lettertype-substitutie, zie het artikel [Font Substitution](/slides/nl/java/font-substitution/).

{{% /alert %}} 

### **Lettertypen zonder eigen vet-type behandelen**

Een presentatie kan vet opmaak toepassen op tekst zelfs wanneer het lettertype geen eigen vet-type heeft. De tekst kan nog steeds vet lijken door synthetisch vetten, wat de gewone glyphs kunstmatig verdikt. Wanneer die tekst te zwaar of anders uitziet dan bedoeld in het PDF, probeer dan [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) aan te roepen met `true`. Deze optie rendert de betreffende tekst als bitmap tijdens de PDF-export en kan de weergave verbeteren voor bepaalde lettertypen. De standaardwaarde is `false`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vet opgemaakte tekst van hetzelfde lettertype, dat geen eigen vet-type heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet-ondersteunde lettertype-stijlen in en exporteert deze naar PDF:

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

De volgende previews tonen de output met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vet-tekst zwaardere strepen wanneer de optie uitgeschakeld is. Met de optie ingeschakeld zijn de strepen lichter; de gewone tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`false`, de standaard) | Optie ingeschakeld (`true`) |
|---|---|
| ![PDF met rasterisatie van niet-ondersteunde lettertype-stijl uitgeschakeld](unsupported-bold-disabled.png) | ![PDF met rasterisatie van niet-ondersteunde lettertype-stijl ingeschakeld](unsupported-bold-enabled.png) |

In dit voorbeeld zet het inschakelen van de optie alleen de vet-tekst om in een bitmap: deze kan niet worden geselecteerd, gekopieerd of doorzocht als tekst zonder OCR, en de randen verschijnen zachter bij 800% zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die vet is opgemaakt wanneer het lettertype geen eigen vet-type heeft. [Font substitution](/slides/nl/java/font-substitution/) selecteert in plaats daarvan een ander lettertype wanneer het oorspronkelijke niet beschikbaar is.

## **Geselecteerde dia’s uit PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia 1 en 3 uit een presentatie naar PDF. De dia-nummers in dit array zijn één-gebaseerd, en de invoerpresentatie moet minstens drie dia’s bevatten.

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

## **PowerPoint naar PDF converteren met aangepaste dia-grootte**

Het volgende voorbeeld kopieert de eerste dia van een presentatie naar een nieuwe presentatie met een dia-grootte van 612 × 792 points (8,5 × 11 inch). Het schaalt de dia-inhoud zodat deze past en exporteert de enkele dia naar PDF.

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

## **PowerPoint naar PDF converteren in notitie-dia-weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de spreker-notities onder elke dia worden geplaatst. Gebruik een presentatie met spreker-notities om het resultaat te zien.

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

## **Toegankelijkheids- en compliance-standaarden voor PDF**

Aspose.Slides stelt u in staat een conversie-procedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint-document exporteren naar PDF met een van deze compliance-standaarden: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze code demonstreert een PowerPoint-naar-PDF-conversieproces dat meerdere PDF’s genereert op basis van verschillende compliance-standaarden:

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

Aspose.Slides ondersteunt PDF-conversie-bewerkingen, waardoor u PDF-bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), en [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF-conversie-bewerkingen naar gespecialiseerde formaten — [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), en [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — worden eveneens ondersteund.

{{% /alert %}}

> **Note:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad-elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten gemarkeerd worden; alternatieve tekst wordt alleen voor de hele figuur verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint-bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch-conversie van meerdere PPT- of PPTX-bestanden naar PDF. U kunt door uw bestanden itereren en het conversie-proces programmatisch toepassen.

**Is het mogelijk om het geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversie-proces.

**Hoe neem ik verborgen dia’s op in het PDF?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) aan met `true` in de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse om verborgen dia’s op te nemen in het resulterende PDF.

**Kan Aspose.Slides hoge beeldkwaliteit handhaven in het PDF?**

Ja, u kunt de beeldkwaliteit regelen via methoden zoals [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) en [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) in de [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑klasse om hoge-kwaliteit afbeeldingen in uw PDF te waarborgen.

**Ondersteunt Aspose.Slides PDF/A-compliance-standaarden?**

Ja, Aspose.Slides stelt u in staat PDF’s te exporteren die voldoen aan [verschillende standaarden](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten aan toegankelijkheids- en archiveringsvereisten voldoen.

## **Aanvullende bronnen**

- [Aspose.Slides for Java Documentation](/slides/nl/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
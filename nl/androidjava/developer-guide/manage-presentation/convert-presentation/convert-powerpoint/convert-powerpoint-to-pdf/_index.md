---
title: Converteer PPT en PPTX naar PDF op Android [Geavanceerde functies inbegrepen]
linktitle: PowerPoint naar PDF
type: docs
weight: 40
url: /nl/androidjava/convert-powerpoint-to-pdf/
keywords:
- converteer PowerPoint
- converteer presentatie
- PowerPoint naar PDF
- presentatie naar PDF
- PPT naar PDF
- converteer PPT naar PDF
- PPTX naar PDF
- converteer PPTX naar PDF
- sla PowerPoint op als PDF
- sla PPT op als PDF
- sla PPTX op als PDF
- exporteer PPT naar PDF
- exporteer PPTX naar PDF
- bijlage
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF‑bestanden in Java met Aspose.Slides voor Android, met snelle code‑voorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) omzetten naar PDF‑formaat op Android biedt verschillende voordelen, waaronder compatibiliteit tussen verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te regelen, verborgen dia’s opneemt, PDF‑bestanden met een wachtwoord beveiligt, lettertype‑vervangingen detecteert, specifieke dia’s selecteert voor conversie en nalevingsstandaarden toepast op de uitvoer‑documenten.

## **PowerPoint naar PDF conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument door aan de [Presentatie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑klasse en slaat u vervolgens de presentatie op als PDF met behulp van een [opslaan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode. De [Presentatie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑klasse biedt de [opslaan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Opmerking" %}}

Aspose.Slides for Android via Java voegt zijn API‑informatie en versienummer toe aan uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het toepassingsveld in met "*Aspose.Slides*" en het PDF‑Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren om deze informatie uit uitvoerdocumenten te wijzigen of te verwijderen.

{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Volledige presentaties naar PDF
* Specifieke dia's uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waarbij de resulterende PDF‑bestanden nauw aansluiten bij de oorspronkelijke presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kopteksten en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op maximaal kwaliteitsniveau.

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

{{% alert color="info" title="Opmerking" %}}

Aspose biedt een gratis online [**PowerPoint naar PDF-converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live‑implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑klasse—die u in staat stellen het resulterende PDF‑bestand aan te passen, het PDF‑bestand met een wachtwoord te beveiligen of te bepalen hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen definiëren, bepalen hoe metafiles afgehandeld moeten worden, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, enzovoort.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, afbeeldingsresolutie ingesteld op 300 DPI, metafiles opgeslagen als PNG en Flate‑tekstcompressie.

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

### **Behoud ingebedde OLE‑bestanden als PDF‑bijlagen**

Als een presentatie een ingebedde Excel‑werkmap bevat, wilt u mogelijk dat PDF‑ontvangers zowel toegang hebben tot de gegevens van de werkmap als de dia’s kunnen bekijken. Roep [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) aan met `true` om ingebedde OLE‑bestanden als bijlagen in het resulterende PDF te behouden.

De standaardwaarde is `false`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt gerenderd op de PDF‑pagina, maar het ingebedde bestand wordt niet als bijlage opgenomen. Door de optie op `true` te zetten wordt het bestand ook bijgevoegd. De voorbeeldweergave blijft een visuele weergave; de bijlage maakt het mogelijk het ingebedde bestand apart te openen of op te slaan. Het OLE‑object wordt niet een interactieve Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die al een ingebedde Excel‑werkmap bevat en exporteert deze naar PDF met de werkmap bijgevoegd.

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

1. Open de geëxporteerde PDF in een viewer die bestandbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Bijlagen**‑paneel van de viewer en zoek de ingebedde werkmap.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze rechtstreeks als de viewer dat toelaat. De voorbeeldweergave op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Opmerking" %}}

De PDF/A‑standaarden leggen beperkingen op voor bijlagen: PDF/A‑1 verbiedt ingebedde bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, waaronder Excel‑werkmappen. Dit zijn eisen van de standaarden, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en toont geen PDF/A‑export.

{{% /alert %}}

### **PowerPoint naar PDF met verborgen dia’s**

Als een presentatie verborgen dia’s bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)‑methode van de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑klasse gebruiken om de verborgen dia’s als pagina’s in het resulterende PDF op te nemen.

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

### **PowerPoint naar een wachtwoord‑beveiligd PDF**

Het volgende voorbeeld exporteert een presentatie naar een PDF dat moet worden geopend met het wachtwoord `password`. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

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

### **Detecteer lettertypevervangingen**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑klasse, waarmee u lettertypevervangingen kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Het volgende voorbeeld exporteert een presentatie naar PDF en schrijft waarschuwingen over lettertypevervanging naar de console. Een waarschuwing wordt alleen afgedrukt wanneer een niet‑beschikbaar lettertype wordt vervangen tijdens de export.

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

{{% alert color="info" title="Opmerking" %}}

Voor meer informatie over lettertypevervanging, zie het artikel [Lettertypevervanging](/slides/nl/androidjava/font-substitution/).

{{% /alert %}} 

## **Selectieve dia’s uit PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia 1 en 3 uit een presentatie naar PDF. De dia‑nummers in deze array zijn één‑gebaseerd, en de invoerpresentatie moet ten minste drie dia’s bevatten.

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

## **PowerPoint naar PDF met aangepaste dia‑grootte**

Het volgende voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud zodat deze past en exporteert de enkele dia naar PDF.

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

    // Verwijder de lege dia die bij het aanmaken van de nieuwe presentatie is aangemaakt.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint naar PDF in notitie‑dia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de aantekeningen van elke dia onder de dia worden geplaatst. Gebruik een presentatie met aantekeningen om het resultaat te zien.

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

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Webinhoudtoegankelijkheidsrichtlijnen (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met een van deze nalevingsstandaarden: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

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

{{% alert color="info" title="Opmerking" %}}

Aspose.Slides ondersteunt PDF‑conversie‑bewerkingen, waarmee u PDF‑bestanden naar populaire bestandsformaten kunt converteren. U kunt [PDF naar HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑bewerkingen naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—worden eveneens ondersteund.

{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de gehele figuur voorzien.

## **Veelgestelde vragen**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF te beveiligen met een wachtwoord?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia’s op in het PDF?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) aan met `true` in de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑klasse om verborgen dia’s in het resulterende PDF op te nemen.

**Kan Aspose.Slides een hoge beeldkwaliteit in het PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen met methoden zoals [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) en [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) in de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑klasse om hoogwaardige afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides de PDF/A‑nalevingsstandaarden?**

Ja, Aspose.Slides maakt het mogelijk PDF‑bestanden te exporteren die voldoen aan [verschillende standaarden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides voor Android via Java‑documentatie](/slides/nl/androidjava/)
- [Aspose.Slides voor Android via Java API‑referentie](https://reference.aspose.com/slides/androidjava/)
- [Aspose gratis online converters](https://products.aspose.app/slides/conversion)
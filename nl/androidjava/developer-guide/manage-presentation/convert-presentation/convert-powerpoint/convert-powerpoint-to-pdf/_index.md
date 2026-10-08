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
- bijlage
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF-bestanden in Java met Aspose.Slides voor Android, inclusief snelle code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

Het converteren van PowerPoint‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat op Android biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, verschillende opties gebruikt om de beeldkwaliteit te regelen, verborgen dia’s omvat, PDF‑bestanden met wachtwoord beveiligt, font‑substitutie detecteert, specifieke dia’s selecteert voor conversie, en nalevingsnormen toepast op de uitvoer‑documenten.

## **PowerPoint naar PDF‑conversies**

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class en slaat u de presentatie vervolgens op als PDF met behulp van een [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) methode. De [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class biedt de [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides voor Android via Java voegt zijn API‑informatie en versienummer toe aan uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld Application in met "*Aspose.Slides*" en het PDF Producer‑veld met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Opmerking** dat u Aspose.Slides niet kunt instrueren deze informatie uit de uitvoer‑documenten te verwijderen of te wijzigen.
{{% /alert %}}

Aspose.Slides maakt het mogelijk om:

* Hele presentaties naar PDF
* Specifieke dia’s uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, zodat de resulterende PDF‑bestanden nauw aansluiten bij de originele presentaties. Elementen en attributen worden nauwkeurig weergegeven tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kopteksten en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de aangeleverde presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

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
Aspose biedt een gratis online [**PowerPoint naar PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live‑implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) class — die u in staat stellen het resulterende PDF‑document aan te passen, het PDF‑bestand met een wachtwoord te beveiligen, of te bepalen hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw voorkeurskwaliteit voor raster‑afbeeldingen definiëren, bepalen hoe metafiles worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, enzovoort.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, beeldresolutie ingesteld op 300 DPI, metafiles opgeslagen als PNG, en Flate‑tekstcompressie.

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

Als een presentatie een ingebed Excel‑werkboek bevat, wilt u wellicht dat PDF‑ontvangers ook toegang hebben tot de gegevens van het werkboek naast de dia’s. Roep [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) aan met `true` om ingesloten OLE‑bestanden te behouden als bijlagen in het resulterende PDF.

Standaard is de waarde `false`: het voorbeeld‑beeld of pictogram van het OLE‑object wordt op de PDF‑pagina gerenderd, maar het ingesloten bestand wordt niet als bijlage toegevoegd. Het instellen van de optie op `true` voegt bovendien de bestandsdata toe. Het voorbeeld blijft een visuele weergave; de bijlage laat ontvangers het ingesloten bestand apart openen of opslaan. Het OLE‑object wordt geen interactieve Excel‑werkblad op de PDF‑pagina.

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

1. Open het geëxporteerde PDF‑bestand in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Attachments**‑paneel van de viewer en zoek het ingesloten werkboek.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer dat toestaat. Het voorbeeld op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑normen leggen beperkingen op voor bijlagen: PDF/A-1 verbiedt ingesloten bestanden, PDF/A-2 staat alleen PDF/A‑bijlagen toe, en PDF/A-3 staat andere bestandstypen toe, inclusief Excel‑werkboeken. Dit zijn eisen van de normen, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld gebruikt de standaard PDF‑nalevingsinstelling en toont geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia's**

Als een presentatie verborgen dia's bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) methode van de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) class gebruiken om de verborgen dia's op te nemen als pagina's in het resulterende PDF.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief eventuele verborgen dia's.

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

### **PowerPoint naar PDF converteren met wachtwoordbeveiliging**

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

### **Detectie van font‑substituties**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) methode onder de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) class, waarmee u font‑substituties kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Het volgende voorbeeld exporteert een presentatie naar PDF en print font‑substitutiewaarschuwingen naar de console. Een waarschuwing wordt alleen geprint wanneer een niet‑beschikbare font wordt vervangen tijdens de export.

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
Voor meer informatie over font‑substitutie, zie het artikel [Font‑substitutie](/slides/nl/androidjava/font-substitution/).
{{% /alert %}} 

### **Lettertypen zonder dedicated bold‑typeface verwerken**

Een presentatie kan vette opmaak toepassen op tekst, zelfs wanneer het gebruikte font geen dedicated vet typeface heeft. De tekst kan nog steeds vet verschijnen via synthetisch vet maken, waarbij de reguliere glyphs kunstmatig worden verdikt. Wanneer die tekst te zwaar of anderszins afwijkt van de beoogde weergave in PDF, probeer dan [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) aan te roepen met `true`. Deze optie rendert de getroffen tekst als bitmap tijdens de PDF‑export en kan de weergave voor bepaalde fonts verbeteren. Standaard is de waarde `false`.

De voorbeeldpresentatie bevat twee tekstvakken: één met normale tekst en één met vette opmaak toegepast op hetzelfde font, dat geen dedicated vet typeface heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde fontstijlen in, en exporteert deze naar PDF:

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

De onderstaande voorbeeldweergaven tonen de uitgeschakelde en ingeschakelde uitvoer. In dit voorbeeld heeft de vette tekst dikkere strepen wanneer de optie is uitgeschakeld. Met de optie ingeschakeld zijn de strepen lichter; de normale tekst blijft onveranderd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`false`, standaard) | Optie ingeschakeld (`true`) |
|---|---|
| ![PDF met rasterisatie van niet‑ondersteunde fontstijl uitgeschakeld](unsupported-bold-disabled.png) | ![PDF met rasterisatie van niet‑ondersteunde fontstijl ingeschakeld](unsupported-bold-enabled.png) |

In dit voorbeeld zet het inschakelen van de optie alleen de vette tekst om in een bitmap: deze kan niet worden geselecteerd, gekopieerd of doorzocht als tekst zonder OCR, en de randen lijken zachter bij 800 % zoom. De normale tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide strings tekst.

Deze optie rastert tekst die vet is opgemaakt wanneer het gebruikte font geen dedicated vet typeface heeft. [Font‑substitutie](/slides/nl/androidjava/font-substitution/) selecteert in plaats daarvan een ander font wanneer het oorspronkelijke font niet beschikbaar is.

## **Geselecteerde dia's vanuit PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia 1 en 3 vanuit een presentatie naar PDF. De dia‑nummers in deze array zijn één‑gebaseerd, en de invoer‑presentatie moet minimaal drie dia's bevatten.

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

Het volgende voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de inhoud van de dia om te passen en exporteert de enkele dia naar PDF.

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

## **PowerPoint naar PDF converteren in notities‑beeld**

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

## **Toegankelijkheids‑ en nalevingsnormen voor PDF**

Aspose.Slides biedt de mogelijkheid een conversieprocedure te gebruiken die voldoet aan de [Richtlijnen voor toegankelijkheid van webinhoud (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met één van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

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

{{% alert color="info" title="Note" %}}
Aspose.Slides ondersteunt PDF‑conversie‑operaties, zodat u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF naar afbeelding](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF naar JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), en [PDF naar PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten — [PDF naar SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), en [PDF naar XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — worden eveneens ondersteund.
{{% /alert %}}

> **Opmerking:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele padelementen worden niet bewaard als afzonderlijke inhoud en kunnen worden gemarkeerd als artefacten; alternatieve tekst wordt alleen voor de volledige figuur verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversieproces programmatically toepassen.

**Is het mogelijk het geconverteerde PDF‑bestand met een wachtwoord te beveiligen?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) class om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe kan ik verborgen dia's opnemen in de PDF?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) aan met `true` in de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) class om verborgen dia's op te nemen in de resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen door methoden zoals [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) en [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) in de [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) class te gebruiken om hoogwaardige afbeeldingen in uw PDF te garanderen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides maakt het mogelijk PDF‑bestanden te exporteren die voldoen aan [verschillende normen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), inclusief PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides voor Android via Java‑documentatie](/slides/nl/androidjava/)
- [Aspose.Slides voor Android via Java API‑referentie](https://reference.aspose.com/slides/androidjava/)
- [Aspose gratis online converters](https://products.aspose.app/slides/conversion)
---
title: Converteer PPT en PPTX naar PDF in JavaScript [Geavanceerde functies inbegrepen]
linktitle: PowerPoint naar PDF
type: docs
weight: 40
url: /nl/nodejs-java/convert-powerpoint-to-pdf/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF's met Aspose.Slides voor Node.js, met snelle codevoorbeelden en geavanceerde conversie‑opties."
---
## **Overzicht**

Het converteren van PowerPoint- en OpenDocument‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in JavaScript biedt verschillende voordelen, waaronder compatibiliteit over verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten kunt converteren, verschillende opties kunt gebruiken om de beeldkwaliteit te regelen, verborgen dia’s kunt opnemen, PDF‑bestanden met een wachtwoord kunt beveiligen, lettertype‑vervangingen kunt detecteren, specifieke dia’s voor conversie kunt selecteren en nalevingsnormen kunt toepassen op de uitvoer documenten.

## **PowerPoint naar PDF-conversies**

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument door aan de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse en slaat u vervolgens de presentatie op als PDF met behulp van de [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) methode. De [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse exposeert de [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java voegt zijn API‑informatie en versienummer toe aan de uitvoerdocumenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF, vult Aspose.Slides het toepassingsveld in met “*Aspose.Slides*” en het PDF‑producer‑veld met een waarde in de vorm “*Aspose.Slides v XX.XX*”. **Opmerking** dat u Aspose.Slides niet kunt instrueren deze informatie te wijzigen of te verwijderen uit de uitvoerdocumenten.
{{% /alert %}}

Aspose.Slides stelt u in staat om te converteren:

* Gehele presentaties naar PDF
* Specifieke dia’s uit een presentatie naar PDF

Aspose.Slides exporteert presentaties naar PDF, waarbij ervoor wordt gezorgd dat de resulterende PDF‑bestanden nauw overeenkomen met de originele presentaties. Elementen en attributen worden nauwkeurig weergegeven tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Koppen en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF‑conversieproces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de aangeleverde presentatie naar PDF te converteren met optimale instellingen op het maximale kwaliteitsniveau.

Het volgende voorbeeld laadt een presentatie en slaat alle zichtbare dia’s op als PDF met de standaard exportinstellingen.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose biedt een gratis online [**PowerPoint naar PDF‑converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) die het presentatie‑naar‑PDF‑conversieproces demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.
{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties—eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) klasse—die u in staat stellen het resulterende PDF‑bestand aan te passen, het PDF‑bestand met een wachtwoord te beveiligen, of te specificeren hoe het conversieproces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met behulp van aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor rasterafbeeldingen definiëren, opgeven hoe metafiles moeten worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, en meer.

Het volgende voorbeeld exporteert een presentatie naar PDF 1.5 met JPEG‑kwaliteit ingesteld op 90, afbeeldingsresolutie op 300 DPI, metafiles opgeslagen als PNG, en Flate‑tekstcompressie.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ingesloten OLE‑bestanden behouden als PDF‑bijlagen**

Als een presentatie een ingesloten Excel‑werkmap bevat, wilt u wellicht dat PDF‑ontvangers zowel de gegevens van de werkmap als de dia’s kunnen bekijken. Roep [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) aan met `true` om ingesloten OLE‑bestanden te behouden als bijlagen in de resulterende PDF.

De standaardwaarde is `false`: de voorbeeldafbeelding of het pictogram van het OLE‑object wordt weergegeven op de PDF‑pagina, maar het ingesloten bestand wordt niet toegevoegd als bijlage. Het instellen van de optie op `true` voegt bovendien de bestandsgegevens toe. De voorbeeldweergave blijft een visuele representatie; de bijlage stelt ontvangers in staat het ingesloten bestand afzonderlijk te openen of op te slaan. Het OLE‑object wordt geen interactieve Excel‑werkblad op de PDF‑pagina.

Het volgende voorbeeld laadt een presentatie die al een ingesloten Excel‑werkmap bevat en exporteert deze naar PDF met de werkmap als bijlage.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Om het resultaat te controleren:

1. Open de geëxporteerde PDF in een viewer die bestandsbijlagen ondersteunt, zoals Adobe Acrobat Reader.
2. Open het **Bijlagen**‑paneel van de viewer en zoek de ingesloten werkmap.
3. Sla de bijlage op en open deze in Excel om de gegevens te inspecteren, of open deze direct als de viewer het toestaat. De voorbeeldweergave op de PDF‑pagina staat los van de bijlage.

{{% alert color="info" title="Note" %}}
De PDF/A‑normen leggen beperkingen op aan bijlagen: PDF/A‑1 verbiedt ingesloten bestanden, PDF/A‑2 staat alleen PDF/A‑bijlagen toe, en PDF/A‑3 staat andere bestandstypen toe, waaronder Excel‑werkmappen. Dit zijn vereisten van de normen, geen beperkingen specifiek voor Aspose.Slides. Dit voorbeeld maakt gebruik van de standaard PDF‑nalevingsinstelling en toont geen PDF/A‑export.
{{% /alert %}}

### **PowerPoint naar PDF converteren met verborgen dia’s**

Als een presentatie verborgen dia’s bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) methode van de [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) klasse gebruiken om de verborgen dia’s op te nemen als pagina’s in de resulterende PDF.

Het volgende voorbeeld exporteert een presentatie naar PDF, inclusief eventuele verborgen dia’s.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint naar een met wachtwoord beveiligde PDF converteren**

Het volgende voorbeeld exporteert een presentatie naar een PDF die het wachtwoord `password` vereist om te openen. De toegangsrechten staan afdrukken toe, inclusief afdrukken van hoge kwaliteit.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Lettertype‑vervangingen detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) methode onder de [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) klasse, waarmee u lettertype‑vervangingen kunt detecteren tijdens het presentatie‑naar‑PDF‑conversieproces.

Het volgende voorbeeld exporteert een presentatie naar PDF en print waarschuwingen voor lettertype‑vervangingen naar de console. Een waarschuwing wordt alleen geprint wanneer een niet‑beschikbaar lettertype tijdens de export wordt vervangen.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Voor meer informatie over lettertype‑vervanging, zie het artikel [Lettertype‑vervanging](/slides/nl/nodejs-java/font-substitution/).
{{% /alert %}} 

### **Lettertypen zonder een eigen vet type behandelen**

Een presentatie kan vette opmaak toepassen op tekst, zelfs wanneer het lettertype geen eigen vet type heeft. De tekst kan nog steeds vet verschijnen via synthetisch vet, waarbij de gewone glyphs kunstmatig dikker worden gemaakt. Wanneer die tekst te zwaar lijkt of anderszins afwijkt van de beoogde weergave in PDF, probeer dan [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) aan te roepen met `true`. Deze optie rendert de betrokken tekst als bitmap tijdens de PDF‑export en kan de weergave voor bepaalde lettertypen verbeteren. De standaardwaarde is `false`.

De voorbeeldpresentatie bevat twee tekstvakken: één met gewone tekst en één met vet opgemaakte tekst toegepast op hetzelfde lettertype, dat geen eigen vet type heeft. Het volgende voorbeeld laadt de presentatie, schakelt rasterisatie van niet‑ondersteunde lettertype‑stijlen in, en exporteert deze naar PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

De volgende voorbeeldweergaven tonen de uitkomst met de optie uitgeschakeld en ingeschakeld. In dit voorbeeld heeft de vette tekst dikkere lijnen wanneer de optie is uitgeschakeld. Met de optie ingeschakeld zijn de lijnen lichter; de gewone tekst blijft ongewijzigd. Vergelijk de resultaten voordat u de instelling voor uw presentatie kiest.

| Optie uitgeschakeld (`false`, standaard) | Optie ingeschakeld (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In dit voorbeeld maakt het inschakelen van de optie alleen de vette tekst om tot een bitmap: deze kan niet worden geselecteerd, gekopieerd of doorzocht als tekst zonder OCR, en de randen lijken zachter bij 800 % zoom. De gewone tekst blijft doorzoekbaar. Met de optie uitgeschakeld blijven beide tekenreeksen tekst.

Deze optie rastert tekst die vet is opgemaakt wanneer het lettertype geen eigen vet type heeft. [Lettertype‑vervanging](/slides/nl/nodejs-java/font-substitution/) kiest in plaats daarvan een ander lettertype wanneer het oorspronkelijke niet beschikbaar is.

## **Geselecteerde dia’s uit PowerPoint naar PDF converteren**

Het volgende voorbeeld exporteert dia’s 1 en 3 uit een presentatie naar PDF. Dia‑nummers in dit array beginnen bij één, en de invoerpresentatie moet minstens drie dia’s bevatten.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Het volgende voorbeeld kopieert de eerste dia uit een presentatie naar een nieuwe presentatie met een dia‑grootte van 612 × 792 punten (8,5 × 11 inch). Het schaalt de dia‑inhoud zodat deze past en exporteert de enkele dia naar PDF.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Verwijder de lege dia die bij het maken van de nieuwe presentatie is aangemaakt.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren in notities‑dia‑weergave**

Het volgende voorbeeld exporteert een presentatie naar PDF, waarbij de notities van elke dia onder de dia worden geplaatst. Gebruik een presentatie met notities om het resultaat te zien.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Toegankelijkheids‑ en nalevingsnormen voor PDF**

Aspose.Slides stelt u in staat een conversieprocedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document exporteren naar PDF met elk van deze nalevingsnormen: **PDF/A1a**, **PDF/A1b**, en **PDF/UA**.

Deze code demonstreert een PowerPoint‑naar‑PDF‑conversieproces dat meerdere PDF’s produceert op basis van verschillende nalevingsnormen:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides ondersteunt PDF‑conversie‑operaties, waardoor u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF naar JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) en [PDF naar PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten—[PDF naar SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—worden ook ondersteund.
{{% /alert %}}

> **Opmerking:** Bij exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele figuur. Individuele pad‑elementen worden niet bewaard als afzonderlijke content en kunnen als artefacten worden gemarkeerd; alternatieve tekst wordt alleen voor de gehele figuur verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in bulk naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt door uw bestanden itereren en het conversieproces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF‑bestand met een wachtwoord te beveiligen?**

Ja. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversieproces.

**Hoe neem ik verborgen dia's op in de PDF?**

Roep [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) aan met `true` in de [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) klasse om verborgen dia's op te nemen in de resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in de PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen met methoden zoals [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) en [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) in de [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) klasse om hoge‑kwaliteit afbeeldingen in uw PDF te waarborgen.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsnormen?**

Ja, Aspose.Slides stelt u in staat PDF's te exporteren die voldoen aan [verscheidene normen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), waaronder PDF/A1a, PDF/A1b, en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides voor Node.js via Java Documentatie](/slides/nl/nodejs-java/)
- [Aspose.Slides voor Node.js via Java API‑referentie](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose gratis online converters](https://products.aspose.app/slides/conversion)
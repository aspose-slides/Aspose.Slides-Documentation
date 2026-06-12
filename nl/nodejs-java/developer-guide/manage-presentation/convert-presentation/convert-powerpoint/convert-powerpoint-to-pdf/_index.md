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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, doorzoekbare PDF-bestanden met Aspose.Slides voor Node.js, met snelle code-voorbeelden en geavanceerde conversie-opties."
---
## **Overzicht**

Het omzetten van PowerPoint‑ en OpenDocument‑presentaties (PPT, PPTX, ODP, enz.) naar PDF‑formaat in JavaScript biedt verschillende voordelen, waaronder compatibiliteit op verschillende apparaten en het behouden van de lay‑out en opmaak van uw presentatie. Deze gids laat zien hoe u presentaties naar PDF‑documenten converteert, diverse opties gebruikt om de beeldkwaliteit te regelen, verborgen dia’s opneemt, PDF‑bestanden met wachtwoord beveiligt, lettertype‑vervangingen detecteert, specifieke dia’s selecteert voor conversie en nalevingsstandaarden toepast op de uitvoer‑documenten.

## **PowerPoint‑naar‑PDF conversies**

Met Aspose.Slides kunt u presentaties in de volgende formaten naar PDF converteren:

* **PPT**
* **PPTX**
* **ODP**

Om een presentatie naar PDF te converteren, geeft u de bestandsnaam als argument aan de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse en slaat u de presentatie vervolgens op als PDF met een `save`‑methode. De [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse biedt de `save`‑methode die doorgaans wordt gebruikt om een presentatie naar PDF te converteren.

{{%  alert title="OPMERKING"  color="warning"   %}} 

Aspose.Slides for Node.js via Java voegt zijn API‑informatie en versienummer toe aan uitvoer‑documenten. Bijvoorbeeld, bij het converteren van een presentatie naar PDF vult Aspose.Slides het veld Application met "*Aspose.Slides*" en het veld PDF Producer met een waarde in de vorm "*Aspose.Slides v XX.XX*". **Let op** dat u Aspose.Slides niet kunt instrueren om deze informatie te wijzigen of te verwijderen uit uitvoer‑documenten.

{{% /alert %}}

Aspose.Slides maakt het mogelijk om:

* Complete presentaties naar PDF te converteren
* Specifieke dia’s uit een presentatie naar PDF te converteren

Aspose.Slides exporteert presentaties naar PDF, zodat de resulterende PDF’s nauw aansluiten bij de originele presentaties. Elementen en attributen worden nauwkeurig gerenderd tijdens de conversie, inclusief:

* Afbeeldingen
* Tekstvakken en vormen
* Tekstopmaak
* Alinea‑opmaak
* Hyperlinks
* Kop‑ en voetteksten
* Opsommingstekens
* Tabellen

## **PowerPoint naar PDF converteren**

Het standaard PowerPoint‑naar‑PDF conversie‑proces gebruikt de standaardopties. In dit geval probeert Aspose.Slides de opgegeven presentatie naar PDF te converteren met optimale instellingen op het hoogste kwaliteitsniveau.

Deze code laat zien hoe u een presentatie (PPT, PPTX, ODP, enz.) naar PDF converteert:

```js
// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Sla de presentatie op als PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose biedt een gratis online [**PowerPoint‑naar‑PDF converter**](https://products.aspose.app/slides/nl/conversion/ppt-to-pdf) die het presentatieto‑PDF‑conversie‑proces demonstreert. U kunt een test uitvoeren met deze converter voor een live implementatie van de hier beschreven procedure.

{{% /alert %}}

## **PowerPoint naar PDF converteren met opties**

Aspose.Slides biedt aangepaste opties — eigenschappen onder de [PdfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pdfoptions/)‑klasse — die u in staat stellen het resulterende PDF aan te passen, het PDF met een wachtwoord te vergrendelen, of te specificeren hoe het conversie‑proces moet verlopen.

### **PowerPoint naar PDF converteren met aangepaste opties**

Met aangepaste conversie‑opties kunt u uw gewenste kwaliteitsinstelling voor raster‑afbeeldingen definiëren, opgeven hoe metafiles moeten worden behandeld, een compressieniveau voor tekst instellen, DPI voor afbeeldingen configureren, enzovoort.

Het onderstaande code‑voorbeeld laat zien hoe u een PowerPoint‑presentatie naar PDF converteert met verschillende aangepaste opties.

```js
// Maak een instantie van de PdfOptions-klasse.
let pdfOptions = new aspose.slides.PdfOptions();

// Set the quality for JPG images.
pdfOptions.setJpegQuality(java.newByte(90));

// Set DPI for images.
pdfOptions.setSufficientResolution(300);

// Set the behavior for metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Set the text compression level for textual content.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Define the PDF compliance mode.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Sla de presentatie op als een PDF-document.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint naar PDF converteren met verborgen dia’s**

Als een presentatie verborgen dia’s bevat, kunt u de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides)‑methode van de [PdfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PdfOptions)‑klasse gebruiken om de verborgen dia’s op te nemen als pagina’s in het resulterende PDF.

Deze JavaScript‑code toont hoe u een PowerPoint‑presentatie naar PDF converteert met verborgen dia’s opgenomen:

```js
// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Maak een instantie van de PdfOptions-klasse.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Voeg verborgen dia’s toe.
    pdfOptions.setShowHiddenSlides(true);

    // Sla de presentatie op als PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint naar wachtwoord‑beveiligd PDF converteren**

Deze JavaScript‑code demonstreert hoe u een PowerPoint‑presentatie omzet in een wachtwoord‑beveiligd PDF met de beveiligingsparameters van de [PdfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PdfOptions)‑klasse:

```js
// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Maak een instantie van de PdfOptions-klasse.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Stel een PDF-wachtwoord en toegangsrechten in.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Sla de presentatie op als PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Lettertype‑vervangingen detecteren**

Aspose.Slides biedt de [setWarningCallback](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveoptions/#setWarningCallback)‑methode onder de [PdfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PdfOptions)‑klasse, waardoor u lettertype‑vervangingen kunt detecteren tijdens het presentatieto‑PDF‑conversie‑proces.

Deze JavaScript‑code laat zien hoe u lettertype‑vervangingen detecteert:

```js
// Stel de waarschuwingcallback in PDF-opties in.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Sla de presentatie op als PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

Voor meer informatie over lettertype‑vervanging, zie het artikel [Font Substitution](/slides/nl/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Geselecteerde dia’s in PowerPoint naar PDF converteren**

Deze JavaScript‑code demonstreert hoe u alleen specifieke dia’s uit een PowerPoint‑presentatie naar PDF converteert:

```js
// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Stel array van dia-nummers in.
    let slides = java.newArray("int", [1, 3]);

    // Sla de presentatie op als PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren met aangepaste dia‑grootte**

Deze JavaScript‑code demonstreert hoe u een PowerPoint‑presentatie naar PDF converteert met een opgegeven dia‑grootte:

```js
const slideWidth = 612;
const slideHeight = 792;

// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Maak een nieuwe presentatie met een aangepaste dia-grootte.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Stel de aangepaste dia-grootte in.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Kloon de eerste dia van de originele presentatie.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Sla de aangepaste presentatie op als een PDF met notities.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint naar PDF converteren in notities‑dia‑weergave**

Deze JavaScript‑code demonstreert hoe u een PowerPoint‑presentatie naar een PDF converteert dat notities bevat:

```js
// Maak een instantie van de Presentation-klasse die een PowerPoint- of OpenDocument-bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Configureer de PDF-opties met notitie-layout.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Sla de presentatie op als een PDF met notities.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Toegankelijkheid en nalevingsstandaarden voor PDF**

Aspose.Slides stelt u in staat een conversie‑procedure te gebruiken die voldoet aan de [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). U kunt een PowerPoint‑document naar PDF exporteren met een van deze nalevingsstandaarden: **PDF/A1a**, **PDF/A1b** en **PDF/UA**.

Deze JavaScript‑code toont een PowerPoint‑naar‑PDF‑conversie‑proces dat meerdere PDF’s produceert op basis van verschillende nalevingsstandaarden:

```js
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

{{% alert title="Opmerking" color="warning" %}} 

Aspose.Slides ondersteunt PDF‑conversie‑operaties, waardoor u PDF‑bestanden kunt omzetten naar populaire bestandsformaten. U kunt [PDF naar HTML](https://products.aspose.com/slides/nl/nodejs-java/conversion/pdf-to-html/), [PDF naar JPG](https://products.aspose.com/slides/nl/nodejs-java/conversion/pdf-to-jpg/) en [PDF naar PNG](https://products.aspose.com/slides/nl/nodejs-java/conversion/pdf-to-png/) conversies uitvoeren. Andere PDF‑conversie‑operaties naar gespecialiseerde formaten — [PDF naar SVG](https://products.aspose.com/slides/nl/nodejs-java/conversion/pdf-to-svg/), [PDF naar TIFF](https://products.aspose.com/slides/nl/nodejs-java/conversion/pdf-to-tiff/) — worden eveneens ondersteund.

{{% /alert %}}

> **Let op:** Bij het exporteren naar PDF/UA behandelt Aspose.Slides complexe grafieken zoals SmartArt, diagrammen en formules als één enkele afbeelding. Individuele pad‑elementen worden niet bewaard als afzonderlijke inhoud en kunnen gemarkeerd worden als artefacten; alternatieve tekst wordt alleen voor de volledige afbeelding verstrekt.

## **FAQ**

**Kan ik meerdere PowerPoint‑bestanden in één keer naar PDF converteren?**

Ja, Aspose.Slides ondersteunt batch‑conversie van meerdere PPT‑ of PPTX‑bestanden naar PDF. U kunt uw bestanden itereren en het conversie‑proces programmatisch toepassen.

**Is het mogelijk het geconverteerde PDF te beveiligen met een wachtwoord?**

Absoluut. Gebruik de [PdfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PdfOptions)‑klasse om een wachtwoord in te stellen en toegangsrechten te definiëren tijdens het conversie‑proces.

**Hoe neem ik verborgen dia’s op in het PDF?**

Gebruik de `setShowHiddenSlides`‑methode in de [PdfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PdfOptions)‑klasse om verborgen dia’s op te nemen in het resulterende PDF.

**Kan Aspose.Slides een hoge beeldkwaliteit in het PDF behouden?**

Ja, u kunt de beeldkwaliteit regelen door methoden zoals `setJpegQuality` en `setSufficientResolution` in de [PdfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PdfOptions)‑klasse te gebruiken, zodat de afbeeldingen in uw PDF van hoge kwaliteit zijn.

**Ondersteunt Aspose.Slides PDF/A‑nalevingsstandaarden?**

Ja, Aspose.Slides maakt het mogelijk PDF’s te exporteren die voldoen aan diverse standaarden, waaronder PDF/A1a, PDF/A1b en PDF/UA, zodat uw documenten voldoen aan toegankelijkheids‑ en archiveringsvereisten.

## **Aanvullende bronnen**

- [Aspose.Slides for Node.js via Java Documentatie](/slides/nl/nodejs-java/)
- [Aspose.Slides for Node.js via Java API‑Referentie](https://reference.aspose.com/slides/nl/nodejs-java/)
- [Aspose Gratis Online Converters](https://products.aspose.app/slides/nl/conversion)
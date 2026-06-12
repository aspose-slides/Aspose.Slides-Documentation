---
title: Export Presentaties naar XAML in JavaScript
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/nodejs-java/export-to-xaml/
keywords:
- PowerPoint exporteren
- OpenDocument exporteren
- presentatie exporteren
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- PowerPoint naar XAML
- OpenDocument naar XAML
- presentatie naar XAML
- PPT naar XAML
- PPTX naar XAML
- ODP naar XAML
- PPT opslaan als XAML
- PPTX opslaan als XAML
- ODP opslaan als XAML
- PPT exporteren naar XAML
- PPTX exporteren naar XAML
- ODP exporteren naar XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's naar XAML in JavaScript met Aspose.Slides voor Node.js - snelle, officevrije oplossing die uw lay-out intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt exporteren naar XAML met Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe u een presentatie opslaat als XAML met de standaardinstellingen, en demonstreert hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/), inclusief het exporteren van verborgen dia's. Het artikel beantwoordt ook een aantal veelgestelde vragen over fallback-lettertypen, compatibiliteit van XAML-stacks en het gedrag bij het exporteren van verborgen dia's.

## **Over XAML**

XAML is een beschrijvende programmeertaal waarmee u gebruikersklassen voor apps kunt bouwen of schrijven, vooral voor apps die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin-forms gebruiken.

XAML, een op XML gebaseerde taal, is Microsoft's variant voor het beschrijven van een GUI. U zult waarschijnlijk meestal een designer gebruiken om aan XAML-bestanden te werken, maar u kunt nog steeds uw GUI schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Deze JavaScript-code laat zien hoe u een presentatie exporteert naar XAML met de standaardinstellingen:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Presentaties exporteren naar XAML met aangepaste opties**

U kunt opties selecteren uit de klasse [XamlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/XamlOptions) die het exportproces regelen en bepalen hoe Aspose.Slides uw presentatie exporteert naar XAML.

Bijvoorbeeld, als u wilt dat Aspose.Slides verborgen dia's uit uw presentatie toevoegt bij het exporteren naar XAML, kunt u de [setExportHiddenSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) methode op true zetten. Zie deze voorbeeld-JavaScript-code:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Veelgestelde vragen**

**Hoe kan ik voorspelbare lettertypen garanderen als het originele lettertype niet beschikbaar is op de machine?**

Gebruik [setDefaultRegularFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/) - dit wordt gebruikt als fallback-lettertype wanneer het originele ontbreekt. Dit helpt onvoorziene vervangingen te voorkomen.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML-stacks worden gebruikt?**

XAML is een algemene UI-markuptaal die wordt gebruikt in WPF, UWP en Xamarin.Forms. De export richt zich op compatibiliteit met de XAML-stacks van Microsoft; het exacte gedrag en de ondersteuning voor specifieke constructies hangen af van het doelsysteem. Test de markup in uw omgeving.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard geëxporteerd worden?**

Standaard worden verborgen dia's niet meegenomen. U kunt dit gedrag regelen via [setExportHiddenSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xamloptions/) - houd het uitgeschakeld als u ze niet wilt exporteren.
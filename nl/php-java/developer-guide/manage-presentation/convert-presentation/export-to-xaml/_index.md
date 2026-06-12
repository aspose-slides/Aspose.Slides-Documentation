---
title: Presentaties exporteren naar XAML in PHP
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "Converteer PowerPoint‑ en OpenDocument‑dia's naar XAML met Aspose.Slides voor PHP via Java — snelle, Office‑vrije oplossing die uw lay‑out intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt exporteren naar XAML met Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe u een presentatie opslaat naar XAML met standaardinstellingen, en toont hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/), inclusief het exporteren van verborgen dia's. Het artikel beantwoordt ook een aantal veelgestelde vragen over fallback‑lettertypen, XAML‑stack‑compatibiliteit en het gedrag bij het exporteren van verborgen dia's.

## **Over XAML**

XAML is een beschrijvende programmeertaal waarmee u gebruikersinterfaces kunt bouwen of schrijven voor apps, met name die welke WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin‑forms gebruiken.  

XAML, dat een op XML gebaseerde taal is, is Microsoft’s variant voor het beschrijven van een GUI. U zult waarschijnlijk een ontwerper gebruiken om met XAML‑bestanden te werken, maar u kunt nog steeds uw GUI schrijven en bewerken. 

## **Presentaties exporteren naar XAML met standaardopties**

Deze PHP‑code laat zien hoe u een presentatie exporteert naar XAML met standaardinstellingen:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Presentaties exporteren naar XAML met aangepaste opties**

U kunt opties kiezen uit de [XamlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/)‑klasse die het exportproces beheert en bepaalt hoe Aspose.Slides uw presentatie naar XAML exporteert.

Bijvoorbeeld, als u wilt dat Aspose.Slides verborgen dia's uit uw presentatie toevoegt bij het exporteren naar XAML, kunt u de [setExportHiddenSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/setexporthiddenslides/)‑methode gebruiken met de waarde `true`. Zie deze voorbeeld‑PHP‑code:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Veelgestelde vragen**

**Hoe kan ik voorspelbare lettertypen garanderen als het originele lettertype niet beschikbaar is op de machine?**

Stel een [standaard regulier lettertype](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/) in — dit wordt gebruikt als fallback‑lettertype wanneer het origineel ontbreekt. Dit helpt onverwachte substituties te voorkomen.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML‑stacks worden gebruikt?**

XAML is een algemene UI‑opmaaktaal die wordt gebruikt in WPF, UWP en Xamarin.Forms. De export richt zich op compatibiliteit met de XAML‑stacks van Microsoft; het exacte gedrag en de ondersteuning voor specifieke constructies hangen af van het doelsysteem. Test de markup in uw omgeving.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia's niet meegenomen. U kunt dit gedrag regelen via [setExportHiddenSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/setexporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xamloptions/) — laat het uitgeschakeld als u ze niet hoeft te exporteren.
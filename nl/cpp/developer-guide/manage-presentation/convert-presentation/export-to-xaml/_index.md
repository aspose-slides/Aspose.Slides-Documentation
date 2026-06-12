---
title: Presentaties exporteren naar XAML in C++
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/cpp/export-to-xaml/
keywords:
- exporteer PowerPoint
- exporteer OpenDocument
- exporteer presentatie
- converteer PowerPoint
- converteer OpenDocument
- converteer presentatie
- PowerPoint naar XAML
- OpenDocument naar XAML
- presentatie naar XAML
- PPT naar XAML
- PPTX naar XAML
- ODP naar XAML
- sla PPT op als XAML
- sla PPTX op als XAML
- sla ODP op als XAML
- exporteer PPT naar XAML
- exporteer PPTX naar XAML
- exporteer ODP naar XAML
- C++
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's naar XAML in C++ met Aspose.Slides — snelle, Office-vrije oplossing die uw lay-out intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties exporteert naar XAML met Aspose.Slides. Het bevat een korte inleiding tot XAML, laat zien hoe je een presentatie opslaat als XAML met standaardinstellingen, en demonstreert hoe je de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/), inclusief het exporteren van verborgen dia’s. Het artikel beantwoordt ook enkele veelgestelde vragen over fallback‑lettertypen, compatibiliteit met XAML‑stacks en het gedrag bij het exporteren van verborgen dia’s.

## **Over XAML**

XAML is een beschrijvende programmeertaal waarmee je gebruikersinterfaces voor apps kunt bouwen of schrijven, vooral voor WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin‑forms.

XAML, een op XML gebaseerde taal, is Microsoft‑s variant voor het beschrijven van een GUI. Je zult waarschijnlijk een designer gebruiken om aan XAML‑bestanden te werken, maar je kunt nog steeds je GUI handmatig schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Deze C++‑code laat zien hoe je een presentatie exporteert naar XAML met de standaardinstellingen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **Presentaties exporteren naar XAML met aangepaste opties**

Je kunt opties selecteren via de [IXamlOptions](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.xaml.i_xaml_options) interface die het exportproces beheersen en bepalen hoe Aspose.Slides jouw presentatie naar XAML exporteert.

Bijvoorbeeld, als je wilt dat Aspose.Slides verborgen dia’s uit je presentatie toevoegt bij het exporteren naar XAML, kun je `true` doorgeven aan de [set_ExportHiddenSlides()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313)‑methode. Zie deze voorbeeld‑C++‑code:

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **Veelgestelde vragen**

**Hoe kan ik voorspelbare lettertypen garanderen als het oorspronkelijke lettertype niet beschikbaar is op de machine?**

Gebruik [set_DefaultRegularFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/) — dit wordt gebruikt als fallback‑lettertype wanneer het origineel ontbreekt. Zo vermijd je onverwachte vervangingen.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML‑stacks worden gebruikt?**

XAML is een algemene UI‑opmaaktal die wordt gebruikt in WPF, UWP en Xamarin.Forms. De export is gericht op compatibiliteit met Microsoft‑XAML‑stacks; het exacte gedrag en de ondersteuning voor specifieke constructies hangen af van het doelsysteem. Test de markup in jouw omgeving.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia’s niet meegenomen. Je kunt dit gedrag regelen via [set_ExportHiddenSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export.xaml/xamloptions/) — houd het uitgeschakeld als je ze niet wilt exporteren.
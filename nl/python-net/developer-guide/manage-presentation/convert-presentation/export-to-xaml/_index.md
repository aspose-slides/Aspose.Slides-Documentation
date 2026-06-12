---
title: Presentaties exporteren naar XAML met Python
linktitle: Exporteren naar XAML
type: docs
weight: 30
url: /nl/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's naar XAML in Python met Aspose.Slides—snelle, Office-vrije oplossing die uw opmaak intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt exporteren naar XAML met behulp van Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe u een presentatie kunt opslaan als XAML met standaardinstellingen, en toont hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/), inclusief het exporteren van verborgen dia’s. Het artikel beantwoordt ook enkele veelgestelde vragen met betrekking tot fallback‑lettertypen, XAML‑stackcompatibiliteit en het gedrag bij het exporteren van verborgen dia’s.

## **Over XAML**

XAML is een beschrijvende programmeertaal die u in staat stelt gebruikersinterfaces voor apps te bouwen of te schrijven, met name voor apps die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin‑forms gebruiken.  

XAML, een op XML gebaseerde taal, is Microsoft’s variant voor het beschrijven van een GUI. U zult waarschijnlijk het grootste deel van de tijd een ontwerper gebruiken om met XAML‑bestanden te werken, maar u kunt nog steeds uw GUI schrijven en bewerken. 

## **Presentaties exporteren naar XAML met standaardopties**

Deze Python‑code laat zien hoe u een presentatie exporteert naar XAML met standaardinstellingen:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Presentaties exporteren naar XAML met aangepaste opties**

U kunt opties selecteren uit de klasse [XamlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/) die het exportproces regelen en bepalen hoe Aspose.Slides uw presentatie exporteert naar XAML. 

Bijvoorbeeld, als u wilt dat Aspose.Slides verborgen dia’s uit uw presentatie toevoegt bij het exporteren naar XAML, kunt u de eigenschap [export_hidden_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) instellen op `True`. Zie deze voorbeeld‑Python‑code: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **FAQ**

**Hoe kan ik voorspelbare lettertypen garanderen als het originele lettertype niet beschikbaar is op de machine?**

Stel [default_regular_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) in [XamlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/) in — deze wordt gebruikt als fallback‑lettertype wanneer het originele lettertype ontbreekt. Dit helpt onverwachte vervangingen te voorkomen.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML‑stacks worden gebruikt?**

XAML is een algemene UI‑opmaaktaal die wordt gebruikt in WPF, UWP en Xamarin.Forms. De export is gericht op compatibiliteit met Microsoft XAML‑stacks; het exacte gedrag en de ondersteuning voor specifieke constructies hangen af van het doelplatform. Test de markup in uw omgeving.

**Worden verborgen dia’s ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia’s niet meegenomen. U kunt dit gedrag regelen via [export_hidden_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) in [XamlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export.xaml/xamloptions/) — houd het uitgeschakeld als u ze niet wilt exporteren.
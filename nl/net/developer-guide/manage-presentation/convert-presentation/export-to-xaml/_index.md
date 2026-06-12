---
title: Presentaties exporteren naar XAML in .NET
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's naar XAML in .NET met Aspose.Slides - een snelle, Office-vrije oplossing die uw lay-out intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties exporteert naar XAML met Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe u een presentatie opslaat naar XAML met standaardinstellingen, en demonstreert hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/), inclusief het exporteren van verborgen dia's. Het artikel beantwoordt ook een aantal veelgestelde vragen over fallback‑lettertypen, compatibiliteit van XAML‑stacks en het gedrag van het exporteren van verborgen dia's.

## **Over XAML**

XAML is een beschrijvende programmeertaal die u in staat stelt gebruikersinterfaces voor apps te bouwen of te schrijven, met name voor apps die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin‑forms gebruiken.  

XAML, een op XML gebaseerde taal, is Microsoft‑variant voor het beschrijven van een GUI. U zult waarschijnlijk meestal een designer gebruiken om aan XAML‑bestanden te werken, maar u kunt nog steeds uw GUI schrijven en bewerken. 

## **Exporteren van presentaties naar XAML met standaardopties**

Deze C#‑code laat zien hoe u een presentatie exporteert naar XAML met de standaardinstellingen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **Exporteren van presentaties naar XAML met aangepaste opties**

U kunt opties selecteren vanuit de IXamlOptions‑interface die het exportproces regelen en bepalen hoe Aspose.Slides uw presentatie exporteert naar XAML. 

Bijvoorbeeld, als u wilt dat Aspose.Slides verborgen dia's uit uw presentatie toevoegt bij het exporteren naar XAML, kunt u de eigenschap [ExportHiddenSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) op true zetten. Zie deze voorbeeld‑C#‑code: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **FAQ**

**Hoe kan ik voorspelbare lettertypen garanderen wanneer het oorspronkelijke lettertype niet beschikbaar is op de machine?**

Stel [DefaultRegularFont](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveoptions/defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/) — dit wordt gebruikt als fallback‑lettertype wanneer het oorspronkelijke lettertype ontbreekt. Dit helpt onverwachte substituties te voorkomen.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML‑stacks worden gebruikt?**

XAML is een algemene UI‑markuptaal die wordt gebruikt in WPF, UWP en Xamarin.Forms. De export is gericht op compatibiliteit met Microsoft‑XAML‑stacks; het exacte gedrag en de ondersteuning voor specifieke constructies zijn afhankelijk van het doelsysteem. Test de markup in uw omgeving.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia's niet meegenomen. U kunt dit gedrag regelen via [ExportHiddenSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export.xaml/xamloptions/) — laat het uitgeschakeld als u ze niet hoeft te exporteren.
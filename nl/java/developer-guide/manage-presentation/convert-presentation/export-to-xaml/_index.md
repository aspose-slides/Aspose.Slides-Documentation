---
title: Presentaties exporteren naar XAML in Java
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's naar XAML in Java met Aspose.Slides—snelle, Office-vrije oplossing die uw lay-out intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint-presentaties kunt exporteren naar XAML met Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe u een presentatie kunt opslaan als XAML met de standaardinstellingen, en toont hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/), inclusief het exporteren van verborgen dia's. Het artikel beantwoordt ook enkele veelgestelde vragen over fallback-lettertypen, XAML stack-compatibiliteit en het gedrag bij het exporteren van verborgen dia's.

## **Over XAML**

XAML is een beschrijvende programmeertaal die het mogelijk maakt om gebruikersinterfaces voor apps te bouwen of te schrijven, met name voor toepassingen die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin forms gebruiken.  

XAML, dat een op XML gebaseerde taal is, is de Microsoft-variant voor het beschrijven van een GUI. U zult waarschijnlijk meestal een ontwerper gebruiken om met XAML-bestanden te werken, maar u kunt uw GUI ook handmatig schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Deze Java-code laat zien hoe u een presentatie kunt exporteren naar XAML met de standaardinstellingen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Presentaties exporteren naar XAML met aangepaste opties**

U kunt opties selecteren vanuit de [IXamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IXamlOptions) interface die het exportproces beheert en bepaalt hoe Aspose.Slides uw presentatie naar XAML exporteert. 

Bijvoorbeeld, als u wilt dat Aspose.Slides verborgen dia's uit uw presentatie toevoegt bij het exporteren naar XAML, kunt u de eigenschap [ExportHiddenSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) instellen op true. Zie deze voorbeeld-Java-code: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hoe kan ik voorspelbare lettertypen garanderen als het originele lettertype niet beschikbaar is op de machine?**

Stel een [standaard regulier lettertype](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/) in - dit wordt gebruikt als fallback-lettertype wanneer het originele ontbreekt. Dit helpt onverwachte vervangingen te voorkomen.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML-stacks worden gebruikt?**

XAML is een algemene UI-opmaaktaal die wordt gebruikt in WPF, UWP en Xamarin.Forms. De export richt zich op compatibiliteit met Microsoft XAML-stacks; het exacte gedrag en de ondersteuning voor specifieke constructies hangen af van het doelsysteem. Test de markup in uw omgeving.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia's niet meegenomen. U kunt dit gedrag regelen via [setExportHiddenSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xamloptions/) - houd deze uitgeschakeld als u ze niet wilt exporteren.
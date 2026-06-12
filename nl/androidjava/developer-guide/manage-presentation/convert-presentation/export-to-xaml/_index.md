---
title: Presentaties exporteren naar XAML op Android
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-dia's naar XAML in Java met Aspose.Slides voor Android - snelle, Office-vrije oplossing die uw lay-out intact houdt."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties naar XAML exporteert met Aspose.Slides. Het bevat een korte introductie tot XAML, laat zien hoe u een presentatie opslaat naar XAML met de standaardinstellingen, en demonstreert hoe u de export kunt aanpassen via [XamlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/), inclusief het exporteren van verborgen dia's. Het artikel beantwoordt ook een aantal veelgestelde vragen over fallback‑lettertypen, compatibiliteit van XAML‑stacks en het gedrag bij het exporteren van verborgen dia's.

## **Over XAML**

XAML is een beschrijvende programmeertaal waarmee u gebruikersinterfaces voor apps kunt bouwen of schrijven, vooral voor apps die WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) en Xamarin‑forms gebruiken.  
XAML, een op XML gebaseerde taal, is Microsoft‑s variant voor het beschrijven van een GUI. U zult waarschijnlijk meestal een ontwerper gebruiken om aan XAML‑bestanden te werken, maar u kunt nog steeds uw GUI schrijven en bewerken.

## **Presentaties exporteren naar XAML met standaardopties**

Deze Java‑code laat zien hoe u een presentatie naar XAML exporteert met de standaardinstellingen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Presentaties exporteren naar XAML met aangepaste opties**

U kunt opties selecteren uit de [IXamlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IXamlOptions) interface die het exportproces regelen en bepalen hoe Aspose.Slides uw presentatie naar XAML exporteert.

Bijvoorbeeld, als u wilt dat Aspose.Slides verborgen dia's uit uw presentatie toevoegt bij het exporteren naar XAML, kunt u de eigenschap [ExportHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) op true zetten. Zie deze voorbeeld‑Java‑code:

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

## **Veelgestelde vragen**

**Hoe kan ik voorspelbare lettertypen garanderen als het oorspronkelijke lettertype niet op de machine beschikbaar is?**

Stel [een standaard regulier lettertype](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [XamlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/) in — het wordt gebruikt als fallback‑lettertype wanneer het oorspronkelijke ontbreekt. Dit helpt onverwachte vervangingen te voorkomen.

**Is de geëxporteerde XAML alleen bedoeld voor WPF, of kan deze ook in andere XAML‑stacks worden gebruikt?**

XAML is een algemene UI‑opmaakt taal die wordt gebruikt in WPF, UWP en Xamarin.Forms. De export richt zich op compatibiliteit met Microsoft‑XAML‑stacks; het exacte gedrag en de ondersteuning voor specifieke constructies hangen af van het doelsysteem. Test de markup in uw omgeving.

**Worden verborgen dia's ondersteund, en hoe kan ik voorkomen dat ze standaard worden geëxporteerd?**

Standaard worden verborgen dia's niet meegenomen. U kunt dit gedrag regelen via [setExportHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) in [XamlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xamloptions/) — houd het uitgeschakeld als u ze niet wilt exporteren.
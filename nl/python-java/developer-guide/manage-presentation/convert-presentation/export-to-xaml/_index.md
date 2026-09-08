---
title: Presentaties exporteren naar XAML in Python via Java
linktitle: Presentatie naar XAML
type: docs
weight: 30
url: /nl/python-java/export-to-xaml/
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
- Python
- Java
- Aspose.Slides
description: "Export PowerPoint- en OpenDocument-presentaties naar XAML met Aspose.Slides for Python via Java. Gebruik standaardopties of neem verborgen dia's op."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint- en OpenDocument‑presentaties kunt exporteren naar XAML met Aspose.Slides for Python via Java. Het introduceert XAML, laat zien hoe u met standaardinstellingen kunt exporteren en laat zien hoe u verborgen dia's kunt opnemen met [XamlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/).

De voorbeelden vereisen Aspose.Slides for Python via Java en een compatibele Java‑runtime. Plaats `pres.pptx` in de huidige werkmap. Elk voorbeeld start de JVM alleen als deze nog niet draait.

## **Over XAML**

XAML (Extensible Application Markup Language) is een op XML gebaseerde taal voor het beschrijven van gebruikersinterfaces. Het wordt gebruikt door frameworks zoals Windows Presentation Foundation (WPF). U kunt XAML maken en bewerken met een visuele ontwerper of een teksteditor.

## **Presentaties exporteren naar XAML met standaardopties**

Maak een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) van het invoerbestand en geef vervolgens [XamlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/) door aan [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) om met de standaardinstellingen te exporteren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Presentaties exporteren naar XAML met aangepaste opties**

Gebruik [XamlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/) om de export te configureren. Om verborgen dia's op te nemen, roep [setExportHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) aan met `True` vóór het opslaan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Hoe kan ik een fallback‑lettertype kiezen wanneer het originele lettertype niet beschikbaar is?**

Gebruik [setDefaultRegularFont](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) op uw [XamlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/)‑object om een fallback‑lettertype op te geven. Zorg ervoor dat het gekozen lettertype beschikbaar is in de exportomgeving.

**Kan ik de geëxporteerde markup gebruiken in elk XAML‑framework?**

XAML‑frameworks verschillen in de ondersteunde elementen en functies. Test de geëxporteerde markup in uw doel‑framework voordat u deze in een applicatie integreert.

**Worden verborgen dia's standaard geëxporteerd?**

Nee. Om ze op te nemen, roep [setExportHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) aan met `True`. Laat het op `False` staan om ze uit te sluiten.
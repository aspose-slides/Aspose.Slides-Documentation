---
title: PowerPoint-presentaties naar XPS converteren in Python
linktitle: PowerPoint naar XPS
type: docs
weight: 70
url: /nl/python-java/convert-powerpoint-to-xps/
keywords:
- PowerPoint converteren
- presentatie converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar XPS
- presentatie naar XPS
- PPT naar XPS
- PPTX naar XPS
- PPT opslaan als XPS
- PPTX opslaan als XPS
- PPT exporteren naar XPS
- PPTX exporteren naar XPS
- Python
- Java
- Aspose.Slides
description: "Converteer PowerPoint PPT- en PPTX-presentaties naar XPS in Python met Aspose.Slides for Python via Java, met standaard- of aangepaste exportinstellingen."
---
## **Overzicht**

Aspose.Slides for Python via Java stelt u in staat PowerPoint‑presentaties te converteren naar XPS door een PPT‑ of PPTX‑bestand op te slaan in het XPS‑formaat. Dit artikel legt uit wanneer XPS nuttig kan zijn en laat zien hoe u een presentatie exporteert met de standaardinstellingen of met aangepaste [XpsOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xpsoptions/) instellingen.

## **Over XPS**

XPS (XML Paper Specification) is een op XML gebaseerd documentformaat ontwikkeld door Microsoft. Het beschrijft vaste pagina's en behoudt de lay-out van tekst en grafische elementen voor weergave en afdrukken met compatibele software.

## **Wanneer Microsoft XPS‑formaat gebruiken**

Gebruik XPS wanneer een documentworkflow vaste‑layoutbestanden vereist voor delen of afdrukken via XPS‑compatibele tools. Ontvangers hebben software nodig die XPS ondersteunt. Als uw workflow PDF vereist, zie [Convert PowerPoint to PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Om een PPT‑ of PPTX‑presentatie naar XPS te converteren, gebruikt u de [gratis online converter](https://products.aspose.app/slides/nl/conversion).
{{% /alert %}}

| Invoer PowerPoint‑presentatie | Uitvoer XPS‑document |
| --- | --- |
| ![Originele PowerPoint‑presentatie](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Presentatie geconverteerd naar XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **XPS‑conversie met Aspose.Slides**

Gebruik de [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) methode van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse met [SaveFormat.Xps](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Xps) om een presentatie te exporteren. U kunt de standaardexportinstellingen gebruiken of [XpsOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xpsoptions/) opgeven om de output aan te passen.

Elk voorbeeld hieronder start de Java‑virtual machine indien nodig en geeft de presentatie vrij na gebruik. Vervang de invoerbestandsnaam door het pad naar uw PPT‑ of PPTX‑bestand.

### **Presentaties naar XPS converteren met standaardinstellingen**

De volgende Python‑code converteert een presentatie naar XPS met de standaardinstellingen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Sla de presentatie op als een XPS-document.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Presentaties naar XPS converteren met aangepaste instellingen**

Het volgende voorbeeld gebruikt [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) om metafiles op te slaan als PNG‑afbeeldingen in het resulterende XPS‑document:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Sla de presentatie op met de aangepaste XPS-instellingen.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik XPS opslaan naar een stream in plaats van een bestand?**

Ja. De [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) methode heeft overloads die een Java‑outputstream accepteren. Met Python via Java gebruikt u een compatibele Java‑stream via JPype, zoals een Java‑byte‑array‑outputstream, om de geëxporteerde data in het geheugen te houden.

**Worden verborgen dia's opgenomen in de XPS-uitvoer?**

Verborgen dia's worden standaard uitgesloten. Om ze op te nemen, stelt u [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) in op `True` vóór het opslaan.

**Worden animaties en dia‑overgangen behouden in XPS?**

Nee. XPS bevat vaste pagina's, waardoor de geëxporteerde dia's geen animaties of overgangseffecten afspelen.
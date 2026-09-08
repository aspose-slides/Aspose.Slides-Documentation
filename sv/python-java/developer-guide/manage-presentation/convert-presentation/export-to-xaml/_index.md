---
title: Exportera presentationer till XAML i Python via Java
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/python-java/export-to-xaml/
keywords:
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- PowerPoint till XAML
- OpenDocument till XAML
- presentation till XAML
- PPT till XAML
- PPTX till XAML
- ODP till XAML
- spara PPT som XAML
- spara PPTX som XAML
- spara ODP som XAML
- exportera PPT till XAML
- exportera PPTX till XAML
- exportera ODP till XAML
- Python
- Java
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till XAML med Aspose.Slides för Python via Java. Använd standardalternativ eller inkludera dolda bilder."
---
## **Översikt**

Denna artikel förklarar hur du exporterar PowerPoint- och OpenDocument-presentationer till XAML med Aspose.Slides för Python via Java. Den introducerar XAML, visar hur du exporterar med standardinställningar och demonstrerar hur du inkluderar dolda bilder med [XamlOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/).

Exemplen kräver Aspose.Slides för Python via Java samt en kompatibel Java-runtime. Placera `pres.pptx` i den aktuella arbetskatalogen. Varje exempel startar JVM endast om den inte redan körs.

## **Om XAML**

XAML (Extensible Application Markup Language) är ett XML-baserat språk för att beskriva användargränssnitt. Det används av ramverk som Windows Presentation Foundation (WPF). Du kan skapa och redigera XAML med en visuell designer eller en textredigerare.

## **Exportera presentationer till XAML med standardalternativ**

Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) från indatafilen, skicka sedan [XamlOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/) till [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) för att exportera med standardinställningar:

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

## **Exportera presentationer till XAML med anpassade alternativ**

Använd [XamlOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/) för att konfigurera exporten. För att inkludera dolda bilder, anropa [setExportHiddenSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) med `True` innan du sparar:

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

## **Vanliga frågor**

**Hur kan jag välja ett reservteckensnitt när det ursprungliga teckensnittet inte är tillgängligt?**

Använd [setDefaultRegularFont](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) på ditt [XamlOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/)‑objekt för att ange ett reservteckensnitt. Se till att det valda teckensnittet är tillgängligt i exportmiljön.

**Kan jag använda den exporterade markupen i vilket XAML‑ramverk som helst?**

XAML‑ramverk skiljer sig åt när det gäller vilka element och funktioner som stöds. Testa den exporterade markupen i ditt målramverk innan du integrerar den i en applikation.

**Exporteras dolda bilder som standard?**

Nej. För att inkludera dem, anropa [setExportHiddenSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) med `True`. Sätt den till `False` för att exkludera dem.
---
title: Eksportowanie prezentacji do XAML w Pythonie przez Java
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/python-java/export-to-xaml/
keywords:
- eksport PowerPoint
- eksport OpenDocument
- eksport prezentacji
- konwersja PowerPoint
- konwersja OpenDocument
- konwersja prezentacji
- PowerPoint do XAML
- OpenDocument do XAML
- prezentacja do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- zapisz PPT jako XAML
- zapisz PPTX jako XAML
- zapisz ODP jako XAML
- eksport PPT do XAML
- eksport PPTX do XAML
- eksport ODP do XAML
- Python
- Java
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do XAML przy użyciu Aspose.Slides dla Pythona przez Java. Użyj opcji domyślnych lub dołącz ukryte slajdy."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint i OpenDocument do XAML przy użyciu Aspose.Slides dla Pythona przez Java. Wprowadza XAML, pokazuje, jak eksportować z ustawieniami domyślnymi, oraz demonstruje, jak dołączyć ukryte slajdy za pomocą XamlOptions.

Przykłady wymagają Aspose.Slides dla Pythona przez Java oraz kompatybilnego środowiska uruchomieniowego Java. Umieść `pres.pptx` w bieżącym katalogu roboczym. Każdy przykład uruchamia JVM tylko wtedy, gdy nie jest już uruchomiona.

## **O XAML**

XAML (Extensible Application Markup Language) jest językiem opartym na XML służącym do opisywania interfejsów użytkownika. Jest używany przez frameworki takie jak Windows Presentation Foundation (WPF). Można tworzyć i edytować XAML przy użyciu projektanta wizualnego lub edytora tekstu.

## **Eksportowanie prezentacji do XAML z opcjami domyślnymi**

Utwórz [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) z pliku wejściowego, a następnie przekaż [XamlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/) do [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), aby wyeksportować z ustawieniami domyślnymi:

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

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Użyj [XamlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/), aby skonfigurować eksport. Aby dołączyć ukryte slajdy, wywołaj [setExportHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) z wartością `True` przed zapisaniem:

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

**Jak mogę wybrać czcionkę zapasową, gdy oryginalna czcionka jest niedostępna?**

Użyj [setDefaultRegularFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) na obiekcie [XamlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/), aby określić czcionkę zapasową. Upewnij się, że wybrana czcionka jest dostępna w środowisku eksportu.

**Czy mogę używać wyeksportowanego markupu w dowolnym frameworku XAML?**

Frameworki XAML różnią się pod względem obsługiwanych elementów i funkcji. Przetestuj wyeksportowany markup w docelowym frameworku przed jego integracją z aplikacją.

**Czy ukryte slajdy są eksportowane domyślnie?**

Nie. Aby je dołączyć, wywołaj [setExportHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) z wartością `True`. Ustaw wartość `False`, aby je wykluczyć.
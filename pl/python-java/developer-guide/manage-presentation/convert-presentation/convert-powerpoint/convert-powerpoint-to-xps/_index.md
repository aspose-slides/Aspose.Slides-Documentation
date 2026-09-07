---
title: Konwertuj prezentacje PowerPoint do XPS w Pythonie
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /pl/python-java/convert-powerpoint-to-xps/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do XPS
- prezentacja do XPS
- PPT do XPS
- PPTX do XPS
- zapisz PPT jako XPS
- zapisz PPTX jako XPS
- eksportuj PPT do XPS
- eksportuj PPTX do XPS
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint w formatach PPT i PPTX do XPS w Pythonie przy użyciu Aspose.Slides for Python via Java, z domyślnymi lub niestandardowymi ustawieniami eksportu."
---
## **Przegląd**

Aspose.Slides for Python via Java pozwala konwertować prezentacje PowerPoint do XPS, zapisując plik PPT lub PPTX w formacie XPS. Ten artykuł wyjaśnia, kiedy XPS może być przydatny oraz pokazuje, jak wyeksportować prezentację przy użyciu domyślnych ustawień lub niestandardowych ustawień [XpsOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xpsoptions/).

## **O XPS**

XPS (XML Paper Specification) to oparty na XML format dokumentu opracowany przez firmę Microsoft. Opisuje on stałe strony, zachowując układ tekstu i grafiki do przeglądania oraz drukowania przy użyciu kompatybilnego oprogramowania.

## **Kiedy używać formatu Microsoft XPS**

Używaj XPS, gdy przepływ dokumentów wymaga plików o stałym układzie do udostępniania lub drukowania przy użyciu narzędzi kompatybilnych z XPS. Odbiorcy muszą posiadać oprogramowanie obsługujące XPS. Jeśli Twój przepływ wymaga formatu PDF, zobacz [Convert PowerPoint to PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Uwaga" %}}

Aby wypróbować konwersję prezentacji PPT lub PPTX do XPS, użyj [darmowego konwertera online](https://products.aspose.app/slides/pl/conversion).

{{% /alert %}}

| Prezentacja PowerPoint wejściowa | Dokument XPS wyjściowy |
| --- | --- |
| ![Oryginalna prezentacja PowerPoint](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Prezentacja przekonwertowana do XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Konwersja XPS przy użyciu Aspose.Slides**

Użyj metody [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) z [SaveFormat.Xps](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Xps), aby wyeksportować prezentację. Możesz użyć domyślnych ustawień eksportu lub podać [XpsOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xpsoptions/), aby dostosować wynik.

Każdy przykład poniżej uruchamia maszynę wirtualną Javy w razie potrzeby i zwalnia prezentację po użyciu. Zastąp nazwę pliku wejściowego ścieżką do swojego pliku PPT lub PPTX.

### **Konwertuj prezentacje do XPS używając domyślnych ustawień**

Poniższy kod Python konwertuje prezentację do XPS przy użyciu domyślnych ustawień:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Zapisz prezentację jako dokument XPS.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Konwertuj prezentacje do XPS używając niestandardowych ustawień**

Poniższy przykład używa [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng), aby zapisać metafile jako obrazy PNG w wynikowym dokumencie XPS:

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

    # Zapisz prezentację z niestandardowymi ustawieniami XPS.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę zapisać XPS do strumienia zamiast do pliku?**

Tak. Metoda [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) ma przeciążenia, które akceptują strumień wyjściowy Javy. Korzystając z Pythona przez Javę, użyj kompatybilnego strumienia Javy poprzez JPype, takiego jak strumień wyjściowy tablicy bajtów Javy, aby zachować wyeksportowane dane w pamięci.

**Czy ukryte slajdy są uwzględniane w wyjściu XPS?**

Ukryte slajdy są domyślnie wykluczane. Aby je uwzględnić, ustaw [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) na `True` przed zapisem.

**Czy animacje i przejścia slajdów są zachowywane w XPS?**

Nie. XPS zawiera stałe strony, więc wyeksportowane slajdy nie odtwarzają animacji ani efektów przejść.
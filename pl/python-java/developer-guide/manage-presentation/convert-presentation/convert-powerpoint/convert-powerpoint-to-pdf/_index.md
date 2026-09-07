---
title: Konwertuj PPT i PPTX do PDF w Pythonie przy użyciu Javy [Zawarte zaawansowane funkcje]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /pl/python-java/convert-powerpoint-to-pdf/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- PowerPoint do PDF
- prezentacja do PDF
- PPT do PDF
- konwertuj PPT do PDF
- PPTX do PDF
- konwertuj PPTX do PDF
- zapisz PowerPoint jako PDF
- zapisz PPT jako PDF
- zapisz PPTX jako PDF
- eksportuj PPT do PDF
- eksportuj PPTX do PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Konwertuj PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w Pythonie przy użyciu Javy i Aspose.Slides, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w Pythonie przy użyciu Javy oferuje kilka zalet, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolujących jakość obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać zamiany czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Korzystając z Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF przy użyciu metody [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save). Klasa [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), która zazwyczaj służy do konwertowania prezentacji na PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java wstawia informacje o API i numer wersji do dokumentów wyjściowych. Na przykład, podczas konwertowania prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, że nie możesz nakazać Aspose.Slides zmienić lub usunąć tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides pozwala na konwersję:

* Całe prezentacje do PDF
* Wybrane slajdy z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że wynikowe PDF-y ściśle odpowiadają oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Pole tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitu
* Hiperdłącza
* Nagłówki i stopki
* Wypunktowania
* Tabele

## **Konwersja PowerPoint do PDF**

Standardowa konwersja używa domyślnych ustawień eksportu PDF. Użyj opcji niestandardowych, gdy potrzebujesz kontrolować jakość obrazów, zawartość stron lub zgodność PDF.

Zainstaluj [Aspose.Slides for Python via Java](/slides/pl/python-java/installation/) oraz kompatybilne środowisko Java przed uruchomieniem przykładów. Każdy przykład odczytuje `presentation.pptx` z bieżącego katalogu roboczego; zamień go na swój plik PPT, PPTX lub ODP. Uruchom JVM raz na proces Pythona.

Ten kod konwertuje prezentację do PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose oferuje darmowy internetowy **konwerter PowerPoint do PDF**, który demonstruje proces konwersji prezentacji na PDF. Możesz przeprowadzić test przy użyciu tego konwertera, aby zobaczyć działanie opisanego tutaj procesu.
{{% /alert %}}

## **Konwersja PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia opcje niestandardowe — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwersja PowerPoint do PDF z opcjami niestandardowymi**

Korzystając z opcji konwersji niestandardowych, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metaplików, ustawić poziom kompresji dla tekstu, skonfigurować DPI dla obrazów i wiele innych.

Poniższy przykład kodu pokazuje, jak skonwertować prezentację PowerPoint do PDF z kilkoma opcjami niestandardowymi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Konwersja PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) z klasy [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w wynikowym PDF.

Ten kod pokazuje, jak skonwertować prezentację PowerPoint do PDF wraz z uwzględnieniem ukrytych slajdów:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Konwersja PowerPoint do PDF zabezpieczonego hasłem**

Ten kod demonstruje, jak skonwertować prezentację PowerPoint do PDF zabezpieczonego hasłem przy użyciu parametrów ochrony z klasy [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Wykrywanie zamiany czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveoptions/#setWarningCallback) w klasie [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), umożliwiającą wykrywanie zamiany czcionek podczas procesu konwersji prezentacji do PDF.

Użyj proxy JPype, aby odbierać wywołania zwrotne ostrzeżeń z API Javy. Przed sprawdzeniem prefiksu przekonwertuj ciąg opisu Javy na ciąg Pythona:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aby uzyskać więcej informacji o odbieraniu wywołań zwrotnych dotyczących zamiany czcionek podczas procesu renderowania, zobacz [Getting Warning Callbacks for Fonts Substitution](/slides/pl/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Aby uzyskać więcej informacji o zamianie czcionek, zobacz artykuł [Font Substitution](/slides/pl/python-java/font-substitution/).
{{% /alert %}}

## **Konwersja wybranych slajdów w PowerPoint do PDF**

Numery slajdów przekazywane do [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) są numerowane od 1. Ten przykład eksportuje slajdy 1 i 3, jeśli oba istnieją:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **Konwersja PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Ten przykład eksportuje pierwszy slajd na stronie o wymiarach 612 na 792 punktów (US Letter). Klonuje slajd do nowej prezentacji o określonym rozmiarze:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **Konwersja PowerPoint do PDF w widoku notatek slajdu**

Ten kod demonstruje, jak skonwertować prezentację PowerPoint do PDF zawierającego notatki:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Standardy dostępności i zgodności dla PDF**

Przy przygotowywaniu dostępnych PDF-ów, zapoznaj się z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Użyj [PdfOptions.setCompliance](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setCompliance), aby wybrać standard wyjściowy: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Ten kod demonstruje proces konwersji PowerPoint do PDF, który tworzy wiele plików PDF w oparciu o różne standardy zgodności:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako pojedynczą figurę. Poszczególne elementy ścieżki nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednorazowo?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu w trakcie procesu konwersji.

**Jak włączyć ukryte slajdy do PDF?**

Użyj metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) w klasie [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides może utrzymać wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazów, używając metod takich jak [setJpegQuality](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setJpegQuality) i [setSufficientResolution](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setSufficientResolution) w klasie [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), aby zapewnić wysokiej jakości obrazy w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides umożliwia eksport PDF-ów zgodnych z [różnymi standardami](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfcompliance/), w tym PDF/A1a, PDF/A1b i PDF/UA, pod kątem dostępności lub archiwizacji. Wybierz odpowiedni standard i zweryfikuj wynik pod kątem swoich wymagań.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides for Python via Java](/slides/pl/python-java/)
- [Referencja API Aspose.Slides for Python via Java](https://reference.aspose.com/slides/pl/python-java/)
- [Darmowe konwertery online Aspose](https://products.aspose.app/slides/pl/conversion)
---
title: Konwertuj PPT i PPTX do PDF w Pythonie za pośrednictwem Javy [Zawarte Zaawansowane Funkcje]
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
description: "Konwertuj prezentacje PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w Pythonie za pośrednictwem Javy przy użyciu Aspose.Slides, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w Pythonie za pośrednictwem Javy oferuje wiele zalet, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontroli jakości obrazu, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Za pomocą Aspose.Slides możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF przy użyciu metody [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save). Klasa [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save), która jest zazwyczaj używana do konwersji prezentacji do PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java wstawia informacje o API oraz wersję do dokumentów wyjściowych. Na przykład podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga** że nie możesz nakazać Aspose.Slides zmienić lub usunąć tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia:

* Konwertowanie całych prezentacji do PDF
* Konwertowanie wybranych slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że otrzymane pliki PDF są bardzo zbliżone do oryginalnych prezentacji. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hiperłącza
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwertowanie PowerPoint do PDF**

Standardowa konwersja używa domyślnych ustawień eksportu PDF. Użyj opcji niestandardowych, gdy potrzebujesz kontrolować jakość obrazu, zawartość strony lub zgodność PDF.

Zainstaluj [Aspose.Slides for Python via Java](/slides/pl/python-java/installation/) oraz kompatybilne środowisko Java przed uruchomieniem przykładów. Każdy przykład odczytuje `presentation.pptx` z bieżącego katalogu; zamień go na swój plik PPT, PPTX lub ODP. Uruchom JVM raz na proces Pythona.

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

Aspose oferuje darmowy internetowy **Konwerter PowerPoint do PDF**(https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przetestować ten konwerter, aby zobaczyć działanie opisanej procedury.

{{% /alert %}}

## **Konwertowanie PowerPoint do PDF z Opcjami**

Aspose.Slides udostępnia opcje niestandardowe — właściwości w klasie [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertowanie PowerPoint do PDF z Opcjami Niestandardowymi**

Korzystając z opcji konwersji, możesz określić preferowane ustawienie jakości rastrowych obrazów, zdefiniować sposób obsługi metaplik, ustawić poziom kompresji tekstu, skonfigurować DPI obrazów i wiele więcej.

Poniższy przykład kodu demonstruje konwersję prezentacji PowerPoint do PDF z kilkoma opcjami niestandardowymi.

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

### **Konwertowanie PowerPoint do PDF z Ukrytymi Slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) z klasy [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w wynikowym PDF.

Ten kod pokazuje, jak konwertować prezentację PowerPoint do PDF z uwzględnionymi ukrytymi slajdami:

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

### **Konwertowanie PowerPoint do PDF zabezpieczonego hasłem**

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do PDF zabezpieczonego hasłem przy użyciu parametrów ochrony z klasy [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/):

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

### **Wykrywanie Podstawień Czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveoptions/#setWarningCallback) w klasie [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), umożliwiając wykrycie podstawień czcionek podczas procesu konwersji prezentacji do PDF.

Użyj proxy JPype, aby otrzymywać wywołania zwrotne ostrzeżeń z API Javy. Przed sprawdzeniem prefiksu skonwertuj ciąg opisu z Javy na ciąg Pythona:

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

Po więcej informacji o odbieraniu wywołań zwrotnych dla podstawień czcionek podczas renderowania, zobacz [Getting Warning Callbacks for Font Substitution](/slides/pl/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Po więcej informacji o podstawieniach czcionek, zobacz artykuł [Font Substitution](/slides/pl/python-java/font-substitution/).

{{% /alert %}}

## **Konwertowanie Wybranych Slajdów w PowerPoint do PDF**

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

## **Konwertowanie PowerPoint do PDF z Niestandardowym Rozmiarem Slajdu**

Ten przykład eksportuje pierwszy slajd na stronie o wymiarach 612 × 792 punktów (US Letter). Klonuje slajd w nowej prezentacji o określonym rozmiarze:

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

## **Konwertowanie PowerPoint do PDF w Widoku Notatek Slajdu**

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do PDF, który zawiera notatki:

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

## **Standardy Dostępności i Zgodności dla PDF**

Przy tworzeniu dostępnych PDF‑ów, odwołaj się do [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Użyj [PdfOptions.setCompliance](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setCompliance), aby wybrać standard wyjściowy: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Ten kod demonstruje proces konwersji PowerPoint do PDF, który generuje wiele plików PDF w zależności od różnych standardów zgodności:

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

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako pojedynczą figurę. Poszczególne elementy ścieżek nie są zachowywane jako odrębna treść i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany wyłącznie dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo stosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), aby ustawić hasło i zdefiniować uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Użyj metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) w klasie [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), aby włączyć ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides utrzymuje wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazu, używając metod takich jak [setJpegQuality](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setJpegQuality) i [setSufficientResolution](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setSufficientResolution) w klasie [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), aby zapewnić wysoką jakość obrazów w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides pozwala eksportować PDF‑y zgodne z [różnymi standardami](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfcompliance/), w tym PDF/A1a, PDF/A1b i PDF/UA, przeznaczone do dostępności lub archiwizacji. Wybierz odpowiedni standard i zweryfikuj wynik względem swoich wymagań.

## **Dodatkowe zasoby**

- [Aspose.Slides for Python via Java Documentation](/slides/pl/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/pl/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/pl/conversion)
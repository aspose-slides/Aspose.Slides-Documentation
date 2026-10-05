---
title: Konwertuj PPT i PPTX do PDF w Pythonie przy użyciu Java [Zawarte funkcje zaawansowane]
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
- załącznik
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Konwertuj PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF w Pythonie przy użyciu Java i Aspose.Slides, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w języku Python przy użyciu Java zapewnia szereg korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontroli jakości obrazu, włączać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Korzystając z Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację na PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF używając metody [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Klasa [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), która zwykle służy do konwersji prezentacji do PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java wstawia informacje o API oraz numer wersji do dokumentów wyjściowych. Na przykład podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, że nie możesz nakazać Aspose.Slides zmiany lub usunięcia tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Konkretnego slajdu lub slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF bardzo dokładnie odzwierciedlają oryginalne prezentacje. Elementy i atrybuty są renderowane precyzyjnie podczas konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hiperłącza
* Nagłówki i stopki
* Wypunktowania
* Tabele

## **Konwersja PowerPoint do PDF**

Standardowa konwersja wykorzystuje domyślne ustawienia eksportu PDF. Użyj własnych opcji, gdy potrzebujesz kontrolować jakość obrazu, zawartość stron lub zgodność PDF.

Zainstaluj [Aspose.Slides for Python via Java](/slides/pl/python-java/installation/) oraz kompatybilne środowisko Java przed uruchomieniem przykładów. Każdy przykład odczytuje plik `presentation.pptx` z bieżącego katalogu; zamień go na własny plik PPT, PPTX lub ODP. Uruchom JVM raz na proces Pythona.

Poniższy przykład wczytuje prezentację i zapisuje wszystkie widoczne slajdy do PDF przy użyciu domyślnych ustawień eksportu.

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

Aspose oferuje darmowy internetowy [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przetestować ten konwerter, aby zobaczyć działanie opisanej tu procedury.

{{% /alert %}}

## **Konwersja PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia własne opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć PDF hasłem lub określić sposób przebiegu konwersji.

### **Konwersja PowerPoint do PDF z własnymi opcjami**

Korzystając z własnych opcji konwersji, możesz określić preferowane ustawienie jakości rastra obrazów, sposób obsługi metafili, poziom kompresji tekstu, DPI obrazów i więcej.

Poniższy przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metafilami zapisywanymi jako PNG oraz kompresją tekstu Flate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Zachowanie osadzonych plików OLE jako załączników PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excela, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz do slajdów. Wywołaj metodę [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) z wartością `True`, aby zachować osadzone pliki OLE jako załączniki w powstałym PDF.

Domyślna wartość to `False`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `True` dodatkowo dołącza dane pliku. Podgląd pozostaje wizualną reprezentacją; załącznik pozwala odbiorcom otworzyć lub zapisać osadzony plik osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excela na stronie PDF.

Poniższy przykład wczytuje prezentację, która już zawiera osadzony skoroszyt Excela i eksportuje ją do PDF z dołączonym skoroszytem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Aby sprawdzić wynik:

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki, np. Adobe Acrobat Reader.
2. Otwórz panel **Attachments** i znajdź osadzony skoroszyt.
3. Zapisz załącznik i otwórz go w Excelu, aby zbadać dane, lub otwórz bezpośrednio, jeśli przeglądarka to umożliwia. Podgląd na stronie PDF jest odrębny od załącznika.

{{% alert color="info" title="Note" %}}

Standardy PDF/A narzucają ograniczenia dotyczące załączników: PDF/A-1 zakazuje osadzonych plików, PDF/A-2 dopuszcza jedynie załączniki PDF/A, a PDF/A-3 dopuszcza inne typy plików, w tym skoroszyty Excela. Są to wymogi standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.

{{% /alert %}}

### **Konwersja PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) klasy [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), aby włączyć ukryte slajdy jako strony w powstałym PDF.

Poniższy przykład eksportuje prezentację do PDF, uwzględniając wszystkie ukryte slajdy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Konwersja PowerPoint do PDF zabezpieczonego hasłem**

Poniższy przykład eksportuje prezentację do PDF, który wymaga podania hasła `password` przy otwieraniu. Uprawnienia dostępu pozwalają na drukowanie, w tym drukowanie wysokiej jakości.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Wykrywanie podstawień czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) w klasie [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), umożliwiając wykrycie podstawień czcionek podczas konwersji prezentacji do PDF.

Poniższy przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o podstawieniach czcionek na konsolę. Ostrzeżenie pojawia się tylko wtedy, gdy podczas eksportu zostaje zastąpiona niedostępna czcionka. Użyj proxy JPype, aby otrzymywać wywołania zwrotne ostrzeżeń z API Java. Przed sprawdzeniem prefiksu przekonwertuj ciąg opisowy z Java na ciąg Pythona:

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


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Więcej informacji o podstawieniach czcionek znajdziesz w artykule [Font Substitution](/slides/pl/python-java/font-substitution/).

{{% /alert %}}

## **Konwersja wybranych slajdów z PowerPoint do PDF**

Numery slajdów przekazywane do [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) są numerowane od 1. Ten przykład eksportuje slajdy 1 i 3, jeśli oba istnieją:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Konwersja PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Ten przykład eksportuje pierwszy slajd na stronę o wymiarach 612 × 792 punktów (US Letter). Klonuje slajd do nowej prezentacji o określonym rozmiarze i skaluje zawartość slajdu, aby pasowała.

```python
import jpype
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Usuń pusty slajd, który został utworzony w nowej prezentacji.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Konwersja PowerPoint do PDF w widoku notatek slajdu**

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta pod każdym slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć wynik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Dostępność i standardy zgodności PDF**

Podczas przygotowywania dostępnych PDF‑ów odwołaj się do [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Użyj [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance), aby wybrać standard wyjściowy: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Poniższy kod demonstruje proces konwersji PowerPoint do PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

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

> **Uwaga:** przy eksportowaniu do PDF/UA, Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako pojedynczą figurę. Poszczególne elementy ścieżek nie są zachowywane jako odrębna zawartość i mogą być oznaczone jako artefakty; alternatywny tekst jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF masowo?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), aby ustawić hasło i zdefiniować uprawnienia dostępu podczas konwersji.

**Jak włączyć ukryte slajdy w PDF?**

Wywołaj metodę [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) z wartością `True` w klasie [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy w powstałym PDF.

**Czy Aspose.Slides może zachować wysoką jakość obrazu w PDF?**

Tak, możesz kontrolować jakość obrazu, używając metod takich jak [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) i [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) w klasie [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), aby zapewnić wysoką jakość obrazów w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides umożliwia eksport PDF‑ów zgodnych z [różnymi standardami](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), w tym PDF/A1a, PDF/A1b i PDF/UA, dla dostępności lub archiwizacji. Wybierz odpowiedni standard i zweryfikuj wynik pod kątem swoich wymagań.

## **Dodatkowe zasoby**

- [Aspose.Slides for Python via Java Documentation](/slides/pl/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
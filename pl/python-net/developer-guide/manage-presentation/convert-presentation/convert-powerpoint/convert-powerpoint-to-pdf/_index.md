---
title: Konwertuj PPT i PPTX do PDF w Pythonie | Zaawansowane opcje
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /pl/python-net/convert-powerpoint-to-pdf/
keywords:
- konwertuj PowerPoint
- prezentacja
- PowerPoint do PDF
- PPT do PDF
- PPTX do PDF
- zapisz PowerPoint jako PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Przewodnik krok po kroku konwertujący PPT, PPTX i ODP na wysokiej jakości, zgodne z WCAG pliki PDF w Pythonie przy użyciu Aspose.Slides - obejmuje ochronę hasłem, wybór slajdów i kontrolę jakości obrazu."
showReadingTime: true
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP) do formatu PDF w języku Python oferuje wiele korzyści, w tym zapewnienie kompatybilności na różnych urządzeniach oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, korzystać z różnych opcji kontrolujących jakość obrazów, uwzględniać ukryte slajdy, zabezpieczać PDF hasłem, wykrywać zamiany czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności dla dokumentów wyjściowych.

## **Konwersje PowerPoint do PDF**

Korzystając z Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację do PDF w Pythonie, wystarczy przekazać nazwę pliku jako argument do klasy [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/) oraz zapisać prezentację jako PDF przy użyciu metody [Save](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/#methods). Klasa [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/) udostępnia metodę [Save](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/#methods), która jest zazwyczaj używana do konwersji prezentacji do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python bezpośrednio zapisuje informacje o API i numerze wersji w dokumentach wyjściowych. Na przykład, podczas konwersji prezentacji do PDF, Aspose.Slides for Python wypełnia pole Application wartością '*Aspose.Slides*' oraz pole PDF Producer wartością w formacie '*Aspose.Slides v XX.XX*'. **Uwaga**, że nie możesz nakazać Aspose.Slides for Python zmiany ani usunięcia tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Wybranych slajdów w prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że zawartość uzyskanych plików PDF ściśle odpowiada oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Odnośniki hipertekstowe
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowa operacja konwersji PowerPoint do PDF jest wykonywana przy użyciu domyślnych opcji. W tym przypadku Aspose.Slides stara się przekonwertować podaną prezentację do PDF, stosując optymalne ustawienia przy maksymalnym poziomie jakości. Ten kod w Pythonie pokazuje, jak konwertować PowerPoint do PDF:

*Steps: PowerPoint to PDF Conversions in Python*

Poniższy przykładowy kod opisuje te konwersje przy użyciu Pythona w środowisku .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Steps: Convert PowerPoint to PDF using Python via .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Steps: Convert PPT to PDF using Python via .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Steps: Convert PPTX to PDF using Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Steps: Convert ODP to PDF using Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Steps: Convert PPS to PDF using Python via .NET</a></strong>

_Code Steps:_

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i podaj jej plik PowerPoint.
  * rozszerzenie _.ppt_ aby załadować plik **PPT** w klasie _Presentation_.
  * rozszerzenie _.pptx_ aby załadować plik **PPTX** w klasie _Presentation_.
  * rozszerzenie _.odp_ aby załadować plik **ODP** w klasie _Presentation_.
  * rozszerzenie _.pps_ aby załadować plik **PPS** w klasie _Presentation_.
- Zapisz _Presentation_ w formacie **PDF**, wywołując metodę **Save** i używając enumeracji **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Tworzy instancję klasy Presentation, która reprezentuje plik PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Zapisuje prezentację jako PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Aby przetestować opisany tutaj przebieg, możesz skorzystać z tego konwertera.

{{% /alert %}}

## **Konwertuj PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości klasy [PdfOptions](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides.export/pdfoptions/) — które pozwalają dostosować PDF (wynik procesu konwersji), zabezpieczyć PDF hasłem lub nawet określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z własnymi opcjami**

Korzystając z własnych opcji konwersji, możesz ustawić preferowane ustawienia jakości obrazów rastrowych, określić sposób obsługi metafile, ustawić poziom kompresji tekstu, DPI obrazów itp.

Poniższy przykład kodu demonstruje operację, w której prezentacja PowerPoint jest konwertowana do PDF z kilkoma niestandardowymi opcjami:

```python
import aspose.slides as slides

# Tworzy instancję klasy PdfOptions
pdf_options = slides.export.PdfOptions()

# Ustawia jakość obrazów JPG
pdf_options.jpeg_quality = 90

# Ustawia DPI dla obrazów
pdf_options.sufficient_resolution = 300

# Ustawia zachowanie metafili
pdf_options.save_metafiles_as_png = True

# Ustawia poziom kompresji tekstu dla zawartości tekstowej
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definiuje tryb zgodności PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Tworzy instancję klasy Presentation, która reprezentuje dokument PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Zapisuje prezentację jako dokument PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć własnej opcji — właściwości `show_hidden_slides` klasy [PdfOptions](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides.export/pdfoptions/) — aby nakazać Aspose.Slides uwzględnienie ukrytych slajdów jako stron w wynikowym PDF.

Ten kod w Pythonie pokazuje, jak konwertować prezentację PowerPoint do PDF z uwzględnieniem ukrytych slajdów:

```python
import aspose.slides as slides

# Tworzy instancję klasy Presentation, która reprezentuje plik PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Tworzy instancję klasy PdfOptions
pdfOptions = slides.export.PdfOptions()

# Dodaje ukryte slajdy
pdfOptions.show_hidden_slides = True

# Zapisuje prezentację jako PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Ten kod w Pythonie pokazuje, jak przekonwertować PowerPoint do PDF zabezpieczonego hasłem (przy użyciu parametrów ochrony z klasy [PdfOptions](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Tworzy obiekt Presentation, który reprezentuje plik PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Tworzy instancję klasy PdfOptions
pdfOptions = slides.export.PdfOptions()

# Ustawia hasło PDF oraz uprawnienia dostępu
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Zapisuje prezentację jako PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Konwertuj wybrane slajdy w PowerPoint do PDF**

Ten kod w Pythonie pokazuje, jak konwertować konkretne slajdy w prezentacji PowerPoint do PDF:

```python
import aspose.slides as slides

# Tworzy obiekt Presentation, który reprezentuje plik PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Ustawia tablicę pozycji slajdów
slides_array = [ 1, 3 ]

# Zapisuje prezentację jako PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Konwertuj PowerPoint do PDF z własnym rozmiarem slajdu**

Ten kod w Pythonie pokazuje, jak konwertować PowerPoint, gdy jego rozmiar slajdu jest określony, do PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Tworzy instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Tworzy nową prezentację z dostosowanym rozmiarem slajdu.
    with slides.Presentation() as resized_presentation:

        # Ustawia niestandardowy rozmiar slajdu.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Klonuje pierwszy slajd z oryginalnej prezentacji.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Zapisuje przeskalowaną prezentację jako PDF z notatkami.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Ten kod w Pythonie pokazuje, jak konwertować PowerPoint do PDF z notatkami:

```python
import aspose.slides as slides

# Tworzy instancję klasy Presentation, która reprezentuje plik PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Zapisuje prezentację jako notatki PDF
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Dostępność i standardy zgodności dla PDF**

Aspose.Slides pozwala używać procedury konwersji spełniającej [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, stosując dowolny z następujących standardów zgodności: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Ten kod w Pythonie demonstruje operację konwersji PowerPoint do PDF, w której uzyskuje się wiele plików PDF opartych na różnych standardach zgodności:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

Obsługa konwersji PDF w Aspose.Slides rozszerza się o możliwość konwersji PDF do najpopularniejszych formatów plików. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-jpg/), oraz [PDF do PNG](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-tiff/), i [PDF do XML](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-xml/) — również są wspierane.

{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostępny tylko dla całej figury.

## **FAQ**

**Czy Aspose.Slides for Python może usunąć informacje o aplikacji z PDF?**

Nie, Aspose.Slides for Python automatycznie umieszcza informacje o API i numer wersji w wyjściowym PDF. Nie można modyfikować ani usuwać tych danych.

**Jak uwzględnić tylko wybrane slajdy w konwersji PDF?**

Możesz określić indeksy slajdów, które chcesz przekonwertować, przekazując tablicę pozycji slajdów do metody `save`.

**Czy można zabezpieczyć PDF hasłem podczas konwersji?**

Tak, możesz ustawić hasło i określić uprawnienia dostępu przy użyciu klasy `PdfOptions` przed zapisaniem prezentacji jako PDF.

**Czy Aspose.Slides obsługuje konwersję PDF do innych formatów?**

Tak, Aspose.Slides obsługuje konwersję PDF do formatów takich jak HTML, obrazy (JPG, PNG), SVG, TIFF oraz XML.

**Jak zapewnić, że mój PDF spełnia standardy dostępności?**

Ustaw właściwość `compliance` w `PdfOptions` na standardy takie jak `PDF_A1A`, `PDF_A1B` lub `PDF_UA`, aby zapewnić zgodność z wytycznymi dostępności.

**Czy mogę uwzględnić ukryte slajdy w wyjściowym PDF?**

Tak, ustawiając właściwość `show_hidden_slides` w `PdfOptions` na `True`, ukryte slajdy zostaną uwzględnione w PDF.

**Jak dostosować jakość obrazu i rozdzielczość podczas konwersji?**

Użyj właściwości `jpeg_quality` oraz `sufficient_resolution` w `PdfOptions`, aby kontrolować jakość i rozdzielczość obrazu w wynikowym PDF.

**Czy Aspose.Slides automatycznie obsługuje zamiany czcionek?**

Aspose.Slides wykrywa zamiany czcionek podczas konwersji i możesz nimi zarządzać przy użyciu właściwości `warning_callback` w `SaveOptions` (obecnie ograniczone).

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides dla .NET](https://docs.aspose.com/slides/pl/python-net/)
- [Referencja API Aspose.Slides](https://reference.aspose.com/slides/pl/python-net/)
- [Darmowe konwertery online Aspose](https://products.aspose.app/slides/pl/conversion)
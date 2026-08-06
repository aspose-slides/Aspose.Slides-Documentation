---
title: "Konwertuj PPT i PPTX do PDF w Pythonie | Zaawansowane opcje"
linktitle: "PowerPoint do PDF"
type: docs
weight: 40
url: /pl/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
  - "konwertuj PowerPoint"
  - "prezentacja"
  - "PowerPoint do PDF"
  - "PPT do PDF"
  - "PPTX do PDF"
  - "zapisz PowerPoint jako PDF"
  - "PDF/A1a"
  - "PDF/A1b"
  - "PDF/UA"
  - "Python"
  - "Aspose.Slides for Python"
description: "Przewodnik krok po kroku konwertujący PPT, PPTX i ODP do wysokiej jakości, zgodnych z WCAG plików PDF w Pythonie przy użyciu Aspose.Slides — obejmuje ochronę hasłem, wybór slajdów i kontrolę jakości obrazów."
showReadingTime: true
---
## **Przegląd**

Konwersja prezentacji PowerPoint (PPT, PPTX, ODP) do formatu PDF w języku Python oferuje wiele korzyści, w tym zapewnienie kompatybilności na różnych urządzeniach oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, korzystać z różnych opcji kontrolujących jakość obrazów, uwzględniać ukryte slajdy, zabezpieczać dokumenty PDF hasłem, wykrywać podstawienia czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Instalacja**

```bash
pip install aspose.slides
```

Pakiet zawiera niezbędne środowisko uruchomieniowe, więc Microsoft PowerPoint nie musi być zainstalowany na komputerze wykonującym konwersję.

## **Konwersje PowerPoint do PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację do PDF w Pythonie, wystarczy przekazać nazwę pliku jako argument do klasy [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/) . Następnie należy zapisać prezentację jako PDF przy użyciu metody [Save](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/#methods) . Klasa [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/) udostępnia metodę [Save](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/#methods) , która zazwyczaj jest używana do konwersji prezentacji do PDF.

{{%  alert title="UWAGA"  color="warning"   %}} 
Aspose.Slides for Python bezpośrednio zapisuje informacje o API i numer wersji w dokumentach wyjściowych. Na przykład, podczas konwersji prezentacji do PDF, Aspose.Slides for Python wypełnia pole Application wartością '*Aspose.Slides*', a pole PDF Producer wartością w formacie '*Aspose.Slides v XX.XX*'. **Uwaga** że nie można nakazać Aspose.Slides for Python zmiany lub usunięcia tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides umożliwia konwersję:
* Całe prezentacje do PDF
* Konkretne slajdy w prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że zawartość powstałych plików PDF bardzo dokładnie odpowiada oryginalnym prezentacjom. Elementy i atrybuty są renderowane precyzyjnie podczas konwersji, w tym:
* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hiperłącza
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowa operacja konwersji PowerPoint do PDF jest wykonywana przy użyciu domyślnych opcji. W tym przypadku Aspose.Slides próbuje przekonwertować podaną prezentację do PDF, stosując optymalne ustawienia przy maksymalnym poziomie jakości. Ten kod w Pythonie pokazuje, jak skonwertować PowerPoint do PDF:

*Steps: Konwersje PowerPoint do PDF w Pythonie*

Poniższy przykładowy kod wyjaśnia te konwersje przy użyciu Pythona poprzez .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Steps: Convert PowerPoint to PDF using Python via .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Steps: Convert PPT to PDF using Python via .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Steps: Convert PPTX to PDF using Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Steps: Convert ODP to PDF using Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Steps: Convert PPS to PDF using Python via .NET</a></strong>

_Kroki kodu:_

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i podaj jej plik PowerPoint.
  * _.ppt_ rozszerzenie, aby załadować plik **PPT** w klasie _Presentation_.
  * _.pptx_ rozszerzenie, aby załadować plik **PPTX** w klasie _Presentation_.
  * _.odp_ rozszerzenie, aby załadować plik **ODP** w klasie _Presentation_.
  * _.pps_ rozszerzenie, aby załadować plik **PPS** w klasie _Presentation_.
- Zapisz _Presentation_ w formacie **PDF**, wywołując metodę **Save** i używając wyliczenia **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Tworzy instancję klasy Presentation, która reprezentuje plik PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Zapisuje prezentację jako PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 
Aspose udostępnia bezpłatny internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Aby zobaczyć działanie opisanej procedury, możesz przetestować konwerter.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z Opcjami**

Aspose.Slides udostępnia własne opcje—właściwości w klasie [PdfOptions](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides.export/pdfoptions/)—które pozwalają dostosować PDF (powstały w wyniku procesu konwersji), zabezpieczyć PDF hasłem lub określić sposób przeprowadzania konwersji.

### **Konwertuj PowerPoint do PDF z niestandardowymi opcjami**

Korzystając z własnych opcji konwersji, możesz ustawić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metafili, ustawić poziom kompresji tekstu, DPI dla obrazów itp.  
Poniższy przykład kodu demonstruje operację, w której prezentacja PowerPoint jest konwertowana do PDF z kilkoma niestandardowymi opcjami:

```python
import aspose.slides as slides

# Tworzy instancję klasy PdfOptions
pdf_options = slides.export.PdfOptions()

# Ustawia jakość obrazów JPG
pdf_options.jpeg_quality = 90

# Ustawia DPI dla obrazów
pdf_options.sufficient_resolution = 300

# Ustawia zachowanie dla metafili
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

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć własnej opcji — właściwości `show_hidden_slides` z klasy [PdfOptions](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides.export/pdfoptions/) — aby nazwać Aspose.Slides, aby uwzględnił ukryte slajdy jako strony w wynikowym PDF.  
Ten kod w Pythonie pokazuje, jak przekonwertować prezentację PowerPoint do PDF z uwzględnieniem ukrytych slajdów:

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

### **Konwertuj PowerPoint do PDF chronionego hasłem**

Ten kod w Pythonie pokazuje, jak przekonwertować PowerPoint do PDF chronionego hasłem (używając parametrów ochrony z klasy [PdfOptions](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides.export/pdfoptions/) ):

```python
import aspose.slides as slides

# Tworzy obiekt Presentation, który reprezentuje plik PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Tworzy instancję klasy PdfOptions
pdfOptions = slides.export.PdfOptions()

# Ustawia hasło PDF i uprawnienia dostępu
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Zapisuje prezentację jako PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Konwertuj wybrane slajdy w PowerPoint do PDF**

Ten kod w Pythonie pokazuje, jak przekonwertować wybrane slajdy w prezentacji PowerPoint do PDF:

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

Ten kod w Pythonie pokazuje, jak przekonwertować PowerPoint, gdy jego rozmiar slajdu jest określony, do PDF:

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

        # Klonuje pierwszy slajd z oryginalnej prezentacji i usuwa domyślny pusty slajd.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # Zapisuje przeskalowaną prezentację jako PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Ten kod w Pythonie pokazuje, jak przekonwertować PowerPoint do notatek PDF:

```python
import aspose.slides as slides

# Tworzy instancję klasy Presentation, która reprezentuje plik PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

# Konfiguruje opcje PDF z układem notatek
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Zapisuje prezentację jako PDF z notatkami
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Standardy dostępności i zgodności dla PDF**

Aspose.Slides umożliwia użycie procedury konwersji, która spełnia [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, stosując jeden z następujących standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.  
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

{{% alert title="Uwaga" color="warning" %}} 
Obsługa konwersji PDF w Aspose.Slides obejmuje możliwość konwertowania PDF do najpopularniejszych formatów plików. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-jpg/), oraz [PDF do PNG](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-png/) . Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-tiff/), i [PDF do XML](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-xml/) — również są wspierane.
{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożoną grafikę, taką jak SmartArt, wykresy i formuły, jako pojedynczą figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

### Czy Aspose.Slides for Python może usunąć informacje o aplikacji z pliku PDF?

Nie, Aspose.Slides for Python automatycznie umieszcza informacje o API i numer wersji w wyjściowym pliku PDF. Informacji tych nie można modyfikować ani usunąć.

### Jak uwzględnić w konwersji tylko wybrane slajdy?

Możesz określić indeksy slajdów, które chcesz skonwertować, przekazując tablicę pozycji slajdów do metody `save`.

### Czy podczas konwersji można zabezpieczyć PDF hasłem?

Tak, przed zapisaniem prezentacji jako PDF możesz ustawić hasło i zdefiniować uprawnienia dostępu za pomocą klasy `PdfOptions`.

### Czy Aspose.Slides obsługuje konwersję PDF do innych formatów?

Tak, Aspose.Slides obsługuje konwersję PDF do formatów takich jak HTML, formaty obrazów (JPG, PNG), SVG, TIFF oraz XML.

### Jak zapewnić, że mój PDF spełnia standardy dostępności?

Ustaw właściwość `compliance` w `PdfOptions` na wartości takie jak `PDF_A1A`, `PDF_A1B` lub `PDF_UA`, aby zapewnić zgodność z wytycznymi dotyczącymi dostępności.

### Czy mogę uwzględnić ukryte slajdy w wyjściowym PDF?

Tak, ustawiając właściwość `show_hidden_slides` w `PdfOptions` na `True`, ukryte slajdy zostaną uwzględnione w PDF.

### Jak dostosować jakość obrazu i rozdzielczość podczas konwersji?

Użyj właściwości `jpeg_quality` i `sufficient_resolution` w `PdfOptions`, aby kontrolować jakość obrazu oraz rozdzielczość w wynikowym PDF.

### Czy Aspose.Slides automatycznie obsługuje podstawienia czcionek?

Aspose.Slides wykrywa podstawienia czcionek podczas konwersji i możesz nimi zarządzać za pomocą właściwości `warning_callback` w `SaveOptions` (obecnie ograniczone).

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides dla .NET](https://docs.aspose.com/slides/pl/python-net/)
- [Referencje API Aspose.Slides](https://reference.aspose.com/slides/pl/python-net/)
- [Bezpłatne konwertery online Aspose](https://products.aspose.app/slides/pl/conversion)
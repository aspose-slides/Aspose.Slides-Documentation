---
title: Konwersja PPT i PPTX do PDF w Pythonie | Zaawansowane opcje
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /pl/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
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
description: "Kompletny przewodnik krok po kroku konwertowania PPT, PPTX i ODP do wysokiej jakości, zgodnych z WCAG plików PDF w Pythonie przy użyciu Aspose.Slides — obejmuje zabezpieczenie hasłem, wybór slajdów i kontrolę jakości obrazów."
showReadingTime: true
---
## **Przegląd**

Konwersja prezentacji PowerPoint (PPT, PPTX, ODP) do formatu PDF w języku Python oferuje wiele korzyści, w tym zapewnienie kompatybilności na różnych urządzeniach oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, korzystać z różnych opcji kontrolujących jakość obrazów, włączać ukryte slajdy, zabezpieczać dokumenty PDF hasłem, wykrywać zamienniki czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację do PDF w Pythonie, wystarczy przekazać nazwę pliku jako argument w klasie [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/) i następnie zapisać prezentację jako PDF przy użyciu metody [Save](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/#methods). Klasa [Presentation](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/) udostępnia metodę [Save](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides/presentation/#methods), która zwykle jest używana do konwersji prezentacji do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python bezpośrednio zapisuje informacje o API oraz numer wersji w dokumentach wyjściowych. Na przykład, podczas konwersji prezentacji do PDF, Aspose.Slides for Python wypełnia pole Application wartością '*Aspose.Slides*' oraz pole PDF Producer wartością w formacie '*Aspose.Slides v XX.XX*'. **Uwaga**: nie można nakazać Aspose.Slides for Python zmienić lub usunąć tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides pozwala na konwersję:

* Całe prezentacje do PDF
* Wybrane slajdy w prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że zawartość wynikowych plików PDF ściśle odpowiada oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie w konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitu
* Hipertłącza
* Nagłówki i stopki
* Punktory
* Tabele

## **Konwersja PowerPoint do PDF**

Standardowa operacja konwersji PowerPoint do PDF jest wykonywana przy użyciu domyślnych opcji. W tym przypadku Aspose.Slides próbuje skonwertować podaną prezentację do PDF, korzystając z optymalnych ustawień przy maksymalnych poziomach jakości. Ten kod w Pythonie pokazuje, jak skonwertować PowerPoint do PDF:

_Kroki: Konwersje PowerPoint do PDF w Pythonie_

Następujący przykładowy kod wyjaśnia te konwersje przy użyciu Pythona przez .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Kroki: Konwersja PowerPoint do PDF przy użyciu Pythona przez .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Kroki: Konwersja PPT do PDF przy użyciu Pythona przez .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Kroki: Konwersja PPTX do PDF przy użyciu Pythona przez .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Kroki: Konwersja ODP do PDF przy użyciu Pythona przez .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Kroki: Konwersja PPS do PDF przy użyciu Pythona przez .NET</a></strong>

_Kroki kodu:_

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i podaj jej plik PowerPoint.
  * rozszerzenie _.ppt_ służy do załadowania pliku **PPT** w klasie _Presentation_.
  * rozszerzenie _.pptx_ służy do załadowania pliku **PPTX** w klasie _Presentation_.
  * rozszerzenie _.odp_ służy do załadowania pliku **ODP** w klasie _Presentation_.
  * rozszerzenie _.pps_ służy do załadowania pliku **PPS** w klasie _Presentation_.
- Zapisz _Presentation_ w formacie **PDF**, wywołując metodę **Save** i używając wyliczenia **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Tworzy instancję klasy Presentation, która reprezentuje plik PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Zapisuje prezentację jako PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose udostępnia darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Aby przetestować opisany tutaj proces na żywo, możesz skorzystać z konwertera.

{{% /alert %}}

## **Konwersja PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia własne opcje — właściwości klasy [PdfOptions](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides.export/pdfoptions/) — które pozwalają dostosować PDF (wynikający z procesu konwersji), zabezpieczyć PDF hasłem lub nawet określić sposób przebiegu konwersji.

### **Konwersja PowerPoint do PDF z własnymi opcjami**

Korzystając z własnych opcji konwersji, możesz ustawić preferowaną jakość obrazów rastrowych, określić sposób obsługi metafili, ustawić poziom kompresji tekstów, DPI dla obrazów itp.

Przykład kodu poniżej demonstruje operację, w której prezentacja PowerPoint jest konwertowana do PDF z kilkoma własnymi opcjami:

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

# Ustawia poziom kompresji tekstu dla treści tekstowych
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definiuje tryb zgodności PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Tworzy instancję klasy Presentation, która reprezentuje dokument PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Zapisuje prezentację jako dokument PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Konwersja PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć własnej opcji — właściwości `show_hidden_slides` z klasy [PdfOptions](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides.export/pdfoptions/), aby nakazać Aspose.Slides uwzględnienie ukrytych slajdów jako stron w wynikowym PDF.

Ten kod w Pythonie pokazuje, jak skonwertować prezentację PowerPoint do PDF, uwzględniając ukryte slajdy:

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

### **Konwersja PowerPoint do PDF chronionego hasłem**

Ten kod w Pythonie pokazuje, jak skonwertować PowerPoint do PDF chronionego hasłem (używając parametrów ochrony z klasy [PdfOptions](https://docs.aspose.com/slides/pl/python-net/api-reference/aspose.slides.export/pdfoptions/)):

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

## **Konwersja wybranych slajdów w PowerPoint do PDF**

Ten kod w Pythonie pokazuje, jak skonwertować wybrane slajdy w prezentacji PowerPoint do PDF:

```python
import aspose.slides as slides

# Tworzy obiekt Presentation, który reprezentuje plik PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Ustawia tablicę pozycji slajdów
slides_array = [ 1, 3 ]

# Zapisuje prezentację jako PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Konwersja PowerPoint do PDF z własnym rozmiarem slajdu**

Ten kod w Pythonie pokazuje, jak skonwertować PowerPoint, gdy jego rozmiar slajdu został określony, do PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Utwórz nową prezentację z dostosowanym rozmiarem slajdu.
    with slides.Presentation() as resized_presentation:

        # Ustaw niestandardowy rozmiar slajdu.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Sklonuj pierwszy slajd z oryginalnej prezentacji.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Zapisz zmienioną prezentację jako PDF z notatkami.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Konwersja PowerPoint do PDF w widoku notatek slajdu**

Ten kod w Pythonie pokazuje, jak skonwertować PowerPoint do PDF z notatkami:

```python
import aspose.slides as slides

# Tworzy instancję klasy Presentation, która reprezentuje plik PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Zapisuje prezentację jako notatki PDF
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Standardy dostępności i zgodności dla PDF**

Aspose.Slides umożliwia użycie procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, wykorzystując dowolny z tych standardów zgodności: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

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

Obsługa konwersji PDF w Aspose.Slides rozszerza się o możliwość konwertowania PDF do najpopularniejszych formatów plików. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-jpg/), oraz [PDF do PNG](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-tiff/), i [PDF do XML](https://products.aspose.com/slides/pl/python-net/conversion/pdf-to-xml/) — są również obsługiwane.

{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożone grafiki takie jak SmartArt, wykresy i formuły jako jedną figurę. Poszczególne elementy ścieżki nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy Aspose.Slides for Python może usunąć informacje o aplikacji z PDF?**

Nie, Aspose.Slides for Python automatycznie umieszcza informacje o API oraz numer wersji w wyjściowym PDF. Nie można modyfikować ani usunąć tych informacji.

**Jak włączyć tylko określone slajdy w konwersji do PDF?**

Możesz określić indeksy slajdów, które chcesz skonwertować, przekazując tablicę pozycji slajdów do metody `save`.

**Czy można zabezpieczyć PDF hasłem podczas konwersji?**

Tak, możesz ustawić hasło i określić uprawnienia dostępu za pomocą klasy `PdfOptions` przed zapisaniem prezentacji jako PDF.

**Czy Aspose.Slides obsługuje konwersję PDF do innych formatów?**

Tak, Aspose.Slides obsługuje konwersję PDF do formatów takich jak HTML, formaty obrazów (JPG, PNG), SVG, TIFF oraz XML.

**Jak zapewnić, że mój PDF jest zgodny ze standardami dostępności?**

Ustaw właściwość `compliance` w `PdfOptions` na standardy takie jak `PDF_A1A`, `PDF_A1B` lub `PDF_UA`, aby zapewnić zgodność z wytycznymi dostępności.

**Czy mogę uwzględnić ukryte slajdy w wyjściowym PDF?**

Tak, ustawiając właściwość `show_hidden_slides` w `PdfOptions` na `True`, ukryte slajdy zostaną uwzględnione w PDF.

**Jak dostosować jakość i rozdzielczość obrazów podczas konwersji?**

Użyj właściwości `jpeg_quality` i `sufficient_resolution` w `PdfOptions`, aby kontrolować jakość i rozdzielczość obrazów w wynikowym PDF.

**Czy Aspose.Slides automatycznie obsługuje zamiany czcionek?**

Aspose.Slides wykrywa zamiany czcionek podczas konwersji i możesz je obsłużyć za pomocą właściwości `warning_callback` w `SaveOptions` (obecnie ograniczone).

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides dla .NET](https://docs.aspose.com/slides/pl/python-net/)
- [Referencja API Aspose.Slides](https://reference.aspose.com/slides/pl/python-net/)
- [Bezpłatne konwertery online Aspose](https://products.aspose.app/slides/pl/conversion)
---
title: "Konwertuj PPT i PPTX do PDF w Pythonie | Zaawansowane opcje"
linktitle: "PowerPoint do PDF"
type: docs
weight: 40
url: /pl/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
  - konwertować PowerPoint
  - prezentacja
  - PowerPoint do PDF
  - PPT do PDF
  - PPTX do PDF
  - zapisać PowerPoint jako PDF
  - załącznik
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Python
  - Aspose.Slides for Python
description: "Przewodnik krok po kroku konwertujący PPT, PPTX i ODP do wysokiej jakości, zgodnych z WCAG plików PDF w Pythonie przy użyciu Aspose.Slides — zawiera ochronę hasłem, wybór slajdów i kontrolę jakości obrazów."
showReadingTime: true
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP) do formatu PDF w Pythonie oferuje wiele zalet, w tym zapewnienie kompatybilności na różnych urządzeniach oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, wykorzystać różne opcje kontrolowania jakości obrazów, uwzględnić ukryte slajdy, zabezpieczyć PDF hasłem, wykrywać substytucje czcionek, wybrać konkretne slajdy do konwersji oraz zastosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Przy użyciu Aspose.Slides możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację do PDF w Pythonie, wystarczy przekazać nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) i następnie zapisać prezentację jako PDF przy użyciu metody [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Klasa [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/), która jest typowo używana do konwersji prezentacji do PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python wstawia informacje o API i numer wersji do dokumentów wyjściowych. Na przykład, gdy konwertuje prezentację do PDF, Aspose.Slides for Python wypełnia pole Application wartością '*Aspose.Slides*', a pole PDF Producer wartością w formacie '*Aspose.Slides v XX.XX*'. **Uwaga**, że nie można nakazać Aspose.Slides for Python, aby zmienił lub usunął te informacje z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides pozwala konwertować:

* Całe prezentacje do PDF
* Konkretne slajdy w prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że zawartość powstałych plików PDF ściśle odpowiada oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie w trakcie konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* hiperłącza
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa domyślnych opcji. W tym przypadku Aspose.Slides stara się przekonwertować podaną prezentację do PDF przy użyciu optymalnych ustawień o maksymalnej jakości.

Poniższy przykład wczytuje prezentację i zapisuje wszystkie widoczne slajdy do PDF przy użyciu domyślnych ustawień eksportu.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}

Aspose oferuje darmowy internetowy [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Aby przetestować opisany tutaj sposób, możesz skorzystać z konwertera.

{{% /alert %}}

## **Konwertuj PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia własne opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — które pozwalają dostosować PDF (powstały w wyniku konwersji), zabezpieczyć PDF hasłem lub określić, w jaki sposób ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z własnymi opcjami**

Używając własnych opcji konwersji, możesz ustawić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metafili, ustawić poziom kompresji tekstu, DPI dla obrazów itd.

Poniższy przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metafilami zapisywanymi jako PNG oraz kompresją tekstu Flate.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Zachowaj osadzone pliki OLE jako załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz mogli przeglądać slajdy. Ustaw [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) na `True`, aby zachować osadzone pliki OLE jako załączniki w powstałym PDF.

Domyślna wartość to `False`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `True` dodatkowo dołącza dane pliku. Podgląd pozostaje wizualną reprezentacją; załącznik pozwala odbiorcom otworzyć lub zapisać osadzony plik osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład wczytuje prezentację, która już zawiera osadzony skoroszyt Excel, i eksportuje ją do PDF z dołączonym skoroszytem.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Aby sprawdzić wynik:

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki, takiej jak Adobe Acrobat Reader.
2. Otwórz panel **Attachments** i znajdź osadzony skoroszyt.
3. Zapisz załącznik i otwórz go w Excelu, aby przeanalizować dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Note" %}}

Standardy PDF/A nakładają ograniczenia na załączniki: PDF/A-1 zakazuje plików osadzonych, PDF/A-2 zezwala wyłącznie na załączniki PDF/A, a PDF/A-3 dopuszcza inne typy plików, w tym skoroszyty Excel. Są to wymagania standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.

{{% /alert %}}

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć własnej opcji — właściwości [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) klasy [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — aby polecić Aspose.Slides uwzględnienie ukrytych slajdów jako stron w powstałym PDF.

Poniższy przykład eksportuje prezentację do PDF, włączając wszystkie ukryte slajdy.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Poniższy przykład eksportuje prezentację do PDF, który wymaga podania hasła `password` przy otwieraniu. Uprawnienia dostępu zezwalają na drukowanie, w tym drukowanie wysokiej jakości.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Obsługa czcionek bez dedykowanej wersji pogrubionej**

Prezentacja może stosować pogrubienie tekstu, nawet gdy czcionka nie posiada dedykowanej wersji pogrubionej. Tekst może być wówczas pogrubiony sztucznie, co polega na sztucznym pogrubianiu regularnych glifów. Gdy taki tekst wygląda zbyt ciężko lub odbiega od zamierzonego wyglądu w PDF, spróbuj ustawić [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) na `True`. Opcja ta renderuje dotknięty tekst jako bitmapę podczas eksportu PDF i może poprawić jego wygląd dla niektórych czcionek. Domyślna wartość to `False`.

Przykładowa prezentacja zawiera dwa pola tekstowe: jedno z normalnym tekstem i drugie z pogrubionym formatowaniem zastosowanym do tej samej czcionki, która nie ma dedykowanej wersji pogrubionej. Poniższy przykład wczytuje prezentację, włącza rasteryzację nieobsługiwanych stylów czcionek i eksportuje ją do PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Poniższe podglądy pokazują wynik przy wyłączonej i włączonej opcji. W tym przykładzie tekst pogrubiony ma cięższe kreski przy wyłączonej opcji. Po włączeniu opcji kreski są lżejsze; tekst normalny pozostaje niezmieniony. Porównaj wyniki przed podjęciem decyzji o ustawieniu dla swojej prezentacji.

| Opcja wyłączona (`False`, domyślnie) | Opcja włączona (`True`) |
|---|---|
| ![PDF z wyłączoną rasteryzacją nieobsługiwanych stylów czcionek](unsupported-bold-disabled.png) | ![PDF z włączoną rasteryzacją nieobsługiwanych stylów czcionek](unsupported-bold-enabled.png) |

W tym przykładzie włączenie opcji przetwarza tylko pogrubiony tekst na bitmapę: nie można go zaznaczyć, skopiować ani wyszukać jako tekst bez OCR, a jego krawędzie wyglądają miękko przy 800 % powiększeniu. Normalny tekst pozostaje przeszukiwalny. Przy wyłączonej opcji oba ciągi pozostają tekstem.

Opcja ta rasteryzuje tekst sformatowany jako pogrubiony, gdy jego czcionka nie ma dedykowanej wersji pogrubionej. [Font substitution](/slides/pl/python-net/font-substitution/) zamiast tego wybiera inną czcionkę, gdy oryginalna jest niedostępna.

## **Konwertuj wybrane slajdy w PowerPoint do PDF**

Poniższy przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numery slajdów w tej tablicy są numerowane od 1, a prezentacja wejściowa musi zawierać co najmniej trzy slajdy.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Konwertuj PowerPoint do PDF z własnym rozmiarem slajdu**

Poniższy przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skaluje zawartość slajdu, aby dopasować ją i eksportuje pojedynczy slajd do PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Usuń pusty slajd, który został utworzony w nowej prezentacji.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta pod każdym slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć rezultat.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Standardy dostępności i zgodności dla PDF**

Aspose.Slides umożliwia użycie procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, stosując dowolny z następujących standardów zgodności: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Ten kod Pythona demonstruje operację konwersji PowerPoint do PDF, w której uzyskuje się wiele plików PDF opartych na różnych standardach zgodności:

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

{{% alert color="info" title="Note" %}}

Obsługa konwersji PDF w Aspose.Slides pozwala konwertować PDF do najpopularniejszych formatów plików. Możesz wykonać konwersje [PDF to HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), oraz [PDF to PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF to SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), oraz [PDF to XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — również są wspierane.

{{% /alert %}}

> **Uwaga:** Przy eksporcie do PDF/UA, Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy Aspose.Slides for Python może usunąć informacje o aplikacji z PDF?**

Nie, Aspose.Slides for Python automatycznie dołącza informacje o API i numer wersji do wyjściowego PDF. Nie można ich zmodyfikować ani usunąć.

**Jak uwzględnić tylko wybrane slajdy w konwersji PDF?**

Możesz określić indeksy slajdów, które chcesz przekonwertować, przekazując tablicę pozycji slajdów do metody [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Czy można zabezpieczyć PDF hasłem podczas konwersji?**

Tak, możesz ustawić hasło i zdefiniować uprawnienia dostępu przy użyciu klasy [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) przed zapisaniem prezentacji jako PDF.

**Czy Aspose.Slides obsługuje konwersję PDF do innych formatów?**

Tak, Aspose.Slides obsługuje konwersję PDF do formatów takich jak HTML, formaty obrazu (JPG, PNG), SVG, TIFF oraz XML.

**Jak zapewnić, że mój PDF spełnia standardy dostępności?**

Ustaw właściwość [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) w [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) na standardy takie jak `PDF_A1A`, `PDF_A1B` lub `PDF_UA`, aby zapewnić zgodność z wytycznymi dostępności.

**Czy mogę uwzględnić ukryte slajdy w wyjściowym PDF?**

Tak, ustawiając właściwość [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) w [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) na `True`, ukryte slajdy zostaną uwzględnione w PDF.

**Jak dostosować jakość i rozdzielczość obrazów podczas konwersji?**

Użyj właściwości [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) i [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) w [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), aby kontrolować jakość i rozdzielczość obrazów w powstałym PDF.

**Czy Aspose.Slides automatycznie obsługuje substytucje czcionek?**

Aspose.Slides wykrywa substytucje czcionek podczas konwersji i możesz nimi zarządzać przy użyciu właściwości `warning_callback` w `SaveOptions` (obecnie ograniczone).

## **Dodatkowe zasoby**

- [Aspose.Slides for Python via .NET Documentation](/slides/pl/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
---
title: "Konwertuj PPT i PPTX na PDF w Pythonie | Zaawansowane opcje"
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
  - "załącznik"
  - "PDF/A1a"
  - "PDF/A1b"
  - "PDF/UA"
  - "Python"
  - "Aspose.Slides for Python"
description: "Kompletny przewodnik krok po kroku konwertowania PPT, PPTX i ODP na wysokiej jakości, zgodne z WCAG pliki PDF w Pythonie z użyciem Aspose.Slides — obejmuje ochronę hasłem, wybór slajdów i kontrolę jakości obrazów."
showReadingTime: true
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP) na format PDF w języku Python oferuje wiele korzyści, w tym zapewnienie zgodności na różnych urządzeniach oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje na dokumenty PDF, wykorzystywać różne opcje kontrolowania jakości obrazów, uwzględniać ukryte slajdy, zabezpieczać PDF hasłem, wykrywać zamiany czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach na PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację na PDF w Pythonie, wystarczy przekazać nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) , a następnie zapisać prezentację jako PDF przy użyciu metody [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) . Klasa [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) , która zazwyczaj jest używana do konwersji prezentacji na PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python wstawia informacje o swoim API oraz numer wersji do dokumentów wyjściowych. Na przykład, podczas konwersji prezentacji do PDF, Aspose.Slides for Python wypełnia pole Application wartością '*Aspose.Slides*', a pole PDF Producer wartością w formacie '*Aspose.Slides v XX.XX*'. **Uwaga** że nie możesz nakazać Aspose.Slides for Python zmienić lub usunąć tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides pozwala na konwersję:

* Całe prezentacje do PDF
* Wybrane slajdy w prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że zawartość powstałych plików PDF ściśle odpowiada oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Ramki tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hiperdłącza
* Nagłówki i stopki
* Punktory
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa domyślnych opcji. W tym przypadku Aspose.Slides próbuje przekonwertować podaną prezentację na PDF, używając optymalnych ustawień przy maksymalnym poziomie jakości.

Poniższy przykład ładuje prezentację i zapisuje wszystkie widoczne slajdy do PDF przy użyciu domyślnych ustawień eksportu.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose udostępnia bezpłatny internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) , który demonstruje proces konwersji prezentacji do PDF. Aby zobaczyć działanie opisanej procedury w praktyce, możesz przetestować konwerter.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z Opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) , które pozwalają dostosować PDF (powstały w wyniku procesu konwersji), zabezpieczyć PDF hasłem lub nawet określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z Niestandardowymi Opcjami**

Korzystając z własnych opcji konwersji, możesz ustawić preferowane ustawienie jakości rastrowych obrazów, określić sposób obsługi metafili, ustawić poziom kompresji tekstu, DPI obrazów itp.

Poniższy przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metafile zapisanymi jako PNG oraz kompresją tekstu Flate.

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

### **Automatyczny Wybór Kompresji Obrazów**

Gdy prezentacja zawiera wiele fotografii lub zrzutów ekranu, zmniejszenie rozmiaru eksportowanego PDF może ułatwić jego wysyłanie e‑mail lub pobieranie. Ustaw [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) na `True`, aby automatycznie wybrać najbardziej odpowiedni algorytm kompresji dla każdego obrazu podczas eksportu PDF.

Poniższy przykład ładuje istniejącą prezentację, włącza automatyczny wybór kompresji obrazów i zapisuje ją jako dokument PDF. Wszystkie pozostałe ustawienia eksportu PDF zachowują domyślne wartości.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Ta opcja wybiera algorytm kompresji dla każdego obrazu. Obniżenie [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) zmniejsza jakość obrazu JPEG, natomiast obniżenie [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) pozwala na zmniejszenie rozdzielczości obrazu, co może ograniczyć szczegóły. Włączenie automatycznego wyboru kompresji nie obniża samo tych ustawień.

Wybór algorytmów kompresji obrazów wymaga dodatkowego czasu przetwarzania i pamięci. Redukcja rozmiaru zależy od obrazów w prezentacji i ustawień eksportu; stała redukcja nie jest gwarantowana dla każdej prezentacji.

### **Zachowaj Osadzone Pliki OLE jako Załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz mogli przeglądać slajdy. Ustaw [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) na `True`, aby zachować osadzone pliki OLE jako załączniki w powstałym PDF.

Domyślna wartość to `False`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale jego osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `True` dodatkowo obejmuje dane pliku. Podgląd pozostaje wizualną reprezentacją; załącznik umożliwia odbiorcom otwarcie lub zapisanie osadzonego pliku osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład ładuje prezentację, która już zawiera osadzony skoroszyt Excel i eksportuje ją do PDF z dołączonym skoroszytem.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Aby sprawdzić wynik:

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki, takiej jak Adobe Acrobat Reader.
2. Otwórz panel **Attachments** (Załączniki) przeglądarki i znajdź osadzony skoroszyt.
3. Zapisz załącznik i otwórz go w Excelu, aby sprawdzić dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Note" %}}
Standardy PDF/A nakładają ograniczenia na załączniki: PDF/A-1 zakazuje osadzonych plików, PDF/A-2 dopuszcza jedynie załączniki PDF/A, a PDF/A-3 zezwala na inne typy plików, w tym skoroszyty Excel. Są to wymagania standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstranuje eksportu PDF/A.
{{% /alert %}}

### **Konwertuj PowerPoint do PDF z Ukrytymi Slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć niestandardowej opcji — własności [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) z klasy [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) , aby nakazać Aspose.Slides uwzględnienie ukrytych slajdów jako stron w powstałym PDF.

Poniższy przykład eksportuje prezentację do PDF, uwzględniając wszystkie ukryte slajdy.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Poniższy przykład eksportuje prezentację do PDF, który wymaga hasła `password` do otwarcia. Uprawnienia dostępu zezwalają na drukowanie, w tym drukowanie w wysokiej jakości.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Obsługa Czcionek Bez Dedykowanego Pogrubionego Odwzorowania**

Prezentacja może zastosować pogrubienie tekstu, nawet gdy czcionka nie ma dedykowanego odcienia pogrubionego. Tekst może nadal wyglądać na pogrubiony dzięki syntetycznemu pogrubieniu, które sztucznie zagęszcza zwykłe glify. Gdy taki tekst wydaje się zbyt ciężki lub różni się od zamierzonego wyglądu w PDF, spróbuj ustawić [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) na `True`. Opcja ta renderuje dotknięty tekst jako bitmapę podczas eksportu PDF i może poprawić jego wygląd dla niektórych czcionek. Domyślna wartość to `False`.

Przykładowa prezentacja zawiera dwie ramki tekstowe: jedną z tekstem zwykłym i jedną z pogrubieniem zastosowanym do tej samej czcionki, która nie ma dedykowanego odcienia pogrubionego. Poniższy przykład ładuje prezentację, włącza rasteryzację nieobsługiwanych stylów czcionek i eksportuje ją do PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Poniższe podglądy pokazują wynik z wyłączoną i włączoną opcją. W tym przykładzie pogrubiony tekst ma grubsze kreski przy wyłączonej opcji. Po włączeniu opcji jego kreski są cieńsze; tekst zwykły pozostaje niezmieniony. Porównaj wyniki przed wybraniem ustawienia dla swojej prezentacji.

| Opcja wyłączona (`False`, domyślna) | Opcja włączona (`True`) |
|---|---|
| ![PDF z wyłączoną rasteryzacją nieobsługiwanego stylu czcionki](unsupported-bold-disabled.png) | ![PDF z włączoną rasteryzacją nieobsługiwanego stylu czcionki](unsupported-bold-enabled.png) |

W tym przykładzie włączenie opcji zmienia tylko pogrubiony tekst w bitmapę: nie może być zaznaczony, kopiowany ani przeszukiwany jako tekst bez OCR, a jego krawędzie wyglądają miękniej przy powiększeniu 800 %. Tekst zwykły pozostaje możliwy do wyszukiwania. Przy wyłączonej opcji oba ciągi pozostają tekstem.

Ta opcja rasteryzuje tekst sformatowany jako pogrubiony, gdy jego czcionka nie ma dedykowanego odcienia pogrubionego. [Zamiana czcionek](/slides/pl/python-net/font-substitution/) zamiast tego wybiera inną czcionkę, gdy oryginalna jest niedostępna.

## **Konwertuj wybrane slajdy w PowerPoint do PDF**

Poniższy przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numery slajdów w tej tablicy zaczynają się od 1, a prezentacja wejściowa musi zawierać co najmniej trzy slajdy.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Konwertuj PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Poniższy przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skaluje zawartość slajdu, aby pasowała, i eksportuje pojedynczy slajd do PDF.

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

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta każdego slajdu pod slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć wynik.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Standardy dostępności i zgodności dla PDF**

Aspose.Slides umożliwia użycie procedury konwersji zgodnej z [Wytycznymi dotyczącymi dostępności treści internetowych (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) . Możesz eksportować dokument PowerPoint do PDF, korzystając z dowolnego z tych standardów zgodności: **PDF/A1a**, **PDF/A1b**, i **PDF/UA**.

Ten kod w języku Python demonstruje operację konwersji PowerPoint do PDF, w której uzyskuje się wiele plików PDF opartych na różnych standardach zgodności:

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
Obsługa konwersji PDF w Aspose.Slides umożliwia konwersję PDF do najpopularniejszych formatów plików. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/) , [PDF do obrazu](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/) , [PDF do JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) , oraz [PDF do PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) . Inne operacje konwersji PDF do specjalistycznych formatów — [PDF do SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/) , [PDF do TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/) , i [PDF do XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — są również obsługiwane.
{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA Aspose.Slides traktuje złożoną grafikę, taką jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako osobna treść i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy Aspose.Slides for Python może usunąć informacje o aplikacji z PDF?**

Nie, Aspose.Slides for Python automatycznie dodaje informacje o API oraz numer wersji do wyjściowego PDF. Nie można zmodyfikować ani usunąć tych informacji.

**Jak dołączyć tylko wybrane slajdy w konwersji do PDF?**

Możesz określić indeksy slajdów, które chcesz konwertować, przekazując tablicę pozycji slajdów do metody [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) .

**Czy można zabezpieczyć PDF hasłem podczas konwersji?**

Tak, możesz ustawić hasło i określić uprawnienia dostępu za pomocą klasy [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) , przed zapisaniem prezentacji jako PDF.

**Czy Aspose.Slides obsługuje konwersję PDF do innych formatów?**

Tak, Aspose.Slides obsługuje konwersję PDF do formatów takich jak HTML, formaty obrazów (JPG, PNG), SVG, TIFF i XML.

**Jak mogę zapewnić, że mój PDF spełnia standardy dostępności?**

Ustaw właściwość [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) w [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) na standardy takie jak `PDF_A1A`, `PDF_A1B` lub `PDF_UA`, aby zapewnić zgodność z wytycznymi dostępności.

**Czy mogę uwzględnić ukryte slajdy w wyjściowym PDF?**

Tak, ustawiając właściwość [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) w [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) na `True`, ukryte slajdy zostaną uwzględnione w PDF.

**Jak dostosować jakość i rozdzielczość obrazu podczas konwersji?**

Użyj właściwości [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) i [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) w [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) , aby kontrolować jakość i rozdzielczość obrazu w powstałym PDF.

**Czy Aspose.Slides automatycznie obsługuje zamiany czcionek?**

Aspose.Slides wykrywa zamiany czcionek podczas konwersji i możesz nimi zarządzać przy użyciu właściwości `warning_callback` w `SaveOptions` (obecnie ograniczone).

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides for Python via .NET](/slides/pl/python-net/)
- [Odwołanie API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Bezpłatne konwertery online Aspose](https://products.aspose.app/slides/conversion)
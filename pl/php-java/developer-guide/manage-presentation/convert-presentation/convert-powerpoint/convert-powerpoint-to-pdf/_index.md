---
title: "Konwertuj PPT i PPTX do PDF w PHP [Zawarte Zaawansowane Funkcje]"
linktitle: "PowerPoint do PDF"
type: docs
weight: 40
url: /pl/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "Konwertuj PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w PHP przy użyciu Aspose.Slides, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) na format PDF w PHP oferuje wiele korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontroli jakości obrazu, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać substytucje czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Przy użyciu Aspose.Slides możesz konwertować prezentacje w następujących formatach na PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację na PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF używając metody [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Klasa [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/), która jest zazwyczaj używana do konwersji prezentacji na PDF.

{{% alert color="info" title="Uwaga" %}}

Aspose.Slides for PHP via Java wstawia informacje o swoim API oraz numer wersji do dokumentów wyjściowych. Na przykład, podczas konwersji prezentacji na PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, nie można nakazać Aspose.Slides zmiany lub usunięcia tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Pojedynczych slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF ściśle odwzorowują oryginalne prezentacje. Elementy i atrybuty są renderowane dokładnie w trakcie konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hiperłącza
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwertuj PowerPoint na PDF**

Standardowy proces konwersji PowerPoint‑to‑PDF używa domyślnych opcji. W tym przypadku Aspose.Slides stara się przekonwertować podaną prezentację na PDF, wykorzystując optymalne ustawienia przy maksymalnej jakości.

Poniższy przykład ładuje prezentację i zapisuje wszystkie widoczne slajdy do PDF przy użyciu domyślnych ustawień eksportu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Uwaga" %}}

Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji na PDF. Możesz przetestować ten konwerter, aby zobaczyć działanie procedury opisanej tutaj.

{{% /alert %}}

## **Konwersja PowerPoint do PDF z Opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć go hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint na PDF z Niestandardowymi Opcjami**

Korzystając z niestandardowych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metafili, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i więcej.

Poniższy przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metafilami zapisywanymi jako PNG oraz kompresją tekstu Flate.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Automatyczny Wybór Kompresji Obrazów**

Gdy prezentacja zawiera wiele fotografii lub zrzutów ekranu, zmniejszenie rozmiaru eksportowanego PDF może ułatwić jego wysyłanie lub pobieranie. Wywołaj [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) z wartością `true`, aby automatycznie wybrać najodpowiedniejszy algorytm kompresji dla każdego obrazu podczas eksportu PDF.

Poniższy przykład ładuje istniejącą prezentację, włącza automatyczny wybór kompresji obrazów i zapisuje ją jako dokument PDF. Wszystkie pozostałe ustawienia eksportu PDF pozostają na wartościach domyślnych.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Ta opcja wybiera algorytm kompresji dla każdego obrazu. Obniżenie wartości przekazywanej do [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) zmniejsza jakość obrazu JPEG, natomiast obniżenie wartości przekazywanej do [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) pozwala na downsampling obrazów do niższej rozdzielczości, co może zmniejszyć szczegółowość. Włączenie automatycznego wyboru kompresji nie obniża tych ustawień.

Wybór algorytmów kompresji obrazów wymaga dodatkowego czasu przetwarzania i pamięci. Redukcja rozmiaru zależy od obrazów w prezentacji i ustawień eksportu; stała redukcja nie jest gwarantowana dla każdej prezentacji.

### **Zachowaj Osadzone Pliki OLE jako Załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mogli uzyskać dostęp do danych skoroszytu oraz zobaczyć slajdy. Wywołaj [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) z wartością `true`, aby zachować osadzone pliki OLE jako załączniki w wynikowym PDF.

Domyślna wartość to `false`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `true` dodatkowo dołącza dane pliku. Podgląd pozostaje wizualną reprezentacją; załącznik umożliwia odbiorcom otwarcie lub zapisanie osadzonego pliku osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład ładuje prezentację, w której już znajduje się osadzony skoroszyt Excel, i eksportuje ją do PDF z dołączonym skoroszytem.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Aby sprawdzić wynik:

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki, np. Adobe Acrobat Reader.
2. Otwórz panel **Załączniki** i zlokalizuj osadzony skoroszyt.
3. Zapisz załącznik i otwórz go w Excelu, aby przejrzeć dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Uwaga" %}}

Standardy PDF/A nakładają ograniczenia na załączniki: PDF/A‑1 zabrania plików osadzonych, PDF/A‑2 zezwala wyłącznie na załączniki PDF/A, a PDF/A‑3 dopuszcza inne typy plików, w tym skoroszyty Excel. Są to wymogi standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.

{{% /alert %}}

### **Konwertuj PowerPoint na PDF z Ukrytymi Slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) klasy [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w wynikowym PDF.

Poniższy przykład eksportuje prezentację do PDF, włączając wszystkie ukryte slajdy.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Konwertuj PowerPoint na PDF Chroniony Hasłem**

Poniższy przykład eksportuje prezentację do PDF, który wymaga hasła `password` przy otwieraniu. Uprawnienia dostępu zezwalają na drukowanie, w tym drukowanie wysokiej jakości.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Wykryj Substytucje Czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) w klasie [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), umożliwiającą wykrycie substytucji czcionek podczas konwersji prezentacji do PDF.

Poniższy przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o substytucjach czcionek w konsoli. Ostrzeżenie jest wyświetlane tylko wtedy, gdy podczas eksportu zostaje podmieniona czcionka niedostępna.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Uwaga" %}}

Więcej informacji o substytucji czcionek znajdziesz w artykule [Font Substitution](/slides/pl/php-java/font-substitution/).

{{% /alert %}} 

### **Obsługa Czcionek Bez Dedykowanego Sposobu Pogrubienia**

Prezentacja może stosować pogrubienie do tekstu, nawet jeśli czcionka nie ma dedykowanego stylu pogrubionego. Tekst może być wówczas pogrubiony syntetycznie, co sztucznie zagęszcza regularne glify. Gdy taki tekst wygląda zbyt ciężko lub niezgodnie z zamierzoną aparycją w PDF, spróbuj wywołać [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) z wartością `true`. Opcja ta renderuje dotknięty tekst jako bitmapę podczas eksportu PDF i może poprawić jego wygląd w przypadku niektórych czcionek. Domyślna wartość to `false`.

Przykładowa prezentacja zawiera dwa pola tekstowe: jedno z tekstem zwykłym i drugie z pogrubionym tekstem tej samej czcionki, która nie ma dedykowanego stylu pogrubionego. Poniższy przykład ładuje prezentację, włącza rasteryzację nieobsługiwanych stylów czcionek i eksportuje ją do PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Poniższe podglądy pokazują wynik przy wyłączonej i włączonej opcji. W tym przykładzie pogrubiony tekst ma cięższe kreski przy wyłączonej opcji. Po włączeniu opcji jego kreski są lżejsze; tekst zwykły pozostaje niezmieniony. Porównaj wyniki przed podjęciem decyzji o ustawieniu dla własnej prezentacji.

| Opcja wyłączona (`false`, domyślna) | Opcja włączona (`true`) |
|---|---|
| ![PDF z wyłączoną rasteryzacją stylu czcionki nieobsługiwanej](unsupported-bold-disabled.png) | ![PDF z włączoną rasteryzacją stylu czcionki nieobsługiwanej](unsupported-bold-enabled.png) |

W tym przykładzie włączenie opcji przekształca tylko pogrubiony tekst w bitmapę: nie może być on zaznaczony, kopiowany ani przeszukiwany jako tekst bez OCR, a jego krawędzie wyglądają mięknie przy przybliżeniu 800 %. Tekst zwykły pozostaje przeszukiwalny. Przy wyłączonej opcji oba ciągi pozostają tekstem.

Ta opcja rasteryzuje tekst sformatowany jako pogrubiony, gdy czcionka nie ma dedykowanego stylu pogrubionego. [Font substitution](/slides/pl/php-java/font-substitution/) zamiast tego wybiera inną czcionkę, gdy oryginalna jest niedostępna.

## **Konwertuj Wybrane Slajdy z PowerPoint do PDF**

Poniższy przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numery slajdów w tej tablicy są numerowane od 1, a wejściowa prezentacja musi zawierać co najmniej trzy slajdy.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Konwertuj PowerPoint na PDF z Niestandardowym Rozmiarem Slajdu**

Poniższy przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skalujemy zawartość slajdu, aby pasowała, i eksportujemy pojedynczy slajd do PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Usuń pusty slajd, który został utworzony w nowej prezentacji.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Konwertuj PowerPoint na PDF w Widoku Notatek Slajdu**

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta pod każdym slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć rezultat.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Standardy Dostępności i Zgodności dla PDF**

Aspose.Slides pozwala używać procedury konwersji zgodnej ze [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz eksportować dokument PowerPoint do PDF, używając dowolnego z następujących standardów zgodności: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Poniższy kod demonstruje proces konwersji PowerPoint‑to‑PDF, który tworzy wiele plików PDF w oparciu o różne standardy zgodności:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Uwaga" %}}

Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) oraz [PDF do PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), oraz [PDF do XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — są również obsługiwane.

{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożoną grafikę, taką jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint na PDF jednorazowo?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) aby ustawić hasło i zdefiniować uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Wywołaj [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) z wartością `true` w klasie [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), aby włączyć ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides utrzymuje wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazów, używając metod takich jak [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) i [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) w klasie [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), aby zapewnić wysokiej jakości obrazy w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides pozwala eksportować PDFy zgodne z [różnymi standardami](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), w tym PDF/A1a, PDF/A1b oraz PDF/UA, zapewniając, że dokumenty spełniają wymogi dostępności i archiwizacji.

## **Dodatkowe Źródła**

- [Dokumentacja Aspose.Slides for PHP via Java](/slides/pl/php-java/)
- [Referencja API Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
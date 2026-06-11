---
title: Konwertuj PPT i PPTX do PDF w PHP [Zawarte Zaawansowane Funkcje]
linktitle: PowerPoint do PDF
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Konwertuj PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF w PHP przy użyciu Aspose.Slides, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w PHP oferuje wiele korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontroli jakości obrazu, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać zastąpienia czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności do dokumentów wyjściowych.

## **Konwersje PowerPoint do PDF**

Przy użyciu Aspose.Slides możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) i następnie zapisz prezentację jako PDF przy użyciu metody `save`. Klasa [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) udostępnia metodę `save`, która zazwyczaj służy do konwersji prezentacji do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for PHP via Java wstawia informacje o API oraz numer wersji do dokumentów wyjściowych. Na przykład, przy konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga** że nie możesz polecić Aspose.Slides, aby zmieniło lub usunęło te informacje z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Konkretnego zestawu slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF bardzo dokładnie odzwierciedlają oryginalne prezentacje. Elementy i atrybuty są renderowane precyzyjnie podczas konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hiperłącza
* Nagłówki i stopki
* Wypunktowania
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint‑do‑PDF używa domyślnych opcji. W tym przypadku Aspose.Slides stara się skonwertować podaną prezentację do PDF przy użyciu optymalnych ustawień o maksymalnej jakości.

Ten kod pokazuje, jak skonwertować prezentację (PPT, PPTX, ODP itp.) do PDF:

```php
# Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Zapisz prezentację jako PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przetestować ten konwerter, aby zobaczyć działanie procedury opisanej tutaj.

{{% /alert %}}

## **Konwertuj PowerPoint do PDF z Opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PdfOptions) — pozwalające spersonalizować wynikowy PDF, zabezpieczyć go hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z Niestandardowymi Opcjami**

Używając niestandardowych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metafili, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i wiele innych.

Poniższy przykład kodu pokazuje, jak skonwertować prezentację PowerPoint do PDF z kilkoma niestandardowymi opcjami.

```php
# Utwórz instancję klasy PdfOptions.
$pdfOptions = new PdfOptions();

# Ustaw jakość obrazów JPG.
$pdfOptions->setJpegQuality(90);

# Ustaw DPI dla obrazów.
$pdfOptions->setSufficientResolution(300);

# Ustaw zachowanie dla metaplików.
$pdfOptions->setSaveMetafilesAsPng(true);

# Ustaw poziom kompresji tekstu dla treści tekstowej.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Zdefiniuj tryb zgodności PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Zapisz prezentację jako dokument PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Konwertuj PowerPoint do PDF z Ukrytymi Slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) klasy [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PdfOptions), aby uwzględnić ukryte slajdy jako strony w wynikowym PDF.

Ten kod pokazuje, jak skonwertować prezentację PowerPoint do PDF z uwzględnieniem ukrytych slajdów:

```php
# Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Utwórz instancję klasy PdfOptions.
    $pdfOptions = new PdfOptions();

    # Dodaj ukryte slajdy.
    $pdfOptions->setShowHiddenSlides(true);

    # Zapisz prezentację jako PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Ten kod demonstruje, jak skonwertować prezentację PowerPoint do PDF zabezpieczonego hasłem, wykorzystując parametry ochrony z klasy [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/):

```php
# Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Utwórz instancję klasy PdfOptions.
    $pdfOptions = new PdfOptions();

    # Ustaw hasło PDF i uprawnienia dostępu.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Zapisz prezentację jako PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Wykrywanie Zastąpień Czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveoptions/#setWarningCallback) w ramach klasy [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/), umożliwiającą wykrycie zastąpień czcionek podczas konwersji prezentacji do PDF.

Ten kod pokazuje, jak wykrywać zastąpienia czcionek:

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// Ustaw wywołanie zwrotne ostrzeżenia w opcjach PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Zapisz prezentację jako PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

Aby uzyskać więcej informacji o zastępowaniu czcionek, zobacz artykuł [Font Substitution](/slides/pl/php-java/font-substitution/).

{{% /alert %}} 

## **Konwertuj wybrane slajdy PowerPoint do PDF**

Ten kod demonstruje, jak skonwertować wyłącznie wybrane slajdy z prezentacji PowerPoint do PDF:

```php
# Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Ustaw tablicę numerów slajdów.
    $slides = array(1, 3);

    # Zapisz prezentację jako PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Konwertuj PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Ten kod demonstruje, jak skonwertować prezentację PowerPoint do PDF przy użyciu określonego rozmiaru slajdu:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# Utwórz nową prezentację z dostosowanym rozmiarem slajdu.
$resizedPresentation = new Presentation();

try {
    # Ustaw niestandardowy rozmiar slajdu.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Sklonuj pierwszy slajd z oryginalnej prezentacji.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Zapisz przeskalowaną prezentację jako PDF z notatkami.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Ten kod demonstruje, jak skonwertować prezentację PowerPoint do PDF zawierającego notatki:

```php
# Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Skonfiguruj opcje PDF z układem notatek.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Zapisz prezentację jako PDF z notatkami.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Standardy dostępności i zgodności PDF**

Aspose.Slides umożliwia użycie procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, stosując dowolny z następujących standardów zgodności: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Ten kod demonstruje proces konwersji PowerPoint‑do‑PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/pl/php-java/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/pl/php-java/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/pl/php-java/conversion/pdf-to-jpg/) i [PDF do PNG](https://products.aspose.com/slides/pl/php-java/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/pl/php-java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/pl/php-java/conversion/pdf-to-tiff/) oraz [PDF do XML](https://products.aspose.com/slides/pl/php-java/conversion/pdf-to-xml/) — są również wspierane.

{{% /alert %}}

> **Uwaga:** Przy eksporcie do PDF/UA Aspose.Slides traktuje złożoną grafikę, taką jak SmartArt, wykresy i formuły, jako pojedynczą figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany jedynie dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy istnieje możliwość zabezpieczenia konwertowanego PDF hasłem?**

Oczywiście. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/), aby ustawić hasło i zdefiniować uprawnienia dostępu podczas procesu konwersji.

**Jak włączyć ukryte slajdy w PDF?**

Użyj metody `setShowHiddenSlides` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides utrzymuje wysoką jakość obrazu w PDF?**

Tak, możesz kontrolować jakość obrazu, korzystając z metod takich jak `setJpegQuality` i `setSufficientResolution` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/), aby zapewnić wysokiej jakości obrazy w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides pozwala eksportować PDF spełniające różne standardy, w tym PDF/A1a, PDF/A1b oraz PDF/UA, zapewniając, że twoje dokumenty spełniają wymogi dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides for PHP via Java](/slides/pl/php-java/)
- [Reference API Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/pl/php-java/)
- [Darmowe konwertery online Aspose](https://products.aspose.app/slides/pl/conversion)
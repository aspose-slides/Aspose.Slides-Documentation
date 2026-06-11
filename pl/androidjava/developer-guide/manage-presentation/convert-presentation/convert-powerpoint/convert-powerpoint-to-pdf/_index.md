---
title: Konwertuj PPT i PPTX do PDF na Androidzie [Zawarte Zaawansowane Funkcje]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /pl/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w Javie przy użyciu Aspose.Slides dla Androida, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) na format PDF w systemie Android oferuje wiele korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten poradnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolujących jakość obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podmiany czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i następnie zapisz prezentację jako PDF przy użyciu metody `save`. Klasa [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) udostępnia metodę `save`, która zazwyczaj służy do konwersji prezentacji do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Android via Java wstawia informacje o API oraz numer wersji do dokumentów wyjściowych. Na przykład, podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, że nie można nakazać Aspose.Slides zmienić ani usunąć tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Określonych slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF bardzo dokładnie odzwierciedlają oryginalne prezentacje. Elementy i atrybuty są renderowane dokładnie w trakcie konwersji, w tym:

* Obrazy
* Ramki tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hyperlinki
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa domyślnych opcji. W tym przypadku Aspose.Slides próbuje przekonwertować dostarczoną prezentację do PDF, wykorzystując optymalne ustawienia przy maksymalnym poziomie jakości.

Ten kod pokazuje, jak przekonwertować prezentację (PPT, PPTX, ODP itp.) do PDF:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Zapisz prezentację jako PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji na PDF. Możesz przeprowadzić test przy użyciu tego konwertera, aby zobaczyć działanie opisanej tutaj procedury.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/), które pozwalają dostosować powstały PDF, zabezpieczyć PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z niestandardowymi opcjami**

Korzystając z niestandardowych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, sprecyzować sposób obsługi metaplików, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i wiele innych.

Poniższy przykład kodu pokazuje, jak przekonwertować prezentację PowerPoint do PDF z kilkoma niestandardowymi opcjami.

```java
// Utwórz instancję klasy PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Ustaw jakość obrazów JPG.
pdfOptions.setJpegQuality((byte)90);

// Ustaw DPI dla obrazów.
pdfOptions.setSufficientResolution(300);

/// Ustaw zachowanie dla metaplików.
pdfOptions.setSaveMetafilesAsPng(true);

// Ustaw poziom kompresji tekstu dla treści tekstowej.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Zdefiniuj tryb zgodności PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Zapisz prezentację jako dokument PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) klasy [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/) , aby uwzględnić ukryte slajdy jako strony w powstałym PDF.

Ten kod pokazuje, jak przekonwertować prezentację PowerPoint do PDF z uwzględnieniem ukrytych slajdów:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Utwórz instancję klasy PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Dodaj ukryte slajdy.
    pdfOptions.setShowHiddenSlides(true);

    // Zapisz prezentację jako PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konwertuj PowerPoint do PDF chronionego hasłem**

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do PDF chronionego hasłem, wykorzystując parametry ochrony klasy [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/) :

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Utwórz instancję klasy PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Ustaw hasło PDF i uprawnienia dostępu.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Zapisz prezentację jako PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Wykrywanie podmian czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) klasy [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/) , umożliwiającą wykrycie podmian czcionek podczas procesu konwersji prezentacji do PDF.

Ten kod pokazuje, jak wykrywać podmiany czcionek:

```java
public static void main(String[] args) {
    // Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Ustaw funkcję zwrotną ostrzeżenia w opcjach PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Zapisz prezentację jako PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementacja funkcji zwrotnej ostrzeżenia.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 
Aby uzyskać więcej informacji na temat podmiany czcionek, zobacz artykuł [Font Substitution](/slides/pl/androidjava/font-substitution/).
{{% /alert %}} 

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Ten kod demonstruje, jak przekonwertować tylko wybrane slajdy z prezentacji PowerPoint do PDF:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Ustaw tablicę numerów slajdów.
    int[] slides = { 1, 3 };

    // Zapisz prezentację jako PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Konwertuj PowerPoint do PDF o niestandardowym rozmiarze slajdu**

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do PDF z określonym rozmiarem slajdu:

```java
float slideWidth = 612;
float slideHeight = 792;

// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Utwórz nową prezentację z dostosowanym rozmiarem slajdu.
Presentation resizedPresentation = new Presentation();

try {
    // Ustaw niestandardowy rozmiar slajdu.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Sklonuj pierwszy slajd z oryginalnej prezentacji.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Zapisz przeskalowaną prezentację jako PDF z notatkami.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do PDF zawierającego notatki:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Skonfiguruj opcje PDF z układem notatek.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Zapisz prezentację jako PDF z notatkami.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Standardy dostępności i zgodności dla PDF**

Aspose.Slides umożliwia użycie procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, stosując dowolny z tych standardów zgodności: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Ten kod demonstruje proces konwersji PowerPoint do PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF to HTML](https://products.aspose.com/slides/pl/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/pl/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/pl/java/conversion/pdf-to-jpg/), oraz [PDF to PNG](https://products.aspose.com/slides/pl/java/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF to SVG](https://products.aspose.com/slides/pl/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/pl/java/conversion/pdf-to-tiff/), i [PDF to XML](https://products.aspose.com/slides/pl/java/conversion/pdf-to-xml/) — również są wspierane.
{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna treść i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz przechodzić po swoich plikach i programowo stosować proces konwersji.

**Czy istnieje możliwość zabezpieczenia konwertowanego PDF hasłem?**

Oczywiście. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak włączyć ukryte slajdy do PDF?**

Użyj metody `setShowHiddenSlides` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy w powstałym PDF.

**Czy Aspose.Slides może utrzymać wysoką jakość obrazu w PDF?**

Tak, możesz kontrolować jakość obrazu, używając metod takich jak `setJpegQuality` i `setSufficientResolution` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/), aby zapewnić wysoką jakość obrazów w swoim PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides umożliwia eksport PDF zgodnych z różnymi standardami, w tym PDF/A1a, PDF/A1b oraz PDF/UA, zapewniając, że dokumenty spełniają wymagania dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [*Dokumentacja Aspose.Slides dla Android via Java*](/slides/pl/androidjava/)
- [*Referencja API Aspose.Slides dla Android via Java*](https://reference.aspose.com/slides/pl/androidjava/)
- [*Darmowe konwertery online Aspose*](https://products.aspose.app/slides/pl/conversion)
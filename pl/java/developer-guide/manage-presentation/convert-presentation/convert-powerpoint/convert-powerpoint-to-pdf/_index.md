---
title: Konwertuj PPT i PPTX do PDF w Javie [Zawarte zaawansowane funkcje]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /pl/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "Konwertuj PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w Javie przy użyciu Aspose.Slides, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwersja prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w języku Java oferuje wiele korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontroli jakości obrazu, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać zamiany czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wynikowych.

## **Konwersje PowerPoint na PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach na PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i następnie zapisz prezentację jako PDF przy użyciu metody `save`. Klasa [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) udostępnia metodę `save`, która zazwyczaj jest używana do konwersji prezentacji na PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java wstawia informacje o swojej API oraz numer wersji do dokumentów wyjściowych. Na przykład, podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" i pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, że nie można nakazać Aspose.Slides zmienić lub usunąć tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides pozwala na konwersję:

* Całych prezentacji do PDF
* Określonych slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że wynikowe pliki PDF są bardzo zbliżone do oryginalnych prezentacji. Elementy i atrybuty są renderowane dokładnie w procesie konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hyperlinki
* Nagłówki i stopki
* Wypunktowania
* Tabele

## **Konwertuj PowerPoint na PDF**

Standardowy proces konwersji PowerPoint‑do‑PDF używa domyślnych opcji. W tym przypadku Aspose.Slides stara się skonwertować podaną prezentację do PDF, stosując optymalne ustawienia przy maksymalnej jakości.

Ten kod pokazuje, jak skonwertować prezentację (PPT, PPTX, ODP itp.) do PDF:

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

Aspose oferuje darmowy internetowy [**konwerter PowerPoint na PDF**](https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przeprowadzić test z tym konwerterem, aby zobaczyć działanie procedury opisanej tutaj.

{{% /alert %}}

## **Konwertuj PowerPoint na PDF z opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć go hasłem lub określić sposób przebiegu procesu konwersji.

### **Konwertuj PowerPoint na PDF z własnymi opcjami**

Używając własnych opcji konwersji, możesz określić preferowane ustawienia jakości rastrowych obrazów, sposób obsługi metafili, poziom kompresji tekstu, DPI dla obrazów i wiele innych.

Poniższy przykład kodu demonstruje, jak skonwertować prezentację PowerPoint do PDF z kilkoma własnymi opcjami.

```java
// Utwórz instancję klasy PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Ustaw jakość obrazów JPG.
pdfOptions.setJpegQuality((byte)90);

// Ustaw DPI dla obrazów.
pdfOptions.setSufficientResolution(300);

// Ustaw zachowanie metafili.
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

### **Konwertuj PowerPoint na PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) klasy [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w wynikowym PDF.

Ten kod pokazuje, jak skonwertować prezentację PowerPoint do PDF z uwzględnionymi ukrytymi slajdami:

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

### **Konwertuj PowerPoint na PDF zabezpieczony hasłem**

Ten kod demonstruje, jak skonwertować prezentację PowerPoint do PDF zabezpieczonego hasłem przy użyciu parametrów ochrony klasy [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/):

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Utwórz instancję klasy PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Ustaw hasło PDF oraz uprawnienia dostępu.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Zapisz prezentację jako PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Wykrywanie zamiany czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) w klasie [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/), umożliwiającą wykrycie zamiany czcionek podczas konwersji prezentacji do PDF.

Ten kod pokazuje, jak wykrywać zamiany czcionek:

```java
public static void main(String[] args) {
    // Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Ustaw wywołanie zwrotne ostrzeżeń w opcjach PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Zapisz prezentację jako PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// Implementacja wywołania zwrotnego ostrzeżeń.
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

Aby uzyskać więcej informacji o odbieraniu wywołań zwrotnych dotyczących zamiany czcionek w trakcie renderowania, zobacz [Getting Warning Callbacks for Fonts Substitution](/slides/pl/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Więcej informacji o zamianie czcionek znajdziesz w artykule [Font Substitution](/slides/pl/java/font-substitution/).

{{% /alert %}} 

## **Konwertuj wybrane slajdy w PowerPoint na PDF**

Ten kod demonstruje, jak skonwertować tylko określone slajdy z prezentacji PowerPoint do PDF:

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

## **Konwertuj PowerPoint na PDF z własnym rozmiarem slajdu**

Ten kod demonstruje, jak skonwertować prezentację PowerPoint do PDF z określonym rozmiarem slajdu:

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

    // Zapisz przeskalowaną prezentację do PDF z notatkami.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konwertuj PowerPoint na PDF w widoku notatek slajdu**

Ten kod demonstruje, jak skonwertować prezentację PowerPoint do PDF zawierającego notatki:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Skonfiguruj opcje PDF z układem notatek.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Zapisz prezentację do PDF z notatkami.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Standardy dostępności i zgodności dla PDF**

Aspose.Slides umożliwia użycie procedury konwersji spełniającej [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, stosując którekolwiek z następujących standardów zgodności: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Ten kod demonstruje proces konwersji PowerPoint‑do‑PDF, który tworzy wiele plików PDF w oparciu o różne standardy zgodności:

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

Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF to HTML](https://products.aspose.com/slides/pl/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/pl/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/pl/java/conversion/pdf-to-jpg/), oraz [PDF to PNG](https://products.aspose.com/slides/pl/java/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF to SVG](https://products.aspose.com/slides/pl/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/pl/java/conversion/pdf-to-tiff/), oraz [PDF to XML](https://products.aspose.com/slides/pl/java/conversion/pdf-to-xml/) — również są wspierane.

{{% /alert %}}

> **Uwaga:** Przy eksporcie do PDF/UA Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżki nie są zachowywane jako odrębna treść i mogą zostać oznaczone jako artefakty; tekst alternatywny jest dostarczany wyłącznie dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint na PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Zdecydowanie. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Użyj metody `setShowHiddenSlides` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides zapewnia wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazów, używając metod takich jak `setJpegQuality` oraz `setSufficientResolution` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/), aby zapewnić wysoką jakość obrazów w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides umożliwia eksport PDF‑ów zgodnych z [różnymi standardami](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfcompliance/), w tym PDF/A1a, PDF/A1b oraz PDF/UA, zapewniając spełnienie wymogów dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Aspose.Slides for Java Documentation](/slides/pl/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/pl/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/pl/conversion)
---
title: Konwertuj PPT i PPTX do PDF na Androidzie [Zawarte zaawansowane funkcje]
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
description: "Konwertuj PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF w Javie przy użyciu Aspose.Slides for Android, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w systemie Android oferuje wiele korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontroli jakości obrazu, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać substytucje czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Korzystając z Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i następnie zapisz prezentację jako PDF używając metody `save`. Klasa [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) udostępnia metodę `save`, która jest zwykle używana do konwersji prezentacji do PDF.

{{% alert title="UWAGA" color="warning" %}} 
Aspose.Slides for Android via Java wstawia informacje o API oraz numer wersji do dokumentów wyjściowych. Na przykład, podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, że nie możesz nakazać Aspose.Slides zmienić lub usunąć tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całe prezentacje do PDF
* Wybrane slajdy z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że otrzymane pliki PDF ściśle odpowiadają oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Poli tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitu
* Hiperdłącza
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa domyślnych opcji. W tym przypadku Aspose.Slides próbuje przekonwertować podaną prezentację do PDF, używając optymalnych ustawień przy maksymalnych poziomach jakości.

Ten kod pokazuje, jak przekonwertować prezentację (PPT, PPTX, ODP itd.) do PDF:

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Zapisz prezentację jako PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 
Aspose oferuje bezpłatny internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przeprowadzić test z tym konwerterem, aby zobaczyć działanie opisanego tutaj procesu.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia własne opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z własnymi opcjami**

Używając własnych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metaplików, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i wiele innych.

Poniższy przykład kodu pokazuje, jak przekonwertować prezentację PowerPoint do PDF z kilkoma własnymi opcjami.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Ustaw jakość obrazów JPG.
pdfOptions.setJpegQuality((byte)90);

// Ustaw DPI dla obrazów.
pdfOptions.setSufficientResolution(300);

/// Ustaw zachowanie dla metaplików.
pdfOptions.setSaveMetafilesAsPng(true);

// Ustaw poziom kompresji tekstu dla treści tekstowych.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Zdefiniuj tryb zgodności PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Zapisz prezentację jako dokument PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) klasy [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/), aby włączyć ukryte slajdy jako strony w wynikowym PDF.

Ten kod pokazuje, jak przekonwertować prezentację PowerPoint do PDF z uwzględnieniem ukrytych slajdów:

```java
import com.aspose.slides.*;

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

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do PDF zabezpieczonego hasłem, używając parametrów ochrony z klasy [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/):

```java
import com.aspose.slides.*;

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

### **Wykryj substytucje czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) w ramach klasy [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/), umożliwiającą wykrywanie substytucji czcionek podczas procesu konwersji prezentacji do PDF.

Ten kod pokazuje, jak wykrywać substytucje czcionek:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Ustaw funkcję zwrotną ostrzeżeń w opcjach PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Zapisz prezentację jako PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementacja funkcji zwrotnej ostrzeżeń.
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

{{% alert color="info" %}} 
Więcej informacji na temat substytucji czcionek znajdziesz w artykule [Font Substitution](/slides/pl/androidjava/font-substitution/).
{{% /alert %}}

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Ten kod demonstruje, jak przekonwertować wyłącznie wybrane slajdy z prezentacji PowerPoint do PDF:

```java
import com.aspose.slides.*;

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

## **Konwertuj PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do PDF z określonym rozmiarem slajdu:

```java
import com.aspose.slides.*;

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

    // Usuń pusty slajd, z którym została utworzona nowa prezentacja.
    resizedPresentation.getSlides().removeAt(1);

    // Zapisz zmodyfikowaną prezentację jako PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Ten kod demonstruje, jak przekonwertować prezentację PowerPoint do PDF, który zawiera notatki:

```java
import com.aspose.slides.*;

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

## **Standardy dostępności i zgodności PDF**

Aspose.Slides umożliwia zastosowanie procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, używając dowolnego z tych standardów zgodności: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Poniższy kod demonstruje proces konwersji PowerPoint do PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

```java
import com.aspose.slides.*;

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

{{% alert title="Uwaga" color="warning" %}} 
Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/pl/java/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/pl/java/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/pl/java/conversion/pdf-to-jpg/), i [PDF do PNG](https://products.aspose.com/slides/pl/java/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/pl/java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/pl/java/conversion/pdf-to-tiff/), oraz [PDF do XML](https://products.aspose.com/slides/pl/java/conversion/pdf-to-xml/) — są również wspierane.
{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożoną grafikę, taką jak SmartArt, wykresy i formuły, jako pojedynczą figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

### Czy mogę konwertować wiele plików PowerPoint do PDF jednorazowo?

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

### Czy można zabezpieczyć konwertowany PDF hasłem?

Oczywiście. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/), aby ustawić hasło i zdefiniować uprawnienia dostępu podczas procesu konwersji.

### Jak włączyć ukryte slajdy w PDF?

Użyj metody `setShowHiddenSlides` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy w wynikowym PDF.

### Czy Aspose.Slides może utrzymać wysoką jakość obrazu w PDF?

Tak, możesz kontrolować jakość obrazu, używając metod takich jak `setJpegQuality` i `setSufficientResolution` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/), aby zapewnić wysokiej jakości obrazy w swoim PDF.

### Czy Aspose.Slides obsługuje standardy zgodności PDF/A?

Tak, Aspose.Slides pozwala eksportować PDFy zgodne z różnymi standardami, w tym PDF/A1a, PDF/A1b oraz PDF/UA, zapewniając, że Twoje dokumenty spełniają wymagania dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides dla Android via Java](/slides/pl/androidjava/)
- [Referencja API Aspose.Slides dla Android via Java](https://reference.aspose.com/slides/pl/androidjava/)
- [Bezpłatne konwertery online Aspose](https://products.aspose.app/slides/pl/conversion)
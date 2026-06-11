---
title: Konwertuj PPT i PPTX do PDF w JavaScript [Zaawansowane funkcje w zestawie]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /pl/nodejs-java/convert-powerpoint-to-pdf/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF przy użyciu Aspose.Slides dla Node.js, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint i OpenDocument (PPT, PPTX, ODP itp.) do formatu PDF w JavaScript oferuje kilka zalet, w tym kompatybilność na różnych urządzeniach oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontroli jakości obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać zamiany czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Za pomocą Aspose.Slides możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF przy użyciu metody `save`. Klasa [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) udostępnia metodę `save`, która zwykle służy do konwertowania prezentacji do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides dla Node.js via Java wstawia informacje o API i numer wersji do dokumentów wyjściowych. Na przykład podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, że nie można nakazać Aspose.Slides zmienić lub usunąć tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Określonych slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF ściśle odzwierciedlają oryginalne prezentacje. Elementy i atrybuty są renderowane dokładnie w procesie konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatyzacja tekstu
* Formatyzacja akapitu
* Hyperlinki
* Nagłówki i stopki
* Punktory
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint‑do‑PDF używa domyślnych opcji. W tym przypadku Aspose.Slides stara się przekonwertować podaną prezentację do PDF, korzystając z ustawień optymalnych przy maksymalnych poziomach jakości.

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Zapisz prezentację jako PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose oferuje bezpłatny internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przeprowadzić test przy użyciu tego konwertera, aby zobaczyć działanie opisanej tutaj procedury.

{{% /alert %}}

## **Konwertuj PowerPoint do PDF z Opcjami**

Aspose.Slides udostępnia własne opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z własnymi opcjami**

Korzystając z własnych opcji konwersji, możesz określić preferowane ustawienia jakości rastrów, zdefiniować sposób obsługi metazestawów, ustawić poziom kompresji tekstu, skonfigurować DPI obrazów i wiele innych.

Poniższy przykład kodu pokazuje, jak przekonwertować prezentację PowerPoint do PDF z kilkoma własnymi opcjami.

```js
// Utwórz instancję klasy PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Ustaw jakość obrazów JPG.
pdfOptions.setJpegQuality(java.newByte(90));

// Ustaw DPI dla obrazów.
pdfOptions.setSufficientResolution(300);

// Ustaw zachowanie dla metafile.
pdfOptions.setSaveMetafilesAsPng(true);

// Ustaw poziom kompresji tekstu dla treści tekstowej.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Zdefiniuj tryb zgodności PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Zapisz prezentację jako dokument PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) klasy [PdfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PdfOptions), aby uwzględnić ukryte slajdy jako strony w wynikowym PDF.

Ten kod JavaScript pokazuje, jak przekonwertować prezentację PowerPoint do PDF z uwzględnionymi ukrytymi slajdami:

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Utwórz instancję klasy PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Dodaj ukryte slajdy.
    pdfOptions.setShowHiddenSlides(true);

    // Zapisz prezentację jako PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konwertuj PowerPoint do PDF chronionego hasłem**

Ten kod JavaScript demonstruje, jak przekonwertować prezentację PowerPoint do PDF chronionego hasłem przy użyciu parametrów ochrony z klasy [PdfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PdfOptions):

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Utwórz instancję klasy PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Ustaw hasło PDF oraz uprawnienia dostępu.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Zapisz prezentację jako PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Wykrywanie zamian czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) w klasie [PdfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PdfOptions), umożliwiającą wykrycie zamian czcionek podczas procesu konwersji prezentacji do PDF.

Ten kod JavaScript pokazuje, jak wykrywać zamiany czcionek:

```js
// Ustaw funkcję zwrotną ostrzeżeń w opcjach PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Zapisz prezentację jako PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

Więcej informacji o zamianie czcionek znajdziesz w artykule [Font Substitution](/slides/pl/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Konwertuj wybrane slajdy w PowerPoint do PDF**

Ten kod JavaScript demonstruje, jak przekonwertować tylko wybrane slajdy z prezentacji PowerPoint do PDF:

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Ustaw tablicę numerów slajdów.
    let slides = java.newArray("int", [1, 3]);

    // Zapisz prezentację jako PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Konwertuj PowerPoint do PDF z własnym rozmiarem slajdu**

Ten kod JavaScript demonstruje, jak przekonwertować prezentację PowerPoint do PDF z określonym rozmiarem slajdu:

```js
const slideWidth = 612;
const slideHeight = 792;

// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Utwórz nową prezentację z dostosowanym rozmiarem slajdu.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Ustaw własny rozmiar slajdu.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Sklonuj pierwszy slajd z oryginalnej prezentacji.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Zapisz zmienioną prezentację jako PDF z notatkami.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Ten kod JavaScript demonstruje, jak przekonwertować prezentację PowerPoint do PDF zawierającego notatki:

```js
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Skonfiguruj opcje PDF z układem notatek.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Zapisz prezentację jako PDF z notatkami.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Dostępność i standardy zgodności dla PDF**

Aspose.Slides umożliwia użycie procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, stosując dowolny z następujących standardów zgodności: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Ten kod JavaScript demonstruje proces konwersji PowerPoint‑do‑PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

```js
let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/pl/nodejs-java/conversion/pdf-to-html/), [PDF do JPG](https://products.aspose.com/slides/pl/nodejs-java/conversion/pdf-to-jpg/), oraz [PDF do PNG](https://products.aspose.com/slides/pl/nodejs-java/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/pl/nodejs-java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/pl/nodejs-java/conversion/pdf-to-tiff/) — również są obsługiwane.

{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżki nie są zachowywane jako odrębna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany wyłącznie dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Oczywiście. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PdfOptions), aby ustawić hasło i zdefiniować uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Użyj metody `setShowHiddenSlides` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PdfOptions), aby włączyć ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides zapewnia wysoką jakość obrazu w PDF?**

Tak, możesz kontrolować jakość obrazów, używając metod takich jak `setJpegQuality` oraz `setSufficientResolution` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PdfOptions), aby zapewnić wysokiej jakości obrazy w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides pozwala eksportować PDF‑y zgodne z różnymi standardami, w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając spełnienie wymagań dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Aspose.Slides for Node.js via Java Documentation](/slides/pl/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/pl/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/pl/conversion)
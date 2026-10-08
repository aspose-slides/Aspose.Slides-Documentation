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
- załącznik
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF przy użyciu Aspose.Slides dla Node.js, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwersja prezentacji PowerPoint i OpenDocument (PPT, PPTX, ODP itp.) do formatu PDF w JavaScript oferuje wiele korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolujących jakość obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF przy użyciu metody [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Klasa [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/), która jest typowo używana do konwersji prezentacji do PDF.

{{% alert color="info" title="Uwaga" %}}

Aspose.Slides for Node.js via Java wstawia informacje o API i numer wersji do dokumentów wyjściowych. Na przykład podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, że nie możesz nakazać Aspose.Slides zmiany lub usunięcia tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Konkretnego slajdu z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF są w dużej mierze zgodne z oryginalnymi prezentacjami. Elementy i atrybuty są renderowane dokładnie w trakcie konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hiperłącza
* Nagłówki i stopki
* Wypunktowania
* Tabele

## **Konwersja PowerPoint do PDF**

Standardowy proces konwersji PowerPoint‑do‑PDF używa domyślnych opcji. W tym przypadku Aspose.Slides próbuje przekonwertować podaną prezentację do PDF przy użyciu optymalnych ustawień o maksymalnej jakości.

Poniższy przykład ładuje prezentację i zapisuje wszystkie widoczne slajdy do PDF przy użyciu domyślnych ustawień eksportu.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Uwaga" %}}

Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przetestować ten konwerter, aby zobaczyć działanie opisanej tutaj procedury.

{{% /alert %}}

## **Konwersja PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) — które pozwalają dostosować powstały PDF, zabezpieczyć go hasłem lub określić, jak proces konwersji ma przebiegać.

### **Konwersja PowerPoint do PDF z własnymi opcjami**

Używając własnych opcji konwersji, możesz określić preferowane ustawienie jakości dla rastrowych obrazów, określić sposób obsługi metaplików, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i nie tylko.

Poniższy przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metaplikami zapisywanymi jako PNG oraz kompresją tekstu Flate.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Zachowanie osadzonych plików OLE jako załączników PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz do slajdów. Wywołaj [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) z wartością `true`, aby zachować osadzone pliki OLE jako załączniki w wygenerowanym PDF.

Domyślna wartość to `false`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale jego osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `true` dodatkowo dołącza dane pliku. Podgląd pozostaje wizualną reprezentacją; załącznik pozwala odbiorcom otworzyć lub zapisać osadzony plik osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład ładuje prezentację, która już zawiera osadzony skoroszyt Excel, i eksportuje ją do PDF z dołączonym skoroszytem.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Aby sprawdzić wynik:

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki, np. Adobe Acrobat Reader.
2. Otwórz panel **Attachments** i znajdź osadzony skoroszyt.
3. Zapisz załącznik i otwórz go w Excelu, aby przejrzeć dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Uwaga" %}}

Standardy PDF/A nakładają ograniczenia na załączniki: PDF/A‑1 zakazuje osadzonych plików, PDF/A‑2 zezwala tylko na załączniki PDF/A, a PDF/A‑3 pozwala na inne typy plików, w tym skoroszyty Excel. Są to wymagania standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.

{{% /alert %}}

### **Konwersja PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) z klasy [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), aby włączyć ukryte slajdy jako strony w powstałym PDF.

Poniższy przykład eksportuje prezentację do PDF, włączając wszelkie ukryte slajdy.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konwersja PowerPoint do PDF chronionego hasłem**

Poniższy przykład eksportuje prezentację do PDF, który wymaga hasła `password` do otwarcia. Uprawnienia dostępu pozwalają na drukowanie, w tym drukowanie wysokiej jakości.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Wykrywanie podstawień czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) w klasie [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), umożliwiającą wykrycie podstawień czcionek podczas konwersji prezentacji do PDF.

Poniższy przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o podstawieniach czcionek w konsoli. Ostrzeżenie jest wypisywane tylko wtedy, gdy nieobecna czcionka zostanie zastąpiona podczas eksportu.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Uwaga" %}}

Po więcej informacji na temat podstawień czcionek zobacz artykuł [Font Substitution](/slides/pl/nodejs-java/font-substitution/).

{{% /alert %}} 

### **Obsługa czcionek bez dedykowanego stylu pogrubionego**

Prezentacja może stosować pogrubienie tekstu, nawet gdy czcionka nie posiada dedykowanego stylu pogrubionego. Tekst może nadal wyglądać pogrubienie dzięki syntetycznemu pogrubianiu, które sztucznie zagęszcza zwykłe glify. Gdy taki tekst wygląda zbyt ciężko lub inaczej niż zamierzono w PDF, spróbuj wywołać [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) z wartością `true`. Opcja ta renderuje dotknięty tekst jako bitmapę podczas eksportu PDF i może poprawić jego wygląd dla niektórych czcionek. Domyślna wartość to `false`.

Przykładowa prezentacja zawiera dwa pola tekstowe: jedno z normalnym tekstem i drugie z pogrubionym formatowaniem tej samej czcionki, która nie ma dedykowanego stylu pogrubionego. Poniższy przykład ładuje prezentację, włącza rasteryzację nieobsługiwanych stylów czcionek i eksportuje ją do PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Poniższe podglądy przedstawiają wynik z wyłączoną i włączoną opcją. W tym przykładzie tekst pogrubiony ma cięższe kreski przy wyłączonej opcji. Po włączeniu opcji kreski są lżejsze; tekst normalny pozostaje niezmieniony. Porównaj wyniki przed podjęciem decyzji o ustawieniu dla swojej prezentacji.

| Opcja wyłączona (`false`, domyślnie) | Opcja włączona (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

W tym przykładzie włączenie opcji powoduje rasteryzację jedynie pogrubionego tekstu: nie może być zaznaczony, kopiowany ani przeszukiwany jako tekst bez OCR, a jego krawędzie są miększe przy 800 % powiększeniu. Normalny tekst pozostaje przeszukiwalny. Przy wyłączonej opcji oba ciągi pozostają tekstem.

Opcja ta rasteryzuje tekst sformatowany jako pogrubiony, gdy jego czcionka nie ma dedykowanego stylu pogrubionego. [Font substitution](/slides/pl/nodejs-java/font-substitution/) zamiast tego wybiera inną czcionkę, gdy oryginalna jest niedostępna.

## **Konwersja wybranych slajdów z PowerPoint do PDF**

Poniższy przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numery slajdów w tej tablicy są numerowane od 1, a wejściowa prezentacja musi zawierać co najmniej trzy slajdy.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Konwersja PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Poniższy przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skaluje zawartość slajdu, aby pasowała, i eksportuje pojedynczy slajd do PDF.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Usuń pusty slajd, który został utworzony w nowej prezentacji.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konwersja PowerPoint do PDF w widoku notatek slajdu**

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta pod każdym slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć rezultat.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Dostępność i standardy zgodności PDF**

Aspose.Slides pozwala używać procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz eksportować dokument PowerPoint do PDF, stosując dowolny z tych standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Poniższy kod demonstruje proces konwersji PowerPoint‑do‑PDF, który generuje wiele plików PDF na podstawie różnych standardów zgodności:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Uwaga" %}}

Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonywać konwersje [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) oraz [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — także są wspierane.

{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożoną grafikę taką jak SmartArt, wykresy i formuły jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna treść i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo stosować proces konwersji.

**Czy możliwe jest zabezpieczenie skonwertowanego PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), aby ustawić hasło i zdefiniować uprawnienia dostępu podczas procesu konwersji.

**Jak włączyć ukryte slajdy w PDF?**

Wywołaj [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) z wartością `true` w klasie [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy w powstałym PDF.

**Czy Aspose.Slides potrafi zachować wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazów, używając metod takich jak [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) i [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) w klasie [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), aby zapewnić wysoką jakość obrazów w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides umożliwia eksport PDF zgodnych z [różnymi standardami](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), w tym PDF/A1a, PDF/A1b oraz PDF/UA, zapewniając spełnienie wymagań dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Aspose.Slides for Node.js via Java Documentation](/slides/pl/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
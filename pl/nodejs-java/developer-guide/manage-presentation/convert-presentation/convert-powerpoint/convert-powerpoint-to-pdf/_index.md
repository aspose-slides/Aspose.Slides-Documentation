---
title: Konwertuj PPT i PPTX do PDF w JavaScript [Zawarte zaawansowane funkcje]
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
description: "Konwertuj PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF przy użyciu Aspose.Slides for Node.js, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint i OpenDocument (PPT, PPTX, ODP itp.) do formatu PDF w JavaScript oferuje kilka zalet, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania Twojej prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolujących jakość obrazów, włączać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać zastąpienia czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Prezentacja](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF używając metody [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Klasa [Prezentacja](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/), która jest zazwyczaj używana do konwersji prezentacji do PDF.

{{% alert color="info" title="Uwaga" %}}
Aspose.Slides for Node.js via Java wstawia informacje o API i numer wersji do dokumentów wyjściowych. Na przykład, podczas konwertowania prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, że nie można nakazać Aspose.Slides zmienić lub usunąć tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całe prezentacje do PDF
* Określone slajdy z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF ściśle odpowiadają oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie w trakcie konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitu
* Hiperłącza
* Nagłówki i stopki
* Punktory
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa domyślnych opcji. W tym przypadku Aspose.Slides stara się skonwertować podaną prezentację do PDF, stosując optymalne ustawienia przy maksymalnym poziomie jakości.

Następujący przykład ładuje prezentację i zapisuje wszystkie widoczne slajdy do PDF, używając domyślnych ustawień eksportu.

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
Aspose oferuje bezpłatny internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przeprowadzić test z tym konwerterem, aby zobaczyć działanie opisanej tutaj procedury.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z własnymi opcjami**

Używając własnych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metaplików, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i wiele więcej.

Następujący przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metaplikami zapisywanymi jako PNG oraz kompresją tekstu Flate.

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

### **Automatyczny wybór kompresji obrazu**

Gdy prezentacja zawiera wiele fotografii lub zrzutów ekranu, zmniejszenie rozmiaru eksportowanego PDF może ułatwić wysyłanie e‑mail lub pobieranie. Wywołaj [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) z wartością `true`, aby automatycznie wybrać najbardziej odpowiedni algorytm kompresji dla każdego obrazu podczas eksportu do PDF.

Następujący przykład ładuje istniejącą prezentację, włącza automatyczny wybór kompresji obrazów i zapisuje ją jako dokument PDF. Wszystkie pozostałe ustawienia eksportu PDF zachowują wartości domyślne.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Ta opcja wybiera algorytm kompresji dla każdego obrazu. Obniżenie wartości przekazywanej do [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) powoduje obniżenie jakości obrazu JPEG, natomiast obniżenie wartości przekazywanej do [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) pozwala na zmniejszenie rozdzielczości obrazów, co może zmniejszyć szczegóły. Włączenie automatycznego wyboru kompresji nie obniża tych ustawień.

Wybór algorytmów kompresji obrazów wymaga dodatkowego czasu przetwarzania i pamięci. Redukcja rozmiaru zależy od obrazów w prezentacji i ustawień eksportu; stała redukcja nie jest gwarantowana dla każdej prezentacji.

### **Zachowaj osadzone pliki OLE jako załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz mogli przeglądać slajdy. Wywołaj [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) z wartością `true`, aby zachować osadzone pliki OLE jako załączniki w wynikowym PDF.

Wartość domyślna to `false`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale jego osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `true` dodatkowo dołącza dane pliku. Podgląd pozostaje wizualną reprezentacją; załącznik umożliwia odbiorcom otwarcie lub zapisanie osadzonego pliku osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Następujący przykład ładuje prezentację, która już zawiera osadzony skoroszyt Excel, i eksportuje ją do PDF z załączonym skoroszytem.

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

1. Otwórz wyeksportowany plik PDF w przeglądarce obsługującej załączniki, takiej jak Adobe Acrobat Reader.  
2. Otwórz panel **Załączniki** w przeglądarce i znajdź osadzony skoroszyt.  
3. Zapisz załącznik i otwórz go w Excelu, aby sprawdzić dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Uwaga" %}}
Standardy PDF/A nakładają ograniczenia na załączniki: PDF/A-1 zakazuje osadzonych plików, PDF/A-2 zezwala tylko na załączniki PDF/A, a PDF/A-3 zezwala na inne typy plików, w tym skoroszyty Excel. Są to wymagania standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.
{{% /alert %}}

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) z klasy [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w wynikowym PDF.

Następujący przykład eksportuje prezentację do PDF, uwzględniając wszystkie ukryte slajdy.

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

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Następujący przykład eksportuje prezentację do PDF, który wymaga hasła `password` do otwarcia. Uprawnienia dostępu pozwalają na drukowanie, w tym drukowanie w wysokiej jakości.

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

### **Wykryj zastąpienia czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) w klasie [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), umożliwiając wykrycie zastąpień czcionek podczas procesu konwersji prezentacji do PDF.

Następujący przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o zastąpieniach czcionek na konsolę. Ostrzeżenie jest wypisywane tylko wtedy, gdy podczas eksportu zastąpiona zostaje niedostępna czcionka.

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
Aby uzyskać więcej informacji o zastępowaniu czcionek, zobacz artykuł [Zastępowanie czcionek](/slides/pl/nodejs-java/font-substitution/).
{{% /alert %}}

### **Obsługa czcionek bez dedykowanej pogrubionej odmiany**

Prezentacja może zastosować pogrubienie do tekstu, nawet jeśli czcionka nie ma dedykowanej pogrubionej wersji. Tekst może nadal wyglądać pogrubiony dzięki syntetycznemu pogrubianiu, które sztucznie zagęszcza zwykłe glify. Gdy taki tekst wygląda zbyt ciężko lub inaczej niż zamierzony w PDF, spróbuj wywołać [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) z wartością `true`. Ta opcja renderuje dotknięty tekst jako bitmapę podczas eksportu do PDF i może poprawić jego wygląd dla niektórych czcionek. Jej domyślna wartość to `false`.

Przykładowa prezentacja zawiera dwa pola tekstowe: jedno z normalnym tekstem i jedno z pogrubionym formatowaniem zastosowanym do tej samej czcionki, która nie ma dedykowanej pogrubionej odmiany. Następujący przykład ładuje prezentację, włącza rasteryzację nieobsługiwanych stylów czcionek i eksportuje ją do PDF:

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

Następujące podglądy pokazują wynik z wyłączoną i włączoną opcją. W tym przykładzie pogrubiony tekst ma cięższe kreski przy wyłączonej opcji. Po włączeniu opcja powoduje lżejsze kreski; tekst zwykły pozostaje niezmieniony. Porównaj wyniki przed wyborem ustawienia dla swojej prezentacji.

| Opcja wyłączona (`false`, domyślnie) | Opcja włączona (`true`) |
|---|---|
| ![PDF z wyłączoną rasteryzacją nieobsługiwanych stylów czcionki](unsupported-bold-disabled.png) | ![PDF z włączoną rasteryzacją nieobsługiwanych stylów czcionki](unsupported-bold-enabled.png) |

W tym przykładzie włączenie opcji zamienia tylko pogrubiony tekst na bitmapę: nie można go zaznaczyć, skopiować ani przeszukiwać jako tekst bez OCR, a jego krawędzie wyglądają miękko przy 800% powiększeniu. Tekst zwykły pozostaje przeszukiwalny. Przy wyłączonej opcji oba ciągi pozostają tekstem.

Ta opcja rasteryzuje tekst sformatowany jako pogrubiony, gdy jego czcionka nie ma dedykowanej pogrubionej odmiany. [Zastępowanie czcionek](/slides/pl/nodejs-java/font-substitution/) zamiast tego wybiera inną czcionkę, gdy oryginalna jest niedostępna.

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Następujący przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numery slajdów w tej tablicy zaczynają się od 1, a prezentacja wejściowa musi zawierać co najmniej trzy slajdy.

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

## **Konwertuj PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Następujący przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skaluje zawartość slajdu, aby dopasować, i eksportuje pojedynczy slajd do PDF.

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

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Następujący przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta każdego slajdu pod slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć rezultat.

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

## **Standardy dostępności i zgodności dla PDF**

Aspose.Slides umożliwia użycie procedury konwersji, która jest zgodna z [Wytycznymi dostępności treści internetowych (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, używając dowolnego z tych standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Ten kod demonstruje proces konwersji PowerPoint do PDF, który tworzy wiele plików PDF w oparciu o różne standardy zgodności:

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
Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF do JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), oraz [PDF do PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Inne operacje konwersji PDF do specjalistycznych formatów — [PDF do SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — są również obsługiwane.
{{% /alert %}}

> **Uwaga:** Kiedy eksportuje się do PDF/UA, Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest podany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**  
Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy można zabezpieczyć hasłem skonwertowany PDF?**  
Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), aby ustawić hasło i zdefiniować uprawnienia dostępu podczas procesu konwersji.

**Jak włączyć ukryte slajdy w PDF?**  
Wywołaj [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) z wartością `true` w klasie [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides może zachować wysoką jakość obrazu w PDF?**  
Tak, możesz kontrolować jakość obrazu, używając metod takich jak [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) i [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) w klasie [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), aby zapewnić wysokiej jakości obrazy w swoim PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**  
Tak, Aspose.Slides umożliwia eksport PDF zgodnych z [różnymi standardami](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając, że Twoje dokumenty spełniają wymagania dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides for Node.js via Java](/slides/pl/nodejs-java/)
- [Odnośnik API Aspose.Slides for Node.js via Java](https://reference.aspose.com/slides/nodejs-java/)
- [Bezpłatne konwertery online Aspose](https://products.aspose.app/slides/conversion)
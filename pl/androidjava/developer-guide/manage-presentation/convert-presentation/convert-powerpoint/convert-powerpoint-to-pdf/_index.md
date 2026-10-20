---
title: Konwertuj PPT i PPTX na PDF w Androidzie [Zawarte Zaawansowane Funkcje]
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
- załącznik
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w Javie przy użyciu Aspose.Slides for Android, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF na systemie Android daje wiele korzyści, w tym kompatybilność na różnych urządzeniach oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontroli jakości obrazu, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać zastąpienia czcionek, wybierać konkretne slajdy do konwersji oraz stosować normy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Przy użyciu Aspose.Slides możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację na PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) i następnie zapisz prezentację jako PDF przy użyciu metody [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Klasa [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), która zazwyczaj jest używana do konwersji prezentacji na PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java wstawia informacje o API oraz numer wersji do dokumentów wyjściowych. Na przykład, przy konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, nie możesz nakazać Aspose.Slides zmiany lub usunięcia tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* całych prezentacji do PDF
* wybranych slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że wynikowe pliki PDF są bardzo zbliżone do oryginalnych prezentacji. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* obrazy
* pola tekstowe i kształty
* formatowanie tekstu
* formatowanie akapitu
* hiperłącza
* nagłówki i stopki
* punktory
* tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint‑to‑PDF używa domyślnych opcji. W tym przypadku Aspose.Slides stara się przekonwertować podaną prezentację do PDF przy użyciu optymalnych ustawień o maksymalnej jakości.

Poniższy przykład ładuje prezentację i zapisuje wszystkie widoczne slajdy do PDF przy użyciu domyślnych ustawień eksportu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose oferuje darmowy internetowy [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz wykonać test przy użyciu tego konwertera, aby zobaczyć działanie procedury opisanej tutaj.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z Opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości w klasie [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć go hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z Niestandardowymi Opcjami**

Korzystając z własnych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, zdefiniować sposób obsługi metafili, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i nie tylko.

Poniższy przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metafilami zapisywanymi jako PNG oraz kompresją tekstu Flate.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Automatyczny Wybór Kompresji Obrazów**

Gdy prezentacja zawiera wiele fotografii lub zrzutów ekranu, zmniejszenie rozmiaru eksportowanego PDF może ułatwić jego wysyłanie lub pobieranie. Wywołaj [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) z wartością `true`, aby automatycznie wybrać najodpowiedniejszy algorytm kompresji dla każdego obrazu podczas eksportu PDF.

Poniższy przykład ładuje istniejącą prezentację, włącza automatyczny wybór kompresji obrazów i zapisuje ją jako dokument PDF. Wszystkie pozostałe ustawienia eksportu PDF zachowują wartości domyślne.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Ta opcja wybiera algorytm kompresji dla każdego obrazu. Obniżenie wartości przekazywanej do [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) zmniejsza jakość obrazu JPEG, natomiast obniżenie wartości przekazywanej do [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) pozwala na zmniejszenie rozdzielczości obrazu, co może ograniczyć szczegóły. Włączenie automatycznego wyboru kompresji nie obniża samych tych ustawień.

Wybór algorytmów kompresji obrazów wymaga dodatkowego czasu przetwarzania i pamięci. Redukcja rozmiaru zależy od obrazów w prezentacji i ustawień eksportu; stała redukcja nie jest gwarantowana dla każdej prezentacji.

### **Zachowaj Osadzone Pliki OLE jako Załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz do slajdów. Wywołaj [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) z wartością `true`, aby zachować osadzone pliki OLE jako załączniki w wynikowym PDF.

Domyślna wartość to `false`: podglądowy obraz lub ikona obiektu OLE jest renderowana na stronie PDF, ale osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `true` dodatkowo dołącza dane pliku. Podgląd pozostaje reprezentacją wizualną; załącznik umożliwia odbiorcom osobne otwarcie lub zapisanie osadzonego pliku. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład ładuje prezentację, w której już znajduje się osadzony skoroszyt Excel, i eksportuje ją do PDF z dołączonym skoroszytem.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Aby sprawdzić wynik:

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki, np. Adobe Acrobat Reader.  
2. Otwórz panel **Attachments** i znajdź osadzony skoroszyt.  
3. Zapisz załącznik i otwórz go w Excelu, aby przejrzeć dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Note" %}}
Standardy PDF/A nakładają ograniczenia na załączniki: PDF/A‑1 zabrania osadzonych plików, PDF/A‑2 dopuszcza jedynie załączniki PDF/A, a PDF/A‑3 zezwala na inne typy plików, w tym skoroszyty Excel. Są to wymogi standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.
{{% /alert %}}

### **Konwertuj PowerPoint do PDF z Ukrytymi Slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) z klasy [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w wynikowym PDF.

Poniższy przykład eksportuje prezentację do PDF, włączając wszystkie ukryte slajdy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Poniższy przykład eksportuje prezentację do PDF, który wymaga hasła `password` przy otwieraniu. Uprawnienia dostępu zezwalają na drukowanie, w tym drukowanie wysokiej jakości.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Wykryj Zastąpienia Czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) w klasie [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), umożliwiającą wykrycie zastąpień czcionek podczas procesu konwersji prezentacji do PDF.

Poniższy przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o zastąpieniach czcionek w konsoli. Ostrzeżenie jest wyświetlane tylko wtedy, gdy podczas eksportu zostaje zastąpiona niedostępna czcionka.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Po więcej informacji o zastąpieniach czcionek zobacz artykuł [Font Substitution](/slides/pl/androidjava/font-substitution/).
{{% /alert %}} 

### **Obsługa Czcionek Bez Dedykowanego Stylu Pogrubionego**

Prezentacja może stosować pogrubienie tekstu, nawet jeśli czcionka nie posiada dedykowanego stylu pogrubionego. Tekst może być wówczas pogrubiony syntetycznie, co sztucznie zagęszcza zwykłe glify. Gdy taki tekst wygląda zbyt ciężko lub różni się od zamierzonego wyglądu w PDF, spróbuj wywołać [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) z wartością `true`. Opcja ta renderuje dotknięty tekst jako bitmapę podczas eksportu PDF i może poprawić jego wygląd dla niektórych czcionek. Jej domyślna wartość to `false`.

Przykładowa prezentacja zawiera dwa pola tekstowe: jedno z normalnym tekstem i drugie z pogrubionym formatowaniem tego samego fontu, który nie ma dedykowanego stylu pogrubionego. Poniższy przykład ładuje prezentację, włącza rasteryzację nieobsługiwanych stylów czcionek i eksportuje ją do PDF:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Poniższe podglądy pokazują wynik przy wyłączonej i włączonej opcji. W tym przykładzie pogrubiony tekst ma cięższe kreski przy wyłączonej opcji. Po włączeniu opcji kreski są lżejsze; tekst zwykły pozostaje niezmieniony. Porównaj wyniki przed podjęciem decyzji o ustawieniu dla swojej prezentacji.

| Opcja wyłączona (`false`, domyślna) | Opcja włączona (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

W tym przykładzie włączenie opcji powoduje rasteryzację tylko pogrubionego tekstu: nie może być on zaznaczony, skopiowany ani przeszukany jako tekst bez OCR, a jego krawędzie wydają się miękkie przy powiększeniu 800 %. Tekst zwykły pozostaje możliwy do wyszukiwania. Przy wyłączonej opcji oba łańcuchy pozostają tekstem.

Ta opcja rasteruje tekst sformatowany jako pogrubiony, gdy jego czcionka nie ma dedykowanego stylu pogrubionego. Zamiast tego [Font substitution](/slides/pl/androidjava/font-substitution/) wybiera inną czcionkę, gdy oryginalna nie jest dostępna.

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Poniższy przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numery slajdów w tej tablicy są liczone od 1, a wejściowa prezentacja musi zawierać przynajmniej trzy slajdy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Konwertuj PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Poniższy przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skaluje zawartość slajdu, aby dopasować ją i eksportuje pojedynczy slajd do PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Usuń pusty slajd, który został utworzony w nowej prezentacji.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta pod każdym slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć wynik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Dostępność i standardy zgodności PDF**

Aspose.Slides umożliwia użycie procedury konwersji zgodnej ze [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz eksportować dokument PowerPoint do PDF, stosując dowolny z następujących standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Ten kod demonstruje proces konwersji PowerPoint‑to‑PDF, który tworzy wiele plików PDF w oparciu o różne standardy zgodności:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje: [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), oraz [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), i [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — są również wspierane.
{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożoną grafikę taką jak SmartArt, wykresy i formuły jako jedną figurę. Poszczególne elementy ścieżki nie są zachowywane jako odrębna treść i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany wyłącznie dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Wywołaj [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) z wartością `true` w klasie [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides zachowuje wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazów, używając metod takich jak [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) i [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) w klasie [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), aby zapewnić wysoką jakość obrazów w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides pozwala eksportować PDFy zgodne z [różnymi standardami](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając spełnienie wymagań dostępności i archiwizacji.

## **Dodatkowe Zasoby**

- [Aspose.Slides for Android via Java Documentation](/slides/pl/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
---
title: Przekształć PPT i PPTX na PDF w Javie [Zaawansowane funkcje włączone]
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
- załącznik
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w Javie przy użyciu Aspose.Slides, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w Javie oferuje kilka korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Niniejszy przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolowania jakości obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać zamiany czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności dla dokumentów wyjściowych.

## **Konwersje PowerPoint do PDF**

Za pomocą Aspose.Slides możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację na PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), a następnie zapisz prezentację jako PDF przy użyciu metody [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Klasa [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-), która zazwyczaj służy do konwersji prezentacji do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java wstawia informacje o swoim API oraz numer wersji do dokumentów wyjściowych. Na przykład podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga** że nie możesz nakazać Aspose.Slides zmiany lub usunięcia tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Wybranych slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF ściśle odpowiadają oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Pole tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitu
* Odnośniki hipertekstowe
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwersja PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa domyślnych opcji. W tym przypadku Aspose.Slides próbuje przekonwertować podaną prezentację na PDF, wykorzystując optymalne ustawienia przy maksymalnych poziomach jakości.

Następny przykład ładuje prezentację i zapisuje wszystkie widoczne slajdy do PDF przy użyciu domyślnych ustawień eksportu.

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
Aspose oferuje bezpłatny internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przeprowadzić test przy użyciu tego konwertera, aby zobaczyć działanie opisanej tutaj procedury.
{{% /alert %}}

## **Konwersja PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości w klasie [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), które pozwalają dostosować wynikowy PDF, zabezpieczyć PDF hasłem lub określić, w jaki sposób ma przebiegać proces konwersji.

### **Konwersja PowerPoint do PDF z niestandardowymi opcjami**

Korzystając z niestandardowych opcji konwersji, możesz określić preferowane ustawienie jakości obrazów rastrowych, określić sposób obsługi metafili, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i wiele innych.

Następny przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metafile zapisanymi jako PNG oraz kompresją tekstu Flate.

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

### **Automatyczny wybór kompresji obrazu**

Gdy prezentacja zawiera wiele fotografii lub zrzutów ekranu, zmniejszenie rozmiaru eksportowanego pliku PDF może ułatwić jego wysyłanie lub pobieranie. Wywołaj [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) z wartością `true`, aby automatycznie wybrać najbardziej odpowiedni algorytm kompresji dla każdego obrazu podczas eksportu PDF.

Następny przykład ładuje istniejącą prezentację, włącza automatyczny wybór kompresji obrazu i zapisuje ją jako dokument PDF. Wszystkie pozostałe ustawienia eksportu PDF zachowują swoje domyślne wartości.

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

Ta opcja wybiera algorytm kompresji dla każdego obrazu. Obniżenie wartości przekazywanej do [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) zmniejsza jakość obrazu JPEG, natomiast obniżenie wartości przekazywanej do [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) pozwala na downsampling obrazów do niższej rozdzielczości, co może zmniejszyć szczegóły. Włączenie automatycznego wyboru kompresji nie obniża samo w sobie żadnego z tych ustawień.

Wybór algorytmów kompresji obrazu wymaga dodatkowego czasu przetwarzania i pamięci. Redukcja rozmiaru zależy od obrazów w prezentacji i ustawień eksportu; stała redukcja nie jest gwarantowana dla każdej prezentacji.

### **Zachowanie osadzonych plików OLE jako załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz mogli przeglądać slajdy. Wywołaj [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) z wartością `true`, aby zachować osadzone pliki OLE jako załączniki w wynikowym PDF.

Domyślna wartość to `false`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale jego osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `true` dodatkowo dołącza dane pliku. Podgląd pozostaje reprezentacją wizualną; załącznik umożliwia odbiorcom otwarcie lub zapisanie osadzonego pliku osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Następny przykład ładuje prezentację, która już zawiera osadzony skoroszyt Excel, i eksportuje ją do PDF z dołączonym skoroszytem.

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
1. Otwórz wyeksportowany PDF w programie przeglądającym, który obsługuje załączniki, np. Adobe Acrobat Reader.
2. Otwórz panel **Attachments** (Załączniki) przeglądarki i zlokalizuj osadzony skoroszyt.
3. Zapisz załącznik i otwórz go w Excelu, aby sprawdzić dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Note" %}}
Standardy PDF/A nakładają ograniczenia na załączniki: PDF/A-1 zakazuje osadzania plików, PDF/A-2 zezwala wyłącznie na załączniki PDF/A, a PDF/A-3 dopuszcza inne typy plików, w tym skoroszyty Excel. Są to wymogi standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.
{{% /alert %}}

### **Konwersja PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) z klasy [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w wynikowym PDF.

Następny przykład eksportuje prezentację do PDF, włączając wszelkie ukryte slajdy.

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

### **Konwersja PowerPoint do PDF zabezpieczonego hasłem**

Następny przykład eksportuje prezentację do PDF, które wymaga hasła `password` przy otwieraniu. Uprawnienia dostępu pozwalają na drukowanie, w tym drukowanie w wysokiej jakości.

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

### **Wykrywanie zamiany czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) w ramach klasy [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), umożliwiając wykrywanie zamiany czcionek podczas procesu konwersji prezentacji do PDF.

Następny przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o zamianie czcionek na konsolę. Ostrzeżenie jest wyświetlane tylko wtedy, gdy podczas eksportu zostaje zamieniona niedostępna czcionka.

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
Aby uzyskać więcej informacji na temat zamiany czcionek, zobacz artykuł [Font Substitution](/slides/pl/java/font-substitution/).
{{% /alert %}} 

### **Obsługa czcionek bez dedykowanej pogrubionej czcionki**

Prezentacja może stosować pogrubienie tekstu, nawet gdy czcionka nie posiada dedykowanej pogrubionej wersji. Tekst może nadal wyglądać na pogrubiony dzięki syntetycznemu pogrubianiu, które sztucznie zagęszcza zwykłe glify. Gdy taki tekst wygląda zbyt ciężko lub inaczej niż zamierzone w PDF, spróbuj wywołać [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) z wartością `true`. Ta opcja renderuje dotknięty tekst jako bitmapę podczas eksportu PDF i może poprawić jego wygląd dla niektórych czcionek. Domyślna wartość to `false`.

Przykładowa prezentacja zawiera dwa pola tekstowe: jedno z normalnym tekstem i drugie z pogrubionym formatowaniem zastosowanym do tej samej czcionki, która nie ma dedykowanej pogrubionej wersji. Następny przykład ładuje prezentację, włącza rasteryzację nieobsługiwanych stylów czcionek i eksportuje ją do PDF:

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

Poniższe podglądy przedstawiają wynik z wyłączoną i włączoną opcją. W tym przykładzie pogrubiony tekst ma cięższe kreski przy wyłączonej opcji. Po włączeniu opcji kreski są lżejsze; zwykły tekst pozostaje niezmieniony. Porównaj wyniki przed wyborem ustawienia dla swojej prezentacji.

| Opcja wyłączona (`false`, domyślna) | Opcja włączona (`true`) |
|---|---|
| ![PDF z wyłączoną rasteryzacją nieobsługiwanego stylu czcionki](unsupported-bold-disabled.png) | ![PDF z włączoną rasteryzacją nieobsługiwanego stylu czcionki](unsupported-bold-enabled.png) |

W tym przykładzie włączenie opcji przekształca tylko pogrubiony tekst w bitmapę: nie można go zaznaczyć, skopiować ani wyszukać jako tekst bez OCR, a jego krawędzie wydają się miększe przy powiększeniu 800 %. Zwykły tekst pozostaje możliwy do przeszukania. Przy wyłączonej opcji oba ciągi pozostają tekstem.

Ta opcja rasteryzuje tekst sformatowany jako pogrubiony, gdy jego czcionka nie ma dedykowanej pogrubionej wersji. [Font substitution](/slides/pl/java/font-substitution/) zamiast tego wybiera inną czcionkę, gdy oryginalna jest niedostępna.

## **Konwersja wybranych slajdów z PowerPoint do PDF**

Następny przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numery slajdów w tej tablicy są numerowane od 1, a prezentacja wejściowa musi zawierać co najmniej trzy slajdy.

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

## **Konwersja PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Następny przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skaluje zawartość slajdu, aby dopasować ją, i eksportuje pojedynczy slajd do PDF.

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

## **Konwersja PowerPoint do PDF w widoku notatek slajdu**

Następny przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta każdego slajdu pod slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć wynik.

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

## **Standardy dostępności i zgodności dla PDF**

Aspose.Slides umożliwia użycie procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF używając dowolnego z tych standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Niniejszy kod demonstruje proces konwersji PowerPoint do PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

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
Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) oraz [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Inne operacje konwersji PDF do specjalistycznych formatów — [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), i [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — są również obsługiwane.
{{% /alert %}}

> **Uwaga:** przy eksporcie do PDF/UA, Aspose.Slides traktuje złożoną grafikę, taką jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo stosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak dodać ukryte slajdy do PDF?**

Wywołaj [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) z wartością `true` w klasie [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides może utrzymać wysoką jakość obrazu w PDF?**

Tak, możesz kontrolować jakość obrazu, używając metod takich jak [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) i [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) w klasie [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), aby zapewnić wysokiej jakości obrazy w swoim PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides umożliwia eksport PDF-ów zgodnych z [różnymi standardami](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając, że Twoje dokumenty spełniają wymagania dotyczące dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides for Java](/slides/pl/java/)
- [Referencja API Aspose.Slides for Java](https://reference.aspose.com/slides/java/)
- [Bezpłatne konwertery online Aspose](https://products.aspose.app/slides/conversion)
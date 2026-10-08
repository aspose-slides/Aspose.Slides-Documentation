---
title: "Konwertuj PPT i PPTX do PDF na Androidzie [Zawarte zaawansowane funkcje]"
linktitle: "PowerPoint do PDF"
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
description: "Konwertuj prezentacje PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF w Javie przy użyciu Aspose.Slides dla Androida, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF na Androidzie oferuje kilka korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolowania jakości obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację, przekaż nazwę pliku jako argument do klasy [Prezentacja](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) i następnie zapisz prezentację jako PDF używając metody [zapisz](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Klasa [Prezentacja](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) udostępnia metodę [zapisz](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), która zazwyczaj jest używana do konwersji prezentacji do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java wstawia informacje o API oraz numer wersji do dokumentów wyjściowych. Na przykład, podczas konwertowania prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, że nie możesz polecić Aspose.Slides, aby zmienił lub usunął te informacje z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całe prezentacje do PDF
* Konkretne slajdy z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF ściśle odpowiadają oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Ramki tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitu
* Hiperdłącza
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint‑do‑PDF używa domyślnych opcji. W takim przypadku Aspose.Slides próbuje przekształcić podaną prezentację do PDF, stosując optymalne ustawienia przy maksymalnych poziomach jakości.

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
Aspose oferuje darmowy internetowy [**Konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przetestować ten konwerter, aby zobaczyć działanie opisanej procedury.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z Opcjami**

Aspose.Slides udostępnia własne opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć go hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z Własnymi Opcjami**

Korzystając z własnych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, zdefiniować sposób obsługi metafili, ustawić poziom kompresji tekstu, skonfigurować DPI obrazów i wiele więcej.

Poniższy przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metafile zapisanymi jako PNG oraz kompresją tekstu Flate.

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

### **Zachowaj osadzone pliki OLE jako załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz mogli przeglądać slajdy. Wywołaj metodę [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) z wartością `true`, aby zachować osadzone pliki OLE jako załączniki w powstałym PDF.

Domyślna wartość to `false`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `true` dodatkowo dołącza dane pliku. Podgląd pozostaje reprezentacją wizualną; załącznik umożliwia odbiorcom otwarcie lub zapisanie osadzonego pliku osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład ładuje prezentację, która już zawiera osadzony skoroszyt Excel, i eksportuje ją do PDF z dołączonym skoroszytem.

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
3. Zapisz załącznik i otwórz go w Excelu, aby przeanalizować dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Note" %}}
Standardy PDF/A nakładają ograniczenia dotyczące załączników: PDF/A‑1 zakazuje osadzonych plików, PDF/A‑2 zezwala wyłącznie na załączniki PDF/A, a PDF/A‑3 dopuszcza inne typy plików, w tym skoroszyty Excel. Są to wymogi samych standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.
{{% /alert %}}

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) klasy [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w powstałym PDF.

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

Poniższy przykład eksportuje prezentację do PDF, który wymaga podania hasła `password` przy otwieraniu. Uprawnienia dostępu zezwalają na drukowanie, w tym drukowanie wysokiej jakości.

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

### **Wykryj podstawienia czcionek**

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) klasy [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), umożliwiając wykrywanie podstawień czcionek podczas procesu konwersji prezentacji do PDF.

Poniższy przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o podstawieniach czcionek w konsoli. Ostrzeżenie jest wyświetlane tylko wtedy, gdy podczas eksportu zostanie zastąpiona niedostępna czcionka.

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
Więcej informacji o podstawianiu czcionek znajdziesz w artykule [Podstawianie czcionek](/slides/pl/androidjava/font-substitution/).
{{% /alert %}} 

### **Obsługa czcionek bez dedykowanej pogrubionej czcionki**

Prezentacja może stosować pogrubienie tekstu, nawet jeśli używana czcionka nie posiada dedykowanego stylu pogrubionego. Tekst może być wówczas wyświetlany jako pogrubiony syntetycznie, co sztucznie zagęszcza regularne glify. Gdy taki tekst wygląda zbyt ciężko lub odbiega od zamierzonego wyglądu w PDF, spróbuj wywołać metodę [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) z wartością `true`. Opcja ta renderuje dotknięty tekst jako bitmapę podczas eksportu PDF i może poprawić jego wygląd w przypadku niektórych czcionek. Domyślna wartość to `false`.

Przykładowa prezentacja zawiera dwa pola tekstowe: jedno z tekstem zwykłym i drugie z pogrubionym formatowaniem tej samej czcionki, która nie ma dedykowanego stylu pogrubionego. Poniższy przykład ładuje prezentację, włącza rasteryzację niewspieranych stylów czcionki i eksportuje ją do PDF:

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

Poniższe podglądy pokazują wynik przy wyłączonej i włączonej opcji. W tym przykładzie tekst pogrubiony ma cięższe kreski przy wyłączonej opcji. Po włączeniu opcji jego kreski są lżejsze; tekst zwykły pozostaje niezmieniony. Porównaj wyniki przed podjęciem decyzji o ustawieniu dla swojej prezentacji.

| Opcja wyłączona (`false`, domyślna) | Opcja włączona (`true`) |
|---|---|
| ![PDF z wyłączoną rasteryzacją nieobsługiwanych stylów czcionki pogrubionej](unsupported-bold-disabled.png) | ![PDF z włączoną rasteryzacją nieobsługiwanych stylów czcionki pogrubionej](unsupported-bold-enabled.png) |

W tym przykładzie włączenie opcji zamienia jedynie pogrubiony tekst w bitmapę: nie może być zaznaczony, kopiowany ani wyszukiwany jako tekst bez OCR, a jego krawędzie wydają się miękkie przy przybliżeniu 800 %. Tekst zwykły pozostaje przeszukiwany. Przy wyłączonej opcji oba ciągi pozostają tekstem.

Ta opcja rasteryzuje tekst sformatowany jako pogrubiony, gdy jego czcionka nie posiada dedykowanego stylu pogrubionego. [Podstawianie czcionek](/slides/pl/androidjava/font-substitution/) zamiast tego wybiera inną czcionkę, gdy oryginalna jest niedostępna.

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Poniższy przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numeracja w tej tablicy jest jednoczynnikowa, a wejściowa prezentacja musi zawierać co najmniej trzy slajdy.

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

Poniższy przykład kopiuję pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skaluje zawartość slajdu, aby dopasować ją, i eksportuje pojedynczy slajd do PDF.

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

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta każdego slajdu pod samym slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć rezultat.

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

Aspose.Slides pozwala używać procedury konwersji zgodnej z [Wytycznymi dotyczącymi dostępności treści internetowych (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz eksportować dokument PowerPoint do PDF, stosując dowolny z następujących standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Ten kod demonstruje proces konwersji PowerPoint‑do‑PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

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
Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) oraz [PDF do PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) i [PDF do XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — są również wspierane.
{{% /alert %}}

> **Uwaga:** Przy eksporcie do PDF/UA, Aspose.Slides traktuje złożone grafiki takie jak SmartArt, wykresy i formuły jako jedną figurę. Poszczególne elementy ścieżki nie są zachowywane jako odrębna treść i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednorazowo?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo stosować proces konwersji.

**Czy możliwe jest zabezpieczenie konwertowanego PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Wywołaj metodę [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) z wartością `true` w klasie [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), aby uwzględnić ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides zachowuje wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazów, używając metod takich jak [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) i [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) w klasie [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), aby zapewnić wysokiej jakości obrazy w swoim PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides pozwala eksportować PDF‑y zgodne z [różnymi standardami](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając spełnienie wymogów dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides dla Androida przez Java](/slides/pl/androidjava/)
- [Odwołanie do API Aspose.Slides dla Androida przez Java](https://reference.aspose.com/slides/androidjava/)
- [Bezpłatne konwertery online Aspose](https://products.aspose.app/slides/conversion)
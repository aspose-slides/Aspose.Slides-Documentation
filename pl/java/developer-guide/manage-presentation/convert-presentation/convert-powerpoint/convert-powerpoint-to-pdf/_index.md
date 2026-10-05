---
title: Konwertuj PPT i PPTX do PDF w Javie [Zawiera zaawansowane funkcje]
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
description: "Konwertuj prezentacje PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF w Javie przy użyciu Aspose.Slides, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w Javie oferuje wiele korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolujących jakość obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) , a następnie zapisz prezentację jako PDF przy użyciu metody [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Klasa [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) udostępnia metodę [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-), która zazwyczaj służy do konwersji prezentacji do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides dla Javy wstawia informacje o API oraz numer wersji do dokumentów wyjściowych. Na przykład podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formie "*Aspose.Slides v XX.XX*". **Uwaga** że nie możesz nakazać Aspose.Slides zmiany lub usunięcia tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całe prezentacje do PDF
* Określone slajdy z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF bardzo dokładnie odwzorowują oryginalne prezentacje. Elementy i atrybuty są renderowane precyzyjnie podczas konwersji, w tym:

* Obrazy
* Ramki tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitu
* Odnośniki hipertekstowe
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa domyślnych opcji. W takim przypadku Aspose.Slides stara się skonwertować podaną prezentację do PDF, wykorzystując optymalne ustawienia przy maksymalnym poziomie jakości.

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
Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przeprowadzić test przy użyciu tego konwertera, aby zobaczyć działanie opisanej tutaj procedury.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z Opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) , które pozwalają dostosować powstały PDF, zabezpieczyć PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z Niestandardowymi Opcjami**

Korzystając z niestandardowych opcji konwersji, możesz określić preferowane ustawienia jakości dla obrazów rastrowych, określić sposób obsługi metafili, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i wiele więcej.

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

### **Zachowaj Osadzone Pliki OLE jako Załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz mogli przeglądać slajdy. Wywołaj [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) z `true`, aby zachować osadzone pliki OLE jako załączniki w powstałym PDF.

Domyślna wartość to `false`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `true` dodatkowo dołącza dane pliku. Podgląd pozostaje reprezentacją wizualną; załącznik umożliwia odbiorcom otwarcie lub zapisanie osadzonego pliku osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład ładuje prezentację, która już zawiera osadzony skoroszyt Excel i eksportuje ją do PDF z dołączonym skoroszytem.

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

Aby sprawdzić rezultat:

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki, takiej jak Adobe Acrobat Reader.
2. Otwórz panel **Attachments** (Załączniki) przeglądarki i znajdź osadzony skoroszyt.
3. Zapisz załącznik i otwórz go w Excelu, aby sprawdzić dane, lub otwórz bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Note" %}}
Standardy PDF/A nakładają ograniczenia na załączniki: PDF/A-1 zabrania osadzonych plików, PDF/A-2 zezwala tylko na załączniki PDF/A, a PDF/A-3 dopuszcza inne typy plików, w tym skoroszyty Excel. Są to wymogi standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.
{{% /alert %}}

### **Konwertuj PowerPoint do PDF z Ukrytymi Slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) klasy [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) , aby uwzględnić ukryte slajdy jako strony w powstałym PDF.

Poniższy przykład eksportuje prezentację do PDF, uwzględniając wszystkie ukryte slajdy.

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

### **Konwertuj PowerPoint do PDF chronionego hasłem**

Poniższy przykład eksportuje prezentację do PDF, które wymaga hasła `password` do otwarcia. Uprawnienia dostępu pozwalają na drukowanie, w tym drukowanie wysokiej jakości.

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

Aspose.Slides udostępnia metodę [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) w klasie [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) , umożliwiając wykrywanie podstawień czcionek podczas procesu konwersji prezentacji do PDF.

Poniższy przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o podstawieniach czcionek na konsolę. Ostrzeżenie jest wyświetlane tylko wtedy, gdy podczas eksportu zostanie podmieniona niedostępna czcionka.

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
Aby uzyskać więcej informacji na temat podstawień czcionek, zobacz artykuł [Font Substitution](/slides/pl/java/font-substitution/).
{{% /alert %}} 

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Poniższy przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numery slajdów w tej tablicy są liczbami zaczynającymi się od 1, a wejściowa prezentacja musi zawierać co najmniej trzy slajdy.

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

Poniższy przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skaluje zawartość slajdu, aby dopasować ją, i eksportuje pojedynczy slajd do PDF.

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

## **Konwertuj PowerPoint do PDF w widoku slajdu z notatkami**

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta każdego slajdu pod slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć rezultat.

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

Aspose.Slides umożliwia użycie procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz eksportować dokument PowerPoint do PDF, stosując dowolny z poniższych standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Ten kod demonstruje proces konwersji PowerPoint do PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

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
Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), i [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), i [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — są również wspierane.
{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżki nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; alternatywny tekst jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować przez swoje pliki i programowo zastosować proces konwersji.

**Czy możliwe jest zabezpieczenie hasłem przekonwertowanego PDF?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) , aby ustawić hasło i zdefiniować uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Wywołaj [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) z `true` w klasie [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) , aby uwzględnić ukryte slajdy w powstałym PDF.

**Czy Aspose.Slides może zachować wysoką jakość obrazu w PDF?**

Tak, możesz kontrolować jakość obrazu, używając metod takich jak [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) i [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) w klasie [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) , aby zapewnić wysokiej jakości obrazy w swoim PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides umożliwia eksport PDF‑ów zgodnych z [różnymi standardami](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) , w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając, że dokumenty spełniają wymagania dotyczące dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides for Java](/slides/pl/java/)
- [Referencja API Aspose.Slides for Java](https://reference.aspose.com/slides/java/)
- [Darmowe konwertery online Aspose](https://products.aspose.app/slides/conversion)
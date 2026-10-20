---
title: Konwertuj PPT i PPTX do PDF w .NET [Zawarte zaawansowane funkcje]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /pl/net/convert-powerpoint-to-pdf/
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
- .NET
- C#
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w .NET przy użyciu Aspose.Slides, z szybkimi przykładami kodu C# i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w C# oferuje kilka zalet, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje na dokumenty PDF, używać różnych opcji kontrolujących jakość obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności do dokumentów wyjściowych.

## **Konwersje z PowerPoint do PDF**

Korzystając z Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Prezentacja](https://reference.aspose.com/slides/net/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF używając metody [Zapisz](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Klasa [Prezentacja](https://reference.aspose.com/slides/net/aspose.slides/presentation/) udostępnia metodę [Zapisz](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), która jest zazwyczaj używana do konwersji prezentacji do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides dla .NET wstawia informacje o API oraz numer wersji do dokumentów wyjściowych. Na przykład, przy konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga** że nie możesz nakazać Aspose.Slides zmiany lub usunięcia tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides pozwala na konwersję:

* Całych prezentacji do PDF
* Wybranych slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF ściśle odzwierciedlają oryginalne prezentacje. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hiperłącza
* Nagłówki i stopki
* Wypunktowania
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa domyślnych opcji. W tym przypadku Aspose.Slides stara się przekonwertować podaną prezentację do PDF, używając optymalnych ustawień przy maksymalnej jakości.

Poniższy przykład ładuje prezentację i zapisuje wszystkie widoczne slajdy do PDF przy użyciu domyślnych ustawień eksportu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przeprowadzić test z tym konwerterem, aby zobaczyć działanie procedury opisanej tutaj.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z Opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości w klasie [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), które pozwalają dostosować wynikowy PDF, zablokować PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z Niestandardowymi Opcjami**

Korzystając z niestandardowych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metafili, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i nie tylko.

Poniższy przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metafile zapisanymi jako PNG oraz kompresją tekstu Flate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Automatyczny Wybór Kompresji Obrazów**

Kiedy prezentacja zawiera wiele fotografii lub zrzutów ekranu, zmniejszenie rozmiaru eksportowanego PDF może ułatwić jego wysyłanie lub pobieranie. Ustaw [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) na `true`, aby automatycznie wybrać najbardziej odpowiedni algorytm kompresji dla każdego obrazu podczas eksportu PDF.

Poniższy przykład ładuje istniejącą prezentację, włącza automatyczny wybór kompresji obrazów i zapisuje ją jako dokument PDF. Wszystkie pozostałe ustawienia eksportu PDF zachowują wartości domyślne.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Ta opcja wybiera algorytm kompresji dla każdego obrazu. Obniżenie [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) zmniejsza jakość obrazu JPEG, natomiast obniżenie [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) pozwala na zmniejszenie rozdzielczości obrazu, co może redukować szczegóły. Włączenie automatycznego wyboru kompresji nie obniża tych ustawień samo w sobie.

Wybór algorytmów kompresji obrazów wymaga dodatkowego czasu przetwarzania i pamięci. Redukcja rozmiaru zależy od obrazów w prezentacji i ustawień eksportu; stała redukcja nie jest gwarantowana dla każdej prezentacji.

### **Zachowaj Osadzone Pliki OLE jako Załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz do slajdów. Ustaw [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) na `true`, aby zachować osadzone pliki OLE jako załączniki w powstałym PDF.

Domyślna wartość to `false`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale jego osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `true` dodatkowo dołącza dane pliku. Podgląd pozostaje reprezentacją wizualną; załącznik pozwala odbiorcom otworzyć lub zapisać osadzony plik osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład ładuje prezentację, która już zawiera osadzony skoroszyt Excel, i eksportuje ją do PDF z dołączonym skoroszytem.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Aby sprawdzić wynik:

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki, takiej jak Adobe Acrobat Reader.  
2. Otwórz panel **Załączniki** przeglądarki i znajdź osadzony skoroszyt.  
3. Zapisz załącznik i otwórz go w Excelu, aby przeanalizować dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Note" %}}
Standardy PDF/A narzucają ograniczenia dotyczące załączników: PDF/A‑1 zakazuje osadzonych plików, PDF/A‑2 zezwala wyłącznie na załączniki PDF/A, a PDF/A‑3 dopuszcza inne typy plików, w tym skoroszyty Excel. Są to wymagania standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.
{{% /alert %}}

### **Konwertuj PowerPoint do PDF z Ukrytymi Slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć właściwości [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) z klasy [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w powstałym PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Konwertuj PowerPoint do PDF chronionego hasłem**

Poniższy przykład eksportuje prezentację do PDF, który wymaga podania hasła `password` w celu otwarcia. Uprawnienia dostępu umożliwiają drukowanie, w tym drukowanie wysokiej jakości.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Wykryj podstawienia czcionek**

Aspose.Slides udostępnia właściwość [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) w klasie [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), umożliwiając wykrywanie podstawień czcionek podczas procesu konwersji prezentacji do PDF.

Poniższy przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o podstawieniach czcionek w konsoli. Ostrzeżenie jest generowane tylko wtedy, gdy podczas eksportu zostanie podmieniona niedostępna czcionka.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
Aby uzyskać więcej informacji o podstawieniach czcionek, zobacz artykuł [Podstawienia czcionek](/slides/pl/net/font-substitution/).
{{% /alert %}} 

### **Obsługuj czcionki bez dedykowanego kroju pogrubionego**

Prezentacja może stosować pogrubienie tekstu nawet wtedy, gdy czcionka nie posiada dedykowanego kroju pogrubionego. Tekst może wciąż wyglądać pogrubienie dzięki syntetycznemu pogrubieniu, które sztucznie zagęszcza zwykłe glify. Gdy taki tekst wydaje się zbyt ciężki lub różni się od zamierzonego wyglądu w PDF, spróbuj ustawić [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) na `true`. Opcja ta renderuje dotknięty tekst jako bitmapę podczas eksportu PDF i może poprawić jego wygląd dla niektórych czcionek. Jej domyślna wartość to `false`.

Przykładowa prezentacja zawiera dwa pola tekstowe: jedno z tekstem zwykłym i jedno z pogrubionym formatowaniem zastosowanym do tej samej czcionki, która nie ma dedykowanego kroju pogrubionego. Poniższy przykład ładuje prezentację, włącza rasteryzację niewspieranych stylów czcionek i eksportuje ją do PDF:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

Poniższe podglądy pokazują wynik z wyłączoną i włączoną opcją. W tym przykładzie tekst pogrubiony ma cięższe kreski przy wyłączonej opcji. Po włączeniu opcji kreski są lżejsze; tekst zwykły pozostaje niezmieniony. Porównaj wyniki przed podjęciem decyzji o ustawieniu dla swojej prezentacji.

| Opcja wyłączona (`false`, domyślnie) | Opcja włączona (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

W tym przykładzie włączenie opcji zamienia tylko pogrubiony tekst w bitmapę: nie może być zaznaczony, kopiowany ani przeszukiwany jako tekst bez OCR, a jego krawędzie wyglądają miękko przy 800 % powiększeniu. Tekst zwykły pozostaje wyszukiwalny. Przy wyłączonej opcji oba ciągi pozostają tekstem.

Opcja ta rasteryzuje tekst sformatowany jako pogrubiony, gdy jego czcionka nie posiada dedykowanego kroju pogrubionego. [Podstawienia czcionek](/slides/pl/net/font-substitution/) zamiast tego wybierają inną czcionkę, gdy oryginalna jest niedostępna.

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Poniższy przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numery slajdów w tej tablicy są indeksowane od 1, a wejściowa prezentacja musi zawierać co najmniej trzy slajdy.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Konwertuj PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Poniższy przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cal). Skaluje zawartość slajdu, aby dopasować ją do rozmiaru, i eksportuje pojedynczy slajd do PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta każdego slajdu pod slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć wynik.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Standardy dostępności i zgodności dla PDF**

Aspose.Slides pozwala używać procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz eksportować dokument PowerPoint do PDF, stosując dowolny z tych standardów zgodności: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Ten kod C# demonstruje proces konwersji PowerPoint do PDF, który tworzy wiele plików PDF opartych na różnych standardach zgodności:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert color="info" title="Note" %}}
Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), i [PDF do PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), oraz [PDF do XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)\- są również wspierane.
{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożone grafiki takie jak SmartArt, wykresy i formuły jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako osobna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo stosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Ustaw właściwość [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) w klasie [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) na `true`, aby uwzględnić ukryte slajdy w powstałym PDF.

**Czy Aspose.Slides może utrzymać wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazów, ustawiając właściwości takie jak [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) i [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) w klasie [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), aby zapewnić wysoką jakość obrazów w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides pozwala eksportować PDFy zgodne z różnymi standardami, w tym PDF/A1a, PDF/A1b oraz PDF/UA, zapewniając, że dokumenty spełniają wymagania dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides dla .NET](/slides/pl/net/)
- [Odwołanie API Aspose.Slides dla .NET](https://reference.aspose.com/slides/net/)
- [Bezpłatne konwertery online Aspose](https://products.aspose.app/slides/conversion)
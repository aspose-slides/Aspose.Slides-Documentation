---
title: Konwertuj PPT i PPTX do PDF w .NET [Zaawansowane funkcje uwzględnione]
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
description: "Konwertuj PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w .NET używając Aspose.Slides, z szybkimi przykładami kodu C# i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w C# oferuje wiele korzyści, w tym zgodność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolowania jakości obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Korzystając z Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF przy użyciu metody [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Klasa [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) udostępnia metodę [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), która zazwyczaj jest używana do konwersji prezentacji do PDF.

{{% alert color="info" title="Uwaga" %}}

Aspose.Slides for .NET wstawia informacje o API i numer wersji do dokumentów wyjściowych. Na przykład podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, że nie można nakazać Aspose.Slides zmiany lub usunięcia tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Wybranych slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF są bardzo zbliżone do oryginalnych prezentacji. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hiperłącza
* Nagłówki i stopki
* Wypunktowania
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint‑to‑PDF używa domyślnych opcji. W tym przypadku Aspose.Slides stara się przekonwertować podaną prezentację do PDF, korzystając z optymalnych ustawień przy maksymalnych poziomach jakości.

Poniższy przykład ładuje prezentację i zapisuje wszystkie widoczne slajdy do PDF przy użyciu domyślnych ustawień eksportu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Uwaga" %}}

Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przetestować ten konwerter, aby zobaczyć działanie opisanej tutaj procedury.

{{% /alert %}}

## **Konwertuj PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć go hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z własnymi opcjami**

Korzystając z niestandardowych opcji konwersji, możesz określić preferowane ustawienia jakości rastra obrazów, sposób obsługi metaplików, poziom kompresji tekstu, DPI dla obrazów i wiele innych.

Poniższy przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metaplikami zapisywanymi jako PNG oraz kompresją tekstu Flate.

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

### **Zachowaj osadzone pliki OLE jako załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz do slajdów. Ustaw [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) na `true`, aby zachować osadzone pliki OLE jako załączniki w wynikowym PDF.

Domyślna wartość to `false`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `true` dodatkowo dołącza dane pliku. Podgląd pozostaje reprezentacją wizualną; załącznik umożliwia odbiorcom otwarcie lub zapisanie osadzonego pliku osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład ładuje prezentację, która już zawiera osadzony skoroszyt Excel, i eksportuje ją do PDF z dołączonym skoroszytem.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Aby sprawdzić wynik:

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki, np. Adobe Acrobat Reader.
2. Otwórz panel **Attachments** i znajdź osadzony skoroszyt.
3. Zapisz załącznik i otwórz go w Excelu, aby przeanalizować dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Uwaga" %}}

Standardy PDF/A nakładają ograniczenia na załączniki: PDF/A‑1 zakazuje plików osadzonych, PDF/A‑2 dopuszcza jedynie załączniki PDF/A, a PDF/A‑3 dopuszcza inne typy plików, w tym skoroszyty Excel. Są to wymagania standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.

{{% /alert %}}

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć właściwości [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) klasy [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w wynikowym PDF.

Poniższy przykład eksportuje prezentację do PDF, włączając wszystkie ukryte slajdy.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Poniższy przykład eksportuje prezentację do PDF, które wymaga hasła `password` przy otwieraniu. Uprawnienia dostępu pozwalają na drukowanie, w tym drukowanie wysokiej jakości.

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

Aspose.Slides udostępnia właściwość [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) w klasie [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), umożliwiającą wykrycie podstawień czcionek podczas konwersji prezentacji do PDF.

Poniższy przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o podstawieniach czcionek w konsoli. Ostrzeżenie jest wyświetlane tylko wtedy, gdy podczas eksportu zostaje podmieniona niedostępna czcionka.

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

{{% alert color="info" title="Uwaga" %}}

Więcej informacji na temat podstawień czcionek znajdziesz w artykule [Font Substitution](/slides/pl/net/font-substitution/).

{{% /alert %}} 

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

Poniższy przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skalowanie treści slajdu dopasowuje ją do rozmiaru i eksportuje pojedynczy slajd do PDF.

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

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta pod każdym slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć rezultat.

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

## **Dostępność i standardy zgodności PDF**

Aspose.Slides pozwala używać procedury konwersji spełniającej [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz eksportować dokument PowerPoint do PDF, stosując dowolny z następujących standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Ten kod C# demonstruje proces konwersji PowerPoint‑to‑PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

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

{{% alert color="info" title="Uwaga" %}}

Aspose.Slides wspiera operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) i [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), oraz [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — są również obsługiwane.

{{% /alert %}}

> **Uwaga:** Przy eksporcie do PDF/UA, Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako pojedynczą figurę. Poszczególne elementy ścieżek nie są zachowywane jako odrębna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo stosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), aby ustawić hasło i zdefiniować uprawnienia dostępu podczas konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Ustaw właściwość [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) w klasie [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) na `true`, aby włączyć ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides utrzymuje wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazów, ustawiając właściwości takie jak [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) i [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) w klasie [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), aby zapewnić wysoką jakość obrazów w PDF.

**Czy Aspose.Slides wspiera standardy zgodności PDF/A?**

Tak, Aspose.Slides pozwala eksportować PDF‑y zgodne z różnymi standardami, w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając, że dokumenty spełniają wymagania dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides dla .NET](/slides/pl/net/)
- [Referencja API Aspose.Slides dla .NET](https://reference.aspose.com/slides/net/)
- [Bezpłatne konwertery online Aspose](https://products.aspose.app/slides/conversion)
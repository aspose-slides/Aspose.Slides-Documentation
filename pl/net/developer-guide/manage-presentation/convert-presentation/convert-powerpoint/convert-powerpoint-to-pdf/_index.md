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
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Konwertuj PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF w .NET przy użyciu Aspose.Slides, z szybkimi przykładami kodu C# i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w języku C# oferuje kilka korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolujących jakość obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) a następnie zapisz prezentację jako PDF używając metody [Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/). Klasa [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) udostępnia metodę [Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/), która zazwyczaj jest używana do konwersji prezentacji do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides dla .NET wstawia informacje o swoim API oraz numer wersji do dokumentów wyjściowych. Na przykład, przy konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*", a pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga** że nie można nakazać Aspose.Slides zmienić lub usunąć tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides pozwala na konwersję:

* Całe prezentacje do PDF
* Wybrane slajdy z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF w dużej mierze odzwierciedlają oryginalne prezentacje. Elementy i atrybuty są renderowane dokładnie w konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitu
* Hiperłącza
* Nagłówki i stopki
* Punktory
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa domyślnych opcji. W tym przypadku Aspose.Slides próbuje przekonwertować podaną prezentację do PDF, korzystając z optymalnych ustawień przy maksymalnych poziomach jakości.

Ten kod C# pokazuje, jak przekonwertować prezentację (PPT, PPTX, ODP itp.) do PDF:

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Save the presentation as a PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 
Aspose oferuje bezpłatny internetowy [**Konwerter PowerPoint do PDF**](https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz uruchomić test z tym konwerterem, aby zobaczyć działanie opisanej tutaj procedury.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia opcje niestandardowe — właściwości w klasie [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć go hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z niestandardowymi opcjami**

Używając opcji konwersji niestandardowych, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metafili, ustawić poziom kompresji dla tekstu, skonfigurować DPI dla obrazów i więcej.

Poniższy przykład kodu pokazuje, jak przekonwertować prezentację PowerPoint do PDF z kilkoma opcjami niestandardowymi.

```c#
 // Utwórz instancję klasy PdfOptions.
 var pdfOptions = new PdfOptions
 {
     // Ustaw jakość obrazów JPG.
     JpegQuality = 90,

     // Ustaw DPI dla obrazów.
     SufficientResolution = 300,

     // Ustaw zachowanie metafili.
     SaveMetafilesAsPng = true,

     // Ustaw poziom kompresji tekstu dla treści tekstowej.
     TextCompression = PdfTextCompression.Flate,

     // Określ tryb zgodności PDF.
     Compliance = PdfCompliance.Pdf15
 };

 // Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
 using var presentation = new Presentation("PowerPoint.pptx");

 // Zapisz prezentację jako dokument PDF.
 presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć właściwości [ShowHiddenSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/showhiddenslides/) z klasy [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w powstałym PDF.

Ten kod C# pokazuje, jak przekonwertować prezentację PowerPoint do PDF z uwzględnieniem ukrytych slajdów:

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Utwórz instancję klasy PdfOptions.
var pdfOptions = new PdfOptions();

// Dodaj ukryte slajdy.
pdfOptions.ShowHiddenSlides = true;

// Zapisz prezentację jako PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Ten kod C# demonstruje, jak przekonwertować prezentację PowerPoint do PDF zabezpieczonego hasłem, używając parametrów ochrony z klasy [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/):

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Utwórz instancję klasy PdfOptions.
var pdfOptions = new PdfOptions();

// Ustaw hasło PDF i uprawnienia dostępu.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Zapisz prezentację jako PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Wykrywanie podstawień czcionek**

Aspose.Slides udostępnia właściwość [WarningCallback](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveoptions/warningcallback/) w klasie [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/), umożliwiając wykrywanie podstawień czcionek podczas procesu konwersji prezentacji do PDF.

Ten kod C# pokazuje, jak wykrywać podstawienia czcionek:

```c#
public static void Main()
{
    // Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
    using var presentation = new Presentation("sample.pptx");

    // Ustaw wywołanie zwrotne ostrzeżenia w opcjach PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Zapisz prezentację jako PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementacja wywołania zwrotnego ostrzeżenia.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 
Po więcej informacji o odbieraniu wywołań zwrotnych dotyczących podstawień czcionek podczas procesu renderowania, zobacz [Getting Warning Callbacks for Fonts Substitution](/slides/pl/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Po więcej informacji o podstawieniach czcionek, zobacz artykuł [Font Substitution](/slides/pl/net/font-substitution/).
{{% /alert %}} 

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Ten kod C# demonstruje, jak skonwertować tylko wybrane slajdy z prezentacji PowerPoint do PDF:

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Ustaw tablicę numerów slajdów.
int[] slides = { 1, 3 };

// Zapisz prezentację jako PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Konwertuj PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Ten kod C# demonstruje, jak przekonwertować prezentację PowerPoint do PDF z określonym rozmiarem slajdu:

```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Ten kod C# demonstruje, jak przekonwertować prezentację PowerPoint do PDF, który zawiera notatki:

```c#
// Wczytaj prezentację PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Skonfiguruj opcje PDF z układem notatek.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Zapisz prezentację do PDF z notatkami.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Standardy dostępności i zgodności PDF**

Aspose.Slides pozwala używać procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz eksportować dokument PowerPoint do PDF używając dowolnego z tych standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Ten kod C# demonstruje proces konwersji PowerPoint do PDF, który tworzy wiele plików PDF w zależności od różnych standardów zgodności:

```c#
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

{{% alert title="Note" color="warning" %}} 
Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/pl/net/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/pl/net/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/pl/net/conversion/pdf-to-jpg/), oraz [PDF do PNG](https://products.aspose.com/slides/pl/net/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/pl/net/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/pl/net/conversion/pdf-to-tiff/), i [PDF do XML](https://products.aspose.com/slides/pl/net/conversion/pdf-to-xml/) — są również wspierane.
{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA Aspose.Slides traktuje złożoną grafikę, taką jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF wsadowo?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Oczywiście. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/) aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Ustaw właściwość `ShowHiddenSlides` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/) na `true`, aby uwzględnić ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides utrzymuje wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazów, ustawiając właściwości takie jak `JpegQuality` i `SufficientResolution` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/), aby zapewnić wysokiej jakości obrazy w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides pozwala eksportować PDFy zgodne z różnymi standardami, w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając, że dokumenty spełniają wymagania dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides dla .NET](/slides/pl/net/)
- [Referencja API Aspose.Slides dla .NET](https://reference.aspose.com/slides/pl/net/)
- [Bezpłatne konwertery online Aspose](https://products.aspose.app/slides/pl/conversion)
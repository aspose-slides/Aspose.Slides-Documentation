---
title: Konwertuj PPT i PPTX do PDF w C++ [Zawarte zaawansowane funkcje]
linktitle: PowerPoint do PDF
type: docs
weight: 40
url: /pl/cpp/convert-powerpoint-to-pdf/
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
- C++
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w C++ przy użyciu Aspose.Slides, z szybkim przykładem kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w C++ oferuje wiele korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolujących jakość obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności do dokumentów wyjściowych.

## **Konwersje PowerPoint do PDF**

Korzystając z Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację na PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF przy użyciu metody `Save`. Klasa [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) udostępnia metodę `Save`, która jest zazwyczaj używana do konwersji prezentacji do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ wstawia informacje o API i numer wersji do dokumentów wyjściowych. Na przykład, podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, że nie możesz nakazać Aspose.Slides zmienić lub usunąć tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Konkretnego slajdu z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF bardzo dokładnie odzwierciedlają oryginalne prezentacje. Elementy i atrybuty są renderowane precyzyjnie podczas konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitu
* Hiperłącza
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwersja PowerPoint do PDF**

Standardowy proces konwersji PowerPoint‑PDF używa domyślnych opcji. W takim wypadku Aspose.Slides stara się przekonwertować podaną prezentację do PDF, stosując optymalne ustawienia przy maksymalnych poziomach jakości.

Ten kod C++ pokazuje, jak przekonwertować prezentację (PPT, PPTX, ODP itp.) do PDF:

```c++
// Instancjonuj klasę Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Zapisz prezentację jako PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przetestować ten konwerter, aby zobaczyć działanie opisanej tutaj procedury.

{{% /alert %}}

## **Konwersja PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia własne opcje — własności klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć go hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwersja PowerPoint do PDF z niestandardowymi opcjami**

Korzystając z niestandardowych opcji konwersji, możesz określić preferowane ustawienia jakości dla obrazów rastrowych, zdefiniować sposób obsługi metafili, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i wiele więcej.

Poniższy przykład kodu demonstruje, jak przekonwertować prezentację PowerPoint do PDF z kilkoma niestandardowymi opcjami.

```c++
// Utwórz instancję klasy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Ustaw jakość obrazów JPG.
pdfOptions->set_JpegQuality(90);

// Ustaw DPI dla obrazów.
pdfOptions->set_SufficientResolution(300);

// Ustaw zachowanie dla metafili.
pdfOptions->set_SaveMetafilesAsPng(true);

// Ustaw poziom kompresji tekstu dla treści tekstowej.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Zdefiniuj tryb zgodności PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Zapisz prezentację jako dokument PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konwersja PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [set_ShowHiddenSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w wynikowym PDF.

Ten kod C++ pokazuje, jak przekonwertować prezentację PowerPoint do PDF z uwzględnionymi ukrytymi slajdami:

```c++
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Utwórz instancję klasy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Dodaj ukryte slajdy.
pdfOptions->set_ShowHiddenSlides(true);

// Zapisz prezentację jako PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konwersja PowerPoint do PDF zabezpieczonego hasłem**

Ten kod C++ demonstruje, jak przekonwertować prezentację PowerPoint do PDF zabezpieczonego hasłem, używając parametrów ochrony klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/):

```c++
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Utwórz instancję klasy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Ustaw hasło PDF oraz uprawnienia dostępu.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Zapisz prezentację jako PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Wykrywanie podstawień czcionek**

Aspose.Slides udostępnia metodę [set_WarningCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveoptions/set_warningcallback/) w ramach klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), umożliwiającą wykrywanie podstawień czcionek podczas konwersji prezentacji do PDF.

Ten kod C++ pokazuje, jak wykrywać podstawienia czcionek:

```c++
// Implementacja wywołania zwrotnego ostrzeżenia.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Ustaw wywołanie zwrotne ostrzeżenia w opcjach PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Zapisz prezentację jako PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

Po więcej informacji o otrzymywaniu wywołań zwrotnych przy podstawieniach czcionek podczas renderowania, zobacz [Getting Warning Callbacks for Fonts Substitution](/slides/pl/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Po więcej informacji o podstawieniach czcionek, zobacz artykuł [Font Substitution](/slides/pl/cpp/font-substitution/).

{{% /alert %}} 

## **Konwersja wybranych slajdów z PowerPoint do PDF**

Ten kod C++ demonstruje, jak przekonwertować tylko wybrane slajdy z prezentacji PowerPoint do PDF:

```C++
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Ustaw tablicę numerów slajdów.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Zapisz prezentację jako PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Konwersja PowerPoint do PDF z własnym rozmiarem slajdu**

Ten kod C++ demonstruje, jak przekonwertować prezentację PowerPoint do PDF z określonym rozmiarem slajdu:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Konwersja PowerPoint do PDF w widoku notatek slajdu**

Ten kod C++ demonstruje, jak przekonwertować prezentację PowerPoint do PDF, który zawiera notatki:

```C++
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Skonfiguruj opcje PDF z układem notatek.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Zapisz prezentację do PDF z notatkami.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Dostępność i standardy zgodności dla PDF**

Aspose.Slides pozwala na użycie procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, stosując dowolny z następujących standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Ten kod C++ demonstruje proces konwersji PowerPoint‑PDF, który tworzy wiele plików PDF w oparciu o różne standardy zgodności:

```C++
auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides wspiera operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-jpg/) oraz [PDF do PNG](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-tiff/), i [PDF do XML](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-xml/) — są również obsługiwane.

{{% /alert %}}

> **Uwaga:** Przy eksportowaniu do PDF/UA, Aspose.Slides traktuje złożoną grafikę, taką jak SmartArt, wykresy i formuły, jako pojedynczą figurę. Poszczególne elementy ścieżek nie są zachowywane jako odrębna treść i mogą być oznaczone jako artefakty; alternatywny tekst jest dostarczany wyłącznie dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo stosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Oczywiście. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Użyj metody `set_ShowHiddenSlides` klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), aby uwzględnić ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides utrzymuje wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazów, korzystając z metod takich jak `set_JpegQuality` i `set_SufficientResolution` klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), aby zagwarantować wysoką jakość obrazów w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides umożliwia eksport PDF zgodnych z różnymi standardami, w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając spełnienie wymagań dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides for C++](/slides/pl/cpp/)
- [Referencja API Aspose.Slides for C++](https://reference.aspose.com/slides/pl/cpp/)
- [Darmowe konwertery online Aspose](https://products.aspose.app/slides/pl/conversion)
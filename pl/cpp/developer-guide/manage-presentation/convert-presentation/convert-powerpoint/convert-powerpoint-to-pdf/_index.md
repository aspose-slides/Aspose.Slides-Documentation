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
description: "Konwertuj PowerPoint PPT/PPTX na wysokiej jakości, przeszukiwalne pliki PDF w C++ przy użyciu Aspose.Slides, z szybkim przykładem kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w C++ oferuje kilka zalet, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania Twojej prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolowania jakości obrazów, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Używając Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF używając metody `Save`. Klasa [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) udostępnia metodę `Save`, która zazwyczaj jest używana do konwersji prezentacji na PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ wstawia informacje o swoim API oraz numer wersji do dokumentów wyjściowych. Na przykład, podczas konwertowania prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga** że nie można nakazać Aspose.Slides zmienić lub usunąć tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całe prezentacje do PDF
* Konkretne slajdy z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF ściśle odpowiadają oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hiperłącza
* Nagłówki i stopki
* Wypunktowanie
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa opcji domyślnych. W tym przypadku Aspose.Slides próbuje przekonwertować podaną prezentację na PDF, wykorzystując optymalne ustawienia przy maksymalnych poziomach jakości.

Ten kod C++ pokazuje, jak przekonwertować prezentację (PPT, PPTX, ODP itp.) na PDF:

```c++
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Zapisz prezentację jako PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przeprowadzić test przy użyciu tego konwertera, aby zobaczyć działanie opisanej tutaj procedury.

{{% /alert %}}

## **Konwertuj PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia własne opcje — właściwości w klasie [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/) — które pozwalają dostosować rezultujący PDF, zabezpieczyć PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z własnymi opcjami**

Korzystając z własnych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metafile, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i wiele innych.

Poniższy przykład kodu demonstruje, jak przekonwertować prezentację PowerPoint do PDF z kilkoma własnymi opcjami.

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

// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Zapisz prezentację jako dokument PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [set_ShowHiddenSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) z klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w powstałym PDF.

Ten kod C++ pokazuje, jak przekonwertować prezentację PowerPoint do PDF z uwzględnieniem ukrytych slajdów:

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

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Ten kod C++ demonstruje, jak przekonwertować prezentację PowerPoint do PDF zabezpieczonego hasłem przy użyciu parametrów ochrony z klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/):

```c++
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Utwórz instancję klasy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Ustaw hasło PDF i uprawnienia dostępu.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Zapisz prezentację jako PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Wykryj podstawienia czcionek**

Aspose.Slides udostępnia metodę [set_WarningCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveoptions/set_warningcallback/) w klasie [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), umożliwiając wykrywanie podstawień czcionek podczas procesu konwersji prezentacji do PDF.

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

    // Ustaw wywołanie zwrotne ostrzeżeń w opcjach PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Zapisz prezentację jako PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

Aby uzyskać więcej informacji o odbieraniu wywołań zwrotnych w przypadku podstawień czcionek podczas procesu renderowania, zobacz [Getting Warning Callbacks for Fonts Substitution](/slides/pl/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Aby dowiedzieć się więcej o podstawieniach czcionek, zobacz artykuł [Font Substitution](/slides/pl/cpp/font-substitution/).

{{% /alert %}} 

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Ten kod C++ demonstruje, jak przekonwertować tylko określone slajdy z prezentacji PowerPoint do PDF:

```C++
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Ustaw tablicę numerów slajdów.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Zapisz prezentację jako PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Konwertuj PowerPoint do PDF z własnym rozmiarem slajdów**

Ten kod C++ demonstruje, jak przekonwertować prezentację PowerPoint do PDF z określonym rozmiarem slajdu:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Utwórz nową prezentację z dostosowanym rozmiarem slajdu.
auto resizedPresentation = MakeObject<Presentation>();

// Ustaw własny rozmiar slajdu.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Sklonuj pierwszy slajd z oryginalnej prezentacji.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Zapisz przeskalowaną prezentację jako PDF z notatkami.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Ten kod C++ demonstruje, jak przekonwertować prezentację PowerPoint do PDF, który zawiera notatki:

```C++
// Utwórz instancję klasy Presentation, która reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Skonfiguruj opcje PDF z układem notatek.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Zapisz prezentację jako PDF z notatkami.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Standardy dostępności i zgodności dla PDF**

Aspose.Slides umożliwia użycie procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF, stosując dowolny z poniższych standardów zgodności: **PDF/A1a**, **PDF/A1b** oraz **PDF/UA**.

Ten kod C++ demonstruje proces konwersji PowerPoint do PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

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

Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF to HTML](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-jpg/) oraz [PDF to PNG](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-png/). Inne operacje konwersji PDF do specjalistycznych formatów — [PDF to SVG](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-tiff/) i [PDF to XML](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-xml/) — są również obsługiwane.

{{% /alert %}}

> **Uwaga:** Podczas eksportowania do PDF/UA, Aspose.Slides traktuje złożoną grafikę, taką jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżki nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednocześnie?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy możliwe jest zabezpieczenie konwertowanego PDF hasłem?**

Oczywiście. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Użyj metody `set_ShowHiddenSlides` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), aby uwzględnić ukryte slajdy w powstałym PDF.

**Czy Aspose.Slides może utrzymać wysoką jakość obrazu w PDF?**

Tak, możesz kontrolować jakość obrazu, używając metod takich jak `set_JpegQuality` i `set_SufficientResolution` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), aby zapewnić wysoką jakość obrazów w PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides umożliwia eksport PDFów zgodnych z różnymi standardami, w tym PDF/A1a, PDF/A1b oraz PDF/UA, zapewniając, że dokumenty spełniają wymagania dotyczące dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides dla C++](/slides/pl/cpp/)
- [Referencja API Aspose.Slides dla C++](https://reference.aspose.com/slides/pl/cpp/)
- [Darmowe konwertery online Aspose](https://products.aspose.app/slides/pl/conversion)
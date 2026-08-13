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
description: "Konwertuj prezentacje PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF w C++ przy użyciu Aspose.Slides, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itd.) do formatu PDF w C++ oferuje kilka korzyści, w tym kompatybilność na różnych urządzeniach oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolujących jakość obrazu, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać substytucje czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Korzystając z Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby przekonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Prezentacja](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) i potem zapisz prezentację jako PDF przy użyciu metody `Save`. Klasa [Prezentacja](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) udostępnia metodę `Save`, która zazwyczaj jest używana do konwersji prezentacji do PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides dla C++ wstawia informacje o API i numer wersji do dokumentów wyjściowych. Na przykład, podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga** że nie możesz nakazać Aspose.Slides zmienić lub usunąć tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Wybranych slajdów z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe dokumenty PDF bardzo dokładnie odwzorowują oryginalne prezentacje. Elementy i atrybuty są renderowane precyzyjnie w konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hiperłącza
* Nagłówki i stopki
* Punktory
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa opcji domyślnych. W tym przypadku Aspose.Slides próbuje przekonwertować podaną prezentację do PDF, używając optymalnych ustawień przy maksymalnej jakości.

Ten kod C++ pokazuje, jak przekonwertować prezentację (PPT, PPTX, ODP itd.) do PDF:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz obiekt klasy Presentation, który reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Zapisz prezentację jako PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 

Aspose oferuje darmowy internetowy **konwerter PowerPoint do PDF**(https://products.aspose.app/slides/pl/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz uruchomić test za pomocą tego konwertera, aby zobaczyć działanie procedury opisanej tutaj.

{{% /alert %}}

## **Konwertuj PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia własne opcje — właściwości w klasie [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć PDF hasłem lub określić sposób przeprowadzania procesu konwersji.

### **Konwertuj PowerPoint do PDF z własnymi opcjami**

Korzystając z własnych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metafili, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i nie tylko.

Poniższy przykład kodu demonstruje, jak przekonwertować prezentację PowerPoint do PDF z kilkoma własnymi opcjami.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz obiekt klasy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Ustaw jakość obrazów JPG.
pdfOptions->set_JpegQuality(90);

// Ustaw DPI dla obrazów.
pdfOptions->set_SufficientResolution(300);

// Ustaw zachowanie dla metafili.
pdfOptions->set_SaveMetafilesAsPng(true);

// Ustaw poziom kompresji tekstu dla zawartości tekstowej.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Zdefiniuj tryb zgodności PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Utwórz obiekt klasy Presentation, który reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Zapisz prezentację jako dokument PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [set_ShowHiddenSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) z klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w powstałym PDF.

Ten kod C++ pokazuje, jak przekonwertować prezentację PowerPoint do PDF z uwzględnieniem ukrytych slajdów:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz obiekt klasy Presentation, który reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Utwórz obiekt klasy PdfOptions.
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
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz obiekt klasy Presentation, który reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Utwórz obiekt klasy PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Ustaw hasło PDF i uprawnienia dostępu.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Zapisz prezentację jako PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Wykrywanie substytucji czcionek**

Aspose.Slides udostępnia metodę [set_WarningCallback](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveoptions/set_warningcallback/) w ramach klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), umożliwiając wykrywanie substytucji czcionek podczas procesu konwersji prezentacji do PDF.

Ten kod C++ pokazuje, jak wykrywać substytucje czcionek:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

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
    // Utwórz obiekt klasy Presentation, który reprezentuje plik PowerPoint lub OpenDocument.
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

{{%  alert color="info"  %}} 

Po więcej informacji o otrzymywaniu wywołań zwrotnych ostrzeżeń o substytucji czcionek podczas procesu renderowania, zobacz [Otrzymywanie wywołań zwrotnych ostrzeżeń o substytucji czcionek](/slides/pl/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Po więcej informacji o substytucji czcionek, zobacz artykuł [Substytucja czcionek](/slides/pl/cpp/font-substitution/).

{{% /alert %}} 

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Ten kod C++ demonstruje, jak przekonwertować tylko wybrane slajdy z prezentacji PowerPoint do PDF:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz obiekt klasy Presentation, który reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Ustaw tablicę numerów slajdów.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Zapisz prezentację jako PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Konwertuj PowerPoint do PDF z własnym rozmiarem slajdu**

Ten kod C++ demonstruje, jak przekonwertować prezentację PowerPoint do PDF z określonym rozmiarem slajdu:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// Utwórz obiekt klasy Presentation, który reprezentuje plik PowerPoint lub OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Utwórz nową prezentację z dostosowanym rozmiarem slajdu.
auto resizedPresentation = MakeObject<Presentation>();

// Ustaw niestandardowy rozmiar slajdu.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Sklonuj pierwszy slajd z oryginalnej prezentacji.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Zapisz zmienioną rozmiarowo prezentację jako PDF z notatkami.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Ten kod C++ demonstruje, jak przekonwertować prezentację PowerPoint do PDF zawierającego notatki:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Utwórz obiekt klasy Presentation, który reprezentuje plik PowerPoint lub OpenDocument.
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

Aspose.Slides umożliwia użycie procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz wyeksportować dokument PowerPoint do PDF używając dowolnego z tych standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Ten kod C++ demonstruje proces konwersji PowerPoint do PDF, który tworzy wiele plików PDF w oparciu o różne standardy zgodności:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-jpg/), i [PDF do PNG](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF do SVG](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-tiff/), i [PDF do XML](https://products.aspose.com/slides/pl/cpp/conversion/pdf-to-xml/) — są również wspierane.

{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożoną grafikę, taką jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielne treści i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany tylko dla całej figury.

## **FAQ**

### Czy mogę konwertować wiele plików PowerPoint na PDF jednocześnie?

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

### Czy można zabezpieczyć konwertowany PDF hasłem?

Oczywiście. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/) aby ustawić hasło i określić uprawnienia dostępu w trakcie procesu konwersji.

### Jak włączyć ukryte slajdy do PDF?

Użyj metody `set_ShowHiddenSlides` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), aby uwzględnić ukryte slajdy w powstałym PDF.

### Czy Aspose.Slides może utrzymać wysoką jakość obrazu w PDF?

Tak, możesz kontrolować jakość obrazu, używając metod takich jak `set_JpegQuality` i `set_SufficientResolution` w klasie [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), aby zapewnić wysokiej jakości obrazy w swoim PDF.

### Czy Aspose.Slides obsługuje standardy zgodności PDF/A?

Tak, Aspose.Slides pozwala eksportować PDFy zgodne z różnymi standardami, w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając, że Twoje dokumenty spełniają wymagania dotyczące dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Aspose.Slides dla C++ Dokumentacja](/slides/pl/cpp/)
- [Aspose.Slides dla C++ – odniesienie API](https://reference.aspose.com/slides/pl/cpp/)
- [Aspose darmowe konwertery online](https://products.aspose.app/slides/pl/conversion)
---
title: Konwertuj PPT i PPTX do PDF w C++ [Zawarte Zaawansowane Funkcje]
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
- załącznik
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Konwertuj PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF w C++ przy użyciu Aspose.Slides, z szybkim przykładem kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w języku C++ oferuje kilka zalet, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Ten przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolowania jakości obrazu, włączać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać zamiany czcionek, wybierać określone slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Korzystając z Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF, używając metody [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Klasa [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) udostępnia metodę [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/), która zazwyczaj służy do konwersji prezentacji do PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides dla C++ wstawia informacje o API oraz numer wersji do dokumentów wyjściowych. Na przykład podczas konwersji prezentacji do PDF, Aspose.Slides wypełnia pole Application wartością „*Aspose.Slides*”, a pole PDF Producer wartością w formacie „*Aspose.Slides v XX.XX*”. **Uwaga** że nie można nakazać Aspose.Slides zmienić ani usunąć tych informacji z dokumentów wyjściowych.
{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całe prezentacje do PDF
* Poszczególne slajdy z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF ściśle odpowiadają oryginalnym prezentacjom. Elementy i atrybuty są renderowane dokładnie podczas konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitu
* Hiperdłącza
* Nagłówki i stopki
* Punktory
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint do PDF używa domyślnych opcji. W tym przypadku Aspose.Slides próbuje konwertować podaną prezentację do PDF, używając optymalnych ustawień przy maksymalnych poziomach jakości.

Poniższy przykład ładuje prezentację i zapisuje wszystkie widoczne slajdy do PDF, używając domyślnych ustawień eksportu.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose oferuje bezpłatny internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przeprowadzić test z użyciem tego konwertera, aby zobaczyć działanie opisanego tutaj procesu.
{{% /alert %}}

## **Konwertuj PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia niestandardowe opcje — właściwości w klasie [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — które pozwalają dostosować powstały PDF, zabezpieczyć PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z niestandardowymi opcjami**

Korzystając z niestandardowych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, określić sposób obsługi metaplików, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i wiele innych.

Poniższy przykład eksportuje prezentację do PDF 1.5 z jakością JPEG ustawioną na 90, rozdzielczością obrazu 300 DPI, metaplikami zapisywanymi jako PNG oraz kompresją tekstu Flate.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Zachowaj osadzone pliki OLE jako załączniki PDF**

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mogli uzyskać dostęp do danych skoroszytu oraz przeglądać slajdy. Wywołaj [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) z wartością `true`, aby zachować osadzone pliki OLE jako załączniki w powstałym PDF.

Domyślną wartością jest `false`: podgląd obrazu lub ikona obiektu OLE jest renderowana na stronie PDF, ale jego osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `true` dodatkowo dołącza dane pliku. Podgląd pozostaje wizualną reprezentacją; załącznik umożliwia odbiorcom otwarcie lub zapisanie osadzonego pliku osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład ładuje prezentację, która już zawiera osadzony skoroszyt Excel, i eksportuje ją do PDF z dołączonym skoroszytem.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Aby sprawdzić wynik:

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki, takiej jak Adobe Acrobat Reader.
2. Otwórz panel **Attachments** przeglądarki i zlokalizuj osadzony skoroszyt.
3. Zapisz załącznik i otwórz go w Excelu, aby sprawdzić jego dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Note" %}}
Standardy PDF/A nakładają ograniczenia dotyczące załączników: PDF/A-1 zakazuje osadzonych plików, PDF/A-2 zezwala tylko na załączniki PDF/A, a PDF/A-3 dopuszcza inne typy plików, w tym skoroszyty Excel. Są to wymogi standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.
{{% /alert %}}

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) z klasy [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby uwzględnić ukryte slajdy jako strony w powstałym PDF.

Poniższy przykład eksportuje prezentację do PDF, uwzględniając wszystkie ukryte slajdy.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Konwertuj PowerPoint do PDF zabezpieczonego hasłem**

Poniższy przykład eksportuje prezentację do PDF, które wymaga hasła `password` do otwarcia. Uprawnienia dostępu umożliwiają drukowanie, w tym drukowanie w wysokiej jakości.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Wykryj zamiany czcionek**

Aspose.Slides udostępnia metodę [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) w klasie [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), umożliwiającą wykrywanie zamian czcionek podczas procesu konwersji prezentacji do PDF.

Poniższy przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o zamianie czcionek w konsoli. Ostrzeżenie jest wypisywane tylko wtedy, gdy podczas eksportu zostanie zastąpiona niedostępna czcionka.

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aby uzyskać więcej informacji o zamianie czcionek, zobacz artykuł [Zamiana czcionek](/slides/pl/cpp/font-substitution/).
{{% /alert %}}

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Poniższy przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numery slajdów w tej tablicy są numerowane od jednego, a wejściowa prezentacja musi zawierać co najmniej trzy slajdy.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **Konwertuj PowerPoint do PDF z własnym rozmiarem slajdu**

Poniższy przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skaluje zawartość slajdu, aby dopasować ją, i eksportuje pojedynczy slajd do PDF.

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Konwertuj PowerPoint do PDF w widoku notatek slajdu**

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta każdego slajdu pod slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć rezultat.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Standardy dostępności i zgodności PDF**

Aspose.Slides umożliwia użycie procedury konwersji, która jest zgodna z [Wytyczne dostępności treści internetowych (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz eksportować dokument PowerPoint do PDF, używając dowolnego z tych standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Ten kod C++ demonstruje proces konwersji PowerPoint do PDF, który generuje wiele plików PDF w oparciu o różne standardy zgodności:

```cpp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF do HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF do obrazu](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF do JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), oraz [PDF do PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Inne operacje konwersji PDF do specjalistycznych formatów — [PDF do SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF do TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), i [PDF do XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — są również obsługiwane.
{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA Aspose.Slides traktuje złożone grafiki, takie jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżek nie są zachowywane jako oddzielna zawartość i mogą być oznaczone jako artefakty; alternatywny tekst jest dostarczany tylko dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednorazowo?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy można zabezpieczyć konwertowany PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak włączyć ukryte slajdy w PDF?**

Użyj metody [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) w klasie [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby włączyć ukryte slajdy w powstałym PDF.

**Czy Aspose.Slides może utrzymać wysoką jakość obrazu w PDF?**

Tak, możesz kontrolować jakość obrazu, używając metod takich jak [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) i [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) w klasie [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby zapewnić wysokiej jakości obrazy w swoim PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides umożliwia eksport PDF, które są zgodne z różnymi standardami, w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając, że dokumenty spełniają wymagania dotyczące dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Dokumentacja Aspose.Slides dla C++](/slides/pl/cpp/)
- [Odniesienie API Aspose.Slides dla C++](https://reference.aspose.com/slides/cpp/)
- [Bezpłatne konwertery online Aspose](https://products.aspose.app/slides/conversion)
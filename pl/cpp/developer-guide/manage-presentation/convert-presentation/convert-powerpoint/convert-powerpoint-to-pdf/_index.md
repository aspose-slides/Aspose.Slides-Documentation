---
title: Konwertuj PPT i PPTX do PDF w C++ [Zawarte funkcje zaawansowane]
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
description: "Konwertuj prezentacje PowerPoint PPT/PPTX do wysokiej jakości, przeszukiwalnych plików PDF w C++ przy użyciu Aspose.Slides, z szybkimi przykładami kodu i zaawansowanymi opcjami konwersji."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint (PPT, PPTX, ODP itp.) do formatu PDF w C++ oferuje kilka korzyści, w tym kompatybilność z różnymi urządzeniami oraz zachowanie układu i formatowania prezentacji. Niniejszy przewodnik pokazuje, jak konwertować prezentacje do dokumentów PDF, używać różnych opcji kontrolujących jakość obrazu, uwzględniać ukryte slajdy, zabezpieczać pliki PDF hasłem, wykrywać podstawienia czcionek, wybierać konkretne slajdy do konwersji oraz stosować standardy zgodności w dokumentach wyjściowych.

## **Konwersje PowerPoint do PDF**

Korzystając z Aspose.Slides, możesz konwertować prezentacje w następujących formatach do PDF:

* **PPT**
* **PPTX**
* **ODP**

Aby skonwertować prezentację do PDF, przekaż nazwę pliku jako argument do klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) i następnie zapisz prezentację jako PDF przy użyciu metody [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Klasa [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) udostępnia metodę [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/), która zazwyczaj jest używana do konwersji prezentacji do PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for C++ wstawia informacje o swojej API oraz numer wersji do dokumentów wyjściowych. Na przykład podczas konwersji prezentacji do PDF Aspose.Slides wypełnia pole Application wartością "*Aspose.Slides*" oraz pole PDF Producer wartością w formacie "*Aspose.Slides v XX.XX*". **Uwaga**, nie możesz nakazać Aspose.Slides zmiany lub usunięcia tych informacji z dokumentów wyjściowych.

{{% /alert %}}

Aspose.Slides umożliwia konwersję:

* Całych prezentacji do PDF
* Konkretnego slajdu (lub slajdów) z prezentacji do PDF

Aspose.Slides eksportuje prezentacje do PDF, zapewniając, że powstałe pliki PDF bardzo dokładnie odzwierciedlają oryginalne prezentacje. Elementy i atrybuty są renderowane precyzyjnie podczas konwersji, w tym:

* Obrazy
* Pola tekstowe i kształty
* Formatowanie tekstu
* Formatowanie akapitów
* Hyperlinki
* Nagłówki i stopki
* Wypunktowania
* Tabele

## **Konwertuj PowerPoint do PDF**

Standardowy proces konwersji PowerPoint‑do‑PDF używa domyślnych opcji. W takim przypadku Aspose.Slides próbuje skonwertować podaną prezentację do PDF przy użyciu optymalnych ustawień i maksymalnej jakości.

Poniższy przykład wczytuje prezentację i zapisuje wszystkie widoczne slajdy do PDF używając domyślnych ustawień eksportu.

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

Aspose oferuje darmowy internetowy [**konwerter PowerPoint do PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf), który demonstruje proces konwersji prezentacji do PDF. Możesz przetestować ten konwerter, aby zobaczyć działanie procedury opisanej tutaj.

{{% /alert %}}

## **Konwertuj PowerPoint do PDF z opcjami**

Aspose.Slides udostępnia własne opcje — właściwości klasy [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — które pozwalają dostosować wynikowy PDF, zabezpieczyć PDF hasłem lub określić, jak ma przebiegać proces konwersji.

### **Konwertuj PowerPoint do PDF z niestandardowymi opcjami**

Korzystając z własnych opcji konwersji, możesz określić preferowane ustawienie jakości dla obrazów rastrowych, zdefiniować sposób obsługi metaplików, ustawić poziom kompresji tekstu, skonfigurować DPI dla obrazów i nie tylko.

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

Jeśli prezentacja zawiera osadzony skoroszyt Excel, możesz chcieć, aby odbiorcy PDF mieli dostęp do danych skoroszytu oraz mogli przeglądać slajdy. Wywołaj [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) z wartością `true`, aby zachować osadzone pliki OLE jako załączniki w wynikowym PDF.

Domyślna wartość to `false`: podglądowy obraz lub ikona obiektu OLE jest renderowana na stronie PDF, ale osadzony plik nie jest dołączany jako załącznik. Ustawienie opcji na `true` dodatkowo dołącza dane pliku. Podgląd pozostaje wizualną reprezentacją; załącznik umożliwia odbiorcom otwarcie lub zapisanie osadzonego pliku osobno. Obiekt OLE nie staje się interaktywnym arkuszem Excel na stronie PDF.

Poniższy przykład wczytuje prezentację już zawierającą osadzony skoroszyt Excel i eksportuje ją do PDF z załączonym skoroszytem.

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

1. Otwórz wyeksportowany PDF w przeglądarce obsługującej załączniki, np. Adobe Acrobat Reader.
2. Otwórz panel **Attachments** i zlokalizuj osadzony skoroszyt.
3. Zapisz załącznik i otwórz go w Excelu, aby sprawdzić dane, lub otwórz go bezpośrednio, jeśli przeglądarka na to pozwala. Podgląd na stronie PDF jest oddzielny od załącznika.

{{% alert color="info" title="Note" %}}

Standardy PDF/A nakładają ograniczenia na załączniki: PDF/A‑1 zabrania osadzania plików, PDF/A‑2 zezwala wyłącznie na załączniki PDF/A, a PDF/A‑3 dopuszcza inne typy plików, w tym skoroszyty Excel. Są to wymogi standardów, a nie ograniczenia specyficzne dla Aspose.Slides. Ten przykład używa domyślnego ustawienia zgodności PDF i nie demonstruje eksportu PDF/A.

{{% /alert %}}

### **Konwertuj PowerPoint do PDF z ukrytymi slajdami**

Jeśli prezentacja zawiera ukryte slajdy, możesz użyć metody [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) klasy [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby włączyć ukryte slajdy jako strony w wynikowym PDF.

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

Poniższy przykład eksportuje prezentację do PDF, który wymaga hasła `password` przy otwieraniu. Uprawnienia dostępu zezwalają na drukowanie, w tym drukowanie w wysokiej jakości.

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

### **Wykryj podstawienia czcionek**

Aspose.Slides udostępnia metodę [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) klasy [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), umożliwiającą wykrycie podstawień czcionek podczas procesu konwersji prezentacji do PDF.

Poniższy przykład eksportuje prezentację do PDF i wypisuje ostrzeżenia o podstawieniach czcionek na konsolę. Ostrzeżenie jest wypisywane tylko wtedy, gdy podczas eksportu zostaje zastąpiona niedostępna czcionka.

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

Więcej informacji o podstawieniach czcionek znajdziesz w artykule [Font Substitution](/slides/pl/cpp/font-substitution/).

{{% /alert %}} 

### **Obsługa czcionek bez dedykowanego kroju pogrubionego**

Prezentacja może stosować pogrubienie tekstu, nawet jeśli czcionka nie posiada dedykowanego kroju pogrubionego. Tekst może wyglądać na pogrubiony dzięki syntetycznemu pogrubieniu, które sztucznie zagęszcza zwykłe glify. Gdy taki tekst wydaje się zbyt ciężki lub inaczej wygląda niż zamierzono w PDF, spróbuj wywołać [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) z wartością `true`. Opcja ta renderuje dotknięty tekst jako bitmapę podczas eksportu do PDF i może poprawić jego wygląd dla niektórych czcionek. Domyślna wartość to `false`.

Przykładowa prezentacja zawiera dwa pola tekstowe: jedno z tekstem zwykłym i drugie z pogrubionym formatowaniem tej samej czcionki, która nie ma dedykowanego kroju pogrubionego. Poniższy przykład wczytuje prezentację, włącza rasteryzację nieobsługiwanych stylów czcionek i eksportuje ją do PDF:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Poniższe podglądy przedstawiają wynik przy wyłączonej i włączonej opcji. W tym przykładzie tekst pogrubiony ma cięższe linie przy wyłączonej opcji. Po włączeniu opcji jego linie są lżejsze; tekst zwykły pozostaje niezmieniony. Porównaj wyniki przed podjęciem decyzji o ustawieniu dla własnej prezentacji.

| Opcja wyłączona (`false`, domyślna) | Opcja włączona (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

W tym przykładzie włączenie opcji przekształca wyłącznie pogrubiony tekst w bitmapę: nie może być zaznaczony, kopiowany ani przeszukiwany jako tekst bez OCR, a jego krawędzie wyglądają miękko przy 800 % powiększeniu. Tekst zwykły pozostaje przeszukiwalny. Przy wyłączonej opcji oba ciągi pozostają tekstem.

Ta opcja rasteryzuje tekst sformatowany jako pogrubiony, gdy jego czcionka nie ma dedykowanego kroju pogrubionego. [Font substitution](/slides/pl/cpp/font-substitution/) zamiast tego wybiera inną czcionkę, gdy oryginalna jest niedostępna.

## **Konwertuj wybrane slajdy z PowerPoint do PDF**

Poniższy przykład eksportuje slajdy 1 i 3 z prezentacji do PDF. Numery slajdów w tej tablicy są numerowane od 1, a prezentacja wejściowa musi zawierać co najmniej trzy slajdy.

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

## **Konwertuj PowerPoint do PDF z niestandardowym rozmiarem slajdu**

Poniższy przykład kopiuje pierwszy slajd z prezentacji do nowej prezentacji o rozmiarze slajdu 612 × 792 punktów (8,5 × 11 cali). Skaluję zawartość slajdu, aby pasowała, i eksportuję pojedynczy slajd do PDF.

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

Poniższy przykład eksportuje prezentację do PDF, umieszczając notatki prelegenta każdego slajdu pod samym slajdem. Użyj prezentacji zawierającej notatki prelegenta, aby zobaczyć rezultat.

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

## **Dostępność i standardy zgodności dla PDF**

Aspose.Slides pozwala używać procedury konwersji zgodnej z [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Możesz eksportować dokument PowerPoint do PDF przy użyciu dowolnego z tych standardów zgodności: **PDF/A1a**, **PDF/A1b** i **PDF/UA**.

Ten kod C++ demonstruje proces konwersji PowerPoint‑do‑PDF, który tworzy wiele plików PDF na podstawie różnych standardów zgodności:

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

Aspose.Slides obsługuje operacje konwersji PDF, umożliwiając konwersję plików PDF do popularnych formatów. Możesz wykonać konwersje [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) i [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Inne operacje konwersji PDF do formatów specjalistycznych — [PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), oraz [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — są również wspierane.

{{% /alert %}}

> **Uwaga:** Podczas eksportu do PDF/UA, Aspose.Slides traktuje złożoną grafikę, taką jak SmartArt, wykresy i formuły, jako jedną figurę. Poszczególne elementy ścieżki nie są zachowywane jako oddzielna treść i mogą być oznaczone jako artefakty; tekst alternatywny jest dostarczany wyłącznie dla całej figury.

## **FAQ**

**Czy mogę konwertować wiele plików PowerPoint do PDF jednorazowo?**

Tak, Aspose.Slides obsługuje konwersję wsadową wielu plików PPT lub PPTX do PDF. Możesz iterować po swoich plikach i programowo zastosować proces konwersji.

**Czy istnieje możliwość zabezpieczenia konwertowanego PDF hasłem?**

Tak. Użyj klasy [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby ustawić hasło i określić uprawnienia dostępu podczas procesu konwersji.

**Jak uwzględnić ukryte slajdy w PDF?**

Użyj metody [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) w klasie [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby włączyć ukryte slajdy w wynikowym PDF.

**Czy Aspose.Slides utrzymuje wysoką jakość obrazów w PDF?**

Tak, możesz kontrolować jakość obrazów, używając metod takich jak [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) i [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) w klasie [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), aby zapewnić wysoką jakość obrazów w swoim PDF.

**Czy Aspose.Slides obsługuje standardy zgodności PDF/A?**

Tak, Aspose.Slides pozwala eksportować PDF, które spełniają różne standardy, w tym PDF/A1a, PDF/A1b i PDF/UA, zapewniając, że Twoje dokumenty spełniają wymogi dostępności i archiwizacji.

## **Dodatkowe zasoby**

- [Aspose.Slides for C++ Documentation](/slides/pl/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)
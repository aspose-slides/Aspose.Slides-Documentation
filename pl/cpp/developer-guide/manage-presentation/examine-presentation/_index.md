---
title: Pobieranie i aktualizacja informacji o prezentacji w C++
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/cpp/examine-presentation/
keywords:
- format prezentacji
- właściwości prezentacji
- właściwości dokumentu
- pobieranie właściwości
- odczytywanie właściwości
- zmiana właściwości
- modyfikacja właściwości
- aktualizacja właściwości
- przeglądanie PPTX
- przeglądanie PPT
- przeglądanie ODP
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu C++, aby uzyskać szybsze wnioski i inteligentniejsze audyty zawartości."
---
## **Przegląd**

Aspose.Slides może określić format prezentacji i odczytać jej metadane dokumentu bez tworzenia pełnego modelu obiektu prezentacji. Jest to przydatne, gdy trzeba sklasyfikować pliki, zbudować inwentaryzację lub sprawdzić właściwości przed podjęciem decyzji o załadowaniu i przetworzeniu zawartości prezentacji.

Ten artykuł pokazuje lekką inspekcję przy użyciu [PresentationFactory](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentationfactory/) i [IPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/), a także ukierunkowane aktualizacje przy użyciu [IDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/).

## **Sprawdzenie formatu prezentacji**

Użyj [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/), aby zbadać plik bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/). Metoda [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/get_loadformat/) zwraca wykryty format, taki jak PPTX, PPT lub ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Budowanie lekkiej inwentaryzacji prezentacji**

Gdy przetwarzasz wiele plików prezentacji, możesz potrzebować zwartej inwentaryzacji do walidacji, indeksowania lub systemu zarządzania dokumentami. W takim scenariuszu użyj [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/), aby uzyskać obiekt [IPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/), a następnie wywołaj [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), aby odczytać metadane dokumentu. To podejście nie tworzy instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) ani nie wymaga przeglądania pełnego modelu obiektu prezentacji.

Rozszerzone właściwości udostępniane przez [IDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/) zapewniają następujące wartości inwentaryzacji:

| Metoda | Wartość inwentaryzacji |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/get_slides/) | Łączna liczba slajdów. |
| [get_HiddenSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Liczba ukrytych slajdów. |
| [get_Notes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/get_notes/) | Liczba slajdów zawierających notatki. |
| [get_Paragraphs](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Łączna liczba akapitów, jeśli dostępna. |
| [get_Words](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/get_words/) | Łączna liczba słów. |
| [get_MultimediaClips](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Łączna liczba klipów audio i wideo. |

Poniższy przykład odczytuje te wartości bez tworzenia obiektu [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) i wyświetla zwartą inwentaryzację. Łączy również [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/get_headingpairs/) z [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/get_titlesofparts/), aby wyświetlić grupy treści, takie jak czcionki, motywy i tytuły slajdów.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Każdy [IHeadingPair](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iheadingpair/) dostarcza nazwę grupy przez [IHeadingPair::get_Name](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iheadingpair/get_name/) oraz liczbę elementów w tej grupie przez [IHeadingPair::get_Count](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) zwraca płaską, uporządkowaną tablicę, więc należy pobrać liczbę kolejnych tytułów określoną przez każdy nagłówek.

### **Przechowywane metadane i ograniczenia formatu**

Właściwości inwentaryzacji zwracane przez [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) odzwierciedlają metadane dostępne w źródłowym dokumencie. Aspose.Slides nie ładuje i nie przegląda modelu obiektu prezentacji, aby przeliczyć te wartości przy tym wywołaniu. Brakujące właściwości są reprezentowane przez wartości domyślne, a przechowywane wartości mogą być nieaktualne, jeśli aplikacja ostatnio zapisująca plik nie zaktualizowała ich właściwości dokumentu.

- **PPTX:** Format udostępnia rozszerzone właściwości dokumentu dla liczby slajdów, notatek, ukrytych slajdów, akapitów, słów i multimediów, a także par nagłówków i tytułów części. Dostępność zależy od tego, które właściwości zostały zapisane przez twórcę dokumentu.
- **PPT:** Format binarny może przechowywać odpowiadające właściwości podsumowania dokumentu. Jeśli właściwość jest nieobecna lub nie została odświeżona przez twórcę dokumentu, Aspose.Slides zwraca jej przechowywaną lub domyślną wartość, zamiast obliczać ją na podstawie slajdów.
- **ODP:** Metadane OpenDocument dostarczają ogólne statystyki dokumentu, takie jak liczba stron, akapitów i słów, ale te wartości nie mapują na wszystkie rozszerzone właściwości specyficzne dla PowerPoint. Metadane dotyczące ukrytych slajdów, notatek, multimediów, par nagłówków i tytułów części mogą być niedostępne, a właściwości inwentaryzacji mogą zwracać wartości domyślne. Nie traktuj zerowej wartości ani pustej tablicy jako ostatecznego dowodu, że odpowiadająca treść nie występuje.

Używaj lekkiego podejścia do metadanych przy tworzeniu inwentaryzacji i wstępnych kontroli. Ładuj prezentację i sprawdzaj jej żywy model obiektu, gdy wynik musi odzwierciedlać zmiany w pamięci lub gdy musisz zweryfikować rzeczywistą zawartość prezentacji.

## **Aktualizacja właściwości prezentacji**

Właściwości zwracane przez [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) można również zmienić bez tworzenia instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/). Zastosuj zmiany przy pomocy [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), a następnie zapisz powiązaną prezentację przy użyciu [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

Poniższy obraz przedstawia oryginalne właściwości dokumentu.

![Original document properties of the PowerPoint presentation](input_properties.png)

Poniższy przykład zmienia tytuł oraz czas ostatniego zapisu i zapisuje wynik do nowego pliku:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

Poniższy obraz przedstawia zaktualizowane właściwości dokumentu.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Przydatne linki**

Po związane z kontrolami bezpieczeństwa i ustawieniami ochrony znajdziesz w następujących artykułach:

- [Password-Protect Presentations](/slides/pl/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/pl/cpp/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Załaduj prezentację i użyj [Presentation::get_FontsManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_fontsmanager/). Wywołaj [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getembeddedfonts/), aby uzyskać osadzone czcionki, oraz [FontsManager::GetFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getfonts/), aby uzyskać czcionki używane w prezentacji. Porównaj oba wyniki, aby znaleźć czcionki wymagane do renderowania, które nie są osadzone.

**Jak szybko sprawdzić, czy plik ma ukryte slajdy i ile ich jest?**

Gdy przechowywane metadane dokumentu są wystarczające, odczytaj [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) poprzez [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) i [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). To rozwiązanie nadaje się do lekkiej inwentaryzacji. Jeśli prezentacja została zmodyfikowana w pamięci, przechowywane metadane mogą być brakujące lub nieaktualne, lub potrzebujesz zweryfikować bieżące wartości – w takim wypadku iteruj przez [Presentation::get_Slides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_slides/) i sprawdzaj metodę [Slide::get_Hidden](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/get_hidden/) każdego slajdu.

**Czy mogę wykryć, czy użyto niestandardowego rozmiaru i orientacji slajdu oraz czy różnią się od domyślnych?**

Tak. Załaduj prezentację i odczytaj [Presentation::get_SlideSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_slidesize/). Zbadaj [ISlideSize::get_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidesize/get_size/) i [ISlideSize::get_Orientation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidesize/get_orientation/), aby porównać bieżące ustawienia z oczekiwanymi domyślnymi i wymiarami.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Znajdź każdy [Chart](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chart/) i sprawdź [ChartData::get_DataSourceType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Dla zewnętrznego skoroszytu odczytaj [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Typ źródła danych i ścieżka identyfikują zewnętrzne odwołanie, ale weryfikacja dostępności docelowego pliku wymaga osobnego sprawdzenia zasobów.

**Jak ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Nie istnieje pojedyncza właściwość opisująca złożoność. Przeglądaj [Presentation::get_Slides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_slides/) oraz kolekcję [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/get_shapes/) każdego slajdu. Używaj liczby kształtów oraz obecności dużych obrazów, efektów, animacji lub multimediów jako wskaźników przeglądowych i zmierz reprezentatywne renderowanie lub eksport, zanim uznasz slajd za potwierdzony wąski gardło wydajności.
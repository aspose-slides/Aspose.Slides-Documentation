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
- analiza PPTX
- analiza PPT
- analiza ODP
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Eksploruj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu C++, aby uzyskać szybszy wgląd i inteligentniejsze audyty treści."
---
## **Przegląd**

Ten artykuł pokazuje, jak sprawdzić informacje o prezentacji w Aspose.Slides. Wyjaśnia, jak określić aktualny format prezentacji bez ładowania całego pliku, odczytać jej właściwości dokumentu oraz zaktualizować te właściwości w razie potrzeby.

Przykłady oparte są na API [PresentationInfo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentationinfo/) i [DocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/documentproperties/) oraz demonstrują typowe operacje związane z metadanymi prezentacji.

## **Sprawdź format prezentacji**

Zanim zaczniesz pracę nad prezentacją, możesz chcieć dowiedzieć się, w jakim formacie (PPT, PPTX, ODP i inne) znajduje się ona w danym momencie.

Możesz sprawdzić format prezentacji bez jej ładowania. Zobacz ten kod C++:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Pobierz właściwości prezentacji**

Ten kod C++ pokazuje, jak uzyskać właściwości prezentacji (informacje o prezentacji):

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```

## **Zaktualizuj właściwości prezentacji**

Aspose.Slides udostępnia metodę [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentationinfo/updatedocumentproperties/), która pozwala wprowadzić zmiany w właściwościach prezentacji.

Załóżmy, że mamy prezentację PowerPoint z właściwościami dokumentu pokazanymi poniżej.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Ten przykład kodu pokazuje, jak edytować niektóre właściwości prezentacji:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Wyniki zmiany właściwości dokumentu są pokazane poniżej.

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Aby uzyskać więcej informacji o prezentacji i jej atrybutach zabezpieczeń, przydatne mogą być następujące linki:

- [Prezentacje chronione hasłem](/slides/pl/cpp/password-protected-presentation/)
- [Prezentacje chronione przed zapisem](/slides/pl/cpp/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Poszukaj informacji o [embedded-font](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getembeddedfonts/) na poziomie prezentacji, a następnie porównaj te wpisy z zestawem [czcionek faktycznie używanych w treści](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getfonts/), aby określić, które czcionki są kluczowe dla renderowania.

**Jak szybko stwierdzić, czy plik zawiera ukryte slajdy i ile ich jest?**

Iteruj po [kolekcji slajdów](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidecollection/) i sprawdzaj flagę [widoczności każdego slajdu](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/get_hidden/).

**Czy mogę wykryć, czy użyto niestandardowego rozmiaru i orientacji slajdu oraz czy różnią się od domyślnych?**

Tak. Porównaj bieżący [rozmiar i orientację slajdu](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_slidesize/) ze standardowymi ustawieniami; pomoże to przewidzieć zachowanie przy drukowaniu i eksporcie.

**Czy istnieje szybki sposób sprawdzenia, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Przejdź przez wszystkie [wykresy](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chart/), sprawdź ich [źródło danych](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) i zanotuj, czy dane są wewnętrzne, czy oparte na linku, włączając ewentualne zerwane linki.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Dla każdego slajdu zlicz liczbę obiektów i szukaj dużych obrazów, przezroczystości, cieni, animacji oraz multimediów; przyznaj przybliżoną ocenę złożoności, aby zaznaczyć potencjalne wąskie gardła wydajności.
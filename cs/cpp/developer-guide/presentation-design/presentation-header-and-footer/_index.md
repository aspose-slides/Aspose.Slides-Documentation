---
title: Správa záhlaví a patiček prezentace v C++
linktitle: Záhlaví a patička
type: docs
weight: 140
url: /cs/cpp/presentation-header-and-footer/
keywords:
- záhlaví
- text záhlaví
- patička
- text patičky
- nastavit záhlaví
- nastavit patičku
- výtisk
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak spravovat zástupné symboly patičky, data‑času, čísla snímku a záhlaví na snímcích, stránkách poznámek a výtiscích pomocí Aspose.Slides pro C++."
---
## **Přehled**

PowerPoint používá různé zástupné symboly záhlaví a patičky v závislosti na typu stránky. Aspose.Slides pro C++ vám umožňuje řídit text a viditelnost těchto zástupných symbolů pomocí rozhraní správců záhlaví/patičky.

Dostupné zástupné symboly závisí na rozsahu:

| Rozsah | Záhlaví | Patička | Datum/čas | Číslo snímku/stránky |
|---|---|---|---|---|
| Normální snímek | Ne | Ano | Ano | Ano |
| Poznámkový master | Ano | Ano | Ano | Ano |
| Poznámkový snímek | Ano | Ano | Ano | Ano |
| Výtiskový master | Ano | Ano | Ano | Ano |

Normální snímek prezentace nemá zástupný symbol záhlaví. Záhlaví jsou k dispozici na stránkách poznámek a výtiscích. Pro normální snímky použijte místo toho zástupné symboly patičky, datum/čas a číslo snímku.

Rozsah změny závisí na použitém správci. Rozhraní [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideheaderfootermanager/) řídí jeden normální snímek. Rozhraní [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inotesslideheaderfootermanager/) řídí jeden snímek poznámek. Správci masteru a rozvržení mohou také šířit nastavení do závislých snímků, zatímco rozhraní [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) řídí výtiskový master.

## **Nastavení patičky, data/času a čísel snímků na normálních snímcích**

Pro normální snímky je základní postup získat správce záhlaví/patičky každého snímku, nastavit text patičky a data/času, povolit požadované zástupné symboly a uložit prezentaci. Čísla snímků generuje prezentace, takže je třeba řídit jen jejich viditelnost.

Použijte [`SetFooterText`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) a [`SetDateTimeText`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) k nastavení textu a použijte [`SetFooterVisibility`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) a [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) k zobrazení odpovídajících zástupných symbolů.

Následující kompletní příklad použije stejnou patičku, text data/času a viditelnost čísla snímku na všech normálních snímcích:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Pokud potřebujete aktualizovat pouze jeden snímek, přistupte k němu přímo přes [`Presentation::get_Slide`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_slide/) místo iterace přes celou kolekci snímků.

## **Nastavení záhlaví a patiček na masteru poznámek**

Master poznámek definuje společné formátování a chování zástupných symbolů pro stránky poznámek. Použijte rozhraní [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslideheaderfootermanager/) když chcete změnit pouze samotný master poznámek.

Následující příklad nastaví záhlaví, patičku a text data/času na masteru poznámek a zobrazí všechny podporované zástupné symboly na tomto masteru:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

Metoda [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) vrací `nullptr`, když prezentace neobsahuje master poznámek.

## **Použití nastavení masteru poznámek na podřízených snímcích poznámek**

Master poznámek může aplikovat nastavení záhlaví a patičky na sebe i na všechny podřízené snímky poznámek. Použijte dedikované metody propagace na [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslideheaderfootermanager/) když mají být stejná nastavení použita napříč hierarchií poznámek.

Například [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) a [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) aktualizují záhlaví masteru poznámek a všech podřízených záhlaví. Ekvivalantní metody jsou k dispozici pro patičky, datum/čas a čísla snímků.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Metody propagace použité výše jsou [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) a [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Nastavení záhlaví a patiček na individuálním snímku poznámek**

Snímek poznámek patří ke konkrétnímu normálnímu snímku. Použijte jeho rozhraní [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inotesslideheaderfootermanager/) když chcete přizpůsobit pouze tuto stránku poznámek.

Metoda [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inotesslidemanager/addnotesslide/) vrací snímek poznámek pro aktuální snímek a vytvoří jej, pokud ještě neexistuje. Následující příklad konfiguruje stránku poznámek přidruženou k prvnímu snímku prezentace:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Pokud nejprve propagujete nastavení z masteru poznámek a poté změníte individuální snímek poznámek, pozdější nastavení per‑snímek vám umožní přizpůsobit tuto stránku poznámek nezávisle.

## **Nastavení záhlaví a patiček na výtiskovém masteru**

Stránky výtisků používají výtiskový master pro své zástupné symboly záhlaví, patičky, datum/čas a číslo stránky. Na rozdíl od stránek poznámek jsou nastavení výtisku spravována přes výtiskový master, nikoli přes jednotlivé výtiskové snímky.

Použijte [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) k přístupu k výtiskovému masteru. Pokud není přítomen, zavolejte [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) k vytvoření výchozího výtiskového masteru.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Pochopení rozsahu a dědičnosti**

Vyberte správce záhlaví/patičky, který odpovídá rozsahu, který chcete změnit:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islideheaderfootermanager/) mění nastavení patičky, data/času a čísla snímku pro jeden normální snímek.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslideheaderfootermanager/) řídí snímek rozvržení a může šířit podporovaná nastavení do závislých snímků.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslideheaderfootermanager/) řídí běžný master snímků a může šířit podporovaná nastavení do závislých snímků.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasternotesslideheaderfootermanager/) řídí master poznámek a může šířit nastavení do všech podřízených snímků poznámek.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inotesslideheaderfootermanager/) mění jeden snímek poznámek a podporuje zástupný symbol záhlaví kromě patičky, data/času a čísla snímku.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) mění výtiskový master a podporuje všechny čtyři typy zástupných symbolů.

Použijte propagaci z masteru nebo rozvržení, když má stejné nastavení platit v celé jeho hierarchii. Použijte individuální správce snímku nebo správce snímku poznámek, když potřebujete lokální nastavení pro jednu stránku.

## **Často kladené otázky**

**Mohu přidat záhlaví na normální snímek?**

Ne. PowerPoint nedefinuje zástupný symbol záhlaví pro normální snímky. Na normálních snímcích použijte zástupné symboly patičky, datum/čas a číslo snímku. Zástupné symboly záhlaví jsou k dispozici na stránkách poznámek a výtiscích.

**Co když zástupný symbol patičky, datum/čas nebo číslo snímku není viditelný?**

Použijte odpovídajícího správce záhlaví/patičky k ověření jeho viditelnosti a povolení podle potřeby. Například [`get_IsFooterVisible`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) uvádí, zda je zástupný symbol patičky přítomen, a [`SetFooterVisibility`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) mění jeho viditelnost.

**Jak nastavit číslování snímků od hodnoty jiné než 1?**

Použijte [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/set_firstslidenumber/) k nastavení čísla prvního snímku. Zástupné symboly čísla snímku pak použijí aktualizovanou sekvenci číslování.

**Co se stane se záhlavími a patičkami při exportu do PDF, obrázků nebo HTML?**

Viditelné prvky záhlaví a patičky jsou vykresleny spolu se zbytkem obsahu prezentace ve výstupním formátu. Jejich vzhled závisí na typu stránky, která je exportována, a na nastavení viditelnosti odpovídajících zástupných symbolů.
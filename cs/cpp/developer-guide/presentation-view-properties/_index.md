---
title: Získání a aktualizace vlastností zobrazení prezentace v C++
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/cpp/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit vertikální rozdělovač
- jednoduché zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro C++, které umožňují přizpůsobit formáty PPT, PPTX a ODP snímků – upravte rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, v jakém bylo prezentace naposledy uložena.

Metoda [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) byla přidána pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inormalviewrestoredproperties/) a jejich potomci, výčet [SplitterBarStateType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/splitterbarstatetype/) byl přidán.

## **O INormalViewProperties**

Representuje vlastnosti normálního zobrazení.

Vlastnost **ShowOutlineIcons** určuje, zda by měla aplikace zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu v režimu normálního zobrazení.

Vlastnost **SnapVerticalSplitter** určuje, zda se má vertikální rozdělovací lišta zachytit do minimalizovaného stavu, když je postranní oblast dostatečně malá.

Vlastnost **PreferSingleView** určuje, zda uživatel upřednostňuje zobrazení jedné celé okna s jednou oblastí obsahu oproti standardnímu normálnímu zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Vlastnosti **VerticalBarState** a **HorizontalBarState** určují stav, ve kterém má být zobrazena horizontální nebo vertikální rozdělovací lišta. Horizontální rozdělovací lišta odděluje snímek od oblasti obsahu pod snímkem, vertikální rozdělovací lišta odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** a **SplitterBarStateType.Restored**.

Vlastnosti **RestoredLeft** a **RestoredTop** určují velikost horní nebo postranní oblasti snímku v normálním zobrazení, když je pro **VerticalBarState** a **HorizontalBarState** použita hodnota **SplitterBarStateType.Restored**.

## **O obnovení INormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je dítětem RestoredTop, výška, když je dítětem RestoredLeft) v normálním zobrazení, když má oblast proměnnou obnovenou velikost (ani minimalizovanou, ani maximalizovanou).

Vlastnost **DimensionSize** určuje velikost oblasti snímku (šířka, když je dítětem restoredTop, výška, když je dítětem restoredLeft).

Vlastnost **AutoAdjust** určuje, zda by měla oblast postranního obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, který ukazuje, jak můžete získat přístup k vlastnostem **ViewProperties.NormalViewProperties** pro prezentaci.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Obnovit vlastnosti zobrazení prezentace
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Nastavení výchozí hodnoty přiblížení**

Aspose.Slides pro C++ nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby bylo při otevření prezentace již nastaveno. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/) prezentace. Vlastnosti zobrazení snímku i [get_NotesViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/get_notesviewproperties/) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit vlastnosti zobrazení prezentace v Aspose.Slides.

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/)
1. Nastavte [Properties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/) zobrazení prezentace
1. Uložte prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Nastavení vlastností zobrazení prezentace
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Hodnota zvětšení v procentech pro zobrazení snímku
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Hodnota zvětšení v procentech pro zobrazení poznámek

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Nastavení rozestupu mřížky**

Použijte [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_viewproperties/) pro přístup k nastavením zobrazení na úrovni celé prezentace. Metody [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iviewproperties/get_gridspacing/) a [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iviewproperties/set_gridspacing/) čtou nebo mění interval podkladové editační mřížky. Toto nastavení platí pro celou prezentaci, nikoli pro jednotlivý snímek. Rozestup mřížky je zadáván v bodech, kde 72 bodů odpovídá jedné palci. Použijte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující soubor `demo.pptx`, vypíše jeho aktuální rozestup mřížky, nastaví interval čtvrtinové palce a uloží výsledek.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Mřížka se liší od [kreslicích vodítek](/slides/cs/cpp/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco kreslicí vodítka jsou jednotlivě umístěné vodorovné nebo svislé zarovnávací čáry. Přidání, přesunutí či vymazání kreslicích vodítek nemění rozestup mřížky.

Jak mřížka, tak kreslicí vodítka jsou pomocnými nástroji pro úpravy. Nejsou vykreslovány jako obsah snímku v PDF, obrázcích, SVG ani v prezentaci. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na preferencích prohlížeče nebo editoru.

## **Zobrazení nebo skrytí komentářů při otevírání prezentace**

Použijte [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_viewproperties/) pro přístup k nastavením zobrazení na úrovni celé prezentace. Použijte [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iviewproperties/get_showcomments/) a [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iviewproperties/set_showcomments/) k uložení preference, zda se mají při otevření prezentace v PowerPointu nebo jiném kompatibilním editoru zobrazit komentáře.

Toto nastavení řídí pouze uloženou preferenci zobrazení. Nepřidává, neodstraňuje, needituje ani neřeší komentáře. Skrytí komentářů zachovává jejich obsah, autory, pozice, odpovědi a stavy. Viz [Presentation Comments](/slides/cs/cpp/presentation-comments/) pro operace, které mění samotné komentáře.

Následující příklad vyžaduje existující soubor `comments.pptx`, který obsahuje komentáře. Vypíše aktuální nastavení viditelnosti, požádá o skrytí komentářů a uloží nový soubor PPTX, aniž by odstranil jakékoli komentáře. Také používá [IViewProperties::set_LastView](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iviewproperties/set_lastview/) spolu s [ViewType::SlideView](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewtype/) k nastavení počátečního editačního zobrazení vedle viditelnosti komentářů.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Toto nastavení neurčuje, zda jsou komentáře zahrnuty do exportů PDF, HTML, obrázků, poznámek nebo podkladů. Příslušné možnosti specifické pro export nakonfigurujte samostatně.

## **Často kladené otázky**

**Proč není po opětovném otevření prezentace viditelná mřížka?**

Soubor ukládá rozestup mřížky, ale editor rozhoduje, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Nezmění vymazání kreslicích vodítek rozestup mřížky?**

Ne. Kreslicí vodítka a rozestup mřížky jsou nezávislá nastavení. Vymazání vodítek ponechá uložený interval mřížky beze změny.

**Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?**

Nastavení zobrazení ([View settings](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_viewproperties/)) jsou definována na úrovni celé prezentace (Normal View/Slide View), nikoli pro jednotlivé sekce, takže jeden soubor parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Aplikační prohlížeče mohou respektovat preference uživatele, ale soubor samotný obsahuje jen jeden soubor vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_viewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
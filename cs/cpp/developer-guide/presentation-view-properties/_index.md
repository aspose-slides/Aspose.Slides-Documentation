---
title: Načtení a aktualizace vlastností zobrazení prezentace v C++
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
description: "Objevte vlastnosti zobrazení Aspose.Slides pro C++, které umožní přizpůsobit formáty PPT, PPTX a ODP snímků – upravte rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a dolní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu jako při posledním uložení prezentace.

Metoda [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) byla přidána, aby poskytla přístup k vlastnostem normálního zobrazení prezentace.

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inormalviewrestoredproperties/) a jejich potomci, výčtový typ [SplitterBarStateType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/splitterbarstatetype/) byly přidány.

## **O INormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Vlastnost **ShowOutlineIcons** určuje, zda by aplikace měla zobrazovat ikony při zobrazení osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Vlastnost **SnapVerticalSplitter** určuje, zda by vertikální rozdělovač měl přecházet do minimalizovaného stavu, když je postranní oblast dostatečně malá.

Vlastnost **PreferSingleView** určuje, zda uživatel preferuje zobrazení jedné oblasti obsahu na celou obrazovku místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povolena, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Vlastnosti **VerticalBarState** a **HorizontalBarState** určují stav, ve kterém by měl být zobrazen horizontální nebo vertikální rozdělovač. Horizontální rozdělovač odděluje snímek od oblasti obsahu pod snímkem, vertikální rozdělovač odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** a **SplitterBarStateType.Restored**.

Vlastnosti **RestoredLeft** a **RestoredTop** určují velikost horní nebo postranní oblasti snímku v normálním zobrazení, když je pro **VerticalBarState** a **HorizontalBarState** použita hodnota **SplitterBarStateType.Restored**.

## **O obnovování INormalViewProperties**

Určuje velikost oblasti snímku (šířka, pokud je podřízená RestoredTop, výška, pokud je podřízená RestoredLeft) v normálním zobrazení, když má oblast proměnnou obnovovanou velikost (ani minimalizovanou, ani maximalizovanou).

Vlastnost **DimensionSize** určuje velikost oblasti snímku (šířka, pokud je podřízená restoredTop, výška, pokud je podřízená restoredLeft).

Vlastnost **AutoAdjust** určuje, zda by velikost postranní oblasti obsahu měla kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Příklad uvedený níže ukazuje, jak můžete získat přístup k vlastnostem **ViewProperties.NormalViewProperties** pro prezentaci.

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

Aspose.Slides pro C++ nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby při otevření prezentace bylo přiblížení již nastaveno. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/) prezentace. Vlastnosti zobrazení snímku i [get_NotesViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/get_notesviewproperties/) mohou být nastaveny programově. V tomto tématu si ukážeme na příkladu, jak nastavit vlastnosti zobrazení prezentace v Aspose.Slides.

Aby bylo možné nastavit vlastnosti zobrazení, postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/)  
1. Nastavte View [Properties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/) prezentace  
1. Uložte prezentaci jako soubor PPTX  

V příkladu uvedeném níže jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Nastavení vlastností zobrazení prezentace
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Hodnota přiblížení v procentech pro zobrazení snímku
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Hodnota přiblížení v procentech pro zobrazení poznámek 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Nastavení rozestupu mřížky**

Použijte [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_viewproperties/) pro přístup k nastavením zobrazení na úrovni celé prezentace. Metody [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iviewproperties/get_gridspacing/) a [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iviewproperties/set_gridspacing/) načítají nebo mění interval podkladové editační mřížky. Toto nastavení platí pro celou prezentaci, ne pro jednotlivý snímek. Rozestup mřížky je udáván v bodech, kde 72 bodů odpovídá jedné palci. Použijte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtiny palce a uloží výsledek.

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

Mřížka se liší od [drawing guides](/slides/cs/cpp/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco vodítka jsou jednotlivě umístěné vodorovné nebo svislé zarovnávací čáry. Přidání, přesunutí nebo vymazání vodítek nemění rozestup mřížky.

Obě, mřížka i vodítka, jsou pomůcky pro úpravy. Nejsou vykreslovány jako obsah snímku v PDF, obrázcích, SVG ani při prezentaci. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastavení prohlížeče nebo editoru.

## **Často kladené otázky**

**Proč není mřížka viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale editor rozhoduje, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání vodítek rozestup mřížky?**

Ne. Vodítka a rozestup mřížky jsou nezávislá nastavení. Vymazání vodítek ponechává uložený interval mřížky beze změny.

**Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_viewproperties/) jsou definována na úrovni celé prezentace ([Normal View](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), nikoli pro jednotlivé sekce, takže při otevření dokumentu se použije jediná sada parametrů pro celý dokument.

**Mohu předdefinovat různá stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a sdílena. Aplikační prohlížeče mohou respektovat preference uživatele, ale soubor sám obsahuje jen jednu sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_viewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet nové dokumenty s touto stejnou výchozí konfigurací zobrazení.
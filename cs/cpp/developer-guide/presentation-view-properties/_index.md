---
title: Načíst a aktualizovat vlastnosti zobrazení prezentace v C++
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/cpp/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichycení svislého rozdělovače
- jednoduché zobrazení
- stav panelu
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Pomocí Aspose.Slides pro C++ můžete nakonfigurovat rozvržení normálního zobrazení, přiblížení snímků a poznámek, rozestup mřížky a viditelnost komentářů v prezentacích PowerPoint."
---
## **Úvod**

V normálním zobrazení PowerPointu se snímek zobrazuje mezi postranním panelem s náhledy nebo obrysem a panelem s poznámkami pod ním. Aspose.Slides pro C++ zpřístupňuje uložené předvolby úprav prezentace přes [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Patří mezi ně rozvržení panelů, úrovně přiblížení, rozestupy mřížky a viditelnost komentářů.

## **O INormalViewProperties**

Použijte [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) k přístupu k rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) řídí, zda se vedle názvů snímků v obrysu zobrazují ikony. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) umožňuje, aby se postranní panel při zúžení uživatelem přichytil do minimalizovaného stavu. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) udává preferenci zobrazit v celém okně jediný panel.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) řídí oddělovač mezi postranním panelem a snímkem. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) řídí oddělovač nad panelem s poznámkami. Oba přijímají hodnotu typu [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` nebo `Restored`.

## **O obnovování INormalViewProperties**

Když je oddělovač obnoven, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) poskytuje uloženou šířku postranního panelu a [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) poskytuje uloženou výšku horní oblasti snímku. Oba exponují [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). Jeho metoda [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) přijímá procento od 0 do 100 a [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) určuje, zda editor při změně velikosti okna upraví rozměr.

Tento příklad aktualizuje existující prezentaci. Obnoví vodorovný oddělovač, nastaví velikost horní oblasti snímku zpřístupněnou pomocí [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) na 80 % s povoleným automatickým přizpůsobením a maximalizuje svislý oddělovač. Také povolí ikony obrysu pomocí [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) pro zobrazení obrysu.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```
## **Nastavte výchozí hodnotu přiblížení**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) a [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) ukládají samostatná nastavení přiblížení pro editor. Tato nastavení neovlivňují rozměry snímku, přehrávání prezentace ani rozlišení exportovaných obrázků.

Tento příklad otevře existující prezentaci a povolí automatické škálování pomocí [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) , aby se snímek vešel do okna editoru. Pro stránku s poznámkami vypne automatické škálování a použije [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) , aby nastavil pevné přiblížení 80 %.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```
## **Nastavte rozestup mřížky**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) určuje vzdálenost mezi čarami editační mřížky v celé prezentaci. Přijímá kladnou hodnotu v bodech, přičemž 72 bodů představuje jeden palec. Tento příklad vytiskne aktuální rozestup v existující prezentaci a uloží čtvrttučekovou mřížku nastavením intervalu na 18 bodů.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Mřížka se opakuje v pevném intervalu. [Kreslicí vodítka](/slides/cs/cpp/drawing-guides/) označují jednotlivé vodorovné nebo svislé pozice. Obě jsou pomůckami při úpravách a zobrazují se jen v editorech, které je podporují. Přehlídky a exporty do PDF, obrázků nebo SVG je vynechají.

## **Zobrazit nebo skrýt komentáře při otevírání prezentace**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) ukládá předvolbu, kterou kompatibilní editory používají při otevírání prezentace. Pro existující prezentaci s komentáři tento příklad vytiskne aktuální nastavení a uloží kopii s komentáři skrytými. Také volá [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) s [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/), aby se kopie otevřela v zobrazení snímku.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Skrytí komentářů zachovává jejich text, autory, pozice, odpovědi a stavy. Pro úpravu samotných komentářů viz [Komentáře k prezentaci](/slides/cs/cpp/presentation-comments/). Nastavení exportu řídí, zda se komentáře zobrazí v PDF, HTML, obrázcích, poznámkách nebo podklady.

## **Často kladené otázky**

**Proč je mřížka skryta, když znovu otevřu prezentaci?**  
Prezentace ukládá interval mřížky. Pro zobrazení mřížky ji v editoru povolte.

**Mění vymazání vodicích čar rozestup mřížky?**  
Ne. Přidání, přesunutí nebo smazání vodící čáry nemění interval mřížky.

**Může mít různá oddíly prezentace různé nastavení zobrazení?**  
Ne. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) se vztahuje na celou prezentaci.

**Mohu uložit různá nastavení zobrazení pro různé uživatele?**  
Soubor ukládá jeden soubor nastavení zobrazení pro všechny. Editor může také aplikovat místní předvolby uživatele.

**Mohu uložit nastavení zobrazení v šabloně?**  
Ano. Prezentace vytvořené ze šablony zdědí její uložená nastavení zobrazení.
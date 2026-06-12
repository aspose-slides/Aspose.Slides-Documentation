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
- přichytit svislý rozdělovač
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
description: "Objevte vlastnosti zobrazení Aspose.Slides pro C++, které umožňují přizpůsobit formáty PPT, PPTX a ODP snímků — upravit rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, boční oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu jako při posledním uložení prezentace.

Metoda [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) byla přidána pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inormalviewrestoredproperties/) a jejich potomci, výčtový typ [SplitterBarStateType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/splitterbarstatetype/) byly přidány.

## **O INormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Vlastnost **ShowOutlineIcons** určuje, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v kterékoliv oblasti obsahu v režimu normálního zobrazení.

Vlastnost **SnapVerticalSplitter** určuje, zda se má svislý rozdělovač přichytit do zmenšeného stavu, když je boční oblast dostatečně malá.

Vlastnost **PreferSingleView** určuje, zda uživatel upřednostňuje zobrazit jednorázovou oblast obsahu na celou obrazovku místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povolena, může aplikace zvolit zobrazení jedné z oblastí obsahu v celém okně.

Vlastnosti **VerticalBarState** a **HorizontalBarState** určují stav, ve kterém má být zobrazena horizontální nebo vertikální lišta rozdělovače. Horizontální lišta rozdělovače odděluje snímek od oblasti obsahu pod snímkem, vertikální lišta rozdělovače odděluje snímek od boční oblasti obsahu. Možné hodnoty jsou: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** a **SplitterBarStateType.Restored**.

Vlastnosti **RestoredLeft** a **RestoredTop** určují velikost horní nebo boční oblasti snímku v normálním zobrazení, když je pro **VerticalBarState** a **HorizontalBarState** použita hodnota **SplitterBarStateType.Restored**.

## **O obnově INormalViewProperties**

Určuje velikost oblasti snímku (šířka, pokud je potomkem RestoredTop, výška, pokud je potomkem RestoredLeft) v normálním zobrazení, když má oblast proměnnou obnovovanou velikost (ani zmenšenou, ani maximalizovanou).

Vlastnost **DimensionSize** určuje velikost oblasti snímku (šířka, pokud je potomkem restoredTop, výška, pokud je potomkem restoredLeft).

Vlastnost **AutoAdjust** určuje, zda má velikost boční oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, který ukazuje, jak můžete získat přístup k vlastnostem **ViewProperties.NormalViewProperties** pro prezentaci.

``` cpp
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

Aspose.Slides pro C++ nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby bylo při otevření prezentace přiblížení již nastavené. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/) prezentace. Vlastnosti zobrazení snímku i [get_NotesViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/get_notesviewproperties/) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit vlastnosti zobrazení prezentace v Aspose.Slides.

Pro nastavení vlastností zobrazení postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/)
1. Nastavte zobrazení [Vlastnosti](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/) prezentace
1. Uložte prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i zobrazení poznámek.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Nastavení vlastností zobrazení prezentace
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Hodnota přiblížení v procentech pro zobrazení snímku
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Hodnota přiblížení v procentech pro zobrazení poznámek 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_viewproperties/) jsou definována na úrovni prezentace ([Normální zobrazení](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Zobrazení snímku](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), nikoli na úrovni sekce, takže při otevření dokumentu se použije jediná sada parametrů pro celý dokument.

**Mohu předdefinovat různá stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Prohlížečské aplikace mohou respektovat uživatelské preference, ale samotný soubor obsahuje jedinou sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [vlastnosti zobrazení](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_viewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet nové dokumenty se stejnou počáteční konfigurací zobrazení.
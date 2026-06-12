---
title: "Načtení a aktualizace vlastností zobrazení prezentace v .NET"
linktitle: "Vlastnosti zobrazení"
type: docs
weight: 80
url: /cs/net/presentation-view-properties/
keywords:
- "vlastnosti zobrazení"
- "normální zobrazení"
- "obsah osnovy"
- "ikony osnovy"
- "přichytit vertikální rozdělovač"
- "jednoduché zobrazení"
- "stav lišty"
- "rozměr"
- "automatické přizpůsobení"
- "výchozí přiblížení"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Objevte vlastnosti zobrazení Aspose.Slides pro .NET, které umožňují přizpůsobit formáty PPT, PPTX a ODP snímků – upravovat rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění jednotlivých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu jako při posledním uložení prezentace.

Vlastnost [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/iviewproperties/properties/normalviewproperties) byla přidána pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/inormalviewrestoredproperties) a jejich potomci, enum [SplitterBarStateType](https://reference.aspose.com/slides/cs/net/aspose.slides/splitterbarstatetype) byly přidány.

## **O INormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Vlastnost **ShowOutlineIcons** určuje, zda by aplikace měla zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Vlastnost **SnapVerticalSplitter** určuje, zda se vertikální rozdělovač má přichytit do zmenšeného stavu, když je postranní oblast dostatečně malá.

Vlastnost **PreferSingleView** určuje, zda uživatel upřednostňuje zobrazit oblast obsahu na celou obrazovku místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zvolit zobrazení jedné z oblastí obsahu v celém okně.

Vlastnosti **VerticalBarState** a **HorizontalBarState** určují stav, ve kterém by měl být zobrazen vodorovný nebo svislý rozdělovač. Vodorovný rozdělovač odděluje snímek od oblasti obsahu pod snímkem, svislý rozdělovač odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** a **SplitterBarStateType.Restored**.

Vlastnosti **RestoredLeft** a **RestoredTop** určují velikost horní nebo postranní oblasti snímku normálního zobrazení, když je pro **VerticalBarState** a **HorizontalBarState** použita hodnota **SplitterBarStateType.Restored**.

## **O obnově INormalViewProperties**

Určuje velikost oblasti snímku (šířka, pokud je podřízená RestoredTop, výška, pokud je podřízená RestoredLeft) normálního zobrazení, když je oblast v proměnné obnovené velikosti (ne zmenšená ani maximalizovaná).

Vlastnost **DimensionSize** určuje velikost oblasti snímku (šířka, pokud je podřízená restoredTop, výška, pokud je podřízená restoredLeft).

Vlastnost **AutoAdjust** určuje, zda by měla oblast postranního obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže uvedený příklad ukazuje, jak můžete získat přístup k vlastnostem **ViewProperties.NormalViewProperties** pro prezentaci.

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Obnovit vlastnosti zobrazení prezentace
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Nastavení výchozí hodnoty přiblížení**

Aspose.Slides pro .NET nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby bylo přiblížení nastaveno již při otevření prezentace. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties) prezentace. Vlastnosti zobrazení snímku i [NotesViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/properties/notesviewproperties) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit vlastnosti zobrazení prezentace v Aspose.Slides.

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)
1. Nastavte View [Properties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties) prezentace
1. Uložte prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Nastavení vlastností zobrazení prezentace
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Hodnota přiblížení v procentech pro zobrazení snímku
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Hodnota přiblížení v procentech pro zobrazení poznámek 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Mohu nastavit různé nastavení zobrazení pro různé sekce prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/viewproperties/) jsou definována na úrovni celé prezentace ([Normal View](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/slideviewproperties/)), nikoli pro jednotlivé sekce, takže jeden soubor parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Prohlížečské aplikace mohou respektovat uživatelské preference, ale samotný soubor obsahuje jediný soubor vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [vlastnosti zobrazení](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/viewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
---
title: Načíst a aktualizovat vlastnosti zobrazení prezentace v .NET
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/net/presentation-view-properties/
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
- výchozí zoom
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro .NET a upravte formáty PPT, PPTX a ODP snímků — nastavte rozložení, úroveň zoomu a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění jednotlivých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, jako bylo naposledy uloženo prezentací.

Vlastnost [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/iviewproperties/properties/normalviewproperties) byla přidána pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/inormalviewrestoredproperties), a jejich potomci, výčtový typ [SplitterBarStateType](https://reference.aspose.com/slides/cs/net/aspose.slides/splitterbarstatetype) byl přidán.

## **O INormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Vlastnost **ShowOutlineIcons** určuje, zda aplikace má zobrazovat ikony při zobrazování osnovy v libovolné oblasti obsahu režimu normálního zobrazení.

Vlastnost **SnapVerticalSplitter** určuje, zda se vertikální rozdělovač má přichytit do zmenšeného stavu, pokud je boční oblast dostatečně malá.

Vlastnost **PreferSingleView** určuje, zda uživatel upřednostňuje zobrazení jediné oblasti obsahu na celé obrazovce místo standardního normálního zobrazení se třemi oblastmi. Pokud je povoleno, může aplikace zobrazit jednu z oblastí obsahu v celém okně.

Vlastnosti **VerticalBarState** a **HorizontalBarState** určují stav, ve kterém má být zobrazen horizontální nebo vertikální rozdělovač. Horizontální rozdělovač odděluje snímek od oblasti obsahu pod snímkem, vertikální rozdělovač odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** a **SplitterBarStateType.Restored**.

Vlastnosti **RestoredLeft** a **RestoredTop** určují velikost horní nebo boční oblasti snímku v normálním zobrazení, když je pro **VerticalBarState** a **HorizontalBarState** použita hodnota **SplitterBarStateType.Restored**.

## **O obnově INormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je podřízenou **RestoredTop**, výška, když je podřízenou **RestoredLeft**) v normálním zobrazení, kdy má oblast proměnnou obnovovanou velikost (ne zmenšenou ani maximalizovanou).

Vlastnost **DimensionSize** určuje velikost oblasti snímku (šířka, když je podřízeným **RestoredTop**, výška, když je podřízeným **RestoredLeft**).

Vlastnost **AutoAdjust** určuje, zda má velikost boční oblasti obsahu kompenzovat novou velikost při změně rozměrů okna obsahujícího zobrazení v aplikaci.

Níže uvedený příklad ukazuje, jak můžete získat přístup k vlastnostem **ViewProperties.NormalViewProperties** pro prezentaci.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Nastavení výchozí úrovně zoomu**

Aspose.Slides pro .NET nyní podporuje nastavení výchozí hodnoty zoomu pro prezentaci tak, aby byl zoom nastaven již při otevření. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties) prezentace. Vlastnosti zobrazení snímku i [NotesViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/properties/notesviewproperties) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit vlastnosti zobrazení prezentace v Aspose.Slides.

Pro nastavení vlastností zobrazení postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)
2. Nastavte zobrazení [Properties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties)
3. Uložte prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme nastavili hodnotu zoomu pro zobrazení snímku i pro zobrazení poznámek.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Nastavení vlastností zobrazení prezentace
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Hodnota zoomu v procentech pro zobrazení snímku
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Hodnota zoomu v procentech pro zobrazení poznámek 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Nastavení rozestupu mřížky**

Použijte [Presentation.ViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/viewproperties/) pro přístup k nastavením zobrazení v celé prezentaci. Vlastnost [IViewProperties.GridSpacing](https://reference.aspose.com/slides/cs/net/aspose.slides/iviewproperties/gridspacing/) načítá nebo mění interval základní editační mřížky. Toto nastavení platí pro celou prezentaci, nikoli pro jednotlivý snímek. Rozestup mřížky je určen v bodech, kde 72 bodů odpovídá jednomu palci. Použijte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtinového palce a uloží výsledek.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Mřížka se liší od [drawing guides](/slides/cs/net/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco vodítka jsou jednotlivě umístěné horizontální nebo vertikální čáry zarovnání. Přidání, přesunutí nebo vymazání vodítek nemění rozestup mřížky.

Jak mřížka, tak vodítka jsou pomocné nástroje pro úpravy. Nejsou vykreslovány jako obsah snímku v PDF, obrázcích, SVG ani během prezentace. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastavení prohlížeče či editoru.

## **Často kladené otázky**

**Proč není mřížka viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale editor rozhoduje, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání vodítek rozestup mřížky?**

Ne. Vodítka a rozestup mřížky jsou nezávislá nastavení. Vymazání vodítek ponechává uložený interval mřížky beze změny.

**Mohu nastavit různé nastavení zobrazení pro různé sekce prezentace?**

[View settings](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/viewproperties/) jsou definována na úrovni prezentace ([Normal View](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/slideviewproperties/)), nikoli pro jednotlivé sekce, takže jeden soubor parametrů se aplikuje na celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Aplikační prohlížeče mohou respektovat uživatelské preference, ale samotný soubor obsahuje jedinou sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/viewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
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
- přichytit svislý oddělovač
- jednoobrazové zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro .NET a upravte formáty PPT, PPTX a ODP snímků — nastavte rozvržení, úroveň přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného slidu, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění jednotlivých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, aby při opětovném otevření byl pohled ve stejném stavu, v jakém byl prezentace naposledy uložena.

Byla přidána vlastnost [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/iviewproperties/properties/normalviewproperties), která poskytuje přístup k vlastnostem normálního zobrazení prezentace.  

Byly přidány rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/inormalviewrestoredproperties) a jejich potomci, stejně jako výčet [SplitterBarStateType](https://reference.aspose.com/slides/cs/net/aspose.slides/splitterbarstatetype).

## **O INormalViewProperties**

Představuje vlastnosti normálního zobrazení.

Vlastnost **ShowOutlineIcons** určuje, zda má aplikace zobrazovat ikony při zobrazování osnovy v některé z oblastí obsahu v režimu normálního zobrazení.

Vlastnost **SnapVerticalSplitter** určuje, zda se má vertikální oddělovač přichytit do minimalizovaného stavu, když je postranní oblast dostatečně malá.

Vlastnost **PreferSingleView** určuje, zda uživatel preferuje zobrazení jedné oblasti obsahu na celé obrazovce místo standardního normálního zobrazení se třemi oblastmi. Pokud je povoleno, může aplikace zobrazit jednu z oblastí obsahu v celém okně.

Vlastnosti **VerticalBarState** a **HorizontalBarState** určují stav, v jakém má být zobrazena vodorovná nebo svislá lišta oddělovače. Vodorovná lišta oddělovače odděluje slide od oblasti obsahu pod slidem, svislá lišta oddělovače odděluje slide od postranní oblasti obsahu. Možné hodnoty jsou: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** a **SplitterBarStateType.Restored**.

Vlastnosti **RestoredLeft** a **RestoredTop** určují velikost horní nebo postranní oblasti slidu v normálním zobrazení, když je pro **VerticalBarState** a **HorizontalBarState** použita hodnota **SplitterBarStateType.Restored**.

## **O obnovování INormalViewProperties**

Určuje velikost oblasti slidu (šířku, pokud je podřízená RestoredTop, výšku, pokud je podřízená RestoredLeft) v normálním zobrazení, když má oblast proměnnou obnovovanou velikost (není ani minimalizována, ani maximalizována).

Vlastnost **DimensionSize** určuje velikost oblasti slidu (šířku, pokud je podřízená restoredTop, výšku, pokud je podřízená restoredLeft).

Vlastnost **AutoAdjust** určuje, zda má velikost postranní oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, který ukazuje, jak můžete získat přístup k vlastnostem **ViewProperties.NormalViewProperties** pro prezentaci.

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

## **Nastavení výchozí hodnoty přiblížení**

Aspose.Slides pro .NET nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby bylo přiblížení nastaveno již při otevření. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties) prezentace. Vlastnosti zobrazení slidu i [NotesViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/viewproperties/properties/notesviewproperties) lze nastavit programově. V tomto tématu si na příkladu ukážeme, jak nastavit vlastnosti zobrazení prezentace v Aspose.Slides.

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)
1. Nastavte vlastnosti zobrazení prezentace
1. Uložte prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení slidu i pro zobrazení poznámek.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Nastavení vlastností zobrazení prezentace
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Hodnota přiblížení v procentech pro zobrazení slidu
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Hodnota přiblížení v procentech pro zobrazení poznámek 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Nastavení rozestupu mřížky**

Použijte [Presentation.ViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/viewproperties/) k získání přístupu k nastavením zobrazení na úrovni celé prezentace. Vlastnost [IViewProperties.GridSpacing](https://reference.aspose.com/slides/cs/net/aspose.slides/iviewproperties/gridspacing/) načítá nebo mění interval podkladové editační mřížky. Toto nastavení platí pro celou prezentaci, nikoli pro jednotlivý slide. Rozestup mřížky je udáván v bodech, kde 72 bodů odpovídá jedné palci. Použijte kladnou hodnotu, jak je požadováno v dokumentaci API.

Následující příklad otevře existující `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtiny palce a výsledek uloží.

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

Mřížka se liší od [kreslicích vodítek](/slides/cs/net/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco kreslicí vodítka jsou individuálně umístěné vodorovné nebo svislé čáry pro zarovnání. Přidání, přesunutí nebo vymazání kreslicích vodítek nemění rozestup mřížky.

Jak mřížka, tak kreslicí vodítka jsou pomůcky při úpravách. Nejsou vykreslovány jako obsah slidu v PDF, obrázcích, SVG ani v prezentaci. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastavení prohlížeče či editoru.

## **Zobrazit nebo skrýt komentáře při otevírání prezentace**

Použijte [Presentation.ViewProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/viewproperties/) k získání přístupu k nastavením zobrazení na úrovni celé prezentace. Přečtěte nebo změňte [IViewProperties.ShowComments](https://reference.aspose.com/slides/cs/net/aspose.slides/iviewproperties/showcomments/) a uložte preferenci, zda mají být komentáře při otevření prezentace v PowerPointu nebo jiném kompatibilním editoru zobrazeny.

Toto nastavení ovlivňuje pouze uloženou preferenci zobrazení. Nepřidává, neodstraňuje, neupravuje ani neřeší komentáře. Skrytí komentářů zachovává jejich obsah, autory, umístění, odpovědi a stavy. Viz [Presentation Comments](/slides/cs/net/presentation-comments/) pro operace, které mění samotné komentáře.

Následující příklad vyžaduje existující `comments.pptx` obsahující komentáře. Vypíše aktuální nastavení viditelnosti, požádá o skrytí komentářů a uloží nový PPTX bez odstranění jakýchkoli komentářů. Také nastaví [IViewProperties.LastView](https://reference.aspose.com/slides/cs/net/aspose.slides/iviewproperties/lastview/) na [ViewType.SlideView](https://reference.aspose.com/slides/cs/net/aspose.slides/viewtype/), aby nakonfiguroval počáteční zobrazení úprav spolu s viditelností komentářů.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Toto nastavení neurčuje, zda jsou komentáře zahrnuty do exportu do PDF, HTML, obrázku, poznámek nebo podkladů. Příslušné možnosti specifické pro export nakonfigurujte samostatně.

## **Často kladené otázky**

**Proč není mřížka viditelná po opětovném otevření prezentace?**  
Soubor ukládá rozestup mřížky, ale editor rozhoduje, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání kreslicích vodítek rozestup mřížky?**  
Ne. Kreslicí vodítka a rozestup mřížky jsou nezávislá nastavení. Vymazání vodítek ponechá uložený interval mřížky beze změny.

**Mohu nastavit různé nastavení zobrazení pro různé sekce prezentace?**  
[Nastavení zobrazení](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/viewproperties/) jsou definována na úrovni celé prezentace ([Normal View]/[Slide View]), nikoli na úrovni sekce, takže při otevření celého dokumentu se použije jediná sada parametrů.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**  
Ne. Nastavení jsou uložena v souboru a jsou sdílena. Prohlížečové aplikace mohou respektovat uživatelské preference, ale samotný soubor obsahuje jen jednu sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevřely stejným způsobem?**  
Ano. Protože [vlastnosti zobrazení](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/viewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
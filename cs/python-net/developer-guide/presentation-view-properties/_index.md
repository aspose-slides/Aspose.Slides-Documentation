---
title: Načtení a aktualizace vlastností zobrazení prezentace v Pythonu
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/python-net/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichycení vertikálního rozdělovače
- jednoduché zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Python via .NET a upravte formáty PPT, PPTX a ODP snímků—přizpůsobte rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, boční oblasti obsahu a spodní oblasti obsahu. Vlastnosti vztahující se k umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, jako když byla prezentace naposledy uložena.

Vlastnost [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/normal_view_properties/) byla přidána pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.  

Třídy [NormalViewProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/normalviewrestoredproperties/) a jejich potomci, výčtové typy [SplitterBarStateType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/splitterbarstatetype/) byly přidány.

## **O INormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Vlastnost **ShowOutlineIcons** určuje, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Vlastnost **SnapVerticalSplitter** určuje, zda se vertikální rozdělovač má zachytit do minimalizovaného stavu, když je boční oblast dostatečně malá.

Vlastnost **PreferSingleView** určuje, zda uživatel preferuje zobrazení jediné celé okna s jednou oblastí obsahu místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, může aplikace zobrazit jednu z oblastí obsahu v celém okně.

Vlastnosti **VerticalBarState** a **HorizontalBarState** určují stav, ve kterém má být zobrazena horizontální nebo vertikální lišta rozdělovače. Horizontální lišta rozdělovače odděluje snímek od oblasti obsahu pod snímkem, vertikální lišta rozdělovače odděluje snímek od boční oblasti obsahu. Možné hodnoty jsou: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** a **SplitterBarStateType.Restored**.

Vlastnosti **RestoredLeft** a **RestoredTop** určují velikost horní nebo boční oblasti snímku normálního zobrazení, když je pro **VerticalBarState** a **HorizontalBarState** použita hodnota **SplitterBarStateType.Restored**.

## **O obnovení INormalViewProperties**

Určuje velikost oblasti snímku (šířka, pokud je podřízená RestoredTop, výška, pokud je podřízená RestoredLeft) normálního zobrazení, když má oblast proměnnou obnovenou velikost (ani minimalizovanou, ani maximalizovanou).

Vlastnost **DimensionSize** určuje velikost oblasti snímku (šířka, pokud je podřízená restoredTop, výška, pokud je podřízená restoredLeft).

Vlastnost **AutoAdjust** určuje, zda má boční oblast obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže uvedený příklad ukazuje, jak můžete přistupovat k vlastnostem **ViewProperties.NormalViewProperties** pro prezentaci.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Obnovit vlastnosti zobrazení prezentace
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit výchozí hodnotu přiblížení**

Aspose.Slides for Python via .NET nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby při otevření prezentace bylo přiblížení již nastaveno. To lze provést nastavením [view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) prezentace. Vlastnosti zobrazení snímku i [notes_view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/notes_view_properties/) lze nastavit programově. V tomto tématu uvidíme na příkladu, jak nastavit vlastnosti zobrazení prezentace v Aspose.Slides.

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/)
2. Nastavte [view properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/) prezentace
3. Uložte prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Nastavení vlastností zobrazení prezentace
    presentation.view_properties.slide_view_properties.scale = 100 # Hodnota přiblížení v procentech pro zobrazení snímku
    presentation.view_properties.notes_view_properties.scale = 100 # Hodnota přiblížení v procentech pro zobrazení poznámek 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit rozestup mřížky**

Použijte [Presentation.view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) pro přístup k nastavením zobrazení na úrovni celé prezentace. Vlastnost [ViewProperties.grid_spacing](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/grid_spacing/) čte nebo mění interval základní editační mřížky. Toto nastavení se vztahuje na celou prezentaci, nikoli na jednotlivý snímek. Rozestup mřížky je uveden v bodech, kde 72 bodů odpovídá jednomu palci. Použijte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující soubor `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtinového palce a výsledek uloží.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Mřížka se liší od [drawing guides](/slides/cs/python-net/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco vodicí čáry jsou individuálně umístěné horizontální nebo vertikální zarovnávací čáry. Přidání, přesunutí nebo vymazání vodicích čar nemění rozestup mřížky.

Jak mřížka, tak vodicí čáry jsou pomocníky při úpravách. Nejsou vykreslovány jako obsah snímku v PDF, obrázcích, SVG ani v prezentaci. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastavení prohlížeče nebo editoru.

## **Zobrazit nebo skrýt komentáře při otevírání prezentace**

Použijte [Presentation.view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) pro přístup k nastavením zobrazení na úrovni celé prezentace. Přečtěte nebo změňte [ViewProperties.show_comments](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/show_comments/) a uložte preferenci, zda se mají při otevření prezentace v PowerPointu nebo jiném kompatibilním editoru zobrazovat komentáře.

Toto nastavení řídí pouze uloženou preferenci zobrazení. Nepřidává, neodstraňuje, neupravuje ani neřeší komentáře. Skrytí komentářů zachovává jejich obsah, autory, pozice, odpovědi a stavy. Viz [Presentation Comments](/slides/cs/python-net/presentation-comments/) pro operace, které mění samotné komentáře.

Následující příklad vyžaduje existující soubor `comments.pptx` obsahující komentáře. Vypíše aktuální nastavení viditelnosti, požádá o skrytí komentářů a uloží nový soubor PPTX, aniž by odstranil jakékoli komentáře. Také nastaví [ViewProperties.last_view](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/last_view/) na [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewtype/) pro konfiguraci počátečního zobrazení úprav spolu s viditelností komentářů.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Toto nastavení neurčuje, zda jsou komentáře zahrnuty do exportů PDF, HTML, obrázku, poznámek nebo podkladů. Konfigurujte příslušné možnosti specifické pro export samostatně.

## **FAQ**

**Proč není mřížka viditelná po opětovném otevření prezentace?**  
Soubor ukládá rozestup mřížky, ale editor řídí, zda se mřížka zobrazí. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání vodicích čar rozestup mřížky?**  
Ne. Vodicí čáry a rozestup mřížky jsou nezávislá nastavení. Vymazání vodicích čar nemění uložený interval mřížky.

**Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?**  
[Nastavení zobrazení](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) jsou definována na úrovni celé prezentace ([Normal View](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/slide_view_properties/)), nikoli po sekcích, takže jedná se o jeden soubor parametrů platný pro celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**  
Ne. Nastavení jsou uložena v souboru a sdílena. Aplikační prohlížeče mohou respektovat uživatelské preference, ale soubor samotný obsahuje jen jeden soubor vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevřely stejným způsobem?**  
Ano. Protože [view properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
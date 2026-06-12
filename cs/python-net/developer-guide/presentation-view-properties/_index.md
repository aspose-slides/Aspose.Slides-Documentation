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
- přichytit svislý rozdělovač
- jediné zobrazení
- stav lišty
- rozměr velikosti
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Python přes .NET a přizpůsobte formáty PPT, PPTX a ODP snímků – upravte rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti se týkají umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže při opětovném otevření je zobrazení ve stejném stavu, v jakém bylo posledně uloženo.

Byla přidána vlastnost [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/normal_view_properties/) pro zpřístupnění vlastností normálního zobrazení prezentace.

Byly přidány třídy [NormalViewProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/normalviewrestoredproperties/) a jejich potomci, výčtový typ [SplitterBarStateType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/splitterbarstatetype/) byly přidány.

## **O INormalViewProperties**

Representuje vlastnosti normálního zobrazení.

Vlastnost **ShowOutlineIcons** určuje, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v kterékoliv oblasti obsahu režimu normálního zobrazení.

Vlastnost **SnapVerticalSplitter** určuje, zda se svislý rozdělovač má přichytit do zmenšeného stavu, když je postranní oblast dostatečně malá.

Vlastnost **PreferSingleView** určuje, zda uživatel preferuje zobrazení jedné oblasti obsahu přes celou obrazovku místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celé okně.

Vlastnosti **VerticalBarState** a **HorizontalBarState** určují stav, ve kterém má být zobrazen vodorovný nebo svislý rozdělovač. Vodorovný rozdělovač odděluje snímek od oblasti obsahu pod snímkem, svislý rozdělovač odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** a **SplitterBarStateType.Restored**.

Vlastnosti **RestoredLeft** a **RestoredTop** určují velikost horní nebo postranní oblasti snímku v normálním zobrazení, když je pro **VerticalBarState** a **HorizontalBarState** použita hodnota **SplitterBarStateType.Restored**.

## **O obnovení INormalViewProperties**

Určuje velikost oblasti snímku (šířka, pokud je podřízená RestoredTop, výška, pokud je podřízená RestoredLeft) v normálním zobrazení, když má oblast proměnnou obnovenou velikost (ani zmenšenou, ani maximalizovanou).

Vlastnost **DimensionSize** určuje velikost oblasti snímku (šířka, pokud je podřízená restoredTop, výška, pokud je podřízená restoredLeft).

Vlastnost **AutoAdjust** určuje, zda má velikost postranní oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, který ukazuje, jak můžete přistupovat k vlastnostem **ViewProperties.NormalViewProperties** v prezentaci.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Obnovit vlastnosti zobrazení prezentace
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení výchozí hodnoty přiblížení**

Aspose.Slides for Python přes .NET nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby bylo přiblížení nastaveno již při otevření prezentace. To lze provést nastavením [view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) prezentace. Vlastnosti zobrazení snímku i [notes_view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/notes_view_properties/) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit View Properties prezentace v Aspose.Slides.

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/)  
1. Nastavte [view properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/) prezentace  
1. Uložte prezentaci jako soubor PPTX  

V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Nastavení vlastností zobrazení prezentace
    presentation.view_properties.slide_view_properties.scale = 100 # Hodnota přiblížení v procentech pro zobrazení snímku
    presentation.view_properties.notes_view_properties.scale = 100 # Hodnota přiblížení v procentech pro zobrazení poznámek 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?**  
[Nastavení zobrazení](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) jsou definována na úrovni prezentace ([Normal View](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/slide_view_properties/)), ne podle sekce, takže jedna sada parametrů se použije na celý dokument při jeho otevření.

**Mohu předdefinovat různá stavy zobrazení pro různé uživatele?**  
Ne. Nastavení jsou uložena v souboru a jsou sdílena. Prohlížečové aplikace mohou respektovat uživatelské preference, ale samotný soubor obsahuje jen jednu sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**  
Ano. Protože [view properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
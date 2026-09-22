---
title: Načíst a aktualizovat vlastnosti zobrazení prezentace v Pythonu
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/python-net/presentation-view-properties/
keywords: 
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit svislý dělitel
- jedno zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí zoom
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Python via .NET, které umožňují přizpůsobit formáty PPT, PPTX a ODP snímků – upravit rozvržení, úrovně zoomu a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, boční oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tato informace umožňuje aplikaci uložit stav zobrazení do souboru, takže při opětovném otevření je zobrazení ve stejném stavu, jako bylo při posledním uložení prezentace.

Vlastnost [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/normal_view_properties/) byla přidána pro přístup k vlastnostem normálního zobrazení prezentace.

Třídy [NormalViewProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/normalviewrestoredproperties/) a jejich potomci, enum [SplitterBarStateType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/splitterbarstatetype/) byly přidány.

## **O INormalViewProperties**

Reprezentuje normální vlastnosti zobrazení.

Vlastnost **ShowOutlineIcons** určuje, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Vlastnost **SnapVerticalSplitter** určuje, zda má svislý dělitel přejít do minimalizovaného stavu, když je boční oblast dostatečně malá.

Vlastnost **PreferSingleView** určuje, zda uživatel dává přednost zobrazení jedné celé oblasti obsahu v celé obrazovce místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Vlastnosti **VerticalBarState** a **HorizontalBarState** určují stav, ve kterém má být zobrazen svislý nebo vodorovný dělící pruh. Vodorovný dělící pruh odděluje snímek od oblasti obsahu pod snímkem, svislý dělící pruh odděluje snímek od boční oblasti obsahu. Možné hodnoty jsou: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** a **SplitterBarStateType.Restored**.

Vlastnosti **RestoredLeft** a **RestoredTop** určují velikost horní nebo boční oblasti snímku normálního zobrazení, když je pro **VerticalBarState** a **HorizontalBarState** použita hodnota **SplitterBarStateType.Restored**.

## **O obnovování INormalViewProperties**

Určuje velikost oblasti snímku (šířka, pokud je potomkem RestoredTop, výška, pokud je potomkem RestoredLeft) normálního zobrazení, když má oblast proměnnou obnovovanou velikost (ani minimalizovanou, ani maximalizovanou).

Vlastnost **DimensionSize** určuje velikost oblasti snímku (šířka, pokud je potomkem restoredTop, výška, pokud je potomkem restoredLeft).

Vlastnost **AutoAdjust** určuje, zda má boční oblast obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, jak můžete přistupovat k vlastnostem **ViewProperties.NormalViewProperties** pro prezentaci.

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

## **Nastavení výchozí hodnoty zoomu**

Aspose.Slides pro Python via .NET nyní podporuje nastavení výchozí hodnoty zoomu pro prezentaci tak, aby byl zoom při otevření prezentace již nastaven. Toto lze provést nastavením [view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) prezentace. Vlastnosti zobrazení snímku i [notes_view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/notes_view_properties/) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit vlastnosti zobrazení prezentace v Aspose.Slides.

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/)
2. Nastavte [view properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/) prezentace
3. Uložte prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme nastavili hodnotu zoomu pro zobrazení snímku i pro zobrazení poznámek.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Nastavení vlastností zobrazení prezentace
    presentation.view_properties.slide_view_properties.scale = 100 # Hodnota zoomu v procentech pro zobrazení snímku
    presentation.view_properties.notes_view_properties.scale = 100 # Hodnota zoomu v procentech pro zobrazení poznámek 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení rozestupu mřížky**

Použijte [Presentation.view_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) pro přístup k nastavením zobrazení na úrovni celé prezentace. Vlastnost [ViewProperties.grid_spacing](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/grid_spacing/) čte nebo mění interval podkladové editační mřížky. Toto nastavení se vztahuje na celou prezentaci, nikoli na jednotlivý snímek. Rozestup mřížky je uváděn v bodech, kde 72 bodů odpovídá jednomu palci. Použijte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtinového palce a výsledek uloží.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Mřížka se liší od [drawing guides](/slides/cs/python-net/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco vodicí linky jsou jednotlivě umístěné vodorovné nebo svislé zarovnávací čáry. Přidávání, přesouvání nebo mazání vodicích linek nemění rozestup mřížky.

Obě, mřížka i vodicí linky, jsou nápomocné při úpravách. Nejsou renderovány jako obsah snímku v PDF, obrázcích, SVG ani při prezentaci. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastaveních prohlížeče nebo editoru.

## **FAQ**

**Proč není mřížka viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale editor řídí, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání vodicích linek rozestup mřížky?**

Ne. Vodicí linky a rozestup mřížky jsou nezávislá nastavení. Vymazání linek ponechává uložený interval mřížky nezměněn.

**Mohu nastavit různá zobrazení pro různé sekce prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) jsou definována na úrovni prezentace ([Normal View](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/cs/python-net/aspose.slides/viewproperties/slide_view_properties/)), nikoli per sekce, takže jediná sada parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Aplikační prohlížeče mohou respektovat uživatelské preference, ale soubor sám obsahuje jen jednu sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevřely stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/view_properties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
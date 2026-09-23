---
title: Načíst a aktualizovat vlastnosti zobrazení prezentace v Pythonu pomocí Javy
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/python-java/presentation-view-properties/
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
- Python
- Java
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Python pomocí Javy a přizpůsobte snímky PPT, PPTX a ODP - upravte rozvržení, úroveň přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti normálního zobrazení popisují umístění těchto oblastí obsahu. Tato informace umožňuje aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, v jakém bylo prezentace naposledy uložena.

Byla přidána metoda [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNormalViewProperties), která poskytuje přístup k vlastnostem normálního zobrazení prezentace.

Byly přidány třídy [NormalViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewrestoredproperties/) a výčtový typ [SplitterBarStateType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/).

## **O NormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) určují, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v kterékoliv oblasti obsahu v režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) určují, zda se má svislý rozdělovací pruh přichytit do minimalizovaného stavu, když je postranní oblast dostatečně malá.

Metody [getPreferSingleView](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) a [setPreferSingleView](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) určují, zda uživatel preferuje zobrazení jedné obsahové oblasti na celou obrazovku místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, může aplikace zobrazit jednu z oblastí obsahu v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) určují stav, ve kterém má být zobrazen vodorovný nebo svislý rozdělovací pruh. Vodorovný pruh odděluje snímek od oblasti obsahu pod snímkem; svislý pruh odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) a [getRestoredTop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredTop) určují velikost horní nebo postranní oblasti snímku v normálním zobrazení, když je použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Restored), na [getVerticalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) respektive.

## **O obnovování NormalViewProperties**

Určuje velikost oblasti snímku (šířka, pokud je podřízená [getRestoredTop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredTop), výška, pokud je podřízená [getRestoredLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) v normálním zobrazení, když je oblast o proměnné obnovené velikosti (ani minimalizovaná, ani maximalizovaná).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) určuje velikost oblasti snímku (šířka, pokud je podřízená [getRestoredTop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredTop), výška, pokud je podřízená [getRestoredLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) určuje, zda má velikost postranní oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Příklad níže ukazuje, jak získat přístup k [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNormalViewProperties) pro prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Obnovit vlastnosti zobrazení prezentace.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavit výchozí hodnotu přiblížení**

{{% alert color="info" title="Note" %}}
Produkt Aspose.Slides pro Python pomocí Java podporuje nastavení výchozí hodnoty přiblížení, takže je aplikována již při otevření prezentace. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getSlideViewProperties) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNotesViewProperties) lze konfigurovat programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/) objektu [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) v Aspose.Slides.
{{% /alert %}}

Pro nastavení vlastností zobrazení postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/) objektu [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

V níže uvedeném příkladu nastavujeme hodnotu přiblížení pro zobrazení snímku i poznámek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Nastavit vlastnosti zobrazení prezentace.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Procento přiblížení pro zobrazení snímku.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Procento přiblížení pro zobrazení poznámek.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavit rozestup mřížky**

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getViewProperties) pro přístup k nastavením zobrazení na úrovni celé prezentace. Metody [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getGridSpacing) a [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#setGridSpacing) čtou nebo mění interval základní editační mřížky. Toto nastavení se vztahuje na celou prezentaci, ne na jednotlivý snímek. Rozestup mřížky je udáván v bodech, kde 72 bodů odpovídá jedné palci. Použijte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující soubor `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtiny palce a výsledek uloží.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mřížka se liší od [drawing guides](/slides/cs/python-java/drawing-guides/). Rozestup mřížky určuje pravidelný interval, zatímco vodící linie jsou jednotlivě umístěné horizontální nebo vertikální zarovnávací čáry. Přidání, přesunutí nebo vymazání vodících linií nemění rozestup mřížky.

Jak mřížka, tak i vodící linie jsou pomocné nástroje při úpravách. Nejsou vykreslovány jako obsah snímku v PDF, obrázcích, SVG ani při prezentaci. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost závisí také na nastavení prohlížeče nebo editoru.

## **Zobrazit nebo skrýt komentáře při otevření prezentace**

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getViewProperties) pro přístup k nastavením zobrazení na úrovni celé prezentace. Použijte [ViewProperties.getShowComments](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getShowComments) a [ViewProperties.setShowComments](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#setShowComments) pro čtení či změnu uložené preference, zda se mají komentáře při otevření prezentace v PowerPointu nebo jiném kompatibilním editoru zobrazit.

Toto nastavení ovlivňuje pouze uloženou preferenci zobrazení. Nepřidává, neodstraňuje, neupravuje ani neřeší komentáře. Skrytí komentářů zachovává jejich obsah, autory, pozice, odpovědi a stavy. Viz [Presentation Comments](/slides/cs/python-java/presentation-comments/) pro operace, které mění samotné komentáře.

Následující příklad vyžaduje existující soubor `comments.pptx` obsahující komentáře. Vypíše aktuální nastavení viditelnosti, požaduje skrytí komentářů a uloží nový PPTX bez odstranění jakýchkoli komentářů. Také používá [ViewProperties.setLastView](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#setLastView) s [ViewType.SlideView](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewtype/#SlideView) pro konfiguraci počátečního zobrazení úprav spolu s viditelností komentářů.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Toto nastavení neurčuje, zda jsou komentáře zahrnuty do exportů PDF, HTML, obrázků, poznámek nebo letáků. Relevantní možnosti specifické pro exporty nastavte odděleně.

## **Často kladené otázky**

**Proč není mřížka viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale editor řídí, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Změní vymazání vodících linií rozestup mřížky?**

Ne. Vodící linie a rozestup mřížky jsou nezávislá nastavení. Vymazání linií ponechá uložený interval mřížky nezměněn.

**Mohu nastavit různé nastavení zobrazení pro různé sekce prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getViewProperties) jsou definována na úrovni celé prezentace ([Normal View](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), nikoli pro jednotlivé sekce, takže jeden soubor parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Prohlížečové aplikace mohou respektovat uživatelské preference, ale samotný soubor obsahuje jediné nastavení vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevřely stejným způsobem?**

Ano. Protože [vlastnosti zobrazení](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getViewProperties) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
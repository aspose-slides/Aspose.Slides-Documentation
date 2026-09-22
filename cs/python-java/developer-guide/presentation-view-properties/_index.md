---
title: Načíst a aktualizovat vlastnosti zobrazení prezentace v Pythonu přes Java
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
- rozměr velikosti
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Python přes Java a přizpůsobte snímky PPT, PPTX a ODP – upravte rozvržení, úroveň přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, boční oblasti obsahu a spodní oblasti obsahu. Vlastnosti normálního zobrazení popisují umístění těchto oblastí. Tato informace umožňuje aplikaci uložit stav zobrazení do souboru, aby po jeho opětovném otevření bylo zobrazení ve stejném stavu jako při posledním uložení prezentace.

Metoda [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNormalViewProperties) byla přidána pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.

Byly přidány třídy [NormalViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/) a [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewrestoredproperties/) a výčtový typ [SplitterBarStateType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/).

## **O NormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) určují, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) určují, zda má být svislý rozdělovač zachycen do minimalizovaného stavu, když je boční oblast dostatečně malá.

Metody [getPreferSingleView](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) a [setPreferSingleView](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) určují, zda uživatel preferuje zobrazit jedinou oblast obsahu na celou obrazovku namísto standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celé okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) určují stav, ve kterém má být zobrazen vodorovný nebo svislý rozdělovač. Vodorovný rozdělovač odděluje snímek od oblasti obsahu pod snímkem; svislý rozdělovač odděluje snímek od boční oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) a [getRestoredTop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredTop) určují velikost horní nebo boční oblasti snímku v normálním zobrazení, když je použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Restored) pro [getVerticalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), respektive.

## **O obnově NormalViewProperties**

Určuje velikost oblasti snímku (šířku, když je podřízená [getRestoredTop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredTop), výšku, když je podřízená [getRestoredLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) v normálním zobrazení, když má oblast proměnnou obnovovanou velikost (není ani minimalizovaná, ani maximalizovaná).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) určuje velikost oblasti snímku (šířku, když je podřízená [getRestoredTop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredTop), výšku, když je podřízená [getRestoredLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) určuje, zda má velikost boční oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže uvedený příklad ukazuje, jak získat [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNormalViewProperties) pro prezentaci.

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

## **Nastavení výchozí hodnoty přiblížení**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java podporuje nastavení výchozí hodnoty přiblížení, která je aplikována již při otevření prezentace. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/) prezentace. Metody [getSlideViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getSlideViewProperties) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNotesViewProperties) lze konfigurovat programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/) pro [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) v Aspose.Slides.
{{% /alert %}}

Pro nastavení vlastností zobrazení postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/) pro [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).

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

## **Nastavení rozestupu mřížky**

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getViewProperties) pro přístup k nastavením zobrazení na úrovni celé prezentace. Metody [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getGridSpacing) a [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#setGridSpacing) čtou nebo mění interval podkladové editační mřížky. Toto nastavení platí pro celou prezentaci, ne pro jednotlivý snímek. Rozestup mřížky se udává v bodech, kde 72 bodů odpovídá jednomu palci. Použijte kladnou hodnotu, jak požaduje dokumentace API.

Níže uvedený příklad otevírá existující soubor `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtiny palce a uloží výsledek.

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

Mřížka se liší od [drawing guides](/slides/cs/python-java/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco vodítka jsou jednotlivě umístěné vodorovné nebo svislé zarovnávací čáry. Přidání, přesunutí nebo vymazání vodítek nemění rozestup mřížky.

Jak mřížka, tak vodítka jsou pomůcky pro úpravy. Nejsou vykreslovány jako obsah snímku v PDF, obrázcích, SVG ani při promítání. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí – její viditelnost také závisí na nastavení prohlížeče nebo editoru.

## **Často kladené otázky**

**Proč mřížka není viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale editor rozhoduje, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání vodítek rozestup mřížky?**

Ne. Vodítka a rozestup mřížky jsou nezávislá nastavení. Vymazání vodítek nechává uložený interval mřížky beze změny.

**Mohu nastavit různé nastavení zobrazení pro různé sekce prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getViewProperties) jsou definována na úrovni celé prezentace ([Normal View](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), ne pro jednotlivé sekce, takže jeden soubor parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Aplikační prohlížeče mohou respektovat uživatelské preference, ale samotný soubor obsahuje jen jednu sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getViewProperties) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
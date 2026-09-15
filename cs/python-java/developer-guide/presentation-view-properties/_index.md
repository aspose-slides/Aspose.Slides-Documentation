---
title: Načtení a aktualizace vlastností zobrazení prezentace v Pythonu přes Java
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/python-java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit vertikální oddělovač
- jednoduché zobrazení
- stav pruhu
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Python přes Java, které umožňují přizpůsobit snímky PPT, PPTX a ODP — upravujte rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, boční oblasti obsahu a spodní oblasti obsahu. Vlastnosti normálního zobrazení popisují umístění těchto oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po znovuotevření je zobrazení ve stejném stavu, jako když byla prezentace naposledy uložena.

Metoda [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNormalViewProperties) byla přidána pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.

Třídy [NormalViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/) a [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewrestoredproperties/) a výčet [SplitterBarStateType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/) byly přidány.

## **O NormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) určují, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) určují, zda má být svislý rozdělovací pruh zachycen do zmenšeného stavu, když je boční oblast dostatečně malá.

Metody [getPreferSingleView](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) a [setPreferSingleView](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) určují, zda uživatel upřednostňuje zobrazit oblast s obsahem na celou obrazovku místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může vybrat zobrazení jedné z oblastí obsahu v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) určují stav, ve kterém má být zobrazen horizontální nebo vertikální oddělovač. Horizontální oddělovač odděluje snímek od oblasti obsahu pod snímkem; vertikální oddělovač odděluje snímek od boční oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) a [getRestoredTop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredTop) určují velikost horní nebo boční oblasti snímku v normálním zobrazení, když je hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/python-java/aspose.slides/splitterbarstatetype/#Restored) použita na [getVerticalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) respektive.

## **O obnovování NormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je podřízenou [getRestoredTop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredTop), výška, když je podřízenou [getRestoredLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) normálního zobrazení, když má oblast proměnnou obnovenou velikost (ani zmenšenou, ani maximalizovanou).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) určuje velikost oblasti snímku (šířka, když je podřízenou [getRestoredTop](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredTop), výška, když je podřízenou [getRestoredLeft](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) určuje, zda má velikost boční oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Následující příklad ukazuje, jak získat přístup k [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNormalViewProperties) pro prezentaci.

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
Aspose.Slides pro Python via Java podporuje nastavení výchozí hodnoty přiblížení, aby byla již použita při otevření prezentace. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getSlideViewProperties) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNotesViewProperties) lze konfigurovat programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/) pro [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) v [Aspose.Slides](/slides/cs/).
{{% /alert %}}

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Nastavte [View Properties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/) pro [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
3. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).

V níže uvedeném příkladu nastavujeme hodnotu přiblížení pro zobrazení snímku i poznámek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Nastavit vlastnosti zobrazení prezentace.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Procento zvětšení pro zobrazení snímku.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Procento zvětšení pro zobrazení poznámek.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?**

Nastavení zobrazení jsou definována na úrovni celé prezentace ([Normal View](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), nikoli na úrovni sekce, takže jediná sada parametrů se použije na celý dokument při jeho otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílená. Aplikační prohlížeče mohou respektovat uživatelské preference, ale samotný soubor obsahuje jedinou sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi View Properties, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože vlastnosti zobrazení jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
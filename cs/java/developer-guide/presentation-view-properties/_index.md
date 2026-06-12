---
title: Načtení a aktualizace vlastností zobrazení prezentace v Javě
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- zachytit svislý oddělovač
- jednoduché zobrazení
- stav pruhu
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Java a přizpůsobte formáty PPT, PPTX a ODP snímků – upravte rozložení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tato informace umožňuje aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, jako když byla prezentace naposledy uložena.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) byla přidána pro poskytování přístupu k vlastnostem normálního zobrazení prezentace.  

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties) a jejich potomci, výčet [SplitterBarStateType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType) byl přidán.

## **O INormalViewProperties**

Zastupuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) určují, zda má aplikace zobrazovat ikony při zobrazování osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) určují, zda se má svislý oddělovač zachytit do minimalizovaného stavu, když je postranní oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) a [setPreferSingleView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) určuje, zda uživatel upřednostňuje zobrazení jedné celé oblasti obsahu v celém okně místo standardního normálního zobrazení se třemi oblastmi. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) určují stav, ve kterém má být zobrazen svislý nebo vodorovný pruh oddělovače. Vodorovný oddělovač odděluje snímek od oblasti obsahu pod snímkem, svislý oddělovač odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) a [getRestoredTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) určují velikost horní nebo postranní oblasti snímku normálního zobrazení, když je pro [getVerticalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Restored).

## **O obnovení INormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je potomkem [getRestoredTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), výška, když je potomkem [getRestoredLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) normálního zobrazení, když má oblast proměnnou obnovenou velikost (ani minimalizovanou, ani maximalizovanou).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) určuje velikost oblasti snímku (šířka, když je potomkem restoredTop, výška, když je potomkem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) určuje, zda má velikost postranní oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, který ukazuje, jak můžete získat přístup k vlastnostem [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) pro prezentaci.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Obnovit vlastnosti zobrazení prezentace
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Nastavení výchozí hodnoty přiblížení**

{{% alert color="primary" %}} 

Aspose.Slides pro Java nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby bylo při otevření prezentace již nastaveno. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) dokumentu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) v [Aspose.Slides](/slides/cs/).

{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) dokumentu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i zobrazení poznámek.

```java
Presentation presentation = new Presentation();
try {
    // Nastavení vlastností zobrazení prezentace
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Hodnota přiblížení v procentech pro zobrazení snímku
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Hodnota přiblížení v procentech pro zobrazení poznámek 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu nastavit odlišná nastavení zobrazení pro různé sekce prezentace?**

Nastavení zobrazení jsou definována na úrovni celé prezentace ([Normal View](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), ne na úrovni sekce, takže jeden soubor parametrů se vztahuje na celý dokument při jeho otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílená. Prohlížečské aplikace mohou respektovat uživatelské preference, ale samotný soubor obsahuje jedinečnou sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Vzhledem k tomu, že vlastnosti zobrazení jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
---
title: Načíst a aktualizovat vlastnosti zobrazení prezentace v Javě
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit vertikální dělič
- jednoduché zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Java, které umožňují přizpůsobit formáty PPT, PPTX a ODP snímků – upravovat rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, boční oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění jednotlivých oblastí obsahu. Tato informace umožňuje aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu jako při posledním uložení prezentace.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) byla přidána, aby poskytla přístup k vlastnostem normálního zobrazení prezentace.  

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties) a jejich potomci, enum [SplitterBarStateType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType) byly přidány.

## **O INormalViewProperties**

Representuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) určují, zda by aplikace měla zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) určují, zda se má vertikální dělič přichytit do minimalizovaného stavu, když je boční oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) a [setPreferSingleView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) určují, zda uživatel upřednostňuje zobrazení jedné celé oblasti obsahu přes celé okno místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) určují stav, ve kterém má být vodorovný nebo svislý dělič zobrazen. Vodorovný dělič odděluje snímek od oblasti obsahu pod snímkem, svislý dělič odděluje snímek od boční oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) a [getRestoredTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) určují velikost horní nebo boční oblasti snímku v normálním zobrazení, když je pro [getVerticalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Restored).

## **O obnově INormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je podřízená [getRestoredTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), výška, když je podřízená [getRestoredLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) normálního zobrazení, když má oblast proměnlivou obnovovanou velikost (není ani minimalizovaná, ani maximalizovaná).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) určuje velikost oblasti snímku (šířka, když je podřízená restoredTop, výška, když je podřízená restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) určuje, zda má boční oblast obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže uvedený příklad ukazuje, jak můžete získat vlastnosti [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) pro prezentaci.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 

Aspose.Slides for Java nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, že při otevření je přiblížení již nastaveno. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) v [Aspose.Slides](/slides/cs/).

{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

```java
import com.aspose.slides.*;

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

### Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?

[View settings](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getViewProperties--) jsou definována na úrovni celé prezentace ([Normal View](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nikoli pro jednotlivé sekce, takže jedna sada parametrů platí pro celý dokument při otevření.

### Mohu předdefinovat různá stavy zobrazení pro různé uživatele?

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Aplikační prohlížeče mohou respektovat uživatelské preference, ale samotný soubor obsahuje jedinou sadu vlastností zobrazení.

### Mohu vytvořit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getViewProperties--) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
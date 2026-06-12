---
title: Načtení a aktualizace vlastností zobrazení prezentace v Androidu
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/androidjava/presentation-view-properties/
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
- Android
- Java
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Android pomocí Javy a přizpůsobte formáty PPT, PPTX a ODP snímků – upravte rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění jednotlivých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, v jakém bylo prezentace naposledy uložena.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) byla přidána pro poskytování přístupu k vlastnostem normálního zobrazení prezentace.

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties) a jejich potomci, enum [SplitterBarStateType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType) byly přidány.

## **O INormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) určují, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) určují, zda se má svislý rozdělovač zachytit do minimalizovaného stavu, když je postranní oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) a [setPreferSingleView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) určuje, zda uživatel preferuje zobrazení jedné celé oblasti v okně místo standardního normálního zobrazení se třemi oblastmi. Pokud je povoleno, aplikace může zobrazit jednu z oblastí v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) určují stav, ve kterém by měla být zobrazena vodorovná nebo svislá lišta rozdělovače. Vodorovná lišta odděluje snímek od oblasti obsahu pod snímkem, svislá lišta odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) a [getRestoredTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) určují velikost horní nebo postranní oblasti snímku normálního zobrazení, když je pro [getVerticalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

## **O obnově INormalViewProperties**

Určuje velikost oblasti snímku (šířka při potomku [getRestoredTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), výška při potomku [getRestoredLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) normálního zobrazení, když má oblast proměnnou obnovovanou velikost (ani minimalizovanou, ani maximalizovanou).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) určuje velikost oblasti snímku (šířka při potomku restoredTop, výška při potomku restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) určuje, zda má oblast postranního obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, který ukazuje, jak můžete získat vlastnosti ViewProperties.getNormalViewProperties pro prezentaci.

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

## **Nastavte výchozí úroveň zvětšení**

{{% alert color="primary" %}} 

Aspose.Slides pro Android pomocí Java nyní podporuje nastavení výchozí úrovně zvětšení pro prezentaci tak, aby bylo zvětšení nastaveno již při otevření prezentace. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) v [Aspose.Slides](/slides/cs/).

{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/) .
   V níže uvedeném příkladu jsme nastavili hodnotu zvětšení pro zobrazení snímku i pro zobrazení poznámek.

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

**Mohu nastavit různé nastavení zobrazení pro různé sekce prezentace?**

Nastavení zobrazení jsou definována na úrovni prezentace ([Normal View](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nikoli pro jednotlivé sekce, takže jeden soubor parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Prohlížečové aplikace mohou respektovat uživatelské preference, ale samotný soubor obsahuje jen jeden soubor vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getViewProperties--) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
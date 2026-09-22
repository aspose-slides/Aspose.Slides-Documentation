---
title: Načíst a aktualizovat vlastnosti zobrazení prezentace na Androidu
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
- stav pruhu
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Android via Java a přizpůsobte formáty PPT, PPTX a ODP snímků – upravte rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, boční oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, jako když byla prezentace naposledy uložena.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) byla přidána pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.  

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties) a jejich potomci, výčtový typ [SplitterBarStateType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType) byly přidány.

## **O INormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) určují, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) určují, zda se svislý rozdělovač má přichytit do zmenšeného stavu, když je boční oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) a [setPreferSingleView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) určuje, zda uživatel preferuje vidět celou oblast obsahu na celé obrazovce místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) určují stav, ve kterém má být zobrazen vodorovný nebo svislý rozdělovač. Vodorovný rozdělovač odděluje snímek od oblasti obsahu pod snímkem, svislý rozdělovač odděluje snímek od boční oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) a [getRestoredTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) určují velikost horní nebo boční oblasti snímku v normálním zobrazení, když je pro [getVerticalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

## **O obnovování INormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je potomkem [getRestoredTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), výška, když je potomkem [getRestoredLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) normálního zobrazení, když má oblast proměnnou obnovovanou velikost (ani zmenšenou, ani maximalizovanou).  

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) určuje velikost oblasti snímku (šířka, když je potomkem restoredTop, výška, když je potomkem restoredLeft).  

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) určuje, zda má velikost boční oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.  

Níže uvedený příklad ukazuje, jak můžete získat přístup k vlastnostem [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) pro prezentaci.

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

Aspose.Slides for Android via Java nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby bylo přiblížení nastaveno již při otevření prezentace. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) lze nastavit programově. V tomto článku si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) v Aspose.Slides.

{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/). V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i poznámek.

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

## **Nastavení rozestupu mřížky**

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getViewProperties--) abyste získali přístup k nastavením zobrazení pro celou prezentaci. Metody [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) a [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) čtou nebo mění interval podkladové editační mřížky. Toto nastavení se vztahuje na celou prezentaci, ne na jednotlivý snímek. Rozestup mřížky je udáván v bodech, kde 72 bodů odpovídá jedné palci. Použijte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující soubor `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtiny palce a výsledek uloží.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mřížka se liší od [drawing guides](/slides/cs/androidjava/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco vodící linky jsou jednotlivě umístěné vodorovné nebo svislé zarovnávací čáry. Přidání, přesunutí nebo vymazání vodicích linek nemění rozestup mřížky.

Jak mřížka, tak i vodící linky jsou pomocné nástroje pro úpravy. Nejsou vykresleny jako obsah snímku v PDF, obrázcích, SVG ani v prezentaci. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastavení prohlížeče nebo editoru.

## **FAQ**

**Proč není mřížka viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale editor řídí, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání vodicích linek rozestup mřížky?**

Ne. Vodící linky a rozestup mřížky jsou nezávislé nastavení. Vymazání linek ponechává uložený interval mřížky nezměněný.

**Mohu nastavit různá nastavení zobrazení pro různé části prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getViewProperties--) jsou definována na úrovni prezentace ([Normal View]/[Slide View]), nikoli pro jednotlivé sekce, takže jeden soubor parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různá stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Prohlížečové aplikace mohou respektovat uživatelské preference, ale samotný soubor obsahuje jeden soubor vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [vlastnosti zobrazení](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getViewProperties--) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet nové dokumenty se stejnou počáteční konfigurací zobrazení.
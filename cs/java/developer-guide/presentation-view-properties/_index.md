---
title: Získání a aktualizace vlastností zobrazení prezentace v Javě
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- zachycení svislého rozdělovacího pruhu
- jednoduché zobrazení
- stav pruhu
- velikost rozměru
- automatické přizpůsobení
- výchozí zoom
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Java, které vám umožní přizpůsobit formáty PPT, PPTX a ODP snímků — upravit rozvržení, úrovně zoomu a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří obsahových oblastí: samotného snímku, boční obsahové oblasti a spodní obsahové oblasti. Vlastnosti týkající se umístění jednotlivých obsahových oblastí. Tato informace umožňuje aplikaci uložit stav zobrazení do souboru, takže při opětovném otevření je zobrazení ve stejném stavu, v jakém bylo prezentace naposledy uložena.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) byla přidána, aby poskytla přístup k vlastnostem normálního zobrazení prezentace.

Rozhraní [INormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties) a jejich potomci, enum [SplitterBarStateType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType) byly přidány.

## **O INormalViewProperties**

Představuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) určují, zda má aplikace zobrazovat ikony při zobrazování osnovy v některé z obsahových oblastí režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) určují, zda se má svislý rozdělovací pruh zachytit do minimalizovaného stavu, když je boční oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) a [setPreferSingleView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) určuje, zda uživatel dává přednost zobrazení jediné obsahové oblasti přes celé okno místo standardního normálního zobrazení se třemi obsahovými oblastmi. Pokud je povoleno, aplikace může zobrazit jednu z obsahových oblastí v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specifikují stav, ve kterém má být zobrazen svislý nebo vodorovný rozdělovací pruh. Vodorovný pruh odděluje snímek od obsahové oblasti pod snímkem, svislý pruh odděluje snímek od boční obsahové oblasti. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) a [getRestoredTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) určují velikost horní nebo boční oblasti snímku v normálním zobrazení, když je pro [getVerticalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SplitterBarStateType#Restored).

## **O obnovení INormalViewProperties**

Určuje velikost oblasti snímku (šířka, pokud je podřízená [getRestoredTop](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), výška, pokud je podřízená [getRestoredLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) v normálním zobrazení, když má oblast proměnnou obnovenou velikost (nesmíminizovanou ani maximalizovanou).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) určuje velikost oblasti snímku (šířka, pokud je podřízená restoredTop, výška, pokud je podřízená restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) určuje, zda má velikost boční obsahové oblasti kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, který ukazuje, jak můžete získat vlastnosti [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) pro prezentaci.

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

## **Nastavení výchozí hodnoty zvětšení**

{{% alert color="info" %}} 
Aspose.Slides for Java nyní podporuje nastavení výchozí hodnoty zvětšení pro prezentaci tak, aby bylo při otevření prezentace zvětšení již nastavené. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) v Aspose.Slides.
{{% /alert %}} 

Aby bylo možné nastavit vlastnosti zobrazení, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).

V níže uvedeném příkladu jsme nastavili hodnotu zvětšení pro zobrazení snímku i pro zobrazení poznámek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Nastavení vlastností zobrazení prezentace
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Hodnota zvětšení v procentech pro zobrazení snímku
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Hodnota zvětšení v procentech pro zobrazení poznámek 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení rozestupu mřížky**

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getViewProperties--) k přístupu k nastavením zobrazení na úrovni celé prezentace. Metody [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iviewproperties/#getGridSpacing--) a [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) čtou nebo mění interval podkladové editační mřížky. Toto nastavení se vztahuje na celou prezentaci, nikoli na jednotlivý snímek. Rozestup mřížky je uváděn v bodech, kde 72 bodů odpovídá jednomu palci. Použijte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující soubor `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrťi palce a výsledek uloží.

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

Mřížka se liší od [drawing guides](/slides/cs/java/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco vodící čáry jsou jednotlivě umístěné vodorovné nebo svislé zarovnávací linie. Přidávání, přesouvání nebo odstraňování vodících čar nemění rozestup mřížky.

Jak mřížka, tak vodící čáry jsou pomůcky pro editaci. Nejsou vykreslovány jako obsah snímku v PDF, obrázcích, SVG ani při prezentaci. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastavení prohlížeče nebo editoru.

## **Často kladené otázky**

**Proč není mřížka viditelná po opětovném otevření prezentace?**

Soubor uloží rozestup mřížky, ale editor rozhoduje, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání vodících čar rozestup mřížky?**

Ne. Vodící čáry a rozestup mřížky jsou nezávislá nastavení. Vymazání vodících čar nezmění uložený interval mřížky.

**Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?**

Nastavení zobrazení ([View settings](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getViewProperties--)) jsou definována na úrovni prezentace ([Normal View](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nikoli na úrovni sekce, takže při otevření dokumentu se použije jediná sada parametrů pro celý dokument.

**Mohu předdefinovat různá stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Prohlížečské aplikace mohou respektovat uživatelské preference, ale samotný soubor obsahuje jen jednu sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getViewProperties--) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
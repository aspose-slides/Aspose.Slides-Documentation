---
title: Načtení a aktualizace vlastností zobrazení prezentace na Androidu
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/androidjava/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit vertikální rozdělovač
- jednoduché zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí zvětšení
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte vlastnosti zobrazení Aspose.Slides pro Android přes Java a přizpůsobte formáty PPT, PPTX a ODP snímků – upravte rozvržení, úrovně zvětšení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, v jakém byla prezentace naposledy uložena.

Metoda[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) byla přidána pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.

[INormalViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties) rozhraní a jejich potomci, [SplitterBarStateType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType) výčet byly přidány.

## **O INormalViewProperties**

Zastupuje vlastnosti normálního zobrazení.

Metody[getShowOutlineIcons](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) a[setShowOutlineIcons](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) určují, zda by aplikace měla zobrazovat ikony při zobrazování osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Metody[getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) a[setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) určují, zda se má vertikální rozdělovač zachytit do minimalizovaného stavu, když je postranní oblast dostatečně malá.

Vlastnosti[getPreferSingleView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) a[setPreferSingleView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) určují, zda uživatel upřednostňuje zobrazit jednorázovou oblast obsahu na celou obrazovku místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celé okně.

Metody[getVerticalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a[getHorizontalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) určují stav, ve kterém by měla být zobrazena horizontální nebo vertikální lišta rozdělovače. Horizontální lišta rozděluje snímek od oblasti obsahu pod snímkem, vertikální lišta rozděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou:[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Minimized),[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) a[SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metody[getRestoredLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) a[getRestoredTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) určují velikost horní nebo postranní oblasti snímku normálního zobrazení, když je pro[getVerticalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) a[getHorizontalBarState](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) použita hodnota[SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

## **O obnovení INormalViewProperties**

Určuje velikost oblasti snímku (šířka, pokud je podřízená[getRestoredTop](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), výška, pokud je podřízená[getRestoredLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) normálního zobrazení, když je oblast proměnlivé obnovené velikosti (ani minimalizovaná, ani maximalizovaná).

Metoda[getDimensionSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) určuje velikost oblasti snímku (šířka, pokud je podřízená restoredTop, výška, pokud je podřízená restoredLeft).

Metoda[getAutoAdjust](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) určuje, zda by velikost postranní oblasti obsahu měla kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, jak získat vlastnosti[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) pro prezentaci.

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

## **Nastavit výchozí hodnotu přiblížení**

{{% alert color="info" %}} 

Aspose.Slides pro Android přes Java nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby bylo přiblížení nastaveno již při otevření prezentace. To lze provést nastavením[ViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) i[ getNotesViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit[View Properties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) v[Aspose.Slides](/slides/cs/).

{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy[Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Nastavte[View Properties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ViewProperties) [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Uložte prezentaci jako soubor[PPTX](https://docs.fileformat.com/presentation/pptx/).  
   V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

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

## **Často kladené otázky**

### Mohu nastavit různé nastavení zobrazení pro různé sekce prezentace?

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getViewProperties--) jsou definována na úrovni celé prezentace (Normal View/Slide View), nikoli pro jednotlivé sekce, takže jediná sada parametrů platí pro celý dokument při jeho otevření.

### Mohu předdefinovat různé stavy zobrazení pro různé uživatele?

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Prohlížečové aplikace mohou respektovat uživatelské preference, ale soubor samotný obsahuje jedinou sadu vlastností zobrazení.

### Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevřely stejným způsobem?

Ano. Protože[vlastnosti zobrazení](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getViewProperties--) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
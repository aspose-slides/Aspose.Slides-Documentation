---
title: Načtení a aktualizace vlastností zobrazení prezentace v JavaScriptu
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/nodejs-java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit svislý dělič
- jednozobrazové zobrazení
- stav lišty
- rozměrná velikost
- automatické přizpůsobení
- výchozí zvětšení
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte Aspose.Slides pro Node.js přes Java vlastnosti zobrazení a přizpůsobte formáty PPT, PPTX a ODP snímků – upravte rozvržení, úrovně zvětšení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, v jakém bylo prezentace naposledy uložena.

Byla přidána metoda [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) pro poskytnutí přístupu k vlastnostem normálního zobrazení prezentace.

Byly přidány třídy [NormalViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewRestoredProperties) a jejich potomci a výčtový typ [SplitterBarStateType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType) enum.

## **O NormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) určují, zda by aplikace měla zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean--) určují, zda se svislý dělič má přichytit do minimalizovaného stavu, když je postranní oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) a [setPreferSingleView](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) určuje, zda uživatel upřednostňuje zobrazit celoplošnou oblast s jedním obsahem místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) určují stav, ve kterém má být zobrazena vodorovná nebo svislá lišta děliče. Vodorovná lišta děliče odděluje snímek od oblasti obsahu pod snímkem, svislá lišta děliče odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) a [getRestoredTop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) určují velikost horní nebo postranní oblasti snímku v normálním zobrazení, když je pro [getVerticalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

## **O obnovení NormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je podřízená [getRestoredTop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), výška, když je podřízená [getRestoredLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) v normálním zobrazení, když má oblast proměnnou obnovenou velikost (ne ani minimalizovanou, ani maximalizovanou).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) určuje velikost oblasti snímku (šířka, když je podřízená restoredTop, výška, když je podřízená restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) určuje, zda má velikost postranní oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, jak můžete získat přístup k vlastnostem [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) pro prezentaci.

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Obnovit vlastnosti zobrazení prezentace
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Nastavení výchozí úrovně přiblížení**

{{% alert color="primary" %}} 

Aspose.Slides pro Node.js přes Java nyní podporuje nastavení výchozí úrovně přiblížení pro prezentaci, takže když je prezentace otevřena, je přiblížení již nastaveno. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) v [Aspose.Slides](/slides/cs/).

{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties) prezentace [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/). V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Nastavení vlastností zobrazení prezentace
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Hodnota přiblížení v procentech pro zobrazení snímku
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Hodnota přiblížení v procentech pro zobrazení poznámek
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu nastavit různé nastavení zobrazení pro různé sekce prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getviewproperties/) jsou definována na úrovni prezentace ([Normal View](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), ne na úrovni sekce, takže jediné sady parametrů platí pro celý dokument při jeho otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Prohlížečské aplikace mohou respektovat uživatelské preference, ale samotný soubor obsahuje jedinou sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [vlastnosti zobrazení](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getviewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
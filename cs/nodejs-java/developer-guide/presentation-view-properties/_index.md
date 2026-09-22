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
- přichycení svislého rozdělovače
- jednozobrazové zobrazení
- stav lišty
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte Aspose.Slides pro Node.js přes Java vlastnosti zobrazení a přizpůsobte formáty snímků PPT, PPTX a ODP — upravte rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění jednotlivých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu, v jakém bylo prezentace naposledy uloženo.

Metoda [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) byla přidána, aby poskytla přístup k vlastnostem normálního zobrazení prezentace.

Přidány byly třída [NormalViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties), třída [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewRestoredProperties) a její potomci, výčtový typ [SplitterBarStateType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType).

## **O NormalViewProperties**

Reprezentuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) určují, zda by aplikace měla zobrazovat ikony při zobrazování obsahu osnovy v některé z oblastí obsahu v režimu normálního zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) určují, zda by svislý rozdělovač měl přejít do stavu minimalizovaného, když je postranní oblast dostatečně malá.

Vlastnosti [getPreferSingleView](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) a [setPreferSingleView](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) určují, zda uživatel upřednostňuje zobrazení jedné oblasti obsahu na celé obrazovce místo standardního normálního zobrazení se třemi oblastmi. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celé obrazovce.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) určují stav, v jakém by měl být zobrazen vodorovný nebo svislý oddělovač. Vodorovný oddělovač odděluje snímek od oblasti obsahu pod snímkem, svislý oddělovač odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) a [getRestoredTop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) určují velikost horní nebo boční oblasti snímku v normálním zobrazení, když je použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Restored) pro [getVerticalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) odpovídajícím způsobem.

## **O obnovování NormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je podřízená [getRestoredTop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), výška, když je podřízená [getRestoredLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) v normálním zobrazení, pokud má oblast proměnnou obnovovanou velikost (ne minimalizovanou ani maximalizovanou).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) určuje velikost oblasti snímku (šířka, když je podřízená restoredTop, výška, když je podřízená restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) určuje, zda má velikost postranní oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uveden příklad, který ukazuje, jak můžete získat vlastnosti [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) pro prezentaci.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Nastavit výchozí úroveň přiblížení**

{{% alert color="info" %}} 
Aspose.Slides pro Node.js přes Java nyní podporuje nastavení výchozí úrovně přiblížení pro prezentaci tak, že při otevření prezentace je přiblížení již nastaveno. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) mohou být nastaveny programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) v Aspose.Slides.
{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
2. Nastavte [View Properties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
3. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).
   V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro náhled poznámek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Nastavit rozestup mřížky**

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getViewProperties--) k přístupu k nastavením zobrazení pro celou prezentaci. Metody [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) a [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) čtou nebo mění interval podkladové editační mřížky. Toto nastavení platí pro celou prezentaci, ne pro jednotlivý snímek. Rozestup mřížky je udáván v bodech, kde 72 bodů odpovídá jedné palci. Použijte kladnou hodnotu, jak vyžaduje dokumentace API.

Následující příklad otevře existující `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtiny palce a uloží výsledek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mřížka se liší od [drawing guides](/slides/cs/nodejs-java/drawing-guides/). Rozestup mřížky určuje pravidelný interval, zatímco vodící linky jsou jednotlivě umístěné vodorovné nebo svislé zarovnávací čáry. Přidání, přesunutí nebo vymazání vodících linek nemění rozestup mřížky.

Jak mřížka, tak vodící linky jsou pomůcky při úpravách. Nejsou vykresleny jako obsah snímku v PDF, obrázcích, SVG ani v prezentaci. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastavení prohlížeče nebo editoru.

## **Často kladené otázky**

**Proč není mřížka viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale editor rozhoduje, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání vodících linek rozestup mřížky?**

Ne. Vodící linky a rozestup mřížky jsou nezávislá nastavení. Vymazání linek ponechá uložený interval mřížky beze změny.

**Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?**

Nastavení zobrazení ([View settings](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getviewproperties/)) jsou definována na úrovni prezentace ([Normal View](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), nikoli pro jednotlivé sekce, takže jediná sada parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různá stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Aplikační prohlížeče mohou respektovat uživatelské preference, ale samotný soubor obsahuje jen jednu sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getviewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvořit z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
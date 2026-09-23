---
title: Načíst a aktualizovat vlastnosti zobrazení prezentace v JavaScriptu
linktitle: Vlastnosti zobrazení
type: docs
weight: 80
url: /cs/nodejs-java/presentation-view-properties/
keywords:
- vlastnosti zobrazení
- normální zobrazení
- obsah osnovy
- ikony osnovy
- přichytit svislý rozdělovač
- jednozobrazové zobrazení
- stav panelu
- velikost rozměru
- automatické přizpůsobení
- výchozí přiblížení
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte Aspose.Slides pro Node.js přes Java vlastnosti zobrazení a přizpůsobte formáty PPT, PPTX a ODP snímků – upravte rozvržení, úrovně přiblížení a nastavení zobrazení."
---
## **Úvod**

Normální zobrazení se skládá ze tří oblastí obsahu: samotného snímku, postranní oblasti obsahu a spodní oblasti obsahu. Vlastnosti týkající se umístění různých oblastí obsahu. Tyto informace umožňují aplikaci uložit stav zobrazení do souboru, takže po opětovném otevření je zobrazení ve stejném stavu jako při posledním uložení prezentace.

Metoda [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) byla přidána, aby poskytla přístup k vlastnostem normálního zobrazení prezentace.

Třídy [NormalViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewRestoredProperties) a jejich potomci a výčtový typ [SplitterBarStateType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType) byly přidány.

## **O NormalViewProperties**

Představuje vlastnosti normálního zobrazení.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) a [setShowOutlineIcons](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) určují, zda má aplikace zobrazovat ikony při zobrazování obsahu osnovy v kterékoliv oblasti obsahu normálního režimu zobrazení.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) a [setSnapVerticalSplitter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) určují, zda se má svislý rozdělovač přichytit do zmenšeného stavu, když je postranní oblast dostatečně malá.

Vlastnost [getPreferSingleView](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) a [setPreferSingleView](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) určuje, zda uživatel preferuje zobrazit celou jednorázovou oblast obsahu v celém okně místo standardního normálního zobrazení se třemi oblastmi obsahu. Pokud je povoleno, aplikace může zobrazit jednu z oblastí obsahu v celém okně.

Metody [getVerticalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) určují stav, ve kterém by měl být zobrazen svislý nebo vodorovný rozdělovač. Vodorovný rozdělovač odděluje snímek od oblasti obsahu pod snímkem, svislý rozdělovač odděluje snímek od postranní oblasti obsahu. Možné hodnoty jsou: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) a [getRestoredTop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) určují velikost horní nebo postranní oblasti snímku v normálním zobrazení, když je použita hodnota [SplitterBarStateType.Restored](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SplitterBarStateType#Restored) pro [getVerticalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) a [getHorizontalBarState](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--).

## **O obnovování NormalViewProperties**

Určuje velikost oblasti snímku (šířka, když je dítětem [getRestoredTop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), výška, když je dítětem [getRestoredLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) v normálním zobrazení, když má oblast proměnnou obnovovanou velikost (ani zmenšenou, ani maximalizovanou).

Metoda [getDimensionSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) určuje velikost oblasti snímku (šířka, když je dítětem restoredTop, výška, když je dítětem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) určuje, zda má velikost postranní oblasti obsahu kompenzovat novou velikost při změně velikosti okna obsahujícího zobrazení v aplikaci.

Níže je uvedený příklad, který ukazuje, jak můžete přistupovat k [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) vlastnostem pro prezentaci.

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

## **Nastavit výchozí hodnotu přiblížení**

{{% alert color="info" %}} 

Aspose.Slides pro Node.js přes Java nyní podporuje nastavení výchozí hodnoty přiblížení pro prezentaci tak, aby bylo přiblížení nastaveno již při otevření prezentace. To lze provést nastavením [ViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties) prezentace. [getSlideViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) i [getNotesViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) lze nastavit programově. V tomto tématu si ukážeme na příkladu, jak nastavit [View Properties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) v Aspose.Slides.

{{% /alert %}} 

Pro nastavení vlastností zobrazení postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Nastavte [View Properties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ViewProperties) pro [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   V níže uvedeném příkladu jsme nastavili hodnotu přiblížení pro zobrazení snímku i pro zobrazení poznámek.

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

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getViewProperties--) k přístupu k nastavením zobrazení na úrovni celé prezentace. Metody [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) a [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) čtou nebo mění interval podkladové editační mřížky. Toto nastavení se vztahuje na celou prezentaci, nikoli na jednotlivý snímek. Rozestup mřížky se uvádí v bodech, kde 72 bodů odpovídá jednomu palci. Používejte kladnou hodnotu, jak vyžaduje dokumentace API.

Níže uvedený příklad otevře existující `demo.pptx`, vypíše aktuální rozestup mřížky, nastaví interval čtvrtinového palce a uloží výsledek.

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

Mřížka se liší od [drawing guides](/slides/cs/nodejs-java/drawing-guides/). Rozestup mřížky řídí pravidelný interval, zatímco vodicí čáry jsou jednotlivě umístěné vodorovné nebo svislé zarovnávací linie. Přidání, přesunutí nebo vymazání vodicích čar nemění rozestup mřížky.

Obě, mřížka i vodicí čáry, jsou pomocnými nástroji pro úpravy. Nejsou vykreslovány jako obsah snímku v PDF, obrázcích, SVG ani při promítání. Uložení rozestupu mřížky nezaručuje, že editor mřížku zobrazí: její viditelnost také závisí na nastaveních prohlížeče či editoru.

## **Zobrazit nebo skrýt komentáře při otevírání prezentace**

Použijte [Presentation.getViewProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getViewProperties--) k přístupu k nastavením zobrazení na úrovni celé prezentace. Metody [ViewProperties.getShowComments](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/#getShowComments--) a [ViewProperties.setShowComments](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) čtou nebo mění uloženou předvolbu, zda mají být komentáře zobrazeny při otevření prezentace v PowerPointu nebo jiném kompatibilním editoru.

Toto nastavení řídí jen uloženou předvolbu zobrazení. Nepřidává, neodstraňuje, neupravuje ani neřeší komentáře. Skrytí komentářů zachovává jejich obsah, autory, pozice, odpovědi a stavy. Viz [Presentation Comments](/slides/cs/nodejs-java/presentation-comments/) pro operace měnící samotné komentáře.

Níže uvedený příklad vyžaduje existující `comments.pptx` obsahující komentáře. Vypíše aktuální nastavení viditelnosti, požádá o skrytí komentářů a uloží nový PPTX, aniž by odstranil jakékoli komentáře. Také používá [ViewProperties.setLastView](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) s [ViewType.SlideView](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewtype/#SlideView) k nastavení počátečního editačního zobrazení spolu s viditelností komentářů.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Toto nastavení neurčuje, zda jsou komentáře zahrnuty do exportu do PDF, HTML, obrázku, poznámek nebo letáků. Nastavte příslušné možnosti exportu zvlášť.

## **Často kladené otázky**

**Proč není mřížka viditelná po opětovném otevření prezentace?**

Soubor ukládá rozestup mřížky, ale editor řídí, zda je mřížka zobrazena. Zkontrolujte nastavení viditelnosti mřížky v editoru.

**Mění vymazání vodicích čar rozestup mřížky?**

Ne. Vodicí čáry a rozestup mřížky jsou nezávislá nastavení. Vymazání vodicích čar ponechává uložený interval mřížky beze změny.

**Mohu nastavit různá nastavení zobrazení pro různé sekce prezentace?**

[Nastavení zobrazení](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getviewproperties/) jsou definována na úrovni prezentace ([Normal View](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), ne na úrovni sekce, takže jedná sada parametrů platí pro celý dokument při otevření.

**Mohu předdefinovat různé stavy zobrazení pro různé uživatele?**

Ne. Nastavení jsou uložena v souboru a jsou sdílena. Aplikační prohlížeče mohou respektovat uživatelské předvolby, ale samotný soubor obsahuje jen jednu sadu vlastností zobrazení.

**Mohu připravit šablonu s předdefinovanými vlastnostmi zobrazení, aby se nové prezentace otevíraly stejným způsobem?**

Ano. Protože [view properties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getviewproperties/) jsou uloženy na úrovni prezentace, můžete je vložit do šablony a vytvářet z ní nové dokumenty se stejnou počáteční konfigurací zobrazení.
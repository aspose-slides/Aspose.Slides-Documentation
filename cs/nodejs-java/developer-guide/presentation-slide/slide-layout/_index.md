---
title: Použít nebo změnit rozvržení snímků v JavaScriptu
linktitle: Rozvržení snímku
type: docs
weight: 60
url: /cs/nodejs-java/slide-layout/
keywords:
- rozvržení snímku
- rozvržení obsahu
- zástupný objekt
- návrh prezentace
- návrh snímku
- nepoužité rozvržení
- viditelnost zápatí
- titulní snímek
- název a obsah
- hlavička sekce
- dva obsahy
- srovnání
- pouze název
- prázdné rozvržení
- obsah s popiskem
- obrázek s popiskem
- název a vertikální text
- vertikální název a text
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Používejte, vytvářejte a upravujte rozvržení snímků v Aspose.Slides pro Node.js pomocí Javy, přidávejte zástupné objekty, odstraňujte nepoužitá rozvržení a ovládejte viditelnost zápatí."
---
## **Přehled**

Rozvržení snímku určuje pozice a formátování zástupných objektů, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použití rozvržení poskytuje snímkům konzistentní strukturu a zároveň umožňuje každému snímku obsahovat vlastní obsah.

Mezi nejčastější rozvržení patří:

- **Title Slide**: Obsahuje zástupné objekty nadpisu a podnadpisu.
- **Title and Content**: Obsahuje zástupný objekt nadpisu a obecný zástupný objekt obsahu.
- **Blank**: Neobsahuje žádné zástupné objekty obsahu a je užitečné, když bude každý tvar umístěn ručně.

## **Porozumění dědičnosti rozvržení**

Prezentace má tři související úrovně:

1. Mistrovský snímek [master slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/) definuje téma, sdílené formátování, pozadí a společné objekty.
2. Rozvržovací snímek [layout slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/) patří k hlavnímu snímku a definuje konkrétní uspořádání zástupných objektů.
3. Normální snímek [normal slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/) používá jedno rozvržení a ukládá obsah zadaný pro tento snímek.

Normální snímek dědí téma a formátování ze svého rozvržení a rozvržení dědí z hlavního snímku. Hodnota nastavená přímo na normálním snímku přepíše děděnou hodnotu na té úrovni. Když je normální snímek vytvořen, jeho tvary zástupných objektů jsou generovány z vybraného rozvržení, zatímco obsah zadaný do těchto zástupných objektů patří k normálnímu snímku.

Přidejte požadované zástupné objekty do rozvržení před vytvořením snímků z něj. Přidání dalšího zástupného objektu do rozvržení později automaticky nepřidá odpovídající tvar zástupného objektu do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna děděného formátování nebo geometrie existujících zástupných objektů v rozvržení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozvržení, které již používá, zkontrolujte jeho závislé snímky a přezkoumejte výslednou prezentaci.
- Rozvržení, které je stále používáno nějakým snímkem, nelze odstranit. Nejprve přiřaďte jeho závislé snímky k jinému rozvržení nebo odstraňte jen nepoužívaná rozvržení.

Pro více informací o nejvyšší úrovni této hierarchie viz [Slide Master](/slides/cs/nodejs-java/slide-master/).

Pro skrytí zděděných log a dekorativních hlavních tvarů na jednom snímku nebo přes sdílené rozvržení viz [Control the Visibility of Master Graphics](/slides/cs/nodejs-java/slide-master/). Příklad porovnává dva snímky používající stejný hlavní snímek.

## **Vybrat a použít rozvržení snímku**

Použijte hodnotu [SlideLayoutType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidelayouttype/) pokud prezentace následuje standardní definice rozvržení PowerPointu. Názvy rozvržení jsou editovatelné uživatelem a mohou být lokalizovány, takže výběr založený na názvu je méně spolehlivý, pokud neovládáte zdrojovou šablonu.

Následující příklad hledá **Title and Content** na první hlavě. Pokud není toto rozvržení k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na null je nutná, protože prezentace může obsahovat jen vlastní rozvržení. Vybrané rozvržení je pak aplikováno na první normální snímek pomocí metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Změna rozvržení snímku neodstraňuje běžné tvary přidané přímo do snímku. Avšak pozice zástupných objektů, děděné formátování a shoda mezi existujícími zástupnými objekty a novým rozvržením se mohou změnit, proto výstup při přepínání mezi podstatně odlišnými rozvrženími pečlivě zkontrolujte.

## **Přidat rozvržení snímku**

Výběr a vytvoření jsou samostatné operace. Předchozí příklad vybere existující rozvržení; nevytváří ho. Pro vytvoření rozvržení zavolejte metodu [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) na kolekci rozvržení cílového hlavního snímku.

Následující příklad vždy přidá nové rozvržení **Title and Content** pojmenované `Report Title and Content` a poté přidá normální snímek založený na něm. Názvy rozvržení musí být v kolekci jedinečné.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Přidejte rozvržení jen tehdy, když šablona skutečně potřebuje další znovupoužitelnou strukturu. Pokud již vhodné rozvržení existuje, vyberte ho a znovu použijte místo vytváření duplikátu.

## **Přidat zástupné objekty do rozvržení snímku**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) poskytuje [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/) pro přidávání tvarů zástupných objektů do rozvržení.

| PowerPoint zástupný objekt | `LayoutPlaceholderManager` metoda |
| --------------------------- | --------------------------------- |
| ![Obsah](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Obsah (vertikální)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (vertikální)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Obrázek](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Graf](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabulka](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Média](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online obrázek](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Následující příklad ověří, že rozvržení **Blank** existuje, přidá k němu čtyři zástupné objekty a poté vytvoří normální snímek, který používá upravené rozvržení. Pořadí je úmyslné: zástupné objekty jsou přidány před vytvořením normálního snímku, takže Aspose.Slides může na tomto snímku vygenerovat odpovídající tvary.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zástupné objekty na rozvržení snímku](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna děděného formátování nebo geometrie existujících zástupných objektů v rozvržení může ovlivnit závislé snímky. Nově přidaný zástupný objekt rozvržení se nevyplní do existujících normálních snímků. Testujte změny rozvržení na kopii prezentace a zkontrolujte každý závislý snímek.
{{% /alert %}}

## **Odstranit nepoužívaná rozvržení snímků**

Použijte metodu [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) k odstranění rozvržení, na která neodkazuje žádný normální snímek. Metoda ponechá rozvržení, která jsou stále používána, nedotčena.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Chcete‑li odstranit konkrétní rozvržení, nejprve použijte jeho metodu [hasDependingSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) nebo [getDependingSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Před voláním [LayoutSlide.remove](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#remove) přiřaďte všechny závislé snímky. Pokus o odstranění používaného rozvržení vyvolá [PptxEditException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxeditexception/).

## **Ovládání viditelnosti zápatí na rozvržení snímku**

Rozvržení má vlastní zástupné objekty zápatí, čísla snímku a data/času. Použijte metodu [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) k řízení těchto zástupných objektů pro jedno rozvržení. To je užitečné například tehdy, když rozvržení obsahu má zobrazovat zápatí, ale rozvržení nadpisu ne.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ovládání viditelnosti zápatí na hlavním snímku a jeho podřízených rozvrženích**

Pro aplikaci konzistentních nastavení zápatí napříč hierarchií hlavního snímku použijte metodu [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody šíření [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslideheaderfootermanager/) působí na hlavní snímek i jeho závislé rozvržení snímků a normální snímky; necílí pouze na jeden normální snímek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Jaký je rozdíl mezi hlavním snímkem a rozvržením snímku?**

Hlavní snímek definuje téma prezentace a sdílené formátování. Rozvržení snímku patří k hlavnímu snímku a určuje jedno opakovaně použitelné uspořádání zástupných objektů. Normální snímky používají tato rozvržení a ukládají obsah specifický pro konkrétní snímek.

**Mohu zkopírovat rozvržení snímku z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Při kopírování mezi prezentacemi také ověřte písma, témata, obrázky a další zdroje použité v původním rozvržení.

**Co se stane, když upravím rozvržení, které je již používáno?**

Závislé snímky převezmou změny rozvržení, pokud ne přepíšou postižené formátování nebo objekty lokálně. Geometrie zástupných objektů a děděný styl se tak mohou změnit na mnoha snímcích najednou. Použijte [getDependingSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) k identifikaci ovlivněných snímků před úpravou rozvržení.

**Co se stane, pokud odstraním rozvržení, které je stále používáno?**

Aspose.Slides vyhodí [PptxEditException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxeditexception/). Nejprve přiřaďte závislé snímky jinde, nebo použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) k odstranění jen neodkazovaných rozvržení.
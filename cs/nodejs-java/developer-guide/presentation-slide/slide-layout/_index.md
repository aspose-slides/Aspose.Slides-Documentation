---
title: Použít nebo změnit rozložení snímků v JavaScriptu
linktitle: Rozložení snímku
type: docs
weight: 60
url: /cs/nodejs-java/slide-layout/
keywords:
- rozložení snímku
- rozložení obsahu
- zástupný znak
- design prezentace
- design snímku
- nepoužité rozložení
- viditelnost zápatí
- úvodní snímek
- nadpis a obsah
- nadpis sekce
- dvě části obsahu
- srovnání
- jen nadpis
- prázdné rozložení
- obsah s popiskem
- obrázek s popiskem
- nadpis a svislý text
- svislý nadpis a text
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Použijte, vytvořte a upravujte rozložení snímků v Aspose.Slides pro Node.js prostřednictvím Javy, přidejte zástupné znaky, odstraňte nepoužitá rozložení a ovládejte viditelnost zápatí."
---
## **Přehled**

Rozložení snímku určuje polohy a formátování zástupných znaků, jako jsou nadpisy, text, obrázky, grafy a tabulky. Použitím rozložení získají snímky jednotnou strukturu, přičemž každý snímek může obsahovat vlastní obsah.

Nejčastější rozložení jsou:

- **Title Slide**: Obsahuje zástupné znaky pro nadpis a podnadpis.
- **Title and Content**: Obsahuje zástupný znak pro nadpis a obecný zástupný znak pro obsah.
- **Blank**: Neobsahuje žádné zástupné znaky a je užitečné, když budou všechny tvary umístěny ručně.

## **Pochopení dědičnosti rozložení**

Prezentace má tři související úrovně:

1. [master slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/) definuje motiv, sdílené formátování, pozadí a společné objekty.
1. [layout slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/) patří k masteru a určuje konkrétní uspořádání zástupných znaků.
1. [normal slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/) používá jedno rozložení a ukládá obsah zadáný pro tento snímek.

Normální snímek dědí motiv a formátování ze svého rozložení a rozložení dědí z masteru. Hodnota nastavená přímo na normálním snímku přepíše zděděnou hodnotu na této úrovni. Při vytvoření normálního snímku se tvary zástupných znaků vygenerují podle vybraného rozložení, přičemž obsah zadaný do těchto zástupných znaků patří k normálnímu snímku.

Přidejte požadované zástupné znaky do rozložení před vytvořením snímků z něj. Přidání dalšího zástupného znaku do rozložení později automaticky nepřidá odpovídající tvar zástupného znaku do existujících normálních snímků.

Tento vztah má dva důležité důsledky:

- Změna zděděného formátování nebo geometrie existujícího zástupného znaku v rozložení může aktualizovat každý snímek, který na něm závisí. Před úpravou rozložení, které se již používá, zkontrolujte jeho závislé snímky a prohlédněte výslednou prezentaci.
- Rozložení, které je stále používáno nějakým snímkem, nelze odstranit. Nejprve přesuňte jeho závislé snímky na jiné rozložení nebo odstraňte pouze nepoužívaná rozložení.

Další informace o nejvyšší úrovni této hierarchie najdete v [Slide Master](/slides/cs/nodejs-java/slide-master/).

## **Výběr a použití rozložení snímku**

Použijte hodnotu [SlideLayoutType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidelayouttype/), pokud prezentace následuje standardní definice rozložení PowerPointu. Názvy rozložení jsou editovatelné uživatelem a mohou být lokalizovány, takže výběr založený na názvu je méně spolehlivý, pokud neovládáte zdrojovou šablonu.

Následující příklad hledá **Title and Content** v prvním masteru. Pokud není toto rozložení k dispozici, úmyslně přejde na **Blank**. Druhá kontrola na null je nutná, protože prezentace může obsahovat jen vlastní rozložení. Vybrané rozložení se pak použije na první normální snímek pomocí metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#setLayoutSlide).

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

Změna rozložení snímku neodstraňuje běžné tvary přidané přímo do snímku. Nicméně pozice zástupných znaků, zděděné formátování a korespondence mezi existujícími zástupnými znaky a novým rozložením se mohou změnit, proto při přepínání mezi podstatně odlišnými rozloženími zkontrolujte výstup.

## **Přidání rozložení snímku**

Výběr a vytvoření jsou oddělené operace. Předchozí příklad vybírá existující rozložení; nevytváří ho. Pro vytvoření rozložení zavolejte metodu [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) na kolekci rozložení cílového masteru.

Následující příklad vždy přidá nové rozložení **Title and Content** s názvem `Report Title and Content` a poté přidá normální snímek založený na něm. Názvy rozložení musí být v kolekci jedinečné.

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

Přidejte rozložení jen tehdy, když šablona opravdu potřebuje další znovupoužitelnou strukturu. Pokud již vhodné rozložení existuje, vyberte a znovu jej použijte místo vytváření duplikátu.

## **Přidání zástupných znaků do rozložení snímku**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) poskytuje [LayoutPlaceholderManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/) pro přidání tvarů zástupných znaků do rozložení.

| Zástupný znak PowerPoint            | `LayoutPlaceholderManager` Metoda |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Následující příklad ověří, že rozložení **Blank** existuje, přidá k němu čtyři zástupné znaky a poté vytvoří normální snímek, který používá upravené rozložení. Pořadí je záměrné: zástupné znaky jsou přidány před vytvořením normálního snímku, takže Aspose.Slides může vygenerovat odpovídající tvary zástupných znaků na tomto snímku.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Změna zděděného formátování nebo geometrie existujících zástupných znaků v rozložení může ovlivnit závislé snímky. Nově přidaný zástupný znak rozložení se automaticky nevyplní do existujících normálních snímků. Testujte změny rozložení na kopii prezentace a zkontrolujte každý závislý snímek.
{{% /alert %}}

## **Odstranění nepoužívaných rozložení snímků**

Použijte metodu [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) k odstranění rozložení, na která neodkazuje žádný normální snímek. Metoda ponechá rozložení, která jsou stále používána, nedotčena.

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

Pro odstranění konkrétního rozložení nejprve použijte jeho metodu [hasDependingSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) nebo [getDependingSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Přesuňte všechny závislé snímky před voláním [LayoutSlide.remove](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#remove). Pokus o odstranění použitého rozložení vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxeditexception/).

## **Řízení viditelnosti zápatí v rozložení snímku**

Rozložení má vlastní zástupné znaky pro zápatí, číslo snímku a datum/čas. Použijte metodu [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) k řízení těchto zástupných znaků pro jedno rozložení. To je užitečné, když například obsahová rozložení mají zobrazovat zápatí, ale rozložení nadpisů ne.

Následující příklad bezpečně vybere rozložení a učiní jeho prvky zápatí viditelnými:

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

## **Řízení viditelnosti zápatí v masteru a jeho podřízených rozloženích**

Pro použití konzistentních nastavení zápatí napříč hierarchií masteru použijte metodu [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody šíření [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslideheaderfootermanager/) působí na master a jeho závislé rozložení snímků a normální snímky; netargetují jen jeden normální snímek.

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

## **Často kladené dotazy**

**Jaký je rozdíl mezi master snímkem a rozložením snímku?**

Master snímek definuje motiv prezentace a sdílené formátování. Rozložení snímku patří k masteru a určuje jedno znovupoužitelné uspořádání zástupných znaků. Normální snímky používají tato rozložení a ukládají obsah specifický pro konkrétní snímek.

**Mohu zkopírovat rozložení snímku z jedné prezentace do druhé?**

Ano. Přidejte kopii do cílové kolekce pomocí metody [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Při kopírování mezi prezentacemi také ověřte písma, motivy, obrázky a další prostředky použité ve zdrojovém rozložení.

**Co se stane, když upravím rozložení, které je již používáno?**

Závislé snímky zdědí změny rozložení, pokud místně nepřepíší dotčené formátování nebo objekty. Geometrie zástupných znaků a zděděné styly se tak mohou změnit na mnoha snímcích najednou. Použijte [getDependingSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) k identifikaci ovlivněných snímků před úpravou rozložení.

**Co se stane, když odstraním rozložení, které je stále používáno?**

Aspose.Slides vyvolá výjimku [PptxEditException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxeditexception/). Nejprve přesuňte závislé snímky, nebo použijte [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) k odstranění pouze neodkazovaných rozložení.
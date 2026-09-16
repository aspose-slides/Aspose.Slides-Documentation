---
title: Správa hypertextových odkazů v prezentaci v JavaScriptu
linktitle: Správa hypertextových odkazů
type: docs
weight: 20
url: /cs/nodejs-java/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnitelný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Přidávejte, formátujte, aktualizujte a odstraňujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js prostřednictvím Javy, s ukázkami v JavaScriptu."
---
## **Úvod**

Hyperlink spojuje obsah prezentace s webovou stránkou nebo umístěním v rámci prezentace. V PowerPointu hypertextové odkazy obvykle slouží k dvěma účelům:

* Otevřít webovou stránku z textu, tvaru nebo media rámce.
* Přesunout se na jiný snímek, například z obsahu.

Aspose.Slides pro Node.js via Java vám umožňuje přidávat tyto odkazy, ovládat jejich vzhled a zvuk, aktualizovat jejich vlastnosti a odstraňovat je. Níže uváděné příklady ukazují, jak pracovat s hypertextovými odkazy na jednotlivých prvcích a jak přistupovat k odkazům na úrovni prezentace, snímku nebo textového rámce.

{{% alert color="info" title="Poznámka" %}}
Můžete také upravovat prezentace pomocí [bezplatného online editoru Aspose PowerPoint](https://products.aspose.app/slides/cs/editor).
{{% /alert %}} 

## **Přidání URL odkazů**

Můžete přiřadit webovou URL textu, tvaru nebo media rámci. Prvek, ke kterému hypertextový odkaz přiřadíte, určuje klikací oblast: část textu odkazuje vybraný text, zatímco tvar nebo rámec odkazuje objekt snímku.

### **Přidání URL odkazů do textu**

Chcete‑li propojit text s webovou stránkou, předáte objekt [Hyperlink](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink) metodě [setHyperlinkClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) příslušné textové části, jak je ukázáno níže. Klikací se stane pouze tato část textu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Přidání URL odkazů do tvarů a media rámců**

Aby byl tvar nebo rámec klikací, zavolejte jeho metodu [setHyperlinkClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#setHyperlinkClick). Hyperlink patří samotnému objektu, nikoli textové části uvnitř něj.

Stejný přístup platí pro obrázkové, audio i video rámce: přiřaďte hyperlink rámci a v případě potřeby zavolejte [setTooltip](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setTooltip).

Následující příklad dělá obdélník klikacím:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Použití hypertextových odkazů k vytvoření obsahu**

Interní hypertextové odkazy umožňují čtenářům přejít z obsahu na konkrétní snímek. Následující příklad používá [setInternalHyperlinkClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) k propojení textu „Page 2“ na první snímek s druhým snímkem.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formátování hypertextových odkazů**

### **Barva**

Metoda [setColorSource](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setColorSource) třídy [Hyperlink](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink) určuje, zda odkaz používá barvu hyperlinku prezentace, nebo formátování textové části. Pro použití vlastní barvy textu vyberte [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkColorSource) a nastavte výplňovou barvu části. Tato funkce byla zavedena v PowerPoint 2019; starší verze toto nastavení nepoužívají.

Následující příklad přidává dva textové odkazy na stejný snímek. První používá červenou výplň textu, druhý zachovává výchozí barvu hyperlinku.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Zvuk**

Hyperlink může při aktivaci přehrát zvuk nebo zastavit již přehrávaný zvuk. K nastavení těchto chování použijte následující metody:

- [Hyperlink.setSound](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setSound) určuje audio soubor spojený s odkazem.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) řídí, zda aktivace odkazu zastaví předchozí zvuk.

#### **Přidání zvuku k hyperlinku**

Následující příklad načte `sampleaudio.wav` a přiřadí jej tlačítku na prvním snímku. Kliknutí na tlačítko přehraje zvuk a přejde na další snímek. Druhý tvar na tom samém snímku při kliknutí zastaví předchozí zvuk, aniž by provedl navigaci.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Extrahování zvuku z hyperlinku**

Následující příklad otevře prezentaci vytvořenou výše a načte audio hyperlinku první části do paměti pomocí [getSound](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#getSound) a [getBinaryData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Audio#getBinaryData).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Nápověda a nastavení interakce**

Po přiřazení hyperlinku textu nebo tvaru můžete volat následující metody třídy [Hyperlink](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink):

- [setTooltip](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setTooltip) nastaví text, který může prohlížeč zobrazit jako nápovědu pro odkaz.
- [setTargetFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) určuje cílový rámec v rámci rodičovské HTML frameset, je‑li to relevantní.
- [setHistory](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setHistory) určuje, zda aktivace odkazu přidá jeho cíl do seznamu zobrazených hyperlinků.
- [setHighlightClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) určuje, zda je odkaz zvýrazněn po kliknutí.

## **Odstranění hyperlinků z prezentací**

Pomocí [getAnyHyperlinks](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) můžete sbírat kontejnery hyperlinků, včetně odkazů na textové části, před jejich změnou. Následující příklad odstraňuje oba typy aktivací z prvního snímku. Chcete‑li odstranit jen jeden typ, zavolejte pouze [removeHyperlinkClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) nebo [removeHyperlinkMouseOver](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); odstranění akce kliknutí neodstraňuje její protějšek při najetí myší.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Pro nepodmíněné odstranění [removeAllHyperlinks](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) odstraňuje oba typy aktivací ve vybraném rozsahu jedním voláním. Pro selektivní úklid a pokrytí hlav, rozvržení a poznámek viz [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Vytvoření kompletního inventáře hyperlinků**

Před distribucí prezentace inventarizujte její interaktivní akce i webové odkazy. [getAnyHyperlinks](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) vrací kontejnery hyperlinků, ne plochý seznam řetězců URL. Prohlédněte jak [getHyperlinkClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getHyperlinkClick), tak [getHyperlinkMouseOver](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) u každého kontejneru. Jsou nezávislé: stejný kontejner může vystavovat obě akce, takže úplná zpráva potřebuje až dva řádky na kontejner.

Pouze na úrovni tvarů skenované hypertextové odkazy mohou opomenout odkazy připojené k textovým částem. Dotazujte se na vhodný rozsah a uchovávejte vrácené kontejnery, abyste je mohli později aktualizovat nebo odstranit jejich akce.

### **Dotazování na rozsahy prezentace, snímku a textového rámce**

Třída [HyperlinkQueries](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries) je dostupná přes [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) a [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Každý rozsah podporuje stejné dotazy:

- [getHyperlinkClicks](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) vrací kontejnery s akcí kliknutí.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) vrací kontejnery s akcí najetí myší.
- [getAnyHyperlinks](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) vrací kontejnery s jednou nebo oběma akcemi.

Následující příklad vytvoří `hyperlink-audit-input.pptx` s externím odkazem při kliknutí, odkazem na soubor při najetí, interní navigací mezi snímky, odkazem na text při najetí a akcí makra. Žádná z těchto akcí není vykonána. Stejné tři dotazy fungují v každém rozsahu; počty popisují kontejnery, nikoli celkový počet akcí. Rozsah textového rámce vylučuje odkazy vlastního tvaru.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

V tomto příkladu dotazy na prezentaci a snímek uvádějí po třech kontejnerech kliknutí, dvou kontejnerech najetí a třech kontejnerech s libovolnou akcí. Dotaz na textový rámec uvádí po jednom kontejneru v každé kategorii.

### **Klasifikace akcí a cílů**

Pomocí [Hyperlink.getActionType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#getActionType) interpretujte akci před interpretací jejího cíle. Hodnoty [HyperlinkActionType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkActionType) zahrnují více než jen webovou navigaci:

| Hodnoty | Význam pro audit |
| --- | --- |
| `Hyperlink` | Externí odkaz; prověřte URL a její schéma. |
| `JumpSpecificSlide` | Interní navigace na konkrétní snímek. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Vestavěná navigace v prezentaci, řešená v kontextu prezentace. |
| `JumpEndShow`, `StartCustomSlideShow` | Ukončit aktuální ukázku nebo spustit vlastní ukázku. |
| `StartMacro` | Spustit makro. |
| `StartProgram` | Spustit program. |
| `OpenFile`, `OpenPresentation` | Otevřít soubor nebo jinou prezentaci; hodnotit odděleně od webových URL. |
| `StartStopMedia` | Spustit nebo zastavit přehrávání média. |
| `NoAction`, `Unknown` | Žádná navigační akce, nebo neznámá akce vyžadující revizi. |

Externí cíle čtěte z [getExternalUrl](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) a specifické interní cíle z [getTargetSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Interní akce a vestavěné příkazy nemusí mít externí URL; prázdná URL neznamená, že kontejner nemá žádnou akci. Uchovejte hodnotu vrácenou metodou [getExternalUrlOriginal](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal), pokud se liší od normalizované URL, a zahrňte nápovědu vrácenou metodou [getTooltip](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Hyperlink#getTooltip), pokud je k dispozici.

### **Zpráva, sanitizace a ověření hyperlinků**

Následující JavaScriptový příklad načte existující prezentaci (použijte soubor vytvořený výše), zapíše `hyperlink-audit.json`, aplikuje politiku, uloží `hyperlink-sanitized.pptx` a znovu jej otevře, aby zkontroloval oba typy aktivací. Před změnou sbírá kontejnery a používá referenční rovnost, aby se vyhnul duplicitnímu zpracování stejných kontejnerů. Dotazy na prezentaci pokrývají běžné snímky; pro inventář na úrovni balíčku explicitně dotazují hlavní šablony, rozvržení, poznámky a zároveň poznámkové a výstřižkové šablony, pokud jsou přítomny.

Zpráva zaznamenává jednorázový index snímku a [getSlideId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/BaseSlide#getSlideId), je‑li k dispozici. [getSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getSlide) poskytuje vlastní snímek pro podporované kontejnery. Hlavní šablony, rozvržení a poznámky nemají obyčejný index snímku a jsou identifikovány svým rozsahem. Kontejnery tvarů a formátovací kontejnery textových částí jsou označeny odděleně; ostatní typy kontejnerů si zachovávají název runtime typu. Každý kontejner dostane lokální ID zprávy, aby bylo možné korelovat jeho dvě akce. Zpráva ukládá typy akcí jako celočíselné konstanty definované výčtem HyperlinkActionType.

Tato záměrně restriktivní politika aplikace povoluje jen absolutní HTTPS URL a platné interní cíle snímků. Odmítá makra, programy, souborové akce, jiné akce prezentace, neznámé akce a jiné schémata URL. Tyto odmítnutí jsou politickými rozhodnutími, nikoli bezpečnostním verdiktem Aspose.Slides. HTTPS samotné netvoří důvěru: přidejte seznam povolených hostitelů a další kontroly pro vaši aplikaci. Kontrolují se jak původní, tak normalizované externí URL. Příklad audituje metadata bez sledování odkazů nebo spouštění akcí.

Pro nápravu kontejnerova [getHyperlinkManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getHyperlinkManager) podporuje [setExternalHyperlinkClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) a [removeHyperlinkMouseOver](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Zde jsou zakázané externí odkazy při kliknutí nahrazeny fixní HTTPS vstupní stránkou; ostatní zakázané kliknutí a zakázané akce při najetí jsou odstraňovány nezávisle. Nastavte `replaceExternalClicks` na `false`, chcete‑li odstranit všechny porušení politiky. Před nasazením zvolte náhradní stránku vlastněnou aplikací.

Exportní příznak zprávy používá konzervativní politiku revize PDF: označuje akce při najetí a vše kromě externího odkazu nebo konkrétního skoku na snímek jako potenciálně nepodporované. Jedná se o tip pro revizi, ne o test schopností ani záruku, že neoznačené odkazy přežijí export. Podporované exporty do [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/) mohou zachovat hyperlinky v závislosti na akci, možnostech exportu a prohlížeči. Rasterové [obrázky](/slides/cs/nodejs-java/convert-powerpoint-to-png/) a [video](/slides/cs/nodejs-java/convert-powerpoint-to-video/) nemohou zachovat interaktivní hyperlinky; při auditu pro tyto výstupy označte každou akci.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

S výše vytvořeným vstupem zpráva obsahuje pět řádků akcí. Odkaz na soubor při najetí a kliknutí na makro jsou odstraněny, zatímco HTTPS odkazy a interní navigace mezi snímky zůstávají. Ověření vypíše nula zakázaných akcí. Vstup obsahující zakázanou externí URL při kliknutí také ukazuje větev nahrazení. Kontejner s povoleným kliknutím a zakázaným najetím si ponechává akci kliknutí.

Tento selektivní úklid se liší od [removeAllHyperlinks](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), který odstraňuje oba typy aktivací v celém vybraném rozsahu bez ohledu na politiku. Ověření zde kontroluje pouze akce hyperlinků; neodstraňuje vložené VBA projekty, OLE objekty ani jiný aktivní obsah a nevaliduje exportovaný PDF nebo HTML soubor.

## **Často kladené otázky**

**Jak mohu propojit sekci nebo její první snímek?**

Sekce v PowerPointu seskupují snímky, ale interní hypertextový odkaz cílí na konkrétní snímek. Pro vytvoření navigace do sekce odkažte na první snímek v dané sekci.

**Mohu přiřadit hypertextový odkaz k prvkům hlavní šablony, aby fungoval na všech snímcích?**

Ano. Prvky hlavní šablony a rozvržení podporují hypertextové odkazy. Odkazy na těchto prvcích jsou k dispozici během prezentace na snímcích, které používají příslušnou hlavní šablonu nebo rozvržení.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

Podporované exporty do PDF a HTML mohou zachovat hypertextové odkazy; rastrové obrázky a video ne. Viz úvahy o exportu v [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).
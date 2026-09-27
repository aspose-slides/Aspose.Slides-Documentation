---
title: Správa textu prezentace v Node.js pomocí .NET
linktitle: Spravovat text
type: docs
weight: 50
url: /cs/nodejs-net/manage-text/
keywords:
- text
- textové pole
- přidat text
- změnit text
- formátovat text
- velikost písma
- tučný text
- textový rámec
- odstavec
- část
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Přidejte textové pole na snímek a poté změňte jeho text, velikost písma a tučný styl v JavaScriptu pomocí Aspose.Slides pro Node.js přes .NET."
---
## **Přehled**

V Aspose.Slides patří text na snímku k tvaru. Automatický tvar, například obdélník, má textový rámeček; textový rámeček obsahuje odstavce a každý odstavec obsahuje části, což jsou úseky textu se stejným formátováním. Text měníte prostřednictvím textového rámečku a písmo prostřednictvím formátu části.

Tento článek přidá textové pole na snímek a uloží prezentaci. Poté otevře uložený soubor a změní text v textovém poli, velikost písma a tučný styl.

Příklady vyžadují projekt nastavený podle pokynů v [Installation](/slides/cs/nodejs-net/installation/). Uložte každý příklad jako soubor `.js` do složky projektu a spusťte jej z této složky pomocí `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET nemá vlastní referenci API. Zrcadlí API Aspose.Slides pro .NET s názvy ve stylu camelCase, takže odkazy na API v tomto článku vedou na odpovídající třídy a členy v [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Přidání textového pole**

Chcete-li přidat textové pole, přidejte automatický tvar na snímek pomocí metody [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) a přiřaďte mu text pomocí metody [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/). Následující příklad přidá obdélník na první snímek nové prezentace a uloží prezentaci jako `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Pozice (x, y) a velikost (šířka, výška) jsou v bodech.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

Snímek v souboru `text-box.pptx` obsahuje obdélník široký 500 bodů a vysoký 80 bodů, s textem „Quarterly report“ ve výchozím písmu a velikosti. Další příklad mění toto textové pole.

## **Změna textu a jeho formátování**

Následující příklad otevře `text-box.pptx`, který vytvořil předchozí příklad, a získá první tvar na prvním snímku. Tvary jako obrázky a tabulky nemají textový rámeček, proto příklad kontroluje, že tvar je [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) předtím, než použije [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) tvaru. Poté provede následující:

1. Prostřednictvím vlastnosti [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) nahradí text. Po té textový rámeček obsahuje jeden odstavec s jednou částí.
2. Získá tuto část ze sbírek [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/) a [portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/) a přečte její [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/).
3. Nastaví [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/), velikost písma v bodech, a [fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/), která přijímá hodnotu [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/).

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

V souboru `text-box-updated.pptx` textové pole zobrazuje „Quarterly report: third quarter“ tučným písmem velikosti 32 bodů. Protože nový text je jedna část, oba formátovací vlastnosti se vztahují na celý text. Bez licence každé uložení přidá vodotisk s označením evaluace. Protože `text-box.pptx` byl také uložen v evaluačním režimu, `text-box-updated.pptx` obsahuje dva; viz [Vyhodnocení Aspose.Slides](/slides/cs/nodejs-net/evaluate-aspose-slides/).

## **Často kladené otázky**

**Proč `fontBold` přijímá hodnotu `NullableBool` místo `true` nebo `false`?**

Část může nechat vlastnost nedefinovanou a zdědit ji z odstavce, tvaru nebo rozvržení a hlavního snímku. `NullableBool.NotDefined` znamená „zdědit“, zatímco `NullableBool.True` a `NullableBool.False` přepíšou zděděnou hodnotu. Přiřazení `true` nebo `false` vyvolá chybu. Ze stejného důvodu `fontHeight` vrací `NaN`, když část zdědí velikost písma.

**Jak změním barvu textu?**

Nastavte výplň formátu části: přiřaďte `FillType.Solid` k `portionFormat.fillFormat.fillType` a poté přiřaďte barvu, například `"#FF0000"`, k `portionFormat.fillFormat.solidFillColor.color`. Přidejte `FillType` k názvům, které importujete z balíčku.

**Jak naformátuji jen část textu?**

Formátování patří částem, takže tuto část textu umístěte do vlastní části. Vytvořte část pomocí `Portion.CreatePortionFromText`, připojte ji k odstavci pomocí metody `add` ze sbírky `portions` odstavce a potom nastavte `portionFormat` nové části. Přidejte `Portion` k názvům, které importujete z balíčku.

**Proč čtení textu vrací „... text has been truncated due to evaluation version limitation“?**

Bez licence Aspose.Slides vrací pouze prvních pět znaků jakéhokoli delšího textu, který čtete, například `textFrame.text`, následované touto zprávou. Text, který zapíšete, je uložen celý. Použijte licenci podle návodu v [Licensing](/slides/cs/nodejs-net/licensing/), aby bylo možné přečíst celý text.
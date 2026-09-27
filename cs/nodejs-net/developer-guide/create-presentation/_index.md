---
title: Vytváření prezentací v Node.js přes .NET
linktitle: Vytvořit prezentaci
type: docs
weight: 10
url: /cs/nodejs-net/create-presentation/
keywords:
- vytvořit prezentaci
- nová prezentace
- vytvořit PowerPoint
- vytvořit PPTX
- přidat textové pole
- přidat snímek
- velikost snímku
- širokoúhlý
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte PowerPoint prezentace v JavaScriptu pomocí Aspose.Slides pro Node.js přes .NET: přidejte textové pole a snímky, nastavte velikost snímku 16:9 a uložte výsledek jako PPTX."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit prezentaci pomocí Aspose.Slides pro Node.js přes .NET, přidat textové pole na její první snímek a uložit výsledek jako soubor PPTX. Také ukazuje, jak přidat další snímky a jak přepnout prezentaci na širokoúhlé (16:9) snímky.

Příklady vyžadují projekt nastavený podle popisu v [Installation](/slides/cs/nodejs-net/installation/). Uložte každý příklad jako soubor `.js` do složky projektu a spusťte jej z této složky pomocí `node`, například `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro Node.js přes .NET nemá vlastní referenci API. Odráží API Aspose.Slides pro .NET s názvy ve formátu camelCase, takže odkazy na API v tomto článku směřují na odpovídající třídy a členy v [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Vytvoření prezentace s textovým polem**

Chcete-li vytvořit prezentaci a umístit textové pole na její první snímek, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Nová prezentace již obsahuje jeden prázdný snímek.
2. Získejte tento snímek ze sbírky [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). Sbírky v tomto balíčku se čtou pomocí `get(index)` a indexy začínají od 0.
3. Přidejte obdélník pomocí metody [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) a nastavte [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) jeho [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/).
4. Uložte prezentaci pomocí metody [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) a hodnoty `SaveFormat.Pptx`.
5. Volajte `dispose` v bloku `finally`, aby se uvolnily .NET prostředky, které prezentaci podporují.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Pozice (x, y) a velikost (šířka, výška) jsou v bodech.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Skript zapíše `new-presentation.pptx` do složky projektu. Soubor obsahuje jeden snímek s vyplněným obdélníkem, jehož levý horní roh je vzdálen 50 bodů od levého a horního okraje snímku. Obdélník má šířku 400 bodů a výšku 100 bodů a jeho text je zarovnán na střed. Jeden bod je 1/72 palce. Bez licence Aspose.Slides také přidává na snímek vodoznak s textem „Evaluation only“; viz [Licensing](/slides/cs/nodejs-net/licensing/).

## **Přidání snímků**

Nová prezentace má jeden snímek. Chcete-li přidat další, předávejte rozložení snímku metodě [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) sbírky `slides`. Metoda [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) sbírky [layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) vrací první rozložení daného [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/).

Následující příklad přidá dva snímky s rozložením Blank:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skript vypíše `Slide count: 3` a zapíše `three-slides.pptx`. Nové snímky jsou přidány za první a neobsahují žádné tvary. Nová prezentace vždy obsahuje rozložení Blank, ale prezentace otevřená ze souboru nemusí mít rozložení požadovaného typu; v takovém případě `getByType` vrací `null`, takže výsledek před jeho použitím zkontrolujte.

## **Nastavení velikosti snímku**

Nová prezentace používá snímky 4:3 o rozměrech 720 × 540 bodů (10 × 7,5 palce). Pro vytvoření širokoúhlých snímků místo toho zavolejte metodu [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) vlastnosti [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) prezentace s hodnotou [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) a hodnotou [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/). Typ měřítka říká Aspose.Slides, co má dělat s tvary, které jsou již na snímcích; `DoNotScale` je nechá tak, jak jsou, což je správná volba pro prezentaci, která zatím neobsahuje žádný obsah.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skript vypíše `Slide size: 960 x 540 points`, což je 13,33 × 7,5 palce, a zapíše `widescreen.pptx`. `SlideSizeType.OnScreen16x9` má stejný poměr stran 16:9, ale je menší: 720 × 405 bodů.

## **Často kladené otázky**

**V jakých jednotkách jsou měřeny pozice a velikosti?**

V bodech. Jeden palec je 72 bodů, takže výchozí snímek 4:3 má rozměry 720 × 540 bodů a širokoúhlý snímek 16:9 má rozměry 960 × 540 bodů.

**Do jakých formátů mohu novou prezentaci uložit?**

Libovolná hodnota výčtu [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/), například `SaveFormat.Ppt` pro PowerPoint 97–2003, `SaveFormat.Odp` pro OpenDocument nebo `SaveFormat.Pdf`. Pro výstup do PDF viz [Convert PowerPoint to PDF](/slides/cs/nodejs-net/convert-powerpoint-to-pdf/).

**Proč uložená prezentace obsahuje text „Evaluation only“?**

Bez licence Aspose.Slides přidává na uložené snímky vodoznak s textem „Evaluation only“. Použijte licenci podle popisu v [Licensing](/slides/cs/nodejs-net/licensing/), aby byl odstraněn.

**Proč bych měl volat `dispose`?**

`Presentation` objekt je podpořen .NET objektem, který drží paměť a další zdroje. Volání `dispose` je uvolní, jakmile prezentaci již nepotřebujete, a volání v bloku `finally` je uvolní i při výskytu chyby.
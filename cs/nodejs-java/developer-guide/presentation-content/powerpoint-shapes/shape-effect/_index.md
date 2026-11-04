---
title: Použití efektů tvarů v prezentacích pomocí JavaScriptu
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/nodejs-java/shape-effect/
keywords:
- efekt tvaru
- efekt stínu
- efekt odrazu
- efekt záře
- efekt měkkých okrajů
- formát efektu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů v JavaScriptu a Aspose.Slides pro Node.js — vytvořte za sekundy působivé, profesionální snímky."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [výplní](/slides/cs/nodejs-java/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit jeho záři atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu PowerPoint nabízí možnosti pod **Preset**. Možnosti Preset jsou kombinace dvou nebo více efektů, o nichž je známo, že vypadají dobře. Tímto způsobem, když vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli pěknou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody pod třídou [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) , které vám umožní použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použít efekt stínu**

Aspose.Slides pro Node.js přes Java podporuje vnější a vnitřní stíny pro tvary. Můžete upravit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použít vnější stín**

Použijte vnější stín, aby karta nebo panel vynikl na pozadí snímku. Stín se rozšiřuje za okraje tvaru a vytváří dojem, že je tvar zvýšen nad snímkem. Upravit jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento JavaScriptový kód ukazuje, jak použít [efekt vnějšího stínu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) na obdélník:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efekt stínu](shadow_effect.png)

### **Použít vnitřní stín**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel získala zapuštěný vzhled. Vnější stín se rozšiřuje mimo tvar a dává mu dojem zvýšení, zatímco vnitřní stín stínuje vnitřek jeho okrajů.

Zavolejte [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), potom nakonfigurujte stín vrácený metodou [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Větší hodnoty poloměru rozostření vytvářejí měkčí okraje.

Tento JavaScriptový příklad vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX. Směr stínu je 225 stupňů, vzdálenost 7 bodů a poloměr rozostření 6 bodů:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Světle modrý obdélník s vnitřním stínem](inner_shadow_effect.png)

Aby se vnitřní stín odstranil, zavolejte [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) na formát efektu tvaru.

## **Použít efekt odrazu**

Aby se v Aspose.Slides pro Node.js přes Java použil efekt odrazu, můžete přidat zrcadlový odraz k tvarům a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že tvarům dodá uhlazenější a sofistikovanější vzhled. Je snadné jej implementovat pomocí jednoduchého kódu, což umožňuje rychlé použití napříč více prvky pro konzistentní design.

Tento JavaScriptový kód ukazuje, jak použít [efekt odrazu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) na tvar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efekt odrazu](reflection_effect.png)

## **Použít efekt záře**

Aby se na tvar v Aspose.Slides pro Node.js přes Java použil efekt záře, můžete přidat měkkou, zářivou auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá zvýraznit tvary a přidává atraktivní, poutavý vizuální prvek do vaší prezentace. Je snadné jej implementovat s minimálním kódem, čímž se zlepšuje celkový vzhled snímků.

Tento JavaScriptový kód ukazuje, jak použít [efekt záře](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) na tvar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efekt záře](glow_effect.png)

## **Použít efekt měkkých okrajů**

Aby se v Aspose.Slides pro Node.js přes Java použil efekt měkkých okrajů, můžete vytvořit plynulý, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro návrhy, které potřebují jemný, měkčí vzhled. Parametry jako poloměr lze snadno upravit, aby se dosáhlo požadovaného efektu u různých tvarů ve vaší prezentaci.

Tento JavaScriptový kód ukazuje, jak použít [efekt měkkých okrajů](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) na tvar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efekt měkkých okrajů](soft_edges_effect.png)

## **Použít efekt rozostření**

Použijte rozostření tvaru k změkčení výplně a obrysu tvaru a zároveň zachovejte editovatelnost tvaru. Zavolejte [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) na formát efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž větší hodnoty vytvářejí silnější rozostření. Poloměr nula ponechává vzhled beze změny.

Nastavení [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) řídí viditelné hranice efektu. S `false` je rozostření oříznuto na původní namalované hranice, včetně obrysu. S `true` může rozostření přesáhnout tyto hranice. Žádné z nastavení nemění pozici ani rozměry tvaru.

Porovnání níže používá po celou dobu stejnou výplň, obrys a rozměry tvaru. Horní řada používá `grow = false`; dolní řada používá `grow = true`.

![Původní obdélník porovnán s rozostřením o poloměrech 5 a 15 bodů, s vypnutým a zapnutým zvětšením](shape_blur_comparison.png)

Tento JavaScriptový příklad vytvoří oranžový obdélník s tmavě modrým obrysem, aplikuje rozostření o 5 bodů a poté jej aktualizuje na rozostření o 15 bodů opětovným zavoláním [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect). Uloží oba rozostřené stavy, následně zavolá [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) a uloží tvar bez rozostření.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozostření tvaru ovlivňuje výplň i obrys společně. Efekt měkkých okrajů zeslabuje okraje tvaru, zatímco rozostření stínu změkčuje jen stín. Efekty transformace obrazu pracují s obsahem obrázku; tento příklad aplikuje rozostření přímo na formát efektu tvaru bez konverze tvaru na obrázek.

## **Často kladené otázky**

**Mohu na stejný tvar použít více efektů?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jednom tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu použít efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu použít efekty na seskupené tvary?**

Ano, můžete použít efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.
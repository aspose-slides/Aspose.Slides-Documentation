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
- efekt měkkých hran
- formát efektu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů v JavaScriptu a Aspose.Slides pro Node.js—vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění objektu, liší se od [výplní](/slides/cs/nodejs-java/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu PowerPoint nabízí možnosti pod **Preset**. Předvolby jsou kombinacemi dvou nebo více efektů, které jsou známy tím, že vypadají dobře. Tím, že vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli pěknou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/), které vám umožní použít stejné efekty na tvary v prezentacích PowerPointu.

## **Použít efekt stínu**

Aspose.Slides pro Node.js via Java podporuje vnější a vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použít vnější stín**

Použijte vnější stín, aby karta nebo panel vynikl na pozadí snímku. Stín přesahuje okraje tvaru a vytváří dojem, že je tvar vyvýšený nad snímkem. Upravit jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento JavaScriptový kód ukazuje, jak aplikovat [vnější efekt stínu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) na obdélník:

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

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel získaly zapuštěný vzhled. Vnější stín se rozprostírá mimo tvar a dává mu dojem vyvýšení, zatímco vnitřní stín stínuje vnitřek jeho okrajů.

Zavolejte [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) a poté nakonfigurujte stín vrácený metodou [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Větší hodnoty poloměru rozostření produkují měkčí hrany.

Tento JavaScriptový příklad vytváří světle modrou kartu s tmavě šedým vnitřním stínem a ukládá ji jako soubor PPTX. Směr stínu je 225 stupňů, jeho vzdálenost je 7 bodů a poloměr rozostření je 6 bodů:

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

Pro odebrání vnitřního stínu zavolejte [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) na formátu efektu tvaru.

### **Použít, změnit a odebrat předdefinovaný stín**

Zavolejte [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) a použijte [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) k výběru [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/). Pro změnu stylu změňte předvolbu na stejném tvaru. Zavolejte [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) pro odebrání stínu při zachování výplně a obrysu.

Tento příklad ukazuje čtyři fáze vedle sebe na jednom snímku. Oba stíny jsou posunuty o 10 bodů. Směr 225° umístí první stín nad a vlevo od obdélníku, a 45° umístí druhý pod a vpravo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, aspose.slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const shape = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    const shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(aspose.slides.PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(aspose.slides.PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Originál | První předvolba | Druhá předvolba | Po odebrání |
| :---: | :---: | :---: | :---: |
| ![Žádný stín](preset_shadow_original.png) | ![Stín v levém horním rohu](preset_shadow_top_left.png) | ![Stín v pravém dolním rohu](preset_shadow_bottom_right.png) | ![Žádný stín po odebrání](preset_shadow_removed.png) |

## **Použít efekt odrazu**

Pro aplikaci efektu odrazu v Aspose.Slides pro Node.js via Java můžete přidat zrcadlový odraz na tvary a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že tvarům dodává uhlazenější a sofistikovanější vzhled. Je snadno implementovatelný pomocí jednoduchého kódu, což umožňuje rychlé použití napříč více prvky pro konzistentní design.

Tento JavaScriptový kód ukazuje, jak aplikovat [efekt odrazu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) na tvar:

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

Pro aplikaci efektu záře na tvar v Aspose.Slides pro Node.js via Java můžete přidat měkkou, zářivou auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá zvýraznit tvary a přidává atraktivní, poutavý vizuální prvek vaší prezentaci. Je snadno implementovatelný s minimálním kódem, což vylepšuje celkový vzhled vašich snímků.

Tento JavaScriptový kód ukazuje, jak aplikovat [efekt záře](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) na tvar:

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

## **Použít efekt měkkých hran**

Pro aplikaci efektu měkkých hran v Aspose.Slides pro Node.js via Java můžete vytvořit plynulý, rozmazaný přechod kolem okrajů tvaru. Tento efekt dodává jemnější a rafinovanější vzhled, ideální pro návrhy, které potřebují jemnější vzhled. Můžete snadno upravit parametry jako poloměr, abyste dosáhli požadovaného efektu napříč různými tvary ve vaší prezentaci.

Tento JavaScriptový kód ukazuje, jak aplikovat [efekt měkkých hran](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) na tvar:

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

![Efekt měkkých hran](soft_edges_effect.png)

## **Použít efekt rozostření**

Použijte rozostření tvaru k zeslabení výplně a obrysu tvaru při zachování editovatelnosti tvaru. Zavolejte [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) na formátu efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž větší hodnoty produkují silnější rozostření. Poloměr nula ponechává vzhled nezměněný.

Nastavení [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) řídí viditelné hranice efektu. S `false` je rozostření oříznuto na původní namalované hranice, včetně obrysu. S `true` může rozostření přesahovat tyto hranice. Žádné z nastavení nemění pozici ani rozměry tvaru.

Níže uvedené srovnání používá stejnou výplň, obrys a rozměry tvaru po celou dobu. Horní řada používá `grow = false`; dolní řada používá `grow = true`.

![Originální obdélník s rozostřeními 5 a 15 bodů, s vypnutým a zapnutým růstem](shape_blur_comparison.png)

Tento JavaScriptový příklad vytváří oranžový obdélník s tmavě modrým obrysem, použije rozostření 5 bodů a poté jej aktualizuje na rozostření 15 bodů opětovným zavoláním [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect). Uloží oba rozostřené stavy, poté zavolá [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) a uloží tvar bez rozostření.

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

Rozostření tvaru ovlivňuje výplň a obrys společně. Efekt měkkých hran zeslabuje hrany tvaru, zatímco rozostření stínu měkčí pouze stín. Efekty transformace obrazu působí na obsah obrázku; tento příklad aplikuje rozostření přímo na formát efektu tvaru bez převodu tvaru na obrázek.

## **Často kladené otázky**

**Mohu použít více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako je stín, odraz a záře, na jednom tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Můžete aplikovat efekty na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt se použije na celou skupinu.
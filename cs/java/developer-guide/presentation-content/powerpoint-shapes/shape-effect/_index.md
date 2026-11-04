---
title: Aplikace efektů tvarů v prezentacích pomocí Javy
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/java/shape-effect/
keywords:
- efekt tvaru
- efekt stínu
- efekt odrazu
- efekt záře
- efekt měkkých okrajů
- formát efektu
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Přetvořte své soubory PPT a PPTX pomocí pokročilých efektů tvarů v Aspose.Slides pro Java—vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění objektu, liší se od [výplní](/slides/cs/java/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na objektu, rozšířit jeho záři atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu PowerPoint nabízí možnosti v sekci **Preset**. Možnosti Preset jsou kombinace dvou nebo více efektů, které jsou známé tím, že vypadají dobře. Tímto způsobem, výběrem předvolby, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli vhodnou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/), které umožňují použít stejné efekty na tvary v prezentacích PowerPoint.

## **Aplikovat efekt stínu**

Aspose.Slides pro Java podporuje vnější a vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření, aby odpovídaly designu vaší prezentace.

### **Aplikovat vnější stín**

Použijte vnější stín, aby karta nebo panel vystoupily na pozadí snímku. Stín přesahuje okraje tvaru a vytváří dojem, že tvar je nad snímkem. Přizpůsobte jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento Java kód ukazuje, jak aplikovat [efekt vnějšího stínu](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) na obdélník:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Stínový efekt](shadow_effect.png)

### **Aplikovat vnitřní stín**

Pro reprodukci vizuálního stylu šablony použijte vnitřní stín, který kartě nebo panelu dodá zapuštěný vzhled. Vnější stín vyčnívá mimo tvar a způsobí, že vypadá zvýšený, zatímco vnitřní stín stínuje vnitřní část jeho okrajů.

Zavolejte [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), poté nakonfigurujte stín vrácený metodou [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Větší hodnoty poloměru rozostření produkují měkčí hrany.

Tento Java příklad vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX. Směr stínu je 225 stupňů, vzdálenost je 7 bodů a poloměr rozostření je 6 bodů:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Světle modrý obdélník s vnitřním stínem](inner_shadow_effect.png)

Chcete-li odstranit vnitřní stín, zavolejte [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) na formát efektu tvaru.

## **Aplikovat efekt odrazu**

Chcete-li použít odrazový efekt v Aspose.Slides pro Java, můžete přidat zrcadlový odraz k tvarům a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že tvarům dodává uhlazenější a sofistikovanější vzhled. Je snadno implementovatelný pomocí jednoduchého kódu, což umožňuje rychlé použití napříč více prvky pro jednotný design.

Tento Java kód ukazuje, jak aplikovat [efekt odrazu](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) na tvar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efekt odrazu](reflection_effect.png)

## **Aplikovat efekt záře**

Chcete-li použít efekt záře na tvar v Aspose.Slides pro Java, můžete přidat jemnou, zářivou auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvarům vyniknout a přidává atraktivní, upoutávající vizuální prvek do vaší prezentace. Je snadno implementovatelný s minimálním kódem, čímž zlepšuje celkový vzhled vašich snímků.

Tento Java kód ukazuje, jak aplikovat [efekt záře](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) na tvar:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efekt záře](glow_effect.png)

## **Aplikovat efekt měkkých okrajů**

Chcete-li použít efekt měkkých okrajů v Aspose.Slides pro Java, můžete vytvořit hladký, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Parametry jako poloměr lze snadno upravit k dosažení požadovaného efektu na různých tvarech v prezentaci.

Tento Java kód ukazuje, jak aplikovat [efekt měkkých okrajů](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) na tvar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efekt měkkých okrajů](soft_edges_effect.png)

## **Aplikovat efekt rozmazání**

Použijte rozmazání tvaru k změkčení výplně a obrysu tvaru a přitom ponechte tvar editovatelný. Zavolejte [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) na formát efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž větší hodnoty vytvářejí silnější rozmazání. Poloměr nula ponechává vzhled nezměněný.

Nastavení [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) řídí viditelné hranice efektu. S hodnotou `false` je rozmazání oříznuto na původní natřené hranice, včetně obrysu. S hodnotou `true` může rozmazání přesahovat tyto hranice. Žádné nastavení nemění pozici ani rozměry tvaru.

Srovnání níže používá stejnou výplň, obrys a rozměry tvaru po celou dobu. Horní řada použije `grow = false`; spodní řada použije `grow = true`.

![Původní obdélník porovnaný s poloměry rozmazání 5 a 15 bodů, s vypnutým a zapnutým rozšířením](shape_blur_comparison.png)

Tento Java příklad vytvoří oranžový obdélník s tmavě modrým obrysem, použije 5‑bodové rozmazání a poté jej aktualizuje na 15‑bodové rozmazání zavoláním [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) znovu. Uloží oba rozmazané stavy, poté zavolá [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) a uloží tvar bez rozmazání.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rozmazání tvaru ovlivňuje výplň i obrys současně. Efekt měkkých okrajů ztmavne okraje tvaru, zatímco rozmazání stínu změkčuje jen stín. Transformace obrazu působí na obsah obrázku; tento příklad aplikuje rozmazání přímo na formát efektu tvaru bez převodu tvaru na obrázek.

## **Často kladené otázky**

**Mohu na stejný tvar použít více efektů?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jediném tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete použít efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.
---
title: Použití efektů tvarů v prezentacích na Androidu
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/androidjava/shape-effect/
keywords:
- efekt tvaru
- stínový efekt
- odrazový efekt
- efekt záře
- efekt měkkých okrajů
- formát efektu
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů s Aspose.Slides pro Android přes Java — vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu mohou být použity k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/androidjava/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Můžete použít jeden nebo více efektů na tvar.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu PowerPoint poskytuje možnosti pod **Předvolba**. Možnosti Předvolby jsou kombinace dvou nebo více efektů, o kterých se ví, že vypadají dobře. Tímto způsobem, výběrem předvolby, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli vhodnou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/), které vám umožňují použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použít stínový efekt**

Aspose.Slides pro Android přes Java podporuje vnější a vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použít vnější stín**

Použijte vnější stín, aby karta nebo panel vynikl vůči pozadí snímku. Stín se rozprostírá za hranice tvaru a vytváří dojem, že tvar je nad snímkem. Upravit jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento Java kód ukazuje, jak použít [vnější stínový efekt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) na obdélník:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Stínový efekt](shadow_effect.png)

### **Použít vnitřní stín**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel získaly zapuštěný vzhled. Vnější stín se rozšiřuje mimo tvar a vytvoří dojem, že je nadýchaný, zatímco vnitřní stín zakrývá vnitřní část jeho hran.

Zavolejte [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--), poté nakonfigurujte stín vrácený metodou [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Větší hodnoty poloměru rozostření vytvářejí měkčí hrany.

Tento Java příklad vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX. Směr stínu je 225 stupňů, vzdálenost je 7 bodů a poloměr rozostření je 6 bodů:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Světle modrý obdélník s vnitřním stínem](inner_shadow_effect.png)

Pro odstranění vnitřního stínu zavolejte [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) na effect format tvaru.

## **Použít odrazový efekt**

Pro použití odrazového efektu v Aspose.Slides pro Android přes Java můžete přidat zrcadlový odraz k tvarům a upravit parametry, jako jsou vzdálenost, průhlednost a velikost. Tento efekt vylepšuje estetiku vašich prezentací tím, že tvarům dodává hladší a sofistikovanější vzhled. Je snadné jej implementovat pomocí jednoduchého kódu, což umožňuje rychlé nasazení napříč více prvky pro jednotný design.

Tento Java kód ukazuje, jak použít [odrazový efekt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) na tvar:

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

![Odrazový efekt](reflection_effect.png)

## **Použít efekt záře**

Pro použití zářivého efektu na tvar v Aspose.Slides pro Android přes Java můžete přidat měkkou, zářivou auru kolem tvarů a upravit vlastnosti, jako jsou barva a velikost. Tento efekt pomáhá zvýraznit tvary a přidává atraktivní, upoutávající vizuální prvek k vaší prezentaci. Je snadné jej implementovat s minimálním kódem, čímž se zlepšuje celkový vzhled vašich snímků.

Tento Java kód ukazuje, jak použít [efekt záře](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) na tvar:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Použít efekt měkkých okrajů**

Pro použití efektu měkkých okrajů v Aspose.Slides pro Android přes Java můžete vytvořit hladký, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Můžete snadno upravit parametry, jako je poloměr, abyste dosáhli požadovaného efektu na různých tvarech ve vaší prezentaci.

Tento Java kód ukazuje, jak použít [efekt měkkých okrajů](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) na tvar:

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

## **Použít rozostřený efekt**

Použijte rozostření tvaru k změkčení výplně a obrysu tvaru při zachování jeho editovatelnosti. Zavolejte [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) na effect format tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž větší hodnoty vytvářejí silnější rozostření. Poloměr nula ponechává vzhled beze změny.

Nastavení [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) řídí viditelné hranice efektu. S `false` je rozostření oříznuto na původní natřené hranice, včetně obrysu. S `true` může rozostření přesáhnout tyto hranice. Žádné nastavení nemění pozici ani rozměry tvaru.

Níže uvedené srovnání používá stejnou výplň, obrys a rozměry tvaru po celou dobu. Horní řádek používá `grow = false`; spodní řádek používá `grow = true`.

![Původní obdélník porovnán s rozostřením (poloměry 5 a 15 bodů) při vypnutém a zapnutém růstu](shape_blur_comparison.png)

Tento Java příklad vytvoří oranžový obdélník s tmavě modrým obrysem, použije rozostření o 5 bodů a následně jej aktualizuje na rozostření o 15 bodů voláním [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) znovu. Uloží oba rozostřené stavy, poté zavolá [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) a uloží tvar bez rozostření.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

Rozostření tvaru ovlivňuje výplň i obrys společně. Efekt měkkých okrajů rozplývá hrany tvaru, zatímco rozostření stínu změkčuje pouze stín. Efekty transformace obrazu působí na obsah obrazu; tento příklad aplikuje rozostření přímo na effect format tvaru, aniž by tvar převáděl na obrázek.

## **Často kladené otázky**

**Mohu použít více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jediném tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Můžete aplikovat efekty na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt se použije na celou skupinu.
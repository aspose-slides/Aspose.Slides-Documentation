---
title: Použít efekty tvarů v prezentacích na Androidu
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/androidjava/shape-effect/
keywords:
- efekt tvaru
- stínový efekt
- odrazový efekt
- efekt záře
- efekt měkkých hran
- formát efektu
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů s Aspose.Slides pro Android prostřednictvím Javy — vytvořte působivé, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/androidjava/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit jeho záři atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Můžete použít jeden nebo více efektů na tvar.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu PowerPoint nabízí možnosti pod **Preset**. Možnosti Preset jsou kombinace dvou nebo více efektů, o kterých se ví, že vypadají dobře. Tímto způsobem, když vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů k nalezení vhodné kombinace.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/), které umožňují použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použít stínový efekt**

Aspose.Slides pro Android prostřednictvím Javy podporuje vnější a vnitřní stíny pro tvary. Můžete upravit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použít vnější stín**

Použijte vnější stín, aby karta nebo panel vynikly proti pozadí snímku. Stín přesahuje okraje tvaru a vytváří dojem, že je tvar nadzvednutý nad snímkem. Upravením barvy, směru, vzdálenosti a poloměru rozostření přizpůsobíte osvětlení a styl vaší šablony.

Tento Java kód ukazuje, jak použít [vnějšího stínového efektu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) na obdélník:

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

#### **Ovládání směru stínu při otáčení tvaru**

Ve výchozím nastavení se vnější stín otáčí spolu s tvarem. Aby se tvary s různými otočeními jevily osvětlené ze stejného směru, zavolejte [setRotateShadowWithShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) s `false` a použijte [setDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setDirection-float-) k nastavení stejných směrů stínů.

Příklad vytvoří dvě modré šipky se šedými stíny posunutými o 42 bodů doprava (0°). Poté duplikuje snímek a otočí obě šipky o 90° ve směru hodinových ručiček.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(128, 128, 128));
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Na druhém snímku vrhá levá šipka svůj stín dolů, zatímco pravá šipka stále vrhá stín doprava. Nastavený směr zůstává 0° pro oba stíny.

![Vykreslení PowerPointu před a po otočení o 90°. Oba stíny začínají vpravo. Po otočení se stín přesune pod levou šipku a zůstane vpravo od pravé šipky.](arrow-shadow-rotation.png)

### **Použít vnitřní stín**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel získaly zapuštěný vzhled. Vnější stín se rozšiřuje mimo tvar a dává mu vzhled zvýšeného, zatímco vnitřní stín ztmaví vnitřní část jeho okrajů.

Zavolejte [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--), poté nastavte stín získaný pomocí [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Větší hodnoty poloměru rozostření produkují měkčí hrany.

Tento Java příklad vytvoří světlemodrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX. Směr stínu je 225 stupňů, vzdálenost 7 bodů a poloměr rozostření 6 bodů:

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

![Světlemodrý obdélník s vnitřním stínem](inner_shadow_effect.png)

Chcete-li odebrat vnitřní stín, zavolejte [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) na formátu efektu tvaru.

### **Použít, změnit a odstranit přednastavený stín**

Zavolejte [enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) a použijte [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) k výběru [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/). Pro změnu stylů změňte předvolbu u stejného tvaru. Zavolejte [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) k odstranění stínu při zachování výplně a obrysu.

Tento příklad ukazuje čtyři fáze vedle sebe na jednom snímku. Oba stíny jsou posunuty o 10 bodů. Směr 225° umístí první stín nad a vlevo od obdélníku, a 45° umístí druhý pod a vpravo.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Původní | První předvolba | Druhá předvolba | Po odstranění |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Použít odrazový efekt**

Chcete‑li použít odrazový efekt v Aspose.Slides pro Android prostřednictvím Javy, můžete přidat zrcadlový odraz k tvarům a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt zlepší estetiku vašich prezentací tím, že tvarům dodá uhlazený a sofistikovaný vzhled. Je snadno implementovatelný pomocí jednoduchého kódu, což umožňuje rychlé použití napříč více prvky pro konzistentní design.

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

## **Použít zářivý efekt**

Chcete-li použít efekt záře na tvar v Aspose.Slides pro Android prostřednictvím Javy, můžete přidat měkkou, zářivou auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvarům vyniknout a přidává atraktivní, upoutávající vizuální prvek do vaší prezentace. Je snadno implementovatelný s minimálním kódem, čímž vylepšuje celkový vzhled vašich snímků.

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

![Zářivý efekt](glow_effect.png)

## **Použít efekt měkkých hran**

Chcete-li použít efekt měkkých hran v Aspose.Slides pro Android prostřednictvím Javy, můžete vytvořit plynulý, rozostřený přechod kolem okrajů tvaru. Tento efekt přidává subtilnější a propracovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Parametry, jako je poloměr, lze snadno upravit pro dosažení požadovaného efektu na různých tvarech ve vaší prezentaci.

Tento Java kód ukazuje, jak použít [efekt měkkých hran](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) na tvar:

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

![Efekt měkkých hran](soft_edges_effect.png)

## **Použít rozostřovací efekt**

Použijte rozostření tvaru k zeslabování výplně a obrysu tvaru při zachování editovatelnosti tvaru. Zavolejte [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) na formátu efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž vyšší hodnoty produkují silnější rozostření. Poloměr nula ponechává vzhled beze změny.

Nastavení [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) řídí viditelné hranice efektu. Při `false` je rozostření oříznuto na původní nakreslené hranice, včetně obrysu. Při `true` může rozostření přesáhnout tyto hranice. Žádné nastavení nemění polohu ani rozměry tvaru.

Níže uvedené srovnání používá stejnou výplň, obrys a rozměry tvaru po celé době. Horní řada používá `grow = false`; dolní řada používá `grow = true`.

![Původní obdélník porovnán s rozostřením o poloměrech 5 a 15 bodů, s grow vypnutým a zapnutým](shape_blur_comparison.png)

Tento Java příklad vytvoří oranžový obdélník s tmavě modrým obrysem, použije rozostření o 5 bodů a poté jej aktualizuje na rozostření o 15 bodů voláním [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) znovu. Uloží oba rozostřené stavy, pak zavolá [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) a uloží tvar bez rozostření.

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

Rozostření tvaru postihuje zároveň výplň i obrys. Efekt měkkých hran zeslabuje hrany tvaru, zatímco rozostření stínu zeslabuje jen stín. Efekty transformace obrazu působí na obsah obrazu; tento příklad aplikuje rozostření přímo na formát efektu tvaru, aniž by tvar převáděl na obrázek.

## **FAQ**

**Mohu na stejný tvar použít více efektů?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jednom tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu použít efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu použít efekty na seskupené tvary?**

Ano, můžete použít efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.
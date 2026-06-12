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
description: "Přeměňte své soubory PPT a PPTX pomocí pokročilých efektů tvarů s Aspose.Slides pro Javu — vytvořte úderné, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/java/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.  

* Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu jsou v PowerPointu k dispozici možnosti pod **Preset**. Předvolby jsou v podstatě ověřená kombinace dvou nebo více efektů, která vypadá dobře. Tím, že vyberete předvolbu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli hezkou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/EffectFormat), které vám umožní použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použití stínového efektu**

Tento Java kód ukazuje, jak použít efekt vnějšího stínu ([OuterShadowEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) na obdélník:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Použití odrazového efektu**

Tento Java kód ukazuje, jak použít odrazový efekt na tvar:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Použití efektu záře**

Tento Java kód ukazuje, jak použít efekt záře na tvar:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Použití efektu měkkých okrajů**

Tento Java kód ukazuje, jak použít měkké okraje na tvar:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Mohu použít více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jednom tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu použít efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt se použije na celou skupinu.
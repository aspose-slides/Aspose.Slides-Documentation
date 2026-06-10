---
title: Prezentációs Témák Kezelése JavaScriptben
linktitle: Prezentációs Téma
type: docs
weight: 10
url: /hu/nodejs-java/presentation-theme/
keywords:
- PowerPoint téma
- prezentációs téma
- dia téma
- téma beállítása
- téma módosítása
- téma kezelése
- téma színe
- kiegészítő paletta
- téma betűtípusa
- téma stílusa
- téma hatása
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje a prezentációs témákat JavaScriptben az Aspose.Slides for Node.js segítségével, hogy PowerPoint fájlokat hozzon létre, testreszabjon és konvertáljon következetes márkaarculattal."
---
## **Bevezetés**

A prezentációs sablon meghatározza a tervezési elemek tulajdonságait. Amikor egy prezentációs sablont választ, lényegében egy meghatározott vizuális elemek és azok tulajdonságainak halmazát választja ki.

A PowerPointban egy sablon színekből, [betűtípusok](/slides/hu/nodejs-java/powerpoint-fonts/), [háttérstílusok](/slides/hu/nodejs-java/presentation-background/), és hatásokból áll.

![theme-constituents](theme-constituents.png)

## **Téma Színének Módosítása**

A PowerPoint sablon a dián lévő különböző elemekhez egy meghatározott színkészletet használ. Ha nem tetszenek a színek, új színeket alkalmazva módosíthatja a sablont. Az új téma színének kiválasztásához az Aspose.Slides a [SchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SchemeColor) felsorolásban biztosít értékeket.

Ez a JavaScript kód azt mutatja meg, hogyan változtatható meg a kiemelés színe a sablonban:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

A kapott szín tényleges értékét így határozhatja meg:
```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Az átszínezés műveletének további bemutatásához létrehozunk egy másik elemet, és ráhúzzuk a kiemelés színét (az első műveletből). Ezután megváltoztatjuk a színt a sablonban:
```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Az új szín automatikusan alkalmazásra kerül mindkét elemre.

### **Téma Színének Beállítása Kiegészítő Palettáról**

Amikor a fő téma színén (1) luminancia‑transzformációkat alkalmaz, a kiegészítő palettáról (2) színek alakulnak ki. Ezeket a téma színeket ezután beállíthatja és lekérheti.

![additional-palette-colors](additional-palette-colors.png)

**1** - Fő téma színek  
**2** - Színek a kiegészítő palettáról.

Ez a JavaScript kód bemutat egy olyan műveletet, ahol a kiegészítő paletta színeit a fő téma színéből nyeri ki, majd alakzatokban használja:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Akcentus 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Akcentus 4, Világosabb 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Akcentus 4, Világosabb 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Akcentus 4, Világosabb 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Akcentus 4, Sötétebb 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Akcentus 4, Sötétebb 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **`SchemeColor` leképezése a `ColorScheme` színekre**

Amikor a [SchemeColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/schemecolor/)‑vel dolgozik, észreveheti, hogy a következő téma színértékeket tartalmazza:

`Background1`, `Background2`, `Text1`, és `Text2`.

Azonban a `Presentation.getMasterTheme().getColorScheme()` egy [ColorScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/colorscheme/)‑t ad vissza, amely a megfelelő színeket a következőként teszi közzé:

`Dark1`, `Dark2`, `Light1`, és `Light2`.

Ez a néveltérés a Microsoft Office terminológiájából ered. A régebbi Office verziók a `Dark 1`, `Light 1`, `Dark 2` és `Light 2` elnevezéseket használták, míg az újabb felhasználói felületek ugyanazokat a helyeket `Text 1`, `Background 1`, `Text 2`, és `Background 2` néven jelenítik meg.

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Nincs dinamikus konverzió a `Text`/`Background` és a `Dark`/`Light` között. Egyszerűen csak alternatív nevei ugyanannak a téma színnek.

## **Téma Betűtípusának Módosítása**

Ahhoz, hogy a sablonokhoz és egyéb célokhoz betűtípusokat választhasson, az Aspose.Slides ezeket a speciális azonosítókat használja (hasonlóan a PowerPointhoz):

* **+mn-lt** - Test betűtípus latin (Minor Latin Font)
* **+mj-lt** - Címsor betűtípus latin (Major Latin Font)
* **+mn-ea** - Test betűtípus kelet‑ázsiai (Minor East Asian Font)
* **+mj-ea** - Címsor betűtípus kelet‑ázsiai (Major East Asian Font)

Ez a JavaScript kód azt mutatja, hogyan rendelhet latin betűtípust egy sablon elemhez:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Ez a JavaScript kód azt mutatja, hogyan változtatható meg a prezentáció sablon betűtípusa:
```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

A betűtípus minden szövegdobozban frissülni fog.

{{% alert color="primary" title="TIP" %}} 
Érdemes megnézni a [PowerPoint betűtípusokat](/slides/hu/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Téma Háttérstílusának Módosítása**

Alapértelmezés szerint a PowerPoint alkalmazás 12 előre definiált háttérstílust kínál, de ezek közül csak 3 van mentve egy tipikus prezentációban.

![todo:image_alt_text](presentation-design_8.png)

Például, miután menti a prezentációt a PowerPoint alkalmazásban, futtathatja ezt a JavaScript kódot, hogy megtudja a prezentációban lévő előre definiált háttérstílusok számát:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
A [BackgroundFillStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) tulajdonságot a [FormatScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FormatScheme) osztályból használva hozzáadhat vagy elérheti a háttérstílust egy PowerPoint sablonban.
{{% /alert %}} 

Ez a JavaScript kód azt mutatja, hogyan állítható be a háttér egy prezentációhoz:
```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Index útmutató**: 0 jelenti a kitöltés hiányát. Az index 1‑től kezdődik.

{{% alert color="primary" title="TIP" %}} 
Érdemes megnézni a [PowerPoint háttér](/slides/hu/nodejs-java/presentation-background/).
{{% /alert %}}

## **Téma Hatásának Módosítása**

A PowerPoint sablon általában 3 értéket tartalmaz minden stílus táblázatban. Ezeket a táblázatokat kombinálják a 3 hatásba: finom, közepes és intenzív. Például ez a végeredmény, amikor a hatásokat egy konkrét alakzatra alkalmazzák:
![todo:image_alt_text](presentation-design_10.png)

Az [FillStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--) három tulajdonságot a [FormatScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FormatScheme) osztályból használva módosíthatja a sablon elemeit (még rugalmasabban, mint a PowerPoint lehetőségei).

Ez a JavaScript kód azt mutatja, hogyan változtatható meg egy téma hatása az elemek részeinek módosításával:
```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

A kapott változások a kitöltő színben, kitöltés típusában, árnyékhatásban stb.:
![todo:image_alt_text](presentation-design_11.png)

## **GYIK**

**Alkalmazhatok‑e sablont egyetlen diára a mester módosítása nélkül?**  
Igen. Az Aspose.Slides támogatja a diához szintű téma felülírását, így egy helyi sablont csak arra a diára alkalmazhat, miközben a mester témát érintetlenül hagyja (a [SlideThemeManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidethememanager/) segítségével).

**Mely a legbiztonságosabb módja egy téma átvitelének egy prezentációról a másikra?**  
A [Klónozott diák](/slides/hu/nodejs-java/clone-slides/) együtt a masterrel a célprezentációba a legbiztonságosabb módja. Ez megőrzi az eredeti mastert, elrendezéseket és a kapcsolódó témát, így a megjelenés konzisztens marad.

**Hogyan tekinthetem meg a „effective” értékeket minden öröklődés és felülírás után?**  
Használja az API ["effective" views](/slides/hu/nodejs-java/shape-effective-properties/) funkcióját a téma/szín/betűtípus/hatás esetén. Ezek visszaadják a feloldott, végső tulajdonságokat a mester és a helyi felülírások alkalmazása után.
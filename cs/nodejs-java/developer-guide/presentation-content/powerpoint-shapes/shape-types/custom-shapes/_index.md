---
title: Přizpůsobení tvarů v prezentacích v JavaScriptu
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/nodejs-java/custom-shape/
keywords:
- vlastní tvar
- přidat tvar
- vytvořit tvar
- změnit tvar
- geometrie tvaru
- cesta geometrie
- body cesty
- editační body
- přidat bod
- odstranit bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v prezentacích PowerPoint pomocí JavaScriptu a Aspose.Slides pro Node.js: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary v prezentacích v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s `GeometryPath` pro úpravu existujících tvarů, provádět základní operace úprav cesty, přidávat nebo odstraňovat body a použít aktualizovanou geometrii zpět na tvar.

Také demonstruje, jak vytvořit vlastní a složené tvary, sestavit tvary s zakřivenými rohy, určit, zda je geometrie tvaru uzavřená, a převést mezi `GeometryPath` a `java.awt.Shape` pro další scénáře přizpůsobení geometrie.

## **Změna tvaru pomocí editačních bodů**

Zvažte čtverec. V PowerPointu můžete pomocí **edit points**  

* posunout roh čtverce dovnitř nebo ven  
* zadat zakřivení rohu nebo bodu  
* přidat nové body do čtverce  
* manipulovat s body na čtverci atd.  

V podstatě můžete provádět popsané úkoly na libovolném tvaru. Používáním editačních bodů můžete změnit tvar nebo vytvořit nový tvar z existujícího.

## **Tipy pro úpravu tvarů**

![overview_image](custom_shape_0.png)

Než začnete upravovat tvary v PowerPointu pomocí editačních bodů, zvažte následující body o tvarech:

* Tvar (nebo jeho cesta) může být uzavřený nebo otevřený.  
* Když je tvar uzavřený, postrádá počáteční nebo koncový bod. Když je tvar otevřený, má začátek a konec.  
* Všechny tvary se skládají z alespoň 2 ukotvacích bodů propojených čarami.  
* Čára je buď přímá, nebo zakřivená. Ukotvacující body určují charakter čáry.  
* Ukotvacující body existují jako rohové body, přímé body nebo hladké body:  
  * Rohový bod je bod, kde se dva přímé úseky setkají pod úhlem.  
  * Hladký bod je bod, kde jsou dva ovládací úchyty v přímé linii a úseky čáry se spojují do hladké křivky. V tomto případě jsou všechny úchyty od ukotvovacího bodu ve stejném odstupu.  
  * Přímý bod je bod, kde jsou dva ovládací úchyty v přímé linii a úseky čáry se spojují do hladké křivky. V tomto případě nemusí být úchyty od ukotvovacího bodu ve stejném odstupu.  
* Posunem nebo úpravou ukotvacujících bodů (což mění úhel čar) můžete změnit vzhled tvaru.  

Pro úpravu tvarů v PowerPointu pomocí editačních bodů poskytuje **Aspose.Slides** třídu [**GeometryPath**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath) a třídu [**GeometryPath**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath).

* Instance [GeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath) představuje geometrickou cestu objektu [GeometryShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryShape).  
* Pro získání `GeometryPath` z instance `GeometryShape` můžete použít metodu [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--).  
* Pro nastavení `GeometryPath` pro tvar můžete použít tyto metody: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) pro *plné tvary* a [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) pro *složené tvary*.  
* Pro přidání segmentů můžete použít metody pod [GeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath).  
* Pomocí metod [GeometryPath.setStroke](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) a [GeometryPath.setFillMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) můžete nastavit vzhled geometrické cesty.  
* Pomocí metody [GeometryPath.getPathData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath#getPathData--) můžete získat geometrickou cestu `GeometryShape` jako pole segmentů cesty.  
* Pro přístup k dalším možnostem úpravy geometrie tvaru můžete převést [GeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
* Použijte metody [geometryPathToGraphicsPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) a [graphicsPathToGeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (z třídy [ShapeUtil](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeUtil)) k převodu [GeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) zpět a vpřed.

## **Jednoduché operace úprav**

Tento JavaScriptový kód ukazuje, jak

**Přidat úsečku** na konec cesty

```javascript
lineTo(point);
lineTo(x, y);
```
**Přidat úsečku** na určenou pozici cesty:

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**Přidat kubickou Bézierovu křivku** na konec cesty:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Přidat kubickou Bézierovu křivku** na určenou pozici cesty:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Přidat kvadratickou Bézierovu křivku** na konec cesty:

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**Přidat kvadratickou Bézierovu křivku** na určenou pozici cesty:

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**Připojit daný oblouk** k cestě:

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**Uzavřít aktuální obrazec** cesty:

```javascript
closeFigure();
```
**Nastavit pozici pro další bod**:

```javascript
moveTo(point);
moveTo(x, y);
```
**Odstranit segment cesty** na zadaném indexu:

```javascript
removeAt(index);
```

## **Přidat vlastní body do tvaru**
1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryShape) a nastavte typ [ShapeType.Rectangle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeType).  
2. Získejte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath) ze tvaru.  
3. Přidejte nový bod mezi dva horní body na cestě.  
4. Přidejte nový bod mezi dva spodní body na cestě.  
5. Použijte cestu na tvar.  

Tento JavaScriptový kód ukazuje, jak přidat vlastní body do tvaru:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example1_image](custom_shape_1.png)

## **Odebrat body z tvaru**

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryShape) a nastavte typ [ShapeType.Heart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeType).  
2. Získejte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath) ze tvaru.  
3. Odstraňte segment cesty.  
4. Použijte cestu na tvar.  

Tento JavaScriptový kód ukazuje, jak odebrat body z tvaru:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example2_image](custom_shape_2.png)

## **Vytvořit vlastní tvar**

1. Vypočítejte body pro tvar.  
2. Vytvořte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath).  
3. Naplňte cestu body.  
4. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryShape).  
5. Použijte cestu na tvar.  

Tento JavaScript ukazuje, jak vytvořit vlastní tvar:

```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example3_image](custom_shape_3.png)


## **Vytvořit složený vlastní tvar**

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryShape).  
2. Vytvořte první instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath).  
3. Vytvořte druhou instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath).  
4. Použijte cesty na tvar.  

Tento JavaScriptový kód ukazuje, jak vytvořit složený vlastní tvar:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example4_image](custom_shape_4.png)

## **Vytvořit vlastní tvar se zakřivenými rohy**

Tento JavaScriptový kód ukazuje, jak vytvořit vlastní tvar se zakřivenými rohy (dovnitř):

```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();
    childShape.setGeometryPath(geometryPath);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zjistit, zda je geometrie tvaru uzavřená**

Uzavřený tvar je definován jako takový, kde všechny jeho strany spojují, vytvářejí jedinou hranici bez mezer. Takový tvar může být jednoduchý geometrický útvar nebo složitý vlastní obrys. Následující ukázkový kód ukazuje, jak zjistit, zda je geometrie tvaru uzavřená:

```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```

## **Převést GeometryPath na java.awt.Shape** 

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryShape).  
2. Vytvořte instanci třídy [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
3. Převěďte instanci [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) na instanci [GeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/GeometryPath) pomocí [ShapeUtil](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeUtil).  
4. Použijte cesty na tvar.  

Tento JavaScriptový kód – implementace výše uvedených kroků – demonstruje proces převodu **GeometryPath** na **GraphicsPath**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Vytvořit nový tvar
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Získat geometrickou cestu tvaru
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Vytvořit novou grafickou cestu s textem
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // Převést grafickou cestu na geometrickou cestu
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Nastavit kombinaci nové geometrické cesty a původní geometrické cesty na tvar
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **Často kladené otázky**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstává s tvarem; mění se pouze obrys. Výplň a obrys jsou automaticky použity na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte metodu [setRotation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/setrotation/) tvaru; geometrie se otočí spolu s tvarem, protože je svázána s vlastním souřadnicovým systémem tvaru.

**Mohu převést vlastní tvar na obrázek a „uzamknout“ výsledek?**

Ano. Exportujte požadovanou [slide](/slides/cs/nodejs-java/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/nodejs-java/create-shape-thumbnails/) do rastrového formátu; to usnadní další práci s těžkými geometriemi.
---
title: PowerPoint tinta objektumok kezelése JavaScriptben
linktitle: Tinta kezelése
type: docs
weight: 95
url: /hu/nodejs-java/manage-ink/
keywords:
- tinta
- tinta objektum
- tinta nyom
- tinta kezelése
- tinta rajzolás
- rajzolás
- tinta export
- tinta renderelés
- tinta elrejtése
- InkOptions
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Kezelje a PowerPoint tinta objektumokat, szerkessze a nyomokat és az ecset tulajdonságait, valamint szabályozza a tinta megjelenését PDF, HTML, SVG, TIFF és kép exportálása során az Aspose.Slides for Node.js segítségével Java‑on keresztül."
---
## **Bevezetés**

A PowerPoint egy tinta funkciót biztosít, amely lehetővé teszi, hogy szabad formájú vonalakat rajzolj. A tinta használható más objektumok kiemelésére, kapcsolatok és folyamatok megjelenítésére, valamint a dián lévő konkrét elemek figyelemfelkeltésére.

Az Aspose.Slides biztosítja a tintával kapcsolatos objektumok kezeléséhez szükséges típusokat. Például a [Ink](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ink/) osztály egy tintát jelképez egy dián.

## **Különbségek a szokásos objektumok és a tinta objektumok között**

A PowerPoint diákon lévő objektumokat általában alakzatobjektumok képviselik. Egyszerű formájukban egy alakzat egy tároló, amely meghatározza az objektum területét (keretét) a méret, forma és háttér tulajdonságokkal együtt. További információkért lásd a [Shape Layout Format](https://docs.aspose.com/slides/hu/nodejs-java/shape-manipulations/#access-layout-formats-for-shape) szekciót.

Azonban amikor a PowerPoint egy tinta objektumot kezel, figyelmen kívül hagyja az objektum keretének (tárolójának) minden tulajdonságát, kivéve annak méretét. A tároló terület mérete a szabványos [Shape.getWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getWidth--) és [Shape.getHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getHeight--) metódusok által van meghatározva:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintavonalak**

Egy tintavonal egy alapvető elem, amely a toll útvonalát rögzíti, amikor a felhasználó digitális tintát ír. A vonal egy összekapcsolt pontsorozatot tárol.

A kódolás legegyszerűbb formája minden mintapont X és Y koordinátáit adja meg. Ha az összekapcsolt pontok megjelennek, egy ilyen képet kapunk:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecset tulajdonságok a rajzoláshoz**

Az ecsetet arra használják, hogy vonalakat rajzoljanak, amelyek összekötik a tintavonal pontjait. Az ecset saját színnel és mérettel rendelkezik, amelyet a [InkBrush.getColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkbrush/#getColor--) és a [InkBrush.getSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkbrush/#getSize--) metódusok képviselnek.

### **Ecset színének beállítása**

Ez a JavaScript‑kód bemutatja, hogyan lehet beállítani egy tinta ecset színét:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Ecset méretének beállítása**

Ez a JavaScript‑kód bemutatja, hogyan lehet beállítani egy tinta ecset méretét:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Általában egy ecset szélessége és magassága nem egyezik, ezért a PowerPoint nem jeleníti meg az ecset méretét (a megfelelő adatmező szürkén van). Ha az ecset szélessége és magassága egyezik, a PowerPoint a méretét így jeleníti meg:

![ink_powerpoint3](ink_powerpoint3.png)

Az átláthatóság kedvéért növeljük meg a tinta objektum magasságát, és tekintsük át a fontos méreteket:

![ink_powerpoint4](ink_powerpoint4.png)

A tároló (keret) nem veszi figyelembe az ecsetek méretét – mindig azt feltételezi, hogy a vonalvastagság nulla (lásd a korábbi képet).

Ezért a teljes tinta objektum látható területének meghatározásához figyelembe kell venni a vonalak ecsetméretét. Itt a célobjektum (a kézírásos szövegvonal) a tároló (keret) méretéhez lett skálázva. Amikor a tároló mérete változik, az ecset mérete állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint hasonló viselkedést alkalmaz a szövegobjektumokra:

![ink_powerpoint6](ink_powerpoint6.png)

## **Tintajelen megjelenés vezérlése exportálás és renderelés során**

Az Aspose.Slides a [InkOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkoptions/) osztályt biztosítja a tinta objektumok exportált vagy renderelt kimenetben való megjelenésének szabályozásához. A tulajdonságait használhatja a tinta teljes elrejtésére vagy a tinta ecset maszk műveletek értelmezésének módosítására.

A tinta beállítások a különböző kimeneti típusok export‑ vagy renderelési beállításaiban érhetők el:

| Kimenet | Tintabeállítások tulajdonsága |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Az alábbi [InkOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkoptions/) metódusok ugyanazokat a két beállítást exponálják:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkoptions/#getHideInk--) határozza meg, hogy a tinta objektumok szerepelnek-e a kimenetben. Alapértelmezett értéke `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) határozza meg, hogy egy maszk műveletet átlátszóságként értelmezzen‑e egy tinta ecset renderelésekor. Alapértelmezett értéke `true`; a [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) hívása `false` értékkel a ROP műveletet használja helyette.

### **Tintobjektumok elrejtése PDF kimenetben**

Alapértelmezés szerint a tinta objektumok láthatóak maradnak exportáláskor. Egy tiszta kimenethez, amely nem tartalmaz kézírásos megjegyzéseket vagy más tinta tartalmat, hívja meg a [InkOptions.setHideInk](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) metódust `true` értékkel.

Az alábbi JavaScript‑példa PDF‑re exportál egy prezentációt, miközben elrejti az összes tinta objektumot:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Tintobjektumok elrejtése dia kép renderelésekor**

A tinta objektumok elrejtéséhez, amikor a diákat bitmap képként rendereli, állítsa be a [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) beállítást, és adja át a renderelési opciókat a [Slide.getImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-) metódusnak.

Az alábbi JavaScript‑példa az első diát PNG‑képként rendereli tintobjektumok nélkül:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Tint maszk renderelésének vezérlése**

A [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) beállítás szabályozza, hogyan értelmeződnek a maszk műveletek tintacseppek renderelésekor. Alapértelmezett értéke `true`, ami átlátszóságot használ. A ROP művelet használatához hívja meg a [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) metódust `false` értékkel.

Az alábbi JavaScript‑példa egy diát SVG‑re exportál, és ROP‑alapú renderelést alkalmaz a tinta maszk műveletekhez:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

Ugyanaz a beállítás alkalmazható a [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) segítségével, amikor egy prezentációt exportál vagy egy diát TIFF‑re renderel.

### **Válassza ki, hogy elrejtse vagy megőrizze a tintát**

Ha egy annotált prezentáció tiszta változatát szeretné terjeszteni, hívja meg a [InkOptions.setHideInk](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) metódust `true` értékkel exportáláskor.

Hagyja a [InkOptions.getHideInk](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkoptions/#getHideInk--) értékét `false`‑on, ha a tinta megjegyzések a kívánt tartalom részei, például felülvizsgálati megjegyzések, kézírásos jegyzetek, kiemelések vagy rajzok, melyeknek láthatónak kell maradniuk az exportált eredményben. Ez lehetővé teszi az alkalmazások számára, hogy ugyanabból a prezentációból külön felülvizsgálati és végleges kimeneteket generáljanak a forrás tinta objektumok módosítása nélkül.

## **GYIK**

**Megváltoztathatom egy meglévő tintavonal színét vagy méretét?**

Igen. Szerezze meg a vonalat a [Ink.getTraces](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ink/#getTraces--) metódussal, majd változtassa meg a [InkTrace.getBrush](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inktrace/#getBrush--) értékét. Hívja meg az [InkBrush.setColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) vagy az [InkBrush.setSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) metódust az ecset módosításához.

**A tinta elrejtése módosítja a forrás prezentációt?**

Nem. A [InkOptions.setHideInk](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) hívása csak a renderelt vagy exportált eredményt érinti; nem távolítja el vagy módosítja a tinta objektumokat a forrás prezentációban.

**Mely export formátumok támogatják a tintabeállításokat?**

A tinta beállításokat a PDF, HTML, SVG, TIFF és bitmap diakép exportálási vagy renderelési beállításaiban konfigurálhatja a fenti táblázat szerint.

**További olvasnivalók**

* Általános alakzatok leírásáért lásd a [PowerPoint Shapes](https://docs.aspose.com/slides/hu/nodejs-java/powerpoint-shapes/) szekciót.
* A hatékony értékekkel kapcsolatban lásd a [Shape Effective Properties](https://docs.aspose.com/slides/hu/nodejs-java/shape-effective-properties/#get-effective-font-height-value) dokumentációt.
* A PDF export részleteiért lásd a [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) útmutatót.
* A HTML export részleteiért lásd a [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hu/nodejs-java/convert-powerpoint-to-html/) útmutatót.
* Az SVG export részleteiért lásd a [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hu/nodejs-java/render-a-slide-as-an-svg-image/) útmutatót.
* A TIFF export részleteiért lásd a [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hu/nodejs-java/convert-powerpoint-to-tiff/) útmutatót.
* A diák képpé konvertálásának részleteiért lásd a [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hu/nodejs-java/convert-slide/) útmutatót.
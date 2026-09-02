---
title: PowerPoint tintobjektumok kezelése PHP-ben
linktitle: Tint kezelése
type: docs
weight: 95
url: /hu/php-java/manage-ink/
keywords:
- tinta
- tinta objektum
- tinta vonal
- tinta kezelése
- tinta rajzolása
- rajzolás
- tinta exportálása
- tinta renderelése
- tinta elrejtése
- InkOptions
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje a PowerPoint tintobjektumokat, szerkessze a vonalakat és az ecset tulajdonságait, valamint szabályozza a tinta megjelenését PDF, HTML, SVG, TIFF és képexportálás során az Aspose.Slides PHP számára Java használatával."
---
## **Bevezetés**

A PowerPoint egy tintával kapcsolatos funkciót kínál, amely lehetővé teszi szabadformájú vonalak rajzolását. A tinta használható más objektumok kiemelésére, kapcsolatok és folyamatok megjelenítésére, valamint egyes elemek felhívására a dián.

Az Aspose.Slides biztosítja a tintobjektumokkal való munkához szükséges típusokat. Például az [Ink](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ink/) osztály egy tintobjektumot képvisel egy dián.

## **A szabályos objektumok és a tintobjektumok közötti különbségek**

A PowerPoint-diákon lévő objektumok általában [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) objektumokkal vannak ábrázolva. Egyszerű formájukban a shape egy konténer, amely meghatározza az objektum tényleges területét (keretét), valamint olyan tulajdonságokat, mint a konténer mérete, alakja és háttérszíne. További információkért lásd a [Shape Layout Format](https://docs.aspose.com/slides/hu/php-java/shape-manipulations/#access-layout-formats-for-shape) cikket.

Azonban amikor a PowerPoint egy tintobjektummal dolgozik, figyelmen kívül hagyja a keret (konténer) összes tulajdonságát, kivéve annak méretét. A konténer terület mérete a szabványos [Shape.getWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getWidth) és [Shape.getHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getHeight) metódusokkal határozható meg:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintavonalak**

A tintavonal egy alapvető elem, amely a toll mozgását rögzíti, amikor a felhasználó digitális tintát ír. A vonal egy összekapcsolt pontsorozatot tárol.

A legegyszerűbb kódolási forma minden mintapont X és Y koordinátáját adja meg. Amikor az összes összekapcsolt pontot megjelenítik, egy ilyen képet kapunk:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecsettulajdonságok a rajzoláshoz**

Az ecsetet a tintavonal pontjait összekötő vonalak rajzolására használják. Az ecset saját színnel és mérettel rendelkezik, amelyet a [InkBrush.getColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkbrush/#getColor) és [InkBrush.getSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkbrush/#getSize) metódusok képviselnek.

### **Tintaecset színének beállítása**

Ez a PHP kód bemutatja, hogyan állítható be egy tintaecset színe:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Tintaecset méretének beállítása**

Ez a PHP kód bemutatja, hogyan állítható be egy tintaecset mérete:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

Általában az ecset szélessége és magassága nem egyezik, ezért a PowerPoint nem jeleníti meg az ecset méretét (a megfelelő adatmező szürke). Ha az ecset szélessége és magassága megegyezik, a PowerPoint a méretet a következő módon jeleníti meg:

![ink_powerpoint3](ink_powerpoint3.png)

A szemléltetés kedvéért növeljük meg a tintobjektum magasságát, és tekintsük át a fontos méreteket:

![ink_powerpoint4](ink_powerpoint4.png)

A konténer (keret) nem veszi figyelembe az ecsetek méretét – mindig úgy gondolja, hogy a vonalvastagság nulla (lásd a fenti képet).

Ezért a teljes tintobjektum látható területének meghatározásához figyelembe kell venni az egyes vonalak ecsetméretét. Itt a célobjektum (a kézírásos szövegvonal) a konténer (keret) méretéhez van skálázva. Amikor a konténer mérete változik, az ecsetméret állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint hasonló viselkedést alkalmaz a szövegobjektumoknál is:

![ink_powerpoint6](ink_powerpoint6.png)

## **A tinta megjelenésének vezérlése exportálás és renderelés során**

Az Aspose.Slides a [InkOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkoptions/) osztályt biztosítja a tintobjektumok exportált vagy renderelt kimenetben való megjelenésének szabályozására. A tulajdonságait használhatja a tinta teljes elrejtésére vagy a tintaecset maszkműveletek értelmezésének módosítására.

A tintabeállítások több kimeneti típus export- vagy renderelési opcióin keresztül érhetők el:

| Kimenet | Tintabeállítások tulajdonsága |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Diakép | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/renderingoptions/#getInkOptions) |

A következő [InkOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkoptions/) metódusok ugyanazokat a két beállítást teszik közzé:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkoptions/#getHideInk) meghatározza, hogy a tintobjektumok szerepelnek-e a kimenetben. Alapértelmezett értéke `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) meghatározza, hogy egy maszkművelet opacitásként legyen-e értelmezve a tintaecset renderelésekor. Alapértelmezett értéke `true`; a [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) `false` értékkel való meghívása esetén a ROP művelet kerül használatra.

### **Tintobjektumok elrejtése PDF-kimenetben**

Alapértelmezés szerint a tintobjektumok láthatóak maradnak exportáláskor. Egy tiszta kimenet létrehozásához, amely nem tartalmaz kézírásos megjegyzéseket vagy egyéb tintatartalmat, hívja meg a [InkOptions.setHideInk](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkoptions/#setHideInk) metódust `true` értékkel.

Az alábbi PHP példa egy prezentációt PDF-be exportál, miközben minden tintobjektumot elrejt:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Tintobjektumok elrejtése dia képként való renderelésekor**

A tintobjektumok elrejtéséhez a diákat bitmap képekké renderelve, konfigurálja a [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/renderingoptions/#getInkOptions) beállítást, és adja át a renderelési opciókat a [Slide.getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getImage) metódusnak.

Az alábbi PHP példa az első diát PNG képként rendereli tintobjektumok nélkül:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Tintamaskaraffent renderelésének vezérlése**

A [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) beállítás szabályozza, hogyan vannak értelmezve a maszkműveletek tintaecsetek renderelésekor. Alapértelmezett értéke `true`, ami opacitást használ. A ROP művelet használatához hívja meg a [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) metódust `false` értékkel.

Az alábbi PHP példa egy diát SVG-be exportál, és ROP-alapú renderelést alkalmaz a tintamaskara módszerre:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Ugyanaz a beállítás alkalmazható a [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/#getInkOptions) segítségével is, amikor egy prezentációt exportál vagy egy diát TIFF-re renderel.

### **Döntés a tinta elrejtéséről vagy megtartásáról**

Ha egy megjegyzésekkel ellátott prezentáció tiszta verziójára van szükség a terjesztéshez, anélkül, hogy a megjegyzésjelek megmaradnának, hívja meg a [InkOptions.setHideInk](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkoptions/#setHideInk) metódust `true` értékkel exportáláskor.

Hagyja a [InkOptions.getHideInk](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkoptions/#getHideInk) beállítást alapértelmezett `false` értéken, ha a tinta megjegyzései a szándékolt tartalom részét képezik, például felülvizsgálati megjegyzések, kézírásos jegyzetek, kiemelések vagy rajzok, amelyeknek láthatónak kell maradniuk a kimeneti eredményben. Ez lehetővé teszi, hogy ugyanabból a prezentációból külön felülvizsgálati és végleges kimeneteket generáljanak anélkül, hogy módosítanák a forrás tintobjektumokat.

## **GYIK**

**Megváltoztathatom egy meglévő tintavonal színét vagy méretét?**

Igen. Szerezze be a vonalat a [Ink.getTraces](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ink/#getTraces) segítségével, majd módosítsa a [InkTrace.getBrush](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inktrace/#getBrush) értékét. Hívja meg a [InkBrush.setColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkbrush/#setColor) vagy a [InkBrush.setSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkbrush/#setSize) metódust az ecset módosításához.

**A tinta elrejtése módosítja a forrás prezentációt?**

Nem. A [InkOptions.setHideInk](https://reference.aspose.com/slides/hu/php-java/aspose.slides/inkoptions/#setHideInk) meghívása csak a renderelt vagy exportált eredményt befolyásolja; nem távolítja el vagy módosítja a tintobjektumokat a forrás prezentációban.

**Mely exportformátumok támogatják a tintabeállításokat?**

A tintabeállításokat konfigurálhatja PDF, HTML, SVG, TIFF és bitmap diákképek esetén a fent bemutatott megfelelő export- vagy renderelési opciók használatával.

**További olvasmányok**

* A formákról általánosságban a [PowerPoint Shapes](https://docs.aspose.com/slides/hu/php-java/powerpoint-shapes/) szekcióban olvashat.
* A hatékony értékekkel kapcsolatban lásd a [Shape Effective Properties](https://docs.aspose.com/slides/hu/php-java/shape-effective-properties/#get-effective-font-height-value) oldalt.
* A PDF export részletei: [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hu/php-java/convert-powerpoint-to-pdf/).
* A HTML export részletei: [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hu/php-java/convert-powerpoint-to-html/).
* Az SVG export részletei: [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hu/php-java/render-a-slide-as-an-svg-image/).
* A TIFF export részletei: [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hu/php-java/convert-powerpoint-to-tiff/).
* A dia képpé konvertálás részletei: [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hu/php-java/convert-slide/).
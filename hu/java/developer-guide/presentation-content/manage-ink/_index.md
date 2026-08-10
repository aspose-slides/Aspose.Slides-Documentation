---
title: PowerPoint tintaobjektumok kezelése Java-ban
linktitle: Tintakezelés
type: docs
weight: 95
url: /hu/java/manage-ink/
keywords:
- tinta
- tintaobjektum
- tintasáv
- tinta kezelése
- tintát rajzolni
- rajzolás
- tinta exportálása
- tinta renderelése
- tinta elrejtése
- IInkOptions
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Kezelje a PowerPoint tintaobjektumokat, szerkessze a tintasávokat és ecsettulajdonságokat, és szabályozza a tinta megjelenését PDF, HTML, SVG, TIFF és képexportálás során az Aspose.Slides for Java segítségével."
---
## **Bevezetés**

PowerPoint egy tinta funkciót biztosít, amely lehetővé teszi szabadkézi vonalak rajzolását. A tintát használhatja más objektumok kiemelésére, kapcsolatok és folyamatok megjelenítésére, valamint egyes diák elemeinek figyelemfelkeltésére.

Aspose.Slides biztosítja a tintával kapcsolatos típusokat. Például az [IInk](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iink/) interfész egy tintát ábrázoló objektumot képvisel egy dián.

## **Különbségek a szokásos objektumok és a tintaobjektumok között**

Objektumok egy PowerPoint dián általában alakzat objektumokként jelennek meg. A legegyszerűbb formában egy alakzat egy tároló, amely meghatározza az objektum tényleges területét (a keretét) valamint olyan tulajdonságokat, mint a tároló mérete, alakja és háttérje. További információért lásd a [Shape Layout Format](https://docs.aspose.com/slides/hu/java/shape-manipulations/#access-layout-formats-for-shape) oldalt.

Azonban amikor a PowerPoint tintát kezel, figyelmen kívül hagyja az objektum keretének (tárolójának) minden tulajdonságát, kivéve a méretét. A tároló terület mérete a szabványos [IShape.getWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getWidth--) és [IShape.getHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getHeight--) metódusok alapján határozható meg:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintasávok**

Egy tintasáv egy alapvető elem, amely a toll pályáját rögzíti a felhasználó digitális tinta írásakor. Egy sáv egy összekapcsolt pontok sorozatát tárolja.

A legegyszerűbb kódolási forma meghatározza az egyes mintapont X és Y koordinátáit. Amikor az összekapcsolt pontok megjelennek, egy ilyen képet kapunk:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecsettulajdonságok a rajzoláshoz**

Egy ecsetet használnak a tintasáv pontjait összekötő vonalak rajzolásához. Az ecset saját színnel és mérettel rendelkezik, amelyeket a [IInkBrush.getColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkbrush/#getColor--) és [IInkBrush.getSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkbrush/#getSize--) metódusok reprezentálnak.

### **Az Ink Ecset Színének Beállítása**

Ez a Java kód bemutatja, hogyan állítható be egy tintaecset színe:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Az Ink Ecset Méretének Beállítása**

Ez a Java kód bemutatja, hogyan állítható be egy tintaecset mérete:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Általában az ecset szélessége és magassága nem egyezik, ezért a PowerPoint nem jeleníti meg az ecset méretét (a megfelelő adatmező szürkén van). Ha az ecset szélessége és magassága megegyezik, a PowerPoint így jeleníti meg a méretet:

![ink_powerpoint3](ink_powerpoint3.png)

A tisztább áttekintés érdekében növeljük meg a tinta objektum magasságát, és nézzük meg a fontos dimenziókat:

![ink_powerpoint4](ink_powerpoint4.png)

A tároló (keret) nem veszi figyelembe az ecsetek méretét – mindig úgy feltételezi, hogy a vonal vastagsága nulla (lásd a előző képet).

Ezért a teljes tintaobjektum látható területének meghatározásához figyelembe kell venni a sávok ecsetméretét. Itt a célobjektum (a kézírásos szövegsáv) a tároló (keret) méretéhez van skálázva. Ha a tároló mérete változik, az ecset mérete állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint hasonló viselkedést alkalmaz a szövegobjektumokra is:

![ink_powerpoint6](ink_powerpoint6.png)

## **A tinta megjelenésének szabályozása exportálás és renderelés során**

Aspose.Slides biztosítja a [IInkOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkoptions/) interfészt a tintaobjektumok exportált vagy renderelt kimenetben való megjelenésének szabályozásához. A tulajdonságai segítségével teljesen elrejtheti a tintát vagy módosíthatja, hogyan értelmeződnek a tintaecset maszk műveletek.

Tinta beállítások elérhetők a különféle kimeneti típusok export vagy render opcióin keresztül:

| Kimenet | Tintabeállítás tulajdonság |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/hu/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

A következő [IInkOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkoptions/) metódusok ugyanazt a két beállítást teszik elérhetővé:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkoptions/#getHideInk--) meghatározza, hogy a tintaobjektumok bele legyenek-e véve a kimenetbe. Alapértelmezett értéke `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) meghatározza, hogy a maszk művelet átlátszatlanságként legyen-e értelmezve egy tintaecset renderelésekor. Alapértelmezett értéke `true`; hívja a [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) metódust `false` értékkel, hogy a ROP műveletet használja.

### **Tintaobjektumok elrejtése PDF kimenetben**

Alapértelmezés szerint a tintaobjektumok láthatóak maradnak exportáláskor. Egy tiszta kimenethez kézírásos megjegyzések vagy egyéb tinta tartalom nélkül, hívja a [IInkOptions.setHideInk](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) metódust `true` értékkel.

A következő Java példa egy bemutatót PDF-be exportál, miközben elrejti az összes tintaobjektumot:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Tintaobjektumok elrejtése dia képkénti rendereléskor**

A tintaobjektumok elrejtéséhez, amikor a diákat bitmap képként rendereli, állítsa be a [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/renderingoptions/#getInkOptions--) opciót, és adja át a renderelési beállításokat a [ISlide.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

A következő Java példa az első diát PNG képként rendereli tintával kapcsolatos objektumok nélkül:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Tintamaszk renderelés szabályozása**

A [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) beállítás szabályozza, hogyan értelmeződnek a maszk műveletek tintabecsek renderelésekor. Alapértelmezett értéke `true`, ami átlátszatlanságot használ. A ROP művelet használatához hívja a [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) metódust `false` értékkel.

A következő Java példa egy diát SVG-be exportál, és ROP-alapú renderelést használ a tintamaszk műveletekhez:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

Ugyanez a beállítás alkalmazható a [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tiffoptions/#getInkOptions--) segítségével, amikor a bemutatót TIFF-be exportálja vagy a diát TIFF-ként rendereli.

### **Válassza ki, hogy elrejtse vagy megőrizze a tintát**

Ha egy megjegyzésekkel ellátott bemutató tiszta verziójára van szüksége terjesztéshez, anélkül, hogy a felülvizsgálati jelek láthatóak lennének, hívja a [IInkOptions.setHideInk](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) metódust `true` értékkel exportáláskor.

Hagyja a [IInkOptions.getHideInk](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkoptions/#getHideInk--) alapértelmezett `false` értékén, ha a tinta megjegyzések a kívánt tartalom részei, például felülvizsgálati megjegyzések, kézírásos jegyzetek, kiemelések vagy rajzok, amelyeknek láthatónak kell maradniuk az exportált eredményben. Ez lehetővé teszi az alkalmazások számára, hogy külön felülvizsgálati és végleges kimenetet generáljanak ugyanabból a bemutatóból anélkül, hogy módosítanák a forrás tintákat.

## **GYIK**

**Megváltoztathatom egy meglévő tinta vonal színét vagy méretét?**

Igen. Szerezze be a sávot az [IInk.getTraces](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iink/#getTraces--) metódussal, majd módosítsa annak [IInkTrace.getBrush](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinktrace/#getBrush--) értékét. Hívja az [IInkBrush.setColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) vagy az [IInkBrush.setSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) metódust az ecset megváltoztatásához.

**A tinta elrejtése módosítja a forrás bemutatót?**

Nem. A [IInkOptions.setHideInk](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) meghívása csak a renderelt vagy exportált eredményt befolyásolja; nem távolítja el vagy módosítja a tintaobjektumokat a forrás bemutatóban.

**Mely exportformátumok támogatják a tintabeállításokat?**

A fent bemutatott export vagy render opciókon keresztül beállíthatók a tintabeállítások PDF, HTML, SVG, TIFF és bitmap diakép formátumokhoz.

**További olvasmányok**

* Az alakzatokról általánosságban a [PowerPoint Shapes](https://docs.aspose.com/slides/hu/java/powerpoint-shapes/) szakaszban olvashat.
* A hatékony értékekről további információkért lásd a [Shape Effective Properties](https://docs.aspose.com/slides/hu/java/shape-effective-properties/#get-effective-font-height-value) szekciót.
* A PDF export részleteiért lásd a [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hu/java/convert-powerpoint-to-pdf/) oldalt.
* A HTML export részleteiért lásd a [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hu/java/convert-powerpoint-to-html/) oldalt.
* Az SVG export részleteiért lásd a [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hu/java/render-a-slide-as-an-svg-image/) oldalt.
* A TIFF export részleteiért lásd a [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hu/java/convert-powerpoint-to-tiff/) oldalt.
* A diák képpé konvertálásának részleteiért lásd a [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hu/java/convert-slide/) oldalt.
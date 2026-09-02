---
title: PowerPoint toll objektumok kezelése Androidon
linktitle: Toll kezelése
type: docs
weight: 95
url: /hu/androidjava/manage-ink/
keywords:
- toll
- toll objektum
- toll nyomvonal
- toll kezelése
- toll rajzolása
- rajzolás
- toll exportálás
- toll renderelés
- toll elrejtése
- IInkOptions
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Kezelje a PowerPoint toll objektumokat, szerkessze a nyomvonalakat és ecset tulajdonságokat, valamint szabályozza a toll megjelenését PDF, HTML, SVG, TIFF és kép exportálása során az Aspose.Slides for Android segítségével."
---
## **Bevezetés**

A PowerPoint egy toll funkciót kínál, amely lehetővé teszi a szabadkézi vonalak rajzolását. A toll használható más objektumok kiemelésére, kapcsolatok és folyamatok bemutatására, valamint a dián lévő konkrét elemek figyelemfelkeltésére.

Az Aspose.Slides biztosítja a toll objektumokkal való munkahez szükséges típusokat. Például a [IInk](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iink/) interfész egy toll objektumot képvisel egy dián.

## **Különbségek a szabványos objektumok és a toll objektumok között**

A PowerPoint-dián lévő objektumok általában alakzatobjektumok formájában jelennek meg. Egyszerű formában egy alakzat egy tartály, amely meghatározza az objektum saját területét (a keretét), valamint olyan tulajdonságokat, mint a tartály mérete, alakja és háttérje. További információkért lásd a [Alakzat elrendezés formátuma](https://docs.aspose.com/slides/hu/androidjava/shape-manipulations/#access-layout-formats-for-shape) cikket.

Azonban amikor a PowerPoint egy toll objektumot kezel, figyelmen kívül hagyja az objektum keretének (tartályának) minden tulajdonságát, kivéve a méretét. A tartály területének méretét a szabványos [IShape.getWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getWidth--) és [IShape.getHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getHeight--) metódusok határozzák meg:

![ink_powerpoint1](ink_powerpoint1.png)

## **Toll nyomvonalak**

A toll nyomvonal egy alapvető elem, amelyet a toll digitális írás közbeni pályájának rögzítésére használnak. Egy nyomvonal összekapcsolt pontok sorozatát tárolja.

A legegyszerűbb kódolási forma minden mintapont X és Y koordinátáit adja meg. Ha az összekapcsolt pontok megjelennek, egy ilyen képet eredményeznek:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecset tulajdonságok a rajzoláshoz**

Az ecsetet a toll nyomvonal pontjait összekötő vonalak rajzolására használják. Az ecset saját színnel és mérettel rendelkezik, amelyet a [IInkBrush.getColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkbrush/#getColor--) és [IInkBrush.getSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkbrush/#getSize--) metódusok képviselnek.

### **Toll ecset színének beállítása**

Ez a Java‑kód mutatja, hogyan állítható be egy toll ecset színe:

```java
import android.graphics.Color;
import com.aspose.slides.*;

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

### **Toll ecset méretének beállítása**

Ez a Java‑kód mutatja, hogyan állítható be egy toll ecset mérete:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Általában az ecset szélessége és magassága nem egyezik meg, ezért a PowerPoint nem jeleníti meg az ecset méretét (a megfelelő adatmező szürkén van). Ha az ecset szélessége és magassága megegyezik, a PowerPoint a méretet így jeleníti meg:

![ink_powerpoint3](ink_powerpoint3.png)

A világosabb szemléltetéshez növeljük meg a toll objektum magasságát, és tekintsük át a fontos dimenziókat:

![ink_powerpoint4](ink_powerpoint4.png)

A tartály (keret) nem veszi figyelembe az ecsetek méretét – mindig azt feltételezi, hogy a vonalvastagság nulla (lásd a korábbi képet).

Ezért a teljes toll objektum látható területének meghatározásához a nyomvonalak ecsetméretét is figyelembe kell venni. Itt a célobjektum (a kézírásos szöveg nyomvonal) a tartály (keret) méretéhez lett méretezve. Amikor a tartály mérete változik, az ecset mérete állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint hasonló viselkedést alkalmaz a szövegobjektumokra is:

![ink_powerpoint6](ink_powerpoint6.png)

## **Toll megjelenésének szabályozása exportálás és renderelés közben**

Az Aspose.Slides biztosítja a [IInkOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkoptions/) interfészt a toll objektumok exportált vagy renderelt kimenetben való megjelenésének szabályozásához. A tulajdonságait használhatja a toll teljes elrejtésére vagy a toll ecset maszk műveleteinek értelmezésének módosítására.

Az ink opciók a különböző kimeneti típusok export‑ vagy renderelési beállításaiban érhetők el:

| Kimenet | Ink opciók tulajdonság |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Dia kép | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

A következő [IInkOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkoptions/) metódusok ugyanazokat a két beállítást teszik elérhetővé:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) határozza meg, hogy a toll objektumok szerepelnek‑e a kimenetben. Alapértelmezett értéke `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) határozza meg, hogy egy maszk művelet opacitásként legyen‑e értelmezve a toll ecset renderelésekor. Alapértelmezett értéke `true`; a [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) metódus `false` paraméterrel való meghívásával a ROP művelet használható.

### **Toll objektumok elrejtése PDF kimenetben**

Alapértelmezés szerint a toll objektumok láthatóak maradnak exportáláskor. Egy tiszta kimenet létrehozásához, amely nem tartalmaz kézírásos megjegyzéseket vagy egyéb toll tartalmat, hívja meg a [IInkOptions.setHideInk](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) metódust `true` értékkel.

A következő Java‑példa egy prezentációt exportál PDF‑be, miközben elrejti az összes toll objektumot:

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

### **Toll objektumok elrejtése, amikor diát képként renderel**

A toll objektumok elrejtéséhez, amikor a diákat bitmap képként rendereli, konfigurálja a [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) beállítást, és adja át a renderelési opciókat a [ISlide.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) metódusnak.

A következő Java‑példa az első diát PNG‑képként rendereli toll objektumok nélkül:

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

### **Toll maszk renderelésének szabályozása**

Az [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) beállítás szabályozza, hogy a maszk műveletek hogyan legyenek értelmezve a toll ecsetek renderelésekor. Alapértelmezett értéke `true`, ami opacitást használ. A ROP művelethez állítsa `false`‑ra a [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) metódust.

A következő Java‑példa egy diát SVG‑be exportál, és ROP‑alapú renderelést használ a toll maszk műveletekhez:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

Ugyanaz a beállítás alkalmazható a [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) használatával is, amikor a prezentációt exportálja vagy a diát TIFF‑képpé rendereli.

### **Válassza ki, hogy elrejtse vagy megtartsa a tollat**

Ha egy megjegyzésekkel ellátott prezentáció tiszta verziójára van szüksége terjesztéshez, hívja meg a [IInkOptions.setHideInk](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) metódust `true` értékkel exportáláskor.

Hagyja a [IInkOptions.getHideInk](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) alapértelmezett `false` értékét, ha a toll annotációk a kívánt tartalom részei, például felülvizsgálati megjegyzések, kézírásos jegyzetek, kiemelések vagy rajzok, amelyeknek láthatónak kell maradniuk az exportált eredményben. Ez lehetővé teszi, hogy ugyanabból a prezentációból külön felülvizsgálati és végleges kimeneteket generáljon a forrási toll objektumok módosítása nélkül.

## **GYIK**

**Megváltoztathatom egy meglévő toll vonal színét vagy méretét?**

Igen. A nyomvonalat a [IInk.getTraces](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iink/#getTraces--) metódussal kérheti le, majd módosíthatja annak [IInkTrace.getBrush](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinktrace/#getBrush--) tulajdonságát. Hívja a [IInkBrush.setColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) vagy a [IInkBrush.setSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) metódusokat az ecset színének vagy méretének módosításához.

**A toll elrejtése módosítja a forrás prezentációt?**

Nem. A [IInkOptions.setHideInk](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) meghívása csak a renderelt vagy exportált eredményt érinti; nem távolítja el vagy módosítja a toll objektumokat a forrás prezentációban.

**Mely export formátumok támogatják a toll opciókat?**

A toll opciókat beállíthatja PDF, HTML, SVG, TIFF és bitmap diakép esetén a fent bemutatott megfelelő export‑ vagy renderelési beállításokon keresztül.

**További olvasnivaló**

* Az alakzatok általános áttekintéséhez lásd a [PowerPoint Shapes](https://docs.aspose.com/slides/hu/androidjava/powerpoint-shapes/) részt.
* A hatékony értékekkel kapcsolatos információkért tekintse meg a [Shape Effective Properties](https://docs.aspose.com/slides/hu/androidjava/shape-effective-properties/#get-effective-font-height-value) cikket.
* A PDF export részleteiért lásd a [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hu/androidjava/convert-powerpoint-to-pdf/) oldalt.
* A HTML export részleteiért lásd a [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hu/androidjava/convert-powerpoint-to-html/) oldalt.
* Az SVG export részleteiért lásd a [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hu/androidjava/render-a-slide-as-an-svg-image/) oldalt.
* A TIFF export részleteiért lásd a [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hu/androidjava/convert-powerpoint-to-tiff/) oldalt.
* A dia‑kép renderelés részleteiért lásd a [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hu/androidjava/convert-slide/) oldalt.
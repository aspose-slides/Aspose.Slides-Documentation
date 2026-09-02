---
title: "PowerPoint tintobjektumok kezelése Pythonban"
linktitle: "Tint kezelés"
type: docs
weight: 95
url: /hu/python-net/manage-ink/
keywords:
- tinta
- tintobjektum
- tintatrace
- tinta kezelése
- tinta rajzolása
- rajzolás
- tinta exportálás
- tinta renderelés
- tinta elrejtése
- InkOptions
- PowerPoint
- bemutató
- Python
- Aspose.Slides
description: "Kezelje a PowerPoint tintobjektumokat, szerkessze a trace-eket és az ecset tulajdonságait, valamint szabályozza a tinta megjelenését PDF, HTML, SVG, TIFF és képexportálás során az Aspose.Slides Python verziójával a .NET-en keresztül."
---
## **Bevezetés**

A PowerPoint egy tinta funkciót nyújt, amely lehetővé teszi szabadkézi vonalak rajzolását. A tintát használhatja más objektumok kiemelésére, kapcsolatok és folyamatok megjelenítésére, valamint a dián lévő adott elemek felhívására.

Az [aspose.slides.ink](https://reference.aspose.com/slides/hu/python-net/aspose.slides.ink/) névtér tartalmazza a tintával kapcsolatos objektumok kezeléséhez szükséges osztályokat. Például az [Ink](https://reference.aspose.com/slides/hu/python-net/aspose.slides.ink/ink/) osztály egy tintát ábrázoló objektumot képvisel a dián.

## **Különbségek a szokásos objektumok és a tintobjektumok között**

A PowerPoint dián lévő objektumok általában alakzatobjektumokként jelennek meg. Egyszerű formájukban egy alakzat egy tároló, amely meghatározza az objektum saját területét (keretét) valamint olyan tulajdonságokat, mint a tároló mérete, alakja és háttérszíne. További információkért lásd a [Alakzat elrendezési formátum](https://docs.aspose.com/slides/hu/python-net/shape-manipulations/#access-layout-formats-for-shape) szakaszt.

Azonban amikor a PowerPoint tintobjektummal dolgozik, figyelmen kívül hagyja az objektumkeret minden tulajdonságát (kivéve a méretét). A tároló terület méretét az alapértelmezett [Ink.width](https://reference.aspose.com/slides/hu/python-net/aspose.slides.ink/ink/width/) és [Ink.height](https://reference.aspose.com/slides/hu/python-net/aspose.slides.ink/ink/height/) tulajdonságok határozzák meg:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintatracek**

Egy tintatrace egy alapvető elem, amely a toll mozgását rögzíti, amikor a felhasználó digitális tintát ír. Egy trace egy összekapcsolt pontok sorozatát tárolja.

A legegyszerűbb kódolási forma minden minta pont X és Y koordinátáit adja meg. Ha az összes összekapcsolt pontot megjelenítik, egy ilyen képet kapnak:

![ink_powerpoint2](ink_powerpoint2.png)

## **Ecset tulajdonságok a rajzoláshoz**

Az ecsetet a tintatrace pontjait összekötő vonalak rajzolásához használják. Az [InkBrush.color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.ink/inkbrush/color/) és az [InkBrush.size](https://reference.aspose.com/slides/hu/python-net/aspose.slides.ink/inkbrush/size/) tulajdonságok szabályozzák a színét és a méretét.

### **Tintaecset színének beállítása**

Ez a Python kód mutatja be, hogyan állítható be egy tintaecset színe:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Tintaecset méretének beállítása**

Ez a Python kód mutatja be, hogyan állítható be egy tintaecset mérete:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Általánosságban az ecset szélessége és magassága nem egyezik meg, ezért a PowerPoint nem jeleníti meg az ecset méretét (a megfelelő adatmező szürkén jelenik meg). Amikor az ecset szélessége és magassága megegyezik, a PowerPoint a méretet a következőképp jeleníti meg:

![ink_powerpoint3](ink_powerpoint3.png)

A tisztább áttekinthetőség kedvéért növeljük meg a tintobjektum magasságát, és tekintsük át a fontos méreteket:

![ink_powerpoint4](ink_powerpoint4.png)

A tároló (keret) nem veszi figyelembe az ecsetek méretét – mindig úgy feltételezi, hogy a vonal vastagsága nulla (lásd a fentebb látható képet).

Ezért a teljes tintobjektum látható területének meghatározásához a trace-ek ecsetméretét is figyelembe kell venni. Itt a céltárgy (a kézzel írt szöveg trace) a tároló (keret) méretéhez lett skálázva. Amikor a tároló mérete változik, az ecsetméret állandó marad, és fordítva.

![ink_powerpoint5](ink_powerpoint5.png)

A PowerPoint hasonló viselkedést alkalmaz a szövegobjektumoknál is:

![ink_powerpoint6](ink_powerpoint6.png)

## **A tinta megjelenésének szabályozása exportálás és renderelés során**

Az Aspose.Slides a [InkOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/inkoptions/) osztályt biztosítja, amely a tintobjektumok exportált vagy renderelt kimenetben való megjelenését szabályozza. A tulajdonságait használhatja a tinta teljes elrejtésére vagy a tinta ecset maszk műveletek értelmezésének módosítására.

Az ink beállítások elérhetők a különböző kimeneti típusok export- vagy renderelési beállításaiban:

| Kimenet | Tintabeállítás tulajdonság |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Diakép | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Ugyanaz a két beállítás érhető el ezeken a tulajdonságokon keresztül:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/inkoptions/hide_ink/) határozza meg, hogy a tintobjektumok szerepelnek-e a kimenetben. Alapértelmezett értéke `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) határozza meg, hogy egy maszk műveletet átlátszóságként vagy ROP‑ként értelmezzen a renderelés során. Alapértelmezett értéke `True`; `False` értékre állítva a ROP műveletet használja.

### **Tintobjektumok elrejtése PDF-kimenetben**

Alapértelmezés szerint a tintobjektumok láthatóak exportáláskor. Állítsa a [InkOptions.hide_ink](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/inkoptions/hide_ink/) értékét `True`‑ra, ha tiszta kimenetre van szüksége kézírásos megjegyzések vagy egyéb tinta tartalom nélkül.

Az alábbi Python példa PDF‑re exportál egy bemutatót, miközben elrejti az összes tintát:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Tintobjektumok elrejtése dia képként való rendereléskor**

A tintobjektumok elrejtéséhez a diák bitmap képként történő renderelésekor állítsa be a [RenderingOptions.ink_options](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/renderingoptions/ink_options/) beállítást, majd adja át a renderelési beállításokat a [Slide.get_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/) metódusnak.

Az alábbi Python példa a első diát PNG képként rendereli tintobjektumok nélkül:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Tintamaska renderelésének szabályozása**

Az [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) tulajdonság szabályozza, hogy a maszk műveleteket hogyan értelmezzék tintaecsetek renderelésekor. Alapértelmezett értéke `True`, ami átlátszóságot használ. Állítsa `False`‑ra a ROP művelet használatához.

Az alábbi Python példa egy diát SVG‑re exportál, és ROP‑alapú renderelést használ a tintamaska műveletekhez:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Ugyanez a beállítás alkalmazható a [TiffOptions.ink_options](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/tiffoptions/ink_options/) segítségével is, amikor egy bemutatót TIFF‑re exportál vagy egy diát TIFF‑képként renderel.

### **Válassza ki, hogy elrejtse vagy megőrizze a tintát**

Állítsa a [InkOptions.hide_ink](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/inkoptions/hide_ink/) értékét `True`‑ra, ha a exportált fájlnak egy annotált bemutató tiszta verziójának kell lennie, például végleges másolatként, amelyet terjeszteni kíván felülvizsgálati jelölések nélkül.

Hagyja a [InkOptions.hide_ink](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/inkoptions/hide_ink/) alapértelmezett `False` értékén, ha a tinta megjegyzések a szándékos tartalom részei – például felülvizsgálati megjegyzések, kézírásos jegyzetek, kiemelések vagy rajzok, amelyeknek láthatóaknak kell maradniuk az exportált eredményben. Ez lehetővé teszi, hogy az alkalmazások ugyanabból a bemutatóból külön felülvizsgálati és végleges kimeneteket generáljanak a forrás tintobjektumok módosítása nélkül.

## **GYIK**

**Meg tudom változtatni egy meglévő tintavonal színét vagy méretét?**  
Igen. A trace‑t a [Ink.traces](https://reference.aspose.com/slides/hu/python-net/aspose.slides.ink/ink/traces/) segítségével érheti el, majd módosítsa a [InkTrace.brush](https://reference.aspose.com/slides/hu/python-net/aspose.slides.ink/inktrace/brush/) tulajdonságát. Beállíthatja az ecset [InkBrush.color](https://reference.aspose.com/slides/hu/python-net/aspose.slides.ink/inkbrush/color/) és [InkBrush.size](https://reference.aspose.com/slides/hu/python-net/aspose.slides.ink/inkbrush/size/) értékeit.

**A tinta elrejtése módosítja a forrásbemutatót?**  
Nem. Az [InkOptions.hide_ink](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/inkoptions/hide_ink/) csak a renderelt vagy exportált eredményt érinti; nem távolítja el vagy módosítja a tintobjektumokat a forrásbemutatóban.

**Mely exportformátumok támogatják a tinta beállításokat?**  
A tinta beállításokat konfigurálhatja PDF, HTML, SVG, TIFF és bitmap diaképek esetén a fentebb bemutatott export‑ vagy renderelési beállításokon keresztül.

**További olvasnivaló**  

* Az alakzatok általános ismertetéséhez lásd a [PowerPoint Shapes](https://docs.aspose.com/slides/hu/python-net/powerpoint-shapes/) szakaszt.  
* A hatékony értékekkel kapcsolatos információkért tekintse meg a [Shape Effective Properties](https://docs.aspose.com/slides/hu/python-net/shape-effective-properties/#get-effective-font-height-value) oldalt.  
* A PDF export részleteiért lásd a [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hu/python-net/convert-powerpoint-to-pdf/) anyagot.  
* A HTML export részleteiért lásd a [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hu/python-net/convert-powerpoint-to-html/) anyagot.  
* Az SVG export részleteiért lásd a [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hu/python-net/render-a-slide-as-an-svg-image/) anyagot.  
* A TIFF export részleteiért lásd a [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hu/python-net/convert-powerpoint-to-tiff/) anyagot.  
* A dia‑kép renderelés részleteiért lásd a [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hu/python-net/convert-slide/) anyagot.
---
title: Ellipszisek hozzáadása prezentációkhoz Pythonban
linktitle: Ellipszis
type: docs
weight: 30
url: /hu/python-net/ellipse/
keywords:
- ellipszis
- alakzat
- ellipszis hozzáadása
- ellipszis létrehozása
- ellipszis rajzolása
- formázott ellipszis
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre, formázhat és kezelhet ellipszis alakzatokat az Aspose.Slides for Python via .NET segítségével PPT, PPTX és ODP prezentációkban – kódpéldákkal együtt."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatunk ellipszis alakzatokat PowerPoint diához az Aspose.Slides használatával. Lefedi egy egyszerű ellipszis, egy formázott ellipszis létrehozását, valamint a módosított prezentáció PPTX fájlként való mentését. Továbbá érinti a kapcsolódó kérdéseket, mint az ellipszis pozíciójának és méretének kezelése, a rétegezési sorrend szabályozása, és animációs hatások alkalmazása.

## **Ellipszis létrehozása**
Ebben a témában a fejlesztőket tájékoztatjuk arról, hogyan adhatnak ellipszis alakzatot a diákhoz az Aspose.Slides for Python via .NET használatával. Az Aspose.Slides for Python via .NET egyszerűsített API-kat biztosít különböző alakzatok rajzolásához néhány sor kóddal. Egy egyszerű ellipszis hozzáadásához a prezentáció egy kiválasztott diájához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/)osztályból
1. Szerezze meg a diára mutató hivatkozást az Index segítségével
1. Adjon hozzá egy Ellipse típusú AutoShape-et az IShapes objektum által biztosított AddAutoShape metódussal
1. Mentse a módosított prezentációt PPTX fájlként

Az alábbi példában ellipszist adtunk hozzá az első diához.

```py
import aspose.slides as slides

# Létrehozza a Presentation osztályt, amely a PPTX-et képviseli
with slides.Presentation() as pres:
    # Az első diát lekéri
    sld = pres.slides[0]

    # Ellipszis típusú autoshape-et ad hozzá
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # A PPTX fájlt lemezre írja
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Formázott ellipszis létrehozása**
Egy jobban formázott ellipszis hozzáadásához a diához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/)osztályból.
1. Szerezze meg a diára mutató hivatkozást az Index segítségével.
1. Adjon hozzá egy Ellipse típusú AutoShape-et az IShapes objektum által biztosított AddAutoShape metódussal.
1. Állítsa be az ellipszis kitöltéstípusát Solid értékre.
1. Állítsa be az ellipszis színét a FillFormat objektumhoz tartozó IShape objektum által kibocsátott SolidFillColor.Color tulajdonsággal.
1. Állítsa be az ellipszis vonalainak színét.
1. Állítsa be az ellipszis vonalai vastagságát.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példában egy formázott ellipszist adtunk hozzá a prezentáció első diájához.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Létrehozza a Presentation osztályt, amely a PPTX-et képviseli
with slides.Presentation() as pres:
    # Az első diát lekéri
    sld = pres.slides[0]

    # Ellipszis típusú autoshape-et ad hozzá
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Néhány formázást alkalmaz az ellipszis alakzatra
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Néhány formázást alkalmaz az ellipszis vonalára
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # A PPTX fájlt lemezre írja
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Hogyan állíthatom be egy ellipszis pontos pozícióját és méretét a diák mértékegységeihez képest?**

A koordináták és méretek általában **pont** egységben vannak megadva. A kiszámítható eredmény érdekében a számításokat a dia méretéhez igazítsa, és a szükséges millimétereket vagy hüvelyket pontokra konvertálja, mielőtt értékeket adna meg.

**Hogyan helyezhetem el az ellipszist más objektumok felett vagy alatt (a rétegezési sorrend vezérlése)?**

Állítsa be az objektum rajzolási sorrendjét az előre hozással vagy hátra küldéssel. Így az ellipszis átfedheti a többi objektumot, vagy felfedheti az alatta lévőket.

**Hogyan animálhatom egy ellipszis megjelenését vagy hangsúlyozását?**

[Apply](/slides/hu/python-net/shape-animation/) belépési, hangsúlyozási vagy kilépési effektusok az alakzatra, és konfigurálja a triggereket és az időzítést, hogy meghatározza, mikor és hogyan játszódik le az animáció.
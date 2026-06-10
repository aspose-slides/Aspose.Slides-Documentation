---
title: "Téglalapok hozzáadása prezentációkhoz Pythonban"
linktitle: "Téglalap"
type: docs
weight: 80
url: /hu/python-net/rectangle/
keywords:
- "téglalap hozzáadása"
- "téglalap létrehozása"
- "téglalap alakzat"
- "egyszerű téglalap"
- "formázott téglalap"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Növelje PowerPoint és OpenDocument prezentációi hatékonyságát téglalapok hozzáadásával az Aspose.Slides for Python via .NET segítségével – egyszerűen tervezzék és módosítsák az alakzatokat programozottan."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatunk hozzá téglalap alakzatokat a PowerPoint diákhoz az Aspose.Slides használatával. Kiterjed az egyszerű téglalap létrehozására, a formázott téglalap létrehozására és a módosított prezentáció PPTX fájlként való mentésére.  

Megtekintheti továbbá, hogyan alkalmazhat alapvető téglalap formázást, például egyszínű kitöltést, vonalszínt és vonalvastagságot. Emellett a cikk GYIK-ja a kapcsolódó téglalap feladatokra mutat, beleértve a lekerekített sarkokat, képtöltéseket, vizuális effektusokat, hiperlinkeket, alakzatzárolásokat, exportálási lehetőségeket és hatékony tulajdonságokat.

## **Egyszerű téglalap létrehozása**
Mint a korábbi témák, ez is egy alakzat hozzáadásáról szól, és ezúttal a Rectangle alakzatról beszélünk. Ebben a témában leírtuk, hogyan adhatnak fejlesztők egyszerű vagy formázott téglalapokat a diákhoz az Aspose.Slides for Python via .NET használatával. Egy egyszerű téglalap hozzáadásához a prezentáció kiválasztott diájához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezze be a diák referenciáját az Index használatával.  
3. Adjon hozzá egy Rectangle típusú IAutoShape-t a IShapes objektum által biztosított AddAutoShape metódussal.  
4. Írja a módosított prezentációt PPTX fájlként.  

Az alább bemutatott példában egyszerű téglalapot adtunk hozzá a prezentáció első diájához.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
with slides.Presentation() as pres:
    # Az első diát kapja meg
    sld = pres.slides[0]

    # Téglalap típusú autoshape hozzáadása
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Írja a PPTX fájlt a lemezekre
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Formázott téglalap létrehozása**
Formázott téglalap diára történő hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezze be a diák referenciáját az Index használatával.  
3. Adjon hozzá egy Rectangle típusú IAutoShape-t a IShapes objektum által biztosított AddAutoShape metódussal.  
4. Állítsa be a Rectangle kitöltés típusát Szilárdra.  
5. Állítsa be a Rectangle színét a FillFormat objektumhoz tartozó IShape objektum SolidFillColor.Color tulajdonságával.  
6. Állítsa be a Rectangle vonalainak színét.  
7. Állítsa be a Rectangle vonalainak vastagságát.  
8. Írja a módosított prezentációt PPTX fájlként.  

A fenti lépések az alább bemutatott példában vannak megvalósítva.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
with slides.Presentation() as pres:
    # Az első diát kapja meg
    sld = pres.slides[0]

    # Téglalap típusú autoshape hozzáadása
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Néhány formázást alkalmaz a téglalap alakzatra
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Néhány formázást alkalmaz a téglalap vonalára
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #A PPTX fájl írása a lemezre
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Hogyan adhatok hozzá lekerekített sarkú téglalapot?**  
Használja a lekerekített sarkú [alakzat típust](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapetype/) és állítsa be a sarkok sugárát az alakzat tulajdonságaiban; a lekerekítés egyes sarkokra is alkalmazható geometriai beállításokkal.

**Hogyan tölthetem ki egy téglalapot képpel (textúrával)?**  
Válassza ki a kép [kitöltés típusát](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/), adja meg a képfájlt, és konfigurálja a [nyújtás/csempézés móduszt](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillmode/).

**Lehet a téglalapnak árnyéka és ragyogása?**  
Igen. [Külső/belső árnyék, ragyogás és lágy élek](/slides/hu/python-net/shape-effect/) elérhetők állítható paraméterekkel.

**Átalakíthatom a téglalapot gombbal és hiperlinkkel?**  
Igen. [Rendeljen hiperlinket](/slides/hu/python-net/manage-hyperlinks/) az alakzat kattintásához (ugrás egy diára, fájlra, webcímre vagy e‑mailre).

**Hogyan védhetem meg a téglalapot a mozgatástól és változtatásoktól?**  
[Használja az alakzat zárolásait](/slides/hu/python-net/applying-protection-to-presentation/): tiltani lehet a mozgatást, átméretezést, kijelölést vagy a szövegszerkesztést a elrendezés megőrzése érdekében.

**Átalakíthatom a téglalapot raszteres képpé vagy SVG‑vé?**  
Igen. [Megjelenítheti az alakzatot](http://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_image/) egy megadott méretű/skálájú képként, vagy [exportálhatja SVG‑ként](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/write_as_svg/) vektoros felhasználáshoz.

**Hogyan tudom gyorsan lekérdezni egy téglalap tényleges (hatékony) tulajdonságait a téma és öröklődés figyelembevételével?**  
[Használja az alakzat hatékony tulajdonságait](/slides/hu/python-net/shape-effective-properties/): az API kiszámított értékeket ad vissza, amelyek figyelembe veszik a téma stílusait, elrendezést és helyi beállításokat, ezáltal egyszerűsítve a formázási elemzést.
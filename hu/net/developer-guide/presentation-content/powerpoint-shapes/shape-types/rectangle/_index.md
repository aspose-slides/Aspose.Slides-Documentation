---
title: Téglalapok hozzáadása a bemutatókhoz .NET-ben
linktitle: Téglalap
type: docs
weight: 80
url: /hu/net/rectangle/
keywords:
- téglalap hozzáadása
- téglalap létrehozása
- téglalap alakzat
- egyszerű téglalap
- formázott téglalap
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Növelje PowerPoint bemutatóit téglalapok hozzáadásával az Aspose.Slides for .NET segítségével—könnyedén tervezhet és módosíthat alakzatokat programozottan."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatunk hozzá téglalap alakzatokat a PowerPoint-diákhoz az Aspose.Slides használatával. Lefedi egy egyszerű téglalap létrehozását, egy formázott téglalap létrehozását, és az frissített bemutató PPTX fájlként való mentését.  
A továbbiakban megtekintheti az alapvető téglalap formázás alkalmazását, például a szilárd kitöltőszínt, a vonalszínt és a vonalszélességet. Emellett a cikk GYIK-ja kapcsolódó téglalap feladatokra mutat, beleértve a lekerekített sarkokat, képes kitöltéseket, vizuális hatásokat, hiperhivatkozásokat, alakzólakat, exportálási lehetőségeket és az effektív tulajdonságokat.

## **Egyszerű téglalap létrehozása**

Az előző témákhoz hasonlóan ez is egy alakzat hozzáadásáról szól, és ezúttal a vizsgálandó alakzat a Téglalap. Ebben a témában leírtuk, hogyan adhatnak a fejlesztők egyszerű vagy formázott téglalapokat a diáikhoz az Aspose.Slides for .NET használatával. Egy egyszerű téglalap hozzáadásához a bemutató kiválasztott diájához, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg egy dia referenciáját az Index használatával.  
3. Adjon egy IAutoShape objektumot Téglalap típusban az IShapes objektum által biztosított AddAutoShape metódussal.  
4. Írja ki a módosított bemutatót PPTX fájlként.  

Az alább bemutatott példában egy egyszerű téglalapot adtunk hozzá a bemutató első diájához.

```c#
 // Példányosítja a Presentation osztályt, amely a PPTX-et jelenti
 using (Presentation pres = new Presentation())
 {
 
     // A legelső dia lekérése
     ISlide sld = pres.Slides[0];
 
     // Téglalap típusú autoshape hozzáadása
     sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);
 
     // A PPTX fájl mentése lemezre
     pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
 }
```

## **Formázott téglalap létrehozása**

Formázott téglalap hozzáadásához egy diára, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg egy dia referenciáját az Index használatával.  
3. Adjon egy IAutoShape objektumot Téglalap típusban az IShapes objektum által biztosított AddAutoShape metódussal.  
4. Állítsa be a téglalap kitöltés típusát Szilárd értékre.  
5. Állítsa be a téglalap színét a FillFormat objektumhoz tartozó IShape objektum SolidFillColor.Color tulajdonságával.  
6. Állítsa be a téglalap vonalainak színét.  
7. Állítsa be a téglalap vonalainak szélességét.  
8. Írja ki a módosított bemutatót PPTX fájlként.  

A fenti lépéseket az alább bemutatott példában valósítottuk meg.

```c#
 // Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
 using (Presentation pres = new Presentation())
 {
 
     // Az első dia lekérése
     ISlide sld = pres.Slides[0];
 
     // Téglalap típusú autoshape hozzáadása
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);
 
     // Formázás alkalmazása a téglalap alakzatra
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
 
     // Formázás alkalmazása a téglalap vonalára
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;
 
     //A PPTX fájl mentése lemezre
     pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **GYIK**

**Hogyan adhatok hozzá lekerekített sarkú téglalapot?**  
Használja a lekerekített sarkú [shape type](https://reference.aspose.com/slides/hu/net/aspose.slides/shapetype/) típusú alakzatot, és állítsa be a sarok sugárát az alakzat tulajdonságaiban; a lekerekítés minden sarokra külön‑külön is alkalmazható geometriai beállításokkal.

**Hogyan tölthetem ki a téglalapot képpel (textúrával)?**  
Válassza ki a kép [fill type](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) opciót, adja meg a képfájlt, és konfigurálja a [stretching/tiling modes](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillmode/) beállításait.

**Lehet egy téglalapnak árnyéka és ragyogása?**  
Igen. Az [Outer/inner shadow, glow, and soft edges](/slides/hu/net/shape-effect/) elérhetőek állítható paraméterekkel.

**Átalakíthatom a téglalapot gombbal és hiperhivatkozással?**  
Igen. [Assign a hyperlink](/slides/hu/net/manage-hyperlinks/) hozzárendelhető az alakzat kattintásához (ugrás egy diára, fájlra, webcímre vagy e‑mailre).

**Hogyan védhetem meg a téglalapot a mozgatástól és a módosításoktól?**  
Használja a [shape locks](/slides/hu/net/applying-protection-to-presentation/) funkciót: megtilthatja a mozgatást, átméretezést, kijelölést vagy a szöveg szerkesztését a kialakítás megőrzése érdekében.

**Átalakíthatom a téglalapot raszteres képpé vagy SVG‑vé?**  
Igen. [render the shape](http://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage/) képpé konvertálható megadott mérettel/mértékkel, vagy [export it as SVG](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/writeassvg/) vektorként használható.

**Hogyan szerezhetek gyorsan valós (effektív) tulajdonságokat egy téglalapról, figyelembe véve a témát és az öröklődést?**  
Használja a [shape’s effective properties](/slides/hu/net/shape-effective-properties/) funkciót: az API kiszámított értékeket ad vissza, amelyek figyelembe veszik a téma stílusait, az elrendezést és a helyi beállításokat, egyszerűsítve a formázás elemzését.
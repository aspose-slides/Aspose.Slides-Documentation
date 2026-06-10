---
title: Képek kezelésének optimalizálása prezentációkban Java-val
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/java/image/
keywords:
- kép hozzáadása
- képkocka hozzáadása
- bitmap hozzáadása
- kép cseréje
- kép cseréje
- webről
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- EMF hozzáadása
- WMF hozzáadása
- TIFF hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- EMF
- SVG
- Java
- Aspose.Slides
description: "A PowerPoint és OpenDocument képek kezelésének egyszerűsítése az Aspose.Slides for Java segítségével, a teljesítmény optimalizálása és a munkafolyamat automatizálása."
---
## **Bevezetés**

A képek vonzóbbá és érdekesebbé teszik a prezentációkat. A Microsoft PowerPointban a képeket fájlból, az internetről vagy más helyekről szúrhatja be a diákra. Hasonlóan, az Aspose.Slides lehetővé teszi, hogy különböző eljárásokkal képeket adjon hozzá a prezentációk diáihoz. 

{{% alert  title="Tip" color="primary" %}} 

Aspose ingyenes konvertereket biztosít—[JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik, hogy gyorsan prezentációkat hozzanak létre képekből. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Ha képet szeretne keretobjektumként hozzáadni — különösen, ha standard formázási beállításokat szeretne használni a méretének módosításához, effektusok hozzáadásához stb. — lásd a [Picture Frame](https://docs.aspose.com/slides/hu/java/picture-frame/) oldalt. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Képes be- és kimeneti műveletekkel manipulálni a képeket és a PowerPoint prezentációkat egy kép formátumának átalakításához egy másikba. Lásd ezeket az oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/java/conversion/image-to-jpg/); konvertálás [JPG to image](https://products.aspose.com/slides/hu/java/conversion/jpg-to-image/); konvertálás [JPG to PNG](https://products.aspose.com/slides/hu/java/conversion/jpg-to-png/), konvertálás [PNG to JPG](https://products.aspose.com/slides/hu/java/conversion/png-to-jpg/); konvertálás [PNG to SVG](https://products.aspose.com/slides/hu/java/conversion/png-to-svg/), konvertálás [SVG to PNG](https://products.aspose.com/slides/hu/java/conversion/svg-to-png/). 

{{% /alert %}}

Az Aspose.Slides támogatja a képekkel való műveleteket ezekben a népszerű formátumokban: JPEG, PNG, GIF és egyebek. 

## **Képek helyi tárolásból történő hozzáadása a diákhoz**

Számítógépén egy vagy több képet adhat hozzá egy prezentáció diájához. Az alábbi Java példakód bemutatja, hogyan adjon képet egy diához:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Képek hozzáadása a webről a diákhoz**

Ha a diára hozzáadni kívánt kép nem érhető el a számítógépén, közvetlenül a webről adhatja hozzá. 

Ez a példakód bemutatja, hogyan adjon képet a webről egy diához Java nyelven:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Képek hozzáadása diamesterhez**

A diamester a legfelső dia, amely tárolja és irányítja az alatta lévő összes dia információit (tema, elrendezés stb.). Így, ha képet ad hozzá egy diamesterhez, az a kép minden, a diamesterhez tartozó dián megjelenik. 

Ez a Java példakód bemutatja, hogyan adjon képet egy diamesterhez:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Képek hozzáadása dia háttérként**

Előfordulhat, hogy egy képet háttérként szeretne használni egy adott diához vagy több diához. Ebben az esetben lásd a *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/hu/java/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG hozzáadása a prezentációkhoz**
Az [addPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódus használatával, amely a [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) interfészhez tartozik, bármilyen képet hozzáadhat vagy beilleszthet egy prezentációba. 

SVG képre alapozott képobjektum létrehozásához ezt a módot használhatja:

1. Hozzon létre SvgImage objektumot, majd illessze be az ImageShapeCollection-be
2. Hozzon létre PPImage objektumot az ISvgImage-ből
3. Hozzon létre PictureFrame objektumot az IPPImage interfész használatával

Ez a példakód bemutatja, hogyan valósítsa meg a fenti lépéseket SVG kép hozzáadásához a prezentációba:
```java
// PPTX fájlt képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SVG átalakítása alakzatsorozattá**
Az Aspose.Slides SVG-t alakzatsorozattá alakító funkciója hasonló a PowerPoint SVG képekkel való munkához használt funkcióhoz:

![PowerPoint Popup Menu](img_01_01.png)

A funkciót az [addGroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) metódus egyik túlterhelése biztosítja a [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) interfészen, amely az első argumentumként [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISvgImage) objektumot vár.

Ez a példakód bemutatja, hogyan használja a leírt módszert egy SVG fájl alakzatsorozattá konvertálásához:
```java 
// Új prezentáció létrehozása
IPresentation presentation = new Presentation();
try {
    // SVG fájl tartalmának beolvasása
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // SvgImage objektum létrehozása
    ISvgImage svgImage = new SvgImage(svgContent);

    // Dia méretének lekérése
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG képet alakzatcsoporttá konvertálása, a dia méretére skálázva
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Prezentáció mentése PPTX formátumban
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Képek hozzáadása EMF-ként a diákhoz**
Az Aspose.Slides for Java lehetővé teszi, hogy Excel munkalapokból EMF képeket generáljon, és ezeket a képeket EMF formátumban adja hozzá a diákhoz az Aspose.Cells segítségével.  

Ez a példakód bemutatja, hogyan hajtsa végre a leírt feladatot:
```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// A munkafüzet mentése adatfolyamra
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Képek cseréje a képgyűjteményben**

Aspose.Slides lehetővé teszi a prezentáció képgyűjteményében tárolt képek (beleértve a diák alakzatai által használtakat) cseréjét. Ez a rész több megközelítést mutat be a képgyűjtemény képeinek frissítésére. Az API egyszerű módszereket biztosít egy kép cseréjére nyers bájtadatok, egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) példány vagy egy már a gyűjteményben létező másik kép használatával.  

Kövesse az alábbi lépéseket:

1. Töltse be a képeket tartalmazó prezentációfájlt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztállyal.
2. Töltsön be egy új képet egy fájlból bájt tömbbe.
3. Cserélje le a célképet az új képre a bájt tömb használatával.
4. A második megközelítésben töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) objektumba, és cserélje le a célképet azzal az objektummal.
5. A harmadik megközelítésben cserélje le a célképet egy olyan képre, amely már létezik a prezentáció képgyűjteményében.
6. Írja a módosított prezentációt PPTX fájlként.

```java
// A prezentáció fájlt képviselő Presentation osztály példányosítása.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Az első mód.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // A második mód.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // A harmadik mód.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // A prezentáció mentése fájlba.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose INGYENES [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverter használatával könnyedén animálhat szövegeket, készíthet GIF-eket szövegekből stb. 

{{% /alert %}}

## **GYIK**

**Megmarad a forráskép felbontása a beillesztés után?**

Igen. A forráspixelek megmaradnak, de a végső megjelenés attól függ, hogyan van a [picture](/slides/hu/java/picture-frame/) méretezve a dián, és az esetleges mentési tömörítéstől.  

**Mi a legjobb módja egy logó egyszerre több tucat dián való cseréjének?**

Tegye a logót a mástér vagy elrendezés diájára, és cserélje le a prezentáció képgyűjteményében – a frissítések minden olyan elemre kihatnak, amely ezt az erőforrást használja.  

**Átalakítható egy beillesztett SVG szerkeszthető alakzatokká?**

Igen. Egy SVG-t átalakíthat egy alakzatsorozattá, amelynek egyes részei ezután a szokásos alakzattulajdonságokkal szerkeszthetők.  

**Hogyan állíthatok be egy képet több dia háttérképeként egyszerre?**

[Assign the image as the background](/slides/hu/java/presentation-background/) a mástér diáján vagy a megfelelő elrendezésen – minden, azt a mástért/elrendezést használó dia örökli a hátteret.  

**Hogyan akadályozhatom meg, hogy a prezentáció a sok kép miatt "felrobbanjon" méretben?**

Használjon egyetlen képernyő forrást a többszörös helyett, válasszon megfelelő felbontásokat, alkalmazzon tömörítést mentéskor, és a többször ismétlődő grafikákat a megfelelő helyen a mástéren tartsa.
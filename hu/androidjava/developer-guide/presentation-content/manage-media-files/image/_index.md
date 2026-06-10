---
title: Képek kezelésének optimalizálása prezentációkban Androidon
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/androidjava/image/
keywords:
- kép hozzáadása
- kép hozzáadása
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
- Android
- Java
- Aspose.Slides
description: "Optimalizálja a képek kezelését PowerPointban és OpenDocumentben az Aspose.Slides for Android Java segítségével, javítva a teljesítményt és automatizálva a munkafolyamatot."
---
## **Bevezetés**

A képek élvezetesebbé és érdekesebbé teszik a bemutatókat. A Microsoft PowerPointban képeket szúrhat be fájlból, az internetről vagy más helyekről a diába. Hasonlóan, az Aspose.Slides lehetővé teszi, hogy különböző eljárásokkal képeket adjon hozzá a diákhoz a prezentációiban.

{{% alert  title="Tip" color="primary" %}} 
Az Aspose ingyenes konvertereket nyújt —[JPEG PowerPointba](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG PowerPointba](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik, hogy gyorsan készítsen prezentációkat képekből. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Ha képet szeretne keretobjektumként hozzáadni – különösen, ha szabványos formázási beállításokat szeretne alkalmazni rá a méret módosításához, hatások hozzáadásához stb. – tekintse meg a [Képkeret](https://docs.aspose.com/slides/hu/androidjava/picture-frame/) oldalt.
{{% /alert %}} 

Az Aspose.Slides támogatja a képek kezelését ezekben a népszerű formátumokban: JPEG, PNG, GIF és egyebek. 

## **Képek hozzáadása helyi tárolásból a diákhoz**

Az számítógépén lévő egy vagy több képet hozzáadhatja egy diához a prezentációban. Az alábbi Java mintakód bemutatja, hogyan adhat hozzá egy képet egy diához:

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

Ha a diára felvenni kívánt kép nem érhető el a számítógépén, közvetlenül a webről is hozzáadhatja.

Az alábbi mintakód bemutatja, hogyan adhat hozzá egy képet a webről egy diához Java-ban:

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

## **Képek hozzáadása diákmesterekhez**

A diákmester a legfelső dia, amely tárolja és szabályozza az alatta lévő összes dia információit (téma, elrendezés stb.). Így, ha képet ad hozzá egy diákmesterhez, az a kép minden alatta lévő dián megjelenik.

Az alábbi Java mintakód bemutatja, hogyan adhat hozzá egy képet egy diákmesterhez:

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

## **Képek hozzáadása diaháttérként**

Előfordulhat, hogy egy képet háttérként szeretne használni egy adott dián vagy több dián. Ebben az esetben lásd a *[Képek beállítása háttérként a diákhoz](https://docs.aspose.com/slides/hu/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG hozzáadása prezentációkhoz**
Bármilyen képet hozzáadhat vagy beszúrhat a prezentációba a [addPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódus segítségével, amely a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) interfészhez tartozik.

Az SVG képre alapozott képobjektum létrehozásához ezt a módot használhatja:

1. Hozzon létre SvgImage objektumot, hogy beszúrja az ImageShapeCollection-be  
2. Hozzon létre PPImage objektumot az ISvgImage-ből  
3. Hozzon létre PictureFrame objektumot az IPPImage interfész használatával  

```java 
// Létrehozza a Presentation osztályt, amely PPTX fájlt képvisel
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

## **SVG átalakítása alakzatok halmazává**
Az Aspose.Slides SVG-t alakzatok halmazává alakító funkciója hasonló a PowerPoint SVG képekkel való munkára szolgáló funkcióhoz:

![PowerPoint felugró menü](img_01_01.png)

A funkciót az [addGroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) metódus egyik túlterhelése biztosítja a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) interfészen, amely első argumentumként egy [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISvgImage) objektumot kap.

Az alábbi mintakód bemutatja, hogyan használhatja a leírt metódust egy SVG fájl alakzatok halmazává konvertálásához:

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

    // SVG képet alakzatcsoporttá konvertálása a dia méretére méretezve
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
Az Aspose.Slides for Android Java használatával lehetővé válik EMF képek generálása Excel munkalapokból, és ezeknek a képeknek EMF-ként való hozzáadása a diákhoz az Aspose.Cells segítségével.  

Az alábbi mintakód bemutatja, hogyan hajtható végre a leírt feladat:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// A munkafüzet mentése adatfolyamba
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

Az Aspose.Slides lehetővé teszi, hogy kicserélje a prezentáció képgyűjteményében tárolt képeket (beleértve a diák alakzatai által használtakat). Ez a rész több megközelítést mutat be a gyűjteményben lévő képek frissítésére. Az API egyszerű módszereket kínál egy kép cseréjére nyers bájtadatok, egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) példány vagy a gyűjteményben már meglévő másik kép használatával.

1. Töltsük be a képeket tartalmazó prezentációfájlt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály segítségével.  
2. Töltsünk be egy új képet egy fájlból bájt tömbbe.  
3. Cseréljük le a célképet az új képre a bájt tömb használatával.  
4. A második megközelítésben töltsük be a képet egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) objektumba, és cseréljük le a célképet ezzel az objektummal.  
5. A harmadik megközelítésben cseréljük le a célképet egy olyan képre, amely már létezik a prezentáció képgyűjteményében.  
6. Írjuk ki a módosított prezentációt PPTX fájlként.  

```java
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Az első módszer.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // A második módszer.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // A harmadik módszer.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // A prezentáció mentése fájlba.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Az Aspose INGYENES [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverter segítségével könnyedén animálhat szövegeket, készíthet GIF-eket szövegekből stb. 
{{% /alert %}}

## **GYIK**

**Megmarad-e az eredeti kép felbontása a beillesztés után?**

Igen. A forrásbitek megmaradnak, de a végső megjelenés attól függ, hogyan van a [picture](/slides/hu/androidjava/picture-frame/) méretezve a dián és a mentéskor alkalmazott tömörítéstől.  

**Mi a legjobb módja annak, hogy egyszerre cseréljünk egy logót tucatnyi dián?**

Az logót helyezze el a mesterdián vagy egy elrendezésen, és cserélje ki a prezentáció képgyűjteményében – a módosítások minden, az erőforrást használó elemre kiterjednek.  

**Átalakítható-e a beszúrt SVG szerkeszthető alakzatokká?**

Igen. Átalakíthat egy SVG-t alakzatcsoporttá, amely után az egyes részek szerkeszthetők a szabványos alakzat tulajdonságokkal.  

**Hogyan állíthatok be egy képet egyszerre több dia háttérként?**

A képet háttérként [rendelje hozzá](/slides/hu/androidjava/presentation-background/) a mesterdián vagy a megfelelő elrendezésen – minden, azt a mester/ elrendezés használó dia örökli a hátteret.  

**Hogyan akadályozhatom meg, hogy a prezentáció sok kép miatt „nyúljon” méretben?**

Használjon egyetlen kép erőforrást másolás helyett, válasszon megfelelő felbontást, mentéskor alkalmazzon tömörítést, és ahol lehet, a gyakran ismétlődő grafikákat a mesteren tartsa.
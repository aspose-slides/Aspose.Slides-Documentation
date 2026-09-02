---
title: Prezentációs diák konvertálása képekké Java-ban
linktitle: Dia képre
type: docs
weight: 35
url: /hu/java/convert-slide/
keywords:
- dia konvertálása
- dia exportálása
- dia képre
- dia mentése képként
- dia EMF-be
- dia PNG-be
- dia JPEG-be
- dia bitmapként
- dia TIFF-be
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Konvertálja a PPT, PPTX és ODP prezentációkból a diákat PNG, JPEG, GIF, TIFF, EMF és más képformátumokra Java-ban, az Aspose.Slides segítségével."
---
## **Bevezetés**

Az Aspose.Slides for Java képes egyedi diák renderelésére PowerPoint és OpenDocument prezentációkból PNG, JPEG, GIF, TIFF és egyéb képformátumokként.

A dia képbe konvertálásához kövesse az alábbi lépéseket:

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztállyal.
2. Válassza ki a megjeleníteni kívánt diát.
3. Szükség esetén konfigurálja a renderelést a [RenderingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/renderingoptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tiffoptions/) osztállyal.
4. Hívja meg a [ISlide.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#getImage--) metódust. Ez egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) objektumot ad vissza.
5. Hívja meg a [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/#save-java.lang.String-int-) metódust, és adja meg a kimeneti formátumot egy [ImageFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imageformat/) értékkel.

## **Dia konvertálása PNG képre**

A legegyszerűbb konvertálás az alapértelmezett renderelési beállításokat használja. A keletkezett [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) objektum memóriában feldolgozható vagy fájlba menthető.

Az alábbi Java példa rendereli az első diát, és PNG képként menti:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Diák konvertálása képekké egyéni méretekkel**

Használja a [ISlide.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) túlterhelést, amely egy [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) értéket fogad el a dia pontos képpontmérettel történő rendereléséhez.

Az alábbi példa egy 1820 × 1040 JPEG képet hoz létre:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Dia konvertálása jegyzetekkel és megjegyzésekkel képekké**

Alapértelmezés szerint a dia képei nem tartalmazzák a jegyzeteket vagy megjegyzéseket. Adjon át egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notescommentslayoutingoptions/) objektumot a [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) metódusnak, hogy szabályozza, hol jelenjenek meg a jegyzetek és megjegyzések.

Az alábbi példa a lekicsinyített jegyzeteket a dia alá, a megjegyzéseket pedig jobbra helyezi:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Figyelmeztetés" color="warning" %}}
Dia képre konvertálásnál ne adjon át [BottomFull](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notespositions/) a [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) metódusnak. A jegyzetek több szöveget tartalmazhatnak, mint amit a fix képméret befogadhat. Helyette használja a [BottomTruncated](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notespositions/) opciót.
{{% /alert %}}

## **Diák konvertálása képekké TIFF opciók használatával**

A [TiffOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tiffoptions/) osztály lehetővé teszi a renderelt TIFF kép méretének, felbontásának és egyéb tulajdonságainak szabályozását.

Az alábbi példa az első diát 2160 × 2880 méretű, 300 DPI-s TIFF képként rendereli:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Figyelmeztetés" color="warning" %}}
A TIFF támogatás nem garantált a JDK 9 előtti Java verziókban.
{{% /alert %}}

## **Minden dia konvertálása képekké**

Iteráljon a diakollekción, hogy a teljes prezentációt képsorozattá alakítsa. A rejtett diák is bele vannak foglalva, hacsak nem hagyja ki őket kifejezetten.

Az alábbi példa minden diát JPEG képként renderel, a vízszintes és függőleges méretezési tényezővel 2:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Enhanced Metafile (EMF) kimenet létrehozása**

Az Enhanced Metafile (EMF) akkor hasznos, amikor vektoralapú grafikákat kell cserélni a Microsoft Office vagy más Windows alkalmazásokkal, amelyek támogatják a Windows metafájlokat. A pixelalapú képpel szemben egy EMF megőrizheti a vektoros rajzolási műveleteket, amelyek méretezéskor nem veszítenek élességben. Azonban az EMF elsősorban kompatibilitási formátum Windows metafájl támogatással rendelkező alkalmazások számára, nem egy univerzális csereformátum. Emellett a komplex diá tartalom, például bitmap képek és egyes hatások, rasterizált elemekként tárolhatók a vektor metafájl konténerben.

### **Dia exportálása EMF-re**

A [ISlide.writeAsEmf](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) metódus egy [ISlide] objektumot egy cél streambe EMF formátumban ír. Az alábbi példa betölti a prezentációt, kiválasztja az első diát, és egy EMF fájl streambe írja:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

A hívó tulajdonolja a [ISlide.writeAsEmf] metódusnak átadott streamet, és felelős annak lezárásáért, ahogyan fent is látható.

### **SVG kép konvertálása EMF-re és hozzáadása egy prezentációhoz**

Használja a [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) metódust az SVG tartalom EMF-re konvertálásához. A keletkezett bájtok hozzáadhatók a prezentációhoz a [IImageCollection.addImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) segítségével, és a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódussal elhelyezhetők egy dián.

Az alábbi példa egy [SvgImage] objektumot hoz létre SVG markupból, memóriában EMF-re konvertálja, a metafájlt az első diára helyezi el, majd menti a prezentációt:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) nem veszi át a cél stream tulajdonjogát. A [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) az összes generált adatot memóriában tárolja, így a `toByteArray` hívása előtt nincs szükség a pozíció visszaállítására. A visszaadott byte tömb a stream lezárása után is érvényes.

Az EMF generálás elérhető azokban a operációs rendszerekben, amelyeket a kiválasztott Aspose.Slides for Java és JDK konfiguráció támogat, azonban a renderelés platformonként eltérhet, ha betűtípusok vagy grafikai függőségek nem állnak rendelkezésre. Telepítse a forrás tartalom által használt betűtípusokat vagy konfiguráljon megfelelő helyettesítéseket, kövesse az [platformkövetelményeket](/slides/hu/java/system-requirements/) az Aspose.Slides for Java-hoz, és ellenőrizze az eredményt a cél EMF-öt fogyasztó alkalmazásban. A Linux és macOS alkalmazások gyakran korlátozott vagy inkonzisztens támogatással rendelkeznek a Windows metafájlok megjelenítésére és szerkesztésére.

## **Színes Emoji renderelés**

{{% alert title="Megjegyzés" color="info" %}}
A prezentáció diái képekké konvertálásakor a színes emoji-k helyes rendereléséhez a prezentációban használt emoji betűtípusoknak telepítve kell lenniük, és elérhetőeknek kell lenniük azon a rendszeren, amely a konvertálást végzi. Például, ha a prezentáció **Segoe UI Emoji** betűtípust használ, és ez hiányzik, az emoji-k monokrómként jelenhetnek meg a kimeneti képeken.
{{% /alert %}}

## **GYIK**

**Támogatja az Aspose.Slides a diák animációval történő renderelését?**

Nem. Az [ISlide.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#getImage--) metódus a dia statikus képét rendereli, és nem exportálja az animációkat.

**Exportálhatók rejtett diák képekként?**

Igen. A rejtett diák úgy renderelhetők, mint a normál diák. Vegye fel őket a feldolgozási ciklusba, ahogyan a fenti példában is látható.

**Megmaradnak az árnyékok és egyéb hatások a dia képeiben?**

Igen. Az Aspose.Slides árnyékokat, áttetszőséget és egyéb támogatott grafikai hatásokat renderel a dia képeiben.
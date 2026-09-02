---
title: Prezentációs diák konvertálása képekké Androidon
linktitle: Dia képbe
type: docs
weight: 35
url: /hu/androidjava/convert-slide/
keywords:
  - dia konvertálása
  - dia exportálása
  - dia képbe
  - dia mentése képként
  - dia EMF-be
  - dia PNG-be
  - dia JPEG-be
  - dia bitmapbe
  - dia TIFF-be
  - PowerPoint
  - OpenDocument
  - prezentáció
  - Android
  - Java
  - Aspose.Slides
description: "Konvertálja a PPT, PPTX és ODP prezentációkból származó diákot PNG, JPEG, GIF, TIFF, EMF és egyéb képformátumokra Androidon az Aspose.Slides segítségével."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java képes a PowerPoint és OpenDocument prezentációk egyes diákját PNG, JPEG, GIF, TIFF és más képformátumokban megjeleníteni.

Egy dia képpé konvertálásához kövesse az alábbi lépéseket:

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztállyal.
2. Válassza ki a megjeleníteni kívánt diát.
3. Szükség esetén állítsa be a megjelenítést a [RenderingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/renderingoptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/) osztállyal.
4. Hívja meg a [ISlide.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getImage--) metódust. Ez egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) objektumot ad vissza.
5. Hívja meg az [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metódust, és adja meg a kimeneti formátumot egy [ImageFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imageformat/) értékkel.

## **Dia konvertálása PNG képpé**

A legegyszerűbb konvertálás az alapértelmezett megjelenítési beállítások használatával történik. A kapott [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) objektum feldolgozható memóriában vagy menthető fájlba.

Az alábbi Java példa a első diát rendereli, és PNG képként menti:

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

## **Diák konvertálása egyéni méretekkel**

Használja az [ISlide.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) túlterhelést, amely egy [Size](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides.android/size/) értéket fogad, hogy a diát pontos képpontméretekkel renderelje.

Az alábbi példa egy 1820 × 1040 méretű JPEG képet hoz létre:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

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

## **Diák konvertálása megjegyzésekkel és megjegyzésekkel együtt**

Alapértelmezés szerint a diaképek nem tartalmazzák a jegyzeteket vagy a kommentárokat. Adjon meg egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notescommentslayoutingoptions/) objektumot a [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) metódusnak, hogy szabályozza, hol jelenjenek meg a jegyzetek és kommentárok.

Az alábbi példa a levágott jegyzeteket a dia alá, a kommentárokat pedig jobbra helyezi:

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

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

{{% alert title="Warning" color="warning" %}}
Dia‑kép konvertálásánál ne adja át a [BottomFull](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notespositions/) értéket a [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) metódusnak. A jegyzetek több szöveget tartalmazhatnak, mint amennyit a fix képméret befogad. Használja helyette a [BottomTruncated](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notespositions/) értéket.
{{% /alert %}}

## **Diák konvertálása TIFF beállításokkal**

A [TiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/) osztály lehetővé teszi a renderelt TIFF kép méretének, felbontásának és egyéb tulajdonságainak vezérlését.

Az alábbi példa az első diát 2160 × 2880 pixeles, 300 DPI‑s TIFF képpé rendereli:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

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

## **Az összes dia konvertálása képekké**

Iteráljon a dia‑gyűjteményen, hogy a teljes prezentációt sorozat képpé alakítsa. A rejtett diák is belekerülnek, hacsak nem hagyja ki őket kifejezetten.

Az alábbi példa minden diát JPEG képként renderel, vízszintes és függőleges méretezési tényezőkkel 2:

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

Az Enhanced Metafile (EMF) akkor hasznos, amikor vektorgrafikákat kell cserélni a Microsoft Office‑sal vagy más Windows‑alkalmazásokkal, amelyek támogatják a Windows metafájlokat. A pixel‑alapú képpel ellentétben az EMF megőrizheti a vektoros ábrázolást, amely skálázáskor nem veszti el a pontosságát. Az EMF azonban elsősorban kompatibilitási formátum Windows‑metafájl‑támogatással rendelkező alkalmazások számára, nem pedig univerzális csereformátum. Emellett a komplex dia‑tartalom, például bitmap képek és egyes effektusok, rasterizált elemekként jelenhet meg a vektor‑metafájl konténerben.

### **Dia exportálása EMF‑be**

Az [ISlide.writeAsEmf](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) metódus egy [ISlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/) objektumot ír egy cél‑streambe EMF formátumban. Az alábbi példa betölt egy prezentációt, kiválasztja az első diát, és EMF fájl‑streambe írja:

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

A hívó tulajdonolja a [ISlide.writeAsEmf](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) metódusnak átadott streamet, és felelős annak lezárásáért, ahogyan a fenti példában látható.

### **SVG kép konvertálása EMF‑be és hozzáadása a prezentációhoz**

Használja az [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) metódust az SVG tartalom EMF‑re való átalakításához. A kapott bájtok hozzáadhatók a prezentációhoz a [IImageCollection.addImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) metódussal, és elhelyezhetők egy dián a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódussal.

Az alábbi példa egy SVG‑markuptól kiindulva létrehoz egy [SvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgimage/)-t, konvertálja memóriabeli EMF‑be, beilleszti a metafájlt az első diára, és elmenti a prezentációt:

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

Az [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) nem veszi át a cél‑stream tulajdonjogát. Egy [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) minden generált adatot memóriában tárol, így a `toByteArray` hívása előtt nincs szükség a pozíció visszaállítására. A visszaadott bájt‑tömb a stream lezárása után is érvényes marad.

Az EMF generálás elérhető a támogatott Android‑verziókon és eszközkonfigurációkon, de a renderelés eltérhet, ha a betűkészletek vagy grafikus függőségek nem állnak rendelkezésre. Telepítse a forrás‑tartalom által használt betűkészleteket, vagy konfigurálja a megfelelő helyettesítéseket, kövesse a [telepítési útmutatót](/slides/hu/androidjava/install-aspose-slides-for-android-via-java/) az Aspose.Slides for Android via Java használatához, és ellenőrizze az eredményt a cél EMF‑fogyasztó alkalmazásban. A nem‑Windows platformokon futó alkalmazások gyakran korlátozott vagy változó támogatással rendelkeznek a Windows‑metafájlok megjelenítésében és szerkesztésében.

## **Színes Emoji renderelés**

{{% alert title="Note" color="info" %}}
A prezentációs diák kép‑formátumba való konvertálásakor a színes emoji‑k helyes megjelenítéséhez a prezentációban használt emoji‑betűkészleteket telepíteni kell, és elérhetőknek kell lenniük azon a rendszeren, amely a konvertálást végzi. Például ha a prezentáció a **Segoe UI Emoji** betűkészletet használja, és ez hiányzik, az emoji‑k monokrómként jelenhetnek meg a kimeneti képeken.
{{% /alert %}}

## **GYIK**

**Támogatja az Aspose.Slides a diák animációval történő renderelését?**

Nem. Az [ISlide.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getImage--) metódus statikus képet állít elő a diákról, és nem exportálja az animációkat.

**Exportálhatók-e a rejtett diák képként?**

Igen. A rejtett diák ugyanúgy renderelhetők, mint a normál diák. Vegye fel őket a feldolgozási ciklusba, ahogyan a fenti példában látható.

**Megmaradnak-e az árnyékok és egyéb effektusok a diaképekben?**

Igen. Az Aspose.Slides árnyékokat, átlátszóságot és a támogatott grafikai effektusok többi részét megjeleníti a diaképeken.
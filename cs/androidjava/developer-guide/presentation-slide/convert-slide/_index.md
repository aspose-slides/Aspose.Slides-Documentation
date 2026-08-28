---
title: Převod snímků prezentace na obrázky v Androidu
linktitle: Snímek na obrázek
type: docs
weight: 35
url: /cs/androidjava/convert-slide/
keywords: 
- převod snímku
- export snímku
- snímek na obrázek
- uložit snímek jako obrázek
- snímek na EMF
- snímek na PNG
- snímek na JPEG
- snímek na bitmapu
- snímek na TIFF
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Převod snímků z prezentací PPT, PPTX a ODP na PNG, JPEG, GIF, TIFF, EMF a další formáty obrázků v Androidu s Aspose.Slides."
---
## **Úvod**

Aspose.Slides for Android via Java dokáže vykreslovat jednotlivé snímky z prezentací PowerPoint a OpenDocument ve formátech PNG, JPEG, GIF, TIFF a dalších formátech obrázků.

Pro převod snímku na obrázek postupujte podle těchto kroků:

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Vyberte snímek, který chcete vykreslit.
3. V případě potřeby nakonfigurujte vykreslování pomocí třídy [RenderingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/renderingoptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/).
4. Zavolejte metodu [ISlide.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getImage--) . Vrátí objekt [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/).
5. Zavolejte metodu [IImage.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) a specifikujte výstupní formát pomocí hodnoty [ImageFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imageformat/).

## **Převod snímku na PNG obrázek**

Nejjednodušší převod používá výchozí nastavení vykreslování. Výsledný objekt [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) lze zpracovat v paměti nebo uložit do souboru.

Následující Java příklad vykreslí první snímek a uloží jej jako PNG obrázek:

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

## **Převod snímků na obrázky s vlastními rozměry**

Použijte přetížení [ISlide.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) , které přijímá hodnotu [Size](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides.android/size/) , pro vykreslení snímku s přesnými rozměry v pixelech.

Následující příklad vytvoří JPEG obrázek o rozměrech 1820 × 1040:

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

## **Převod snímků s poznámkami a komentáři na obrázky**

Ve výchozím nastavení obrázky snímků neobsahují poznámky ani komentáře. Předávejte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notescommentslayoutingoptions/) metodě [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) , abyste určili, kde se poznámky a komentáře zobrazí.

Následující příklad umístí zkrácené poznámky pod snímek a komentáře napravo od něj:

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
Pro převod snímků na obrázky nepředávejte [BottomFull](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notespositions/) metodě [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) . Poznámky mohou obsahovat více textu, než je možné do pevné velikosti obrázku vejmout. Použijte místo toho [BottomTruncated](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notespositions/) .
{{% /alert %}}

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tiffoptions/) vám umožní nastavit velikost, rozlišení a další vlastnosti vykresleného TIFF obrázku.

Následující příklad vykreslí první snímek jako TIFF obrázek o rozměrech 2160 × 2880 při 300 DPI:

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

## **Převod všech snímků na obrázky**

Projděte kolekci snímků a převádějte celou prezentaci na sérii obrázků. Skryté snímky jsou zahrnuty, pokud je výslovně nevynecháte.

Následující příklad vykreslí každý snímek jako JPEG obrázek s horizontálním a vertikálním měřítkem 2:

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

## **Vytvoření výstupu Enhanced Metafile**

Enhanced Metafile (EMF) je užitečný, když je třeba vyměňovat vektorovou grafiku s Microsoft Office nebo jinými aplikacemi Windows, které podporují Windows metafily. Na rozdíl od rastrového obrázku může EMF zachovat vektorové kreslící operace, které se škálují bez ztráty ostrosti. EMF však slouží především jako formát kompatibility pro aplikace podporující Windows metafily, nikoli jako univerzální výměnný formát. Navíc složitý obsah snímků, jako jsou bitmapové obrázky a některé efekty, může být uložen jako rasterizované prvky uvnitř kontejneru vektorového metafile.

### **Export snímku do EMF**

Metoda [ISlide.writeAsEmf](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) zapíše [ISlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/) do cílového proudu ve formátu EMF. Následující příklad načte prezentaci, vybere první snímek a zapíše jej do EMF souborového proudu:

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

Volající vlastní proud předaný metodě [ISlide.writeAsEmf](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) a je zodpovědný za jeho uzavření, jak je uvedeno výše.

### **Převod SVG obrázku do EMF a jeho přidání do prezentace**

Použijte [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) k převodu SVG obsahu do EMF. Výsledná bajtová data lze přidat do prezentace pomocí [IImageCollection.addImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) a umístit na snímek pomocí [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Následující příklad vytvoří [SvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgimage/) ze SVG značkování, převede jej na EMF v paměti, vloží metafil na první snímek a uloží prezentaci:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) nepřebírá vlastnictví cílového proudu. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) ukládá všechna vygenerovaná data v paměti, takže před voláním `toByteArray` není potřeba resetovat pozici. Vrácené pole bajtů zůstává platné po uzavření proudu.

Generování EMF je k dispozici na podporovaných verzích Androidu a konfiguracích zařízení, ale vykreslování se může lišit, když nejsou k dispozici písma nebo grafické závislosti. Nainstalujte písma používaná ve zdrojovém obsahu nebo nakonfigurujte vhodné náhrady, postupujte podle [průvodce instalací](/slides/cs/androidjava/install-aspose-slides-for-android-via-java/) pro Aspose.Slides for Android via Java a ověřte výsledek v cílové aplikaci, která EMF spotřebovává. Aplikace na ne‑Windows platformách často mají omezenou nebo nekonzistentní podporu pro zobrazování a editaci Windows metafilů.

## **Vykreslování barevných emoji**

{{% alert title="Note" color="info" %}}
Aby se při převodu snímků prezentace na obrázky správně vykreslovaly barevné emoji, musí být nainstalována a dostupná na systému provádějícím převod písma emoji použité v prezentaci. Například pokud prezentace používá **Segoe UI Emoji** a toto písmo chybí, mohou se emoji ve výstupních obrázcích zobrazovat v černobílé.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne. Metoda [ISlide.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getImage--) vykresluje statický obrázek snímku a neexportuje animace.

**Lze skryté snímky exportovat jako obrázky?**

Ano. Skryté snímky lze vykreslit jako běžné snímky. Zařaďte je do smyčky zpracování, jak je uvedeno v příkladu výše.

**Zachovají se stíny a další efekty v obrázcích snímků?**

Ano. Aspose.Slides vykresluje stíny, průhlednost a další podporované grafické efekty v obrázcích snímků.
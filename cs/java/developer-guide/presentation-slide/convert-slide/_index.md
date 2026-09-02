---
title: Převod snímků prezentace na obrázky v Javě
linktitle: Snímek na obrázek
type: docs
weight: 35
url: /cs/java/convert-slide/
keywords:
- převod snímku
- exportovat snímek
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
- Java
- Aspose.Slides
description: "Převod snímků z prezentací PPT, PPTX a ODP na PNG, JPEG, GIF, TIFF, EMF a další formáty obrázků v Javě pomocí Aspose.Slides."
---
## **Úvod**

Aspose.Slides pro Java může vykreslovat jednotlivé snímky z prezentací PowerPoint a OpenDocument jako PNG, JPEG, GIF, TIFF a další formáty obrázků.

Pro převod snímku na obrázek postupujte podle následujících kroků:

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) .
2. Vyberte snímek, který chcete vykreslit.
3. V případě potřeby nakonfigurujte vykreslování pomocí třídy [RenderingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/renderingoptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/) .
4. Zavolejte metodu [ISlide.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getImage--) . Vrátí objekt [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) .
5. Zavolejte metodu [IImage.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/#save-java.lang.String-int-) a zadejte výstupní formát pomocí hodnoty [ImageFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imageformat/) .

## **Převod snímku na PNG obrázek**

Nejjednodušší převod používá výchozí nastavení vykreslování. Výsledný objekt [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) může být zpracován v paměti nebo uložen do souboru.

Následující Java příklad vykresluje první snímek a uloží jej jako PNG obrázek:

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

Použijte přetížení [ISlide.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) , které přijímá hodnotu [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) , pro vykreslení snímku s přesnými rozměry v pixelech.

Následující příklad vytváří JPEG obrázek o rozměrech 1820 × 1040:

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

## **Převod snímků s poznámkami a komentáři na obrázky**

Ve výchozím nastavení obrázky snímků neobsahují poznámky ani komentáře. Předáte objekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notescommentslayoutingoptions/) metodě [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) , abyste určili, kde se mají poznámky a komentáře zobrazovat.

Následující příklad umístí zkrácené poznámky pod snímek a komentáře vpravo od něj:

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

{{% alert title="Warning" color="warning" %}}
Pro převod snímku na obrázek nepředejte [BottomFull](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notespositions/) metodě [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) . Poznámky mohou obsahovat více textu, než umožňuje pevná velikost obrázku. Použijte místo toho [BottomTruncated](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notespositions/) .
{{% /alert %}}

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tiffoptions/) vám umožňuje ovládat velikost, rozlišení a další vlastnosti vykresleného TIFF obrázku.

Následující příklad vykresluje první snímek jako TIFF obrázek o rozměrech 2160 × 2880 při 300 DPI:

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

{{% alert title="Warning" color="warning" %}}
Podpora TIFF není zaručena ve verzích Javy starších než JDK 9.
{{% /alert %}}

## **Převod všech snímků na obrázky**

Iterujte přes kolekci snímků a převádějte celou prezentaci na sérii obrázků. Skryté snímky jsou zahrnuty, pokud je výslovně nevynecháte.

Následující příklad vykresluje každý snímek jako JPEG obrázek s horizontálními i vertikálními měřítky 2:

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

Metafile Enhanced (EMF) je užitečný, když je třeba vyměňovat vektorovou grafiku s Microsoft Office nebo jinými aplikacemi Windows, které podporují Windows metafily. Na rozdíl od obrázku založeného na pixelech může EMF zachovat vektorové kreslicí operace, které se škálují bez ztráty ostrosti. Přesto je EMF především formátem kompatibility pro aplikace s podporou Windows metafile, nikoli univerzálním výměnným formátem. Navíc může být složitý obsah snímku, jako bitmapové obrázky a některé efekty, uložen jako rastrové prvky uvnitř vektorového kontejneru metafile.

### **Export snímku do EMF**

Metoda [ISlide.writeAsEmf](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) zapisuje [ISlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/) do cílového proudu ve formátu EMF. Následující příklad načte prezentaci, vybere první snímek a zapíše jej do EMF souborového proudu:

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

Volající vlastní proud předaný metodě [ISlide.writeAsEmf](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) a je zodpovědný za jeho uzavření, jak je uvedeno výše.

### **Převod SVG obrázku na EMF a jeho přidání do prezentace**

Použijte [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) , abyste převedli obsah SVG na EMF. Výsledná data mohou být přidána do prezentace pomocí [IImageCollection.addImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) a umístěna na snímek pomocí [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) .

Následující příklad vytvoří [SvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgimage/) ze značkovacího jazyka SVG, převede jej na EMF v paměti, vloží metafile na první snímek a uloží prezentaci:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) nepřebírá vlastnictví cílového proudu. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) ukládá všechna vygenerovaná data do paměti, takže není nutné před voláním `toByteArray` resetovat pozici. Vrácené pole bajtů zůstává platné po uzavření proudu.

Generování EMF je k dispozici na operačních systémech podporovaných vybraným Aspose.Slides pro Java a konfigurací JDK, ale vykreslování se může lišit napříč platformami, pokud nejsou k dispozici fonty nebo grafické závislosti. Nainstalujte fonty použité ve zdrojovém obsahu nebo nakonfigurujte vhodné náhrady, dodržujte [požadavky na platformu](/slides/cs/java/system-requirements/) pro Aspose.Slides pro Java a ověřte výsledek v cílové aplikaci, která EMF konzumuje. Linuxové a macOS aplikace často mají omezenou nebo nekonzistentní podporu pro zobrazování a editaci Windows metafile.

## **Vykreslování barevných emoji**

{{% alert title="Note" color="info" %}}
Pro správné vykreslení barevných emoji při převodu snímků prezentace na obrázky musí být na systému, který provádí převod, nainstalovány a dostupné fonty emoji použité v prezentaci. Například pokud prezentace používá **Segoe UI Emoji** a tento font chybí, mohou se emoji v výstupních obrázcích zobrazovat v jednobarevném odstínu.
{{% /alert %}}

## **Časté dotazy**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne. Metoda [ISlide.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getImage--) vykresluje statický obrázek snímku a neexportuje animace.

**Mohou být skryté snímky exportovány jako obrázky?**

Ano. Skryté snímky mohou být vykresleny jako běžné snímky. Zahrňte je do smyčky zpracování, jak je ukázáno v předchozím příkladu.

**Zachovají se stíny a další efekty v obrázcích snímků?**

Ano. Aspose.Slides vykresluje stíny, průhlednost a další podporované grafické efekty v obrázcích snímků.
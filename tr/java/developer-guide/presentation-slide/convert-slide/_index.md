---
title: Java'da Sunum Slaytlarını Görüntülere Dönüştürme
linktitle: Slayttan Görüntüye
type: docs
weight: 35
url: /tr/java/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slaytı görüntüye
- slaytı görüntü olarak kaydet
- slaytı EMF'ye
- slaytı PNG'ye
- slaytı JPEG'e
- slaytı bitmap'e
- slaytı TIFF'e
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java'da PPT, PPTX ve ODP sunumlarından PNG, JPEG, GIF, TIFF, EMF ve diğer görüntü biçimlerine slaytları dönüştürün."
---
## **Giriş**

Aspose.Slides for Java, PowerPoint ve OpenDocument sunumlarından tek tek slaytları PNG, JPEG, GIF, TIFF ve diğer görüntü biçimleri olarak oluşturabilir.

Bir slaytı görüntüye dönüştürmek için şu adımları izleyin:

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. Oluşturmak istediğiniz slaytı seçin.
3. Gerekirse, renderlemeyi [RenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/renderingoptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) sınıfı ile yapılandırın.
4. [ISlide.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage--) yöntemini çağırın. Bu, bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) nesnesi döndürür.
5. [IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) yöntemini çağırın ve çıktının formatını bir [ImageFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imageformat/) değeriyle belirtin.

## **Bir Slaytı PNG Görüntüsüne Dönüştürme**

En basit dönüşüm, varsayılan render ayarlarını kullanır. Oluşan [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) nesnesi bellek içinde işlenebilir veya bir dosyaya kaydedilebilir.

Aşağıdaki Java örneği ilk slaytı renderlayıp PNG görüntüsü olarak kaydeder:

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

## **Özel Boyutlarla Slaytları Görüntülere Dönüştürme**

[Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) değerini kabul eden [ISlide.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) aşırı yüklemesini kullanarak slaytı tam piksel boyutlarıyla renderlayın.

Aşağıdaki örnek 1820 × 1040 JPEG görüntüsü oluşturur:

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

## **Not ve Yorumlarıyla Slaytları Görüntülere Dönüştürme**

Varsayılan olarak, slayt görüntüleri notları veya yorumları içermez. Notların ve yorumların nerede görüneceğini kontrol etmek için bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notescommentslayoutingoptions/) nesnesini [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) yöntemine gönderin.

Aşağıdaki örnek kısaltılmış notları slaytın altına, yorumları ise sağ tarafına yerleştirir:

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
Slaytı-görüntüye dönüştürme işlemi için, [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-com.aspose.slides.ISlidesLayoutOptions-) yöntemine [BottomFull](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notespositions/) parametresini gönderme. Notlar, sabit görüntü boyutunun alabileceğinden daha fazla metin içerebilir. Bunun yerine [BottomTruncated](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notespositions/) kullanın.
{{% /alert %}}

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) sınıfı, renderlanan TIFF görüntüsünün boyutunu, çözünürlüğünü ve diğer özelliklerini kontrol etmenizi sağlar.

Aşağıdaki örnek ilk slaytı 2160 × 2880 boyutunda, 300 DPI'da bir TIFF görüntüsü olarak renderlar:

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
TIFF desteği, JDK 9'dan önceki Java sürümlerinde garanti edilmez.
{{% /alert %}}

## **Tüm Slaytları Görüntülere Dönüştürme**

Tüm sunumu bir dizi görüntüye dönüştürmek için slayt koleksiyonunda döngü oluşturun. Gizli slaytlar, açıkça atlamadığınız sürece dahil edilir.

Aşağıdaki örnek, her slaytı yatay ve dikey ölçek faktörleri 2 olan bir JPEG görüntüsü olarak renderlar:

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

## **Gelişmiş Metafile Çıktısı Oluşturma**

Gelişmiş Metafile (EMF), vektör tabanlı grafiklerin Microsoft Office veya Windows metafil desteği olan diğer Windows uygulamalarıyla değiş tokuş edilmesi gerektiğinde faydalıdır. Piksel tabanlı bir görüntünün aksine, EMF ölçeklendiğinde keskinliğini kaybetmeden vektör çizim işlemlerini koruyabilir. Ancak EMF, esas olarak Windows metafil desteği olan uygulamalar için bir uyumluluk biçimidir, evrensel bir değişim formatı değildir. Ayrıca, bitmap görüntüler ve bazı efektler gibi karmaşık slayt içerikleri, vektör metafil kapsayıcısı içinde rasterleştirilmiş öğeler olarak saklanabilir.

### **Bir Slaytı EMF Olarak Dışa Aktarma**

[ISlide.writeAsEmf](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) yöntemi bir [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/) nesnesini EMF formatında hedef bir akıma yazar. Aşağıdaki örnek bir sunumu yükler, ilk slaytı seçer ve onu bir EMF dosya akımına yazar:

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

Çağırıcı, [ISlide.writeAsEmf](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) yöntemine geçirilen akımı sahiplenir ve yukarıda gösterildiği gibi akımı kapatmakla sorumludur.

### **Bir SVG Görüntüyü EMF'ye Dönüştürme ve Sunuma Ekleme**

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) yöntemini kullanarak SVG içeriğini EMF'ye dönüştürün. Oluşan baytlar, [IImageCollection.addImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) aracılığıyla sunuma eklenebilir ve bir slayta [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ile yerleştirilebilir.

Aşağıdaki örnek, SVG işaretlemesinden bir [SvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgimage/) oluşturur, bunu bellekte bir EMF'ye dönüştürür, metafili ilk slayta ekler ve sunumu kaydeder:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) hedef akımın sahipliğini almaz. Bir [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) tüm oluşturulan verileri bellekte saklar, bu yüzden `toByteArray` çağrılmadan önce konum sıfırlamaya gerek yoktur. Döndürülen bayt dizisi, akım kapatıldıktan sonra da geçerliliğini korur.

EMF oluşturma, seçilen Aspose.Slides for Java ve JDK yapılandırması tarafından desteklenen işletim sistemlerinde kullanılabilir, ancak fontlar veya grafik bağımlılıkları mevcut olmadığında platformlar arasında renderleme farklılık gösterebilir. Kaynak içeriğin kullandığı fontları yükleyin veya uygun ikameler yapılandırın, Aspose.Slides for Java için [platform gereksinimlerini](/slides/tr/java/system-requirements/) izleyin ve sonucu hedef EMF tüketen uygulamada doğrulayın. Linux ve macOS uygulamaları genellikle Windows metafillerinin görüntülenmesi ve düzenlenmesi konusunda sınırlı veya tutarsız destek sunar.

## **Renkli Emoji Renderleme**

{{% alert title="Note" color="info" %}}
Sunum slaytlarını görüntülere dönüştürürken renkli emojileri doğru bir şekilde renderlamak için, sunumda kullanılan emoji fontlarının dönüşümü yapan sistemde yüklü ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** kullanıyorsa ve bu font eksikse, emojiler çıktı görüntülerinde tek renkli görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytları renderlamayı destekliyor mu?**

Hayır. [ISlide.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage--) yöntemi slaydın statik bir görüntüsünü oluşturur ve animasyonları dışa aktarmaz.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet. Gizli slaytlar, normal slaytlar gibi renderlanabilir. Yukarıdaki örnekte gösterildiği gibi işleme döngüsüne dahil edin.

**Gölgeler ve diğer efektler slayt görüntülerinde korunur mu?**

Evet. Aspose.Slides, gölgeleri, saydamlığı ve diğer desteklenen grafik efektleri slayt görüntülerinde renderlar.
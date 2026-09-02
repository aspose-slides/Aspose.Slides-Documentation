---
title: Android'de Sunum Slaytlarını Görüntülere Dönüştürme
linktitle: Slayttan Görüntüye
type: docs
weight: 35
url: /tr/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "Android'de PPT, PPTX ve ODP sunumlarından PNG, JPEG, GIF, TIFF, EMF ve diğer görüntü formatlarına Aspose.Slides ile dönüştürün."
---
## **Giriş**

Aspose.Slides for Android via Java, PowerPoint ve OpenDocument sunumlarından tek tek slaytları PNG, JPEG, GIF, TIFF ve diğer görüntü formatları olarak oluşturabilir.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. Renderlamak istediğiniz slaytı seçin.
3. Gerekirse, renderlamayı [RenderingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/renderingoptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/) sınıfları ile yapılandırın.
4. [ISlide.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage--) metodunu çağırın. Bu metod bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) nesnesi döndürür.
5. [IImage.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metodunu çağırın ve çıkış formatını bir [ImageFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imageformat/) değeriyle belirtin.

## **Bir Slaytı PNG Görüntüsü Olarak Dönüştürme**

En basit dönüşüm, varsayılan render ayarlarını kullanır. Oluşan [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) nesnesi bellek içinde işlenebilir veya bir dosyaya kaydedilebilir.

Aşağıdaki Java örneği ilk slaytı renderlar ve PNG görüntüsü olarak kaydeder:

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

Bir slaytı tam piksel boyutlarıyla renderlamak için, bir [Size](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides.android/size/) değerini kabul eden [ISlide.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) aşırı yüklemesini kullanın.

Aşağıdaki örnek 1820 × 1040 JPEG görüntüsü oluşturur:

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

## **Notlar ve Yorumlarla Slaytları Görüntülere Dönüştürme**

Varsayılan olarak, slayt görüntüleri notları veya yorumları içermez. Notların ve yorumların nerede görüneceğini kontrol etmek için bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) nesnesini [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) metoduna gönderin.

Aşağıdaki örnek, kesilmiş notları slaytın altına ve yorumları sağ tarafına yerleştirir:

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

{{% alert title="Uyarı" color="warning" %}}
Slayt‑görsel dönüşümü için, [BottomFull](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notespositions/) metoduna [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) metoduna geçmeyin. Notlar, sabit görüntü boyutunun alabileceğinden daha fazla metin içerebilir. Bunun yerine [BottomTruncated](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notespositions/) kullanın.
{{% /alert %}}

## **TIFF Seçenekleri Kullanarak Slaytları Görüntülere Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/) sınıfı, renderlanmış TIFF görüntüsünün boyutunu, çözünürlüğünü ve diğer özelliklerini kontrol etmenizi sağlar.

Aşağıdaki örnek ilk slaytı 2160 × 2880 TIFF görüntüsü olarak 300 DPI'de renderlar:

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

## **Tüm Slaytları Görüntülere Dönüştürme**

Sunumdaki tüm slaytları bir dizi görüntüye dönüştürmek için slayt koleksiyonunu yineleyin. Gizli slaytlar, açıkça atlamadığınız sürece dahil edilir.

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

## **Geliştirilmiş Metafile Çıktısı Oluşturma**

Geliştirilmiş Metafile (EMF), vektör tabanlı grafiklerin Microsoft Office veya Windows metafilleri destekleyen diğer Windows uygulamalarıyla değiş tokuş edilmesi gerektiğinde faydalıdır. Piksel tabanlı bir görüntünün aksine, EMF ölçeklendiğinde aynı keskinlik kaybını yaşamadan vektörel çizim işlemlerini koruyabilir. Ancak EMF, esas olarak Windows metafili desteği olan uygulamalar için bir uyumluluk formatıdır, evrensel bir değişim formatı değildir. Buna ek olarak, bitmap görüntüler ve bazı efektler gibi karmaşık slayt içeriği, vektörel metafile konteyneri içinde rasterleştirilmiş öğeler olarak depolanabilir.

### **Bir Slaytı EMF'ye Dışa Aktarma**

[ISlide.writeAsEmf](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) metodu, bir [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) nesnesini EMF formatında hedef akışa yazar. Aşağıdaki örnek bir sunumu yükler, ilk slaytı seçer ve onu bir EMF dosya akışına yazar:

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

Yukarıdaki gibi, [ISlide.writeAsEmf](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) metoduna geçirilen akışa çağıran sahiptir ve akışı kapatmakla sorumludur.

### **SVG Görüntüsünü EMF'ye Dönüştürme ve Sunuma Ekleme**

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) kullanarak SVG içeriğini EMF'ye dönüştürün. Oluşan baytlar, [IImageCollection.addImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) ile sunuma eklenebilir ve [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ile bir slayta yerleştirilebilir.

Aşağıdaki örnek SVG işaretlemesinden bir [SvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgimage/) oluşturur, bellek içinde bir EMF'ye dönüştürür, metafile'i ilk slayta ekler ve sunumu kaydeder:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) hedef akışının sahipliğini almaz. Bir [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) tüm üretilen veriyi bellekte saklar, bu yüzden `toByteArray` çağrılmadan önce konum sıfırlamaya gerek yoktur. Döndürülen bayt dizisi akış kapatıldıktan sonra da geçerliliğini korur.

EMF oluşturma, desteklenen Android sürümlerinde ve cihaz yapılandırmalarında kullanılabilir, ancak yazı tipleri veya grafik bağımlılıkları mevcut değilse renderlama farklılık gösterebilir. Kaynak içeriğin kullandığı yazı tiplerini kurun veya uygun ikameler yapılandırın, Aspose.Slides for Android via Java için [kurulum kılavuzunu](/slides/tr/androidjava/install-aspose-slides-for-android-via-java/) izleyin ve hedef EMF‑kullanan uygulamada sonucu doğrulayın. Windows dışı platformlardaki uygulamalar genellikle Windows metafillerinin görüntülenmesi ve düzenlenmesi konusunda sınırlı ya da tutarsız destek sunar.

## **Renkli Emoji Renderlama**

{{% alert title="Not" color="info" %}}
Sunum slaytlarını görüntülere dönüştürürken renkli emoji'lerin doğru renderlanması için, sunumda kullanılan emoji yazı tiplerinin dönüşüm yapan sistemde kurulu ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emoji'ler çıktı görüntülerinde tek renkli görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytları renderlamayı destekliyor mu?**

Hayır. [ISlide.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage--) metodu, slaytın statik bir görüntüsünü renderlar ve animasyonları dışa aktarmaz.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet. Gizli slaytlar normal slaytlar gibi renderlanabilir. Yukarıdaki örnekte gösterildiği gibi işleme döngüsüne dahil edin.

**Slayt görüntülerinde gölgeler ve diğer efektler korunuyor mu?**

Evet. Aspose.Slides, slayt görüntülerinde gölgeler, şeffaflık ve diğer desteklenen grafik efektlerini renderlar.
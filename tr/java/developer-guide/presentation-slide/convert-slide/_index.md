---
title: Java'da Sunum Slaytlarını Görüntülere Dönüştür
linktitle: Slayttan Görüntüye
type: docs
weight: 35
url: /tr/java/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görüntüye
- slaytı görüntü olarak kaydet
- slayttan PNG
- slayttan JPEG
- slayttan bitmap
- slayttan TIFF
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PPT, PPTX ve ODP dosyalarındaki slaytları görüntülere dönüştürün—hızlı, yüksek kaliteli renderleme ve açık kod örnekleri."
---
## **Giriş**

Aspose.Slides for Java, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğerlerini içeren çeşitli görüntü biçimlerine kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için şu adımları izleyin:

1. İstediğiniz dönüşüm ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları aşağıdaki kullanarak seçin:
    - [ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) arayüzü, veya
    - [IRenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/irenderingoptions/) arayüzü.
2. [getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) metodunu çağırarak slayt görüntüsünü oluşturun.

Aspose.Slides for Java'da, [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) bir arayüzdür ve piksel verileriyle tanımlanan görüntülerle çalışmanıza olanak tanır. Bu arayüzü, görüntüleri geniş bir biçim yelpazesinde (BMP, JPG, PNG vb.) kaydetmek için kullanabilirsiniz.

## **Slaytları Bitmap'lere Dönüştür ve PNG Olarak Görüntüleri Kaydet**

Bir slaytı bitmap nesnesine dönüştürüp doğrudan uygulamanızda kullanabilirsiniz. Alternatif olarak, slaytı bitmap'e dönüştürüp ardından görüntüyü JPEG veya tercih ettiğiniz başka bir formatta kaydedebilirsiniz.

Bu kod, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp ardından PNG formatında kaydetmeyi gösterir:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı bitmap'e dönüştür.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Görüntüyü PNG biçiminde kaydet.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Slaytları Özel Boyutlarda Görüntülere Dönüştür**

Belirli bir boyutta bir görüntü elde etmeniz gerekebilir. [getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) metodunun bir aşırı yüklemesini kullanarak, bir slaytı belirli boyutlarda (genişlik ve yükseklik) görüntüye dönüştürebilirsiniz.

Bu örnek kod, bunu nasıl yapacağınızı gösterir:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı belirtilen boyutta bitmap'e dönüştür.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Görüntüyü JPEG biçiminde kaydet.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Notlar ve Yorumlar İçeren Slaytları Görüntülere Dönüştür**

Bazı slaytlar not ve yorumlar içerebilir.

Aspose.Slides, sunum slaytlarının görüntülere renderlanmasını kontrol etmenizi sağlayan iki arayüz—[ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) ve [IRenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/irenderingoptions/)—sunar. Her iki arayüz de `setSlidesLayoutOptions` metodunu içerir; bu metod, bir slaytı görüntüye dönüştürürken notların ve yorumların renderlanmasını yapılandırmanıza olanak tanır.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notescommentslayoutingoptions/) sınıfı ile, sonuç görüntüde notların ve yorumların istediğiniz konumunu belirtebilirsiniz.

Bu kod, not ve yorum içeren bir slaytı nasıl dönüştüreceğinizi gösterir:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Bir sunum dosyası yükle.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Notların konumunu ayarla.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Yorumların konumunu ayarla.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Yorum alanının genişliğini ayarla.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // Yorum alanının rengini ayarla.

    // Rendering seçeneklerini oluştur.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Sunumun ilk slaytını görüntüye dönüştür.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Görüntüyü GIF biçiminde kaydet.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Herhangi bir slayt‑görüntü dönüşüm sürecinde, [setNotesPosition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) metodu `BottomFull` konumunu (notların konumunu belirlemek için) uygulayamaz; çünkü not metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.
{{% /alert %}} 

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştür**

[ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) arayüzü, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenizi sağlayarak oluşan TIFF görüntüsü üzerinde daha fazla kontrol sunar.

Bu kod, TIFF seçeneklerinin 300 DPI çözünürlükte ve 2160 × 2800 boyutunda siyah‑beyaz bir görüntü üretmek için nasıl kullanıldığını gösterir:

```java 
// Bir sunum dosyası yükle.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Sunumdan ilk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Çıktı TIFF görüntüsünün ayarlarını yapılandır.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // Görüntü boyutunu ayarla.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Piksel biçimini ayarla (siyah beyaz).
    tiffOptions.setDpiX(300);                                        // Yatay çözünürlüğü ayarla.
    tiffOptions.setDpiY(300);                                        // Dikey çözünürlüğü ayarla.

    // Slaytı belirtilen seçeneklerle görüntüye dönüştür.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Görüntüyü TIFF formatında kaydet.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
TIFF desteği JDK 9'dan önceki sürümlerde garanti edilmez.
{{% /alert %}} 

## **Tüm Slaytları Görüntülere Dönüştür**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenizi sağlar; böylece tüm sunumu bir dizi görüntüye çevirir.

Bu örnek kod, Java'da bir sunumdaki tüm slaytları görüntülere nasıl dönüştüreceğinizi gösterir:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumu slayt slayt görüntülere dönüştür.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Gizli slaytları kontrol et (gizli slaytları renderlama).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Slaytı bir görüntüye dönüştür.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Görüntüyü JPEG formatında kaydet.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
} 
```

## **Renkli Emoji Renderlama**

{{% alert title="Note" color="warning" %}} 
Sunum slaytlarını görüntülere dönüştürürken renkli emojileri doğru renderlamak için, sunumda kullanılan emoji fontlarının dönüşümü yapan sistemde yüklü ve kullanılabilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** fontunu kullanıyorsa ve bu font eksikse, emojiler çıktı görüntülerinde tek renkli (monokrom) görünebilir.
{{% /alert %}} 

## **SSS**

**Aspose.Slides animasyonlu slaytların renderlanmasını destekliyor mu?**  
Hayır, `getImage` metodu sadece slaytın statik bir görüntüsünü kaydeder, animasyonları içermez.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**  
Evet, gizli slaytlar normal slaytlar gibi işlenebilir. İşlem döngüsünde dahil olduklarından emin olun.

**Görüntüler gölgeler ve efektlerle kaydedilebilir mi?**  
Evet, Aspose.Slides slaytları görüntü olarak kaydederken gölgeler, şeffaflık ve diğer grafik efektlerinin renderlanmasını destekler.
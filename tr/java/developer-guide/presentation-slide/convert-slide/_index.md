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
- slayttan PNG'ye
- slayttan JPEG'e
- slayttan bitmap'e
- slayttan TIFF'e
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PPT, PPTX ve ODP slaytlarını görüntülere dönüştür—hızlı, yüksek kaliteli renderleme ve net kod örnekleri."
---
## **Giriş**

Aspose.Slides for Java, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğerleri dahil olmak üzere çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. İstediğiniz dönüşüm ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları aşağıdakileri kullanarak seçin:
    - [ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) arayüzü, veya
    - [IRenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/irenderingoptions/) arayüzü.
2. Slayt görüntüsünü, [getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) metodunu çağırarak oluşturun.

Aspose.Slides for Java'da, bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) arayüzü, piksel verileriyle tanımlanan görüntülerle çalışmanıza olanak tanır. Bu arayüzü, görüntüleri geniş bir format yelpazesinde (BMP, JPG, PNG, vb.) kaydetmek için kullanabilirsiniz.

## **Slaytları Bitmape Dönüştür ve Görüntüleri PNG Olarak Kaydet**

Bir slaytı bitmap nesnesine dönüştürüp uygulamanızda doğrudan kullanabilirsiniz. Alternatif olarak, bir slaytı bitmap'e dönüştürüp ardından JPEG veya tercih ettiğiniz başka bir formatta kaydedebilirsiniz.

Bu kod, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp ardından PNG formatında kaydetmeyi gösterir:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı bitmap'e dönüştür.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Görüntüyü PNG formatında kaydet.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Özel Boyutlarla Slaytları Görüntülere Dönüştür**

Belirli bir boyutta bir görüntü almanız gerekebilir. [getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) metodunun bir aşırı yüklemesini kullanarak bir slaytı belirli genişlik ve yükseklik değerlerine sahip bir görüntüye dönüştürebilirsiniz.

Bu örnek kod, bunu nasıl yapacağınızı gösterir:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı belirtilen boyutla bitmap'e dönüştür.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Görüntüyü JPEG formatında kaydet.
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

Aspose.Slides, sunum slaytlarının görüntülere render edilmesini kontrol etmenizi sağlayan iki arayüz—[ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) ve [IRenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/irenderingoptions/)—sunar. Her iki arayüz de `setSlidesLayoutOptions` metodunu içerir; bu metod, bir slaytı görüntüye dönüştürürken not ve yorumların render edilmesini yapılandırmanıza olanak tanır.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notescommentslayoutingoptions/) sınıfı ile elde edilen görüntüde not ve yorumların konumunu istediğiniz gibi belirtebilirsiniz.

Bu kod, not ve yorum içeren bir slaytı nasıl dönüştüreceğinizi gösterir:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Notların konumunu ayarla.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Yorumların konumunu ayarla.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Yorum alanının genişliğini ayarla.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // Yorum alanının rengini ayarla.

    // Render seçeneklerini oluştur.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Sunumun ilk slaytını görüntüye dönüştür.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Görüntüyü GIF formatında kaydet.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Herhangi bir slayt‑görüntü dönüşüm sürecinde, [setNotesPosition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) yöntemi `BottomFull` konumunu uygulayamaz; çünkü not metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir. 
{{% /alert %}} 

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştür**

[ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) arayüzü, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenize izin vererek oluşturulan TIFF görüntüsü üzerinde daha fazla kontrol sağlar.

Bu kod, TIFF seçeneklerinin 300 DPI çözünürlükte ve 2160 × 2800 boyutunda siyah‑beyaz bir görüntü çıkarmak için nasıl kullanılacağını gösterir:

```java 
// Bir sunum dosyası yükle.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Sunumdan ilk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Çıktı TIFF görüntüsünün ayarlarını yapılandır.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // Görüntü boyutunu ayarla.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Piksel formatını ayarla (siyah ve beyaz).
    tiffOptions.setDpiX(300);                                        // Yatay çözünürlüğü ayarla.
    tiffOptions.setDpiY(300);                                        // Dikey çözünürlüğü ayarla.

    // Belirtilen seçeneklerle slaytı görüntüye dönüştür.
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
TIFF desteği JDK 9’dan önceki sürümlerde garanti edilmez. 
{{% /alert %}} 

## **Tüm Slaytları Görüntülere Dönüştür**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürerek bütün sunumu bir dizi görüntüye çevirebilmenizi sağlar.

Bu örnek kod, bir sunumdaki tüm slaytları Java’da görüntülere dönüştürmeyi gösterir:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumu slayt bazında görüntülere render et.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Gizli slaytları kontrol et (gizli slaytları render etme).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Slaytı görüntüye dönüştür.
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

## **SSS**

**Aspose.Slides animasyonlu slaytların render edilmesini destekliyor mu?**  
Hayır, `getImage` yöntemi slaytı yalnızca statik bir görüntü olarak kaydeder; animasyonlar dahil edilmez.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**  
Evet, gizli slaytlar normal slaytlar gibi işlenebilir. İşlem döngüsüne dahil olduklarından emin olun.

**Görüntüler gölgeler ve efektlerle kaydedilebilir mi?**  
Evet, Aspose.Slides, slaytları görüntülere kaydederken gölgeler, şeffaflık ve diğer grafik efektlerini render etmeyi destekler.
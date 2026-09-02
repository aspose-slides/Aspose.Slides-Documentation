---
title: Android'de Sunum Slaytlarını Görüntülere Dönüştürme
linktitle: Slayttan Görüntüye
type: docs
weight: 35
url: /tr/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak PPT, PPTX ve ODP slaytlarını görüntülere dönüştürün—hızlı, yüksek kaliteli renderleme ve net Java kod örnekleri."
---
## **Giriş**

Aspose.Slides for Android via Java, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğer çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için şu adımları izleyin:

1. İstenilen dönüşüm ayarlarını tanımlayın ve dışa aktarılacak slaytları seçin:
    - [ITiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiffoptions/) arayüzünü veya
    - [IRenderingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/irenderingoptions/) arayüzünü kullanarak.
2. [getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage--) metodunu çağırarak slayt görüntüsünü oluşturun.

Aspose.Slides for Android via Java'da, [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) piksel verileriyle tanımlanan görüntülerle çalışmanıza olanak tanıyan bir arayüzdür. Bu arayüzü, görüntüleri geniş bir format yelpazesinde (BMP, JPG, PNG vb.) kaydetmek için kullanabilirsiniz.

## **Slaytları Bitmape Dönüştürme ve PNG Olarak Kaydetme**

Bir slaytı bitmap nesnesine dönüştürüp doğrudan uygulamanızda kullanabilirsiniz. Alternatif olarak, slaytı bitmap’e dönüştürüp görüntüyü JPEG veya istediğiniz başka bir formatta kaydedebilirsiniz.

Aşağıdaki kod, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp PNG formatında kaydetmeyi gösterir:

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

## **Özel Boyutlarda Slaytları Görüntüye Dönüştürme**

Belirli bir boyutta görüntü almanız gerekebilir. [getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) metodunun bir aşırı yüklemesini kullanarak slaytı belirli genişlik ve yüksekliğe sahip bir görüntüye dönüştürebilirsiniz.

Bu örnek kod, bu işlemi nasıl yapacağınızı gösterir:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı belirtilen boyutta bir bitmap'e dönüştür.
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

## **Not ve Yorum İçeren Slaytları Görüntüye Dönüştürme**

Bazı slaytlar not ve yorum içerebilir.

Aspose.Slides, sunum slaytlarının görüntülere dönüştürülmesini kontrol etmenizi sağlayan iki arayüz sunar—[ITiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiffoptions/) ve [IRenderingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/irenderingoptions/)—. Her iki arayüz de bir slaytı görüntüye dönüştürürken not ve yorumların işlenmesini yapılandırmanızı sağlayan `setSlidesLayoutOptions` metodunu içerir.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) sınıfı ile elde edilen görüntüde not ve yorumların tercih ettiğiniz konumunu belirtebilirsiniz.

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
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Yorum alanının rengini ayarla.

    // Renderlama seçeneklerini oluştur.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Sunumun ilk slaytını bir görüntüye dönüştür.
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

{{% alert title="Not" color="warning" %}} 
Herhangi bir slayt‑görüntü dönüşüm sürecinde, [setNotesPosition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) metodu `BottomFull` (notların konumunu belirlemek için) uygulayamaz; çünkü not metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.
{{% /alert %}} 

## **TIFF Seçenekleriyle Slaytları Görüntüye Dönüştürme**

[ITiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiffoptions/) arayüzü, boyut, çözünürlük, renk paleti vb. parametreleri belirlemenize olanak tanıyarak elde edilen TIFF görüntüsü üzerinde daha fazla kontrol sağlar.

Bu kod, TIFF seçeneklerinin kullanıldığı ve 300 DPI çözünürlükte, 2160 × 2800 boyutlarında siyah‑beyaz bir görüntü üretilen dönüşüm sürecini gösterir:

```java 
// Bir sunum dosyası yükle.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Sunumdan ilk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Çıktı TIFF görüntüsünün ayarlarını yapılandır.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Görüntü boyutunu ayarla.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Piksel formatını ayarla (siyah beyaz).
    tiffOptions.setDpiX(300);                                        // Yatay çözünürlüğü ayarla.
    tiffOptions.setDpiY(300);                                        // Dikey çözünürlüğü ayarla.

    // Slaytı belirtilen seçeneklerle bir görüntüye dönüştür.
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

## **Tüm Slaytları Görüntüye Dönüştürme**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenize olanak tanır; böylece tüm sunum bir dizi görüntüye çevrilir.

Bu örnek kod, Java’da bir sunumdaki tüm slaytların nasıl görüntülere dönüştürüleceğini gösterir:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumu slayt slayt görüntülere renderla.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Gizli slaytları kontrol et (gizli slaytları renderleme).
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

## **Renkli Emoji İşleme**

{{% alert title="Not" color="warning" %}} 
Sunum slaytlarını görüntülere dönüştürürken renkli emojilerin doğru şekilde işlenebilmesi için, sunumda kullanılan emoji yazı tiplerinin dönüşümü yapan sistemde kurulu ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emojiler çıktı görüntülerinde tek renkli görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytların render edilmesini destekliyor mu?**

Hayır, `getImage` metodu yalnızca slaytın statik bir görüntüsünü kaydeder, animasyonları içermez.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet, gizli slaytlar da normal slaytlar gibi işlenebilir. Sadece işleme döngüsünde yer aldıklarından emin olun.

**Görüntüler gölgeler ve efektlerle kaydedilebilir mi?**

Evet, Aspose.Slides, slaytları görüntü olarak kaydederken gölgeler, saydamlık ve diğer grafik efektlerinin render edilmesini destekler.
---
title: Android'de Sunum Slaytlarını Görsellere Dönüştürme
linktitle: Slayttan Görsele
type: docs
weight: 35
url: /tr/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak PPT, PPTX ve ODP slaytlarını görüntülere dönüştürün—hızlı, yüksek kaliteli renderleme ve anlaşılır Java kod örnekleri."
---
## **Giriş**

Aspose.Slides for Android via Java, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğer çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için şu adımları izleyin:

1. Dönüştürme ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları şu arabirimleri kullanarak seçin:
    - The [ITiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiffoptions/) interface, or
    - The [IRenderingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/irenderingoptions/) interface.
2. Slayt görüntüsünü, [getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage--) yöntemini çağırarak oluşturun.

Aspose.Slides for Android via Java'da bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) arabirimi, piksel verileriyle tanımlanan görüntülerle çalışmanıza olanak tanır. Bu arabirimi, görüntüleri geniş bir format yelpazesinde (BMP, JPG, PNG vb.) kaydetmek için kullanabilirsiniz.

## **Slaytları Bitmap'e Dönüştürme ve PNG Olarak Kaydetme**

Bir slaytı bitmap nesnesine dönüştürüp uygulamanızda doğrudan kullanabilirsiniz. Alternatif olarak, slaytı bitmap'e dönüştürüp ardından JPEG veya tercih ettiğiniz başka bir formatta kaydedebilirsiniz.

Bu kod, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp ardından PNG formatında kaydetmeyi göstermektedir:

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

## **Özel Boyutlarda Slaytları Görüntülere Dönüştürme**

Belirli bir boyutta görüntü almanız gerekebilir. [getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) üzerindeki bir aşırı yükleme ile bir slaytı belirli boyutlarda (genişlik ve yükseklik) görüntüye dönüştürebilirsiniz. 

Bu örnek kod, bu işlemin nasıl yapılacağını göstermektedir:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı belirtilen boyutta bitmap'e dönüştür.
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

## **Notlar ve Yorumlar İçeren Slaytları Görüntülere Dönüştürme**

Bazı slaytlar not ve yorum içerebilir.

Aspose.Slides, sunum slaytlarının görüntülere dönüştürülmesini kontrol etmenizi sağlayan iki arabirim sunar—[ITiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiffoptions/) ve [IRenderingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/irenderingoptions/)—. Her iki arabirim de `setSlidesLayoutOptions` yöntemini içerir; bu yöntem, bir slaytı görüntüye dönüştürürken not ve yorumların renderlanmasını yapılandırmanıza olanak tanır.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) sınıfı ile sonuç görüntüsünde not ve yorumların istediğiniz konumunu belirtebilirsiniz.

Bu kod, not ve yorum içeren bir slaytı dönüştürmeyi göstermektedir:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Sunum dosyasını yükle.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Notların konumunu ayarla.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Yorumların konumunu ayarla.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Yorum alanının genişliğini ayarla.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Yorum alanının rengini ayarla.

    // Renderleme seçeneklerini oluştur.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Sunumdaki ilk slaytı görüntüye dönüştür.
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

Herhangi bir slayt‑görüntü dönüşüm sürecinde, [setNotesPosition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) yöntemi `BottomFull` (notların konumunu belirlemek için) uygulayamaz; çünkü bir notun metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.

{{% /alert %}} 

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştürme**

[ITiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiffoptions/) arabirimi, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenize izin vererek ortaya çıkan TIFF görüntüsü üzerinde daha fazla kontrol sağlar.

Bu kod, TIFF seçeneklerinin 300 DPI çözünürlükte ve 2160 × 2800 boyutunda siyah‑beyaz bir görüntü üretmek için kullanıldığı bir dönüşüm sürecini göstermektedir:

```java 
// Sunum dosyasını yükle.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Sunumdan ilk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Çıkış TIFF görüntüsünün ayarlarını yapılandır.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Görüntü boyutunu ayarla.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Piksel formatını ayarla (siyah beyaz).
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

## **Tüm Slaytları Görüntülere Dönüştürme**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenize olanak tanır; böylece tüm sunumu bir dizi görüntüye çevirebilirsiniz.

Bu örnek kod, bir sunumdaki tüm slaytları Java’da görüntülere dönüştürmeyi göstermektedir:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumu slayt bazında görüntülere renderla.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Gizli slaytları kontrol et (gizli slaytları renderlama).
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

**Aspose.Slides animasyonlu slaytları renderlamayı destekliyor mu?**

Hayır, `getImage` yöntemi slaytı yalnızca statik bir görüntü olarak kaydeder, animasyonları içermez.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet, gizli slaytlar da normal slaytlar gibi işlenebilir. Yalnızca işleme döngüsünde dahil olduklarından emin olun.

**Görüntüler gölgeler ve efektlerle kaydedilebilir mi?**

Evet, Aspose.Slides, slaytları görüntü olarak kaydederken gölgeler, şeffaflık ve diğer grafik efektlerini renderlamayı destekler.
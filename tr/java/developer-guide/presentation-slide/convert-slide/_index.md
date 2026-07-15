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
- slayt PNG
- slayt JPEG
- slayt bitmap
- slayt TIFF
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PPT, PPTX ve ODP slaytlarını görüntülere dönüştürün—hızlı, yüksek kaliteli işleme ve net kod örnekleri."
---
## **Giriş**

Aspose.Slides for Java, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğer çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. İstediğiniz dönüşüm ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları aşağıdakileri kullanarak seçin:
    - [ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) arayüzü, veya
    - [IRenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/irenderingoptions/) arayüzü.
2. Slayt görüntüsünü, [getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) yöntemini çağırarak oluşturun.

Aspose.Slides for Java'da, [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) piksellik veriyle tanımlanan görüntülerle çalışmanızı sağlayan bir arayüzdür. Bu arayüzü, görüntüleri geniş bir format yelpazesinde (BMP, JPG, PNG vb.) kaydetmek için kullanabilirsiniz.

## **Slaytları Bitmape Dönüştür ve Görüntüleri PNG Olarak Kaydet**

Bir slaytı bitmap nesnesine dönüştürüp uygulamanızda doğrudan kullanabilirsiniz. Alternatif olarak, bir slaytı bitmap olarak dönüştürüp ardından görüntüyü JPEG veya istediğiniz başka bir formatta kaydedebilirsiniz.

Bu kod, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp ardından görüntüyü PNG formatında kaydetmeyi gösterir:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı bir bitmap'e dönüştür.
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

## **Özel Boyutlarda Slaytları Görüntülere Dönüştür**

Belirli bir boyutta görüntü almanız gerekebilir. [getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) üzerine yüklemesinden yararlanarak bir slaytı belirli boyutlarda (genişlik ve yükseklik) bir görüntüye dönüştürebilirsiniz.

Bu örnek kod bunu nasıl yapacağınızı gösterir:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı belirtilen boyutla bir bitmap'e dönüştür.
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

Aspose.Slides, sunum slaytlarının görüntülere işlenmesini kontrol etmenizi sağlayan iki arayüz—[ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) ve [IRenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/irenderingoptions/)—sunar. Her iki arayüz de `setSlidesLayoutOptions` yöntemini içerir; bu yöntem, bir slaytı görüntüye dönüştürürken not ve yorumların işlenmesini yapılandırmanıza olanak tanır.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notescommentslayoutingoptions/) sınıfı ile sonuç görüntüde not ve yorumların istediğiniz konumunu belirtebilirsiniz.

Bu kod, not ve yorum içeren bir slaytı nasıl dönüştüreceğinizi gösterir:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Bir sunum dosyasını yükle.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Notların konumunu ayarla.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Yorumların konumunu ayarla.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Yorum alanının genişliğini ayarla.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // Yorum alanı için rengi ayarla.

    // İşleme seçeneklerini oluştur.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Sunumdaki ilk slaytı bir görüntüye dönüştür.
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

Herhangi bir slayt‑görüntü dönüştürme sürecinde, [setNotesPosition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) yöntemi `BottomFull` (notların konumunu belirlemek için) uygulanamaz çünkü bir notun metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.

{{% /alert %}} 

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştür**

[ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) arayüzü, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenize olanak tanıyarak ortaya çıkan TIFF görüntüsü üzerinde daha fazla kontrol sağlar.

Bu kod, TIFF seçeneklerinin 300 DPI çözünürlükte ve 2160 × 2800 boyutunda siyah‑beyaz bir görüntü oluşturmak için kullanıldığı bir dönüştürme sürecini gösterir:

```java 
// Bir sunum dosyasını yükle.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Sunumdan ilk slaytı al.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Çıktı TIFF görüntüsünün ayarlarını yapılandır.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // Görüntü boyutunu ayarla.
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

{{% alert title="Not" color="warning" %}} 

Tiff desteği, JDK 9’dan önceki sürümlerde garanti edilmez.

{{% /alert %}} 

## **Tüm Slaytları Görüntülere Dönüştür**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenize olanak tanır; böylece tüm sunumu bir dizi görüntüye dönüştürmüş olursunuz.

Bu örnek kod, bir sunumdaki tüm slaytları Java’da görüntülere nasıl dönüştüreceğinizi gösterir:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Sunumu slayt slayt görüntülere render et.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Gizli slaytları kontrol et (gizli slaytları render etme).
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
Sunum slaytlarını görüntülere dönüştürürken renkli emojileri doğru şekilde işlemek için, sunumda kullanılan emoji yazı tiplerinin, dönüştürmeyi yapan sistemde yüklü ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emojiler çıktı görüntülerinde tek renkli görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytların işlenmesini destekliyor mu?**

Hayır, `getImage` yöntemi yalnızca animasyon içermeyen statik bir slayt görüntüsü kaydeder.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet, gizli slaytlar normal slaytlar gibi işlenebilir. Yalnızca işleme döngüsünde yer aldıklarından emin olun.

**Görüntüler gölgeler ve efektlerle kaydedilebilir mi?**

Evet, Aspose.Slides slaytları görüntü olarak kaydederken gölgeler, saydamlık ve diğer grafik efektlerinin işlenmesini destekler.
---
title: JavaScript'te Sunum Slaytlarını Görüntülere Dönüştür
linktitle: Slayttan Görüntüye
type: docs
weight: 35
url: /tr/nodejs-java/convert-slide/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak JavaScript'te PPT, PPTX ve ODP slaytlarını görüntülere dönüştürün — hızlı, yüksek kaliteli renderlama ve net kod örnekleri."
---
## **Giriş**

Aspose.Slides for Node.js via Java, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğer birçok görüntü formatına kolaylıkla dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. İstediğiniz dönüşüm ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları aşağıdakileri kullanarak seçin:
    - [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfını,
    - [RenderingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/) sınıfını.
2. Kaydırma görüntüsünü oluşturmak için [getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage) metodunu çağırın.

Aspose.Slides for Node.js via Java'da, bir [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) sınıfı piksel verileriyle tanımlanan görüntülerle çalışmanıza olanak tanır. Bu sınıfı görüntüleri geniş bir format yelpazesinde (BMP, JPG, PNG, vb.) kaydetmek için kullanabilirsiniz.

## **Slaytları Bitmape Dönüştür ve PNG Olarak Kaydet**

Bir slaytı bitmap nesnesine dönüştürüp uygulamanızda doğrudan kullanabilirsiniz. Alternatif olarak, slaytı bitmap olarak dönüştürüp ardından görüntüyü JPEG ya da istediğiniz başka bir formatta kaydedebilirsiniz.

Bu JavaScript kodu, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp ardından PNG formatında kaydetmeyi gösterir:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı bitmap'e dönüştür.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Görüntüyü PNG formatında kaydet.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Özel Boyutlarda Slaytları Görüntülere Dönüştür**

Belirli bir boyutta görüntü almanız gerekebilir. [getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage) metodunun bir aşırı yüklemesini kullanarak, bir slaytı belirli boyutlarda (genişlik ve yükseklik) bir görüntüye dönüştürebilirsiniz. 

Bu örnek kod bunu nasıl yapacağınızı gösterir:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Belirtilen boyutla sunumdaki ilk slaytı bitmap'e dönüştür.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Görüntüyü JPEG formatında kaydet.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Notlar ve Yorumlarla Slaytları Görüntülere Dönüştür**

Bazı slaytlarda notlar ve yorumlar bulunabilir.

Aspose.Slides, sunum slaytlarının görüntülere dönüştürülmesini kontrol etmenizi sağlayan iki sınıf—[TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) ve [RenderingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/)—sunar. Her iki sınıf da `setSlidesLayoutOptions` metodunu içerir; bu metod, bir slaytı görüntüye dönüştürürken not ve yorumların nasıl render edileceğini yapılandırmanıza olanak tanır.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) sınıfı ile, sonuç görüntüde not ve yorumların istediğiniz konumunu belirtebilirsiniz.

Bu JavaScript kodu, not ve yorum içeren bir slaytı nasıl dönüştüreceğinizi gösterir:

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Notların konumunu ayarla.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Yorumların konumunu ayarla.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Yorum alanının genişliğini ayarla.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Yorum alanının rengini ayarla.

    // Renderleme seçeneklerini oluştur.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Sunumdaki ilk slaytı bir görüntüye dönüştür.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Görüntüyü GIF formatında kaydet.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Herhangi bir slayt‑görüntü dönüştürme işleminde, [setNotesPosition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metodu `BottomFull` (notların konumunu belirlemek için) uygulayamaz çünkü bir notun metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.
{{% /alert %}} 

## **TIFF Seçenekleri Kullanarak Slaytları Görüntülere Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfı, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenize olanak tanıyarak ortaya çıkan TIFF görüntüsü üzerinde daha fazla kontrol sağlar.

Bu JavaScript kodu, TIFF seçeneklerinin 300 DPI çözünürlük ve 2160 × 2800 boyutunda siyah‑beyaz bir görüntü oluşturmak için kullanıldığı bir dönüştürme sürecini gösterir:

```js
// Sunum dosyasını yükle.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Sunumdan ilk slaytı al.
    let slide = presentation.getSlides().get_Item(0);

    // Çıktı TIFF görüntüsünün ayarlarını yapılandır.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Görüntü boyutunu ayarla.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Piksel formatını ayarla (siyah beyaz).
    tiffOptions.setDpiX(300);                                                          // Yatay çözünürlüğü ayarla.
    tiffOptions.setDpiY(300);                                                          // Dikey çözünürlüğü ayarla.

    // Belirtilen seçeneklerle slaytı görüntüye dönüştür.
    let image = slide.getImage(tiffOptions);
    try {
        // Görüntüyü TIFF formatında kaydet.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Tiff desteği JDK 9'dan önceki sürümlerde garanti edilmez.
{{% /alert %}} 

## **Tüm Slaytları Görüntülere Dönüştür**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenizi sağlar; böylece tüm sunumu bir dizi görüntüye çevirmiş olursunuz.

Bu örnek kod, bir sunumdaki tüm slaytları JavaScript'te görüntülere nasıl dönüştüreceğinizi gösterir:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Sunumu slayt slayt görüntülere dönüştür.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Gizli slaytları kontrol et (gizli slaytları renderlama).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Slaytı bir görüntüye dönüştür.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Görüntüyü JPEG formatında kaydet.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Renkli Emoji Renderleme**

{{% alert title="Note" color="warning" %}} 
Sunum slaytlarını görüntülere dönüştürürken renkli emojileri doğru şekilde renderlamak için, sunumda kullanılan emoji fontlarının dönüşümü yapan sistemde yüklü ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** fontunu kullanıyorsa ve bu font eksikse, çıktıda emojiler tek renkli (monokrom) görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytların renderlanmasını destekliyor mu?**  
Hayır, `getImage` metodu slaytı yalnızca statik bir görüntü olarak kaydeder; animasyonları içermez.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**  
Evet, gizli slaytlar da normal slaytlar gibi işlenebilir. İşleme döngüsüne dahil olduklarından emin olun.

**Görüntüler gölgeler ve efektlerle kaydedilebilir mi?**  
Evet, Aspose.Slides, slaytları görüntü olarak kaydederken gölgeler, saydamlık ve diğer grafik efektlerinin renderlanmasını destekler.
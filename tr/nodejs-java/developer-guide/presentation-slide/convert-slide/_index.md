---
title: Sunum Slaytlarını JavaScript'te Görüntülere Dönüştür
linktitle: Slayttan Görüntüye
type: docs
weight: 35
url: /tr/nodejs-java/convert-slide/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak JavaScript'te PPT, PPTX ve ODP slaytlarını görüntülere dönüştürün — hızlı, yüksek kaliteli renderlama ve net kod örnekleri."
---
## **Giriş**

Aspose.Slides for Node.js via Java, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğer çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için şu adımları izleyin:

1. İstediğiniz dönüşüm ayarlarını tanımlayın ve dışa aktarmak istediğiniz slaytları aşağıdakileri kullanarak seçin:
    - [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfı, ya da
    - [RenderingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/) sınıfı.
2. Slayt görüntüsünü oluşturmak için [getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage) yöntemini çağırın.

Aspose.Slides for Node.js via Java'da, [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) sınıfı, piksel verileriyle tanımlanan görüntülerle çalışmanıza olanak sağlar. Bu sınıfı BMP, JPG, PNG vb. geniş bir format yelpazesinde görüntüleri kaydetmek için kullanabilirsiniz.

## **Slaytları Bitmape Dönüştür ve Görüntüleri PNG Olarak Kaydet**

Bir slaytı bitmap nesnesine dönüştürüp uygulamanızda doğrudan kullanabilirsiniz. Alternatif olarak, slaytı bitmap'e dönüştürüp ardından görüntüyü JPEG veya başka bir tercih edilen formatta kaydedebilirsiniz.

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

## **Slaytları Özel Boyutlarla Görüntülere Dönüştür**

Belirli bir boyutta görüntü almanız gerekebilir. [getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage) metodunun bir aşırı yüklemesini kullanarak, bir slaytı belirli boyutlarda (genişlik ve yükseklik) bir görüntüye dönüştürebilirsiniz.

Bu örnek kod bunu nasıl yapacağınızı gösterir:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı belirtilen boyutta bitmap'e dönüştür.
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

## **Notlar ve Yorumlar İçeren Slaytları Görüntülere Dönüştür**

Bazı slaytlarda notlar ve yorumlar bulunabilir.

Aspose.Slides, sunum slaytlarının görüntülere render edilmesini kontrol etmenizi sağlayan iki sınıf—[TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) ve [RenderingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/)—sağlar. Her iki sınıf da `setSlidesLayoutOptions` metodunu içerir; bu metot, bir slaytı görüntüye dönüştürürken notların ve yorumların render edilmesini yapılandırmanıza olanak tanır.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) sınıfı ile, ortaya çıkan görüntüde notlar ve yorumlar için tercih ettiğiniz konumu belirleyebilirsiniz.

Bu JavaScript kodu, notlar ve yorumlar içeren bir slaytı nasıl dönüştüreceğinizi gösterir:

```js
const scaleX = 2;
const scaleY = scaleX;

// Bir sunum dosyası yükle.
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
 
    // Sunumun ilk slaytını görüntüye dönüştür.
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
Herhangi bir slayt‑görüntü dönüştürme işleminde, [setNotesPosition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) yöntemi `BottomFull` konumunu (notların konumunu belirtmek için) uygulamaz; çünkü not metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.
{{% /alert %}} 

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfı, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenize izin vererek ortaya çıkan TIFF görüntüsü üzerinde daha fazla kontrol sağlar.

Bu JavaScript kodu, TIFF seçeneklerinin 300 DPI çözünürlükte ve 2160 × 2800 boyutunda siyah‑beyaz bir görüntü üretmek için kullanıldığı bir dönüştürme sürecini gösterir:

```js
// Bir sunum dosyası yükle.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Sunumdan ilk slaytı al.
    let slide = presentation.getSlides().get_Item(0);

    // Çıktı TIFF görüntüsünün ayarlarını yapılandır.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Görüntü boyutunu ayarla.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Piksel formatını ayarla (siyah ve beyaz).
    tiffOptions.setDpiX(300);                                                          // Yatay çözünürlüğü ayarla.
    tiffOptions.setDpiY(300);                                                          // Dikey çözünürlüğü ayarla.

    // Slaytı belirtilen seçeneklerle görüntüye dönüştür.
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
Tiff desteği JDK 9 öncesi sürümlerde garanti edilmez.
{{% /alert %}} 

## **Tüm Slaytları Görüntülere Dönüştür**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenizi sağlar; böylece tüm sunumu bir dizi görüntüye dönüştürmüş olursunuz.

Bu örnek kod, bir sunumdaki tüm slaytları JavaScript ile görüntülere dönüştürmeyi gösterir:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Sunumu slayt slayt görüntülere render et.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Gizli slaytları kontrol et (gizli slaytları render etme).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Slaytı görüntüye dönüştür.
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

## **FAQ**

**Aspose.Slides animasyonlu slaytları render etmeyi destekliyor mu?**

Hayır, `getImage` yöntemi slaytı yalnızca statik bir görüntü olarak kaydeder, animasyon içermeden.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet, gizli slaytlar da normal slaytlar gibi işlenebilir. İşlem döngüsünde yer aldıklarından emin olun.

**Görseller gölgeler ve efektlerle kaydedilebilir mi?**

Evet, Aspose.Slides, slaytları görüntü olarak kaydederken gölgeler, şeffaflık ve diğer grafik efektlerinin render edilmesini destekler.
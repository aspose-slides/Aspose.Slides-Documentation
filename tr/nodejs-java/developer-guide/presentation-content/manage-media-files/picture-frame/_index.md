---
title: JavaScript Kullanarak Sunumlarda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/nodejs-java/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- görüntü ekle
- görüntü oluştur
- görüntü çıkar
- raster görüntü
- vektör görüntü
- görüntüyü kırp
- kırpılmış alan
- StretchOff özelliği
- resim çerçevesi biçimlendirme
- resim çerçevesi özellikleri
- göreli ölçek
- görüntü efekti
- en boy oranı
- görüntü şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı kolaylaştırın ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Resim çerçevesi, bir resmi içeren bir şekildir—çerçeve içindeki bir resim gibidir.

Bir resmi slayta bir resim çerçevesi aracılığıyla ekleyebilirsiniz. Bu şekilde, resmi resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.

{{% alert  title="Tip" color="primary" %}} 

Aspose ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlayarak insanların görüntülerden hızlıca sunumlar oluşturmasını sağlar. 

{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Presentation sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını dizini üzerinden alın. 
3. Şekli doldurmak için kullanılacak, sunum nesnesine bağlı [ImagesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ImageCollection)'a bir resim ekleyerek bir `PPImage` nesnesi oluşturun.
4. Resmin genişliğini ve yüksekliğini belirtin.
5. Referans verilen slayta bağlı şekil nesnesi tarafından sunulan `addPictureFrame` yöntemiyle, resmin genişliği ve yüksekliğine dayalı bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFrame) oluşturun.
6. Slayta bir resim çerçevesi (resmi içeren) ekleyin.
7. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Bu JavaScript kodu, bir resim çerçevesi oluşturmayı gösterir:

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alır
    var sld = pres.getSlides().get_Item(0);
    // Image sınıfını örnekler
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Resmin eşdeğer yüksekliği ve genişliği ile bir resim çerçevesi ekler
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // PPTX dosyasını diske yazar
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Resim çerçeveleri, görüntülere dayalı sunum slaytlarını hızlıca oluşturmanıza olanak tanır. Resim çerçevesini Aspose.Slides'ın kaydetme seçenekleriyle birleştirdiğinizde, görüntüleri bir formatından diğerine dönüştürmek için giriş/çıkış işlemlerini yönetebilirsiniz.

## **Göreli Ölçekli Resim Çerçevesi Oluşturma**

Bir görüntünün göreli ölçeklemesini değiştirerek daha karmaşık bir resim çerçevesi oluşturabilirsiniz. 

1. Presentation sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını dizini üzerinden alın. 
3. Sunumun resim koleksiyonuna bir resim ekleyin.
4. Şekli doldurmak için kullanılacak, sunum nesnesine bağlı [ImagesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ImageCollection)'a bir resim ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PPImage) nesnesi oluşturun.
5. Resmin göreli genişliğini ve yüksekliğini resim çerçevesinde belirtin.
6. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Bu JavaScript kodu, göreli ölçekli bir resim çerçevesi oluşturmayı gösterir:

```javascript
// PPTX'i temsil eden Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı al
    var sld = pres.getSlides().get_Item(0);
    // Image sınıfını örnekle
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Resmin eşdeğer yüksekliği ve genişliğiyle Resim Çerçevesi ekle
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Göreli ölçek genişliği ve yüksekliğini ayarlama
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // PPTX dosyasını diske yaz
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Resim Çerçevelerinden Raster Görüntüleri Çıkarma**

Resim çerçevelerinden raster görüntüleri çıkarabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, "sample.pptx" belgesinden bir görüntüyü çıkarıp PNG formatında kaydetmeyi göstermektedir.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **Resim Çerçevelerinden SVG Görüntüleri Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) şekilleri içinde yerleştirilmiş SVG grafikleri içerdiğinde, Aspose.Slides for Node.js via Java, orijinal vektör görüntülerini tam doğrulukla almanıza olanak tanır. Slaytın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/)'i tanımlayabilir, altındaki [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) SVG içeriği tutuyor mu kontrol edebilir ve ardından bu görüntüyü diske veya bir akışa yerel SVG formatında kaydedebilirsiniz.

Aşağıdaki kod örneği, bir resim çerçevesinden bir SVG görüntüsü çıkarmayı göstermektedir:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **Görüntünün Şeffaflığını Almak**

Aspose.Slides, bir görüntüye uygulanan şeffaflık etkisini almanıza izin verir. Bu JavaScript kodu işlemi gösterir:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **Görüntünün Parlaklık ve Kontrastını Almak**

Aspose.Slides, bir görüntüye uygulanan parlaklık ve kontrast etkisini almanıza izin verir. [Luminance](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/luminance/) sınıfı bu görüntü dönüşüm etkisini temsil eder.

Bu JavaScript kodu, bir resim çerçevesinden parlaklık ve kontrast ayarlarını almayı gösterir:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulanabilecek birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, bir resim çerçevesini belirli gereksinimlere uyması için değiştirebilirsiniz.

1. Presentation sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını dizini üzerinden alın. 
3. Şekli doldurmak için kullanılacak, sunum nesnesine bağlı [ImagesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ImageCollection)'a bir resim ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PPImage) nesnesi oluşturun.
4. Resmin genişliğini ve yüksekliğini belirtin.
5. Referans verilen slayta bağlı [Shapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) nesnesi tarafından sunulan [addPictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) yöntemiyle, resmin genişliği ve yüksekliğine dayalı bir `PictureFrame` oluşturun.
6. Resim çerçevesini (resmi içeren) slayta ekleyin.
7. Resim çerçevesinin kenar rengini ayarlayın.
8. Resim çerçevesinin kenar kalınlığını ayarlayın.
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.  
   * Pozitif bir değer resmi saat yönünde döndürür.  
   * Negatif bir değer resmi saat yönünün tersine döndürür.
10. Resim çerçevesini (resmi içeren) slayta ekleyin.
11. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Bu JavaScript kodu, resim çerçevesi biçimlendirme sürecini gösterir:

```javascript
// PPTX'i temsil eden Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alır
    var sld = pres.getSlides().get_Item(0);
    // Image sınıfını örnekler
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Resmin eşdeğer yüksekliği ve genişliğiyle Resim Çerçevesi ekler
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // PictureFrameEx'e bazı biçimlendirmeler uygular
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // PPTX dosyasını diske yazar
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose yakın zamanda ücretsiz bir [Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG ([birleştirme](https://products.aspose.app/slides/tr/collage/jpg)) veya PNG görüntüleri birleştirmeniz, fotoğraflardan ızgara oluşturmanız gerektiğinde bu hizmeti kullanabilirsiniz. 

{{% /alert %}}

## **Görüntüyü Bağlantı Olarak Ekle**

Sunum boyutlarını büyük tutmamak için dosyaları doğrudan sunuma gömmek yerine görüntüleri (veya videoları) bağlantılar aracılığıyla ekleyebilirsiniz. Bu JavaScript kodu, bir yer tutucu içine bir görüntü ve video eklemeyi gösterir:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Görüntüyü Kırpma**

Bu JavaScript kodu, bir slayttaki mevcut bir görüntüyü nasıl kırpacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
// Yeni bir görüntü nesnesi oluşturur
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Bir slayta PictureFrame ekler
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Görüntüyü kırpar (yüzde değerleri)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Sonucu kaydeder
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Resmin Kırpılan Alanlarını Sil**

Bir çerçevede bulunan görüntünün kırpılan alanlarını silmek istiyorsanız, [deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) yöntemini kullanabilirsiniz. Bu yöntem, kırpma gereksizse orijinal görüntüyü, aksi takdirde kırpılmış görüntüyü döndürür.

Bu JavaScript kodu işlemi gösterir:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // İlk slayttan PictureFrame'i alır
    var picFrame = slide.getShapes().get_Item(0);
    // PictureFrame görüntüsünün kırpılmış alanlarını siler ve kırpılmış görüntüyü döndürür
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Sonucu kaydeder
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

The [deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) method adds the cropped image to the presentation image collection. If the image is only used in the processed [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/), this setup can reduce the presentation size. Otherwise, the number of images in the resulting presentation will increase.

This method converts WMF/EMF metafiles to raster PNG image in the cropping operation. 

{{% /alert %}}

## **Görüntüleri Sıkıştırma**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) yöntemiyle bir sunumdaki resmi sıkıştırabilirsiniz. Bu yöntem, şekil boyutuna ve belirtilen çözünürlüğe göre resmi küçülterek, kırpılmış alanları silme seçeneğiyle birlikte çalışır.

Resmin boyut ve çözünürlüğünü PowerPoint'ın **Picture Format → Compress Pictures → Resolution** özelliğine benzer şekilde ayarlar.

Aşağıdaki JavaScript örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki görüntüyü nasıl sıkıştıracağınızı gösterir:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Görüntüyü 150 DPI (Web çözünürlüğü) hedef çözünürlüğüyle sıkıştırır ve kırpılmış alanları kaldırır.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Sıkıştırma sonucunu kontrol eder.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Veya başka bir önceden tanımlanmış DPI değeri kullanarak:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Görüntüyü 96 DPI (e-posta çözünürlüğü) sıkıştırır, kırpılmış alanları kaldırır.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

The method converts the image to a lower resolution based on the shape's size and provided DPI. Cropped regions can also be deleted to optimize file size.
If the image is a metafile (WMF/EMF) or SVG, compression will not be applied. Also, JPEG quality is preserved or slightly reduced based on resolution, similarly to how PowerPoint handles high-resolution JPEGs.

{{% /alert %}}

## **En Boy Oranını Kilitle**

Bir şeklin içinde bulunan görüntünün boyutları değiştirildiğinde bile en boy oranının korunmasını istiyorsanız, *Lock Aspect Ratio* ayarını belirlemek için [setAspectRatioLocked](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) yöntemini kullanabilirsiniz.

Bu JavaScript kodu, bir şeklin en boy oranını nasıl kilitleyeceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // yeniden boyutlandırmada en boy oranını korumak için şekli ayarla
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

This *Lock Aspect Ratio* setting preserves only the aspect ratio of the shape and not the image it contains.

{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[PictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFillFormat) sınıfındaki [setStretchOffsetLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) ve [setStretchOffsetBottom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) yöntemlerini kullanarak bir doldurma dikdörtgeni belirleyebilirsiniz.

Bir görüntü için germe belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarından bir yüzde ofsetiyle tanımlanır. Pozitif yüzde içeriği, negatif yüzde dışarıyı belirtir.

1. Presentation sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını dizini üzerinden alın.
3. Bir `AutoShape` dikdörtgeni ekleyin. 
4. Bir resim oluşturun.
5. Şeklin dolgu türünü ayarlayın.
6. Şeklin resim dolgu modunu ayarlayın.
7. Şekli doldurmak için bir görüntü ayarlayın.
8. Görüntünün ofsetlerini, şeklin sınırlayıcı kutusunun ilgili kenarına göre belirtin.
9. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Bu JavaScript kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alır
    var slide = pres.getSlides().get_Item(0);
    // ImageEx sınıfını örnekler
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Dikdörtgen olarak ayarlanmış bir AutoShape ekler
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Şeklin dolgu tipini ayarlar
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Şeklin resim dolgu modunu ayarlar
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Şekli dolduracak görüntüyü ayarlar
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Görüntünün ofsetlerini şeklin sınırlayıcı kutusunun ilgili kenarına göre belirtir
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // PPTX dosyasını diske yazar
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Resim Çerçevesi için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) üzerine atanan görüntü nesnesi aracılığıyla raster görüntüleri (PNG, JPEG, BMP, GIF vb.) ve vektör görüntüleri (örneğin SVG) destekler. Desteklenen formatların listesi genel olarak slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.

**Yüzlerce büyük görüntü eklemek PPTX dosya boyutu ve performansı üzerinde nasıl bir etki yapar?**

Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntülere bağlantı vermek sunum boyutunu düşük tutar ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı yoluyla ekleme imkanı sunar.

**Bir görüntü nesnesinin yanlışlıkla taşınmasını/ölçeklenmesini nasıl kilitleyebilirim?**

Bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) için [shape locks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) (örneğin taşımayı veya yeniden boyutlandırmayı devre dışı bırakma) kullanın. Kilitleme mekanizması, [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) dahil çeşitli şekil tipleri için desteklenir.

**SVG vektör doğruluğu bir sunumu PDF/görüntülere dışa aktarırken korunur mu?**

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) üzerinden SVG'yi orijinal vektör olarak çıkarmanıza izin verir. PDF'ye [/slides/tr/nodejs-java/convert-powerpoint-to-pdf/] veya raster formatlara [/slides/tr/nodejs-java/convert-powerpoint-to-png/] dışa aktarırken, sonuç dışa aktarma ayarlarına bağlı olarak rasterleştirilebilir; ancak orijinal SVG'nin vektör olarak saklandığı çıkarma davranışıyla doğrulanır.
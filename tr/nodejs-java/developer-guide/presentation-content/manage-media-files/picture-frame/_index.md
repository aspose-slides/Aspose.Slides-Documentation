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
- göreceli ölçek
- görüntü etkisi
- en boy oranı
- görüntü şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı basitleştirin ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Bir resim çerçevesi, bir görüntüyü içeren bir şekildir—çerçeve içinde bir resim gibidir.  

Bir slayta bir resmi resim çerçevesi aracılığıyla ekleyebilirsiniz. Bu sayede, resmi resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.

{{% alert  title="Tip" color="primary" %}} 
Aspose, kullanıcıların görüntülerden hızlıca sunumlar oluşturmasını sağlayan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 
{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Sunum nesnesiyle ilişkili [ImagesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ImageCollection) içine bir görüntü ekleyerek bir `PPImage` nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
4. Görüntünün genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slaytla ilişkili şekil nesnesinin `addPictureFrame` yöntemi aracılığıyla görüntünün genişliği ve yüksekliği temelinde bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFrame) oluşturun.  
6. Resim çerçevesini (içindeki resmi) slayta ekleyin.  
7. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Bu JavaScript kodu, bir resim çerçevesi nasıl oluşturulacağını gösterir:

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alır
    var sld = pres.getSlides().get_Item(0);
    // Image sınıfını örnekler
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Resmin eşdeğer yüksekliği ve genişliğiyle bir resim çerçevesi ekler
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

Resim çerçeveleri, görüntülerden hızlıca sunum slaytları oluşturmanıza olanak tanır. Resim çerçevesini Aspose.Slides kaydetme seçenekleriyle birleştirerek, görüntüleri bir formattan diğerine dönüştürmek için giriş/çıkış işlemlerini yönetebilirsiniz.

## **Göreceli Ölçekle Resim Çerçevesi Oluşturma**

Bir görüntünün göreceli ölçeğini değiştirerek daha karmaşık bir resim çerçevesi oluşturabilirsiniz.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Sunumun görüntü koleksiyonuna bir resim ekleyin.  
4. Sunum nesnesiyle ilişkili [ImagesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ImageCollection) içine bir görüntü ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PPImage) nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
5. Resim çerçevesinde görüntünün göreceli genişliğini ve yüksekliğini belirtin.  
6. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Bu JavaScript kodu, göreceli ölçekle bir resim çerçevesi nasıl oluşturulacağını gösterir:

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
    // Göreceli ölçek genişliği ve yüksekliği ayarlama
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

[PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFrame) nesnelerinden raster görüntüler çıkarabilir ve bunları PNG, JPG ve diğer biçimlerde kaydedebilirsiniz. Aşağıdaki kod örneği, “sample.pptx” belgesinden bir görüntüyü çıkarıp PNG biçiminde kaydetmeyi gösterir.

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

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) şekilleri içinde SVG grafikleri barındırıyorsa, Aspose.Slides for Node.js via Java, orijinal vektör görüntülerini tam doğrulukla almanıza olanak tanır. Slaydın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) nesnesini belirleyebilir, altındaki [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesnesinin SVG içeriği taşıyıp taşımadığını kontrol edebilir ve ardından bu görüntüyü yerel SVG biçiminde diske ya da akıma kaydedebilirsiniz.

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsü çıkarmayı gösterir:

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

## **Görüntünün Şeffaflığını Alma**

Aspose.Slides, bir görüntüye uygulanmış şeffaflık etkisini almanıza olanak tanır. Bu JavaScript kodu işlemi gösterir:

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

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulanabilecek birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, bir resim çerçevesini belirli gereksinimlere uygun şekilde değiştirebilirsiniz.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Sunum nesnesiyle ilişkili [ImagesCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ImageCollection) içine bir görüntü ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PPImage) nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
4. Görüntünün genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slaytla ilişkili [Shapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) nesnesinin [addPictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) yöntemiyle görüntünün genişliği ve yüksekliği temelinde bir `PictureFrame` oluşturun.  
6. Resim çerçevesini (içindeki resmi) slayta ekleyin.  
7. Resim çerçevesinin kenar rengini ayarlayın.  
8. Resim çerçevesinin kenar kalınlığını ayarlayın.  
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.  
   * Pozitif değer görüntüyü saat yönünde döndürür.  
   * Negatif değer görüntüyü saat yönünün tersine döndürür.  
10. Resim çerçevesini (içindeki resmi) slayta tekrar ekleyin.  
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
Aspose yeni bir [free Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG ([merge JPG/JPEG](https://products.aspose.app/slides/tr/collage/jpg)) veya PNG görüntülerini birleştirmeniz ([create grids from photos](https://products.aspose.app/slides/tr/collage/photo-grid)) gerekirse bu hizmeti kullanabilirsiniz. 
{{% /alert %}}

## **Görüntüyü Bağlantı Olarak Ekleme**

Sunum boyutlarını küçültmek için, dosyaları doğrudan gömmek yerine görüntüleri (veya videoları) bağlantılar aracılığıyla ekleyebilirsiniz. Bu JavaScript kodu, bir yer tutucuya görüntü ve video eklemeyi gösterir:

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
// Yeni görüntü nesnesi oluşturur
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

## **Resim Çerçevesindeki Kırpılmış Alanları Silme**

Bir çerçeve içinde bulunan görüntünün kırpılmış alanlarını silmek isterseniz, [deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) yöntemini kullanabilirsiniz. Bu yöntem, kırpılmış görüntüyü döndürür; kırpma gerekmezse orijinal görüntüyü döndürür.  

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
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) yöntemi, kırpılmış görüntüyü sunumun görüntü koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) içinde kullanılıyorsa, bu yapı sunum boyutunu azaltabilir; aksi takdirde sonuç sunumdaki görüntü sayısı artar.  

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafile'lerini raster PNG görüntüsüne dönüştürür. 
{{% /alert %}}

## **Görüntüleri Sıkıştırma**

Bir sunumda bulunan bir resmi, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) yöntemiyle sıkıştırabilirsiniz. Bu yöntem, şekil boyutu ve belirtilen çözünürlüğe göre görüntünün boyutunu küçülterek, isteğe bağlı olarak kırpılmış alanları silebilir.  

Bu, PowerPoint'in **Picture Format → Compress Pictures → Resolution** özelliğine benzer biçimde resmin boyutunu ve çözünürlüğünü ayarlar.  

Aşağıdaki JavaScript örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki görüntüyü nasıl sıkıştıracağınızı gösterir:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // 150 DPI (Web çözünürlüğü) hedef çözünürlüğüyle görüntüyü sıkıştırır ve kırpılmış alanları kaldırır.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Sıkıştırmanın sonucunu kontrol eder.
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

Veya başka bir önceden tanımlı DPI değeri kullanarak:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Görüntüyü 96 DPI'ye (e-posta çözünürlüğü) sıkıştırır, kırpılmış alanları kaldırır.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Yöntem, şeklin boyutuna ve sağlanan DPI değerine göre görüntüyü daha düşük bir çözünürlüğe dönüştürür. Kırpılmış bölgeler, dosya boyutunu iyileştirmek için silinebilir. Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca, JPEG kalitesi çözünürlüğe bağlı olarak korunur veya hafifçe azaltılır; bu davranış PowerPoint'in yüksek çözünürlüklü JPEG'leri işleyişine benzer. 
{{% /alert %}}

## **En Boy Oranını Kilitleme**

Bir şeklin içinde bulunan görüntünün boyutlarını değiştirdiğinizde bile en boy oranının korunmasını istiyorsanız, *Lock Aspect Ratio* ayarını yapılandırmak için [setAspectRatioLocked](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) yöntemini kullanabilirsiniz.  

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
    // yeniden boyutlandırıldığında en boy oranını korumasını ayarla
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en boy oranını korur; içinde bulunan görüntünün en boy oranını korumaz. 
{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[PictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFillFormat) sınıfındaki [setStretchOffsetLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) ve [setStretchOffsetBottom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) yöntemlerini kullanarak bir doldurma dikdörtgeni belirtebilirsiniz.  

Bir görüntü için germe (stretch) belirtildiğinde, kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarına yüzde olarak göreceli bir offset ile tanımlanır. Pozitif yüzde bir içeriği (inset) belirtirken, negatif yüzde bir dışarı çıkışı (outset) belirtir.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Bir slaydın referansını indeksine göre alın.  
3. Bir `AutoShape` dikdörtgeni ekleyin.  
4. Bir görüntü oluşturun.  
5. Şeklin doldurma türünü ayarlayın.  
6. Şeklin resim doldurma modunu ayarlayın.  
7. Şekli doldurmak için bir görüntü ekleyin.  
8. Görüntünün offsetlerini, şeklin sınırlayıcı kutusunun ilgili kenarına göre belirtin.  
9. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Bu JavaScript kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:

```javascript
// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alır
    var slide = pres.getSlides().get_Item(0);
    // ImageEx sınıfının bir örneğini oluşturur
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Rectangle olarak ayarlanmış bir AutoShape ekler
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Şeklin doldurma türünü ayarlar
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Şeklin resim doldurma kipini ayarlar
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Şekli dolduracak görüntüyü ayarlar
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Görüntünün, şeklin sınırlayıcı kutusunun ilgili kenarına göre offsetlerini belirler
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

**PictureFrame için hangi görüntü biçimlerinin desteklendiğini nasıl öğrenebilirim?**  
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) içine atanan görüntü nesnesi aracılığıyla raster görüntüler (PNG, JPEG, BMP, GIF vb.) ve vektör görüntüler (örneğin SVG) desteği sunar. Desteklenen biçimlerin listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.  

**Yüzlerce büyük görüntü eklemek PPTX boyutunu ve performansı nasıl etkiler?**  
Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntüleri bağlamak sunum boyutunu düşük tutmaya yardımcı olur ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için bağlantı yoluyla görüntü ekleme özelliği sunar.  

**Bir görüntü nesnesini yanlışlıkla hareket etmeye/ yeniden boyutlandırmaya karşı nasıl kilitleyebilirim?**  
[shape locks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) kullanarak bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) (örneğin, hareketi veya yeniden boyutlandırmayı devre dışı bırakma) kilitleyebilirsiniz. Kilitleme mekanizması, çeşitli şekil tipleri için desteklenir, [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) dahil.  

**SVG vektör doğruluğu bir sunumu PDF/görsellere dışa aktarırken korunur mu?**  
Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) içindeki SVG'yi orijinal vektör olarak çıkarmanıza olanak tanır. [PDF'ye dışa aktarma](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) veya [raster formatlara](/slides/tr/nodejs-java/convert-powerpoint-to-png/) dönüştürürken, dışa aktarma ayarlarına bağlı olarak sonuç rasterleştirilebilir; ancak orijinal SVG'nin vektör olarak saklandığı çıkarım davranışıyla doğrulanır.
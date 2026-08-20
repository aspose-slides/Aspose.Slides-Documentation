---
title: Sunumlarda Resim Çerçevelerini JavaScript Kullanarak Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/nodejs-java/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- gömülü görüntü
- bağlantılı görüntü
- görüntüyü çıkar
- raster görüntü
- SVG görüntü
- görüntüyü kırp
- kırpılmış alanları sil
- görüntüyü sıkıştır
- StretchOffset
- resim çerçevesi biçimlendirme
- göreli ölçek
- görüntü efekti
- en-boy oranı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile JavaScript kullanarak sunumlardaki resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir resmi gösteren bir slayt şeklidir. Aspose.Slides içinde, resim kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) yerleşik resim kaynaklarını [ImageCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagecollection/) aracılığıyla sahiplenirken, bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) resmin konumunu, boyutunu, çizgi biçimlendirmesini, dönüşünü, kırpmasını, resim efektlerini ve diğer çerçeve düzeyindeki ayarları kontrol eder.

Bu ayrım, aynı resmin birden fazla kez gösterilmesi gerektiğinde faydalıdır. Resmi sunuma bir kez ekleyin, döndürülen [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu resim kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntüler ve SVG gibi vektör görüntüler içerebilir. Ayrıca, görüntü baytlarını sunuma depolamak yerine bağlantılı görüntülere de başvurabilirler. Bu seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görüntünün nasıl depolanacağına karar vermek yararlıdır.

## **Gömülü Bir Görüntüyü Ekleyin ve Biçimlendirin**

Gömülü bir görüntü için, görüntü verisini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) kullanın. Görüntü, sunum paketinin bir parçası haline gelir, böylece sunum başka bir bilgisayara taşındığında bile kendi içinde bağımsız kalır.

Aşağıdaki örnek bir PNG görüntüsü ekler, görüntünün yerel boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile dönüşüm uygular:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resim çerçevesi görüntülenen geometriyi kontrol eder; çerçeve boyutunu değiştirmek, gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir görüntüyü kırpma veya sıkıştırma yaparken önemli hale gelir.

## **Göreli Ölçek Kullanımı**

[PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) çerçeve için göreli genişlik ve yükseklik ölçeklemesini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) aracılığıyla sunar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Göreli ölçek, bir iş akışının son boyutları manuel olarak hesaplamak yerine kaynak görüntü boyutuyla ilişkisini koruması gerektiğinde faydalıdır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Göreli ölçek, çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlantılı Görüntüler**

Gömülü bir resim, görüntü verilerini sunum içinde depolar ve bu nedenle taşınabilirlik ve öngörülebilir renderleme için en güvenli seçenektir. Bağlantılı bir resim ise görüntü verilerini aynı şekilde gömmek yerine [Picture.setLinkPathLong](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) yöntemiyle harici bir konumu depolar.

Bağlantılı görüntüler, PPTX içinde depolanan görüntü veri miktarını azaltabilir, ancak bir dış bağımlılık getirir. Bağlantılı dosya, sunumu açan veya renderlayan uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak kullanılamazsa, bağlantılı resim beklendiği gibi gösterilmeyebilir. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamlarda renderlanması gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlantılı Bir Görüntü Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve onu yerel bir görüntü dosyasına yönlendirir. Sadece görüntü bağlantılamasıyla ilgilenir; video bağlantılaması ayrı bir medya iş akışıdır ve bu örnekte kasıtlı olarak karıştırılmamıştır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dış dosya yönetimi kasıtlı olduğunda bağlantıları kullanın. Sıkıştırma yerine sadece bir geçici çözüm olarak kullanmayın: kırık görüntü bağımlılıkları olan küçük bir PPTX, genellikle daha büyük, kendi içinde bağımsız bir sunumdan daha az kullanışlıdır.

## **Resim Çerçevelerinden Görüntüleri Çıkarma**

Mevcut bir sunumdan görüntü çıkarmadan önce, şeklin gerçekten bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) olup olmadığını ve gömülü bir görüntü içerdiğini kontrol edin. Bağlantılı resim çerçeveleri aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API'si doğrudan [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) kullanır. Aşağıdaki örnek, bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

[IImage.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/#save) ile kaydetmek, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunumda saklanan kodlanmış baytlara ihtiyacınız varsa, dönüştürülmüş raster dosya yerine görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntüsü Çıkarma**

Bir SVG resmi için, [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) bir [SvgImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/) nesnesi sunar. Bu, resmi önce rasterleştirmeden SVG verisini doğrudan almanızı sağlar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

SVG içeriğini SVG olarak tutmak, sunum içindeki vektör kaynağını korur. PNG veya JPEG gibi raster dışa aktarımlar, bu vektör içeriğini piksellere dönüştürmek zorundadır. PDF veya SVG slayt dışa aktarma da bir renderleme işlemidir, bu nedenle dışa aktarılan grafikler orijinal gömülü SVG'nin bayt bayt kopyası olarak ele alınmamalıdır; orijinal vektör kaynağı gerektiğinde gömülü [SvgImage.getSvgData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/#getSvgData--) verisini kullanın.

## **Bir Görüntüyü Kırpma**

Kırpma, bir çerçeve içinde görüntünün hangi kısmının görüneceğini değiştirir. [PictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) üzerindeki kırpma değerleri, kaynak görüntünün boyutlarının yüzde oranıdır. Kırpma, başlangıçta gizli pikselleri gömülü görüntüden silmez; sadece görünür bölgeyi değiştirir.

Aşağıdaki örnek, bir resim çerçevesini güvenli bir şekilde bulur ve kırpma değerlerini uygular:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Gizli görüntü verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu geri dönüşümden daha önemliyse, kırpılmış bölgeler bir sonraki bölümde açıklandığı gibi fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldırma**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) mevcut kırpma dikdörtgeninin dışındaki görüntü verilerini kaldırır ve oluşan görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra, kaldırılan pikseller daha sonraki bir kırpma geri alma işlemi için artık mevcut değildir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Yöntem, sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü diğer resim çerçeveleri tarafından da kullanılıyorsa, bu çerçeveler hâlâ mevcut kaynaklarını gerektirir; bu yüzden kırpılmış alanların silinmesi toplam görüntü sayısını mutlaka azaltmaz. Bu yöntemle WMF veya EMF içeriğini kırpmak, kırpılmış sonucu PNG'ye rasterleştirir.

## **Raster Görüntüleri Sıkıştırma**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) görüntünün gösterildiği boyuta göre raster görüntü çözünürlüğünü azaltır. Aynı işlemde kırpılmış bölgeleri de kaldırabilir. Yöntem, görüntü yeniden boyutlandırıldığında veya kırpıldığında `true`, değişiklik gerekmediğinde ise `false` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda önceden tanımlı bir [PicturesCompression](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturescompression/) değeri kullanın:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Belirli bir hedef gerektiğinde, önceden tanımlı bir değer yerine özel pozitif DPI değeri geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca, düşük çözünürlük ve silinen kırpılmış bölgelerin optimize edilmiş sunumdan geri getirilemeyeceğini unutmayın. En düşük DPI'yi küresel olarak uygulamak yerine, görüntünün gerçekten görüntülenecek veya dışa aktarılacak en büyük boyutuna göre bir hedef çözünürlük seçin.

## **Görüntü Efektlerini İnceleme**

Resim efektleri, çerçeve tarafından kullanılan resimde depolanır. Görüntü dönüşüm koleksiyonu, şeffaflık için sabit alfa modülasyonu ve parlaklık ve kontrast için luminans gibi efektler içerebilir. Aşağıdaki örnek, bir slayttaki ilk resim çerçevesinden her iki tür efekti güvenli bir şekilde okur:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Bu efektler, görüntünün çerçevede nasıl renderlendiğini değiştirir; orijinal gömülü görüntü baytlarını yeniden yazmazlar.

## **Resim Çerçevesi Geometrisini Kilitleme**

[PictureFrameLock](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakıldığını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) şeklin yeniden boyutlandırılması sırasında oranlarını korur.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kilitleme, resim çerçevesi şekline uygulanır. Kaynak görüntünün yeniden örneklenmesini veya kalıcı olarak aynı en‑boy oranına değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim dolgu modu stretch olduğunda, [PictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) üzerindeki stretch‑offset değerleri, dolgu dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri bir kenardan içeriye doğru boşluk oluştururken, negatif yüzde değerleri dışarıya doğru çıkıntı oluşturur.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynak görüntünün hangi kısmının görünür olduğunu seçerken; stretch offsetleri, görünür resim dolgusunun hangi dikdörtgene gerileceğini değiştirir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dolgu konumlandırması için stretch offsetlerini kullanın. Kaynak görüntünün kenarlarını gizleme amacı varsa kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarım Hususları**

Görüntü depolama ve resim çerçevesi biçimlendirme ayrı ayrı ele alındığında ana dengelemeler daha kolay yönetilir:

- **Gömülü görüntüler** sunumu kendi içinde bağımsız hâle getirir ve paylaşım ve sunucu tarafı renderleme için en güvenilir olanlardır, ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlantılı görüntüler** paketi daha küçük tutabilir, ancak sunum, depolanan yollar veya konumlardaki dış dosyaların mevcut olmasına bağlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene veya sıkıştırma sırasında kaldırılana kadar gömülü kalır.
- **Sıkıştırma**, aşırı büyük raster görüntüler için dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Bu, slayt üzerindeki hedef boyut bilindikten sonra uygulanmalıdır.
- **SVG görüntüler**, vektör korumanın önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağına doğrudan ihtiyacınız olduğunda gömülü SVG'yi doğrudan çıkarın. Raster slayt dışa aktarımları her zaman renderlenen slaytı piksellere dönüştürür.
- **Tekrarlanan görüntüler**, mümkün olduğunca aynı dosyayı sunum iş akışına tekrar tekrar yüklemek yerine mevcut bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) kaynağını yeniden kullanmalıdır.

Büyük sunumlarda, görüntü optimizasyonu genellikle seçici olarak gerçekleştirildiğinde en etkili olur: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek görüntüleme boyutlarına göre sıkıştırın, kırpılmış pikselleri yalnızca sonradan düzenleme gerektiğinde kaldırın ve dış bağlantılardan kaçının, aksi takdirde bağımlılık yönetimi dağıtım tasarımının bir parçası olmalıdır.

## **SSS**

**Resim çerçevesi ile görüntü kaynağı arasındaki fark nedir?**

[PPImage], sunuma ilişkili bir görüntü kaynağını temsil eder. [PictureFrame] ise bir slaytta görüntüyü gösteren ve çerçeve seviyesindeki geometri ve biçimlendirmeyi (boyut, döndürme, kırpma değerleri, efektler ve kilitlemeler gibi) depolayan bir şekildir.

**Görüntüleri gömmeli miyim yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan renderlanması gerektiğinde görüntüleri gömün. Görüntüleri yalnızca PPTX dışındaki dosyaları tutmak kasıtlı ve dış konumların güvenilir bir şekilde korunabileceği durumlarda bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden değil. Normal kırpma ayarları, kaynak görüntünün bölümlerini gizler ancak altındaki pikselleri tutar. Bu pikseller kalıcı olarak atılabilirse, [PictureFillFormat.deletePictureCroppedAreas] veya kırpılmış alanların kaldırıldığı görüntü sıkıştırmasını kullanın.

**Sıkıştırma sonrası görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma, saklanan raster çözünürlüğü azaltabilir ve kırpılmış bölgelerin kaldırılması görüntü verisini siler. Daha sonra yüksek çözünürlüklü düzenleme gerekebileceği durumlarda orijinal kaynak görüntüyü sunum dışında tutun.

**SVG görüntüler nasıl kullanılmalı?**

Vektör doğruluğunun önemli olduğu durumlarda SVG içeriğini SVG olarak tutun. Gömülü [SvgImage] doğrudan çıkarılabilir. Bir slaytı PNG veya JPEG gibi raster bir formata renderlemek, SVG'yi slayt görüntüsünün bir parçası olarak rasterleştirir.

**Mevcut slaytları okurken güvensiz tip dönüşümlerinden nasıl kaçınılır?**

Resim çerçevesine özgü üyeleri kullanmadan önce şekil tipini kontrol edin. [PictureFrame] karşısında bir `java.instanceOf` kontrolü, geçersiz tip dönüşümlerinden kaçınır ve kodun resim çerçevesi içermeyen slaytları işlemesine olanak tanır.
---
title: Sunularda Resim Çerçevelerini JavaScript Kullanarak Yönetme
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
- görüntü çıkar
- raster görüntü
- SVG görüntü
- görüntüyü kırp
- kırpılmış alanları sil
- görüntüyü sıkıştır
- StretchOffset
- resim çerçevesi biçimlendirme
- göreceli ölçek
- görüntü efekti
- en-boy oranı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile JavaScript kullanarak sunularda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

PictureFrame, bir resmi gösteren bir slayt şeklidir. Aspose.Slides’da, görüntü kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Sunum](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) **ImageCollection**(https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagecollection/) aracılığıyla yerleşik görüntü kaynaklarını sahiplenirken, bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) görüntünün konumunu, boyutunu, kenar biçimlendirmesini, döndürülmesini, kırpılmasını, resim efektlerini ve diğer çerçeve‑seviyesi ayarlarını kontrol eder.

Bu ayrım, aynı görüntünün birden çok kez gösterilmesi gerektiğinde yararlıdır. Görüntüyü sunuma bir kez ekleyin, döndürülen [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesnesini saklayın ve picture frame oluştururken bu görüntü kaynağını kullanın.

Picture frame’ler PNG veya JPEG gibi raster görüntülerin yanı sıra SVG gibi vektör görüntülerini de içerebilir. Ayrıca, görüntü baytlarını sunuma depolamak yerine bağlantılı (linked) görüntülere de başvurabilirler. Bu seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu yüzden biçimlendirme veya optimizasyon uygulanmadan önce görüntünün nasıl saklanacağına karar vermek faydalıdır.

## **Gömülü Bir Görüntü Ekleme ve Biçimlendirme**

Gömülü bir görüntü için, görüntü verisini sunuma ekleyin ve [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) yöntemiyle bir picture frame oluşturun. Görüntü, sunum paketinin bir parçası hâline gelir; bu sayede sunum başka bir bilgisayara taşındığında da kendine yeterli olur.

Aşağıdaki örnek bir PNG görüntüsü ekler, görüntünün yerel boyutlarında bir çerçeve oluşturur ve kenar biçimlendirmesi ile döndürmeyi uygular:

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

Picture frame, görüntünün gösterilen geometrisini kontrol eder; çerçevenin boyutunu değiştirmek, gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra görüntüyü kırpma veya sıkıştırma yapıldığında önemli hâle gelir.

## **Göreceli Ölçek Kullanma**

[PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/), çerçeve için [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) aracılığıyla göreceli genişlik ve yükseklik ölçeklemesini sunar. `1.0` değeri, orijinal resim boyutunun %100’üne karşılık gelir. Göreceli ölçek, bir iş akışının son boyutları manuel olarak hesaplamak yerine kaynak görüntü boyutuna ilişkin bir ilişkiyi koruması gerektiğinde faydalıdır.

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

Göreceli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örnekleme veya sıkıştırma yapmaz.

## **Gömülü ve Bağlantılı Görüntüler**

Gömülü bir picture, görüntü verilerini sunum içinde depolar ve bu yüzden taşınabilirlik ve öngörülebilir render için en güvenli tercihtir. Bağlantılı bir picture, görüntü verilerini aynı şekilde gömmek yerine [Picture.setLinkPathLong](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) yöntemiyle harici bir konumu saklar.

Bağlantılı görüntüler PPTX içinde depolanan görüntü verisi miktarını azaltabilir, ancak dış bir bağımlılık getirir. Bağlantılı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir kalmalıdır. Yol değişirse, dosya taşınırsa veya kaynak mevcut değilse, bağlantılı picture beklenildiği gibi gösterilemez. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamda render edilmesi gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlantılı Bir Görüntü Ekleme**

Aşağıdaki örnek bir picture frame oluşturur ve yerel bir görüntü dosyasına işaret eder. Sadece görüntü bağlama ile ilgilenir; video bağlama ayrı bir medya iş akışı olup bu örnekte kasıtlı olarak karıştırılmamıştır.

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

Harici dosya yönetimi kasıtlıysa linkleri kullanın. Sıkıştırmanın yerine sadece bir seçenek olarak kullanmayın: kırık görüntü bağımlılıkları olan küçük bir PPTX, genellikle daha büyük, kendine yeten bir sunumdan daha az yararlı olur.

## **Picture Frame’lerden Görüntü Çıkarma**

Mevcut bir sunumdan bir görüntü çıkarmadan önce, şeklin gerçekten bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) olup olmadığını ve gömülü bir görüntü içerip içermediğini kontrol edin. Bağlantılı picture frame’ler, aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API’si doğrudan [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

[IImage.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/#save) aracılığıyla kaydetmek, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunum içinde kodlanmış baytları (dönüştürülmüş raster dosya yerine) almanız gerekiyorsa, görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntüsü Çıkarma**

Bir SVG picture için, [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) bir [SvgImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/) nesnesi sunar. Bu, resmi rasterleştirmeden doğrudan SVG verisini almanızı sağlar.

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

SVG içeriğini SVG olarak tutmak, sunum içinde vektör kaynağının korunmasını sağlar. PNG veya JPEG gibi raster dışa aktarımlar, bu vektör içeriği piksellere dönüştürür. PDF veya SVG slayt dışa aktarması da bir render işlemi olduğundan, dışa aktarılan grafikler orijinal gömülü SVG’nin bayt‑bayt kopyası olarak değerlendirilmemelidir; orijinal vektör kaynağı gerektiğinde gömülü [SvgImage.getSvgData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/#getSvgData--) verisi kullanılmalıdır.

## **Bir Görüntüyü Kırpma**

Kırpma, çerçeve içinde görüntünün hangi kısmının görüneceğini değiştirir. [PictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) üzerindeki kırpma değerleri, kaynak görüntünün boyutlarının yüzde değerleridir. Kırpma, gömülü görüntüden gizli pikselleri başlangıçta silmez; yalnızca görünür bölgeyi değiştirir.

Aşağıdaki örnek bir picture frame’i güvenli bir şekilde bulur ve kırpma değerlerini uygular:

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

Gizli görüntü verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu, geri dönüşlülükten daha önemliyse, kırpılmış bölgeler bir sonraki bölümde fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldırma**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) mevcut kırpma dikdörtgeni dışındaki görüntü verisini kaldırır ve ortaya çıkan görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, fakat yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonra bir “uncrop” işlemiyle geri getirilemez.

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

Bu yöntem, sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü başka picture frame’ler tarafından da kullanılıyorsa, bu frame’ler hâlâ mevcut kaynağa ihtiyaç duyar; bu nedenle kırpılmış alanların silinmesi mutlaka toplam görüntü sayısını azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterleştirir.

## **Raster Görüntüleri Sıkıştırma**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) raster görüntünün çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, görüntü yeniden boyutlandırıldıysa veya kırpıldıysa `true`, hiçbir değişiklik gerekmediyse `false` döndürür.

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

Belirli bir hedef gerekiyorsa, önceden tanımlı bir değer yerine pozitif bir DPI değeri de geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metadönüştürme içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca, daha düşük çözünürlük ve silinmiş kırpılmış bölgelerin optimize edilmiş sunumdan geri kazanılamayacağını unutmayın. Hedef çözünürlüğü, görüntünün gerçekten görüntüleneceği veya dışa aktarılacağı en büyük boyuta göre seçin; tüm sunumda en düşük DPI’yı uygulamayın.

## **Görüntü Dönüşüm Efektlerini Yönetme**

Parlaklık, kontrast, renk dönüşümleri, bulanıklaştırma, alfa efektleri, sıralı zincirler, inceleme, kaldırma ve çift yönlü doğrulama gibi tam bir iş akışı için [Image Transform Effects](/slides/tr/nodejs-java/image-transform-effects/) bölümüne bakın.

## **Picture Frame Geometrisini Kilitleme**

[PictureFrameLock](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframelock/) ayarları, bir picture frame için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) yeniden boyutlandırılırken şeklin en‑boy oranını korur.

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

Kilitleme picture frame şekline uygulanır. Kaynak görüntünün yeniden örneklenmesini veya kalıcı olarak aynı en‑boy oranına dönüştürülmesini zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu “stretch” olduğunda, [PictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini picture frame’in sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri bir kenardan içe girerken, negatif değerler dışa çıkar.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynağın hangi kısmının görüneceğini seçerken; stretch offset’ler görünür resim doldurmasının hangi dikdörtgene gerileceğini değiştirir.

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

Dolgu konumlandırması için stretch offset’leri kullanın. Kaynak görüntünün kenarlarını gizlemek istiyorsanız kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Düşünceleri**

Görüntü depolama ve picture‑frame biçimlendirmesi ayrı ayrı ele alındığında temel ödünleşimler daha kolay yönetilir:

- **Gömülü görüntüler** sunumu kendine yeten hâle getirir ve paylaşım ile sunucu tarafı render için en güvenilir seçenektir; ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlantılı görüntüler** paketi daha küçük tutabilir, fakat sunumun dış dosyaların belirtilen yollar/konumlarda erişilebilir olmasına bağlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene kadar gömülü kalır veya sıkıştırma sırasında kaldırılır.
- **Sıkıştırma**, aşırı büyük raster görüntüler için dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Slayt üzerindeki hedef boyut bilindikten sonra uygulanmalıdır.
- **SVG görüntüler** vektör korunumu önemli olduğunda SVG olarak kalmalıdır. Vektör kaynağına ihtiyacınız olduğunda gömülü SVG doğrudan çıkarılabilir. Raster slayt dışa aktarımları her zaman slaytı piksellere dönüştürür.
- **Tekrarlanan görüntüler**, aynı dosyayı tekrar tekrar sunuma yüklemek yerine mümkün olduğunca mevcut bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) kaynağını yeniden kullanmalıdır.

Büyük sunumlarda, görüntü optimizasyonu seçici olarak yapıldığında genellikle en etkilidir: logolar ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutlarına göre sıkıştırın, kırpılmış pikselleri yalnızca sonraki düzenleme gerekmiyorsa kaldırın ve dış bağlantıları, bağımlılık yönetimi dağıtım tasarımına dahil değilse kullanmaktan kaçının.

## **SSS**

**Bir picture frame ile bir görüntü kaynağı arasındaki fark nedir?**

[PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/), sunumla ilişkilendirilmiş bir görüntü kaynağını temsil eder. [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/), bir slaytta görüntüyü gösteren ve çerçeve‑seviyesi geometrik ve biçimlendirme bilgilerini (boyut, döndürme, kırpma değerleri, efektler, kilitlemeler) tutan bir şekildir.

**Görüntüleri gömmeli mi yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa görüntüleri gömün. Görüntü dosyalarını PPTX dışına koymak kasıtlı ve dış konumlar güvenilir bir şekilde yönetilebilecekse yalnızca bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden azaltmaz. Normal kırpma ayarları kaynağın bir kısmını gizler ancak alttaki pikselleri tutar. Kırpılmış pikselleri kalıcı olarak kaldırmak için [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) veya kırpma bölgesi kaldırmalı sıkıştırma kullanın.

**Sıkıştırma sonrası görüntü kalitesi geri getirilebilir mi?**

Hayır. Sıkıştırma depolanan raster çözünürlüğü düşürebilir ve kırpılmış bölgelerin kaldırılması görüntü verisini siler. Daha sonra yüksek çözünürlükte düzenleme gerekebileceği durumlarda orijinal kaynağı sunum dışına alın.

**SVG görüntüler nasıl ele alınmalı?**

Vektör kalitesi önemliyse SVG içeriği SVG olarak tutun. Gömülü [SvgImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/) doğrudan çıkarılabilir. Slaytı PNG veya JPEG gibi raster bir formata render etmek, SVG’yi slayt görüntüsünün bir parçası hâline getirir.

**Mevcut slaytları okurken güvensiz cast’lerden nasıl kaçınılır?**

Picture‑frame‑özel üyeleri kullanmadan önce şekil tipini kontrol edin. [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) karşısında bir `java.instanceOf` kontrolü, geçersiz cast’leri önler ve picture frame içermeyen slaytların kod tarafından uygun şekilde işlenmesini sağlar.
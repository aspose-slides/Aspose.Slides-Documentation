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
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: Aspose.Slides for Node.js ile JavaScript kullanarak sunumlarda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın.
---
## **Genel Bakış**

Bir picture frame bir slayt şeklidir ve bir resmi gösterir. Aspose.Slides'da görüntü kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) gömülü görüntü kaynaklarını [ImageCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagecollection/) aracılığıyla sahiplenirken, bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) görüntünün konumunu, boyutunu, hat biçimini, döndürmeyi, kırpmayı, resim efektlerini ve diğer çerçeve‑seviyesi ayarları kontrol eder.

Bu ayrım aynı görüntünün birden çok kez gösterildiği durumlarda kullanışlıdır. Görüntüyü sunuma bir kez ekleyin, döndürülen [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesnesini saklayın ve picture frame oluştururken bu görüntü kaynağını kullanın.

Picture frame'ler PNG veya JPEG gibi raster görüntülerin yanı sıra vektör SVG görüntülerini de içerebilir. Ayrıca görüntünün baytlarını sunuma depolamak yerine bağlanmış (linked) görüntülere de başvurabilirler. Seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle formatlama veya optimizasyon uygulamadan önce görüntünün nasıl depolanacağına karar vermek faydalıdır.

## **Gömülü Bir Görüntüyü Ekle ve Biçimlendir**

Gömülü bir görüntü için, görüntü verisini sunuma ekleyin ve bir picture frame'i [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) ile oluşturun. Görüntü, sunum paketinin bir parçası haline gelir; böylece sunum, başka bir bilgisayara taşındığında bile kendine yeterli kalır.

Aşağıdaki örnek bir PNG görüntüsü ekler, görüntünün yerel boyutlarında bir çerçeve oluşturur ve hat biçimi ile döndürmeyi uygular:

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

Picture frame görüntülenen geometrileri kontrol eder; çerçeve boyutunu değiştirmek gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir görüntüyü kırpma veya sıkıştırma yapıldığında önem kazanır.

## **Göreli Ölçeği Kullan**

[PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) çerçeve için göreli genişlik ve yükseklik ölçeğini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) metodlarıyla sunar. `1.0` değeri orijinal resim boyutunun %100'üne karşılık gelir. Göreli ölçek, bir iş akışının son boyutları manuel olarak hesaplamak yerine kaynak görüntü boyutuyla olan ilişkiyi koruması gerektiğinde faydalıdır.

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

Göreli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlantılı Görüntüler**

Gömülü bir picture, görüntü verisini sunum içinde depolar ve bu nedenle taşınabilirlik ve öngörülebilir renderlama açısından en güvenli tercih olur. Bağlantılı bir picture, görüntü verisini aynı şekilde gömmek yerine [Picture.setLinkPathLong](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) metodu aracılığıyla harici bir konuma işaret eder.

Bağlantılı görüntüler PPTX içinde depolanan görüntü verisinin miktarını azaltabilir, ancak dış bir bağımlılık getirir. Bağlantılı dosya, sunumu açan veya renderlayan uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak erişilemez hâle gelirse, bağlantılı picture beklendiği gibi gösterilemez. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamda renderlanması gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlantılı Bir Görüntü Ekle**

Aşağıdaki örnek bir picture frame oluşturur ve onu yerel bir resim dosyasına işaret eder. Yalnızca görüntü bağlama ile ilgilenir; video bağlama ayrı bir medya iş akışıdır ve bu örneğe kasıtlı olarak dahil edilmemiştir.

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

Harici dosya yönetimi amaçlı olduğunda bağlantılar kullanılmalıdır. Sıkıştırma yerine bağlantı olarak kullanılmamalıdır: kırık bağımlılıkları olan küçük bir PPTX, daha büyük ama kendine yeterli bir sunuma göre genellikle daha az kullanışlıdır.

## **Resim Çerçevelerinden Görüntüleri Çıkar**

Mevcut bir sunumdan bir görüntü çıkarmadan önce, şeklin gerçekten bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) olup olmadığını ve gömülü bir görüntü içerdiğini kontrol edin. Bağlantılı picture frame'ler aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntüyü Çıkar**

Modern görüntü API'si doğrudan [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster picture'ı bulur ve PNG olarak kaydeder:

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

[IImage.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/#save) üzerinden kaydetmek, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunum içinde depolanmış kodlanmış baytları (dönüştürülmüş raster dosya yerine) istiyorsanız, görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntüyü Çıkar**

SVG picture için, [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) bir [SvgImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/) nesnesi sunar. Bu sayede rasterlaştırma yapmadan SVG verisini doğrudan alabilirsiniz.

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

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarımlar bu vektörü piksellere dönüştürür. PDF veya SVG slayt dışa aktarımları da bir render işlemi olduğundan, dışa aktarılan grafikler orijinal gömülü SVG'nin bayt‑bayt kopyası olarak görülmemelidir; orijinal vektör kaynağı gerektiğinde gömülü [SvgImage.getSvgData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/#getSvgData--) verisi kullanılmalıdır.

## **Bir Görüntüyü Kırp**

Kırpma, bir görüntünün çerçeve içinde hangi kısmının görüleceğini değiştirir. [PictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) üzerindeki kırpma değerleri kaynak görüntünün boyutlarının yüzdelik değerleridir. Kırpma, gizli pikselleri gömülü görüntüden hemen silmez; sadece görünür bölgeyi değiştirir.

Aşağıdaki örnek bir picture frame'i güvenli bir şekilde bulur ve kırpma değerlerini uygular:

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

Gizli görüntü verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu geri dönüşümsüzlüğe göre daha önemliyse, sonraki bölümde açıklanan şekilde kırpılmış bölgeler fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldır**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) mevcut kırpma dikdörtgeninin dışındaki görüntü verisini siler ve ortaya çıkan görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra silinen pikseller daha sonra bir "uncrop" işlemiyle geri getirilemez.

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

Bu yöntem sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü başka picture frame'ler tarafından da kullanılıyorsa, bu frame'ler hâlâ mevcut kaynaklarını ihtiyaç duyar; bu nedenle kırpılmış alanların silinmesi mutlaka toplam görüntü sayısını azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG'ye rasterlaştırır.

## **Raster Görüntüleri Sıkıştır**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) raster görüntünün çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Görüntü yeniden boyutlandırıldıysa veya kırpıldıysa `true`, hiç bir değişiklik gerekmediyse `false` döner.

Standart bir hedef çözünürlük yeterli olduğunda önceden tanımlı bir [PicturesCompression](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturescompression/) değeri kullanılabilir:

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

Belirli bir hedef gerekiyorsa, önceden tanımlı değer yerine pozitif bir DPI değeri geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca düşük çözünürlük ve silinen kırpılmış bölgeler optimize edilmiş sunumdan geri alınamaz. Hedef çözünürlüğü, görüntünün gerçekte görüntülenecek veya dışa aktarılacak en büyük boyutuna göre seçin; tüm sunumu en düşük DPI'ye indirgeyerek değil.

## **Görüntü Dönüşüm Efektlerini Yönet**

Parlaklık, kontrast, renk dönüşümleri, bulanıklaştırma, alfa efektleri, sıralı zincirler, inceleme, kaldırma ve çift yönlü doğrulama gibi tam bir iş akışı için [Image Transform Effects](/nodejs-java/image-transform-effects/) bölümüne bakın.

## **Resim Çerçevesi Geometrisini Kilitle**

[PictureFrameLock](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframelock/) ayarları, bir picture frame için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) şeklin yeniden boyutlandırılırken en boy oranını korur.

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

Kilitleme picture frame şekline uygulanır. Kaynak görüntünün aynı en boy oranına yeniden örneklenmesini veya kalıcı olarak değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarla**

Picture fill modu stretch olduğunda, [PictureFillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini picture frame'in sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri kenardan içe doğru bir içerik oluştururken, negatif yüzde değerleri dışa doğru bir genişleme yaratır.

Bu, kırpmadan farklıdır. Kırpma değerleri kaynak görüntünün hangi kısmının görüleceğini seçer; stretch offset'ler ise görünen picture fill'in uzatılacağı dikdörtgeni değiştirir.

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

Stretch offset'leri doldurma konumlandırması için kullanın. Kaynak görüntünün kenarlarını gizlemek istiyorsanız kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Görsel depolama ve picture‑frame biçimlendirmesi ayrı ayrı ele alındığında temel karşılaştırmalar daha net yönetilir:

- **Gömülü görüntüler** sunumu kendine yeterli kılar ve paylaşım ve sunucu tarafı renderlama için en güvenilir seçenektir, ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlantılı görüntüler** paketi daha küçük tutabilir, ancak sunumun harici dosyaların belirtilen yollarda veya konumlarda mevcut olmasına bağlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene veya sıkıştırma sırasında kaldırılana kadar gömülüdür.
- **Sıkıştırma**, aşırı büyük raster görüntülerin dosya boyutunu önemli ölçüde azaltabilir, fakat kaynak çözünürlüğü feda eder. Görüntünün slayt üzerindeki hedef boyutu bilindiğinde uygulanmalıdır.
- **SVG görüntüler** vektör korumasının önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağının kendisine ihtiyaç duyduğunuzda gömülü SVG'yi doğrudan çıkarın. Raster slayt dışa aktarımları her zaman görüntüyü piksellere dönüştürür.
- **Tekrarlanan görüntüler** mümkün olduğunca mevcut bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) kaynağını yeniden kullanmalı, aynı dosyanın sunuma birden çok kez yüklenmesinden kaçınılmalıdır.

Büyük sunumlarda, görüntü optimizasyonu seçici olarak yapıldığında en etkili olur: logo ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutuna göre sıkıştırın, kırpılmış pikselleri yalnızca sonraki düzenleme gerekmiyorsa kaldırın ve dış bağlantılar ancak bağımlılık yönetimi dağıtım tasarımının bir parçasıysa kullanılmalıdır.

## **SSS**

**Resim çerçevesi ile görüntü kaynağı arasındaki fark nedir?**

[PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) sunumla ilişkili bir görüntü kaynağını temsil eder. [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) ise bir slaytta görüntüyü gösteren, boyut, döndürme, kırpma değerleri, efektler ve kilitler gibi çerçeve‑seviyesi geometrileri ve biçimlendirmeyi depolayan bir şekildir.

**Görüntüleri gömmeli mi yoksa bağlamalı mı?**

Görseller, sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan renderlanması gerektiğinde gömülmelidir. Görselleri dışarda tutmak ve PPTX'in daha küçük olmasını sağlamak sadece dış dosya konumları güvenilir bir şekilde yönetilebileceği durumlarda tercih edilmelidir.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden olmaz. Normal kırpma ayarları kaynak görüntünün bir kısmını gizler ancak alttaki pikselleri tutar. Kırpılmış alanları gerçekten silmek için [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) veya kırpma kaldırmalı bir görüntü sıkıştırması kullanılmalıdır.

**Sıkıştırmadan sonra görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma depolanan raster çözünürlüğü azaltabilir ve kırpılmış bölgelerin kaldırılması görüntü verisini siler. Daha sonraki yüksek çözünürlükli düzenleme ihtimali varsa orijinal kaynak görüntüyü sunum dışına saklayın.

**SVG görüntüler nasıl ele alınmalı?**

Vektör doğruluğunun önemli olduğu durumlarda SVG içeriği SVG olarak tutulmalıdır. Gömülü [SvgImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/) doğrudan çıkarılabilir. PNG veya JPEG gibi raster formatlara slayt renderlamak, SVG'yi slayt görüntüsünün bir parçası olarak piksellere dönüştürür.

**Mevcut slaytları okurken güvenli olmayan cast'leri nasıl önleyebilirim?**

Picture frame'e özgü üyeleri kullanmadan önce şekil tipini kontrol edin. [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) tipine bir `java.instanceOf` kontrolü, geçersiz cast'leri önler ve picture frame içermeyen slaytların kod tarafından uygun şekilde işlenmesini sağlar.
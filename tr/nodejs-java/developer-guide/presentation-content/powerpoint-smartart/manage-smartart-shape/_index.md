---
title: JavaScript kullanarak Sunumlarda SmartArt Grafiklerini Yönetme
linktitle: SmartArt Grafikler
type: docs
weight: 20
url: /tr/nodejs-java/manage-smartart-shape/
keywords:
- SmartArt nesnesi
- SmartArt grafik
- SmartArt stili
- SmartArt rengi
- SmartArt oluştur
- SmartArt ekle
- SmartArt düzenle
- SmartArt değiştir
- SmartArt eriş
- SmartArt düzenleme türü
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te Aspose.Slides kullanarak PowerPoint SmartArt oluşturmayı, düzenlemeyi ve stillendirmeyi otomatikleştirin; özlü kod örnekleri ve performansa odaklı rehberlik sunar."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında SmartArt grafiklerini programlı olarak oluşturmanıza ve yönetmenize olanak tanır. Bu makale, bir slayta SmartArt şekli eklemeyi, mevcut SmartArt şekillerine erişmeyi, belirli bir düzen türüne göre SmartArt bulmayı ve SmartArt stilini veya renk stilini değiştirerek görsel görünümünü güncellemeyi açıklar.

Örnekler, sunum slaytının şekil koleksiyonu üzerinden SmartArt şekilleriyle nasıl çalışılacağını, bir şeklin SmartArt olup olmadığını kontrol etmeyi ve ardından özelliklerini değiştirmeyi veya incelemeyi gösterir.

## **SmartArt Şekli Oluşturma**
Aspose.Slides for Node.js via Java, SmartArt şekilleri oluşturmak için bir API sağlamıştır. Bir slayta SmartArt şekli oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İndeksini kullanarak bir slayt referansı alın.  
1. [SmartArt şekli ekle](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) [LayoutType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtLayoutType) ayarlayarak.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```javascript
// Sunum Sınıfını Örnekle
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı al
    var slide = pres.getSlides().get_Item(0);
    // Smart Art Şekli ekle
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Sunumu kaydet
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Şekil: Slayta eklenen SmartArt şekli**|

## **Slayttaki SmartArt Şekline Erişim**
Aşağıdaki kod, sunum slaytına eklenen SmartArt şekillerine erişmek için kullanılacaktır. Örnek kodda slayt içindeki her şekli dolaşacak ve şeklin bir SmartArt olup olmadığını kontrol edeceğiz. Şekil SmartArt tipindeyse, onu SmartArt örneğine dönüştüreceğiz.

```javascript
// İstenen sunumu yükle
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // İlk slayttaki her şekli dolaş
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Şekli SmartArtEx tipine dönüştür
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Belirli Düzen Türü ile SmartArt Şekline Erişim**
Aşağıdaki örnek kod, belirli bir LayoutType ile SmartArt şekline erişmenize yardımcı olur. Lütfen SmartArt'ın LayoutType'ının yalnızca okunabilir olduğunu ve yalnızca SmartArt şekli eklendiğinde ayarlandığını, bu nedenle değiştirilemeyeceğini unutmayın.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.  
1. İlk slaytın indeksini kullanarak bir referans alın.  
1. İlk slayt içindeki her şekli dolaşın.  
1. Şeklin SmartArt tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt tipine dönüştürün.  
1. Belirli LayoutType ile SmartArt şekli kontrol edin ve ardından gerekli işlemleri yapın.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // İlk slayttaki her şekli dolaş
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Şekli SmartArtEx tipine dönüştür
            var smart = shape;
            // SmartArt yerleşimini kontrol et
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt Şekil Stilini Değiştirme**
Bu örnekte, herhangi bir SmartArt şeklinin hızlı stilini değiştirmeyi öğreneceğiz.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.  
1. İlk slaytın indeksini kullanarak bir referans alın.  
1. İlk slayt içindeki her şekli dolaşın.  
1. Şeklin SmartArt tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt tipine dönüştürün.  
1. Belirli bir Stil ile SmartArt şekli bulun.  
1. SmartArt şekli için yeni Stili ayarlayın.  
1. Sunumu kaydedin.

```javascript
// Sunum Sınıfını Örnekle
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // İlk slaytı al
    var slide = pres.getSlides().get_Item(0);
    // İlk slayttaki her şekli dolaş
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Şekli SmartArtEx tipine dönüştür
            var smart = shape;
            // SmartArt stilini kontrol et
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // SmartArt stilini değiştir
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Sunumu kaydet
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Şekil: Stili değiştirilen SmartArt şekli**|

## **SmartArt Şekil Renk Stilini Değiştirme**
Bu örnekte, herhangi bir SmartArt şeklinin renk stilini değiştirmeyi öğreneceğiz. Aşağıdaki örnek kod, belirli bir renk stili ile SmartArt şekline erişecek ve stilini değiştirecektir.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.  
1. İlk slaytın indeksini kullanarak bir referans alın.  
1. İlk slayt içindeki her şekli dolaşın.  
1. Şeklin SmartArt tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt tipine dönüştürün.  
1. Belirli bir Renk Stili ile SmartArt şekli bulun.  
1. SmartArt şekli için yeni Renk Stilini ayarlayın.  
1. Sunumu kaydedin.

```javascript
// Sunum Sınıfını Örnekle
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // İlk slaytı al
    var slide = pres.getSlides().get_Item(0);
    // İlk slayttaki her şekli dolaş
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Şeklin SmartArt tipinde olup olmadığını kontrol et
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Şekli SmartArtEx tipine dönüştür
            var smart = shape;
            // SmartArt renk tipini kontrol et
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // SmartArt renk tipini değiştir
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Sunumu kaydet
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Şekil: Renk Stili değiştirilen SmartArt şekli**|

## **SSS**

**SmartArt'ı tek bir nesne olarak animasyonlayabilir miyim?**

Evet. SmartArt bir şekildir, bu yüzden diğer şekillerde olduğu gibi animasyon API'si aracılığıyla [standard animasyonlar](/slides/tr/nodejs-java/powerpoint-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulayabilirsiniz.

**Dahili kimliğini bilmediğim bir slayttaki belirli bir SmartArt'ı nasıl bulabilirim?**

Alternatif Metin (AltText) belirleyip kullanarak şekli bu değerle arayın—bu, hedef şekli bulmanın önerilen bir yoludur.

**SmartArt'ı diğer şekillerle gruplayabilir miyim?**

Evet. SmartArt'ı diğer şekillerle (resimler, tablolar vb.) gruplayabilir ve ardından grubu [manipüle](/slides/tr/nodejs-java/group/) edebilirsiniz.

**Belirli bir SmartArt'ın görüntüsünü (örneğin önizleme veya rapor için) nasıl alabilirim?**

Şeklin bir önizleme/görüntüsünü dışa aktarın; kütüphane tek tek şekilleri raster dosyalara (PNG/JPG/TIFF) [render](/slides/tr/nodejs-java/create-shape-thumbnails/) edebilir.

**Tüm sunumu PDF'ye dönüştürürken SmartArt görünümü korunur mu?**

Evet. Rendering motoru, PDF dışa aktarma için yüksek doğruluk hedefler ve çeşitli kalite ve uyumluluk seçenekleri sunar.
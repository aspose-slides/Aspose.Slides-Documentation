---
title: JavaScript'te Sunum Yer Tutucularını Yönet
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/nodejs-java/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- görsel yer tutucu
- grafik yer tutucu
- istem metni
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile yer tutucuları zahmetsizce yönetin: metni değiştirin, istemleri özelleştirin ve PowerPoint ve OpenDocument'te görsel şeffaflığını ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum yer tutucularını programlı olarak yönetmenizi sağlar. Bu makale, slaytlardaki yer tutucuları nasıl bulup metinlerini değiştireceğinizi, yer tutucu düzenleri için özel istem metni nasıl ayarlayacağınızı ve bir yer tutucu arka planı olarak kullanılan resmin şeffaflığını nasıl ayarlayacağınızı açıklar. Ayrıca, temel yer tutucular ile yerel şekiller arasındaki farkı netleştiren kısa bir SSS bölümü, yer tutucu değişikliklerinin düzenler veya masterlar aracılığıyla nasıl uygulanabileceğini ve başlık ile alt bilgi yer tutucularının yönetimine dair ipuçlarını içerir.

## **Yer Tutucudaki Metni Değiştir**

[ Aspose.Slides for Node.js via Java](/slides/tr/nodejs-java/) kullanarak, sunumlardaki slaytlarda yer tutucuları bulabilir ve değiştirebilirsiniz. Aspose.Slides, bir yer tutucudaki metni değiştirme imkanı sunar.

**Önkoşul**: Yer tutucu içeren bir sunuma ihtiyacınız var. Bu tür bir sunumu standart Microsoft PowerPoint uygulamasında oluşturabilirsiniz.

Aspose.Slides kullanarak bu sunumdaki yer tutucunun metnini nasıl değiştireceğiniz aşağıda gösterilmiştir:

1. [`Presentation`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve sunumu argüman olarak geçirin.  
2. Slayt referansını indeks üzerinden alın.  
3. Şekilleri döngüye alarak yer tutucuyu bulun.  
4. Yer tutucu şekli bir [`AutoShape`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) tipine dönüştürün ve ilgili [`AutoShape`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) ile ilişkili [`TextFrame`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrame) kullanarak metni değiştirin.  
5. Değiştirilmiş sunumu kaydedin.

Bu JavaScript kodu, yer tutucudaki metnin nasıl değiştirileceğini gösterir:

```javascript
// Bir Presentation sınıfı örnekler
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Yer tutucuyu bulmak için şekilleri iterasyonla dolaşır
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Her yer tutucudaki metni değiştirir
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Sunumu diske kaydeder
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Yer Tutucuda İstem Metni Ayarla**

Standart ve önceden oluşturulmuş düzenler, ***Click to add a title*** veya ***Click to add a subtitle*** gibi yer tutucu istem metinleri içerir. Aspose.Slides kullanarak, yer tutucu düzenlerine tercih ettiğiniz istem metinlerini ekleyebilirsiniz.

Bu JavaScript kodu, yer tutucuda istem metninin nasıl ayarlanacağını gösterir:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Slaytı iterasyonla dolaşır
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint "Click to add title" ifadesini gösterir
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Alt başlık ekler
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Yer Tutucu Resim Şeffaflığını Ayarla**

Aspose.Slides, bir metin yer tutucusundaki arka plan resminin şeffaflığını ayarlamanıza izin verir. Bu çerçevedeki resmin şeffaflığını ayarlayarak, metin veya resim (renklerine bağlı olarak) öne çıkabilir.

Bu JavaScript kodu, bir şekil içindeki resim arka planının şeffaflığının nasıl ayarlanacağını gösterir:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **SSS**

**Temel bir yer tutucu nedir ve bir slayttaki yerel şekilden nasıl farklıdır?**

Temel yer tutucu, slaytın şeklinin miras aldığı, düzen ya da master üzerindeki orijinal şekildir—tür, konum ve bazı biçimlendirmeler ondan gelir. Yerel şekil bağımsızdır; temel bir yer tutucu yoksa miras uygulanmaz.

**Sunum genelinde tüm başlıkları veya alt yazıları, her slaytı tek tek dolaşmadan nasıl güncelleyebilirim?**

İlgili yer tutucuyu düzen veya master üzerinde düzenleyin. Bu düzen/ master üzerine kurulu slaytlar değişikliği otomatik olarak devralır.

**Standart başlık/alt bilgi yer tutucularını—tarih & saat, slayt numarası ve alt bilgi metnini—nasıl kontrol ederim?**

Uygun kapsamda (normal slaytlar, düzenler, master, notlar/el kitapçıkları) HeaderFooter yöneticilerini kullanarak bu yer tutucuları açıp kapatabilir ve içeriklerini ayarlayabilirsiniz.
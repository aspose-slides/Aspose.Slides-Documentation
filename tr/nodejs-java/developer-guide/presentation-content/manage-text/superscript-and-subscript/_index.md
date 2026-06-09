---
title: Sunumlarda Üst Simge ve Alt Simge Yönetimi JavaScript ile
linktitle: Üst Simge ve Alt Simge
type: docs
weight: 80
url: /tr/nodejs-java/superscript-and-subscript/
keywords:
- üst simge
- alt simge
- üst simge ekle
- alt simge ekle
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te Java aracılığıyla üst simge ve alt simgeyi ustalaştırın ve sunumlarınızı maksimum etki için profesyonel metin biçimlendirmesiyle yükseltin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarınıza üst simge ve alt simge metni ekleme özellikleri sunar. Kimyasal formülleri, matematiksel denklemleri vurgulamanız ya da alt metinle içerik eklemeniz gerektiğinde, bu özel biçimlendirme seçenekleri netlik ve kesinlik sağlar. Bu makalede, üst simge ve alt simge stillerini sorunsuz bir şekilde nasıl uygulayacağınızı ve her slaytta profesyonel sonuçlar elde edeceğinizi öğreneceksiniz.

## **Üst Simge ve Alt Simge Metnini Yönetme**

Herhangi bir paragraf bölümüne üst simge ve alt simge metni ekleyebilirsiniz. Aspose.Slides metin çerçevesine üst simge veya alt simge metni eklemek için [**setEscapement**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) metodunu [PortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PortionFormat) sınıfından kullanmanız gerekir.

Bu özellik, üst simge veya alt simge metnini (değer -100% (alt simge) ile 100% (üst simge) arasında) döndürür veya ayarlar. Örneğin:

- [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slaytın indeksini kullanarak bir slayt referansı alın.
- Slayta [Rectangle](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeType#Rectangle) türünde bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) ekleyin.
- [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) ile ilişkili [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrame) öğesine erişin.
- Mevcut Paragrafları temizleyin
- Üst simge metni tutmak için yeni bir paragraf nesnesi oluşturun ve bunu [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrame) içindeki [Paragraphs collection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrame#getParagraphs--) koleksiyonuna ekleyin.
- Yeni bir portion nesnesi oluşturun
- Üst simge eklemek için portion'ın Escapement özelliğini 0 ile 100 arasında ayarlayın. (0 üst simge yok anlamına gelir)
- [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Portion) için bir metin belirleyin ve ardından bunu paragrafın portion koleksiyonuna ekleyin.
- Alt simge metni tutmak için yeni bir paragraf nesnesi oluşturun ve bunu ITextFrame'in IParagraphs koleksiyonuna ekleyin.
- Yeni bir portion nesnesi oluşturun
- Alt simge eklemek için portion'ın Escapement özelliğini 0 ile -100 arasında ayarlayın. (0 alt simge yok anlamına gelir)
- [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Portion) için bir metin belirleyin ve ardından bunu paragrafın portion koleksiyonuna ekleyin.
- Sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımların uygulanması aşağıda verilmiştir.

```javascript
// PPTX'i temsil eden bir Presentation sınıfı oluşturun
var pres = new aspose.slides.Presentation();
try {
    // Slaytı alın
    var slide = pres.getSlides().get_Item(0);
    // Metin kutusu oluşturun
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Üst simge metni için paragraf oluşturun
    var superPar = new aspose.slides.Paragraph();
    // Normal metin içeren bölüm oluşturun
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Üst simge metni içeren bölüm oluşturun
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Alt simge metni için paragraf oluşturun
    var paragraph2 = new aspose.slides.Paragraph();
    // Normal metin içeren bölüm oluşturun
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Alt simge metni içeren bölüm oluşturun
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Paragrafları metin kutusuna ekleyin
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**PDF veya diğer formatlara dışa aktarırken üst simge ve alt simge korunur mu?**

Evet, Aspose.Slides, sunumları PDF, PPT/PPTX, görüntüler ve diğer desteklenen formatlara dışa aktarırken üst simge ve alt simge biçimlendirmesini doğru bir şekilde korur. Özel biçimlendirme tüm çıktı dosyalarında aynı kalır.

**Üst simge ve alt simge, kalın veya italik gibi diğer biçimlendirme stilleriyle birleştirilebilir mi?**

Evet, Aspose.Slides tek bir metin kısmı içinde çeşitli metin stillerini karıştırmanıza izin verir. [PortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portionformat/) içindeki ilgili özellikleri yapılandırarak kalın, italik, alt çizgi ve aynı anda üst simge veya alt simge uygulayabilirsiniz.

**Üst simge ve alt simge biçimlendirmesi tablolar, grafikler veya SmartArt içindeki metinlerde çalışır mı?**

Evet, Aspose.Slides, tablolar ve grafik öğeleri dahil olmak üzere çoğu nesne içinde biçimlendirmeyi destekler. SmartArt ile çalışırken uygun öğelere (örneğin [SmartArtNode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartartnode/)) ve metin kapsayıcılarına erişmeniz ve ardından [PortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portionformat/) özelliklerini benzer şekilde yapılandırmanız gerekir.
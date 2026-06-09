---
title: Java Kullanarak Sunumlarda Üst Simge ve Alt Simge Yönetimi
linktitle: Üst Simge ve Alt Simge
type: docs
weight: 80
url: /tr/java/superscript-and-subscript/
keywords:
- üst simge
- alt simge
- üst simge ekle
- alt simge ekle
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da üst ve alt simgeyi uzmanlaştırın ve sunumlarınızı profesyonel metin biçimlendirme ile maksimum etki için yükseltin."
---
## **Overview**

Aspose.Slides, PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarına üst simge ve alt simge metin ekleme özellikleri sunar. Kimyasal formülleri, matematiksel denklemleri vurgulamanız ya da içeriği dipnotlarla açıklamanız gerektiğinde, bu özel biçimlendirme seçenekleri netlik ve doğruluk sağlar. Bu makalede, üst ve alt simge stillerini sorunsuz bir şekilde nasıl uygulayacağınızı ve her slaytta profesyonel sonuçlar elde edeceğinizi öğreneceksiniz.

## **Üst Simge ve Alt Simge Metnini Yönetme**
Herhangi bir paragraf bölümüne üst veya alt simge metni ekleyebilirsiniz. Aspose.Slides metin çerçevesine Üst Simge veya Alt Simge metni eklemek için [**setEscapement**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) metodunu [PortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/PortionFormat) sınıfından kullanmalısınız.

Bu özellik, üst veya alt simge metnini (-%100 (alt simge) ile %100 (üst simge) arasında bir değer) döndürür veya ayarlar. Örneğin:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Bir slaytın referansını indeksini kullanarak elde edin.
- Slayta [Rectangle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ShapeType#Rectangle) tipinde bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) ekleyin.
- [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) ile ilişkilendirilmiş [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextFrame) öğesine erişin.
- Mevcut Paragrafları temizleyin
- Üst simge metnini tutmak için yeni bir paragraf nesnesi oluşturun ve bunu [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextFrame) içindeki [IParagraphs collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextFrame#getParagraphs--)'e ekleyin.
- Yeni bir bölüm (portion) nesnesi oluşturun
- Üst simge eklemek için bölümün Escapement özelliğini 0 ile 100 arasında ayarlayın. (0, üst simge olmadığını gösterir)
- [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Portion) için bir metin belirleyin ve ardından bu bölümü paragrafın bölüm koleksiyonuna ekleyin.
- Alt simge metnini tutmak için yeni bir paragraf nesnesi oluşturun ve bunu ITextFrame'in IParagraphs koleksiyonuna ekleyin.
- Yeni bir bölüm nesnesi oluşturun
- Alt simge eklemek için bölümün Escapement özelliğini 0 ile -100 arasında ayarlayın. (0, alt simge olmadığını gösterir)
- [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Portion) için bir metin belirleyin ve ardından bu bölümü paragrafın bölüm koleksiyonuna ekleyin.
- Sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımların uygulanması aşağıda verilmiştir.

```java
// PPTX temsil eden bir Presentation sınıfı örneği oluştur
Presentation pres = new Presentation();
try {
    // Slaytı al
    ISlide slide = pres.getSlides().get_Item(0);

    // Metin kutusu oluştur
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Üst simge metni için paragraf oluştur
    IParagraph superPar = new Paragraph();

    // Normal metinle bir bölüm oluştur
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Üst simge metniyle bir bölüm oluştur
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Alt simge metni için paragraf oluştur
    IParagraph paragraph2 = new Paragraph();

    // Normal metinle bir bölüm oluştur
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Alt simge metniyle bir bölüm oluştur
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Paragrafları metin kutusuna ekle
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**PDF veya diğer formatlara dışa aktarırken üst ve alt simge korunacak mı?**

Evet, Aspose.Slides, sunumları PDF, PPT/PPTX, görüntüler ve diğer desteklenen formatlara dışa aktarırken üst ve alt simge biçimlendirmesini doğru bir şekilde korur. Özel biçimlendirme tüm çıktı dosyalarında aynı kalır.

**Üst ve alt simge, kalın veya italik gibi diğer biçimlendirme stilleriyle birleştirilebilir mi?**

Evet, Aspose.Slides tek bir metin bölümünde çeşitli metin stillerini karıştırmanıza izin verir. Kalın, italik, alt çizgi gibi stilleri etkinleştirebilir ve aynı anda üst veya alt simge uygulamak için [PortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portionformat/) sınıfındaki ilgili özellikleri yapılandırabilirsiniz.

**Üst ve alt simge biçimlendirmesi, tablolar, grafikler veya SmartArt içindeki metinlerde çalışır mı?**

Evet, Aspose.Slides tablolar ve grafik öğeleri dahil olmak üzere çoğu nesnede biçimlendirmeyi destekler. SmartArt ile çalışırken, ilgili öğelere (örneğin [SmartArtNode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/smartartnode/)) ve metin kapsayıcılarına erişmeli ve ardından [PortionFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portionformat/) özelliklerini benzer şekilde yapılandırmalısınız.
---
title: Android'de Sunumlarda Üst Simge ve Alt Simge Yönetimi
linktitle: Üst Simge ve Alt Simge
type: docs
weight: 80
url: /tr/androidjava/superscript-and-subscript/
keywords:
- üst simge
- alt simge
- üst simge ekle
- alt simge ekle
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java kullanarak üst simge ve alt simgeyi ustalaştırın ve sunumlarınızı profesyonel metin biçimlendirmesiyle maksimum etki sağlamak için yükseltin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarınıza üst simge ve alt simge metni eklemenize olanak tanıyan özellikler sunar. Kimyasal formülleri, matematiksel denklemleri vurgulamanız veya içeriği dipnotlarla açıklamanız gerekse, bu özel biçimlendirme seçenekleri netlik ve kesinlik sağlar. Bu makalede, üst simge ve alt simge stillerini sorunsuz bir şekilde nasıl uygulayacağınızı ve her slaytta profesyonel sonuçlar elde edeceğinizi öğreneceksiniz.

## **Üst Simge ve Alt Simge Metnini Yönetme**
Herhangi bir paragraf bölümüne üst simge ve alt simge metni ekleyebilirsiniz. Aspose.Slides metin çerçevesinde Üst Simge ya da Alt Simge metni eklemek için [**setEscapement**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) metodunu [PortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PortionFormat) sınıfından kullanmanız gerekir.

Bu özellik, üst simge veya alt simge metnini (değer -%100 (alt simge) ile %100 (üst simge) arasında) döndürür veya ayarlar. Örneğin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Dizini kullanarak bir slaytın referansını alın.
- Slayta [Rectangle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ShapeType#Rectangle) tipinde bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) ekleyin.
- [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) ile ilişkili [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrame)'e erişin.
- Mevcut Paragrafları temizleyin
- Üst simge metni tutacak yeni bir paragraf nesnesi oluşturun ve bunu [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrame)'in [IParagraphs collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITextFrame#getParagraphs--)'ına ekleyin.
- Yeni bir bölüm (portion) nesnesi oluşturun
- Üst simge eklemek için bölümün Escapement özelliğini 0 ile 100 arasında ayarlayın. (0 üst simge yok anlamına gelir)
- [Portion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Portion) için bir metin belirleyin ve ardından bunu paragraftaki bölüm koleksiyonuna ekleyin.
- Alt simge metni tutacak yeni bir paragraf nesnesi oluşturun ve bunu ITextFrame'in IParagraphs koleksiyonuna ekleyin.
- Yeni bir bölüm nesnesi oluşturun
- Alt simge eklemek için bölümün Escapement özelliğini 0 ile -100 arasında ayarlayın. (0 alt simge yok anlamına gelir)
- [Portion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Portion) için bir metin belirleyin ve ardından bunu paragraftaki bölüm koleksiyonuna ekleyin.
- Sunumu PPTX dosyası olarak kaydedin.

```java
// PPTX temsil eden bir Presentation sınıfını örnekleyin
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

**Üst simge ve alt simge PDF ya da diğer formatlara aktarılırken korunur mu?**

Evet, Aspose.Slides sunumları PDF, PPT/PPTX, görüntüler ve diğer desteklenen formatlara aktarırken üst ve alt simge biçimlendirmesini doğru bir şekilde korur. Özel biçimlendirme tüm çıktı dosyalarında değişmeden kalır.

**Üst simge ve alt simge kalın veya italik gibi diğer biçimlendirme stilleriyle birleştirilebilir mi?**

Evet, Aspose.Slides tek bir metin bölümünde çeşitli metin stillerini karıştırmanıza izin verir. Kalın, italik, alt çizgi gibi özellikleri etkinleştirebilir ve aynı anda üst simge ya da alt simge uygulamak için ilgili özellikleri [PortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portionformat/) içinde yapılandırabilirsiniz.

**Üst simge ve alt simge biçimlendirme, tablolar, grafikler veya SmartArt içindeki metinlerde çalışır mı?**

Evet, Aspose.Slides tablolar ve grafik öğeleri gibi çoğu nesnede biçimlendirmeyi destekler. SmartArt ile çalışırken uygun öğelere (ör. [SmartArtNode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/smartartnode/)) ve metin konteynerlerine erişmeniz ve ardından [PortionFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portionformat/) özelliklerini benzer şekilde yapılandırmanız gerekir.
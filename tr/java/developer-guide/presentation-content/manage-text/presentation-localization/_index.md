---
title: Java'da Sunum Yerelleştirmeyi Otomatikleştir
linktitle: Sunum Yerelleştirme
type: docs
weight: 100
url: /tr/java/presentation-localization/
keywords:
- dili değiştir
- imla denetimi
- dil kimliği
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java'da Aspose.Slides kullanarak PowerPoint ve OpenDocument slayt yerelleştirmesini otomatikleştirin, pratik kod örnekleri ve daha hızlı küresel dağıtım için ipuçlarıyla."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir sunumdaki metin için `LanguageId` değerinin nasıl ayarlanacağını açıklar. Bir sunumu nasıl açacağınızı, metin içeren bir şekil ekleyeceğinizi, bir metin bölümüne dil tanımlayıcısı atayacağınızı ve sonucu PPTX dosyası olarak kaydedeceğinizi gösterir.

## **Sunum ve Şekil Metni İçin Dili Değiştirme**
- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Bir slaytın referansını indeksini kullanarak alın.
- Slayta [Rectangle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ShapeType#Rectangle) tipinde bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) ekleyin.
- TextFrame'e bir miktar metin ekleyin.
- Metne Dil Kimliği ayarlama: [Setting Language Id](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-).
- Sunumu PPTX dosyası olarak yazın.

Yukarıdaki adımların uygulanması aşağıdaki örnekte gösterilmiştir.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Dil Kimliği otomatik metin çevirisini tetikler mi?**

Hayır. Aspose.Slides'daki [Language ID](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) yazım denetimi ve dilbilgisi denetimi için dili saklar, ancak metin içeriğini çevirmez veya değiştirmez. Bu, PowerPoint'in denetim için anladığı bir meta veridir.

**Dil Kimliği, işleme sırasında hecelenme ve satır sonlarını etkiler mi?**

Aspose.Slides'da, [language ID](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) denetim içindir. Hecelenme kalitesi ve satır kaydırma büyük ölçüde [uygun yazı tipleri](/slides/tr/java/powerpoint-fonts/) ve yazı sisteminin düzen/satır sonu ayarlarının mevcut olmasına bağlıdır. Doğru işleme sağlamak için gerekli yazı tiplerini kullanılabilir hâle getirin, [yazı tipi ikame kurallarını](/slides/tr/java/font-substitution/) yapılandırın ve/veya sunuma [gömülü yazı tiplerini](/slides/tr/java/embedded-font/) ekleyin.

**Tek bir paragrafta farklı diller ayarlayabilir miyim?**

Evet. [Language ID](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) metin bölümü düzeyinde uygulanır, bu nedenle tek bir paragraf birden çok dili ayrı denetim ayarlarıyla karıştırabilir.
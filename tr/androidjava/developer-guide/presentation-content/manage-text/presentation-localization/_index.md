---
title: Android'de Sunum Yerelleştirmesini Otomatikleştir
linktitle: Sunum Yerelleştirmesi
type: docs
weight: 100
url: /tr/androidjava/presentation-localization/
keywords:
- dili değiştir
- yazım denetimi
- dil kimliği
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Android için Aspose.Slides ile Java'da PowerPoint ve OpenDocument slayt yerelleştirmesini otomatikleştir, pratik kod örnekleri ve daha hızlı global dağıtım için ipuçları kullan."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir sunumdaki metin için `LanguageId`'yi nasıl ayarlayacağınızı açıklar. Bir sunumu nasıl açacağınızı, metin içeren bir şekil ekleyeceğinizi, bir metin bölümüne dil tanımlayıcısı atayacağınızı ve sonucu bir PPTX dosyası olarak kaydedeceğinizi gösterir.

## **Sunum ve Şekil Metni İçin Dili Değiştir**
- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını indeksini kullanarak elde edin.
- Slayta [Rectangle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ShapeType#Rectangle) tipinde bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape) ekleyin.
- TextFrame'e bir miktar metin ekleyin.
- [Setting Language Id](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) ile metne dil kimliği atayın.
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

**Dil kimliği otomatik metin çevirisini tetikler mi?**

Hayır. Aspose.Slides'teki [Language ID](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) yazım denetimi ve dilbilgisi denetimi için dili saklar, ancak metni çevirmez veya içeriğini değiştirmez. PowerPoint'in denetleme amacıyla anlayabileceği bir meta veridir.

**Dil kimliği, işleme sırasında heceleme ve satır sonlarını etkiler mi?**

Aspose.Slides'te [language ID](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) denetleme içindir. Heceleme kalitesi ve satır kaydırma öncelikle [uygun fontların](/slides/tr/androidjava/powerpoint-fonts/) ve yazı sistemi için düzen/satır sonu ayarlarının mevcut olmasına bağlıdır. Doğru render alınması için gerekli fontları sağlayın, [font ikame kurallarını](/slides/tr/androidjava/font-substitution/) yapılandırın ve/veya fontları [gömün](/slides/tr/androidjava/embedded-font/) sunuma.

**Tek bir paragrafta farklı diller ayarlayabilir miyim?**

Evet. [Language ID](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) metin bölümü seviyesinde uygulanır, bu nedenle tek bir paragrafta farklı diller ve ayrı denetleme ayarları karıştırılabilir.
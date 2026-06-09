---
title: JavaScript'te Sunum Yerelleştirmesini Otomatikleştir
linktitle: Sunum Yerelleştirme
type: docs
weight: 100
url: /tr/nodejs-java/presentation-localization/
keywords:
- dil değiştir
- imla denetimi
- dil kimliği
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides kullanarak JavaScript'te PowerPoint ve OpenDocument slayt yerelleştirmesini otomatikleştirin, pratik kod örnekleri ve daha hızlı küresel dağıtım için ipuçlarıyla."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir sunumdaki metnin `LanguageId` değerini nasıl ayarlayacağınızı açıklar. Bir sunumu nasıl açacağınızı, metin içeren bir şekil ekleyeceğinizi, bir metin bölümüne dil tanımlayıcısı atayacağınızı ve sonucu PPTX dosyası olarak kaydedeceğinizi gösterir.

## **Sunum ve Şeklin Metni İçin Dili Değiştir**

- [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
- Index değerini kullanarak bir slaytın referansını alın.  
- [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) [Rectangle](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeType#Rectangle) türünde bir şekil ekleyin.  
- TextFrame’e bir miktar metin ekleyin.  
- Metne **Language Id** ayarını uygulayın.  
- Sunumu PPTX dosyası olarak kaydedin.  

Yukarıdaki adımların uygulaması aşağıdaki örnekte gösterilmiştir.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Dil kimliği otomatik metin çevirisini tetikler mi?**

Hayır. Aspose.Slides'ta [setLanguageId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) imla denetimi ve dilbilgisi denetimi için dili depolar, ancak metni çevremez veya içeriğini değiştirmez. Bu, PowerPoint'in denetim için anlayabildiği bir meta veridir.

**Dil kimliği, render sırasında heceleme ve satır sonlarını etkiler mi?**

Aspose.Slides'ta [setLanguageId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) yalnızca denetim içindir. Heceleme kalitesi ve satır kaydırma çoğunlukla [uygun yazı tipleri](/slides/tr/nodejs-java/powerpoint-fonts/) ve yazı sistemi için layout/satır sonu ayarına bağlıdır. Doğru görüntülenmeyi sağlamak için gerekli yazı tiplerini kullanıma sunun, [yazı tipi ikame kurallarını](/slides/tr/nodejs-java/font-substitution/) yapılandırın ve/veya sunuma [yazı tiplerini gömün](/slides/tr/nodejs-java/embedded-font/).

**Tek bir paragrafta farklı diller ayarlayabilir miyim?**

Evet. [setLanguageId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) metin parçası düzeyinde uygulanır, bu nedenle tek bir paragrafta birden fazla dil ve ayrı denetim ayarı kullanılabilir.
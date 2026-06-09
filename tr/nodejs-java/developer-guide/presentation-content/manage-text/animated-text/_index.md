---
title: PowerPoint Metnini JavaScript ile Animasyonlu Hale Getirin
linktitle: Animasyonlu Metin
type: docs
weight: 60
url: /tr/nodejs-java/animated-text/
keywords:
- animasyonlu metin
- metin animasyonu
- animasyonlu paragraf
- paragraf animasyonu
- animasyon etkisi
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak PowerPoint ve OpenDocument sunumlarında dinamik animasyonlu metin oluşturun, kolay anlaşılır ve optimize edilmiş kod örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde animasyonlu metinle nasıl çalışılacağını, bireysel paragraflara animasyon etkileri uygulayarak ve bir metin çerçevesindeki paragraflara zaten atanmış etkileri alarak açıklar. Sunumda paragraf düzeyinde animasyon eklemek ve mevcut paragraf animasyon etkilerini incelemek için kullanılan API yöntemlerine odaklanır.

## **Paragraflara Animasyon Efektleri Ekleme**

Biz, [**addEffect()**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) metodunu [**Sequence**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Sequence) ve [**Sequence**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Sequence) sınıflarına ekledik. Bu metod, tek bir paragrafına animasyon etkisi eklemenizi sağlar. Aşağıdaki örnek kod, tek bir paragrafına animasyon etkisi eklemeyi gösterir:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // etki eklemek için paragrafı seç
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // seçilen paragrafa Fly animasyon etkisi ekle
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Paragraflardaki Animasyon Efektlerini Alma**

Bir paragrafta eklenen animasyon etkilerini öğrenmek isteyebilirsiniz—örneğin, bir senaryoda, bu etkileri başka bir paragraf veya şekle uygulamayı planladığınız için bir paragraftaki animasyon etkilerini almak isteyebilirsiniz.

Aspose.Slides for Node.js via Java, bir metin çerçevesi (şekil) içinde bulunan paragraflara uygulanan tüm animasyon etkilerini almanıza olanak tanır. Aşağıdaki örnek kod, bir paragraftaki animasyon etkilerini nasıl alacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **SSS**

**Metin animasyonları slayt geçişlerinden nasıl farklıdır ve birleştirilebilir mi?**

Metin animasyonları, bir slayt üzerindeki nesne davranışını zaman içinde kontrol ederken, [transitions](/slides/tr/nodejs-java/slide-transition/) slaytların nasıl değişeceğini kontrol eder. Bunlar bağımsızdır ve birlikte kullanılabilir; oynatma sırası animasyon zaman çizelgesi ve geçiş ayarları tarafından yönetilir.

**PDF veya görüntülere dışa aktarırken metin animasyonları korunur mu?**

Hayır. PDF ve raster görüntüler statiktir, bu nedenle hareket olmadan slaytın tek bir durumunu görürsünüz. Hareketi korumak için [video](/slides/tr/nodejs-java/convert-powerpoint-to-video/) veya [HTML](/slides/tr/nodejs-java/export-to-html5/) dışa aktarmayı kullanın.

**Metin animasyonları düzenlerde ve slayt ana şablonunda çalışır mı?**

Düzen/ana şablon nesnelerine uygulanan etkiler slaytlar tarafından devralınır, ancak bunların zamanlaması ve slayt düzeyindeki animasyonlarla etkileşimi slayttaki son sıralamaya bağlıdır.
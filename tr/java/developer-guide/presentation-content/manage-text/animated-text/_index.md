---
title: Java'da PowerPoint Metnini Canlandırın
linktitle: Canlandırılmış Metin
type: docs
weight: 60
url: /tr/java/animated-text/
keywords:
- canlandırılmış metin
- metin animasyonu
- canlandırılmış paragraf
- paragraf animasyonu
- animasyon efekti
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument sunumlarında dinamik canlandırılmış metin oluşturun, kolay anlaşılır, optimize edilmiş Java kod örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde hareketli metinle çalışmayı, tek tek paragraflara animasyon efektleri uygulayarak ve bir metin çerçevesindeki paragraflara zaten atanmış efektleri alarak açıklar. Sunumda paragraf düzeyinde animasyon eklemek ve mevcut paragraf animasyon efektlerini incelemek için kullanılan API yöntemlerine odaklanır.

## **Paragraflara Animasyon Efektleri Ekleme**

Biz, [**addEffect()**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) metodunu [**Sequence**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Sequence) ve [**ISequence**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISequence) sınıflarına ekledik. Bu metod tek bir paragrafına animasyon efektleri eklemenizi sağlar. Aşağıdaki örnek kod, tek bir paragrafa animasyon efekti eklemeyi gösterir:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // etki eklemek için paragrafı seç
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // seçilen paragrafa Fly animasyon etkisi ekle
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Paragrafların Animasyon Efektlerini Alma**

Bir paragrafa eklenmiş animasyon efektlerini öğrenmek isteyebilirsiniz—örneğin, bir senaryoda bir paragraftaki animasyon efektlerini elde etmek istersiniz çünkü bu efektleri başka bir paragrafa veya şekle uygulamayı planlıyorsunuz.  
Aspose.Slides for Java, bir metin çerçevesinde (şekil) bulunan paragraflara uygulanmış tüm animasyon efektlerini almanıza olanak tanır. Aşağıdaki örnek kod, bir paragraftaki animasyon efektlerini nasıl alacağınızı gösterir:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **SSS**

**Metin animasyonları slayt geçişlerinden nasıl farklıdır ve birleştirilebilirler mi?**  
Metin animasyonları, bir slayt üzerindeki nesnenin zaman içinde davranışını kontrol ederken, [transitions](/slides/tr/java/slide-transition/) slaytların nasıl değiştiğini kontrol eder. Bağımsızdırlar ve birlikte kullanılabilirler; oynatma sırası animasyon zaman çizelgesi ve geçiş ayarları tarafından belirlenir.

**Metin animasyonları PDF veya görüntülere dışa aktarırken korunur mu?**  
Hayır. PDF ve raster görüntüler statiktir, bu yüzden slaytın hareket olmadan tek bir durumunu görürsünüz. Hareketi korumak için [video](/slides/tr/java/convert-powerpoint-to-video/) veya [HTML](/slides/tr/java/export-to-html5/) dışa aktarmasını kullanın.

**Metin animasyonları düzenlerde ve slayt ana tasarımında çalışır mı?**  
Düzen/ana tasarım nesnelerine uygulanan efektler slaytlara miras geçer, ancak zamanlamaları ve slayt düzeyinde animasyonlarla etkileşimleri slayttaki son sıralamaya bağlıdır.
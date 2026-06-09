---
title: Android'de PowerPoint Metnini Canlandırma
linktitle: Canlandırılmış Metin
type: docs
weight: 60
url: /tr/androidjava/animated-text/
keywords:
- canlandırılmış metin
- metin animasyonu
- canlandırılmış paragraf
- paragraf animasyonu
- animasyon efekti
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak PowerPoint ve OpenDocument sunumlarında dinamik canlandırılmış metin oluşturun, kolay izlenebilir, optimize edilmiş Java kod örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta animasyonlu metinle çalışmayı, bireysel paragraflara animasyon efektleri uygulamayı ve bir metin çerçevesindeki paragraflara zaten atanmış efektleri geri almayı açıklar. Sunumda paragraf düzeyinde animasyon eklemek ve mevcut paragraf animasyon efektlerini denetlemek için kullanılan API yöntemlerine odaklanır.

## **Paragraflara Animasyon Efektleri Ekleme**

[**addEffect()**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) metodunu [**Sequence**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Sequence) ve [**ISequence**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISequence) sınıflarına ekledik. Bu metod tek bir paragrafa animasyon efektleri eklemenizi sağlar. Bu örnek kod, tek bir paragrafa animasyon efekti eklemenizi gösterir:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // efekt eklemek için paragrafı seç
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // seçilen paragrafa Uçuş animasyon efekti ekle
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Paragrafların Animasyon Efektlerini Alma**

Bir paragrafta eklenen animasyon efektlerini öğrenmek isteyebilirsiniz — örneğin, bir senaryoda bir paragraftaki animasyon efektlerini elde etmek istersiniz, çünkü bu efektleri başka bir paragraf veya şekle uygulamayı planlıyorsunuz.

Aspose.Slides for Android via Java, bir metin çerçevesi (shape) içinde bulunan paragraflara uygulanan tüm animasyon efektlerini almanıza izin verir. Bu örnek kod, bir paragraftaki animasyon efektlerini nasıl alacağınızı gösterir:

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

**Metin animasyonları slayt geçişlerinden nasıl farklıdır ve birlikte kullanılabilirler mi?**

Metin animasyonları, bir slayttaki nesnenin zaman içinde davranışını kontrol ederken, [transitions](/slides/tr/androidjava/slide-transition/) slaytların nasıl değiştiğini kontrol eder. Bağımsızdırlar ve birlikte kullanılabilir; oynatma sırası animasyon zaman çizelgesi ve geçiş ayarlarıyla belirlenir.

**Metin animasyonları PDF veya görüntülere dışa aktarırken korunur mu?**

Hayır. PDF ve raster görüntüler statiktir, bu yüzden slaydın hareket olmadan tek bir durumunu görürsünüz. Hareketi korumak için [video](/slides/tr/androidjava/convert-powerpoint-to-video/) veya [HTML](/slides/tr/androidjava/export-to-html5/) dışa aktarmayı kullanın.

**Metin animasyonları düzenlerde ve slayt ana tasarımında çalışır mı?**

Düzen/ana tasarım nesnelerine uygulanan efektler slaytlara miras alınır, ancak zamanlamaları ve slayt seviyesindeki animasyonlarla etkileşimleri slayttaki nihai sıralamaya bağlıdır.
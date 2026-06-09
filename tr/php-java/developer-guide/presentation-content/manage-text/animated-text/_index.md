---
title: PHP'de PowerPoint Metnini Canlandır
linktitle: Canlandırılmış Metin
type: docs
weight: 60
url: /tr/php-java/animated-text/
keywords:
- canlandırılmış metin
- metin animasyonu
- canlandırılmış paragraf
- paragraf animasyonu
- animasyon efekti
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlarında dinamik canlandırılmış metin oluşturun, kolay takip edilebilen, optimize edilmiş kod örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde animasyonlu metinle nasıl çalışılacağını, bireysel paragraflara animasyon efektleri uygulayarak ve bir metin çerçevesindeki paragraflara zaten atanmış olan efektleri alarak açıklar. Sunumda paragraf seviyesinde animasyon eklemek ve mevcut paragraf animasyon efektlerini incelemek için kullanılan API yöntemlerine odaklanır.

## **Paragraflara Animasyon Efektleri Ekle**

[**addEffect()**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) metodunu [**Sequence**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Sequence) sınıfına ekledik. Bu metod, tek bir paragrafa animasyon efektleri eklemenizi sağlar. Aşağıdaki örnek kod, tek bir paragrafa animasyon efekti eklemenin nasıl yapılacağını gösterir:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # etkisi eklemek için paragrafı seç
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # seçilen paragrafa Fly animasyon efekti ekle
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Paragrafların Animasyon Efektlerini Al**

Bir paragrafta eklenmiş animasyon efektlerini öğrenmek isteyebilirsiniz—örneğin, bir senaryoda bir paragraftaki animasyon efektlerini elde etmek istersiniz çünkü bu efektleri başka bir paragraf veya şekle uygulamayı planlarsınız.

Aspose.Slides for PHP via Java, bir metin çerçevesi (şekil) içinde bulunan paragraflara uygulanan tüm animasyon efektlerini almanıza olanak tanır. Aşağıdaki örnek kod, bir paragraftaki animasyon efektlerinin nasıl alınacağını gösterir:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **SSS**

**Metin animasyonları slayt geçişlerinden nasıl farklıdır ve birleştirilebilir mi?**

Metin animasyonları, bir slayttaki nesnenin zaman içinde davranışını kontrol ederken, [geçişler](/slides/tr/php-java/slide-transition/) slaytların nasıl değiştiğini kontrol eder. Bağımsızdırlar ve birlikte kullanılabilir; oynatma sırası animasyon zaman çizelgesi ve geçiş ayarları tarafından belirlenir.

**Metin animasyonları PDF veya görüntülere dışa aktarıldığında korunur mu?**

Hayır. PDF ve raster görüntüler statiktir, bu yüzden slaytın hareket olmadan tek bir durumunu görürsünüz. Hareketi korumak için [video](/slides/tr/php-java/convert-powerpoint-to-video/) veya [HTML](/slides/tr/php-java/export-to-html5/) dışa aktarmasını kullanın.

**Metin animasyonları düzenlerde ve slayt ana sayfasında çalışır mı?**

Düzen/ana sayfa nesnelerine uygulanan efektler slaytlara kalıtılır, ancak zamanlamaları ve slayt seviyesindeki animasyonlarla etkileşimleri slayttaki nihai sıraya bağlıdır.
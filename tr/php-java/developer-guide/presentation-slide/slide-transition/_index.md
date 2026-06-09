---
title: PHP Kullanarak Sunularda Slayt Geçişlerini Yönetme
linktitle: Slayt Geçişi
type: docs
weight: 80
url: /tr/php-java/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişi uygula
- gelişmiş slayt geçişi
- morph geçişi
- geçiş türü
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da slayt geçişlerini nasıl özelleştireceğinizi keşfedin; PowerPoint ve OpenDocument sunumları için adım adım rehberlik sunar."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunularda slayt geçişlerini nasıl yöneteceğinizi açıklar. Geçiş türlerini slaytlara nasıl uygulayacağınızı, tıklamayla veya belirli bir süreden sonra ilerleme gibi geçiş davranışını nasıl yapılandıracağınızı, otomatik ilerlemeyi nasıl kontrol edip devre dışı bırakacağınızı, Morph geçişi ve türlerini nasıl kullanacağınızı ve geçiş efekti seçeneklerini nasıl ayarlayacağınızı gösterir. Örnekler, bir sunumu nasıl yükleyeceğinizi veya oluşturacağınızı, seçili slaytlar için geçiş ayarlarını nasıl değiştireceğinizi ve sonucu PPTX dosyası olarak nasıl kaydedeceğinizi gösterir. Makale ayrıca geçiş hızı, geçiş sesleri, aynı geçişin birden çok slayda uygulanması ve bir slaytta şu anda ayarlı geçişin nasıl kontrol edileceği hakkında yaygın soruları yanıtlar.

## **Slayt Geçişi Ekle**
Basit bir slayt geçişi efekti oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Aspose.Slides for PHP via Java tarafından sunulan geçiş efektlerinden birini kullanarak slayda bir Slide Transition Type uygulayın.  
1. Değiştirilmiş sunum dosyasını yazın.

```php
  # Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # 1. slayta daire tipi geçiş uygula
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 2. slayta tarak tipi geçiş uygula
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Sunumu diske yaz
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Gelişmiş Slayt Geçişi Ekle**
Yukarıdaki bölümde yalnızca basit bir geçiş efekti uyguladık. Şimdi bu basit geçişi daha iyi ve kontrol edilebilir hâle getirmek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Aspose.Slides for PHP via Java tarafından sunulan geçiş efektlerinden birini kullanarak slayda bir Slide Transition Type uygulayın.  
1. Geçişi “Tıklamayla İlerle”, belirli bir zaman diliminden sonra veya her ikisine göre ayarlayabilirsiniz.  
1. Geçiş “Tıklamayla İlerle” olarak etkinse, yalnızca fare tıklandığında ilerler. “Belirli Süreden Sonra İlerle” özelliği ayarlanmışsa, belirtilen süre geçtikten sonra geçiş otomatik olarak ilerler.  
1. Değiştirilmiş sunumu bir sunum dosyası olarak yazın.

```php
  # Sunum dosyasını temsil eden Presentation sınıfını örnekle
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # 1. slayta daire tipi geçiş uygula
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 3 saniyelik geçiş süresini ayarla
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # 2. slayta tarak tipi geçiş uygula
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # 5 saniyelik geçiş süresini ayarla
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # 3. slayta yakınlaştırma tipi geçiş uygula
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # 7 saniyelik geçiş süresini ayarla
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Sunumu diske yaz
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Morph Geçişi**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java artık [Morph Geçişi](https://reference.aspose.com/slides/tr/php-java/aspose.slides/morphtransition/) destekliyor. Bu, PowerPoint 2019’da tanıtılan yeni morph geçişini temsil eder.

{{% /alert %}} 

Morph geçişi, bir slayttan sonraki slayta sorunsuz bir hareket animasyonu sağlar. Bu makale, kavramı ve Morph geçişinin nasıl kullanılacağını anlatır. Morph geçişini etkili bir şekilde kullanmak için en az bir ortak nesne içeren iki slayta ihtiyacınız vardır. En kolay yol, slaytı kopyalamak ve ikinci slayttaki nesneyi farklı bir konuma taşımaktır.

Aşağıdaki kod parçacığı, bir metin içeren slaytın bir kopyasını sunuma eklemenizi ve ikinci slayta bir [morph türü](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TransitionType) geçişi ayarlamanızı gösterir.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Morph Geçişi Türleri**
Yeni [TransitionMorphType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TransitionMorphType) enumʼu eklendi. Bu, farklı Morph slayt geçişi türlerini temsil eder.

TransitionMorphType enumʼunun üç üyesi vardır:

- ByObject: Morph geçişi, şekilleri bölünemez nesneler olarak ele alarak gerçekleştirilir.  
- ByWord: Morph geçişi, mümkün olduğunda metni kelimeler halinde aktararak gerçekleştirilir.  
- ByChar: Morph geçişi, mümkün olduğunda metni karakterler halinde aktararak gerçekleştirilir.

Aşağıdaki kod parçacığı, bir slayta morph geçişi ayarlamayı ve morph türünü değiştirmeyi gösterir:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Geçiş Efektlerini Ayarla**
Aspose.Slides for PHP via Java, siyah üzerinden, soldan, sağdan gibi geçiş efektlerini ayarlamayı destekler. Geçiş Efektini ayarlamak için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
- Slayt referansını alın.  
- Geçiş efektini ayarlayın.  
- Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.

Aşağıdaki örnekte geçiş efektleri ayarlanmıştır.

```php
  # Presentation sınıfının bir örneğini oluştur
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Efekti ayarla
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Sunumu diske yaz
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **SSS**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Geçişin [hızını](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/setspeed/) **TransitionSpeed** (yavaş/orta/hızlı) ayarıyla belirleyebilirsiniz.

**Bir geçişe ses ekleyip döngüye alabilir miyim?**

Evet. Geçiş için ses gömebilir ve ses modu ve döngü gibi ayarlarla davranışı kontrol edebilirsiniz (örnek: [setSound](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/setsoundloop/), ayrıca [setSoundIsBuiltIn](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) ve [setSoundName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/setsoundname/) gibi meta veriler).

**Aynı geçişi her slayta en hızlı nasıl uygulayabilirim?**

Her slaydın geçiş ayarlarında istenen geçiş türünü yapılandırın; geçişler slayt başına saklandığından aynı türü tüm slaytlara uygulamak tutarlı bir sonuç verir.

**Bir slaytta şu anda ayarlı geçişin ne olduğunu nasıl kontrol edebilirim?**

Slaydın [geçiş ayarlarını](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/#getSlideShowTransition) inceleyin ve [geçiş türünü](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/settype/) okuyun; bu değer, hangi etkinin uygulandığını tam olarak gösterir.
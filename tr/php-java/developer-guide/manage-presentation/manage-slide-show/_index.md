---
title: PHP'de Slayt Gösterisini Yönet
linktitle: Slayt Gösterisi
type: docs
weight: 90
url: /tr/php-java/manage-slide-show/
keywords:
- gösteri tipi
- konuşmacı tarafından sunulan
- bireysel olarak göz atılan
- kiosk'ta göz atılan
- gösteri seçenekleri
- sürekli döngü
- anlatım olmadan göster
- animasyon olmadan göster
- kalem rengi
- slaytları göster
- özel gösteri
- slaytları ilerlet
- manuel olarak
- zamanlamaları kullanarak
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak slayt gösterilerini nasıl yöneteceğinizi öğrenin. PPT, PPTX ve ODP formatları arasında slayt geçişlerini, zamanlamaları ve daha fazlasını kolayca kontrol edin."
---
## **Giriş**

Microsoft PowerPoint'te **Slide Show** ayarları, profesyonel sunumlar hazırlamak ve sunmak için temel bir araçtır. Bu bölümdeki en önemli özelliklerden biri **Set Up Show**'dır; bu özellik, sunumunuzu belirli koşullara ve izleyicilere göre uyarlamanıza, esneklik ve rahatlık sağlamanıza olanak tanır. Bu özellik sayesinde gösteri tipini (ör. bir konuşmacı tarafından sunulan, bireysel olarak göz atılan veya kiosk'ta göz atılan), döngüyü etkinleştirebilir veya devre dışı bırakabilir, görüntülenecek belirli slaytları seçebilir ve zamanlamaları kullanabilirsiniz. Bu hazırlık adımı, sunumunuzu daha etkili ve profesyonel hale getirmek için kritik öneme sahiptir.

`getSlideShowSettings` bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının metodudur ve bir [SlideShowSettings](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowsettings/) nesnesi döndürür; bu nesne PowerPoint sunumundaki slide show ayarlarını yönetmenizi sağlar. Bu makalede, bu yöntemi kullanarak slide show ayarlarının çeşitli yönlerini nasıl yapılandırıp kontrol edebileceğinizi inceleyeceğiz. 

## **Gösteri Tipini Seç**

`SlideShowSettings->setSlideShowType` slayt gösterisinin tipini tanımlar; bu, aşağıdaki sınıflardan birinin örneği olabilir: [PresentedBySpeaker](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/tr/php-java/aspose.slides/browsedbyindividual/), veya [BrowsedAtKiosk](https://reference.aspose.com/slides/tr/php-java/aspose.slides/browsedatkiosk/). Bu yöntemi kullanarak sunumu otomatik kiosklar veya manuel sunumlar gibi farklı kullanım senaryolarına uyarlayabilirsiniz.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve gösteri tipini "Browsed by an individual" olarak ayarlar, kaydırma çubuğu gösterilmez.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Gösteri Seçeneklerini Etkinleştir**

`SlideShowSettings->setLoop` slayt gösterisinin manuel olarak durdurulana kadar bir döngüde tekrarlanıp tekrarlanmayacağını belirler. Bu, sürekli çalışması gereken otomatik sunumlar için faydalıdır. `SlideShowSettings->setShowNarration` slayt gösterisi sırasında sesli anlatımların çalınıp çalınmayacağını belirler. Bu, izleyiciye sesli rehberlik içeren otomatik sunumlar için yararlıdır. `SlideShowSettings->setShowAnimation` slayt nesnelerine eklenen animasyonların oynatılıp oynatılmayacağını belirler. Bu, sunumun tam görsel etkisini sağlamak için faydalıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt gösterisini döngüye alır.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Gösterilecek Slaytları Seç**

`SlideShowSettings->setSlides` yöntemi, sunum sırasında gösterilecek slayt aralığını seçmenizi sağlar. Bu, sunumun yalnızca bir kısmını göstermeniz gerektiğinde tüm slaytları göstermek yerine faydalıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt aralığını `2` ile `9` arasındaki slaytları gösterecek şekilde ayarlar.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **İleri Slaytları Kullan**

`SlideShowSettings->setUseTimings` yöntemi, her slayt için önceden ayarlanmış zamanlamaların kullanılmasını etkinleştirmenize veya devre dışı bırakmanıza olanak tanır. Bu, önceden tanımlı gösterim süreleriyle slaytların otomatik olarak gösterilmesi için faydalıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve zamanlamaların kullanımını devre dışı bırakır.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Medya Kontrollerini Göster**

`SlideShowSettings->setShowMediaControls` yöntemi, multimedya içeriği (ör. video veya ses) oynatıldığında slayt gösterisi sırasında medya kontrollerinin (oynat, duraklat, dur) görüntülenip görüntülenmeyeceğini belirler. Bu, sunum sırasında sunucuya medya oynatımını kontrol etme imkanı vermek istediğinizde faydalıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve medya kontrollerinin görüntülenmesini etkinleştirir.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **SSS**

**Sunumu doğrudan slayt gösterisi modunda açılacak şekilde kaydedebilir miyim?**

Evet. Dosyayı PPSX veya PPSM olarak kaydedin; bu formatlar PowerPoint'te açıldığında doğrudan slayt gösterisi olarak başlar. Aspose.Slides'te, [during export](/slides/tr/php-java/save-presentation/) sırasında ilgili kaydetme formatını seçin.

**Bireysel slaytları dosyadan silmeden gösteriden hariç tutabilir miyim?**

Evet. Bir slaytı [hidden](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/sethidden/) olarak işaretleyin. Gizli slaytlar sunumda kalır ancak slayt gösterisi sırasında gösterilmez.

**Aspose.Slides bir slayt gösterisini oynatabilir veya ekranda canlı bir sunumu kontrol edebilir mi?**

Hayır. Aspose.Slides sunum dosyalarını düzenler, analiz eder ve dönüştürür; gerçek oynatma, PowerPoint gibi bir görüntüleyici uygulama tarafından yapılır.
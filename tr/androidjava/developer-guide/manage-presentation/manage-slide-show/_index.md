---
title: Android'de Slayt Gösterisini Yönet
linktitle: Slayt Gösterisi
type: docs
weight: 90
url: /tr/androidjava/manage-slide-show/
keywords:
- gösteri türü
- konuşmacı tarafından sunulan
- birey tarafından göz atılan
- kiosk'ta göz atılan
- gösteri seçenekleri
- sürekli döngü
- anlatımsız göster
- animasyonsuz göster
- kalem rengi
- slaytları göster
- özelleştirilmiş gösteri
- slaytları ilerlet
- manuel olarak
- zamanlamaları kullanarak
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android üzerinden Java ile slayt gösterilerini nasıl yöneteceğinizi öğrenin. PPT, PPTX ve ODP formatlarında slayt geçişlerini, zamanlamaları ve daha fazlasını kolaylıkla kontrol edin."
---
## **Giriş**

Microsoft PowerPoint'te, **Slide Show** ayarları, profesyonel sunumları hazırlamak ve sunmak için temel bir araçtır. Bu bölümdeki en önemli özelliklerden biri **Set Up Show**'dur; bu, sunumunuzu belirli koşullara ve izleyicilere göre özelleştirmenizi sağlar ve esneklik ile rahatlık sunar. Bu özellik sayesinde gösteri tipini seçebilir (ör. konuşmacı tarafından sunulan, birey tarafından göz atılan veya kiosk’da göz atılan), döngüyü etkinleştirebilir veya devre dışı bırakabilir, gösterilecek belirli slaytları seçebilir ve zamanlamaları kullanabilirsiniz. Hazırlık aşamasındaki bu adım, sunumunuzu daha etkili ve profesyonel hâle getirmek için çok önemlidir.

`getSlideShowSettings`, bir PowerPoint sunumunda slayt gösterisi ayarlarını yönetmenizi sağlayan, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir yöntemi olup, [SlideShowSettings](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowsettings/) tipinde bir nesne döndürür. Bu makalede, bu yöntemi kullanarak slayt gösterisi ayarlarının çeşitli yönlerini nasıl yapılandırıp kontrol edebileceğimizi inceleyeceğiz. 

## **Gösteri Tipini Seç**

`SlideShowSettings.setSlideShowType`, slayt gösterisinin tipini tanımlar ve aşağıdaki sınıflardan bir örnek olabilir: [PresentedBySpeaker](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/browsedbyindividual/), veya [BrowsedAtKiosk](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/browsedatkiosk/). Bu yöntemi kullanarak sunumu otomatik kiosklar veya manuel sunumlar gibi farklı kullanım senaryolarına uyarlayabilirsiniz.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve kaydırma çubuğu gösterilmeden gösteri tipini "Browsed by an individual" olarak ayarlar.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gösteri Seçeneklerini Etkinleştir**

`SlideShowSettings.setLoop`, slayt gösterisinin manuel olarak durdurulana kadar bir döngüde tekrar edip etmeyeceğini belirler. Bu, sürekli çalışması gereken otomatik sunumlar için faydalıdır.  
`SlideShowSettings.setShowNarration`, slayt gösterisi sırasında sesli anlatımların çalınıp çalınmayacağını belirler. Bu, izleyicilere sesli rehberlik içeren otomatik sunumlar için faydalıdır.  
`SlideShowSettings.setShowAnimation`, slayt nesnelerine eklenen animasyonların oynatılıp oynatılmayacağını belirler. Bu, sunumun tam görsel etkisini sağlamak için faydalıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt gösterisini döngüye alır.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gösterilecek Slaytları Seç**

`SlideShowSettings.setSlides` yöntemi, sunum sırasında gösterilecek slayt aralığını seçmenize olanak tanır. Bu, tüm slaytları göstermek yerine yalnızca sunumun bir kısmını göstermeniz gerektiğinde faydalıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt aralığını `2` ile `9` arasındaki slaytları gösterecek şekilde ayarlar.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **İleri Slaytları Kullan**

`SlideShowSettings.setUseTimings` yöntemi, her slayt için önceden belirlenmiş zamanlamaların kullanılmasını etkinleştirip devre dışı bırakmanıza olanak tanır. Bu, önceden tanımlanmış gösterim sürelerine sahip slaytların otomatik olarak gösterilmesi için faydalıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve zamanlamaların kullanımını devre dışı bırakır.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Medya Kontrollerini Göster**

`SlideShowSettings.setShowMediaControls` yöntemi, multimedya içeriği (ör. video veya ses) oynatıldığında slayt gösterisi sırasında medya kontrollerinin (oynat, duraklat, dur) gösterilip gösterilmeyeceğini belirler. Bu, sunum sırasında sunucuya medya oynatımı üzerinde kontrol sağlamak istediğinizde faydalıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve medya kontrollerinin gösterilmesini etkinleştirir.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **SSS**

**Sunumu doğrudan slayt gösterisi modunda açılacak şekilde kaydedebilir miyim?**

Evet. Dosyayı PPSX veya PPSM olarak kaydedin; bu formatlar PowerPoint'te açıldığında doğrudan slayt gösterisi olarak başlar. Aspose.Slides'te, ilgili kaydetme formatını [dışa aktarım sırasında](/slides/tr/androidjava/save-presentation/) seçin.

**Tek tek slaytları dosyadan silmeden gösteriden hariç tutabilir miyim?**

Evet. Bir slaytı [gizli](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#setHidden-boolean-) olarak işaretleyin. Gizli slaytlar sunumda kalır ancak slayt gösterisi sırasında gösterilmez.

**Aspose.Slides bir slayt gösterisini oynatabilir veya ekranda canlı bir sunumu kontrol edebilir mi?**

Hayır. Aspose.Slides sunum dosyalarını düzenler, analiz eder ve dönüştürür; gerçek oynatma, PowerPoint gibi bir görüntüleyici uygulama tarafından gerçekleştirilir.
---
title: Java'da Slayt Gösterisini Yönet
linktitle: Slayt Gösterisi
type: docs
weight: 90
url: /tr/java/manage-slide-show/
keywords:
- gösteri tipi
- konuşmacı tarafından sunulan
- bireysel olarak gözatılan
- kiosk'ta gözatılan
- gösteri seçenekleri
- sürekli döngü
- anlatımsız göster
- animasyonsuz göster
- kalem rengi
- slaytları göster
- özel gösteri
- slaytları ilerlet
- manuel olarak
- zamanlamaları kullanma
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da slayt gösterilerini nasıl yöneteceğinizi öğrenin. PPT, PPTX ve ODP formatlarında slayt geçişlerini, zamanlamaları ve daha fazlasını kolayca kontrol edin."
---
## **Giriş**

Microsoft PowerPoint'te, **Slide Show** ayarları profesyonel sunumları hazırlama ve sunma için temel bir araçtır. Bu bölümdeki en önemli özelliklerden biri **Set Up Show**'dur; bu özellik sunumunuzu belirli koşullara ve izleyicilere göre özelleştirmenizi sağlar, esneklik ve kullanım kolaylığı sunar. Bu özellik sayesinde gösteri tipini seçebilir (ör. bir konuşmacı tarafından sunulan, bireysel olarak gözatılan veya kiosk'ta gözatılan), döngüyü etkinleştirebilir veya devre dışı bırakabilir, görüntülenecek belirli slaytları seçebilir ve zamanlamaları kullanabilirsiniz. Bu hazırlık adımı, sunumunuzu daha etkili ve profesyonel hale getirmek için çok önemlidir.

`getSlideShowSettings` is a method of the [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) class that returns an object of type [SlideShowSettings](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowsettings/), which allows you to manage the slide show settings in a PowerPoint presentation. In this article, we will explore how to use this method to configure and control various aspects of slide show settings. 

## **Gösteri Türünü Seç**

`SlideShowSettings.setSlideShowType` slayt gösterisinin tipini tanımlar; bu tip aşağıdaki sınıflardan birinin örneği olabilir: [PresentedBySpeaker](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/tr/java/com.aspose.slides/browsedbyindividual/), veya [BrowsedAtKiosk](https://reference.aspose.com/slides/tr/java/com.aspose.slides/browsedatkiosk/). Bu yöntemi kullanarak sunumu otomatik kiosklar veya manuel sunumlar gibi farklı kullanım senaryolarına uyarlayabilirsiniz.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve gösteri tipini kaydırma çubuğu gösterilmeden "Browsed by an individual" olarak ayarlar.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gösteri Seçeneklerini Etkinleştir**

`SlideShowSettings.setLoop` slayt gösterisinin manuel olarak durdurulana kadar döngüde tekrarlanıp tekrarlanmayacağını belirler. Bu, sürekli çalışması gereken otomatik sunumlar için kullanışlıdır. `SlideShowSettings.setShowNarration` slayt gösterisi sırasında sesli anlatımların çalınıp çalınmayacağını belirler. Bu, izleyicilere sesli rehberlik içeren otomatik sunumlar için faydalıdır. `SlideShowSettings.setShowAnimation` slayt nesnelerine eklenen animasyonların oynatılıp oynatılmayacağını belirler. Bu, sunumun tam görsel etkisini sağlamak için yararlıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt gösterisini döngüye alır.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gösterilecek Slaytları Seç**

`SlideShowSettings.setSlides` yöntemi, sunum sırasında gösterilecek slayt aralığını seçmenizi sağlar. Bu, tüm slaytları göstermek yerine yalnızca sunumun bir kısmını göstermek istediğinizde kullanışlıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt aralığını `2` ile `9` arasındaki slaytlar olarak ayarlar.

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

`SlideShowSettings.setUseTimings` yöntemi, her slayt için önceden belirlenmiş zamanlamaların kullanımını etkinleştirmenizi veya devre dışı bırakmanızı sağlar. Bu, önceden tanımlanmış görüntüleme süreleriyle slaytların otomatik olarak gösterilmesi için kullanışlıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve zamanlamaların kullanımını devre dışı bırakır.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Medya Kontrollerini Göster**

`SlideShowSettings.setShowMediaControls` yöntemi, çoklu ortam içeriği (ör. video veya ses) oynatıldığında slayt gösterisi sırasında medya kontrollerinin (oynat, duraklat, durdur gibi) gösterilip gösterilmeyeceğini belirler. Bu, sunum sırasında sunucuya medya çalma üzerinde kontrol vermek istediğinizde kullanışlıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve medya kontrollerinin gösterilmesini etkinleştirir.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **SSS**

**Bir sunumu doğrudan slayt gösterisi modunda açılacak şekilde kaydedebilir miyim?**

Evet. Dosyayı PPSX veya PPSM formatında kaydedin; bu formatlar PowerPoint'te açıldığında doğrudan slayt gösterisi olarak başlatılır. Aspose.Slides'te, ilgili kaydetme formatını [ihracat sırasında](/slides/tr/java/save-presentation/) seçin.

**Bireysel slaytları dosyadan silmeden gösteriden çıkartabilir miyim?**

Evet. Bir slaytı [gizli](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#setHidden-boolean-) olarak işaretleyin. Gizli slaytlar sunumda kalır ancak slayt gösterisi sırasında gösterilmez.

**Aspose.Slides bir slayt gösterisini oynatabilir veya ekrandaki canlı bir sunumu kontrol edebilir mi?**

Hayır. Aspose.Slides, sunum dosyalarını düzenler, analiz eder ve dönüştürür; gerçek oynatma PowerPoint gibi bir görüntüleyici uygulama tarafından gerçekleştirilir.
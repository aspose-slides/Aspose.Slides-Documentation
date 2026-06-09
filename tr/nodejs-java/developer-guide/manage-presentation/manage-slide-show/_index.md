---
title: JavaScript'te Slayt Gösterisini Yönet
linktitle: Slayt Gösterisi
type: docs
weight: 90
url: /tr/nodejs-java/manage-slide-show/
keywords:
- gösteri türü
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
- zamanlamaları kullanarak
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile JavaScript'te slayt gösterilerini yönetin. PPT, PPTX ve ODP formatlarında slayt geçişlerini, zamanlamaları ve daha fazlasını kolaylıkla kontrol edin."
---
## **Giriş**

Microsoft PowerPoint'te, **Slayt Gösterisi** ayarları profesyonel sunumları hazırlamak ve sunmak için kilit bir araçtır. Bu bölümdeki en önemli özelliklerden biri **Set Up Show**'dur; bu özellik, sunumunuzu belirli koşullara ve izleyicilere göre özelleştirmenize, esneklik ve kullanım kolaylığı sağlamanıza olanak tanır. Bu özellik sayesinde gösteri türünü (örneğin, bir konuşmacı tarafından sunulan, bireysel olarak gözatılan ya da kiosk modunda gözatılan), döngüyü etkinleştirip devre dışı bırakmayı, gösterilecek belirli slaytları seçmeyi ve zamanlamaları kullanmayı seçebilirsiniz. Bu hazırlık adımı, sunumunuzu daha etkili ve profesyonel hâle getirmek için kritiktir.

`getSlideShowSettings` bir [Sunum](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının yöntemidir ve bir [SlideShowSettings](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowsettings/) nesnesi döndürür; bu nesne PowerPoint sunumundaki slayt gösterisi ayarlarını yönetmenizi sağlar. Bu makalede, bu yöntemi kullanarak slayt gösterisi ayarlarının çeşitli yönlerini nasıl yapılandırıp kontrol edeceğimizi inceleyeceğiz. 

## **Gösteri Türünü Seçin**

`SlideShowSettings.setSlideShowType` slayt gösterisinin türünü tanımlar; bu, aşağıdaki sınıflardan birinin örneği olabilir: [PresentedBySpeaker](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/browsedbyindividual/), veya [BrowsedAtKiosk](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/browsedatkiosk/). Bu yöntemi kullanarak sunumu farklı kullanım senaryolarına uyarlayabilirsiniz; örneğin otomatik kiosklarda veya manuel sunumlarda.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve gösteri türünü “Bireysel olarak gözatılan” olarak ayarlar, kaydırma çubuğu gösterilmez.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Gösteri Seçeneklerini Etkinleştir**

`SlideShowSettings.setLoop` slayt gösterisinin manuel olarak durdurulana kadar döngüde tekrarlanıp tekrarlanmayacağını belirler. Bu, sürekli çalışması gereken otomatik sunumlar için kullanışlıdır. `SlideShowSettings.setShowNarration` slayt gösterisi sırasında sesli anlatımların çalınıp çalınmayacağını belirler; sesli rehber içeren otomatik sunumlar için faydalıdır. `SlideShowSettings.setShowAnimation` slayt nesnelerine eklenen animasyonların oynatılıp oynatılmayacağını belirler; bu, sunumun tam görsel etkisini sağlamak için gereklidir.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt gösterisini döngüye alır.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Gösterilecek Slaytları Seçin**

`SlideShowSettings.setSlides` yöntemi, sunum sırasında gösterilecek slayt aralığını seçmenizi sağlar. Bu, tüm slaytlar yerine yalnızca sunumun belirli bir kısmını göstermeniz gerektiğinde kullanışlıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt aralığını `2` ile `9` arasındaki slaytları gösterecek şekilde ayarlar.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Slayt İlerlemesini Kullan**

`SlideShowSettings.setUseTimings` yöntemi, her slayt için önceden ayarlanmış zamanlamaların kullanılmasını etkinleştirir veya devre dışı bırakır. Bu, önceden tanımlanmış gösterim süreleriyle slaytların otomatik olarak ilerlemesini sağlamak için faydalıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve zamanlamaların kullanımını devre dışı bırakır.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Medya Kontrollerini Göster**

`SlideShowSettings.setShowMediaControls` yöntemi, multimedya içeriği (ör. video veya ses) oynatıldığında slayt gösterisi sırasında medya kontrollerinin (oynat, duraklat, durdur vb.) gösterilip gösterilmeyeceğini belirler. Bu, sunum sırasında sunucuya medya oynatımı üzerinde kontrol sağlamak istediğinizde kullanışlıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve medya kontrollerinin gösterilmesini etkinleştirir.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **SSS**

**Bir sunumu doğrudan slayt gösterisi modunda açılacak şekilde kaydedebilir miyim?**

Evet. Dosyayı PPSX veya PPSM olarak kaydedin; bu formatlar PowerPoint'te açıldığında doğrudan slayt gösterisi başlatır. Aspose.Slides'te, ilgili kaydetme formatını [dışa aktarım sırasında](/slides/tr/nodejs-java/save-presentation/) seçin.

**Bireysel slaytları dosyadan silmeden gösteriden hariç tutabilir miyim?**

Evet. Bir slaytı [gizli](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/sethidden/) olarak işaretleyin. Gizli slaytlar sunumda kalır ancak slayt gösterisi sırasında gösterilmez.

**Aspose.Slides bir slayt gösterisini oynatabilir veya ekranda canlı bir sunumu kontrol edebilir mi?**

Hayır. Aspose.Slides sunum dosyalarını düzenler, analiz eder ve dönüştürür; gerçek oynatma PowerPoint gibi bir görüntüleyici uygulama tarafından yapılır.
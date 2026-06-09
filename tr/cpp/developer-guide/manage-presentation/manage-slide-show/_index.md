---
title: "C++'ta Slayt Gösterisini Yönet"
linktitle: "Slayt Gösterisi"
type: docs
weight: 90
url: /tr/cpp/manage-slide-show/
keywords:
- "gösteri tipi"
- "konuşmacı tarafından sunulan"
- "birey tarafından gözatılan"
- "kioskte gözatılan"
- "gösteri seçenekleri"
- "sürekli döngü"
- "anlatım olmadan göster"
- "animasyon olmadan göster"
- "kalem rengi"
- "slaytları göster"
- "özel gösteri"
- "slaytları ilerlet"
- "manuel"
- "zamanlamalar kullanılarak"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++'ta slayt gösterilerini nasıl yöneteceğinizi öğrenin. PPT, PPTX ve ODP formatlarında slayt geçişlerini, zamanlamaları ve daha fazlasını kolayca kontrol edin."
---
## **Giriş**

Microsoft PowerPoint'te **Slayt Sunumu** ayarları, profesyonel sunumları hazırlama ve sunma konusunda temel bir araçtır. Bu bölümdeki en önemli özelliklerden biri **Sunumu Ayarla**dır; bu özellik, sunumunuzu belirli koşullara ve izleyicilere göre özelleştirmenizi sağlayarak esneklik ve rahatlık sunar. Bu özellik sayesinde gösteri türünü (ör. konuşmacı tarafından sunulan, birey tarafından gözatılan veya kioskte gözatılan), döngüyü etkinleştirip devre dışı bırakmayı, gösterilecek belirli slaytları seçmeyi ve zamanlamaları kullanmayı seçebilirsiniz. Bu hazırlık adımı, sunumunuzu daha etkili ve profesyonel hale getirmek için kritiktir.

`get_SlideShowSettings` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir metodudur ve bir [SlideShowSettings](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slideshowsettings/) nesnesi döndürür; bu sayede PowerPoint sunumundaki slayt gösterisi ayarlarını yönetebilirsiniz. Bu makalede, bu yöntemi kullanarak slayt gösterisi ayarlarının çeşitli yönlerini nasıl yapılandırıp kontrol edeceğinizi inceleyeceğiz. 

## **Gösteri Tipini Seç**

`SlideShowSettings.set_SlideShowType` slayt gösterisinin tipini tanımlar ve aşağıdaki sınıflardan birinin örneği olabilir: [PresentedBySpeaker](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/tr/cpp/aspose.slides/browsedbyindividual/) veya [BrowsedAtKiosk](https://reference.aspose.com/slides/tr/cpp/aspose.slides/browsedatkiosk/). Bu yöntemi kullanarak sunumu, otomatik kiosklar veya manuel sunumlar gibi farklı kullanım senaryolarına uyarlayabilirsiniz.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve gösteri tipini “Birey tarafından gözatılan” olarak ayarlar, kaydırma çubuğunu göstermez.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gösteri Seçeneklerini Etkinleştir**

`SlideShowSettings.set_Loop`, slayt gösterisinin manuel olarak durdurulana kadar döngüde tekrarlanıp tekrarlanmayacağını belirler. Bu, sürekli çalışması gereken otomatik sunumlar için faydalıdır. `SlideShowSettings.set_ShowNarration`, slayt gösterisi sırasında sesli anlatımların çalınıp çalınmayacağını belirler. İzleyicilere sesli rehberlik içeren otomatik sunumlar için kullanışlıdır. `SlideShowSettings.set_ShowAnimation`, slayt nesnelerine eklenen animasyonların oynatılıp oynatılmayacağını belirler. Bu, sunumun tam görsel etkisini sağlamak için faydalıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt gösterisini döngüye alır.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gösterilecek Slaytları Seç**

`SlideShowSettings.set_Slides` yöntemi, sunum sırasında gösterilecek slayt aralığını seçmenizi sağlar. Bu, tüm slaytları değil yalnızca sunumun bir bölümünü göstermek istediğinizde kullanışlıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt aralığını `2` ile `9` arasındaki slaytları gösterecek şekilde ayarlar.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Slayt Zamanlamasını Kullan**

`SlideShowSettings.set_UseTimings` yöntemi, her slayt için önceden belirlenmiş zamanlamaların kullanılıp kullanılmayacağını etkinleştirir veya devre dışı bırakır. Bu, önceden tanımlanmış gösterim süreleriyle slaytların otomatik olarak gösterilmesi için faydalıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve zamanlamaların kullanımını devre dışı bırakır.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Medya Kontrollerini Göster**

`SlideShowSettings.set_ShowMediaControls` yöntemi, çoklu ortam içeriği (ör. video veya ses) oynatıldığında slayt gösterisi sırasında medya kontrollerinin (oynat, duraklat, durdur gibi) gösterilip gösterilmeyeceğini belirler. Bu, sunum sırasında sunucuya medya oynatımı üzerinde kontrol sağlamak istediğinizde faydalıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve medya kontrollerinin gösterilmesini etkinleştirir.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Bir sunumu doğrudan slayt gösterisi modunda açılacak şekilde kaydedebilir miyim?**

Evet. Dosyayı PPSX veya PPSM olarak kaydedin; bu formatlar PowerPoint’te açıldığında doğrudan slayt gösterisi modunda başlar. Aspose.Slides'te, uygun kaydetme formatını [dışa aktarım sırasında](/slides/tr/cpp/save-presentation/) seçin.

**Bireysel slaytları dosyadan silmeden gösteriden çıkarabilir miyim?**

Evet. Bir slaytı [gizli](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/set_hidden/) olarak işaretleyin. Gizli slaytlar sunumda kalır ancak slayt gösterisi sırasında gösterilmez.

**Aspose.Slides bir slayt gösterisini oynatabilir veya ekranda canlı bir sunumu kontrol edebilir mi?**

Hayır. Aspose.Slides sunum dosyalarını düzenler, analiz eder ve dönüştürür; gerçek oynatma işlemi PowerPoint gibi bir görüntüleyici uygulama tarafından gerçekleştirilir.
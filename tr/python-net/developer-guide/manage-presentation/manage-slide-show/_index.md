---
title: Python'da Slayt Gösterisini Yönet
linktitle: Slayt Gösterisi
type: docs
weight: 90
url: /tr/python-net/manage-slide-show/
keywords:
- gösteri türü
- konuşmacı tarafından sunulan
- birey tarafından göz atılan
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile slayt gösterilerini nasıl yöneteceğinizi öğrenin. PPT, PPTX ve ODP formatlarında slayt geçişlerini, zamanlamaları ve daha fazlasını kolaylıkla kontrol edin."
---
## **Giriş**

Microsoft PowerPoint'te, **Slide Show** ayarları profesyonel sunumları hazırlamak ve sunmak için temel bir araçtır. Bu bölümdeki en önemli özelliklerden biri **Set Up Show**'dır; bu özellik, sunumunuzu belirli koşullara ve izleyicilere göre özelleştirmenizi sağlar, esneklik ve kullanım kolaylığı sunar. Bu özellik sayesinde gösteri türünü seçebilirsiniz (ör. bir konuşmacı tarafından sunulan, bir birey tarafından göz atılan veya bir kioskte göz atılan), döngüyü açıp kapatabilir, gösterilecek belirli slaytları seçebilir ve zamanlamaları kullanabilirsiniz. Bu hazırlık adımı, sunumunuzu daha etkili ve profesyonel hâle getirmek için çok önemlidir.

`slide_show_settings` bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının özelliğidir ve [SlideShowSettings](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slideshowsettings/) tipindedir; bu özellik, PowerPoint sunumundaki slide show ayarlarını yönetmenizi sağlar. Bu makalede, bu özelliği kullanarak slide show ayarlarının çeşitli yönlerini nasıl yapılandırıp kontrol edeceğinizi inceleyeceğiz. 

## **Gösteri Türünü Seç**

`SlideShowSettings.slide_show_type` slide show türünü tanımlar ve aşağıdaki sınıflardan bir örnek olabilir: [PresentedBySpeaker](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/tr/python-net/aspose.slides/browsedbyindividual/), veya [BrowsedAtKiosk](https://reference.aspose.com/slides/tr/python-net/aspose.slides/browsedatkiosk/). Bu özelliği kullanarak sunumu otomatik kiosklar veya manuel sunumlar gibi farklı kullanım senaryolarına uyarlayabilirsiniz.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve gösteri tipini kaydırma çubuğu göstermeden "Browsed by an individual" olarak ayarlar.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gösteri Seçeneklerini Etkinleştir**

`SlideShowSettings.loop`, slide show'un manuel olarak durdurulana kadar döngü içinde tekrarlanıp tekrarlanmayacağını belirler. Bu, sürekli çalışması gereken otomatik sunumlar için kullanışlıdır. `SlideShowSettings.show_narration`, slide show sırasında sesli anlatımların çalınıp çalınmayacağını belirler. Bu, izleyiciye sesli rehberlik içeren otomatik sunumlar için faydalıdır. `SlideShowSettings.show_animation`, slayt nesnelerine eklenen animasyonların oynatılıp oynatılmayacağını belirler. Bu, sunumun tam görsel etkisini sağlamak için yararlıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve slide show'u döngüye alır.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gösterilecek Slaytları Seç**

`SlideShowSettings.slides` özelliği, sunum sırasında gösterilecek slayt aralığını seçmenizi sağlar. Bu, tüm slaytları göstermek yerine yalnızca sunumun bir kısmını göstermeniz gerektiğinde kullanışlıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve gösterilecek slayt aralığını `2` ile `9` arasına ayarlar.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **İleri Slaytları Kullan**

`SlideShowSettings.use_timings` özelliği, her slayt için önceden ayarlanmış zamanlamaların kullanılmasını etkinleştirmenizi veya devre dışı bırakmanızı sağlar. Bu, önceden tanımlanmış gösterim süreleriyle slaytların otomatik olarak gösterilmesi için kullanışlıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve zamanlamaların kullanımını devre dışı bırakır.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Medya Kontrollerini Göster**

`SlideShowSettings.show_media_controls` özelliği, multimedya içeriği (ör. video veya ses) oynatıldığında slide show sırasında medya kontrollerinin (oynat, duraklat, dur) gösterilip gösterilmeyeceğini belirler. Bu, sunum sırasında sunucuya medya oynatımı üzerinde kontrol vermek istediğinizde kullanışlıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve medya kontrollerinin gösterilmesini etkinleştirir.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir sunumu doğrudan slide show modunda açılacak şekilde kaydedebilir miyim?**

Evet. Dosyayı PPSX veya PPSM olarak kaydedin; bu formatlar PowerPoint'te açıldığında doğrudan slide show olarak başlar. Aspose.Slides'te, ilgili kaydetme formatını [dışa aktarım sırasında](/slides/tr/python-net/save-presentation/) seçin.

**Dosyadan silmeden tek tek slaytları gösteriden hariç tutabilir miyim?**

Evet. Bir slaytı [gizli](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/hidden/) olarak işaretleyin. Gizli slaytlar sunumda kalır ancak slide show sırasında gösterilmez.

**Aspose.Slides bir slide show'u oynatabilir veya ekrandaki canlı bir sunumu kontrol edebilir mi?**

Hayır. Aspose.Slides sunum dosyalarını düzenler, analiz eder ve dönüştürür; gerçek oynatma PowerPoint gibi bir görüntüleyici uygulama tarafından yönetilir.
---
title: .NET içinde Slayt Gösterisini Yönetme
linktitle: Slayt Gösterisi
type: docs
weight: 90
url: /tr/net/manage-slide-show/
keywords:
- gösteri türü
- konuşmacı tarafından sunulan
- bireysel olarak göz atılan
- kiosk’da göz atılan
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile slayt gösterilerini nasıl yöneteceğinizi öğrenin. PPT, PPTX ve ODP formatlarında slayt geçişlerini, zamanlamaları ve daha fazlasını kolaylıkla kontrol edin."
---
## **Giriş**

Microsoft PowerPoint’te **Slide Show** ayarları, profesyonel sunumları hazırlamak ve sunmak için temel bir araçtır. Bu bölümdeki en önemli özelliklerden biri **Set Up Show**’dır; bu özellik, sunumunuzu belirli koşullara ve izleyicilere göre özelleştirmenizi sağlar ve esneklik ve kullanım kolaylığı sunar. Bu özellik sayesinde gösteri türünü (ör. bir konuşmacı tarafından sunulan, bireysel olarak göz atılan veya kiosk’da göz atılan), döngüyü etkinleştirme veya devre dışı bırakma, görüntülenecek belirli slaytları seçme ve zamanlamaları kullanma gibi seçenekleri belirleyebilirsiniz. Bu hazırlık adımı, sunumunuzu daha etkili ve profesyonel hâle getirmek için kritiktir.

`SlideShowSettings` bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının özelliğidir ve [SlideShowSettings](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slideshowsettings/) tipindedir; bu sayede PowerPoint sunumundaki slayt gösterisi ayarlarını yönetebilirsiniz. Bu makalede, bu özelliği kullanarak slayt gösterisi ayarlarının çeşitli yönlerini nasıl yapılandırıp kontrol edeceğimizi inceleyeceğiz. 

## **Gösteri Türünü Seçme**

`SlideShowSettings.SlideShowType`, slayt gösterisinin türünü tanımlar ve aşağıdaki sınıflardan birinin örneği olabilir: [PresentedBySpeaker](https://reference.aspose.com/slides/tr/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/tr/net/aspose.slides/browsedbyindividual/), veya [BrowsedAtKiosk](https://reference.aspose.com/slides/tr/net/aspose.slides/browsedatkiosk/). Bu özelliği kullanarak sunumu otomatik kiosk’lar veya manuel sunumlar gibi farklı kullanım senaryolarına uyarlayabilirsiniz.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve gösteri türünü “Bireysel olarak göz atılan” olarak ayarlar, kaydırma çubuğunu göstermez.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Gösteri Seçeneklerini Etkinleştirme**

`SlideShowSettings.Loop`, slayt gösterisinin manuel olarak durdurulana kadar döngüde tekrarlanıp tekrarlanmayacağını belirler. Bu, sürekli çalışması gereken otomatik sunumlar için faydalıdır. `SlideShowSettings.ShowNarration`, slayt gösterisi sırasında sesli anlatımın çalınıp çalınmayacağını belirler; izleyiciye sesli rehberlik sağlayan otomatik sunumlar için kullanışlıdır. `SlideShowSettings.ShowAnimation`, slayt nesnelerine eklenen animasyonların oynatılıp oynatılmayacağını belirler; bu, sunumun tam görsel etkisini vermek için önemlidir.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt gösterisini döngüye alır.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Gösterilecek Slaytları Seçme**

`SlideShowSettings.Slides` özelliği, sunum sırasında gösterilecek slayt aralığını seçmenizi sağlar. Bu, tüm slaytlar yerine yalnızca sunumun belirli bir kısmını göstermek istediğinizde faydalıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve slayt aralığını `2`‑`9` arasındaki slaytları gösterecek şekilde ayarlar.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Zamanlamaları Kullanma**

`SlideShowSettings.UseTimings` özelliği, her slayt için önceden ayarlanmış zamanlamaların kullanılmasını etkinleştirir veya devre dışı bırakır. Bu, slaytların tanımlı görüntüleme süreleriyle otomatik olarak gösterilmesini sağlamak için kullanışlıdır. Aşağıdaki kod örneği yeni bir sunum oluşturur ve zamanlamaların kullanılmasını devre dışı bırakır.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Medya Kontrollerini Gösterme**

`SlideShowSettings.ShowMediaControls` özelliği, slayt gösterisi sırasında multimedya içeriği (ör. video veya ses) oynatıldığında medya kontrollerinin (oynat, duraklat, durdur vb.) gösterilip gösterilmeyeceğini belirler. Bu, sunum sırasında sunucuya medya oynatımını kontrol etme imkanı vermek istediğinizde faydalıdır.

Aşağıdaki kod örneği yeni bir sunum oluşturur ve medya kontrollerinin gösterilmesini etkinleştirir.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **SSS**

**Bir sunumu doğrudan slayt gösterisi modunda açılacak şekilde kaydedebilir miyim?**

Evet. Dosyayı PPSX veya PPSM olarak kaydedin; bu formatlar PowerPoint’te açıldığında doğrudan slayt gösterisi olarak başlar. Aspose.Slides’te, çıktıyı [dışa aktarırken](/slides/tr/net/save-presentation/) uygun kaydetme formatını seçin.

**Bireysel slaytları dosyadan silmeden gösteriden çıkarabilir miyim?**

Evet. Bir slaytı [Hidden](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/hidden/) olarak işaretleyin. Gizli slaytlar sunumda kalır ancak slayt gösterisi sırasında gösterilmez.

**Aspose.Slides bir slayt gösterisi oynatabilir veya ekrandaki canlı bir sunumu kontrol edebilir mi?**

Hayır. Aspose.Slides, sunum dosyalarını düzenler, analiz eder ve dönüştürür; gerçek oynatma işlemi PowerPoint gibi bir görüntüleyici uygulama tarafından gerçekleştirilir.
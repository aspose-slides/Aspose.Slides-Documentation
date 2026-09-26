---
title: .NET'te Sunumlar Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/net/create-presentation/
keywords:
- sunum oluştur
- yeni sunum
- PPT oluştur
- yeni PPT
- PPTX oluştur
- yeni PPTX
- ODP oluştur
- yeni ODP
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides ile .NET'te sunumlar oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programatik olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta bir sunum oluşturmayı, ilk slaytına bir metin kutusu eklemeyi ve sonucu bir dosya olarak kaydetmeyi gösterir. Ayrıca boş bir sunum oluşturup kaydetmeyi ve desteklenen bir biçimde mevcut bir sunumu açıp başka bir biçimde kaydetmeyi gösterir. Sonundaki kısa SSS, biçimler, şablonlar, slayt boyutu, birimler, bellek kullanımı, çok iş parçacığı, lisanslama, dijital imzalar ve VBA desteğiyle ilgili yaygın soruları kapsar.

Başlamadan önce, projenize NuGet üzerinden Aspose.Slides ekleyin. Windows, Linux ve macOS'ta kullanılacak paket için [Installation](/slides/tr/net/installation/) sayfasına bakın.

## **PowerPoint Sunumu Oluşturma**

Bir sunum oluşturup ilk slaytına bir metin kutusu eklemek için şu adımları izleyin:

1. Yeni bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı örneği oluşturun. Yeni bir sunum zaten tek bir boş slayt içerir.
2. Bu slaytı, indeks 0 kullanarak [Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) koleksiyonundan alın.
3. [AddAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addautoshape/) yöntemiyle bir dikdörtgen ekleyin ve onun [text](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/text/) özelliğini ayarlayın.
4. [Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemiyle sunumu PPTX dosyası olarak kaydedin.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Dikdörtgenin sol üst köşesi slaytın sol kenarından 50 puan, üst kenarından 50 puan uzaktadır ve dikdörtgen 400 puan genişliğinde ve 100 puan yüksekliğindedir. Kaydedilen dosya, bu dikdörtgeni ve metnini içeren bir slayt içerir. Lisans olmadan, Aspose.Slides kaydettiği her slayta bir değerlendirme filigranı ekler; [Licensing](/slides/tr/net/licensing/) sayfasına bakın.

## **Sunum Oluşturma ve Kaydetme**

<a name="csharp-create-save-presentation"></a>

Boş bir sunum oluşturup kaydetmek için, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve bunu [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) enumarasyonundaki herhangi bir biçimde kaydedin. Sonuç, tek bir boş slayt içeren bir sunum olur.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Sunumu Açma ve Kaydetme**

<a name="csharp-open-save-presentation"></a>

Bir sunumu bir biçimden başka bir biçime dönüştürmek için, dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/presentation/) yapıcısına geçirerek açın, ardından hedef biçimde kaydedin. Aspose.Slides, giriş dosyasından PPT, PPTX veya ODP gibi biçimi algılar.

Aşağıdaki örnek, çalışma dizininde *Sample.odp* adlı bir OpenDocument sunumu olduğu varsayımını yapar ve bunu PPTX olarak kaydeder.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **SSS**

### Yeni bir sunumu hangi biçimlere kaydedebilirim?

[PPTX, PPT ve ODP](/slides/tr/net/save-presentation/) biçimlerine kaydedebilir ve ayrıca [PDF](/slides/tr/net/convert-powerpoint-to-pdf/), [XPS](/slides/tr/net/convert-powerpoint-to-xps/), [HTML](/slides/tr/net/convert-powerpoint-to-html/), [SVG](/slides/tr/net/render-a-slide-as-an-svg-image/) ve [images](/slides/tr/net/convert-powerpoint-to-png/) gibi diğer biçimlere dışa aktarabilirsiniz.

### Bir şablondan (POTX/POTM) başlayıp düzenli bir PPTX olarak kaydedebilir miyim?

Evet. Şablonu yükleyin ve istediğiniz biçimde kaydedin; POTX/POTM/PPTM ve benzeri biçimler [desteklenir](/slides/tr/net/supported-file-formats/).

### Sunum oluştururken slayt boyutunu/eksen oranını nasıl kontrol ederim?

Slayt boyutunu (4:3 ve 16:9 gibi ön ayarlar veya özel boyutlar dahil) ayarlayın ve içeriğin nasıl ölçekleneceğini seçin.  

### Boyutlar ve koordinatlar hangi birimlerde ölçülür?

Puan cinsinden: 1 inç 72 birime eşittir.

### Çok büyük sunumları (çok sayıda medya dosyası içeren) bellek kullanımını azaltmak için nasıl yönetirim?

[BLOB yönetim stratejilerini](/slides/tr/net/manage-blob/) kullanın, geçici dosyalarla bellek içi depolamayı sınırlayın ve tamamen bellek içi akışlar yerine dosya tabanlı iş akışlarını tercih edin.

### Sunumları paralel olarak oluşturup/kaydedebilir miyim?

Aynı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneği üzerinde [çoklu iş parçacıkları](/slides/tr/net/multithreading/) ile işlem yapamazsınız. Her iş parçacığı veya süreç için ayrı, izole örnekler çalıştırın.

### Deneme filigranını ve kısıtlamaları nasıl kaldırırım?

Her süreçte bir kez [Lisans uygulayın](/slides/tr/net/licensing/). Lisans XML'i değiştirilmeden kalmalı ve birden fazla iş parçacığı kullanılıyorsa lisans ayarı senkronize edilmelidir.

### Oluşturduğum PPTX'i dijital olarak imzalayabilir miyim?

Evet. Sunumlar için [Dijital imzalar](/slides/tr/net/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

### Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?

Evet. [VBA projeleri oluşturup/düzenleyebilir](/slides/tr/net/presentation-via-vba/) ve PPTM/PPSM gibi makro etkin dosyaları kaydedebilirsiniz.
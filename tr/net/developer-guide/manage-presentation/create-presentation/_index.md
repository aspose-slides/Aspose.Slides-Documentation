---
title: .NET'te Sunumlar Oluştur
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
description: "Aspose.Slides ile .NET'te sunumlar oluşturun—PPT, PPTX ve ODP dosyaları üretin, OpenDocument desteğinden yararlanın ve güvenilir sonuçlar için programlı olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te bir sunum oluşturmayı, bir slayta basit içerik eklemeyi ve sonucu dosya olarak kaydetmeyi gösterir. Ayrıca yeni bir sunum oluşturup kaydetme, desteklenen bir formatta mevcut bir sunumu açma ve başka bir formata kaydetme süreçlerini örnekler. Ek olarak, formatlar, şablonlar, slayt boyutu, birimler, bellek kullanımı, çoklu iş parçacığı, lisanslama, dijital imzalar ve VBA desteğiyle ilgili yaygın soruları kapsayan kısa bir SSS içerir.

## **PowerPoint Sunumu Oluştur**
Seçili bir slayda basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

1. Presentation sınıfının bir örneğini oluşturun.
1. Slaydın indeksini kullanarak onun referansını alın.
1. Shapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Line türünde bir AutoShape ekleyin.
1. Değiştirilen sunumu bir PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaytına bir çizgi ekledik.

```c#
// Sunum dosyasını temsil eden bir Presentation nesnesi örneği oluştur
using (Presentation presentation = new Presentation())
{
    // İlk slaytı al
    ISlide slide = presentation.Slides[0];

    // Tipi çizgi olan bir autoshape ekle
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **Sunum Oluştur ve Kaydet**

<a name="csharp-create-save-presentation"><strong>C# ile Sunum Oluşturma ve Kaydetme Adımları</strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. _Presentation_ öğesini [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) tarafından desteklenen herhangi bir formatta kaydedin.

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Sunumu Aç ve Kaydet**

<a name="csharp-open-save-presentation"><strong>C# ile Sunumu Açma ve Kaydetme Adımları</strong></a>

1. PPT, PPTX, ODP vb. herhangi bir formatta [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. _Presentation_ öğesini [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) tarafından desteklenen herhangi bir formatta kaydedin.

```c#
// Presentation içinde desteklenen herhangi bir dosyayı yükle, örn. ppt, pptx, odp vb.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **SSS**

**Yeni bir sunumu hangi formatlarda kaydedebilirim?**

[PPTX, PPT ve ODP](/slides/tr/net/save-presentation/) formatlarında kaydedebilir ve [PDF](/slides/tr/net/convert-powerpoint-to-pdf/), [XPS](/slides/tr/net/convert-powerpoint-to-xps/), [HTML](/slides/tr/net/convert-powerpoint-to-html/), [SVG](/slides/tr/net/convert-powerpoint-to-png/) ve [görseller](/slides/tr/net/convert-powerpoint-to-png/) gibi diğer formatlara dışa aktarabilirsiniz.

**Şablondan (POTX/POTM) başlayıp düzenli bir PPTX olarak kaydedebilir miyim?**

Evet. Şablonu yükleyin ve istediğiniz formata kaydedin; POTX/POTM/PPTM ve benzeri formatlar [desteklenir](/slides/tr/net/supported-file-formats/).

**Sunum oluştururken slayt boyutunu/eni-yüksek oranını nasıl kontrol edebilirim?**

[slayt boyutunu](/slides/tr/net/slide-size/) (4:3, 16:9 gibi ön ayarlar veya özelleştirilmiş boyutlar dahil) ayarlayın ve içeriğin nasıl ölçekleneceğini seçin.

**Boyutlar ve koordinatlar hangi birimlerde ölçülür?**

Puan cinsinden: 1 inç 72 birime eşittir.

**Bellek kullanımını azaltmak için çok büyük sunumları (çok sayıda medya dosyası içeren) nasıl yönetebilirim?**

[Blob yönetim stratejilerini](/slides/tr/net/manage-blob/) kullanın, geçici dosyalar aracılığıyla bellek içi depolamayı sınırlayın ve mümkün olduğunca dosya tabanlı iş akışlarını tercih edin.

**Sunumları paralel olarak oluşturup kaydedebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneğine [birçok iş parçacığından](/slides/tr/net/multithreading/) erişemezsiniz. Her iş parçacığı veya süreç için ayrı, izole örnekler çalıştırın.

**Deneme sürümü filigranını ve sınırlamaları nasıl kaldırırım?**

İşlem başına bir kez [lisans uygulayın](/slides/tr/net/licensing/). Lisans XML'i değiştirilmemeli ve birden fazla iş parçacığı kullanılıyorsa lisans ayarı senkronize edilmelidir.

**Oluşturduğum PPTX dosyasını dijital olarak imzalayabilir miyim?**

Evet. Sunumlar için [dijital imzalar](/slides/tr/net/digital-signature-in-powerpoint/) (ekleme ve doğrulama) desteklenir.

**Oluşturulan sunumlarda makrolar (VBA) destekleniyor mu?**

Evet. [VBA projeleri oluşturup düzenleyebilir](/slides/tr/net/presentation-via-vba/) ve PPTM/PPSM gibi makro etkin dosyaları kaydedebilirsiniz.
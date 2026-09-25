---
title: .NET'te Sunum Erişilebilirliğini Yönet
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/net/presentation-accessibility/
keywords:
  - sunum erişilebilirliği
  - alternatif metin
  - alternatif metin başlığı
  - alternatif metin açıklaması
  - dekoratif olarak işaretle
  - PowerPoint
  - OpenDocument
  - sunum
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET ile PPT, PPTX ve ODP dosyalarında sunum erişilebilirliği kontrollerini otomatikleştir—ekran okuyucu deneyimini iyileştirin ve uyumluluğu artırın."
---
## **Giriş**

Alternatif metin, yardımcı teknolojiler kullanan kişilerin resimlerin, grafiklerin ve diğer bilgilendirici şekillerin anlamını kavramalarına yardımcı olur. Bu makale, Aspose.Slides for .NET ile alternatif metin başlıklarını ve açıklamalarını nasıl okuyup güncelleyeceğinizi, erişilebilirlik açıklamalarını kodda kullanılan şekil adlarından nasıl ayıracağınızı ve bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl kontrol edeceğinizi açıklar.

Bu özellikler sunum erişilebilirliğini destekler, ancak bunu garanti etmez. Okuma sırası, renk kontrastı, metin okunabilirliği ve diğer erişilebilirlik gereksinimleri de incelenmelidir.

## **Alternatif Metin Başlıklarını ve Açıklamalarını Yönetme**

Alternatif metni, görüntülerin, grafiklerin ve diğer bilgilendirici şekillerin anlamını göremeyen kişilere açıklamak için kullanın. Aşağıdaki özellikler farklı amaçlar için hizmet eder:

| Özellik veya içerik | Amaç |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/alternativetexttitle/) | Alternatif açıklama için kısa bir başlık. |
| [AlternativeText](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/alternativetext/) | Şeklin içeriğinin veya amacının slayt bağlamındaki anlamlı açıklaması. |
| [Name](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/name/) | Kodun sunum içinde belirli bir şekli bulmak için kullanabileceği şekil adı. |
| Görünür metin | Şeklin metni veya bir grafiğin başlığı ve etiketleri gibi slaytta görüntülenen içerik. Alternatif metni güncellemek bu içeriği değiştirmez. |

Sunum bir şablon olarak yeniden kullanıldığında, kod bir şekli güncellemeden önce **[Name]**(https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/name/) ile bulabilir. Bu ad, görselin okuyucuya ne iletiyor olduğunu açıklayan alternatif metinden farklı bir amaca hizmet eder. Ad ile arama, yazarların açıklamaları değiştirmeden veya çevirirken şeklin kod tarafından bulunmasını etkilemez. Adlar düzenlenebilir ve benzersiz olması garanti edilmez; bu nedenle adın hedef şekille eşleştiğinden emin olun; **[Şekilleri Tanımlama ve Bulma](/slides/tr/net/shape-manipulations/#identify-and-find-shapes)** bölümüne bakın.

Aşağıdaki örnek, ilk slayttaki ilk şekil olarak bir ofis girişinin resmini içeren `input.pptx` dosyasına ihtiyaç duyar. Resim dekoratif olarak işaretlenmemelidir. Örnek, mevcut alternatif metin başlığını ve açıklamasını okur, her iki değeri günceller ve sunumu `output.pptx` olarak kaydeder. Metni gerçek resme ve ilettiği bilgiye göre uyarlayın.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Alternatif metin eklemek tek başına sunum erişilebilirliğini veya erişilebilirlik standartlarına uyumu garanti etmez. Açıklamaların doğruluğunu ve alaka düzeyini inceleyin ve ayrıca okuma sırasını, renk kontrastını, okunabilir metni ve diğer erişilebilirlik gereksinimlerini kontrol edin. Bilgilendirici görseller dekoratif olarak işaretlenmemelidir; bir sonraki bölümde **[IsDecorative]**(https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/isdecorative/) nasıl okunacağını gösterir.

## **Dekoratif Olarak İşaretle**

Dekoratif olarak işaretle, sadece süs amaçlı görselleri ekran okuyucularının atlamasını sağlayarak gereksiz gürültüyü azaltır ve odaklanmayı anlamlı içerik üzerinde tutar. Arka planlar, süslemeler ve boşluk doldurucular için uygulanır—bilgi içeren grafikler, simgeler veya resimler için asla kullanılmaz. Aspose.Slides bu işareti algılama ve doğrulama için sunar, böylece otomatik erişilebilirlik kontrolleri ve temizlik mümkündür.

![Dekoratif Olarak İşaretle](mark_as_decorative.png)

Aşağıdaki kod örneği, bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl belirleyeceğinizi gösterir.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **SSS**

**Alternatif metin başlığı ve açıklamasına ne yazmalıyım?**

Konu başlığını tanımlayan kısa bir başlık ve slayt bağlamında görselin ilettiği bilgiyi açıklayan bir açıklama kullanın. Bir grafik için sadece “grafik” demek yerine ilgili trendi veya karşılaştırmayı tanımlayın.

**Şablondaki şekilleri bulmak için alternatif metni kullanmalı mıyım?**

Şekli **[Name]**(https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/name/) ile bulmayı ve beklenen şekil olduğundan emin olmayı tercih edin. Alternatif metin düzenlenebilir veya çevrilebilir, bu da tam açıklamayı arayan kodun kırılmasına neden olabilir; **[Şekilleri Tanımlama ve Bulma](/slides/tr/net/shape-manipulations/)** bölümüne bakın.

**Bir şekil ne zaman dekoratif olarak işaretlenmeli?**

Bilgi eklemeyen süs amaçlı görseller için dekoratif işareti kullanın. Anlam taşıyan resim ve grafikler uygun bir açıklama almalıdır.

**Alternatif metin eklemek bir sunumu tam olarak erişilebilir kılar mı?**

Hayır. Alternatif metin sadece erişilebilirliğin bir kısmını ele alır. Okuma sırası, renk kontrastı, metin okunabilirliği ve diğer geçerli gereksinimler de incelenmelidir; bu özellikleri ayarlamak tek başına uyumu sağlamaz.
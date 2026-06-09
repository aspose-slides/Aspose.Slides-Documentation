---
title: Slayt
type: docs
weight: 10
url: /tr/net/examples/elements/slide/
keywords:
- slayt
- slayt ekle
- slayta eriş
- slayt dizini
- slaytı kopyala
- slaytları yeniden sırala
- slayt sil
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile slaytları kontrol edin: PPT, PPTX ve ODP sunumları için C# kullanarak oluşturun, kopyalayın, yeniden sıralayın, yeniden boyutlandırın, arka planları ayarlayın ve geçişler uygulayın."
---
Bu makale, **Aspose.Slides for .NET** kullanarak slaytlarla nasıl çalışılacağını gösteren bir dizi örnek sunar. `Presentation` sınıfını kullanarak slayt ekleme, erişme, kopyalama, yeniden sıralama ve silme konularını öğreneceksiniz.

Aşağıdaki her örnek, kısa bir açıklama ve ardından C# kod parçacığı içerir.

## **Slayt Ekleme**

Yeni bir slayt eklemek için önce bir düzen seçmeniz gerekir. Bu örnekte `Blank` düzenini kullanarak sunuma boş bir slayt ekliyoruz.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Her slayt, bir düzen temelli olup, bu düzen de bir ana slayta dayanır.
    // Yeni bir slayt oluşturmak için Boş düzeni kullanın.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Seçilen düzeni kullanarak yeni boş bir slayt ekleyin.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Not:** Her slayt düzeni bir ana slayttan türetilir; ana slayt genel tasarımı ve yer tutucu yapısını tanımlar. Aşağıdaki resim, PowerPoint’te ana slaytların ve bunlara bağlı düzenlerin nasıl organize edildiğini gösterir.

![Ana Slayt ve Düzen İlişkisi](master-layout-slide.png)

## **Slaytlara Dizinle Erişme**

Slaytlara dizinleriyle erişebilir veya bir referansa göre slaytın dizinini bulabilirsiniz. Bu, belirli slaytları yinelemek veya değiştirmek için yararlıdır.

```csharp
static void AccessSlide()
{
    // Varsayılan olarak, bir sunum bir boş slayt ile oluşturulur.
    using var presentation = new Presentation();

    // Başka bir boş slayt ekleyin.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Slaytlara dizinle erişin.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Bir referanstan slayt indeksini alın, ardından dizinle erişin.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Slaytı Kopyalama**

Bu örnek, mevcut bir slaytı nasıl kopyalayacağınızı gösterir. Kopyalanan slayt otomatik olarak slayt koleksiyonunun sonuna eklenir.

```csharp
static void CloneSlide()
{
    // Varsayılan olarak, sunum bir boş slayt içerir.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // İlk slaytı kopyala; sunumun sonuna eklenecek.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // Kopyalanan slaytın indeksi 1'dir (sunumda ikinci slayt).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Slaytları Yeniden Sıralama**

Bir slaytı yeni bir dizine taşıyarak sırasını değiştirebilirsiniz. Bu örnekte, kopyalanan slaytı ilk konuma taşıyoruz.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // İlk slaytın bir kopyasını ekle (varsayılan olarak oluşturulan).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Kopyalanan slaytı ilk konuma taşı (diğerleri aşağı kayar).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Slayt Silme**

Bir slaytı silmek için sadece ona referans verip `Remove` metodunu çağırmanız yeterlidir. Bu örnek, ikinci bir slayt ekleyip orijinali kaldırarak yalnızca yenisini bırakır.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Varsayılan ilk slayta ek olarak yeni bir boş slayt ekle.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // İlk slaytı kaldır; yalnızca yeni eklenen slayt kalır.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```
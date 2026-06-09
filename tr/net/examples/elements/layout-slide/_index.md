---
title: Düzen Slaytı
type: docs
weight: 20
url: /tr/net/examples/elements/layout-slide/
keywords:
- düzen slaytı
- düzen slaytı ekle
- düzen slaytına eriş
- düzen slaytı kaldır
- kullanılmayan düzen slaytı
- düzen slaytı kopyala
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te ana düzen slaytları: PPT, PPTX ve ODP sunumları için C# örnekleriyle slayt düzenlerini, yer tutucuları ve masterları seçin, uygulayın ve özelleştirin."
---
Bu makale, Aspose.Slides for .NET'te **Layout Slides** ile nasıl çalışılacağını gösterir. Bir layout slaytı, normal slaytlar tarafından devralınan tasarımı ve biçimlendirmeyi tanımlar. Layout slaytlarını ekleyebilir, erişebilir, kopyalayabilir ve kaldırabilirsiniz; ayrıca kullanılmayanları temizleyerek sunum boyutunu azaltabilirsiniz.

## **Layout Slaytı Ekle**

Yeniden kullanılabilir biçimlendirme tanımlamak için özel bir layout slaytı oluşturabilirsiniz. Örneğin, bu düzeni kullanan tüm slaytlarda görünen bir metin kutusu ekleyebilirsiniz.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Boş bir düzen türü ve özel bir ad ile bir layout slaytı oluşturun.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Layout slaytına bir metin kutusu ekleyin.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Bu düzeni kullanarak iki slayt ekleyin; her ikisi de metni düzenten miras alacak.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Note 1:** Layout slaytları, bireysel slaytlar için şablon görevi görür. Ortak öğeleri bir kez tanımlayabilir ve birçok slayt arasında yeniden kullanabilirsiniz.

> 💡 **Note 2:** Bir layout slaytına şekil veya metin eklediğinizde, bu düzeni temel alan tüm slaytlar bu ortak içeriği otomatik olarak gösterir. Aşağıdaki ekran görüntüsü, aynı layout slaytından bir metin kutusu miras alan iki slaytı gösterir.

![Düzen İçeriğini Miras Alan Slaytlar](layout-slide-result.png)

## **Layout Slaytına Erişim**

Layout slaytlarına, indeks ya da düzen türüne göre (ör. `Blank`, `Title`, `SectionHeader` vb.) erişilebilir.

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Bir layout slaytına indeks ile eriş.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Bir layout slaytına tür ile eriş.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Layout Slaytını Kaldır**

Artık ihtiyaç duyulmadığında belirli bir layout slaytını kaldırabilirsiniz.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Türüne göre bir layout slaytı al ve kaldır.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Kullanılmayan Layout Slaytlarını Kaldır**

Sunum boyutunu küçültmek için, normal slaytlar tarafından kullanılmayan layout slaytlarını kaldırmak isteyebilirsiniz.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Otomatik olarak herhangi bir slayt tarafından referans edilmeyen tüm layout slaytlarını kaldırır.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Layout Slaytını Kopyala**

`AddClone` yöntemini kullanarak bir layout slaytını çoğaltabilirsiniz.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Türüne göre mevcut bir layout slaytı al.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Layout slaytını layout slayt koleksiyonunun sonuna kopyala.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Özet:** Layout slaytları, slaytlar arasında tutarlı biçimlendirmeyi yönetmek için güçlü araçlardır. Aspose.Slides, layout slaytlarını oluşturma, yönetme ve optimize etme konusunda tam kontrol sağlar.
---
title: Düzen Slaytı
type: docs
weight: 20
url: /tr/cpp/examples/elements/layout-slide/
keywords:
- kod örneği
- düzen slaytı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta ana düzen slaytları: PPT, PPTX ve ODP sunumları için C++ örnekleriyle slayt düzenlerini, yer tutucuları ve ana düzenleri seçin, uygulayın ve özelleştirin."
---
Bu makale, Aspose.Slides for C++ içinde **Düzen Slaytları** ile nasıl çalışılacağını gösterir. Bir düzen slaytı, normal slaytlar tarafından devralınan tasarım ve biçimlendirmeyi tanımlar. Düzen slaytlarını ekleyebilir, erişebilir, kopyalayabilir ve kaldırabilir, ayrıca kullanılmayanları temizleyerek sunum boyutunu azaltabilirsiniz.

## **Düzen Slaytı Ekle**

Yeniden kullanılabilir biçimlendirme tanımlamak için özel bir düzen slaytı oluşturabilirsiniz. Örneğin, bu düzeni kullanan tüm slaytlarda görünen bir metin kutusu ekleyebilirsiniz.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Boş bir düzen tipi ve özel bir ad ile bir düzen slaytı oluşturur.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Düzen slaytına bir metin kutusu ekler.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Bu düzeni kullanarak iki slayt ekler; her ikisi de düzenten gelen metni miras alır.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1:** Düzen slaytları, bireysel slaytlar için şablon görevi görür. Ortak öğeleri bir kez tanımlayıp birçok slaytta yeniden kullanabilirsiniz.

> 💡 **Note 2:** Bir düzen slaytına şekil veya metin eklediğinizde, bu düzene dayanan tüm slaytlar paylaşılan içeriği otomatik olarak gösterir.
> Aşağıdaki ekran görüntüsü, aynı düzen slaytından bir metin kutusu miras alan iki slaytı gösterir.

![Düzen İçeriği Miras Alan Slaytlar](layout-slide-result.png)

## **Düzen Slaytına Erişme**

Düzen slaytlarına indeks veya düzen tipi (örn., `Blank`, `Title`, `SectionHeader`, vb.) ile erişilebilir.

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Dizine göre bir düzen slaytına erişir.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Tipe göre bir düzen slaytına erişir.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Düzen Slaytını Kaldır**

Artık gerekli değilse belirli bir düzen slaytını kaldırabilirsiniz.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Tipine göre bir düzen slaytını al ve kaldır.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Kullanılmayan Düzen Slaytlarını Kaldır**

Sunum boyutunu azaltmak için hiçbir normal slayt tarafından kullanılmayan düzen slaytlarını kaldırmak isteyebilirsiniz.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Otomatik olarak herhangi bir slayt tarafından referans alınmayan tüm düzen slaytlarını kaldırır.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Düzen Slaytını Kopyala**

`AddClone` yöntemiyle bir düzen slaytını çoğaltabilirsiniz.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Tipine göre mevcut bir düzen slaytını al.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Düzen slayt koleksiyonunun sonuna düzen slaytını kopyala.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Summary:** Düzen slaytları, slaytlar arasında tutarlı biçimlendirmeyi yönetmek için güçlü araçlardır. Aspose.Slides, düzen slaytlarını oluşturma, yönetme ve optimize etme konusunda tam kontrol sağlar.
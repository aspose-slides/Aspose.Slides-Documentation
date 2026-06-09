---
title: Slayt
type: docs
weight: 10
url: /tr/cpp/examples/elements/slide/
keywords:
- kod örneği
- slayt
- PowerPoint
- Açık Belge
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde slaytları kontrol edin: PPT, PPTX ve ODP sunumları için C++ ile slayt oluşturma, kopyalama, yeniden sıralama, yeniden boyutlandırma, arka plan ayarlama ve geçiş uygulama."
---
Bu makale, **Aspose.Slides for C++** kullanarak slaytlarla çalışmayı gösteren bir dizi örnek sunar. `Presentation` sınıfını kullanarak slayt ekleme, erişme, kopyalama, yeniden sıralama ve kaldırma yöntemlerini öğreneceksiniz.

Aşağıdaki her örnek, kısa bir açıklama ve ardından C++ kod snippet'ini içerir.

## **Slayt Ekle**

Yeni bir slayt eklemek için önce bir layout seçmeniz gerekir. Bu örnekte `Blank` layout'unu kullanarak sunuma boş bir slayt ekliyoruz.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Not:** Her slayt layout'u, genel tasarımı ve yer tutucu yapısını tanımlayan bir ana slayttan türetilir. Aşağıdaki resim, ana slaytların ve ilgili layout'ların PowerPoint'te nasıl düzenlendiğini gösterir.

![Master and Layout Relationship](master-layout-slide.png)

## **Slaytlara İndeks ile Erişim**

Slaytlara indekslerini kullanarak erişebilir veya bir referansa dayanarak bir slaytın indeksini bulabilirsiniz. Bu, belirli slaytlar üzerinde döngü oluşturmak veya değişiklik yapmak için kullanışlıdır.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Başka bir boş slayt ekle.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Slaytlara indeksle eriş.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Bir referanstan slayt indeksini al, ardından indeksle eriş.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Slaytı Kopyala**

Bu örnek, mevcut bir slaytı nasıl kopyalayacağınızı gösterir. Kopyalanan slayt otomatik olarak slayt koleksiyonunun sonuna eklenir.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Slaytları Yeniden Sırala**

Bir slaytı yeni bir indekse taşıyarak slaytların sırasını değiştirebilirsiniz. Bu örnekte, kopyalanan bir slaytı ilk konuma taşıyoruz.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Slaytı Kaldır**

Bir slaytı kaldırmak için sadece referansını verip `Remove` metodunu çağırmanız yeterlidir. Bu örnek, ikinci bir slayt ekler ve ardından orijinali kaldırarak yalnızca yeni slaytı bırakır.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```
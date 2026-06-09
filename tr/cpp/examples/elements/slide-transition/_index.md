---
title: Slayt Geçişi
type: docs
weight: 110
url: /tr/cpp/examples/elements/slide-transition/
keywords:
- kod örneği
- slayt geçişi
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde slayt geçişlerini ustalıkla yönetin: PPT, PPTX ve ODP sunumları için C++ örnekleriyle efektleri ve süreleri ekleyin, özelleştirin ve sıralayın."
---
Bu makale, **Aspose.Slides for C++** ile slayt geçiş efektleri ve zamanlamalarını uygulamayı gösterir.

## **Slayt Geçişi Ekle**

İlk slayta bir solma geçiş etkisi uygula.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Bir solma geçişi uygula.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Slayt Geçişine Erişim**

Bir slayta şu anda atanmış geçiş tipini oku.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Geçiş tipine eriş.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Slayt Geçişini Kaldır**

Geçiş tipini `None` olarak ayarlayarak tüm geçiş efektlerini temizle.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Geçişi none ayarlayarak kaldır.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Geçiş Süresini Ayarla**

Slaydın otomatik olarak ilerlemeden önce ne kadar süre gösterileceğini belirt.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // Milisaniye cinsinden.

    presentation->Dispose();
}
```
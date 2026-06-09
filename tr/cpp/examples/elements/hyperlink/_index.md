---
title: Köprü
type: docs
weight: 130
url: /tr/cpp/examples/elements/hyperlink/
keywords:
- kod örneği
- köprü
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde köprüleri ekleyin ve yönetin: metin, şekil ve görüntüleri bağlayın, PPT, PPTX ve ODP için hedefleri ve eylemleri C++ örnekleriyle ayarlayın."
---
Bu makale, **Aspose.Slides for C++** kullanarak şekiller üzerindeki köprüleri ekleme, erişme, kaldırma ve güncelleme işlemlerini gösterir.

## **Köprü Ekle**

Harici bir web sitesine yönelen bir köprü içeren bir dikdörtgen şekil oluşturun.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **Köprüyü Erişme**

Bir şeklin metin bölümünden köprü bilgilerini okuyun.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **Köprüyü Kaldır**

Şeklin metnindeki köprüyü temizleyin.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **Köprüyü Güncelle**

Mevcut bir köprünün hedefini değiştirin. `HyperlinkManager` kullanarak zaten bir köprü içeren metni değiştirin; bu, PowerPoint'in köprüleri güvenli bir şekilde güncelleme şeklini taklit eder.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // Mevcut metin içinde bir köprüyü değiştirmek, şu yolla yapılmalıdır
    // HyperlinkManager'ı, özelliği doğrudan ayarlamaktan ziyade.
    // Bu, PowerPoint'in köprüleri güvenli bir şekilde güncelleme şekline benzer.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```
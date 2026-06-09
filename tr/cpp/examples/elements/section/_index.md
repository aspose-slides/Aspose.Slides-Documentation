---
title: Bölüm
type: docs
weight: 90
url: /tr/cpp/examples/elements/section/
keywords:
- kod örneği
- bölüm
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'de slayt bölümlerini yönetin: PPT, PPTX ve ODP için C++ örnekleriyle slaytları oluşturun, yeniden adlandırın, yeniden sırala ve gruplandırın."
---
Aspose.Slides for C++ kullanarak bir sunumun bölümlerini programlı olarak yönetmek—ekleme, erişme, kaldırma ve yeniden adlandırma örnekleri.

## **Bölüm Ekle**

Belirli bir slaytta başlayan bir bölüm oluşturun.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Bölümün başlangıcını işaret eden slaytı belirtin.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Bölüme Eriş**

Bir sunumdan bölüm bilgilerini okuyun.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // İndeksle bir bölüme eriş.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Bölümü Kaldır**

Daha önce eklenmiş bir bölümü silin.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // İlk bölümü kaldır.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Bölümü Yeniden Adlandır**

Mevcut bir bölümün adını değiştirin.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```
---
title: Üst Bilgi Alt Bilgi
type: docs
weight: 220
url: /tr/cpp/examples/elements/header-footer/
keywords:
- kod örneği
- üst bilgi
- alt bilgi
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile slayt üst ve alt bilgilerini kontrol edin: PPT, PPTX ve ODP'de tarih, slayt numarası ve özel metin ekleyin, C++ örnekleriyle."
---
Bu makale, **Aspose.Slides for C++** kullanarak alt bilgi eklemeyi ve tarih ve saat yer tutucularını güncellemeyi göstermektedir.

## **Alt Bilgi Ekle**

Bir slaydın alt bilgi alanına metin ekleyin ve görünür yapın.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **Tarih ve Saati Güncelle**

Bir slayttaki tarih ve saat yer tutucusunu değiştirin.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```
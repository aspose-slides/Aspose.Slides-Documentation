---
title: Tinta
type: docs
weight: 180
url: /id/cpp/examples/elements/ink/
keywords:
- contoh kode
- tinta
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Bekerja dengan Tinta di Aspose.Slides untuk C++: menggambar, mengimpor, dan mengedit goresan, mengatur warna dan lebar, serta mengekspor ke PPT, PPTX, dan ODP menggunakan contoh C++."
---
Artikel ini memberikan contoh cara mengakses bentuk tinta yang ada dan menghapusnya menggunakan **Aspose.Slides for C++**.

> ❗ **Catatan:** Bentuk tinta mewakili masukan pengguna dari perangkat khusus. Aspose.Slides tidak dapat membuat goresan tinta baru secara programatis, tetapi Anda dapat membaca dan memodifikasi tinta yang ada.

## **Akses Tinta**

Baca tag dari bentuk tinta pertama pada slide.

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // Gunakan tagName sesuai kebutuhan.
        }
    }

    presentation->Dispose();
}
```

## **Hapus Tinta**

Hapus bentuk tinta dari slide jika ada.

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```
---
title: SmartArt
type: docs
weight: 140
url: /id/cpp/examples/elements/smart-art/
keywords:
- contoh kode
- SmartArt
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Bekerja dengan SmartArt di Aspose.Slides untuk C++: buat, edit, konversi, dan gaya diagram dengan C++ untuk presentasi PowerPoint dan OpenDocument."
---
Artikel ini menunjukkan cara menambahkan grafis SmartArt, mengaksesnya, menghapusnya, dan mengubah tata letak menggunakan **Aspose.Slides for C++**.

## **Tambah SmartArt**

Masukkan grafis SmartArt menggunakan salah satu tata letak bawaan.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Akses SmartArt**

Ambil objek SmartArt pertama pada slide.

```cpp
static void AccessSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    auto firstSmartArt = SharedPtr<ISmartArt>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ISmartArt>(shape))
        {
            firstSmartArt = ExplicitCast<ISmartArt>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Hapus SmartArt**

Hapus bentuk SmartArt dari slide.

```cpp
static void RemoveSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    slide->get_Shapes()->Remove(smartArt);

    presentation->Dispose();
}
```

## **Ubah Tata Letak SmartArt**

Perbarui tipe tata letak grafis SmartArt yang ada.

```cpp
static void ChangeSmartArtLayout()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicBlockList);
    smartArt->set_Layout(SmartArtLayoutType::VerticalPictureList);

    presentation->Dispose();
}
```
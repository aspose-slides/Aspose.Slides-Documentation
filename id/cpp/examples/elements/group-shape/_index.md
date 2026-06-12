---
title: Bentuk Grup
type: docs
weight: 170
url: /id/cpp/examples/elements/group-shape/
keywords:
- contoh kode
- bentuk grup
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kelola bentuk yang dikelompokkan dalam Aspose.Slides for C++: buat, susun, sejajarkan, urutkan kembali, dan gaya bentuk grup dengan contoh C++ dalam presentasi PPT, PPTX, dan ODP."
---
Contoh untuk membuat grup bentuk, mengaksesnya, membatalkan grup, dan menghapus menggunakan **Aspose.Slides for C++**.

## **Tambahkan Bentuk Grup**

Buat grup yang berisi dua bentuk dasar.

```cpp
static void AddGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    group->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

    presentation->Dispose();
}
```

## **Akses Bentuk Grup**

Ambil bentuk grup pertama dari slide.

```cpp
static void AccessGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    auto firstGroup = SharedPtr<IGroupShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IGroupShape>(shape))
        {
            firstGroup = ExplicitCast<IGroupShape>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Hapus Bentuk Grup**

Hapus bentuk grup dari slide.

```cpp
static void RemoveGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();

    slide->get_Shapes()->Remove(group);

    presentation->Dispose();
}
```

## **Batalkan Grup Bentuk**

Pindahkan bentuk keluar dari kontainer grup.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Pindahkan bentuk keluar dari grup.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```
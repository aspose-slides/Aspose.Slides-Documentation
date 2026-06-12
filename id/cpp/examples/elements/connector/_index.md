---
title: Konektor
type: docs
weight: 190
url: /id/cpp/examples/elements/connector/
keywords:
- contoh kode
- Konektor
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara menambahkan, mengarahkan, dan memberi gaya pada konektor antara bentuk menggunakan Aspose.Slides untuk C++, dengan contoh untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menghubungkan bentuk dengan konektor dan mengubah targetnya menggunakan **Aspose.Slides for C++**.

## **Tambahkan Konektor**

Masukkan bentuk konektor di antara dua titik pada slide.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Akses Konektor**

Ambil bentuk konektor pertama yang ditambahkan ke slide.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Akses konektor pertama pada slide.
    auto connector = SharedPtr<IConnector>();
    for (auto&& shape :  slide->get_Shapes())
    {
        if (ObjectExt::Is<IConnector>(shape))
        {
            connector = ExplicitCast<IConnector>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Hapus Konektor**

Hapus konektor dari slide.

```cpp
static void RemoveConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    slide->get_Shapes()->Remove(connector);

    presentation->Dispose();
}
```

## **Sambungkan Kembali Bentuk**

Lampirkan konektor ke dua bentuk dengan menetapkan target awal dan akhir.

```cpp
static void ReconnectShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    connector->set_StartShapeConnectedTo(shape1);
    connector->set_EndShapeConnectedTo(shape2);

    presentation->Dispose();
}
```
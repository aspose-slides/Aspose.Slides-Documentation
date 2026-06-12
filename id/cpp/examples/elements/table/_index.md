---
title: Tabel
type: docs
weight: 120
url: /id/cpp/examples/elements/table/
keywords:
- contoh kode
- tabel
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Bekerja dengan tabel di Aspose.Slides untuk C++: membuat, memformat, menggabungkan sel, menerapkan gaya, mengimpor data, dan mengekspor dengan contoh C++ untuk PPT, PPTX, dan ODP."
---
Contoh menambahkan tabel, mengaksesnya, menghapusnya, dan menggabungkan sel menggunakan **Aspose.Slides for C++**.

## **Menambahkan Tabel**

Buat tabel sederhana dengan dua baris dan dua kolom.

```cpp
static void AddTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    presentation->Dispose();
}
```

## **Mengakses Tabel**

Ambil bentuk tabel pertama pada slide.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Akses tabel pertama pada slide.
    auto firstTable = SharedPtr<ITable>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            firstTable = ExplicitCast<ITable>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Menghapus Tabel**

Hapus tabel dari slide.

```cpp
static void RemoveTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    slide->get_Shapes()->Remove(table);

    presentation->Dispose();
}
```

## **Menggabungkan Sel Tabel**

Gabungkan sel-sel bersebelahan dalam tabel menjadi satu sel.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Gabungkan sel.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```
---
title: Tablo
type: docs
weight: 120
url: /tr/cpp/examples/elements/table/
keywords:
- kod örneği
- tablo
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile tablolara çalışın: oluşturma, biçimlendirme, hücre birleştirme, stil uygulama, veri içe aktarma ve PPT, PPTX ve ODP için C++ örnekleriyle dışa aktarma."
---
**Aspose.Slides for C++** kullanarak tablo ekleme, tabloya erişme, tablo kaldırma ve hücre birleştirme örnekleri.

## **Tablo Ekle**

İki satır ve iki sütundan oluşan basit bir tablo oluşturun.

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

## **Tabloya Erişim**

Slayttaki ilk tablo şekli alın.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Slayttaki ilk tabloya eriş.
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

## **Tabloyu Kaldır**

Bir slayttan tabloyu silin.

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

## **Tablo Hücrelerini Birleştir**

Bir tablonun komşu hücrelerini tek bir hücreye birleştirin.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // Hücreleri birleştir.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```
---
title: جدول
type: docs
weight: 120
url: /ar/cpp/examples/elements/table/
keywords:
- مثال على الشيفرة
- جدول
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "العمل مع الجداول في Aspose.Slides for C++: إنشاء، تنسيق، دمج الخلايا، تطبيق الأنماط، استيراد البيانات، وتصدير مع أمثلة C++ لـ PPT و PPTX و ODP."
---
أمثلة لإضافة الجداول، والوصول إليها، وإزالتها، ودمج الخلايا باستخدام **Aspose.Slides for C++**.

## **إضافة جدول**

إنشاء جدول بسيط يحتوي على صفين وعمودين.

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

## **الوصول إلى جدول**

استرجاع الشكل الجدولي الأول على الشريحة.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // الوصول إلى أول جدول على الشريحة.
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

## **إزالة جدول**

حذف جدول من شريحة.

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

## **دمج خلايا الجدول**

دمج الخلايا المتجاورة في جدول لتصبح خلية واحدة.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // دمج الخلايا.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```
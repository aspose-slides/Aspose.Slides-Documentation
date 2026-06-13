---
title: جدول
type: docs
weight: 120
url: /fa/cpp/examples/elements/table/
keywords:
- مثال کد
- جدول
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کار با جداول در Aspose.Slides for C++: ایجاد، قالب‌بندی، ادغام سلول‌ها، اعمال سبک‌ها، وارد کردن داده‌ها، و خروجی با مثال‌های C++ برای PPT، PPTX و ODP."
---
نمونه‌هایی برای افزودن جداول، دسترسی به آن‌ها، حذف آن‌ها و ادغام سلول‌ها با استفاده از **Aspose.Slides for C++**.

## **افزودن جدول**

یک جدول ساده با دو ردیف و دو ستون ایجاد کنید.

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

## **دسترسی به جدول**

شکل جدول اولین در اسلاید را بازیابی کنید.

```cpp
static void AccessTable()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // دسترسی به اولین جدول در اسلاید.
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

## **حذف جدول**

یک جدول را از اسلاید حذف کنید.

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

## **ادغام سلول‌های جدول**

سلول‌های مجاور یک جدول را در یک سلول ترکیب کنید.

```cpp
static void MergeTableCells()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto widths = MakeArray<double>({ 80, 80 });
    auto heights = MakeArray<double>({ 30, 30 });
    auto table = slide->get_Shapes()->AddTable(50, 50, widths, heights);

    // ادغام سلول‌ها.
    table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 1), false);

    presentation->Dispose();
}
```
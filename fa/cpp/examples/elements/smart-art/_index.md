---
title: SmartArt
type: docs
weight: 140
url: /fa/cpp/examples/elements/smart-art/
keywords:
- مثال کد
- SmartArt
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کار با SmartArt در Aspose.Slides برای C++: ایجاد، ویرایش، تبدیل و طراحی نمودارها با C++ برای ارائه‌های PowerPoint و OpenDocument."
---
این مقاله نشان می‌دهد که چگونه می‌توان گرافیک‌های SmartArt را اضافه کرد، به آن‌ها دسترسی یافت، آن‌ها را حذف کرد و طرح‌بندی‌ها را با استفاده از **Aspose.Slides for C++** تغییر داد.

## **افزودن SmartArt**
یک گرافیک SmartArt را با استفاده از یکی از طرح‌بندی‌های پیش‌ساخته وارد کنید.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **دسترسی به SmartArt**
اولین شیء SmartArt موجود در اسلاید را بازیابی کنید.

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

## **حذف SmartArt**
یک شکل SmartArt را از اسلاید حذف کنید.

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

## **تغییر طرح‌بندی SmartArt**
نوع طرح‌بندی یک گرافیک SmartArt موجود را به‌روز کنید.

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
---
title: SmartArt
type: docs
weight: 140
url: /ar/cpp/examples/elements/smart-art/
keywords:
- مثال على الكود
- SmartArt
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "العمل مع SmartArt في Aspose.Slides for C++: إنشاء، تعديل، تحويل، وتنسيق المخططات باستخدام C++ لعروض PowerPoint وOpenDocument التقديمية."
---
توضح هذه المقالة كيفية إضافة رسومات SmartArt، والوصول إليها، وإزالتها، وتغيير التخطيطات باستخدام **Aspose.Slides for C++**.

## **إضافة SmartArt**
إدراج رسم SmartArt باستخدام أحد التخطيطات المدمجة.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **الوصول إلى SmartArt**
استرجاع أول كائن SmartArt في الشريحة.

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

## **إزالة SmartArt**
حذف شكل SmartArt من الشريحة.

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

## **تغيير تخطيط SmartArt**
تحديث نوع التخطيط لرسم SmartArt موجود.

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
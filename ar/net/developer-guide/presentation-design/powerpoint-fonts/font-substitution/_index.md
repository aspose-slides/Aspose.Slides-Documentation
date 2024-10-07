---
title: استبدال الخطوط - PowerPoint C# API
linktitle: استبدال الخطوط
type: docs
weight: 70
url: /net/font-substitution/
keywords: 
- خط
- خط بديل
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: تتيح لك واجهة برمجة تطبيقات PowerPoint C# استبدال الخطوط داخل العروض التقديمية
---

## **الحصول على استبدال الخطوط**

لتمكينك من اكتشاف الخطوط المستخدمة في العرض التقديمي والتي تم استبدالها خلال عملية عرض العرض، توفر Aspose.Slides طريقة [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) من واجهة [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

يوضح كود C# كيفية الحصول على جميع استبدالات الخطوط التي يتم تنفيذها عند عرض العرض:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **تحديد قواعد استبدال الخطوط**

تتيح لك Aspose.Slides تعيين قواعد للخطوط تحدد ما يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى خط معين) بهذه الطريقة:

1. تحميل العرض التقديمي المعني.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. إضافة قاعدة للاستبدال.
5. إضافة القاعدة إلى مجموعة قواعد استبدال الخطوط في العرض التقديمي.
6. توليد صورة الشريحة لملاحظة التأثير.

يظهر هذا الكود C# عملية استبدال الخطوط:

```c#
// يحمّل عرض تقديمي
Presentation presentation = new Presentation("Fonts.pptx");

// يحمّل الخط المصدر الذي سيتم استبداله
IFontData sourceFont = new FontData("SomeRareFont");

// يحمّل الخط الجديد
IFontData destFont = new FontData("Arial");

// يضيف قاعدة خط لاستبدال الخطوط
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// يضيف القاعدة إلى مجموعة قواعد الخطوط البديلة
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// يضيف مجموعة قواعد الخطوط إلى قائمة القواعد
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // يحفظ الصورة على القرص بصيغة JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="ملاحظة"  color="warning"   %}} 

قد ترغب في رؤية [**استبدال الخطوط**](/slides/net/font-replacement/). 

{{% /alert %}}
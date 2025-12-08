---
title: استبدال الخط - PowerPoint C# API
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/net/font-substitution/
keywords:
- خط
- خط بديل
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: يتيح لك API PowerPoint C# استبدال الخطوط داخل العروض التقديمية
---

## **الحصول على استبدال الخط**

لتمكينك من معرفة الخطوط التي يتم استبدالها أثناء عملية عرض العرض التقديمي، توفر Aspose.Slides طريقة [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) من الواجهة [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

يعرض لك كود C# كيفية الحصول على جميع استبدالات الخط التي تُجرى عند عرض عرض تقديمي:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **ضبط قواعد استبدال الخط**

Aspose.Slides يسمح لك بتحديد قواعد للخطوط تحدد ما يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى الخط) بهذه الطريقة:

1. تحميل العرض التقديمي المناسب.  
2. تحميل الخط الذي سيتم استبداله.  
3. تحميل الخط الجديد.  
4. إضافة قاعدة للاستبدال.  
5. إضافة القاعدة إلى مجموعة قواعد استبدال الخط في العرض التقديمي.  
6. إنشاء صورة الشريحة لملاحظة التأثير.

هذا كود C# يوضح عملية استبدال الخط:
```c#
 // تحميل عرض تقديمي
 Presentation presentation = new Presentation("Fonts.pptx");
 
 // تحميل الخط المصدر الذي سيتم استبداله
 IFontData sourceFont = new FontData("SomeRareFont");
 
 // تحميل الخط الجديد
 IFontData destFont = new FontData("Arial");
 
 // إضافة قاعدة خط لاستبدال الخط
 IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
 
 // إضافة القاعدة إلى مجموعة قواعد استبدال الخطوط
 IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
 fontSubstRuleCollection.Add(fontSubstRule);
 
 // إضافة مجموعة قواعد الخط إلى قائمة القواعد
 presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;
 
 using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
 {
     // حفظ الصورة إلى القرص بتنسيق JPEG
     image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
 }
```


{{%  alert title="NOTE"  color="warning"   %}} 
قد ترغب في الاطلاع على [**استبدال الخط**](/slides/ar/net/font-replacement/). 
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**

[الاستبدال](/slides/ar/net/font-replacement/) هو تجاوز قسري لخط بآخر عبر كامل العرض التقديمي. الاستبدال هو قاعدة تُفعل تحت شرط محدد، على سبيل المثال عندما يكون الخط الأصلي غير متوفر، ثم يُستخدم خط بديل معين.

**متى تُطبق قواعد الاستبدال بدقة؟**

تشارك القواعد في تسلسل [اختيار الخط](/slides/ar/net/font-selection-sequence/) القياسي الذي يُقيم أثناء التحميل والعرض والتحويل؛ إذا كان الخط المختار غير متوفر، يُطبق الاستبدال أو الاستبدال.

**ما السلوك الافتراضي إذا لم يتم تكوين استبدال ولا استبدال خطوط وكان الخط مفقودًا على النظام؟**

ستحاول المكتبة اختيار أقرب خط نظام متاح، مشابهًا لسلوك PowerPoint.

**هل يمكنني إرفاق خطوط خارجية مخصصة وقت التشغيل لتجنب الاستبدال؟**

نعم. يمكنك [إضافة خطوط خارجية](/slides/ar/net/custom-font/) وقت التشغيل بحيث تُعتبر المكتبة لهذه الخطوط عند الاختيار والعرض، بما في ذلك التحويلات اللاحقة.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. لا توزع Aspose خطوطًا مدفوعة أو مجانية؛ أنت تضيف وتستخدم الخطوط وفقًا لتقديرك ومسؤوليتك.

**هل هناك اختلافات في سلوك الاستبدال على Windows وLinux وmacOS؟**

نعم. يبدأ اكتشاف الخطوط من دلائل خطوط نظام التشغيل. مجموعة الخطوط المتاحة افتراضيًا ومسارات البحث تختلف بين المنصات، مما يؤثر على التوفر والحاجة إلى الاستبدال.

**كيف يجب أن أجهز البيئة لتقليل الاستبدال غير المتوقع أثناء التحويلات الدفعة؟**

قم بمزامنة مجموعة الخطوط عبر الأجهزة أو الحاويات، [أضف الخطوط الخارجية](/slides/ar/net/custom-font/) المطلوبة للمستندات الناتجة، و[دمج الخطوط](/slides/ar/net/embedded-font/) في العروض التقديمية عندما يكون ذلك ممكنًا لتكون الخطوط المختارة متاحة أثناء العرض.
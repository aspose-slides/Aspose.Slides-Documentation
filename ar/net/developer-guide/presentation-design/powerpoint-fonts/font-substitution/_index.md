---
title: تهيئة استبدال الخطوط في العروض التقديمية في .NET
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/net/font-substitution/
keywords:
- خط
- خط بديل
- استبدال الخط
- استبدال الخط
- استبدال الخط
- قاعدة الاستبدال
- قاعدة الاستبدال
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تمكين استبدال الخطوط المثالي في Aspose.Slides لـ .NET عند تحويل عروض PowerPoint و OpenDocument إلى صيغ ملفات أخرى."
---

## **الحصول على استبدال الخطوط**

للسماح لك بمعرفة الخطوط المستخدمة في العرض التي يتم استبدالها أثناء عملية رسم العرض، توفر Aspose.Slides طريقة [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) من واجهة [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

يظهر لك كود C# كيفية الحصول على جميع استبدالات الخطوط التي يتم تنفيذها عند رسم عرض تقديمي:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```



## **تعيين قواعد استبدال الخطوط**

تتيح لك Aspose.Slides تعيين قواعد للخطوط تحدد ما الذي يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى خط) بهذه الطريقة:

1. تحميل العرض التقديمي ذو الصلة.  
2. تحميل الخط الذي سيتم استبداله.  
3. تحميل الخط الجديد.  
4. إضافة قاعدة للاستبدال.  
5. إضافة القاعدة إلى مجموعة قواعد استبدال خطوط العرض التقديمي.  
6. توليد صورة الشريحة لملاحظة التأثير.

يوضح كود C# عملية استبدال الخطوط:
```c#
// يقوم بتحميل عرض تقديمي
Presentation presentation = new Presentation("Fonts.pptx");

// يقوم بتحميل الخط المصدر الذي سيتم استبداله
IFontData sourceFont = new FontData("SomeRareFont");

// يقوم بتحميل الخط الجديد
IFontData destFont = new FontData("Arial");

// يضيف قاعدة خط لاستبدال الخط
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// يضيف القاعدة إلى مجموعة قواعد استبدال الخطوط
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// يضيف مجموعة قواعد الخط إلى قائمة القواعد
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // يحفظ الصورة إلى القرص بتنسيق JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

قد ترغب في الاطلاع على [**استبدال الخط**](/slides/ar/net/font-replacement/). 

{{% /alert %}}

## **الأسئلة الشائعة**

**ما الفرق بين استبدال الخط واستبداله؟**

[الاستبدال](/slides/ar/net/font-replacement/) هو تجاوز إجباري لخط بآخر عبر كامل العرض التقديمي. الاستبدال هو قاعدة تُفعَّل تحت شرط معين، مثل عدم توفر الخط الأصلي، ثم يُستخدم خط احتياطي محدد.

**متى تُطبق قواعد الاستبدال بالضبط؟**

تشارك القواعد في تسلسل [اختيار الخط](/slides/ar/net/font-selection-sequence/) القياسي الذي يتم تقييمه أثناء التحميل والرسم والتحويل؛ إذا كان الخط المختار غير متاح، يتم تطبيق الاستبدال أو الاستبدال بالخط.

**ما السلوك الافتراضي إذا لم يتم تكوين استبدال أو استبدال وكان الخط مفقودًا على النظام؟**

ستحاول المكتبة اختيار أقرب خط نظام متاح، مشابهًا للسلوك الذي يتبعه PowerPoint.

**هل يمكنني إرفاق خطوط خارجية مخصصة في وقت التشغيل لتجنب الاستبدال؟**

نعم. يمكنك [إضافة خطوط خارجية](/slides/ar/net/custom-font/) في وقت التشغيل حتى تعتبرها المكتبة للاختيار والرسم، بما في ذلك التحويلات اللاحقة.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. لا توزع Aspose خطوطًا مدفوعة أو مجانية؛ أنت تضيف الخطوط وتستخدمها حسب تقديرك ومسؤوليتك.

**هل هناك اختلافات في سلوك الاستبدال على Windows وLinux وmacOS؟**

نعم. يبدأ اكتشاف الخطوط من دلائل الخطوط في نظام التشغيل. مجموعة الخطوط المتاحة افتراضيًا ومسارات البحث تختلف عبر المنصات، مما يؤثر على التوفر وحاجة الاستبدال.

**كيف يجب أن أجهز البيئة لتقليل الاستبدال غير المتوقع أثناء التحويلات الجماعية؟**

قُم بمزامنة مجموعة الخطوط عبر الأجهزة أو الحاويات، [أضف الخطوط الخارجية](/slides/ar/net/custom-font/) المطلوبة للمستندات الناتجة، و[ضمّ الخطوط](/slides/ar/net/embedded-font/) في العروض التقديمية عندما يكون ذلك ممكنًا حتى تكون الخطوط المختارة متاحة أثناء الرسم.
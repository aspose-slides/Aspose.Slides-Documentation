---
title: تكوين استبدال الخط في العروض التقديمية في .NET
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
description: "تمكين استبدال الخط الأمثل في Aspose.Slides لـ .NET عند تحويل عروض PowerPoint و OpenDocument إلى صيغ ملفات أخرى."
---

## **الحصول على استبدال الخطوط**

لسماحك بمعرفة الخطوط المستخدمة في العرض التي يتم استبدالها أثناء عملية عرض الشرائح، يوفر Aspose.Slides طريقة [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) من الواجهة [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/).

الكود C# يوضح لك كيفية الحصول على جميع استبدالات الخطوط التي تُجري عند عرض العرض:
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

يسمح لك Aspose.Slides بتعيين قواعد للخطوط تحدد ما يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى خط) بهذه الطريقة:

1. تحميل العرض المعني.  
2. تحميل الخط الذي سيتم استبداله.  
3. تحميل الخط الجديد.  
4. إضافة قاعدة للاستبدال.  
5. إضافة القاعدة إلى مجموعة قواعد استبدال خطوط العرض.  
6. توليد صورة الشريحة لملاحظة التأثير.

يظهر هذا الكود C# عملية استبدال الخطوط:
```c#
 // يقوم بتحميل عرض تقديمي
Presentation presentation = new Presentation("Fonts.pptx");

// يقوم بتحميل الخط المصدر الذي سيتم استبداله
IFontData sourceFont = new FontData("SomeRareFont");

// يقوم بتحميل الخط الجديد
IFontData destFont = new FontData("Arial");

// يضيف قاعدة خط لاستبدال الخط
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// يضيف القاعدة إلى مجموعة قواعد استبدال الخط
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
قد ترغب في رؤية [**استبدال الخط**](/slides/ar/net/font-replacement/). 
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين استبدال الخط واستبدال الخط الافتراضي؟**  
[استبدال](/slides/ar/net/font-replacement/) هو تجاوز إجباري لخط بآخر في جميع أنحاء العرض. الاستبدال الافتراضي هو قاعدة تُفعَّل تحت شرط محدد، على سبيل المثال عندما يكون الخط الأصلي غير متاح، ثم يُستخدم خط بديل مخصص.

**متى تُطبق قواعد الاستبدال بالضبط؟**  
تشارك القواعد في تسلسل [اختيار الخط](/slides/ar/net/font-selection-sequence/) القياسي الذي يتم تقييمه أثناء التحميل والعرض والتحويل؛ إذا كان الخط المحدد غير متاح، يتم تطبيق الاستبدال أو الاستبدال الافتراضي.

**ما السلوك الافتراضي إذا لم يتم تكوين أي استبدال أو استبدال افتراضي وكان الخط مفقودًا على النظام؟**  
سيحاول المكتبة اختيار أقرب خط نظام متاح، مشابهًا للطريقة التي يتصرف بها PowerPoint.

**هل يمكنني إرفاق خطوط خارجية مخصصة وقت التشغيل لتجنب الاستبدال؟**  
نعم. يمكنك [إضافة خطوط خارجية](/slides/ar/net/custom-font/) وقت التشغيل حتى تأخذ المكتبة هذه الخطوط في الاعتبار للاختيار والعرض، بما في ذلك التحويلات اللاحقة.

**هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟**  
لا. لا تقوم Aspose بتوزيع خطوط مدفوعة أو مجانية؛ أنت تضيف وتستخدم الخطوط وفقًا لتقديرك ومسؤوليتك.

**هل هناك اختلافات في سلوك الاستبدال على Windows و Linux و macOS؟**  
نعم. يبدأ اكتشاف الخطوط من دلائل خطوط نظام التشغيل. مجموعة الخطوط المتاحة افتراضيًا ومسارات البحث تختلف بين المنصات، ما يؤثر على التوافر والحاجة إلى الاستبدال.

**كيف يجب أن أجهز البيئة لتقليل الاستبدال غير المتوقع أثناء التحويلات الدفعية؟**  
قم بمزامنة مجموعة الخطوط عبر الأجهزة أو الحاويات، [أضف الخطوط الخارجية](/slides/ar/net/custom-font/) المطلوبة للمستندات الناتجة، و[ضمن الخطوط](/slides/ar/net/embedded-font/) في العروض عندما يكون ذلك ممكنًا حتى تكون الخطوط المختارة متاحة أثناء العرض.
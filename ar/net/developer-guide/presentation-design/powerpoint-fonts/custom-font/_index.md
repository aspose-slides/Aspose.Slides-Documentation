---
title: تخصيص خطوط PowerPoint في .NET
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/net/custom-font/
keywords:
- خط
- خط مخصص
- خط خارجي
- تحميل خط
- إدارة الخطوط
- مجلد الخطوط
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بتخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides لـ .NET للحفاظ على عروضك التقديمية واضحة ومتسقة عبر أي جهاز."
---
## **نظرة عامة**

تتيح لك Aspose.Slides استخدام خطوط مخصصة في العروض التقديمية دون تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير الخطوط لعروض تقديمية معينة عبر مصادر الخط على مستوى المستند، أو تحميل خطوط خارجية مباشرة من البيانات الثنائية.

يتم استخدام الخطوط المحملة عند عرض أو تصدير العرض التقديمي، على سبيل المثال إلى PDF أو صور أو غيرها من الصيغ المدعومة. يساعد ذلك في الحفاظ على اتساق مخرجات العرض عبر بيئات مختلفة. توضح المقالة أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للعرض منفصل عن تضمين الخطوط في ملف PPTX. إذا كان يجب تخزين الخط داخل العرض نفسه، استخدم ميزات تضمين الخطوط بشكل صريح.

{{% alert color="info" %}} 
تتيح لك Aspose Slides تحميل هذه الخطوط باستخدام طريقة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfonts/):
* خطوط TrueType (.ttf) وTrueType Collection (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

تتيح لك Aspose.Slides تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير — مثل PDF والصور والصيغ المدعومة الأخرى — بحيث تكون المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من دلائل مخصصة.

1. حدد مجلدًا واحدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الساكنة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك المجلدات.
3. حمّل العرض التقديمي وقم بعرضه/تصديره.
4. استدعِ [FontsLoader.ClearCache](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة التخزين المؤقت للخطوط.

يوضح المثال البرمجي التالي عملية تحميل الخطوط:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// حدد المجلدات التي تحتوي على ملفات الخطوط المخصصة.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// حمّل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// اعرض/صدّر العرض التقديمي (مثلاً إلى PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحملة.
presentation.Save("output.pdf", SaveFormat.Pdf);

// امسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
FontsLoader.ClearCache();
```

{{% alert color="info" title="ملاحظة" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfonts/) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخط.
يتم تهيئة الخطوط بهذا الترتيب:
1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**
توفر Aspose.Slides طريقة [GetFontFolders](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/getfontfolders/) لتسمح لك بالعثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي تم إضافتها عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يظهر لك هذا الكود C# كيفية استخدام [GetFontFolders](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/getfontfolders/):
```c#
using Aspose.Slides;

// هذا السطر يعرض المجلدات التي يتم التحقق منها لملفات الخط.
// هذه هي المجلدات التي أضيفت عبر طريقة LoadExternalFonts ومجلدات الخط النظامية.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**
توفر Aspose.Slides الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/documentlevelfontsources/) لتتيح لك تحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

يظهر لك هذا الكود C# كيفية استخدام الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/documentlevelfontsources/):
```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // العمل مع العرض التقديمي
    // خطوط CustomFont1 و CustomFont2 و الخطوط من مجلدي assets\fonts و global\fonts ومجلداتهما الفرعية متاحة للعرض التقديمي
}
```

## **إدارة الخطوط خارجيًا**
توفر Aspose.Slides الطريقة [LoadExternalFont](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) لتحميل الخطوط الخارجية من بيانات ثنائية.

يوضح هذا الكود C# عملية تحميل الخط من مصفوفة بايت:
```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // تم تحميل الخط الخارجي طوال مدة عرض الشرائح
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **الأسئلة الشائعة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. يتم استخدام الخطوط المتصلة من قبل المُعالج عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للعرض ليس هو نفسه تضمينه في ملف PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض التقديمي، يجب عليك استخدام [ميزات التضمين](/slides/ar/net/embedded-font/) بشكل صريح.

**هل يمكنني التحكم في سلوك الاحتياطي عندما يفتقر الخط المخصص إلى بعض الرموز؟**

نعم. قم بتكوين [استبدال الخط](/slides/ar/net/font-substitution/)، [قواعد الاستبدال](/slides/ar/net/font-replacement/)، و[مجموعات الاحتياطي](/slides/ar/net/fallback-font/) لتحديد بالضبط الخط الذي يُستخدم عندما يكون الرمز المطلوب مفقودًا.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. أشِر إلى مجلدات الخط الخاصة بك أو حمّل الخطوط من مصفوفات البايت. هذا يزيل أي اعتماد على دلائل الخط النظامية في صورة الحاوية.

> **ملاحظة لـ Linux/Docker**: عند استدعاء `FontsLoader.LoadExternalFonts`، تأكد من أن كل عنصر في مصفوفة `directories` يحتوي على مسار غير فارغ لمجلد موجود. إذا كان متغيّر البيئة المستخدم لإنشاء مسار الخط غير معرف أو فارغ، قد تحاول Aspose.Slides حل القيمة الفارغة كمسار كامل، مما يؤدي إلى `System.ArgumentException`.

**ماذا عن الترخيص — هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت المسؤول عن الامتثال لتراخيص الخطوط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. احرص دائمًا على مراجعة اتفاقية ترخيص المستخدم النهائي (EULA) للخط قبل توزيع المخرجات.
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
- تحميل الخط
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

Aspose.Slides يسمح لك باستخدام خطوط مخصصة في العروض التقديمية دون الحاجة لتثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير خطوط لعروض تقديمية معينة عبر مصادر خطوط على مستوى المستند، أو تحميل خطوط خارجية مباشرة من بيانات ثنائية.

تُستخدم الخطوط المحملة عندما يتم عرض أو تصدير العرض التقديمي، على سبيل المثال إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك في الحفاظ على تناسق مخرجات العرض عبر بيئات مختلفة. يشرح هذا المقال أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل بالخطوط الخارجية.

تسجيل الخطوط المخصصة للتصيير منفصل عن تضمين الخطوط في ملف PPTX. إذا كان يجب تخزين الخط داخل العرض نفسه، استخدم ميزات تضمين الخط بشكل صريح.

يمكن لمظهر العرض الإشارة إلى عائلات خطوط مختلفة لأنظمة كتابة مختلفة. تُخزن هذه الخرائط أسماء الخطوط ولكنها لا تثبت أو تحمّل ملفات الخط. راجع [Script-Specific Theme Fonts](/slides/ar/net/script-specific-font-mappings/) لإدارة الخرائط، واستخدم خيارات التحميل أدناه لجعل الخطوط المشار إليها متاحة لتصيير متسق.

{{% alert color="info" title="ملاحظة" %}}

Aspose Slides يسمح لك بتحميل هذه الخطوط باستخدام طريقة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfonts/):

* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides يسمح لك بتحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير—مثل PDF أو صور أو صيغ أخرى مدعومة—لذلك تظهر المستندات الناتجة متسقة عبر البيئات. تُحمَّل الخطوط من دلائل مخصصة.

1. حدّد مجلدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الساكنة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك المجلدات.
3. حمّل واعرض/صدّر العرض التقديمي.
4. استدعِ [FontsLoader.ClearCache](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة التخزين المؤقت للخطوط.

يظهر المثال التالي عملية تحميل الخطوط:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// تعريف المجلدات التي تحتوي على ملفات خطوط مخصصة.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// عرض/تصدير العرض التقديمي (مثلاً إلى PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحمَّلة.
presentation.Save("output.pdf", SaveFormat.Pdf");

// مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
FontsLoader.ClearCache();
```

{{% alert color="info" title="ملاحظة" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfonts/) يضيف دلائل إضافية إلى مسارات بحث الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط. تُهيأ الخطوط بالترتيب التالي:

1. مسار الخط الافتراضي لنظام التشغيل.
2. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**

Aspose.Slides يوفر طريقة [GetFontFolders](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/getfontfolders/) لتمكينك من العثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أضيفت عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يعرض الكود التالي بلغة C# كيفية استخدام [GetFontFolders](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// هذا السطر يعرض المجلدات التي يتم التحقق منها لملفات الخطوط.
// هذه هي المجلدات التي تمت إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

Aspose.Slides يوفر الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/documentlevelfontsources/) لتمكينك من تحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

يعرض الكود التالي بلغة C# كيفية استخدام الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/documentlevelfontsources/):

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
    // CustomFont1، CustomFont2، والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
}
```

## **إدارة الخطوط خارجيًا**

Aspose.Slides يقدم الطريقة [LoadExternalFont](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) لتمكينك من تحميل خطوط خارجية من بيانات ثنائية.

يعرض الكود التالي بلغة C# عملية تحميل الخط من مصفوفة بايت:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // الخط الخارجي تم تحميله طوال عمر العرض التقديمي
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. تُستخدم الخطوط المتصلة بواسطة المُعالج عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للتصيير ليس هو نفسه تضمينه في PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض، يجب عليك استخدام ميزات [التضمين](/slides/ar/net/embedded-font/) الصريحة.

**هل يمكنني التحكم في سلوك السقوط عندما يفتقر الخط المخصص إلى بعض الأحرف؟**

نعم. يمكنك تكوين [استبدال الخطوط](/slides/ar/net/font-substitution/)، و[قواعد الاستبدال](/slides/ar/net/font-replacement/)، و[مجموعات السقوط](/slides/ar/net/fallback-font/) لتحديد الخط الذي يُستخدم عند عدم وجود الحرف المطلوب.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. قم بالإشارة إلى مجلدات الخطوط الخاصة بك أو حمّل الخطوط من مصفوفات بايت. هذا يزيل أي اعتماد على دلائل الخطوط النظامية في صورة الحاوية.

> **ملاحظة لـ Linux/Docker**: عند استدعاء `FontsLoader.LoadExternalFonts`، تأكد من أن كل إدخال في مصفوفة `directories` يحتوي على مسار غير فارغ إلى دليل موجود. إذا كان المتغيّر البيئي المستخدم لإنشاء مسار الخط غير معرف أو فارغ، قد تحاول Aspose.Slides حل القيمة الفارغة كمسار كامل، مما ينتج عنه `System.ArgumentException`.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت المسؤول عن الالتزام بترخيص الخط. الشروط تختلف؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. راجع دائمًا اتفاقية ترخيص المستخدم النهائي (EULA) للخط قبل توزيع المخرجات.
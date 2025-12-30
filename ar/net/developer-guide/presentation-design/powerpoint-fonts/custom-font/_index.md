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
description: "قم بتخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides لـ .NET للحفاظ على عرض تقديمياتك دقيقة ومتسقة عبر أي جهاز."
---

{{% alert color="primary" %}} 

يتيح Aspose Slides تحميل هذه الخطوط باستخدام طريقة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) :

* خطوط TrueType (.ttf) و TrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل خطوط مخصصة**

يوفر Aspose.Slides إمكانية تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير—مثل PDF، الصور، والصيغ المدعومة الأخرى—بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من أدلة مخصصة.

1. حدد مجلدًا واحدًا أو أكثر يحتوي على ملفات الخطوط.
2. استدعِ الطريقة الساكنة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك المجلدات.
3. حمّل واعرض/صدّر العرض التقديمي.
4. استدعِ [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة التخزين المؤقت للخطوط.

يوضح المثال البرمجي التالي عملية تحميل الخطوط:
```cs
// تعريف المجلدات التي تحتوي على ملفات الخطوط المخصصة.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// تصيير/تصدير العرض التقديمي (مثلاً إلى PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحملة.
presentation.Save("output.pdf", SaveFormat.Pdf);

// مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
FontsLoader.ClearCache();
```


{{% alert color="info" title="ملاحظة" %}}

يقوم [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) بإضافة مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط. يتم تهيئة الخطوط بهذا الترتيب:

1. مسار خطوط نظام التشغيل الافتراضي.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**
يوفر Aspose.Slides طريقة [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) للسماح لك بالعثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أضيفت من خلال طريقة `LoadExternalFonts` ومجلدات خطوط النظام.

يعرض كود C# التالي كيفية استخدام [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):
```c#
// يسرد هذا السطر المجلدات التي يتم فحصها لملفات الخطوط.
// هذه هي المجلدات التي تم إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
string[] fontFolders = FontsLoader.GetFontFolders();
```



## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**
يوفر Aspose.Slides الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) للسماح لك بتحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

يعرض كود C# التالي كيفية استخدام الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // العمل مع العرض التقديمي
    // الخطوط CustomFont1 و CustomFont2، بالإضافة إلى الخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
}
```


## **إدارة الخطوط من الخارج**

يوفر Aspose.Slides طريقة [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) للسماح لك بتحميل الخطوط الخارجية من البيانات الثنائية.

يوضح كود C# التالي عملية تحميل الخطوط من مصفوفة البايت:
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // تم تحميل الخط الخارجي خلال فترة تشغيل العرض التقديمي
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **الأسئلة الشائعة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. يتم استخدام الخطوط المتصلة بواسطة أداة العرض عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للاستخدام في العرض لا يعني تضمينه في PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض، يجب عليك استخدام [ميزات التضمين](/slides/ar/net/embedded-font/).

**هل يمكنني التحكم في سلوك الاستبدال عندما يفتقر الخط المخصص إلى بعض الرموز؟**

نعم. قم بتكوين [استبدال الخط](/slides/ar/net/font-substitution/)، [قواعد الاستبدال](/slides/ar/net/font-replacement/)، و[مجموعة الخطوط الاحتياطية](/slides/ar/net/fallback-font/) لتحديد الخط المستخدم بالضبط عندما يكون الرمز المطلوب مفقودًا.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. يمكنك الإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات البايت. يزيل هذا أي اعتماد على دليل الخطوط النظامي في صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت المسؤول عن الامتثال لترخيص الخطوط. الشروط تختلف؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. دائمًا راجع اتفاقية الترخيص الخاصة بالخط قبل توزيع المخرجات.
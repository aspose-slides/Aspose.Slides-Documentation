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
description: "قم بتخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للـ .NET للحفاظ على عروضك التقديمية حادة ومتناسقة عبر أي جهاز."
---
## **نظرة عامة**

Aspose.Slides يسمح لك باستخدام خطوط مخصصة في العروض التقديمية دون تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير الخطوط لعروض تقديمية محددة عبر مصادر خطوط على مستوى المستند، أو تحميل خطوط خارجية مباشرة من بيانات ثنائية.

الخطوط المحملة تُستخدم عند تصيير العرض أو تصديره، على سبيل المثال إلى PDF أو صور أو تنسيقات أخرى مدعومة. هذا يساعد على الحفاظ على تناسق مخرجات العرض عبر بيئات مختلفة. يوضح المقال أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للتصيير منفصل عن تضمين الخطوط في ملف PPTX. إذا كان يجب تخزين خط داخل العرض نفسه، استخدم ميزات تضمين الخط صراحةً.

يمكن لسمة العرض الإشارة إلى عائلات خطوط مختلفة لأنظمة الكتابة الفردية. هذه الخرائط تخزن أسماء الخطوط لكنها لا تقوم بتثبيت أو تحميل ملفات الخط. راجع [خطوط السمة الخاصة بالنصوص](/slides/ar/net/script-specific-font-mappings/) لإدارة الخرائط، واستخدم خيارات التحميل أدناه لجعل الخطوط المشار إليها متاحة لتصيير متسق.

{{% alert color="info" title="Note" %}}
تتيح لك Aspose Slides تحميل هذه الخطوط باستخدام طريقة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):
* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides يسمح لك بتحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. هذا يؤثر على ناتج التصدير — مثل PDF، الصور، وغيرها من التنسيقات المدعومة — بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من دلائل مخصصة.

1. حدد مجلدًا واحدًا أو أكثر يحتوي على ملفات الخط.
2. استدعي الطريقة الساكنة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك المجلدات.
3. حمِّل وصِف/صدّر العرض.
4. استدعي [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة التخزين المؤقت للخطوط.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// تعريف المجلدات التي تحتوي على ملفات خطوط مخصصة.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// تصيير/تصدير العرض (مثال: إلى PDF، صور، أو تنسيقات أخرى) باستخدام الخطوط المحملة.
presentation.Save("output.pdf", SaveFormat.Pdf);

// مسح ذاكرة التخزين المؤقت للخطوط بعد انتهاء العمل.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغير ترتيب تهيئة الخطوط.
يتم تهيئة الخطوط بهذا الترتيب:
1. مسار الخطوط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**

توفر Aspose.Slides طريقة [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) لتسمح لك بالبحث عن مجلدات الخطوط. تعيد هذه الطريقة المجلدات التي تمت إضافتها عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يعرض لك هذا الكود C# كيفية استخدام طريقة [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):
```c#
using Aspose.Slides;

// هذا السطر يعرض المجلدات التي يتم فحصها لملفات الخطوط.
// هذه هي المجلدات التي تم إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

توفر Aspose.Slides الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) لتسمح لك بتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

يعرض لك هذا الكود C# كيفية استخدام الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):
```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // العمل مع العرض
    // الخطوط CustomFont1 و CustomFont2، والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض
}
```

## **إدارة الخطوط خارجياً**

توفر Aspose.Slides طريقة [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) لتحميل الخطوط الخارجية من البيانات الثنائية.

يوضح لك هذا الكود C# عملية تحميل الخط من مصفوفة البايت:
```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // خط خارجي تم تحميله خلال مدة عرض الشرائح
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

للسماح لخط مُسجَّل مطابق أن يحظى بالأولوية أثناء التصدير دون إزالة الخط المضمّن، راجع [تفضيل الخطوط المسجلة على الخطوط المضمَّنة](/slides/ar/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 أو إصدارات أحدث).

## **الأسئلة الشائعة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF، PNG، SVG، HTML)؟**

نعم. يتم استخدام الخطوط المتصلة من قبل المصرّف عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للتصيير ليس هو نفسه تضمينه في ملف PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض، يجب عليك استخدام [ميزات التضمين](/slides/ar/net/embedded-font/) صراحةً.

**هل يمكنني التحكم في سلوك الفولباك عندما يفتقر الخط المخصص إلى بعض الرموز؟**

نعم. قم بتكوين [استبدال الخط](/slides/ar/net/font-substitution/)، [قواعد الاستبدال](/slides/ar/net/font-replacement/)، و[مجموعات الفولباك](/slides/ar/net/fallback-font/) لتحديد الخط الذي يُستخدم بالضبط عندما تكون الرموز المطلوبة مفقودة.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. اشِر إلى مجلدات الخطوط الخاصة بك أو حمِّل الخطوط من مصفوفات البايت. هذا يُزيل أي اعتماد على دلائل الخطوط النظامية في صورة الحاوية.

> **ملاحظة لـ Linux/Docker**: عند استدعاء `FontsLoader.LoadExternalFonts`، تأكد من أن كل عنصر في مصفوفة `directories` يحتوي على مسار غير فارغ إلى دليل موجود. إذا كان متغيّر بيئي يُستخدم لإنشاء مسار الخط غير معرف أو فارغ، قد تحاول Aspose.Slides حل القيمة الفارغة كمسار كامل، مما يؤدي إلى `System.ArgumentException`.

**ماذا عن الترخيص — هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت المسؤول عن الالتزام بترخيص الخطوط. الشروط تختلف؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. احرص دائمًا على مراجعة اتفاقية ترخيص الخط قبل توزيع المخرجات.
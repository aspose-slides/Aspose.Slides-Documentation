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

Aspose.Slides تسمح لك باستخدام الخطوط المخصصة في العروض التقديمية دون تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير الخطوط لعرض تقديمي معين عبر مصادر الخطوط على مستوى المستند، أو تحميل الخطوط الخارجية مباشرةً من بيانات ثنائية.

يتم استخدام الخطوط التي تم تحميلها عندما يتم عرض أو تصدير العرض التقديمي، مثلاً إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك في الحفاظ على تناسق مخرجات العرض عبر بيئات مختلفة. يتناول المقال أيضاً كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للاستخدام في العرض مختلف عن دمج الخطوط في ملف PPTX. إذا كان لابد من تخزين الخط داخل العرض نفسه، استخدم ميزات دمج الخطوط صراحة.

{{% alert color="primary" %}} 
Aspose Slides تسمح لك بتحميل هذه الخطوط باستخدام طريقة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfonts/) :

* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides تسمح لك بتحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير — مثل PDF، الصور، والصيغ المدعومة الأخرى — بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من دلائل مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخطوط.
2. استدعِ الطريقة الساكنة [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك المجلدات.
3. حمّل واعرض/صدّر العرض التقديمي.
4. استدعِ [FontsLoader.ClearCache](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة التخزين المؤقت للخطوط.

المثال التالي يوضح عملية تحميل الخطوط:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// تعريف المجلدات التي تحتوي على ملفات الخطوط المخصصة.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// عرض/تصدير العرض التقديمي (مثل PDF أو الصور أو صيغ أخرى) باستخدام الخطوط التي تم تحميلها.
presentation.Save("output.pdf", SaveFormat.Pdf);

// مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfonts/) يضيف مجلدات إضافية إلى مسارات بحث الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط.
يتم تهيئة الخطوط بالترتيب التالي:

1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**
Aspose.Slides توفر طريقة [GetFontFolders](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/getfontfolders/) لتسمح لك بالعثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أضيفت عبر طريقة `LoadExternalFonts` ومجلدات الخطوط الخاصة بالنظام.

هذا الكود C# يوضح كيفية استخدام [GetFontFolders](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// تقوم هذه السطر بإخراج المجلدات التي يتم فحصها لملفات الخطوط.
// تلك هي المجلدات التي تمت إضافتها عبر طريقة LoadExternalFonts ومجلدات خطوط النظام.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**
Aspose.Slides توفر الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/documentlevelfontsources/) لتسمح لك بتحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

هذا الكود C# يوضح كيفية استخدام الخاصية [DocumentLevelFontSources](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/documentlevelfontsources/):

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
    // الخط CustomFont1، الخط CustomFont2، والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
}
```

## **إدارة الخطوط خارجيًا**

Aspose.Slides توفر الطريقة [LoadExternalFont](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) لتسمح لك بتحميل الخطوط الخارجية من بيانات ثنائية.

هذا الكود C# يوضح عملية تحميل الخط عبر مصفوفة البايتات:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // الخط الخارجي محمّل خلال عمر العرض التقديمي
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF، PNG، SVG، HTML)؟**

نعم. يتم استخدام الخطوط المتصلة من قبل المحرك في جميع صيغ التصدير.

**هل يتم دمج الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للاستخدام في العرض ليس هو نفسه دمجه في PPTX. إذا كنت بحاجة إلى أن يُحمل الخط داخل ملف العرض، يجب عليك استخدام ميزات [الدمج الصريح](/slides/ar/net/embedded-font/).

**هل يمكن التحكم في سلوك الاحتياطي عندما يفتقد الخط المخصص بعض الحروف؟**

نعم. قم بتكوين [استبدال الخطوط](/slides/ar/net/font-substitution/)، [قواعد الاستبدال](/slides/ar/net/font-replacement/)، و[مجموعات الاحتياطي](/slides/ar/net/fallback-font/) لتحديد الخط الذي يُستخدم عندما يكون الحرف المطلوب مفقودًا.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. قم بالإشارة إلى مجلدات الخطوط الخاصة بك أو حمل الخطوط من مصفوفات البايت. يزيل ذلك أي اعتماد على مجلدات الخطوط النظامية في صورة الحاوية.

> **ملاحظة لـ Linux/Docker**: عند استدعاء `FontsLoader.LoadExternalFonts`، تأكد من أن كل عنصر في مصفوفة `directories` يحتوي على مسار غير فارغ لمجلد موجود. إذا كان متغير بيئي يُستخدم لتكوين مسار الخط غير معرف أو فارغ، قد يحاول Aspose.Slides حل القيمة الفارغة كمسار كامل، ما ينتج عنه `System.ArgumentException`.

**ماذا عن الترخيص — هل يمكنني دمج أي خط مخصص بدون قيود؟**

أنت مسؤول عن الامتثال لترخيص الخط. تختلف الشروط؛ بعض التراخيص تحظر الدمج أو الاستخدام التجاري. راجع دائمًا اتفاقية ترخيص المستخدم النهائي (EULA) للخط قبل توزيع المخرجات.
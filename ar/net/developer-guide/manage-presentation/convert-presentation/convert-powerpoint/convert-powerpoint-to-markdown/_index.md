---
title: تحويل عروض PowerPoint إلى Markdown في .NET
linktitle: PowerPoint إلى Markdown
type: docs
weight: 140
url: /ar/net/convert-powerpoint-to-markdown/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى MD
- العرض التقديمي إلى MD
- الشريحة إلى MD
- PPT إلى MD
- PPTX إلى MD
- حفظ PowerPoint كـ Markdown
- حفظ العرض التقديمي كـ Markdown
- حفظ الشريحة كـ Markdown
- حفظ PPT كـ MD
- حفظ PPTX كـ MD
- تصدير PPT إلى MD
- تصدير PPTX إلى MD
- تصدير صور Markdown
- روابط صور CDN
- PowerPoint
- عرض تقديمي
- Markdown
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PPT و PPTX إلى Markdown في .NET والتحكم في مكان حفظ الصور المصدَّرة من نوع bitmap وmetafile وSVG والإشارة إليها."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for .NET تحويل عروض PPT و PPTX إلى تنسيق Markdown للتوثيق، وإنشاء المواقع الثابتة، وهجرة المحتوى، وسير عمل التحكم في الإصدارات. يمكنك اختيار نكهة Markdown، والتحكم في طريقة عرض محتوى الشرائح، وتحديد مكان حفظ الصور المصدَّرة وكيفية إشارة Markdown المُولَّدة إليها.

بشكلٍ افتراضي، يستخدم تصدير Markdown إخراجًا نصيًا فقط. لتصدير المحتوى البصري، اضبط خاصية [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/exporttype/) إلى القيمة `Sequential` أو `Visual` من تعداد [MarkdownExportType](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownexporttype/). تُظهر `Sequential` عناصر الشريحة بشكل منفصل وبالترتيب، بينما تُبقي `Visual` العناصر المجمعة معًا للحفاظ على العلاقة البصرية بينها. القيمة `TextOnly` لا تُصدِّر موارد الصور، لذا لا يتم استدعاء أحداث حفظ الصورة في هذا الوضع.

## **تحويل عرض تقديمي إلى Markdown**

حمِّل ملف المصدر باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/)، ثم استدعِ طريقة [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) مع القيمة `Md` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **اختيار نكهة Markdown**

تتحكم خاصية [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/flavor/) في مواصفة Markdown المستخدمة في الإخراج. يتضمن تعداد [Flavor](https://reference.aspose.com/slides/ar/net/aspose.slides.export/flavor/) CommonMark، وGitHub Flavored Markdown، وغيرها من المتغيّرات المدعومة.

المثال التالي يصدر عرضًا تقديميًا بصيغة CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **تصدير الصور باستخدام سلوك الحفظ المحلي الافتراضي**

توفر فئة [MarkdownSaveOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/) خاصيتين للصور المحفوظة محليًا:

- [BasePath](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/basepath/) يحدّد الدليل الأساسي للمستند Markdown وموارده.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) يحدّد المجلد الفرعي للصور. القيمة الافتراضية هي `Images`.

المثال التالي يعرض المحتوى البصري، يكتب الصور إلى `output/assets`، ويُنشئ إشارات صور نسبية في مستند Markdown:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

يعمل هذا السلوك أيضًا كخيار احتياطي عندما يُعيد مُعالج حفظ الصورة المخصصة القيمة `false`.

## **تخصيص حفظ الصور وروابط Markdown**

استخدم حدث [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/imagesaving/) للموارد غير الـ SVG من نوع bitmap وmetafile التي تُصدر أثناء تصدير Markdown. يتلقى مفوض [MarkdownImageSavingHandler](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) كائن [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/)، و[ImageFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/imageformat/)، ورابط Markdown المُولَّد كمعامل `ref string`. احفظ أو حمّل الصورة باستخدام الصيغة المقدَّمة، واستبدل `link` بالإشارة التي يجب أن تظهر في إخراج Markdown.

تُعالج الموارد المُصدَّرة بصيغة SVG بصورة منفصلة. اشترك في حدث [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) الذي يتلقى مفوض [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) كائن [ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/) ومعامل `ref string link`. لا يحتوي SVG على حجة `ImageFormat`؛ اكتب أو حمّل بيانات XML الخاصة به من خاصية [ISvgImage.SvgData](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/svgdata/) بدلاً من ذلك. بناءً على وضع التصدير وتجمّع العناصر البصرية، قد يتم تحويل SVG في العرض المصدر إلى نقطة نقطية أو دمجه مع محتوى آخر؛ تُمرَّر النتيجة غير الـ SVG إلى `ImageSaving`. اشترك في الحدثين عندما يتطلب كل مورد بصري مُصدَّر معالجة مخصصة.

تحدد قيمة الإرجاع للمُعالج من سيعالج الصورة:

- إرجاع `true` بعد أن يُنقّذ المُعالج الصورة، أو يحمّلها، أو يحوّلها، أو يعالجها بأي طريقة أخرى ويُعيّن قيمة صالحة لـ `link`. تكتب Aspose.Slides تلك القيمة إلى مستند Markdown ولا تقوم بالحفظ المحلي الافتراضي.
- إرجاع `false` للسماح لـ Aspose.Slides بحفظ الصورة محليًا وإنشاء رابطها وفقًا لـ [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/basepath/) و[MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
المُعالج الذي يُعيد `true` يتحمل مسؤولية الصورة. إذا أرجع `true` دون أن يُعيّن ارتباطًا صالحًا غير فارغ، سيفشل التصدير بـ `InvalidOperationException`.
{{% /alert %}}

### **حفظ الصور إلى دليل أصل CDN واستخدام عناوين URL خارجية**

المثال التالي يعامل `cdn-origin/presentations/quarterly-report` كدليل أصل CDN مركّب أو مُزامن. يستخرج كل مُعالج اسم الملف المُولَّد، يحفظ الصورة إلى ذلك الدليل المخصص، ويستبدل الإشارة المحلية المُولَّدة بعنوان URL عام على CDN. لا يُجري النموذج نفسه أي تحميل شبكي: يصبح العنوان صالحًا فقط بعد أن يُركَّب الدليل كأصل CDN أو تُنشر ملفاته على CDN. لتخزين الكائنات، استبدل كتابة نظام الملفات بعملية تحميل SDK التخزينية وعيّن `link` فقط بعد نجاح التحميل.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

المعالج bitmap يُعيد عمدًا `false` للصور أصغر من 128 × 128 بكسل، لذا تقوم Aspose.Slides بحفظ تلك الصور إلى `output/fallback-images` باستخدام السلوك الافتراضي. تُعالج الموارد bitmap وmetafile الأكبر، بالإضافة إلى موارد SVG، بواسطة الشيفرة المخصصة. على سبيل المثال، تتحول إشارة محلية مُولَّدة مثل `fallback-images/image1.png` إلى `https://cdn.example.com/presentations/quarterly-report/image1.png`. يستخدم المُعالجون مسارات نظام التشغيل فقط عند كتابة الملفات؛ وتستخدم الروابط المكتوبة إلى Markdown الشرطات المائلة للأمام وأسماء الملفات المشفَّرة URL. طبّق القاعدة نفسها عند بناء الروابط النسبية: استخدم `/`، لا الفاصل الخاص بالنظام.

## **الأسئلة المتداولة**

**هل يمكن لمُعالج واحد معالجة كل من الصور النقطية وصور SVG؟**

لا. استخدم [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/imagesaving/) للموارد bitmap وmetafile التي تُصدر، و[MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) للموارد الصادرة كـ SVG. الأول يُقدّم كائن [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) وحجة [ImageFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/imageformat/)، بينما الثاني يُقدّم كائن [ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/) يمكن قراءة بيانات SVG من [ISvgImage.SvgData](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/svgdata/). تُعالج SVG المصدرية التي تُحوَّل إلى نقطية أثناء التصدير بواسطة `ImageSaving` بدلًا من ذلك.

**ماذا يحدث عندما يُعيد مُعالج حفظ الصورة القيمة `false`؟**

تستخدم Aspose.Slides سلوك الحفظ المحلي الافتراضي. يتم التحكم في موقع الصورة والإشارة المُولَّدة بواسطة [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/basepath/) و[MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/ar/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**هل يستطيع المُعالج تقديم عنوان URL دون حفظ الصورة محليًا؟**

نعم. يمكن للمُعالج رفع الصورة إلى تخزين الكائنات أو تمريرها إلى خدمة أخرى، تعيين عنوان URL الناتج إلى `link`، وإرجاع `true`. يجب على المُعالج إكمال المعالجة بنفسه؛ إرجاع `true` يمنع الحفظ المحلي الافتراضي.

**لماذا يُلقي تصدير Markdown استثناءً `InvalidOperationException` من المُعالج؟**

يحدث هذا الاستثناء عندما يُعيد المُعالج `true` دون أن يُقدِّم رابطًا صالحًا. عيّن المسار النسبي أو عنوان URL الخارجي الذي يجب كتابته إلى Markdown قبل إرجاع `true`.

**أي فاصل مسار يجب أن تُستخدمه روابط الصور؟**

استخدم الشرطات المائلة للأمام في روابط Markdown وURL. استخدم `Path.Combine` فقط لمسارات نظام الملفات، ثم أنشئ أو طوَّع إشارة Markdown بصورة منفصلة.

**هل تُحافظ الروابط التشعبية على وجودها أثناء تصدير Markdown؟**

نعم. تُحافظ النصوص [hyperlinks](/slides/ar/net/manage-hyperlinks/) كروابط Markdown قياسية. لا تُحوَّل [transitions](/slides/ar/net/slide-transition/) و[animations](/slides/ar/net/powerpoint-animation/) إلى Markdown.

**هل يمكن تحويل العروض التقديمية إلى Markdown بشكل متوازي؟**

يمكنك معالجة ملفات عرض تقديمي مختلفة بصورة متوازية، لكن لا تشترك في نفس كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) بين الخيوط. اتبع [multithreading guidelines](/slides/ar/net/multithreading/) واستخدم كائنًا منفصلًا لكل ملف.
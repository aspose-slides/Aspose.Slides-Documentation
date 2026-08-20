---
title: تحويل PPT إلى PPTX في C++
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/cpp/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT بصيغة PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX في C++ باستخدام Aspose.Slides. يتضمن أمثلة C++ للتحويل الفردي وعلى دفعات، ومعالجة الأخطاء، وملاحظات حول الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي legacy، بينما PPTX هو تنسيق Open XML الأحدث. يمكن لـ Aspose.Slides for C++ تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. يوضح هذا المقال كيفية تحويل ملف واحد أو مجلد من الملفات ويشرح ما يجب التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

حمّل ملف المصدر باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)، ثم استدعِ [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) مع [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/). حرّر العرض عندما لا يكون مطلوبًا لإطلاق الموارد الخاصة به.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

امتداد الملف لا يحدد تنسيق الإخراج بنفسه؛ إنّ المعامل [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/) هو الذي يحدده. احتفظ بمسارات الإدخال والإخراج مختلفة إذا كنت بحاجة إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف `.ppt` في مجلد واحد. تتم معالجة كل ملف بشكل مستقل، لذا لا يتوقف التحويل المتبقي إذا فشل أحد الملفات.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

في بيئات الإنتاج، سجّل الاستثناء بالكامل، قرّر ما إذا كان يمكن استبدال ملف الإخراج الموجود، واكتب أسماء الملفات الفاشلة إلى قائمة إعادة محاولة أو مراجعة. قد تؤدي الملفات التالفة، أو الملفات المحمية بكلمة مرور المفتوحة بدون كلمة المرور المطلوبة، أو المسارات غير المتاحة، أو المحتوى غير المدعوم إلى فشل التحويل. راجع [Password‑Protected Presentations](/cpp/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما يحافظ التحويل على الشرائح، القوالب، التخطيطات، النصوص، الأشكال، الصور، الجداول، والرسوم البيانية. ومع ذلك، لا تمثّل PPT و PPTX كل ميزة بنفس الطريقة تمامًا. قد يتم تعديل أو حذف أو عرض مختلف للميزة القديمة التي لا يوجد لها ما يعادلها في PPTX أو التي لا يدعمها المكتبة.

تحقق من الملف المحوّل عندما يحتوي على رسوم متحركة، انتقالات، كائنات OLE مضمّنة أو مرتبطة، عناصر تحكم ActiveX، وسائط مضمّنة، خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس تنسيقًا يدعم الماكرو، لذا استخدم سير عمل يدعم الماكرو عندما تحتاج إلى إبقاء VBA متاحًا. كما تأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح فيها أو يُعرض العرض التقديمي المحوّل.

للمستندات الهامة، أعد فتح ملف PPTX الناتج برمجيًا وتفقد عدد الشرائح ومحتواها الرئيسي، ثم قارن مظهره وسلوك عرض الشرائح في المشغّل المستهدف. لا تُعتَبَر عملية استدعاء [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) الناجحة دليلًا على أن كل ميزة قديمة لها تمثيل دقيق في PPTX.

## **متى تستخدم PPTX**

استخدم PPTX عندما يُعديل العرض التقديمي في إصدارات PowerPoint الحديثة، أو يتم تبادله مع أنظمة تتعامل مع حزم Open XML، أو يُخزّن بصيغة أسهل للفحص والاسترداد مقارنةً بالـ PPT الثنائي القديم. احتفظ بـ PPT الأصلي كنسخة أرشيفية أو للعودة إليها حتى يجتاز العرض المحوّل فحوصات الدقة الخاصة بك.

إذا كنت بحاجة إلى PDF أو HTML أو صور أو XPS أو أي نوع إخراج آخر، فاتبع الإرشادات الخاصة بذلك في [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) بدلاً من الافتراض بأن جميع الأهداف تحافظ على ميزات PowerPoint القابلة للتحرير.

## **محول عبر الإنترنت**

لملف عائد أو مقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة أو المعالجة الدُفعيّة أو معالجة الأخطاء على مستوى التطبيق، استخدم API الخاصة بـ C++.

## **مقالات ذات صلة**

- [Save Presentations in C++](/cpp/save-presentation/)
- [Supported File Formats](/cpp/supported-file-formats/)
- [Open Presentations in C++](/cpp/open-presentation/)

## **الأسئلة الشائعة**

**هل يمكنني تحويل PPT إلى PPTX بدون تثبيت Microsoft PowerPoint؟**

نعم. يقوم Aspose.Slides for C++ بتحميل وحفظ ملفات العرض التقديمي دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ التحويل من PPT إلى PPTX على كل المحتوى بدقة مطلقة؟**

يحافظ على المحتوى الشائع للعرض التقديمي، لكن الدقة الكاملة غير مضمونة لكل ميزة قديمة أو غير مدعومة. راجع الملف الناتج عندما يحتوي على ماكرو، كائنات OLE أو ActiveX، وسائط، رسوم متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا قدمت كلمة المرور الصحيحة عند تحميل الملف. كلمة مرور مفقودة أو غير صحيحة تتسبب في فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

 احتفظ بالأصل حتى تتحقق من PPTX في المشغلات وسير العمل الذي يهمك. هذا يوفر نسخة للعودة إليها إذا تم تحويل ميزة قديمة بطريقة مختلفة.
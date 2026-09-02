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
- حفظ PPT كـ PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX في C++ باستخدام Aspose.Slides. يتضمن أمثلة C++ للتحويل الفردي والتحويل الجماعي، ومعالجة الأخطاء، وملاحظات الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. يمكن لـ Aspose.Slides for C++ تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. توضح هذه المقالة كيفية تحويل ملف واحد أو دليل من الملفات وتشرح ما الذي يجب التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

قم بتحميل الملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)، ثم استدعِ [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) باستخدام [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/). حرّر العرض التقديمي عندما لا يكون مطلوباً بعد ذلك لتحرير موارده.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// تحميل عرض PPT القديم.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// حفظ العرض التقديمي بصيغة PPTX.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

امتداد الملف لا يحدد تنسيق الإخراج بحد ذاته؛ إنّ معطى [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/) يُحدده. احرص على أن تكون مسارات الإدخال والإخراج مختلفة إذا كنت بحاجة إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف `.ppt` في مجلد واحد. يتم معالجة كل ملف بشكل مستقل، لذا فإن فشل تحويل واحد لا يوقف باقي الدفعة.

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

في بيئات الإنتاج، سجّل الاستثناء بالكامل، وحدد ما إذا كان يمكن استبدال ملف الإخراج الموجود، واكتب أسماء الملفات الفاشلة إلى قائمة إعادة المحاولة أو المراجعة. يمكن أن تتسبب الملفات الفاسدة، والملفات المحمية بكلمة مرور تم فتحها دون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعوم جميعًا في فشل التحويل. راجع [Password-Protected Presentations](/slides/ar/cpp/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما يحافظ التحويل على الشرائح، والنماذج الأساسية، والتخطيطات، والنصوص، والأشكال، والصور، والجداول، والرسوم البيانية. ومع ذلك، لا تمثل صيغتي PPT و PPTX كل ميزة بنفس الطريقة تمامًا. قد يتم تطبيع أو حذف أو عرض مختلف لميزة قديمة لا توجد لها مكافئ في PPTX أو لا يدعمها المكتبة.

تحقق من الملف المحوَّل عندما يحتوي على رسوم متحركة، أو انتقالات، أو كائنات OLE مدمجة أو مرتبطة، أو عناصر تحكم ActiveX، أو وسائط مدمجة، أو خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس بتنسيق يدعم الماكرو، لذا استخدم سير عمل مناسب يدعم الماكرو عندما يجب أن يبقى VBA متاحًا. كما تأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح أو يُعرض فيها العرض التقديمي المحوَّل.

بالنسبة للوثائق الهامة، أعد فتح ملف PPTX الذي تم إنشاؤه برمجيًا وتفحص عدد الشرائح الرئيسية ومحتواها، ثم قارن مظهره وسلوك العرض الشرائحي في المشاهد المستهدف. لا تعتبر استدعاء [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) الناجح دليلًا على أن كل ميزة قديمة لها تمثيل دقيق في PPTX.

## **متى يجب استخدام PPTX**

استخدم PPTX عندما يتم تحرير العرض التقديمي في إصدارات PowerPoint الحالية، أو تبادله مع أنظمة تعمل مع حزم Open XML، أو حفظه بتنسيق يسهل فحصه واستعادته مقارنةً بملف PPT الثنائي القديم. احتفظ بملف PPT الأصلي كنسخة أرشيفية أو احتياطية حتى يجتاز العرض المحوَّل فحوصات الدقة الخاصة بك.

إذا كنت تحتاج إلى PDF أو HTML أو صور أو XPS أو أي نوع إخراج آخر، استخدم الإرشادات الخاصة بالتنسيق في [Convert Presentations to Multiple Formats](/slides/ar/cpp/convert-presentation/) بدلاً من الافتراض أن جميع الأهداف تحتفظ بميزات PowerPoint القابلة للتحرير.

## **محول على الإنترنت**

لملف عرض تقديمي عرضي أو لمقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة، أو المعالجة الدفعية، أو معالجة الأخطاء على مستوى التطبيق، استخدم واجهة برمجة التطبيقات C++.

## **مقالات ذات صلة**

- [حفظ العروض التقديمية في C++](/slides/ar/cpp/save-presentation/)
- [تنسيقات الملفات المدعومة](/slides/ar/cpp/supported-file-formats/)
- [فتح العروض التقديمية في C++](/slides/ar/cpp/open-presentation/)

## **الأسئلة الشائعة**

**هل يمكنني تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم. يقوم Aspose.Slides for C++ بتحميل وحفظ ملفات العروض التقديمية دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ تحويل PPT إلى PPTX على جميع المحتويات بدقة؟**

إنه يحتفظ بالمحتوى الشائع للعرض التقديمي، لكن الدقة الكاملة غير مضمونة لكل ميزة قديمة أو غير مدعومة. راجع الملف الذي تم إنشاؤه عندما يحتوي على ماكرو، أو كائنات OLE أو ActiveX، أو وسائط، أو رسومات متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا قمت بتوفير كلمة المرور الصحيحة عند تحميل الملف. عدم وجود كلمة مرور أو كلمة مرور غير صحيحة يتسبب في فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالأصل حتى تتحقق من ملف PPTX في المشاهد وسير العمل ذات الأهمية بالنسبة لك. هذا يوفر نسخة احتياطية في حال تم تحويل ميزة قديمة بشكل مختلف.
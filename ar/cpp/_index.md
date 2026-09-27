---
title: Aspose.Slides لـ C++
second_title: Aspose.Slides لـ C++
type: docs
weight: 30
url: /ar/cpp/
keywords:
- توثيق
- معالجة العروض
- تحويل العروض
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "ابدأ هنا: ثبّت Aspose.Slides للـ C++، أنشئ أول عرض تقديمي، وابحث عن الأدلة للمهام الشائعة، ومرجع API والدعم."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ هي مكتبة C++ أصلية لإنشاء، قراءة، تعديل وتحويل عروض PowerPoint وOpenDocument، بدون الحاجة إلى Microsoft PowerPoint أو أتمتة Office.

تقوم بتحميل وحفظ PPT، PPTX، PPS، POT وODP، بما في ذلك الإصدارات التي تدعم الماكرو والقوالب، وتصدّر إلى PDF، XPS، HTML، SVG، TIFF، Markdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>البدء</b></p>
<hr>
<p>بدء الاستخدام</p>
<ul>
<li><a href="/slides/ar/cpp/installation/">التثبيت</a></li>
<li><a href="/slides/ar/cpp/create-presentation/">إنشاء أول عرض تقديمي لك</a></li>
<li><a href="/slides/ar/cpp/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/cpp/supported-file-formats/">تنسيقات الملفات المدعومة</a></li>
<li><a href="/slides/ar/cpp/evaluate-aspose-slides/">قيود النسخة التجريبية</a></li>
<li><a href="/slides/ar/cpp/licensing/">الترخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>البناء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/cpp/open-presentation/">فتح عرض تقديمي</a></li>
<li><a href="/slides/ar/cpp/save-presentation/">حفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/cpp/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/cpp/convert-slide/">تصدير الشرائح كصور</a></li>
<li><a href="/slides/ar/cpp/manage-text/">تحرير النص والأشكال</a></li>
</ul>
<p>سير عمل Slides</p>
<ul>
<li><a href="/slides/ar/cpp/powerpoint-charts/">الرسوم البيانية</a></li>
<li><a href="/slides/ar/cpp/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/cpp/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/cpp/presentation-design/">تصميم الشريحة</a></li>
<li><a href="/slides/ar/cpp/merge-presentation/">دمج العروض التقديمية</a></li>
</ul>
<p>الأمثلة</p>
<ul>
<li><a href="/slides/ar/cpp/examples/">أمثلة حسب عنصر الشريحة</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">أمثلة على GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>المرجع والدعم</b></p>
<hr>
<p>المرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ar/cpp/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/ar/cpp/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/cpp/known-issues/">المشكلات المعروفة</a></li>
<li><a href="https://releases.aspose.com/slides/ar/cpp/">التنزيل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ar/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب المساعدة للدعم المدفوع</a></li>
</ul>
</div>
</div>

------

## **أول عرض تقديمي لك**

في نظام Windows، أنشئ مشروع C++ **Console App** في Visual Studio وقم بتثبيت حزمة NuGet عبر Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

في نظام Linux، قم بتحميل حزمة ZIP للـ Linux وقم بإعداد مشروع CMake الموضح في [التثبيت](/slides/ar/cpp/installation/#linux).

ثم استخدم هذا الشيفرة كملف المصدر الرئيسي لبرنامجك. تنشئ عرض تقديمي بجهة نص واحدة وتحفظه:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

لتشغيله على Windows، اختر منصة **x64** من شريط الأدوات واضغط **Ctrl+F5**. على Linux، احفظه كـ *main.cpp* في مجلد المشروع، ثم ابنِه وشغّله هناك:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

يحفظ البرنامج *hello.pptx* بشريحة واحدة تحتوي على جهة نص. بدون ترخيص، يحمل الملف المحفوظ علامة مائية تجريبية — انظر [الترخيص](/slides/ar/cpp/licensing/). لمزيد من الطرق لإنشاء وتعبئة عرض تقديمي، انظر [إنشاء عروض تقديمية](/slides/ar/cpp/create-presentation/).
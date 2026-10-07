---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /ar/cpp/
keywords:
- توثيق
- معالجة العروض التقديمية
- تحويل العروض التقديمية
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "ابدأ هنا: ثبّت Aspose.Slides for C++، أنشئ أول عرض تقديمي، واعثر على الأدلة للمهام الشائعة، ومرجع API والدعم."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ هي مكتبة C++ أصلية لإنشاء وقراءة وتعديل وتحويل عروض PowerPoint وOpenDocument، دون الحاجة إلى Microsoft PowerPoint أو أتمتة Office.

تقوم بتحميل وحفظ صيغ PPT وPPTX وPPS وPOT وODP، بما في ذلك الإصدارات التي تدعم الماكرو والقوالب، وتصدّر إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/cpp/installation/">التثبيت</a></li>
<li><a href="/slides/ar/cpp/create-presentation/">إنشاء أول عرض تقديمي لك</a></li>
<li><a href="/slides/ar/cpp/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/cpp/supported-file-formats/">تنسيقات الملفات المدعومة</a></li>
<li><a href="/slides/ar/cpp/evaluate-aspose-slides/">قيود النسخة التجريبية</a></li>
<li><a href="/slides/ar/cpp/licensing/">التراخيص</a></li>
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
<li><a href="/slides/ar/cpp/convert-slide/">تحويل الشرائح إلى صور</a></li>
<li><a href="/slides/ar/cpp/manage-text/">تحرير النصوص والأشكال</a></li>
</ul>
<p>سير عمل Slides</p>
<ul>
<li><a href="/slides/ar/cpp/powerpoint-charts/">المخططات</a></li>
<li><a href="/slides/ar/cpp/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/cpp/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/cpp/presentation-design/">تصميم الشرائح</a></li>
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
<li><a href="https://reference.aspose.com/slides/cpp/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/cpp/known-issues/">المشكلات المعروفة</a></li>
<li><a href="https://products.aspose.com/slides/cpp/">صفحة المنتج</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">التنزيل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب مساعدة الدعم المدفوع</a></li>
</ul>
</div>
</div>

------

## **أول عرض تقديمي لك**

في نظام Windows، أنشئ مشروع **Console App** بلغة C++ في Visual Studio وقم بتثبيت حزمة NuGet عبر نافذة Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**):
```powershell
Install-Package Aspose.Slides.Cpp
```

في نظام Linux، نزّل حزمة ZIP الخاصة بـ Linux وأعد إعداد مشروع CMake الوارد في [التثبيت](/slides/ar/cpp/installation/#linux).

بعد ذلك استخدم هذا الكود كملف المصدر الرئيسي لبرنامجك. يقوم بإنشاء عرض تقديمي يحتوي على صندوق نص واحد ويحفظه:
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

لتشغيله على Windows، اختر منصة **x64** من شريط الأدوات واضغط **Ctrl+F5**. على Linux، احفظه كملف *main.cpp* في مجلد المشروع، ثم ابنِه وشغّله هناك:
```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

يقوم البرنامج بحفظ *hello.pptx* مع شريحة واحدة تحتوي على صندوق نص. بدون ترخيص، يحتوي الملف المحفوظ على علامة مائية تجريبية — راجع [التراخيص](/slides/ar/cpp/licensing/). لمزيد من الطرق لإنشاء وتعبئة عرض تقديمي، راجع [إنشاء العروض التقديمية](/slides/ar/cpp/create-presentation/).
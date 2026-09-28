---
title: "Aspose.Slides لـ .NET"
second_title: "Aspose.Slides لـ .NET"
type: docs
weight: 10
url: /ar/net/
keywords:
- "توثيق"
- "معالجة العروض التقديمية"
- "تحويل العروض التقديمية"
- "PowerPoint"
- "OpenDocument"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "ابدأ هنا: قم بتثبيت Aspose.Slides لـ .NET، أنشئ أول عرض تقديمي، واعثر على الأدلة للمهام الشائعة، والنشر، ومرجع API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET هي مكتبة فئات لإنشاء وقراءة وتعديل وتحويل عروض PowerPoint وOpenDocument في تطبيقات .NET، دون الحاجة إلى Microsoft PowerPoint أو أتمتة Office.

تدعم تحميل وحفظ صيغ PPT وPPTX وPPS وPOT وODP، بما في ذلك النسخ التي تدعم الماكرو والقوالب، وتصدير إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/net/installation/">التثبيت</a></li>
<li><a href="/slides/ar/net/create-presentation/">إنشاء أول عرض تقديمي لك</a></li>
<li><a href="/slides/ar/net/system-requirements/">متطلبات النظام</a></li>
<li><a href="/slides/ar/net/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/net/supported-file-formats/">تنسيقات الملفات المدعومة</a></li>
<li><a href="/slides/ar/net/features-overview/">نظرة عامة على الميزات</a></li>
<li><a href="/slides/ar/net/evaluate-aspose-slides/">قيود النسخة التجريبية</a></li>
<li><a href="/slides/ar/net/licensing/">التراخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>بناء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/net/open-presentation/">فتح عرض تقديمي</a></li>
<li><a href="/slides/ar/net/save-presentation/">حفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/net/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/net/convert-slide/">تحويل الشرائح إلى صور</a></li>
<li><a href="/slides/ar/net/manage-text/">تحرير النصوص والأشكال</a></li>
</ul>
<p>تدفقات عمل Slides</p>
<ul>
<li><a href="/slides/ar/net/powerpoint-charts/">الرسوم البيانية</a></li>
<li><a href="/slides/ar/net/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/net/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/net/presentation-design/">تصميم الشريحة</a></li>
<li><a href="/slides/ar/net/merge-presentation/">دمج العروض التقديمية</a></li>
</ul>
<p>أمثلة</p>
<ul>
<li><a href="/slides/ar/net/examples/">أمثلة حسب عنصر الشريحة</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">أمثلة على GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>النشر والدعم</b></p>
<hr>
<p>النشر</p>
<ul>
<li><a href="/slides/ar/net/net6/">متعدد المنصات (.NET 6+)</a></li>
<li><a href="/slides/ar/net/how-to-run-aspose-slides-in-docker/">التشغيل في Docker</a></li>
<li><a href="/slides/ar/net/deploy-fonts/">الخطوط</a></li>
<li><a href="/slides/ar/net/security/">الأمان</a></li>
</ul>
<p>المرجعية</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/net/known-issues/">مشكلات معروفة</a></li>
<li><a href="/slides/ar/net/api-limitations/">قيود بيانات التعريف الناتجة</a></li>
<li><a href="https://releases.aspose.com/slides/net/">تحميل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب مساعدة الدعم المدفوع</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **أول عرض تقديمي لك**

قم بإنشاء تطبيق console باستخدام .NET SDK 6 أو أحدث:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

ثم أضف حزمة واحدة لمنصتك:

- على Windows: `dotnet add package Aspose.Slides.NET`
- على Linux و macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — راجع [التثبيت](/slides/ar/net/installation/) للمتطلبات المسبقة على Linux وللأنظمة التي تحتاج إلى Aspose.Slides.NET بدلاً من ذلك.

استبدل محتويات *Program.cs* بهذا الكود وشغّل `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

يقوم البرنامج بحفظ *hello.pptx* بشرحة واحدة تحتوي على مربع نص. بدون ترخيص، يحتوي الملف المحفوظ على علامة مائية للتقييم — راجع [التراخيص](/slides/ar/net/licensing/). للمزيد من الطرق لإنشاء وتعبئة عرض تقديمي، راجع [إنشاء عروض تقديمية](/slides/ar/net/create-presentation/).
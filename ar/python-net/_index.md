---
title: Aspose.Slides لـ Python عبر .NET
second_title: Aspose.Slides لـ Python
type: docs
weight: 35
url: /ar/python-net/
is_root: true
keywords:
- Aspose.Slides لـ Python
- أتمتة PowerPoint باستخدام Python
- مكتبة Python للـ PPT
- تصدير PowerPoint إلى PDF باستخدام Python
- تصدير PowerPoint إلى SVG باستخدام Python
- تحرير PowerPoint في Python
- PowerPoint لـ Python بدون Microsoft Office
- إدارة PPTX باستخدام Python
- معاينة الشرائح باستخدام Python
- إضافة صوت إلى الشرائح في Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "ابدأ هنا: قم بتثبيت Aspose.Slides لـ Python عبر .NET، أنشئ أول عرض تقديمي، وتعرف على الأدلة للمهام الشائعة، ومرجع API والدعم."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET هو مكتبة بايثون لإنشاء وقراءة وتحرير وتحويل عروض PowerPoint وOpenDocument، دون الحاجة إلى Microsoft PowerPoint أو Microsoft Office.

يمكنه تحميل وحفظ صيغ PPT وPPTX وPPS وPOT وODP، بما في ذلك المتغيرات التي تدعم الماكرو والقوالب، ويصدّر إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>البدء</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/python-net/installation/">التثبيت</a></li>
<li><a href="/slides/ar/python-net/create-presentation/">إنشاء أول عرض تقديمي لك</a></li>
<li><a href="/slides/ar/python-net/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/python-net/supported-file-formats/">صيغ الملفات المدعومة</a></li>
<li><a href="/slides/ar/python-net/evaluate-aspose-slides/">قيود النسخة التجريبية</a></li>
<li><a href="/slides/ar/python-net/licensing/">التراخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>البناء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/python-net/open-presentation/">فتح عرض تقديمي</a></li>
<li><a href="/slides/ar/python-net/save-presentation/">حفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/python-net/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/python-net/convert-slide/">عرض الشرائح كصور</a></li>
<li><a href="/slides/ar/python-net/manage-text/">تحرير النصوص والأشكال</a></li>
</ul>
<p>مسارات عمل Slides</p>
<ul>
<li><a href="/slides/ar/python-net/powerpoint-charts/">المخططات</a></li>
<li><a href="/slides/ar/python-net/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/python-net/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/python-net/presentation-design/">تصميم الشريحة</a></li>
<li><a href="/slides/ar/python-net/merge-presentation/">دمج العروض التقديمية</a></li>
</ul>
<p>الأمثلة</p>
<ul>
<li><a href="/slides/ar/python-net/examples/">أمثلة حسب عنصر الشريحة</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">أمثلة على GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>المرجع والدعم</b></p>
<hr>
<p>المرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">صفحة المنتج</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">تحميل</a></li>
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

قم بتثبيت الحزمة من PyPI:

```bash
pip install aspose.slides
```

تتضمن الحزمة وقت تشغيل .NET الذي تستخدمه، لذلك لا تحتاج إلى تثبيت .NET. على Linux، قم أيضًا بتثبيت مكتبات libgdiplus وICU، ومع Python النظام في Debian أو Ubuntu، شغّل الأمر داخل بيئة افتراضية. macOS لديها متطلبات مسبقة إضافية، ولم نتحقق من التثبيت هناك. راجع [التثبيت](/slides/ar/python-net/installation/) للحصول على الأوامر ومتطلبات macOS وإصدارات Python المدعومة.

احفظ هذا الكود كـ *hello.py*:

```py
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من النوع CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

شغّله باستخدام `python hello.py`. يحفظ السكريبت *new_presentation.pptx* في المجلد الحالي، مع شريحة واحدة تحتوي على شكل سحابة يكتب "Hello, Aspose!". بدون ترخيص، يحتوي الملف المحفوظ على علامة مائية للتقييم — راجع [التراخيص](/slides/ar/python-net/licensing/). لمزيد من الطرق لإنشاء وتعبئة عرض تقديمي، راجع [إنشاء عروض تقديمية](/slides/ar/python-net/create-presentation/).
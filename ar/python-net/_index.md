---
title: "Aspose.Slides للبايثون عبر .NET"
second_title: "Aspose.Slides للبايثون"
type: docs
weight: 35
url: /ar/python-net/
is_root: true
keywords:
- "Aspose.Slides للبايثون"
- "أتمتة PowerPoint بايثون"
- "مكتبة PPT بايثون"
- "تصدير PowerPoint إلى PDF بايثون"
- "تصدير PowerPoint إلى SVG بايثون"
- "تحرير PowerPoint بايثون"
- "PowerPoint بايثون بدون Microsoft Office"
- "إدارة PPTX بايثون"
- "معاينة الشرائح بايثون"
- "إضافة صوت إلى الشرائح بايثون"
- "PowerPoint"
- "OpenDocument"
- "Python"
- "Aspose.Slides"
description: "ابدأ هنا: ثبّت Aspose.Slides للبايثون عبر .NET، أنشئ أول عرض تقديمي، وابحث عن الأدلة للمهام الشائعة، مرجع API والدعم."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET هو مكتبة بايثون لإنشاء وقراءة وتحرير وتحويل عروض PowerPoint وOpenDocument، دون الحاجة إلى Microsoft PowerPoint أو Microsoft Office.

يقوم بتحميل وحفظ ملفات PPT وPPTX وPPS وPOT وODP، بما في ذلك المتغيرات المدعومة بالماكرو والقوالب، ويصدر إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/python-net/installation/">التثبيت</a></li>
<li><a href="/slides/ar/python-net/create-presentation/">إنشاء عرضك الأول</a></li>
<li><a href="/slides/ar/python-net/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/python-net/supported-file-formats/">تنسيقات الملفات المدعومة</a></li>
<li><a href="/slides/ar/python-net/evaluate-aspose-slides/">قيود الإصدار التجريبي</a></li>
<li><a href="/slides/ar/python-net/licensing/">الترخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>بناء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/python-net/open-presentation/">فتح عرض</a></li>
<li><a href="/slides/ar/python-net/save-presentation/">حفظ عرض</a></li>
<li><a href="/slides/ar/python-net/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/python-net/convert-slide/">عرض الشرائح كصور</a></li>
<li><a href="/slides/ar/python-net/manage-text/">تحرير النص والأشكال</a></li>
</ul>
<p>سير عمل Slides</p>
<ul>
<li><a href="/slides/ar/python-net/powerpoint-charts/">المخططات</a></li>
<li><a href="/slides/ar/python-net/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/python-net/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/python-net/presentation-design/">تصميم الشريحة</a></li>
<li><a href="/slides/ar/python-net/merge-presentation/">دمج العروض</a></li>
</ul>
<p>أمثلة</p>
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
<li><a href="https://reference.aspose.com/slides/ar/python-net/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/ar/python-net/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="https://releases.aspose.com/slides/ar/python-net/">تحميل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ar/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب مساعدة الدعم المدفوع</a></li>
</ul>
</div>
</div>

------

## **العرض التقديمي الأول لك**

قم بتثبيت الحزمة من PyPI:

```bash
pip install aspose.slides
```

تتضمن الحزمة وقت تشغيل .NET الذي تستخدمه، لذا لا تحتاج إلى تثبيت .NET. على نظام Linux، قم أيضًا بتثبيت مكتبات libgdiplus وICU، ومع Python النظام في Debian أو Ubuntu، شغّل الأمر في بيئة افتراضية. macOS يتطلب متطلبات إضافية، ولم نتحقق من التثبيت هناك. راجع [التثبيت](/slides/ar/python-net/installation/) للحصول على الأوامر ومتطلبات macOS وإصدارات Python المدعومة.

احفظ هذا الكود كملف *hello.py*:

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    # احصل على الشريحة الأولى.
    slide = presentation.slides[0]

    # أضف شكلًا تلقائيًا من النوع CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # احفظ العرض التقديمي كملف PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

شغّله باستخدام `python hello.py`. يحفظ البرنامج النصي *new_presentation.pptx* في المجلد الحالي، مع شريحة واحدة تحتوي على شكل سحابة يحمل النص "Hello, Aspose!". بدون ترخيص، يحتوي الملف المحفوظ على علامة مائية تجريبية — راجع [الترخيص](/slides/ar/python-net/licensing/). لمزيد من الطرق لإنشاء وتعبئة عرض، راجع [إنشاء عروض](/slides/ar/python-net/create-presentation/).
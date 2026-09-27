---
title: Aspose.Slides لـ Python عبر Java
second_title: Aspose.Slides لـ Python
type: docs
weight: 47
url: /ar/python-java/
is_root: true
keywords:
- Aspose.Slides لـ Python عبر Java
- مكتبة Python لPowerPoint
- إدارة عروض PowerPoint التقديمية في Python
- قراءة وكتابة PowerPoint في Python
- تحرير شرائح PowerPoint في Python
- تصدير PowerPoint إلى PDF في Python
- تصدير PowerPoint إلى SVG في Python
- معاينة الشرائح في Python
- إضافة صوت وفيديو إلى الشرائح في Python
- PowerPoint دون Microsoft Office
- بايثون
- جافا
- Aspose.Slides
description: "ابدأ هنا: قم بتثبيت Aspose.Slides لـ Python عبر Java، أنشئ أول عرض تقديمي، وابحث عن الأدلة للمهام الشائعة، ومرجع API والدعم."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java هي مكتبة لإنشاء وقراءة وتحرير وتحويل عروض PowerPoint وOpenDocument في تطبيقات بايثون، دون الحاجة إلى Microsoft PowerPoint؛ فهي تشغل محرك Aspose.Slides Java في عملية بايثون الخاصة بك عبر JPype.

تدعم تحميل وحفظ ملفات PPT وPPTX وPPS وPOT وODP، بما في ذلك الإصدارات المدعومة للماكرو والقوالب، وتصدّر إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/python-java/installation/">التثبيت</a></li>
<li><a href="/slides/ar/python-java/create-presentation/">إنشاء أول عرض تقديمي لك</a></li>
<li><a href="/slides/ar/python-java/getting-started/">دليل البدء</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/python-java/supported-file-formats/">تنسيقات الملفات المدعومة</a></li>
<li><a href="/slides/ar/python-java/evaluate-aspose-slides/">قيود التجربة</a></li>
<li><a href="/slides/ar/python-java/licensing/">الترخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>البناء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/python-java/open-presentation/">فتح عرض تقديمي</a></li>
<li><a href="/slides/ar/python-java/save-presentation/">حفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/python-java/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/python-java/convert-slide/">تحويل الشرائح إلى صور</a></li>
<li><a href="/slides/ar/python-java/manage-text/">تحرير النص والأشكال</a></li>
</ul>
<p>سير عمل Slides</p>
<ul>
<li><a href="/slides/ar/python-java/powerpoint-charts/">المخططات</a></li>
<li><a href="/slides/ar/python-java/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/python-java/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/python-java/presentation-design/">تصميم الشرائح</a></li>
<li><a href="/slides/ar/python-java/merge-presentation/">دمج العروض التقديمية</a></li>
</ul>
<p>أمثلة</p>
<ul>
<li><a href="/slides/ar/python-java/examples/">أمثلة حسب عنصر الشريحة</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>المرجع&amp;الدعم</b></p>
<hr>
<p>المرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ar/python-java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/ar/python-java/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/python-java/known-issues/">المشكلات المعروفة</a></li>
<li><a href="https://releases.aspose.com/slides/ar/python-java/">تنزيل</a></li>
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

قم بتثبيت بايثون وJDK، عيّن `JAVA_HOME`، وأنشئ وفعل بيئة افتراضية كما هو موضح في [التثبيت](/slides/ar/python-java/installation/). ثم قم بتثبيت JPype وAspose.Slides من PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

احفظ هذا الكود باسم *hello.py*. يبدأ تشغيل Java Virtual Machine، ويضيف شكل سحابة بنص إلى الشريحة الأولى من عرض تقديمي جديد، ويحفظ العرض التقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# إنشاء عرض تقديمي بشريحة فارغة واحدة.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل سحابة وتعيين نصه.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

شغّله في نفس البيئة الافتراضية:

```sh
python hello.py
```

يحفظ السكريبت الملف *new_presentation.pptx* بشريحة واحدة تحتوي على شكل سحابة مع النص "Hello, Aspose!". بدون ترخيص، يحتوي الملف المحفوظ أيضًا على علامة مائية للتقييم — راجع [الترخيص](/slides/ar/python-java/licensing/). لمزيد من الطرق لإنشاء وتعبئة عرض تقديمي، راجع [إنشاء عروض تقديمية](/slides/ar/python-java/create-presentation/).
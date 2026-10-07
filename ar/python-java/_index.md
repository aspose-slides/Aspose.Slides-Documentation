---
title: Aspose.Slides لـ Python عبر Java
second_title: Aspose.Slides لـ Python
type: docs
weight: 47
url: /ar/python-java/
is_root: true
keywords:
- Aspose.Slides لـ Python عبر Java
- مكتبة PowerPoint للـ Python
- إدارة عروض PowerPoint في Python
- قراءة وكتابة PowerPoint في Python
- تحرير شرائح PowerPoint في Python
- تصدير PowerPoint إلى PDF في Python
- تصدير PowerPoint إلى SVG في Python
- معاينة الشرائح في Python
- إضافة صوت وفيديو إلى الشرائح في Python
- PowerPoint دون Microsoft Office
- Python
- Java
- Aspose.Slides
description: "ابدأ هنا: ثبّت Aspose.Slides لـ Python عبر Java، أنشئ العرض الأول، وابحث عن الأدلة للمهام الشائعة، ومرجع API والدعم."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java هي مكتبة لإنشاء وقراءة وتحرير وتحويل عروض PowerPoint وOpenDocument في تطبيقات Python، دون الحاجة إلى Microsoft PowerPoint؛ فهي تشغل محرك Aspose.Slides Java في عملية Python الخاصة بك عبر JPype.

تقوم بتحميل وحفظ ملفات PPT وPPTX وPPS وPOT وODP، بما في ذلك الإصدارات التي تدعم الماكرو والقوالب، وتصدّر إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/python-java/installation/">التثبيت</a></li>
<li><a href="/slides/ar/python-java/create-presentation/">إنشاء عرضك الأول</a></li>
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
<li><a href="/slides/ar/python-java/open-presentation/">فتح عرض</a></li>
<li><a href="/slides/ar/python-java/save-presentation/">حفظ عرض</a></li>
<li><a href="/slides/ar/python-java/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/python-java/convert-slide/">تصدير الشرائح كصور</a></li>
<li><a href="/slides/ar/python-java/manage-text/">تحرير النصوص والأشكال</a></li>
</ul>
<p>تدفقات عمل Slides</p>
<ul>
<li><a href="/slides/ar/python-java/powerpoint-charts/">الرسوم البيانية</a></li>
<li><a href="/slides/ar/python-java/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/python-java/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/python-java/presentation-design/">تصميم الشرائح</a></li>
<li><a href="/slides/ar/python-java/merge-presentation/">دمج العروض</a></li>
</ul>
<p>الأمثلة</p>
<ul>
<li><a href="/slides/ar/python-java/examples/">أمثلة حسب عنصر الشريحة</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>المرجع والدعم</b></p>
<hr>
<p>المرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/python-java/known-issues/">المشكلات المعروفة</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">صفحة المنتج</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">التنزيل</a></li>
</ul>
<p>الدعم</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب المساعدة للدعم المدفوع</a></li>
</ul>
</div>
</div>

------

## **العرض الأول الخاص بك**

قم بتثبيت Python وJDK، اضبط `JAVA_HOME`، وأنشئ وفّعل بيئة افتراضية كما هو موضح في [التثبيت](/slides/ar/python-java/installation/). ثم قم بتثبيت JPype وAspose.Slides من PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

احفظ هذا الكود باسم *hello.py*. يبدأ تشغيل آلة Java الافتراضية، ويضيف شكل سحابة مع نص إلى الشريحة الأولى من عرض جديد، ويحفظ العرض:

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

يحفظ السكريبت *new_presentation.pptx* بشريحة واحدة تحتوي على شكل سحابة بالنص "Hello, Aspose!". بدون ترخيص، يحتوي الملف المحفوظ أيضًا على علامة مائية للتقييم — راجع [الترخيص](/slides/ar/python-java/licensing/). لمزيد من الطرق لإنشاء وتعبئة عرض، راجع [إنشاء العروض](/slides/ar/python-java/create-presentation/).
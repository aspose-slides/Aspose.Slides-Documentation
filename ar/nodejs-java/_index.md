---
title: Aspose.Slides لـ Node.js عبر Java
second_title: Aspose.Slides لـ Node.js
type: docs
weight: 47
url: /ar/nodejs-java/
keywords:
- توثيق
- معالجة العروض التقديمية
- تحويل العروض التقديمية
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "ابدأ هنا: قم بتثبيت Aspose.Slides لـ Node.js عبر Java، أنشئ عرضًا تقديميًا أولًا، واعثر على الأدلة للمهام الشائعة، ومرجع API، والدعم."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides لـ Node.js عبر Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides لـ Node.js عبر Java هي مكتبة لإنشاء وقراءة وتعديل وتحويل عروض PowerPoint وOpenDocument في تطبيقات Node.js، دون الحاجة إلى Microsoft PowerPoint.

تدعم تحميل وحفظ ملفات PPT وPPTX وPPS وPOT وODP، بما في ذلك الإصدارات ذات الماكرو والقوالب، وتُمكن من تصديرها إلى PDF وXPS وHTML وSVG وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>البدء</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/ar/nodejs-java/installation/">التثبيت</a></li>
<li><a href="/slides/ar/nodejs-java/create-presentation/">إنشاء العرض التقديمي الأول الخاص بك</a></li>
<li><a href="/slides/ar/nodejs-java/getting-started/">دليل البدء</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/ar/nodejs-java/supported-file-formats/">تنسيقات الملفات المدعومة</a></li>
<li><a href="/slides/ar/nodejs-java/evaluate-aspose-slides/">قيود التجربة</a></li>
<li><a href="/slides/ar/nodejs-java/licensing/">التراخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>إنشاء باستخدام Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/ar/nodejs-java/open-presentation/">فتح عرض تقديمي</a></li>
<li><a href="/slides/ar/nodejs-java/save-presentation/">حفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/nodejs-java/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/nodejs-java/convert-slide/">تصيير الشرائح كصور</a></li>
<li><a href="/slides/ar/nodejs-java/manage-text/">تحرير النصوص والأشكال</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/ar/nodejs-java/powerpoint-charts/">المخططات</a></li>
<li><a href="/slides/ar/nodejs-java/powerpoint-animation/">الرسوم المتحركة</a></li>
<li><a href="/slides/ar/nodejs-java/manage-media-files/">الصوت والفيديو</a></li>
<li><a href="/slides/ar/nodejs-java/presentation-design/">تصميم الشرائح</a></li>
<li><a href="/slides/ar/nodejs-java/merge-presentation/">دمج العروض التقديمية</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/ar/nodejs-java/examples/">أمثلة حسب عنصر الشريحة</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>المرجع والدعم</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="/slides/ar/nodejs-java/known-issues/">المشكلات المعروفة</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-java/">صفحة المنتج</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">التحميل</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">منتدى الدعم المجاني</a></li>
<li><a href="https://helpdesk.aspose.com/">مكتب المساعدة للدعم المدفوع</a></li>
</ul>
</div>
</div>

------

## **العرض التقديمي الأول الخاص بك**

بالإضافة إلى Node.js 20 أو أحدث، تحتاج الحزمة إلى مجموعة تطوير جافا (JDK) وPython وأدوات بناء C++، لأن npm يقوم بترجمة جسر `java` أثناء التثبيت. راجع [Installation](/slides/ar/nodejs-java/installation/) للحصول على الخطوات الخاصة بكل نظام تشغيل. ثم أنشئ مشروعًا وقم بتثبيت الحزمة من npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

احفظ هذا الكود كملف *hello.js* في مجلد المشروع:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// تشغل Aspose.Slides في آلة افتراضية جافا تبقي Node.js قيد التشغيل، لذا يجب إنهاء العملية صراحةً.
process.exit(0);
```

شغّله باستخدام `node hello.js`. يقوم السكربت بحفظ *hello.pptx* مع شريحة واحدة تحتوي على مربع نص. بدون ترخيص، يحتوي الملف المحفوظ على علامة مائية للتقييم — راجع [Licensing](/slides/ar/nodejs-java/licensing/). لمزيد من الطرق لإنشاء وتعبئة عرض تقديمي، انظر [Create Presentations](/slides/ar/nodejs-java/create-presentation/).
---
title: Aspose.Slides for Node.js via .NET
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /ar/nodejs-net/
keywords:
- توثيق
- معالجة العروض التقديمية
- تحويل العروض التقديمية
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "ابدأ هنا: ثبّت Aspose.Slides for Node.js عبر .NET، أنشئ أول عرض تقديمي، واعثر على الأدلة للمهام الشائعة، والترخيص، ومرجع API، والدعم."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET هي مكتبة لإنشاء وقراءة وتحرير وتحويل عروض PowerPoint وOpenDocument في تطبيقات Node.js، دون الحاجة إلى Microsoft PowerPoint أو أتمتة Office. تقوم بتشغيل Aspose.Slides for .NET عبر جسر edge-js، لذا فإن واجهة برمجة JavaScript تعكس واجهة .NET، مع أسماء الأعضاء بصيغة camelCase.

إنه يقوم بتحميل وحفظ ملفات PPT وPPTX وPPS وPOT وODP، بما في ذلك الإصدارات المدعوة بالماكرو والقوالب، ويصدّر إلى PDF وXPS وHTML وTIFF وMarkdown والصور.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>ابدأ</b></p>
<hr>
<p>البدء</p>
<ul>
<li><a href="/slides/ar/nodejs-net/installation/">التثبيت</a></li>
<li><a href="/slides/ar/nodejs-net/create-presentation/">إنشاء أول عرض تقديمي لك</a></li>
<li><a href="/slides/ar/nodejs-net/developer-guide/">دليل المطور</a></li>
</ul>
<p>التقييم</p>
<ul>
<li><a href="/slides/ar/nodejs-net/evaluate-aspose-slides/">قيود النسخة التجريبية</a></li>
<li><a href="/slides/ar/nodejs-net/licensing/">الترخيص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>البناء باستخدام Slides</b></p>
<hr>
<p>المهام الشائعة</p>
<ul>
<li><a href="/slides/ar/nodejs-net/open-presentation/">فتح وحفظ عرض تقديمي</a></li>
<li><a href="/slides/ar/nodejs-net/convert-powerpoint-to-pdf/">تحويل إلى PDF</a></li>
<li><a href="/slides/ar/nodejs-net/convert-slide/">تحويل الشرائح إلى صور</a></li>
<li><a href="/slides/ar/nodejs-net/manage-text/">تحرير النص</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>المرجع &amp; الدعم</b></p>
<hr>
<p>المرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">مرجع API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">ملاحظات الإصدار</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">صفحة المنتج</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">تحميل</a></li>
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

تحتاج إلى Node.js 22 أو 24 و.NET SDK 8 أو أحدث؛ يحتاج Linux أيضًا إلى بعض حزم النظام. [التثبيت](/slides/ar/nodejs-net/installation/) يدرجها والمنصات التي تم اختبارها. أنشئ مشروعًا، أضف تجاوزًا يخبر npm أي نسخة من edge-js يجب تثبيتها، ثم قم بتثبيت الحزمة:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

مرة واحدة لكل جهاز، استعد حزم .NET التي تعتمد عليها المكتبة. احفظ ملف `deps.csproj` من [استعادة تبعيات .NET](/slides/ar/nodejs-net/installation/#restore-the-net-dependencies) في مجلد `deps` داخل مجلد المشروع، ثم نفّذ:

```sh
dotnet restore deps/deps.csproj
```

احفظ هذا الكود كملف *hello.js* في مجلد المشروع:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// عرض تقديمي جديد يحتوي على شريحة فارغة واحدة.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // الموضع والحجم بوحدات النقاط (1/72 بوصة): س، ص، العرض، الارتفاع.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // تحرير كائن .NET الذي يدعم العرض التقديمي.
    presentation.dispose();
}
```

شغّله من مجلد المشروع:

```sh
node hello.js
```

يعرض البرنامج النصي `Saved hello.pptx` ويحفظ *hello.pptx* بشريحة واحدة تحتوي على مستطيل بالنص. بدون ترخيص، يحمل الملف المحفوظ علامة مائية تقييم — راجع [الترخيص](/slides/ar/nodejs-net/licensing/). لمزيد من الطرق لإنشاء وتعبئة عرض تقديمي، راجع [إنشاء عرض تقديمي](/slides/ar/nodejs-net/create-presentation/).
---
title: الترخيص
description: "تطبيق ملف ترخيص على Aspose.Slides لـ Node.js عبر .NET، ومعرفة حدود نسخة التقييم، والحصول على ترخيص مؤقت مجاني لمدة 30 يومًا للاختبار."
type: docs
weight: 80
url: /ar/nodejs-net/licensing/
---
## **نظرة عامة**

Aspose.Slides for Node.js عبر .NET هو حزمة npm واحدة للتقييم والإنتاج معًا. بدون ترخيص، يعمل في وضع التقييم. بعد شرائك لترخيص، أو الحصول على ترخيص مؤقت مجاني لمدة 30 يومًا، تقوم بتطبيقه ببضع سطر من الشفرة، ولن تُطبق قيود التقييم بعد ذلك.

{{% alert color="info" title="Note" %}}
سياسات عامة حول كيفية تقييم وترخيص وشراء منتجات Aspose مُجمّعة في [Purchase Policies and FAQ](https://purchase.aspose.com/policies). الأسعار مُدرجة في صفحة [Pricing Information](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

## **قيود إصدار التقييم**

يوفر إصدار التقييم جميع وظائف المنتج، مع قيّدتين:

- **علامة مائية.** كل شريحة من كل عرض تقديمي تقوم بحفظه تحصل على علامة مائية للتقييم: صندوق نص مقفل في منتصف الشريحة يقرأ "Evaluation only". تُرسم نفس العلامة المائية في تصدير PDF وXPS وHTML وعلى صور الشرائح.
- **نص مقطوع.** النص الذي تسترجعه شفرتك من إطار نص أو فقرة أو جزء يتم قطعه إلى أول خمسة أحرف، يليه الإشعار "... text has been truncated due to evaluation version limitation." يتم تقصير تصدير Markdown وHTML5 بنفس الطريقة. النص الذي تكتبه الشفرة يُحفظ بالكامل.

[Evaluate Aspose.Slides](/slides/ar/nodejs-net/evaluate-aspose-slides/) يصف كلا القيدين بالتفصيل ويتضمن برنامجًا نصيًا يوضحهما.

{{% alert color="success" title="Tip" %}}
لاختبار Aspose.Slides بدون قيود التقييم، اطلب ترخيصًا مؤقتًا مجانيًا لمدة **30 يومًا**. راجع [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) للحصول على التفاصيل.
{{% /alert %}}

## **حول الترخيص**

الترخيص هو ملف XML نصّي عادي يحتوي على تفاصيل مثل اسم المنتج، عدد المطورين المرخص لهم، وتاريخ انتهاء الاشتراك. الملف موقّع رقمياً، لذا لا تقم بتعديله: حتى إضافة سطر فارغ عن طريق الخطأ يبطل صلاحية الترخيص.

## **تطبيق الترخيص**

قم بتطبيق الترخيص باستخدام طريقة `setLicense` من فئة `License`. استدعها مرة واحدة لكل عملية، قبل إنشاء أي كائن `Presentation`. الاستدعاء مرة أخرى لا يسبب ضررًا، لكنه يكرّر العمل الذي تمّ إنجازه بالفعل.

البرنامج النصي التالي يطبق ترخيصًا من ملف يُدعى `Aspose.Slides.lic`. استبدل الاسم بالاسم أو المسار الكامل لملف الترخيص الخاص بك؛ يمكن للملف أن يحمل أي اسم.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

يُفسَّر اسم الملف أو المسار النسبي بالنسبة للمجلد الحالي، وهو المجلد الذي تشغّل منه `node`. احفظ ملف الترخيص في مجلد المشروع وشغّل البرامج النصية من هناك، أو مرّر المسار الكامل.

إذا تعذر العثور على الملف، أو لم يكن ترخيصًا صالحًا، ترمي `setLicense` خطأ، وتظل Aspose.Slides في وضع التقييم. يلتقط البرنامج النصي الخطأ ويطبع رسالته. في حالة ملف مفقود، تبدأ الرسالة بـ `License "Aspose.Slides.lic" doesn't exist or access is restricted.` وتُدرج كل المواقع التي تم البحث فيها.

في هذه الحزمة، يُطبق الترخيص من ملف فقط. لا تقبل `License` تدفقًا، ولا تُظهر الحزمة الترخيص القائم على العداد. للاطلاع على الفئة التي تغلفها الحزمة، راجع [License](https://reference.aspose.com/slides/net/aspose.slides/license/) في مرجع API الخاص بـ Aspose.Slides for .NET.
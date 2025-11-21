---
title: PPT مقابل PPTX
type: docs
weight: 10
url: /ar/nodejs-java/ppt-vs-pptx/
keywords: "PPT مقابل PPTX"
description: "اقرأ عن الفروق بين PPT و PPTX في Aspose.Slides."
---

## **ما هو PPT؟**

[**PPT**](https://docs.fileformat.com/presentation/ppt/) هو تنسيق ملف ثنائي، أي أنه من المستحيل عرض محتواه بدون أدوات خاصة. النسخ الأولى من PowerPoint 97-2003 كانت تعمل بتنسيق ملف PPT، لكن قابلية التوسيع لهذا التنسيق محدودة.

## **ما هو PPTX؟**

[**PPTX**](https://docs.fileformat.com/presentation/pptx/) هو تنسيق ملف عرض تقديمي جديد، يعتمد على معيار Office Open XML (ISO 29500:2008-2016، ECMA-376). يتمحور PPTX حول مجموعة مؤرشفة من ملفات XML والوسائط. تنسيق PPTX سهل التوسيع؛ فمثلاً يمكن إضافة دعم لنوع مخطط جديد أو شكل جديد دون الحاجة لتغيير تنسيق PPTX في كل نسخة جديدة من PowerPoint. يُستخدم تنسيق PPTX بدءاً من PowerPoint 2007.

## **PPT مقابل PPTX**

على الرغم من أن PPTX يوفر وظائف أوسع بكثير، لا يزال PPT شائعاً. الحاجة إلى التحويل من PPT إلى PPTX والعكس مطلوبة بشدة.

مع ذلك، يُعد التحويل بين تنسيق PPT القديم وPPTX الجديد أكثر التحديات تعقيداً بين تنسيقات Microsoft Office الأخرى. على الرغم من أن مواصفات تنسيق PPT مفتوحة، إلا أن العمل به صعب. يمكن لـ PowerPoint إنشاء أجزاء خاصة (MetroBlob) في ملفات PPT لتخزين معلومات من PPTX لا يدعمها تنسيق PPT ولا يمكن عرضها في إصدارات PowerPoint القديمة. يمكن استعادة هذه المعلومات عند تحميل ملف PPT في نسخة PowerPoint حديثة أو تحويله إلى تنسيق PPTX.

توفر Aspose.Slides فئة عامة للعمل مع جميع تنسيقات العروض التقديمية. تتيح التحويل من PPT إلى PPTX ومن PPTX إلى PPT بطريقة بسيطة جداً. تدعم Aspose.Slides بالكامل التحويل من PPT إلى PPTX وتدعم أيضاً التحويل من PPTX إلى PPT مع بعض القيود. نوصي باستخدام تنسيق PPTX كلما كان ذلك ممكناً.

{{% alert color="primary" %}} 

تحقق من جودة التحويلات من PPT إلى PPTX ومن PPTX إلى PPT باستخدام تطبيق [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/) على الإنترنت.

{{% /alert %}} 
```javascript
// إنشاء كائن Presentation يمثل ملف PPT
var pres = new aspose.slides.Presentation("PPTtoPPTX.ppt");
try {
    // حفظ عرض PPT إلى تنسيق PPTX
    pres.save("PPTtoPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
اقرأ المزيد عن [**كيفية تحويل العروض التقديمية من PPT إلى PPTX**](/slides/ar/nodejs-java/convert-ppt-to-pptx/).
{{% /alert %}} 

## **الأسئلة المتكررة**

**هل هناك فائدة من الاحتفاظ بالعروض القديمة بصيغة PPT إذا كانت تُفتح دون أخطاء؟**

إذا كان العرض يُفتح بموثوقية ولا يحتاج إلى التعاون أو المميزات الأحدث، يمكنك الاحتفاظ به بصيغة PPT. ولكن لضمان التوافق المستقبلي وإمكانية التوسيع، من الأفضل [تحويل إلى PPTX](/slides/ar/nodejs-java/convert-ppt-to-pptx/): التنسيق مبني على معيار OOXML المفتوح ويسهل دعمه من الأدوات الحديثة.

**كيف يمكنني تحديد أي الملفات يجب تحويلها إلى PPTX أولاً؟**

ابدأ بتحويل العروض التي: يتم تحريرها من قبل عدة أشخاص؛ تحتوي على مخططات [معقدة](/slides/ar/nodejs-java/create-chart/) أو [أشكال](/slides/ar/nodejs-java/shape-manipulations/); تُستخدم في اتصالات خارجية؛ أو تُظهر تحذيرات عند [فتحها](/slides/ar/nodejs-java/open-presentation/).

**هل سيتم الحفاظ على حماية كلمة المرور عند التحويل من PPT إلى PPTX والعكس؟**

يتم نقل كلمة المرور فقط إذا تم التحويل بشكل صحيح وتوافر دعم التشفير في الأداة المستخدمة. من الأكثر موثوقية أن تقوم بـ[إزالة الحProtection](/slides/ar/nodejs-java/password-protected-presentation/)، ثم [التحويل](/slides/ar/nodejs-java/convert-ppt-to-pptx/)، ثم إعادة تطبيق الحProtection وفقاً لسياسة الأمان الخاصة بك.

**لماذا تختفي بعض المؤثرات أو تُبسط عند تحويل PPTX مرة أخرى إلى PPT؟**

لأن PPT لا يدعم بعض الكائنات/الخصائص الأحدث. يمكن لـ PowerPoint والأدوات تخزين "آثار" هذه المعلومات في كتل خاصة لاستعادتها لاحقاً، لكن إصدارات PowerPoint القديمة لا يمكنها عرضها.
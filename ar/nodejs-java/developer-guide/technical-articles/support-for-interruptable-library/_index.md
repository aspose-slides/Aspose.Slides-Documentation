---
title: إلغاء عمليات العرض التقديمي طويلة الأمد في Node.js
linktitle: إلغاء عمليات العرض التقديمي
type: docs
weight: 120
url: /ar/nodejs-java/support-for-interruptable-library/
keywords:
- عمليات قابلة للإلغاء
- رمز الإيقاف
- رمز الإلغاء
- مهلة التحويل
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "إلغاء عمليات العرض التقديمي طويلة التنفيذ في Aspose.Slides لـ Node.js عبر Java، تعيين مهلة التحويل، ومتابعة الشرائح التي تم تصديرها قبل الإلغاء."
---
## **نظرة عامة**

تدعم Aspose.Slides for Node.js عبر Java الإلغاء عند تحميل أو حفظ أو عرض عرض تقديمي. يمكنك أيضًا فحص الرمز نفسه في حلقة التصدير الخاصة بك للتوقف قبل الشريحة التالية وإرجاع أرقام الشرائح التي تم حفظها بالفعل.

## **إيقاف عملية عرض تقديمي**

قم بإنشاء [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/)، احصل على رمزه باستخدام [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken)، ومرره إلى [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). استخدم هذه الخيارات عند إنشاء [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). استدعاء [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) على المصدر يطلب إلغاء العملية الحالية. يتوقف Aspose.Slides عندما يتحقق من الرمز في المرة التالية.

### **تعيين مهلة التحويل**

يسمح المثال التالي بـ 20 ثانية لفتح `sample.pptx` وحفظه كـ `sample.pdf`. يعمل كل من المُنشئ وعملية الحفظ بشكل غير متزامن عبر جسر Java بحيث يمكن لمؤقت Node.js أن يُشغل أثناء أي عملية. يتحقق المثال من الرمز بعد التحميل ومرة أخرى بعد الحفظ، لأن نداء المكتبة يمكن أن يعود بعد طلب الإلغاء. يطلق العرض التقديمي عندما تستقر العملية ويُمسح المؤقت إذا انتهى التحويل مبكرًا. إذا حدث إلغاء أثناء الحفظ، قد يكون ملف الإخراج موجودًا بالفعل وقد يكون غير مكتمل.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

لتحويل إلى تنسيق PowerPoint القديم بحد أقصى 10 ثوانٍ، مرّر `"sample.ppt"`، `slides.SaveFormat.Ppt`، و`10000` كأخر ثلاث وسائط.

## **التوقف قبل معالجة الشريحة التالية**

استخدم [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) قبل كل عملية تصدير عندما يمكن للمتصل استخدام نتيجة جزئية. التحميل الزائد [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) للشرائح المحددة يأخذ مصفوفة Java `int[]` لأرقام الشرائح بدءًا من 1. سجّل كل رقم فقط بعد حفظ ملف PDF الخاص به بنجاح.

شغّل المثال بعرض تقديمي يُدعى `sample.pptx` يحتوي على شريحتين على الأقل. لإظهار الإلغاء بين عمليات التصدير، يطلب المثال الإلغاء مباشرةً بعد حفظ الشريحة الأولى.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

المثال يكتب `slide-1.pdf` ويطبع `Starting slide 1` ثم `Completed: [1]`. الحلقة تلاحظ الإلغاء قبل بدء الشريحة 2. إذا تم مقاطعة عملية الحفظ نفسها، تحتوي القائمة المرجعة فقط على عمليات التصدير الناجحة السابقة.

لسماح للمتصل بمعالجة الإلغاء كخطأ، استبدل الفحص و`break` في أعلى الحلقة بـ [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) يُستدعى كـ `token.throwIfInterruptionRequested()`. استخدم نفس الفحص بعد الحفظ واحذف الـ `try`/`catch` حوله. مع نفس الإدخال، لا يزال يتم كتابة ملف PDF الأول، وتطرح الدورة الثانية استثناءً قبل أن تتمكن الدالة من إرجاع قائمة.

## **الأسئلة الشائعة**

**متى يجب أن أطلب الإلغاء؟**  
اطلب الإلغاء عندما ينتهي الموعد النهائي أو عندما لا يحتاج التطبيق النتيجة بعد الآن. يمكن لكل من التحميل والحفظ والعرض استخدام الرمز الممرّر إلى العرض التقديمي عند الإنشاء.

**كيف يختلف المصدر عن الرمز؟**  
المصدر يتيح للتطبيق طلب الإلغاء. الرمز يتيح لـ Aspose.Slides وكودك الخاص التحقق من ذلك الطلب.

**هل يمكن لمؤقت Node.js إيقاف حفظ متزامن؟**  
الحفظ المتزامن يحجب JavaScript على الخيط المستدعي. استخدم نداءات جسر Java غير المتزامنة الموضحة في مثال المهلة بحيث يمكن للمؤقت طلب الإلغاء أثناء تشغيل عملية الحفظ.

**هل يُطبق الإلغاء فورًا؟**  
الإلغاء تعاوني. تتوقف العملية القيد التشغيل عندما تلاحظ الطلب. العملية التي انتهت بالفعل تحتفظ بنتيجتها.

**هل يمكن لعدة عمليات مشاركة مصدر واحد؟**  
نعم. استدعاء `interrupt()` يطلب إلغاء كل عملية تستخدم رمزًا من ذلك المصدر. استخدم مصدرًا منفصلًا لكل عملية تريد إلغاءها بشكل مستقل.
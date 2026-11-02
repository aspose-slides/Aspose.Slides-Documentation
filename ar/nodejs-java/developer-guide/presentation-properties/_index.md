---
title: إدارة خصائص العرض التقديمي في JavaScript
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/nodejs-java/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- خصائص مدمجة
- خصائص مخصصة
- خصائص متقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات تعريف المستند
- تحرير بيانات التعريف
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides لـ Node.js عبر Java وسهل عملية البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **المقدمة**

Aspose.Slides for Node.js عبر Java يدعم خصائص المستند **المدمجة** و **المخصصة**. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل المؤلف، العنوان، والقيم المعرفة من قبل المستخدم.

Aspose.Slides يتيح لك العمل مع خصائص مستند العرض التقديمي عبر الفئة [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties). يتم إرجاع نسخة من هذه الفئة بواسطة [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). تعرض الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
تدير Aspose.Slides بيانات التعريف الخاصة بالتطبيق والمنتج عند حفظ العروض التقديمية؛ هذه الحقول تحدد البرنامج الذي أنشأ النتيجة.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية إلى جانب محتوى العرض التقديمي. تنقسم إلى فئتين:

- **الخصائص المدمجة** تحتوي على بيانات تعريف قياسية، مثل العنوان، المؤلف، وإحصاءات المستند.
- **الخصائص المخصصة** تخزن أزواج اسم/قيمة يحددها المستخدم.

Aspose.Slides for Node.js عبر Java يوفر الوصول إلى كلا الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لتفقد بيانات تعريف المستند. تقوم النافذة بتجميع المعلومات في علامات تبويب مثل **Summary**، **Statistics**، **Contents**، و **Custom**. استخدم علامة التبويب **Custom** لإدارة الخصائص المعرفة من قبل المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

كلمة المرور المفتوحة تحمي عادةً كل من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير العرض التقديمي بعد استدعاء [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) بـ `false`، تظل خصائص المستند عامة. يمكن للتطبيق بعد ذلك استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) بـ `true` وقراءة البيانات العامة دون تزويد كلمة المرور المفتوحة.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) يتحكم فيما يقوم Aspose.Slides بتحميله؛ لا يقوم بفك التشفير. إذا تم تضمين الخصائص في عملية التشفير، سيؤدي تحميلها بدون كلمة المرور إلى فشل. إذا لم يكن العرض التقديمي مشفرًا، يتم تجاهل الخيار ويتم تحميل العرض التقديمي بالكامل.

يتطلب المثال عرضًا تقديميًا مشفرًا تُركت خصائصه العامة. يتحقق من وضع التحميل عبر [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) ثم يقرأ الخصائص المدمجة عبر [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، والكائنات الأخرى غير متاحة. يجب على التطبيقات دائمًا التحقق من [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) قبل إجراء أي عملية تتطلب نموذج كائن العرض التقديمي الكامل.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات العامة عن أسماء المؤلفين، العناوين، المواضيع، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة. شفر الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما تتطلب أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة لملف PPTX مشفر، فإن العرض المُحمَّل بعد استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) بـ `true` يهدف إلى قراءة البيانات العامة فقط. لا يمكن لـ Aspose.Slides حفظ الخصائص المعدلة من ذلك الكائن الذي يحمل البيانات العامة فقط لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفر. لذا فإن تحديثها يتطلب كلمة المرور المفتوحة الصحيحة وتحميلًا كاملاً.

يتطلب المثال عرضًا تقديميًا PPTX مشفرًا يحتوي على خصائص مستند عامة وكلمة مرور مفتوحة معروفة. يفتح العرض الكامل باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword)، يحدّث الخصائص المدمجة العامة، ويحفظ النتيجة. ثم يستخدم [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) للتحقق من بقاء التشفير ويعيد فتح البيانات العامة دون كلمة مرور للتحقق من القيم الجديدة:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض، يجب أن يتعامل مع الخصائص العامة لملف PPTX مشفر على أنها للقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

الفئة [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) تكشف عن بيانات التعريف المدمجة عبر طرق getter، بما في ذلك [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor)، [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle)، و [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). يفتح هذا المثال عرضًا تقديميًا موجودًا ويطبع بياناته المخزنة إلى وحدة التحكم. القيم تعتمد على العرض المدخل؛ قد تكون بعض الحقول فارغة.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **تعديل الخصائص المدمجة**

لتحديث البيانات المدمجة، استخدم طرق setter على الكائن المرتجع من [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). يفتح هذا المثال عرضًا تقديميًا موجودًا، يستدعي [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor)، [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle)، [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject)، [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments)، و [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager)، ثم يحفظ العرض المحدث باستخدام [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). يحتوي ملف PPTX المحفوظ على البيانات التعريفية الجديدة.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إدارة أساس الارتباط التشعبي**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) يُعيد الأساس على مستوى المستند للارتباطات التشعبية النسبية. استخدم [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) لتغييره أو مسحه. هذا مفيد عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. وهو منفصل عن [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) الخاص بكل ارتباط تشعبي: تعديل الأساس لا يُعيد كتابة عناوين الروابط المخزنة ولا يغير الوجهات المطلقة.

يتطلب المثال عرضًا تقديميًا يحتوي على كل من ارتباط نسبي، مثل `target.html`، وارتباط مطلق، مثل `https://example.org/absolute.html`. يقرأ الأساس الحالي، يعيّن أساسًا جديدًا، ثم يحفظ ويعيد فتح العرض للتحقق من القيمة. بعدها يمسح الأساس بسلسلة فارغة ويتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل عنوان الأساس في المثال بموقع ملفاتك المرتبطة.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

يجب أن تُظهر رسائلي التحقق `true`. مسح الأساس يترك عناوين الروابط التشعبية الفردية كما هي.

ارتباط نسبي إلى `target.pptx` فتح `old/target.pptx` عندما كان الأساس يشير إلى المجلد `old`. بعد تغيير الأساس إلى المجلد `new`، وحفظ وإعادة فتح العرض، فتح نفس الرابط `new/target.pptx`. الرابط المطلق استمر في فتح نفس الملف. اختبر روابطك النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير أسسه.

## **إضافة خصائص عرض تقديمي مخصصة**

تخزن الخصائص المخصصة بيانات تعريف لا يوجد لها حقل مدمج مكافئ. تسمح طريقة [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) لك بتعيين قيمة بحسب اسم الخاصية. يخلق هذا المثال عرضًا تقديميًا، يضيف قيمتي نص وقيمة عددية للإصدار، ويحفظ العرض باستخدام [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية الحالية.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الوصول إلى الخصائص المخصصة وتعديلها**

يفتح هذا المثال عرضًا تقديميًا يحتوي على خصائص مخصصة ويستخدم [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) للتكرار عليها. تُعيد [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) اسمًا بناءً على فهرس يبدأ من الصفر، وهو الاسم المستخدم في [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item). يطبع المثال كل اسم وقيمة أصلية، يستبدل كل قيمة بسلسلة مرقمة بغض النظر عن نوعها الأصلي، ثم يحفظ التغييرات. إذا لم توجد خصائص مخصصة، لا يُجري الحلقة أي تعديل.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مثال حي**

جرب التطبيق عبر الإنترنت [**عرض وتعديل بيانات تعريف PowerPoint**](https://products.aspose.app/slides/metadata) لرؤية كيفية العمل مع خصائص المستند باستخدام واجهة Aspose.Slides API:

[![عرض وتعديل بيانات تعريف PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من العرض التقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. مع ذلك، يمكنك إما تغيير قيمتها أو تعيينها إلى فارغ إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟**

إذا أضفت خاصية مخصصة موجودة مسبقًا، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. ليس عليك إزالة الخاصية أو التحقق منها مسبقًا، فـ Aspose.Slides ستقوم بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) ثم [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) لقراءة بيانات التعريف المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). انظر [بناء جرد عرض تقديمي خفيف الوزن](/slides/ar/nodejs-java/examine-presentation/) للحصول على مثال تقرير كامل والقيود الخاصة بكل تنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر دون كلمة المرور المفتوحة؟**

نعم. يجب أن يكون العرض قد تم تشفيره بعد استدعاء [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) بـ `false`، ويجب تحميله بعد استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) بـ `true`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع تحميل الخصائص فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض بالكامل مع كلمة المرور المفتوحة الصحيحة.
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
- بيانات المستند الوصفية
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحكم كامل في خصائص العرض التقديمي باستخدام Aspose.Slides for Node.js عبر Java وقم بتحسين البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **مدمجة** و **مخصصة**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتهما بسهولة باستخدام واجهة برمجة تطبيقات Aspose.Slides.

يتيح لك Aspose.Slides العمل مع خصائص مستند العرض التقديمي عبر الفئة [DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/) . تُرجِع طريقة [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getDocumentProperties) مثيلًا من هذه الفئة. تُظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يرجى ملاحظة أن حقلي **Application** و **AppVersion** لا يمكن تعديلهما. يعيد Aspose.Slides كتابة هذين الحقلين في كل عملية حفظ، لذا فإن أي عرض تقديمي محفوظ دائمًا يشير إلى "Aspose.Slides for Node.js via Java" وإصدار المكتبة التي أنتجته. يتم تجاهل أي قيمة تُمرَّر إلى `setNameOfApplication` عند كتابة العرض التقديمي.
{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العرض التقديمي. تسمح هذه الخصائص بتخزين معلومات مفيدة إلى جانب المستندات (ملفات العرض). هناك نوعان من خصائص المستند كما يلي

- خصائص معرفة بالنظام (مدمجة)
- خصائص معرفة بالمستخدم (مخصصة)

تحتوي الخصائص **المدمجة** على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصاءات المستند وغيرها. الخصائص **المخصصة** هي تلك التي يُعرّفها المستخدم كأزواج **اسم/قيمة**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for Node.js via Java، يمكن للمطورين الوصول إلى قيم الخصائص المدمجة وكذلك الخصائص المخصصة وتعديلها.

## **خصائص المستند في PowerPoint**

يسمح Microsoft PowerPoint 2007 بإدارة خصائص المستند لملفات العروض التقديمية. كل ما عليك فعله هو النقر على أيقونة Office ثم اختيار **Prepare | Properties | Advanced Properties** كما هو موضح أدناه:

|**تحديد عنصر القائمة الخصائص المتقدمة**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
بعد اختيار عنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
في **حوار الخصائص** أعلاه، يمكنك رؤية أن هناك العديد من الصفحات مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. تسمح جميع هذه الصفحات بتكوين معلومات مختلفة تتعلق بملفات PowerPoint. تُستخدم صفحة **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

### العمل مع خصائص المستند باستخدام Aspose.Slides for Node.js via Java

كما وصفنا في البداية، يدعم Aspose.Slides for Node.js via Java نوعين من خصائص المستند، وهما **مدمجة** و **مخصصة**. لذا يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة برمجة تطبيقات Aspose.Slides for Node.js via Java. يوفر Aspose.Slides for Node.js via Java الفئة [DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties) التي تمثل خصائص المستند المرتبطة بملف عرض تقديمي عبر الخاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام الخاصية **DocumentProperties** التي يوفّرها كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) للوصول إلى خصائص المستند لملفات العروض كما هو موضح أدناه:

## **قراءة الخصائص العامة من عرض تقديمي مشفّر**

عادةً ما يحمي كلمة مرور الفتح كلًا من محتوى العرض وخصائص المستند. عندما يتم تشفير عرض تقديمي بتمرير `false` إلى [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)، تظل خصائص المستند عامة. يمكن للتطبيق بعد ذلك تمرير `true` إلى [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) وقراءة البيانات الوصفية العامة دون توفير كلمة مرور الفتح.

الخيار الذي يقتصر على خصائص المستند يتحكم في ما يقوم Aspose.Slides بتحميله؛ لا يقوم بفك التشفير. إذا تم تضمين الخصائص في التشفير، فإن تحميلها دون كلمة المرور سيفشل. إذا لم يكن العرض مشفّرًا، يتم تجاهل الخيار ويتم تحميل العرض بالكامل.

المثال التالي يتحقق من وضع التحميل عبر [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) ثم يقرأ الخصائص المدمجة عبر [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا فحص [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) قبل تنفيذ عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات الوصفية العامة أسماء المؤلفين، العناوين، المواضيع، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض. اتركها عامة فقط عندما يكون الفهرسة أو التصنيف أو البحث أو أنظمة إدارة المستندات تتطلب الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفّر**

بالنسبة لملف PPTX مشفّر، يُقصد من العرض المحمّل في وضعية خصائص المستند فقط قراءة البيانات الوصفية العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص المتغيّرة من ذلك الكائن ذو البيانات الوصفية فقط لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفّر. لذلك يتطلب التحديث كلمة مرور الفتح الصحيحة وتحميلًا كاملاً.

المثال التالي يفتح العرض باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword)، يحدّث الخصائص المدمجة العامة، ويحفظ النتيجة. ثم يستخدم [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) للتحقق من بقاء التشفير، ويعيد فتح البيانات الوصفية العامة بدون كلمة مرور للتحقق من القيم الجديدة:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض، يجب التعامل مع الخصائص العامة لملف PPTX مشفّر كقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

تشمل هذه الخصائص التي تُظهرها كائن [DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **SharedDoc** (هل يتم المشاركة بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن Presentation الذي يمثل العرض التقديمي
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن IDocumentProperties المرتبط بالعرض التقديمي
    var dp = pres.getDocumentProperties();
    // عرض الخصائص المدمجة
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تعديل الخصائص المدمجة**

تعديل الخصائص المدمجة لملفات العرض سهل كما هو الحال في الوصول إليها. يمكنك ببساطة إسناد قيمة نصية إلى أي خاصية تريدها وستتغيّر قيمة الخاصية. في المثال أدناه، أوضحنا كيف يمكننا تعديل خصائص المستند المدمجة للعرض باستخدام Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن IDocumentProperties المرتبط بالعرض التقديمي
    var dp = pres.getDocumentProperties();
    // تعيين الخصائص المدمجة
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // حفظ العرض التقديمي إلى ملف
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

هذا المثال يُعدِّل الخصائص المدمجة للعرض كما هو موضح أدناه:

|**خصائص المستند المدمجة بعد التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصصة**

يسمح Aspose.Slides for Node.js via Java أيضًا للمطورين بإضافة قيم مخصصة لخصائص مستند العرض. المثال أدناه يُظهر كيفية تعيين الخصائص المخصصة لعرض تقديمي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // الحصول على خصائص المستند
    var dProps = pres.getDocumentProperties();
    // إضافة خصائص مخصصة
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // الحصول على اسم الخاصية عند الفهرس المحدد
    var getPropertyName = dProps.getCustomPropertyName(2);
    // إزالة الخاصية المحددة
    dProps.removeCustomProperty(getPropertyName);
    // حفظ العرض التقديمي
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**خصائص المستند المخصصة المضافة**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides for Node.js via Java أيضًا للمطورين بالوصول إلى قيم الخصائص المخصصة. المثال أدناه يُظهر كيفية الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن DocumentProperties المرتبط بالعرض التقديمي
    var dp = pres.getDocumentProperties();
    // الوصول إلى الخصائص المخصَّصة وتعديلها
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // عرض أسماء وقيم الخصائص المخصَّصة
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // تعديل قيم الخصائص المخصَّصة
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // حفظ العرض التقديمي إلى ملف
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

هذا المثال يُعدِّل الخصائص المخصصة للـ [PPTX](https://docs.fileformat.com/presentation/pptx/) العرض. تُظهر الأشكال التالية خصائص العرض المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصصة بعد التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="info" title="Note" %}}
تمت إضافة طرق جديدة [ReadDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) إلى [PresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo)، وتم تعديل منطق الخاصية [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) .
{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) إلى فئة [PresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo). توفّران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض بالكامل.

يمكن تنفيذ السيناريو المعتاد بتحميل الخصائص، تغيير بعض القيم، وتحديث المستند بالطريقة التالية:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// قراءة معلومات العرض التقديمي
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// الحصول على الخصائص الحالية
var props = info.readDocumentProperties();
// تعيين القيم الجديدة لحقلي المؤلف والعنوان
props.setAuthor("New Author");
props.setTitle("New Title");
// تحديث العرض التقديمي بقيم جديدة
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

هناك طريقة أخرى لاستخدام خصائص عرض تقديمي معين كقالب لتحديث الخصائص في عروض تقديمية أخرى:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

يمكن إنشاء قالب جديد من الصفر ثم استخدامه لتحديث عروض تقديمية متعددة:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **تعيين لغة التدقيق**

يوفر Aspose.Slides الخاصية LanguageId (المتوفرة عبر فئة PortionFormat) لتسمح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يعرض هذا الكود JavaScript كيفية تعيين لغة التدقيق لملف PowerPoint: xxx لماذا لا توجد الخاصية LanguageId في فئة JavaScript PortionFormat؟

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تعيين اللغة الافتراضية**

يعرض هذا الكود JavaScript كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // يضيف شكل مستطيل جديد مع نص
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // يفحص لغة الجزء الأول
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مثال حي**

جرّب تطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) عبر الإنترنت لمعرفة كيفية العمل مع خصائص المستند عبر واجهة برمجة تطبيقات Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. ولكن يمكنك إما تعديل قيمها أو تعيينها إلى فارغ إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة مسبقًا، سيتم استبدال القيمة الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، لأن Aspose.Slides يقوم بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) ثم [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) لقراءة بيانات المستند المخزنة دون إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/nodejs-java/examine-presentation/) للحصول على مثال تقارير كامل وقيود خاصة بالتنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفّر دون كلمة مرور الفتح؟**

نعم. يجب أن يكون تم تعطيل تشفير خصائص المستند قبل تشفير العرض، ويجب تحميل العرض في وضعية خصائص المستند فقط.

**هل يمكنني تحديث ملف PPTX مشفّر في وضعية خصائص المستند فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفّر تحميل العرض بالكامل مع كلمة المرور الصحيحة.
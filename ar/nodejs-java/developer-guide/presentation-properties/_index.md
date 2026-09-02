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
- بيانات وصفية للمستند
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحكم كامل في خصائص العرض التقديمي باستخدام Aspose.Slides for Node.js عبر Java وقم بتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **Built-in** و **Custom**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتهما بسهولة باستخدام Aspose.Slides API.

يسمح Aspose.Slides لك بالعمل مع خصائص مستند العرض التقديمي من خلال فئة [DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/) . يتم إرجاع نسخة من هذه الفئة بواسطة طريقة [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . تُظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="ملاحظة" %}}
يرجى ملاحظة أن حقلي **Application** و **AppVersion** لا يمكن تعديلهما. يقوم Aspose.Slides بإعادة كتابتهما عند كل حفظ، لذلك دائمًا ما يعرض العرض المحفوظ "Aspose.Slides for Node.js via Java" وإصدار المكتبة التي أنشأته. أي قيمة تُمرَّر إلى `setNameOfApplication` يتم تجاهلها عند كتابة العرض.
{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

توفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العرض التقديمي. تسمح هذه الخصائص المستندية بتخزين معلومات مفيدة جنبًا إلى جنب مع المستندات (ملفات العرض). هناك نوعان من خصائص المستند كما يلي

- خصائص معرفة بالنظام (Built-in)
- خصائص معرفة من قبل المستخدم (Custom)

تحتوي الخصائص **Built-in** على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصاءات المستند وما إلى ذلك. الخصائص **Custom** هي تلك التي يقوم المستخدمون بتعريفها كأزواج **Name/Value**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for Node.js via Java، يمكن للمطورين الوصول إلى قيم الخصائص المدمجة وكذلك الخصائص المخصصة وتعديلها.

## **خصائص المستند في PowerPoint**

يتيح Microsoft PowerPoint 2007 إدارة خصائص المستند لملفات العرض التقديمي. كل ما عليك هو النقر على أيقونة Office ثم اختيار **Prepare | Properties | Advanced Properties** كما هو موضح أدناه:

|**تحديد عنصر القائمة Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
بعد اختيار عنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
في **حوار الخصائص** أعلاه، يمكنك رؤية أن هناك العديد من تبويبات مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. تتيح جميع هذه التبويبات تكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم تبويبة **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

## **العمل مع خصائص المستند باستخدام Aspose.Slides for Node.js via Java**

كما وصفنا سابقًا، يدعم Aspose.Slides for Node.js via Java نوعين من خصائص المستند، وهما الخصائص **Built-in** والخصائص **Custom**. وبالتالي يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة برمجة تطبيقات Aspose.Slides for Node.js via Java. يقدم Aspose.Slides for Node.js via Java الفئة [DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties) التي تمثل خصائص المستند المرتبطة بملف العرض التقديمي من خلال خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **DocumentProperties** التي يطرحها كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) للوصول إلى خصائص المستند لملفات العرض التقديمي كما هو موضح أدناه:

## **الوصول إلى الخصائص Built-in**

تشمل هذه الخصائص التي يطرحها كائن [DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل هو مشترك بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من الفئة Presentation الذي يمثل العرض التقديمي
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

## **تعديل الخصائص Built-in**

تعديل الخصائص المدمجة لملفات العرض التقديمي سهل كالوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية ترغب فيها وسيتم تعديل قيمة الخاصية. في المثال أدناه، عرضنا كيفية تعديل خصائص المستند المدمجة لملف العرض باستخدام Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن IDocumentProperties المرتبط بالعرض التقديمي
    var dp = pres.getDocumentProperties();
    // ضبط الخصائص المدمجة
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

يقوم هذا المثال بتعديل الخصائص المدمجة للعرض التقديمي ويمكن رؤيتها كما هو موضح أدناه:

|**خصائص المستند المدمجة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصصة**

كما يسمح Aspose.Slides for Node.js via Java للمطورين بإضافة القيم المخصصة لخصائص مستند العرض التقديمي. يُظهر المثال أدناه كيفية ضبط الخصائص المخصصة للعرض.

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
    // الحصول على اسم الخاصية في فهرس معين
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

|**تمت إضافة خصائص المستند المخصصة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصصة وتعديلها**

كما يسمح Aspose.Slides for Node.js via Java للمطورين بالوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيفية الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن DocumentProperties المرتبط بالعرض التقديمي
    var dp = pres.getDocumentProperties();
    // الوصول إلى الخصائص المخصصة وتعديلها
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // عرض أسماء وقيم الخصائص المخصصة
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // تعديل قيم الخصائص المخصصة
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

يقوم هذا المثال بتعديل الخصائص المخصصة لـ [PPTX ](https://docs.fileformat.com/presentation/pptx/)العرض التقديمي. تُظهر الأشكال التالية خصائص العرض التقديمي المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصصة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="info" title="ملاحظة" %}}
تم إضافة الطرق الجديدة [ReadDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)، و[WriteBindedPresentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) إلى [PresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo)، وتم تغيير منطق المعيّن الخاص بالخاصية [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-).
{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) و[UpdateDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) إلى فئة [PresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/PresentationInfo). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض التقديمي بالكامل.

يمكن تنفيذ السيناريو النموذجي لتحميل الخصائص، تغيير قيمة ما وتحديث المستند بالطريقة التالية:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// قراءة معلومات العرض التقديمي
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// الحصول على الخصائص الحالية
var props = info.readDocumentProperties();
// ضبط القيم الجديدة لحقل المؤلف والعنوان
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

يمكن إنشاء قالب جديد من الصفر ثم استخدامه لتحديث عدة عروض تقديمية:

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

## **ضبط لغة التدقيق**

يوفر Aspose.Slides الخاصية LanguageId (المُعرَّضة من قبل فئة PortionFormat) لتسمح لك بضبط لغة التدقيق لملف PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد النحوية في PowerPoint.

يظهر هذا الشيفرة JavaScript كيفية ضبط لغة التدقيق لملف PowerPoint: xxx لماذا الخاصية LanguageId مفقودة في فئة JavaScript PortionFormat؟

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
    portionFormat.setLanguageId("zh-CN");// تعيين معرف لغة التدقيق
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ضبط اللغة الافتراضية**

يظهر هذا الشيفرة JavaScript كيفية ضبط اللغة الافتراضية لكامل عرض PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // إضافة شكل مستطيل جديد مع نص
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // التحقق من لغة الجزء الأول
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مثال حي**

جرّب التطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) عبر الإنترنت لمعرفة كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة هي جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو ضبطها كقيمة فارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، فسيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو التحقق من الخاصية مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) ثم [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) لقراءة البيانات الوصفية للمستند المخزنة دون إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) . راجع [Build a Lightweight Presentation Inventory](/slides/ar/nodejs-java/examine-presentation/) للحصول على مثال كامل للتقارير والقيود الخاصة بالصيغة.
---
title: خصائص العرض التقديمي
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
- تعديل الخصائص
- بيانات تعريف المستند
- تعديل بيانات التعريف
- PowerPoint
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "إدارة خصائص عرض PowerPoint في JavaScript"
---

{{% alert color="primary" %}} 

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العروض التقديمية. تسمح هذه الخصائص الوثائقية بتخزين معلومات مفيدة إلى جانب المستندات (ملفات العروض التقديمية). هناك نوعان من الخصائص الوثائقية كما يلي

- الخصائص المعرفة من النظام (المضمنة)
- الخصائص المعرفة من المستخدم (المخصصة)

**المضمنة** تحتوي على معلومات عامة عن المستند مثل عنوان المستند، اسم المؤلف، إحصاءات المستند وغيرها. **المخصصة** هي تلك التي يحددها المستخدمون كأزواج **اسم/قيمة**، حيث يتم تحديد كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for Node.js via Java، يمكن للمطورين الوصول إلى قيم الخصائص المضمنة وتعديلها وكذلك الخصائص المخصصة.

{{% /alert %}} 

## **خصائص المستند في PowerPoint**

يتيح Microsoft PowerPoint 2007 إدارة خصائص المستند لملفات العروض التقديمية. كل ما عليك فعله هو النقر على أيقونة Office ثم اختيار العنصر **Prepare | Properties | Advanced Properties** في قائمة Microsoft PowerPoint 2007 كما هو موضح أدناه:

{{% alert color="primary" %}} 

يرجى ملاحظة أنه لا يمكنك تعيين قيم لحقلَي **Application** و **Producer**، لأن Aspose Ltd. و Aspose.Slides for Node.js via Java x.x.x سيتم عرضهما في هذين الحقلين.

{{% /alert %}} 

|**تحديد عنصر القائمة Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
بعد تحديدك لعنصر القائمة **Advanced Properties**، سيظهر مربع حوار يتيح لك إدارة خصائص المستند لملف PowerPoint كما هو موضح أدناه في الشكل:

|**مربع حوار الخصائص**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
في **مربع حوار الخصائص** أعلاه، يمكنك رؤية وجود العديد من صفحات التبويب مثل **General**، **Summary**، **Statistics**، **Contents** و **Custom**. جميع هذه الصفحات تسمح بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. يتم استخدام تبويب **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

العمل مع خصائص المستند باستخدام Aspose.Slides for Node.js via Java

كما أوضحنا سابقًا أن Aspose.Slides for Node.js via Java يدعم نوعين من خصائص المستند، وهما الخصائص **Built-in** و **Custom**. لذلك يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة Aspose.Slides for Node.js via Java API. توفر Aspose.Slides for Node.js via Java فئة [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) التي تمثل خصائص المستند المرتبطة بملف عرض تقديمي عبر خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام الخاصية **DocumentProperties** التي تعرضها كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) للوصول إلى خصائص المستند لملفات العرض التقديمي كما هو موضح أدناه:

## **الوصول إلى الخصائص المضمنة**

تتضمن هذه الخصائص التي تعرضها كائن [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل يتم مشاركته بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.
```javascript
// إنشاء كائن فئة Presentation التي تمثل العرض التقديمي
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


## **تعديل الخصائص المضمنة**

تعديل الخصائص المضمنة لملفات العرض التقديمي سهل كما هو الحال في الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية تريدها وسيتم تعديل قيمة الخاصية. في المثال المذكور أدناه، عرضنا كيفية تعديل خصائص المستند المضمنة لملف العرض التقديمي باستخدام Aspose.Slides for Node.js via Java.
```javascript
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


يقوم هذا المثال بتعديل الخصائص المضمنة للعرض التقديمي والتي يمكن رؤيتها كما هو موضح أدناه:

|**خصائص المستند المضمنة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصصة**

كما يسمح Aspose.Slides for Node.js via Java للمطورين بإضافة القيم المخصصة لخصائص المستند في العرض التقديمي. تم تقديم مثال أدناه يوضح كيفية تعيين الخصائص المخصصة للعرض التقديمي.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // جلب خصائص المستند
    var dProps = pres.getDocumentProperties();
    // إضافة خصائص مخصصة
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // جلب اسم الخاصية عند فهرس معين
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


|**تم إضافة خصائص المستند المخصصة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصصة وتعديلها**

كما يسمح Aspose.Slides for Node.js via Java للمطورين بالوصول إلى قيم الخصائص المخصصة. تم تقديم مثال أدناه يوضح كيفية الوصول إلى جميع هذه الخصائص المخصصة وتعديلها للعرض التقديمي.
```javascript
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


يقوم هذا المثال بتعديل الخصائص المخصصة للـ[PPTX ](https://docs.fileformat.com/presentation/pptx/)العرض التقديمي. تُظهر الأشكال التالية خصائص العرض التقديمي المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصصة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="primary" %}} 

تم إضافة طرق جديدة [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)، و[WriteBindedPresentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) إلى [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo)، وتم تعديل منطق مُعين خاصية [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-).
{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) و[UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) إلى فئة [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض التقديمي بالكامل.

يمكن تنفيذ السيناريو الشائع بتحميل الخصائص، تعديل قيمة ما، ثم تحديث المستند على النحو التالي:
```javascript
// قراءة معلومات العرض التقديمي
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


هناك طريقة أخرى لاستخدام خصائص عرض تقديمي معين كقالب لتحديث الخصائص في عروض تقديمية أخرى:
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


يمكن إنشاء قالب جديد من الصفر ثم استخدامه لتحديث عدة عروض تقديمية:
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **ضبط لغة التدقيق**

توفر Aspose.Slides الخاصية LanguageId (التي تعرضها فئة PortionFormat) لتتيح لك ضبط لغة التدقيق لملف PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يعرض لك هذا الكود JavaScript كيفية ضبط لغة التدقيق لملف PowerPoint: xxx لماذا الخاصية LanguageId مفقودة في فئة JavaScript PortionFormat؟
```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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

يعرض لك هذا الكود JavaScript كيفية ضبط اللغة الافتراضية لعرض PowerPoint كامل:
```javascript
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

جرّب تطبيق الويب [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) لتعرف كيف تتعامل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مضمَّنة من عرض تقديمي؟**

الخصائص المضمنة هي جزء أساسي من العرض ولا يمكن إزالتها تمامًا. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كقيمة فارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟**

إذا أضفت خاصية مخصصة موجودة مسبقًا، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث تقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل؟**

نعم، يمكنك الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل باستخدام طريقة `getPresentationInfo` من فئة [PresentationFactory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/). ثم استخدم طريقة `readDocumentProperties` التي توفرها فئة [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo/) لقراءة الخصائص بكفاءة، مما يوفر الذاكرة ويحسن الأداء.
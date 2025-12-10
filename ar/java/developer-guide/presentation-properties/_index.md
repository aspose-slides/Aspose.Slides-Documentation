---
title: إدارة خصائص العرض التقديمي في Java
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/java/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- الخصائص المدمجة
- الخصائص المخصصة
- الخصائص المتقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات المستند الوصفية
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إتقان خصائص العرض التقديمي في Aspose.Slides for Java وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---

{{% alert color="primary" %}} 

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العرض. تتيح هذه الخصائص الوثائقية تخزين بعض المعلومات المفيدة جنبًا إلى جنب مع المستندات (ملفات العروض). هناك نوعان من الخصائص الوثائقية كما يلي

- الخصائص المعرفة نظاميًا (المضمنة)
- الخصائص المعرفة من قبل المستخدم (المخصصة)

تحتوي الخصائص **المضمنة** على معلومات عامة عن المستند مثل عنوان المستند، اسم المؤلف، إحصائيات المستند وما إلى ذلك. الخصائص **المخصصة** هي تلك التي يحددها المستخدمون كأزواج **Name/Value**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for Java، يمكن للمطورين الوصول إلى قيم الخصائص المضمنة وكذلك الخصائص المخصصة وتعديلها.

{{% /alert %}} 

## **خصائص المستند في PowerPoint**

يتيح Microsoft PowerPoint 2007 إدارة خصائص المستند لملفات العرض. كل ما عليك هو النقر على أيقونة Office ثم اختيار القائمة **Prepare | Properties | Advanced Properties** كما هو موضح أدناه:

{{% alert color="primary" %}} 

يرجى ملاحظة أنك لا تستطيع تعيين قيم لحقلَي **Application** و **Producer**، لأن Aspose Ltd. و Aspose.Slides for Java x.x.x سيتم عرضهما في هذين الحقلين.

{{% /alert %}} 

|**تحديد عنصر قائمة الخصائص المتقدمة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

بعد تحديد عنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

في **حوار الخصائص** أعلاه، يمكنك ملاحظة وجود العديد من علامات التبويب مثل **General**، **Summary**، **Statistics**، **Contents** و **Custom**. تتيح كل هذه العلامات تكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم علامة **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

### العمل مع خصائص المستند باستخدام Aspose.Slides for Java

كما أوضحنا سابقًا أن Aspose.Slides for Java يدعم نوعين من خصائص المستند، وهما الخصائص **المضمنة** و **المخصصة**. وبالتالي، يمكن للمطورين الوصول إلى كلا النوعين باستخدام واجهة برمجة تطبيقات Aspose.Slides for Java. توفر Aspose.Slides for Java فئة [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) التي تمثّل خصائص المستند المرتبطة بملف العرض من خلال الخاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام الخاصية **IDocumentProperties** التي يوفرها كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) للوصول إلى خصائص المستند لملفات العرض كما هو موضح أدناه:

## **الوصول إلى الخصائص المضمنة**

تتضمن هذه الخصائص كما تظهر في كائن [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل تم مشاركة المستند بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**
```java
// إنشاء كائن من فئة Presentation الذي يمثل العرض التقديمي
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن IDocumentProperties المرتبط بالعرض التقديمي
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // عرض الخصائص المدمجة
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعديل الخصائص المضمنة**

تعديل الخصائص المضمنة لملفات العرض سهل مثل الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية مرغوبة وسيتم تعديل قيمة الخاصية. في المثال التالي، عرضنا كيف يمكن تعديل خصائص المستند المضمنة للعرض باستخدام Aspose.Slides for Java.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن IDocumentProperties المرتبط بالعرض التقديمي
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // تعيين الخصائص المدمجة
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // حفظ العرض التقديمي إلى ملف
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


يُظهر هذا المثال الخصائص المضمنة للعرض بعد التعديل كما هو موضح أدناه:

|**خصائص المستند المضمنة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصصة**

كما يسمح Aspose.Slides for Java للمطورين بإضافة القيم المخصصة لخصائص المستند للعرض. يُظهر المثال أدناه كيفية تعيين الخصائص المخصصة لعرض ما.
```java
Presentation pres = new Presentation();
try {
    // الحصول على خصائص المستند
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // إضافة خصائص مخصصة
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // الحصول على اسم الخاصية في فهرس معين
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // إزالة الخاصية المحددة
    dProps.removeCustomProperty(getPropertyName);
    
    // حفظ العرض التقديمي
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|**تمت إضافة خصائص المستند المخصصة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides for Java للمطورين أيضًا بالوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيف يمكنك الوصول إلى جميع هذه الخصائص المخصصة للعرض وتعديلها.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن DocumentProperties المرتبط بالعرض التقديمي
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // الوصول إلى الخصائص المخصصة وتعديلها
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // عرض أسماء وقيم الخصائص المخصصة
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // تعديل قيم الخصائص المخصصة
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // حفظ العرض التقديمي إلى ملف
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


يُظهر هذا المثال تعديل الخصائص المخصصة للعرض [PPTX ](https://docs.fileformat.com/presentation/pptx/). تظهر الأشكال التالية الخصائص المخصصة للعرض قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصصة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="primary" %}} 

تمت إضافة طرق جديدة [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) إلى الواجهة [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo)، وتم تغيير منطق مُحدد الخاصية [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-).

{{% /alert %}} 

طُرِّحت الطريقتان الجديدتان [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) على واجهة [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض بالكامل.

يمكن تنفيذ السيناريو النموذجي لتحميل الخصائص، تعديل قيمة ما، ثم تحديث المستند بالطريقة التالية:
```java
// قراءة معلومات العرض التقديمي
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// الحصول على الخصائص الحالية
IDocumentProperties props = info.readDocumentProperties();

// تعيين القيم الجديدة لحقلي المؤلف والعنوان
props.setAuthor("New Author");
props.setTitle("New Title");

// تحديث العرض التقديمي بالقيم الجديدة
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


هناك طريقة أخرى لاستخدام خصائص عرض معين كقالب لتحديث الخصائص في عروض أخرى:
```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


يمكن إنشاء قالب جديد من الصفر ثم استخدامه لتحديث عدة عروض:
```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية LanguageId (المعروضة من فئة PortionFormat) لتتيح لك تعيين لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي يتم فحص الإملاء والقواعد النحوية فيها في PowerPoint.

يعرض هذا الكود Java كيفية تعيين لغة التدقيق لبرنامج PowerPoint: xxx لماذا خاصية LanguageId مفقودة من فئة Java PortionFormat؟
```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // تعيين معرف لغة التدقيق

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين اللغة الافتراضية**

يعرض هذا الكود Java كيفية تعيين اللغة الافتراضية لعرض PowerPoint كامل:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // يضيف شكل مستطيل جديد مع نص
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // يتحقق من لغة الجزء الأول
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```


## **مثال حي**

جرب تطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) على الويب لمعرفة كيفية التعامل مع خصائص المستند عبر واجهة Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمتها أو تعيينها كقيمة فارغة إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟**

في حال إضافة خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض دون تحميله بالكامل؟**

نعم، يمكن الوصول إلى خصائص العرض دون تحميله بالكامل باستخدام طريقة `getPresentationInfo` من فئة [PresentationFactory](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/). بعد ذلك، استخدم طريقة `readDocumentProperties` المقدمة من واجهة [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/) لقراءة الخصائص بكفاءة، مما يوفر الذاكرة ويحسن الأداء.
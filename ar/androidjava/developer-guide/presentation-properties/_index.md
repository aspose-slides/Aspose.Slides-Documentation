---
title: إدارة خصائص العرض التقديمي على Android
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/androidjava/presentation-properties/
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
- تحرير البيانات التعريفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إتقان خصائص العرض التقديمي في Aspose.Slides for Android عبر Java وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---

{{% alert color="primary" %}} 

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العروض التقديمية. تسمح هذه الخصائص الوثائقية بتخزين معلومات مفيدة جنبًا إلى جنب مع المستندات (ملفات العرض). هناك نوعان من الخصائص الوثائقية كما يلي:

- خصائص معرفة نظاميًا (مضمَّنة)
- خصائص معرفة من قبل المستخدم (مخصَّصة)

تحتوي الخصائص **المضمنة** على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصاءات المستند، وما إلى ذلك. أما الخصائص **المخصَّصة** فهي التي يحددها المستخدمون كأزواج **اسم/قيمة**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for Android via Java، يمكن للمطورين الوصول إلى قيم الخصائص المضمنة وكذلك الخصائص المخصَّصة وتعديلها.

{{% /alert %}} 

## **خصائص المستند في PowerPoint**

يسمح Microsoft PowerPoint 2007 بإدارة خصائص المستند لملفات العروض التقديمية. كل ما عليك فعله هو النقر على أيقونة Office ثم اختيار القائمة **Prepare | Properties | Advanced Properties** في Microsoft PowerPoint 2007 كما هو موضح أدناه:

{{% alert color="primary" %}} 

يرجى ملاحظة أنك لا تستطيع تعيين قيم لحقلَي **Application** و **Producer**، لأن Aspose Ltd. و Aspose.Slides for Android via Java x.x.x سيتم عرضهما في هذين الحقلين.

{{% /alert %}} 

|**اختيار عنصر القائمة Advanced Properties**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

بعد اختيار عنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
في **حوار الخصائص** أعلاه، يمكنك رؤية العديد من صفحات التبويب مثل **General**, **Summary**, **Statistics**, **Contents** و **Custom**. تسمح جميع صفحات التبويب هذه بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم صفحة **Custom** لإدارة الخصائص المخصَّصة لملفات PowerPoint.



## العمل مع خصائص المستند باستخدام Aspose.Slides for Android via Java

كما وصفنا سابقًا، يدعم Aspose.Slides for Android via Java نوعين من خصائص المستند، وهما الخصائص **المضمنة** والخصائص **المخصَّصة**. لذا يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام API الخاص بـ Aspose.Slides for Android via Java. يوفر Aspose.Slides for Android via Java الفئة [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) التي تمثل خصائص المستند المرتبطة بملف عرض تقديمي من خلال خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **IDocumentProperties** التي يطرحها الكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) للوصول إلى خصائص المستند لملفات العرض التقديمي كما هو موضح أدناه:

## **الوصول إلى الخصائص المضمنة**

تتضمن الخصائص التي يطرحها كائن [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **SharedDoc** (هل تم مشاركة المستند بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.
```java
// إنشاء كائن من فئة Presentation الذي يمثل العرض التقديمي
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع لكائن IDocumentProperties المرتبط بالعرض التقديمي
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

تعديل الخصائص المضمنة لملفات العرض التقديمي سهل مثل الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية مرغوب فيها وسيتم تعديل قيمة الخاصية. في المثال المدرج أدناه، أظهرنا كيفية تعديل خصائص المستند المضمنة لملف العرض باستخدام Aspose.Slides for Android via Java.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع لكائن IDocumentProperties المرتبط بالعرض التقديمي
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // تعيين الخصائص المدمجة
    dp.setAuthor("Aspose.Slides for Android via Java");
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


هذا المثال ي modifies الخصائص المضمنة للعرض كما يمكن رؤيته أدناه:

|**خصائص المستند المضمنة بعد التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصَّصة**

يسمح Aspose.Slides for Android via Java أيضًا للمطورين بإضافة القيم المخصَّصة لخصائص المستند للعرض التقديمي. المثال أدناه يوضح كيفية تعيين الخصائص المخصَّصة لعرض تقديمي.
```java
Presentation pres = new Presentation();
try {
    // الحصول على خصائص المستند
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // إضافة خصائص مخصصة
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // الحصول على اسم الخاصية عند فهرس معين
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // إزالة الخاصية المحددة
    dProps.removeCustomProperty(getPropertyName);
    
    // حفظ العرض التقديمي
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|**تمت إضافة خصائص مستند مخصَّصة**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصَّصة وتعديلها**

يسمح Aspose.Slides for Android via Java أيضًا للمطورين بالوصول إلى قيم الخصائص المخصَّصة. المثال أدناه يوضح كيفية الوصول إلى جميع هذه الخصائص المخصَّصة لعرض تقديمي وتعديلها.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع لكائن DocumentProperties المرتبط بالعرض التقديمي
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


هذا المثال ي modifies الخصائص المخصَّصة للعرض التقديمي [PPTX](https://docs.fileformat.com/presentation/pptx/). تُظهر الأشكال التالية الخصائص المخصَّصة للعرض قبل وبعد التعديل:

|**الخصائص المخصَّصة قبل التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**الخصائص المخصَّصة بعد التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="primary" %}} 

تم إضافة طرق جديدة [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), و [WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) إلى [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo)، كما تم تغيير منطق خاصية [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) setter.

{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo). تتيحان وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض بالكامل.

يمكن تنفيذ السيناريو النموذجي بتحميل الخصائص، تعديل قيمة ما، ثم تحديث المستند كما يلي:
```java
// قراءة معلومات العرض التقديمي
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// الحصول على الخصائص الحالية
IDocumentProperties props = info.readDocumentProperties();

// تعيين القيم الجديدة لحقلَي المؤلف والعنوان
props.setAuthor("New Author");
props.setTitle("New Title");

// تحديث العرض التقديمي بالقيم الجديدة
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


هناك طريقة أخرى لاستخدام خصائص عرض تقديمي معين كقالب لتحديث الخصائص في عروض تقديمية أخرى:
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


يمكن إنشاء قالب جديد من الصفر ثم استخدامه لتحديث عدة عروض تقديمية:
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

يوفر Aspose.Slides الخاصية LanguageId (المُعرَّضة من خلال فئة PortionFormat) لتسمح لك بتعيين لغة التدقيق لملف PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والنحو في PowerPoint.

يعرض هذا الشيفرة Java كيفية تعيين لغة التدقيق لملف PowerPoint: xxx لماذا LanguageId مفقودة من فئة Java PortionFormat؟
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

يعرض هذا الشيفرة Java كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // إضافة شكل مستطيل جديد بالنص
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // التحقق من لغة الجزء الأول
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```


## **مثال حي**

جرّب التطبيق عبر الإنترنت [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) لرؤية كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها إلى فارغة إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصَّصة موجودة بالفعل؟**

إذا أضفت خاصية مخصَّصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض دون تحميله بالكامل؟**

نعم، يمكنك الوصول إلى خصائص العرض دون تحميله بالكامل باستخدام طريقة `getPresentationInfo` من الفئة [PresentationFactory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/). ثم استخدم طريقة `readDocumentProperties` المقدمة من واجهة [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/) لقراءة الخصائص بكفاءة، مما يوفر الذاكرة ويحسن الأداء.
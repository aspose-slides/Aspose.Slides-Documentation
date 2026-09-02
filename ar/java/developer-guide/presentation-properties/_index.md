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
- Java
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides لـ Java وقم بتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **مدمجة** و **مخصصة**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتها بسهولة باستخدام Aspose.Slides API.

يتيح Aspose.Slides لك العمل مع خصائص مستند العرض التقديمي من خلال الواجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/) . تُرجع طريقة [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getDocumentProperties--) مثالًا من هذه الواجهة. تظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="ملاحظة" %}}
يرجى ملاحظة أنه لا يمكن تعديل حقلي **Application** و **AppVersion**. يقوم Aspose.Slides بإعادة كتابة هذه الحقول في كل عملية حفظ، لذا دائمًا ما يُظهر العرض المحفوظ "Aspose.Slides for Java" وإصدار المكتبة التي أنشأته. يتم تجاهل أي قيمة تُمرَّر إلى `setNameOfApplication` عندما يتم كتابة العرض التقديمي.
{{% /alert %}} 

## **خصائص المستند في PowerPoint**

يسمح Microsoft PowerPoint 2007 بإدارة خصائص مستند ملفات العرض التقديمي. كل ما عليك فعله هو النقر على أيقونة Office ثم اختيار عنصر القائمة **Prepare | Properties | Advanced Properties** في Microsoft PowerPoint 2007 كما هو موضح أدناه:

|**اختيار عنصر قائمة الخصائص المتقدمة**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

بعد اختيارك لعنصر القائمة **Advanced Properties**، سيظهر حوار يسمح لك بإدارة خصائص المستند لملف PowerPoint كما هو موضح أدناه في الشكل:

|**حوار الخصائص**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

في **حوار الخصائص** أعلاه، يمكنك رؤية العديد من صفحات التبويب مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. تسمح جميع صفحات التبويب هذه بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم صفحة **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

### العمل مع خصائص المستند باستخدام Aspose.Slides for Java

كما ذكرنا بالفعل، يدعم Aspose.Slides for Java نوعين من خصائص المستند، وهما الخصائص **المدمجة** و **المخصصة**. وبالتالي يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام Aspose.Slides for Java API. يوفر Aspose.Slides for Java فئة [IDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties) التي تمثل خصائص المستند المرتبطة بملف العرض التقديمي من خلال الخاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام الخاصية **IDocumentProperties** التي تُعرضها كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) للوصول إلى خصائص مستند ملفات العرض التقديمي كما هو موضح أدناه:

## **الوصول إلى الخصائص المدمجة**

هذه الخصائص التي تُعرضها كائن [IDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties) تشمل: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ آخر طباعة)، **LastModifiedBy**، **SharedDoc** (هل تم مشاركة الملف بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

```java
import com.aspose.slides.*;

// إنشاء كائن Presentation الذي يمثل العرض التقديمي
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

## **تعديل الخصائص المدمجة**

تعديل الخصائص المدمجة لملفات العرض التقديمي سهل مثل الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية تريدها وسيتم تعديل قيمة الخاصية. في المثال أدناه، قمنا بتوضيح كيفية تعديل خصائص المستند المدمجة لملف العرض باستخدام Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع لكائن IDocumentProperties المرتبط بالعرض التقديمي
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

يعدل هذا المثال الخصائص المدمجة للعرض التقديمي كما يمكن رؤيته أدناه:

|**خصائص المستند المدمجة بعد التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص المستند المخصصة**

يتيح Aspose.Slides for Java أيضًا للمطورين إضافة القيم المخصصة لخصائص مستند العرض التقديمي. يضيف المثال أدناه ثلاثة خصائص مخصصة، ثم يبحث عن الاسم المخزن في الفهرس 2 ويزيل تلك الخاصية، بحيث يبقى في العرض المحفوظ اثنان منها. يتم فهرسة الخصائص المخصصة بالترتيب الأبجدي، وليس بترتيب إضافتها.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // جلب خصائص المستند
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // إضافة خصائص مخصصة
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // جلب اسم الخاصية عند فهرس معين
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // إزالة الخاصية المحددة
    dProps.removeCustomProperty(getPropertyName);
    
    // حفظ العرض التقديمي
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**خصائص المستند المخصصة التي تمت إضافتها**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى وتعديل الخصائص المخصصة**

يتيح Aspose.Slides for Java أيضًا للمطورين الوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيفية الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع لكائن DocumentProperties المرتبط بالعرض التقديمي
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // الوصول وتعديل الخصائص المخصصة
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

يقوم هذا المثال بتعديل الخصائص المخصصة للعرض التقديمي [PPTX](https://docs.fileformat.com/presentation/pptx/). توضح الأشكال التالية خصائص العرض التقديمي المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصصة بعد التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="info" title="ملاحظة" %}}
تم إضافة طرق جديدة [ReadDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), و [WriteBindedPresentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) إلى [IPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo)، تم تغيير منطق الدالة الضابطة للخاصية [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-).
{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties] و [UpdateDocumentProperties] إلى واجهة [IPresentationInfo]. توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض التقديمي كاملًا.

يمكن تنفيذ السيناريو الشائع بتحميل الخصائص، تعديل قيمة ما، ثم تحديث المستند بالطريقة التالية:

```java
import com.aspose.slides.*;

// قراءة معلومات العرض التقديمي
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// الحصول على الخصائص الحالية
IDocumentProperties props = info.readDocumentProperties();

// تعيين القيم الجديدة لحقلي المؤلف والعنوان
props.setAuthor("New Author");
props.setTitle("New Title");

// تحديث العرض التقديمي بقيم جديدة
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

هناك طريقة أخرى لاستخدام خصائص عرض تقديمي معين كقالب لتحديث الخصائص في عروض تقديمية أخرى:

```java
import com.aspose.slides.*;

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

يمكن إنشاء قالب جديد من الصفر ثم استخدامه لتحديث عدة عروض تقديمية:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **تعيين لغة التدقيق**

يوفر Aspose.Slides الخاصية LanguageId (المُعَرَّضة من فئة PortionFormat) لتسمح لك بتعيين لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والنحو في PowerPoint.

يوضح لك هذا الكود Java كيفية تعيين لغة التدقيق لملف PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

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

يوضح لك هذا الكود Java كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // يضيف شكلاً مستطيلاً جديدًا مع نص
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // يتحقق من لغة الجزء الأول
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **مثال حي**

جرّب التطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) على الإنترنت لترى كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![عرض وتحرير بيانات PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مدمجة من العرض التقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض التقديمي ولا يمكن إزالتها تمامًا. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كفارغة إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل؟**

نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ثم [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) لقراءة بيانات التعريف المخزنة للمستند دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) . راجع [إنشاء جرد عروض تقديمية خفيف الوزن](/slides/ar/java/examine-presentation/) للحصول على مثال تقارير كامل والقيود الخاصة بالصيغة.
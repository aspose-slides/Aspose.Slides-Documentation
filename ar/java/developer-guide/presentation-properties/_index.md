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
- بيانات تعريف المستند
- تحرير بيانات التعريف
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides for Java وحسّن البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument."
---
## **مقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **Built-in** و **Custom**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتها بسهولة باستخدام Aspose.Slides API.

يسمح Aspose.Slides لك بالعمل مع خصائص مستند العرض التقديمي عبر واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/) . تُعيد طريقة [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getDocumentProperties--) نسخة من هذه الواجهة. تُظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" %}} 

يرجى ملاحظة أن حقلي **Application** و **AppVersion** لا يمكن تعديلهما. يقوم Aspose.Slides بإعادة كتابتهما في كل عملية حفظ، لذا فإن العرض المحفوظ دائماً يُظهر "Aspose.Slides for Java" وإصدار المكتبة التي أنشأته. أي قيمة تُمرّر إلى `setNameOfApplication` تُهجر عندما يُكتب العرض.

{{% /alert %}} 

## **خصائص المستند في PowerPoint**

يسمح Microsoft PowerPoint 2007 بإدارة خصائص المستند لملفات العرض التقديمي. كل ما عليك هو النقر على أيقونة Office ثم اختيار العنصر **Prepare | Properties | Advanced Properties** من القائمة في Microsoft PowerPoint 2007 كما هو موضح أدناه:

|**تحديد عنصر القائمة Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

بعد اختيار عنصر القائمة **Advanced Properties**، سيظهر حوار يسمح لك بإدارة خصائص مستند ملف PowerPoint كما هو موضح أدناه:

|**حوار الخصائص**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

في **حوار الخصائص** أعلاه، يمكنك أن ترى وجود العديد من صفحات التبويب مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. تسمح جميع صفحات التبويب هذه بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم تبويب **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

### العمل مع خصائص المستند باستخدام Aspose.Slides for Java

كما وصفنا سابقاً أن Aspose.Slides for Java يدعم نوعين من خصائص المستند، وهما خصائص **Built-in** و **Custom**. وبالتالي يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام Aspose.Slides for Java API. توفر Aspose.Slides for Java الفئة [IDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties) التي تمثل خصائص المستند المرتبطة بملف العرض من خلال خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **IDocumentProperties** التي تُعرضها كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) للوصول إلى خصائص المستند لملفات العرض كما هو موضح أدناه:

## **الوصول إلى الخصائص المدمجة**

تشمل هذه الخصائص التي تعرضها كائن [IDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ آخر طباعة)، **LastModifiedBy**، **SharedDoc** (هل هو مشترك بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل العرض التقديمي
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

## **تعديل الخصائص المدمجة**

تعديل الخصائص المدمجة لملفات العرض سهل كما هو الحال في الوصول إليها. يمكنك ببساطة تعيين قيمة سلسلة نصية لأي خاصية مرغوبة وسيتم تعديل قيمة الخاصية. في المثال المعروض أدناه، أوضحنا كيف يمكننا تعديل خصائص المستند المدمجة لملف العرض باستخدام Aspose.Slides for Java.

```java
import com.aspose.slides.*;

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

هذا المثال ي modifica الخصائص المدمجة للعرض كما هو موضح أدناه:

|**خصائص المستند المدمجة بعد التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصصة**

يسمح Aspose.Slides for Java أيضاً للمطورين بإضافة القيم المخصصة لخصائص مستند العرض. يضيف المثال أدناه ثلاث خصائص مخصصة، ثم يبحث عن الاسم المخزن في الفهرس 2 ويزيل تلك الخاصية، وبالتالي يبقى في العرض المحفوظ خاصيتان. تُفهرس الخصائص المخصصة بالحروف الأبجدية، وليس بترتيب الإضافة.

```java
import com.aspose.slides.*;

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

|**تمت إضافة خصائص مستند مخصصة**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى وتعديل الخصائص المخصصة**

يسمح Aspose.Slides for Java أيضاً للمطورين بالوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيف يمكنك الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن DocumentProperties المرتبط بالعرض التقديمي
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // الوصول إلى خصائص مخصصة وتعديلها
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

هذا المثال يعدل الخصائص المخصصة للعرض [PPTX ](https://docs.fileformat.com/presentation/pptx/). تُظهر الأشكال التالية خصائص العرض المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصصة بعد التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="info" %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo)، وتم تغيير منطق مُعيّن الخاصية [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-).

{{% /alert %}} 

تمت إضافة الطريقتين [ReadDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo). توفران وصولاً سريعاً إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض بأكمله.

سيناريو شائع هو تحميل الخصائص، تعديل قيمة ما، ثم تحديث المستند، ويمكن تنفيذ ذلك بالطريقة التالية:

```java
import com.aspose.slides.*;

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

توفر Aspose.Slides الخاصية LanguageId (المُعرّضة عبر فئة PortionFormat) لتسمح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد النحوية في PowerPoint.

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

يعرض هذا الكود Java كيفية تعيين اللغة الافتراضية لعرض PowerPoint كامل:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // إضافة شكل مستطيل جديد مع نص
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // التحقق من لغة الجزء الأول
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **مثال حي**

جرّب تطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) على الإنترنت لترا رؤية كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## ***الأسئلة الشائعة**

### كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها تماماً. يمكنك إما تعديل قيمها أو تعيينها كقيمة فارغة إذا سمحت الخاصية بذلك.

### ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟

إذا أضفت خاصية مخصصة موجودة مسبقاً، سيتم استبدال القيمة الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخصية أو التحقق منها مسبقاً، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائياً.

### هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟

نعم، يمكنك الوصول إلى خصائص العرض دون تحميل العرض بالكامل باستخدام طريقة `getPresentationInfo` من فئة [PresentationFactory](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/). ثم استخدم طريقة `readDocumentProperties` المقدمة من واجهة [IPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/) لقراءة الخصائص بكفاءة، مما يوفر الذاكرة ويحسن الأداء.
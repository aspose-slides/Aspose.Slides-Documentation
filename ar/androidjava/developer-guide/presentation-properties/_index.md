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
  - خصائص مضمّنة
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
  - Android
  - Java
  - Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides لنظام Android عبر Java وسهّل البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **مضمّن** و **مخصص**. يمكن بسهولة الوصول إلى هذين النوعين من الخصائص وإدارتها باستخدام واجهة برمجة تطبيقات Aspose.Slides.

يتيح Aspose.Slides لك العمل مع خصائص مستند العرض التقديمي من خلال واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/) . يتم إرجاع مثيل من هذه الواجهة بواسطة طريقة [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . تُظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="ملاحظة" %}}
يرجى ملاحظة أن حقلي **Application** و **AppVersion** لا يمكن تعديلهما. يقوم Aspose.Slides بإعادة كتابةهما في كل عملية حفظ، لذا فإن العرض التقديمي المحفوظ دائمًا يُظهر اسم منتج Aspose.Slides وإصدار المكتبة التي أنشأته. يتم تجاهل أي قيمة تُمرَّر إلى `setNameOfApplication` عند كتابة العرض التقديمي.
{{% /alert %}} 

## **خصائص المستند في PowerPoint**

يتيح Microsoft PowerPoint 2007 إدارة خصائص المستند لملفات العرض التقديمي. كل ما عليك هو النقر على أيقونة Office ثم اختيار العنصر **Prepare | Properties | Advanced Properties** في قائمة Microsoft PowerPoint 2007 كما هو موضح أدناه:

|**تحديد عنصر القائمة الخصائص المتقدمة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

بعد اختيارك لعنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

في **حوار الخصائص** أعلاه، يمكنك رؤية أن هناك العديد من علامات التبويب مثل **General**، **Summary**، **Statistics**، **Contents** و **Custom**. تسمح جميع هذه العلامات بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم علامة التبويب **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

### **العمل مع خصائص المستند باستخدام Aspose.Slides لنظام Android عبر Java**

كما وصفنا سابقًا أن Aspose.Slides لنظام Android عبر Java يدعم نوعين من خصائص المستند، وهما خصائص **مضمّن** و**مخصص**. وبالتالي يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة برمجة تطبيقات Aspose.Slides لنظام Android عبر Java. توفر Aspose.Slides لنظام Android عبر Java الفئة [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties) التي تمثل خصائص المستند المرتبطة بملف العرض التقديمي من خلال خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **IDocumentProperties** التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) للوصول إلى خصائص المستند لملفات العرض التقديمي كما هو موضح أدناه:

## **الوصول إلى الخصائص المضمّنة**

تشمل هذه الخصائص التي تُظهرها كائن [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ آخر طباعة)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل يتم مشاركته بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

```java
import com.aspose.slides.*;

// إنشاء كائن فئة Presentation الذي يمثل العرض التقديمي
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن IDocumentProperties المرتبط بـ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // عرض الخصائص المضمّنة
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

## **تعديل الخصائص المضمّنة**

تعديل الخصائص المضمنة لملفات العرض التقديمي سهل مثل الوصول إليها. يمكنك ببساطة إسناد قيمة نصية إلى أي خاصية تريدها وسيتم تعديل قيمة الخاصية. في المثال أدناه، قمنا بشرح كيفية تعديل خصائص المستند المضمنة لملف العرض التقديمي باستخدام Aspose.Slides لنظام Android عبر Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن IDocumentProperties المرتبط بـ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // تعيين الخصائص المضمنة
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

يقوم هذا المثال بتعديل الخصائص المضمنة للعرض التقديمي كما يمكن رؤيته في الشكل أدناه:

|**الخصائص المضمنة للمستند بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصصة**

يسمح Aspose.Slides لنظام Android عبر Java للمطورين أيضًا بإضافة القيم المخصصة لخصائص مستند العرض التقديمي. يضيف المثال أدناه ثلاث خصائص مخصصة، ثم يبحث عن الاسم المخزن في الفهرس 2 ويحذف تلك الخاصية، لذا يحتفظ العرض التقديمي المحفوظ باثنتين منهما. يتم فهرسة الخصائص المخصصة بترتيب أبجدي، وليس بترتيب الإضافة.

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
    
    // الحصول على اسم الخاصية عند فهرس محدد
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // إزالة الخاصية المحددة
    dProps.removeCustomProperty(getPropertyName);
    
    // حفظ العرض التقديمي
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**خصائص المستند المخصصة المضافة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides لنظام Android عبر Java للمطورين أيضًا بالوصول إلى قيم الخصائص المخصصة. يُعطى المثال أدناه الذي يوضح كيفية الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع إلى كائن DocumentProperties المرتبط بـ Presentation
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

يقوم هذا المثال بتعديل الخصائص المخصصة لعرض [PPTX](https://docs.fileformat.com/presentation/pptx/) . تُظهر الأشكال التالية خصائص العرض المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصصة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="info" title="ملاحظة" %}}
تم إضافة طرق جديدة [ReadDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) ، [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ، و [WriteBindedPresentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) إلى [IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo) ، وتم تغيير منطق ضبط الخاصية [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) .
{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل عرض تقديمي كامل.

يمكن تنفيذ سيناريو التحميل النموذجي للخصائص، تغيير قيمة ما وتحديث المستند بالطريقة التالية:

```java
import com.aspose.slides.*;

// قراءة معلومات العرض التقديمي
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// الحصول على الخصائص الحالية
IDocumentProperties props = info.readDocumentProperties();

// تعيين القيم الجديدة لحقلين المؤلف والعنوان
props.setAuthor("New Author");
props.setTitle("New Title");

// تحديث العرض التقديمي بالقيم الجديدة
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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

يمكن إنشاء قالب جديد من الصفر ثم استخدامه لتحديث عروض تقديمية متعددة:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **تحديد لغة التدقيق**

يوفر Aspose.Slides الخاصية LanguageId (المعروضة من قبل فئة PortionFormat) لتتيح لك تعيين لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يبين لك هذا الكود Java كيفية تعيين لغة التدقيق لملف PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

## **تحديد اللغة الافتراضية**

يبين لك هذا الكود Java كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint:

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

جرّب تطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) المتوفر على الإنترنت لترى كيفية العمل مع خصائص المستند عبر واجهة برمجة تطبيقات Aspose.Slides:

[![عرض وتحرير بيانات تعريف PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مضمنة من عرض تقديمي؟**

الخصائص المضمنة هي جزء أساسي من العرض التقديمي ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها إلى فارغ إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، فسيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ثم [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) لقراءة بيانات تعريف المستند المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/androidjava/examine-presentation/) للحصول على مثال تقرير كامل والقيود الخاصة بكل تنسيق.
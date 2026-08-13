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
- تحرير بيانات التعريف
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides for Android عبر Java وقم بتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **Built-in** و **Custom**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتهما بسهولة باستخدام واجهة برمجة تطبيقات Aspose.Slides.

يسمح لك Aspose.Slides بالعمل مع خصائص مستند العرض التقديمي من خلال واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/) . تُعيد طريقة [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) كائنًا من هذه الواجهة. تُظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" %}} 
يرجى ملاحظة أنه لا يمكن تعديل حقلي **Application** و **AppVersion**. يقوم Aspose.Slides بإعادة كتابة هذين الحقلين في كل عملية حفظ، لذا دائمًا ما يُظهر العرض المحفوظ اسم منتج Aspose.Slides وإصدار المكتبة التي أنشأته. يتم تجاهل أي قيمة تُمرَّر إلى `setNameOfApplication` عند كتابة العرض.
{{% /alert %}} 

## **خصائص المستند في PowerPoint**

يتيح Microsoft PowerPoint 2007 إدارة خصائص المستند لملفات العرض التقديمي. كل ما عليك هو النقر على أيقونة Office ثم اختيار القائمة **Prepare | Properties | Advanced Properties** في Microsoft PowerPoint 2007 كما هو موضح أدناه:

|**اختيار عنصر قائمة الخصائص المتقدمة**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

بعد اختيار عنصر قائمة **Advanced Properties**، سيظهر مربع حوار يتيح لك إدارة خصائص المستند لملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
في **حوار الخصائص** أعلاه، يمكنك رؤية العديد من علامات التبويب مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. تسمح جميع هذه العلامات بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم علامة **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

العمل مع خصائص المستند باستخدام Aspose.Slides for Android عبر Java

كما وصفنا سابقًا، يدعم Aspose.Slides for Android عبر Java نوعين من خصائص المستند، وهما خصائص **Built-in** و **Custom**. وبالتالي يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة برمجة تطبيقات Aspose.Slides for Android عبر Java. يوفر Aspose.Slides for Android عبر Java الفئة [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties) التي تمثل خصائص المستند المرتبطة بملف العرض التقديمي من خلال خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **IDocumentProperties** التي يوفرها كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) للوصول إلى خصائص المستند لملفات العرض التقديمي كما هو موضح أدناه:

## **الوصول إلى الخصائص المدمجة**

تتضمن هذه الخصائص التي تُظهرها كائن [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل هو مشترك بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل العرض التقديمي
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

تعديل الخصائص المدمجة لملفات العرض التقديمي سهل تمامًا مثل الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية تريدها وسيتم تعديل قيمة الخاصية. في المثال أدناه، نوضح كيفية تعديل خصائص المستند المدمجة لملف العرض باستخدام Aspose.Slides for Android عبر Java.

```java
import com.aspose.slides.*;

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

يعدل هذا المثال الخصائص المدمجة للعرض التقديمي كما يمكن رؤيته في الشكل أدناه:

|**خصائص المستند المدمجة بعد التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص المستند المخصصة**

يسمح Aspose.Slides for Android عبر Java للمطورين أيضًا بإضافة القيم المخصصة لخصائص مستند العرض التقديمي. يضيف المثال أدناه ثلاث خصائص مخصصة، ثم يبحث عن الاسم المخزن في الفهرس 2 ويزيل تلك الخاصية، بحيث يحتفظ العرض المحفوظ باثنتين منها. تُفهرس الخصائص المخصصة أبجديًا، وليس بترتيب إضافتها.

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

|**خصائص المستند المخصصة المضافة**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides for Android عبر Java للمطورين أيضًا بالوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيفية الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

```java
import com.aspose.slides.*;

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

يُعدّل هذا المثال الخصائص المخصصة لملف [PPTX](https://docs.fileformat.com/presentation/pptx/) العرض. تُظهر الأشكال التالية خصائص العرض المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصصة بعد التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="info" %}} 
تمت إضافة الطرق الجديدة [ReadDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), و[WriteBindedPresentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) إلى [IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo)، كما تم تغيير منطق دالة الضبط للخاصية [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) .
{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و[UpdateDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض بالكامل.

يمكن تنفيذ السيناريو النموذجي الذي يحمل الخصائص، يغيّر بعض القيم، ثم يُحدّث المستند بالطريقة التالية:

```java
import com.aspose.slides.*;

// قراءة معلومات العرض التقديمي
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// الحصول على الخصائص الحالية
IDocumentProperties props = info.readDocumentProperties();

// تعيين القيم الجديدة لحقول المؤلف والعنوان
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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **تحديد لغة التدقيق**

توفر Aspose.Slides الخاصية LanguageId (المُعَرَّضة بواسطة فئة PortionFormat) لتتيح لك تحديد لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يعرض هذا الكود Java كيفية تحديد لغة التدقيق لـ PowerPoint:

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

يعرض هذا الكود Java كيفية تحديد اللغة الافتراضية لكامل عرض PowerPoint:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // يضيف شكل مستطيل جديد مع نص
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // يفحص لغة الجزء الأول
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **مثال حي**

جرّب تطبيق الويب [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) لمعرفة كيفية التعامل مع خصائص المستند عبر واجهة برمجة تطبيقات Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## ***الأسئلة الشائعة**

### كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟

الخصائص المدمجة جزء لا يتجزأ من العرض التقديمي ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كقيمة فارغة إذا سمحت الخاصية المحددة بذلك.

### ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟

إذا أضفت خاصية مخصصة موجودة بالفعل، فسيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث تقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

### هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل؟

نعم، يمكنك الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل باستخدام طريقة `getPresentationInfo` من الفئة [PresentationFactory](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/) . ثم استخدم طريقة `readDocumentProperties` المقدمة من الواجهة [IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/) لقراءة الخصائص بكفاءة، مما يوفر الذاكرة ويحسن الأداء.
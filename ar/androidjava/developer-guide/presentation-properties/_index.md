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
- بيانات وصفية للمستند
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة خصائص العرض التقديمي في Aspose.Slides لنظام Android عبر Java وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **مدمجة** و **مخصصة**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتهما بسهولة باستخدام Aspose.Slides API.

يتيح Aspose.Slides لك العمل مع خصائص مستند العرض التقديمي عبر واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/) . تُرجع هذه الواجهة مثالًا من خلال [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) . تُظهر الأمثلة التالية كيفية قراءة وتعديل وإدارة هذه الخصائص.

{{% alert color="info" title="Note" %}}
يرجى ملاحظة أن حقلي **Application** و **AppVersion** لا يمكن تعديلهما. يقوم Aspose.Slides بإعادة كتابتهما عند كل حفظ، لذا فإن عرض تقديمي محفوظ دائمًا يُظهر اسم منتج Aspose.Slides وإصدار المكتبة التي أنشأته. أي قيمة تُمرّر إلى `setNameOfApplication` تُهمل عند كتابة العرض التقديمي.
{{% /alert %}} 

## **خصائص المستند في PowerPoint**

يسمح Microsoft PowerPoint 2007 بإدارة خصائص المستند لملفات العرض التقديمي. كل ما عليك هو النقر على أيقونة Office ثم اختيار **Prepare | Properties | Advanced Properties** كما هو موضح أدناه:

|**اختيار عنصر القائمة الخصائص المتقدمة**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
بعد اختيار عنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
في **حوار الخصائص** أعلاه، يمكنك ملاحظة وجود العديد من علامات التبويب مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. تسمح جميع هذه العلامات بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم علامة **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

## **العمل مع خصائص المستند باستخدام Aspose.Slides for Android عبر Java**

كما أوضحنا في السابق، يدعم Aspose.Slides for Android عبر Java نوعين من خصائص المستند، وهما **مدمجة** و **مخصصة**. وبالتالي يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام API الخاص بـ Aspose.Slides for Android عبر Java. يوفر Aspose.Slides for Android عبر Java فئة [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties) التي تمثل خصائص المستند المرتبطة بملف عرض تقديمي من خلال خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **IDocumentProperties** التي تُعرِضها كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) للوصول إلى خصائص المستند للعرض التقديمي كما هو موضح أدناه:

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما تحمي كلمة مرور الفتح كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير العرض التقديمي بتمرير `false` إلى [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)، تبقى خصائص المستند عامة. يمكن بعد ذلك للتطبيق تمرير `true` إلى [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) وقراءة البيانات الوصفية العامة دون توفير كلمة مرور الفتح.

تتحكم خيار تحميل الخصائص فقط في ما يقوم Aspose.Slides بتحميله؛ فهو لا يقوم بفك تشفير أي شيء. إذا كانت الخصائص مشمولة بالتشفير، فإن تحميلها دون كلمة المرور سيفشل. إذا لم يكن العرض التقديمي مشفرًا، فإن الخيار يُهمل ويتم تحميل العرض التقديمي بالكامل.

المثال التالي يتحقق من وضع التحميل عبر [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) ثم يقرأ الخصائص المدمجة عبر [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) :

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

في هذا الوضع، لا يتم تحميل محتوى الشريحة. الشرائح، والقوالب، وتنسيقات الشرائح، والأشكال، والوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا فحص [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) قبل تنفيذ عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات الوصفية العامة عن أسماء المؤلفين والعناوين والمواضيع والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما تتطلب أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

لملف PPTX مشفر، يُقصد بالعرض الذي يُحمَّل في وضع الخصائص فقط للقراءة العامة للبيانات الوصفية. لا يمكن لـ Aspose.Slides حفظ الخصائص المعدلة من ذلك الكائن ذو البيانات الوصفية فقط لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفر. وبالتالي يتطلب تعديلها كلمة مرور الفتح الصحيحة وتحميلًا كاملًا.

المثال التالي يفتح العرض باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)، يُحدث الخصائص العامة المدمجة، ويحفظ النتيجة. ثم يستخدم [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) للتحقق من بقاء التشفير، ويعيد فتح البيانات الوصفية العامة دون كلمة مرور للتحقق من القيم الجديدة:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض، يجب معاملة الخصائص العامة لملف PPTX المشفر كقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

تشمل الخصائص التي يُعرِضها كائن [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **SharedDoc** (هل يشارك بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

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

تعديل الخصائص المدمجة لملفات العرض التقديمي سهل كما هو الحال في الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية تريدها وستُعدَّل قيمة الخاصية. في المثال أدناه، أظهرنا كيفية تعديل خصائص المستند المدمجة للعرض التقديمي باستخدام Aspose.Slides for Android عبر Java.

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

هذا المثال يغير الخصائص المدمجة للعرض التي يمكن رؤيتها كما هو موضح أدناه:

|**خصائص المستند المدمجة بعد التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصصة**

يسمح Aspose.Slides for Android عبر Java للمطورين أيضًا بإضافة قيم مخصصة لخصائص مستند العرض التقديمي. يضيف المثال أدناه ثلاث خصائص مخصصة، ثم يبحث عن الاسم المخزن في الفهرس 2 ويزيل تلك الخاصية، لذا يبقى العرض المحفوظ به خاصيتان. تُرتَّب الخصائص المخصصة أبجديًا، وليس بترتيب إضافتها.

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
    
    // جلب اسم الخاصية في الفهرس المحدد
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // إزالة الخاصية المحددة
    dProps.removeCustomProperty(getPropertyName);
    
    // حفظ العرض التقديمي
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**خصائص المستند المخصصة التي تمت إضافتها**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides for Android عبر Java أيضًا للمطورين بالوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيف يمكنك الوصول وتعديل جميع هذه الخصائص المخصصة لعرض تقديمي.

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

هذا المثال يغيّر الخصائص المخصصة للعرض التقديمي [PPTX](https://docs.fileformat.com/presentation/pptx/). تُظهر الأشكال التالية خصائص العرض قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |
|**الخصائص المخصصة بعد التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="info" title="Note" %}}
تمت إضافة طرق جديدة [ReadDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) إلى [IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo)، وتم تغيير منطق مُعيّن الخاصية [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-).
{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IPresentationInfo). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض بالكامل.

يمكن تنفيذ السيناريو التقليدي بتحميل الخصائص، تعديل قيمة ما، ثم تحديث المستند بالطريقة التالية:

```java
import com.aspose.slides.*;

// قراءة معلومات العرض التقديمي
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
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

## **تعيين لغة التدقيق**

يوفر Aspose.Slides الخاصية LanguageId (المُعرَضة بواسطة فئة PortionFormat) لتسمح لك بتعيين لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي تُفحص فيها الإملاء والقواعد النحوية في PowerPoint.

يعرض هذا الكود Java طريقة تعيين لغة التدقيق لمستند PowerPoint:

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

## **تعيين اللغة الافتراضية**

يعرض هذا الكود Java طريقة تعيين اللغة الافتراضية لكامل عرض PowerPoint:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // يضيف شكلًا مستطيليًا جديدًا مع نص
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // يتحقق من لغة الجزء الأول
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **مثال حي**

جرّب تطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) على الإنترنت لترى كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها تمامًا. مع ذلك، يمكنك إما تغيير قيمها أو تعيينها إلى فارغ إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة مسبقًا، فإن قيمتها الحالية ستُستبدل بالجديدة. لا تحتاج إلى حذف أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض دون تحميله بالكامل؟**

نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ثم [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) لقراءة البيانات الوصفية المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) . راجع [Build a Lightweight Presentation Inventory](/slides/ar/androidjava/examine-presentation/) للحصول على مثال شامل وتحديد القيود الخاصة بكل صيغة.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر دون كلمة مرور الفتح؟**

نعم. يجب أن يكون تشفير خصائص المستند قد تم تعطيله قبل تشفير العرض، ويجب تحميل العرض في وضع الخصائص فقط.

**هل يمكنني تحديث ملف PPTX مشفر في وضع الخصائص فقط؟**

لا. يجب أن تبقى بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض بالكامل مع كلمة المرور الصحيحة.
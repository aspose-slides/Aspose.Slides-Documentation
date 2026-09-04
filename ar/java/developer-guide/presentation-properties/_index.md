---
title: إدارة خصائص العرض التقديمي في Java
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/java/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض
- خصائص المستند
- خصائص مضمّنة
- خصائص مخصّصة
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
- Java
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides for Java وسهّل البحث والعلامة التجارية وتدفق العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **مقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **مضمّن** و **مخصّص**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتها بسهولة باستخدام Aspose.Slides API.

يسمح Aspose.Slides لك بالعمل مع خصائص مستند العرض التقديمي عبر واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/). يتم إرجاع مثال من هذه الواجهة بواسطة [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getDocumentProperties--). تظهر الأمثلة التالية كيفية قراءة وتعديل وإدارة هذه الخصائص.

{{% alert color="info" title="Note" %}}
يرجى ملاحظة أن حقلي **Application** و **AppVersion** لا يمكن تعديلهما. يقوم Aspose.Slides بإعادة كتابتهما في كل عملية حفظ، لذا فإن العرض المحفوظ دائمًا يُظهر "Aspose.Slides for Java" وإصدار المكتبة التي أنتجته. يتم تجاهل أي قيمة تُمرَّر إلى `setNameOfApplication` عند كتابة العرض.
{{% /alert %}} 

## **خصائص المستند في PowerPoint**

يسمح Microsoft PowerPoint 2007 بإدارة خصائص مستند ملفات العروض التقديمية. كل ما عليك هو النقر على أيقونة Office ثم اختيار القائمة **Prepare | Properties | Advanced Properties** في Microsoft PowerPoint 2007 كما هو موضح أدناه:

|**تحديد عنصر القائمة Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

بعد اختيار عنصر القائمة **Advanced Properties**، سيظهر حوار يسمح لك بإدارة خصائص مستند ملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

في **حوار الخصائص** أعلاه، يمكنك رؤية العديد من علامات التبويب مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. جميع هذه العلامات تسمح بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم علامة **Custom** لإدارة الخصائص المخصّصة لملفات PowerPoint.

### العمل مع خصائص المستند باستخدام Aspose.Slides for Java

كما أوضحنا سابقًا، يدعم Aspose.Slides for Java نوعين من خصائص المستند، وهما الخصائص **المضمّنة** و **المخصّصة**. وبالتالي يمكن للمطورين الوصول إلى كلا النوعين باستخدام Aspose.Slides for Java API. يوفر Aspose.Slides for Java الفئة [IDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties) التي تمثّل خصائص المستند المرتبطة بملف العرض التقديمي عبر خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام الخاصية **IDocumentProperties** التي يقدّمها كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) للوصول إلى خصائص مستند ملفات العروض التقديمية كما هو موضح أدناه:

## **قراءة الخصائص العامة من عرض تقديمي مشفّر**

عادةً ما تحمي كلمة مرور الفتح كلًا من محتوى العرض وخصائص المستند. عندما يتم تشفير عرض تقديمي بتمرير `false` إلى [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)، تظل خصائص المستند عامة. يمكن لتطبيق بعد ذلك تمرير `true` إلى [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) وقراءة البيانات الوصفية العامة دون توفير كلمة مرور الفتح.

خيار تحميل الخصائص فقط يتحكم فيما يقوم Aspose.Slides بتحميله؛ فهو لا يفك تشفير شيء. إذا كانت الخصائص مشفّرة، فسينتهي التحميل دون كلمة المرور بالفشل. إذا لم يكن العرض مشفّرًا، يُتجاهل الخيار ويُحمَّل العرض بالكامل.

المثال التالي يتحقق من وضع التحميل عبر [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) ثم يقرأ الخصائص المضمنة عبر [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، والماسترات، وتخطيطات الشرائح، والأشكال، والوسائط، والكائنات الأخرى غير متوفرة. يجب على التطبيقات دائمًا التحقق من [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) قبل تنفيذ عملية تتطلّب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات الوصفية العامة عن أسماء المؤلفين، والعناوين، والمواضيع، والكلمات المفتاحية، ومعلومات الشركة، والتعليقات، والقيم المخصّصة. شفر الخصائص الحساسة مع العرض. اتركها عامة فقط عندما تكون أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات تتطلب الوصول إليها بدون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفّر**

بالنسبة إلى ملف PPTX مشفّر، يُقصد من العرض المحمّل في وضع الخصائص العامة فقط قراءة البيانات الوصفية العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص المعدّلة من هذا الكائن بسبب ضرورة توافق الخصائص العامة مع البيانات المقابلة داخل العرض المشفّر. لذلك يتطلّب التحديث كلمة مرور الفتح الصحيحة وتحميلًا كاملاً.

المثال التالي يفتح العرض باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)، يحدّث الخصائص المضمّنة العامة، ثم يحفظ النتيجة. بعد ذلك يستخدم [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) للتحقق من بقاء التشفير، ويعيد فتح البيانات الوصفية العامة بدون كلمة مرور للتحقق من القيم الجديدة:

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

إذا لم يُسمح لتطبيق بفك تشفير أو تحميل محتوى العرض، يجب أن يتعامل مع الخصائص العامة لملف PPTX المشفّر كقراءة فقط.

## **الوصول إلى الخصائص المضمّنة**

تشمل الخصائص التي يوفّرها كائن [IDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **SharedDoc** (هل هو مشترك بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل العرض التقديمي
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء إشارة إلى كائن IDocumentProperties المرتبط بالعرض التقديمي
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

تعديل الخصائص المضمّنة لملفات العرض سهل مثل الوصول إليها. يمكنك ببساطة إسناد قيمة نصية لأي خاصية مرغوبة وسيتم تعديل قيمة الخاصية. في المثال أدناه، عرضنا كيف يمكننا تعديل خصائص المستند المضمّنة لملف العرض باستخدام Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء إشارة إلى كائن IDocumentProperties المرتبط بالعرض التقديمي
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ضبط الخصائص المضمّنة
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

هذا المثال يغيّر الخصائص المضمّنة للعرض ويمكن مشاهدة النتيجة كما هو موضح أدناه:

|**خصائص المستند المضمّنة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصّصة**

يسمح Aspose.Slides for Java أيضًا للمطورين بإضافة قيم مخصّصة لخصائص مستند العرض. المثال أدناه يضيف ثلاث خصائص مخصّصة، ثم يبحث عن الاسم المخزن في الفهرس 2 ويزيل تلك الخاصية، وبالتالي يبقى في العرض المحفوظ خاصيتان. تُرتّب الخصائص المخصّصة أبجديًا، وليس بترتيب الإضافة.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // الحصول على خصائص الوثيقة
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

|**خصائص مستند مخصّصة مضافة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصّصة وتعديلها**

يتيح Aspose.Slides for Java أيضًا للمطورين الوصول إلى قيم الخصائص المخصّصة. المثال أدناه يوضح كيف يمكنك الوصول إلى جميع هذه الخصائص المخصّصة للعرض وتعديلها.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء إشارة إلى كائن DocumentProperties المرتبط بالعرض التقديمي
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // الوصول إلى الخصائص المخصّصة وتعديلها
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // عرض أسماء وقيم الخصائص المخصّصة
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // تعديل قيم الخصائص المخصّصة
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // حفظ العرض التقديمي إلى ملف
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

هذا المثال يغيّر الخصائص المخصّصة للـ [PPTX](https://docs.fileformat.com/presentation/pptx/) العرض. تُظهر الأشكال التالية الخصائص المخصّصة للعرض قبل وبعد التعديل:

|**الخصائص المخصّصة قبل التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصّصة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="info" title="Note" %}}
تمت إضافة الطرق الجديدة [ReadDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) إلى [IPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo)، وتم تغيير منطق المُعيّن [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-).
{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentationInfo). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض بالكامل.

يمكن تنفيذ السيناريو النموذجي بتحميل الخصائص، تعديل بعض القيم، ثم تحديث المستند بالطريقة التالية:

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

هناك طريقة أخرى لاستخدام خصائص عرض تقديمي معين كقالب لتحديث خصائص عروض تقديمية أخرى:

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

## **تحديد لغة التدقيق**

يوفر Aspose.Slides الخاصية LanguageId (المُعَرَّفة في فئة PortionFormat) لتعيين لغة التدقيق لملف PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يعرض هذا الشيفرة Java كيفية تحديد لغة التدقيق لملف PowerPoint:

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

## **تحديد اللغة الافتراضية**

يعرض هذا الشيفرة Java كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint:

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

جرّب تطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) على الإنترنت لترى كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مضمّنة من عرض تقديمي؟**

الخصائص المضمّنة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. يمكنك إما تغيير قيمها أو تعيينها إلى فارغ إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصّصة موجودة بالفعل؟**

إذا أضفت خاصية مخصّصة موجودة، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمتها تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ثم [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) لقراءة البيانات الوصفية المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) . راجع [Build a Lightweight Presentation Inventory](/slides/ar/java/examine-presentation/) للحصول على مثال تقارير كامل والقيود الخاصة بكل تنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض مشفّر دون كلمة مرور الفتح؟**

نعم. يجب أن يكون تشفير خاصية المستند قد أُعطل قبل تشفير العرض، ويجب تحميل العرض في وضع الخصائص العامة فقط.

**هل يمكنني تحديث ملف PPTX مشفّر في وضع الخصائص العامة فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفّرة متسقة، لذا يتطلب تحديث ملف PPTX مشفّر تحميل العرض بالكامل مع كلمة مرور الفتح الصحيحة.
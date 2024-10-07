---
title: خصائص العرض
type: docs
weight: 70
url: /androidjava/presentation-properties/
---

{{% alert color="primary" %}} 

تقدم Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العرض. تسمح هذه الخصائص الوثائقية بتخزين بعض المعلومات المفيدة جنبًا إلى جنب مع الوثائق (ملفات العرض). يوجد نوعان من الخصائص الوثائقية كما يلي:

- الخصائص المعرفة من النظام (المضمنة)
- الخصائص المعرفة من المستخدم (المخصصة)

تحتوي الخصائص **المضمنة** على معلومات عامة حول الوثيقة مثل عنوان الوثيقة، اسم المؤلف، إحصائيات الوثيقة وما إلى ذلك. الخصائص **المخصصة** هي تلك التي يتم تعريفها من قبل المستخدمين كأزواج **اسم/قيمة**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides لنظام Android عبر Java، يمكن للمطورين الوصول إلى قيم الخصائص المضمنة وتعديلها بالإضافة إلى الخصائص المخصصة.

{{% /alert %}} 

## **خصائص الوثيقة في PowerPoint**
يسمح Microsoft PowerPoint 2007 بإدارة الخصائص الوثائقية لملفات العرض. كل ما عليك فعله هو النقر على أيقونة Office ثم عنصر القائمة **إعداد | خصائص | خصائص متقدمة** كما هو موضح أدناه:

{{% alert color="primary" %}} 

يرجى ملاحظة أنك لا تستطيع تعيين قيم ضد حقول **التطبيق** و **المنتج**، لأنه سيظهر Aspose Ltd. و Aspose.Slides لنظام Android عبر Java x.x.x ضد هذه الحقول.

{{% /alert %}} 

|**اختيار عنصر قائمة الخصائص المتقدمة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
بعد اختيار عنصر القائمة **خصائص متقدمة**، ستظهر نافذة حوار تسمح لك بإدارة الخصائص الوثائقية لملف PowerPoint كما هو موضح أدناه في الشكل:

|**نافذة خصائص**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
في **نافذة الخصائص** أعلاه، يمكنك رؤية العديد من الصفحات مثل **عام**، **ملخص**، **إحصائيات**، **محتويات** و **مخصص**. جميع هذه الصفحات تسمح بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم علامة **مخصص** لإدارة الخصائص المخصصة لملفات PowerPoint.



العمل مع الخصائص الوثائقية باستخدام Aspose.Slides لنظام Android عبر Java

كما وصفنا سابقًا فإن Aspose.Slides لنظام Android عبر Java يدعم نوعين من الخصائص الوثائقية، وهما الخصائص **المضمنة** و **المخصصة**. لذا، يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة برمجة تطبيقات Aspose.Slides لنظام Android عبر Java. توفر Aspose.Slides لنظام Android عبر Java فئة [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) التي تمثل الخصائص الوثائقية المتعلقة بملف العرض من خلال خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **IDocumentProperties** التي تعرضها كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) للوصول إلى الخصائص الوثائقية لملفات العرض كما هو موضح أدناه:

## **الوصول إلى الخصائص المضمنة**
تشمل هذه الخصائص كما تعرضها كائن [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties): **المنشئ** (المؤلف)، **الوصف**، **الكلمات المفتاحية**، **تاريخ الإنشاء** (تاريخ الإنشاء)، **تاريخ التعديل**، **آخر تاريخ طباعة**، **آخر تعديل بواسطة**، **الكلمات المفتاحية**، **وثيقة مشتركة** (هل يتم مشاركتها بين منتجات مختلفة؟)، **تنسيق العرض**، **الموضوع** و **العنوان**.

```java
// إنشاء مثيل من فئة Presentation التي تمثل العرض
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع لكائن IDocumentProperties المرتبط بالتقديم
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // عرض الخصائص المضمنة
    System.out.println("الفئة : " + dp.getCategory());
    System.out.println("الحالة الحالية : " + dp.getContentStatus());
    System.out.println("تاريخ الإنشاء : " + dp.getCreatedTime());
    System.out.println("المؤلف : " + dp.getAuthor());
    System.out.println("الوصف : " + dp.getComments());
    System.out.println("الكلمات المفتاحية : " + dp.getKeywords());
    System.out.println("آخر تعديل بواسطة : " + dp.getLastSavedBy());
    System.out.println("المشرف : " + dp.getManager());
    System.out.println("تاريخ التعديل : " + dp.getLastSavedTime());
    System.out.println("تنسيق العرض : " + dp.getPresentationFormat());
    System.out.println("آخر تاريخ طباعة : " + dp.getLastPrinted());
    System.out.println("هل يتم مشاركتها بين المنتجات : " + dp.getSharedDoc());
    System.out.println("الموضوع : " + dp.getSubject());
    System.out.println("العنوان : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعديل الخصائص المضمنة**
تعديل الخصائص المضمنة لملفات العرض سهل كما هو الحال في الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية مرغوبة وسيتم تعديل قيمة الخاصية. في المثال المذكور أدناه، قمنا بشرح كيفية تعديل الخصائص الوثائقية المضمنة لملف العرض باستخدام Aspose.Slides لنظام Android عبر Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع لكائن IDocumentProperties المرتبط بالتقديم
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // تعيين الخصائص المضمنة
    dp.setAuthor("Aspose.Slides لنظام Android عبر Java");
    dp.setTitle("تعديل خصائص العرض");
    dp.setSubject("موضوع Aspose");
    dp.setComments("وصف Aspose");
    dp.setManager("مدير Aspose");
    
    // حفظ العرض إلى ملف
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

يعدل هذا المثال الخصائص المضمنة للعرض التي يمكن مشاهدتها كما هو موضح أدناه:

|**الخصائص الوثائقية المضمنة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص وثائقية مخصصة**
تسمح Aspose.Slides لنظام Android عبر Java أيضًا للمطورين بإضافة القيم المخصصة لخصائص وثائق العرض. فيما يلي مثال يوضح كيفية تعيين الخصائص المخصصة لعرض.

```java
Presentation pres = new Presentation();
try {
    // الحصول على الخصائص الوثائقية
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // إضافة الخصائص المخصصة
    dProps.set_Item("خصائص مخصصة جديدة", 12);
    dProps.set_Item("اسمي", "مدثر");
    dProps.set_Item("مخصص", 124);
    
    // الحصول على اسم الخاصية في الفهرس المحدد
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // إزالة الخاصية المحددة
    dProps.removeCustomProperty(getPropertyName);
    
    // حفظ العرض
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**الخصائص الوثائقية المخصصة المضافة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى وتعديل الخصائص المخصصة**
تسمح Aspose.Slides لنظام Android عبر Java أيضًا للمطورين بالوصول إلى قيم الخصائص المخصصة. فيما يلي مثال يوضح كيفية الوصول إلى جميع هذه الخصائص المخصصة ومعدلها لعرض.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع لكائن DocumentProperties المرتبط بالتقديم
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // الوصول إلى وتعديل الخصائص المخصصة
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // عرض أسماء وقيم الخصائص المخصصة
        System.out.println("اسم الخاصية المخصصة : " + dp.getCustomPropertyName(i));
        System.out.println("قيمة الخاصية المخصصة : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // تعديل قيم الخصائص المخصصة
        dp.set_Item(dp.getCustomPropertyName(i), "قيمة جديدة " + (i + 1));
    }
    
    // حفظ عرضك إلى ملف
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

يعدل هذا المثال الخصائص المخصصة للعرض [PPTX ](https://docs.fileformat.com/presentation/pptx/). توضح الأشكال التالية الخصائص المخصصة للعرض قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**الخصائص المخصصة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **الخصائص الوثائقية المتقدمة**
{{% alert color="primary" %}} 

تمت إضافة طرق جديدة [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) و [WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo)، وتم تغيير منطق مُعين الخاصية [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) .

{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo). ويوفران الوصول السريع إلى الخصائص الوثائقية ويسمحان بتغيير وتحديث الخصائص دون تحميل العرض بالكامل.

يمكن تنفيذ السيناريو النموذجي لتحميل الخصائص، وتغيير بعض القيم وتحديث الوثيقة بالطريقة التالية:

```java
// قراءة معلومات العرض
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// الحصول على الخصائص الحالية
IDocumentProperties props = info.readDocumentProperties();

// تعيين القيم الجديدة لحقول المؤلف والعنوان
props.setAuthor("مؤلف جديد");
props.setTitle("عنوان جديد");

// تحديث العرض بالقيم الجديدة
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

هناك طريقة أخرى لاستخدام خصائص عرض معينة كنموذج لتحديث الخصائص في عروض أخرى:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("مؤلف النموذج");
template.setTitle("عنوان النموذج");
template.setCategory("فئة النموذج");
template.setKeywords("الكلمة المفتاحية 1، الكلمة المفتاحية 2، الكلمة المفتاحية 3");
template.setCompany("شركتنا");
template.setComments("تم إنشاؤه من القالب");
template.setContentType("محتوى النموذج");
template.setSubject("موضوع النموذج");

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

يمكن إنشاء نموذج جديد من الصفر ثم استخدامه لتحديث عروض متعددة:

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("مؤلف النموذج");
template.setTitle("عنوان النموذج");
template.setCategory("فئة النموذج");
template.setKeywords("الكلمة المفتاحية 1، الكلمة المفتاحية 2، الكلمة المفتاحية 3");
template.setCompany("شركتنا");
template.setComments("تم إنشاؤه من القالب");
template.setContentType("محتوى النموذج");
template.setSubject("موضوع النموذج");

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

## **تحقق مما إذا كان العرض قد تم تعديله أو إنشاؤه**
تقدم Aspose.Slides لنظام Android عبر Java ميزة للتحقق مما إذا كان قد تم تعديل العرض أو إنشاؤه. فيما يلي مثال يوضح كيفية التحقق مما إذا كان العرض قد تم إنشاؤه أو تعديله.

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("اسم التطبيق: " + app);
System.out.println("إصدار التطبيق: " + ver);
```

## **تعيين لغة التدقيق**

توفر Aspose.Slides خاصية LanguageId (المعروضة بواسطة فئة PortionFormat) لتسمح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص التهجئة والنحو في PowerPoint.

يوضح هذا الكود Java كيفية تعيين لغة التدقيق لعرض PowerPoint: xxx لماذا لغة LanguageId مفقودة من فئة PortionFormat في Java؟

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

يوضح هذا الكود Java كيفية تعيين اللغة الافتراضية لعرض PowerPoint بالكامل:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // إضافة شكل مستطيل جديد مع نص
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("نص جديد");

    // التحقق من لغة الجزء الأول
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```
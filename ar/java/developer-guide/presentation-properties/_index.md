---
title: خصائص العرض
type: docs
weight: 70
url: /java/presentation-properties/
---

{{% alert color="primary" %}} 

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العرض التقديمي. تتيح هذه الخصائص الوثائقية تخزين بعض المعلومات المفيدة مع الوثائق (ملفات العرض التقديمي). هناك نوعان من الخصائص الوثائقية كما يلي:

- الخصائص المعرفة بواسطة النظام (المضمنة)
- الخصائص المعرفة بواسطة المستخدم (المخصصة)

الخصائص **المضمنة** تحتوي على معلومات عامة عن الوثيقة مثل عنوان الوثيقة، اسم المؤلف، إحصاءات الوثيقة وما إلى ذلك. الخصائص **المخصصة** هي تلك التي يتم تعريفها بواسطة المستخدمين كأزواج **اسم/قيمة**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides لـ Java، يمكن للمطورين الوصول إلى القيم وتعديلها للخصائص المضمنة بالإضافة إلى الخصائص المخصصة.

{{% /alert %}} 

## **خصائص الوثيقة في PowerPoint**
يتيح Microsoft PowerPoint 2007 إدارة خصائص الوثيقة لملفات العرض التقديمي. كل ما عليك فعله هو النقر على رمز Office ومن ثم تحديد خيار القائمة **إعداد | خصائص | خصائص متقدمة** في Microsoft PowerPoint 2007 كما هو موضح أدناه:

{{% alert color="primary" %}} 

يرجى ملاحظة أنه لا يمكنك تعيين قيم للحقول **التطبيق** و **المنتج**، لأن Aspose Ltd. و Aspose.Slides لـ Java x.x.x ستظهر ضد هذه الحقول.

{{% /alert %}} 

|**اختيار خيار خصائص متقدمة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
بعد اختيار خيار **خصائص متقدمة**، ستظهر نافذة حوار تسمح لك بإدارة خصائص الوثيقة لملف PowerPoint كما هو موضح أدناه في الشكل:

|**نافذة خصائص**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
في **نافذة الخصائص** أعلاه، يمكنك رؤية أن هناك العديد من الصفحات مثل **عام**، **ملخص**، **إحصائيات**، **محتويات** و **مخصصة**. تسمح جميع هذه الصفحات بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. يتم استخدام علامة التبويب **مخصصة** لإدارة الخصائص المخصصة لملفات PowerPoint.



العمل مع خصائص الوثيقة باستخدام Aspose.Slides لـ Java

كما وصفنا سابقًا، يدعم Aspose.Slides لـ Java نوعين من خصائص الوثيقة، وهما الخصائص **المضمنة** و **المخصصة**. لذلك، يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة برمجة تطبيقات Aspose.Slides لـ Java. توفر Aspose.Slides لـ Java فئة [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) التي تمثل خصائص الوثيقة المرتبطة بملف العرض التقديمي من خلال خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **IDocumentProperties** المعروضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) للوصول إلى خصائص وثيقة ملفات العرض التقديمي كما هو موضح أدناه:

## **الوصول إلى الخصائص المضمنة**
تشمل هذه الخصائص كما تعرضها كائن [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties): **المؤلف** (Author)، **الوصف**، **الكلمات المفتاحية**، **تاريخ الإنشاء**، **تاريخ التعديل**، **تاريخ الطباعة الأخير**، **آخر من عدلها**، **الكلمات المفتاحية**، **وثيقة مشتركة** (هل مكررة بين منتجين مختلفين؟)، **صيغة العرض**، **الموضوع** و **العنوان**.

```java
// إنشاء كائن من فئة العرض الذي يمثل العرض التقديمي
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع لكائن IDocumentProperties المرتبط بالعرض التقديمي
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // عرض الخصائص المضمنة
    System.out.println("الفئة : " + dp.getCategory());
    System.out.println("الحالة الحالية : " + dp.getContentStatus());
    System.out.println("تاريخ الإنشاء : " + dp.getCreatedTime());
    System.out.println("المؤلف : " + dp.getAuthor());
    System.out.println("الوصف : " + dp.getComments());
    System.out.println("الكلمات المفتاحية : " + dp.getKeywords());
    System.out.println("آخر من عدلها : " + dp.getLastSavedBy());
    System.out.println("المدير : " + dp.getManager());
    System.out.println("تاريخ التعديل : " + dp.getLastSavedTime());
    System.out.println("صيغة العرض : " + dp.getPresentationFormat());
    System.out.println("تاريخ الطباعة الأخير : " + dp.getLastPrinted());
    System.out.println("هل مشتركة بين المنتجين : " + dp.getSharedDoc());
    System.out.println("الموضوع : " + dp.getSubject());
    System.out.println("العنوان : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعديل الخصائص المضمنة**
تعديل الخصائص المضمنة لملفات العرض التقديمي سهل كما هو الوصول إليها. يمكنك ببساطة تعيين قيمة سلسلة لأي خاصية مرغوبة وسيتم تعديل قيمة الخاصية. في المثال المذكور أدناه، قمنا بإظهار كيفية تعديل الخصائص المضمنة لوثيقة العرض التقديمي باستخدام Aspose.Slides لـ Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع لكائن IDocumentProperties المرتبط بالعرض التقديمي
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // تعيين الخصائص المضمنة
    dp.setAuthor("Aspose.Slides لـ Java");
    dp.setTitle("تعديل خصائص العرض");
    dp.setSubject("موضوع Aspose");
    dp.setComments("وصف Aspose");
    dp.setManager("مدير Aspose");
    
    // حفظ العرض التقديمي إلى ملف
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

هذا المثال يعدل الخصائص المضمنة للعرض التقديمي التي يمكن رؤيتها كما هو موضح أدناه:

|**خصائص الوثيقة المضمنة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص وثيقة مخصصة**
يسمح Aspose.Slides لـ Java أيضًا للمطورين بإضافة القيم المخصصة لخصائص وثيقة العرض التقديمي. مثال موضح أدناه يظهر كيفية تعيين الخصائص المخصصة لعرض تقديمي.

```java
Presentation pres = new Presentation();
try {
    // الحصول على خصائص الوثيقة
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // إضافة خصائص مخصصة
    dProps.set_Item("خصائص جديدة", 12);
    dProps.set_Item("اسمي", "مدثر");
    dProps.set_Item("مخصص", 124);
    
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

|**خصائص وثيقة مخصصة تمت إضافتها**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصصة وتعديلها**
يسمح Aspose.Slides لـ Java أيضًا للمطورين بالوصول إلى قيم الخصائص المخصصة. مثال موضح أدناه يظهر كيف يمكنك الوصول إلى وتعديل جميع هذه الخصائص المخصصة لعرض تقديمي.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // إنشاء مرجع لكائن DocumentProperties المرتبط بالعرض التقديمي
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // الوصول إلى وتعديل الخصائص المخصصة
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // عرض أسماء وقيم الخصائص المخصصة
        System.out.println("اسم الخاصية المخصصة : " + dp.getCustomPropertyName(i));
        System.out.println("قيمة الخاصية المخصصة : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // تعديل قيم الخصائص المخصصة
        dp.set_Item(dp.getCustomPropertyName(i), "قيمة جديدة " + (i + 1));
    }
    
    // حفظ العرض التقديمي إلى ملف
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

هذا المثال يعدل الخصائص المخصصة لوثيقة [PPTX ](https://docs.fileformat.com/presentation/pptx/). توضح الأشكال التالية خصائص العرض المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**الخصائص المخصصة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص الوثيقة المتقدمة**
{{% alert color="primary" %}} 

تمت إضافة طرق جديدة [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) و [WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo)، وتم تغيير منطق الخاصية [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) setter.

{{% /alert %}} 

تمت إضافة طريقتين جديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo). توفر هذه الطرق وصولًا سريعًا إلى خصائص الوثيقة وتسمح بتغيير وتحديث الخصائص دون تحميل العرض التقديمي بالكامل.

يمكن تنفيذ السيناريو النموذجي لتحميل الخصائص، وتغيير بعض القيم وتحديث الوثيقة على النحو التالي:

```java
// قراءة معلومات العرض التقديمي
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// الحصول على الخصائص الحالية
IDocumentProperties props = info.readDocumentProperties();

// تعيين القيم الجديدة لحقول المؤلف والعنوان
props.setAuthor("مؤلف جديد");
props.setTitle("عنوان جديد");

// تحديث العرض التقديمي بالقيم الجديدة
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

هناك طريقة أخرى لاستخدام خصائص عرض معين كنموذج لتحديث الخصائص في عروض أخرى:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("مؤلف النموذج");
template.setTitle("عنوان النموذج");
template.setCategory("فئة النموذج");
template.setKeywords("الكلمة المفتاحية 1، الكلمة المفتاحية 2، الكلمة المفتاحية 3");
template.setCompany("شركتنا");
template.setComments("تم إنشائها من النموذج");
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

يمكن إنشاء نموذج جديد من الصفر ثم استخدامه لتحديث عدة عروض:

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("مؤلف النموذج");
template.setTitle("عنوان النموذج");
template.setCategory("فئة النموذج");
template.setKeywords("الكلمة المفتاحية 1، الكلمة المفتاحية 2، الكلمة المفتاحية 3");
template.setCompany("شركتنا");
template.setComments("تم إنشائها من النموذج");
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

## **التحقق مما إذا كان العرض التقديمي تم تعديله أو إنشاؤه**
يوفر Aspose.Slides لـ Java الميزة للتحقق مما إذا كان العرض التقديمي قد تم تعديله أو إنشاؤه. مثال موضح أدناه يظهر كيفية التحقق مما إذا كان العرض التقديمي قد تم إنشاؤه أو تعديله.

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("اسم التطبيق: " + app);
System.out.println("إصدار التطبيق: " + ver);
```

## **تعيين لغة التدقيق**

يوفر Aspose.Slides خاصية LanguageId (المعروضة بواسطة فئة PortionFormat) للسماح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم التحقق من تهجئتها وقواعدها في PowerPoint.

يوضح هذا الكود في Java كيفية تعيين لغة التدقيق لعرض PowerPoint: xxx لماذا لغة LanguageId مفقودة من فئة PortionFormat في Java؟

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

    portionFormat.setLanguageId("zh-CN"); // تعيين Id للغة التدقيق

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين اللغة الافتراضية**

يوضح هذا الكود في Java كيفية تعيين اللغة الافتراضية لعرض PowerPoint بالكامل:

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
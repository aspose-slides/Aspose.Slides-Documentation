---
title: استرجاع وتحديث معلومات العرض التقديمي في جافا
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/java/examine-presentation/
keywords:
- صيغة العرض التقديمي
- خصائص العرض التقديمي
- خصائص المستند
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- تحديث الخصائص
- فحص PPTX
- فحص PPT
- فحص ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام جافا للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides تحديد تنسيق العرض التقديمي وقراءة البيانات الوصفية للمستند دون إنشاء نموذج كائن عرض تقديمي كامل. هذا مفيد عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ القرار بتحميل ومعالجة محتوى العرض التقديمي.

توضح هذه المقالة عملية الفحص الخفيف الوزن من خلال [PresentationFactory](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/) و[IPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/)، بالإضافة إلى التحديثات المستهدفة عبر [IDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/).

## **التحقق من تنسيق العرض التقديمي**

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) لفحص ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) . تُبلغ طريقة [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) عن التنسيق المكتشف، مثل PPTX أو PPT أو ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **إنشاء جرد عرض تقديمي خفيف الوزن**

عند معالجة عدد كبير من ملفات العروض التقديمية، قد تحتاج إلى جرد مضغوط للتصديق أو الفهرسة أو نظام إدارة المستندات. في هذا السيناريو، استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) للحصول على كائن [IPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/) ، ثم استدعِ [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) لقراءة البيانات الوصفية للمستند. لا يقوم هذا الأسلوب بإنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) ولا يتطلب منك استعراض نموذج كائن العرض الكامل.

توفر الخصائص الموسعة التي يعرضها [IDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/) القيم التالية للجرد:

| Method | Inventory value |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getSlides--) | إجمالي عدد الشرائح. |
| [getHiddenSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | عدد الشرائح المخفية. |
| [getNotes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getNotes--) | عدد الشرائح التي تحتوي على ملاحظات. |
| [getParagraphs](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | إجمالي عدد الفقرات، إذا كانت متوفرة. |
| [getWords](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getWords--) | إجمالي عدد الكلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | إجمالي عدد مقاطع الصوت والفيديو. |

المثال التالي يقرأ هذه القيم دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) ويطبع جردًا مضغوطًا. كما يجمع بين [getHeadingPairs](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) و[getTitlesOfParts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) لعرض مجموعات المحتوى مثل الخطوط، السمات، وعناوين الشرائح.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

كل [IHeadingPair](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iheadingpair/) يورد اسم المجموعة وعدد العناصر في تلك المجموعة. تُعيد [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) مصفوفة مسطحة مرتبة، لذا استخدم عدد العناوين المتتالية المحدد بواسطة كل زوج عنوان.

### **البيانات الوصفية المخزنة وقيود التنسيق**

خصائص الجرد التي تُرجعها [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) تعكس البيانات الوصفية المتوفرة في المستند الأصلي. لا يقوم Aspose.Slides بتحميل واستعراض نموذج كائن العرض لإعادة حساب هذه القيم لهذه العملية. تُستبدل الخصائص المفقودة بالقيم الافتراضية، وقد تكون القيم المخزنة قديمة إذا لم تقم التطبيق الذي حفظ الملف آخر مرة بتحديث خصائص المستند.

- **PPTX:** يقدم التنسيق خصائص مستند موسعة لعدد الشرائح، الملاحظات، الشرائح المخفية، الفقرات، الكلمات، ومقاطع الوسائط المتعددة، بالإضافة إلى أزواج العناوين وعناوين الأجزاء. تعتمد التوفرية على الخصائص التي كتبها منتج المستند.
- **PPT:** يمكن للتنسيق الثنائي تخزين خصائص ملخص المستند المقابلة. إذا كانت الخاصية غير موجودة أو لم يتم تحديثها من قبل منتج المستند، يعيد Aspose.Slides قيمتها المخزنة أو الافتراضية بدلاً من حسابها من الشرائح.
- **ODP:** توفر بيانات OpenDocument إحصائيات عامة للمستند مثل عدد الصفحات، الفقرات، والكلمات، لكن هذه القيم لا تتطابق مع كل خاصية موسعة خاصة بـ PowerPoint. قد تكون بيانات الشرائح المخفية، شرائح الملاحظات، الوسائط المتعددة، أزواج العناوين، وعناوين الأجزاء غير متوفرة، وقد تُرجع خصائص الجرد قيمًا افتراضية. لا تُعامل القيمة صفر أو المصفوفة الفارغة كدليل قاطع على عدم وجود المحتوى المقابل.

استخدم نهج البيانات الوصفية الخفيفة للجرد والفحوصات الأولية. حمّل العرض وابدأ استعراض نموذج كائنه الحي عندما يجب أن يعكس النتيجة التغييرات في الذاكرة أو عندما تحتاج إلى التحقق من المحتوى الفعلي للعرض.

## **تحديث خصائص العرض التقديمي**

يمكن أيضًا تغيير الخصائص التي تُرجعها [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) . طبّق التغييرات باستخدام [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، ثم اكتب العرض المرتبط باستخدام [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

الصورة التالية تعرض خصائص المستند الأصلية لعرض PowerPoint:

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

المثال التالي يغيّر العنوان وتاريخ الحفظ الأخير ويكتب النتيجة إلى ملف جديد:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

الصورة التالية تعرض خصائص المستند المعدلة لعرض PowerPoint:

![خصائص المستند المعدلة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للفحوصات الأمنية ذات الصلة وإعدادات الحماية، راجع المقالات التالية:

- [حماية العروض التقديمية بكلمة مرور](/slides/ar/java/password-protected-presentation/)
- [حماية العروض التقديمية من الكتابة](/slides/ar/java/write-protected-presentation/)

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمنة وما هي؟**

حمّل العرض واستخدم [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getFontsManager--). استدعِ [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) للحصول على الخطوط المضمنة و[IFontsManager.getFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getFonts--) للحصول على الخطوط المستخدمة في العرض. قارن النتيجتين لتحديد الخطوط المطلوبة للعرض ولكنها غير مضمّنة.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

عند كون البيانات الوصفية المخزنة كافية، اقرأ [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) عبر [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). هذا مناسب لجرد خفيف. إذا تم تعديل العرض في الذاكرة، قد تكون البيانات الوصفية المخزنة مفقودة أو قديمة، أو إذا احتجت إلى التحقق من القيم الحية، استعرض [Presentation.getSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSlides--) وتفحص طريقة [ISlide.getHidden](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getHidden--) لكل شريحة بدلاً من ذلك.

**هل يمكنني اكتشاف ما إذا كان يتم استخدام حجم وشكل مخصص للشرائح، وما إذا كان يختلف عن الإعدادات الافتراضية؟**

نعم. حمّل العرض واستدعِ [Presentation.getSlideSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSlideSize--). استخدم [ISlideSize.getType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidesize/#getType--)، [ISlideSize.getSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidesize/#getSize--)، و[ISlideSize.getOrientation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidesize/#getOrientation--) لمقارنة الإعدادات الحالية مع القيم المسبقة والأبعاد المتوقعة.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. ابحث عن كل [Chart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chart/) واستدعِ [IChartData.getDataSourceType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#getDataSourceType--). إذا كان المصدر ملفًا عمل خارجيًا، استدعِ [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). يحدد نوع المصدر والمسار إشارة إلى مرجع خارجي، لكن التحقق من توفر الهدف يتطلب فحصًا منفصلاً للموارد.

**كيف يمكنني تقييم "الشرائح الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

لا توجد خاصية واحدة تعكس التعقيد. استعرض [Presentation.getSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSlides--) وكل مجموعة [IBaseSlide.getShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/#getShapes--) للشرائح. استخدم عدد الأشكال ووجود صور كبيرة، تأثيرات، رسومات متحركة، أو وسائط متعددة كإشارات فحص، وقم بقياس عرض تمثيلي أو تصدير قبل اعتبار الشريحة عنق زجاجة للأداء.
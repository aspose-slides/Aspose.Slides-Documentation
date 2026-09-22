---
title: استرداد وتحديث معلومات العرض التقديمي على Android
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/androidjava/examine-presentation/
keywords:
- تنسيق العرض التقديمي
- خصائص العرض التقديمي
- خصائص المستند
- جلب الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- تحديث الخصائص
- فحص PPTX
- فحص PPT
- فحص ODP
- PowerPoint
- OpenDocument
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات التعريفية في عروض PowerPoint وOpenDocument باستخدام Java للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides تحديد تنسيق العرض التقديمي وقراءة بيانات تعريف المستند دون إنشاء نموذج كائن عرض تقديمي كامل. يكون هذا مفيدًا عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ قرار بتحميل ومعالجة محتوى العرض التقديمي.

توضح هذه المقالة الفحص الخفيف الوزن من خلال [PresentationFactory](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/) و[IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/)، بالإضافة إلى التحديثات المستهدفة من خلال [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/).

## **التحقق من تنسيق العرض التقديمي**

إذا كان لديك عرض تقديمي محمَّل بالفعل، راجع [Determine the Original Presentation Format](/slides/ar/androidjava/detect-presentation-source-format/) للاكتشاف بعد التحميل وقيود تدفقات PPT وPPS وPOT القديمة.

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) لفحص ملف دون إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). تقوم طريقة [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) بالإبلاغ عن التنسيق المكتشف، مثل PPTX أو PPT أو ODP.

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

عند معالجة العديد من ملفات العروض التقديمية، قد تحتاج إلى جرد مضغوط للتحقق، الفهرسة، أو نظام إدارة المستندات. في هذا السيناريو، استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) للحصول على كائن [IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/)، ثم استدعِ [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) لقراءة بيانات تعريف المستند. لا ينشئ هذا النهج مثيلًا من [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) ولا يتطلب استعراض نموذج كائن العرض الكامل.

توفر الخصائص الموسعة التي يكشف عنها [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/) القيم التالية للجرد:

| الطريقة | قيمة الجرد |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | العدد الإجمالي للشرائح. |
| [getHiddenSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | عدد الشرائح المخفية. |
| [getNotes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | عدد الشرائح التي تحتوي على ملاحظات. |
| [getParagraphs](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | العدد الإجمالي للفقرات، إذا كان متاحًا. |
| [getWords](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | العدد الإجمالي للكلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | العدد الإجمالي لمقاطع الصوت والفيديو. |

تقرأ المثال التالي هذه القيم دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) وتطبع جردًا مضغوطًا. كما يجمع بين [getHeadingPairs](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) و[getTitlesOfParts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) لعرض مجموعات محتوى مثل الخطوط، السمات، وعناوين الشرائح.

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

كل [IHeadingPair](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iheadingpair/) يوفّر اسم مجموعة وعدد العناصر في تلك المجموعة. تُرجع [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) مصفوفة مسطحة مرتبة، لذا استهلك عدد العناوين المتتالية المحدد بواسطة كل زوج عنوان.

### **البيانات المخزنة وقيود التنسيق**

تعكس الخصائص التي تُعيدها [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) البيانات التعريفية المتوفرة في المستند الأصلي. لا تقوم Aspose.Slides بتحميل واستعراض نموذج كائن العرض لإعادة حساب هذه القيم عند هذه الاستدعاءات. تُمثَّل الخصائص المفقودة بقيم افتراضية، وقد تكون القيم المخزنة قديمة إذا لم تُحدِّث التطبيق الذي حفظ الملف آخر مرة خصائص المستند.

- **PPTX:** يوفر التنسيق خصائص مستند موسعة لعدد الشرائح، الملاحظات، الشرائح المخفية، الفقرات، الكلمات، والمقاطع المتعددة الوسائط، بالإضافة إلى أزواج العناوين وعناوين الأجزاء. تعتمد التوافرية على الخصائص التي كتبها منتج المستند.
- **PPT:** يمكن للنسق الثنائي تخزين خصائص ملخص المستند المقابلة. إذا كانت الخاصية غائبة أو لم يُحدِّثها منتج المستند، تُعيد Aspose.Slides قيمتها المخزنة أو القيمة الافتراضية بدلًا من حسابها من الشرائح.
- **ODP:** توفر بيانات تعريف OpenDocument إحصاءات عامة للمستند مثل عدد الصفحات، الفقرات، والكلمات، لكن هذه القيم لا تتطابق مع كل خاصية موسعة خاصة بـ PowerPoint. قد تكون بيانات الشرائح المخفية، ملاحظات الشرائح، الوسائط المتعددة، أزواج العناوين، وعناوين الأجزاء غير متوفرة، وقد تُعيد خصائص الجرد قيمًا افتراضية. لا تُعامل القيمة الصفرية أو المصفوفة الفارغة كدليل قاطع على غياب المحتوى المقابل.

استخدم نهج البيانات التعريفية الخفيف للجرد والفحوصات الأولية. احمِل العرض وتفحص نموذج كائنه الحي عندما يجب أن يعكس النتيجة تغييرات الذاكرة أو عندما تحتاج إلى التحقق من المحتوى الفعلي للعرض.

## **تحديث خصائص العرض التقديمي**

يمكن أيضًا تعديل الخصائص التي تُعيدها [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) دون إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). طبِّق التغييرات باستخدام [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، ثم اكتب العرض المرتبط باستخدام [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

الصورة التالية توضح خصائص المستند الأصلية لعرض PowerPoint.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

المثال التالي يغيّر العنوان ووقت الحفظ الأخير ويكتب النتيجة إلى ملف جديد:

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

الصورة التالية توضح خصائص المستند المحدثة لعرض PowerPoint.

![خصائص المستند المحدثة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للفحوصات الأمنية ذات الصلة وإعدادات الحماية، راجع المقالات التالية:

- [Password-Protect Presentations](/slides/ar/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ar/androidjava/write-protected-presentation/)

## **FAQ**

**كيف يمكنني التحقق مما إذا كانت الخطوط مدمجة وأيها؟**

حمِّل العرض واستخدم [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getFontsManager--). استدعِ [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) للحصول على الخطوط المدمجة و[IFontsManager.getFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) للحصول على الخطوط المستخدمة في العرض. قارن النتيجتين لتحديد الخطوط المطلوبة للعرض ولكن غير مدمجة.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

عند كفاية بيانات تعريف المستند المخزنة، اقرأ [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) عبر [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). هذا مناسب لجرد خفيف. إذا كان العرض قد تم تعديلُه في الذاكرة، قد تكون البيانات المخزنة مفقودة أو قديمة، أو تحتاج للتحقق من القيم الحية، فاستعرض [Presentation.getSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlides--) وتفحص طريقة [ISlide.getHidden](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#getHidden--) لكل شريحة بدلاً من ذلك.

**هل يمكنني اكتشاف ما إذا كان حجم الشريحة المخصص والاتجاه مستخدمين، وما إذا كانا يختلفان عن القيم الافتراضية؟**

نعم. حمِّل العرض واستدعِ [Presentation.getSlideSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlideSize--). استخدم [ISlideSize.getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidesize/#getType--)، [ISlideSize.getSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidesize/#getSize--)، و[ISlideSize.getOrientation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidesize/#getOrientation--) لمقارنة الإعدادات الحالية مع القالب والأبعاد المتوقعة.

**هل هناك طريقة سريعة لمعرفة ما إذا كان الرسوم البيانية تشير إلى مصادر بيانات خارجية؟**

نعم. حدد كل [Chart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/chart/) واستدعِ [IChartData.getDataSourceType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--). لدفتر عمل خارجي، استدعِ [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). يحدد نوع مصدر البيانات والمسار إشارة إلى مرجع خارجي، لكن التحقق من توفر الهدف يتطلب فحصًا منفصلًا للموارد.

**كيف يمكنني تقييم "الشرائح الثقيلة" التي قد تُبطئ العرض أو تصدير PDF؟**

لا توجد خاصية تعقيد واحدة. استعرض [Presentation.getSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlides--) وكل مجموعة [IBaseSlide.getShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/#getShapes--) لكل شريحة. استخدم عدد الأشكال ووجود صور كبيرة، تأثيرات، رسوم متحركة، أو وسائط متعددة كإشارات فحص، وقم بقياس عملية عرض أو تصدير تمثلية قبل اعتبار الشريحة عبئًا مؤكدًا على الأداء.
---
title: استرجاع وتحديث معلومات العرض التقديمي على Android
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/androidjava/examine-presentation/
keywords:
- تنسيق العرض التقديمي
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
- باوربوينت
- أوبن دوكيومنت
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint و OpenDocument باستخدام Java للحصول على رؤى أسرع وتدقيق محتوى أذكى."
---
## **نظرة عامة**

Aspose.Slides يمكنه التعرف على تنسيق العرض التقديمي وقراءة بيانات التعريف الخاصة بالمستند دون إنشاء نموذج كائن عرض كامل. هذا مفيد عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ قرار بتحميل ومعالجة محتوى العرض.

توضح هذه المقالة الفحص الخفيف الوزن عبر [PresentationFactory](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/) و[IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/)، بالإضافة إلى التحديثات المستهدفة عبر [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/).

## **التحقق من تنسيق العرض التقديمي**

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) لتفقد ملف دون إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) . طريقة [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) تُبلغ عن التنسيق المكتشف، مثل PPTX أو PPT أو ODP.

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

عند معالجة الكثير من ملفات العرض التقديمي، قد تحتاج إلى جرد مضغوط للتحقق، الفهرسة، أو نظام إدارة المستندات. في هذا السيناريو، استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) للحصول على كائن [IPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/) ، ثم نادِ [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) لقراءة بيانات تعريف المستند. لا ينشئ هذا النهج مثيلًا من [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) ولا يتطلب استعراض نموذج كائن العرض الكامل.

القيم الممتدة التي توفرها [IDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/) تشمل القيم التالية للجرد:

| الطريقة | قيمة الجرد |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | إجمالي عدد الشرائح. |
| [getHiddenSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | عدد الشرائح المخفية. |
| [getNotes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | عدد الشرائح التي تحتوي على ملاحظات. |
| [getParagraphs](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | إجمالي عدد الفقرات، إذا كانت متوفرة. |
| [getWords](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | إجمالي عدد الكلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | إجمالي عدد مقاطع الصوت والفيديو. |

المثال التالي يقرأ هذه القيم دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) ويطبع جردًا مضغوطًا. كما يجمع بين [getHeadingPairs](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) و[getTitlesOfParts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) لعرض مجموعات المحتوى مثل الخطوط، السمات، وعناوين الشرائح.

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

كل [IHeadingPair](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iheadingpair/) يوفر اسم المجموعة وعدد العناصر في تلك المجموعة. تسترجع [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) مصفوفة مسطحة مرتبة، لذا استهلك عدد العناوين المتتالية المحدد بواسطة كل زوج عنوان.

### **البيانات الوصفية المخزنة وقيود التنسيق**

القيم التي تُعيدها [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) تعكس بيانات التعريف المتاحة في المستند الأصلي. لا يقوم Aspose.Slides بتحميل واستعراض نموذج كائن العرض لإعادة حساب هذه القيم لهذا الاستدعاء. تُمثَّل الخصائص المفقودة بالقيم الافتراضية، وقد تكون القيم المخزنة قديمة إذا لم يحدث التطبيق الذي حفظ الملف آخرًا خصائص المستند.

- **PPTX:** يوفر التنسيق خصائص مستند موسعة لعدد الشرائح، الملاحظات، الشرائح المخفية، الفقرات، الكلمات، والوسائط المتعددة، بالإضافة إلى أزواج العناوين وعناوين الأجزاء. التوافر يعتمد على الخصائص التي كتبها مُنتج المستند.
- **PPT:** يمكن للنسق الثنائي تخزين خصائص ملخص المستند المقابلة. إذا كانت الخاصية غائبة أو لم يتم تحديثها من قبل مُنتج المستند، يعيد Aspose.Slides قيمتها المخزنة أو الافتراضية بدلاً من حسابها من الشرائح.
- **ODP:** توفر بيانات تعريف OpenDocument إحصاءات عامة للمستند مثل عدد الصفحات، الفقرات، والكلمات، لكن هذه القيم لا تتطابق مع كل خاصية موسعة خاصة بـ PowerPoint. قد تكون بيانات الشرائح المخفية، ملاحظات الشرائح، الوسائط المتعددة، أزواج العناوين، وعناوين الأجزاء غير متاحة، وقد تُعيد خصائص الجرد قيمًا افتراضية. لا تُعامل القيمة صفر أو المصفوفة الفارغة كدليل قاطع على أن المحتوى المقابل غير موجود.

استخدم نهج البيانات الوصفية الخفيفة للجردات والفحوصات الأولية. حمِّل العرض واستعرض نموذج كائنه الحي عندما يجب أن يعكس النتيجة تغييرات الذاكرة أو عندما تحتاج إلى التحقق من المحتوى الفعلي للعرض.

## **تحديث خصائص العرض التقديمي**

يمكن أيضًا تغيير الخصائص التي تُعيدها [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) دون إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). طبّق التغييرات باستخدام [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، ثم اكتب العرض المرتبط باستخدام [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

الصورة التالية تُظهر خصائص المستند الأصلية.

![خصائص المستند الأصلية للعرض التقديمي PowerPoint](input_properties.png)

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

الصورة التالية تُظهر خصائص المستند بعد التحديث.

![خصائص المستند بعد التغيير للعرض التقديمي PowerPoint](output_properties.png)

## **روابط مفيدة**

للفحوصات الأمنية ذات الصلة وإعدادات الحماية، انظر المقالات التالية:

- [Password-Protect Presentations](/slides/ar/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ar/androidjava/write-protected-presentation/)

## **الأسئلة الشائعة**

**How can I check whether fonts are embedded and which ones they are?**

قم بتحميل العرض واستخدم [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getFontsManager--). نادِ [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) للحصول على الخطوط المدمجة و[IFontsManager.getFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) للحصول على الخطوط المستخدمة في العرض. قارن النتيجتين لتحديد الخطوط المطلوبة للعرض والتي لم تُدمج.

**How can I quickly tell if the file has hidden slides and how many?**

عند كون بيانات تعريف المستند المخزنة كافية، اقرأ [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) عبر [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). هذا مناسب لجرد خفيف. إذا تم تعديل العرض في الذاكرة، قد تكون البيانات الوصفية المخزنة مفقودة أو قديمة، أو تحتاج إلى التحقق من القيم الحية؛ في هذه الحالة، استعرض [Presentation.getSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlides--) وفحص طريقة [ISlide.getHidden](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#getHidden--) لكل شريحة.

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

نعم. حمِّل العرض ونادِ [Presentation.getSlideSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlideSize--). استخدم [ISlideSize.getType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidesize/#getType--)، [ISlideSize.getSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidesize/#getSize--)، و[ISlideSize.getOrientation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidesize/#getOrientation--) لمقارنة الإعدادات الحالية مع القيم المسبقة والأبعاد المتوقعة.

**Is there a quick way to see if charts reference external data sources?**

نعم. حدِّد كل [Chart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/chart/) وانادِ [IChartData.getDataSourceType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--). إذا كان المصدر خارجيًا، نادِ [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). نوع مصدر البيانات والمسار يحددان وجود إشارة خارجية، لكن التحقق من توفر الهدف يتطلب فحص موارد منفصل.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

لا توجد خاصية تعقيد واحدة. استعرض [Presentation.getSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlides--) وكل مجموعة [IBaseSlide.getShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/#getShapes--) لكل شريحة. استخدم عدد الأشكال ووجود صور كبيرة أو تأثيرات أو رسوم متحركة أو وسائط متعددة كإشارات فحص، وقم بقياس عملية عرض أو تصدير تمثيلية قبل اعتبار الشريحة عنق زجاجة في الأداء.
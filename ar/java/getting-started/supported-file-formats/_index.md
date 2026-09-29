---
title: تنسيقات الملفات المدعومة
type: docs
weight: 106
url: /ar/java/supported-file-formats/
keywords:
- تنسيقات الملفات المدعومة
- تحميل العرض
- استيراد PDF
- استيراد HTML
- حفظ العرض
- عرض الشرائح
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- Java
- Aspose.Slides
description: "اعرف تنسيقات الملفات التي يمكن لـ Aspose.Slides for Java تحميلها أو استيرادها أو حفظها أو عرضها، وأي واجهة برمجة تطبيقات (API) تقرأ أو تكتب كل واحدة منها."
---
## **نظرة عامة**

Aspose.Slides for Java يفتح ويحفظ عروض PowerPoint وOpenDocument. كما يستورد محتوى PDF وHTML إلى الشرائح، يحفظ العروض بتنسيقات المستندات والويب والصور، ويعرض الشرائح والأشكال الفردية كصور. تُدرج هذه المقالة كل تنسيق مدعوم وتُحدد الـ API الذي يقرأه أو يكتبه.

للحصول على نظرة عامة على ميزات التحرير، راجع [نظرة عامة على الميزات](/slides/ar/java/features-overview/).

## **الإصدارات المدعومة من Microsoft PowerPoint**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}

العروض التقديمية التي تم حفظها بواسطة PowerPoint 95 والإصدارات السابقة لا يمكن فتحها. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) يتعرف على ملف PowerPoint 95 ويُبلغ عن `LoadFormat.Ppt95`، لكن مُنشئ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) يُطلق استثناء [PptUnsupportedFormatException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptunsupportedformatexception/) بخصوصه.

{{% /alert %}}

## **تنسيقات الملفات المدعومة**

الجدول يستخدم أربع عمليات:

- **Load**: مُنشئ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) يفتح الملف كعرض قابل للتحرير.
- **Import**: طريقة في [SlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidecollection/) تنشئ شرائح من محتوى الملف وتضيفها إلى عرض موجود. مُنشئ Presentation لا يحول هذه الملفات إلى شرائح.
- **Save**: [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) يكتب العرض إلى ملف أو تدفق. كل تنسيق ما عدا XAML يُحدَّد بقيمة من [SaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/).
- **Render**: طريقة عرض ترسم شريحة أو شكل كصورة. التنسيقات التي تُعرض فقط ليست قيمًا في SaveFormat.

|**الصيغة**|**الوصف**|**تحميل / استيراد**|**حفظ / عرض**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|عرض PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|قالب PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|عرض شريحة PowerPoint 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|عرض PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|قالب PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|عرض شريحة PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|عرض PowerPoint مع تمكين الماكرو|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|قالب PowerPoint مع تمكين الماكرو|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|عرض شريحة PowerPoint مع تمكين الماكرو|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|عرض OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|عرض Flat XML OpenDocument|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|قالب عرض OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|عرض PowerPoint XML|Load|Save|`SaveFormat.Xml`; الملفات المحملة تُبلغ عن `SourceFormat.Xml` (لا توجد قيمة `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|تنسيق المستندات المتنقلة|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|لغة ترميز النص الفائق|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|مواصفة ورق XML|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|تنسيق ملف الصورة الموسومة|—|Save, Render|`SaveFormat.Tiff` (صفحة واحدة لكل شريحة); `ImageFormat.Tiff` (شريحة واحدة)|
|[GIF](https://docs.fileformat.com/image/gif/)|تنسيق تبادل الرسوميات|—|Save, Render|`SaveFormat.Gif` (متحرك، كل الشرائح); `ImageFormat.Gif` (شريحة واحدة)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|لغة ترميز تطبيقات ممتدة|—|Save|`Presentation.save(IXamlOptions)`, ملف XAML واحد لكل شريحة؛ ليست قيمة `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|صورة JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|صورة Bitmap|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **التحميل والاستيراد**

- **Load:** مرّر مسار ملف أو تدفق إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). يتم اكتشاف التنسيق من المحتوى؛ [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/) تُوفر إعدادات مثل كلمة المرور. للتحقق من ملف قبل فتحه، استدعِ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)، الذي يُبلغ عن قيمة [LoadFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadformat/). يُبلغ عن `LoadFormat.Unknown` لملفات PowerPoint XML، لكن المُنشئ يفتح هذا الملف، ثم تُعيد [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSourceFormat--) القيمة `SourceFormat.Xml`. راجع [Open Presentations](/slides/ar/java/open-presentation/) و[Determine the Original Presentation Format](/slides/ar/java/detect-presentation-source-format/).
- **Import:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) يضيف شريحة واحدة لكل صفحة PDF إلى نهاية العرض. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) يضيف شرائح تم إنشاؤها من HTML، و[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) يُدرجها في موضع معين. مُنشئ Presentation لا يستورد: يُطلق استثناء [PptUnsupportedFormatException](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptunsupportedformatexception/) لملف PDF ولا يُحول ترميز HTML إلى محتوى شريحة. راجع [Import Presentations from PDF or HTML](/slides/ar/java/import-presentation/).

## **الحفظ والعرض**

- **Save:** [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) يكتب العرض بالتنسيق المحدد في قيمة [SaveFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/). التحميلات التي تأخذ كائن خيارات تتحكم في المخرجات، مثل [PdfOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/), و[GifOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/gifoptions/). التحميلات التي تأخذ مصفوفة من مواضع الشرائح (بدءًا من 1) تُكتب تلك الشرائح فقط؛ تدعم PDF، XPS، TIFF، HTML، HTML5، SWF، GIF، وMarkdown، لكن لا تدعم تنسيقات العروض أو PowerPoint XML. XAML له تحميل خاص، [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)، الذي يأخذ [IXamlOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ixamloptions/). راجع [Save Presentations](/slides/ar/java/save-presentation/), [Convert Presentations](/slides/ar/java/convert-presentation/), و[Export Presentations to XAML](/slides/ar/java/export-to-xaml/).
- **Render:** [Slide.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slide/#getImage-float-float-) و[Shape.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getImage--) تُعيدان [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/)، و[IImage.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/#save-java.lang.String-int-) يكتبها كـ PNG أو JPEG أو BMP أو GIF أو TIFF، يُحدد عبر قيمة [ImageFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) يُظهر جميع الشرائح أو المختارة دفعة واحدة. [Slide.writeAsSvg](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) و[Shape.writeAsSvg](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) يكتبان SVG، و[Slide.writeAsEmf](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) يكتب EMF. راجع [Convert Presentation Slides to Images](/slides/ar/java/convert-slide/) و[Render Presentation Slides as SVG Images](/slides/ar/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat يحتوي أيضًا على القيم `Emf`, `Wmf`, `Icon`, `Exif`, و`MemoryBmp`، لكن IImage.save لا ينتج هذه التنسيقات: الملف الذي يُكتب يحتوي على بيانات PNG. للحصول على صورة EMF لشريحة، استخدم Slide.writeAsEmf.

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل عرض PPT إلى PPTX أو ODP؟**

نعم. افتح ملف PPT باستخدام مُنشئ Presentation واحفظه بـ `SaveFormat.Pptx` أو `SaveFormat.Odp`. راجع [Convert PPT to PPTX](/slides/ar/java/convert-ppt-to-pptx/).

**هل يمكنني فتح ملف PDF أو HTML كعرض تقديمي؟**

لا. مُنشئ Presentation يُطلق استثناء PptUnsupportedFormatException لملف PDF ولا يحول ترميز HTML إلى شرائح. أنشئ أو افتح عرضًا، استورد صفحات PDF أو محتوى HTML إليه باستخدام طرق مجموعة الشرائح المذكورة أعلاه، ثم احفظه بأي تنسيق مدعوم.

**هل يمكنني تحميل صورة PNG أو SVG تم تصديرها كعرض تقديمي قابل للتحرير؟**

لا. إخراج الصورة يُسجل مظهر الشريحة فقط، وليس النص أو الأشكال أو المخططات. احتفظ بالعرض الأصلي إذا كنت تحتاج إلى تحريره لاحقًا.

**هل يمكنني حفظ مستندات PDF/A أو PDF/UA؟**

نعم. مرّر قيمة من [PdfCompliance](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfcompliance/) إلى [PdfOptions.setCompliance](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, أو PDF/UA.

**هل يمكنني التحقق ما إذا كان الملف محميًا بكلمة مرور قبل فتحه؟**

نعم. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) يفحص الملف دون إنشاء كائن Presentation، و[IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) يُبلغ عما إذا كانت كلمة مرور مطلوبة. راجع [Password-Protect Presentations](/slides/ar/java/password-protected-presentation/).
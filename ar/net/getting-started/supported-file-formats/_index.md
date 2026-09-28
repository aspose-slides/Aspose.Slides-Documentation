---
title: الصيغ الملفية المدعومة
type: docs
weight: 96
url: /ar/net/supported-file-formats/
keywords:
- الصيغ الملفية المدعومة
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
- .NET
- C#
- Aspose.Slides
description: "اعرف صيغ الملفات التي يستطيع Aspose.Slides for .NET تحميلها واستيرادها وحفظها وعرضها، وأي API يقرأ أو يكتب كل منها."
---
## **نظرة عامة**

Aspose.Slides for .NET يفتح ويحفظ عروض PowerPoint وOpenDocument. كما يستورد محتوى PDF وHTML إلى الشرائح، ويحفظ العروض إلى صيغ المستندات والويب والصور، ويعرض الشرائح والأشكال الفردية كصور. تُدرج هذه المقالة كل صيغة مدعومة وتُسمّي API التي تقرأها أو تكتبها.

كلتا حزمتَي NuGet، Aspose.Slides.NET وAspose.Slides.NET6.CrossPlatform، تدعمان نفس الصيغ؛ راجع [التثبيت](/slides/ar/net/installation/) للاختيار بينهما. للحصول على نظرة عامة على ميزات التحرير، راجع [نظرة عامة على الميزات](/slides/ar/net/features-overview/).

## **إصدارات Microsoft PowerPoint المدعومة**

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

{{% alert color="info" title="ملاحظة" %}}

العروض التي تم حفظها بواسطة PowerPoint 95 والإصدارات الأقدم لا يمكن فتحها. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) يتعرف على ملف PowerPoint 95 ويُعيد `LoadFormat.Ppt95`، لكن مُنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/presentation/) يُطلق استثناء [PptUnsupportedFormatException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptunsupportedformatexception/) لهذا النوع.

{{% /alert %}}

## **الصيغ الملفّية المدعومة**

الجدول يستخدم أربع عمليات:

- **Load**: مُنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/presentation/) يفتح الملف كعرض قابل للتحرير.
- **Import**: طريقة في [SlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/slidecollection/) تنشئ شرائح من محتوى الملف وتضيفها إلى عرض موجود. مُنشئ Presentation لا يحمل هذه الملفات كعروض.
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) يكتب العرض إلى ملف أو تدفق. كل صيغة ما عدا XAML يتم اختيارها بقيمة من [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/).
- **Render**: طريقة العرض ترسم شريحة أو شكل كصورة. الصيغ التي تُعرض فقط ليست قيمًا في SaveFormat.

|**التنسيق**|**الوصف**|**تحميل / استيراد**|**حفظ / عرض**|**API**|
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
|FODP|عرض OpenDocument XML مسطح|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|قالب OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|عرض PowerPoint XML|Load|Save|`SaveFormat.Xml`; الملفات المحملة تُعيد `SourceFormat.Xml` (لا توجد قيمة `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|تنسيق المستندات المحمولة|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|لغة توصيف النص الفائق|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|مواصفات ورق XML|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|تنسيق ملف الصورة الموسومة|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (شريحة واحدة)|
|[GIF](https://docs.fileformat.com/image/gif/)|تنسيق تبادل الرسوميات|—|Save, Render|`SaveFormat.Gif` (متحرك، كل الشرائح); `ImageFormat.Gif` (شريحة واحدة)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|تنسيق الويب الصغير (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|لغة توصيف تطبيقات موسعة|—|Save|`Presentation.Save(IXamlOptions)`, ملف XAML واحد لكل شريحة؛ ليست قيمة `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|صورة JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|صورة BMP|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **التحميل والاستيراد**

- **Load:** مرّر مسار ملف أو تدفق إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/presentation/). يتم اكتشاف الصيغة من المحتوى؛ [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/) تُزوّد إعدادات مثل كلمة المرور. للتحقق من ملف قبل فتحه، استدعِ [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/)، التي تُعيد قيمة [LoadFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/loadformat/). تُعيد `LoadFormat.Unknown` لـ PowerPoint XML، لكن المُنشئ يفتح مثل هذا الملف، ثم تُعيد [Presentation.SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sourceformat/) `SourceFormat.Xml`. راجع [فتح العروض](/slides/ar/net/open-presentation/) و[تحديد صيغة العرض الأصلي](/slides/ar/net/detect-presentation-source-format/).
- **Import:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/ar/net/aspose.slides/slidecollection/addfrompdf/) يضيف شريحة واحدة لكل صفحة PDF إلى نهاية العرض. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/ar/net/aspose.slides/slidecollection/addfromhtml/) يضيف شرائح من HTML، و[SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/ar/net/aspose.slides/slidecollection/insertfromhtml/) يُدرجها في موضع معين. مُنشئ Presentation لا يستورد: يُطلق استثناء [PptUnsupportedFormatException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptunsupportedformatexception/) لملف PDF ولا يحوّل ترميز HTML إلى محتوى شريحة. راجع [استيراد العروض من PDF أو HTML](/slides/ar/net/import-presentation/).

## **الحفظ والعرض**

- **Save:** [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) يكتب العرض بصيغة قيمة [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/). التحميلات التي تقبل كائن خيارات تتحكم في المخرجات، مثل [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/), و[GifOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/gifoptions/). التحميلات التي تقبل مصفوفة من مواضع الشرائح (بدءًا من 1) تكتب تلك الشرائح فقط؛ وتدعم PDF, XPS, TIFF, HTML, HTML5, SWF, GIF, وMarkdown، لكن لا تدعم صيغ العروض أو PowerPoint XML. XAML له تحميل خاص يقبل [IXamlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/ixamloptions/). راجع [حفظ العروض](/slides/ar/net/save-presentation/), [تحويل العروض](/slides/ar/net/convert-presentation/), و[تصدير العروض إلى XAML](/slides/ar/net/export-to-xaml/).
- **Render:** [Slide.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/getimage/) و[Shape.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/getimage/) تُعيد [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/)، و[IImage.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/save/) يكتبها كـ PNG أو JPEG أو BMP أو GIF أو TIFF، مُحددةً بقيمة من [ImageFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/imageformat/). [Presentation.GetImages](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/getimages/) يعرض جميع الشرائح أو الشرائح المختارة مرةً واحدة. [Slide.WriteAsSvg](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/writeassvg/) و[Shape.WriteAsSvg](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/writeassvg/) يكتبان SVG، و[Slide.WriteAsEmf](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/writeasemf/) يكتب EMF. راجع [تحويل شرائح العرض إلى صور](/slides/ar/net/convert-slide/) و[عرض شريحة كصورة SVG](/slides/ar/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="تحذير" %}}

ImageFormat يحتوي أيضًا على القيم `Emf`, `Wmf`, `Icon`, `Exif`, و`MemoryBmp`، لكن IImage.Save لا ينتج تلك الصيغ: الملف المكتوب يحتوي على بيانات PNG. للحصول على صورة EMF لشريحة، استخدم Slide.WriteAsEmf.

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل عرض PPT إلى PPTX أو ODP؟**

نعم. افتح ملف PPT باستخدام مُنشئ Presentation واحفظه باستخدام `SaveFormat.Pptx` أو `SaveFormat.Odp`. راجع [تحويل PPT إلى PPTX](/slides/ar/net/convert-ppt-to-pptx/).

**هل يمكنني فتح ملف PDF أو HTML كعرض؟**

لا. أنشئ أو افتح عرضًا، استورد صفحات PDF أو محتوى HTML إليه باستخدام طرق مجموعة الشرائح المذكورة أعلاه، ثم احفظه بأي صيغة مدعومة.

**هل يمكنني تحميل صورة PNG أو SVG مُصدَّرة كعرض قابل للتحرير؟**

لا. ناتج الصورة يُسجِّل مظهر الشريحة فقط، وليس نصها أو أشكالها أو مخططاتها. احتفظ بالعرض الأصلي إذا كنت بحاجة لتعديله لاحقًا.

**هل يمكنني حفظ مستندات PDF/A أو PDF/UA؟**

نعم. عيّن [PdfOptions.Compliance](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/compliance/) إلى قيمة من [PdfCompliance](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfcompliance/): PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, أو PDF/UA.

**هل يمكنني التحقق مما إذا كان الملف محميًا بكلمة مرور قبل فتحه؟**

نعم. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/getpresentationinfo/) تفحص الملف دون إنشاء كائن Presentation، وتُعيد خصيصية [IsPasswordProtected](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/ispasswordprotected/) ما إذا كانت كلمة مرور مطلوبة. راجع [حماية العروض بكلمة مرور](/slides/ar/net/password-protected-presentation/).

**هل تدعم الحزمتان في NuGet صيغًا مختلفة؟**

لا. Aspose.Slides.NET وAspose.Slides.NET6.CrossPlatform لديهما نفس قيم LoadFormat وSaveFormat ونفس طرق الاستيراد والعرض. الاختلاف يكمن في المنصات التي يعملان عليها وما تحتاجه تلك المنصات؛ راجع [التثبيت](/slides/ar/net/installation/).
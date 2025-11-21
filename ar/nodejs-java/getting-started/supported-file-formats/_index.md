---
title: تنسيقات الملفات المدعومة
type: docs
weight: 30
url: /ar/nodejs-java/supported-file-formats/
---

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
- Microsoft PowerPoint for MAC
- Office 365

## **تنسيقات الملفات المدعومة**
This table contains the file formats that Aspose.Slides for Node.js via Java can load and save:

|**التنسيق**|**الوصف**|**التحميل**|**الحفظ**|**ملاحظات**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|عرض PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|قالب PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|عرض PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|عرض PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|قالب PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|عرض PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|عرض PowerPoint مع تمكين الماكرو|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|عرض PowerPoint مع تمكين الماكرو|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|قالب PowerPoint مع تمكين الماكرو|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|عرض OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|قالب عرض OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|تنسيق ملف صورة العلامة (Tag Image File Format)| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|تنسيق الميتافيل المحسن| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|تنسيق المستند المحمول|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|مواصفات ورق XML| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|مجموعة خبراء الصور المشتركة| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|رسومات الشبكة القابلة للنقل| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|تنسيق تبادل الرسومات| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|صورة نقطية مستقلة عن الجهاز| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|رسومات متجهية قابلة للتوسع| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|تنسيق الويب الصغير| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|لغة توصيف النص الفائق|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|لغة توصيف التطبيق القابلة للتوسيع| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|ماركداون| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|عرض PowerPoint XML| |{{< emoticons/tick >}}| |

## **الأسئلة الشائعة**

**هل يمكنني حفظ العروض التقديمية إلى PDF التي تفي بمعايير الأرشفة وإمكانية الوصول (PDF/A و PDF/UA)؟**

نعم. يدعم Aspose.Slides التصدير إلى PDF مع مستويات الالتزام مثل PDF/A-2a، PDF/A-2b، PDF/A-2u، PDF/A-3a، PDF/A-3b، بالإضافة إلى PDF/UA من خلال إعداد [compliance](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setcompliance/) في [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**هل تدعم المكتبة تضمين الخطوط عند التصدير إلى PDF، مع تحكم دقيق في ما يتم تضمينه؟**

نعم. يمكنك التحكم فيما إذا كانت الخطوط مضمَّنة بالكامل أو كجزء فرعي (glyphs المستخدمة فقط)، وتحديد كيفية معاملة الخطوط النظامية الشائعة، وتكوين سلوك النص ASCII من خلال [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**هل يمكنني اكتشاف ما إذا كان الملف محميًا بكلمة مرور قبل تحميله فعليًا؟**

نعم. باستخدام [factory-based inspection API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/)، يمكنك الاستعلام عن ملف العرض لتحديد ما إذا كان محميًا بكلمة مرور دون فتحه بالكامل.

**هل توجد آليات احتياطي للخطوط ودعم للخطوط المخصصة؟**

نعم. تدعم المكتبة [loading](/slides/ar/nodejs-java/custom-font/) و[embedding](/slides/ar/nodejs-java/embedded-font/) للخطوط المخصصة وتوفر قواعد [fallback](/slides/ar/nodejs-java/fallback-font/) للخطوط لتفادي فقدان الرموز أثناء العرض والتحويل.

**هل يمكنني تصدير الشرائح إلى XPS، وهل هناك خيارات لضبط مخرجات XPS؟**

نعم. يتم دعم [Export to XPS](/slides/ar/nodejs-java/convert-powerpoint-to-xps/) ويمكنك تعديل [save options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) ذات الصلة للتحكم في جودة المخرجات ومحتوى مستند XPS.
---
title: تحويل العروض التقديمية إلى صيغ متعددة في .NET
linktitle: تحويل العرض التقديمي
type: docs
weight: 70
url: /ar/net/convert-presentation/
keywords:
- تحويل عرض تقديمي
- تصدير عرض تقديمي
- PPT إلى PPTX
- PPTX إلى PPT
- ODP إلى PPTX
- PPT إلى PDF
- PPTX إلى PDF
- ODP إلى PDF
- PPT إلى HTML
- PPTX إلى HTML
- ODP إلى HTML
- PPT إلى PNG
- PPTX إلى PNG
- ODP إلى PNG
- PPTX إلى JPG
- ODP إلى JPG
- PPT إلى XPS
- PPTX إلى XPS
- ODP إلى XPS
- PPT إلى TIFF
- PPTX إلى TIFF
- ODP إلى TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint وOpenDocument إلى PPTX وPDF وHTML وصور وXPS وTIFF وغيرها باستخدام Aspose.Slides for .NET."
---
## **نظرة عامة**

Aspose.Slides for .NET يمكنه تحميل عروض PowerPoint وOpenDocument وحفظها أو تصييرها إلى صيغ متعددة أخرى دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، تصدير العروض إلى مستندات ثابتة مثل PDF وXPS، نشر الشرائح كـ HTML، أو تصيير الشرائح كملفات صورة للمعاينات، المصغرات، والأرشفة.

معظم عمليات تحويل المستندات تتبع نفس سير العمل العام: تحميل الملف المصدر، اختيار الصيغة المطلوبة، وتطبيق الخيارات الخاصة بالصيغ عندما يلزم. بالنسبة لصيغ الصور، يتم تصيير كل شريحة على حدة ثم حفظها كصورة نقطية أو متجهة. المقالات المخصصة المرتبطة أدناه توضح تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه للحصول على أمثلة C# كاملة وخيارات خاصة بالصيغ.

| السيناريو | استخدمه عندما تحتاج إلى | المقالة |
| --- | --- | --- |
| PPT/PPTX/ODP إلى PPTX | تحديث ملفات PPT القديمة، توحيد ملفات PPTX الحالية، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/net/convert-ppt-to-pptx/),[تحويل ODP إلى PPTX](/slides/ar/net/convert-odp-to-pptx/),[حفظ العروض](/slides/ar/net/save-presentation/) |
| PPTX إلى PPT | حفظ عرض PowerPoint حديث بصيغة PPT الثنائية القديمة للتوافق مع سير عمل قديم. | [تحويل PPTX إلى PPT](/slides/ar/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP إلى PDF | إنشاء مستندات ثابتة، قابلة للبحث، ومحمولة للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP إلى PDF مع الملاحظات | تصدير ملاحظات المتحدث مع محتوى الشرائح. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP إلى HTML | نشر العروض كصفحات HTML والتحكم في الصور، الخطوط، الملاحظات، وخيارات التخطيط المتجاوب. | [تحويل PowerPoint إلى HTML](/slides/ar/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP إلى HTML5 | تصدير الشرائح إلى HTML5 للعرض في المتصفحات مع الحفاظ على التنسيق والتفاعلية. | [تحويل العروض إلى HTML5](/slides/ar/net/export-to-html5/) |
| PPT/PPTX/ODP إلى PNG | تصيير كل شريحة إلى صورة PNG للمعاينات، المصغرات، أو إخراج الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP إلى JPG | تصيير الشرائح إلى صور JPG والتحكم في أبعاد الصورة وجودتها. | [تحويل PowerPoint إلى JPG](/slides/ar/net/convert-powerpoint-to-jpg/) |
| شريحة إلى SVG | تصدير شرائح فردية كرسومات SVG قابلة للتوسع. | [تصيير شريحة كـ SVG](/slides/ar/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP إلى XPS | إنشاء مستندات XPS ثابتة. | [تحويل PowerPoint إلى XPS](/slides/ar/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP إلى TIFF | حفظ عرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو الأرشفة. | [تحويل PowerPoint إلى TIFF](/slides/ar/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP إلى TIFF مع الملاحظات | حفظ الشرائح مع ملاحظات المتحدث إلى TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX إلى Word | تحويل الشرائح إلى مستند Word عندما تحتاج إلى مخرجات بنمط مستند. | [تحويل PowerPoint إلى Word](/slides/ar/net/convert-powerpoint-to-word/) |
| PPT/PPTX إلى Markdown | استخراج محتوى العرض إلى Markdown للتوثيق وسير العمل النصي. | [تحويل PowerPoint إلى Markdown](/slides/ar/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX إلى GIF متحرك | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى GIF متحرك](/slides/ar/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX إلى فيديو | بناء سير عمل لتصدير العرض كفيديو. | [تحويل PowerPoint إلى فيديو](/slides/ar/net/convert-powerpoint-to-video/) |
| العرض إلى XAML | تصدير الشرائح إلى XAML لسيناريوهات واجهة .NET. | [تصدير العروض إلى XAML](/slides/ar/net/export-to-xaml/) |

لقائمة أوسع من صيغ الإدخال والإخراج، راجع [الصيغ المدعومة](/slides/ar/net/supported-file-formats/).

## **تحويل PowerPoint وOpenDocument**

Aspose.Slides for .NET يدعم التحويل من صيغ العروض الشائعة مثل PPT وPPTX وPPS وPPSX وPOT وPOTX وODP. تُستخدم نفس واجهة برمجة التطبيقات للتحويل بين ملفات PowerPoint وOpenDocument، لذا يمكن عادةً تطبيق سير عمل يحفظ ملف PPTX إلى PDF على ملف ODP بتغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، تذكر أن تطبيقات PowerPoint وOpenDocument لا تدعم كل تخطيط وميزة تنسيق بنفس الطريقة تمامًا. إذا تم إنشاء ملف ODP في LibreOffice أو OpenOffice Impress، راجع النتيجة واستخدم الخيارات الموضحة في [تحويل عروض OpenDocument](/slides/ar/net/convert-openoffice-odp/) عندما تحتاج إلى إرشادات خاصة بالصيغ.

## **تحويل PPT إلى PPTX**

PPT هو صيغة PowerPoint الثنائية القديمة، بينما PPTX هو صيغة Office Open XML الحديثة. Aspose.Slides for .NET يدعم تحويل PPT إلى PPTX بدقة عالية مع الحفاظ على هياكل العرض المعقدة مثل القوالب، التخطيطات، الشرائح، المخططات، الأشكال المجمعة، عناصر العنصر النائب، إطارات النص، القوام، وتعبئات الصور.

للتفاصيل، راجع [تحويل PPT إلى PPTX](/slides/ar/net/convert-ppt-to-pptx/) و[الفرق بين PPT وPPTX](/slides/ar/net/ppt-vs-pptx/).

## **تصدير ثابت التخطيط**

PDF وXPS وTIFF مفيدة عندما يجب أن يكون المخرج متطابقًا عبر الأجهزة ولا يُراد تحريره كعرض تقديمي. استخدم [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/)، [XpsOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/xpsoptions/)، و[TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/) للتحكم في التوافق، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، تنسيق البكسل، وحجم المخرج.

## **تصدير HTML والصور**

تصدير HTML وHTML5 مفيد للعرض في المتصفح، النشر على الويب، والمشاركة الخفيفة. تصدير الصور مفيد عندما يجب أن تتحول كل شريحة إلى معاينة، صورة مصغرة، أو أصل نقطي منفصل. استخدم مقالات PNG وJPG وSVG للحصول على إرشادات تصيير خاصة بالصيغ.

## **الأسئلة المتكررة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض؟**

لا. Aspose.Slides for .NET مكتبة مستقلة ولا تتطلب Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل مجموعة من العروض دفعيًا؟**

نعم. حمِّل كل عرض، احفظه بالصيغ المطلوبة، وتخلص من كائن `Presentation` بعد المعالجة. للمعالجة المتوازية، استخدم مثيلات عرض منفصلة واتبع إرشادات [المعالجة المتعددة الخيوط](/slides/ar/net/multithreading/).

**هل يمكنني تصدير شرائح مختارة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير فهارس الشرائح أو تصيير شرائح فردية، حسب صيغة المخرج. راجع المقالة المخصصة للصيغة المستهدفة.

**هل يمكنني تضمين الشرائح المخفية عند تصدير إلى PDF أو XPS؟**

نعم. استخدم خاصية `ShowHiddenSlides` في [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) أو [XpsOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/xpsoptions/).

**هل يمكنني إنشاء مخرجات PDF/A؟**

نعم. تتوفر إعدادات توافق PDF من خلال [PdfOptions.Compliance](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/compliance/) و[PdfCompliance](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfcompliance/).

**كيف يتم التعامل مع الخطوط أثناء التحويل؟**

Aspose.Slides يمكنه استخدام الخطوط المضمنة، والبدائل، وإعدادات استبدال الخطوط. راجع [الخط المضمن](/slides/ar/net/embedded-font/)، [خط البديل](/slides/ar/net/fallback-font/)، و[استبدال الخط](/slides/ar/net/font-substitution/).
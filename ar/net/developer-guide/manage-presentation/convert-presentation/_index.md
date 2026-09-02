---
title: تحويل العروض إلى صيغ متعددة في .NET
linktitle: تحويل العرض
type: docs
weight: 70
url: /ar/net/convert-presentation/
keywords:
- تحويل العرض
- تصدير العرض
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
- باوربوينت
- مستند مفتوح
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint وOpenDocument إلى PPTX وPDF وHTML وصور وXPS وTIFF والمزيد باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for .NET تحميل عروض PowerPoint وOpenDocument وحفظها أو عرضها بعدة صيغ أخرى دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، تصدير العروض إلى مستندات ذات تخطيط ثابت مثل PDF وXPS، نشر الشرائح كـ HTML، أو عرض الشرائح كملفات صورة للمعاينات، المصغرات، والأرشفة.

معظم تحويلات المستندات تستخدم نفس سير العمل العام: تحميل ملف المصدر، اختيار صيغة الإخراج المطلوبة، وتطبيق الخيارات الخاصة بالصيغ عند الحاجة. بالنسبة لصيغ الصور، يتم عرض كل شريحة بشكل منفصل ثم حفظها كصورة نقطية أو متجهة. المقالات المخصصة المرفقة أدناه توفر تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه للحصول على أمثلة كاملة بلغة C# وخيارات خاصة بالصيغ.

| السيناريو | يستخدم عندما تحتاج إلى | المقالة |
| --- | --- | --- |
| PPT/PPTX/ODP إلى PPTX | تحديث ملفات PPT القديمة، توحيد ملفات PPTX الحالية، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/net/convert-ppt-to-pptx/), [تحويل ODP إلى PPTX](/slides/ar/net/convert-odp-to-pptx/), [حفظ العروض](/slides/ar/net/save-presentation/) |
| PPTX إلى PPT | احفظ عرض PowerPoint الحديث إلى صيغة PPT الثنائية القديمة للتوافق مع سير عمل أقدم. | [تحويل PPTX إلى PPT](/slides/ar/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP إلى PDF | إنشاء مستندات محمولة وقابلة للبحث وتخطيط ثابت للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP إلى PDF مع الملاحظات | تصدير ملاحظات المتحدث مع محتوى الشريحة. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP إلى HTML | نشر العروض كصفحات HTML والتحكم في الصور والخطوط والملاحظات وخيارات التخطيط المستجيب. | [تحويل PowerPoint إلى HTML](/slides/ar/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP إلى HTML5 | تصدير الشرائح إلى HTML5 للعرض عبر المتصفح مع الحفاظ على التنسيق والتفاعلية. | [تحويل العروض إلى HTML5](/slides/ar/net/export-to-html5/) |
| PPT/PPTX/ODP إلى PNG | عرض كل شريحة كصورة PNG للمعاينات أو المصغرات أو مخرجات الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP إلى JPG | عرض الشرائح كصور JPG والتحكم في أبعاد وجودة الصورة. | [تحويل PowerPoint إلى JPG](/slides/ar/net/convert-powerpoint-to-jpg/) |
| شريحة إلى SVG | تصدير شرائح فردية كرسومات متجهة قابلة للتكبير. | [عرض الشريحة كـ SVG](/slides/ar/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP إلى XPS | إنشاء مستندات XPS بتخطيط ثابت. | [تحويل PowerPoint إلى XPS](/slides/ar/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP إلى TIFF | حفظ عرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو سير عمل الأرشفة. | [تحويل PowerPoint إلى TIFF](/slides/ar/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP إلى TIFF مع الملاحظات | حفظ الشرائح مع ملاحظات المتحدث إلى TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX إلى Word | تحويل الشرائح إلى مستند Word عندما تحتاج إلى مخرجات على شكل مستند. | [تحويل PowerPoint إلى Word](/slides/ar/net/convert-powerpoint-to-word/) |
| PPT/PPTX إلى Markdown | استخراج محتوى العرض إلى Markdown للتوثيق وسير العمل النصي. | [تحويل PowerPoint إلى Markdown](/slides/ar/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP إلى XML | إنشاء PowerPoint XML Presentation كنص قابل للقراءة للفحص أو المقارنة أو استكشاف الأخطاء أو سير عمل قائم على XML. | [تحويل PowerPoint إلى XML](/slides/ar/net/convert-powerpoint-to-xml/) |
| PPT/PPTX إلى GIF متحرك | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى GIF متحرك](/slides/ar/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX إلى فيديو | إنشاء سير عمل لتصدير الفيديو من شرائح العرض. | [تحويل PowerPoint إلى فيديو](/slides/ar/net/convert-powerpoint-to-video/) |
| العرض إلى XAML | تصدير الشرائح إلى XAML لسيناريوهات واجهة .NET. | [تصدير العروض إلى XAML](/slides/ar/net/export-to-xaml/) |

لقائمة أوسع من صيغ الإدخال والإخراج، راجع [الصيغ المدعومة للملفات](/slides/ar/net/supported-file-formats/).

## **تحويل PowerPoint وOpenDocument**

يدعم Aspose.Slides for .NET التحويل من صيغ العروض الشائعة مثل PPT وPPTX وPPS وPPSX وPOT وPOTX وODP. تُستخدم نفس واجهة برمجة التحويل لكل من ملفات PowerPoint وOpenDocument، لذا يمكن عادةً تطبيق سير عمل يحفظ ملف PPTX إلى PDF على ملف ODP بتغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، تذكر أن تطبيقات PowerPoint وOpenDocument لا تدعم كل ميزات التخطيط والتنسيق بنفس الطريقة تمامًا. إذا تم إنشاء ملف ODP باستخدام LibreOffice أو OpenOffice Impress، راجع الناتج واستخدم الخيارات الموضحة في [تحويل عروض OpenDocument](/slides/ar/net/convert-openoffice-odp/) عندما تحتاج إلى إرشادات خاصة بالصيغ.

## **تحويل PPT إلى PPTX**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Office Open XML الحديث. يدعم Aspose.Slides for .NET تحويل عالي الدقة من PPT إلى PPTX مع الحفاظ على هياكل العرض المعقدة مثل القوالب الأساسية، التخطيطات، الشرائح، المخططات، الأشكال المجمعّة، العناصر النائبة، إطارات النص، القوام، وتعبئة الصور.

للتفاصيل، راجع [تحويل PPT إلى PPTX](/slides/ar/net/convert-ppt-to-pptx/) و[الفرق بين PPT و PPTX](/slides/ar/net/ppt-vs-pptx/).

## **تصدير بتخطيط ثابت**

PDF وXPS وTIFF مفيدة عندما يجب أن يبدو الناتج واحدًا عبر جميع الأجهزة ويجب ألا يُعدل كعرض تقديمي. استخدم [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/)، [XpsOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/xpsoptions/)، و[TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/) للتحكم في الامتثال، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، تنسيق البكسل، وحجم الناتج.

## **تصدير HTML والصور**

تصدير HTML وHTML5 مفيد للعرض في المتصفح، النشر على الويب، والمشاركة الخفيفة. تصدير الصور مفيد عندما يجب أن تصبح كل شريحة معاينة منفصلة أو مصغرة أو عنصر نقطي. استخدم مقالات PNG وJPG وSVG للحصول على إرشادات عرض خاصة بالصيغ.

## **الأسئلة المتكررة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض؟**

لا. Aspose.Slides for .NET هي مكتبة مستقلة ولا تحتاج إلى Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل العديد من العروض دفعة واحدة؟**

نعم. قم بتحميل كل عرض، احفظه بالصغة المطلوبة، وتخلص من كائن `Presentation` بعد المعالجة. للمعالجة المتوازية، استخدم نسخًا منفصلة من العروض واتبع إرشادات [multithreading](/slides/ar/net/multithreading/).

**هل يمكنني تصدير شرائح مختارة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير مؤشرات الشرائح أو عرض الشرائح الفردية، حسب صيغة الإخراج. راجع المقالة المخصصة للصيغة المستهدفة.

**هل يمكنني تضمين الشرائح المخفية عند التصدير إلى PDF أو XPS؟**

نعم. استخدم الخاصية `ShowHiddenSlides` في [PdfOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/) أو [XpsOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/xpsoptions/).

**هل يمكنني إنشاء ناتج PDF/A؟**

نعم. تتوفر إعدادات الامتثال لـ PDF من خلال [PdfOptions.Compliance](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/compliance/) و[PdfCompliance](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfcompliance/).

**كيف يتم التعامل مع الخطوط أثناء التحويل؟**

يمكن لـ Aspose.Slides استخدام الخطوط المدمجة، والبديل الافتراضي للخط، وإعدادات استبدال الخط. راجع [خط مدمج](/slides/ar/net/embedded-font/)، [خط بديل](/slides/ar/net/fallback-font/)، و[استبدال الخط](/slides/ar/net/font-substitution/).
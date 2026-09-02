---
title: تحويل العروض إلى صيغ متعددة في JavaScript
linktitle: تحويل العرض
type: docs
weight: 70
url: /ar/nodejs-java/convert-presentation/
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
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل عروض PowerPoint وOpenDocument إلى PPTX وPDF وHTML والصور وXPS وTIFF وأكثر باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Node.js عبر Java تحميل عروض PowerPoint وOpenDocument وحفظها أو تصييرها إلى العديد من الصيغ الأخرى دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، تصدير العروض إلى مستندات ذات تخطيط ثابت مثل PDF وXPS، نشر الشرائح كـ HTML، أو تصيير الشرائح كملفات صور للمعاينات، المصغرات، والأرشفة.

تستخدم معظم عمليات تحويل المستندات نفس سير العمل العام: تحميل ملف المصدر، اختيار الصيغة المطلوبة للإخراج، وتطبيق الخيارات الخاصة بالصيغ عند الحاجة. بالنسبة لصيغ الصور، يتم تصيير كل شريحة بشكل منفصل ثم حفظها كصورة نقطية أو متجهة. المقالات المخصصة المرتبطة أدناه توضح تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه للحصول على أمثلة JavaScript كاملة وخيارات خاصة بكل صيغة.

| السيناريو | استخدمه عندما تحتاج إلى | المقالة |
| --- | --- | --- |
| PPT/PPTX/ODP إلى PPTX | تحديث ملفات PPT القديمة، توحيد ملفات PPTX الموجودة، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/nodejs-java/convert-ppt-to-pptx/), [تحويل ODP إلى PPTX](/slides/ar/nodejs-java/convert-odp-to-pptx/), [حفظ العروض التقديمية](/slides/ar/nodejs-java/save-presentation/) |
| PPTX إلى PPT | حفظ عرض PowerPoint الحديث إلى الصيغة الثنائية القديمة PPT للتوافق مع سير عمل أقدم. | [تحويل PPTX إلى PPT](/slides/ar/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP إلى PDF | إنشاء مستندات محمولة، قابلة للبحث، ذات تخطيط ثابت للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP إلى PDF مع الملاحظات | تصدير ملاحظات المتحدث مع محتوى الشريحة. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP إلى HTML | نشر العروض كصفحات HTML والتحكم في الصور، الخطوط، الملاحظات، وخيارات التصميم المتجاوب. | [تحويل PowerPoint إلى HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP إلى HTML5 | تصدير الشرائح إلى HTML5 للعرض في المتصفح مع الحفاظ على التنسيق والتفاعلية. | [تحويل العروض إلى HTML5](/slides/ar/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP إلى PNG | تصيير كل شريحة إلى صورة PNG للمعاينات، المصغرات، أو مخرجات الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP إلى JPG | تصيير الشرائح إلى صور JPG والتحكم في أبعاد الصورة وجودتها. | [تحويل PowerPoint إلى JPG](/slides/ar/nodejs-java/convert-powerpoint-to-jpg/) |
| شريحة إلى SVG | تصدير شرائح فردية كرسوميات متجهة قابلة للتوسع. | [تصيير شريحة كـ SVG](/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP إلى XPS | إنشاء مستندات XPS ذات تخطيط ثابت. | [تحويل PowerPoint إلى XPS](/slides/ar/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP إلى TIFF | حفظ العرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو الأرشفة. | [تحويل PowerPoint إلى TIFF](/slides/ar/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP إلى TIFF مع الملاحظات | حفظ الشرائح مع ملاحظات المتحدث إلى TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX إلى Markdown | استخراج محتوى العرض إلى Markdown للتوثيق وسير عمل النصوص. | [تحويل PowerPoint إلى Markdown](/slides/ar/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP إلى XML | إنشاء عرض PowerPoint بصيغة XML نصية للفحص أو المقارنة أو استكشاف الأخطاء أو سير عمل مبني على XML. | [تحويل PowerPoint إلى XML](/slides/ar/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX إلى GIF متحرك | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى GIF متحرك](/slides/ar/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX إلى فيديو | بناء سير عمل تصدير الفيديو من شرائح العرض. | [تحويل PowerPoint إلى فيديو](/slides/ar/nodejs-java/convert-powerpoint-to-video/) |
| العرض إلى XAML | تصدير الشرائح إلى XAML لسيناريوهات واجهة المستخدم JavaScript أو Java. | [تصدير العروض إلى XAML](/slides/ar/nodejs-java/export-to-xaml/) |

لقائمة أوسع من صيغ الإدخال والإخراج، راجع [الصيغ المدعومة](/slides/ar/nodejs-java/supported-file-formats/).

## **تحويل PowerPoint وOpenDocument**

يدعم Aspose.Slides for Node.js عبر Java التحويل من صيغ العروض الشائعة مثل PPT وPPTX وPPS وPPSX وPOT وPOTX وODP. يتم استخدام نفس واجهة برمجة التطبيقات للتحويل بين ملفات PowerPoint وOpenDocument، لذا يمكن عادةً تطبيق سير عمل حفظ ملف PPTX إلى PDF على ملف ODP بتغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، تذكر أن تطبيقات PowerPoint وOpenDocument لا تدعم كل تخطيط وميزة تنسيق بنفس الطريقة تمامًا. إذا تم إنشاء ملف ODP في LibreOffice أو OpenOffice Impress، تحقق من المخرجات واستخدم الخيارات الموضحة في [تحويل عروض OpenDocument](/slides/ar/nodejs-java/convert-openoffice-odp/) عندما تحتاج إلى إرشاد خاص بالصيغ.

## **تحويل PPT إلى PPTX**

PPT هو تنسيق PowerPoint الثنائي الأقدم، بينما PPTX هو تنسيق Office Open XML الحديث. يدعم Aspose.Slides for Node.js عبر Java تحويل PPT إلى PPTX بجودة عالية مع الحفاظ على هياكل العرض المعقدة مثل القوالب، التخطيطات، الشرائح، المخططات، الأشكال المجمعة، العناصر النائبة، إطارات النص، القوام، وتعبئة الصور.

للتفاصيل، راجع [تحويل PPT إلى PPTX](/slides/ar/nodejs-java/convert-ppt-to-pptx/) و[ PPT مقابل PPTX](/slides/ar/nodejs-java/ppt-vs-pptx/).

## **التصدير ذو التخطيط الثابت**

PDF وXPS وTIFF مفيدة عندما يجب أن يبدو الإخراج متطابقًا عبر الأجهزة ولا ينبغي تحريره كعرض تقديمي. تشرح المقالات المخصصة لـ PDF وXPS وTIFF كيفية التحكم في الامتثال، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، تنسيق البكسل، وحجم الإخراج.

## **تصدير HTML والصور**

تصدير HTML وHTML5 مفيد للعرض في المتصفح، النشر على الويب، والمشاركة الخفيفة. تصدير الصور مفيد عندما يجب أن تصبح كل شريحة معاينة منفصلة، مصغرة، أو أصل نقطي. استخدم مقالات PNG وJPG وSVG للحصول على إرشادات التصيير الخاصة بكل صيغة.

## **الأسئلة المتكررة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض التقديمية؟**

لا. Aspose.Slides for Node.js عبر Java هي مكتبة مستقلة ولا تتطلب Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل العديد من العروض دفعة واحدة؟**

نعم. حمّل كل عرض، احفظه بالصيغ المطلوبة، وتخلص من كائن العرض بعد المعالجة. للمعالجة المتوازية، استخدم نسخًا منفصلة من كائنات العرض واتبع إرشادات [التعددية](/slides/ar/nodejs-java/multithreading/).

**هل يمكنني تصدير شرائح محددة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير فهارس الشرائح أو تصيير شرائح فردية، حسب صيغة الإخراج. راجع المقال المخصص للصيغة المستهدفة.

**هل يمكنني تضمين الشرائح المخفية عند التصدير إلى PDF أو XPS؟**

نعم. استخدم إعدادات تصدير الشرائح المخفية الموضحة في مقالات [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) و[XPS](/slides/ar/nodejs-java/convert-powerpoint-to-xps/).

**هل يمكنني إنشاء مخرج PDF/A؟**

نعم. تتوفر إعدادات الامتثال لـ PDF عند تصدير PDF. راجع [تحويل PowerPoint إلى PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) للحصول على التفاصيل.

**كيف يتم التعامل مع الخطوط أثناء التحويل؟**

يمكن لـ Aspose.Slides استخدام الخطوط المضمّنة، الخط الاحتياطي، وإعدادات استبدال الخط. راجع [الخط المضمّن](/slides/ar/nodejs-java/embedded-font/)، [الخط الاحتياطي](/slides/ar/nodejs-java/fallback-font/)، و[استبدال الخط](/slides/ar/nodejs-java/font-substitution/).
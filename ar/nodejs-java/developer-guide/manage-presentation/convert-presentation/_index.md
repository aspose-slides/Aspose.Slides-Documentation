---
title: تحويل العروض إلى تنسيقات متعددة في JavaScript
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
description: "تحويل عروض PowerPoint وOpenDocument إلى PPTX وPDF وHTML وصور وXPS وTIFF والمزيد باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Node.js عبر Java تحميل عروض PowerPoint وOpenDocument وحفظها أو عرضها إلى العديد من الصيغ الأخرى دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، وتصدير العروض إلى مستندات ذات تخطيط ثابت مثل PDF وXPS، ونشر الشرائح كـ HTML، أو عرض الشرائح كملفات صورة للمعاينات، والملفات المصغرة، والأرشفة.

معظم عمليات تحويل المستندات تستخدم سير عمل عام مماثل: تحميل الملف المصدر، اختيار صيغة الإخراج المطلوبة، وتطبيق الخيارات الخاصة بالصِيغة عند الحاجة. بالنسبة لصيغ الصور، يتم عرض كل شريحة بشكل منفصل ثم حفظها كصورة نقطية أو متجهة. المقالات المخصصة المرتبطة أدناه توفر تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه للحصول على أمثلة JavaScript كاملة وخيارات خاصة بالصِيغة.

| السيناريو | استخدمه عندما تحتاج إلى | المقال |
| --- | --- | --- |
| PPT/PPTX/ODP إلى PPTX | تحديث ملفات PPT القديمة، وتوحيد ملفات PPTX الموجودة، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/nodejs-java/convert-ppt-to-pptx/), [تحويل ODP إلى PPTX](/slides/ar/nodejs-java/convert-odp-to-pptx/), [حفظ العروض](/slides/ar/nodejs-java/save-presentation/) |
| PPTX إلى PPT | حفظ عرض PowerPoint حديث إلى صيغة PPT الثنائية القديمة لضمان التوافق مع سير العمل القديم. | [تحويل PPTX إلى PPT](/slides/ar/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP إلى PDF | إنشاء مستندات قابلة للنقل والبحث وتخطيط ثابت للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP إلى PDF مع ملاحظات | تصدير ملاحظات المتحدث مع محتوى الشرائح. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP إلى HTML | نشر العروض كصفحات HTML والتحكم في الصور والخطوط والملاحظات وخيارات التخطيط المتجاوب. | [تحويل PowerPoint إلى HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP إلى HTML5 | تصدير الشرائح إلى HTML5 للعرض عبر المتصفح مع الحفاظ على التنسيق والتفاعلية. | [تحويل العروض إلى HTML5](/slides/ar/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP إلى PNG | عرض كل شريحة كصورة PNG للمعاينات، الصور المصغرة، أو مخرجات الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP إلى JPG | عرض الشرائح كصور JPG والتحكم في أبعاد الصورة وجودتها. | [تحويل PowerPoint إلى JPG](/slides/ar/nodejs-java/convert-powerpoint-to-jpg/) |
| شريحة إلى SVG | تصدير الشرائح الفردية كرسومات متجهة قابلة للتوسع. | [عرض الشريحة كـ SVG](/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP إلى XPS | إنشاء مستندات XPS ذات تخطيط ثابت. | [تحويل PowerPoint إلى XPS](/slides/ar/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP إلى TIFF | حفظ العرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو سير العمل الأرشيفي. | [تحويل PowerPoint إلى TIFF](/slides/ar/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP إلى TIFF مع ملاحظات | حفظ الشرائح مع ملاحظات المتحدث كملف TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX إلى Markdown | استخراج محتوى العرض إلى Markdown للتوثيق وسير العمل القائم على النص. | [تحويل PowerPoint إلى Markdown](/slides/ar/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX إلى GIF متحرك | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى GIF متحرك](/slides/ar/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX إلى فيديو | إنشاء سير عمل لتصدير الفيديو من شرائح العرض. | [تحويل PowerPoint إلى فيديو](/slides/ar/nodejs-java/convert-powerpoint-to-video/) |
| العرض إلى XAML | تصدير الشرائح إلى XAML لتطبيقات واجهة المستخدم JavaScript أو Java. | [تصدير العروض إلى XAML](/slides/ar/nodejs-java/export-to-xaml/) |

لقائمة أوسع من صيغ الإدخال والإخراج، راجع [الصيغ المدعومة للملفات](/slides/ar/nodejs-java/supported-file-formats/).

## **تحويل PowerPoint وOpenDocument**

يدعم Aspose.Slides for Node.js عبر Java التحويل من صيغ العروض الشائعة مثل PPT وPPTX وPPS وPPSX وPOT وPOTX وODP. يتم استخدام نفس واجهة برمجة التطبيقات للتحويل للملفات PowerPoint وOpenDocument، لذلك يمكن عادةً تطبيق سير عمل يحفظ ملف PPTX إلى PDF على ملف ODP عبر تغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، تذكّر أن تطبيقات PowerPoint وOpenDocument لا تدعم كل ميزات التخطيط والتنسيق بنفس الطريقة تمامًا. إذا تم إنشاء ملف ODP في LibreOffice أو OpenOffice Impress، راجع الناتج واستخدم الخيارات الموضحة في [تحويل عروض OpenDocument](/slides/ar/nodejs-java/convert-openoffice-odp/) عندما تحتاج إلى إرشادات خاصة بالصِيغة.

## **تحويل PPT إلى PPTX**

PPT هو صيغة PowerPoint الثنائية القديمة، بينما PPTX هو صيغة Office Open XML الحديثة. يدعم Aspose.Slides for Node.js عبر Java تحويل PPT إلى PPTX بدقة عالية مع الحفاظ على هياكل العروض المعقدة مثل القوالب، التخطيطات، الشرائح، المخططات، الأشكال المجمعة، العناصر النائبة، إطارات النص، القوام، وتعبئات الصور.

للتفاصيل، راجع [تحويل PPT إلى PPTX](/slides/ar/nodejs-java/convert-ppt-to-pptx/) و[الفرق بين PPT و PPTX](/slides/ar/nodejs-java/ppt-vs-pptx/).

## **تصدير تخطيط ثابت**

تكون صياغات PDF وXPS وTIFF مفيدة عندما يجب أن يبقى المخرج متشابهًا عبر الأجهزة ولا ينبغي تحريره كعرض تقديمي. تشرح المقالات المخصصة لـ PDF وXPS وTIFF كيفية التحكم في الامتثال، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، تنسيق البكسل، وحجم الإخراج.

## **تصدير HTML والصور**

يكون تصدير HTML وHTML5 مفيدًا للعرض عبر المتصفح، النشر على الويب، والمشاركة الخفيفة. يكون تصدير الصور مفيدًا عندما يجب أن تتحول كل شريحة إلى معاينة منفصلة أو صورة مصغرة أو عنصر نقطي. استخدم مقالات PNG وJPG وSVG للحصول على إرشادات العرض الخاصة بالصِيغة.

## **الأسئلة الشائعة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض التقديمية؟**

لا. Aspose.Slides for Node.js عبر Java هي مكتبة مستقلة ولا تتطلب Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل العديد من العروض دفعة واحدة؟**

نعم. قم بتحميل كل عرض، احفظه بالصِيغة المطلوبة، وتخلص من كائن العرض بعد المعالجة. للمعالجة المتوازية، استخدم نماذج عرض منفصلة وتبع إرشادات [المعالجة المتعددة الخيوط](/slides/ar/nodejs-java/multithreading/).

**هل يمكنني تصدير شرائح مختارة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير فهارس الشرائح أو عرض شرائح فردية، بحسب صيغة الإخراج. راجع المقال المخصص للصِيغة المستهدفة.

**هل يمكنني تضمين الشرائح المخفية عند التصدير إلى PDF أو XPS؟**

نعم. استخدم إعدادات تصدير الشرائح المخفية الموضحة في مقالات التحويل لـ [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) و[XPS](/slides/ar/nodejs-java/convert-powerpoint-to-xps/).

**هل يمكنني إنشاء مخرجات PDF/A؟**

نعم. تتوفر إعدادات الامتثال لـ PDF لتصدير PDF. راجع [تحويل PowerPoint إلى PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) لمزيد من التفاصيل.

**كيف يتم التعامل مع الخطوط أثناء التحويل؟**

يمكن لـ Aspose.Slides استخدام الخطوط المدمجة، وبدائل الخط، وإعدادات استبدال الخطوط. راجع [الخط المدمج](/slides/ar/nodejs-java/embedded-font/)، [خط البديل](/slides/ar/nodejs-java/fallback-font/)، و[استبدال الخط](/slides/ar/nodejs-java/font-substitution/).
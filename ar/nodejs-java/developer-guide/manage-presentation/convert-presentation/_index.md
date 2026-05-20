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
description: "تحويل عروض PowerPoint و OpenDocument إلى PPTX و PDF و HTML و صور و XPS و TIFF وغيرها باستخدام Aspose.Slides for Node.js via Java."
---
## **نظرة عامة**

Aspose.Slides for Node.js via Java يمكنه تحميل عروض PowerPoint و OpenDocument وحفظها أو تحويلها إلى تنسيقات أخرى كثيرة دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، تصدير العروض إلى مستندات ذات تخطيط ثابت مثل PDF و XPS، نشر الشرائح كـ HTML، أو تحويل الشرائح إلى ملفات صور للمعاينات، المصغرات، والأرشفة.

معظم عمليات تحويل المستندات تتبع نفس سير العمل العام: تحميل الملف المصدر، اختيار التنسيق المطلوب للإخراج، وتطبيق الخيارات الخاصة بالتنسيق عند الحاجة. بالنسبة لتنسيقات الصور، يتم تحويل كل شريحة على حدة ثم حفظها كصورة نقطية أو متجهة. المقالات المخصصة المرتبطة أدناه توضح تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه للحصول على أمثلة JavaScript كاملة وخيارات التنسيق الخاصة.

| السيناريو | استخدمه عندما تحتاج إلى | المقال |
| --- | --- | --- |
| PPT/PPTX/ODP إلى PPTX | تحديث ملفات PPT القديمة، توحيد ملفات PPTX الحالية، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/nodejs-java/convert-ppt-to-pptx/), [تحويل ODP إلى PPTX](/slides/ar/nodejs-java/convert-odp-to-pptx/), [حفظ العروض](/slides/ar/nodejs-java/save-presentation/) |
| PPTX إلى PPT | حفظ عرض PowerPoint الحديث إلى تنسيق PPT الثنائي القديم لتوافق مع تدفقات العمل القديمة. | [تحويل PPTX إلى PPT](/slides/ar/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP إلى PDF | إنشاء مستندات محمولة، قابلة للبحث، ذات تخطيط ثابت للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP إلى PDF مع الملاحظات | تصدير ملاحظات المتحدث مع محتوى الشريحة. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP إلى HTML | نشر العروض كصفحات HTML والتحكم في الصور، الخطوط، الملاحظات، وخيارات التخطيط المتجاوب. | [تحويل PowerPoint إلى HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP إلى HTML5 | تصدير الشرائح إلى HTML5 للعرض في المتصفح مع الحفاظ على التنسيق والتفاعلية. | [تحويل العروض إلى HTML5](/slides/ar/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP إلى PNG | تحويل كل شريحة إلى صورة PNG للمعاينات، المصغرات، أو إخراج الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP إلى JPG | تحويل الشرائح إلى صور JPG والتحكم في أبعاد الصورة وجودتها. | [تحويل PowerPoint إلى JPG](/slides/ar/nodejs-java/convert-powerpoint-to-jpg/) |
| الشريحة إلى SVG | تصدير شرائح فردية كرسومات متجهة قابلة للتوسيع. | [تحويل الشريحة إلى SVG](/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP إلى XPS | إنشاء مستندات XPS ذات تخطيط ثابت. | [تحويل PowerPoint إلى XPS](/slides/ar/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP إلى TIFF | حفظ العرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو الأرشفة. | [تحويل PowerPoint إلى TIFF](/slides/ar/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP إلى TIFF مع الملاحظات | حفظ الشرائح مع ملاحظات المتحدث إلى TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX إلى Markdown | استخراج محتوى العرض إلى Markdown للتوثيق أو تدفقات العمل النصية. | [تحويل PowerPoint إلى Markdown](/slides/ar/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX إلى GIF متحرك | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى GIF متحرك](/slides/ar/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX إلى فيديو | بناء سير عمل لتصدير الفيديو من شرائح العرض. | [تحويل PowerPoint إلى فيديو](/slides/ar/nodejs-java/convert-powerpoint-to-video/) |
| العرض إلى XAML | تصدير الشرائح إلى XAML لسيناريوهات واجهة المستخدم JavaScript أو Java. | [تصدير العروض إلى XAML](/slides/ar/nodejs-java/export-to-xaml/) |

للحصول على قائمة أوسع من صيغ الإدخال والإخراج، راجع [الصيغ المدعومة للملفات](/slides/ar/nodejs-java/supported-file-formats/).

## **تحويل PowerPoint و OpenDocument**

Aspose.Slides for Node.js via Java يدعم التحويل من صيغ العروض الشائعة مثل PPT و PPTX و PPS و PPSX و POT و POTX و ODP. يتم استخدام نفس واجهة برمجة التطبيقات للتحويل بين ملفات PowerPoint و OpenDocument، لذا يمكن تطبيق سير عمل يحفظ ملف PPTX إلى PDF عادةً على ملف ODP بتغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، تذكر أن تطبيقات PowerPoint و OpenDocument لا تدعم كل تخطيط وميزة تنسيق بنفس الطريقة تمامًا. إذا تم إنشاء ملف ODP في LibreOffice أو OpenOffice Impress، راجع الإخراج واستخدم الخيارات الموضحة في [Convert OpenDocument Presentations](/slides/ar/nodejs-java/convert-openoffice-odp/) عندما تحتاج إلى دليل خاص بالتنسيق.

## **تحويل PPT إلى PPTX**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Office Open XML الحديث. Aspose.Slides for Node.js via Java يدعم تحويل PPT إلى PPTX بجودة عالية مع الحفاظ على هياكل العرض المعقدة مثل القوالب، التخطيطات، الشرائح، المخططات، الأشكال المجمعة، العناصر النائبة، إطارات النص، القوام، وتعبئات الصور.

للتفاصيل، راجع [تحويل PPT إلى PPTX](/slides/ar/nodejs-java/convert-ppt-to-pptx/) و [PPT vs PPTX](/slides/ar/nodejs-java/ppt-vs-pptx/).

## **التصدير بتخطيط ثابت**

PDF و XPS و TIFF مفيدة عندما يجب أن يكون الإخراج متطابقًا عبر الأجهزة ولا ينبغي تعديلها كعرض تقديمي. المقالات المخصصة لـ PDF و XPS و TIFF توضح كيفية التحكم في الامتثال، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، صيغة البكسل، وحجم الإخراج.

## **التصدير إلى HTML والصور**

تصدير HTML و HTML5 مفيد للعرض في المتصفح، النشر على الويب، والمشاركة الخفيفة. تصدير الصور مفيد عندما يجب أن تتحول كل شريحة إلى معاينة، مصغرة، أو أصل نقطي منفصل. استخدم مقالات PNG و JPG و SVG للحصول على إرشادات الت rendering الخاصة بالتنسيق.

## **الأسئلة المتكررة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض؟**

لا. Aspose.Slides for Node.js via Java مكتبة مستقلة ولا تتطلب Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل عدد كبير من العروض دفعيًا؟**

نعم. قم بتحميل كل عرض، احفظه بالتنسيق المطلوب، وتخلص من كائن العرض بعد المعالجة. للمعالجة المتوازية، استخدم مثيلات عرض منفصلة واتبع إرشادات [multithreading](/slides/ar/nodejs-java/multithreading/).

**هل يمكنني تصدير شرائح مختارة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير فهارس الشرائح أو تصيير شرائح فردية، حسب تنسيق الإخراج. راجع المقال المخصص للتنسيق المستهدف.

**هل يمكنني تضمين الشرائح المخفية عند التصدير إلى PDF أو XPS؟**

نعم. استخدم إعدادات تصدير الشرائح المخفية الموضحة في مقالات [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) و [XPS](/slides/ar/nodejs-java/convert-powerpoint-to-xps/).

**هل يمكنني إنشاء مخرجات PDF/A؟**

نعم. تتوفر إعدادات الامتثال لـ PDF عند التصدير. راجع [تحويل PowerPoint إلى PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) للتفاصيل.

**كيف يتم التعامل مع الخطوط أثناء التحويل؟**

يمكن لـ Aspose.Slides استخدام الخطوط المضمنة، وتعويض الخطوط، وإعدادات استبدال الخطوط. راجع [Embedded Font](/slides/ar/nodejs-java/embedded-font/)، [Fallback Font](/slides/ar/nodejs-java/fallback-font/)، و [Font Substitution](/slides/ar/nodejs-java/font-substitution/).
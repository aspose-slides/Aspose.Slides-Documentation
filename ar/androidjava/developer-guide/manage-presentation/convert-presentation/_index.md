---
title: تحويل العروض التقديمية إلى صيغ متعددة على Android
linktitle: تحويل العرض التقديمي
type: docs
weight: 70
url: /ar/androidjava/convert-presentation/
keywords:
- تحويل العرض التقديمي
- تصدير العرض التقديمي
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
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint و OpenDocument إلى PPTX و PDF و HTML والصور و XPS و TIFF وأكثر باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **نظرة عامة**

Aspose.Slides for Android via Java يمكنه تحميل عروض PowerPoint و OpenDocument وت保存ها أو تصييرها إلى صيغ أخرى عديدة دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، تصدير العروض إلى مستندات ذات تخطيط ثابت مثل PDF و XPS، نشر الشرائح كـ HTML، أو تصيير الشرائح كملفات صورة للمعاينات، الصور المصغرة، والأرشيفات.

معظم عمليات تحويل المستندات تتبع سير عمل عام مماثل: تحميل الملف المصدر، اختيار صيغة الإخراج المطلوبة، وتطبيق الخيارات الخاصة بالصِغة عند الحاجة. بالنسبة لصيغ الصور، يتم تصيير كل شريحة بشكل منفصل ثم حفظها كصورة نقطية أو متجهة. المقالات المخصصة المرتبطة أدناه توضح تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه للحصول على أمثلة Java كاملة وخيارات الصِغة المحددة.

| سيناريو | استخدمه عندما تحتاج إلى | مقال |
| --- | --- | --- |
| PPT/PPTX/ODP إلى PPTX | تحديث ملفات PPT القديمة، توحيد ملفات PPTX الموجودة، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/androidjava/convert-ppt-to-pptx/), [تحويل ODP إلى PPTX](/slides/ar/androidjava/convert-odp-to-pptx/), [حفظ العروض](/slides/ar/androidjava/save-presentation/) |
| PPTX إلى PPT | حفظ عرض PowerPoint الحديث بصيغة PPT الثنائية القديمة للتوافق مع سير العمل القديم. | [تحويل PPTX إلى PPT](/slides/ar/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP إلى PDF | إنشاء مستندات محمولة، قابلة للبحث، ذات تخطيط ثابت للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP إلى PDF مع ملاحظات | تصدير ملاحظات المتحدث مع محتوى الشرائح. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP إلى HTML | نشر العروض كصفحات HTML والتحكم في الصور، الخطوط، الملاحظات، وخيارات التخطيط المتجاوب. | [تحويل PowerPoint إلى HTML](/slides/ar/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP إلى HTML5 | تصدير الشرائح إلى HTML5 للعرض في المتصفح مع الحفاظ على التنسيق والتفاعلية. | [تحويل العروض إلى HTML5](/slides/ar/androidjava/export-to-html5/) |
| PPT/PPTX/ODP إلى PNG | تصيير كل شريحة إلى صورة PNG للمعاينات أو الصور المصغرة أو المخرجات الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP إلى JPG | تصيير الشرائح إلى صور JPG والتحكم في أبعاد الصورة وجودتها. | [تحويل PowerPoint إلى JPG](/slides/ar/androidjava/convert-powerpoint-to-jpg/) |
| شريحة إلى SVG | تصدير شرائح فردية كرسومات متجهة قابلة للتوسع. | [تصيير الشريحة كـ SVG](/slides/ar/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP إلى XPS | إنشاء مستندات XPS ذات تخطيط ثابت. | [تحويل PowerPoint إلى XPS](/slides/ar/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP إلى TIFF | حفظ العرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو الأرشفة. | [تحويل PowerPoint إلى TIFF](/slides/ar/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP إلى TIFF مع ملاحظات | حفظ الشرائح مع ملاحظات المتحدث إلى TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX إلى Word | تحويل الشرائح إلى مستند Word عندما تحتاج مخرجات على شكل مستند. | [تحويل PowerPoint إلى Word](/slides/ar/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX إلى Markdown | استخراج محتوى العرض إلى Markdown للتوثيق وسير العمل النصي. | [تحويل PowerPoint إلى Markdown](/slides/ar/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP إلى XML | إنشاء تمثيل XML نصي لعرض PowerPoint للفحص أو المقارنة أو استكشاف الأخطاء أو سير عمل معتمد على XML. | [تحويل PowerPoint إلى XML](/slides/ar/androidjava/convert-powerpoint-to-xml/) |
| PPT/PPTX إلى GIF متحرك | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى GIF متحرك](/slides/ar/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX إلى فيديو | إنشاء سير عمل لتصدير العرض كفيديو. | [تحويل PowerPoint إلى فيديو](/slides/ar/androidjava/convert-powerpoint-to-video/) |
| عرض إلى XAML | تصدير الشرائح إلى XAML لسيناريوهات واجهة Android أو Java. | [تصدير العروض إلى XAML](/slides/ar/androidjava/export-to-xaml/) |

للقائمة الأوسع من صيغ الإدخال والإخراج، راجع [صيغ الملفات المدعومة](/slides/ar/androidjava/supported-file-formats/).

## **تحويل PowerPoint و OpenDocument**

Aspose.Slides for Android via Java يدعم التحويل من صيغ العرض الشائعة مثل PPT و PPTX و PPS و PPSX و POT و POTX و ODP. يتم استخدام نفس واجهة برمجة التطبيقات للتحويل بين ملفات PowerPoint و OpenDocument، لذا يمكن عادةً تطبيق سير عمل حفظ ملف PPTX إلى PDF على ملف ODP بتغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، تذكر أن تطبيقات PowerPoint و OpenDocument لا تدعم كل تخطيط وتنسيق بنفس الطريقة تمامًا. إذا تم إنشاء ملف ODP في LibreOffice أو OpenOffice Impress، راجع المخرجات واستخدم الخيارات الموضحة في [تحويل عروض OpenDocument](/slides/ar/androidjava/convert-openoffice-odp/) عندما تحتاج إلى إرشادات خاصة بالصِغة.

## **تحويل PPT إلى PPTX**

PPT هو صيغة PowerPoint الثنائية القديمة، بينما PPTX هي صيغة Office Open XML الحديثة. Aspose.Slides for Android via Java يدعم تحويل PPT إلى PPTX بدقة عالية مع الحفاظ على هياكل العرض المعقدة مثل القوالب، التخطيطات، الشرائح، المخططات، الأشكال المجمعة، العناصر النائبة، إطارات النص، القوام، وتعبئة الصور.

للتفاصيل، راجع [تحويل PPT إلى PPTX](/slides/ar/androidjava/convert-ppt-to-pptx/) و[PPT مقابل PPTX](/slides/ar/androidjava/ppt-vs-pptx/).

## **تصدير التخطيط الثابت**

PDF و XPS و TIFF مفيدان عندما يجب أن يبقى المخرج متطابقًا عبر الأجهزة ولا ينبغي تحريره كعرض تقديمي. المقالات المخصصة لـ PDF و XPS و TIFF تشرح كيفية التحكم في الامتثال، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، صيغة البكسل، وحجم الإخراج.

## **تصدير HTML والصور**

تصدير HTML و HTML5 مفيد للعرض في المتصفح، النشر على الويب، والمشاركة الخفيفة. تصدير الصور مفيد عندما يجب أن تصبح كل شريحة معاينة أو صورة مصغرة أو أصل نقطي منفصل. استخدم مقالات PNG و JPG و SVG للحصول على إرشادات تصيير خاصة بالصِغة.

## **الأسئلة المتكررة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض؟**

لا. Aspose.Slides for Android via Java مكتبة مستقلة ولا تتطلب Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل مجموعة كبيرة من العروض دفعيًا؟**

نعم. حمّل كل عرض، احفظه بالصِغة المطلوبة، وأفرغ كائن العرض بعد المعالجة. للمعالجة المتوازية، استخدم مثيلات عرض منفصلة واتبع إرشادات [التعدد الخيطي](/slides/ar/androidjava/multithreading/).

**هل يمكنني تصدير شرائح مختارة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير فهارس الشرائح أو تصيير شرائح فردية، حسب صيغة الإخراج. راجع المقال المخصص للصِغة المستهدفة.

**هل يمكنني تضمين الشرائح المخفية عند التصدير إلى PDF أو XPS؟**

نعم. استخدم إعدادات تصدير الشرائح المخفية الموضحة في مقالات [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/) و[XPS](/slides/ar/androidjava/convert-powerpoint-to-xps/).

**هل يمكنني إنشاء مخرجات PDF/A؟**

نعم. تتوفر إعدادات امتثال PDF لتصدير PDF. راجع [تحويل PowerPoint إلى PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/) للتفاصيل.

**كيف يتم التعامل مع الخطوط أثناء التحويل؟**

Aspose.Slides يمكنه استخدام الخطوط المضمنة، fallback للخطوط، وإعدادات استبدال الخطوط. راجع [خط مضمن](/slides/ar/androidjava/embedded-font/)، [خط احتياطي](/slides/ar/androidjava/fallback-font/)، و[استبدال خط](/slides/ar/androidjava/font-substitution/).
---
title: تحويل العروض التقديمية إلى صيغ متعددة في PHP
linktitle: تحويل العرض التقديمي
type: docs
weight: 70
url: /ar/php-java/convert-presentation/
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
- PHP
- Aspose.Slides
description: "تحويل عروض PowerPoint و OpenDocument إلى PPTX و PDF و HTML وصور و XPS و TIFF وغيرها باستخدام Aspose.Slides لـ PHP عبر Java."
---
## **نظرة عامة**

Aspose.Slides for PHP via Java يمكنه تحميل عروض PowerPoint و OpenDocument وحفظها أو عرضها بتنسيقات متعددة دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، وتصدير العروض إلى مستندات ثابتة التخطيط مثل PDF و XPS، نشر الشرائح كـ HTML، أو عرض الشرائح كملفات صورة للمعاينات، المصغرات، والأرشفة.

معظم تحويلات المستندات تتبع نفس سير العمل العام: تحميل الملف المصدر، اختيار تنسيق الإخراج المطلوب، وتطبيق الخيارات الخاصة بالتنسيق عند الحاجة. بالنسبة لتنسيقات الصورة، يتم عرض كل شريحة على حدة ثم حفظها كصورة نقطية أو متجهة. المقالات المخصصة المرتبطة أدناه توضح تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه للحصول على أمثلة PHP كاملة وخيارات خاصة بالتنسيق.

| السيناريو | استخدمه عندما تحتاج إلى | المقال |
| --- | --- | --- |
| PPT/PPTX/ODP إلى PPTX | تحديث ملفات PPT القديمة، توحيد ملفات PPTX الحالية، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/php-java/convert-ppt-to-pptx/), [تحويل ODP إلى PPTX](/slides/ar/php-java/convert-odp-to-pptx/), [حفظ العروض التقديمية](/slides/ar/php-java/save-presentation/) |
| PPTX إلى PPT | حفظ عرض PowerPoint الحديث إلى تنسيق PPT الثنائي القديم لتوافق مع سير العمل القديم. | [تحويل PPTX إلى PPT](/slides/ar/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP إلى PDF | إنشاء مستندات ثابتة التخطيط، قابلة للنقل والبحث، للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP إلى PDF مع الملاحظات | تصدير ملاحظات المتحدث مع محتوى الشرائح. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP إلى HTML | نشر العروض التقديمية كصفحات HTML والتحكم في الصور والخطوط والملاحظات وخيارات التخطيط المتجاوب. | [تحويل PowerPoint إلى HTML](/slides/ar/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP إلى HTML5 | تصدير الشرائح إلى HTML5 للعرض في المتصفح مع الحفاظ على التنسيق والتفاعلية. | [تحويل العروض إلى HTML5](/slides/ar/php-java/export-to-html5/) |
| PPT/PPTX/ODP إلى PNG | تحويل كل شريحة إلى صورة PNG للمعاينات أو المصغرات أو الإخراج الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP إلى JPG | تحويل الشرائح إلى صور JPG والتحكم في أبعاد الصورة وجودتها. | [تحويل PowerPoint إلى JPG](/slides/ar/php-java/convert-powerpoint-to-jpg/) |
| Slide إلى SVG | تصدير شرائح فردية كرسومات متجهة قابلة للتوسع. | [تصدير الشريحة كـ SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP إلى XPS | إنشاء مستندات XPS ثابتة التخطيط. | [تحويل PowerPoint إلى XPS](/slides/ar/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP إلى TIFF | حفظ العرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو سير عمل الأرشفة. | [تحويل PowerPoint إلى TIFF](/slides/ar/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP إلى TIFF مع الملاحظات | حفظ الشرائح مع ملاحظات المتحدث إلى TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX إلى Markdown | استخراج محتوى العرض إلى Markdown للتوثيق وسير العمل النصي. | [تحويل PowerPoint إلى Markdown](/slides/ar/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX إلى GIF متحرك | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى GIF متحرك](/slides/ar/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX إلى فيديو | إنشاء سير عمل تصدير فيديو من شرائح العرض. | [تحويل PowerPoint إلى فيديو](/slides/ar/php-java/convert-powerpoint-to-video/) |
| Presentation إلى XAML | تصدير الشرائح إلى XAML لسيناريوهات واجهة المستخدم PHP أو Java. | [تصدير العروض إلى XAML](/slides/ar/php-java/export-to-xaml/) |

لقائمة أوسع من تنسيقات الإدخال والإخراج، راجع [تنسيقات الملفات المدعومة](/slides/ar/php-java/supported-file-formats/).

## **تحويل PowerPoint و OpenDocument**

Aspose.Slides for PHP via Java يدعم التحويل من تنسيقات العرض الشائعة مثل PPT و PPTX و PPS و PPSX و POT و POTX و ODP. يتم استخدام نفس واجهة برمجة التحويل لملفات PowerPoint و OpenDocument، لذا يمكن عادةً تطبيق سير عمل يحفظ ملف PPTX إلى PDF على ملف ODP بتغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، تذكر أن تطبيقات PowerPoint و OpenDocument لا تدعم كل تخطيط وميزة تنسيق بنفس الطريقة بالضبط. إذا تم إنشاء ملف ODP في LibreOffice أو OpenOffice Impress، راجع النتيجة واستخدم الخيارات الموضحة في [تحويل عروض OpenDocument](/slides/ar/php-java/convert-openoffice-odp/) عندما تحتاج إلى إرشادات خاصة بالتنسيق.

## **تحويل PPT إلى PPTX**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Office Open XML الحديث. Aspose.Slides for PHP via Java يدعم تحويل PPT إلى PPTX بدقة عالية مع الحفاظ على هياكل العرض المعقدة مثل القوالب، التخطيطات، الشرائح، المخططات، الأشكال المجمعة، العناصر النائبة، أطر النص، القوام، وتعبئات الصور.

لمزيد من التفاصيل، راجع [تحويل PPT إلى PPTX](/slides/ar/php-java/convert-ppt-to-pptx/) و [PPT vs PPTX](/slides/ar/php-java/ppt-vs-pptx/).

## **تصدير التخطيط الثابت**

PDF و XPS و TIFF مفيدان عندما يجب أن يبدو الإخراج متطابقاً عبر الأجهزة ولا ينبغي تحريره كعرض تقديمي. المقالات المخصصة لـ PDF و XPS و TIFF تشرح كيفية التحكم في الامتثال، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، صيغة البكسل، وحجم الإخراج.

## **تصدير HTML والصور**

تصدير HTML و HTML5 مفيد للعرض في المتصفح، النشر على الويب، والمشاركة الخفيفة. تصدير الصور مفيد عندما يجب أن تتحول كل شريحة إلى معاينة منفصلة أو مصغرة أو أصل نقطي. استخدم مقالات PNG و JPG و SVG للحصول على إرشادات خاصة بالرندر.

## **الأسئلة الشائعة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض؟**

لا. Aspose.Slides for PHP via Java مكتبة مستقلة ولا تتطلب Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل مجموعة من العروض دفعة واحدة؟**

نعم. حمل كل عرض، احفظه بالتنسيق المطلوب، ثم حرر كائن العرض بعد المعالجة. للمعالجة المتوازية، استخدم نسخ مستقلة من كائنات العرض واتبع إرشادات [تعدد الخيوط](/slides/ar/php-java/multithreading/).

**هل يمكنني تصدير شرائح مختارة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير فهارس الشرائح أو عرض شرائح فردية، حسب تنسيق الإخراج. راجع المقال المخصص للتنسيق المستهدف.

**هل يمكنني تضمين الشرائح المخفية عند التصدير إلى PDF أو XPS؟**

نعم. استخدم إعدادات تصدير الشرائح المخفية الموضحة في مقالات [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) و [XPS](/slides/ar/php-java/convert-powerpoint-to-xps/).

**هل يمكنني إنشاء مخرجات PDF/A؟**

نعم. إعدادات الامتثال متاحة لتصدير PDF. راجع [تحويل PowerPoint إلى PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) للتفاصيل.

**كيف يتم التعامل مع الخطوط أثناء التحويل؟**

Aspose.Slides يمكنه استخدام الخطوط المدمجة، والfallback للخطوط، وإعدادات استبدال الخطوط. راجع [الخط المدمج](/slides/ar/php-java/embedded-font/)، [خط fallback](/slides/ar/php-java/fallback-font/)، و [استبدال الخط](/slides/ar/php-java/font-substitution/).
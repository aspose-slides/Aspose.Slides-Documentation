---
title: تحويل العروض إلى صيغ متعددة في PHP
linktitle: تحويل العرض
type: docs
weight: 70
url: /ar/php-java/convert-presentation/
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
- PHP
- Aspose.Slides
description: "تحويل عروض PowerPoint وOpenDocument إلى PPTX وPDF وHTML وصور وXPS وTIFF وأكثر باستخدام Aspose.Slides for PHP عبر Java."
---
## **نظرة عامة**

Aspose.Slides for PHP عبر Java يمكنه تحميل عروض PowerPoint وOpenDocument وحفظها أو تحويلها إلى صيغ أخرى متعددة دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، وتصدير العروض إلى مستندات ثابتة مثل PDF وXPS، ونشر الشرائح كـ HTML، أو تحويل الشرائح إلى ملفات صورة للمعاينات، الصور المصغرة، والأرشفة.

معظم تحويلات المستندات تتبع سير عمل عام مماثل: تحميل الملف المصدر، اختيار الصيغة المطلوبة، وتطبيق خيارات خاصة بالصية عند الحاجة. بالنسبة لصيغ الصور، يتم تحويل كل شريحة على حدة ثم حفظها كصورة نقطية أو متجهة. المقالات المخصصة المرتبطة أدناه توضح تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه لأمثلة PHP كاملة وخيارات مخصصة حسب الصيغة.

| السيناريو | استخدمه عندما تحتاج إلى | المقال |
| --- | --- | --- |
| PPT/PPTX/ODP إلى PPTX | تحديث ملفات PPT القديمة، توحيد ملفات PPTX الحالية، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/php-java/convert-ppt-to-pptx/),[تحويل ODP إلى PPTX](/slides/ar/php-java/convert-odp-to-pptx/),[حفظ العروض](/slides/ar/php-java/save-presentation/) |
| PPTX إلى PPT | حفظ عرض PowerPoint حديث إلى الصيغة الثنائية القديمة PPT لتوافقه مع عمليات العمل القديمة. | [تحويل PPTX إلى PPT](/slides/ar/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP إلى PDF | إنشاء مستندات ثابتة، قابلة للبحث، ومحمولة للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP إلى PDF مع الملاحظات | تصدير ملاحظات المتحدث مع محتوى الشرائح. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP إلى HTML | نشر العروض كصفحات HTML والتحكم في الصور، الخطوط، الملاحظات، وخيارات التخطيط المتجاوب. | [تحويل PowerPoint إلى HTML](/slides/ar/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP إلى HTML5 | تصدير الشرائح إلى HTML5 للعرض في المتصفح مع الحفاظ على التنسيق والتفاعلية. | [تحويل العروض إلى HTML5](/slides/ar/php-java/export-to-html5/) |
| PPT/PPTX/ODP إلى PNG | تحويل كل شريحة إلى صورة PNG للمعاينات أو الصور المصغرة أو الإخراج الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP إلى JPG | تحويل الشرائح إلى صور JPG والتحكم في أبعاد الصورة وجودتها. | [تحويل PowerPoint إلى JPG](/slides/ar/php-java/convert-powerpoint-to-jpg/) |
| شريحة إلى SVG | تصدير الشرائح الفردية كرسومات متجهة قابلة للتوسع. | [تحويل الشريحة إلى SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP إلى XPS | إنشاء مستندات XPS ثابتة. | [تحويل PowerPoint إلى XPS](/slides/ar/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP إلى TIFF | حفظ العرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو الأرشفة. | [تحويل PowerPoint إلى TIFF](/slides/ar/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP إلى TIFF مع الملاحظات | حفظ الشرائح مع ملاحظات المتحدث إلى TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX إلى Markdown | استخراج محتوى العرض إلى صيغة Markdown للتوثيق وسير العمل النصي. | [تحويل PowerPoint إلى Markdown](/slides/ar/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP إلى XML | إنشاء عرض PowerPoint XML نصي للفحص أو المقارنة أو استكشاف الأخطاء أو سير عمل XML. | [تحويل PowerPoint إلى XML](/slides/ar/php-java/convert-powerpoint-to-xml/) |
| PPT/PPTX إلى GIF متحرك | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى GIF متحرك](/slides/ar/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX إلى فيديو | بناء سير عمل لتصدير الفيديو من شرائح العرض. | [تحويل PowerPoint إلى فيديو](/slides/ar/php-java/convert-powerpoint-to-video/) |
| العرض إلى XAML | تصدير الشرائح إلى XAML لسيناريوهات واجهة PHP أو Java. | [تصدير العروض إلى XAML](/slides/ar/php-java/export-to-xaml/) |

للحصول على قائمة أوسع من صيغ الإدخال والإخراج، راجع [الصيغ المدعومة](/slides/ar/php-java/supported-file-formats/).

## **تحويل PowerPoint وOpenDocument**

Aspose.Slides for PHP عبر Java يدعم التحويل من صيغ العروض الشائعة مثل PPT، PPTX، PPS، PPSX، POT، POTX، وODP. يتم استخدام نفس واجهة برمجة التطبيقات للتحويل بين ملفات PowerPoint وOpenDocument، لذلك يمكن عادةً تطبيق سير عمل حفظ ملف PPTX إلى PDF على ملف ODP بتغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، تذكر أن تطبيقات PowerPoint وOpenDocument لا تدعم جميع تخطيطات وتنسيقات المحتوى بنفس الطريقة. إذا تم إنشاء ملف ODP في LibreOffice أو OpenOffice Impress، راجع النتيجة واستخدم الخيارات الموضحة في [تحويل عروض OpenDocument](/slides/ar/php-java/convert-openoffice-odp/) إذا احتجت إرشادات خاصة بالصيفة.

## **تحويل PPT إلى PPTX**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Office Open XML الحديث. Aspose.Slides for PHP عبر Java يدعم تحويل PPT إلى PPTX بجودة عالية مع الحفاظ على هياكل العرض المعقدة مثل القوالب، التخطيطات، الشرائح، المخططات، الأشكال المجمعة، العناصر النائبة، إطارات النص، القوام، وتعبئة الصور.

للتفاصيل، راجع [تحويل PPT إلى PPTX](/slides/ar/php-java/convert-ppt-to-pptx/) و[الفرق بين PPT وPPTX](/slides/ar/php-java/ppt-vs-pptx/).

## **تصدير ثابت التخطيط**

PDF وXPS وTIFF مفيدة عندما يجب أن يبدو الناتج موحدًا عبر الأجهزة ولا يُعدل كعرض تقديمي. المقالات المخصصة للـ PDF والـ XPS والـ TIFF تشرح كيفية التحكم في الامتثال، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، تنسيق البكسل، وحجم الإخراج.

## **تصدير HTML والصور**

تصدير HTML وHTML5 مفيد للعرض في المتصفح، النشر على الويب، والمشاركة الخفيفة. تصدير الصور مفيد عندما تحتاج كل شريحة إلى معاينة منفصلة أو صورة مصغرة أو أصل نقطي. استخدم مقالات PNG وJPG وSVG للحصول على إرشادات حول التصيير الخاص بكل صيغة.

## **الأسئلة المتكررة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض؟**

لا. Aspose.Slides for PHP عبر Java مكتبة مستقلة ولا تحتاج إلى Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل مجموعة من العروض دفعيًا؟**

نعم. قم بتحميل كل عرض، احفظه بالصيفة المطلوبة، ثم حرّر كائن العرض بعد المعالجة. للمعالجة المتوازية، استخدم نسخًا مستقلة من كائنات العرض واتبع إرشادات [التعدد الخيطي](/slides/ar/php-java/multithreading/).

**هل يمكنني تصدير شرائح محددة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير فهارس الشرائح أو تصيير الشرائح الفردية حسب صيغة الإخراج. راجع المقال المخصص للصيفة المستهدفة.

**هل يمكنني تضمين الشرائح المخفية عند التصدير إلى PDF أو XPS؟**

نعم. استخدم إعدادات تصدير الشرائح المخفية الموضحة في مقالات [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) و[XPS](/slides/ar/php-java/convert-powerpoint-to-xps/).

**هل يمكنني إنشاء مخرجات PDF/A؟**

نعم. تتوفر إعدادات الامتثال للـ PDF عند التصدير. راجع [تحويل PowerPoint إلى PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) للتفاصيل.

**كيف يتم معالجة الخطوط أثناء التحويل؟**

Aspose.Slides يمكنه استخدام الخطوط المضمنة، fallback للخطوط، وإعدادات استبدال الخطوط. راجع [الخط المضمن](/slides/ar/php-java/embedded-font/)، [خط fallback](/slides/ar/php-java/fallback-font/)، و[استبدال الخط](/slides/ar/php-java/font-substitution/).
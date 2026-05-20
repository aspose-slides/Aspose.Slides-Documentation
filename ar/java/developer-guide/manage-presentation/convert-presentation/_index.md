---
title: تحويل العروض إلى صيغ متعددة في Java
linktitle: تحويل العرض
type: docs
weight: 70
url: /ar/java/convert-presentation/
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
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint وOpenDocument إلى PPTX وPDF وHTML وصور وXPS وTIFF والمزيد باستخدام Aspose.Slides for Java."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Java تحميل عروض PowerPoint وOpenDocument وتخزينها أو تصييرها إلى العديد من الصيغ الأخرى دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، تصدير العروض إلى مستندات ثابتة التخطيط مثل PDF وXPS، نشر الشرائح كـ HTML، أو تصيير الشرائح كملفات صور للمعاينات، المصغرات، والأرشفة.

تستخدم معظم عمليات تحويل المستندات نفس سير العمل العام: تحميل الملف المصدر، اختيار الصيغة المطلوبة للإخراج، وتطبيق الخيارات الخاصة بالصِيغة عند الحاجة. بالنسبة لصيغ الصور، يتم تصيير كل شريحة على حدة ثم حفظها كصورة نقطية أو متجهة. توفر المقالات المخصصة المذكورة أدناه تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه للحصول على أمثلة Java كاملة وخيارات خاصة بكل صيغة.

| سيناريو | استخدمه عندما تحتاج إلى | المقال |
| --- | --- | --- |
| PPT/PPTX/ODP إلى PPTX | تحديث ملفات PPT القديمة، توحيد ملفات PPTX الموجودة، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/java/convert-ppt-to-pptx/), [تحويل ODP إلى PPTX](/slides/ar/java/convert-odp-to-pptx/), [حفظ العروض](/slides/ar/java/save-presentation/) |
| PPTX إلى PPT | حفظ عرض PowerPoint حديث إلى الصيغة الثنائية القديمة PPT للتوافق مع سير عمل أقدم. | [تحويل PPTX إلى PPT](/slides/ar/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP إلى PDF | إنشاء مستندات ثابتة، قابلة للبحث، ومحمولة للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP إلى PDF مع الملاحظات | تصدير ملاحظات المتحدث مع محتوى الشريحة. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP إلى HTML | نشر العروض كصفحات HTML والتحكم في الصور، الخطوط، الملاحظات، وخيارات التخطيط المتجاوب. | [تحويل PowerPoint إلى HTML](/slides/ar/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP إلى HTML5 | تصدير الشرائح إلى HTML5 للعرض في المتصفح مع الحفاظ على التنسيق والتفاعلية. | [تحويل العروض إلى HTML5](/slides/ar/java/export-to-html5/) |
| PPT/PPTX/ODP إلى PNG | تصيير كل شريحة إلى صورة PNG للمعاينات أو المصغرات أو إخراج الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP إلى JPG | تصيير الشرائح إلى صور JPG والتحكم بأبعاد الجودة. | [تحويل PowerPoint إلى JPG](/slides/ar/java/convert-powerpoint-to-jpg/) |
| شريحة إلى SVG | تصدير شرائح فردية كرسومات متجهية قابلة للتوسع. | [تصيير الشريحة كـ SVG](/slides/ar/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP إلى XPS | إنشاء مستندات XPS ثابتة التخطيط. | [تحويل PowerPoint إلى XPS](/slides/ar/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP إلى TIFF | حفظ العرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو الأرشفة. | [تحويل PowerPoint إلى TIFF](/slides/ar/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP إلى TIFF مع الملاحظات | حفظ الشرائح مع ملاحظات المتحدث إلى TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX إلى Word | تحويل الشرائح إلى مستند Word عندما تحتاج إخراجًا بنمط مستند. | [تحويل PowerPoint إلى Word](/slides/ar/java/convert-powerpoint-to-word/) |
| PPT/PPTX إلى Markdown | استخراج محتوى العرض إلى Markdown للتوثيق وسير العمل النصي. | [تحويل PowerPoint إلى Markdown](/slides/ar/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX إلى GIF متحرك | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى Animated GIF](/slides/ar/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX إلى فيديو | إنشاء سير عمل لتصدير الفيديو من شرائح العرض. | [تحويل PowerPoint إلى Video](/slides/ar/java/convert-powerpoint-to-video/) |
| عرض إلى XAML | تصدير الشرائح إلى XAML لسيناريوهات واجهة Java. | [تصدير العروض إلى XAML](/slides/ar/java/export-to-xaml/) |

لمزيد من قائمة شاملة لصيغ الإدخال والإخراج، راجع [الصيغ المدعومة للملفات](/slides/ar/java/supported-file-formats/).

## **تحويل PowerPoint وOpenDocument**

يدعم Aspose.Slides for Java التحويل من صيغ العروض الشائعة مثل PPT، PPTX، PPS، PPSX، POT، POTX، وODP. يتم استخدام نفس API التحويل لملفات PowerPoint وOpenDocument، لذا يمكن عادةً تطبيق سير عمل حفظ ملف PPTX إلى PDF على ملف ODP بتغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، تذكر أن تطبيقات PowerPoint وOpenDocument لا تدعم كل تخطيط وميزة تنسيق بنفس الطريقة تمامًا. إذا تم إنشاء ملف ODP في LibreOffice أو OpenOffice Impress، راجع الناتج واستخدم الخيارات الموضحة في [Convert OpenDocument Presentations](/slides/ar/java/convert-openoffice-odp/) عندما تحتاج إلى إرشادات خاصة بالصِيغة.

## **تحويل PPT إلى PPTX**

PPT هو صيغة PowerPoint الثنائية القديمة، بينما PPTX هو صيغة Office Open XML الحديثة. يدعم Aspose.Slides for Java تحويل PPT إلى PPTX بدقة عالية مع الحفاظ على هياكل العرض المعقدة مثل القوالب، التخطيطات، الشرائح، المخططات، الأشكال المجمعة، النواقل، إطارات النص، القوام، وتعبئة الصور.

للتفاصيل، راجع [Convert PPT to PPTX](/slides/ar/java/convert-ppt-to-pptx/) و[ PPT vs PPTX](/slides/ar/java/ppt-vs-pptx/).

## **تصدير ثابت التخطيط**

تُعد صيغ PDF وXPS وTIFF مفيدة عندما يجب أن يبدو المخرجات نفسها على جميع الأجهزة ولا ينبغي تعديلها كعرض تقديمي. توضح مقالات PDF وXPS وTIFF المخصصة كيفية التحكم في الالتزام، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، صيغة البكسل، وحجم الإخراج.

## **تصدير HTML والصور**

يعد تصدير HTML وHTML5 مفيدًا للعرض في المتصفح، النشر على الويب، والمشاركة الخفيفة. يكون تصدير الصور مفيدًا عندما يجب أن تتحول كل شريحة إلى معاينة أو مصغرة أو أصل نقطي منفصل. استخدم مقالات PNG وJPG وSVG للحصول على إرشادات خاصة بالصيغة.

## **الأسئلة الشائعة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض؟**

لا. Aspose.Slides for Java مكتبة مستقلة ولا تتطلب Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل عدة عروض دفعة واحدة؟**

نعم. قم بتحميل كل عرض، احفظه بالصِيغة المطلوبة، وتخلص من كائن العرض بعد المعالجة. للمعالجة المتوازية، استخدم نسخ منفصلة من العروض واتبع إرشادات [multithreading](/slides/ar/java/multithreading/).

**هل يمكنني تصدير شرائح مختارة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير فهارس الشرائح أو تصيير شرائح فردية، حسب صيغة الإخراج. راجع المقال المخصص للصِيغة المستهدفة.

**هل يمكنني تضمين الشرائح المخفية عند التصدير إلى PDF أو XPS؟**

نعم. استخدم إعدادات تصدير الشرائح المخفية الموضحة في مقالات [PDF](/slides/ar/java/convert-powerpoint-to-pdf/) و[XPS](/slides/ar/java/convert-powerpoint-to-xps/).

**هل يمكنني إنشاء مخرجات PDF/A؟**

نعم. تتوفر إعدادات الالتزام للـ PDF عند التصدير. راجع [Convert PowerPoint to PDF](/slides/ar/java/convert-powerpoint-to-pdf/) للتفاصيل.

**كيف يتم التعامل مع الخطوط أثناء التحويل؟**

يمكن لـ Aspose.Slides استخدام الخطوط المدمجة، fallback للخطوط، وإعدادات استبدال الخطوط. راجع [Embedded Font](/slides/ar/java/embedded-font/)، [Fallback Font](/slides/ar/java/fallback-font/)، و[Font Substitution](/slides/ar/java/font-substitution/).
---
title: تحويل العروض إلى صيغ متعددة في C++
linktitle: تحويل العرض
type: docs
weight: 70
url: /ar/cpp/convert-presentation/
keywords:
- تحويل عرض
- تصدير عرض
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
- C++
- Aspose.Slides
description: "تحويل عروض PowerPoint وOpenDocument إلى PPTX وPDF وHTML وصور وXPS وTIFF وغيرها باستخدام Aspose.Slides for C++."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for C++ تحميل عروض PowerPoint وOpenDocument وتصديرها أو تصييرها إلى العديد من الصيغ الأخرى دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، وتصدير العروض إلى مستندات ثابتة التخطيط مثل PDF وXPS، ونشر الشرائح كـ HTML، أو تصيير الشرائح كملفات صورة للمعاينات، والصغار، والأرشفة.

معظم عمليات تحويل المستندات تستخدم سير عمل عام مماثل: تحميل الملف المصدر، اختيار الصيغة المطلوبة، وتطبيق الخيارات الخاصة بالصيغ عند الحاجة. بالنسبة لصيغ الصور، يتم تصيير كل شريحة على حدة ثم حفظها كصورة نقطية أو متجهة. المقالات المخصصة المرتبطة أدناه توضح تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه للحصول على أمثلة C++ كاملة وخيارات خاصة بالصيغة.

| السيناريو | استخدمه عندما تحتاج إلى | المقالة |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | تحديث ملفات PPT القديمة، توحيد ملفات PPTX الحالية، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/cpp/convert-ppt-to-pptx/), [تحويل ODP إلى PPTX](/slides/ar/cpp/convert-odp-to-pptx/), [حفظ العروض](/slides/ar/cpp/save-presentation/) |
| PPTX to PPT | حفظ عرض PowerPoint الحديث إلى صيغة PPT الثنائية القديمة لتوافق مع سير عمل أقدم. | [تحويل PPTX إلى PPT](/slides/ar/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | إنشاء مستندات محمولة، قابلة للبحث، ثابتة التخطيط للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | تصدير ملاحظات المتحدث مع محتوى الشريحة. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | نشر العروض كصفحات HTML والتحكم في الصور، الخطوط، الملاحظات، وخيارات التخطيط المتجاوب. | [تحويل PowerPoint إلى HTML](/slides/ar/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | تصدير الشرائح إلى HTML5 للعرض عبر المتصفح مع الحفاظ على التنسيق والتفاعلية. | [تحويل العروض إلى HTML5](/slides/ar/cpp/export-to-html5/) |
| PPT/PPTX/ODP to PNG | تصيير كل شريحة إلى صورة PNG للمعاينات أو الصغار أو مخرجات الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | تصيير الشرائح إلى صور JPG والتحكم في أبعاد الصورة وجودتها. | [تحويل PowerPoint إلى JPG](/slides/ar/cpp/convert-powerpoint-to-jpg/) |
| Slide to SVG | تصدير الشرائح الفردية كرسومات متجهة قابلة للتوسع. | [تصيير الشريحة كـ SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | إنشاء مستندات XPS ثابتة التخطيط. | [تحويل PowerPoint إلى XPS](/slides/ar/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | حفظ عرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو سير عمل الأرشفة. | [تحويل PowerPoint إلى TIFF](/slides/ar/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | حفظ الشرائح مع ملاحظات المتحدث إلى TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | تحويل الشرائح إلى مستند Word عندما تحتاج إلى مخرجات بنمط مستند. | [تحويل PowerPoint إلى Word](/slides/ar/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | استخراج محتوى العرض إلى Markdown للتوثيق وسير العمل النصي. | [تحويل PowerPoint إلى Markdown](/slides/ar/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى GIF متحرك](/slides/ar/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | إنشاء سير عمل تصدير فيديو من شرائح العرض. | [تحويل PowerPoint إلى فيديو](/slides/ar/cpp/convert-powerpoint-to-video/) |
| Presentation to XAML | تصدير الشرائح إلى XAML لسيناريوهات واجهة المستخدم C++. | [تصدير العروض إلى XAML](/slides/ar/cpp/export-to-xaml/) |

لقائمة أوسع من صيغ الإدخال والإخراج، انظر [صيغ الملفات المدعومة](/slides/ar/cpp/supported-file-formats/).

## **تحويل PowerPoint وOpenDocument**

يدعم Aspose.Slides for C++ التحويل من صيغ العروض الشائعة مثل PPT وPPTX وPPS وPPSX وPOT وPOTX وODP. يتم استخدام نفس واجهة برمجة التطبيقات للتحويل بين PowerPoint وOpenDocument، لذا يمكن عادةً تطبيق سير عمل حفظ ملف PPTX إلى PDF على ملف ODP بتغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، تذكر أن تطبيقات PowerPoint وOpenDocument لا تدعم كل ميزات التخطيط والتنسيق بنفس الطريقة. إذا تم إنشاء ملف ODP في LibreOffice أو OpenOffice Impress، راجع النتيجة واستخدم الخيارات الموضحة في [Convert OpenDocument Presentations](/slides/ar/cpp/convert-openoffice-odp/) عندما تحتاج إلى إرشادات خاصة بالصيغ.

## **تحويل PPT إلى PPTX**

PPT هو صيغة PowerPoint الثنائية القديمة، بينما PPTX هو صيغة Office Open XML الحديثة. يدعم Aspose.Slides for C++ تحويلًا عالي الدقة من PPT إلى PPTX مع الحفاظ على هياكل العرض المعقدة مثل القوالب، التخطيطات، الشرائح، المخططات، الأشكال المجمعة، العناصر النائبة، إطارات النص، القوام، وتعبئات الصور.

للتفاصيل، انظر [تحويل PPT إلى PPTX](/slides/ar/cpp/convert-ppt-to-pptx/).

## **تصدير ثابت التخطيط**

PDF وXPS وTIFF مفيدة عندما يجب أن يبدو الناتج متطابقًا عبر الأجهزة ولا ينبغي تحريره كعرض تقديمي. تشرح مقالات PDF وXPS وTIFF كيفية التحكم في التوافق، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، تنسيق البكسل، وحجم الإخراج.

## **تصدير HTML والصور**

تصدير HTML وHTML5 مفيد للعرض عبر المتصفح، النشر على الويب، والمشاركة الخفيفة. تصدير الصور مفيد عندما يجب أن تتحول كل شريحة إلى معاينة منفصلة أو صورة مصغرة أو أصل شريطي. استخدم مقالات PNG وJPG وSVG للحصول على إرشادات تصيير خاصة بالصيغ.

## **الأسئلة الشائعة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض؟**

لا. Aspose.Slides for C++ مكتبة مستقلة ولا تتطلب Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل العديد من العروض دفعة واحدة؟**

نعم. حمّل كل عرض، احفظه بالصيفة المطلوبة، وتخلص من كائن العرض بعد المعالجة. للمعالجة المتوازية، استخدم نسخًا منفصلة من كائن العرض واتبع إرشادات [متعددة الخيوط](/slides/ar/cpp/multithreading/).

**هل يمكنني تصدير شرائح مختارة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير فهارس الشرائح أو تصيير شرائح فردية، حسب صيغة الإخراج. انظر المقالة المخصصة للصيغة المستهدفة.

**هل يمكنني تضمين الشرائح المخفية عند التصدير إلى PDF أو XPS؟**

نعم. استخدم إعدادات تصدير الشرائح المخفية الموضحة في مقالات [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) و [XPS](/slides/ar/cpp/convert-powerpoint-to-xps/).

**هل يمكنني إنشاء مخرجات PDF/A؟**

نعم. تتوفر إعدادات التوافق لملف PDF. راجع [تحويل PowerPoint إلى PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) للتفاصيل.

**كيف يتم التعامل مع الخطوط أثناء التحويل؟**

يمكن لـ Aspose.Slides استخدام الخطوط المدمجة، fallback للخطوط، وإعدادات استبدال الخطوط. راجع [خط مدمج](/slides/ar/cpp/embedded-font/)، [Fallback Font](/slides/ar/cpp/fallback-font/)، و [استبدال الخط](/slides/ar/cpp/font-substitution/).
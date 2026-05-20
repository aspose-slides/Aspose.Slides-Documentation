---
title: تحويل العروض التقديمية إلى صيغ متعددة في C++
linktitle: تحويل العرض التقديمي
type: docs
weight: 70
url: /ar/cpp/convert-presentation/
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
- C++
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint وOpenDocument إلى PPTX وPDF وHTML والصور وXPS وTIFF وغيرها باستخدام Aspose.Slides for C++."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for C++ تحميل عروض PowerPoint وOpenDocument وتخزينها أو تحويلها إلى العديد من الصيغ الأخرى دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، وتصدير العروض إلى مستندات ثابتة التخطيط مثل PDF وXPS، ونشر الشرائح كـ HTML، أو تحويل الشرائح إلى ملفات صور للمعاينات، المصغرات، والأرشفة.

تستخدم معظم عمليات تحويل المستندات نفس سير العمل العام: تحميل ملف المصدر، اختيار الصيغة المطلوبة للإخراج، وتطبيق الخيارات الخاصة بالصورة عند الحاجة. بالنسبة لصيغ الصور، يتم تحويل كل شريحة على حدة ثم حفظها كصورة نقطية أو متجهة. توفر المقالات المخصصة أدناه تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه للحصول على أمثلة C++ كاملة وخيارات خاصة بالصيغ.

| السيناريو | استخدمه عندما تحتاج إلى | المقال |
| --- | --- | --- |
| PPT/PPTX/ODP إلى PPTX | تحديث ملفات PPT القديمة، توحيد ملفات PPTX الحالية، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/cpp/convert-ppt-to-pptx/), [تحويل ODP إلى PPTX](/slides/ar/cpp/convert-odp-to-pptx/), [حفظ العروض](/slides/ar/cpp/save-presentation/) |
| PPTX إلى PPT | احفظ عرض PowerPoint الحديث إلى صيغة PPT الثنائية القديمة لتوافق مع سير عمل أقدم. | [تحويل PPTX إلى PPT](/slides/ar/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP إلى PDF | إنشاء مستندات محمولة، قابلة للبحث، ثابتة التخطيط للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP إلى PDF مع الملاحظات | تصدير ملاحظات المتحدث مع محتوى الشريحة. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP إلى HTML | نشر العروض كصفحات HTML والتحكم في الصور، الخطوط، الملاحظات، وخيارات التخطيط المتجاوب. | [تحويل PowerPoint إلى HTML](/slides/ar/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP إلى HTML5 | تصدير الشرائح إلى HTML5 للعرض عبر المتصفح مع الحفاظ على التنسيق والتفاعل. | [تحويل العروض إلى HTML5](/slides/ar/cpp/export-to-html5/) |
| PPT/PPTX/ODP إلى PNG | تحويل كل شريحة إلى صورة PNG للمعاينات، المصغرات، أو إخراج الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP إلى JPG | تحويل الشرائح إلى صور JPG والتحكم في أبعاد الصورة وجودتها. | [تحويل PowerPoint إلى JPG](/slides/ar/cpp/convert-powerpoint-to-jpg/) |
| Slide إلى SVG | تصدير شرائح فردية كرسومات متجهة قابلة للتكبير. | [تحويل الشريحة إلى SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP إلى XPS | إنشاء مستندات XPS ذات تخطيط ثابت. | [تحويل PowerPoint إلى XPS](/slides/ar/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP إلى TIFF | حفظ عرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو الأرشفة. | [تحويل PowerPoint إلى TIFF](/slides/ar/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP إلى TIFF مع الملاحظات | حفظ الشرائح مع ملاحظات المتحدث إلى TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX إلى Word | تحويل الشرائح إلى مستند Word عندما تحتاج إلى إخراج بنمط مستند. | [تحويل PowerPoint إلى Word](/slides/ar/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX إلى Markdown | استخراج محتوى العرض إلى Markdown للتوثيق وسير العمل النصي. | [تحويل PowerPoint إلى Markdown](/slides/ar/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX إلى GIF متحرك | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى GIF متحرك](/slides/ar/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX إلى فيديو | إنشاء سير عمل لتصدير الفيديو من شرائح العرض. | [تحويل PowerPoint إلى فيديو](/slides/ar/cpp/convert-powerpoint-to-video/) |
| Presentation إلى XAML | تصدير الشرائح إلى XAML لسيناريوهات واجهة مستخدم C++. | [تصدير العروض إلى XAML](/slides/ar/cpp/export-to-xaml/) |

للحصول على قائمة أوسع من صيغ الإدخال والإخراج، راجع [الصيغ المدعومة للملفات](/slides/ar/cpp/supported-file-formats/).

## **تحويل PowerPoint وOpenDocument**

يدعم Aspose.Slides for C++ التحويل من صيغ العروض الشائعة مثل PPT وPPTX وPPS وPPSX وPOT وPOTX وODP. يتم استخدام نفس واجهة برمجة التطبيقات للتحويل للملفات PowerPoint وOpenDocument، لذا يمكن عادةً تطبيق سير عمل يحفظ ملف PPTX إلى PDF على ملف ODP بتغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، يجب أن تتذكر أن تطبيقات PowerPoint وOpenDocument لا تدعم كل ميزات التخطيط والتنسيق بنفس الطريقة تمامًا. إذا تم إنشاء ملف ODP في LibreOffice أو OpenOffice Impress، راجع النتيجة واستخدم الخيارات الموضحة في [تحويل عروض OpenDocument](/slides/ar/cpp/convert-openoffice-odp/) عندما تحتاج إلى إرشادات خاصة بالصيغ.

## **تحويل PPT إلى PPTX**

PPT هو صيغة PowerPoint الثنائية القديمة، بينما PPTX هي صيغة Office Open XML الحديثة. يدعم Aspose.Slides for C++ تحويل PPT إلى PPTX بدقة عالية مع الحفاظ على هياكل العرض المعقدة مثل القوالب الأساسية، التخطيطات، الشرائح، المخططات، الأشكال المجمعة، العناصر النائبية، إطارات النص، القوام، وتعبئة الصور.

للتفاصيل، راجع [تحويل PPT إلى PPTX](/slides/ar/cpp/convert-ppt-to-pptx/).

## **تصدير تخطيط ثابت**

تعتبر صيغ PDF وXPS وTIFF مفيدة عندما يجب أن يكون المخرجات متطابقة عبر الأجهزة ولا يجب تحريرها كعرض تقديمي. توضح المقالات المخصصة لـ PDF وXPS وTIFF كيفية التحكم في الامتثال، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، تنسيق البكسل، وحجم الإخراج.

## **تصدير HTML والصور**

يعد تصدير HTML وHTML5 مفيدًا للعرض في المتصفح، النشر على الويب، والمشاركة الخفيفة. تصدير الصور مفيد عندما يجب أن تتحول كل شريحة إلى معاينة منفصلة، صورة مصغرة، أو عنصر نقطي. استخدم مقالات PNG وJPG وSVG للحصول على إرشادات خاصة بتصيير كل صيغة.

## **الأسئلة المتداولة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض؟**

لا. Aspose.Slides for C++ مكتبة مستقلة ولا تتطلب Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل عدة عروض دفعةً واحدة؟**

نعم. قم بتحميل كل عرض، احفظه بالصيغة المطلوبة، وتخلص من كائن العرض بعد المعالجة. للمعالجة المتوازية، استخدم مثيلات عرض منفصلة وتبع إرشادات [المعالجة المتعددة](/slides/ar/cpp/multithreading/).

**هل يمكنني تصدير شرائح مختارة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير فهارس الشرائح أو تصيير شرائح منفردة، حسب صيغة الإخراج. راجع المقال المخصص للصيغة المستهدفة.

**هل يمكنني تضمين الشرائح المخفية عند التصدير إلى PDF أو XPS؟**

نعم. استخدم إعدادات تصدير الشرائح المخفية الموضحة في مقالات التحويل [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) و[XPS](/slides/ar/cpp/convert-powerpoint-to-xps/).

**هل يمكنني إنشاء مخرجات PDF/A؟**

نعم. تتوفر إعدادات الامتثال لـ PDF لتصدير PDF. راجع [تحويل PowerPoint إلى PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) للحصول على التفاصيل.

**كيف يتم التعامل مع الخطوط أثناء التحويل؟**

يمكن لـ Aspose.Slides استخدام الخطوط المضمنة، fallback الخط، وإعدادات استبدال الخط. راجع [Embedded Font](/slides/ar/cpp/embedded-font/)، [Fallback Font](/slides/ar/cpp/fallback-font/)، و[Font Substitution](/slides/ar/cpp/font-substitution/).
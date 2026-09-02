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
description: "تحويل عروض PowerPoint وOpenDocument إلى PPTX وPDF وHTML وصور وXPS وTIFF وغير ذلك باستخدام Aspose.Slides for C++."
---
## **نظرة عامة**

Aspose.Slides for C++ يمكنه تحميل عروض PowerPoint وOpenDocument وحفظها أو عرضها بصيغ أخرى كثيرة دون الحاجة إلى Microsoft PowerPoint أو OpenOffice أو LibreOffice. يمكنك تحويل ملفات PPT القديمة إلى PPTX الحديثة، تصدير العروض إلى مستندات ذات تنسيق ثابت مثل PDF وXPS، نشر الشرائح كـ HTML، أو عرض الشرائح كملفات صورة للمعاينات، المصغرات، والأرشفة.

معظم عمليات تحويل المستندات تتبع نفس سير العمل العام: تحميل ملف المصدر، اختيار الصيغة المطلوبة، وتطبيق الخيارات الخاصة بالصيغة عند الحاجة. بالنسبة لصيغ الصور، يتم عرض كل شريحة بشكل منفصل ثم حفظها كصورة نقطية أو متجهة. المقالات المخصصة المرتبطة أدناه توضح تفاصيل التنفيذ لكل حالة.

## **اختر سيناريو التحويل**

استخدم المقالات أدناه للحصول على أمثلة C++ كاملة وخيارات خاصة بالصيغة.

| السيناريو | استخدمه عندما تحتاج إلى | المقال |
| --- | --- | --- |
| PPT/PPTX/ODP إلى PPTX | تحديث ملفات PPT القديمة، توحيد ملفات PPTX الحالية، أو تحويل عروض OpenDocument إلى PowerPoint PPTX. | [تحويل PPT إلى PPTX](/slides/ar/cpp/convert-ppt-to-pptx/),[تحويل ODP إلى PPTX](/slides/ar/cpp/convert-odp-to-pptx/),[ حفظ العروض](/slides/ar/cpp/save-presentation/) |
| PPTX إلى PPT | حفظ عرض PowerPoint الحديث بتنسيق PPT الثنائي القديم لتوافق مع سير العمل القديم. | [تحويل PPTX إلى PPT](/slides/ar/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP إلى PDF | إنشاء مستندات ثابتة، قابلة للبحث، للمشاركة أو الطباعة أو الأرشفة. | [تحويل PowerPoint إلى PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP إلى PDF مع الملاحظات | تصدير ملاحظات المتحدث مع محتوى الشريحة. | [تحويل PowerPoint إلى PDF مع الملاحظات](/slides/ar/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP إلى HTML | نشر العروض كصفحات HTML والتحكم في الصور، الخطوط، الملاحظات، وخيارات التخطيط المتجاوب. | [تحويل PowerPoint إلى HTML](/slides/ar/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP إلى HTML5 | تصدير الشرائح إلى HTML5 للعرض في المتصفح مع الحفاظ على التنسيق والتفاعلية. | [تصدير العروض إلى HTML5](/slides/ar/cpp/export-to-html5/) |
| PPT/PPTX/ODP إلى PNG | عرض كل شريحة كصورة PNG للمعاينات أو المصغرات أو ناتج الويب. | [تحويل PowerPoint إلى PNG](/slides/ar/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP إلى JPG | عرض الشرائح كصور JPG والتحكم في أبعاد وجودة الصورة. | [تحويل PowerPoint إلى JPG](/slides/ar/cpp/convert-powerpoint-to-jpg/) |
| الشريحة إلى SVG | تصدير شرائح فردية كرسوميات متجهة قابلة للتوسيع. | [عرض الشريحة كـ SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP إلى XPS | إنشاء مستندات XPS ذات تخطيط ثابت. | [تحويل PowerPoint إلى XPS](/slides/ar/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP إلى TIFF | حفظ عرض كملف TIFF متعدد الصفحات للطباعة أو المسح أو الفاكس أو الأرشفة. | [تحويل PowerPoint إلى TIFF](/slides/ar/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP إلى TIFF مع الملاحظات | حفظ الشرائح مع ملاحظات المتحدث إلى TIFF. | [تحويل PowerPoint إلى TIFF مع الملاحظات](/slides/ar/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX إلى Word | تحويل الشرائح إلى مستند Word عندما تحتاج مخرجات بنمط المستند. | [تحويل PowerPoint إلى Word](/slides/ar/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX إلى Markdown | استخراج محتوى العرض إلى Markdown للتوثيق وسير العمل النصي. | [تحويل PowerPoint إلى Markdown](/slides/ar/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP إلى XML | إنشاء عرض PowerPoint XML نصي للفحص أو المقارنة أو استكشاف الأخطاء أو سير العمل القائم على XML. | [تحويل PowerPoint إلى XML](/slides/ar/cpp/convert-powerpoint-to-xml/) |
| PPT/PPTX إلى GIF متحرك | إنشاء GIF متحرك من الشرائح. | [تحويل PowerPoint إلى GIF متحرك](/slides/ar/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX إلى فيديو | بناء سير عمل تصدير فيديو من شرائح العرض. | [تحويل PowerPoint إلى فيديو](/slides/ar/cpp/convert-powerpoint-to-video/) |
| العرض إلى XAML | تصدير الشرائح إلى XAML لسيناريوهات واجهة المستخدم C++. | [تصدير العروض إلى XAML](/slides/ar/cpp/export-to-xaml/) |

لقائمة أوسع من صيغ الإدخال والإخراج، راجع [الصيغ المدعومة](/slides/ar/cpp/supported-file-formats/).

## **تحويل PowerPoint وOpenDocument**

Aspose.Slides for C++ يدعم التحويل من صيغ العروض الشائعة مثل PPT وPPTX وPPS وPPSX وPOT وPOTX وODP. يتم استخدام نفس واجهة برمجة التحويل لملفات PowerPoint وOpenDocument، لذا يمكن عادةً تطبيق سير عمل يحفظ ملف PPTX إلى PDF على ملف ODP بتغيير ملف الإدخال فقط.

عند تحويل ملفات ODP، تذكر أن تطبيقات PowerPoint وOpenDocument لا تدعم كل تخطيط وميزة تنسيق بنفس الطريقة تمامًا. إذا تم إنشاء ملف ODP في LibreOffice أو OpenOffice Impress، راجع المخرجات واستخدم الخيارات المذكورة في [تحويل عروض OpenDocument](/slides/ar/cpp/convert-openoffice-odp/) عندما تحتاج إرشادات خاصة بالصيغة.

## **تحويل PPT إلى PPTX**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Office Open XML الحديث. Aspose.Slides for C++ يدعم تحويل PPT إلى PPTX بأعلى دقة مع الحفاظ على هياكل العرض المعقدة مثل القوالب، التخطيطات، الشرائح، المخططات، الأشكال المجمعة، العناصر النائبة، إطارات النص، القوام، وتعبئات الصور.

للتفاصيل، راجع [تحويل PPT إلى PPTX](/slides/ar/cpp/convert-ppt-to-pptx/).

## **تصدير بتنسيق ثابت**

PDF وXPS وTIFF مفيدة عندما يجب أن يبقى المخرجات متطابقة عبر الأجهزة ولا يجب تحريرها كعرض تقديمي. المقالات المخصصة لـ PDF وXPS وTIFF تشرح كيفية التحكم في الامتثال، الشرائح المخفية، الملاحظات، جودة الصورة، الضغط، تنسيق البكسل، وحجم المخرجات.

## **تصدير HTML وصور**

تصدير HTML وHTML5 مفيد للعرض في المتصفح، النشر على الويب، والمشاركة الخفيفة. تصدير الصور مفيد عندما يجب أن تصبح كل شريحة معاينة أو مصغرة أو أصل نقطي منفصل. استخدم مقالات PNG وJPG وSVG للحصول على إرشادات عرض خاصة بالصيغ.

## **الأسئلة المتكررة**

**هل أحتاج إلى Microsoft PowerPoint لتحويل العروض؟**

لا. Aspose.Slides for C++ مكتبة مستقلة ولا تتطلب Microsoft PowerPoint أو أتمتة Office.

**هل يمكنني تحويل العديد من العروض دفعة واحدة؟**

نعم. قم بتحميل كل عرض، احفظه بالصيغ المطلوبة، وتخلص من كائن العرض بعد المعالجة. للمعالجة المتوازية، استخدم مثيلات عرض منفصلة واتبع إرشادات [multithreading](/slides/ar/cpp/multithreading/).

**هل يمكنني تصدير شرائح مختارة فقط؟**

نعم. تسمح عدة طرق تصدير بتمرير فهارس الشرائح أو عرض شرائح فردية، حسب صيغة المخرجات. راجع المقال المخصص للصيغة المستهدفة.

**هل يمكنني تضمين الشرائح المخفية عند التصدير إلى PDF أو XPS؟**

نعم. استخدم إعدادات تصدير الشرائح المخفية الموضحة في مقالات [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) و [XPS](/slides/ar/cpp/convert-powerpoint-to-xps/).

**هل يمكنني إنشاء مخرجات PDF/A؟**

نعم. تتوفر إعدادات الامتثال لـ PDF عند التصدير. راجع [تحويل PowerPoint إلى PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/) للتفاصيل.

**كيف يتم التعامل مع الخطوط أثناء التحويل؟**

Aspose.Slides يمكنه استخدام الخطوط المضمنة، fallback للخطوط، وإعدادات استبدال الخطوط. راجع [Embedded Font](/slides/ar/cpp/embedded-font/)،[Fallback Font](/slides/ar/cpp/fallback-font/)،[Font Substitution](/slides/ar/cpp/font-substitution/).
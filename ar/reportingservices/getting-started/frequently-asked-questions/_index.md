---
title: الأسئلة الشائعة
type: docs
weight: 110
url: /reportingservices/frequently-asked-questions/
---

{{% alert color="primary" %}} 

تجمع هذه الصفحة عددًا من الأسئلة الشائعة حول:

- [الصيغ المدعومة](#Supported-File-Formats).
- [الدعم لخدمات Power BI Reporting](#Support-for-Power-BI-Reporting-services).
- [التثبيت](#Installation).
- [تكوين التصدير](#Export-Configuration).

{{% /alert %}} 
### **الصيغ المدعومة**
#### **س: ما هي الصيغ التي يمكنك تصدير التقارير إليها باستخدام Aspose.Slides لخدمات Reporting؟**
**ج**: تجعل Aspose.Slides لخدمات Reporting من الممكن تصدير أي تقرير بصيغ PPT، PPS، PPTX، PPSX، XPS، أو RPL.
### **الدعم لخدمات Power BI Reporting**
#### **س: هل تدعم Aspose.Slides لخدمات Reporting Power BI؟**
**ج**: نعم. تدعم Aspose.Slides لخدمات Reporting تصدير التقارير المرقمة (RDL) إلى Power BI.
### **التثبيت**
#### **س: برنامج التثبيت لا يبدأ. التثبيت اليدوي لا يؤدي إلى النتيجة المرجوة.**
**ج**: تأكد من تثبيت .NET Framework 3.5 على نظامك.
#### **س: خيارات التصدير مفقودة بعد تثبيت Aspose.Slides لخدمات Reporting.**
**ج**: إذا كانت أي مجموعة كود في rssrvpolicy.config لا تعمل بشكل صحيح، قد يتم تخطي محلل ملف التكوين الأقسام الأخيرة من المجموعة. لذا قم بنقل جميع مجموعات الكود المرتبطة بـ Aspose.Slides لخدمات Reporting إلى أعلى الكتلة التي تحتوي على مجموعات كود Aspose.Slides لخدمات Reporting.
#### **س: تعذر تحميل الملف أو التجميع Aspose.Slides.ReportingServices (لا يمكن الحصول على إذن التنفيذ \ استثناء من HRESULT: 0x80131418).**
**ج**: تشير كود الخطأ (0x80131418) إلى أن وحدة dll ليس لديها حقوق كافية. قد يكون ذلك بسبب ميزة أمان منعت الوصول الكامل إلى ملف .dll إذا تم الحصول عليه من جهاز كمبيوتر آخر. يمكن إصلاح ذلك من خلال فتح نافذة خصائص ملف dll والنقر على زر "إلغاء الحظر" في لوحة "الأمان".
#### **س: لا يمكن العثور على الترخيص 'Aspose.Slides.Reporting.Services.lic'.**
**ج**: يجب أن يتواجد ملف الترخيص بجوار ملف dll أو في دليل Program Files(x86)\Aspose\Slides\.
### **تكوين التصدير**
#### **س: كيف يمكنني تغيير لون الروابط في تقرير مصدّر؟**
**ج**: لكل امتداد رسم تخطيطي في Aspose.Slides لخدمات Reporting في rsreportserver.config إعداداته الخاصة. لتغيير لون الرابط، قم بتعيين القيمة المطلوبة في قسم <HyperlinkColor>.
#### **س: في العروض التقديمية المصدرة، يتم تمديد النص في الجداول عموديًا.**
**ج**: يتم ذلك لتسهيل قراءة المستند. لعرض النص في الجدول كما يظهر في التقرير، قم بتعيين امتداد Aspose.Slides لخدمات Reporting المطلوب إلى "طبيعي" في ملف تكوين rsreportserver.config.
---
title: الدعم لمكتبة قابلة للإيقاف
type: docs
weight: 120
url: /php-java/support-for-interruptable-library/
---

## **المكتبة القابلة للإيقاف**
تم إضافة بنية InterruptionToken و فئة InterruptionTokenSource في Aspose.Slides. تدعم هذه الأنواع إيقاف المهام طويلة الأمد، مثل إلغاء التسلسل، التسلسل أو العرض. تمثل InterruptionTokenSource مصدر الرمز أو رموز متعددة تم تمريرها إلى **ILoadOptions.InterruptionToken**. عندما يتم تعيين ILoadOptions.InterruptionToken وتم تمرير هذه الحالة من LoadOptions إلى مُنشئ Presentation، سيتم إيقاف أي مهمة طويلة الأمد تتعلق بهذا العرض التقديمي عندما يتم استدعاء طريقة InterruptionTokenSource.Interrupt.

تظهر قطعة الكود أدناه إيقاف المهمة قيد التشغيل.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}
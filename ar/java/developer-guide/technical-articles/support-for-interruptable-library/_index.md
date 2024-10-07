---
title: الدعم للمكتبة القابلة للإيقاف
type: docs
weight: 120
url: /java/support-for-interruptable-library/
---

## **المكتبة القابلة للإيقاف**
تم الآن إضافة بنية InterruptionToken و فئة InterruptionTokenSource في Aspose.Slides. تدعم هذه الأنواع إيقاف المهام الطويلة الأمد، مثل إلغاء التسلسل، التسلسل أو العرض. تمثل InterruptionTokenSource مصدر الرموز أو عدة رموز يتم تمريرها إلى **ILoadOptions.InterruptionToken**. عندما يتم تعيين ILoadOptions.InterruptionToken وتتم تمرير مثيل LoadOptions هذا إلى منشئ Presentation، سيتم إيقاف أي مهمة طويلة الأمد تتعلق بهذه Presentation عندما يتم استدعاء طريقة InterruptionTokenSource.Interrupt.

توضح مقتطفات الشيفرة أدناه إيقاف مهمة قيد التشغيل.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}
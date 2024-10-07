---
title: تغيير حجم الأشكال في الشريحة
type: docs
weight: 110
url: /java/re-sizing-shapes-on-slide/
---

## **تغيير حجم الأشكال في الشريحة**
أحد الأسئلة الأكثر شيوعًا التي يطرحها عملاء Aspose.Slides لـ Java هو كيفية تغيير حجم الأشكال بحيث عند تغيير حجم الشريحة لا يتم قطع البيانات. توضح هذه النصيحة الفنية القصيرة كيفية تحقيق ذلك.

لتجنب تشويش الأشكال، يجب تحديث كل شكل في الشريحة وفقًا لحجم الشريحة الجديد.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

إذا كان هناك أي جدول في الشريحة، فإن الكود أعلاه قد لا يعمل بشكل مثالي. في هذه الحالة، يجب إعادة ضبط حجم كل خلية من خلايا الجدول.

{{% /alert %}} 

تحتاج إلى استخدام الكود التالي على جانبك إذا كنت بحاجة لتغيير حجم الشرائح ذات الجداول. إعداد عرض أو ارتفاع الجدول هو حالة خاصة في الأشكال حيث تحتاج إلى تعديل ارتفاع الصف الفردي وعرض العمود لتغيير ارتفاع الجدول وعرضه.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}
---
title: تغيير حجم الأشكال على الشريحة
type: docs
weight: 110
url: /ar/php-java/re-sizing-shapes-on-slide/
---

## **تغيير حجم الأشكال على الشريحة**
واحدة من أكثر الأسئلة تكرارًا التي يطرحها عملاء Aspose.Slides لـ PHP عبر Java هي كيفية تغيير حجم الأشكال بحيث عند تغيير حجم الشريحة لا يتم قطع البيانات. تُظهر هذه النصيحة التقنية القصيرة كيفية تحقيق ذلك.

لتجنب تشويه الأشكال، يجب تحديث كل شكل على الشريحة وفقًا لحجم الشريحة الجديد.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

إذا كان هناك أي جدول في الشريحة، فإن الكود أعلاه لن يعمل بشكل مثالي. في هذه الحالة، يجب تغيير حجم كل خلية من خلايا الجدول.

{{% /alert %}} 

تحتاج إلى استخدام الكود التالي على جانبك إذا كنت بحاجة إلى تغيير حجم الشرائح مع الجداول. يعتبر ضبط عرض أو ارتفاع الجدول حالة خاصة في الأشكال حيث تحتاج إلى تغيير ارتفاع الصف الفردي وعرض العمود لتغيير ارتفاع الجدول وعرضه.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}
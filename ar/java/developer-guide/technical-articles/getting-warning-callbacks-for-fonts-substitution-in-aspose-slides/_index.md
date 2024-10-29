---
title: الحصول على ردود تحذيرية لاستبدال الخطوط في Aspose.Slides
type: docs
weight: 90
url: /ar/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

تتيح Aspose.Slides لـ Java الحصول على ردود تحذيرية لاستبدال الخطوط في حال عدم توفر الخط المستخدم على الجهاز أثناء عملية العرض. تعتبر ردود التحذير مفيدة في تصحيح مشاكل الخطوط المفقودة أو غير المتاحة أثناء عملية العرض.

{{% /alert %}} 

توفر Aspose.Slides لـ Java طرق API بسيطة لاستقبال ردود التحذير أثناء عملية العرض. اتبع الخطوات أدناه لتكوين ردود التحذير:

1. أنشئ فئة ردود مخصصة لاستقبال الردود.
1. قم بإعداد ردود التحذير باستخدام فئة LoadOptions
1. قم بتحميل ملف العرض الذي يستخدم خطًا غير متوفر على جهاز الهدف الخاص بك.
1. قم بإنشاء صورة مصغرة للشريحة لرؤية التأثير.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}
---
title: الحصول على استدعاءات تحذيرية لاستبدال الخطوط في Aspose.Slides
type: docs
weight: 90
url: /ar/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

تتيح لك Aspose.Slides لـ PHP عبر Java الحصول على استدعاءات تحذيرية لاستبدال الخطوط في حالة عدم توفر الخط المستخدم على الجهاز أثناء عملية الرسم. تعتبر استدعاءات التحذير مفيدة في تصحيح مشاكل الخطوط المفقودة أو غير المتاحة أثناء عملية الرسم.

{{% /alert %}} 

تقدم Aspose.Slides لـ PHP عبر Java طرق API بسيطة لاستقبال استدعاءات التحذير أثناء عملية الرسم. اتبع الخطوات أدناه لتكوين استدعاءات التحذير:

1. أنشئ فئة استدعاء مخصصة لاستقبال الاستدعاءات.
1. قم بتعيين استدعاءات التحذير باستخدام فئة LoadOptions
1. قم بتحميل ملف العرض التقديمي الذي يستخدم خطًا للنص داخله غير متوفر على جهازك المستهدف.
1. قم بإنشاء صورة مصغرة للشرائح لرؤية التأثير.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}
---
title: إعداد العروض التوضيحية
type: docs
weight: 70
url: /ar/jasperreports/demos-setup/
---

جميع العروض التوضيحية المقدمة مع Aspose.Slides لـ JasperReports هي عروض توضيحية قياسية معدلة. من الأفضل نسخ جميع العروض التوضيحية إلى مجلد عروض JasperReports:
...\jasperreports-x.x.x\demo\samples\

استخدم تسلسل الأوامر القياسية لبناء وتصدير التقارير:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 

يرجى عدم نسيان تشغيل HSQLDB مع قاعدة البيانات الاختبارية لملء التقارير بالبيانات ونسخ aspose.slides.jasperreports.library-xx.x.jar من مجلد \lib\JasperReports X.X.X - X.X.X في aspose-slides-xx.x-jasperreports.zip إلى دليل &#60;InstallDir&#62;\lib.

{{% /alert %}} 

معظم العروض التوضيحية (باستثناء الرسوم البيانية) لديها بالفعل عروض تقديمية تم إنشاؤها، لذا يمكنك تخطي جميع خطوات "ant" والتحقق من النتائج على الفور.
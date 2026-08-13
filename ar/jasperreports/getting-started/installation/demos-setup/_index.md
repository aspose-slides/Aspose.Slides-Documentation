---
title: إعداد العروض التجريبية
type: docs
weight: 70
url: /ar/jasperreports/demos-setup/
---
جميع العروض التجريبية المقدمة مع Aspose.Slides لـ JasperReports هي عروض تجريبية قياسية تم تعديلها. من الأفضل نسخ جميع العروض التجريبية إلى مجلد تجارب JasperReports:
...\jasperreports-x.x.x\demo\samples\

استخدم تسلسل الأوامر القياسية لبناء وتصدير التقارير:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 
يرجى عدم نسيان تشغيل HSQLDB مع قاعدة البيانات التجريبية لملء التقارير بالبيانات ونسخ aspose.slides.jasperreports.library-xx.x.jar من المجلد \lib\JasperReports X.X.X - X.X.X داخل ملف aspose-slides-xx.x-jasperreports.zip إلى المجلد &#60;InstallDir&#62;\lib.
{{% /alert %}} 

معظم العروض التجريبية (باستثناء المخططات) لديها عروض تقديمية مُولدة بالفعل، لذا يمكنك تخطي جميع خطوات “ant” والتحقق من النتائج فورًا.
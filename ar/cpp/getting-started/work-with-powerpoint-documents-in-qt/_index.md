---
title: العمل مع مستندات PowerPoint في Qt
type: docs
weight: 60
url: /ar/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- مُنشئ Qt
- تطبيق Qt
- متعدد المنصات
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "استخدم Aspose.Slides لـ C++ مع Qt Creator و Visual Studio لإنشاء وتحميل وتعديل عروض PowerPoint و OpenDocument في تطبيقات متعددة المنصات."
---
## **المقدمة**

Qt هو إطار عمل لتطوير التطبيقات يعتمد على C++ ومتعدد المنصات يُستخدم على نطاق واسع لتطوير مجموعة متنوعة من تطبيقات سطح المكتب والهواتف المحمولة والأنظمة المدمجة. يمكن دمج Aspose.Slides لـ C++ داخل Qt لإنشاء ومعالجة مستندات PowerPoint في تطبيقات Qt الخاصة بك.

## **استخدام Aspose.Slides لـ C++ داخل Qt Creator**

لاستخدام Aspose.Slides لـ C++ في تطبيق Qt الخاص بك، قم بتحميل أحدث إصدار من الـ API من قسم [downloads](https://downloads.aspose.com/slides/ar/cpp). بمجرد تحميل الـ API، يمكنك دمج مكتبة C++ داخل Qt Creator أو Visual Studio.

لدمج واستخدام مكتبة Aspose.Slides لـ C++ داخل تطبيق Qt Console تم تطويره في Qt Creator، يرجى اتباع الخطوات التالية:

- افتح Qt Creator وأنشئ *Qt Console Application* جديدًا.

![تطبيق وحدة التحكم Qt](qt-console-application.png)

- اختر خيار QMake من القائمة المنسدلة *Build System*.

![اختيار QMake في Qt Creator](qt-console-application-qmake.png)

- اختر المجموعة المناسبة وأكمل المعالج.
- انسخ مجلد **aspose-slides-cpp-21.02** من حزمة Aspose.Slides لـ C++ المستخرجة إلى جذر المشروع.

![ملفات المكتبة](aspose.slides-lib-files.png)

- لإضافة مسارات المكتبة ومجلدات include، انقر بزر الماوس الأيمن على المشروع في اللوحة اليسرى واختر *Add Library*.

![إضافة مكتبة في Qt](qt_add_library.png)

- اختر خيار External Library وتصفح المسارات إلى مجلدات include و lib واحدةً تلو الأخرى.

![إضافة مكتبة خارجية](qt-add-external-library.png)

- بعد الانتهاء، سيحتوي ملف *.pro* الخاص بالمشروع على الإدخالات التالية:

![ملف .pro في Qt](qt-pro-file.png)

- قم ببناء التطبيق وقد انتهيت من الدمج.  

{{% alert color="info" %}}

ملاحظة: راجع [مشروع العرض الكامل](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) لمزيد من المعلومات.

{{% /alert %}}

## **استخدام Aspose.Slides لـ C++ في تطبيقات Qt داخل Visual Studio**

لتطوير تطبيق Qt باستخدام Visual Studio، تحتاج إلى تثبيت [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). بعد التثبيت، قم بتحميل أحدث إصدار من الـ API من قسم [downloads](https://downloads.aspose.com/slides/ar/cpp) واتبع الخطوات التالية:

- افتح Microsoft Visual Studio وأنشئ *Qt Console Application* جديدًا.

![تطبيق وحدة التحكم في Visual Studio](vs-console-application.png)

- اختر المجموعة المناسبة وأكمل المعالج.
- لدمج واستخدام مكتبة Aspose.Slides لـ C++، انقر بزر الماوس الأيمن على المشروع واختر *Manage NuGet Packages...*.

![إدارة حزم NuGet في Visual Studio](vs-manage-nuget-package.png)

- ابحث عن الحزمة *Aspose.Slides.Cpp* المطلوبة وقم بتثبيتها.

![البحث عن حزمة Aspose.Slides.Cpp في Visual Studio](vs-find-nuget.png)

- قم ببناء المشروع وقد انتهيت من الدمج.  

{{% alert color="info" %}}

ملاحظة: راجع [مشروع العرض الكامل](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) لمزيد من المعلومات.

{{% /alert %}}
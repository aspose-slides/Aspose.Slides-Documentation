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
description: "استخدم Aspose.Slides لـ C++ مع Qt Creator و Visual Studio لإنشاء وتحميل وتحرير عروض PowerPoint و OpenDocument في تطبيقات متعددة المنصات."
---

Qt هو إطار عمل لتطوير التطبيقات متعدد المنصات يعتمد على C++ ويستخدم على نطاق واسع لتطوير مجموعة متنوعة من تطبيقات سطح المكتب والهواتف المحمولة والأنظمة المدمجة. يمكن دمج Aspose.Slides لـ C++ داخل Qt لإنشاء ومعالجة مستندات PowerPoint في تطبيقات Qt الخاصة بك.

## **استخدام Aspose.Slides لـ C++ داخل Qt Creator**

لاستخدام Aspose.Slides لـ C++ في تطبيق Qt الخاص بك، قم بتنزيل أحدث نسخة من واجهة برمجة التطبيقات من قسم [التنزيلات](https://downloads.aspose.com/slides/cpp). بعد تنزيل واجهة برمجة التطبيقات، يمكنك دمج مكتبة C++ داخل Qt Creator أو Visual Studio.

لدمج واستخدام مكتبة Aspose.Slides لـ C++ داخل تطبيق Qt Console تم تطويره في Qt Creator، يرجى اتباع الخطوات التالية:

- افتح Qt Creator وأنشئ *Qt Console Application* جديدًا.

![qt_console_application](qt-console-application.png)

- اختر خيار QMake من القائمة المنسدلة *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- اختر المجموعة المناسبة وأنهِ المعالج.
- انسخ مجلد **aspose-slides-cpp-21.02** من الحزمة المستخرجة لـ Aspose.Slides لـ C++ إلى جذر المشروع.

![lib_files](aspose.slides-lib-files.png)

- لإضافة مسارات إلى مجلدي lib و include، انقر بزر الماوس الأيمن على المشروع في اللوحة اليسرى وحدد *Add Library*.

![qt_add_library](qt_add_library.png)

- اختر خيار External Library وتصفح المسارات إلى مجلدي include و lib واحدة تلو الأخرى.

![todo:image_alt_text](qt-add-external-library.png)

- بعد الانتهاء، سيحتوي ملف المشروع .pro على الإدخالات التالية:

![qt_pro_file.png](qt-pro-file.png)

- ابنِ التطبيق وقد انتهيت من الدمج.  

{{% alert color="primary" %}}

ملاحظة: راجع [مشروع العرض الكامل](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) للحصول على مزيد من المعلومات.

{{% /alert %}}

## **استخدام Aspose.Slides لـ C++ في تطبيقات Qt داخل Visual Studio**

لتطوير تطبيق Qt باستخدام Visual Studio، تحتاج إلى تثبيت [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). بعد التثبيت، قم بتنزيل أحدث نسخة من واجهة برمجة التطبيقات من قسم [التنزيلات](https://downloads.aspose.com/slides/cpp) واتبع الخطوات التالية:

- افتح Microsoft Visual Studio وأنشئ *Qt Console Application* جديدًا.

![VS_Console_Application.png](vs-console-application.png)

- اختر المجموعة المناسبة وأنهِ المعالج.
- لدمج واستخدام مكتبة Aspose.Slides لـ C++، انقر بزر الماوس الأيمن على المشروع وحدد *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- ابحث عن الحزمة *Aspose.Slides.Cpp* المطلوبة وقم بتثبيتها.

![VS_Find_Nuget.png](vs-find-nuget.png)

- ابنِ المشروع وقد انتهيت من الدمج.  

{{% alert color="primary" %}}

ملاحظة: راجع [مشروع العرض الكامل](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) للحصول على مزيد من المعلومات.

{{% /alert %}}
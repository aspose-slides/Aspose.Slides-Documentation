---
title: العمل مع مستندات PowerPoint في Qt
type: docs
description: "يمكن دمج Aspose.Slides لـ C++ داخل Qt لإنشاء والتلاعب بمستندات PowerPoint في تطبيقات Qt."
keywords: "إنشاء مستند في Qt Creator، تحميل مستند في Qt Creator، استخدام Aspose C++ مع Qt Creator، تحميل مستند Aspose C++، تحميل التنسيقات المدعومة من Aspose.Slides C++"
weight: 60
url: /cpp/work-with-powerpoint-documents-in-qt/
---

Qt هو إطار تطوير تطبيقات متعدد المنصات قائم على C++ ويستخدم على نطاق واسع لتطوير مجموعة متنوعة من تطبيقات سطح المكتب و الهواتف المحمولة والأنظمة المضمنة. يمكن دمج Aspose.Slides لـ C++ داخل Qt من أجل إنشاء والتلاعب بمستندات PowerPoint في تطبيقات Qt الخاصة بك.

## استخدام Aspose.Slides لـ C++ داخل Qt Creator

من أجل استخدام Aspose.Slides لـ C++ في تطبيق Qt الخاص بك، قم بتحميل أحدث إصدار من واجهة البرمجة من قسم [التحميلات](https://downloads.aspose.com/slides/cpp). بمجرد تحميل واجهة البرمجة، يمكنك دمج مكتبة C++ داخل Qt Creator أو Visual Studio.

من أجل دمج واستخدام مكتبة Aspose.Slides لـ C++ داخل تطبيق وحدة التحكم Qt الذي تم تطويره في Qt Creator، يرجى اتباع الخطوات التالية:

- افتح Qt Creator وأنشئ *تطبيق وحدة تحكم Qt* جديد.

![qt_console_application](qt-console-application.png)

- اختر خيار QMake من قائمة *نظام البناء* المنسدلة.

![qt_console_application_qmake](qt-console-application-qmake.png)

- اختر المجموعة المناسبة وانهي المعالج.
- انسخ مجلد aspose-slides-cpp-21.02 من الحزمة المستخرجة من Aspose.Slides لـ C++ إلى جذر المشروع.

![lib_files](aspose.slides-lib-files.png)

- لإضافة مسارات إلى مجلدات lib وinclude، انقر بزر الماوس الأيمن على المشروع في لوحة LHS واختر *إضافة مكتبة*.

![qt_add_library](qt_add_library.png)

- اختر خيار المكتبة الخارجية وتصفح المسارات لإضافة مجلدات lib واحدة تلو الأخرى.

![todo:image_alt_text](qt-add-external-library.png)

- بمجرد الانتهاء، ستحتوي ملف .pro للمشروع على الإدخالات التالية:

![qt_pro_file.png](qt-pro-file.png)

- قم ببناء التطبيق وقد انتهيت من الدمج.  

{{% alert color="primary" %}}

ملاحظة: راجع [مشروع العرض التوضيحي الكامل](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) لمزيد من المعلومات.

{{% /alert %}}

## استخدام Aspose.Slides لـ C++ في تطبيقات Qt داخل Visual Studio

من أجل تطوير تطبيق Qt باستخدام Visual Studio، تحتاج إلى تثبيت [أدوات Qt Visual Studio](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). بمجرد أن يكون لديك التثبيت، قم بتحميل أحدث إصدار من واجهة البرمجة من قسم [التحميلات](https://downloads.aspose.com/slides/cpp) واتبع الخطوات التالية:

- افتح Microsoft Visual Studio وأنشئ *تطبيق وحدة تحكم Qt* جديد.

![VS_Console_Application.png](vs-console-application.png)

- اختر المجموعة المناسبة وانهي المعالج.
- من أجل دمج واستخدام مكتبة Aspose.Slides لـ C++، انقر بزر الماوس الأيمن على المشروع واختر *إدارة حزم NuGet...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- ابحث وثبت الحزمة المطلوبة *Aspose.Slides.Cpp*.

![VS_Find_Nuget.png](vs-find-nuget.png)

- قم ببناء المشروع وقد انتهيت من الدمج.  

{{% alert color="primary" %}}

ملاحظة: راجع [مشروع العرض التوضيحي الكامل](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) لمزيد من المعلومات.

{{% /alert %}}
---
title: کار با اسناد PowerPoint در Qt
type: docs
weight: 60
url: /fa/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt سازنده
- برنامه Qt
- چندسکویی
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "از Aspose.Slides برای C++ همراه با Qt Creator و Visual Studio برای ایجاد، بارگذاری و ویرایش ارائه‌های PowerPoint و OpenDocument در برنامه‌های چندسکویی استفاده کنید."
---
## **معرفی**

Qt یک چارچوب توسعه برنامه‌های کاربردی چندسکویی مبتنی بر C++ است که به‌طور گسترده برای توسعه انواع برنامه‌های دسکتاپ، موبایل و سیستم‌های تعبیه‌شده استفاده می‌شود. Aspose.Slides برای C++ می‌تواند در داخل Qt یکپارچه شود تا اسناد PowerPoint را در برنامه‌های Qt خود ایجاد و دستکاری کنید.

## **استفاده از Aspose.Slides برای C++ در Qt Creator**

برای استفاده از Aspose.Slides برای C++ در برنامه Qt خود، آخرین نسخه API را از بخش [downloads](https://downloads.aspose.com/slides/fa/cpp) دانلود کنید. پس از دانلود API، می‌توانید کتابخانه C++ را در Qt Creator یا Visual Studio یکپارچه کنید.

برای یکپارچه‌سازی و استفاده از کتابخانه Aspose.Slides برای C++ در یک برنامه کنسول Qt که در Qt Creator توسعه یافته است، مراحل زیر را دنبال کنید:

- Qt Creator را باز کنید و یک *Qt Console Application* جدید ایجاد کنید.

![برنامه_کنسول_Qt](qt-console-application.png)

- گزینه QMake را از فهرست کشویی *Build System* انتخاب کنید.

![qt_console_application_qmake](qt-console-application-qmake.png)

- کیت مناسب را انتخاب کنید و راه‌انداز را پایان دهید.
- پوشه aspose‑slides‑cpp‑21.02 را از بسته استخراج‌شده Aspose.Slides برای C++ به ریشه پروژه کپی کنید.

![lib_files](aspose.slides-lib-files.png)

- برای افزودن مسیرها به پوشه‌های lib و include، روی پروژه در پنل سمت چپ کلیک راست کنید و *Add Library* را انتخاب کنید.

![qt_add_library](qt_add_library.png)

- گزینه External Library را انتخاب کنید و مسیرهای پوشه‌های include و lib را یکی‌یکی مرور کنید.

![todo:image_alt_text](qt-add-external-library.png)

- پس از اتمام، فایل .pro پروژه شما شامل ورودی‌های زیر خواهد بود:

![qt_pro_file.png](qt-pro-file.png)

- برنامه را ساخت کنید و یکپارچه‌سازی تمام شد.  

{{% alert color="primary" %}}

توجه: برای اطلاعات بیشتر به [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) مراجعه کنید.

{{% /alert %}}

## **استفاده از Aspose.Slides برای C++ در برنامه‌های Qt با Visual Studio**

برای توسعه یک برنامه Qt با استفاده از Visual Studio، باید [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123) را نصب کنید. پس از نصب، آخرین نسخه API را از بخش [downloads](https://downloads.aspose.com/slides/fa/cpp) دانلود کنید و مراحل زیر را دنبال کنید:

- Microsoft Visual Studio را باز کنید و یک *Qt Console Application* جدید ایجاد کنید.

![VS_Console_Application.png](vs-console-application.png)

- کیت مناسب را انتخاب کنید و راه‌انداز را پایان دهید.
- برای یکپارچه‌سازی و استفاده از کتابخانه Aspose.Slides برای C++، روی پروژه کلیک راست کنید و *Manage NuGet Packages...* را انتخاب کنید.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- بسته *Aspose.Slides.Cpp* مورد نیاز را پیدا کنید و نصب کنید.

![VS_Find_Nuget.png](vs-find-nuget.png)

- پروژه را ساخت کنید و یکپارچه‌سازی تمام شد.  

{{% alert color="primary" %}}

توجه: برای اطلاعات بیشتر به [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) مراجعه کنید.

{{% /alert %}}
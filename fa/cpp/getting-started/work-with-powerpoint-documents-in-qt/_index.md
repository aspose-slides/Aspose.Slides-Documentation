---
title: کار با اسناد PowerPoint در Qt
type: docs
weight: 60
url: /fa/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt سازنده
- برنامه Qt
- چندسکو
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "از Aspose.Slides برای C++ همراه با Qt Creator و Visual Studio برای ایجاد، بارگذاری و ویرایش ارائه‌های پاورپوینت و OpenDocument در برنامه‌های چندسکو استفاده کنید."
---
## **معرفی**

Qt یک فریمورک توسعهٔ برنامه‌های کاربردی مبتنی بر C++ و چندسکو است که به‌طور گسترده‌ای برای ساخت انواع برنامه‌های دسکتاپ، موبایل و سیستم‌های تعبیه‌شده استفاده می‌شود. Aspose.Slides for C++ می‌تواند درون Qt یکپارچه شود تا اسناد PowerPoint را در برنامه‌های Qt خود ایجاد و دستکاری کنید.

## **استفاده از Aspose.Slides for C++ درون Qt Creator**

برای استفاده از Aspose.Slides for C++ در برنامهٔ Qt خود، آخرین نسخهٔ API را از بخش [بارگیری‌ها](https://downloads.aspose.com/slides/fa/cpp) دانلود کنید. پس از دانلود API، می‌توانید کتابخانهٔ C++ را درون Qt Creator یا Visual Studio یکپارچه کنید.

برای یکپارچه‌سازی و استفاده از کتابخانهٔ Aspose.Slides for C++ در یک برنامهٔ Qt Console که در Qt Creator توسعه یافته است، لطفاً مراحل زیر را دنبال کنید:

- Qt Creator را باز کنید و یک *Qt Console Application* جدید ایجاد کنید.

![qt_console_application](qt-console-application.png)

- گزینهٔ QMake را از فهرست کشویی *Build System* انتخاب کنید.

![qt_console_application_qmake](qt-console-application-qmake.png)

- کیت مناسب را انتخاب کنید و ویزارد را تکمیل کنید.
- پوشهٔ aspose-slides-cpp-21.02 را از بسته استخراج‌شدهٔ Aspose.Slides for C++ به ریشهٔ پروژه کپی کنید.

![lib_files](aspose.slides-lib-files.png)

- برای افزودن مسیرها به پوشه‌های lib و include، روی پروژه در پنل سمت چپ کلیک راست کنید و *Add Library* را انتخاب کنید.

![qt_add_library](qt_add_library.png)

- گزینهٔ External Library را انتخاب کنید و مسیرهای پوشه‌های lib را یکی‌یکی مرور کنید.

![todo:image_alt_text](qt-add-external-library.png)

- پس از اتمام، فایل .pro پروژه شما شامل ورودی‌های زیر خواهد بود:

![qt_pro_file.png](qt-pro-file.png)

- برنامه را بسازید و یکپارچه‌سازی تمام شد.  

{{% alert color="info" %}}
توجه: برای اطلاعات بیشتر، به [پروژهٔ کامل دمو](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) مراجعه کنید.
{{% /alert %}}

## **استفاده از Aspose.Slides for C++ در برنامه‌های Qt درون Visual Studio**

برای توسعهٔ برنامهٔ Qt با استفاده از Visual Studio، باید [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123) را نصب کنید. پس از نصب، آخرین نسخهٔ API را از بخش [بارگیری‌ها](https://downloads.aspose.com/slides/fa/cpp) دانلود کنید و مراحل زیر را دنبال کنید:

- Microsoft Visual Studio را باز کنید و یک *Qt Console Application* جدید ایجاد کنید.

![VS_Console_Application.png](vs-console-application.png)

- کیت مناسب را انتخاب کنید و ویزارد را تکمیل کنید.
- برای یکپارچه‌سازی و استفاده از کتابخانهٔ Aspose.Slides for C++، روی پروژه کلیک راست کنید و *Manage NuGet Packages...* را انتخاب کنید.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- پکیج مورد نیاز *Aspose.Slides.Cpp* را پیدا کنید و نصب کنید.

![VS_Find_Nuget.png](vs-find-nuget.png)

- پروژه را بسازید و یکپارچه‌سازی تمام شد.  

{{% alert color="info" %}}
توجه: برای اطلاعات بیشتر، به [پروژهٔ کامل دمو](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) مراجعه کنید.
{{% /alert %}}
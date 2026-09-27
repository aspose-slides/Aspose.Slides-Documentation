---
title: نصب
type: docs
weight: 70
url: /fa/cpp/installation/
keywords:
- نصب Aspose.Slides
- دانلود Aspose.Slides
- استفاده از Aspose.Slides
- نصب Aspose.Slides
- NuGet
- CMake
- ویندوز
- لینوکس
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "نصب Aspose.Slides برای C++ بر روی ویندوز از طریق NuGet در Visual Studio یا بر روی لینوکس از بستهٔ ZIP با CMake و بررسی نصب با اجرای اولین برنامه."
---
## **نمای کلی**

Aspose.Slides for C++ در دو فرم توزیع می‌شود:

| فرم | برای چه استفاده شود | از کجا دریافت شود |
|---|---|---|
| بسته‌های NuGet: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64‑bit) و [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32‑bit) | پروژه‌های Visual Studio C++ در ویندوز | NuGet |
| بسته‌های ZIP برای ویندوز، لینوکس و macOS | ساخت‌ها بدون NuGet، مانند پروژه‌های CMake | صفحهٔ [download page](https://releases.aspose.com/slides/cpp/) |

این مقاله نشان می‌دهد چگونه بسته NuGet را در Visual Studio بر ویندوز نصب کنید و چطور بسته ZIP را با CMake بر لینوکس استفاده کنید. هر دو مسیر با همان بررسی پایان می‌یابند: ساخت و اجرای مثال اول در [Create Presentations](/slides/fa/cpp/create-presentation/).

## **ویندوز**

در ویندوز بسته NuGet را به یک پروژه Visual Studio C++ اضافه کنید. این بسته همچنین وابستگی خود، CodePorting.Translator.Cs2Cpp.Framework را نصب می‌کند و فایل‌های DLL مورد نیاز برنامه‌تان را به پوشه خروجی ساخت کپی می‌نماید.

بسته را بر پایهٔ پلتفرمی که برای آن می‌سازید انتخاب کنید: **Aspose.Slides.Cpp** برای x64 و **Aspose.Slides.Cpp.x86** برای Win32 (x86). بسته Aspose.Slides.Cpp برای ساخت Win32 اعمال نمی‌شود، بنابراین کامپایلر نمی‌تواند سرآیندهای آن را در آنجا پیدا کند.

یک بسته ZIP ویندوزی نیز از [download page](https://releases.aspose.com/slides/cpp/) در دسترس است.

### **روش ۱: نصب یا به‌روزرسانی Aspose.Slides از طریق NuGet Package Manager**

1. Microsoft Visual Studio را باز کنید.  
2. یک پروژه **Console App** ‎C++ ایجاد کنید یا پروژهٔ موجودی را باز کنید.  
3. در **Solution Explorer**، روی پروژه راست‑کلیک کنید و **Manage NuGet Packages** را انتخاب کنید (یا به **Project** > **Manage NuGet Packages** بروید).  
4. در **Browse**، برای *Aspose.Slides.Cpp* جستجو کنید.  
   ![جستجو برای Aspose.Slides.Cpp در NuGet Package Manager](installation_1.png)  
5. **Aspose.Slides.Cpp** (یا **Aspose.Slides.Cpp.x86** برای ساخت ۳۲‑بیتی) را انتخاب کنید و سپس **Install** را کلیک کنید.  
   * اگر قبلاً Aspose.Slides را نصب کرده‌اید و می‌خواهید به‌روزرسانی کنید، به‌جای آن **Update** را کلیک کنید.

بسته بارگیری می‌شود و در پروژهٔ شما مرجع می‌شود.

### **روش ۲: نصب یا به‌روزرسانی Aspose.Slides از طریق Package Manager Console**

1. Microsoft Visual Studio را باز کنید.  
2. یک پروژه **Console App** ‎C++ ایجاد کنید یا پروژهٔ موجودی را باز کنید.  
3. به **Tools** > **NuGet Package Manager** > **Package Manager Console** بروید.  
   ![باز کردن Package Manager Console](installation_2.png)  
4. این فرمان را اجرا کنید:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   برای ساخت ۳۲‑بیتی (Win32) بسته x86 را به‌جای آن نصب کنید:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

   ![اجرای فرمان Install-Package](installation_3.png)

زمانی که نصب خاتمه یافت، پیام‌های تأیید نمایش داده می‌شوند. این بسته تحت [Aspose EULA](https://about.aspose.com/legal/eula) توزیع می‌شود.  
   ![پیام‌های تأیید نصب](installation_4.png)

برای به‌روزرسانی بسته، `Update-Package Aspose.Slides.Cpp` (یا `Update-Package Aspose.Slides.Cpp.x86`) را در Package Manager Console اجرا کنید.

### **بررسی نصب**

1. محتوای فایل اصلی *.cpp* پروژه (فایلی که حاوی `main` است) را با مثال اول در [Create Presentations](/slides/fa/cpp/create-presentation/) جایگزین کنید.  
2. در نوار ابزار، پلتفرم **x64** را انتخاب کنید، یا **x86** اگر Aspose.Slides.Cpp.x86 را نصب کرده‌اید.  
3. **Ctrl+F5** را فشار دهید تا برنامه ساخته و اجرا شود.

برنامه *hello.pptx* را در پوشهٔ پروژه ذخیره می‌کند؛ که این پوشه به‌طور پیش‌فرض به عنوان پوشهٔ کاری وقتی Visual Studio برنامه‌ای را اجرا می‌کند، در نظر گرفته می‌شود.

## **لینوکس**

در لینوکس، بسته ZIP لینوکس را با CMake استفاده کنید. این بسته شامل کتابخانه Aspose.Slides، وابستگی آن CodePorting.Translator.Cs2Cpp.Framework و یک فایل پیکربندی CMake برای هر یک می‌باشد. کتابخانه‌ها برای لینوکس x86_64 با glibc 2.23 یا بالاتر ساخته شده‌اند.

1. یک کامپایلر ‎C++، make، CMake، unzip و کتابخانهٔ fontconfig را نصب کنید؛ که کتابخانه‌های Aspose.Slides به آن نیاز دارند. در Debian و Ubuntu:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. یک پوشهٔ پروژه ایجاد کنید و به آن بروید:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. بسته ZIP لینوکس (**Aspose.Slides for C++ Linux**) را از [download page](https://releases.aspose.com/slides/cpp/) به پوشهٔ پروژه دانلود کنید و آن را به زیرپوشهٔ *aspose‑slides‑cpp* استخراج کنید:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. فایلی به نام *CMakeLists.txt* در پوشهٔ پروژه ایجاد کنید با محتوای زیر:

   ```cmake
   cmake_minimum_required(VERSION 3.13)
   project(HelloSlides CXX)

   set(CMAKE_CXX_STANDARD 14)
   set(CMAKE_CXX_STANDARD_REQUIRED ON)

   set(ASPOSE_SLIDES_DIR "${CMAKE_CURRENT_SOURCE_DIR}/aspose-slides-cpp")
   find_package(CodePorting.Translator.Cs2Cpp.Framework REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)
   find_package(Aspose.Slides.Cpp REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)

   add_executable(hello main.cpp)
   target_link_libraries(hello PRIVATE Aspose.Slides.Cpp)
   ```

   دو فراخوانی `find_package` فایل‌های پیکربندی CMake را از بستهٔ استخراج‌شده بارگذاری می‌کنند. چارچوب ابتدا پیدا می‌شود چون Aspose.Slides به آن وابسته است. لینک کردن هدف `Aspose.Slides.Cpp` پوشه‌های include و هر دو کتابخانه را به ساخت اضافه می‌کند.

5. مثال اول در [Create Presentations](/slides/fa/cpp/create-presentation/) را به عنوان *main.cpp* در پوشهٔ پروژه ذخیره کنید.  
6. برنامه را بسازید و اجرا کنید:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

برنامه *hello.pptx* را در پوشهٔ جاری ذخیره می‌کند. CMake مکان کتابخانه‌ها را در برنامه ثبت می‌کند، بنابراین نیازی به تنظیم `LD_LIBRARY_PATH` ندارید در حالی که پوشهٔ *aspose‑slides‑cpp* در جای خود باقی می‌ماند.

برای رندر صحیح متن هنگام تبدیل اسلایدها به PDF یا تصویر، فونت‌های استفاده‌شده در ارائه‌های شما یا جایگزین‌های مناسب باید بر سیستم نصب شوند.

## **سؤال‌های متداول**

**آیا نسخهٔ رایگان یا محدودیت آزمایشی وجود دارد؟**

بله. بدون لایسنس، Aspose.Slides در حالت ارزیابی اجرا می‌شود: یک واترمارک ارزیابی به هر اسلایدی که ذخیره می‌کند اضافه می‌کند و متن خوانده‌شده از ارائه‌ها را کوتاه می‌نماید. برای رفع این محدودیت‌ها، یک [license](/slides/fa/cpp/licensing/) معتبر اعمال کنید.

**چرا کامپایلر اعلام می‌کند که نمی‌تواند *DOM/Presentation.h* را باز کند؟**

بستهٔ نصب‌شده با پلتفرمی که برای آن می‌سازید مطابقت ندارد. Aspose.Slides.Cpp تنها برای ساخت‌های x64 اعمال می‌شود و Aspose.Slides.Cpp.x86 فقط برای ساخت‌های Win32. پلتفرم متناسب را در Visual Studio انتخاب کنید یا بستهٔ دیگر را نصب کنید.
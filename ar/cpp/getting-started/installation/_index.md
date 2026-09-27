---
title: التثبيت
type: docs
weight: 70
url: /ar/cpp/installation/
keywords:
- تثبيت Aspose.Slides
- تنزيل Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- NuGet
- CMake
- ويندوز
- لينكس
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "قم بتثبيت Aspose.Slides للغة C++ على نظام Windows من خلال NuGet في Visual Studio، أو على نظام Linux من حزمة ZIP مع CMake، وتحقق من التثبيت باستخدام برنامج أول."
---
## **نظرة عامة**

يتم توزيع Aspose.Slides للغة C++ في شكلين:

| النموذج | استخدامه لـ | مكان الحصول عليه |
|---|---|---|
| حزم NuGet: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64‑بت) و [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32‑بت) | مشاريع Visual Studio C++ على نظام Windows | NuGet |
| حزم ZIP لأنظمة Windows و Linux و macOS | بناءات بدون NuGet، مثل مشاريع CMake | [صفحة التحميل](https://releases.aspose.com/slides/cpp/) |

توضح هذه المقالة كيفية تثبيت حزمة NuGet في Visual Studio على نظام Windows وكيفية استخدام حزمة ZIP مع CMake على نظام Linux. كلا الطريقتين تنتهيان بنفس الفحص: بناء وتشغيل المثال الأول في [Create Presentations](/slides/ar/cpp/create-presentation/).

## **Windows**

على نظام Windows، قم بإضافة حزمة NuGet إلى مشروع Visual Studio C++. تثبت الحزمة أيضاً تبعيتها، CodePorting.Translator.Cs2Cpp.Framework، وتنسخ ملفات DLL التي يحتاجها برنامجك إلى مجلد مخرجات البناء.

اختر الحزمة بحسب النظام الأساسي الذي تبني له: **Aspose.Slides.Cpp** للـ x64، و **Aspose.Slides.Cpp.x86** للـ Win32 (x86). حزمة Aspose.Slides.Cpp غير مطبقة على بناء Win32، لذا لا يستطيع المترجم العثور على رؤوسها هناك.

حزمة ZIP لنظام Windows متاحة أيضاً من [صفحة التحميل](https://releases.aspose.com/slides/cpp/).

### **Method 1: Install or Update Aspose.Slides from the NuGet Package Manager**

1. افتح Microsoft Visual Studio.
2. أنشئ مشروع **Console App** بلغة C++، أو افتح مشروعاً موجوداً.
3. في **Solution Explorer**، انقر بزر الماوس الأيمن على المشروع واختر **Manage NuGet Packages** (أو انتقل إلى **Project** > **Manage NuGet Packages**).
4. تحت **Browse**، ابحث عن *Aspose.Slides.Cpp*.
![البحث عن Aspose.Slides.Cpp في مدير حزم NuGet](installation_1.png)
5. انقر على **Aspose.Slides.Cpp** (أو **Aspose.Slides.Cpp.x86** لبناء 32‑بت) ثم اضغط **Install**.  
   * إذا كنت قد قمت بالفعل بتثبيت Aspose.Slides وتريد تحديثه، اضغط **Update** بدلاً من ذلك.

سيتم تنزيل الحزمة وإضافتها إلى مرجع مشروعك.

### **Method 2: Install or Update Aspose.Slides Through the Package Manager Console**

1. افتح Microsoft Visual Studio.
2. أنشئ مشروع **Console App** بلغة C++، أو افتح مشروعاً موجوداً.
3. انتقل إلى **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![فتح وحدة التحكم الخاصة بمدير الحزم](installation_2.png)
4. نفّذ هذا الأمر:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   لبناء 32‑بت (Win32) استخدم حزمة x86 بدلاً من ذلك:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

![تشغيل أمر Install-Package](installation_3.png)

عند إكمال التثبيت ستظهر رسائل تأكيد. تُوزَّع الحزمة وفقاً لـ [Aspose EULA](https://about.aspose.com/legal/eula).
![رسائل تأكيد التثبيت](installation_4.png)

لتحديث الحزمة، نفّذ `Update-Package Aspose.Slides.Cpp` (أو `Update-Package Aspose.Slides.Cpp.x86`) في نافذة Package Manager Console.

### **Check the Installation**

1. استبدل محتويات ملف *.cpp* الرئيسي للمشروع (الملف الذي يحتوي على `main`) بالمثال الأول في [Create Presentations](/slides/ar/cpp/create-presentation/).
2. في شريط الأدوات، اختر منصة **x64**، أو **x86** إذا قمت بتثبيت Aspose.Slides.Cpp.x86.
3. اضغط **Ctrl+F5** لبناء البرنامج وتشغيله.

يحفظ البرنامج الملف *hello.pptx* في مجلد المشروع، وهو دليل العمل الافتراضي عندما يقوم Visual Studio بتشغيل برنامج.

## **Linux**

على نظام Linux، استخدم حزمة ZIP الخاصة بـ Linux مع CMake. تتضمن الحزمة مكتبة Aspose.Slides، وتبعيتها CodePorting.Translator.Cs2Cpp.Framework، وملف تكوين CMake لكل منهما. تم بناء المكتبات لنظام Linux x86_64 مع glibc 2.23 أو أحدث.

1. ثبّت مترجم C++، وmake، وCMake، وunzip، ومكتبة fontconfig التي تعتمد عليها مكتبات Aspose.Slides. على Debian و Ubuntu:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. أنشئ مجلد مشروع وانتقل إليه:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. قم بتحميل ملف ZIP الخاص بـ Linux (**Aspose.Slides for C++ Linux**) من [صفحة التحميل](https://releases.aspose.com/slides/cpp/) إلى مجلد المشروع، ثم فك ضغطه في المجلد الفرعي *aspose-slides-cpp*:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. أنشئ ملفًا باسم *CMakeLists.txt* في مجلد المشروع بالمحتوى التالي:

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

   تستدعي استدعاءات `find_package` ملفي تكوين CMake من الحزمة المفكوكة. تُعثر على الإطار أولاً لأن Aspose.Slides تعتمد عليه. ربط الهدف `Aspose.Slides.Cpp` يضيف مجلدات التضمين والمكتبتين إلى عملية البناء.

5. احفظ المثال الأول في [Create Presentations](/slides/ar/cpp/create-presentation/) كملف *main.cpp* في مجلد المشروع.
6. بِنِّ البرنامج وشغّله:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

يحفظ البرنامج الملف *hello.pptx* في المجلد الحالي. يسجل CMake موقع المكتبات في البرنامج، لذا لا تحتاج إلى ضبط `LD_LIBRARY_PATH` طالما يظل مجلد *aspose-slides-cpp* في مكانه.

يجب تثبيت الخطوط المستخدمة في عروضك التقديمية، أو بدائل مناسبة، على النظام لكي يتم عرض النص بشكل صحيح عند تحويل الشرائح إلى PDF أو صور.

## **الأسئلة المتكررة**

**هل هناك نسخة مجانية أو قيود على النسخة التجريبية؟**  
نعم. بدون ترخيص، يعمل Aspose.Slides في وضع التقييم: يضيف علامة مائية تقييم إلى كل شريحة يتم حفظها ويقتطع النص المستخرج من العروض. لإزالة هذه القيود، طبّق [ترخيص](/slides/ar/cpp/licensing/) صالح.

**لماذا يُظهر المترجم رسالة عدم القدرة على فتح *DOM/Presentation.h*؟**  
الحزمة المثبتة لا تتطابق مع النظام الأساسي الذي تُجري البناء له. Aspose.Slides.Cpp يطبق فقط على بناءات x64، وAspose.Slides.Cpp.x86 يطبق فقط على بناءات Win32. اختر النظام المناسب في Visual Studio، أو قم بتثبيت الحزمة الأخرى.
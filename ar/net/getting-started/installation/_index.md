---
title: التثبيت
type: docs
weight: 70
url: /ar/net/installation/
keywords:
- تثبيت Aspose.Slides
- تحميل Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- ويندوز
- لينكس
- ماك أو إس
- باوربوينت
- مستند مفتوح
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيف تثبت Aspose.Slides لـ .NET بسرعة. دليل خطوة بخطوة، متطلبات النظام، وعينات الكود — ابدأ العمل على عروض PowerPoint اليوم!"
---
## **نظرة عامة**

تشرح هذه المقالة طريقة تثبيت Aspose.Slides لـ .NET على نظامي Windows وLinux وmacOS. تُركز على التثبيت عبر NuGet وتُظهر كيفية إضافة المكتبة من خلال مدير الحزم NuGet أو وحدة تحكم مدير الحزم في Windows، وإضافتها إلى مشروع .NET في Linux، وإلى مشروع Visual Studio في macOS. كما تُوضح كيفية تحديث الحزمة وتثبيت الإصدارات ما قبل الإصدار عند الحاجة.

قبل التثبيت، راجع أنظمة التشغيل المدعومة، وتنفيذات .NET، والاعتمادات الإضافية في [System Requirements](/slides/ar/net/system-requirements/).

## **ويندوز**
يوفر NuGet أسهل طريقة لتنزيل وتثبيت واجهات برمجة تطبيقات Aspose لـ .NET على أجهزة الكمبيوتر.

### **الطريقة 1: تثبيت أو تحديث Aspose.Slides من مدير حزم NuGet**

1. افتح Microsoft Visual Studio.  
2. أنشئ تطبيق console بسيط أو افتح مشروعًا موجودًا.  
3. انتقل إلى **Tools** > **NuGet package manager**.  
4. تحت **Browse**، ابحث عن *Aspose Slides* في حقل النص.  
{{% image img="installation_1.png" alt="تثبيت Aspose.Slides من مدير الحزم NuGet - 1" %}}
5. انقر على **Aspose.Slides.NET** ثم انقر **Install**.  
   * إذا أردت تحديث Aspose.Slides—بافتراض أنك قد ثبتها بالفعل—انقر **Update** بدلاً من ذلك.  

يتم تنزيل الواجهة البرمجية المحددة وإضافتها إلى مشروعك كمرجع.

### **الطريقة 2: تثبيت أو تحديث Aspose.Slides من خلال وحدة تحكم مدير الحزم**

هذا هو طريقة الإشارة إلى [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) عبر وحدة تحكم مدير الحزم:

1. افتح Microsoft Visual Studio.  
2. أنشئ تطبيق console بسيط أو افتح مشروعًا موجودًا.  
3. انتقل إلى **Tools** > **Library Package Manager** > **Package Manager Console**.  
![todo:image_alt_text](installation_2.png)
4. نفّذ الأمر التالي: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)  
يتم تثبيت أحدث إصدار كامل في تطبيقك.  

* بدلاً من ذلك، يمكنك إضافة اللاحقة `-prerelease` إلى الأمر لتحديد أنه يجب تثبيت أحدث إصدار (بما في ذلك التصحيحات).  

تظهر تلميحة **Installing Aspose.Slides.NET** في أسفل النافذة.  
![todo:image_alt_text](installation_4.png)

عند اكتمال التحميل، يجب أن ترى بعض رسائل التأكيد.  

إذا لم تكن مألوفًا مع [Aspose EULA](https://about.aspose.com/legal/eula)، فربما ترغب في قراءة الرخصة الموجودة في الرابط.  
![todo:image_alt_text](installation_5.png)

في تطبيقك، يجب أن ترى أن Aspose.Slides قد تمت إضافتها والإشارة إليها بنجاح.  
![todo:image_alt_text](installation_6.png)

في وحدة تحكم مدير الحزم، يمكنك تشغيل الأمر `Update-Package Aspose.Slides.NET` للتحقق من وجود تحديثات لحزمة Aspose.Slides. تُثبت التحديثات (إن وجدت) تلقائيًا. يمكنك أيضًا استخدام اللاحقة `-prerelease` لتحديث أحدث إصدار.

#### **اعتبارات عند التشغيل في بيئة خادم مشترك**
نوصي بشدة بتشغيل جميع مكونات Aspose .NET باستخدام مجموعة الأذونات **Full Trust** لأن مكونات Aspose قد تحتاج أحيانًا إلى الوصول إلى إعدادات السجل والملفات الموجودة في مواقع خارج الدليل الافتراضي—على سبيل المثال، عندما تحتاج مكونات Aspose إلى قراءة الخطوط.

علاوة على ذلك، مكونات Aspose.NET تستند إلى الفئات الأساسية لنظام .NET—وبعض هذه الفئات تتطلب أيضًا أذن **Full Trust** للعمليات في حالات معينة.

مزودو خدمة الإنترنت الذين يستضيفون تطبيقات متعددة من شركات مختلفة غالبًا ما يُطبقون مستوى أمان **Medium Trust**. في حالة .NET 2.0، قد يؤدي هذا المستوى إلى قيود تؤثر على عمليات Aspose.Slides:

- **RegistryPermission** غير متاحة. هذا يعني أنك لا تستطيع الوصول إلى السجل، وهو أمر مطلوب لتعداد الخطوط المثبتة عند عرض الوثائق.  
- **FileIOPermission** مقيدة. هذا يعني أنه يمكنك فقط الوصول إلى الملفات داخل هيكل الدليل الافتراضي لتطبيقك. وهذا قد يعني أيضًا عدم القدرة على قراءة الخطوط أثناء عمليات التصدير.  

لهذا السبب، نوصي بشدة بتشغيل Aspose.Slides بأذونات **Full Trust**. إذا استخدمت **Medium trust**، قد تواجه عدم اتساق—بعض ميزات المكتبة (مثل العرض) قد لا تعمل عند أداء مهام معينة.

## **لينكس**

يوفر NuGet أسهل طريقة لتنزيل وتثبيت Aspose.Slides لـ .NET على Linux. أضف حزمة [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) إلى مشروع .NET الخاص بك.

## **ماك أو إس**

يوفر NuGet أسهل طريقة لتنزيل وتثبيت Aspose.Slides لـ .NET على أجهزة ماك.

### **تثبيت Aspose.Slides**

1. افتح Visual Studio.  
2. أنشئ تطبيق console بسيط أو افتح مشروعًا موجودًا.  
3. انتقل إلى **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. اكتب *Aspose.Slides* في حقل النص.  
5. انقر على **Aspose.Slides for .NET** ثم انقر **Add Package**.  
6. أضف مقتطف شفرة بسيط.  
   * يمكنك نسخ الشفرة من [this page](/slides/ar/net/create-presentation/).  
7. شغّل التطبيق.  
8. افتح *folder/bin/Debug/presentation_file_name* داخل مشروعك.

## **الأسئلة المتكررة**

**هل هناك نسخة مجانية أو قيود على الإصدار التجريبي؟**

نعم، بشكل افتراضي، يعمل Aspose.Slides في وضع التقييم، مما يضيف علامات مائية وقد يكون له قيود أخرى. لإزالة القيود، تحتاج إلى تطبيق [license](/slides/ar/net/licensing/).
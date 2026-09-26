---
title: التثبيت
type: docs
weight: 70
url: /ar/net/installation/
keywords:
- تثبيت Aspose.Slides
- تنزيل Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تثبيت Aspose.Slides for .NET من NuGet على Windows و Linux و macOS: اختر بين الحزمتين، أضف إحداهما باستخدام .NET CLI أو Visual Studio، وقم بتثبيت المتطلبات المسبقة لـ Linux."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إضافة Aspose.Slides for .NET إلى مشروع على Windows و Linux و macOS. يتم توزيع Aspose.Slides عبر NuGet. يمكنك إضافتها باستخدام .NET CLI على أي نظام تشغيل، أو باستخدام NuGet Package Manager أو Package Manager Console في Visual Studio على Windows. كما توضح المقالة أي من حزم NuGet الاثنين يجب اختيارها وما الذي تحتاجه Linux بالإضافة.

قبل التثبيت، راجع أنظمة التشغيل المدعومة، وتنفيذيات .NET، والاعتمادات الإضافية في [متطلبات النظام](/slides/ar/net/system-requirements/).

## **اختر الحزمة**

Aspose.Slides for .NET يتم نشره كحزمتين من NuGet. كلاهما يوفر نفس مساحات الأسماء والفئات الخاصة بـ Aspose.Slides، لذا لا يتغير الكود الخاص بك عند التبديل بينهما؛ إلا أن مرجع الحزمة ومتطلبات النظام تختلف.

| الحزمة | استخدامه لـ | المتطلبات الإضافية |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | تطبيقات Windows و .NET Framework | على Linux و macOS: مكتبة `libgdiplus`، وتبديل `System.Drawing.EnableUnixSupport` مفعّل عند بدء تشغيل التطبيق |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 أو أحدث على Windows و Linux و macOS | على Linux: مكتبة `fontconfig`، إذا لم تكن مثبتة مسبقًا |

إذا لم تكن متأكدًا، استخدم Aspose.Slides.NET على Windows و Aspose.Slides.NET6.CrossPlatform على Linux و macOS. على Alpine Linux، وعلى أنظمة Linux التي تكون مكتبة glibc فيها أقدم من 2.23 (x64) أو 2.39 (ARM64)، استخدم Aspose.Slides.NET بدلاً من ذلك. [متطلبات النظام](/slides/ar/net/system-requirements/) تُدرج المنصات المدعومة لكل حزمة.

## **التثبيت باستخدام .NET CLI**

تعمل هذه الخطوات على Windows و Linux و macOS باستخدام .NET SDK 6 أو أحدث. إنشاء تطبيق سطر أوامر:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

ثم أضف الحزمة المناسبة لمنصتك. أضف إحدى الحزمتين فقط إلى المشروع.

- على Windows: `dotnet add package Aspose.Slides.NET`
- على Linux و macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (على Linux، قم بتثبيت المتطلب الأساسي أولاً؛ راجع [Linux](#linux))

للتحقق من أن الحزمة تعمل، استبدل محتوى *Program.cs* بالمثال الأول في [إنشاء عروض تقديمية](/slides/ar/net/create-presentation/) ثم شغّل `dotnet run`. سيحفظ *hello.pptx* في مجلد المشروع.

## **ويندوز**

### **طريقة 1: تثبيت أو تحديث Aspose.Slides من مدير حزم NuGet**

1. افتح Microsoft Visual Studio.
2. أنشئ تطبيق سطر أوامر أو افتح مشروعًا موجودًا.
3. في **Solution Explorer**، انقر بزر الماوس الأيمن على المشروع واختر **Manage NuGet Packages** (أو انتقل إلى **Project** > **Manage NuGet Packages**).
4. ضمن **Browse**، ابحث عن *Aspose.Slides*.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. انقر على **Aspose.Slides.NET** ثم انقر على **Install**.
   * إذا كنت قد قمت بالفعل بتثبيت Aspose.Slides وتريد تحديثه، انقر على **Update** بدلاً من ذلك.

تم تنزيل الحزمة وإدراجها في مشروعك.

### **طريقة 2: تثبيت أو تحديث Aspose.Slides عبر وحدة التحكم الخاصة بمدير الحزم**

هكذا تقوم بالإشارة إلى حزمة [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) عبر وحدة التحكم الخاصة بمدير الحزم:

1. افتح Microsoft Visual Studio.
2. أنشئ تطبيق سطر أوامر أو افتح مشروعًا موجودًا.
3. انتقل إلى **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![فتح وحدة التحكم الخاصة بمدير الحزم](installation_2.png)
4. نفّذ هذا الأمر: `Install-Package Aspose.Slides.NET`
![تشغيل أمر Install-Package](installation_3.png)
تم تثبيت أحدث إصدار في مشروعك.

تظهر الرسالة **Installing Aspose.Slides.NET** قرب أسفل النافذة.
![تقدم التثبيت في وحدة التحكم الخاصة بمدير الحزم](installation_4.png)

عند انتهاء التنزيل، تظهر رسائل تأكيد. الحزمة موزعة وفقًا لـ [Aspose EULA](https://about.aspose.com/legal/eula).
![رسائل تأكيد التثبيت](installation_5.png)

تم الآن إضافة Aspose.Slides إلى مشروعك وإدراجها.
![الإشارة إلى Aspose.Slides في المشروع](installation_6.png)

لتحديث الحزمة، نفّذ `Update-Package Aspose.Slides.NET` في وحدة التحكم الخاصة بمدير الحزم.

## **Linux**

استخدم خطوات .NET CLI المذكورة أعلاه. اختر الحزمة وقم بتثبيت المتطلبات المسبقة باستخدام مدير الحزم الخاص بتوزيعتك. على Debian و Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: قم بتثبيت `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: قم بتثبيت `libgdiplus`، ومكّن دعم Unix لـ System.Drawing قبل أن يستخدم التطبيق Aspose.Slides.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

أضف هذا السطر في بداية التطبيق، قبل أي استدعاء لـ Aspose.Slides. في *Program.cs* يحمل عبارات المستوى العلوي، ضعها بعد توجيهات `using`:
```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

استخدم هذه الحزمة على Alpine Linux، وعلى الأنظمة التي تكون مكتبة glibc فيها قديمة جدًا بالنسبة لـ Aspose.Slides.NET6.CrossPlatform.

يجب تثبيت الخطوط المستخدمة في عروضك التقديمية، أو البدائل المناسبة، على النظام ليتم عرض النص بشكل صحيح. [متطلبات النظام](/slides/ar/net/system-requirements/) تصف الحزم التي تحتاجها Aspose.Slides.NET على Alpine Linux، بما في ذلك الخطوط.

## **macOS**

استخدم خطوات .NET CLI المذكورة أعلاه مع حزمة **Aspose.Slides.NET6.CrossPlatform**، التي تدعم كلًا من أجهزة Intel (x86_64) وأجهزة Apple silicon (ARM64) على ماك:

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **الأسئلة المتكررة**

**هل هناك نسخة مجانية أو قيود على الإصدار التجريبي؟**

نعم. بدون ترخيص، يعمل Aspose.Slides في وضع التقييم: يضيف علامة مائية تقييم على كل شريحة يتم حفظها ويقص النص المقروء من العروض التقديمية. لإزالة هذه القيود، استخدم [رخصة](/slides/ar/net/licensing/).
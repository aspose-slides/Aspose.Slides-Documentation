---
title: دمج Aspose.Slides مع Google Slides
linktitle: شرائح Google
type: docs
weight: 50
url: /ar/net/integrating-aspose-slides-with-google-slides/
keywords:
- منصات السحابة
- تكامل السحابة
- شرائح Google
- قوقل درايف
- واجهة برمجة تطبيقات Google
- حساب خدمة Google
- تكامل SaaS
- OAuth 2.0
- PPT إلى PDF
- أتمتة PowerPoint
- معالجة العروض التقديمية
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "ربط Aspose.Slides مع Google Slides لاستيراد ومزامنة وتحويل العروض التقديمية، أتمتة سير العمل، والحفاظ على PowerPoint و OpenDocument في خط أنابيب واحد."
---

## **مقدمة**

يقدم Aspose.Slides الآن تكاملًا مع Google Slides وGoogle Drive من خلال [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). يتيح هذا التكامل لتطبيقات .NET تحويل وتحرير وتنزيل وتحميل عروض Google Slides.

## **ما هو Google Slides؟**
[Google Slides](https://workspace.google.com/products/slides/) هو برنامج عرض تقديمي مجاني يعمل على الويب تم تطويره من قبل Google. يتيح للمستخدمين إنشاء وتحرير ومشاركة عروض الشرائح عبر الإنترنت، مشابهًا لـ Microsoft PowerPoint. يدعم التعاون في الوقت الفعلي، التخزين السحابي، ويعمل على أي جهاز لديه اتصال بالإنترنت.

## **Google API**
قبل البدء في العمل مع عرض Google Slides عبر Aspose.Slides، يجب عليك إنشاء مشروع Google API وإنشاء [Google Cloud project](https://developers.google.com/workspace/guides/create-project)، ثم تمكين APIs المطلوبة.

بعد ذلك عليك اختيار الطريقة التي ستستخدمها للوصول إلى Google API – يدعم [Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) طريقتين للوصول إلى Google API:
- `Google Service Account`
- `OAuth 2.0` مع تفاعل المستخدم عبر المتصفح.

### **Google Service Account**
حساب الخدمة هو حساب Google خاص يُستخدم من قبل التطبيقات أو الخوادم للوصول إلى Google APIs برمجياً دون تفاعل المستخدم. يُستخدم عادةً للأنظمة الخلفية أو المهام الآلية. يتم توثيق حسابات الخدمة باستخدام ملف مفتاح JSON ولها عنوان بريد إلكتروني خاص. يمكن تعيين أذونات محددة لها عبر [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) وغالبًا ما تُستخدم مع APIs مثل Google Drive أو Sheets أو BigQuery للوصول الآمن والآلي إلى الموارد.

### **OAuth 2.0**
طريقة شائعة أخرى للوصول إلى Google APIs هي عبر OAuth 2.0 مع تفاعل المستخدم عبر المتصفح. في هذا التدفق، يُعاد توجيه المستخدم إلى صفحة تسجيل دخول Google حيث يمنح الإذن للتطبيق. بعد الموافقة، يحصل التطبيق على رمز تفويض، يُستبدل برمز وصول ورمز تحديث.

يسمح رمز الوصول بالوصول المؤقت إلى Google APIs، بينما يمكن تخزين رمز التحديث وإعادة استخدامه للحصول على رموز وصول جديدة دون الحاجة إلى تسجيل دخول المستخدم مرة أخرى. هذا يعني أن تفاعل المتصفح مطلوب مرة واحدة فقط، مما يجعل الوصول اللاحق إلى API مؤتمتًا بالكامل. تُستخدم هذه الطريقة عادةً للتطبيقات التي تحتاج إلى الوصول إلى بيانات مستخدم (مثل Gmail أو Calendar أو Drive) بموافقة المستخدم.

## **لنكتب الكود**
أولاً، أضف حزمة NuGet [Aspose.Slides SaaS Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) إلى مشروعك:
```
dotnet add package Aspose.Slides.SaaSIntegrations
```


### **مثال 1**
في المثال التالي، سنقوم بتنزيل عرض Google Slides من Google Drive وحفظه على القرص المحلي كملف PDF. سنستخدم حساب خدمة Google للتفويض، بافتراض أن ملف JSON الخاص بحساب الخدمة تم تنزيله مسبقًا.
```csharp
// إنشاء HttpClient مُدار خارجيًا
HttpClient httpClient = new HttpClient();

// إنشاء موفر تفويض باستخدام ملف JSON لحساب الخدمة
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// تهيئة خدمة تكامل Google Slides باستخدام موفر التفويض
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// تحميل عرض تقديمي من Google Drive باستخدام معرف الملف إلى كائن Aspose.Slides IPresentation
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// تعديل العرض التقديمي إذا لزم الأمر (مثال: إزالة الشريحة الثانية)
pres.Slides.RemoveAt(1);

// حفظ العرض التقديمي محليًا كملف PDF
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```


لتسهيل الأمر، توفر Aspose.Slides SaaS Integration طريقة لتعداد جميع الملفات المتاحة للمستخدم. تشمل البيانات المرتجعة اسم الملف، نوع MIME، ومعرف الملف.
```csharp
// احصل على قائمة الملفات المتاحة لحساب الخدمة المقدم
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```


طريقة أخرى للعثور على معرف الملف هي فتح العرض في تطبيق Google Slides على الويب وتحديده في عنوان URL.

على سبيل المثال، في عنوان URL التالي:
```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```


معرف الملف هو:
```
1A2B3C4D5E6F7G8H9I0J
```


## **مثال 2**
في المثّل التالي، سننشئ عرض PowerPoint من الصفر ونحمّله إلى Google Drive بصيغة Google Slides. للتفويض، سنستخدم OAuth 2.0.
```csharp
// إنشاء HttpClient مُدار خارجيًا
HttpClient httpClient = new HttpClient();

// إنشاء موفر تفويض باستخدام OAuth مع معرف العميل والسر الخاص بالعميل
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// تهيئة خدمة تكامل Google Slides باستخدام موفر التفويض
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Create a sample presentation
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // حفظ العرض التقديمي إلى المجلد الجذر في Google Drive بصيغة Google Slides
    // يمكنك أيضًا اختيار أي صيغة تصدير أخرى يدعمها Aspose.Slides
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```


إذا استخدمت هذا النوع من التفويض في تطبيقك، `interaction with the browser is required`. عليك اختيار حسابك وتأكيد السماح للتطبيق بالوصول إلى Google Drive API. هذا كل شيء—يُطلب هذا الإجراء فقط في التشغيل الأول.

### **مثال 3**
في المثال التالي سنستخدم رمز وصول تم الحصول عليه مسبقًا. `GoogleAccessTokenAuthProvider` هو تنفيذ للواجهة `IGoogleAuthorizationProvider` يستخدم رمز وصول OAuth 2.0 موجود لتفويض الطلبات إلى Google APIs. على عكس المزودات التي تُدير تدفق OAuth، تعتمد هذه الفئة على المرسل لتزويدها برمز وصول صالح.

هذا المزود مفيد في الأنظمة التي يتم فيها الحصول على رمز الوصول خارجيًا—عادةً عبر تطبيق أمامي أو خدمة أخرى—ثم يُمرّر إلى الخلفية. وهو مناسب بشكل خاص للبيئات الموزَّعة حيث يُعقّد إدارة رموز التحديث على الخادم أو يزداد خطر إبطال الرمز بسبب محاولات التحديث المتزامنة.

يوضح هذا المثال كيفية استبدال ملف وتحديث اسمه على Google Drive مع الحفاظ على معرف الملف.
```csharp
// إنشاء عميل HTTP لإجراء الطلبات
using HttpClient httpClient = new HttpClient();

// إعداد مصادقة Google Drive باستخدام رمز وصول
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// تهيئة التكامل مع Google Slides/Drive باستخدام المصادقة وعميل HTTP
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Create a sample presentation using Aspose.Slides
using (var presentation = new Presentation())
{
    // إضافة شكل مستطيل إلى الشريحة الأولى وتعيين نصه
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // تعريف خيارات حفظ PDF بجودة محددة وإعدادات امتثال معينة
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // حفظ (استبدال) الملف الموجود على Google Drive بواسطة معرف الملف، تحديث اسمه، وتصديره كملف PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // معرف الملف الموجود على Google Drive
        GoogleSaveFormatType.Pdf,         // الصيغة المطلوبة للحفظ كـ
        saveOptions,           
        "NewFileName.pdf"                 // الاسم الجديد لتعيينه للملف
    );
}
```


## **ملخص**
يدعم Aspose.Slides الآن تنسيق ملف إضافي للإدارة، مما يبسط أتمتة سير العمل السحابي لإنشاء ومشاركة وتحرير العروض التقديمية.

غطى هذا المقال الميزات الأساسية. يمكنك أيضًا حفظ الملفات إلى مجلدات فرعية، استبدال الملفات الحالية، وتصدير إلى Google Drive بصيغ مختلفة—not limited to Google Slides presentations.

ستستمر Aspose.Slides SaaS Integration في توسيع الدعم لمنصات SaaS للعروض التقديمية، لذا راجع التحديثات المستقبلية.

## **الأسئلة الشائعة**

**هل أحتاج إلى حساب Google Workspace لاستخدام هذا التكامل؟**
لا. يمكنك استخدام حساب Google مجاني أو حساب Google Workspace. يعتمد الوصول المطلوب على أذونات Google Drive وSlides الخاصة بك.

**أي طريقة توثيق يجب أن أختار—Service Account أم OAuth 2.0؟**
استخدم **Service Account** للأنظمة الخلفية أو سير العمل الآلي دون تفاعل المستخدم.
استخدم **OAuth 2.0** إذا كنت تحتاج إلى الوصول إلى ملفات Google Slides أو Drive لمستخدم محدد بموافقته.

**هل يمكنني العمل مع تنسيقات غير Google Slides؟**
نعم. يتيح Aspose.Slides حفظ العروض التقديمية بصيغ مختلفة (مثل PDF أو PPTX أو HTML) قبل تحميلها إلى Google Drive.

**كيف يمكنني الحصول على معرف ملف عرض Google Slides؟**
يمكنك استرجاعه باستخدام طريقة `GetDriveFileInfosAsync()` أو بنسخه من عنوان URL للعرض في Google Slides.

**هل يدعم التكامل استبدال ملف موجود على Google Drive؟**
نعم. استخدم طريقة `SavePresentationToExistingFileAsync` لتحديث ملف مع الحفاظ على معرفه.

**هل التفاعل مع المتصفح مطلوب في كل مرة عند استخدام OAuth 2.0؟**
لا. التفاعل مع المتصفح مطلوب فقط أثناء التفويض الأول. بعد ذلك، تُسمح رموز التحديث المخزنة بالوصول الآلي.
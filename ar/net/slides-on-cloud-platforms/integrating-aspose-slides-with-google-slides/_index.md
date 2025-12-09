---
title: دمج Aspose.Slides مع Google Slides
linktitle: شرائح Google
type: docs
weight: 50
url: /ar/net/integrating-aspose-slides-with-google-slides/
keywords:
- منصات سحابية
- تكامل سحابي
- شرائح Google
- Google Drive
- Google API
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

# دمج Aspose.Slides مع Google Slides

Aspose.Slides الآن يوفر دمجًا مع Google Slides وGoogle Drive عبر [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). يتيح هذا الدمج لتطبيقات .NET تحويل، تعديل، تنزيل، وتحميل عروض Google Slides.

## ما هو Google Slides؟
[Google Slides](https://workspace.google.com/products/slides/) هو برنامج عروض تقديمية مجاني قائم على الويب تم تطويره بواسطة Google. يتيح للمستخدمين إنشاء، تعديل، ومشاركة العروض التقديمية عبر الإنترنت، مشابهًا لـ Microsoft PowerPoint. يدعم التعاون الفوري، التخزين السحابي، ويعمل على أي جهاز متصل بالإنترنت.

## Google API
قبل البدء في العمل مع عرض Google Slides عبر Aspose.Slides عليك إنشاء مشروع Google API وإنشاء [Google Cloud project](https://developers.google.com/workspace/guides/create-project)، ثم تمكين واجهات برمجة التطبيقات المطلوبة.

بعد ذلك عليك اختيار طريقة الوصول إلى Google API—[Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) يدعم طريقتين للوصول إلى Google API:
- `Google Service Account`
- `OAuth 2.0` مع تفاعل المستخدم عبر المتصفح.

### حساب خدمة Google
حساب الخدمة هو حساب Google خاص يُستخدم من قبل التطبيقات أو الخوادم للوصول إلى واجهات برمجة تطبيقات Google برمجيًا دون تفاعل المستخدم. يُستخدم عادةً للأنظمة الخلفية أو المهام الآلية. يتم توثيق حسابات الخدمة باستخدام ملف مفتاح JSON ولها عنوان بريد إلكتروني خاص. يمكن تعيين أذونات محددة لها عبر [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) وغالبًا ما تُستخدم مع واجهات مثل Google Drive أو Sheets أو BigQuery للوصول الآمن والآلي إلى الموارد.

### OAuth 2.0
طريقة شائعة أخرى للوصول إلى واجهات Google API هي عبر OAuth 2.0 مع تفاعل المستخدم عبر المتصفح. في هذا التدفق يُعاد توجيه المستخدم إلى صفحة تسجيل دخول Google حيث يمنح الإذن للتطبيق. بعد الموافقة، يتلقى التطبيق رمز تفويض يقوم بتبادله للحصول على رمز وصول ورمز تحديث.

يسمح رمز الوصول بالوصول المؤقت إلى واجهات Google API، بينما يمكن تخزين رمز التحديث وإعادة استخدامه للحصول على رموز وصول جديدة دون الحاجة إلى تسجيل دخول المستخدم مرة أخرى. هذا يعني أن تفاعل المتصفح مطلوب مرة واحدة فقط، وتصبح عمليات الوصول اللاحقة مؤتمتة بالكامل. تُستخدم هذه الطريقة عادةً للتطبيقات التي تحتاج إلى الوصول إلى بيانات مستخدم (مثل Gmail أو Calendar أو Drive) بموافقة المستخدم.

## لنكتب الشيفرة
أولًا، أضف حزمة NuGet الخاصة بـ [Aspose.Slides SaaS Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) إلى مشروعك:
```
dotnet add package Aspose.Slides.SaaSIntegrations
```


### المثال 1
في المثال التالي، سنقوم بتنزيل عرض Google Slides من Google Drive وحفظه على القرص المحلي كملف PDF. سنستخدم حساب خدمة Google للتوثيق، بافتراض أنه قد تم تنزيل ملف JSON الخاص بحساب الخدمة مسبقًا.
```csharp
// إنشاء HttpClient مُدار خارجيًا
HttpClient httpClient = new HttpClient();

// Create an authorization provider using a service account JSON file
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Initialize Google Slides integration service with the authorization provider
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Load a presentation from Google Drive by its file ID into an Aspose.Slides IPresentation instance
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Modify the presentation if needed (e.g., remove the second slide)
pres.Slides.RemoveAt(1);

// Save the presentation locally as a PDF file
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```


للتسهيل، يوفر Aspose.Slides SaaS Integration طريقة لسرد جميع الملفات المتاحة للمستخدم. تشمل البيانات المرجعة اسم الملف، نوع MIME، ومعرّف الملف.
```csharp
// احصل على قائمة الملفات المتاحة لحساب الخدمة المقدم
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```


طريقة أخرى للعثور على معرّف الملف هي فتح العرض في تطبيق Google Slides على الويب وتحديده في عنوان URL.

على سبيل المثال، في العنوان التالي:
```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```


معرّف الملف هو:
```
1A2B3C4D5E6F7G8H9I0J
```


## المثال 2
في المثال التالي، سننشئ عرض PowerPoint من الصفر ونرفعه إلى Google Drive بصيغة Google Slides. للتوثيق، سنستخدم OAuth 2.0.
```csharp
// إنشاء HttpClient مُدار خارجيًا
HttpClient httpClient = new HttpClient();

// إنشاء موفر تفويض باستخدام OAuth مع معرف العميل والسر الخاص بالعميل
IGGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// تهيئة خدمة تكامل Google Slides باستخدام موفر التفويض
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// إنشاء عرض تقديمي تجريبي
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // حفظ العرض التقديمي في المجلد الجذر لـ Google Drive بصيغة Google Slides
    // يمكنك أيضًا اختيار أي صيغة تصدير أخرى يدعمها Aspose.Slides
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```


إذا استخدمت هذا النوع من التوثيق في تطبيقك، `يتطلب تفاعل المتصفح`. سيتعين عليك اختيار حسابك وتأكيد السماح للتطبيق بالوصول إلى واجهة Google Drive API. هذا كل ما يلزم—يُطلب هذا الإجراء فقط عند التشغيل الأول.

### المثال 3
في المثال التالي سنستخدم رمز وصول تم الحصول عليه مسبقًا. `GoogleAccessTokenAuthProvider` هو تطبيق للواجهة `IGoogleAuthorizationProvider` يستخدم رمز وصول OAuth 2.0 موجود لتفويض الطلبات إلى واجهات Google API. على عكس الموفرين الذين يبدأون أو يديرون تدفق OAuth، تعتمد هذه الفئة على المتصل لتزويدها برمز وصول صالح.

هذا الموفر مفيد في الأنظمة التي يتم فيها الحصول على رمز الوصول خارجيًا—عادةً عبر تطبيق أمامي أو خدمة أخرى—ويتم تمريره إلى الخلفية. وهو ملائم بشكل خاص للبيئات الموزعة حيث يُضيف إدارة رموز التحديث على الخادم تعقيدات أو مخاطر إبطال الرمز بسبب محاولات تحديث متزامنة.

يوضح هذا المثال كيفية استبدال ملف وتحديث اسمه على Google Drive مع الحفاظ على معرّف الملف.
```csharp
// إنشاء عميل HTTP لإجراء الطلبات
using HttpClient httpClient = new HttpClient();

// إعداد مصادقة Google Drive باستخدام رمز وصول
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// تهيئة التكامل مع Google Slides/Drive باستخدام المصادقة وعميل HTTP
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// إنشاء عرض تقديمي تجريبي باستخدام Aspose.Slides
using (var presentation = new Presentation())
{
    // إضافة شكل مستطيل إلى الشريحة الأولى وتعيين نصه
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // تعريف خيارات حفظ PDF بجودة وإعدادات توافق محددة
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // حفظ (استبدال) الملف الموجود على Google Drive باستخدام معرف الملف، تحديث اسمه، وتصديره كملف PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // معرف الملف الموجود على Google Drive
        GoogleSaveFormatType.Pdf,         // الصيغة المطلوبة للحفظ
        saveOptions,           
        "NewFileName.pdf"                 // الاسم الجديد لتعيينه للملف
    );
}
```


## الملخص
Aspose.Slides الآن يدعم تنسيق ملف إضافي للإدارة، مما يبسط أتمتة سير عمل سحابي لإنشاء، مشاركة، وتعديل العروض التقديمية.

غطى هذا المقال الخصائص الأساسية. يمكنك أيضًا حفظ الملفات إلى مجلدات فرعية، استبدال الملفات الحالية، وتصديرها إلى Google Drive بصيغ مختلفة—ليس مقتصرًا على عروض Google Slides.

ستستمر Aspose.Slides SaaS Integration في توسيع الدعم لمنصات SaaS الخاصة بالعروض التقديمية، لذا ترقب التحديثات المستقبلية.

## الأسئلة المتكررة

**س: هل أحتاج إلى حساب Google Workspace لاستخدام هذا الدمج؟**  
لا. يمكنك استخدام حساب Google مجاني أو حساب Google Workspace. يعتمد الوصول المطلوب على أذونات Google Drive وSlides الخاصة بك.

**س: أي طريقة توثيق يجب أن أختار—حساب خدمة أم OAuth 2.0؟**  
استخدم **حساب خدمة** للأنظمة الخلفية أو سير العمل الآلي بدون تفاعل المستخدم.  
استخدم **OAuth 2.0** إذا كنت بحاجة إلى الوصول إلى ملفات Google Slides أو Drive الخاصة بمستخدم معين بموافقته.

**س: هل يمكنني العمل مع صيغ غير Google Slides؟**  
نعم. Aspose.Slides يسمح بحفظ العروض إلى صيغ متعددة (مثل PDF، PPTX، HTML) قبل رفعها إلى Google Drive.

**س: كيف يمكنني الحصول على معرّف الملف لعروض Google Slides؟**  
يمكنك استرجاعه باستخدام طريقة `GetDriveFileInfosAsync()` أو بنسخه من عنوان URL للعرض في Google Slides.

**س: هل يدعم الدمج استبدال ملف موجود على Google Drive؟**  
نعم. استخدم طريقة `SavePresentationToExistingFileAsync` لتحديث ملف مع الحفاظ على معرّف الملف.

**س: هل يتطلب تفاعل المتصفح في كل مرة عند استخدام OAuth 2.0؟**  
لا. يتطلب تفاعل المتصفح فقط أثناء التفويض الأول. بعد ذلك، تسمح رموز التحديث المخزنة بالوصول المؤتمت.
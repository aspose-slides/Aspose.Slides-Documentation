---
title: استخدام Aspose.Slides على Azure
linktitle: أزور
type: docs
weight: 10
url: /ar/net/using-aspose-slides-on-azure/
keywords:
- منصات السحابة
- تكامل السحابة
- مايكروسوفت أزور
- وظائف أزور
- PPT إلى PDF
- تخزين Blob
- بدون خوادم
- معالجة المستندات
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخدام Aspose.Slides على Azure App Service و Functions والحاويات لتوليد وتعديل وتحويل ملفات PPT و PPTX و ODP في تطبيقات .NET سحابية قابلة للتوسع."
---

## استخدام Aspose.Slides على Azure

### المقدمة
Aspose.Slides هي مكتبة قوية لإدارة عروض PowerPoint برمجيًا. عند نشرها على Microsoft Azure، توفر القابلية للتوسع، والموثوقية، وتكاملًا سلسًا مع خدمات السحابة المتنوعة. تستكشف هذه المقالة فوائد استخدام Aspose.Slides على Azure، وتناقش إمكانيات التكامل، وتوفر إرشادات لإعداد البيئة.

### الفوائد
استخدام Aspose.Slides على Azure يوفر عدة مزايا، بما في ذلك:
- **القابلية للتوسع**: تسمح بنية Azure التحتية لك بتوسيع تطبيقاتك ديناميكيًا.  
  - *ملاحظة واقعية:* على سبيل المثال، يمكنك توسيع عدة مثيلات Azure Function تلقائيًا عند تحويل دفعات كبيرة من ملفات PowerPoint إلى PDF. من خلال الاستفادة من التوسع الديناميكي في Azure، يمكنك معالجة الارتفاعات المفاجئة في تحميل الملفات دون تدخل يدوي.
- **الموثوقية**: تضمن Microsoft توفر عالي وتحمل أخطاء عبر مراكز البيانات الخاصة بها.  
  - *ملاحظة واقعية:* في السيناريوهات العملية، إذا واجهت منطقة واحدة فترة تعطل أو زمن استجابة عالي، تضمن قدرات الفشل الاحتياطي في Azure استمرار تحويلات PPT في منطقة أخرى، مما يحافظ على الخدمة دون انقطاع.
- **الأمان**: توفر Azure ميزات أمان مدمجة لحماية تطبيقاتك وبياناتك.  
  - *ملاحظة واقعية:* نهج شائع هو تخزين العروض التقديمية الحساسة في حاوية Blob آمنة، ثم دمج التحكم في الوصول بناءً على الأدوار (RBAC) بحيث لا يمكن إلا لوظائف Azure المصرح لها الوصول إليها للمعالجة.
- **تكامل سلس**: تعزز خدمات Azure مثل Azure Functions، Blob Storage، وApp Services قدرات Aspose.Slides.  
  - *ملاحظة واقعية & مثال على الكود:* قد تقوم بربط Logic App يُشغّل Azure Function كلما وصل ملف PowerPoint إلى Blob Storage. أدناه مقتطف مثال يوضح كيفية معالجة التزامن عبر معالجة كل ملف تم رفعه بالتوازي:
```cs
    [FunctionName("BulkConvertPptToPdf")]
    public static async Task RunAsync(
        [BlobTrigger("incoming-presentations/{name}", Connection = "AzureWebJobsStorage")] Stream inputFile,
        string name,
        [Blob("output-pdfs/{name}.pdf", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream outputFile,
        ILogger log)
    {
        log.LogInformation($"Converting {name} to PDF in parallel...");
        
        // مثال على معالجة التزامن:
        // يمكن أن يكون هذا جزءًا من منظّم دفعات أكبر يقسّم الملفات أو يعالجها بالتوازي.
        using (var presentation = new Presentation(inputFile))
        {
            presentation.Save(outputFile, SaveFormat.Pdf);
        }

        log.LogInformation("Conversion completed successfully.");
    }
```

  - في خط أنابيب واقعي، يمكنك تكوين مشغلات متعددة وتنفيذات متوازية، مما يضمن معالجة كل عرض تقديمي بسرعة—حتى عندما يحدث مئات التحميلات في آن واحد.

### التكامل مع الخدمات
يمكن دمج Aspose.Slides مع خدمات Azure المختلفة لتحسين أتمتة سير العمل ومعالجة المستندات. بعض التكاملات الشائعة تشمل:
- **Azure Blob Storage**: تخزين واسترداد ملفات العروض التقديمية بكفاءة.  
  *ملاحظة واقعية:* للتحويلات الضخمة الليلية، قد تقوم بتحميل العشرات—أو المئات—من ملفات PPT إلى حاوية Blob. يمكن بعد ذلك معالجة كل ملف تلقائيًا في خط أنابيب خالٍ من الخوادم.
- **Azure Functions**: أتمتة إنشاء وعالجة العروض التقديمية باستخدام الحوسبة الخالية من الخوادم.  
  *ملاحظة واقعية:* على سبيل المثال، يمكن أن تُشغّل Azure Function كلما تم اكتشاف ملف PowerPoint جديد في Blob Storage، وتقوم بتحويله فورًا إلى PDF أو صور دون الحاجة إلى آلة افتراضية مخصصة.
- **Azure App Services**: نشر تطبيقات الويب التي تُنشئ وتُManipulate العروض التقديمية في الوقت الفعلي.  
  *ملاحظة واقعية:* استضافة تطبيق ويب .NET يتيح للمستخدمين تحميل ملفات PPT، تعديل محتوى الشرائح، ثم تنزيل PDF محول—مع توسيع تلقائي مع زيادة حركة المرور.
- **Azure Logic Apps**: إنشاء سير عمل آلي يتعامل مع ملفات PowerPoint.  
  *ملاحظة واقعية:* يمكنك ربط إجراءات (مثل إرسال إشعارات بريد إلكتروني أو تحديث قاعدة بيانات) بعد تحويل ناجح، مما يسهل بناء عمليات شاملة مع قليل من الكود المخصص.

### إعداد البيئة
لبدء استخدام Aspose.Slides على Azure، تحتاج إلى إعداد الخدمات السحابية المناسبة. عند الاختيار بين عروض Azure، ضع في اعتبارك ما يلي:
- **Azure Functions** للمعالجة الخالية من الخوادم للعروض التقديمية.
- **Azure Virtual Machines** لاستضافة التطبيقات التي تتطلب تخصيصًا عاليًا.
- **Azure Kubernetes Service (AKS)** لنشر التطبيقات القائمة على Aspose.Slides في حاويات.
- **Azure App Services** لتشغيل تطبيقات الويب مع ميزات توسيع مدمجة.

### حالات الاستخدام الشائعة
يمكن لـ Aspose.Slides على Azure تمكين تطبيقات واقعية متعددة، بما في ذلك:
- **إنشاء تقارير تلقائي**: إنشاء تقارير PowerPoint ديناميكيًا من قواعد البيانات.
- **تحرير العروض التقديمية عبر الإنترنت**: تقديم أداة ويب تفاعلية لتعديل الشرائح للمستخدمين.
- **معالجة دفعات**: تحويل أعداد كبيرة من العروض التقديمية إلى صيغ مختلفة باستخدام Azure Functions.
- **أمان العروض التقديمية**: تطبيق حماية كلمة مرور وتوقيعات رقمية على ملفات PowerPoint.

### مثال: أتمتة تحويل PPT إلى PDF باستخدام Azure Functions
أدناه مثال على Azure Function يعالج ملف PowerPoint مخزن في Azure Blob Storage ويحولّه إلى PDF باستخدام Aspose.Slides:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

public static class ConvertPptToPdf
{
    [FunctionName("ConvertPptToPdf")]
    public static void Run(
        [BlobTrigger("presentations/{name}", Connection = "AzureWebJobsStorage")] Stream inputBlob, string name,
        [Blob("pdfs/{name}.pdf", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream outputBlob, ILogger log)
    {
        try
        {
            log.LogInformation($"Processing file: {name}");
            using (var presentation = new Presentation(inputBlob))
            {
                presentation.Save(outputBlob, SaveFormat.Pdf);
            }
            log.LogInformation("Conversion successful.");
        }
        catch (Exception ex)
        {
            log.LogError($"Error processing file: {ex.Message}");
        }
    }
}
```


هذه الدالة تُشغّل عندما يتم تحميل ملف PowerPoint إلى Azure Blob Storage وتقوم تلقائيًا بتحويله إلى PDF، وتخزين الناتج في حاوية Blob أخرى.

من خلال الاستفادة من Aspose.Slides على Azure، يمكن للمطورين بناء حلول قوية، قابلة للتوسع، ومؤتمتة لمعالجة مستندات PowerPoint.
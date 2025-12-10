---
title: استخدام Aspose.Slides على Azure
linktitle: Azure
type: docs
weight: 10
url: /ar/net/using-aspose-slides-on-azure/
keywords:
- منصات السحابة
- تكامل السحابة
- مايكروسوفت أزور
- وظائف Azure
- PPT إلى PDF
- تخزين Blob
- بدون خادم
- معالجة المستندات
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخدام Aspose.Slides على Azure App Service و Functions والحاويات لتوليد وتحرير وتحويل ملفات PPT و PPTX و ODP في تطبيقات .NET السحابية القابلة للتوسع."
---

## **المقدمة**
Aspose.Slides هي مكتبة قوية لإدارة عروض PowerPoint برمجيًا. عند نشرها على Microsoft Azure، توفر القابلية للتوسع، والموثوقية، وتكاملًا سلسًا مع خدمات السحابة المختلفة. تستعرض هذه المقالة فوائد استخدام Aspose.Slides على Azure، وتناقش إمكانيات التكامل، وتقدم إرشادات لإعداد البيئة.

## **الفوائد**
استخدام Aspose.Slides على Azure يوفر عدة مزايا، بما في ذلك:
- **القابلية للتوسع**: تسمح بنية Azure التحتية لك بتوسيع تطبيقاتك ديناميكيًا.  
  - *ملاحظة من الواقع:* على سبيل المثال، يمكنك توسيع عدة مثيلات Azure Function تلقائيًا عند تحويل دفعات كبيرة من ملفات PowerPoint إلى PDF. من خلال استغلال التوسع الديناميكي في Azure، يمكنك التعامل مع زيادة تحميل الملفات دون تدخل يدوي.
- **الموثوقية**: تضمن Microsoft توافرًا عاليًا وتحملًا للأخطاء عبر مراكز البيانات الخاصة بها.  
  - *ملاحظة من الواقع:* في السيناريوهات العملية، إذا واجهت منطقة واحدة تعطلًا أو تأخيرًا عاليًا، تضمن قدرات الفشل التلقائي في Azure استمرار تحويلات PPT في منطقة أخرى، مما يحافظ على الخدمة دون انقطاع.
- **الأمان**: توفر Azure ميزات أمان مدمجة لحماية تطبيقاتك وبياناتك.  
  - *ملاحظة من الواقع:* نهج شائع هو تخزين العروض الحساسة في حاوية Blob آمنة، ثم دمج التحكم في الوصول القائم على الدور (RBAC) بحيث لا تتمكن سوى وظائف Azure المصرح لها من الوصول إليها للمعالجة.
- **تكامل سلس**: تعزز خدمات Azure مثل Azure Functions، Blob Storage، وApp Services قدرات Aspose.Slides.  
  - *ملاحظة من الواقع & مثال على الكود:* قد تقوم بربط Logic App يُشغل Azure Function كلما وصل ملف PowerPoint إلى Blob Storage. فيما يلي مقتطف مثال يوضح كيفية معالجة التوازي عن طريق معالجة كل ملف مُحمَّل بالتوازي:
    ```cs
    [FunctionName("BulkConvertPptToPdf")]
    public static async Task RunAsync(
        [BlobTrigger("incoming-presentations/{name}", Connection = "AzureWebJobsStorage")] Stream inputFile,
        string name,
        [Blob("output-pdfs/{name}.pdf", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream outputFile,
        ILogger log)
    {
        log.LogInformation($"Converting {name} to PDF in parallel...");
        
        // مثال على معالجة التوازي: 
        // قد يكون هذا جزءًا من منسق دفعات أكبر يقوم بتقسيم الملفات أو معالجتها بالتوازي.
        using (var presentation = new Presentation(inputFile))
        {
            presentation.Save(outputFile, SaveFormat.Pdf);
        }

        log.LogInformation("Conversion completed successfully.");
    }
    ```

  - في خط أنابيب واقعي، يمكنك تكوين مشغلات متعددة وتنفيذات متوازية، مما يضمن معالجة كل ملف عرض بسرعة—حتى عندما يحدث مئات التحميلات في آن واحد.

## **التكامل مع الخدمات**
يمكن دمج Aspose.Slides مع خدمات Azure المختلفة لتحسين أتمتة سير العمل ومعالجة المستندات. تشمل بعض عمليات التكامل الشائعة:
- **Azure Blob Storage**: تخزين واسترجاع ملفات العروض بكفاءة.  
  *ملاحظة من الواقع:* للتحويلات الضخمة الليلية، يمكنك رفع العشرات أو مئات ملفات PPT إلى حاوية Blob. يمكن بعد ذلك معالجة كل ملف تلقائيًا في خط أنابيب بدون خادم.
- **Azure Functions**: أتمتة إنشاء العروض ومعالجتها باستخدام الحوسبة بدون خادم.  
  *ملاحظة من الواقع:* على سبيل المثال، يمكن أن تُشغل Azure Function كلما تم اكتشاف ملف PowerPoint جديد في Blob Storage، وتقوم فورًا بتحويله إلى PDF أو صور دون الحاجة إلى جهاز افتراضي مخصص.
- **Azure App Services**: نشر تطبيقات ويب تُنشئ وتعدل العروض في الوقت الفعلي.  
  *ملاحظة من الواقع:* استضافة تطبيق ويب .NET يتيح للمستخدمين رفع ملفات PPT، تعديل محتوى الشرائح، ثم تنزيل PDF محوَّل—مع التوسع تلقائيًا مع زيادة الحركة.
- **Azure Logic Apps**: إنشاء سير عمل مؤتمت يتعامل مع ملفات PowerPoint.  
  *ملاحظة من الواقع:* يمكنك ربط إجراءات (مثل إرسال إشعارات البريد الإلكتروني أو تحديث قاعدة البيانات) بعد تحويل ناجح، مما يسهل بناء عمليات متكاملة بنهاية إلى نهاية مع قليل من الشيفرة المخصصة.

## **إعداد البيئة**
لبدء استخدام Aspose.Slides على Azure، تحتاج إلى إعداد الخدمات السحابية المناسبة. عند اختيارك بين عروض Azure، ضع في الاعتبار ما يلي:
- **Azure Functions** للمعالجة بدون خادم للعروض.
- **Azure Virtual Machines** لاستضافة التطبيقات التي تتطلب تخصيصًا عاليًا.
- **Azure Kubernetes Service (AKS)** للنشر الحاوي للتطبيقات المعتمدة على Aspose.Slides.
- **Azure App Services** لتشغيل تطبيقات الويب مع ميزات توسع مدمجة.

## **حالات الاستخدام الشائعة**
تمكن Aspose.Slides على Azure من تطبيقات واقعية متعددة، بما في ذلك:
- **إنشاء تقارير آلية**: إنشاء تقارير PowerPoint ديناميكيًا من قواعد البيانات.
- **تحرير العروض عبر الإنترنت**: توفير أداة ويب تفاعلية للمستخدمين لتعديل الشرائح.
- **معالجة دفعات**: تحويل أعداد كبيرة من العروض إلى صيغ مختلفة باستخدام Azure Functions.
- **أمان العروض**: تطبيق حماية كلمة المرور والتوقيعات الرقمية على ملفات PowerPoint.

## **مثال: أتمتة تحويل PPT إلى PDF باستخدام Azure Functions**
فيما يلي مثال على Azure Function يعالج ملف PowerPoint مخزن في Azure Blob Storage ويحوله إلى PDF باستخدام Aspose.Slides:
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


تُشغل هذه الدالة عندما يتم رفع ملف PowerPoint إلى Azure Blob Storage وتقوم تلقائيًا بتحويله إلى PDF، مع تخزين النتيجة في حاوية Blob أخرى.

من خلال الاستفادة من Aspose.Slides على Azure، يمكن للمطورين بناء حلول قوية، قابلة للتوسع، ومؤتمتة لمعالجة مستندات PowerPoint.
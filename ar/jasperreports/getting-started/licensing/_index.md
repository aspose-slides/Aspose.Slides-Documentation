---
title: الترخيص
type: docs
weight: 50
url: /ar/jasperreports/licensing/
description: "تعرف على ما تضيفه نسخة التقييم من Aspose.Slides for JasperReports إلى الملفات المصدرة، وكيفية تطبيق ترخيص في JasperReports و JasperReports Server."
---
{{% alert color="info" title="Note" %}}
Aspose.Slides for JasperReports متاح كتقييم مجاني غير محدود الوقت من [صفحة التحميل](https://releases.aspose.com/slides/ar/jasperreport/). نسخة التقييم والنسخة المرخصة من المنتج هما نفس ملف التحميل.

عند رضاك عن التقييم، يمكنك [شراء ترخيص](https://purchase.aspose.com/pricing/slides/ar/jasperreports/). تأكد من أنك تفهم وتوافق على شروط الاشتراك.

يمكن تنزيل الترخيص من صفحة الطلب بعد إتمام الدفع. الترخيص هو ملف XML نصي واضح موقع رقمياً يحتوي على معلومات مثل اسم العميل، المنتج المشتراى ونوع الترخيص. لا تقم بتعديل محتوى ملف الترخيص بأي شكل: فإن ذلك يبطل الترخيص.

حمّل الترخيص على جهازك وانسخه إلى المجلد المناسب (على سبيل المثال مجلد التطبيق الخاص بك أو **JasperReports\lib**).
{{% /alert %}}

## **قيود النسخة التجريبية**
النسخة التجريبية من Aspose.Slides for JasperReports (بدون ترخيص محدد) تقوم بتصدير كل صفحة من التقرير، لكنها تضيف علامة مائية تقييم في مركز كل شريحة أو صفحة، في جميع تنسيقات الإخراج الأربعة (PPT, PPTX, PDF و HTML)، كما هو موضح في الشكل أدناه. راجع [تقييم Aspose.Slides](/slides/ar/jasperreports/evaluate-aspose-slides/) للتفاصيل.

![علامة مائية التقييم في مركز الشريحة المصدرة](evaluation_watermark.png)

## **تطبيق ترخيص**
هناك عدة طرق لتطبيق الترخيص، اعتماداً على ما إذا كنت تعمل على JasperReports أو JasperServer.

### **تطبيق ترخيص لـ JasperReports**
استدعِ طريقة `setLicense` من الفئة `License` مع تدفق يقرأ ملف الترخيص، كما في Aspose.Slides for Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // إنشاء كائن تدفق يحتوي على ملف الترخيص.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // إنشاء كائن من فئة License.
            License license = new License();

            // تعيين الترخيص عبر كائن التدفق.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

أو، مرّر مسار ملف الترخيص إلى المُصدِّر في معلمة `ASExporterParameters.PPT_LICENSE`. في هذا المقتطف، `jasperPrint` هو تقرير مملوء، كما في [تصديرك الأول](/slides/ar/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **تطبيق ترخيص على JasperServer**
عيّن خاصية `licenseFile` للـ bean `pptExportParameters` في *applicationContext.xml* إلى مسار ملف الترخيص، كما هو موضح في [التكامل مع JasperServer](/slides/ar/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).
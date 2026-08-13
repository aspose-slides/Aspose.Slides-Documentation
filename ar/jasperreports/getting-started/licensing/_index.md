---
title: الترخيص
type: docs
weight: 50
url: /ar/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides لـ JasperReports متاح كإصدار تجريبي مجاني غير محدود الوقت من [صفحة التحميل](https://downloads.aspose.com/slides/ar/jasperreport). إصدار التجربة والإصدارات المرخصة للمنتج يتم تحميلهما من نفس الرابط.

عند رضاك عن النسخة التجريبية، [اشترِ ترخيصًا](https://purchase.aspose.com/buy). تأكد من فهمك وموافقتك على شروط الاشتراك.

يمكن تنزيل الترخيص من صفحة الطلب بعد إتمام الدفع. الترخيص هو ملف XML نصي واضح موقّع رقمياً يحتوي على معلومات مثل اسم العميل، المنتج المشترى ونوع الترخيص. لا تقم بتعديل محتوى ملف الترخيص بأي شكل: فإن ذلك يبطل الترخيص.

حمّل الترخيص إلى جهازك وانسخه إلى المجلد المناسب (على سبيل المثال مجلد التطبيق الخاص بك أو **JasperReports\lib**).
{{% /alert %}}

## **قيود نسخة التقييم**
الإصدار التجريبي من Aspose.Slides (بدون ترخيص محدد) يوفر جميع وظائف المنتج، لكنه (عند حفظ العروض التقديمية) يضيف علامة مائية تجريبية في وسط كل شريحة كما هو موضح في الشكل أدناه:

![todo:image_alt_text](evaluation_watermark.png) 

## **تطبيق الترخيص**
هناك عدة طرق لتطبيق الترخيص، وذلك حسب ما إذا كنت تعمل على JasperReports أو JasperServer.

### **تطبيق الترخيص لـ JasperReports**
استخدم استدعاء مباشر لطريقة setLicense مشابه لـ Aspose.Slides للـ Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //إنشاء كائن تدفق يحتوي على ملف الترخيص
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //إنشاء نسخة من فئة License
    License license = new License();
	
    //ضبط الترخيص من خلال كائن التدفق
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

أو، عيّن معلمة المُصدِّر في الشيفرة.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **تطبيق الترخيص على JasperServer**
قُم بضبط معلمة المُصدِّر في ملف applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
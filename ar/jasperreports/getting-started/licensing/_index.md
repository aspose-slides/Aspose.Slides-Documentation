---
title: الترخيص
type: docs
weight: 50
url: /ar/jasperreports/licensing/
---
{{% alert color="primary" %}} 

يتوفر Aspose.Slides لـ JasperReports كتقييم مجاني غير محدود المدة من صفحة [download page](https://downloads.aspose.com/slides/ar/jasperreport). نسخة التقييم والنسخة المرخصة من المنتج تُنزل من نفس الرابط.

عندما تكون راضيًا عن التقييم، يمكنك [buy a license](https://purchase.aspose.com/buy). تأكد من أنك تفهم وتوافق على شروط الاشتراك.

الترخيص متاح للتحميل من صفحة الطلب بعد إتمام الدفع. الترخيص هو ملف XML نصي واضح، موقّع رقميًا، يحتوي على معلومات مثل اسم العميل، المنتج المشترا، ونوع الترخيص. لا تُعدّل محتوى ملف الترخيص بأي شكل: أي تعديل يبطل الترخيص.

حمّل الترخيص إلى جهازك وانسخه إلى المجلد المناسب (مثلاً مجلد التطبيق الخاص بك أو **JasperReports\lib**).
{{% /alert %}}

## **القيود في نسخة التقييم**
توفر نسخة التقييم من Aspose.Slides (بدون ترخيص محدد) جميع وظائف المنتج بالكامل، لكن (عند حفظ العروض التقديمية) تُضيف علامة مائية للتقييم في وسط كل شريحة كما هو موضح في الشكل أدناه:

![todo:image_alt_text](evaluation_watermark.png) 

## **تطبيق الترخيص**
هناك عدة طرق لتطبيق الترخيص، اعتمادًا على ما إذا كنت تعمل على JasperReports أو JasperServer.

### **تطبيق الترخيص لـ JasperReports**
استخدم نداء setLicense مباشر مماثل لـ Aspose.Slides للـ Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //إنشاء كائن تدفق يحتوي على ملف الترخيص
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //إنشاء كائن من الفئة License
    License license = new License();
	
    //تعيين الترخيص عبر كائن التدفق
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

أو، اضبط معلمة المُصدِّر في الشيفرة.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **تطبيق الترخيص على JasperServer**
اضبط معلمة المُصدِّر في ملف applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
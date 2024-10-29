---
title: الترخيص
type: docs
weight: 50
url: /ar/jasperreports/licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides لـ JasperReports متاح كتقييم مجاني غير محدود المدة من [صفحة التحميل](https://downloads.aspose.com/slides/jasperreport). النسخ التجريبية والترخيصية للمنتج هي نفس النسخة التي يتم تحميلها.

عندما تكون راضيًا عن التقييم، [اشترِ ترخيصًا](https://purchase.aspose.com/buy). تأكد من فهمك وامتناك لشروط الاشتراك.

الترخيص متاح للتنزيل من صفحة الطلب بعد دفع طلب الشراء. الترخيص هو ملف XML موقع رقميًا يحتوي على معلومات مثل اسم العميل، والمنتج المشتراة ونوع الترخيص. لا تقم بتعديل محتوى ملف الترخيص بأي شكل من الأشكال: القيام بذلك يبطل الترخيص.

قم بتنزيل الترخيص إلى جهاز الكمبيوتر الخاص بك وانسخه إلى المجلد المناسب (على سبيل المثال، مجلد التطبيق الخاص بك أو **JasperReports\lib**).

## **قيود النسخة التجريبية**
توفر النسخة التجريبية من Aspose.Slides (بدون ترخيص محدد) جميع وظائف المنتج، ولكن (عند حفظ العروض التقديمية الخاصة بك) تقوم بإدخال علامة مائية تجريبية في وسط كل شريحة كما هو موضح في الشكل أدناه:

![todo:image_alt_text](evaluation_watermark.png) 

## **تطبيق الترخيص**
هناك عدة طرق لتطبيق الترخيص، يعتمد ذلك على ما إذا كنت تعمل على JasperReports أو JasperServer.

### **تطبيق الترخيص لـ JasperReports**
استخدم مكالمة مباشرة لطريقة setLicense مشابهة لما هو موجود في Aspose.Slides لـ Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //إنشاء كائن دفق يحتوي على ملف الترخيص
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instantiate the License class
    License license = new License();
	
    //Set the license through the stream object
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

أو، قم بتعيين معلمة المصدر في الكود.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **تطبيق الترخيص على JasperServer**
قم بتعيين معلمة المصدر في applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
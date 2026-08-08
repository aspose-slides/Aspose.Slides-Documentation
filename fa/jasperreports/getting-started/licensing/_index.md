---
title: مجوزدهی
type: docs
weight: 50
url: /fa/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides برای JasperReports به‌صورت ارزیابی رایگان و نامحدود زمانی از صفحهٔ [صفحه دانلود](https://downloads.aspose.com/slides/fa/jasperreport) در دسترس است. نسخهٔ ارزیابی و نسخه‌های دارای لایسنس محصول از همان لینک دانلود می‌آیند.

وقتی از ارزیابی راضی شدید، [خرید لایسنس](https://purchase.aspose.com/buy) کنید. مطمئن شوید که شرایط اشتراک را می‌فهمید و با آن موافقید.

پس از پرداخت سفارش، لایسنس برای دانلود از صفحهٔ سفارش در دسترس می‌شود. لایسنس یک فایل XML متنی، دیجیتally امضا شده است که شامل اطلاعاتی مانند نام مشتری، محصول خریداری شده و نوع لایسنس می‌باشد. محتویات فایل لایسنس را به هیچ وجه تغییر ندهید؛ این کار اعتبار لایسنس را باطل می‌کند.

لایسنس را روی کامپیوتر خود دانلود کنید و به پوشهٔ مناسب (مثلاً پوشهٔ برنامه شما یا **JasperReports\lib**) کپی کنید.
{{% /alert %}}

## **محدودیت نسخهٔ ارزیابی**
نسخهٔ ارزیابی Aspose.Slides (بدون لایسنس مشخص) تمام عملکردهای محصول را فراهم می‌کند، اما (هنگام ذخیرهٔ ارائه‌ها) یک واترمارک ارزیابی در مرکز هر اسلاید اعمال می‌کند همان‌طور که در شکل زیر نشان داده شده است:

![todo:image_alt_text](evaluation_watermark.png) 

## **اعمال لایسنس**
چندین روش برای اعمال لایسنس وجود دارد که بستگی به این دارد که در JasperReports یا JasperServer کار می‌کنید.

### **اعمال لایسنس برای JasperReports**
از فراخوانی مستقیم متد setLicense مشابه Aspose.Slides برای Java استفاده کنید.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //یک شیء جریان حاوی فایل لایسنس ایجاد کنید
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //نمونه‌سازی کلاس License
    License license = new License();
	
    //تنظیم لایسنس از طریق شیء جریان
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

یا، پارامتر exporter را در کد تنظیم کنید.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **اعمال لایسنس در JasperServer**
پارامتر exporter را در فایل applicationContext.xml تنظیم کنید.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
---
title: مجوزدهی
type: docs
weight: 50
url: /fa/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides برای JasperReports به صورت یک ارزیابی رایگان و بدون محدودیت زمانی از [صفحه دانلود](https://downloads.aspose.com/slides/fa/jasperreport) در دسترس است. نسخهٔ ارزیابی و نسخه‌های دارای مجوز محصول همان دانلود هستند.

وقتی از ارزیابی راضی شدید، [خرید مجوز](https://purchase.aspose.com/buy) کنید. مطمئن شوید که شرایط اشتراک را می‌فهمید و قبول دارید.

مجوز پس از پرداخت سفارش از صفحهٔ سفارش برای دانلود در دسترس است. مجوز یک فایل XML متنی ساده و با امضای دیجیتال است که اطلاعاتی نظیر نام مشتری، محصول خریداری شده و نوع مجوز را شامل می‌شود. محتویات فایل مجوز را به هیچ وجه تغییر ندهید: این کار مجوز را نامعتبر می‌سازد.

مجوز را به رایانه خود دانلود کرده و در پوشهٔ مناسب قرار دهید (برای مثال پوشهٔ برنامهٔ شما یا **JasperReports\lib**).
{{% /alert %}}

## **محدودیت نسخهٔ ارزیابی**
نسخهٔ ارزیابی Aspose.Slides (بدون مشخص کردن مجوز) تمام عملکردهای محصول را ارائه می‌دهد، اما (زمانی که ارائه‌های خود را ذخیره می‌کنید) یک واترمارک ارزیابی در مرکز هر اسلاید اضافه می‌کند همان‌طور که در شکل زیر نشان داده شده است:

![todo:image_alt_text](evaluation_watermark.png) 

## **اعمال مجوز**
روش‌های مختلفی برای اعمال مجوز وجود دارد که بسته به این که در JasperReports یا JasperServer کار می‌کنید، متفاوت است.

### **اعمال مجوز برای JasperReports**
از فراخوانی مستقیم متد setLicense مشابه Aspose.Slides برای Java استفاده کنید.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //یک شیء جریان شامل فایل مجوز ایجاد کنید
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //نمونه‌سازی کلاس License
    License license = new License();
	
    //مجوز را از طریق شیء جریان تنظیم کنید
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

### **اعمال مجوز در JasperServer**
پارامتر exporter را در applicationContext.xml تنظیم کنید.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
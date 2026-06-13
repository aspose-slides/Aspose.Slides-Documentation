---
title: مجوزدهی
type: docs
weight: 50
url: /fa/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides برای JasperReports به‌صورت ارزیابی رایگان بدون محدودیت زمانی از [صفحه دانلود](https://downloads.aspose.com/slides/fa/jasperreport) در دسترس است. نسخه ارزیابی و نسخه‌های دارای لایسنس محصول از همان لینک دانلود می‌شوند.

وقتی از ارزیابی راضی شدید، [خرید یک لایسنس](https://purchase.aspose.com/buy) را انجام دهید. مطمئن شوید شرایط اشتراک را درک کرده و آن را می‌پذیرید.

پس از پرداخت سفارش، لایسنس برای دانلود از صفحه سفارش در دسترس است. لایسنس یک فایل XML متنی واضح، دارای امضای دیجیتال است که اطلاعاتی مانند نام مشتری، محصول خریداری‌شده و نوع لایسنس را شامل می‌شود. به هیچ وجه محتوای فایل لایسنس را تغییر ندهید: این کار اعتبار لایسنس را باطل می‌کند.

لایسنس را در رایانه خود دانلود کنید و به پوشه مناسب کپی کنید (برای مثال پوشه برنامه شما یا **JasperReports\lib**).

## **محدودیت نسخه ارزیابی**

نسخه ارزیابی Aspose.Slides (بدون لایسنس مشخص) تمام قابلیت‌های محصول را فراهم می‌کند، اما هنگام ذخیره‌سازی ارائه‌ها، یک واترمارک ارزیابی در مرکز هر اسلاید قرار می‌دهد همان‌طور که در شکل زیر نشان داده شده است:

![متن جایگزین](evaluation_watermark.png) 

## **اعمال لایسنس**

چندین روش برای اعمال لایسنس وجود دارد که بسته به اینکه در JasperReports یا JasperServer کار می‌کنید متفاوت است.

### **اعمال لایسنس برای JasperReports**

از فراخوانی مستقیم متد setLicense مشابه Aspose.Slides برای Java استفاده کنید.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //یک شی استریم حاوی فایل لایسنس را ایجاد کنید
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //یک نمونه از کلاس License ایجاد کنید
    License license = new License();
	
    //لایسنس را از طریق شی استریم تنظیم کنید
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

یا پارامتر exporter را در کد تنظیم کنید.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **اعمال لایسنس بر روی JasperServer**

پارامتر exporter را در فایل applicationContext.xml تنظیم کنید.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
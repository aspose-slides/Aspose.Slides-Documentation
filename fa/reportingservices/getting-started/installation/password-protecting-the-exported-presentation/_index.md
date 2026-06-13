---
title: محافظت با رمز عبور از ارائه صادر شده
type: docs
weight: 90
url: /fa/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

محافظت از یک ارائه با رمز عبور از استفاده و دسترسی غیرمجاز جلوگیری می‌کند. حفاظت با رمز عبور مفید است اگر شما گزارش‌هایی ایجاد می‌کنید که حاوی داده‌های حساس یا جزئیاتی هستند که فقط برخی افراد در سازمان شما باید آن‌ها را ببینند.

این مقاله نشان می‌دهد چگونه محیط Reporting Services یا Visual Studio خود را به‌روزرسانی کنید تا بتوانید ارائه‌ها را با حفاظت رمز عبور ذخیره کنید.

{{% /alert %}} 
## **افزودن حفاظت رمز عبور به ارائه‌های صادر شده در محیط Reporting Services**
برای اعمال تغییرات در اینجا، باید فایل‌ها را در دایرکتوری که Microsoft SQL Server Reporting Services نصب شده است، ویرایش کنید.
### **مرحله 1. یافتن مسیر نصب Reporting Server.**
دایرکتوری ریشه برای Microsoft SQL Server معمولاً C:\Program Files\Microsoft SQL Server است.

{{% alert color="primary" %}} 

برای سیستم 64 بیتی، نسخه x86 SQL Server در مسیر C:\Program Files (x86)\Microsoft SQL Server نصب می‌شود.

{{% /alert %}} 

Microsoft SQL Server 2005 و 2008: ممکن است چندین نمونه از Microsoft SQL Server بر روی ماشین پیکربندی شده باشد. هر یک یک زیرپوشه MSSQL.x مختلف را اشغال می‌کنند، به عنوان مثال MSSQL.1، MSSQL.2 و غیره. قبل از ادامه مراحل بعدی، مسیر صحیح C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer را پیدا کنید.

تمام مسیرهای زیر به پوشه نصب Microsoft SQL Server Reporting Services به عنوان <Instance> ارجاع می‌دهند.
### **مرحله 2. افزودن کد برای اضافه کردن رمز عبور به ارائه‌های صادر شده**
پسوندهای رندر موجود Aspose.Slides for Reporting Services را در فایل **rsreportserver.config** جایگزین کنید. برای این کار، فایل C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config را باز کنید. 

گزینه‌های رندر را که بلافاصله زیر این متن آمده‌اند پیدا کنید و آن‌ها را با کد در بخش بعدی جایگزین کنید.
#### **یافتن گزینه‌های رندر Aspose.Slides for Reporting Service**
**<Render>**

``` xml

   ...

  <!--شروع از اینجا.>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--پایان از اینجا.-->


</Render>
```
#### **کد جایگزین**
**<Render>**

``` xml

   ...

  <!--شروع از اینجا.>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--پایان از اینجا.-->


</Render>
```
### **افزودن حفاظت رمز عبور برای ارائه‌های صادر شده در Visual Studio**
برای اعمال تغییرات در اینجا، باید فایلی را که Microsoft Visual Studio Report Designer در آن نصب شده است، ویرایش کنید.
### **مرحله 1. باز کردن پوشه Visual Studio.**
- برای ترکیب با Visual Studio 2005 Report Designer، پوشه C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies را باز کنید.
- برای ترکیب با Visual Studio 2008 Report Designer، پوشه C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies را باز کنید.
### **مرحله 2. افزودن کد برای اضافه کردن رمز عبور به ارائه‌های صادر شده.**
پسوندهای رندر موجود Aspose.Slides for Reporting Services را در فایل **rsreportserver.config** جایگزین کنید. برای این کار، فایل C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config را باز کنید (که در آن **<Version>** برای Visual Studio 2005 برابر “8” و برای Visual Studio 2008 برابر “9.0” است) و این خطوط را در عنصر **<Render>** اضافه کنید. سپس آن‌ها را با کد در بخش کد بعدی جایگزین کنید.
#### **یافتن گزینه‌های رندر Aspose.Slides for Reporting Service**
**<Render>**

``` xml

   ...

  <!--شروع از اینجا.>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--پایان از اینجا.-->


</Render>



```
#### **کد جایگزین**
**<Render>**

``` xml

   ...

  <!--شروع از اینجا.>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--پایان از اینجا.-->


</Render>



```
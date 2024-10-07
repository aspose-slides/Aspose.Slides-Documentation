---
title: حماية كلمة المرور للعروض التقديمية المصدرة
type: docs
weight: 90
url: /reportingservices/password-protecting-the-exported-presentation/
---

{{% alert color="primary" %}} 

يمنع تفعيل حماية كلمة المرور للعروض التقديمية الاستخدام غير المصرح به والوصول إليها. تعتبر حماية كلمة المرور مفيدة إذا كنت تقوم بإنشاء تقارير تحتوي على بيانات حساسة أو تفاصيل يجب أن يراها بعض الأشخاص فقط في منظمتك.

توضح هذه المقالة كيفية تحديث بيئة خدمات التقارير أو بيئة Visual Studio للسماح لك بحفظ العروض التقديمية مع حماية بكلمة مرور.

{{% /alert %}} 
## **إضافة حماية كلمة المرور للعروض التقديمية المصدرة في بيئة خدمات التقارير**
لتطبيق التغييرات هنا، يجب عليك تعديل الملفات في الدليل حيث تم تثبيت خدمات التقارير من Microsoft SQL Server.
### **الخطوة 1. حدد موقع دليل تثبيت خادم التقارير.**
عادةً ما يكون الدليل الجذر لـ Microsoft SQL Server هو C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

لأنظمة x64، تكون النسخة x86 من SQL Server مثبتة في C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 و 2008: قد تكون هناك عدة نسخ من Microsoft SQL Server مُكوّنة على الجهاز. كل منها يحتل دليل MSSQL.x مختلف، مثل MSSQL.1، MSSQL.2 وهكذا. ابحث عن الدليل الصحيح C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer قبل الاستمرار في الخطوات التالية.

تشير جميع المسارات المستخدمة أدناه إلى دليل تثبيت خدمات التقارير من Microsoft SQL Server كـ <Instance>.
### **الخطوة 2. أضف الكود لإضافة كلمات المرور للعروض التقديمية المصدرة**
استبدل المكونات الإضافية الحالية لـ Aspose.Slides لخدمات التقارير في ملف **rsreportserver.config**. للقيام بذلك، افتح ملف C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config.

ابحث عن خيارات التقديم المدرجة أدناه واستبدلها بالكود في الجزء الذي يلي ذلك.
#### **ابحث عن خيارات تقديم Aspose.Slides لخدمات التقارير**
**<Render>**

``` xml

   ...

  <!--ابدأ هنا.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--انتهى هنا.-->

</Render>

```
#### **كود الاستبدال**
**<Render>**

``` xml

   ...

  <!--ابدأ هنا.-->


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

  <!--انتهى هنا.-->

</Render>

```
### **إضافة حماية كلمة المرور للعروض التقديمية المصدرة في Visual Studio**
لتطبيق التغييرات هنا، يجب عليك تعديل الملف حيث تم تثبيت مصمم التقارير من Microsoft Visual Studio.
### **الخطوة 1. افتح دليل Visual Studio.**
- للتكامل مع مصمم تقارير Visual Studio 2005، افتح الدليل C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- للتكامل مع مصمم تقارير Visual Studio 2008، افتح الدليل C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **الخطوة 2. أضف الكود لإضافة كلمة المرور للعروض التقديمية المصدرة.**
استبدل المكونات الإضافية الحالية لـ Aspose.Slides لخدمات التقارير في ملف **rsreportserver.config**. للقيام بذلك، افتح ملف C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config (حيث **<Version>** هو "8" لـ Visual Studio 2005 أو "9.0" لـ Visual Studio 2008) وأضف هذه الأسطر في عنصر **<Render>**. ثم استبدلها بالكود في جزء الكود التالي.
#### **ابحث عن خيارات تقديم Aspose.Slides لخدمات التقارير**
**<Render>**

``` xml

   ...

  <!--ابدأ هنا.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--انتهى هنا.-->

</Render>

```
#### **كود الاستبدال**
**<Render>**

``` xml

   ...

  <!--ابدأ هنا.-->


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

  <!--انتهى هنا.-->

</Render>

```
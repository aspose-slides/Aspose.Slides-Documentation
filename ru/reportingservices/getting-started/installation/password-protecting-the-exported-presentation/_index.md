---
title: Защита экспортированной презентации паролем
type: docs
weight: 90
url: /reportingservices/password-protecting-the-exported-presentation/
---

{{% alert color="primary" %}} 

Защита презентации паролем предотвращает несанкционированное использование и доступ. Защита паролем полезна, если вы создаете отчеты, содержащие конфиденциальные данные или детали, которые должны видеть только некоторые сотрудники вашей организации.

В этой статье показано, как обновить вашу среду Reporting Services или Visual Studio, чтобы сохранить презентации с защитой паролем.

{{% /alert %}} 
## **Добавление защиты паролем на экспортированные презентации в среде Reporting Services**
Чтобы применить изменения, необходимо изменить файлы в директории, где установлен Microsoft SQL Server Reporting Services.
### **Шаг 1. Найдите директорию установки Reporting Server.**
Корневая директория для Microsoft SQL Server обычно C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

Для 64-разрядной системы 32-разрядный экземпляр SQL Server установлен в C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 и 2008: На машине может быть несколько экземпляров Microsoft SQL Server. Каждый занимает отдельный подкаталог MSSQL.x, например MSSQL.1, MSSQL.2 и так далее. Найдите правильный каталог C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer, прежде чем продолжить выполнение следующих шагов.

Все пути, используемые ниже, относятся к директории установки Microsoft SQL Server Reporting Services как <Instance>.
### **Шаг 2. Добавьте код для добавления паролей к экспортированным презентациям**
Замените существующие расширения рендеринга Aspose.Slides для Reporting Services в файле **rsreportserver.config**. Для этого откройте файл C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config. 

Найдите перечисленные ниже параметры рендеринга и замените их кодом из следующего сегмента.
#### **Найдите параметры рендеринга Aspose.Slides для Reporting Service**
**<Render>**

``` xml

   ...

  <!--Начните здесь.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Завершите здесь.-->


</Render>



```
#### **Код замены**
**<Render>**

``` xml

   ...

  <!--Начните здесь.-->



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

  <!--Завершите здесь.-->


</Render>



```
### **Добавление защиты паролем для экспортированных презентаций в Visual Studio**
Чтобы применить изменения, необходимо изменить файл, в котором установлен Microsoft Visual Studio Report Designer.
### **Шаг 1. Откройте директорию Visual Studio.**
- Чтобы интегрироваться с Visual Studio 2005 Report Designer, откройте директорию C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Чтобы интегрироваться с Visual Studio 2008 Report Designer, откройте директорию C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Шаг 2. Добавьте код для добавления пароля к экспортированным презентациям.**
Замените существующие расширения рендеринга Aspose.Slides для Reporting Services в файле **rsreportserver.config**. Для этого откройте файл C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config (где **<Version>** это “8” для Visual Studio 2005 или “9.0” для Visual Studio 2008) и добавьте эти строки в элемент **<Render>**. Затем замените их кодом из следующего сегмента.
#### **Найдите параметры рендеринга Aspose.Slides для Reporting Service**
**<Render>**

``` xml

   ...

  <!--Начните здесь.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Завершите здесь.-->


</Render>



```
#### **Код замены**
**<Render>**

``` xml

   ...

  <!--Начните здесь.-->



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

  <!--Завершите здесь.-->


</Render>



```
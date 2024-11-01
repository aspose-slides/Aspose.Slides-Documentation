---
title: Password Protecting the Exported Presentation
type: docs
weight: 90
url: /reportingservices/password-protecting-the-exported-presentation/
---

{{% alert color="primary" %}} 

Password protecting a presentation prevents unauthorized use and access. Password protection is useful if you are creating reports that contain sensitive data or details that only some people in your organization should see.

This article shows you how to update your Reporting Services or Visual Studio environment to allow you to save presentations with password protection.

{{% /alert %}} 
## **Adding Password Protection on Exported Presentations in a Reporting Services Environment**
To apply the changes here, you need to modify files in the directory where Microsoft SQL Server Reporting Services is installed.
### **Step 1. Locate the Reporting Server installation directory.**
The root directory for Microsoft SQL Server is usually C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

For x64 bit System the x86 instance of SQL Server is installed at C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 and 2008: There could be several instances of Microsoft SQL Server configured on the machine. Each occupies a different MSSQL.x subdirectory, for example MSSQL.1, MSSQL.2 and so on. Find the correct C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer directory before proceeding with the following steps.

All paths used below refer to the Microsoft SQL Server Reporting Services installation directory as <Instance>.
### **Step 2. Add the code for adding passwords to exported presentations**
Replace the existing Aspose.Slides for Reporting Services rendering extensions in the **rsreportserver.config** file. To do this, open the C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config file. 

Find the rendering options listed immediately below and replace them with the code in the segment that follows after that.
#### **Find Aspose.Slides for Reporting Service Rendering Options**
**<Render>**

``` xml

   ...

  <!--Start here.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--End here.-->


</Render>



```
#### **Replacement Code**
**<Render>**

``` xml

   ...

  <!--Start here.-->



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

  <!--End here.-->


</Render>



```
### **Adding Password Protection for Exported Presentations in Visual Studio**
To apply the changes here, you need to modify the file where the Microsoft Visual Studio Report Designer is installed.
### **Step 1. Open the Visual Studio directory.**
- To integrate with Visual Studio 2005 Report Designer, open the C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies directory.
- To integrate with Visual Studio 2008 Report Designer, open the C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies directory.
### **Step 2. Add the code for adding password to exported presentations.**
Replace the existing Aspose.Slides for Reporting Services rendering extensions in the **rsreportserver.config** file. To do this, open the C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config file (where **<Version>** is “8” for Visual Studio 2005 or “9.0” for Visual Studio 2008) and add these lines in the **<Render>** element. Then replace them with the code in the next code segment.
#### **Find Aspose.Slides for Reporting Service Rendering Options**
**<Render>**

``` xml

   ...

  <!--Start here.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--End here.-->


</Render>



```
#### **Replacement Code**
**<Render>**

``` xml

   ...

  <!--Start here.-->



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

  <!--End here.-->


</Render>



```

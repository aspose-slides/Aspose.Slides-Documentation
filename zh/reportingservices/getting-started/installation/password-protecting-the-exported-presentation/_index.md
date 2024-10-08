---
title: 保护导出演示文稿的密码
type: docs
weight: 90
url: /zh/reportingservices/password-protecting-the-exported-presentation/
---

{{% alert color="primary" %}} 

保护演示文稿的密码可以防止未经授权的使用和访问。如果您正在创建包含敏感数据或仅供某些人查看的详细信息的报告，密码保护非常有用。

本文将向您展示如何更新 Reporting Services 或 Visual Studio 环境，以允许您保存带有密码保护的演示文稿。

{{% /alert %}} 
## **在 Reporting Services 环境中为导出演示文稿添加密码保护**
要应用此处的更改，您需要修改 Microsoft SQL Server Reporting Services 安装目录中的文件。
### **步骤 1. 找到 Reporting Server 安装目录。**
Microsoft SQL Server 的根目录通常是 C:\Program Files\Microsoft SQL Server。

{{% alert color="primary" %}} 

对于 x64 位系统，x86 实例的 SQL Server 安装在 C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 和 2008：该机器上可能配置了多个 Microsoft SQL Server 实例。每个实例占用不同的 MSSQL.x 子目录，例如 MSSQL.1、MSSQL.2 等。请在继续执行以下步骤之前，找到正确的 C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer 目录。

以下使用的所有路径均指 Microsoft SQL Server Reporting Services 安装目录为 <Instance>。
### **步骤 2. 添加导出演示文稿的密码代码**
在 **rsreportserver.config** 文件中替换现有的 Aspose.Slides for Reporting Services 渲染扩展。为此，打开 C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config 文件。

找到紧接着列出的渲染选项，并将其替换为后面代码段中的代码。
#### **找到 Aspose.Slides for Reporting Service 渲染选项**
**<Render>**

``` xml

   ...

  <!--从这里开始.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--到这里结束.-->


</Render>

```
#### **替换代码**
**<Render>**

``` xml

   ...

  <!--从这里开始.-->


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

  <!--到这里结束.-->


</Render>

```
### **在 Visual Studio 中为导出演示文稿添加密码保护**
要在这里应用更改，您需要修改安装 Microsoft Visual Studio Report Designer 的文件。
### **步骤 1. 打开 Visual Studio 目录。**
- 要与 Visual Studio 2005 Report Designer 集成，请打开 C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies 目录。
- 要与 Visual Studio 2008 Report Designer 集成，请打开 C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies 目录。
### **步骤 2. 添加导出演示文稿的密码代码。**
在 **rsreportserver.config** 文件中替换现有的 Aspose.Slides for Reporting Services 渲染扩展。为此，打开 C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config 文件（其中 **<Version>** 对于 Visual Studio 2005 为“8”，对于 Visual Studio 2008 为“9.0”），并在 **<Render>** 元素中添加这些行。然后用下一个代码段中的代码替换它们。
#### **找到 Aspose.Slides for Reporting Service 渲染选项**
**<Render>**

``` xml

   ...

  <!--从这里开始.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--到这里结束.-->


</Render>

```
#### **替换代码**
**<Render>**

``` xml

   ...

  <!--从这里开始.-->


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

  <!--到这里结束.-->


</Render>

```
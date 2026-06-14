---
title: 匯出簡報的密碼保護
type: docs
weight: 90
url: /zh-hant/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

為簡報設定密碼保護可防止未經授權的使用和存取。若您正在建立含有機密資料或僅限組織內特定人員檢視的細節的報告，密碼保護相當有用。

{{% /alert %}} 
## **在 Reporting Services 環境中為匯出的簡報新增密碼保護**
若要套用此處的變更，您需要修改 Microsoft SQL Server Reporting Services 安裝目錄中的檔案。
### **步驟 1. 找到 Reporting Server 的安裝目錄。**
Microsoft SQL Server 的根目錄通常位於 C:\Program Files\Microsoft SQL Server。

{{% alert color="primary" %}} 

對於 x64 位元系統，SQL Server 的 x86 實例安裝在 C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 與 2008：機器上可能已配置多個 Microsoft SQL Server 實例。每個實例佔用不同的 MSSQL.x 子目錄，例如 MSSQL.1、MSSQL.2 等。請先找到正確的 C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer 目錄，再繼續以下步驟。

以下所有路徑皆指 Microsoft SQL Server Reporting Services 安裝目錄，稱為 <Instance>。
### **步驟 2. 新增程式碼以為匯出的簡報設定密碼**
在 **rsreportserver.config** 檔案中取代現有的 Aspose.Slides for Reporting Services 呈現擴充功能。為此，開啟 C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config 檔案。

尋找下列立即出現的呈現選項，並以後續段落中的程式碼取代它們。
#### **尋找 Aspose.Slides for Reporting Service 的轉譯選項**
**<Render>**

``` xml

   ...

  <!--從此開始。>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--在此結束。-->


</Render>



```
#### **取代程式碼**
**<Render>**

``` xml

   ...

  <!--從此開始。-->



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

  <!--在此結束。-->


</Render>



```
### **在 Visual Studio 中為匯出的簡報新增密碼保護**
若要套用此處的變更，您需要修改 Microsoft Visual Studio Report Designer 所在的檔案。
### **步驟 1. 開啟 Visual Studio 目錄。**
- 若要與 Visual Studio 2005 報表設計師整合，請開啟 C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies 目錄。
- 若要與 Visual Studio 2008 報表設計師整合，請開啟 C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies 目錄。
### **步驟 2. 新增程式碼以為匯出的簡報設定密碼。**
在 **rsreportserver.config** 檔案中取代現有的 Aspose.Slides for Reporting Services 呈現擴充功能。為此，開啟 C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config 檔案（其中 **<Version>** 為 Visual Studio 2005 時的「8」或 Visual Studio 2008 時的「9.0」），並在 **<Render>** 元素中加入這些行。然後以下一段程式碼取代它們。
#### **尋找 Aspose.Slides for Reporting Service 的轉譯選項**
**<Render>**

``` xml

   ...

  <!--從此開始。-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--在此結束。-->


</Render>



```
#### **取代程式碼**
**<Render>**

``` xml

   ...

  <!--從此開始。-->


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

  <!--在此結束。-->


</Render>
```
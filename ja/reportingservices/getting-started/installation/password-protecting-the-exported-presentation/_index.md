---
title: エクスポートされたプレゼンテーションのパスワード保護
type: docs
weight: 90
url: /ja/reportingservices/password-protecting-the-exported-presentation/
---

{{% alert color="primary" %}} 

プレゼンテーションにパスワードを保護することで、無許可の使用やアクセスを防ぎます。パスワード保護は、機密データや組織内の特定の人だけが見るべき詳細を含むレポートを作成する際に便利です。

この記事では、エクスポートしたプレゼンテーションをパスワード保護で保存できるように、Reporting ServicesまたはVisual Studio環境を更新する方法を示します。

{{% /alert %}} 
## **Reporting Services環境でのエクスポートされたプレゼンテーションへのパスワード保護の追加**
ここでの変更を適用するには、Microsoft SQL Server Reporting Servicesがインストールされているディレクトリ内のファイルを修正する必要があります。
### **ステップ1. Reporting Serverのインストールディレクトリを特定する。**
Microsoft SQL Serverのルートディレクトリは通常C:\Program Files\Microsoft SQL Serverです。

{{% alert color="primary" %}} 

x64ビットシステムの場合、SQL Serverのx86インスタンスはC:\Program Files (x86)\Microsoft SQL Serverにインストールされています。

{{% /alert %}} 

Microsoft SQL Server 2005および2008：マシンには複数のMicrosoft SQL Serverインスタンスが構成されている可能性があります。それぞれが異なるMSSQL.xサブディレクトリを占有しており、例えばMSSQL.1、MSSQL.2などです。次の手順に進む前に、正しいC:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServerディレクトリを見つけてください。

以下で使用されるすべてのパスは、Microsoft SQL Server Reporting Servicesインストールディレクトリを<Instance>として参照します。
### **ステップ2. エクスポートされたプレゼンテーションにパスワードを追加するコードを追加する**
**rsreportserver.config**ファイル内の既存のAspose.Slides for Reporting Servicesレンダリング拡張機能を置き換えます。これを行うには、C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.configファイルを開きます。 

直後にリストされているレンダリングオプションを見つけ、次のセグメントにあるコードに置き換えます。
#### **Aspose.Slides for Reporting Serviceレンダリングオプションを見つける**
**<Render>**

``` xml

   ...

  <!--ここから開始.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--ここまで。-->


</Render>



```
#### **置換コード**
**<Render>**

``` xml

   ...

  <!--ここから開始.-->



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

  <!--ここまで。-->


</Render>



```
### **Visual Studioでエクスポートされたプレゼンテーションにパスワード保護を追加する**
ここでの変更を適用するには、Microsoft Visual Studioレポートデザイナーがインストールされているファイルを修正する必要があります。
### **ステップ1. Visual Studioディレクトリを開く。**
- Visual Studio 2005レポートデザイナーと統合するには、C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssembliesディレクトリを開きます。
- Visual Studio 2008レポートデザイナーと統合するには、C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssembliesディレクトリを開きます。
### **ステップ2. エクスポートされたプレゼンテーションにパスワードを追加するコードを追加する。**
**rsreportserver.config**ファイル内の既存のAspose.Slides for Reporting Servicesレンダリング拡張機能を置き換えます。これを行うには、C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.configファイルを開き（**<Version>**はVisual Studio 2005の場合は「8」、Visual Studio 2008の場合は「9.0」）、**<Render>**要素内にこれらの行を追加します。それから次のコードセグメントのコードに置き換えます。
#### **Aspose.Slides for Reporting Serviceレンダリングオプションを見つける**
**<Render>**

``` xml

   ...

  <!--ここから開始.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--ここまで。-->


</Render>



```
#### **置換コード**
**<Render>**

``` xml

   ...

  <!--ここから開始.-->



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

  <!--ここまで。-->


</Render>



```
---
title: Melindungi Presentasi yang Diekspor dengan Kata Sandi
type: docs
weight: 90
url: /id/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

Mengamankan presentasi dengan kata sandi mencegah penggunaan dan akses yang tidak sah. Perlindungan kata sandi berguna jika Anda membuat laporan yang berisi data sensitif atau detail yang hanya boleh dilihat oleh sebagian orang di organisasi Anda.

{{% /alert %}} 
## **Menambahkan Perlindungan Kata Sandi pada Presentasi yang Diekspor dalam Lingkungan Reporting Services**
Untuk menerapkan perubahan ini, Anda perlu memodifikasi file di direktori tempat Microsoft SQL Server Reporting Services diinstal.
### **Langkah 1. Temukan direktori instalasi Reporting Server.**
Direktori root untuk Microsoft SQL Server biasanya C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

Untuk sistem 64‑bit, instance x86 dari SQL Server diinstal di C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 dan 2008: Mungkin terdapat beberapa instance Microsoft SQL Server yang dikonfigurasi pada mesin. Setiap instance menempati subdirektori MSSQL.x yang berbeda, misalnya MSSQL.1, MSSQL.2, dan sebagainya. Temukan direktori yang tepat C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer sebelum melanjutkan ke langkah berikutnya.

Semua jalur yang digunakan di bawah mengacu pada direktori instalasi Microsoft SQL Server Reporting Services sebagai <Instance>.
### **Langkah 2. Tambahkan kode untuk menambahkan kata sandi pada presentasi yang diekspor**
Ganti ekstensi rendering Aspose.Slides for Reporting Services yang ada di file **rsreportserver.config**. Untuk melakukannya, buka file C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config.

Temukan opsi rendering yang tercantum tepat di bawah ini dan ganti dengan kode pada segmen berikutnya.
#### **Temukan Opsi Rendering Aspose.Slides untuk Reporting Service**
**<Render>**

``` xml

   ...

  <!--Mulai di sini.>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Akhiri di sini.-->


</Render>



```
#### **Kode Pengganti**
**<Render>**

``` xml

   ...

  <!--Mulai di sini.-->


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

  <!--Akhiri di sini.-->


</Render>



```
### **Menambahkan Perlindungan Kata Sandi untuk Presentasi yang Diekspor di Visual Studio**
Untuk menerapkan perubahan ini, Anda perlu memodifikasi file tempat Microsoft Visual Studio Report Designer diinstal.
### **Langkah 1. Buka direktori Visual Studio.**
- Untuk mengintegrasikan dengan Visual Studio 2005 Report Designer, buka direktori C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Untuk mengintegrasikan dengan Visual Studio 2008 Report Designer, buka direktori C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Langkah 2. Tambahkan kode untuk menambahkan kata sandi pada presentasi yang diekspor.**
Ganti ekstensi rendering Aspose.Slides for Reporting Services yang ada di file **rsreportserver.config**. Untuk melakukannya, buka file C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config (di mana **<Version>** adalah “8” untuk Visual Studio 2005 atau “9.0” untuk Visual Studio 2008) dan tambahkan baris-baris ini ke dalam elemen **<Render>**. Kemudian gantikan dengan kode pada segmen kode berikutnya.
#### **Temukan Opsi Rendering Aspose.Slides untuk Reporting Service**
**<Render>**

``` xml

   ...

  <!--Mulai di sini.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Akhiri di sini.-->


</Render>



```
#### **Kode Pengganti**
**<Render>**

``` xml

   ...

  <!--Mulai di sini.-->


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

  <!--Akhiri di sini.-->


</Render>

```
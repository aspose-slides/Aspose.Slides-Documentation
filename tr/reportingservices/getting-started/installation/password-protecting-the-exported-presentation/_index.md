---
title: Dışa Aktarılan Sunumu Şifreyle Koruma
type: docs
weight: 90
url: /tr/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

Bir sunumu şifreyle korumak yetkisiz kullanım ve erişimi önler. Şifre koruması, hassas veriler veya yalnızca kuruluşunuzdaki belirli kişilerin görmesi gereken ayrıntılar içeren raporlar oluşturuyorsanız faydalıdır.

Bu makale, raporlama hizmetleri veya Visual Studio ortamınızı şifre korumalı sunumlar kaydedebilmeniz için nasıl güncelleyeceğinizi gösterir.

{{% /alert %}} 
## **Raporlama Hizmetleri Ortamında Dışa Aktarılan Sunumlara Şifre Koruması Eklemek**
Buradaki değişiklikleri uygulamak için Microsoft SQL Server Reporting Services'in yüklü olduğu dizindeki dosyaları değiştirmeniz gerekir.
### **Adım 1. Raporlama Sunucusunun kurulum dizinini bulun.**
Microsoft SQL Server için kök dizin genellikle C:\Program Files\Microsoft SQL Server'dir.

{{% alert color="primary" %}} 

x64 bit sistemlerde SQL Server'ın x86 örneği C:\Program Files (x86)\Microsoft SQL Server\ dizinine kurulur.

{{% /alert %}} 

Microsoft SQL Server 2005 ve 2008: Makinede birden fazla Microsoft SQL Server örneği yapılandırılmış olabilir. Her biri farklı bir MSSQL.x alt dizinine sahiptir; örneğin MSSQL.1, MSSQL.2 vb. Aşağıdaki adımlara geçmeden önce doğru C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer dizinini bulun.

Aşağıda kullanılan tüm yollar, Microsoft SQL Server Reporting Services kurulum dizini <Instance> olarak belirtilir.
### **Adım 2. Dışa aktarılan sunumlara şifre eklemek için kodu ekleyin**
Mevcut **rsreportserver.config** dosyasındaki Aspose.Slides for Reporting Services render uzantılarını değiştirin. Bunun için C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config dosyasını açın. 

Aşağıda listelenen render seçeneklerini bulun ve bunları ardından gelen kod segmentiyle değiştirin.
#### **Aspose.Slides for Reporting Service Render Seçeneklerini Bulun**
**<Render>**

``` xml

   ...

  <!--Buradan başlayın.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Buradan bitir.-->


</Render>
```
#### **Değiştirme Kodu**
**<Render>**

``` xml

   ...

  <!--Buradan başlayın.-->



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

  <!--Buradan bitir.-->


</Render>
```
### **Visual Studio'da Dışa Aktarılan Sunumlara Şifre Koruması Eklemek**
Buradaki değişiklikleri uygulamak için Microsoft Visual Studio Report Designer'ın yüklü olduğu dosyayı değiştirmeniz gerekir.
### **Adım 1. Visual Studio dizinini açın.**
- Visual Studio 2005 Report Designer ile bütünleştirmek için C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies dizinini açın.
- Visual Studio 2008 Report Designer ile bütünleştirmek için C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies dizinini açın.
### **Adım 2. Dışa aktarılan sunumlara şifre eklemek için kodu ekleyin.**
Mevcut **rsreportserver.config** dosyasındaki Aspose.Slides for Reporting Services render uzantılarını değiştirin. Bunun için C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config dosyasını açın (**<Version>** “8” Visual Studio 2005 için veya “9.0” Visual Studio 2008 için) ve bu satırları **<Render>** öğesine ekleyin. Ardından bunları bir sonraki kod segmentindeki kodla değiştirin.
#### **Aspose.Slides for Reporting Service Render Seçeneklerini Bulun**
**<Render>**

``` xml

   ...

  <!--Buradan başlayın.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Buradan bitir.-->


</Render>
```
#### **Değiştirme Kodu**
**<Render>**

``` xml

   ...

  <!--Buradan başlayın.-->



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

  <!--Buradan bitir.-->


</Render>

```
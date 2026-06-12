---
title: Menyesuaikan Caption Ekstensi Rendering PowerPoint
type: docs
weight: 60
url: /id/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 
Artikel ini menunjukkan cara menyesuaikan caption opsi rendering Aspose.Slides untuk Reporting Services. 
{{% /alert %}} 
## **Contoh**
Saat menginstal Aspose.Slides untuk Reporting Services, 4 opsi ekspor tambahan ditambahkan di menu dropdown opsi ekspor:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **Cara memodifikasi teks caption**
Caption default dari ekstensi ini dapat diubah dengan mengganti nama default. Langkah-langkah berikut menunjukkan cara mengubah caption dari “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” menjadi “ **PowerPoint 97 – 2003 format(PPT)** ”. 

**Langkah** **1:** Temukan file **rsreportserver.config** yang biasanya berada di direktori berikut: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Langkah** **2:** Temukan baris-baris ini dalam file rsreportserver.config: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**Langkah** **3:** Ganti parameter ekstensi dengan yang berikut: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

Opsi ekspor sekarang akan muncul seperti ini: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)
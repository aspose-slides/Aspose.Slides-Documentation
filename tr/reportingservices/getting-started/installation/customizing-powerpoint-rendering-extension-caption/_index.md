---
title: PowerPoint Oluşturma Uzantısı Altyazısını Özelleştirme
type: docs
weight: 60
url: /tr/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 

Bu makale, Aspose.Slides for Reporting Services oluşturma seçenekleri altyazılarını nasıl özelleştireceğinizi gösterir. 

{{% /alert %}} 
## **Örnek**
Aspose.Slides for Reporting Services kurulduğunda, dışa aktarma seçenekleri açılır menüsüne 4 ek dışa aktarma seçeneği eklenir:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **Altyazı metnini nasıl değiştirirsiniz**
Bu uzantıların varsayılan altyazıları, varsayılan adları geçersiz kılarak değiştirilebilir. Bu adımlar, “**PPT – PowerPoint** **Presentation via** **Aspose.Slides**” altyazısını “**PowerPoint 97 – 2003 formatı(PPT)**” olarak nasıl değiştireceğinizi gösterir. 

**Adım 1:** Genellikle şu dizinde bulunan **rsreportserver.config** dosyasını bulun: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Adım** **2:** rsreportserver.config dosyasında bu satırları bulun: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**Adım** **3:** Uzantı parametresini şu şekilde değiştirin: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

Dışa aktarma seçenekleri artık şöyle görünecektir: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)
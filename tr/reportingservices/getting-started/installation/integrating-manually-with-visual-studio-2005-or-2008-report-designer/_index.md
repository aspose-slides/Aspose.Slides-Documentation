---
title: Visual Studio 2005 veya 2008 Report Designer ile Elle Entegrasyon
type: docs
weight: 50
url: /tr/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

Bu makale, Aspose.Slides for Reporting Services'ı Visual Studio ile elle nasıl bütünleştireceğinizi öğretir. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** için ana makinede **.NET Framework 3.5** kurulmuş olmalıdır. 

{{% /alert %}}

## **Aspose.Slides for Reporting Services'ın Visual Studio ile Entegrasyonu**
Aspose.Slides for Reporting Services'ı kurmak için MSI yükleyicisini kullanmanızı öneririz; çünkü tüm gerekli kurulum görevlerini ve yapılandırma işlemlerini otomatik olarak gerçekleştirir. Ancak MSI yükleyicisiyle kurulum başarısız olursa, burada verilen rehberi izleyin. 

Bu makale ayrıca Aspose.Slides for Reporting Services'ı Business Intelligence Development Studio yüklü bir bilgisayara nasıl kuracağınızı gösterir. Böylece Microsoft Visual Studio 2005 veya 2008 Report Designer'dan tasarım aşamasında raporları Microsoft PowerPoint formatlarına dışa aktarabilirsiniz. 

1. Aspose.Slides.ReportingServices.dll dosyasını Visual Studio dizinine kopyalayın.

   - Visual Studio 2005 Report Designer ile bütünleştirmek için **Aspose.Slides.ReportingServices.dll** dosyasını **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies** dizinine kopyalayın.
   - Visual Studio 2008 Report Designer ile bütünleştirmek için **Aspose.Slides.ReportingServices.dll** dosyasını **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** dizinine kopyalayın.
2. Aspose.Slides for Reporting Services'ı bir render uzantısı olarak kaydedin. 

3. **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** dosyasını açın (burada <Version> Visual Studio 2005 için “8”, Visual Studio 2008 için “9.0” demektir) ve <Render> öğesine şu satırları ekleyin: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Aspose.Slides for Reporting Services'a çalıştırma izni verin. 
   1. **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** dosyasını açın (burada <Version> Visual Studio 2005 için “8”, Visual Studio 2008 için “9.0” demektir).
   1. Bu satırı, dıştaki ikinci <CodeGroup> öğesinin (şu şekilde olmalıdır: <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) son öğesi olarak ekleyin. 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Buradan başlayın.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="This code group grants full trust to the AS4SSRS assembly.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--Buradan bitir.-->

  </CodeGroup>

</CodeGroup>



```

5. Aspose.Slides for Reporting Services'ın başarılı bir şekilde kurulduğunu doğrulayın. 
6. Microsoft Visual Studio 2005 veya 2008 Report Designer'ı çalıştırın veya yeniden başlatın. Dışa aktarma biçimleri listesinde yeni formatların göründüğünü fark edeceksiniz.

**Yeni dışa aktarma formatları Report Designer'da görünür.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)
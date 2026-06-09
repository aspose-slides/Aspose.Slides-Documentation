---
title: Aspose.Slides for Reporting Services Yeniden Kurulması
type: docs
weight: 40
url: /tr/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

Bu makale, Aspose.Slides for Reporting Services zaten yüklü olduğunda, ancak herhangi bir nedenle yeniden kurulması gerektiğinde uygulanacak düzeltmeyi açıklar.

{{% /alert %}} 

{{% alert title="Not" color="warning" %}} 

**Aspose.Slides for Reporting Services**, ana bilgisayarda **.NET Framework 3.5** kurulumu gerektirir. 

{{% /alert %}}

## **Aspose.Slides for Reporting Services yeniden kurulum adımları**
En önemli şey, önceki Aspose.Slides for Reporting Services kurulumlarının tamamen kaldırılmasıdır. MSI yükleyicisi gerekli kaldırma ve ardından yeniden kurma işlemlerini otomatik olarak yapabilse de, aşağıdaki adımlar izlenmelidir:

1. MSI yükleyicisini kullanarak Aspose.Slides for Reporting Services'i kaldırın. 

2. Aspose.Slides for Reporting Services kurulum dizinini bulun; genellikle şu konumdadır:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. MSI yükleyicisi Aspose.Slides for Reporting Services'i kaldırırken “Aspose.Slides for Reporting Services” dizinini kaldırmadıysa, klasörü silin. 

4. Her SQL Server Reporting Services örneğinin “bin” dizininde **Aspose.Slides.ReportingServices.dll** ikili dosyasını bulun. Örneğin, bir Microsoft SQL Server 2008 örneği “MSSQLSERVER” varsa, ilgili Reporting Service “bin” dizini muhtemelen şu konumdadır: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. MSI yükleyicisi Aspose.Slides for Reporting Services'i kaldırırken yukarıdaki dizinden Aspose.Slides.ReportingServices.dll ikili dosyasını kaldırmadıysa, dosyayı şimdi silin.

6. **rsreportserver.config** dosyasını her SSRS örneği için bulun. Örneğin, bir Reporting Service örneği “**MSRS10.MSSQLSERVER**” varsa, **rsreportserver.config** dosyası şu dizinde olacaktır:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. **rsreportserver.config** dosyasını herhangi bir editörde açın ve Aspose.Slides for Reporting Services kurulumu sırasında PowerPoint Format Uzantılarını eklemek için oluşturulan satırları bulun. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Adım** **8:** MSI yükleyicisi Aspose.Slides for Reporting Services'i kaldırırken bu satırları kaldırmadıysa, **rsreportserver.config** dosyasından satırları şimdi silin.

**Adım** **9:** Her SSRS örneği için **rssrvpolicy.config** dosyasını bulun. Örneğin, bir Reporting Service örneği “MSRS10.MSSQLSERVER” varsa, **rssrvpolicy.config** dosyası şu dizinde olacaktır:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Adım** **10:** **rssrvpolicy.config** dosyasını herhangi bir editörde açın ve Aspose.Slides for Reporting Services kurulumu sırasında yürütme izinleri vermek için oluşturulan satırları bulun. 

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

    <!--Buradan bitirin.-->

  </CodeGroup>

</CodeGroup>



```

**Adım** **11:** MSI yükleyicisi ürünü kaldırırken yukarıdaki satırları kaldırmadıysa, **rssrvpolicy.config** dosyasından bu satırları şimdi kaldırın. 

**Adım** **12:** Aspose.Slides for Reporting Services, Microsoft Visual Studio içinde RDL rapor geliştirme ve PowerPoint Formatlarına dışa aktarım için Microsoft Visual Studio ile de yüklendiyse, Microsoft Visual Studio 2008 durumu için **Aspose.Slides.ReportingServices.dll** ikili dosyası ve yapılandırma dosyaları (**rsreportserver.config** ve **rssrvpolicy.config**) şu konumda olmalıdır: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Adım** **13:** MSI yükleyicisi **Aspose.Slides.ReportingServices.dll** ikili dosyasını kaldırmadıysa, silin. Ayrıca, **rsreportserver.config** ve **rssrvpolicy.config** dosyalarını sırasıyla PowerPoint Format Uzantılarını ve kod yürütme izinlerini kaldıracak şekilde güncellemediyse, önceki adımlarda yaptığınız gibi bu dosyaları da manuel olarak kaldırmanız gerekir. 

**Adım** **14:** Aspose.Slides for Reporting Services'i yeniden kurma zamanı. Otomatik kurulum için MSI yükleyicisini kullanın ya da manuel olarak yapın.
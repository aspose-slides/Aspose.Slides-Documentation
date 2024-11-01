---
title: Re Installing Aspose.Slides for Reporting Services
type: docs
weight: 40
url: /reportingservices/re-installing-aspose-slides-for-reporting-services/
---

{{% alert color="primary" %}} 

This article describes the fix for a situation in which Aspose.Slides for Reporting Services is already installed, but for whatever reason, it has to be reinstalled.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** requires the installation of **.NET Framework 3.5** on the host machine. 

{{% /alert %}}

## **Steps of Re-installing Aspose.Slides for Reporting Services**
The most important thing is the removal of the previous Aspose.Slides for Reporting Services installations completely. While the MSI installer can successfully perform the necessary actions required to uninstall and, hence, reinstall Aspose.Slides for Reporting Services automatically, these steps must be followed:

1. Uninstall Aspose.Slides for Reporting Services using MSI installer. 

2. Locate Aspose.Slides for Reporting Services installation directory that is typically at:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3.  If the MSI installer has not removed the “Aspose.Slides for Reporting Services” directory when it uninstalled Aspose.Slides for Reporting Services, delete the folder. 

4. Locate **Aspose.Slides.ReportingServices.dll** binary in “bin” directory of each SQL Server Reporting Service instance. For example, if there is a Microsoft SQL Server 2008 instance “MSSQLSERVER”, the corresponding Reporting Service “bin” directory is likely to be at: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. If the MSI installer has not removed Aspose.Slides.ReportingServices.dll binary file from the directory above when it uninstalled Aspose.Slides for Reporting Services, delete the file now.

6. Locate **rsreportserver.config** file for each SSRS instance. For example, if there is a Reporting Service instance “ **MSRS10.MSSQLSERVER** ”, the **rsreportserver.config** file will be in this directory:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Open the **rsreportserver.config** file in any editor and find the lines that were created to add PowerPoint Format Extensions during the installation of Aspose.Slides for Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** If MSI installer has not removed those lines when it uninstalled Aspose.Slides for Reporting Services, delete the lines from **rsreportserver.config** file now.

**Step** **9:** Locate the **rssrvpolicy.config** file for each SSRS instance. For example, if there is a Reporting Ser vice instance “ MSRS10.MSSQLSERVER ”, the **rssrvpolicy.config** file will be in this directory:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Step** **10:** Open the **rssrvpolicy.config** file in any editor and find the the lines that were created to grant execution permissions to Aspose.Slides for Reporting Services during the installation of Aspose.Slides for Reporting Services. 

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--Start here.-->

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

    <!--End here.-->

  </CodeGroup>

</CodeGroup>



```

**Step** **11:** If the MSI installer has not removed the lines above when it uninstalled the product, remove those lines from the **rssrvpolicy.config** file now. 

**Step** **12:** If Aspose.Slides for Reporting Services was also installed with Microsoft Visual Studio for RDL report development and export to PowerPoint Formats within Microsoft Visual Studio environment, the binary file Aspose.Slides.ReportingServices.dll and configuration files ( **rsreportserver.config** and **rssrvpolicy.config** ) in case of Microsoft Visual Studio 2008 should be: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Step** **13:** If the MSI installer has not removed the **Aspose.Slides.ReportingServices.dll** binary, delete it. Moreover, if it has not updated the **rsreportserver.config** and **rssrvpolicy.config** files to remove PowerPoint Format Extensions and code execution permissions respectively, you have to remove them manually the same way you did with files in previous steps. 

**Step** **14:** It is time to reinstall Aspose.Slides for Reporting Services. Use the MSI installer for automatic installation or do it manually. 

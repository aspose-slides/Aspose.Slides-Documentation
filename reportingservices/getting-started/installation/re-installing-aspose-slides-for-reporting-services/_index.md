---
title: Re Installing Aspose.Slides for Reporting Services
type: docs
weight: 40
url: /reportingservices/re-installing-aspose-slides-for-reporting-services/
---

{{% alert color="primary" %}} 

This section explains the scenario where Aspose.Slides for Reporting Services is already installed and for some reason, reinstallation of Aspose.Slides for Reporting Services is required. 

{{% /alert %}} 
#### **Steps of Re-installing Aspose.Slides for Reporting Services**
T he most important point to consider is to remove the previous Aspose.Slides for Reporting Services installations completely. Although, the MSI installer can successfully perform the necessary actions required to uninstall and hence reinstall Aspose.Slides for Reporting Services automatically, yet the following checklist of steps will ensure to achieve the desired results: 

**Step** **1:** Uninstall Aspose.Slides for Reporting Services using MSI installer. 


**Step** **2:** Locate Aspose.Slides for Reporting Services installation directory which is typically located at: 

**OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 


**Step** **3:** If MSI installer has not removed “Aspose.Slides for Reporting Services” directory while uninstalling Aspose.Slides for Reporting Services, just delete it. 


**Step** **4:** Locate **Aspose.Slides.ReportingServices.dll** binary in “bin” directory of each SQL Server Reporting Service instance. For example, if there is a Microsoft SQL Server 2008 instance “MSSQLSERVER”, the corresponding Reporting Service “bin” directory will be typically located at: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 


**Step** **5:** If MSI installer has not removed Aspose.Slides.ReportingServices.dll binary file from the above directory while uninstalling Aspose.Slides for Reporting Services, just delete this file. 


**Step** **6:** Locate **rsreportserver.config** file for each SSRS instance. For example, if there is a Reporting Ser vice instance “ **MSRS10.MSSQLSERVER** ”, the **rsreportserver.config** file will be in the following directory: 

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 


**Step** **7:** Open **rsreportserver.config** file in some editor and locate the following lines that were created in order to add PowerPoint Formats Extensions during the installation of Aspose.Slides for Reporting Services. 

```

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** If MSI installer has not removed the above lines while uninstalling Aspose.Slides for Reporting Services, just delete these lines from **rsreportserver.config** file. 


**Step** **9:** Locate **rssrvpolicy.config** file for each SSRS instance. For examp le, if there is a Reporting Ser vice instance “ MSRS10.MSSQLSERVER ”, the **rssrvpolicy.config** file will be in the following directory: 

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 


**Step** **10:** Open **rssrvpolicy.config** file in some editor and locate the following lines that were created in order to grant execution permissions to Aspose.Slides for Reporting Services during the installation of Aspose.Slides for Reporting Services. 

**<CodeGroup>**

```

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

**Step** **11:** If MSI installer has not removed the above lines while uninstalling Aspose.Slides for Reporting Services, just remove these lines from **rssrvpolicy.config** file. 


**Step** **12:** If Aspose.Slides for Reporting Services was also installed with Microsoft Visual Studio for RDL report development and export to PowerPoint Formats within Microsoft Visual Studio environment: the binary file Aspose.Slides.ReportingServices.dll and configuration files ( **rsreportserver.config** and **rssrvpolicy.config** ) in case of Microsoft Visual Studio 2008 will be typically located at: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 


**Step** **13:** If MSI installer has not removed the **Aspose.Slides.ReportingServices.dll** binary, delete it. Moreover, if it has not updated the **rsreportserver.config** and **rssrvpolicy.config** files to remove PowerPoint Format Extensions and code execution permissions respectively, remove them manually in the same way as explained in the previous steps. 


**Step** **14:** Now, it is time to re-install the Aspose.Slides for Reporting Services. This can be done either through MSI installer or manually as explained in the previous sections. 

---
title: Install Manually
type: docs
weight: 30
url: /reportingservices/install-manually/
---

{{% alert color="primary" %}} 

You only need to follow these steps if you install Aspose.Slides for Reporting Services manually, not using the MSI installer. The MSI installer performs all necessary installation and registration actions automatically. 

{{% /alert %}} 
### **Manual Installation**
In the following steps, you will need to copy and modify files in the directory where Microsoft SQL Server Reporting Services is installed. 

1. Locate the Report Server installation directory.
   The root directory for Microsoft SQL Server is usually C:\Program Files\Microsoft SQL Server. {{% alert color="primary" %}} 

**Microsoft SQL Server 2005 and 2008**: There could be several instances of Microsoft SQL Server configured on the machine and they occupy different MSSQL.x subdirectories such as MSSQL.1, MSSQL.2 and so on. Find the correct **C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer** directory before proceeding.

{{% /alert %}} All paths used below will refer to this directory as <Instance>. 

1. Copy Aspose.Slides.ReportingServices.dll to **C:\Program Files\Microsoft SQL Server\ <Instance> \Reporting Services\ReportServer\bin** folder.
   The **Aspose.Slides.ReportingServices.zip** download contains the **Aspose.Slides.ReportingServices.dll** and compiled documentation in CHM format. {{% alert color="primary" %}} 

In some cases, when you copy the DLL to the **ReportServer\bin** directory, it might get copied together with the explicit NTFS file permissions assigned to it. The NTFS permissions might be such that Microsoft SQL Server Reporting Services is denied access when loading **Aspose.Slides.ReportingServices.dll**. If this happens, the new export formats do not become available. To make sure that the NTFS permissions are correct:

   1. Right click **Aspose.Slides.ReportingServices.dll**.
   1. Click **Properties** and select the **Security** tab.
   1. Remove any explicitly assigned NTFS permissions and leave only inherited permissions.

{{% /alert %}}

1. Register Aspose.Slides for Reporting Services as a rendering extension: 
   1. Open *C:\Program
      Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.
   1. Add the following lines into the <Render> element: 

**<Render>**

```

   ...

  <!--Start here.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--End here.-->

</Render>



```

1. Give Aspose.Slides for Reporting Services permissions to execute: 
   1. Open **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.
   1. Add the following as the last item in the second to outer <CodeGroup> element (which should be <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">). 

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

1. Verify that Aspose.Slides for Reporting Services was installed successfully: 
   1. Open Report Manager and check the list of available export types for a report. {{% alert color="primary" %}} 

You can launch Report Manager by opening a browser (Microsoft Internet Explorer 6.0 or later) and typing the Report Manager URL in the address bar (by default it is http://< ComputerName >/Reports ). 

{{% /alert %}}

1. Select one of the reports on the server.
1. Open the **Select Format** list.
   You should see a list of export formats provided by Aspose.Slides for Reporting Services. 
1. Select **PPT – PowerPoint Presentation via Aspose.Slides**. 

   **Aspose.Slides for Reporting Services installed successfully and new export formats are available.** 

![todo:image_alt_text](install-manually_1.png)




1. Click the **Export** link.
   The report is generated in the selected format, sent to the client and opened in an appropriate application. In our case, the report opens in Microsoft PowerPoint. 

   **A PPT report generated by Aspose.Slides for Reporting Services.** 

![todo:image_alt_text](install-manually_2.png)

Congratulations, you’ve successfully installed Aspose.Slides for Reporting Services and generated a report as a Microsoft PowerPoint presentation! 

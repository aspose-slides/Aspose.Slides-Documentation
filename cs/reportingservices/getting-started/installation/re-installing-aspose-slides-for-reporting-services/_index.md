---
title: Přeinstalace Aspose.Slides for Reporting Services
type: docs
weight: 40
url: /cs/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

Tento článek popisuje opravu pro situaci, kdy je Aspose.Slides for Reporting Services již nainstalováno, ale z jakéhokoli důvodu je nutné jej přeinstalovat.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** vyžaduje na hostitelském počítači instalaci **.NET Framework 3.5**. 

{{% /alert %}}

## **Kroky k přeinstalaci Aspose.Slides for Reporting Services**
Nejdůležitější je úplné odstranění předchozích instalací Aspose.Slides for Reporting Services. Zatímco MSI instalátor může úspěšně provést potřebné kroky k odinstalaci a následné automatické přeinstalaci Aspose.Slides for Reporting Services, je třeba postupovat podle následujících kroků:

1. Odinstalujte Aspose.Slides for Reporting Services pomocí MSI instalátoru. 

2. Najděte adresář instalace Aspose.Slides for Reporting Services, který se obvykle nachází v:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. Pokud MSI instalátor neodstranil adresář “Aspose.Slides for Reporting Services” při odinstalaci, smažte tento adresář. 

4. Najděte binární soubor **Aspose.Slides.ReportingServices.dll** v adresáři “bin” každé instance SQL Server Reporting Services. Například pokud existuje instance Microsoft SQL Server 2008 “MSSQLSERVER”, odpovídající adresář “bin” Reporting Service bude pravděpodobně na:

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Pokud MSI instalátor neodstranil soubor Aspose.Slides.ReportingServices.dll z výše uvedeného adresáře při odinstalaci, smažte soubor nyní.

6. Najděte soubor **rsreportserver.config** pro každou instanci SSRS. Například pokud existuje instance Reporting Service “MSRS10.MSSQLSERVER”, soubor **rsreportserver.config** bude v tomto adresáři:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Otevřete soubor **rsreportserver.config** v libovolném editoru a najděte řádky, které byly vytvořeny pro přidání PowerPoint Formátových Rozšíření během instalace Aspose.Slides for Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Krok** **8:** Pokud MSI instalátor neodstranil tyto řádky při odinstalaci Aspose.Slides for Reporting Services, odstraňte řádky ze souboru **rsreportserver.config** nyní.

**Krok** **9:** Najděte soubor **rssrvpolicy.config** pro každou instanci SSRS. Například pokud existuje instance Reporting Service “MSRS10.MSSQLSERVER”, soubor **rssrvpolicy.config** bude v tomto adresáři:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Krok** **10:** Otevřete soubor **rssrvpolicy.config** v libovolném editoru a najděte řádky, které byly vytvořeny k udělení oprávnění k provádění pro Aspose.Slides for Reporting Services během instalace Aspose.Slides for Reporting Services. 

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--Začněte zde.-->

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

    <!--Ukončete zde.-->

  </CodeGroup>

</CodeGroup>



```

**Krok** **11:** Pokud MSI instalátor neodstranil výše uvedené řádky při odinstalaci produktu, odstraňte tyto řádky ze souboru **rssrvpolicy.config** nyní. 

**Krok** **12:** Pokud byl Aspose.Slides for Reporting Services také nainstalován s Microsoft Visual Studio pro vývoj RDL reportů a export do PowerPoint formátů v prostředí Microsoft Visual Studio, binární soubor Aspose.Slides.ReportingServices.dll a konfigurační soubory (**rsreportserver.config** a **rssrvpolicy.config**) v případě Microsoft Visual Studio 2008 by měly být umístěny v:

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Krok** **13:** Pokud MSI instalátor neodstranil binární soubor **Aspose.Slides.ReportingServices.dll**, smažte jej. Navíc, pokud neaktualizoval soubory **rsreportserver.config** a **rssrvpolicy.config** tak, aby odstranil PowerPoint Formátová Rozšíření a oprávnění k provádění kódu, musíte je odstranit ručně stejným způsobem, jakým jste postupovali u souborů v předchozích krocích. 

**Krok** **14:** Je čas přeinstalovat Aspose.Slides for Reporting Services. Použijte MSI instalátor pro automatickou instalaci nebo to proveďte ručně.
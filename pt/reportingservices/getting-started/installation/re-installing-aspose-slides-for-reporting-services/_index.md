---
title: Reinstalando Aspose.Slides for Reporting Services
type: docs
weight: 40
url: /pt/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

Este artigo descreve a correção para uma situação em que o Aspose.Slides for Reporting Services já está instalado, mas por algum motivo precisa ser reinstalado.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** requer a instalação do **.NET Framework 3.5** na máquina host. 

{{% /alert %}}

## **Etapas para reinstalar o Aspose.Slides for Reporting Services**
O mais importante é a remoção completa das instalações anteriores do Aspose.Slides for Reporting Services. Embora o instalador MSI possa executar com sucesso as ações necessárias para desinstalar e, portanto, reinstalar o Aspose.Slides for Reporting Services automaticamente, estas etapas devem ser seguidas:

1. Desinstale o Aspose.Slides for Reporting Services usando o instalador MSI. 

2. Localize o diretório de instalação do Aspose.Slides for Reporting Services, que normalmente está em:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3.  Se o instalador MSI não tiver removido o diretório “Aspose.Slides for Reporting Services” ao desinstalar o produto, exclua a pasta. 

4. Localize o binário **Aspose.Slides.ReportingServices.dll** no diretório “bin” de cada instância do SQL Server Reporting Services. Por exemplo, se houver uma instância do Microsoft SQL Server 2008 chamada “MSSQLSERVER”, o diretório “bin” correspondente do Reporting Service provavelmente está em: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Se o instalador MSI não tiver removido o arquivo binário Aspose.Slides.ReportingServices.dll do diretório acima ao desinstalar o produto, exclua o arquivo agora.

6. Localize o arquivo **rsreportserver.config** para cada instância do SSRS. Por exemplo, se houver uma instância do Reporting Service “**MSRS10.MSSQLSERVER**”, o arquivo **rsreportserver.config** estará neste diretório:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Abra o arquivo **rsreportserver.config** em qualquer editor e encontre as linhas que foram criadas para adicionar Extensões de Formato PowerPoint durante a instalação do Aspose.Slides for Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Etapa** **8:** Se o instalador MSI não tiver removido essas linhas ao desinstalar o Aspose.Slides for Reporting Services, exclua-as do arquivo **rsreportserver.config** agora.

**Etapa** **9:** Localize o arquivo **rssrvpolicy.config** para cada instância do SSRS. Por exemplo, se houver uma instância do Reporting Service “MSRS10.MSSQLSERVER”, o arquivo **rssrvpolicy.config** estará neste diretório:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Etapa** **10:** Abra o arquivo **rssrvpolicy.config** em qualquer editor e encontre as linhas que foram criadas para conceder permissões de execução ao Aspose.Slides for Reporting Services durante a instalação do produto. 

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--Comece aqui.-->

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

    <!--Fim aqui.-->

  </CodeGroup>

</CodeGroup>



```

**Etapa** **11:** Se o instalador MSI não tiver removido as linhas acima ao desinstalar o produto, remova-as do arquivo **rssrvpolicy.config** agora. 

**Etapa** **12:** Se o Aspose.Slides for Reporting Services também foi instalado com o Microsoft Visual Studio para desenvolvimento de relatórios RDL e exportação para formatos PowerPoint dentro do ambiente do Microsoft Visual Studio, o arquivo binário Aspose.Slides.ReportingServices.dll e os arquivos de configuração (**rsreportserver.config** e **rssrvpolicy.config**) no caso do Microsoft Visual Studio 2008 devem estar em:

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Etapa** **13:** Se o instalador MSI não tiver removido o binário **Aspose.Slides.ReportingServices.dll**, exclua-o. Além disso, se não tiver atualizado os arquivos **rsreportserver.config** e **rssrvpolicy.config** para remover as Extensões de Formato PowerPoint e as permissões de execução de código, respectivamente, você deverá removê‑los manualmente da mesma forma que fez nos passos anteriores. 

**Etapa** **14:** É hora de reinstalar o Aspose.Slides for Reporting Services. Use o instalador MSI para instalação automática ou faça manualmente.
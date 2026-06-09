---
title: Integração manual com o Visual Studio 2005 ou 2008 Report Designer
type: docs
weight: 50
url: /pt/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

Este artigo ensina como integrar o Aspose.Slides for Reporting Services manualmente com o Visual Studio. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** requer a instalação do **.NET Framework 3.5** na máquina host. 

{{% /alert %}}

## **Integrando Aspose.Slides for Reporting Services com o Visual Studio**
Recomendamos que você use o instalador MSI para instalar o Aspose.Slides for Reporting Services, pois ele executa todas as tarefas necessárias de instalação e processos de configuração automaticamente. No entanto, se a instalação com o instalador MSI falhar, use o guia aqui. 

Este artigo também mostra como instalar o Aspose.Slides for Reporting Services em um computador com Business Intelligence Development Studio. Isso permitirá que você exporte relatórios para formatos do Microsoft PowerPoint no tempo de design a partir do Microsoft Visual Studio 2005 ou 2008 Report Designer. 

1. Copie Aspose.Slides.ReportingServices.dll para o diretório do Visual Studio.

   - Para integrar com o Visual Studio 2005 Report Designer, copie **Aspose.Slides.ReportingServices.dll** para o diretório **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - Para integrar com o Visual Studio 2008 Report Designer, copie **Aspose.Slides.ReportingServices.dll** para o diretório **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. Registre o Aspose.Slides for Reporting Services como uma extensão de renderização. 

3. Abra **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config** (onde <Version> é “8” para o Visual Studio 2005 ou “9.0” para o Visual Studio 2008) e adicione estas linhas ao elemento <Render>: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Conceda ao Aspose.Slides for Reporting Services permissões para executar. 
   1. Abra **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (onde <Version> é “8” para o Visual Studio 2005 ou “9.0” para o Visual Studio 2008).
   1. Adicione esta linha como o último item no segundo elemento externo <CodeGroup> (que deve ser <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) 

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
    <!--Termine aqui.-->
  </CodeGroup>
</CodeGroup>
```

5. Verifique se o Aspose.Slides for Reporting Services foi instalado com sucesso. 
6. Execute ou reinicie o Microsoft Visual Studio 2005 ou 2008 Report Designer. Você deverá notar novos formatos na lista de formatos de exportação.

**Novos formatos de exportação aparecem no Report Designer.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)
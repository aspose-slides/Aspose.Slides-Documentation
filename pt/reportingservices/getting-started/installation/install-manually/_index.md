---
title: Instalar Manualmente
type: docs
weight: 30
url: /pt/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

Siga estas etapas somente se planeja instalar Aspose.Slides for Reporting Services manualmente. Neste caso, você baixou o pacote ZIP contendo os arquivos de assembly. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** requer a instalação do **.NET Framework 3.5** na máquina host. 

{{% /alert %}}

### **Instalação Manual**
Estas instruções mostram como copiar e modificar arquivos no diretório onde o Microsoft SQL Server Reporting Services está instalado:

1. Localize o diretório de instalação do Report Server.  
   O diretório raiz do Microsoft SQL Server geralmente está aqui: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 e 2008**: Pode haver várias instâncias do Microsoft SQL Server configuradas na máquina e elas podem ocupar diferentes subdiretórios MSSQL.x, como MSSQL.1, MSSQL.2 e assim por diante. Você deve encontrar o diretório correto ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** antes de prosseguir para a próxima etapa.
   
   {{% /alert %}} Todos os caminhos usados abaixo referirão a este diretório como <Instance>. 

2. Copie Aspose.Slides.ReportingServices.dll para a pasta **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.  
   O download **Aspose.Slides.ReportingServices.zip** contém o **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

Em alguns casos, ao copiar a DLL para o diretório **ReportServer\bin**, ela pode ser copiada junto com as permissões NTFS explícitas atribuídas a ela. As permissões NTFS fazem com que o Microsoft SQL Server Reporting Services tenha acesso negado ao carregar **Aspose.Slides.ReportingServices.dll**. Se isso acontecer, os novos formatos de exportação não ficarão disponíveis. Verifique e confirme que as permissões NTFS corretas estão em vigor :

   1. Clique com o botão direito em **Aspose.Slides.ReportingServices.dll**.  
   1. Clique em **Properties** e selecione a guia **Security**.  
   1. Remova quaisquer permissões NTFS atribuídas explicitamente e deixe apenas as permissões herdadas.

{{% /alert %}}

3. Registre Aspose.Slides for Reporting Services como uma extensão de renderização:  
   1. Abra *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.  
   1. Adicione estas linhas ao elemento <Render>:  

**<Render>**

``` xml

   ...

  <!--Inicie aqui.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Termine aqui.-->

</Render>



```

4. Conceda permissões ao Aspose.Slides for Reporting Services para executar:  
   1. Abra **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.  
   1. Adicione o seguinte como o último item no segundo <CodeGroup> externo (que deve ser `<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">`).  

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Inicie aqui.-->

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

5. Verifique se o Aspose.Slides for Reporting Services foi instalado com sucesso:  
   1. Abra o Report Manager e verifique a lista de tipos de exportação disponíveis para um relatório.  
   
   {{% alert color="primary" %}} Você pode iniciar o Report Manager abrindo um navegador (Microsoft Internet Explorer 6.0 ou posterior) e digitando a URL do Report Manager na barra de endereços (por padrão, é http://< ComputerName >/Reports ).  
   
   {{% /alert %}}

1. Selecione um relatório no servidor.  
1. Abra a lista **Select Format**.  
   Você deverá ver uma lista de formatos de exportação fornecidos pelo Aspose.Slides for Reporting Services.  
1. Selecione **PPT – PowerPoint Presentation via Aspose.Slides**.  

   **Aspose.Slides for Reporting Services instalado com sucesso e novos formatos de exportação estão disponíveis**.  

![todo:image_alt_text](install-manually_1.png)




6. Clique no link **Export**.  
   O relatório é gerado no formato escolhido, enviado ao cliente e então aberto em um aplicativo apropriado. No nosso caso, o relatório foi aberto no Microsoft PowerPoint.  

   **Um relatório PPT gerado pelo Aspose.Slides for Reporting Services.**  

![todo:image_alt_text](install-manually_2.png)

Você instalou com sucesso o Aspose.Slides for Reporting Services e gerou um relatório como uma apresentação do Microsoft PowerPoint!
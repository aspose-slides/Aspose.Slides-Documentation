---
title: Instalação Manual
type: docs
weight: 30
url: /pt/reportingservices/install-manually/
keywords:
- instalação manual
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Instale o Aspose.Slides for Reporting Services manualmente a partir do pacote ZIP contendo apenas DLLs: qual assembly copiar e o que adicionar ao rsreportserver.config e rssrvpolicy.config."
---
## **Visão geral**

Siga estas etapas para instalar o Aspose.Slides for Reporting Services sem o instalador MSI, a partir do pacote ZIP *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* na [página de download](https://releases.aspose.com/slides/reportingservices/). Eles registram as mesmas extensões que o [instalador MSI](/slides/pt/reportingservices/install-with-msi-installer/). Repita-as para cada instância do servidor de relatórios.

Antes de começar, verifique os [requisitos de sistema](/slides/pt/reportingservices/system-requirements/). Você precisa de direitos de administrador local no servidor de relatórios.

## **Escolha o Assembly**

O pacote ZIP contém várias compilações. Copie exatamente um *Aspose.Slides.ReportingServices.dll* para o servidor de relatórios:

| Arquivo no pacote ZIP | Use para |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 e posterior Reporting Services, e Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Não para um servidor de relatórios: aplicativos que exportam do controle ReportViewer 2010 ou 2012, veja [Usando Aspose.Slides com ReportViewer 2010 e 2012](/slides/pt/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Opcional: salva relatórios em formato RPL para relatórios de problemas, veja [Exportando Relatórios para Formato RPL](/slides/pt/reportingservices/exporting-reports-to-rpl-format/) |

## **Encontre a Pasta do Servidor de Relatórios**

As etapas abaixo referem-se à pasta *ReportServer* do servidor de relatórios, que contém *rsreportserver.config* e *rssrvpolicy.config*. Em uma instalação padrão, ela é:

| Servidor de relatórios | Pasta padrão *ReportServer* |
| :- | :- |
| SQL Server 2017 e posterior Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 e anterior Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, onde a pasta da instância é, por exemplo, `MSRS13.MSSQLSERVER` para SQL Server 2016 ou `MSSQL.x` para SQL Server 2005 |

Para mais locais, veja o artigo [arquivo de configuração RsReportServer.config](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file) da Microsoft.

## **Instalar a Extensão**

1. Copie o assembly que você escolheu para a subpasta *bin* da pasta *ReportServer*.

   O arquivo copiado não deve possuir permissões NTFS atribuídas explicitamente, caso contrário o servidor de relatórios será negado o acesso ao carregar o assembly e os novos formatos de exportação não aparecerão. Clique com o botão direito no arquivo, selecione **Properties**, e na aba **Security** remova quaisquer permissões atribuídas explicitamente, deixando apenas as herdadas. Se a aba **General** mostrar a opção **Unblock**, selecione‑a.

2. Salve uma cópia de *rsreportserver.config* e, em seguida, abra o arquivo em um editor de texto. Adicione estas entradas dentro do elemento `<Render>`:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Cada entrada registra um formato de exportação; `Name` deve ser exclusivo entre as extensões de renderização. O instalador MSI registra os mesmos seis nomes e tipos. Omitir uma entrada se você não quiser seu formato na lista de exportação.

3. Salve uma cópia de *rssrvpolicy.config* e, em seguida, abra o arquivo em um editor de texto. Encontre o grupo de código cuja `Description` é "This code group grants MyComputer code Execution permission." e adicione este grupo de código como seu último filho:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` é a chave pública do assembly Aspose.Slides.ReportingServices. Mantenha‑a em uma única linha.

4. Salve ambos os arquivos. O servidor de relatórios lê seus arquivos de configuração novamente sempre que são salvos. Se um arquivo contiver XML malformado, o servidor de relatórios o ignora ou não inicia, portanto restaure sua cópia se algo der errado.

## **Verificar a Instalação**

Abra um relatório paginado no portal web (Report Manager no SQL Server 2014 e anteriores) e abra a lista **Export**. Ela agora inclui estes formatos:

- PPT - Apresentação PowerPoint via Aspose.Slides
- PPS - Apresentação de Slides PowerPoint via Aspose.Slides
- PPTX - Apresentação PowerPoint 2007 via Aspose.Slides
- PPSX - Apresentação de Slides PowerPoint 2007 via Aspose.Slides
- ODP - Apresentação OpenDocument via Aspose.Slides
- XPS - via Aspose.Slides

Selecione um deles para exportar o relatório. O arquivo abre no aplicativo associado ao seu formato.

![Um relatório exportado para PowerPoint por Aspose.Slides for Reporting Services](install-manually_2.png)

Se os formatos não aparecerem, verifique as permissões NTFS do assembly copiado. Sem uma licença, os arquivos exportados contêm uma marca d'água de avaliação; veja [Licenciamento](/slides/pt/reportingservices/license-aspose-slides-for-reporting-services/).
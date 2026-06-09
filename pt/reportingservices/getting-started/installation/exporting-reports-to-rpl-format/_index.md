---
title: Exportando relatórios para o formato RPL
type: docs
weight: 110
url: /pt/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Aspose.Slides usa relatórios no formato RPL (Report Processing Language) para renderização. Esta página demonstra como exportar relatórios para o formato RPL.
{{% /alert %}} 

Em muitos cenários, os clientes precisam compartilhar os relatórios que contêm problemas para resolução com a equipe da Aspose. Quando os relatórios compartilhados estão no formato RDL, o conjunto de dados ou o esquema também são compartilhados para nos permitir reproduzir o problema. Às vezes, mesmo o compartilhamento do relatório RDL junto com o conjunto de dados não é suficiente para resolver a questão completamente. Nesses casos, recomendamos que você exporte os relatórios no formato RPL e compartilhe o arquivo RPL conosco. O arquivo RPL inclui o conjunto de dados usado nele também. Dessa forma, fica mais fácil exportar para RPL e o arquivo pode ser compartilhado imediatamente conosco.

Execute estas etapas:

1. Copie o Aspose.ReportingServices.Debug.Rpl.dll para o diretório bin dos Serviços de Relatórios (geralmente em c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 
Aspose.ReportingServices.Debug.Rpl.dll está disponível nas versões mais recentes do Aspose.Slides para Reporting Services, que podem ser baixadas na [Releases page](https://releases.aspose.com/slides/pt/reportingservices/).
{{% /alert %}} 

2. Adicione esta extensão à tag **<Render>** do arquivo **rsreportserver.config** (geralmente em c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Adicione esta tag ao elemento <Render> 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Especifique o caminho para os arquivos RPL resultantes modificando o elemento path.

4. Conceda permissões ao Aspose.ReportingServices.Debug.Rpl.dll para execução da seguinte forma: abra C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config e adicione isto como o último item no segundo **<CodeGroup>** externo (que deve ser **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** ) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Comece aqui.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--Termine aqui.-->

  </CodeGroup>

</CodeGroup>


```

5. Reinicie os Serviços de Relatórios. Você deverá encontrar a opção Aspose.Rpl no menu Exportar.

A opção "Rpl export" deve aparecer no painel de exportação. Você precisa exportar o relatório para RPL e compartilhar o arquivo RPL.
---
title: Esportazione di report in formato RPL
type: docs
weight: 110
url: /it/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Aspose.Slides utilizza rapporti in formato RPL (Report Processing Language) per il rendering. Questa pagina dimostra come esportare i report nel formato RPL. 
{{% /alert %}} 

In molti scenari, i clienti devono condividere i report contenenti problemi per la risoluzione con il personale di Aspose. Quando i report condivisi sono in formato RDL, anche il set di dati o lo schema viene condiviso per consentirci di riprodurre il problema. Talvolta, anche la condivisione del report RDL insieme al set di dati non è sufficiente a risolvere completamente la questione. In questi casi, consigliamo di esportare i report in formato RPL e di condividere il file RPL per la segnalazione a noi. Il file RPL include anche il set di dati utilizzato. In questo modo, l'esportazione in RPL è più semplice e può essere condivisa immediatamente con noi.

Eseguire questi passaggi:

1. Copiare Aspose.ReportingServices.Debug.Rpl.dll nella directory bin dei Reporting Services (di solito in c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 
Aspose.ReportingServices.Debug.Rpl.dll è disponibile nelle versioni più recenti di Aspose.Slides per Reporting Services, che può essere scaricato dalla [pagina Releases](https://releases.aspose.com/slides/it/reportingservices/). 
{{% /alert %}} 

2. Aggiungere questa estensione al tag **<Render>** del file **rsreportserver.config** (di solito in c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Aggiungi questo tag all'elemento <Render> 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Specificare il percorso dei file RPL risultanti modificando l'elemento path.

4. Concedere a Aspose.ReportingServices.Debug.Rpl.dll i permessi per l'esecuzione in questo modo: aprire C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config e aggiungere questo come ultimo elemento nel secondo **<CodeGroup>** più esterno (che dovrebbe essere **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** ) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Inizia qui.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--Fine qui.-->

  </CodeGroup>

</CodeGroup>


```

5. Riavviare i Reporting Services. Dovreste trovare l'opzione Aspose.Rpl nel menu Esporta.

L'opzione "Rpl export" dovrebbe apparire nel pannello di esportazione. È necessario esportare il report in RPL e condividere il file RPL.
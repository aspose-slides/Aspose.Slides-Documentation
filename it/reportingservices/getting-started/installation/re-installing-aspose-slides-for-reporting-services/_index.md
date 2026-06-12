---
title: Reinstallazione di Aspose.Slides per Reporting Services
type: docs
weight: 40
url: /it/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

Questo articolo descrive la correzione per una situazione in cui Aspose.Slides for Reporting Services è già installato, ma per qualsiasi motivo deve essere reinstallato.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** richiede l'installazione di **.NET Framework 3.5** sulla macchina host. 

{{% /alert %}}

## **Passaggi per reinstallare Aspose.Slides for Reporting Services**
La cosa più importante è rimuovere completamente le precedenti installazioni di Aspose.Slides for Reporting Services. Sebbene il programma di installazione MSI possa eseguire automaticamente le azioni necessarie per disinstallare e quindi reinstallare Aspose.Slides for Reporting Services, è necessario seguire questi passaggi:

1. Disinstallare Aspose.Slides for Reporting Services utilizzando il programma di installazione MSI. 

2. Individuare la cartella di installazione di Aspose.Slides for Reporting Services, tipicamente in:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3.  Se il programma di installazione MSI non ha rimosso la cartella “Aspose.Slides for Reporting Services” durante la disinstallazione, eliminare la cartella. 

4. Individuare il file binario **Aspose.Slides.ReportingServices.dll** nella cartella “bin” di ogni istanza di SQL Server Reporting Services. Ad esempio, se esiste un'istanza Microsoft SQL Server 2008 chiamata “MSSQLSERVER”, la relativa cartella “bin” del servizio di reporting si trova probabilmente in: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Se il programma di installazione MSI non ha rimosso il file binario Aspose.Slides.ReportingServices.dll dalla cartella sopra indicata durante la disinstallazione, eliminarlo ora.

6. Individuare il file **rsreportserver.config** per ogni istanza SSRS. Ad esempio, se esiste un'istanza di Reporting Service chiamata “**MSRS10.MSSQLSERVER**”, il file **rsreportserver.config** si troverà in questa cartella:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Aprire il file **rsreportserver.config** con un editor qualsiasi e trovare le righe create per aggiungere le estensioni di formato PowerPoint durante l'installazione di Aspose.Slides for Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** Se il programma di installazione MSI non ha rimosso quelle righe durante la disinstallazione di Aspose.Slides for Reporting Services, eliminarle ora dal file **rsreportserver.config**.

**Step** **9:** Individuare il file **rssrvpolicy.config** per ogni istanza SSRS. Ad esempio, se esiste un'istanza di Reporting Service “MSRS10.MSSQLSERVER”, il file **rssrvpolicy.config** si troverà in questa cartella:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Step** **10:** Aprire il file **rssrvpolicy.config** con un editor qualsiasi e trovare le righe create per concedere i permessi di esecuzione a Aspose.Slides for Reporting Services durante l'installazione. 

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--Inizia qui.-->

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

    <!--Fine qui.-->

  </CodeGroup>

</CodeGroup>



```

**Step** **11:** Se il programma di installazione MSI non ha rimosso le righe sopra durante la disinstallazione del prodotto, rimuoverle ora dal file **rssrvpolicy.config**. 

**Step** **12:** Se Aspose.Slides for Reporting Services è stato installato anche con Microsoft Visual Studio per lo sviluppo di report RDL e l'esportazione in formati PowerPoint all'interno dell'ambiente Microsoft Visual Studio, il file binario Aspose.Slides.ReportingServices.dll e i file di configurazione (**rsreportserver.config** e **rssrvpolicy.config**) nel caso di Microsoft Visual Studio 2008 dovrebbero trovarsi in: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Step** **13:** Se il programma di installazione MSI non ha rimosso il file binario **Aspose.Slides.ReportingServices.dll**, eliminarlo. Inoltre, se non ha aggiornato i file **rsreportserver.config** e **rssrvpolicy.config** per rimuovere le estensioni di formato PowerPoint e i permessi di esecuzione del codice rispettivamente, è necessario rimuoverli manualmente nello stesso modo in cui sono stati rimossi i file nei passaggi precedenti. 

**Step** **14:** È ora di reinstallare Aspose.Slides for Reporting Services. Utilizzare il programma di installazione MSI per un'installazione automatica o eseguirla manualmente.
---
title: Installazione manuale
type: docs
weight: 30
url: /it/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

Segui questi passaggi solo se prevedi di installare Aspose.Slides for Reporting Services manualmente. In tal caso, hai scaricato il pacchetto ZIP contenente i file assembly. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** richiede l'installazione di **.NET Framework 3.5** sulla macchina host. 

{{% /alert %}}

### **Installazione manuale**
Queste istruzioni mostrano come copiare e modificare i file nella directory in cui è installato Microsoft SQL Server Reporting Services:

1. Individua la directory di installazione del Report Server.  
   La directory principale per Microsoft SQL Server è di solito qui: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 e 2008**: potrebbero esserci diverse istanze di Microsoft SQL Server configurate sulla macchina e potrebbero occupare diverse sottodirectory MSSQL.x come MSSQL.1, MSSQL.2 e così via. È necessario trovare la directory corretta ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** prima di procedere al passaggio successivo.
   
   {{% /alert %}} Tutti i percorsi utilizzati di seguito si riferiranno a questa directory come <Instance>. 

2. Copia Aspose.Slides.ReportingServices.dll nella cartella **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.  
   Il download **Aspose.Slides.ReportingServices.zip** contiene il file **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

In alcuni casi, quando copi il DLL nella directory **ReportServer\bin**, potrebbe essere copiato insieme alle autorizzazioni NTFS esplicite assegnate. Le autorizzazioni NTFS impediscono a Microsoft SQL Server Reporting Services di accedere al **Aspose.Slides.ReportingServices.dll**. Se ciò accade, i nuovi formati di esportazione non saranno disponibili. Verifica e conferma che le autorizzazioni NTFS corrette siano impostate:

   1. Fai clic con il tasto destro su **Aspose.Slides.ReportingServices.dll**.  
   1. Seleziona **Properties** e vai alla scheda **Security**.  
   1. Rimuovi eventuali autorizzazioni NTFS esplicite e mantieni solo le autorizzazioni ereditate.

{{% /alert %}}

3. Registra Aspose.Slides for Reporting Services come estensione di rendering:  
   1. Apri *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.  
   1. Aggiungi queste righe all'elemento <Render>:  

**<Render>**

``` xml

   ...

  <!--Inizia qui.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Fine qui.-->

</Render>



```

4. Concedi a Aspose.Slides for Reporting Services le autorizzazioni per l'esecuzione:  
   1. Apri **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.  
   1. Aggiungi quanto segue come ultimo elemento nel secondo <CodeGroup> più esterno (che dovrebbe essere `<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">`).  

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

5. Verifica che Aspose.Slides for Reporting Services sia stato installato correttamente:  
   1. Apri Report Manager e controlla l'elenco dei tipi di esportazione disponibili per un report.  
   
      {{% alert color="primary" %}} È possibile avviare Report Manager aprendo un browser (Microsoft Internet Explorer 6.0 o successivo) e digitando l'URL di Report Manager nella barra degli indirizzi (per impostazione predefinita è http://< ComputerName >/Reports ).  
   
      {{% /alert %}}

1. Seleziona un report sul server.  
1. Apri l'elenco **Select Format**.  
   Dovresti vedere un elenco di formati di esportazione forniti da Aspose.Slides for Reporting Services.  
1. Seleziona **PPT – PowerPoint Presentation via Aspose.Slides**.  

   **Aspose.Slides for Reporting Services installato correttamente e i nuovi formati di esportazione sono disponibili.**  

![todo:image_alt_text](install-manually_1.png)




6. Fai clic sul collegamento **Export**.  
   Il report viene generato nel formato scelto, inviato al client e quindi aperto in un'applicazione appropriata. Nel nostro caso, il report è stato aperto in Microsoft PowerPoint.  

   **Un report PPT generato da Aspose.Slides for Reporting Services.**  

![todo:image_alt_text](install-manually_2.png)

Hai installato con successo Aspose.Slides for Reporting Services e hai generato un report come presentazione Microsoft PowerPoint!
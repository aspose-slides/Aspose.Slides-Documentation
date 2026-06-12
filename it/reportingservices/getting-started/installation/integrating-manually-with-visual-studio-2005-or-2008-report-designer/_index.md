---
title: Integrazione manuale con Visual Studio 2005 o 2008 Report Designer
type: docs
weight: 50
url: /it/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

Questo articolo ti insegna come integrare manualmente Aspose.Slides for Reporting Services con Visual Studio. 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}} 

**Aspose.Slides for Reporting Services** richiede l'installazione di **.NET Framework 3.5** sulla macchina host. 

{{% /alert %}}

## **Integrare Aspose.Slides for Reporting Services con Visual Studio**
Ti consigliamo di utilizzare il programma di installazione MSI per installare Aspose.Slides for Reporting Services perché esegue automaticamente tutte le operazioni di installazione e i processi di configurazione necessari. Tuttavia, se l'installazione con il programma MSI dovesse fallire, utilizza la guida qui. 

Questo articolo ti mostra anche come installare Aspose.Slides for Reporting Services su un computer con Business Intelligence Development Studio. Questo ti consentirà di esportare i report nei formati Microsoft PowerPoint in fase di progettazione dal Microsoft Visual Studio 2005 o 2008 Report Designer. 

1. Copia **Aspose.Slides.ReportingServices.dll** nella directory di Visual Studio.

   - Per integrare con Visual Studio 2005 Report Designer, copia **Aspose.Slides.ReportingServices.dll** nella directory **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - Per integrare con Visual Studio 2008 Report Designer, copia **Aspose.Slides.ReportingServices.dll** nella directory **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. Registra Aspose.Slides for Reporting Services come estensione di rendering. 

3. Apri **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** (dove <Version> è “8” per Visual Studio 2005 o “9.0” per Visual Studio 2008) e aggiungi queste righe nell'elemento `<Render>`: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Concedi a Aspose.Slides for Reporting Services le autorizzazioni per l'esecuzione. 
   1. Apri **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (dove <Version> è “8” per Visual Studio 2005 o “9.0” per Visual Studio 2008).
   1. Aggiungi questa riga come ultimo elemento nel secondo elemento `<CodeGroup>` più interno (che dovrebbe essere `<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">`) 

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

5. Verifica che Aspose.Slides for Reporting Services sia stato installato correttamente. 
6. Avvia o riavvia Microsoft Visual Studio 2005 o 2008 Report Designer. Dovresti vedere i nuovi formati nell'elenco dei formati di esportazione.

**I nuovi formati di esportazione compaiono nel Report Designer.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)
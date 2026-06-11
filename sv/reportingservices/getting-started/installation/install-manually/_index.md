---
title: Installera manuellt
type: docs
weight: 30
url: /sv/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

Följ dessa steg endast om du planerar att installera Aspose.Slides for Reporting Services manuellt. I så fall har du laddat ner ZIP‑paketet som innehåller assemblies‑filerna. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** kräver att **.NET Framework 3.5** är installerat på värddatorn. 

{{% /alert %}}

### **Manuell installation**
Dessa instruktioner visar hur du kopierar och ändrar filer i den mapp där Microsoft SQL Server Reporting Services är installerat:

1. Hitta installationskatalogen för Report Server.  
   Rotkatalogen för Microsoft SQL Server finns vanligtvis här: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 och 2008**: Det kan finnas flera Microsoft SQL Server‑instanser konfigurerade på maskinen och de kan ligga i olika MSSQL.x‑undermappar, t.ex. MSSQL.1, MSSQL.2 osv. Du måste hitta rätt ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer***‑katalog innan du går vidare till nästa steg.
   
   {{% /alert %}} Alla sökvägar som används nedan refererar till den här katalogen som <Instance>. 

2. Kopiera **Aspose.Slides.ReportingServices.dll** till mappen **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.  
   Nedladdningen **Aspose.Slides.ReportingServices.zip** innehåller **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

I vissa fall, när du kopierar DLL‑en till katalogen **ReportServer\bin**, kan den kopieras med de explicita NTFS‑behörigheter som tilldelats den. NTFS‑behörigheterna kan leda till att Microsoft SQL Server Reporting Services nekas åtkomst när **Aspose.Slides.ReportingServices.dll** laddas. Om detta händer blir de nya exportformaten inte tillgängliga. Kontrollera och bekräfta att korrekta NTFS‑behörigheter finns på plats:

   1. Högerklicka på **Aspose.Slides.ReportingServices.dll**.  
   1. Klicka på **Properties** och välj fliken **Security**.  
   1. Ta bort eventuella explicit tilldelade NTFS‑behörigheter och låt endast ärvda behörigheter finnas kvar.

{{% /alert %}}

3. Registrera Aspose.Slides for Reporting Services som en renderings‑extension:  
   1. Öppna *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.  
   2. Lägg till dessa rader i elementet <Render>:

**<Render>**

``` xml

   ...

  <!--Börja här.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Sluta här.-->

</Render>



```

4. Ge Aspose.Slides for Reporting Services behörighet att köras:  
   1. Öppna **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.  
   2. Lägg till följande som sista post i det näst sista <CodeGroup>-elementet (som bör vara `<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">`).

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Börja här.-->

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

    <!--Avsluta här.-->

  </CodeGroup>

</CodeGroup>
```

5. Verifiera att Aspose.Slides for Reporting Services installerades korrekt:  
   1. Öppna Report Manager och kontrollera listan med tillgängliga exporttyper för en rapport.  

      {{% alert color="primary" %}} Du kan starta Report Manager genom att öppna en webbläsare (Microsoft Internet Explorer 6.0 eller senare) och skriva in Report Manager‑adressen i adressfältet (standard är http://< ComputerName >/Reports).  

      {{% /alert %}}

1. Välj en rapport på servern.  
1. Öppna listan **Select Format**.  
   Du bör se en lista med exportformat som tillhandahålls av Aspose.Slides for Reporting Services.  
1. Välj **PPT – PowerPoint Presentation via Aspose.Slides**.  

   **Aspose.Slides for Reporting Services installerades framgångsrikt och nya exportformat är tillgängliga.**  

![todo:image_alt_text](install-manually_1.png)




6. Klicka på länken **Export**.  
   Rapporten genereras i det valda formatet, skickas till klienten och öppnas sedan i ett lämpligt program. I vårt fall öppnades rapporten i Microsoft PowerPoint.  

   **En PPT‑rapport genererad av Aspose.Slides for Reporting Services.**  

![todo:image_alt_text](install-manually_2.png)

Du har framgångsrikt installerat Aspose.Slides for Reporting Services och genererat en rapport som en Microsoft PowerPoint‑presentation!
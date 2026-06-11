---
title: Exportera rapporter till RPL-format
type: docs
weight: 110
url: /sv/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 

Aspose.Slides använder rapporter i RPL (Report Processing Language)-format för rendering. Den här sidan visar hur man exporterar rapporter till RPL-formatet.

{{% /alert %}} 

I många scenarier måste kunderna dela rapporterna som innehåller problem för lösning med Aspose‑personal. När de delade rapporterna är i RDL‑format delas även datasetet eller schemat för att vi ska kunna reproducera problemet. Ibland är inte ens delning av RDL‑rapporten tillsammans med datasetet tillräckligt för att helt lösa problemet. I sådana fall rekommenderar vi att du exporterar rapporterna i RPL‑format och delar RPL‑filen med oss för rapportering. RPL‑filen innehåller även det dataset som används. På så sätt blir det enklare att exportera till RPL och den kan omedelbart delas med oss.

Följ dessa steg:

1. Kopiera Aspose.ReportingServices.Debug.Rpl.dll till Reporting Services bin‑katalog (vanligtvis på c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 

Aspose.ReportingServices.Debug.Rpl.dll finns i de senaste versionerna av Aspose.Slides för Reporting Services, och kan hämtas från [Utsläppsidan](https://releases.aspose.com/slides/sv/reportingservices/).

{{% /alert %}} 

2. Lägg till detta tillägg i **<Render>**‑taggen i **rsreportserver.config**‑filen (vanligtvis på c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Lägg till den här taggen i <Render>-elementet 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Ange sökvägen till de resulterande RPL‑filerna genom att ändra path‑elementet.

4. Ge Aspose.ReportingServices.Debug.Rpl.dll behörighet att köras på följande sätt: öppna C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config och lägg till detta som det sista objektet i det näst yttre **<CodeGroup>**‑elementet (som ska vara **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">**):

``` xml

<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Börja här.-->

				<CodeGroup class="UnionCodeGroup"
					version="1"
					PermissionSetName="FullTrust"
					Name="Aspose.Rpl_Debug_for_Reporting_Services"
					Description="Code group for my Aspose.Rpl.Debug rendering extension">
			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />
				</CodeGroup>

    <!--Sluta här.-->

  </CodeGroup>

</CodeGroup>
```

5. Starta om Reporting Services. Du bör hitta Aspose.Rpl‑alternativet i Export‑menyn.

Alternativet "Rpl export" bör visas i exportpanelen. Du måste exportera rapporten till RPL och dela RPL‑filen.
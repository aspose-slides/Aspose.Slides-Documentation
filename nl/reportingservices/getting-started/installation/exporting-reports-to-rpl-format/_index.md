---
title: Rapporten exporteren naar RPL-formaat
type: docs
weight: 110
url: /nl/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Aspose.Slides gebruikt rapporten in RPL (Report Processing Language) formaat voor weergave. Deze pagina laat zien hoe je rapporten exporteert naar het RPL‑formaat.
{{% /alert %}} 

In veel scenario's moeten klanten de rapporten met problemen delen met het personeel van Aspose. Wanneer de gedeelde rapporten in RDL‑formaat zijn, wordt ook de dataset of het schema gedeeld zodat we het probleem kunnen reproduceren. Soms is zelfs het delen van het RDL‑rapport samen met de dataset niet voldoende om het probleem volledig op te lossen. In dergelijke gevallen raden we aan de rapporten te exporteren naar het RPL‑formaat en het RPL‑bestand met ons te delen. Het RPL‑bestand bevat ook de gebruikte dataset. Op deze manier is het makkelijker om naar RPL te exporteren en kan het direct met ons worden gedeeld.

Voer de volgende stappen uit:

1. Kopieer Aspose.ReportingServices.Debug.Rpl.dll naar de bin‑map van Reporting Services (meestal op c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 
Aspose.ReportingServices.Debug.Rpl.dll is beschikbaar in de nieuwste versies van Aspose.Slides voor Reporting Services en kan worden gedownload vanaf de [Releases page](https://releases.aspose.com/slides/nl/reportingservices/).
{{% /alert %}} 

2. Voeg deze extensie toe aan het **<Render>**‑tag van het **rsreportserver.config**‑bestand (meestal op c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Voeg deze tag toe aan het <Render>-element 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Geef het pad naar de resulterende RPL‑bestanden op door het pad‑element aan te passen.

4. Geef Aspose.ReportingServices.Debug.Rpl.dll uitvoeringsrechten op deze manier: open C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config en voeg dit toe als het laatste item in het tweede buitenste **<CodeGroup>**‑element (dat moet **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** zijn):

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Start hier.-->

				<CodeGroup class="UnionCodeGroup"
					version="1"
					PermissionSetName="FullTrust"
					Name="Aspose.Rpl_Debug_for_Reporting_Services"
					Description="Code group for my Aspose.Rpl.Debug rendering extension">
			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />
				</CodeGroup>

    <!--Einde hier.-->

  </CodeGroup>

</CodeGroup>


```

5. Herstart Reporting Services. Je vindt de Aspose.Rpl‑optie in het Export‑menu.

De optie "Rpl export" zou moeten verschijnen op het exportpaneel. Je moet het rapport naar RPL exporteren en het RPL‑bestand delen.
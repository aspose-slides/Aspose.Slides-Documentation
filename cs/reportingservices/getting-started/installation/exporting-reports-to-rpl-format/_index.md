---
title: Exportování reportů do formátu RPL
type: docs
weight: 110
url: /cs/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Aspose.Slides používá zprávy ve formátu RPL (Report Processing Language) pro vykreslování. Tato stránka ukazuje, jak exportovat zprávy do formátu RPL.
{{% /alert %}} 

V mnoha situacích musí zákazníci sdílet zprávy obsahující problémy k vyřešení s personálem Aspose. Když jsou sdílené zprávy ve formátu RDL, je také sdílen datový soubor nebo schéma, aby nám umožnily reprodukovat problém. Někdy však i sdílení RDL zprávy spolu s datovým souborem nestačí k úplnému vyřešení problému. V takových případech doporučujeme exportovat zprávy do formátu RPL a sdílet soubor RPL s námi. Soubor RPL také obsahuje použitý datový soubor. Tím se export do RPL zjednoduší a může být okamžitě sdílen s námi.

Postupujte podle těchto kroků:

1. Zkopírujte soubor Aspose.ReportingServices.Debug.Rpl.dll do bin složky Reporting Services (obvykle v c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 
Soubor Aspose.ReportingServices.Debug.Rpl.dll je k dispozici v nejnovějších verzích Aspose.Slides pro Reporting Services, které můžete stáhnout ze [stránky Releases](https://releases.aspose.com/slides/cs/reportingservices/).
{{% /alert %}} 

2. Přidejte tuto rozšíření do značky **<Render>** v souboru **rsreportserver.config** (obvykle v c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Přidejte tento tag do elementu <Render> 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Určete cestu k výsledným RPL souborům úpravou prvku path.

4. Poskytněte souboru Aspose.ReportingServices.Debug.Rpl.dll oprávnění k provedení tímto způsobem: otevřete C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config a přidejte následující jako poslední položku do druhého nejvzdálenějšího elementu **<CodeGroup>** (který by měl být **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** ) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Začátek zde.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--Konec zde.-->

  </CodeGroup>

</CodeGroup>
```

5. Restartujte Reporting Services. V nabídce Export byste měli najít možnost Aspose.Rpl.

Možnost "Rpl export" by se měla objevit na panelu exportu. Musíte exportovat zprávu do RPL a sdílet soubor RPL.
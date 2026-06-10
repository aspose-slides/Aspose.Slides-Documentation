---
title: Jelentések exportálása RPL formátumba
type: docs
weight: 110
url: /hu/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Az Aspose.Slides a jelentéseket RPL (Report Processing Language) formátumban használja a rendereléshez. Ez az oldal bemutatja, hogyan lehet a jelentéseket RPL formátumba exportálni.
{{% /alert %}} 

Sok esetben az ügyfeleknek a problémákat tartalmazó jelentéseket kell megosztaniuk az Aspose munkatársaival a megoldás érdekében. Ha a megosztott jelentések RDL formátumban vannak, akkor az adatkészletet vagy a sémát is meg kell osztani, hogy reprodukálni tudjuk a problémát. Néha még az RDL jelentés és az adatkészlet megosztása sem elegendő a probléma teljes megoldásához. Ilyen esetekben azt javasoljuk, hogy exportálja a jelentéseket RPL formátumban, és ossza meg velünk az RPL fájlt. Az RPL fájl tartalmazza a benne használt adatkészletet is. Így könnyebb az RPL‑be exportálni, és azonnal megosztható velünk.

A következő lépéseket hajtsa végre:

1. Másolja az **Aspose.ReportingServices.Debug.Rpl.dll** fájlt a Reporting Services bin könyvtárába (általában a c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin helyen).

{{% alert color="primary" %}} 
Az **Aspose.ReportingServices.Debug.Rpl.dll** elérhető az Aspose.Slides for Reporting Services legújabb verzióiban, amely letölthető [a Kiadások oldalról](https://releases.aspose.com/slides/hu/reportingservices/).
{{% /alert %}} 

2. Adja hozzá ezt a kiterjesztést a **<Render>** címke **rsreportserver.config** fájljához (általában a c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config helyen)

``` xml



//Adja hozzá ezt a címkét a <Render> elemhez 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Adja meg az eredményül kapott RPL fájlok útvonalát a path elem módosításával.

4. Adjon jogosultságot az **Aspose.ReportingServices.Debug.Rpl.dll** fájlnak a következő módon: nyissa meg a C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config fájlt, és adja hozzá ezt a második legkülső **<CodeGroup>** elem utolsó eleméhez (eznek a következőnek kell lennie: **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** ) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Kezdje itt.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--Vége itt.-->

  </CodeGroup>

</CodeGroup>


```

5. Indítsa újra a Reporting Services szolgáltatást. Az Export menüben meg kell jelennie az **Aspose.Rpl** lehetőségnek.

Az "Rpl export" opció megjelenik az export panelen. Exportálja a jelentést RPL formátumba, és ossza meg az RPL fájlt.
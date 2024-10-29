---
title: Exportation de rapports au format RPL
type: docs
weight: 110
url: /fr/reportingservices/exporting-reports-to-rpl-format/
---

﻿

{{% alert color="primary" %}} 

Aspose.Slides utilise des rapports au format RPL (Report Processing Language) pour le rendu. Cette page montre comment exporter des rapports au format RPL﻿.

{{% /alert %}} 

Dans de nombreux scénarios, les clients doivent partager les rapports contenant des problèmes pour résolution avec le personnel d'Aspose. Lorsque les rapports partagés sont au format RDL, l'ensemble de données ou le schéma est également partagé pour nous permettre de reproduire le problème. Parfois, même le partage du rapport RDL avec l'ensemble de données n'est pas suffisant pour résoudre complètement le problème. Dans de tels cas, nous vous recommandons d'exporter les rapports au format RPL et de partager le fichier RPL pour la déclaration avec nous. Le fichier RPL inclut également l'ensemble de données utilisé. De cette manière, il devient plus facile d'exporter vers RPL et il peut être partagé instantanément avec nous.

Exécutez les étapes suivantes :

1. Copiez Aspose.ReportingServices.Debug.Rpl.dll dans le répertoire bin des services de reporting (généralement à c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 

Aspose.ReportingServices.Debug.Rpl.dll est disponible dans les dernières versions d'Aspose.Slides pour Reporting Services, téléchargeables depuis la [page des versions](https://releases.aspose.com/slides/reportingservices/).

{{% /alert %}} 

2. Ajoutez cette extension à la balise **<Render>** du fichier **rsreportserver.config** (généralement à c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Ajoutez cette balise à l'élément <Render> 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Spécifiez le chemin des fichiers RPL résultants en modifiant l'élément de chemin.

4. Accordez les permissions à Aspose.ReportingServices.Debug.Rpl.dll de cette manière : ouvrez C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config et ajoutez ceci comme dernier élément dans le deuxième élément **<CodeGroup>** extérieur (qui devrait être **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Ce groupe de code accorde à MyComputer la permission d'exécution du code. ">** ) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Commencez ici.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Groupe de code pour mon extension de rendu Aspose.Rpl.Debug">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--Fin ici.-->

  </CodeGroup>

</CodeGroup>


```

5. Redémarrez les services de reporting. Vous devriez trouver l'option Aspose.Rpl dans le menu d'exportation.

L'option "Exportation Rpl" devrait apparaître sur le panneau d'exportation. Vous devez exporter le rapport au format RPL et partager le fichier RPL.
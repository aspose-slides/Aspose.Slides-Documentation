---
title: Exportar informes al formato RPL
type: docs
weight: 110
url: /es/reportingservices/exporting-reports-to-rpl-format/
---

﻿

{{% alert color="primary" %}} 

Aspose.Slides utiliza informes en formato RPL (Report Processing Language) para la renderización. Esta página demuestra cómo exportar informes al formato RPL﻿.

{{% /alert %}} 

En muchos escenarios, los clientes deben compartir los informes que contienen problemas para su resolución con el personal de Aspose. Cuando los informes compartidos están en forma RDL, el conjunto de datos o esquema también se comparte para permitirnos reproducir el problema. A veces, incluso compartir el informe RDL junto con el conjunto de datos no es suficiente para resolver completamente el problema. En tales casos, recomendamos que exporten los informes en formato RPL y compartan el archivo RPL para informarnos. El archivo RPL incluye también el conjunto de datos utilizado en él. De esta manera, es más fácil exportar a RPL y puede ser compartido instantáneamente con nosotros.

Realice estos pasos:

1. Copie Aspose.ReportingServices.Debug.Rpl.dll en el directorio bin de Reporting Services (usualmente en c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 

Aspose.ReportingServices.Debug.Rpl.dll está disponible en las versiones más recientes de Aspose.Slides para Reporting Services, que se pueden descargar desde la [página de lanzamientos](https://releases.aspose.com/slides/reportingservices/).

{{% /alert %}} 

2. Agregue esta extensión a la etiqueta **<Render>** del archivo **rsreportserver.config** (usualmente en c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Agregue esta etiqueta al elemento <Render> 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Especifique la ruta a los archivos RPL resultantes modificando el elemento de ruta.

4. Dé permisos a Aspose.ReportingServices.Debug.Rpl.dll para ejecutar de esta manera: abra C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config y agregue esto como el último elemento en el segundo elemento externo **<CodeGroup>** (que debería ser **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Este grupo de código otorga permisos de ejecución al código de MyComputer. ">** ) :

``` xml



<CodeGroup>

  ... 

  <CodeGroup>

    ...

    <!--Comience aquí.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Grupo de código para mi extensión de renderizado Aspose.Rpl.Debug">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--Termine aquí.-->

  </CodeGroup>

</CodeGroup>


```

5. Reinicie los servicios de Reporting. Debería encontrar la opción Aspose.Rpl en el menú de exportación.

La opción "Rpl export" debería aparecer en el panel de exportación. Necesita exportar el informe a RPL y compartir el archivo RPL.
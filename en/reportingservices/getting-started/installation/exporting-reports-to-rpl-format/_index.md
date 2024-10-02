---
title: Exporting Reports to RPL format
type: docs
weight: 110
url: /reportingservices/exporting-reports-to-rpl-format/
---

﻿

{{% alert color="primary" %}} 

Aspose.Slides uses reports in RPL (Report Processing Language) format for rendering. This page demonstrates how to export reports to the RPL Format﻿.

{{% /alert %}} 

In many scenarios, customers have to share the reports containing issues for resolution with Aspose staff. When the shared reports are in RDL form, the data set or schema is also shared to allow us to reproduce the problem. Sometimes, even the sharing of the RDL report along with the data set is not sufficient to resolve the issue completely. In such cases, we recommend that you export the reports in RPL format and share the RPL file for reporting with us. The RPL file includes the data set used in it as well. This way, it gets easier to export to RPL and it can be shared instantly with us.

Perform these steps:

1. Copy to Aspose.ReportingServices.Debug.Rpl.dll to Reporting services bin directory (usually at c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 

Aspose.ReportingServices.Debug.Rpl.dll is available in the latest versions of Aspose.Slides for Reporting Services, which can be downloaded from the [Releases page](https://releases.aspose.com/slides/reportingservices/).

{{% /alert %}} 

2. Add this extension to **<Render>** tag of **rsreportserver.config** file (usually at c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Add this tag to <Render> element 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Specify the path to resulting RPL files by modifying the path element.

4. Give Aspose.ReportingServices.Debug.Rpl.dll permissions to execute this way: open C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config and add this as the last item in the second to outer **<CodeGroup>** element ( which should be **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** ) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Start here.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--End here.-->

  </CodeGroup>

</CodeGroup>


```

5. Restart Reporting services. You should find Aspose.Rpl option in Export menu.

The "Rpl export" option should appear on the export panel. You need to export the report to RPL and share the RPL file.

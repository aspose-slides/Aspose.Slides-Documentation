---
title: 导出报告至 RPL 格式
type: docs
weight: 110
url: /zh/reportingservices/exporting-reports-to-rpl-format/
---

﻿

{{% alert color="primary" %}} 

Aspose.Slides 使用 RPL（报告处理语言）格式的报告进行渲染。本页面演示了如何将报告导出为 RPL 格式﻿。

{{% /alert %}} 

在许多情况下，客户必须与 Aspose 员工共享包含问题的报告以进行解决。当共享的报告为 RDL 格式时，数据集或架构也将被共享，以便我们重现问题。有时，即使共享 RDL 报告和数据集也不足以完全解决问题。在这种情况下，我们建议您将报告导出为 RPL 格式并将 RPL 文件共享给我们。RPL 文件还包括所使用的数据集。这样，导出为 RPL 变得更简单，并且可以立即与我们共享。

执行以下步骤：

1. 将 Aspose.ReportingServices.Debug.Rpl.dll 复制到 Reporting services 的 bin 目录（通常在 c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin）。

{{% alert color="primary" %}} 

Aspose.ReportingServices.Debug.Rpl.dll 在最新版本的 Aspose.Slides for Reporting Services 中可用，可以从 [Releases page](https://releases.aspose.com/slides/reportingservices/) 下载。

{{% /alert %}} 

2. 将此扩展添加到 **<Render>** 标签中 **rsreportserver.config** 文件（通常在 c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config）

``` xml



//将此标签添加到 <Render> 元素 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. 通过修改路径元素来指定生成的 RPL 文件的路径。

4. 给 Aspose.ReportingServices.Debug.Rpl.dll 授权以执行，方法是打开 C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config，并将其作为最后一个项目添加到外部的第二个 **<CodeGroup>** 元素中（应为 **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="此代码组授予 MyComputer 代码执行权限。 ">**）:

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--从这里开始.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="我 Aspose.Rpl.Debug 渲染扩展的代码组">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--到此结束.-->

  </CodeGroup>

</CodeGroup>


```

5. 重启 Reporting services。您应该在导出菜单中找到 Aspose.Rpl 选项。

“Rpl 导出”选项应出现在导出面板上。您需要将报告导出为 RPL 并共享 RPL 文件。
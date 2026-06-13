---
title: RPL 형식으로 보고서 내보내기
type: docs
weight: 110
url: /ko/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Aspose.Slides는 렌더링을 위해 RPL(Report Processing Language) 형식의 보고서를 사용합니다. 이 페이지에서는 보고서를 RPL 형식으로 내보내는 방법을 보여줍니다.
{{% /alert %}} 

많은 경우에 고객은 문제 해결을 위해 Aspose 직원과 문제를 포함한 보고서를 공유해야 합니다. 공유된 보고서가 RDL 형식인 경우 문제를 재현할 수 있도록 데이터 세트 또는 스키마도 함께 공유됩니다. 때때로 데이터 세트와 함께 RDL 보고서를 공유하는 것만으로는 문제를 완전히 해결하기에 충분하지 않을 수 있습니다. 이러한 경우 보고서를 RPL 형식으로 내보내고 RPL 파일을 저희에게 공유하는 것을 권장합니다. RPL 파일에는 사용된 데이터 세트도 포함됩니다. 이렇게 하면 RPL로 내보내기가 쉬워지고 즉시 저희에게 공유할 수 있습니다.

다음 단계를 수행하십시오:

1. Aspose.ReportingServices.Debug.Rpl.dll 파일을 Reporting Services bin 디렉터리(일반적으로 c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin)에 복사합니다.

{{% alert color="primary" %}} 
Aspose.ReportingServices.Debug.Rpl.dll은 최신 버전의 Aspose.Slides for Reporting Services에 포함되어 있으며, [Releases page](https://releases.aspose.com/slides/ko/reportingservices/)에서 다운로드할 수 있습니다.
{{% /alert %}} 

2. **rsreportserver.config** 파일의 **<Render>** 태그에 이 확장을 추가합니다(일반적으로 c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config).
``` xml



//이 태그를 <Render> 요소에 추가합니다 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. path 요소를 수정하여 결과 RPL 파일의 경로를 지정합니다.

4. 다음과 같이 Aspose.ReportingServices.Debug.Rpl.dll에 실행 권한을 부여합니다: C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config 파일을 열고 두 번째 외부 **<CodeGroup>** 요소의 마지막 항목으로 다음을 추가합니다(이는 **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">**이어야 합니다):
``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--여기서 시작합니다.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--여기서 끝납니다.-->

  </CodeGroup>

</CodeGroup>


```

5. Reporting Services를 다시 시작합니다. 내보내기 메뉴에서 Aspose.Rpl 옵션을 찾을 수 있습니다.

"Rpl export" 옵션이 내보내기 패널에 표시되어야 합니다. 보고서를 RPL로 내보내고 RPL 파일을 공유해야 합니다.
---
title: Aspose.Slides for Reporting Services 재설치
type: docs
weight: 40
url: /ko/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

이 문서는 Aspose.Slides for Reporting Services가 이미 설치되어 있지만, 어떤 이유로든 다시 설치해야 하는 상황에 대한 해결 방법을 설명합니다.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services**는 호스트 컴퓨터에 **.NET Framework 3.5**가 설치되어 있어야 합니다. 

{{% /alert %}}

## **Aspose.Slides for Reporting Services 재설치 단계**
가장 중요한 것은 이전에 설치된 Aspose.Slides for Reporting Services를 완전히 제거하는 것입니다. MSI 설치 프로그램이 필요한 제거 작업을 자동으로 수행하고 따라서 Aspose.Slides for Reporting Services를 자동으로 다시 설치할 수 있지만, 다음 단계들을 반드시 따라야 합니다:

1. MSI 설치 프로그램을 사용하여 Aspose.Slides for Reporting Services를 제거합니다. 

2. 일반적으로 다음 위치에 있는 Aspose.Slides for Reporting Services 설치 디렉터리를 찾습니다:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. MSI 설치 프로그램이 Aspose.Slides for Reporting Services를 제거할 때 “Aspose.Slides for Reporting Services” 디렉터리를 삭제하지 않았다면, 해당 폴더를 삭제합니다. 

4. 각 SQL Server Reporting Service 인스턴스의 “bin” 디렉터리에서 **Aspose.Slides.ReportingServices.dll** 바이너리를 찾습니다. 예를 들어 Microsoft SQL Server 2008 인스턴스 “MSSQLSERVER”가 있는 경우, 해당 Reporting Service “bin” 디렉터리는 다음과 같을 수 있습니다: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. MSI 설치 프로그램이 Aspose.Slides for Reporting Services를 제거할 때 위 디렉터리에서 Aspose.Slides.ReportingServices.dll 파일을 삭제하지 않았다면, 지금 파일을 삭제합니다.

6. 각 SSRS 인스턴스에 대해 **rsreportserver.config** 파일을 찾습니다. 예를 들어 Reporting Service 인스턴스 “**MSRS10.MSSQLSERVER**”가 있는 경우, **rsreportserver.config** 파일은 다음 디렉터리에 있습니다:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. 任意의 편집기로 **rsreportserver.config** 파일을 열고 Aspose.Slides for Reporting Services 설치 중에 PowerPoint 형식 확장을 추가하기 위해 만든 라인을 찾습니다. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** MSI 설치 프로그램이 Aspose.Slides for Reporting Services를 제거할 때 해당 라인을 삭제하지 않았다면, 지금 **rsreportserver.config** 파일에서 해당 라인을 삭제합니다.

**Step** **9:** 각 SSRS 인스턴스에 대한 **rssrvpolicy.config** 파일을 찾습니다. 예를 들어 Reporting Service 인스턴스 “MSRS10.MSSQLSERVER”가 있는 경우, **rssrvpolicy.config** 파일은 다음 디렉터리에 있습니다:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Step** **10:** 任意의 편집기로 **rssrvpolicy.config** 파일을 열고 Aspose.Slides for Reporting Services 설치 중에 실행 권한을 부여하기 위해 만든 라인을 찾습니다. 

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--여기서 시작.-->

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

    <!--여기서 끝.-->

  </CodeGroup>

</CodeGroup>



```

**Step** **11:** MSI 설치 프로그램이 제품을 제거할 때 위 라인을 삭제하지 않았다면, 지금 **rssrvpolicy.config** 파일에서 해당 라인을 삭제합니다. 

**Step** **12:** Aspose.Slides for Reporting Services가 Microsoft Visual Studio와 함께 설치되어 RDL 보고서 개발 및 Microsoft Visual Studio 환경에서 PowerPoint 형식으로 내보내는 경우, Microsoft Visual Studio 2008에서의 **Aspose.Slides.ReportingServices.dll** 바이너리 파일 및 구성 파일(**rsreportserver.config** 및 **rssrvpolicy.config**)은 다음 위치에 있어야 합니다: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Step** **13:** MSI 설치 프로그램이 **Aspose.Slides.ReportingServices.dll** 바이너리를 삭제하지 않았다면, 삭제합니다. 또한 **rsreportserver.config**와 **rssrvpolicy.config** 파일에서 PowerPoint 형식 확장 및 코드 실행 권한을 제거하도록 업데이트되지 않았다면, 앞 단계에서 파일을 삭제한 것과 같은 방법으로 수동으로 제거해야 합니다. 

**Step** **14:** 이제 Aspose.Slides for Reporting Services를 재설치할 시간입니다. MSI 설치 프로그램을 사용하여 자동 설치하거나 수동으로 설치하십시오.
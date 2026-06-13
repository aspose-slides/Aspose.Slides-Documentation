---
title: Visual Studio 2005 또는 2008 보고서 디자이너와 수동 통합
type: docs
weight: 50
url: /ko/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 
이 문서는 Aspose.Slides for Reporting Services를 Visual Studio와 수동으로 통합하는 방법을 안내합니다. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 
**Aspose.Slides for Reporting Services**는 호스트 머신에 **.NET Framework 3.5**가 설치되어 있어야 합니다. 
{{% /alert %}}

## **Aspose.Slides for Reporting Services를 Visual Studio와 통합하기**
MSI 설치 프로그램을 사용하여 Aspose.Slides for Reporting Services를 설치하는 것을 권장합니다. MSI 설치 프로그램은 모든 필요한 설치 작업과 구성 프로세스를 자동으로 수행합니다. 그러나 MSI 설치 프로그램으로 설치가 실패할 경우, 여기의 가이드를 사용하십시오. 

이 문서는 Business Intelligence Development Studio가 설치된 컴퓨터에 Aspose.Slides for Reporting Services를 설치하는 방법도 안내합니다. 이를 통해 Microsoft Visual Studio 2005 또는 2008 보고서 디자이너에서 디자인 시점에 보고서를 Microsoft PowerPoint 형식으로 내보낼 수 있습니다. 

1. Aspose.Slides.ReportingServices.dll을 Visual Studio 디렉터리에 복사합니다.

   - Visual Studio 2005 보고서 디자이너와 통합하려면 **Aspose.Slides.ReportingServices.dll**을 **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies** 디렉터리에 복사합니다.
   - Visual Studio 2008 보고서 디자이너와 통합하려면 **Aspose.Slides.ReportingServices.dll**을 **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 디렉터리에 복사합니다.
2. Aspose.Slides for Reporting Services를 렌더링 확장으로 등록합니다. 

3. **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config** ( <Version>은 Visual Studio 2005일 경우 “8”, Visual Studio 2008일 경우 “9.0”) 를 열고 <Render> 요소에 다음 줄을 추가합니다: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Aspose.Slides for Reporting Services에 실행 권한을 부여합니다. 
   1. **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** 파일을 엽니다(<Version>은 Visual Studio 2005일 경우 “8”, Visual Studio 2008일 경우 “9.0”). 
   1. 두 번째 외부 <CodeGroup> 요소의 마지막 항목으로 이 줄을 추가합니다(다음과 같아야 합니다: <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--여기서 시작합니다.-->

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

    <!--여기서 끝납니다.-->

  </CodeGroup>

</CodeGroup>



```

5. Aspose.Slides for Reporting Services가 성공적으로 설치되었는지 확인합니다. 
6. Microsoft Visual Studio 2005 또는 2008 보고서 디자이너를 실행하거나 재시작합니다. 내보내기 형식 목록에 새로운 형식이 표시되는 것을 확인할 수 있습니다.

**새 내보내기 형식이 보고서 디자이너에 나타납니다.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)
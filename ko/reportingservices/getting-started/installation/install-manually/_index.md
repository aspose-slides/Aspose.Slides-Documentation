---
title: 수동 설치
type: docs
weight: 30
url: /ko/reportingservices/install-manually/
keywords:
- 수동 설치
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "DLL 전용 ZIP 패키지에서 Aspose.Slides for Reporting Services를 직접 설치합니다: 복사할 어셈블리와 rsreportserver.config 및 rssrvpolicy.config에 추가할 내용을 설명합니다."
---
## **개요**

MSI 설치 프로그램 없이 ZIP 패키지 *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* 에서 Aspose.Slides for Reporting Services를 설치하려면 다음 단계를 따르세요. 이 패키지는 [download page](https://releases.aspose.com/slides/ko/reportingservices/)에 있습니다. 이 단계는 [MSI installer](/slides/ko/reportingservices/install-with-msi-installer/)와 동일한 확장자를 등록합니다. 각 보고 서버 인스턴스마다 반복하십시오.

시작하기 전에 [system requirements](/slides/ko/reportingservices/system-requirements/)를 확인하십시오. 보고 서버에 대한 로컬 관리자 권한이 필요합니다.

## **어셈블리 선택**

ZIP 패키지에는 여러 빌드가 포함되어 있습니다. 보고 서버에 *Aspose.Slides.ReportingServices.dll* 파일을 정확히 하나 복사하십시오:

| ZIP 패키지 내 파일 | 사용 대상 |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 이후 Reporting Services 및 Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | 보고 서버용이 아님: ReportViewer 2010 또는 2012 컨트롤에서 내보내는 애플리케이션, 자세한 내용은 [Using Aspose.Slides with ReportViewer 2010 and 2012](/slides/ko/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | 선택 사항: 문제 보고서를 위해 보고서를 RPL 형식으로 저장합니다. 자세한 내용은 [Exporting Reports to RPL Format](/slides/ko/reportingservices/exporting-reports-to-rpl-format/) |

## **보고 서버 폴더 찾기**

아래 단계는 *ReportServer* 폴더( *rsreportserver.config* 와 *rssrvpolicy.config* 가 포함된 폴더)를 참조합니다. 기본 설치에서는 다음과 같습니다:

| 보고 서버 | 기본 *ReportServer* 폴더 |
| :- | :- |
| SQL Server 2017 이후 Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 및 이전 Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, 여기서 인스턴스 폴더는 예를 들어 SQL Server 2016 의 경우 `MSRS13.MSSQLSERVER`, SQL Server 2005 의 경우 `MSSQL.x` 입니다. |

자세한 위치는 Microsoft의 [RsReportServer.config configuration file](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file) 문서를 확인하십시오.

## **확장 설치**

1. 선택한 어셈블리를 *ReportServer* 폴더의 *bin* 하위 폴더에 복사합니다.

   복사한 파일에 명시적으로 할당된 NTFS 권한이 없어야 합니다. 그렇지 않으면 어셈블리를 로드할 때 보고 서버가 접근을 거부하고 새 내보내기 형식이 표시되지 않습니다. 파일을 마우스 오른쪽 버튼으로 클릭하고 **Properties**를 선택한 다음 **Security** 탭에서 명시적으로 할당된 권한을 모두 제거하고 상속된 권한만 남깁니다. **General** 탭에 **Unblock** 옵션이 표시되면 선택하십시오.

2. *rsreportserver.config* 의 사본을 저장한 뒤 텍스트 편집기로 엽니다. `<Render>` 요소 안에 다음 항목을 추가합니다:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   각 항목은 하나의 내보내기 형식을 등록합니다. `Name` 은 렌더링 확장 사이에서 고유해야 합니다. MSI 설치 프로그램은 동일한 6개의 이름과 유형을 등록합니다. 내보내기 목록에 해당 형식을 원하지 않으면 항목을 생략하십시오.

3. *rssrvpolicy.config* 의 사본을 저장한 뒤 텍스트 편집기로 엽니다. `Description` 이 "This code group grants MyComputer code Execution permission." 인 코드 그룹을 찾고, 다음 코드 그룹을 마지막 자식으로 추가합니다:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` 은 Aspose.Slides.ReportingServices 어셈블리의 공개 키입니다. 한 줄에 유지하십시오.

4. 두 파일을 모두 저장합니다. 보고 서버는 파일이 저장될 때마다 구성 파일을 다시 읽습니다. 파일에 잘못된 XML이 포함되어 있으면 서버가 이를 무시하거나 시작되지 않으므로 문제가 발생하면 사본을 복원하십시오.

## **설치 확인**

웹 포털( SQL Server 2014 이전의 경우 Report Manager)에서 페이지 매김된 보고서를 열고 **Export** 목록을 엽니다. 이제 다음 형식이 포함됩니다:

- PPT - PowerPoint 프레젠테이션 via Aspose.Slides
- PPS - PowerPoint 슬라이드쇼 via Aspose.Slides
- PPTX - PowerPoint 2007 프레젠테이션 via Aspose.Slides
- PPSX - PowerPoint 2007 슬라이드쇼 via Aspose.Slides
- ODP - OpenDocument 프레젠테이션 via Aspose.Slides
- XPS - via Aspose.Slides

그 중 하나를 선택해 보고서를 내보냅니다. 파일은 해당 형식과 연결된 애플리케이션에서 열립니다.

![Aspose.Slides for Reporting Services를 사용하여 PowerPoint로 내보낸 보고서](install-manually_2.png)

형식이 표시되지 않으면 복사한 어셈블리의 NTFS 권한을 확인하십시오. 라이선스가 없으면 내보낸 파일에 평가용 워터마크가 표시됩니다; 자세한 내용은 [Licensing](/slides/ko/reportingservices/license-aspose-slides-for-reporting-services/) 를 확인하십시오.
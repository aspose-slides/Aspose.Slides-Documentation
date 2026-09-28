---
title: MSI 설치 프로그램으로 설치
type: docs
weight: 20
url: /ko/reportingservices/install-with-msi-installer/
keywords:
- MSI 설치 프로그램
- 설치
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "MSI 설치 프로그램을 사용하여 Aspose.Slides for Reporting Services를 설치합니다: 설치 프로그램에 필요한 것, 각 보고서 서버 인스턴스에 적용되는 변경 사항, 결과 확인 방법."
---
## **설치**

MSI 설치 프로그램은 Aspose.Slides for Reporting Services를 설치하는 가장 간단한 방법입니다. 보고서 서버에 .NET Framework 3.5와 관리자 권한이 필요합니다; 자세한 내용은 [시스템 요구 사항](/slides/ko/reportingservices/system-requirements/)을 참고하세요.

1. MSI 설치 프로그램인 *Aspose.Slides for Reporting Services XX.XX*을 [다운로드 페이지](https://releases.aspose.com/slides/ko/reportingservices/)에서 다운로드하고 보고서 서버에 복사합니다.
1. 관리자 권한으로 실행합니다. .NET Framework 3.5가 없으면 설치 프로그램이 메시지를 표시하고 중지됩니다; .NET Framework 3.5 기능을 설치한 후 다시 실행합니다.
1. 라이선스 계약에 동의합니다.
1. **Custom Setup** 페이지에서 기능 트리는 설치 프로그램이 머신에서 감지한 각 SQL Server Reporting Services 및 Power BI Report Server 인스턴스를 표시합니다. 인스턴스를 변경하지 않으려면 해당 아이콘을 클릭하고 **Entire feature will be unavailable**를 선택합니다. Express 에디션은 렌더링 확장자를 지원하지 않으므로 Express 인스턴스를 선택하지 마십시오. 설치 프로그램은 SQL Server 2016 이전 버전의 Express 인스턴스를 숨깁니다.
1. **Next**를 선택한 다음 **Install**를 선택합니다.

선택적 **Rpl Export** 기능은 기본적으로 선택되지 않습니다. 이 기능은 보고서를 RPL 형식으로 저장하는 숨겨진 확장자를 추가하며, Aspose에 문제 보고서를 보낼 때 유용합니다; 자세한 내용은 [RPL 형식으로 보고서 내보내기](/slides/ko/reportingservices/exporting-reports-to-rpl-format/)를 참고하세요.

## **설치 프로그램이 변경하는 내용**

설치 프로그램은 32비트 패키지이므로 64비트 Windows에서는 *Program Files (x86)* 폴더 아래 *Aspose\Aspose.Slides for Reporting Services*에 파일을 보관합니다. 그런 다음 선택된 각 인스턴스에 대해 다음을 수행합니다:

- 인스턴스의 *ReportServer\bin* 폴더에 *Aspose.Slides.ReportingServices.dll*을 복사합니다 — SQL Server 2005용 빌드 또는 SQL Server 2008 이후 및 Power BI Report Server용 빌드;
- 여섯 개의 렌더링 확장(ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS 및 ASODP)을 *rsreportserver.config*의 `<Render>` 요소에 추가합니다;
- 어셈블리에 전체 신뢰를 부여하는 코드 그룹을 *rssrvpolicy.config*에 추가합니다;
- 변경된 각 구성 파일의 복사본을 파일 이름에 *.bak*를 추가하여 저장합니다.

[수동 설치](/slides/ko/reportingservices/install-manually/)에서 이러한 변경 사항을 단계별로 확인할 수 있습니다.

인스턴스를 구성할 수 없는 경우, 설치 프로그램은 메시지에 해당 인스턴스 이름을 표시하고 설치 폴더에 *rserrors<date>.log* 파일에 세부 정보를 기록합니다. 해당 인스턴스에 확장을 수동으로 설치하십시오.

## **설치 확인**

웹 포털(SQL Server 2014 및 이전 버전의 Report Manager)에서 페이지가 있는 보고서를 열고 **Export** 목록을 엽니다. 이제 다음 형식이 포함됩니다:

- PPT - Aspose.Slides를 통한 PowerPoint 프레젠테이션
- PPS - Aspose.Slides를 통한 PowerPoint 슬라이드쇼
- PPTX - Aspose.Slides를 통한 PowerPoint 2007 프레젠테이션
- PPSX - Aspose.Slides를 통한 PowerPoint 2007 슬라이드쇼
- ODP - Aspose.Slides를 통한 OpenDocument 프레젠테이션
- XPS - Aspose.Slides를 통해

라이선스가 없을 경우, 내보낸 파일에 평가용 워터마크가 표시됩니다; 자세한 내용은 [라이선스](/slides/ko/reportingservices/license-aspose-slides-for-reporting-services/)를 참고하세요.

## **수동 설치 시점**

다음 상황에서는 확장을 [수동으로](/slides/ko/reportingservices/install-manually/) 설치합니다:

- 설치 프로그램이 인스턴스를 구성할 수 없는 경우(예: 서버 보안 설정 때문에);
- 업그레이드 후 이전 버전을 제거하고 새 설치 프로그램을 실행하는 대신 어셈블리만 교체하려는 경우.

제품을 제거하면 각 인스턴스에서 어셈블리와 구성 항목이 삭제됩니다.
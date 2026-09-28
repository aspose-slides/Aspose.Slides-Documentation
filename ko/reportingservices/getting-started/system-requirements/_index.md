---
title: 시스템 요구 사항
type: docs
weight: 15
url: /ko/reportingservices/system-requirements/
keywords:
- 시스템 요구 사항
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "설치하기 전에 Aspose.Slides for Reporting Services가 필요로 하는 보고서 서버, 에디션 및 .NET Framework 버전을 확인하십시오."
---
## **개요**

Aspose.Slides for Reporting Services는 렌더링 확장 기능으로 보고서 서버 내부에서 실행됩니다. 이 페이지에서는 보고서 서버 머신에 [설치](/slides/ko/reportingservices/installing-aspose-slides-for-reporting-services/)하기 전에 필요한 사항을 나열합니다. Microsoft PowerPoint와 Microsoft Office는 필요하지 않습니다.

## **지원되는 보고서 서버**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, 페이징된 (RDL) 보고서용

32비트와 64비트 보고서 서버 모두 지원됩니다. SQL Server 2005는 자체 빌드를 사용하고, 이후 모든 버전 및 Power BI Report Server는 동일한 빌드를 사용합니다. [수동 설치](/slides/ko/reportingservices/install-manually/)에서 복사할 파일을 확인할 수 있습니다.

목록에 보고서 서버 버전이 없으면, 배포하기 전에 [무료 지원 포럼](https://forum.aspose.com/c/slides/11)에서 문의하세요.

## **보고서 서버 에디션**

SQL Server 2016 Reporting Services 이후 버전과 Power BI Report Server의 경우, Microsoft는 Enterprise, Standard, Developer, Evaluation 에디션에서 렌더링 확장 기능을 지원합니다; Web 및 Express 에디션은 이를 지원하지 않습니다. [에디션별 지원되는 Reporting Services 기능](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server)을 참조하십시오. MSI 설치 프로그램은 SQL Server 2016 및 이전 버전의 Express 에디션 인스턴스를 건너뜁니다.

## **.NET Framework**

.NET Framework 3.5는 보고서 서버 머신에 설치되어 있어야 합니다. 확장의 어셈블리는 .NET Framework 2.0 런타임용으로 빌드되었으며, .NET Framework 3.5가 없을 경우 MSI 설치 프로그램이 메시지를 표시하고 중지됩니다. Windows Server에서는 역할 및 기능 추가 마법사에서 **.NET Framework 3.5 기능**을 추가하세요; 자세한 내용은 [Windows에 .NET Framework 3.5 설치](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows)를 참조하십시오.

## **권한**

확장을 설치하면 보고서 서버 폴더의 파일이 변경되므로, 두 설치 경로 모두 로컬 관리자 권한이 필요합니다. 관리자 권한 없이 MSI 설치 프로그램을 시작하면 관리자 권한으로 다시 시작하겠다는 옵션을 제공합니다.

## **FAQ**

**보고서 서버에 Microsoft PowerPoint가 필요합니까?**

아니요. 확장은 자체적으로 프레젠테이션을 생성하므로 PowerPoint나 Microsoft Office를 설치할 필요가 없습니다.

**Express 에디션에 확장을 설치할 수 있나요?**

아니요. Express 에디션은 렌더링 확장을 지원하지 않습니다. MSI 설치 프로그램은 SQL Server 2016 및 이전 버전의 Express 인스턴스를 숨기며, 이후 버전에서는 Express 인스턴스를 선택하지 마세요.

**확장이 내보내기 목록에 추가하는 형식은 무엇입니까?**

PPT, PPS, PPTX, PPSX, ODP 및 XPS. [지원되는 파일 형식](/slides/ko/reportingservices/supported-file-formats/)을 보십시오.
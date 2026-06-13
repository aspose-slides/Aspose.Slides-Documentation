---
title: 선언
type: docs
weight: 110
url: /ko/net/declaration/
keywords:
- 선언
- 구성 요소
- Full Trust 권한
- 레지스트리 설정
- 시스템 파일
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 신뢰 요구 사항, 권한 및 호스팅 제한에 대해 알아보고 PPT, PPTX 및 ODP를 처리하는 애플리케이션을 서버에 안전하게 배포할 수 있습니다."
---
{{% alert color="primary" %}} 

모든 Aspose .NET 구성 요소는 Full Trust 권한 세트가 필요합니다. 이는 특정 작업(예: 글꼴 파싱) 중에 레지스트리 설정, 시스템 파일 및 가상 디렉터리 외의 다른 위치에 저장된 파일에 액세스해야 할 때가 있기 때문입니다. 또한 Aspose .NET 구성 요소는 핵심 .NET 시스템 클래스를 기반으로 하며, 많은 경우 Full Trust 권한 세트가 필요합니다. 

{{% /alert %}} 

여러 회사의 여러 애플리케이션을 호스팅하는 인터넷 서비스 제공업체(ISP)는 대부분 Medium Trust 보안 수준을 적용합니다. .NET 2.0 환경에서는 이러한 보안 수준이 다음과 같은 제약을 적용합니다: 

- OleDbPermission이 제공되지 않습니다. 이는 데이터베이스에 액세스하기 위해 ADO.NET 관리형 OLE DB 데이터 공급자를 사용할 수 없음을 의미합니다.
- EventLogPermission이 제공되지 않습니다. 이는 Windows 이벤트 로그에 액세스할 수 없음을 의미합니다.
- ReflectionPermission이 제공되지 않습니다. 이는 리플렉션을 사용할 수 없음을 의미합니다.
- RegistryPermission이 제공되지 않습니다. 이는 레지스트리에 액세스할 수 없음을 의미합니다.
- WebPermission이 제한됩니다. 이는 애플리케이션이 <trust> 요소에 정의한 주소 또는 주소 범위와만 통신할 수 있음을 의미합니다.
- FileIOPermission이 제한됩니다. 이는 애플리케이션의 가상 디렉터리 계층 내 파일에만 접근할 수 있음을 의미합니다.

{{% alert color="primary" %}} 

위의 이유로 인해 Aspose .NET 구성 요소는 Full Trust 권한 세트를 부여하는 서버에서만 사용할 수 있습니다. 

{{% /alert %}}
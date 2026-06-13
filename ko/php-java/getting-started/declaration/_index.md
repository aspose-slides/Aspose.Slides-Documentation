---
title: 선언
type: docs
weight: 60
url: /ko/php-java/declaration/
keywords:
- 선언
- 구성 요소
- 전체 신뢰 권한
- 레지스트리 설정
- 시스템 파일
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP의 신뢰 요구 사항, 권한 및 호스팅 제한 사항에 대해 배우고, 서버에서 PPT, PPTX 및 ODP를 처리하는 앱을 안전하게 배포할 수 있습니다."
---
{{% alert color="primary" %}} 

모든 Aspose Java 구성 요소는 Full Trust 권한 집합이 필요합니다. 그 이유는 Aspose Java 구성 요소가 레지스트리 설정, 가상 디렉터리 외의 시스템 파일 등에 접근해야 하며, 글꼴 파싱 등 특정 작업을 수행하기 위해 필요합니다. 또한 Aspose Java 구성 요소는 핵심 Java 시스템 클래스를 기반으로 하며, 많은 경우 Full Trust 권한 집합이 필요합니다. 

{{% /alert %}} 

다양한 회사의 여러 애플리케이션을 호스팅하는 인터넷 서비스 제공업체(ISP)는 대부분 Medium Trust 보안 수준을 적용합니다: 

- OleDbPermission은 사용할 수 없습니다. 이는 데이터베이스에 접근하기 위해 ADO.NET 관리형 OLE DB 데이터 제공자를 사용할 수 없음을 의미합니다.
- EventLogPermission은 사용할 수 없습니다. 이는 Windows 이벤트 로그에 접근할 수 없음을 의미합니다.
- ReflectionPermission은 사용할 수 없습니다. 이는 리플렉션을 사용할 수 없음을 의미합니다.
- RegistryPermission은 사용할 수 없습니다. 이는 레지스트리에 접근할 수 없음을 의미합니다.
- WebPermission은 제한됩니다. 이는 애플리케이션이 <trust> 요소에 정의한 주소 또는 주소 범위와만 통신할 수 있음을 의미합니다.
- FileIOPermission은 제한됩니다. 이는 애플리케이션의 가상 디렉터리 계층에 있는 파일에만 접근할 수 있음을 의미합니다.

{{% alert color="primary" %}} 

위에서 언급한 이유로 인해, Full Trust가 아닌 권한 집합을 부여하는 서버에서는 Aspose Java 구성 요소를 사용할 수 없습니다. 

{{% /alert %}}
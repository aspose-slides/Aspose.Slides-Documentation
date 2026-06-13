---
title: 선언
type: docs
weight: 60
url: /ko/java/declaration/
keywords:
- 선언
- 구성 요소
- Full Trust 권한
- 레지스트리 설정
- 시스템 파일
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 신뢰 요구 사항, 권한 및 호스팅 제한 사항에 대해 학습하여 PPT, PPTX 및 ODP를 처리하는 애플리케이션을 서버에 안전하게 배포할 수 있습니다."
---
{{% alert color="primary" %}} 

모든 Aspose Java 구성 요소는 Full Trust 권한 세트가 필요합니다. 그 이유는 Aspose Java 구성 요소가 레지스트리 설정, 가상 디렉터리를 제외한 시스템 파일 등에 접근해야 폰트 파싱 등 특정 작업을 수행할 수 있기 때문입니다. 또한 Aspose Java 구성 요소는 핵심 Java 시스템 클래스를 기반으로 하며, 이러한 클래스도 많은 경우 Full Trust 권한 세트를 요구합니다. 

{{% /alert %}} 

여러 회사의 애플리케이션을 다수 호스팅하는 인터넷 서비스 제공업체는 대부분 Medium Trust 보안 수준을 적용합니다: 

- OleDbPermission이 제공되지 않습니다. 이는 ADO.NET 관리형 OLE DB 데이터 제공자를 사용해 데이터베이스에 접근할 수 없음을 의미합니다.
- EventLogPermission이 제공되지 않습니다. 이는 Windows 이벤트 로그에 접근할 수 없음을 의미합니다.
- ReflectionPermission이 제공되지 않습니다. 이는 리플렉션을 사용할 수 없음을 의미합니다.
- RegistryPermission이 제공되지 않습니다. 이는 레지스트리에 접근할 수 없음을 의미합니다.
- WebPermission이 제한됩니다. 이는 애플리케이션이 <trust> 요소에 정의한 주소 또는 주소 범위와만 통신할 수 있음을 의미합니다.
- FileIOPermission이 제한됩니다. 이는 애플리케이션의 가상 디렉터리 계층 구조에 있는 파일만 접근할 수 있음을 의미합니다.

{{% alert color="primary" %}} 

위에서 언급한 이유들로 인해 Full Trust가 아닌 권한 세트를 부여하는 서버에서는 Aspose Java 구성 요소를 사용할 수 없습니다. 

{{% /alert %}}
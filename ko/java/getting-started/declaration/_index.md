---
title: 보안 관리자 요구 사항
type: docs
weight: 190
url: /ko/java/declaration/
keywords:
- 보안 관리자
- 보안 정책
- AllPermission
- 권한
- 샌드박스
- JDK 24
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Java 23 및 이전 버전에서 Aspose.Slides for Java와 이를 호출하는 코드에 필요한 Security Manager 권한은 무엇이며, Java 24 및 이후 버전에서는 구성할 것이 없는 이유를 설명합니다."
---
## **개요**

Java 보안 관리자는 보안 정책에 따라 코드가 할 수 있는 작업을 제한합니다. Java 17에서 제거를 위해 폐기되었으며([JEP 411](https://openjdk.org/jeps/411)), Java 24에서는 영구적으로 비활성화되었습니다([JEP 486](https://openjdk.org/jeps/486)). 이 문서는 애플리케이션이 여전히 보안 관리자를 사용하여 실행되는 경우 Aspose.Slides for Java에 필요한 사항을 설명합니다. 기본값으로 보안 관리자를 사용하지 않는 경우 구성할 것이 없습니다.

## **Java 23 및 이전 버전**

보안 관리자가 활성화된 경우, 보안 정책은 Aspose.Slides JAR 파일과 이를 호출하는 애플리케이션 코드에 다음 권한을 부여해야 합니다:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides는 시스템 속성을 읽습니다.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides는 글꼴 파일 및 기타 파일을 읽습니다.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides는 운영 체제 프로그램을 시작합니다. 예를 들어 Windows에서는 `reg`, Linux에서는 `fc-match`가 있습니다.
- `java.io.FilePermission`에 `write` 작업을 추가하여 애플리케이션이 파일을 저장하는 폴더에 대한 권한을 부여합니다.

JAR 파일에만 권한을 부여하는 것으로는 충분하지 않으며, Aspose.Slides를 호출하는 코드에도 동일한 권한이 필요합니다. 두 대상 모두에 `java.security.AllPermission`을 부여해도 작동합니다.

시스템 속성을 읽거나 프로그램을 시작할 권한이 없으면, Aspose.Slides는 첫 사용 시 실패합니다: [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 객체를 생성하면 `ExceptionInInitializerError`가 발생합니다. 글꼴 파일에 대한 읽기 권한이 없으면 프레젠테이션을 PDF로 저장할 때 "Cannot find any fonts installed on the system" 오류가 발생합니다.

## **Java 24 및 이후 버전**

Java 24 및 이후 버전에서는 보안 관리자를 활성화할 수 없으므로 부여할 권한이 없습니다. Aspose.Slides는 애플리케이션을 실행하는 계정의 권한으로 실행됩니다. 애플리케이션이 접근할 수 있는 범위를 제한하려면 OpenJDK 프로젝트에서는 컨테이너, 하이퍼바이저, 운영 체제 샌드박스 기능 등 JDK 외부 기술을 사용할 것을 권장합니다. 자세히 보려면 [JEP 486](https://openjdk.org/jeps/486)을 참조하십시오.

## **FAQ**

**제한적인 Security Manager 정책 하에서 애플리케이션을 실행하는 환경에서도 Aspose.Slides를 사용할 수 있나요?**

위에 나열된 권한이 Aspose.Slides와 이를 호출하는 코드 모두에게 부여되는 경우에만 가능합니다. 여기에는 모든 파일을 읽고 모든 프로그램을 시작하는 권한이 포함됩니다.
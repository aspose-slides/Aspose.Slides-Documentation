---
title: 보안
type: docs
weight: 160
url: /ko/java/security/
keywords:
- 보안
- 종속성
- 제3자 구성 요소
- Maven
- JAR 서명
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java가 프레젠테이션을 처리하는 방식, 프로젝트 종속성에 추가되는 내용, JAR 파일을 검증하는 방법, 포함된 제3자 구성 요소를 검토합니다."
---
## **소개**

이 문서는 Aspose.Slides for Java를 사용하는 애플리케이션에 대한 보안 검토에 일반적으로 필요한 정보를 수집합니다: 라이브러리가 프레젠테이션을 처리하는 방법, 프로젝트에 추가되는 종속성, JAR 파일이 Aspose에서 제공된 것인지 확인하는 방법, 그리고 JAR 파일에 포함된 제3자 구성 요소.

## **Aspose.Slides의 보안**

Aspose는 제품 개발 시 모범 사례를 적용합니다.

* Aspose.Slides for Java는 프레젠테이션을 만들고, 수정하고, 변환하는 데 사용됩니다. 프레젠테이션 내에서 스크립트를 실행하지 않습니다. Aspose.Slides는 프레젠테이션 구조를 구문 분석하고 코드가 객체 모델로 작업할 수 있도록 합니다.
* Aspose.Slides는 원격 코드를 실행하지 않고 문서를 구문 분석하고 해석하는 라이브러리로 작동합니다. 모든 Aspose 제품은 사용자의 컴퓨터에서 실행됩니다. Aspose에 데이터를 전송하지 않습니다. 유일한 예외는 [metered licensing](/slides/ko/java/metered-licensing/): 이를 사용할 경우 API 사용 정보만 처리됩니다.
* Aspose 구성 요소는 일반 애플리케이션과 동일한 사용자 컨텍스트에서 실행됩니다. 따라서 Aspose 구성 요소가 핵심 시스템 리소스에 위험을 초래하지 않습니다. 또한 Aspose 구성 요소가 문서를 열 때 매크로가 자동으로 실행되지 않습니다.

## **Maven 종속성**

Aspose.Slides for Java의 Maven 아티팩트인 `com.aspose:aspose-slides`는 종속성을 선언하지 않습니다. POM 파일에는 해당 아티팩트 자체 좌표만 포함되어 있습니다. 프로젝트에 추가하면 Maven은 이 JAR 파일 하나만 추가하고 다른 것은 추가하지 않습니다. 전이적 종속성을 포함하여 프로젝트가 해결하는 모든 아티팩트를 나열하려면 프로젝트 폴더에서 다음 명령을 실행하십시오:

```bash
mvn dependency:tree
```

[Installation](/slides/ko/java/installation/) 프로젝트에서 출력은 Aspose.Slides를 유일한 종속성으로 나열합니다:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **JAR 파일 확인**

Aspose는 JAR 파일에 서명합니다. 서명을 확인하려면 JAR 파일이 있는 폴더에서 JDK의 `jarsigner` 도구를 실행하십시오:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

서명이 유효하고 파일이 서명된 이후 항목이 변경되지 않았을 경우 명령은 `jar verified.`를 출력합니다. 이 메시지는 서명자를 표시하지 않습니다. Aspose가 파일에 서명했는지 확인하려면 `-verbose`와 `-certs` 옵션을 추가하고 서명자 인증서가 `CN=ASPOSE PTY LTD`에 발급되었는지 확인하십시오. Maven이 JAR 파일을 다운로드할 때도 저장소가 파일 옆에 게시하는 SHA-1 체크섬을 확인합니다.

## **제3자 구성 요소**

Aspose.Slides for Java에는 제3자 구성 요소의 코드와 데이터가 포함되어 있습니다. 이들은 별도의 Maven 아티팩트가 아니라 JAR 파일의 일부이므로 `mvn dependency:tree` 등 Maven 종속성을 읽는 도구에서는 표시되지 않습니다. JAR 파일에는 *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf* 공지가 포함되어 있으며, 여기에는 구성 요소와 해당 라이선스가 나열되어 있습니다:

| 구성 요소 | 공지에 명시된 라이선스 |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT-style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

JAR 파일에서 공지를 추출하려면 JAR 파일이 있는 폴더에서 JDK의 `jar` 도구를 실행하십시오:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**Aspose.Slides for Java가 외부 패키지를 사용합니까?**

[Maven Dependencies](#maven-dependencies)에서 확인할 수 있듯이 Maven 종속성이 없지만, [Third-Party Components](#third-party-components)에 나열된 제3자 구성 요소가 포함되어 있습니다. 보안 검토 시 JAR 파일과 이러한 구성 요소를 모두 포함하십시오.

**Aspose.Slides for Java가 네트워크 접근이 필요합니까?**

아니요. 프레젠테이션을 만들고, 저장하고, 렌더링하는 작업은 네트워크 연결이 없는 시스템에서도 동작합니다. Aspose에 데이터를 전송하는 유일한 기능은 [metered licensing](/slides/ko/java/metered-licensing/)이며, 이는 API 사용량을 보고합니다.

**Aspose.Slides for Java에 네이티브 코드가 포함되어 있습니까?**

아니요. JAR 파일에는 Java 클래스와 리소스만 포함되어 있어 애플리케이션에 네이티브 라이브러리를 추가하지 않습니다. Linux에서는 Java 런타임의 폰트 지원을 위해 fontconfig 라이브러리와 운영 체제의 글꼴이 필요합니다; 자세히 보려면 [System Requirements](/slides/ko/java/system-requirements/#linux)를 참고하십시오.
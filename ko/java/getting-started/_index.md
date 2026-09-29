---
title: 시작하기
type: docs
weight: 10
url: /ko/java/getting-started/
keywords:
- 시작하기
- 시스템 요구 사항
- 설치
- 첫 번째 프레젠테이션
- Maven
- PPT 처리
- PPTX 처리
- ODP 처리
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "새 Java 프로젝트에서 Aspose.Slides로 첫 번째 저장된 프레젠테이션까지의 단계: 요구 사항을 확인하고, Aspose의 Maven 저장소에서 라이브러리를 추가한 뒤 첫 번째 프로그램을 실행하고, 일반 작업을 계속합니다."
---
## **개요**

아래 네 단계를 순서대로 진행하십시오. 각 단계는 수행할 작업을 이름으로 제시하고 자세한 내용이 담긴 문서로 연결합니다. 평가, 라이선스 및 지원은 단계 후에 설명됩니다.

## **1단계: 시스템 요구 사항 확인**

Aspose.Slides for Java는 네이티브 코드가 없는 단일 JAR 파일이므로 지원되는 Java 런타임이 설치된 모든 운영 체제에서 실행됩니다. [시스템 요구 사항](/slides/ko/java/system-requirements/) 페이지에 지원되는 운영 체제와 Java 버전이 나열되어 있습니다. 다음 단계의 프로젝트와 명령은 JDK 11 이상이 필요하며, Maven을 사용하는 경우 [Apache Maven](https://maven.apache.org/install.html)도 필요합니다.

## **2단계: 라이브러리를 프로젝트에 추가**

Aspose.Slides for Java는 Maven Central이 아니라 Aspose 자체 Maven 저장소에 게시됩니다. 다음 방법 중 하나를 선택하십시오:

- Maven 사용: *pom.xml*에 저장소 `https://releases.aspose.com/java/repo/`를 선언하고 `com.aspose:aspose-slides` 의존성을 `jdk16` 클래시파이어와 함께 추가합니다.
- Maven 미사용: 저장소에서 이름이 *-jdk16.jar* 로 끝나는 JAR 파일을 다운로드하여 클래스 경로에 넣습니다.

Linux에서는 fontconfig 라이브러리와 최소 하나의 글꼴을 설치해야 합니다. 이를 설치하지 않으면 프레젠테이션 저장 시 “Fontconfig head is null, check your fonts or fonts configuration” 오류가 발생합니다.

[설치](/slides/ko/java/installation/) 페이지에 *pom.xml* 항목, JAR 다운로드 방법 및 Linux 명령이 제공됩니다.

## **3단계: 첫 번째 프레젠테이션 만들기**

[Aspose.Slides for Java 홈 페이지의 빠른 시작](/slides/ko/java/#your-first-presentation) 예제는 완전한 Maven 프로젝트입니다: *pom.xml* 파일과 클라우드 모양을 텍스트와 함께 슬라이드에 추가하고 프레젠테이션을 PPTX 파일로 저장하는 프로그램이 포함되어 있습니다. 이 예제는 `mvn compile exec:java` 로 실행합니다. [프레젠테이션 만들기](/slides/ko/java/create-presentation/) 문서에서는 같은 프로그램을 단계별로 자세히 설명합니다. 기존 프레젠테이션을 열고 다른 형식으로 저장하려면 [프레젠테이션 열기](/slides/ko/java/open-presentation/)와 [프레젠테이션 저장](/slides/ko/java/save-presentation/)을 참고하십시오.

## **4단계: 일반 작업 계속하기**

- [프레젠테이션 열기](/slides/ko/java/open-presentation/)
- [프레젠테이션 저장](/slides/ko/java/save-presentation/)
- [프레젠테이션을 PDF로 변환](/slides/ko/java/convert-powerpoint-to-pdf/)
- [슬라이드를 이미지로 렌더링](/slides/ko/java/convert-slide/)
- [프레젠테이션 텍스트 편집](/slides/ko/java/manage-text/)
- [슬라이드 요소별 예제](/slides/ko/java/examples/)

## **평가 및 라이선스**

라이선스가 없으면 Aspose.Slides는 평가 모드로 실행됩니다. 저장하는 모든 슬라이드에 워터마크가 추가되고, 코드가 프레젠테이션에서 읽는 텍스트가 잘려 나갑니다.

- [Aspose.Slides 평가](/slides/ko/java/evaluate-aspose-slides/) 페이지에서 평가 제한 사항과 임시 라이선스 요청 방법을 확인할 수 있습니다.
- [라이선스](/slides/ko/java/licensing/)에서는 파일 또는 스트림에서 라이선스를 적용하는 방법을 보여줍니다.
- [사용량 기반 라이선스](/slides/ko/java/metered-licensing/)에서는 사용량에 따라 청구되는 라이선스 모델을 다룹니다.
- [지원 파일 형식](/slides/ko/java/supported-file-formats/)에서는 Aspose.Slides가 로드하고 저장할 수 있는 형식 목록을 제공합니다.

## **도움받기**

[기술 지원](/slides/ko/java/technical-support/) 페이지에서는 [무료 지원 포럼](https://forum.aspose.com/c/slides/ko/11)에서 질문하는 방법과 문제를 보고할 때 포함해야 할 내용을 설명합니다.

## **FAQ**

**Microsoft PowerPoint를 설치해야 하나요?**

아니요. Aspose.Slides는 프레젠테이션 파일을 자체적으로 읽고 쓰며 PowerPoint를 사용하지 않으므로 서버 및 Linux에서도 실행됩니다.

**Maven이 Aspose.Slides for Java를 찾지 못하는 이유는?**

라이브러리가 Maven Central에 없기 때문입니다. *pom.xml*에 Aspose 저장소를 선언하면 ([설치](/slides/ko/java/installation/) 참고) Maven이 해당 저장소에서 라이브러리를 다운로드합니다.

**`jdk16` 클래시파이어가 라이브러리가 Java 16을 필요로 한다는 의미인가요?**

아니요. 이 클래시파이어는 라이브러리의 Java SE 빌드를 선택합니다. 다른 빌드는 Android용이며, 같은 빌드가 현재 JDK(예: JDK 21)에서도 동작합니다.
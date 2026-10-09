---
title: 설치
type: docs
weight: 70
url: /ko/java/installation/
keywords:
- Aspose.Slides 설치
- Aspose.Slides 다운로드
- Aspose.Slides 사용
- Aspose.Slides 설치
- 윈도우
- 리눅스
- 맥OS
- 파워포인트
- 오픈문서
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose의 Maven 리포지터리에서 또는 JAR 파일로 Aspose.Slides for Java를 설치하고, Linux 사전 요구사항을 설정한 뒤 첫 번째 프로그램으로 설치를 확인합니다."
---
## **개요**

이 문서는 Aspose.Slides for Java를 프로젝트에 추가하는 방법을 설명합니다. Aspose.Slides for Java는 Aspose 자체 Maven 리포지터리에 게시되며 Maven Central에는 없습니다. 따라서 Maven 프로젝트는 해당 리포지터리를 선언해야 합니다. JAR 파일을 직접 다운로드하여 클래스 경로에 추가할 수도 있습니다. 두 방법 모두 라이브러리가 정상 작동함을 확인하는 간단한 프로그램으로 마무리됩니다.

Aspose.Slides for Java는 Microsoft PowerPoint가 필요하지 않습니다. 필요한 프레젠테이션 파일을 프로그래밍 방식으로 생성합니다. 그러나 생성된 프레젠테이션을 보려면 Microsoft PowerPoint 또는 다른 프레젠테이션 뷰어가 필요할 수 있습니다.

## **전제조건**

- Java Development Kit (JDK). 이 문서의 프로젝트와 명령은 JDK 11 이상이 필요합니다. JDK 11에서는 설치를 확인하는 프로그램이 "WARNING: An illegal reflective access operation has occurred"라는 경고를 출력하지만 결과에 영향을 주지 않으며 무시해도 됩니다.
- [Apache Maven](https://maven.apache.org/install.html), Maven 방식을 사용하는 경우.
- Linux에서는 fontconfig 라이브러리와 최소 하나 이상의 설치된 폰트가 필요합니다. 자세한 내용은 [Linux](#linux)을 참조하세요.

## **Maven 리포지터리에서 설치**

Aspose는 자체 [Maven 리포지터리](https://releases.aspose.com/java/repo/com/aspose/)에 Java 라이브러리를 호스팅합니다. Maven 프로젝트에서 [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)를 사용하려면 *pom.xml*에 두 항목을 추가합니다.

1. **Aspose Maven 리포지터리를 선언합니다.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Aspose.Slides for Java 의존성을 추가합니다.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

`jdk8` 클래시파이어가 필요합니다: 이는 라이브러리의 Java SE 빌드를 선택합니다. `26.10`을 최신 버전으로 교체하세요. 최신 버전은 [리포지터리](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)에 나와 있습니다. 리포지터리는 각 JAR 옆에 SHA-1 체크섬 파일을 제공하며, Maven은 다운로드 시 이를 확인합니다.

### **설치 확인**

새 프로젝트로 설정을 확인하려면:

1. 프로젝트 폴더를 만들고 이 *pom.xml*을 저장합니다:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.10</version>
               <classifier>jdk8</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   리포지터리와 의존성을 지정할 뿐만 아니라, Java 릴리스를 컴파일 대상으로 설정하고, `mvn exec:java`가 실행할 클래스를 지정하며, 오래된 플러그인이 기본적으로 무시하는 `maven.compiler.release` 설정을 적용하기 위해 컴파일러 플러그인을 고정합니다.

2. 첫 번째 예제를 [프레젠테이션 만들기](/slides/ko/java/create-presentation/)에서 *src/main/java/HelloSlides.java*로 저장합니다.

3. 프로젝트 폴더에서 실행합니다:

   ```bash
   mvn compile exec:java
   ```

Maven이 Aspose.Slides for Java를 다운로드하고 프로그램을 컴파일한 뒤 실행합니다. 프로그램은 프로젝트 폴더에 *new_presentation.pptx*를 저장합니다.

## **Maven 없이 JAR 파일 사용**

1. 리포지터리의 [버전 폴더](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/)에서 *aspose-slides-26.10-jdk8.jar*를 다운로드합니다. 다른 버전을 사용하려면 [리포지터리](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)의 해당 폴더를 열고 *-jdk8.jar*로 끝나는 파일을 다운로드하세요.

2. 첫 번째 예제를 [프레젠테이션 만들기](/slides/ko/java/create-presentation/)에서 *HelloSlides.java*로 저장하고, JAR 파일과 같은 폴더에 두세요.

3. 그 폴더에서 실행합니다:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK가 단일 소스 파일을 컴파일하고 실행하며, 프로그램은 해당 폴더에 *new_presentation.pptx*를 저장합니다. 자체 애플리케이션에서는 빌드 도구나 IDE에서 클래스 경로에 JAR 파일을 추가하세요.

## **Linux**

Aspose.Slides for Java는 Java의 폰트 지원을 사용하며, Linux에서는 fontconfig 라이브러리와 최소 하나 이상의 설치된 폰트가 필요합니다. 이가 없으면 프레젠테이션 저장 시 "Fontconfig head is null, check your fonts or fonts configuration" 오류가 발생합니다. 최소 서버 및 컨테이너 이미지에는 이 두 요소가 모두 없을 수 있으며, 예를 들어 공식 Ubuntu 컨테이너 이미지에는 전혀 포함되어 있지 않습니다.

Debian 및 Ubuntu에서는 다음 명령으로 JDK, Maven, fontconfig 및 DejaVu 폰트를 설치합니다:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

프레젠테이션에 사용되는 폰트 또는 적절한 대체 폰트도 텍스트가 올바르게 렌더링되도록 설치해야 합니다.

## **FAQ**

### Aspose.Slides가 올바르게 통합되었는지 어떻게 확인할 수 있나요?

프로젝트를 빌드하고 빈 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 객체를 생성한 뒤 새 이름으로 저장해 보세요. 예외 없이 파일이 생성되면 라이브러리가 성공적으로 통합된 것입니다.

### 큰 프레젠테이션을 처리할 때 메모리 사용량을 어떻게 제한할 수 있나요?

필요한 만큼만 JVM 메모리 제한을 높이고, `finally` 블록에서 각 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 인스턴스에 대해 [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) 를 호출해 캐시를 즉시 해제하세요. 이렇게 하면 메모리 부족 오류를 방지하고 배치 작업 중 전체 메모리 사용량을 예측 가능하게 유지할 수 있습니다.

### 최종 JAR 크기를 줄기 위해 원하지 않는 내보내기 형식을 제외할 수 있나요?

현재 Aspose.Slides 릴리스는 단일 모놀리식 라이브러리 형태로 제공되므로 빌드 시 PDF나 SVG와 같은 특정 내보내기 기능을 비활성화할 수 없습니다.
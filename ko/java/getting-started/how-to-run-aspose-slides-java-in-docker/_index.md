---
title: Docker에서 Aspose.Slides for Java 실행
linktitle: Docker
type: docs
weight: 150
url: /ko/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker 컨테이너
- 다단계 빌드
- 컨테이너 이미지
- Eclipse Temurin
- Maven
- 리눅스
- 우분투
- 알파인
- 데비안
- fontconfig
- 글꼴
- PDF 변환
- 파워포인트
- 프레젠테이션
- Java
- Aspose.Slides
description: "Docker에서 Aspose.Slides for Java 애플리케이션을 빌드하고 실행합니다: 공식 Maven 및 Eclipse Temurin 이미지에 대한 다단계 Dockerfile, Aspose.Slides가 필요로 하는 Linux 라이브러리 및 글꼴, 그리고 생성된 파일을 머신으로 복사하는 방법."
---
## **개요**

이 문서에서는 Docker 컨테이너에서 Aspose.Slides for Java을 실행하는 방법을 보여줍니다. 텍스트 상자가 있는 프레젠테이션을 만들고 PDF로 변환하는 작은 Maven 프로젝트를 빌드하고, 공식 Maven 및 Eclipse Temurin 이미지에서 다단계 Dockerfile로 패키징한 뒤 실행하고, 생성된 파일을 로컬 머신으로 복사합니다. 또한 이 문서에서는 Linux 이미지에서 Aspose.Slides가 Java 외에 필요로 하는 요소를 설명하고, Alpine Linux용 변형 및 배포판 패키지에서 Java를 설치하는 이미지에 대한 변형으로 마무리합니다.

머신에 Docker만 있으면 됩니다. JDK와 Maven은 빌드 이미지에 포함되어 있으므로 별도로 설치할 필요가 없습니다. Docker를 설치하려면 [Docker 받기](https://docs.docker.com/get-started/get-docker/)를 참고하세요.

## **기본 이미지 선택**

이 문서의 Dockerfile은 Docker Hub에서 제공하는 두 개의 공식 이미지를 사용합니다:

- `[maven](https://hub.docker.com/_/maven) `3.9-eclipse-temurin-21` 태그를 사용하여 애플리케이션을 빌드합니다. Apache Maven 3.9와 Eclipse Temurin JDK 21이 포함되어 있습니다.
- `[eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) `21-jre` 태그를 사용하여 실행합니다. Ubuntu 기반의 Eclipse Temurin Java 21 런타임을 포함하지만 JDK와 Maven은 포함되지 않습니다.

Aspose.Slides for Java는 Java의 글꼴 지원을 사용해 텍스트를 그리며, Linux에서는 fontconfig 및 FreeType 라이브러리와 최소 하나의 설치된 글꼴이 필요합니다. Eclipse Temurin 이미지에는 이미 fontconfig, FreeType 및 DejaVu 글꼴이 포함되어 있으므로 이 문서의 Dockerfile은 추가 패키지를 설치하지 않습니다. 글꼴이 전혀 없는 이미지에서는 프레젠테이션 저장 시 "Fontconfig head is null, check your fonts or fonts configuration" 오류가 발생합니다. 다른 기본 이미지로 빌드하려면 [다른 기본 이미지 사용](#use-another-base-image)을 참고하세요.

## **프로젝트 생성**

*hello-slides-docker* 라는 폴더를 만들고 아래 파일들을 추가합니다.

`*pom.xml*` 은 Aspose의 Maven 저장소와 Aspose.Slides for Java 종속성을 선언합니다. 자세한 내용은 [설치](/slides/ko/java/installation/)를 참고하세요. Aspose.Slides for Java는 Maven Central에 게시되지 않으므로 저장소 항목이 필요합니다. `finalName` 요소는 애플리케이션 JAR 파일을 *hello-slides.jar* 로 지정하고, [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) 은 Maven이 패키징할 때 애플리케이션의 종속성을 *target/lib* 로 복사합니다. Aspose.Slides 버전을 [저장소](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)에 나열된 최신 버전으로 설정하세요.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
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
            <version>26.9</version>
            <classifier>jdk16</classifier>
        </dependency>
    </dependencies>

    <build>
        <finalName>hello-slides</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

`*src/main/java/HelloSlides.java*` 은 [프레젠테이션](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/)을 생성하고, 첫 번째 슬라이드에 텍스트가 포함된 사각형을 추가한 후, [save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드로 프레젠테이션을 두 번 저장합니다: PPTX와 PDF 형식으로. 두 파일 모두 작업 디렉터리 아래 *output* 폴더에 저장됩니다. 프로그램은 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)을 사용해 렌더링 시 Aspose.Slides가 교체하는 글꼴을 나열하므로, 컨테이너에 프레젠테이션이 사용하는 글꼴이 있는지 확인할 수 있습니다.

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

*.dockerignore* 파일은 로컬 빌드의 *target* 폴더와 이전 실행 결과를 Docker 빌드 컨텍스트에서 제외하여 이미지가 소스 파일만으로 빌드되도록 합니다.

```text
target/
output/
```

## **Dockerfile 작성**

*hello-slides-docker* 폴더에 *Dockerfile*이라는 파일을 추가합니다:

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

파일은 두 단계로 구성됩니다:

- **빌드 단계**는 Maven 이미지에서 시작합니다. 먼저 *pom.xml*을 복사하고 `mvn dependency:go-offline`을 실행하여 Aspose.Slides for Java와 Maven 플러그인을 다운로드합니다. 따라서 *pom.xml*이 변경되지 않는 한 Docker는 해당 레이어를 재사용합니다. 이후 소스 코드를 복사하고 `mvn package`를 실행하여 프로그램을 *target/hello-slides.jar* 로 컴파일하고 Aspose.Slides JAR 파일을 *target/lib* 로 복사합니다. `-B` 옵션은 Maven을 비대화식(배치) 모드로 실행합니다.
- **런타임 단계**는 더 작은 Java 런타임 이미지에서 시작하고 애플리케이션 JAR 파일과 *lib* 폴더만 복사합니다. *output* 폴더를 만들고, Ubuntu 기반 이미지가 정의한 비루트 사용자 `ubuntu`에게 소유권을 부여한 뒤 해당 사용자로 애플리케이션을 실행합니다. 클래스 경로 `hello-slides.jar:lib/*`는 애플리케이션과 *lib*에 있는 모든 JAR 파일을 포함하며, Java가 `*` 를 자체적으로 확장합니다.

프로젝트는 Java 11(`maven.compiler.release` 속성)용으로 컴파일되므로 런타임 단계에서는 더 최신 Java 버전을 사용할 수 있습니다. 예를 들어 Java 25에서 애플리케이션을 실행하려면 런타임 단계 이미지명을 `eclipse-temurin:25-jre` 로 변경하면 됩니다.

## **컨테이너 빌드 및 실행**

*hello-slides-docker* 폴더에서 터미널을 열고 이미지를 빌드한 다음 컨테이너를 실행합니다:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

첫 빌드에서는 기본 이미지, Maven 플러그인 및 Aspose.Slides for Java를 다운로드하므로 몇 분이 걸릴 수 있습니다. 이후 빌드에서는 이를 재사용합니다. 컨테이너는 애플리케이션을 실행하고 종료합니다. 다음과 같이 출력됩니다:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

첫 번째 줄은 텍스트가 새 프레젠테이션의 기본 글꼴인 Calibri를 사용하고 있으며, 이미지에 Calibri가 설치되어 있지 않기 때문에 Aspose.Slides가 DejaVu Sans로 텍스트를 그렸음을 보여줍니다. PDF의 텍스트는 해당 글꼴을 사용한 실제 선택 가능한 텍스트입니다. 라이선스가 없으면 Aspose.Slides는 저장되는 모든 슬라이드에 평가용 워터마크를 추가합니다; 자세한 내용은 [라이선스](/slides/ko/java/licensing/)를 참고하세요.

## **출력 파일을 로컬 머신으로 복사**

파일은 중지된 컨테이너의 */app/output* 폴더에 있습니다. 이를 로컬 머신의 *output* 폴더로 복사한 뒤 컨테이너를 제거합니다:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

이 두 명령은 Bash, PowerShell 및 Windows 명령 프롬프트에서 동일하게 동작합니다.

Linux에서는 대신 머신의 폴더를 컨테이너에 마운트하여 애플리케이션이 파일을 직접 해당 폴더에 쓸 수 있습니다:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` 옵션은 현재 사용자와 그룹 ID로 애플리케이션을 실행하므로 생성한 폴더에 쓸 수 있고 파일의 소유권이 당신에게 부여됩니다. `--rm` 은 컨테이너가 종료될 때 자동으로 제거합니다.

## **Alpine Linux에서 실행**

Eclipse Temurin은 더 작고 Alpine Linux 기반 이미지로도 제공됩니다. 이 이미지에도 fontconfig, FreeType, DejaVu 글꼴이 포함되어 있어 애플리케이션에 추가 패키지가 필요하지 않습니다. 사용하려면 *Dockerfile*의 런타임 단계(두 번째 `FROM` 라인부터 전체)를 다음과 같이 교체합니다:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Alpine 이미지에는 `ubuntu` 사용자가 없으므로 이 단계에서는 `adduser` 로 `app` 사용자를 생성하고 해당 사용자로 애플리케이션을 실행합니다. 위와 동일한 명령으로 빌드, 실행 및 출력 복사를 수행합니다. 애플리케이션은 동일한 두 줄을 출력합니다.

## **다른 기본 이미지 사용**

이미지가 Linux 배포판 패키지로 Java를 설치하는 경우, Java의 글꼴 라이브러리와 함께 글꼴도 설치해야 합니다. Debian 및 Ubuntu에서는 `openjdk-21-jre-headless` 패키지가 fontconfig, FreeType, HarfBuzz를 권장 패키지만으로 나열하기 때문에 `apt-get install --no-install-recommends` 로는 이들을 설치하지 않으며, 이로 인해 애플리케이션이 `libfontmanager.so`에 대한 `UnsatisfiedLinkError` 로 중지됩니다. 다음 런타임 단계는 Debian 13에 Java 21, 해당 라이브러리 및 DejaVu 글꼴을 설치하고 `app`이라는 비루트 사용자를 생성합니다:

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

같은 단계는 `FROM ubuntu:26.04` 를 사용하면 Ubuntu 26.04에서도 동작합니다.

## **FAQ**

**"Fontconfig head is null, check your fonts or fonts configuration" 오류로 프레젠테이션 저장이 중지됩니다. 무엇이 누락되었나요?**

글꼴이 없습니다. Java의 글꼴 지원이 이미지에 설치된 글꼴을 찾지 못했습니다. Debian 및 Ubuntu에서는 `fonts-dejavu-core`와 같은 글꼴 패키지를 설치하세요. 자세한 내용은 [다른 기본 이미지 사용](#use-another-base-image)을 참고하십시오. [글꼴 배포](/slides/ko/java/deploy-fonts/) 에서는 다른 글꼴 패키지 목록을 제공합니다.

**애플리케이션이 libfontmanager.so에 대한 UnsatisfiedLinkError 로 중지됩니다. 무엇이 누락되었나요?**

Java 글꼴 지원을 위한 네이티브 라이브러리가 없습니다. 메시지는 로드할 수 없는 파일을 명시하며, 예를 들어 `libharfbuzz.so.0`이 있습니다. 이는 배포판 패키지에서 권장 패키지를 설치하지 않고 Java를 설치했을 때 발생합니다. [다른 기본 이미지 사용](#use-another-base-image)에서 언급된 라이브러리를 설치하세요.

**PDF의 텍스트가 PowerPoint와 다른 글꼴인 이유는 무엇인가요?**

프레젠테이션에 사용된 글꼴이 이미지에 설치되어 있지 않아 Aspose.Slides가 대체 글꼴로 텍스트를 그립니다. 애플리케이션 출력에는 교체된 각 글꼴이 표시됩니다. [글꼴 배포](/slides/ko/java/deploy-fonts/)에서는 이미지에 글꼴을 설치하거나 애플리케이션 폴더에서 로드하는 방법을 설명합니다.

**컨테이너에서 애플리케이션이 사용할 수 있는 메모리는 얼마입니까?**

기본적으로 Java는 컨테이너에 할당된 메모리의 1/4까지만 힙을 사용합니다. 예를 들어 `docker run -m 1g` 로 컨테이너를 시작하면 약 250 MB 정도가 할당됩니다. 큰 프레젠테이션을 처리하려면 `MaxRAMPercentage` 옵션으로 비율을 높일 수 있습니다. 예: `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. 이렇게 하면 Java가 애플리케이션 출력 전에 "Picked up JAVA_TOOL_OPTIONS" 라인을 출력합니다.

**내 머신에 JDK나 Maven이 필요합니까?**

필요 없습니다. 빌드 단계는 Maven 이미지 내부에서 애플리케이션을 컴파일합니다. Docker 외부에서 애플리케이션을 빌드하고 실행하려는 경우에만 JDK와 Maven이 필요합니다; 자세한 내용은 [설치](/slides/ko/java/installation/)를 참고하세요.
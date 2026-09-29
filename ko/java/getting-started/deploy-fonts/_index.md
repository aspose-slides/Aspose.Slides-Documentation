---
title: Linux 및 Docker에서 Aspose.Slides for Java용 글꼴 배포
linktitle: 글꼴 배포
type: docs
weight: 155
url: /ko/java/deploy-fonts/
keywords:
- 글꼴 배포
- 글꼴 설치
- Docker의 글꼴
- Linux의 글꼴
- 누락된 글꼴
- 글꼴 대체
- Microsoft 핵심 글꼴
- ttf-mscorefonts-installer
- 맞춤 글꼴
- 기본 글꼴
- 서버
- 컨테이너
- PDF 변환
- 프레젠테이션
- Java
- Aspose.Slides
description: "Linux 서버와 Docker 컨테이너에서 Aspose.Slides for Java용 글꼴을 배포합니다: 대체되는 글꼴을 확인하고, Debian, Ubuntu, Alpine에 글꼴 패키지를 설치하며, 자체 글꼴 파일을 추가하고, 기본 글꼴을 설정합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션을 렌더링할 때 사용 가능한 글꼴로 텍스트를 그립니다. 예를 들어 슬라이드를 PDF 또는 이미지로 변환할 때입니다. Windows 데스크톱에는 일반적으로 프레젠테이션에서 사용하는 글꼴이 있습니다. Linux 서버와 컨테이너에는 보통 글꼴이 거의 없으므로 Aspose.Slides는 대체 글꼴로 텍스트를 그립니다. 대체 글꼴은 문자 모양과 너비가 달라 줄 바꿈이 달라지거나 텍스트가 영역을 초과할 수 있으며, 대체 글꼴에 없는 문자는 올바르게 그려지지 않습니다. 글꼴이 전혀 설치되지 않은 경우 Java의 글꼴 지원이 시작되지 못하고 Aspose.Slides가 오류와 함께 중지됩니다.

이 문서는 Aspose.Slides가 어느 글꼴을 대체하는지 확인하는 방법, Debian, Ubuntu 및 Alpine Linux에 글꼴을 설치하는 방법, 자체 글꼴 파일을 추가하는 방법, 그리고 글꼴이 없을 때 사용될 글꼴을 설정하는 방법을 보여줍니다. 예제는 공식 Eclipse Temurin 이미지에서 Docker로 실행되며, [Run Aspose.Slides for Java in Docker](/slides/ko/java/how-to-run-aspose-slides-in-docker/)와 동일합니다. 패키지 명령은 Dockerfile 지시문이며, Linux 서버에서는 루트로 동일한 명령을 실행하면 됩니다.

글꼴 API 자체(프레젠테이션에 글꼴을 포함하고 대체 및 교체 규칙을 지정하는 등)에 대해서는 [PowerPoint Fonts](/slides/ko/java/powerpoint-fonts/)를 참조하세요.

## **대체되는 글꼴 확인하기**

다음 Maven 프로젝트는 현재 환경에서 Aspose.Slides가 대체하는 글꼴을 보고합니다. *font-check*라는 폴더를 만들고 아래 파일들을 그 안에 추가하세요.

*pom.xml*은 [Run Aspose.Slides for Java in Docker](/slides/ko/java/how-to-run-aspose-slides-in-docker/#create-the-project)에서 가져온 것이며, artifact ID와 JAR 파일 이름을 *font-check*로 변경했습니다:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
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
        <finalName>font-check</finalName>
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

*src/main/java/FontCheck.java*는 각 글꼴 이름마다 텍스트 상자를 하나씩 추가하고 [setLatinFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) 메서드로 글꼴을 지정합니다. 글꼴 이름은 명령줄 인수에서 가져오며, 인수가 없을 경우 Calibri, Arial, Times New Roman을 확인합니다. 프로그램은 Aspose.Slides가 글꼴을 찾는 폴더([FontsLoader.getFontFolders](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsloader/#getFontFolders--))를 출력하고, 슬라이드를 *output/fonts.pdf*에 렌더링한 뒤 [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)이 보고한 대체 정보를 출력합니다. 시작 부분의 두 선택적 단계인 *fonts* 폴더 로드와 `DEFAULT_FONT` 변수 읽기에 대해서는 아래에서 자세히 설명합니다.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // 확인할 글꼴: 명령줄 인수이거나 일반적인 Office 글꼴 세 개.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // 작업 디렉터리의 fonts 폴더에 있는 글꼴 파일을 로드합니다(존재하는 경우).
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // DEFAULT_FONT 환경 변수에 지정된 글꼴을 사용합니다(설정되어 있으면), 글꼴이 없는 텍스트에 적용됩니다.
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders`는 같은 폴더를 여러 번 반환할 수 있으므로 프로그램은 이를 집합에 모아 출력합니다.

*.dockerignore*는 로컬 빌드 결과를 빌드 컨텍스트에서 제외합니다:

```text
target/
output/
```

*Dockerfile*은 Maven 이미지를 사용해 프로그램을 빌드하고 Eclipse Temurin Java 런타임 이미지에서 실행합니다. 해당 이미지에는 이미 fontconfig와 DejaVu 글꼴이 포함되어 있습니다. [Run Aspose.Slides for Java in Docker](/slides/ko/java/how-to-run-aspose-slides-in-docker/)에서 각 지시문을 설명합니다.

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

이미지를 빌드하고 체크를 실행합니다:

```bash
docker build -t font-check .
docker run --rm font-check
```

이미지에는 DejaVu 글꼴만 포함되어 있으므로 세 글꼴 모두 DejaVu Sans로 교체됩니다:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

자신의 프레젠테이션 글꼴을 확인하려면 예를 들어 `docker run --rm font-check "Segoe UI" Consolas`와 같이 이름을 인수로 전달합니다. *output/fonts.pdf*를 컨테이너 밖으로 복사하려면 [Copy the Output to Your Machine](/slides/ko/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine)에서 제공하는 명령을 사용하세요.

## **Debian 및 Ubuntu에 글꼴 설치하기**

### **Microsoft Core Fonts**

`ttf-mscorefonts-installer` 패키지는 웹용 Microsoft 기본 글꼴을 다운로드하고 설치합니다. 여기에는 Arial, Times New Roman, Courier New, Verdana, Georgia, Trebuchet MS 등이 포함됩니다. 이 글꼴들은 Microsoft 최종 사용자 사용권 계약(EULA)에 따라 라이선스가 부여되며, 패키지는 EULA에 동의한 후에만 설치합니다. Docker 빌드에서는 프롬프트에 응답할 수 없으므로 설치 프로그램이 EULA를 거부하고 글꼴을 설치하지 않으며, `apt-get install`은 여전히 성공으로 보고됩니다. 패키지를 설치하기 **전** `debconf-set-selections`로 EULA에 동의해야 합니다. 이후 단계에서 동의하도록 하면 도움이 되지 않습니다. 그때는 이미 패키지가 설치된 상태이기 때문입니다.

이 지시문을 *Dockerfile*의 `FROM` 라인 직후, 런타임 단계에 추가하여 루트 사용자로 실행되도록 하고 `USER` 지시문 전에 배치합니다:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

이미지를 다시 빌드하고 동일한 두 명령으로 체크를 실행하면 Arial과 Times New Roman이 이제 설치됩니다:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Aspose.Slides가 생성하는 프레젠테이션의 기본 글꼴인 Calibri는 기본 글꼴에 포함되지 않으므로 여전히 대체됩니다. [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts)를 참고하세요.

Ubuntu 기반 Eclipse Temurin 이미지에서는 해당 패키지를 포함하는 `multiverse` 구성 요소가 활성화되어 있습니다. Debian에서는 해당 패키지가 `contrib` 구성 요소에 포함되어 있는데, Debian 이미지에서는 기본적으로 활성화되지 않습니다. Debian 기반 런타임 단계(예: [Use Another Base Image](/slides/ko/java/how-to-run-aspose-slides-in-docker/#use-another-base-image))에서는 동일한 지시문에서 `contrib`를 활성화합니다:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **기타 글꼴 패키지**

Debian 및 Ubuntu에는 자유 라이선스 글꼴도 패키지로 제공됩니다. 예:

| 패키지 | 글꼴 |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, Mono(Arial, Times New Roman, Courier New과 동일한 메트릭) |
| `fonts-crosextra-carlito` | Carlito(Calibri와 동일한 메트릭) |
| `fonts-crosextra-caladea` | Caladea(Cambria와 동일한 메트릭) |

런타임 단계의 `RUN` 지시문에서 `apt-get install`으로 설치하면 Microsoft core fonts와 같은 방식으로 작동합니다. Aspose.Slides for Java는 Linux 글꼴 구성의 별칭을 적용하지 않습니다. `fonts-liberation`을 설치해도 Arial 텍스트는 여전히 일반 대체 글꼴로 그려지며 Liberation Sans가 사용되지 않습니다. 누락된 글꼴 대신 메트릭이 일치하는 글꼴을 사용하려면 [default font](#set-a-default-font-for-missing-fonts)를 설정하거나 [font substitution rule](/slides/ko/java/font-substitution/)을 추가하세요.

## **직접 글꼴 파일 추가하기**

배포판에 포함되지 않은 글꼴(예: 조직 자체 글꼴 또는 서버에서 사용 허가를 받은 기타 글꼴)은 글꼴 파일로 추가할 수 있습니다. 예를 들어 *.ttf* 파일을 *font-check* 폴더 안에 *fonts*라는 폴더에 넣습니다. 아래 예시는 Calibri와 동일한 메트릭을 가진 Carlito 글꼴 파일을 사용하며, 이는 [Google Fonts](https://fonts.google.com/specimen/Carlito)에서 다운로드할 수 있습니다.

### **시스템 글꼴 폴더에 설치하기**

Aspose.Slides는 `Font folders` 라인에 출력된 폴더에서 글꼴을 읽습니다. 이미지 안의 모든 애플리케이션이 사용할 수 있도록 하려면 글꼴을 */usr/local/share/fonts*에 복사합니다. 이 지시문을 *Dockerfile*의 런타임 단계에, Microsoft core fonts를 설치하는 `RUN` 지시문 뒤에 추가합니다:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

이미지를 다시 빌드한 뒤 Calibri와 Carlito를 확인합니다:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito가 더 이상 대체되지 않습니다:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **애플리케이션 폴더에서 로드하기**

시스템 폴더에 설치하는 대신 애플리케이션과 함께 배포하고 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)으로 로드할 수 있습니다. 이렇게 하면 Aspose.Slides에서만 글꼴을 사용할 수 있으며 애플리케이션과 함께 배포됩니다. *FontCheck*가 바로 이 방식을 사용합니다. 컨테이너 내부 작업 디렉터리인 */app*에 *fonts* 폴더가 있으면 프로그램은 프레젠테이션을 만들기 전에 해당 폴더를 `loadExternalFonts`에 전달합니다. [Custom Font](/slides/ko/java/custom-font/)에서 메모리 로드 등 다른 방법도 설명합니다.

*Dockerfile*에서 `COPY fonts/ /usr/local/share/fonts/` 지시문을 제거하고, *lib* 폴더를 복사하는 지시문 뒤에 다음을 추가합니다:

```dockerfile
COPY fonts/ ./fonts/
```

이미지를 다시 빌드하고 동일한 두 명령으로 체크를 실행합니다. 이제 애플리케이션 폴더가 글꼴 폴더 목록에 나타나며 Carlito는 여전히 대체되지 않습니다:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts`는 설치된 글꼴에 추가하지만, Java 글꼴 지원은 최소 하나의 설치된 글꼴이 필요합니다. 글꼴이 전혀 없는 이미지에서는 `loadExternalFonts`가 "Fontconfig head is null, check your fonts or fonts configuration" 오류와 함께 중지됩니다.

## **누락된 글꼴에 대한 기본 글꼴 설정하기**

글꼴이 없을 경우 Aspose.Slides는 자체적으로 선택한 대체 글꼴을 사용합니다. 직접 지정하려면 [LoadOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/)의 [setDefaultRegularFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) 메서드에 글꼴 이름을 넘겨주고, 해당 옵션을 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 생성자에 전달합니다. *FontCheck*는 `DEFAULT_FONT` 환경 변수에서 글꼴 이름을 읽습니다. Carlito를 로드한 상태에서 누락된 글꼴에 사용할 기본 글꼴로 지정합니다:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

이제 Calibri가 Carlito로 그려지며, 문자 너비가 동일해 텍스트 줄 바꿈이 유지됩니다:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

기본 글꼴은 모든 누락된 글꼴을 대체합니다. 개별 글꼴을 매핑하려면 예를 들어 Arial를 Liberation Sans로, Calibri를 Carlito로 매핑하는 [font substitution rules](/slides/ko/java/font-substitution/)을 사용하세요. 규칙은 렌더링 결과를 바꾸지만 `getSubstitutions`에는 반영되지 않으므로 출력 파일에서 실제 글꼴을 확인해야 합니다. 아시아어 텍스트의 경우에도 [setDefaultAsianFont](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-)를 호출합니다. 자세한 내용은 [Default Font](/slides/ko/java/default-font/)를 참고하세요.

## **Alpine Linux에 글꼴 설치하기**

Alpine 기반 Eclipse Temurin 이미지에도 DejaVu 글꼴이 포함되어 있습니다. [Run on Alpine Linux](/slides/ko/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux)에서 런타임 단계가 설명됩니다. Microsoft core fonts를 Alpine에도 설치하려면 *font-check* Dockerfile의 런타임 단계를 아래와 같이 교체합니다:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts`는 Debian 및 Ubuntu 패키지와 동일한 Microsoft core fonts를 다운로드하고 설치하며, EULA 적용 방식도 동일합니다. `fc-cache`는 fontconfig의 글꼴 캐시를 업데이트합니다. 이미지를 빌드하고 [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted)에서 두 명령으로 체크를 실행하면 다음과 같이 출력됩니다:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Alpine에서도 다른 단계는 동일하게 작동합니다. *fonts* 폴더를 */usr/local/share/fonts* 또는 애플리케이션 폴더에 복사하고 `DEFAULT_FONT`를 설정하면 됩니다. Alpine 이미지에는 */usr/local/share/fonts* 폴더가 기본적으로 없으므로 `COPY` 지시문으로 폴더를 만든 이후에 `Font folders` 라인에 나타납니다.

## **FAQ**

**서버에서 변환하면 프레젠테이션이 다르게 보이는 이유는?**

서버에 프레젠테이션에서 사용하는 글꼴이 없기 때문에 Aspose.Slides가 글꼴 너비가 다른 대체 글꼴로 텍스트를 그립니다. *FontCheck*를 프레젠테이션의 글꼴 이름으로 실행하여 어떤 글꼴이 대체되는지 확인한 뒤 해당 글꼴을 설치하거나 애플리케이션 폴더에서 로드하세요.

**빌드에서 ttf-mscorefonts-installer를 설치했지만 Arial이 여전히 대체됩니다. 이유가?**

패키지를 설치하기 전에 EULA에 동의하지 않아 설치 프로그램이 글꼴을 건너뛰었습니다. [Microsoft Core Fonts](#microsoft-core-fonts) 섹션에 표시된 대로 `debconf-set-selections` 명령을 `apt-get install` 앞에 넣고 이미지를 다시 빌드하세요.

**PDF를 여는 컴퓨터에 글꼴이 필요합니까?**

필요하지 않습니다. 이 예제에서는 텍스트를 그리는 데 사용된 글꼴이 PDF에 포함되어 있으므로 어느 컴퓨터에서 열어도 동일하게 보입니다. 글꼴은 Aspose.Slides가 프레젠테이션을 렌더링할 때만 필요합니다.
---
title: 시스템 요구 사항
type: docs
weight: 60
url: /ko/java/system-requirements/
keywords:
- 시스템 요구사항
- 지원 플랫폼
- Java 버전
- JDK
- JRE
- fontconfig
- 폰트
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 설치하기 전에 필요한 사항을 확인하십시오: 지원되는 Java 버전 및 운영 체제, 그리고 Linux에 필요한 폰트 라이브러리와 폰트입니다."
---
## **소개**

Aspose.Slides for Java은 독립형 라이브러리이며 Microsoft PowerPoint나 Microsoft Office가 필요하지 않습니다. Aspose의 Maven 리포지토리에 게시된 단일 JAR 파일입니다. JAR 파일에는 Java 클래스와 리소스만 포함되어 있으며 네이티브 라이브러리가 없고 다른 라이브러리에 대한 종속성을 선언하지 않습니다. 따라서 지원되는 Java 런타임이 있는 모든 운영 체제와 프로세서에서 동일한 파일을 실행할 수 있습니다.

이 문서는 지원되는 Java 버전 및 운영 체제, Linux에 필요한 폰트 라이브러리와 폰트를 나열하고, 설정을 확인하는 짧은 프로그램을 소개합니다. 라이브러리를 프로젝트에 추가하려면 [설치](/slides/ko/java/installation/)를 참조하세요.

## **지원되는 Java 버전**

Aspose.Slides for Java는 JDK 또는 JRE와 함께 Java 8 이상에서 실행됩니다. 여기에는 장기 지원(LTS) 버전인 Java 8, 11, 17, 21, 25와 Java 26, Java 27과 같은 최신 릴리스가 포함됩니다. Java 런타임은 Eclipse Temurin, Amazon Corretto, Oracle, Linux 배포판의 OpenJDK 패키지 등 어떤 공급업체든 사용할 수 있습니다.

Aspose.Slides는 이러한 버전에서 `--add-opens`와 같은 JVM 옵션이 전혀 필요하지 않습니다. Java 11에서는 JVM이 “WARNING: An illegal reflective access operation has occurred”라는 경고를 출력하지만, 결과에 영향을 주지는 않습니다.

{{% alert color="warning" title="Warning" %}}
Java 6 및 Java 7은 더 이상 권장되지 않습니다. Aspose.Slides for Java 26.9는 여전히 실행되지만 폐기 경고를 출력합니다. 버전 26.10부터는 최소 Java 8이 필요하며, Java 6 및 Java 7은 지원되지 않습니다.
{{% /alert %}}

[설치](/slides/ko/java/installation/)에 있는 Maven 프로젝트와 명령은 JDK 11 이상이 필요합니다. Java 8을 사용한다면 [설정 확인](#check-your-setup) 섹션에 설명된 대로 프로그램을 컴파일하고 실행하면 됩니다.

## **지원되는 운영 체제**

JAR 파일에 네이티브 코드가 포함되지 않으므로 Aspose.Slides for Java는 Windows, Linux, macOS에서 Java 런타임이 지원하는 모든 프로세서 아키텍처(x64, ARM64 등)에서 실행됩니다. Windows에서는 Java 런타임만 있으면 됩니다. Linux에서는 [Linux](#linux)에서 설명한 폰트 라이브러리와 폰트가 추가로 필요합니다.

## **Linux**

Aspose.Slides for Java는 Java 런타임의 폰트 지원을 사용해 텍스트를 레이아웃하고 그립니다. Linux에서는 이 지원을 위해 `fontconfig` 라이브러리와 최소 하나의 설치된 폰트가 필요합니다. 공식 컨테이너 이미지에는 이들이 포함되지 않은 경우가 많아 첫 번째 예제([프레젠테이션 만들기](/slides/ko/java/create-presentation/))가 발표를 저장할 때 빈 파일을 만들고 다음 오류를 보고합니다:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

공식 `eclipse-temurin` 컨테이너 이미지(Ubuntu 및 Alpine Linux)는 이미 `fontconfig`와 DejaVu 폰트를 포함하고 있어 별도로 설치할 필요가 없습니다. 다른 시스템에서는 아래 패키지를 설치하십시오. Debian, Ubuntu, Red Hat 명령은 `sudo`를 사용합니다; Dockerfile에서는 `sudo` 없이 `RUN` 명령으로 실행합니다. DejaVu 폰트만 있으면 Aspose.Slides가 실행됩니다; 프레젠테이션에 사용되는 폰트는 [글꼴](#fonts)에서 다룹니다.

### **Debian 및 Ubuntu**

[설치](/slides/ko/java/installation/#linux)에서 보여주는 기본 `apt-get` 설정으로 Debian 또는 Ubuntu 패키지에서 Java를 설치하면, Java 패키지가 `fontconfig` 라이브러리, DejaVu 폰트, 그리고 이들 Java 패키지가 필요로 하는 HarfBuzz 라이브러리까지 자동으로 설치되며 추가 작업이 필요하지 않습니다.

다른 출처(Eclipse Temurin 아카이브 등)에서 Java 런타임을 사용한다면 `fontconfig`와 DejaVu 폰트를 설치합니다:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile에서 `openjdk-21-jdk-headless` 또는 `default-jdk-headless`와 같이 `--no-install-recommends` 옵션을 사용하면 위 세 항목이 모두 생략됩니다. 위 명령으로 `fontconfig`와 DejaVu 폰트를 설치하고, HarfBuzz도 함께 설치합니다:

```bash
sudo apt-get install -y libharfbuzz0b
```

HarfBuzz가 없으면 해당 Java 패키지는 `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` 메시지를 출력하고, `libharfbuzz.so.0`을 열 수 없다는 `UnsatisfiedLinkError`와 함께 저장에 실패합니다.

### **Red Hat Enterprise Linux**

Red Hat Enterprise Linux의 `java-<version>-openjdk-headless` 패키지는 `fontconfig` 라이브러리를 설치하지 않습니다. `fontconfig`와 DejaVu 폰트를 함께 설치하십시오:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

전체 `java-<version>-openjdk` 패키지는 의존성으로 `fontconfig`와 폰트를 설치합니다. Amazon Linux 2023의 `java-21-amazon-corretto-headless`와 같은 Amazon Corretto 패키지도 마찬가지입니다.

### **Alpine Linux**

Alpine Linux 기반 Dockerfile에서는 `fontconfig`와 DejaVu 폰트를 설치합니다:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

현재 Alpine 릴리스에서는 `ttf-dejavu`가 `font-dejavu` 패키지를 설치합니다. `openjdk<version>-jre` 또는 `openjdk<version>-jdk`(예: `openjdk25-jdk`) 패키지로 Java를 설치하십시오. Alpine Linux의 `openjdk<version>-jre-headless` 패키지는 Java 폰트 라이브러리를 포함하지 않으므로, 이 패키지만 사용하면 폰트가 설치돼 있어도 `UnsatisfiedLinkError: no fontmanager in system library path` 오류가 발생합니다.

### **글꼴**

텍스트가 올바른 폰트와 메트릭으로 렌더링되려면 프레젠테이션이 사용하는 폰트 또는 적절한 대체 폰트가 시스템에 설치되거나 애플리케이션에서 로드되어야 합니다. 자세한 내용은 [글꼴 배포](/slides/ko/java/deploy-fonts/), [글꼴 대체](/slides/ko/java/font-substitution/), [사용자 정의 글꼴](/slides/ko/java/custom-font/)를 참조하십시오.

## **설정 확인**

라이브러리와 필요 사항이 올바르게 설치되었는지 확인하려면 발표를 저장하고 슬라이드를 이미지로 렌더링하는 프로그램을 실행합니다. 저장 및 렌더링은 Java 런타임의 폰트 지원을 사용하며, 이는 위 Linux 요구 사항이 제공하는 내용과 동일합니다.

아래 코드를 *CheckSetup.java* 파일로 저장하고 Aspose.Slides JAR 파일이 있는 폴더에 둡니다. JAR 파일 다운로드 방법은 [Maven 없이 JAR 파일 사용](/slides/ko/java/installation/#use-the-jar-file-without-maven)을 참고하세요.

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // 첫 번째 슬라이드에 텍스트가 포함된 사각형을 추가하고 프레젠테이션을 저장합니다.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // 슬라이드를 포인트당 한 픽셀로 렌더링하고 이미지를 저장합니다.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

JDK 11 이상을 사용한다면 다음 명령으로 프로그램을 실행합니다. JAR 파일 이름이 다르면 명령에서도 이름을 변경하십시오.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Java 8이거나 JRE만 있는 시스템에서는 JDK에서 `javac`로 컴파일한 뒤 실행합니다. Linux 및 macOS에서는 다음과 같이 실행합니다:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Windows에서는 동일한 `javac` 명령을 실행한 뒤, 클래스 경로 구분자를 세미콜론으로 사용합니다. PowerShell이 세미콜론을 명령 끝으로 인식하지 않도록 따옴표를 유지하십시오: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

프로그램은 첫 번째 슬라이드에 텍스트가 포함된 사각형을 추가하고 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드로 *hello.pptx* 파일에 저장합니다. 이어서 [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) 로 슬라이드를 렌더링하고, [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 로 *hello.png* 파일을 [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) 형식으로 저장합니다. 확대 비율 1은 포인트당 한 픽셀을 렌더링하므로 기본 720 × 540 포인트 슬라이드가 720 × 540 픽셀 이미지가 되며, 텍스트가 사각형 안에 표시됩니다. 라이선스가 없을 경우 두 파일 모두 평가 워터마크가 포함됩니다; 자세한 내용은 [라이선스](/slides/ko/java/licensing/)를 확인하십시오. 필요 요구 사항이 누락되면 [Linux](#linux)에서 설명한 오류 중 하나가 발생하고 프로그램이 중단됩니다.

## **개발 도구**

지원되는 Java 버전의 JDK를 사용하면 Aspose.Slides를 사용하는 애플리케이션을 자유롭게 빌드할 수 있습니다. [설치](/slides/ko/java/installation/)에 설명된 대로 Aspose의 Maven 리포지토리를 활용하거나 Maven 리포지토리를 사용할 수 있는 다른 빌드 도구를 사용하십시오. 또한 JAR 파일을 IDE 또는 빌드 도구의 클래스 경로에 직접 추가할 수도 있습니다.

## **FAQ**

**변환 및 렌더링을 위해 Microsoft PowerPoint를 설치해야 하나요?**

아니요, PowerPoint는 필요하지 않습니다. Aspose.Slides는 [프레젠테이션 만들기](/slides/ko/java/create-presentation/), 수정, [변환](/slides/ko/java/convert-presentation/), [렌더링](/slides/ko/java/convert-powerpoint-to-png/)을 위한 독립 엔진입니다.

**Linux 서버에서 Aspose.Slides for Java가 화면이나 데스크톱 환경이 필요합니까?**

아니요. Aspose.Slides는 X 서버나 디스플레이가 필요 없으므로 서버 및 컨테이너에서 실행됩니다. Linux에서는 [Linux](#linux)에서 설명한 폰트 라이브러리와 폰트만 있으면 됩니다.

**올바른 렌더링을 위해 어떤 폰트가 필요합니까?**

프레젠테이션에 사용된 폰트 또는 적절한 [대체](/slides/ko/java/font-substitution/) 폰트가 시스템에 있어야 합니다. Linux 및 macOS에서는 일관된 렌더링을 위해 프레젠테이션에 필요한 폰트 패키지를 설치하십시오.

**Linux에서 사용자 정의 폰트가 대체 폰트나 누락된 텍스트로 표시되는 이유는 무엇입니까?**

폰트 파일에 이름 테이블 레코드가 일관되지 않거나 손상된 경우, Linux의 폰트 매칭 스택(FreeType/fontconfig)이 잘못된 레코드를 선택해 폰트를 해석하지 못할 수 있습니다. 이름 테이블 레코드가 수정된 폰트 버전을 사용하거나 일관된 교체 폰트를 설치하면 문제가 해결됩니다.
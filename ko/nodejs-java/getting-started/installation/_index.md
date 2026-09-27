---
title: 설치
type: docs
weight: 70
url: /ko/nodejs-java/installation/
keywords:
- Aspose.Slides 설치
- Aspose.Slides 다운로드
- Aspose.Slides 사용
- Aspose.Slides 설치
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Windows, Linux 및 macOS에서 npm을 통해 Java로 Aspose.Slides for Node.js를 설치합니다: 필요한 JDK, Python 및 C++ 빌드 도구, npm 명령, 그리고 설치를 확인하는 첫 번째 스크립트."
---
## **개요**

이 문서는 Windows, Linux 및 macOS에서 Java를 통해 Aspose.Slides for Node.js를 설치하는 방법과 설치가 작동하는지 확인하는 방법을 설명합니다.

Java를 통해 Aspose.Slides for Node.js는 npm에서 `aspose.slides.via.java` 패키지로 배포됩니다. npm이 설치 중에 컴퓨터에서 컴파일하는 네이티브 Node.js 애드온인 [`java`](https://github.com/joeferner/node-java) 패키지를 통해 Java 가상 머신에서 Aspose.Slides를 실행합니다. 따라서 Node.js 외에 설치에 다음이 필요합니다:

- **Java Development Kit (JDK) 8 이상**. Java 런타임만으로는 충분하지 않으며, 빌드에는 JDK의 헤더 파일이 필요합니다.
- **Python 3**, 빌드 도구 [node-gyp](https://github.com/nodejs/node-gyp)에서 사용합니다.
- **운영 체제에 맞는 C++ 빌드 도구 체인**.

## **사전 요구 사항 설치**

### **Windows**

1. [Node.js](https://nodejs.org/en/download) 20 이상을 설치합니다.
2. 예를 들어 [Eclipse Temurin](https://adoptium.net/)과 같은 JDK를 설치하고, `JAVA_HOME` 환경 변수를 해당 설치 폴더로 설정합니다. 빌드는 `JAVA_HOME`이 가리키는 JDK를 사용합니다.
3. [Python 3](https://www.python.org/downloads/)을 설치합니다.
4. [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe)를 **Desktop development with C++** 작업 부하와 함께 설치합니다. 작업 부하의 기본 구성 요소(예: **MSVC v143 - VS 2022 C++ x64/x86 build tools**와 **Windows 11 SDK**)를 유지합니다. Visual Studio 2026은 작동하지 않으며, `java` 패키지가 컴파일하는 node-gyp 버전이 이를 인식하지 못합니다.

### **Linux**

Node.js 20 이상을 [nodejs.org](https://nodejs.org/en/download) 또는 배포판의 패키지 소스에서 설치합니다. 그런 다음 JDK, Python 3 및 C++ 빌드 도구를 설치합니다. Debian 및 Ubuntu에서는:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Linux에서는 빌드가 추가 설정 없이 설치된 JDK를 찾습니다. 여러 JDK가 설치된 경우, 사용하려는 JDK로 `JAVA_HOME`을 설정합니다.

### **macOS**

Node.js 20 이상, JDK 및 Python 3와 C++ 컴파일러를 포함하는 Xcode Command Line Tools를 설치합니다. macOS에 특화된 참고 사항은 [Troubleshooting Installation](/slides/ko/nodejs-java/troubleshooting-installation/)를 참조하십시오.

## **npm에서 설치**

프로젝트 폴더를 만들고 패키지를 설치합니다:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm은 Aspose.Slides를 다운로드하고 `java` 브리지를 컴파일합니다. 이 과정은 몇 분 정도 걸릴 수 있습니다. 컴파일이 실패하면 [Troubleshooting Installation](/slides/ko/nodejs-java/troubleshooting-installation/)를 참고하십시오.

## **설치 확인**

프로젝트 폴더에 *hello.js* 파일을 생성하고 다음 코드를 넣습니다. 이 코드는 프레젠테이션을 만들고, 첫 번째 슬라이드에 텍스트 상자를 추가한 뒤 결과를 *hello.pptx* 로 저장합니다:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides는 Node.js가 계속 실행되도록 하는 Java 가상 머신에서 실행되므로, 프로세스를 명시적으로 종료합니다.
process.exit(0);
```

스크립트를 실행합니다:

```bash
node hello.js
```

*hello.pptx* 파일이 프로젝트 폴더에 생성되면 설치가 정상적으로 작동한 것입니다. Aspose.Slides를 실행하는 Java 가상 머신이 Node.js가 자동으로 종료되지 않게 유지하므로 스크립트는 `process.exit(0)`으로 끝납니다. 코드에 대한 자세한 설명은 [Create Presentations](/slides/ko/nodejs-java/create-presentation/)를 참조하십시오.

## **ZIP 아카이브에서 설치**

패키지는 npm 패키지와 동일한 내용을 가진 ZIP 아카이브 형태로도 제공됩니다. 아카이브에서 설치하려면:

1. 위에 설명된 대로 운영 체제에 맞는 사전 요구 사항을 설치합니다.
2. [Aspose.Slides for Node.js via Java 다운로드 페이지](https://releases.aspose.com/slides/ko/nodejs-java/)에서 아카이브를 다운로드합니다.
3. 프로젝트 폴더를 만듭니다:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. 아카이브를 프로젝트 폴더 안에 *aspose.slides.via.java* 라는 하위 폴더로 압축 해제합니다. 이렇게 하면 아카이브의 *package.json* 파일이 *hello-slides/aspose.slides.via.java/package.json* 위치에 있게 됩니다.
5. 해당 폴더에서 패키지를 설치합니다:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm은 패키지가 의존하는 `java` 브리지를 설치하고 컴파일합니다. 이는 npm 패키지를 설치할 때와 동일한 방식입니다.

6. [설치 확인](#check-the-installation)에서 설명한 대로 설치를 확인합니다.

## **FAQ**

**무료 버전이나 평가 제한이 있나요?**

예. 라이선스가 없으면 Aspose.Slides는 평가 모드로 실행됩니다. 저장하는 모든 슬라이드에 평가용 워터마크가 추가되고 프레젠테이션에서 읽은 텍스트가 잘립니다. 이러한 제한을 해제하려면 유효한 [license](/slides/ko/nodejs-java/licensing/)를 적용하십시오.

**스크립트가 완료된 후 종료되지 않는 이유는 무엇인가요?**

`java` 패키지는 Node.js 프로세스 내부에서 Java 가상 머신을 시작하고, 이 가상 머신이 프로세스가 계속 실행되도록 유지합니다. 스크립트 작업이 끝났을 때 `process.exit`를 호출하십시오.
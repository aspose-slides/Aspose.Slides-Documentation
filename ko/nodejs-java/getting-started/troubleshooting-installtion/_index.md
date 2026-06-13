---
title: Aspose.Slides for Node.js via Java 설치 문제 해결
linktitle: 설치 문제 해결
type: docs
weight: 75
url: /ko/nodejs-java/troubleshooting-installation/
keywords:
- Aspose.Slides 다운로드
- Aspose.Slides 설치
- 설치 문제 해결
- 버전 요구 사항
- 윈도우
- macOS
- 리눅스
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java 설치 문제를 해결하고 일반적인 오류와 종속성을 수정하여 PPT, PPTX 및 ODP와 원활하게 작업할 수 있도록 합니다."
---
## **소개**

npm을 사용하여 `aspose.slides.via.java`를 [설치](/slides/ko/nodejs-java/installation/)할 때, `java`와 `node-gyp` 모듈의 컴파일 중 오류가 발생하는 경우가 있습니다. 우리는 이러한 오류를 더 자세히 조사하고 설치된 프로그램 및 패키지 버전에 대한 구체적인 요구 사항을 확인했습니다.

## **버전 요구 사항**

1. Node.js 12 및 이전 버전의 경우:
   - Python은 3.10 이하이어야 합니다.
   - Windows의 경우 2017년 이전 버전의 Visual Studio Build Tools를 설치하는 것이 권장됩니다.
   - npm java 패키지 버전: 0.12.1.

2. Node.js 13:
   - Node.js 12와 동일한 요구 사항.

3. Node.js 14:
   - Python 3.10.
   - npm java 패키지 버전: 0.14.0.

4. Node.js 15:
   - Python 3.12.
   - npm java 패키지 버전: 0.14.0.

5. Node.js 16 및 이후 버전:
   - Python 3.12.
   - npm java 패키지 버전: 0.14.0.

**아래 지침에 따라 필요한 프로그램을 설치하십시오.**

### **Unix 설치**

- [Node.js](https://nodejs.org/en/download) 설치.
- [Python](https://devguide.python.org/versions/) 설치.
- Java (JDK 1.8) 설치.
- [GCC](https://gcc.gnu.org)와 같은 적절한 C/C++ 컴파일러 툴체인 설치.

### **macOS 설치**

- [Node.js](https://nodejs.org/en/download) 설치.
- [Python](https://devguide.python.org/versions/) 설치.
- Java (JDK 1.8)를 설치하고 루트 권한으로 /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist의 JVMCapabilities 섹션을 수정합니다. jdk1.8.x_xxx.jdk는 jdk 버전에 따라 다릅니다. 다음과 같이 보이게 하십시오: 
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
- `xcode-select --install`을 실행하여 `Xcode Command Line Tools`를 독립적으로 설치합니다. -- OR -- 또는 이미 [전체 Xcode가 설치된](https://developer.apple.com/xcode/download/) 경우, 메뉴 `Xcode -> Open Developer Tool -> More Developer Tools...`에서 Command Line Tools를 설치할 수 있습니다.

### **Windows 설치**

- [Node.js](https://nodejs.org/en/download) 설치.
- [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation)에서 [Python](https://devguide.python.org/versions/)을 설치합니다.
- Java (JDK 1.8) 설치.
- [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools)를 설치합니다 (VS2019 이전 버전을 사용하는 경우 "Visual C++ build tools"를, 그렇지 않으면 "Desktop development with C++" 워크로드 또는 "Desktop development with C++" 워크로드가 포함된 [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community)를 사용합니다).

Node.js, Python 및 Java가 PATH 변수에 추가되었는지 확인하십시오.

## **Node.js 버전 14 이상에서 Java를 통한 Aspose.Slides for Node.js 설치**

다음 명령을 사용하십시오:
```
npm i aspose.slides.via.java
```

## **Node.js 버전 12 또는 13에서 Java를 통한 Aspose.Slides for Node.js 설치**

Aspose.Slides for Node.js via Java는 수동으로 설치해야 합니다. 다음 명령을 사용하십시오:

- Node.js 12용:
```
npm i java@0.12.1
```
- Node.js 13용:
```
npm i java@0.13.0
```

그 후, [aspose.slides.via.java](https://releases.aspose.com/slides/ko/nodejs-java/)를 다운로드하고 `node_modules/aspose.slides.via.java` 폴더에 압축을 풉니다.

## **설치 검증**

프로젝트 루트에 `index.js` 파일을 생성하고 다음 내용을 넣습니다:

```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

다음 명령 `node index.js`로 이 파일을 실행하십시오.

## **추가 정보**

이 문서 범위 내에서 모든 가능한 문제를 다루기는 어렵습니다. `java`와 `node-gyp` 모듈의 컴파일 때문에 발생하는 문제이므로 다음 링크도 도움이 될 것입니다:
- [java installation](https://www.npmjs.com/package/java#installation)
- [node-gyp installation](https://www.npmjs.com/package/node-gyp#installation)
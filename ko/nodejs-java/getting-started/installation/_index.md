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
description: "Aspose.Slides를 빠르게 설치하는 방법을 배웁니다. 단계별 가이드, 시스템 요구 사항 및 코드 샘플 — 오늘 바로 PowerPoint 프레젠테이션 작업을 시작하세요!"
---
## **소개**

Aspose.Slides for Node.js via Java는 플랫폼에 독립적인 API이며 `Node.js`와 [`java`](https://www.npmjs.com/package/java) 브리지가 설치된 모든 플랫폼(Windows, Linux 및 MacOS)에서 사용할 수 있습니다.

## **NPM에서 설치**

Aspose.Slides for Node.js via Java를 [NPM](https://www.npmjs.com/)에서 쉽게 설치할 수 있습니다.

1. 새 폴더를 만들고 다음 명령을 사용하여 새 프로젝트를 초기화합니다:
	```
	$ npm init
	```
2. 제목과 버전 필드를 입력합니다(나머지 필드는 기본값으로 둡니다).
3. 다음 명령을 사용하여 Aspose.Slides for Node.js via Java를 설치합니다:
	```
	$ npm install aspose.slides.via.java
	```

설치 과정에서 문제가 발생하면 이 [문서](/slides/ko/nodejs-java/troubleshooting-installation/)를 참조하십시오.

**사용 예제**:

`hello.js` 파일을 프로젝트 폴더에 생성하고 다음 샘플 코드를 추가합니다:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **ZIP 아카이브에서 설치**

ZIP 아카이브에서 Aspose.Slides for Node.js via Java를 설치하고 사용하려면 아래 지침을 따르세요:

### **Windows**

1. JDK8을 설치하고 `JAVA_HOME` 환경 변수를 설정합니다.
2. Node.js(https://nodejs.org/en/download/)를 설치하고 node.exe를 `PATH`에 추가합니다.
3. node-gyp를 설치합니다.
4. Windows Build Tools를 설치합니다.
5. [`java`](https://www.npmjs.com/package/java) 브리지를 설치하고 관리자 권한으로 명령 프롬프트에서 다음 명령을 실행합니다:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Aspose.Slides for Node.js via Java 다운로드](https://releases.aspose.com/slides/ko/nodejs-java/)하고 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`에 압축을 풉니다.
7. `aspose.slides.nodejs` 폴더에 `hello.js` 파일을 만들고 다음 샘플 코드를 사용합니다:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. 이제 명령 프롬프트에서 `node hello.js`를 실행합니다.

### **Linux**

1. Node.js(https://nodejs.org/en/download/)를 설치합니다.
2. Linux용 JDK8을 설치하고 `JAVA_HOME` 환경 변수를 설정합니다.
3. python 2.x를 설치합니다.
4. [`java`](https://www.npmjs.com/package/java) 브리지를 설치합니다. 터미널에서 다음 명령을 실행할 수 있습니다:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Aspose.Slides for Node.js via Java 다운로드](https://releases.aspose.com/slides/ko/nodejs-java/)하고 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`에 압축을 풉니다.
6. `aspose.slides.nodejs` 폴더에 이 샘플 코드를 사용하여 `hello.js` 테스트 파일을 생성합니다:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. 이제 명령 프롬프트에서 `node hello.js`를 실행합니다.

### **Mac**

1. Node.js(https://nodejs.org/en/download/)를 설치합니다.
2. Mac용 JDK8을 설치하고 `JAVA_HOME` 환경 변수를 설정합니다.
3. 루트 권한으로 `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` 파일의 JVMCapabilities 섹션을 수정합니다. `jdk1.8.x_xxx.jdk`는 사용 중인 JDK 버전에 따라 다릅니다. 아래와 같이 보이게 합니다:
	```xml
	<key>JavaVM</key>
		<dict>
			<key>JVMCapabilities</key>
			<array>
					<string>JNI</string>
					<string>BundledApp</string>
					<string>CommandLine</string>
			</array>
	```
4. python 2.x를 설치합니다(설치되지 않은 경우).
5. Xcode Command Line Tools를 설치합니다.
6. [`java`](https://www.npmjs.com/package/java) 브리지를 설치합니다. 터미널에서 아래 명령을 실행할 수 있습니다:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Aspose.Slides for Node.js via Java를 다운로드하고 `aspose.slides.nodejs/node_modules/aspose.slides.via.java`에 압축을 풉니다.
8. `aspose.slides.nodejs` 폴더에 이 샘플 코드를 사용하여 `hello.js` 테스트 파일을 생성합니다:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. 이제 명령 프롬프트에서 `node hello.js`를 실행합니다.

{{% alert color="primary" %}}
Aspose.Slides for Node.js via Java 설치 중 컴파일 오류가 발생하면 다음 [문서](https://docs.aspose.com/slides/ko/nodejs-java/troubleshooting-installation/)를 사용하십시오.
{{% /alert %}}

## **FAQ**

**무료 버전이나 체험 제한이 있나요?**

네, 기본적으로 Aspose.Slides는 평가 모드로 실행되며 워터마크가 삽입되고 다른 제한이 있을 수 있습니다. 제한을 해제하려면 유효한 [라이선스](/slides/ko/nodejs-java/licensing/)를 적용해야 합니다.
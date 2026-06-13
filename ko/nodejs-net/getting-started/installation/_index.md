---
title: 설치
type: docs
weight: 70
url: /ko/nodejs-net/installation/
keywords:
- Aspose.Slides 다운로드
- Aspose.Slides 설치
- Aspose.Slides 설치
- Windows
- macOS
- 리눅스
- JavaScript
- Node.js
description: "Windows, Linux 또는 macOS에서 .NET을 통해 Node.js용 Aspose.Slides를 설치합니다"
---
Aspose.Slides for Node.js via .NET은 플랫폼에 독립적인 API이며 `Node.js`와 `edge-js` 브리지가 설치된 모든 플랫폼(Windows, Linux 및 MacOS)에서 사용할 수 있습니다.

## **NPM에서 설치**

[NPM](https://www.npmjs.com/)에서 다음 명령을 사용하여 Aspose.Slides for Node.js via .NET을 쉽게 설치할 수 있습니다:
```
$ npm install aspose.slides.via.net
```
설치 과정에서 문제가 발생하면 https://www.npmjs.com/package/edge-js 를 참고하십시오.

## **ZIP 아카이브에서 설치**

ZIP 아카이브에서 Aspose.Slides for Node.js via .NET을 설치하고 사용하려면 다음 지침을 따르세요.

### **Windows**

1. .NET 6 이상을 설치합니다.  
1. Node.js(https://nodejs.org/en/download/)를 설치하고 `node.exe`를 `PATH`에 추가합니다.  
1. edge-js를 설치합니다.  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Aspose.Slides for Node.js via .NET 다운로드](https://releases.aspose.com/slides/ko/nodejs-net/) 후 `aspose.slides.nodejs/node_modules/aspose.slides.via.net`에 압축을 푼다.  
7. 다음 샘플 코드를 사용하여 `aspose.slides.nodejs.net` 폴더에 `hello.js` 파일을 생성합니다:

```javascript
// PowerPoint 파일 조작을 위한 Aspose.Slides 모듈을 가져옵니다
const asposeSlides = require('aspose.slides.via.net');

// asposeSlides에서 필요한 클래스를 추가합니다
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// 새 빈 프레젠테이션을 초기화합니다
function createEmptyPresentation() {
	
    // 빈 프레젠테이션을 PPTX 형식으로 저장합니다
    var emptyPresentation = new Presentation();
    
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // 프레젠테이션과 연결된 리소스를 해제합니다
    emptyPresentation.dispose();
}

createEmptyPresentation(); // 빈 프레젠테이션을 생성하는 함수를 실행합니다
```

8. 이제 명령 프롬프트에서 `node hello.js`를 실행합니다.

### **Linux**

1. .NET 6 이상을 설치합니다.  
1. Node.js(https://nodejs.org/en/download/)를 설치하고 `node.exe`를 `PATH`에 추가합니다.  
1. edge-js를 설치합니다.  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Aspose.Slides for Node.js via Java 다운로드](https://releases.aspose.com/slides/ko/nodejs-net/) 후 `aspose.slides.nodejs/node_modules/aspose.slides.via.net`에 압축을 푼다.  
6. `aspose.slides.nodejs.net` 폴더에 다음 샘플 코드를 사용하여 `hello.js` 테스트 파일을 생성합니다:

```javascript
// PowerPoint 파일 조작을 위한 Aspose.Slides 모듈 가져오기
const asposeSlides = require('aspose.slides.via.net');

// asposeSlides에서 필요한 클래스 추가
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// 기본 기능을 보여주기 위해 빈 프레젠테이션을 생성하고 저장
function createEmptyPresentation() {
	
    // 새 빈 프레젠테이션 초기화
    var emptyPresentation = new Presentation();
    
    // 빈 프레젠테이션을 PPTX 형식으로 저장
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // 프레젠테이션과 연결된 리소스 해제
    emptyPresentation.dispose();
}

createEmptyPresentation(); // 빈 프레젠테이션을 생성하는 함수를 실행
```
7. 이제 명령 프롬프트에서 `node hello.js`를 실행합니다.

### **Mac**

1. .NET 6 이상을 설치합니다.  
1. Node.js(https://nodejs.org/en/download/)를 설치하고 `node.exe`를 `PATH`에 추가합니다.  
1. edge-js를 설치합니다.

$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```

```javascript
// PowerPoint 파일 조작을 위한 Aspose.Slides 모듈 가져오기
const asposeSlides = require('aspose.slides.via.net');

// asposeSlides에서 필요한 클래스 가져오기
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// 기본 기능을 보여주기 위해 빈 프레젠테이션을 생성하고 저장하는 함수
function createEmptyPresentation() {
    
    // 새 빈 프레젠테이션 초기화
    var emptyPresentation = new Presentation();
    
    // 빈 프레젠테이션을 PPTX 형식으로 저장
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // 프레젠테이션과 연결된 리소스 해제
    emptyPresentation.dispose();
}

createEmptyPresentation(); // 빈 프레젠테이션을 생성하는 함수 실행
9. 이제 명령 프롬프트에서 `node hello.js`를 실행합니다.
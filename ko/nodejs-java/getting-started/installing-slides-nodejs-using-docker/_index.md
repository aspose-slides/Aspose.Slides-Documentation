---
title: Docker를 사용하여 Java를 통해 Node.js용 Aspose.Slides 설치
type: docs
weight: 75
url: /ko/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- Aspose.Slides 다운로드
- Aspose.Slides 설치
- Aspose.Slides 설치
- Docker
- Windows
- macOS
- Linux
- 크로스 플랫폼 호환성
- 의존성 격리
- 간소화된 배포
- 프로젝트 설정
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Docker 컨테이너에서 Aspose.Slides를 실행합니다: 이미지, 의존성, 글꼴 및 라이선스를 구성하여 PowerPoint 및 OpenDocument를 처리하는 확장 가능한 서비스를 구축합니다."
---
## 전제 조건:
* 머신에 Docker를 설치하십시오. 공식 설치 가이드를 [here](https://docs.docker.com/get-docker/)에서 확인할 수 있습니다.

## 단계:

### 1. **Dockerfile 만들기** 
   프로젝트 디렉터리에 Dockerfile이라는 새 파일을 생성하고 다음 내용을 넣으십시오:
   ``` 
   # Ubuntu 20.04를 기본 이미지로 사용합니다
   FROM ubuntu:20.04

   # 패키지 목록을 업데이트하고 저장소 추가 및 파일 다운로드에 필요한 필수 패키지를 설치합니다
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Nodesource 저장소에서 Node.js 버전 18.x를 설치합니다
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # node-gyp와 같은 일부 npm 패키지에 필요한 Python 2.x를 설치합니다
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Aspose.Slides의 Java 종속성에 필요한 OpenJDK 11을 설치합니다
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # 네이티브 모듈 빌드에 필요한 'make'와 같은 도구를 포함하는 build-essential 패키지를 설치합니다
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Node.js용 네이티브 애드온을 컴파일하는 데 사용되는 도구인 node-gyp를 전역으로 설치합니다
   RUN npm install -g node-gyp

   # 컨테이너 내부 작업 디렉터리를 /app으로 설정합니다
   WORKDIR /app

   # 필요한 세부 정보와 종속성을 포함한 package.json 파일을 생성합니다
   RUN echo '{\n\
     "name": "aspose-slides-app",\n\
     "version": "1.0.0",\n\
     "main": "index.js",\n\
     "scripts": {\n\
      "start": "node index.js"\n\
     },\n\
     "dependencies": {\n\
      "aspose.slides.via.java": "^25.12.0"\n\
     }\n\
   }' > package.json

   # Aspose.Slides를 사용하여 프레젠테이션을 생성하는 샘플 코드를 포함한 index.js 파일을 생성합니다
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # package.json에 지정된 Aspose.Slides via Java 패키지를 설치합니다
   RUN npm install aspose.slides.via.java

   # 컨테이너 시작 시 애플리케이션을 실행하도록 기본 명령을 설정합니다
   CMD ["node", "index.js"]
```

### 2. **Docker 이미지 빌드**
   Dockerfile이 있는 디렉터리에서 다음 명령을 실행하여 Docker 이미지를 빌드하십시오:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Docker 컨테이너 실행**
   컨테이너를 실행하고 ID를 저장하십시오:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Docker에서 Aspose.Slides에 액세스** 
   컨테이너를 시작한 후 스크립트가 PPTX 파일을 생성합니다. 생성된 출력 파일 `NewPresentation.pptx`는 컨테이너 내부의 `/app` 폴더에서 찾을 수 있습니다:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   임시 컨테이너를 제거하십시오:
   ```bash
   docker rm $CONTAINER_ID
   ```
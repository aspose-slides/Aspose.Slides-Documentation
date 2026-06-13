---
title: 제한 사항 및 API 차이점
type: docs
weight: 100
url: /ko/nodejs-java/limitations-and-api-differences/
keywords:
- 제한
- API 차이점
- 라이브러리 가져오기
- 패키지 비교
- 파일 스트리밍
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java와 Aspose.Slides for Java 간의 제한 사항 및 API 차이점을 비교합니다."
---
## **공개 API 차이점**
다음 목록(샘플 코드 세그먼트 포함)은 Aspose.Slides for Java와 Aspose.Slides for Node.js via Java API 간의 몇 가지 차이점을 보여줍니다.

### **라이브러리 가져오기 (패키지 비교)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **새 프레젠테이션 인스턴스화**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **파일 및 상수 스트리밍**

**Aspose.Slides for Java**

```javascript
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var fs = require("fs");
var readStream = fs.createReadStream("presentation.pptx");
aspose.slides.Presentation.createPresentationFromStream(readStream, function(err, pres) {
   if (err) {
      console.log("open Presentation error");
      return;
   }
   pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
   console.log('saved to file');
});
```

### **Aspose.Slides for Java API와 비교한 Aspose.Slides for Node.js via Java API의 기타 제한 사항**
1. Array, ArrayList, ResultSet 등에서 데이터 가져오기/내보내기는 지원되지 않습니다.
1. 인쇄는 지원되지 않습니다.
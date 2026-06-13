---
title: TypeScript 지원
type: docs
weight: 65
url: /ko/nodejs-java/typescript-support/
keywords:
- 타입스크립트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js와 함께 TypeScript를 사용하여 프레젠테이션 관리를 간소화하십시오. 새로운 기능과 예제를 탐색하여 개발 효율성을 향상시킵니다."
---
## **소개**

우리는 [Aspose.Slides for Node.js via Java](https://www.npmjs.com/package/aspose.slides.via.java) 에 대한 **네이티브 TypeScript 지원**을 발표하게 되어 매우 기쁩니다! 이 주요 개선으로 Node.js에서 PowerPoint 자동화에 현대적인 개발 워크플로우를 제공합니다.

## **주요 이점**

- **전체 API 검색 가능성**: 모든 메서드에 대한 지능형 코드 완성을 제공합니다
- **형식 안전성**: 컴파일 시 오류를 포착합니다
- **제로 설정**: 포함된 `.d.ts` 정의와 함께 바로 사용할 수 있습니다
- **Java 동등성**: Java 패키지의 모든 공개 메서드가 적절히 타입 지정됩니다

## **기술 구현**

타입 정의는 `package.json`을 통해 자동으로 로드됩니다:
```json
"types": "lib/aspose.slides.d.ts"
```

## **개발자 경험**

### **이전 (일반 JavaScript)**
```javascript
import * as AsposeSlides from 'aspose.slides.via.java';

// 자동 완성 및 타입 검사가 없습니다
const pres = new AsposeSlides.??? // 맹목적으로 진행
```

### **이후 (TypeScript)**
```typescript
import * as AsposeSlides from 'aspose.slides.via.java';

const pres = new AsposeSlides.Presentation(); // 전체 자동 완성
const slide = pres.getSlides().get_Item(0); // 올바른 메서드 시그니처
```

![TypeScript 자동 완성 데모](typedemo.png)  


## **시작하기**

1. 최신 버전으로 업데이트합니다:
```bash
npm install aspose.slides.via.java@latest
```

2. TypeScript를 사용하는 경우, 추가 구성은 필요하지 않습니다!
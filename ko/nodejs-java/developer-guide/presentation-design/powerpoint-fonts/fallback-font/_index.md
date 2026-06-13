---
title: JavaScript에서 프레젠테이션용 대체 글꼴 관리
linktitle: 대체 글꼴
type: docs
weight: 50
url: /ko/nodejs-java/fallback-font/
keywords:
- 대체 글꼴
- 사용 가능한 글꼴
- 글리프 교체
- 글꼴 지정
- 규칙 지정
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js가 원본 글꼴을 사용할 수 없을 때 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 가독성을 유지하기 위해 대체 글꼴을 사용하는 방법을 확인하십시오."
---
## **소개**

대체 글꼴은 텍스트에 지정된 글꼴이 시스템에 존재하지만 필요한 글리프를 포함하고 있지 않을 때 사용됩니다. 이 경우 Aspose.Slides는 지정된 대체 글꼴 중 하나를 사용하여 누락된 글리프를 교체할 수 있습니다.

## **대체 글꼴**

Aspose.Slides는 대체 글꼴을 생성하고, 이를 대체 글꼴 컬렉션에 추가하며, 특정 프레젠테이션에 대해 대체 글꼴 컬렉션을 설정하고, 프레젠테이션에서 대체 글꼴을 제거하며, 대체 글꼴을 적용할 규칙 등을 지정할 수 있도록 지원합니다.

이 기능에 익숙해지려면 다음 링크를 사용하십시오:

- [대체 글꼴 만들기](/slides/ko/nodejs-java/create-fallback-font)
- [대체 글꼴 컬렉션 만들기](/slides/ko/nodejs-java/create-fallback-fonts-collection)
- [대체 글꼴을 사용한 프레젠테이션 렌더링](/slides/ko/nodejs-java/render-presentation-with-fallback-font)

## **FAQ**

**대체 글꼴은 글꼴 대체와 어떻게 다릅니까?**

대체 글꼴은 기본 글꼴에 특정 글리프가 없을 때 문자별 또는 유니코드 범위별로 적용되어 누락된 문자만 채웁니다. [대체](/slides/ko/nodejs-java/font-substitution/)은 전체 실행 또는 텍스트 구간에 대해 누락되었거나 사용할 수 없는 글꼴을 다른 글꼴로 교체합니다. 두 기능을 함께 사용할 수 있지만 적용 범위와 선택 로직은 다릅니다.

**대체 설정이 프레젠테이션 파일에 저장되나요?**

아니요. 대체 설정은 라이브러리의 처리/렌더링 시점에 존재하며 PPTX 파일에 직렬화되지 않습니다. 프레젠테이션은 대체 규칙을 저장하지 않습니다.

**대체 글꼴이 PowerPoint 개체(SmartArt, 차트, WordArt)로 만든 요소에 영향을 줍니까?**

예. 이러한 개체 내부의 텍스트도 동일한 렌더링 파이프라인을 거치므로 일반 텍스트와 동일한 대체 규칙이 적용됩니다.
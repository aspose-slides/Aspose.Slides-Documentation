---
title: Python을 사용하여 Java를 통해 프레젠테이션용 대체 폰트 관리
linktitle: 대체 폰트
type: docs
weight: 50
url: /ko/python-java/fallback-font/
keywords:
- 대체 폰트
- 사용 가능한 폰트
- 글리프 교체
- 폰트 지정
- 규칙 지정
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "원래 폰트를 사용할 수 없을 때 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 가독성을 유지하기 위해 Aspose.Slides for Python via Java가 대체 폰트를 어떻게 사용하는지 확인하십시오."
---
## **소개**

텍스트에 지정된 폰트가 시스템에 존재하지만 필요한 글리프를 포함하고 있지 않을 때 대체 폰트가 사용됩니다. 이 경우 Aspose.Slides는 지정된 대체 폰트 중 하나를 사용하여 누락된 글리프를 대체할 수 있습니다.

## **대체 폰트**

Aspose.Slides는 대체 폰트를 생성하고, 이를 대체 폰트 컬렉션에 추가하며, 특정 프레젠테이션에 대체 폰트 컬렉션을 설정하고, 프레젠테이션에서 대체 폰트를 제거하며, 대체 폰트를 적용하는 규칙을 지정하고, 기타 관련 작업을 수행할 수 있게 합니다.

이 기능들을 익히려면 다음 링크를 사용하십시오:

- [대체 폰트 만들기](/slides/ko/python-java/create-fallback-font/)
- [대체 폰트 컬렉션 만들기](/slides/ko/python-java/create-fallback-fonts-collection/)
- [대체 폰트를 사용한 프레젠테이션 렌더링](/slides/ko/python-java/render-presentation-with-fallback-font/)

## **FAQ**

**대체 폰트와 폰트 대체는 어떻게 다릅니까?**

대체는 기본 폰트에 특정 글리프가 없을 때 문자별 또는 유니코드 범위별로 적용되어 누락된 문자만 채웁니다. [Substitution](/slides/ko/python-java/font-substitution/)은 전체 실행이나 텍스트 영역 전체에 대해 누락되었거나 사용할 수 없는 폰트를 다른 폰트로 교체합니다. 두 방법을 함께 사용할 수 있지만 적용 범위와 선택 논리는 서로 다릅니다.

**대체 설정이 프레젠테이션 파일에 저장되나요?**

아니요. 대체 구성은 라이브러리의 처리/렌더링 시점에 존재하며 PPTX 파일에 직렬화되지 않습니다. 프레젠테이션은 대체 규칙을 저장하지 않습니다.

**대체가 PowerPoint 개체(스마트아트, 차트, 워드아트)로 만든 요소에 영향을 줍니까?**

예. 이러한 개체 내부의 텍스트도 동일한 렌더링 파이프라인을 거치므로 일반 텍스트와 동일한 대체 규칙이 적용됩니다.
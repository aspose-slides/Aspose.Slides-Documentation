---
title: Android에서 프레젠테이션용 폴백 폰트 관리
linktitle: 폴백 폰트
type: docs
weight: 50
url: /ko/androidjava/fallback-font/
keywords:
- 폴백 폰트
- 사용 가능한 폰트
- 글리프 대체
- 폰트 지정
- 규칙 지정
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java가 원본 폰트를 사용할 수 없을 때 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 읽을 수 있도록 폴백 폰트를 사용하는 방법을 확인하십시오."
---
## **소개**

텍스트에 지정된 글꼴이 시스템에 존재하지만 해당 글꼴에 필요한 글리프가 없을 경우 폴백 폰트를 사용합니다. 이 경우 지정된 폴백 폰트 중 하나를 사용하여 글리프를 대체할 수 있습니다.

## **폴백 폰트**

Aspose.Slides는 폴백 폰트를 생성하고, 이를 폴백 폰트 컬렉션에 추가하며, 특정 프레젠테이션에 폴백 폰트 컬렉션을 설정하고, 프레젠테이션에서 폴백 폰트를 제거하고, 폴백 폰트를 적용할 규칙 등을 지정할 수 있습니다.

이러한 기능에 익숙해지려면 다음 링크를 사용하십시오:

- [폴백 폰트 만들기](/slides/ko/androidjava/create-fallback-font)
- [폴백 폰트 컬렉션 만들기](/slides/ko/androidjava/create-fallback-fonts-collection)
- [폴백 폰트를 사용한 프레젠테이션 렌더링](/slides/ko/androidjava/render-presentation-with-fallback-font)

## **FAQ**

**폴백 폰트와 글꼴 대체는 어떻게 다릅니까?**

기본 글꼴에 특정 글리프가 없을 때 폴백은 문자별 또는 유니코드 범위별로 적용되어 누락된 문자만 채웁니다. [대체](/slides/ko/androidjava/font-substitution/)은 누락되었거나 사용할 수 없는 글꼴을 전체 실행이나 텍스트 구간 전체에 다른 글꼴로 교체합니다. 두 기능을 함께 사용할 수 있지만 적용 범위와 선택 로직이 다릅니다.

**폴백 설정이 프레젠테이션 파일에 저장됩니까?**

아니요. 폴백 구성은 라이브러리에서 처리/렌더링 시점에 존재하며 PPTX 파일에 직렬화되지 않습니다. 프레젠테이션은 폴백 규칙을 저장하지 않습니다.

**폴백이 PowerPoint 객체(스마트아트, 차트, 워드아트)로 만든 요소에 영향을 줍니까?**

예. 이러한 객체 내부의 텍스트도 동일한 렌더링 파이프라인을 거치므로 일반 텍스트와 동일한 폴백 규칙이 적용됩니다.
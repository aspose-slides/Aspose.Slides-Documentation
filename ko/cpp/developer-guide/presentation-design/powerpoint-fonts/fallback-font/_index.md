---
title: C++에서 프레젠테이션용 폴백 글꼴 관리
linktitle: 폴백 글꼴
type: docs
weight: 50
url: /ko/cpp/fallback-font/
keywords:
- 폴백 글꼴
- 사용 가능한 글꼴
- 글리프 교체
- 글꼴 지정
- 규칙 지정
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++가 원본 글꼴을 사용할 수 없을 때 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 가독성을 유지하기 위해 폴백 글꼴을 어떻게 사용하는지 확인하세요."
---
## **Introduction**

Fallback fonts는 텍스트에 지정된 글꼴이 시스템에 존재하지만 필요한 글리프가 없을 때 사용됩니다. 이 경우 Aspose.Slides는 지정된 폴백 글꼴 중 하나를 사용하여 누락된 글리프를 대체할 수 있습니다.

## **Fallback Font**
Fallback font는 텍스트에 지정된 글꼴이 시스템에 존재하지만 해당 글꼴에 필요한 글리프가 없을 때 사용됩니다. 이 경우 지정된 폴백 글꼴 중 하나를 사용하여 글리프를 교체할 수 있습니다.

Aspose.Slides는 폴백 글꼴을 생성하고, 이를 폴백 글꼴 컬렉션에 추가하며, 특정 프레젠테이션에 폴백 글꼴 컬렉션을 설정하고, 프레젠테이션에서 폴백 글꼴을 제거하고, 폴백 글꼴을 적용할 규칙을 지정하는 등의 기능을 제공합니다.

이 기능들을 익히려면 다음 링크를 이용하십시오:

- [폴백 글꼴 만들기](/slides/ko/cpp/create-fallback-font)
- [폴백 글꼴 컬렉션 만들기](/slides/ko/cpp/create-fallback-fonts-collection)
- [폴백 글꼴을 사용한 프레젠테이션 렌더링](/slides/ko/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Fallback fonts와 font substitution은 어떻게 다릅니까?**

Fallback은 기본 글꼴에 특정 글리프가 없을 때 문자 단위 혹은 유니코드 범위별로 적용되어 누락된 문자만 채웁니다. [Substitution](/slides/ko/cpp/font-substitution/)은 전체 실행(run)이나 텍스트 구간에서 누락되었거나 사용할 수 없는 글꼴을 다른 글꼴로 교체합니다. 두 기능을 함께 사용할 수 있지만 적용 범위와 선택 로직이 다릅니다.

**Fallback 설정이 프레젠테이션 파일에 저장됩니까?**

아니요. 폴백 구성은 라이브러리에서 처리/렌더링 시점에만 존재하며 PPTX 파일에 직렬화되지 않습니다. 프레젠테이션 파일 자체에 폴백 규칙이 저장되지 않습니다.

**Fallback이 PowerPoint 객체(SmartArt, 차트, WordArt)로 만든 요소에 영향을 줍니까?**

예. 이러한 객체 안의 텍스트도 동일한 렌더링 파이프라인을 거치므로 일반 텍스트와 동일한 폴백 규칙이 적용됩니다.
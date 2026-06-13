---
title: C++에서 그룹 프레젠테이션 도형
linktitle: 도형 그룹
type: docs
weight: 40
url: /ko/cpp/group/
keywords:
- 그룹 도형
- 도형 그룹
- 그룹 추가
- 대체 텍스트
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 도형을 그룹화하고 그룹 해제하는 방법을 배우세요 — 빠르고 단계별 가이드와 무료 C++ 코드 제공."
---
## **Overview**

이 문서는 Aspose.Slides에서 그룹 도형을 사용하는 방법을 설명합니다. 그룹 도형을 슬라이드에 추가하고, 그 안에 도형을 배치하고, 업데이트된 프레젠테이션을 저장하는 방법을 보여줍니다. 또한 그룹에 저장된 도형에 접근하여 `AlternativeText` 값을 읽는 방법을 시연합니다. 추가로 중첩 그룹, Z-순서, 잠금 옵션 등 관련된 그룹 도형 기능에 대해 간략히 다룹니다.

## **Add a Group Shape**

Aspose.Slides는 슬라이드에서 그룹 도형을 작업하는 것을 지원합니다. 이 기능을 통해 개발자는 더 풍부한 프레젠테이션을 구현할 수 있습니다. Aspose.Slides for C++는 그룹 도형을 추가하거나 액세스하는 것을 지원합니다. 추가된 그룹 도형에 도형을 추가하여 채우거나 그룹 도형의 속성에 접근할 수 있습니다. Aspose.Slides for C++를 사용하여 슬라이드에 그룹 도형을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스로 생성합니다.
2. 슬라이드의 인덱스를 사용하여 해당 슬라이드의 참조를 얻습니다.
3. 슬라이드에 그룹 도형을 추가합니다.
4. 추가된 그룹 도형에 도형들을 추가합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 슬라이드에 그룹 도형을 추가합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Access the AltText Property**

이 항목에서는 그룹 도형을 추가하고 슬라이드에서 그룹 도형의 AltText 속성에 접근하는 간단한 단계와 코드 예제를 제공합니다. Aspose.Slides for C++를 사용하여 슬라이드의 그룹 도형에서 AltText에 접근하려면:

1. PPTX 파일을 나타내는 `Presentation` 클래스를 인스턴스화합니다.
2. 슬라이드의 인덱스를 사용하여 해당 슬라이드의 참조를 얻습니다.
3. 슬라이드의 도형 컬렉션에 접근합니다.
4. 그룹 도형에 접근합니다.
5. AltText 속성에 접근합니다.

아래 예제는 그룹 도형의 대체 텍스트에 접근합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**중첩 그룹화(그룹 안에 그룹)가 지원됩니까?**

예. [GroupShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/groupshape/)에는 계층 구조 지원을 직접 나타내는 [get_ParentGroup](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/get_parentgroup/) 메서드가 있어 그룹이 다른 그룹의 자식이 될 수 있습니다.

**그룹의 Z-순서를 슬라이드의 다른 객체에 대해 어떻게 제어합니까?**

[GroupShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/groupshape/)의 [Z-Order position](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/get_zorderposition/)을 사용하여 디스플레이 스택에서의 위치를 확인합니다.

**이동/편집/그룹 해제를 방지할 수 있습니까?**

예. 그룹의 잠금 섹션은 [get_GroupShapeLock](https://reference.aspose.com/slides/ko/cpp/aspose.slides/groupshape/get_groupshapelock/)을 통해 노출되며, 이를 통해 객체에 대한 작업을 제한할 수 있습니다.
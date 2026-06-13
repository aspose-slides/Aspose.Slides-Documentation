---
title: C++에서 프레젠테이션에 선 모양 추가
linktitle: 선
type: docs
weight: 50
url: /ko/cpp/line/
keywords:
- 선
- 선 만들기
- 선 추가
- 일반 선
- 선 구성
- 선 맞춤 설정
- 대시 스타일
- 화살촉
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 선 서식을 조작하는 방법을 배우세요. 속성, 메서드 및 예제를 확인하십시오."
---
## **개요**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 슬라이드에 선 모양을 추가할 수 있습니다. 이 문서에서는 간단한 선을 만드는 방법과 선을 화살표처럼 보이도록 사용자 지정하는 방법을 보여줍니다.

슬라이드에 선 모양을 추가하고, 시각적 모습을 조정하며, 업데이트된 프레젠테이션을 저장하는 방법을 배웁니다. 예제에서는 스타일, 너비, 대시 패턴, 화살촉 옵션 및 채우기 색상과 같은 실용적인 선 서식 설정에 중점을 둡니다.

## **일반 선 만들기**

프레젠테이션의 선택된 슬라이드에 단순한 일반 선을 추가하려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.([Presentation class](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/))
- 슬라이드의 인덱스를 사용하여 슬라이드 참조를 얻습니다.
- Shapes 객체가 제공하는 [AddAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addautoshape/) 메서드를 사용하여 Line 유형의 AutoShape를 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 선을 추가했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **화살표 모양 선 만들기**

Aspose.Slides for C++에서도 개발자가 선의 일부 속성을 구성하여 더 매력적으로 보이게 할 수 있습니다. 선을 화살표처럼 보이게 하기 위해 몇 가지 속성을 구성해 보겠습니다. 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.([Presentation class](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/))
- 슬라이드의 인덱스를 사용하여 슬라이드 참조를 얻습니다.
- Shapes 객체가 제공하는 AddAutoShape 메서드를 사용하여 Line 유형의 AutoShape를 추가합니다.
- Aspose.Slides for C++에서 제공하는 스타일 중 하나로 Line Style을 설정합니다.
- 선의 Width를 설정합니다.
- Aspose.Slides for C++에서 제공하는 스타일 중 하나로 선의 [Dash Style](https://reference.aspose.com/slides/ko/cpp/aspose.slides/linedashstyle/)을 설정합니다.
- 선 시작점의 [Arrow Head Style](https://reference.aspose.com/slides/ko/cpp/aspose.slides/lineformat/) 및 Length를 설정합니다.
- 선 끝점의 Arrow Head Style 및 Length를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**일반 선을 커넥터로 변환하여 도형에 "스냅"되게 할 수 있나요?**

아니요. 일반 선( [AutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/autoshape/)의 [Line](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapetype/) 유형)은 자동으로 커넥터가 되지 않습니다. 도형에 스냅하도록 하려면 전용 [Connector](https://reference.aspose.com/slides/ko/cpp/aspose.slides/connector/) 유형과 연결을 위한 [corresponding APIs](/slides/ko/cpp/connector/)를 사용하십시오.

**테마에서 상속된 선 속성이 최종 값을 파악하기 어려운 경우 어떻게 해야 하나요?**

[유효 속성 읽기](/slides/ko/cpp/shape-effective-properties/)를 [ILineFormatEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilinefillformateffectivedata/) 인터페이스를 통해 확인하십시오—이 인터페이스들은 이미 상속 및 테마 스타일을 반영합니다.

**선 편집(이동, 크기 조정)을 방지하도록 잠글 수 있나요?**

예. Shapes는 [lock objects](https://reference.aspose.com/slides/ko/cpp/aspose.slides/autoshape/get_autoshapelock/)를 제공하며, 이를 통해 [편집 작업을 금지](/slides/ko/cpp/applying-protection-to-presentation/)할 수 있습니다.
---
title: C++에서 프레젠테이션 현지화 자동화
linktitle: 프레젠테이션 현지화
type: docs
weight: 100
url: /ko/cpp/presentation-localization/
keywords:
- 언어 변경
- 맞춤법 검사
- 언어 ID
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint 및 OpenDocument 슬라이드 현지화를 자동화하고, 실용적인 코드 샘플과 팁으로 전 세계 배포를 보다 빠르게 수행합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션의 텍스트에 `LanguageId`를 설정하는 방법을 설명합니다. 프레젠테이션을 열고, 텍스트가 포함된 도형을 추가하고, 텍스트 부분에 언어 식별자를 지정한 다음, 결과를 PPTX 파일로 저장하는 과정을 보여줍니다.

## **프레젠테이션 및 도형 텍스트의 언어 변경**
- [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
- 슬라이드에 사각형 유형의 AutoShape를 추가합니다.
- TextFrame에 텍스트를 추가합니다.
- 텍스트에 Language Id를 설정합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현은 아래 예제에서 확인할 수 있습니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **FAQ**

**언어 ID가 자동 텍스트 번역을 트리거합니까?**

아니요. Aspose.Slides의 [Language ID](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_languageid/)는 맞춤법 검사와 문법 교정을 위해 언어를 저장하지만 텍스트 내용을 번역하거나 변경하지는 않습니다. 이는 PowerPoint이 교정을 위해 이해하는 메타데이터에 불과합니다.

**언어 ID가 렌더링 시 하이픈 처리 및 줄 바꿈에 영향을 줍니까?**

Aspose.Slides에서 [Language ID](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_languageid/)는 교정용입니다. 하이픈 품질 및 줄 바꿈은 주로 [적절한 글꼴](/slides/ko/cpp/powerpoint-fonts/)과 쓰기 시스템에 대한 레이아웃/줄 바꿈 설정에 따라 달라집니다. 올바른 렌더링을 위해 필요한 글꼴을 제공하고, [글꼴 대체 규칙](/slides/ko/cpp/font-substitution/)을 구성하거나 프레젠테이션에 [글꼴을 포함](/slides/ko/cpp/embedded-font/)하십시오.

**단일 문단 내에서 서로 다른 언어를 설정할 수 있습니까?**

예. [Language ID](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_languageid/)는 텍스트 부분 수준에서 적용되므로, 하나의 문단에 여러 언어를 혼합하고 각각의 교정 설정을 적용할 수 있습니다.
---
title: C++를 사용하여 프레젠테이션에서 위첨자 및 아래첨자 관리
linktitle: 위첨자 및 아래첨자
type: docs
weight: 80
url: /ko/cpp/superscript-and-subscript/
keywords:
- 위첨자
- 아래첨자
- 위첨자 추가
- 아래첨자 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides에서 위첨자와 아래첨자를 마스터하고 전문적인 텍스트 서식으로 프레젠테이션을 강화하여 최대의 효과를 얻으세요."
---
## **개요**

Aspose.Slides는 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션에 위첨자 및 아래첨자 텍스트를 통합하는 기능을 제공합니다. 화학식, 수학 방정식을 강조하거나 각주로 내용을 주석 달아야 할 때, 이러한 특수 서식 옵션은 명확성과 정확성을 유지하는 데 도움이 됩니다. 이 문서에서는 위첨자와 아래첨자 스타일을 원활하게 적용하고 모든 슬라이드에서 전문적인 결과를 보장하는 방법을 배웁니다.

## **위첨자 및 아래첨자 텍스트 관리**

어떤 단락 부분에도 위첨자 및 아래첨자 텍스트를 추가할 수 있습니다. Aspose.Slides 텍스트 프레임에 위첨자 또는 아래첨자 텍스트를 추가하려면 PortionFormat 클래스의 **Escapement** 속성을 사용해야 합니다.

이 속성은 위첨자 또는 아래첨자 텍스트를 반환하거나 설정합니다(값 범위는 -100% (아래첨자)에서 100% (위첨자)까지). 예를 들어 :

- [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- 슬라이드에 Rectangle 유형의 IAutoShape를 추가합니다.
- IAutoShape와 연결된 ITextFrame에 접근합니다.
- 기존 Paragraph를 삭제합니다.
- 위첨자 텍스트를 담을 새 Paragraph 객체를 생성하고 이를 ITextFrame의 IParagraphs 컬렉션에 추가합니다.
- 새 Portion 객체를 생성합니다.
- 위첨자를 추가하기 위해 Portion의 Escapement 속성을 0에서 100 사이로 설정합니다. (0은 위첨자 없음 의미)
- Portion에 텍스트를 설정하고 이를 Paragraph의 Portion 컬렉션에 추가합니다.
- 아래첨자 텍스트를 담을 새 Paragraph 객체를 생성하고 이를 ITextFrame의 IParagraphs 컬렉션에 추가합니다.
- 새 Portion 객체를 생성합니다.
- 아래첨자를 추가하기 위해 Portion의 Escapement 속성을 0에서 -100 사이로 설정합니다. (0은 아래첨자 없음 의미)
- Portion에 텍스트를 설정하고 이를 Paragraph의 Portion 컬렉션에 추가합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현은 아래에 제공됩니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **FAQ**

**PDF 또는 다른 형식으로 내보낼 때 위첨자와 아래첨자가 유지되나요?**

예, Aspose.Slides는 프레젠테이션을 PDF, PPT/PPTX, 이미지 및 기타 지원되는 형식으로 내보낼 때 위첨자와 아래첨자 서식을 올바르게 유지합니다. 특수 서식은 모든 출력 파일에서 그대로 유지됩니다.

**위첨자와 아래첨자를 굵게, 기울임 등 다른 서식 스타일과 결합할 수 있나요?**

예, Aspose.Slides를 사용하면 단일 Portion 내에서 다양한 텍스트 스타일을 혼합할 수 있습니다. 굵게, 기울임, 밑줄을 활성화하고 해당 속성을 [PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portionformat/)에서 설정하여 위첨자 또는 아래첨자를 동시에 적용할 수 있습니다.

**테이블, 차트 또는 SmartArt 내부의 텍스트에도 위첨자와 아래첨자 서식이 적용되나요?**

예, Aspose.Slides는 테이블 및 차트 요소를 포함한 대부분의 객체 내에서 서식을 지원합니다. SmartArt와 작업할 때는 해당 요소(예: [SmartArtNode](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartartnode/))와 텍스트 컨테이너에 접근한 다음, [PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portionformat/) 속성을 유사하게 설정해야 합니다.
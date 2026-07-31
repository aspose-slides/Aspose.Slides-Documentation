---
title: C++를 사용한 프레젠테이션에서 글꼴 교체 간소화
linktitle: 글꼴 교체
type: docs
weight: 60
url: /ko/cpp/font-replacement/
keywords:
- 글꼴
- 글꼴 교체
- 글꼴 교체
- 글꼴 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides에서 글꼴을 원활하게 교체하여 PowerPoint 및 OpenDocument 프레젠테이션의 일관된 타이포그래피를 보장합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 전체에서 한 글꼴을 다른 글꼴로 교체할 수 있습니다. 글꼴을 교체하면 원래 글꼴이 사용된 모든 인스턴스가 새 글꼴로 변경됩니다.

글꼴 교체를 수행하려면 프레젠테이션을 로드하고, 원본 글꼴과 교체할 글꼴을 지정한 다음, 글꼴 교체 메서드를 호출하고, 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 이 방법은 프레젠테이션 전체에서 한 글꼴 패밀리에서 다른 글꼴 패밀리로 의도적으로 전환하려는 경우에 유용합니다.

## **폰트 교체**

글꼴 사용을 다시 생각하게 되면 해당 글꼴을 다른 글꼴로 교체할 수 있습니다. 이전 글꼴의 모든 인스턴스가 새 글꼴로 교체됩니다.

Aspose.Slides는 다음과 같이 글꼴을 교체합니다:

1. 해당 프레젠테이션을 로드합니다. 
2. 교체할 기존 글꼴을 로드합니다.
3. 새 글꼴을 로드합니다. 
4. 글꼴을 교체합니다. 
5. 수정된 프레젠테이션을 PPTX 파일로 기록합니다.

다음 C++ 코드가 글꼴 교체를 보여줍니다:

``` cpp
// 프레젠테이션을 로드합니다
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// 교체될 원본 글꼴을 로드합니다
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// 새 글꼴을 로드합니다
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// 글꼴을 교체합니다
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// 프레젠테이션을 저장합니다
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
특정 상황에서(예: 글꼴에 접근할 수 없는 경우) 발생하는 동작을 결정하는 규칙을 설정하려면 [**Font Substitution**](/slides/ko/cpp/font-substitution/)을 참조하세요. 
{{% /alert %}}

## **자주 묻는 질문**

**"폰트 교체", "폰트 대체", "대체 폰트"의 차이점은 무엇인가요?**

교체는 문서 전체에서 한 패밀리에서 다른 패밀리로 의도적으로 전환하는 것입니다. [Substitution](/slides/ko/cpp/font-substitution/)은 "글꼴이 없을 경우 X를 사용한다"는 규칙이며, [Fallback](/slides/ko/cpp/fallback-font/)은 기본 글꼴이 설치되어 있지만 필요한 문자를 포함하지 않을 때 개별 누락 글리프에 대해 적용됩니다.

**교체가 마스터 슬라이드, 레이아웃, 노트 및 댓글에도 적용되나요?**

예. 교체는 원본 글꼴을 사용하는 모든 프레젠테이션 객체에 영향을 미치며, 마스터 슬라이드와 노트도 포함됩니다. 댓글도 문서의 일부이며 글꼴 엔진에서 고려됩니다.

**임베디드 OLE 객체(예: Excel) 내부의 글꼴도 변경되나요?**

아니요. [OLE content](/slides/ko/cpp/manage-ole/)는 해당 애플리케이션이 별도로 제어합니다. 프레젠테이션에서의 교체는 내부 OLE 데이터의 형식을 변경하지 않으며, 이미지로 표시되거나 외부에서 편집 가능한 형태로 나타날 수 있습니다.

**프레젠테이션의 일부(슬라이드별 또는 영역별)만 교체할 수 있나요?**

대상 객체/범위 수준에서 글꼴을 변경하면 전체 문서에 대한 전역 교체가 아니라 선택적인 교체가 가능합니다. 렌더링 중 전체 글꼴 선택 로직은 그대로 유지됩니다.

**프레젠테이션에서 사용되는 모든 글꼴을 미리 어떻게 확인하나요?**

프레젠테이션의 [font manager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/)를 사용하면 사용 중인 [패밀리 목록](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/getfonts/)과 [대체/알 수 없는 글꼴](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/getsubstitutions/)에 대한 정보를 얻을 수 있어 교체 계획에 도움이 됩니다.

**PDF/이미지로 변환할 때도 글꼴 교체가 적용되나요?**

예. 내보내기 중 Aspose.Slides는 동일한 [font selection/substitution sequence](/slides/ko/cpp/font-selection-sequence/)를 적용하므로 사전에 수행한 교체가 변환 시에도 유지됩니다.

**대상 글꼴을 시스템에 설치해야 하나요, 아니면 폰트 폴더를 첨부하면 되나요?**

설치가 필요하지 않습니다. 라이브러리는 [loading external fonts](/slides/ko/cpp/custom-font/)를 지원하므로 사용자 폴더에 있는 폰트를 로드하여 [렌더링 및 내보내기](/slides/ko/cpp/convert-powerpoint/)에 사용할 수 있습니다.

**교체가 문자 대신 사각형(“tofu”)을 표시하는 문제를 해결하나요?**

대상 글꼴에 실제로 필요한 글리프가 포함된 경우에만 해결됩니다. 포함되지 않은 경우 [configure fallback](/slides/ko/cpp/fallback-font/)을 설정하여 누락된 문자를 대체하도록 해야 합니다.
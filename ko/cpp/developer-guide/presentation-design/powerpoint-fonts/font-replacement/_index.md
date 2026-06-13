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
description: "C++용 Aspose.Slides에서 글꼴을 원활하게 교체하여 PowerPoint 및 OpenDocument 프레젠테이션에서 일관된 타이포그래피를 보장합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 전체에서 한 글꼴을 다른 글꼴로 교체할 수 있습니다. 글꼴을 교체하면 원래 글꼴의 모든 인스턴스가 새로운 글꼴로 변경됩니다.

글꼴 교체를 수행하려면 프레젠테이션을 로드하고, 원본 글꼴과 교체할 글꼴을 정의한 다음, 글꼴 교체 메서드를 호출하고, 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 이 방법은 프레젠테이션 전체에서 의도적으로 한 글꼴 패밀리에서 다른 글꼴 패밀리로 전환하려는 경우에 유용합니다.

## **글꼴 교체**

글꼴 사용에 대한 생각이 바뀌면 해당 글꼴을 다른 글꼴로 교체할 수 있습니다. 이전 글꼴의 모든 인스턴스가 새로운 글꼴로 교체됩니다.

Aspose.Slides를 사용하면 다음과 같이 글꼴을 교체할 수 있습니다:

1. 관련 프레젠테이션을 로드합니다. 
2. 교체될 글꼴을 로드합니다. 
3. 새 글꼴을 로드합니다. 
4. 글꼴을 교체합니다. 
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

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
특정 조건(예: 글꼴에 접근할 수 없는 경우)에서 발생하는 동작을 결정하는 규칙을 설정하려면 [**폰트 대체**](/slides/ko/cpp/font-substitution/)를 참조하십시오. 
{{% /alert %}}

## **자주 묻는 질문**

**"font replacement", "font substitution", 그리고 "fallback fonts"의 차이점은 무엇입니까?**

Replacement는 전체 문서에서 한 패밀리에서 다른 패밀리로 의도적으로 전환하는 것입니다. [대체](/slides/ko/cpp/font-substitution/)는 "글꼴을 사용할 수 없을 경우 X를 사용한다"와 같은 규칙입니다. [대체 글꼴](/slides/ko/cpp/fallback-font/)은 기본 글꼴이 설치되어 있지만 필요한 문자가 없는 경우 개별 누락된 글리프에 대해 선택적으로 적용됩니다.

**교체가 마스터 슬라이드, 레이아웃, 노트 및 댓글에도 적용됩니까?**

예. 교체는 원본 글꼴을 사용하는 모든 프레젠테이션 객체에 영향을 미치며, 여기에는 마스터 슬라이드와 노트가 포함됩니다. 댓글도 문서의 일부이며 글꼴 엔진이 고려합니다.

**임베드된 OLE 개체(예: Excel) 내부의 글꼴도 변경됩니까?**

아니요. [OLE 콘텐츠](/slides/ko/cpp/manage-ole/)는 해당 애플리케이션에 의해 제어됩니다. 프레젠테이션에서의 교체는 내부 OLE 데이터를 다시 포맷하지 않으며, 이미지로 표시되거나 외부에서 편집 가능한 콘텐츠로 표시될 수 있습니다.

**프레젠테이션의 일부(슬라이드 또는 영역)만 글꼴을 교체할 수 있습니까?**

필요한 객체/범위 수준에서 글꼴을 변경하고 전체 문서에 전역 교체를 적용하지 않으면, 대상화된 교체가 가능합니다. 렌더링 중 전체 글꼴 선택 로직은 동일하게 유지됩니다.

**프레젠테이션이 사용하는 모든 글꼴을 미리 어떻게 확인할 수 있습니까?**

프레젠테이션의 [폰트 관리자](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/)를 사용하십시오. 해당 관리자는 사용 중인 [패밀리 목록](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/getfonts/)과 [대체/"알 수 없는" 글꼴에 대한 정보](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/getsubstitutions/)를 제공하여 교체 계획에 도움이 됩니다.

**PDF/이미지로 변환할 때 글꼴 교체가 적용됩니까?**

예. 내보내기 중에 Aspose.Slides는 동일한 [글꼴 선택/대체 순서](/slides/ko/cpp/font-selection-sequence/)를 적용하므로 미리 수행한 교체가 변환 과정에서 반영됩니다.

**시스템에 대상 글꼴을 설치해야 합니까, 아니면 폰트 폴더를 첨부할 수 있습니까?**

설치는 필요하지 않습니다. 라이브러리는 사용자 폴더에서 [외부 글꼴 로드](/slides/ko/cpp/custom-font/)를 허용하며, 이는 [렌더링 및 내보내기](/slides/ko/cpp/convert-powerpoint/) 중에 사용할 수 있습니다.

**교체가 문자 대신 "두부"(사각형) 표시를 해결합니까?**

대상 글꼴에 실제로 필요한 글리프가 포함된 경우에만 해결됩니다. 그렇지 않으면 누락된 문자를 보완하기 위해 [대체 글꼴 구성](/slides/ko/cpp/fallback-font/)을 설정하십시오.
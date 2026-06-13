---
title: Python을 사용한 프레젠테이션의 글꼴 교체 간소화
linktitle: 글꼴 교체
type: docs
weight: 60
url: /ko/python-net/font-replacement/
keywords:
- 글꼴
- 글꼴 교체
- 글꼴 교체
- 글꼴 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides Python을 .NET을 통해 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 일관된 타이포그래피를 보장하면서 글꼴을 원활하게 교체합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 전체에서 한 글꼴을 다른 글꼴로 교체할 수 있습니다. 글꼴을 교체하면 원래 글꼴의 모든 인스턴스가 새 글꼴로 변경됩니다.

글꼴 교체를 수행하려면 프레젠테이션을 로드하고, 원본 글꼴과 교체할 글꼴을 정의한 뒤, 글꼴 교체 메서드를 호출하고 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 이 방법은 프레젠테이션 전체에서 의도적으로 한 글꼴 패밀리에서 다른 패밀리로 전환하고 싶을 때 유용합니다.

## **글꼴 교체**

글꼴 사용을 다시 생각하게 되면 해당 글꼴을 다른 글꼴로 교체할 수 있습니다. 이전 글꼴의 모든 인스턴스가 새 글꼴로 대체됩니다.

Aspose.Slides를 사용한 글꼴 교체 방법:

1. 관련 프레젠테이션을 로드합니다.  
2. 교체될 글꼴을 로드합니다.  
3. 새 글꼴을 로드합니다.  
4. 글꼴을 교체합니다.  
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Python 코드는 글꼴 교체를 보여줍니다:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# 프레젠테이션을 로드합니다
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 교체될 원본 글꼴을 로드합니다
    sourceFont = slides.FontData("Arial")

    # 새 글꼴을 로드합니다
    destFont = slides.FontData("Times New Roman")

    # 글꼴을 교체합니다
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # 프레젠테이션을 저장합니다
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}}  
특정 상황(예: 글꼴에 접근할 수 없는 경우)에서 발생하는 일을 결정하는 규칙을 설정하려면 [**글꼴 대체**](/slides/ko/python-net/font-substitution/)를 참조하십시오.  
{{% /alert %}}

## **FAQ**

**“글꼴 교체”, “글꼴 대체”, 그리고 “대체 글꼴”의 차이점은 무엇입니까?**  

교체는 문서 전체에서 한 패밀리에서 다른 패밀리로 의도적으로 전환하는 것입니다. [**대체**](/slides/ko/python-net/font-substitution/)는 “글꼴을 사용할 수 없으면 X를 사용한다”와 같은 규칙이며, [**대체 글꼴**](/slides/ko/python-net/fallback-font/)은 기본 글꼴이 설치되어 있지만 필요한 문자를 포함하지 않을 때 개별 누락 글리프에 대해 외과적으로 적용됩니다.

**교체가 마스터 슬라이드, 레이아웃, 노트 및 댓글에도 적용됩니까?**  

예. 교체는 원본 글꼴을 사용하는 모든 프레젠테이션 객체에 영향을 미치며, 마스터 슬라이드와 노트도 포함됩니다. 댓글도 문서의 일부이며 글꼴 엔진에서 고려됩니다.

**임베드된 OLE 개체(예: Excel) 내부의 글꼴도 변경됩니까?**  

아니요. [OLE 콘텐츠](/slides/ko/python-net/manage-ole/)는 자체 응용 프로그램에 의해 제어됩니다. 프레젠테이션에서의 교체는 내부 OLE 데이터의 서식을 변경하지 않으며, 이미지로 표시되거나 외부에서 편집 가능한 콘텐츠로 처리될 수 있습니다.

**프레젠테이션의 일부(슬라이드 또는 영역)만 글꼴을 교체할 수 있습니까?**  

전체 문서에 전역 교체를 적용하는 대신 필요한 객체/범위 수준에서 글꼴을 변경하면 대상 교체가 가능합니다. 렌더링 중 전체 글꼴 선택 논리는 동일하게 유지됩니다.

**프레젠테이션이 사용하는 모든 글꼴을 미리 어떻게 확인할 수 있습니까?**  

프레젠테이션의 [font manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/)를 사용하십시오. 이 관리자는 사용 중인 [패밀리 목록](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_fonts/)과 [대체/“알 수 없는” 글꼴 정보](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsmanager/get_substitutions/)를 제공하여 교체 계획을 세우는 데 도움이 됩니다.

**PDF/이미지로 변환할 때도 글꼴 교체가 적용됩니까?**  

예. 내보내기 중 Aspose.Slides는 동일한 [글꼴 선택/대체 순서](/slides/ko/python-net/font-selection-sequence/)를 적용하므로 사전에 수행한 교체가 변환 시에도 적용됩니다.

**시스템에 대상 글꼴을 설치해야 합니까, 아니면 폰트 폴더를 첨부할 수 있습니까?**  

설치는 필요하지 않습니다. 라이브러리는 [외부 글꼴 로드](/slides/ko/python-net/custom-font/)를 지원하므로 사용자 폴더에서 글꼴을 로드하여 [렌더링 및 내보내기](/slides/ko/python-net/convert-powerpoint/)에 사용할 수 있습니다.

**교체가 “두부”(사각형) 대신 문자를 표시하도록 수정합니까?**  

대상 글꼴에 실제로 필요한 글리프가 포함된 경우에만 가능합니다. 포함되지 않은 경우 [대체 글꼴](/slides/ko/python-net/fallback-font/)을 구성하여 누락된 문자를 보완하십시오.
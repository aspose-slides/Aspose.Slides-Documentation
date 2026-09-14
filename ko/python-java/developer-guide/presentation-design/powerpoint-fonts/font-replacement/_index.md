---
title: Python via Java를 사용하여 프레젠테이션에서 글꼴 교체 간소화
linktitle: 글꼴 교체
type: docs
weight: 60
url: /ko/python-java/font-replacement/
keywords:
- 글꼴
- 글꼴 교체
- 글꼴 교체
- 글꼴 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python via Java용 Aspose.Slides에서 글꼴을 원활하게 교체하여 PowerPoint 및 OpenDocument 프레젠테이션의 일관된 타이포그래피를 보장합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션 전체에서 한 글꼴을 다른 글꼴로 교체할 수 있도록 합니다. 글꼴이 교체되면 원본 글꼴의 모든 인스턴스가 새 글꼴로 변경됩니다.

글꼴 교체를 수행하려면 프레젠테이션을 로드하고, 원본 글꼴과 교체 글꼴을 정의한 다음, 글꼴 교체 메서드를 호출하고, 수정된 프레젠테이션을 PPTX 파일로 저장합니다. 이 방법은 프레젠테이션 전체에서 의도적으로 한 글꼴 패밀리를 다른 패밀리로 전환하고자 할 때 유용합니다.

## **글꼴 교체**

사용하고자 하는 글꼴에 대해 생각이 바뀐 경우 해당 글꼴을 다른 글꼴로 교체할 수 있습니다. 이전 글꼴의 모든 인스턴스가 새 글꼴로 교체됩니다. 

Aspose.Slides는 다음과 같이 글꼴을 교체할 수 있도록 합니다:

1. 관련 프레젠테이션을 로드합니다. 
2. 교체될 글꼴을 로드합니다.
3. 새 글꼴을 로드합니다. 
4. 글꼴을 교체합니다. 
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

이 Python 코드는 글꼴 교체를 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# 프레젠테이션을 로드합니다.
presentation = Presentation("Fonts.pptx")
try:
    # 교체될 원본 글꼴을 로드합니다.
    source_font = FontData("Arial")

    # 새 글꼴을 로드합니다.
    destination_font = FontData("Times New Roman")

    # 글꼴을 교체합니다.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # 프레젠테이션을 저장합니다.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}} 
특정 조건(예: 글꼴에 접근할 수 없는 경우)에서 발생하는 동작을 결정하는 규칙을 설정하려면 [Font Substitution](/slides/ko/python-java/font-substitution/)을 참조하십시오. 
{{% /alert %}}

## **FAQ**

**"font replacement", "font substitution", 및 "fallback fonts"의 차이점은 무엇인가요?**

교체는 전체 문서에서 한 패밀리에서 다른 패밀리로 의도적으로 전환하는 것입니다. [Substitution](/slides/ko/python-java/font-substitution/)은 "글꼴을 사용할 수 없을 경우 X를 사용한다"와 같은 규칙입니다. [Fallback](/slides/ko/python-java/fallback-font/)은 기본 글꼴이 설치되어 있지만 필요한 문자를 포함하지 않을 때 개별 누락 글리프에 적용됩니다.

**교체가 마스터 슬라이드, 레이아웃, 노트 및 주석에 적용되나요?**

예. 교체는 원본 글꼴을 사용하는 모든 프레젠테이션 객체에 영향을 미치며, 여기에는 마스터 슬라이드와 노트가 포함됩니다; 주석도 문서의 일부이며 글꼴 엔진에서 고려됩니다.

**삽입된 OLE 객체(예: Excel) 내부의 글꼴도 변경되나요?**

아니오. [OLE content](/slides/ko/python-java/manage-ole/)는 해당 애플리케이션에 의해 제어됩니다. 프레젠테이션에서의 교체는 내부 OLE 데이터를 재형식화하지 않으며, 이미지로 표시되거나 외부에서 편집 가능한 콘텐츠로 표시될 수 있습니다.

**프레젠테이션의 일부(슬라이드 또는 영역)만 글꼴을 교체할 수 있나요?**

전체 문서에 전역 교체를 적용하는 대신 필요한 객체/범위 수준에서 글꼴을 변경하면 대상 지정 교체가 가능합니다. 렌더링 중 전체 글꼴 선택 로직은 동일하게 유지됩니다.

**프레젠테이션에서 사용되는 글꼴을 미리 어떻게 확인할 수 있나요?**

프레젠테이션의 [font manager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/)를 사용하세요. 이 도구는 사용 중인 [families in use](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#getFonts) 목록과 [substitutions/"unknown" fonts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsmanager/#getSubstitutions) 정보를 제공하여 교체 계획에 도움을 줍니다.

**PDF/이미지로 변환할 때 글꼴 교체가 작동하나요?**

예. 내보내기 중에 Aspose.Slides는 동일한 [font selection/substitution sequence](/slides/ko/python-java/font-selection-sequence/)를 적용하므로 사전에 수행된 교체가 변환 과정에서 반영됩니다.

**대상 글꼴을 시스템에 설치해야 하나요, 아니면 폰트 폴더를 첨부할 수 있나요?**

설치가 필요하지 않습니다. 라이브러리는 사용자 폴더에서 [loading external fonts](/slides/ko/python-java/custom-font/)를 로드하여 [rendering and export](/slides/ko/python-java/convert-powerpoint/) 중에 사용할 수 있게 합니다.

**교체가 문자 대신 "두부"(사각형) 문제를 해결하나요?**

대상 글꼴에 실제로 필요한 글리프가 포함된 경우에만 해결됩니다. 그렇지 않은 경우 [configure fallback](/slides/ko/python-java/fallback-font/)을 사용하여 누락된 문자를 보완하십시오.
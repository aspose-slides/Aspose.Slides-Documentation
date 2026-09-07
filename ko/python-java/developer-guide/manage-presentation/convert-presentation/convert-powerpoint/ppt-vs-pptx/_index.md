---
title: "차이 이해하기: PPT vs PPTX"
linktitle: "PPT vs PPTX"
type: docs
weight: 10
url: /ko/python-java/ppt-vs-pptx/
keywords:
- "PPT vs PPTX"
- "PPT 또는 PPTX"
- "레거시 형식"
- "최신 형식"
- "바이너리 형식"
- "Office Open XML"
- "PowerPoint"
- "프레젠테이션"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java와 함께 PPT와 PPTX 형식, 호환성 및 변환 옵션을 비교하고, Python 코드 예제를 포함합니다."
---
## **개요**

PPT와 PPTX는 내부 구조와 지원 기능이 다른 PowerPoint 프레젠테이션 형식입니다. PPT는 PowerPoint 97–2003에서 사용된 기존 바이너리 형식이며, PPTX는 PowerPoint 2007에 도입된 Office Open XML 형식입니다. 이 문서에서는 두 형식을 비교하고 Aspose.Slides for Python via Java를 사용하여 PPT 파일을 PPTX로 변환하는 방법을 보여줍니다.

## **PPT란?**

[PPT](https://docs.fileformat.com/presentation/ppt/)는 프레젠테이션 데이터를 바이너리 구조로 저장합니다. 해당 구조를 이해하는 소프트웨어가 있어야 내용을 읽거나 수정할 수 있습니다. PPT는 오래된 PowerPoint 버전과 파일을 교환할 때 유용하지만, 최신 프레젠테이션 기능을 표현하는 능력은 제한적입니다.

## **PPTX란?**

[PPTX](https://docs.fileformat.com/presentation/pptx/)는 Office Open XML 기반입니다. PPTX 파일은 XML 파트, 미디어 파일 및 이들 간의 관계를 포함하는 ZIP 패키지입니다. 이 구조는 바이너리 PPT보다 형식을 검사하고 확장하기가 쉽습니다. PowerPoint는 2007 버전 이후 기본 프레젠테이션 형식으로 PPTX를 사용합니다.

## **PPT vs PPTX**

| 항목 | PPT | PPTX |
| --- | --- | --- |
| 내부 구조 | 바이너리 레코드 | XML과 미디어가 포함된 ZIP 패키지 |
| 일반적인 호환 요구 사항 | PowerPoint 97–2003 워크플로 | PowerPoint 2007 이후 워크플로 |
| 최신 프레젠테이션 기능 | 제한된 지원; 일부 콘텐츠가 단순화될 수 있음 | 최신 객체와 효과에 대한 폭넓은 지원 |
| 권장 사용 | PPT가 필요한 시스템과 교환 | 새 프레젠테이션 및 지속적인 편집 |

형식 간 변환은 파일 확장자를 바꾸는 것 이상을 요구합니다. 일부 PPTX 기능은 PPT에 직접 대응되는 항목이 없습니다. PowerPoint는 MetroBlob 데이터와 같은 특수 PPT 레코드에 추가 정보를 저장하여 최신 콘텐츠를 보존할 수 있지만, 오래된 PowerPoint 버전에서는 해당 내용을 모두 표시하지 못합니다. 따라서 저장한다고 해서 모든 뷰어에서 동일하게 보이거나 동작한다는 보장은 없습니다.

Aspose.Slides for Python via Java는 두 형식을 모두 로드하고 저장할 수 있는 공통 API를 제공합니다. 양방향 변환을 지원하지만 형식 차이와 지원되지 않는 기능으로 인해 결과가 영향을 받을 수 있습니다. 가능하면 PPTX를 사용하고, PPT로 변환된 프레젠테이션은 의도된 뷰어에서 검토하십시오.

{{% alert color="info" title="Note" %}}
온라인에서 PPT‑to‑PPTX 및 PPTX‑to‑PPT 변환 결과를 비교하려면 [Aspose.Slides 변환 앱](https://products.aspose.app/slides/ko/conversion/)을 사용해 보세요.
{{% /alert %}}

## **Python에서 PPT를 PPTX로 변환**

[Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스로 PPT 파일을 로드한 다음, [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 메서드에 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Pptx) 를 지정하여 저장합니다. Microsoft PowerPoint는 필요하지 않습니다.

예제는 필요할 경우 Java 가상 머신을 시작하고 `finally` 블록에서 프레젠테이션 리소스를 해제합니다. 입력 및 출력 경로를 자신의 파일 이름으로 바꾸세요.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 레거시 PPT 프레젠테이션을 로드합니다.
presentation = Presentation("presentation.ppt")
try:
    # 프레젠테이션을 PPTX 형식으로 저장합니다.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

더 많은 예제는 [Python에서 PPT를 PPTX로 변환](/slides/ko/python-java/convert-ppt-to-pptx/)을 참고하세요. 역변환 및 호환성 고려 사항은 [Python에서 PPTX를 PPT로 변환](/slides/ko/python-java/convert-pptx-to-ppt/)을 참조하십시오.

## **자주 묻는 질문**

**오류 없이 열리는 오래된 PPT 프레젠테이션을 계속 보관할 필요가 있나요?**

기존 워크플로에서 PPT가 요구되는 경우 보관할 수 있습니다. 지속적인 편집 및 최신 기능을 사용하려면 [PPTX로 변환](/slides/ko/python-java/convert-ppt-to-pptx/)을 고려하세요. 변환된 프레젠테이션을 확인할 때까지 원본을 유지하십시오.

**먼저 어떤 프레젠테이션을 PPTX로 변환해야 하나요?**

자주 편집하거나 공유되는 파일, 복잡한 [차트](/slides/ko/python-java/create-chart/) 또는 [도형](/slides/ko/python-java/shape-manipulations/)을 포함하는 파일, 또는 [열었을 때](/slides/ko/python-java/open-presentation/) 호환성 경고가 발생하는 파일을 우선 변환하세요. 변환 후 외观과 슬라이드 쇼 동작을 확인하십시오.

**PPT와 PPTX 간 변환 시 비밀번호 보호가 유지되나요?**

출력 파일이 자동으로 원본 보호와 동일하다고 가정하지 마십시오. 암호화된 파일을 로드할 때 필요한 비밀번호를 제공하고, 출력 보호 설정을 명시적으로 구성한 후 저장된 파일을 검증하십시오. 자세한 내용은 [비밀번호로 보호된 프레젠테이션](/slides/ko/python-java/password-protected-presentation/)을 확인하세요.

**PPTX를 PPT로 변환할 때 일부 효과가 사라지거나 단순화되는 이유는 무엇인가요?**

PPT는 모든 최신 객체, 속성 또는 효과를 표현할 수 없습니다. 일부 정보는 나중에 복원될 수 있도록 보존되지만, 오래된 뷰어에서는 모두 표시되지 않을 수 있습니다. 최신 기능을 보존해야 한다면 PPTX 원본을 유지하십시오.
---
title: Python에서 PPT를 PPTX로 변환
linktitle: PPT를 PPTX로
type: docs
weight: 20
url: /ko/python-net/convert-ppt-to-pptx/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPT를 PPTX로
- PPT를 PPTX로 저장
- PPT를 PPTX로 내보내기
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 레거시 PPT 파일을 PPTX로 변환합니다. 단일 파일 및 배치 변환 예제, 오류 처리, 정밀도에 대한 설명이 포함되어 있습니다."
---
## **개요**

PPT는 레거시 바이너리 PowerPoint 형식이며, PPTX는 최신 Open XML 형식입니다. Aspose.Slides for Python via .NET은 Microsoft PowerPoint 없이 PPT 파일을 로드하고 PPTX로 저장할 수 있습니다. 이 문서에서는 단일 파일 또는 파일 디렉터리를 변환하는 방법을 보여주고, 변환 후 확인해야 할 사항을 설명합니다.

## **PPT 파일을 PPTX로 변환**

[Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스로 소스 파일을 로드한 다음, [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/)에 [SaveFormat.PPTX](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/)를 지정하여 호출합니다. `with` 문은 블록이 끝날 때 프레젠테이션을 해제하고 리소스를 해제합니다.

```python
import aspose.slides as slides

# 레거시 PPT 프레젠테이션을 로드합니다.
with slides.Presentation("presentation.ppt") as presentation:
    # PPTX 형식으로 프레젠테이션을 저장합니다.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

파일 확장자는 출력 형식을 자동으로 선택하지 않으며, [SaveFormat.PPTX](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/) 인수가 선택을 결정합니다. 원본 PPT 파일을 유지해야 하는 경우 입력 경로와 출력 경로를 다르게 지정하십시오.

## **여러 PPT 파일 변환**

다음 예제는 하나의 디렉터리에서 모든 `.ppt` 파일을 변환합니다. 각 파일은 독립적으로 처리되므로 하나의 변환 실패가 나머지 배치에 영향을 주지 않습니다.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

프로덕션 환경에서는 전체 예외를 로그에 기록하고, 기존 출력 파일을 덮어쓸지 여부를 결정하며, 실패한 파일 이름을 재시도 또는 검토 큐에 기록하십시오. 손상된 파일, 비밀번호가 필요한 파일을 비밀번호 없이 열려는 경우, 접근할 수 없는 경로, 지원되지 않는 콘텐츠 등은 모두 변환 실패의 원인이 될 수 있습니다. 암호화된 파일 로드에 대해서는 [Password-Protected Presentations](/slides/ko/python-net/password-protected-presentation/)를 참고하십시오.

## **정밀도 및 레거시 기능**

변환은 일반적으로 슬라이드, 마스터, 레이아웃, 텍스트, 도형, 이미지, 표 및 차트를 보존합니다. 그러나 PPT와 PPTX는 모든 기능을 동일하게 표현하지 않으며, PPTX에 해당하는 동일한 기능이 없거나 라이브러리에서 지원되지 않는 레거시 기능은 정규화되거나 생략되거나 다르게 표시될 수 있습니다.

애니메이션, 전환, OLE 개체(임베드 또는 링크), ActiveX 컨트롤, 임베드된 미디어, 특수 폰트 또는 VBA 매크로가 포함된 경우 변환된 파일을 확인하십시오. 일반 PPTX 파일은 매크로가 포함된 형식이 아니므로 VBA가 계속 필요할 경우 매크로 지원 워크플로를 사용하십시오. 또한 변환된 프레젠테이션을 열거나 렌더링할 환경에 필요한 폰트와 외부 리소스가 존재하는지 확인하십시오.

중요 문서의 경우, 생성된 PPTX를 프로그래밍 방식으로 다시 열어 주요 슬라이드 수와 콘텐츠를 검사한 뒤, 의도한 뷰어에서 외观과 슬라이드 쇼 동작을 비교하십시오. 성공적인 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) 호출이 모든 레거시 기능이 정확히 PPTX로 표현되었다는 증거가 되어서는 안 됩니다.

## **PPTX를 사용해야 하는 경우**

프레젠테이션을 최신 PowerPoint 버전에서 편집하거나 Open XML 패키지를 지원하는 시스템과 교환하거나, 레거시 바이너리 PPT보다 검사 및 복구가 용이한 형식으로 저장하려는 경우 PPTX를 사용하십시오. 변환된 프레젠테이션이 정밀도 검증을 통과할 때까지 원본 PPT를 아카이브 또는 롤백 사본으로 보관하십시오.

PDF, HTML, 이미지, XPS 또는 다른 출력 형식이 필요하면 [Convert Presentations to Multiple Formats](/slides/ko/python-net/convert-presentation/)에 있는 형식별 가이드를 참고하고, 모든 대상이 편집 가능한 PowerPoint 기능을 보존한다는 전제로 판단하지 마십시오.

## **온라인 변환기**

가끔 파일을 변환하거나 빠르게 비교하려는 경우, [online PPT to PPTX converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)를 사용할 수 있습니다. 반복 변환, 배치 처리 또는 애플리케이션 수준 오류 처리가 필요한 경우 Python API를 사용하십시오.

## **관련 기사**

- [PPT vs PPTX](/slides/ko/python-net/ppt-vs-pptx/)
- [Save Presentations in Python](/slides/ko/python-net/save-presentation/)
- [Supported File Formats](/slides/ko/python-net/supported-file-formats/)
- [Open Presentations in Python](/slides/ko/python-net/open-presentation/)

## **FAQ**

**Microsoft PowerPoint가 설치되지 않은 상태에서 PPT를 PPTX로 변환할 수 있나요?**

예. Aspose.Slides for Python via .NET은 Microsoft PowerPoint 없이 프레젠테이션 파일을 로드하고 저장할 수 있습니다.

**PPT에서 PPTX로 변환할 때 모든 콘텐츠가 정확히 보존되나요?**

일반적인 프레젠테이션 콘텐츠는 보존되지만, 모든 레거시 또는 지원되지 않는 기능에 대해 정확한 정밀도가 보장되지는 않습니다. 매크로, OLE 또는 ActiveX 개체, 미디어, 특수 애니메이션 또는 일반적이지 않은 폰트가 포함된 경우 생성된 파일을 검토하십시오.

**암호가 보호된 PPT 파일을 변환할 수 있나요?**

예. 파일을 로드할 때 올바른 비밀번호를 제공하면 변환할 수 있습니다. 비밀번호가 없거나 잘못된 경우 로드 작업이 실패합니다.

**변환 후 PPT 파일을 삭제해야 하나요?**

원본 PPT를 검증된 PPTX가 필요한 뷰어와 워크플로에서 확인할 때까지 보관하십시오. 이렇게 하면 레거시 기능이 다르게 변환될 경우 롤백 사본으로 사용할 수 있습니다.
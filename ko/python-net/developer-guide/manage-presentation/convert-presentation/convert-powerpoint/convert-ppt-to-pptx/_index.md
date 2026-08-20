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
description: "Aspose.Slides를 사용하여 Python에서 레거시 PPT 파일을 PPTX로 변환합니다. 단일 파일 및 배치 변환 예제, 오류 처리 및 정밀도에 대한 설명이 포함됩니다."
---
## **개요**

PPT는 레거시 이진 PowerPoint 형식이고, PPTX는 최신 Open XML 형식입니다. Aspose.Slides for Python via .NET은 Microsoft PowerPoint 없이 PPT 파일을 로드하고 PPTX로 저장할 수 있습니다. 이 문서는 파일 하나 또는 전체 디렉터리를 변환하는 방법과 변환 후 확인해야 할 사항을 설명합니다.

## **PPT 파일을 PPTX로 변환**

[Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스로 원본 파일을 로드한 다음, [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/)에 [SaveFormat.PPTX](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/)를 전달합니다. `with` 문은 블록이 끝날 때 프레젠테이션을 해제하고 리소스를 해제합니다.

```python
import aspose.slides as slides

# 레거시 PPT 프레젠테이션을 로드합니다.
with slides.Presentation("presentation.ppt") as presentation:
    # 프레젠테이션을 PPTX 형식으로 저장합니다.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

파일 확장자는 자체적으로 출력 형식을 선택하지 않으며, [SaveFormat.PPTX](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/saveformat/) 인수가 선택합니다. 원본 PPT 파일을 보관해야 하는 경우 입력 경로와 출력 경로를 다르게 지정하십시오.

## **여러 PPT 파일 변환**

다음 예제는 한 디렉터리의 모든 `.ppt` 파일을 변환합니다. 각 파일은 독립적으로 처리되므로 하나의 변환 실패가 나머지 배치를 중단하지 않습니다.

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

프로덕션 환경에서는 전체 예외를 기록하고, 기존 출력 파일을 덮어쓸지 여부를 결정하며, 실패한 파일 이름을 재시도 또는 검토 큐에 기록하십시오. 손상된 파일, 필요한 비밀번호 없이 열린 암호 보호 파일, 접근할 수 없는 경로, 지원되지 않는 콘텐츠 등이 변환 실패의 원인이 될 수 있습니다. 암호화된 파일 로드에 대해서는 [Password-Protected Presentations](/python-net/password-protected-presentation/)를 참조하십시오.

## **정밀도와 레거시 기능**

변환은 일반적으로 슬라이드, 마스터, 레이아웃, 텍스트, 도형, 이미지, 표 및 차트를 보존합니다. 그러나 PPT와 PPTX는 모든 기능을 동일하게 표현하지 않습니다. PPTX에 해당하지 않거나 라이브러리에서 지원되지 않는 레거시 기능은 정규화되거나 생략되거나 다르게 표시될 수 있습니다.

애니메이션, 전환, 삽입되거나 연결된 OLE 개체, ActiveX 컨트롤, 삽입된 미디어, 특수 폰트 또는 VBA 매크로가 포함된 경우 변환된 파일을 확인하십시오. 일반 PPTX 파일은 매크로가 포함된 형식이 아니므로 VBA가 필요한 경우 적절한 매크로 활성화 워크플로를 사용하십시오. 또한 변환된 프레젠테이션을 열거나 렌더링할 환경에 필요한 폰트와 외부 리소스가 존재하는지도 확인하십시오.

중요 문서의 경우, 생성된 PPTX를 프로그래밍 방식으로 다시 열어 주요 슬라이드 수와 내용을 검사하고, 의도한 뷰어에서 외관 및 슬라이드쇼 동작을 비교하십시오. 성공적인 [Presentation.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) 호출이 모든 레거시 기능이 정확히 PPTX로 변환되었다는 증거가 되어서는 안 됩니다.

## **PPTX 사용 시점**

프레젠테이션을 최신 PowerPoint 버전에서 편집하거나 Open XML 패키지를 사용하는 시스템과 교환하거나 레거시 이진 PPT보다 검사 및 복구가 쉬운 형식으로 저장하려는 경우 PPTX를 사용하십시오. 변환된 프레젠테이션이 정밀도 검증을 통과할 때까지 원본 PPT를 보관하거나 롤백 복사본으로 유지하십시오.

PDF, HTML, 이미지, XPS 또는 다른 출력 형식이 필요한 경우, 모든 대상이 편집 가능한 PowerPoint 기능을 보존한다는 가정 대신 [Convert Presentations to Multiple Formats](/python-net/convert-presentation/)에 있는 형식별 가이드를 사용하십시오.

## **온라인 변환기**

가끔 파일을 변환하거나 빠르게 비교하고 싶을 때는 [online PPT to PPTX converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)를 사용할 수 있습니다. 반복 변환, 배치 처리 또는 애플리케이션 수준 오류 처리가 필요한 경우 Python API를 사용하십시오.

## **관련 기사**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Save Presentations in Python](/python-net/save-presentation/)
- [Supported File Formats](/python-net/supported-file-formats/)
- [Open Presentations in Python](/python-net/open-presentation/)

## **FAQ**

**Microsoft PowerPoint 없이 PPT를 PPTX로 변환할 수 있나요?**

예. Aspose.Slides for Python via .NET은 Microsoft PowerPoint 없이 프레젠테이션 파일을 로드하고 저장합니다.

**PPT‑to‑PPTX 변환이 모든 콘텐츠를 정확히 보존하나요?**

일반적인 프레젠테이션 콘텐츠는 보존하지만, 모든 레거시 또는 지원되지 않는 기능에 대해 정확한 정밀도가 보장되지는 않습니다. 매크로, OLE 또는 ActiveX 개체, 미디어, 전문 애니메이션 또는 특수 폰트가 포함된 경우 생성된 파일을 검토하십시오.

**암호 보호된 PPT 파일을 변환할 수 있나요?**

예, 파일을 로드할 때 올바른 비밀번호를 제공하면 가능합니다. 비밀번호가 없거나 잘못된 경우 로드 작업이 실패합니다.

**변환 후 PPT 파일을 삭제해야 하나요?**

원본 파일을 보관하십시오. 변환된 PPTX를 뷰어와 워크플로에서 확인할 때까지 원본을 유지하면 레거시 기능이 다르게 변환될 경우 롤백 복사본으로 사용할 수 있습니다.
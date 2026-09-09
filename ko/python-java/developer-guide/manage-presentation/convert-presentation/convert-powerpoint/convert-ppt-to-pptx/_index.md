---
title: Python에서 PPT를 PPTX로 변환
linktitle: PPT를 PPTX로
type: docs
weight: 20
url: /ko/python-java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 레거시 PPT 파일을 PPTX로 변환합니다. 단일 파일 및 배치 변환, 오류 처리, 정밀도 메모에 대한 Python 예제가 포함됩니다."
---
## **개요**

PPT는 레거시 이진 PowerPoint 형식이며, PPTX는 최신 Open XML 형식입니다. Aspose.Slides for Python via Java는 Microsoft PowerPoint 없이 PPT 파일을 로드하고 PPTX로 저장할 수 있습니다. 이 문서에서는 파일 하나 또는 디렉터리의 파일들을 변환하는 방법을 보여주고 변환 후 확인해야 할 사항을 설명합니다.

각 예제는 필요에 따라 Java 가상머신을 시작하고 사용 후 프레젠테이션을 해제합니다. 예제 경로를 자신의 파일 또는 디렉터리 경로로 교체하십시오.

## **PPT 파일을 PPTX로 변환**

소스 파일을 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스으로 로드한 다음, [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Pptx)를 사용하여 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)를 호출합니다. `finally` 블록은 프레젠테이션을 해제하고 그 리소스를 반환합니다.

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

파일 확장자만으로는 출력 형식을 선택하지 않으며, [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Pptx) 인수가 선택합니다. 원본 PPT 파일을 유지하려면 입력 경로와 출력 경로를 다르게 지정하십시오.

## **여러 PPT 파일을 변환**

다음 예제는 한 디렉터리의 모든 `.ppt` 파일을 변환합니다. 각 파일은 독립적으로 처리되므로 하나의 변환 실패가 배치의 나머지를 멈추게 하지 않습니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

프로덕션 환경에서는 전체 예외를 로그에 기록하고, 기존 출력 파일을 덮어쓸지 여부를 결정하며, 실패한 파일 이름을 재시도 또는 검토 큐에 기록하십시오. 손상된 파일, 필요한 비밀번호 없이 열린 암호 보호 파일, 접근할 수 없는 경로, 지원되지 않는 콘텐츠 등은 모두 변환 실패를 초래할 수 있습니다. 암호화된 파일을 로드하려면 [Password-Protected Presentations](/slides/ko/python-java/password-protected-presentation/)를 참조하십시오.

## **정밀도 및 레거시 기능**

변환은 일반적으로 슬라이드, 마스터, 레이아웃, 텍스트, 도형, 이미지, 표 및 차트를 보존합니다. 그러나 PPT와 PPTX는 모든 기능을 정확히 동일한 방식으로 표현하지 않으며, PPTX에 대응되는 것이 없거나 라이브러리에서 지원되지 않는 레거시 기능은 정규화되거나 누락되거나 다르게 표시될 수 있습니다.

변환된 파일에 애니메이션, 전환 효과, 포함되거나 링크된 OLE 객체, ActiveX 컨트롤, 포함된 미디어, 특수 폰트 또는 VBA 매크로가 포함된 경우 확인하십시오. 일반 PPTX 파일은 매크로 사용이 가능한 형식이 아니므로 VBA를 유지해야 할 경우 적절한 매크로 사용 워크플로를 사용하십시오. 또한 변환된 프레젠테이션을 열거나 렌더링할 환경에 필요한 폰트와 외부 리소스가 존재하는지도 확인해야 합니다.

중요 문서의 경우, 생성된 PPTX를 프로그래밍 방식으로 다시 열어 주요 슬라이드 수와 내용을 검사하고, 의도한 뷰어에서의 외관 및 슬라이드 쇼 동작과 비교하십시오. 성공적인 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 호출을 모든 레거시 기능이 정확히 PPTX로 표현된 증거로 간주하지 마십시오.

## **PPTX를 사용해야 할 때**

프레젠테이션을 최신 PowerPoint 버전에서 편집하거나 Open XML 패키지를 사용하는 시스템과 교환하거나 레거시 이진 PPT보다 검사 및 복구가 쉬운 형식으로 저장하려면 PPTX를 사용하십시오. 변환된 프레젠테이션이 정밀도 검사를 통과할 때까지 원본 PPT를 보관용 또는 롤백 복사본으로 유지하십시오.

PDF, HTML, 이미지, XPS 또는 다른 출력 형식이 필요하다면, 모든 대상이 편집 가능한 PowerPoint 기능을 보존한다는 가정 대신 [Convert Presentations to Multiple Formats](/slides/ko/python-java/convert-presentation/)에 있는 형식별 안내를 따르십시오.

## **온라인 변환기**

가끔 파일을 변환하거나 빠르게 비교하려면 [online PPT to PPTX converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)를 사용할 수 있습니다. 반복 변환, 배치 처리 또는 애플리케이션 수준 오류 처리가 필요한 경우 Python via Java API를 사용하십시오.

## **관련 기사**

- [PPT vs PPTX](/slides/ko/python-java/ppt-vs-pptx/)
- [Python에서 프레젠테이션 저장](/slides/ko/python-java/save-presentation/)
- [지원되는 파일 형식](/slides/ko/python-java/supported-file-formats/)
- [Python에서 프레젠테이션 열기](/slides/ko/python-java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint가 설치되지 않은 상태에서 PPT를 PPTX로 변환할 수 있나요?**

예. Aspose.Slides for Python via Java는 Microsoft PowerPoint를 필요로 하지 않고 프레젠테이션 파일을 로드하고 저장합니다.

**PPT를 PPTX로 변환하면 모든 콘텐츠가 정확히 보존되나요?**

일반적인 프레젠테이션 콘텐츠는 보존되지만, 모든 레거시 또는 지원되지 않는 기능에 대해 정확한 정밀도가 보장되지는 않습니다. 매크로, OLE 또는 ActiveX 객체, 미디어, 특수 애니메이션 또는 특수 폰트가 포함된 경우 생성된 파일을 검토하십시오.

**암호가 보호된 PPT 파일을 변환할 수 있나요?**

예, 파일을 로드할 때 올바른 비밀번호를 제공하면 가능합니다. 비밀번호가 없거나 잘못된 경우 로드 작업이 실패합니다.

**변환 후에 PPT 파일을 삭제해야 하나요?**

중요한 뷰어와 워크플로에서 PPTX를 확인할 때까지 원본을 유지하십시오. 레거시 기능이 다르게 변환될 경우 롤백 복사본을 제공하게 됩니다.
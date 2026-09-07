---
title: Python에서 ODP를 PPTX로 변환
linktitle: ODP에서 PPTX로
type: docs
weight: 10
url: /ko/python-java/convert-odp-to-pptx/
keywords:
- OpenDocument 변환
- 프레젠테이션 변환
- 슬라이드 변환
- ODP 변환
- OpenDocument를 PPTX로
- ODP를 PPTX로
- ODP를 PPTX로 저장
- ODP를 PPTX로 내보내기
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 ODP 프레젠테이션을 PPTX로 변환합니다. PowerPoint 또는 LibreOffice를 설치하지 않고도 완전한 Python 예제를 사용할 수 있습니다."
---
## **개요**

이 문서는 Aspose.Slides for Python via Java를 사용하여 OpenDocument(ODP) 프레젠테이션을 PowerPoint(PPTX) 형식으로 변환하는 방법을 설명합니다.

## **ODP를 PPTX로 변환**

The [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스는 ODP 파일을 직접 로드할 수 있습니다. 로드된 프레젠테이션을 [SaveFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/)을 사용하여 PPTX 형식으로 저장합니다.

Follow the [installation instructions](/slides/ko/python-java/installation/)를 예제를 실행하기 전에 따르십시오. 작업 디렉터리에 `AccessOpenDoc.odp`라는 ODP 프레젠테이션을 놓습니다. 아래 코드는 필요할 경우 JVM을 시작하고 ODP 파일을 열어 `AccessOpenDoc_out.pptx`로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # ODP 프레젠테이션을 PPTX 형식으로 저장합니다.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **실시간 예제**

Aspose.Slides가 제공하는 ODP에서 PPTX로의 변환을 확인하려면 [Aspose.Slides Conversion](https://products.aspose.app/slides/ko/conversion/) 웹 앱을 사용해 보세요.

## **FAQ**

**ODP를 PPTX로 변환하기 위해 Microsoft PowerPoint 또는 LibreOffice를 설치해야 하나요?**

아니요. Aspose.Slides for Python via Java는 해당 애플리케이션 없이도 프레젠테이션 파일을 읽고 쓸 수 있습니다. Python 패키지와 호환 가능한 Java 런타임만 필요합니다.

**마스터 슬라이드, 레이아웃 및 테마가 변환 중에 보존되나요?**

Aspose.Slides는 소스 프레젠테이션의 구조와 서식을 PPTX에 매핑합니다. 그러나 ODP와 PPTX는 지원하는 기능이 다르기 때문에 변환 후 일부 요소가 다르게 보일 수 있습니다. 필요한 글꼴을 제공하고 복잡한 서식이 있는 프레젠테이션을 검토하십시오. 호환성 고려 사항은 [OpenDocument conversion](/slides/ko/python-java/convert-openoffice-odp/)을 참조하세요.

**암호로 보호된 ODP 파일을 변환할 수 있나요?**

예, 파일을 열 때 필요한 비밀번호를 제공하면 가능합니다. 다른 형식으로 저장하기 전에 보호된 파일을 로드하는 방법에 대한 자세한 내용은 [password-protected presentations](/slides/ko/python-java/password-protected-presentation/)를 참조하십시오.

**Aspose.Slides가 클라우드 또는 REST 기반 변환 서비스에 적합한가요?**

예. 필요한 Java 런타임을 갖춘 백엔드에서 Aspose.Slides for Python via Java를 사용할 수 있습니다. REST API에 대해서는 [Aspose.Slides Cloud](https://products.aspose.cloud/slides/ko/family/)을 참조하십시오.
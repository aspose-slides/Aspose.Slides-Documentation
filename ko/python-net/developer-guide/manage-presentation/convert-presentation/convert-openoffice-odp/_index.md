---
title: Python에서 OpenDocument 프레젠테이션 변환
linktitle: OpenDocument 변환
type: docs
weight: 10
url: /ko/python-net/convert-openoffice-odp/
keywords:
- OpenDocument 변환
- ODP 변환
- ODP를 PDF로
- ODP를 PPT로
- ODP를 PPTX로
- ODP를 XPS로
- ODP를 HTML로
- ODP를 TIFF로
- ODP를 SWF로
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides를 사용하여 OpenDocument ODP를 PDF, PPT, PPTX, XPS, HTML, TIFF 또는 SWF로 변환합니다: 코드 예제, 높은 정확도, 일괄 변환 및 사용자 지정."
---
## **소개**

[**Aspose.Slides API**](https://products.aspose.com/slides/ko/python-net/)를 사용하면 OpenDocument(ODP) 프레젠테이션을 다양한 형식(HTML, PDF, TIFF, SWF, XPS 등)으로 변환할 수 있습니다. ODP 파일을 다른 문서 형식으로 변환하는 데 사용되는 API는 PowerPoint(PPT 및 PPTX) 변환 작업에 사용되는 API와 동일합니다.

예를 들어, ODP 프레젠테이션을 PDF로 변환하려면 다음과 같이 할 수 있습니다:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **자주 묻는 질문**

**LibreOffice 또는 OpenOffice를 설치하지 않고 ODP를 PPTX로 변환할 수 있나요?**

예. Aspose.Slides는 외부 애플리케이션이 필요 없이 PowerPoint와 OpenOffice 형식을 모두 처리하는 완전 독립형 라이브러리입니다.

**Aspose.Slides가 암호로 보호된 ODP/OTP 파일을 열고 저장할 수 있나요?**

예. 비밀번호를 제공하면 [암호화된 프레젠테이션 로드](/slides/ko/python-net/password-protected-presentation/)이 가능하며, 암호화 및 보호 설정을 적용해 프레젠테이션을 저장할 수도 있습니다.

**ODP를 변환하기 전에 포함된 미디어 파일(오디오/비디오)을 추출할 수 있나요?**

예. Aspose.Slides를 사용하면 프레젠테이션에서 포함된 [오디오](/slides/ko/python-net/audio-frame/)와 [비디오](/slides/ko/python-net/video-frame/)를 접근하고 추출할 수 있어 사전 변환 처리나 별도 재사용에 유용합니다.

**변환된 ODP를 Strict Office Open XML 형식으로 저장할 수 있나요?**

예. PPTX로 저장할 때 [저장 옵션](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pptxoptions/)을 사용해 Strict OOXML을 활성화하여 보다 엄격한 호환성 요구 사항을 충족시킬 수 있습니다.
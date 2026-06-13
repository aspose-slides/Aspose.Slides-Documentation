---
title: C++에서 OpenDocument 프레젠테이션 변환
linktitle: OpenDocument 변환
type: docs
weight: 10
url: /ko/cpp/convert-openoffice-odp/
keywords:
- ODP 변환
- ODP를 이미지로
- ODP를 GIF로
- ODP를 HTML로
- ODP를 JPG로
- ODP를 MD로
- ODP를 PDF로
- ODP를 PNG로
- ODP를 PPT로
- ODP를 PPTX로
- ODP를 TIFF로
- ODP를 비디오로
- ODP를 Word로
- ODP를 XPS로
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하면 ODP를 PDF, HTML 및 이미지 형식으로 손쉽게 변환할 수 있습니다. 빠르고 정확한 프레젠테이션 변환으로 C++ 애플리케이션을 강화하세요."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/ko/cpp/)는 OpenDocument (ODP) 프레젠테이션을 다양한 형식(HTML, PDF, TIFF, SWF, XPS 등)으로 변환할 수 있도록 합니다. ODP 파일을 다른 문서 형식으로 변환하는 데 사용되는 API는 PowerPoint(PPT 및 PPTX) 변환 작업에 사용되는 API와 동일합니다.

예를 들어, ODP 프레젠테이션을 PDF로 변환해야 하는 경우 다음과 같이 할 수 있습니다:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```
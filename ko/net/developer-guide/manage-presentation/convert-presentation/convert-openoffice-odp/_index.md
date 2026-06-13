---
title: OpenDocument 프레젠테이션을 .NET에서 변환
linktitle: OpenDocument 변환
type: docs
weight: 10
url: /ko/net/convert-openoffice-odp/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하면 ODP를 PDF, HTML 및 이미지 형식으로 손쉽게 변환할 수 있습니다. 빠르고 정확한 프레젠테이션 변환으로 .NET 애플리케이션을 강화하세요."
---
## **소개**

[**Aspose.Slides API**](https://products.aspose.com/slides/ko/net/)를 사용하면 OpenDocument(ODP) 프레젠테이션을 다양한 형식(HTML, PDF, TIFF, SWF, XPS 등)으로 변환할 수 있습니다. ODP 파일을 다른 문서 형식으로 변환하는 데 사용되는 API는 PowerPoint(PPT 및 PPTX) 변환 작업에 사용되는 API와 동일합니다.

예를 들어 ODP 프레젠테이션을 PDF로 변환해야 하는 경우 다음과 같이 수행할 수 있습니다:

```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```

## **다양한 애플리케이션에서의 OpenDocument 프레젠테이션**

OpenDocument 프레젠테이션(ODP) 파일을 PowerPoint에서 열면 원본 애플리케이션에서 만든 형식이 유지되지 않을 수 있습니다. 이는 OpenDocument 프레젠테이션 앱과 PowerPoint 앱이 제공하는 기능 및 렌더링 동작이 서로 다르기 때문입니다.

몇 가지 차이점은 다음과 같습니다:

- PowerPoint에서는 테이블이 일반적으로 마지막에 렌더링되어 ODP 슬라이드상의 순서와 관계없이 다른 도형 위에 겹칠 수 있습니다.
- ODP 테이블에 대한 그림 채우기는 PowerPoint에서 지원되지 않습니다.
- 텍스트 수직 회전(270°, 스택) 및 분산 정렬은 LibreOffice/OpenOffice Impress에서 지원되지 않습니다.
- 텍스트에 대한 그림 채우기, 그라디언트 채우기 및 패턴 채우기는 LibreOffice/OpenOffice Impress에서 지원되지 않습니다.

MS PowerPoint와 LibreOffice/OpenOffice Impress는 목록 처리 방식도 다릅니다. PowerPoint에서 만든 ODP 파일이 LibreOffice/OpenOffice Impress에서 올바르게 표시되지 않을 수 있으며 그 반대도 마찬가지입니다.

아래 이미지는 LibreOffice Impress에서 만든 목록이 어떻게 표시되는지를 보여줍니다:

![ODP list example](odp-list-example.png)

Aspose.Slides는 ODP 목록을 LibreOffice/OpenOffice Impress에서 올바르게 표시되도록 저장합니다.

[OpenDocument 형식 및 PowerPoint에 대해 자세히 알아보기](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**변환 후 ODP 파일의 형식이 변경되면 어떻게 해야 하나요?**

ODP와 PowerPoint는 서로 다른 프레젠테이션 모델을 사용하며 테이블, 사용자 정의 글꼴 또는 채우기 스타일과 같은 일부 요소가 정확히 동일하게 렌더링되지 않을 수 있습니다. 필요에 따라 출력물을 검토하고 코드에서 레이아웃이나 형식을 조정하는 것이 권장됩니다.

**ODP 변환을 사용하려면 OpenOffice 또는 LibreOffice를 설치해야 하나요?**

아니요, Aspose.Slides for .NET은 독립형 라이브러리이며 시스템에 OpenOffice 또는 LibreOffice를 설치할 필요가 없습니다.

**ODP 변환 중에 출력 형식을 사용자 정의할 수 있나요(예: PDF 옵션 설정)?**

예, Aspose.Slides는 출력 맞춤화를 위한 풍부한 옵션을 제공합니다. 예를 들어 PDF로 저장할 때 [PdfOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/) 클래스를 통해 압축, 이미지 품질, 텍스트 렌더링 등을 제어할 수 있습니다.

**Aspose.Slides는 서버 측 또는 클라우드 기반 ODP 처리에 적합한가요?**

물론입니다. Aspose.Slides for .NET은 데스크톱 환경뿐만 아니라 Azure, AWS, Docker 컨테이너와 같은 클라우드 기반 플랫폼에서도 UI 종속성 없이 작동하도록 설계되었습니다.
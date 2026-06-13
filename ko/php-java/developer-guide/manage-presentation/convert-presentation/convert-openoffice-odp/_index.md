---
title: PHP에서 OpenDocument 프레젠테이션 변환
linktitle: OpenDocument 변환
type: docs
weight: 10
url: /ko/php-java/convert-openoffice-odp/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 사용하면 ODP를 PDF, HTML 및 이미지 형식으로 손쉽게 변환할 수 있습니다. 빠르고 정확한 프레젠테이션 변환으로 PHP 애플리케이션을 강화하세요."
---
## **소개**

[**Aspose.Slides API**](https://products.aspose.com/slides/ko/php-java/)는 OpenDocument (ODP) 프레젠테이션을 다양한 형식(HTML, PDF, TIFF, SWF, XPS 등)으로 변환할 수 있습니다. ODP 파일을 다른 문서 형식으로 변환하는 데 사용되는 API는 PowerPoint(PPT 및 PPTX) 변환 작업에 사용되는 API와 동일합니다.

## **ODP를 PDF로 변환**

예를 들어 ODP 프레젠테이션을 PDF로 변환해야 하는 경우 다음과 같이 수행할 수 있습니다:

```php
$presentation = null;
try {
    $presentation = new Presentation("pres.odp");
    $presentation->save("pres.pdf", SaveFormat::Pdf);
    
} finally {
    if ($presentation != null) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**변환 후 ODP 파일의 서식이 변경되면 어떻게 하나요?**

ODP와 PowerPoint는 서로 다른 프레젠테이션 모델을 사용하므로 테이블, 사용자 정의 글꼴, 채우기 스타일과 같은 일부 요소가 정확히 동일하게 표시되지 않을 수 있습니다. 필요하면 출력물을 검토하고 코드에서 레이아웃이나 서식을 조정하는 것이 권장됩니다.

**ODP 변환을 사용하려면 OpenOffice 또는 LibreOffice를 설치해야 하나요?**

아니요, Aspose.Slides는 독립 실행형 라이브러리이며 시스템에 OpenOffice나 LibreOffice를 설치할 필요가 없습니다.

**ODP 변환 중에 출력 형식을 사용자 정의할 수 있나요(예: PDF 옵션 설정)?**

예, Aspose.Slides는 출력 사용자 정의를 위한 다양한 옵션을 제공합니다. 예를 들어 PDF로 저장할 때는 [PdfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pdfoptions/) 클래스를 통해 압축, 이미지 품질, 텍스트 렌더링 등 여러 요소를 제어할 수 있습니다.

**Aspose.Slides가 서버 측 또는 클라우드 기반 ODP 처리에 적합한가요?**

물론입니다. Aspose.Slides는 데스크톱 및 서버 환경 모두에서 작동하도록 설계되었으며, Azure, AWS, Docker 컨테이너와 같은 클라우드 플랫폼에서도 UI 의존성 없이 사용할 수 있습니다.
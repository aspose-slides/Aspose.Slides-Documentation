---
title: 지원되는 파일 형식
type: docs
weight: 20
url: /ko/jasperreports/supported-file-formats/
description: "Aspose.Slides for JasperReports가 입력으로 받는 항목과 보고서를 내보내는 파일 형식을 확인하십시오."
---
## **입력**

Aspose.Slides for JasperReports는 보고서를 내보냅니다; 기존 프레젠테이션을 변환하지는 않습니다. 해당 내보내기 도구는 채워진 JasperReports 보고서(`JasperPrint`)를 사용합니다. 예를 들어 `JasperFillManager`의 결과이거나 *.jrprint* 파일에서 로드된 채워진 보고서입니다.

## **출력 형식**

다음 표는 Aspose.Slides for JasperReports가 보고서를 내보내는 형식과 각 형식을 작성하는 내보내기 클래스들을 나열합니다.

|**형식**|**설명**|**내보내기**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97–2003 프레젠테이션; 보고서 페이지당 하나의 슬라이드|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 프레젠테이션(Office Open XML); 보고서 페이지당 하나의 슬라이드|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|휴대용 문서 형식; 보고서 페이지당 하나의 PDF 페이지|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|보고서 페이지당 하나의 SVG 이미지가 포함된 단일 HTML 파일|`ASHtmlExporter`|

PPS 및 PPSX 슬라이드 쇼 형식에 대한 내보내기 도구는 없습니다. PPTX 내보내기에 *.ppsx* 파일 이름을 지정해도 PPTX 프레젠테이션이 생성될 뿐 슬라이드 쇼가 되지는 않습니다. 각 내보내기가 어떻게 사용되는지 보려면 [PPT, PPTX, PDF and HTML Export](/slides/ko/jasperreports/ppt-pptx-pdf-and-html-export/)를 참조하십시오.
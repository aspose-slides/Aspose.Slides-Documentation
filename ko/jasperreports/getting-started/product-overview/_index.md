---
title: 제품 개요
type: docs
weight: 10
url: /ko/jasperreports/product-overview/
description: "Aspose.Slides for JasperReports가 수행하는 작업, 지원하는 JasperReports 버전 및 출력 형식, 그리고 두 개의 jar가 무엇을 위한 것인지 알아봅니다."
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **제품 설명**

Aspose.Slides for JasperReports는 Microsoft PowerPoint 없이도 Java 애플리케이션 및 JasperReports Server에서 JasperReports 보고서를 PowerPoint 프레젠테이션으로 내보냅니다. JasperReports 3.7.2부터 6.16.0까지 지원하며, 각 버전 범위마다 별도의 jar가 제공됩니다 — 자세한 내용은 [Aspose.Slides for JasperReports 설치](/slides/ko/jasperreports/installing-aspose-slides-for-jasperreports/)를 참조하십시오.

채워진 보고서를 네 가지 형식으로 내보내며, 보고서 페이지당 하나의 슬라이드 또는 페이지를 생성합니다:

- PPT – PowerPoint 97–2003 프레젠테이션
- PPTX – PowerPoint 프레젠테이션 (Office Open XML)
- PDF
- HTML

제품은 두 부분으로 구성됩니다:

- 라이브러리 jar는 JasperReports Library에 내보내기 도구 `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` 및 `ASHtmlExporter`를 추가합니다.
- 서버 jar는 동일한 네 가지 형식에 대한 내보내기 작업을 제공하며, 이를 JasperReports Server에 등록합니다 — 자세한 내용은 [JasperServer와의 통합](/slides/ko/jasperreports/integration-with-jasperserver/)을 참조하십시오.

### **출력 예제**

내보내기 도구는 JasperReports 자체 내보내기 클래스를 확장하며 동일한 방식으로 사용됩니다: 채워진 보고서와 출력 파일을 전달한 다음 `exportReport`를 호출합니다. 보고서를 채우고 PPTX로 내보내는 전체 프로그램은 [첫 번째 내보내기](/slides/ko/jasperreports/#your-first-export)에서 확인할 수 있으며, 네 가지 형식 모두에 대해서는 [PPT, PPTX, PDF 및 HTML 내보내기](/slides/ko/jasperreports/ppt-pptx-pdf-and-html-export/)를 참고하십시오.

![라이선스 없이 프레젠테이션으로 내보낸 보고서, 슬라이드 중앙에 평가용 워터마크가 표시됨](product-overview_2.png)
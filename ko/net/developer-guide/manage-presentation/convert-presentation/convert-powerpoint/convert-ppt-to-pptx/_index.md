---
title: .NET에서 PPT를 PPTX로 변환
linktitle: PPT를 PPTX로
type: docs
weight: 20
url: /ko/net/convert-ppt-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 .NET에서 레거시 PPT 프레젠테이션을 최신 PPTX로 빠르게 변환합니다 — 명확한 튜토리얼, 무료 C# 코드 샘플, Microsoft Office 의존 없음."
---
## **개요**

이 문서는 C#와 온라인 PPT to PPTX 변환 앱을 사용하여 PPT 형식의 PowerPoint 프레젠테이션을 PPTX 형식으로 변환하는 방법을 설명합니다. 다음 주제가 다루어집니다.

- [C#에서 PPT를 PPTX로 변환](#convert-ppt-to-pptx)

## **.NET에서 PPT를 PPTX로 변환**

C# 샘플 코드를 보려면 아래 섹션인 [PPT를 PPTX로 변환](#convert-ppt-to-pptx)를 참고하십시오. 이 코드는 PPT 파일을 로드하고 PPTX 형식으로 저장합니다. 다른 저장 형식을 지정하면 PDF, XPS, ODP, HTML 등 다양한 형식으로 PPT 파일을 저장할 수 있습니다. 이러한 내용은 해당 기사에서 논의됩니다.

- [C#에서 PPT를 PDF로 변환](/slides/ko/net/convert-powerpoint-to-pdf/)
- [C#에서 PPT를 XPS로 변환](/slides/ko/net/convert-powerpoint-to-xps/)
- [C#에서 PPT를 HTML로 변환](/slides/ko/net/convert-powerpoint-to-html/)
- [C#에서 PPT를 ODP로 변환](/slides/ko/net/save-presentation/)
- [C#에서 PPT를 PNG로 변환](/slides/ko/net/convert-powerpoint-to-png/)

## **PPT를 PPTX로 변환에 대하여**
Aspose.Slides API를 사용하여 기존 PPT 형식을 PPTX로 변환합니다. 수천 개의 PPT 프레젠테이션을 PPTX 형식으로 변환해야 하는 경우, 가장 좋은 솔루션은 프로그래밍 방식으로 수행하는 것입니다. Aspose.Slides API를 사용하면 몇 줄의 코드만으로 가능합니다. 이 API는 PPT 프레젠테이션을 PPTX로 변환하기 위한 완전한 호환성을 지원하며, 다음과 같은 작업이 가능합니다:

- 마스터, 레이아웃 및 슬라이드의 복잡한 구조를 변환합니다.
- 차트가 포함된 프레젠테이션을 변환합니다.
- 그룹 도형, 자동 도형(사각형 및 타원 등), 사용자 정의 기하 도형이 포함된 프레젠테이션을 변환합니다.
- 자동 도형에 텍스처 및 사진 채우기 스타일이 적용된 프레젠테이션을 변환합니다.
- 플레이스홀더, 텍스트 프레임 및 텍스트 보관소가 포함된 프레젠테이션을 변환합니다.

{{% alert color="primary" %}} 

다음 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx) 앱을 살펴보세요:

[](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)

이 앱은 **Aspose.Slides API**를 기반으로 구축되었으며, 기본 PPT를 PPTX로 변환하는 기능을 실시간 예제로 확인할 수 있습니다. Aspose.Slides Conversion은 웹 앱으로, PPT 형식의 프레젠테이션 파일을 드롭하면 PPTX로 변환된 파일을 다운로드할 수 있습니다.

다른 실시간 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/ko/conversion/) 예제를 확인하십시오.
{{% /alert %}} 

## **PPT를 PPTX로 변환**
PPT를 PPTX로 변환하려면 파일 이름과 저장 형식을 [**Save**](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/methods/save/index) 메서드에 전달하면 됩니다. 아래 C# 코드 샘플은 기본 옵션을 사용하여 프레젠테이션을 PPT에서 PPTX로 변환합니다.

```c#
 // PPTX 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// PPTX 프레젠테이션을 PPTX 형식으로 저장합니다
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

PPT와 PPTX 프레젠테이션 형식에 대해 자세히 보려면 [**PPT vs PPTX**](/slides/ko/net/ppt-vs-pptx/)를 참고하고, [**Aspose.Slides에서 PPT를 PPTX로 변환 지원**](/slides/ko/net/convert-ppt-to-pptx/)을 확인하십시오.

## **FAQ**

**PPT와 PPTX 형식의 차이점은 무엇인가요?**

PPT는 Microsoft PowerPoint에서 사용되는 오래된 바이너리 파일 형식이며, PPTX는 Microsoft Office 2007에서 도입된 XML 기반의 최신 형식입니다. PPTX 파일은 성능이 개선되고 파일 크기가 감소하며 데이터 복구가 향상됩니다.

**.NET을 사용하여 PPT를 PPTX로 변환할 수 있나요?**

예, Aspose.Slides for .NET 라이브러리를 사용하면 몇 줄의 코드만으로 PPT 파일을 로드하고 PPTX 형식으로 저장할 수 있습니다.

**Aspose.Slides가 여러 PPT 파일을 PPTX로 일괄 변환하는 것을 지원하나요?**

예, 루프에서 Aspose.Slides를 사용하여 여러 PPT 파일을 프로그래밍 방식으로 PPTX로 변환할 수 있어 배치 변환 시나리오에 적합합니다.

**변환 후 내용과 서식이 유지되나요?**

Aspose.Slides는 프레젠테이션을 변환할 때 높은 충실도를 유지합니다. 슬라이드 레이아웃, 애니메이션, 도형, 차트 및 기타 디자인 요소가 PPT를 PPTX로 변환하는 동안 보존됩니다.

**PPT 파일을 PDF나 HTML과 같은 다른 형식으로 변환할 수 있나요?**

예, Aspose.Slides는 PPT 파일을 PDF, XPS, HTML, ODP 및 PNG, JPEG과 같은 이미지 형식으로 변환하는 것을 지원합니다.

**Microsoft PowerPoint가 설치되지 않은 상태에서 PPT를 PPTX로 변환할 수 있나요?**

예, Aspose.Slides for .NET은 독립형 API이며 Microsoft PowerPoint나 타사 소프트웨어 없이도 변환을 수행할 수 있습니다.

**PPT를 PPTX로 변환하는 온라인 도구가 있나요?**

예, 코드를 작성하지 않고 브라우저에서 직접 변환할 수 있는 무료 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx) 웹 애플리케이션을 사용할 수 있습니다.
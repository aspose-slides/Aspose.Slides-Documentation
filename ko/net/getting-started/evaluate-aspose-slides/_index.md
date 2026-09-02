---
title: Aspose.Slides 평가
type: docs
weight: 120
url: /ko/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides 평가
- Aspose.Slides 평가
- 평가 버전
- 전체 기능
- 평가 워터마크
- Aspose.Slides 구매
- 제한
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET용 Aspose.Slides를 평가하고 PowerPoint(PPT, PPTX)와 OpenDocument(ODP) 프레젠테이션용 API 기능을 살펴보세요—무료 체험을 시작하세요."
---
## **Aspose.Slides 평가**

평가용 Aspose.Slides를 쉽게 다운로드할 수 있습니다. 평가 패키지는 구매한 패키지와 동일합니다. 평가 버전은 라이선스를 적용하는 몇 줄의 코드를 추가하면 라이선스가 적용된 버전으로 전환됩니다.  

라이선스가 지정되지 않은 평가용 Aspose.Slides 버전은 전체 제품 기능을 제공하지만, 열기와 저장 시 문서 상단에 평가 워터마크를 삽입합니다. 또한 프레젠테이션 슬라이드에서 텍스트를 추출할 경우 한 슬라이드로 제한됩니다.

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 
평가 버전 제한 없이 Aspose.Slides를 테스트하고 싶다면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [임시 라이선스를 받는 방법?](https://purchase.aspose.com/temporary-license) 를 참고하십시오.
{{% /alert %}}

## **평가 패키지 설치**

```bash
dotnet add package Aspose.Slides.NET
```

## **라이선스 적용**

평가 패키지를 라이선스가 적용된 패키지로 전환하는 “몇 줄의 코드”입니다. 라이선스는 애플리케이션 시작 시 한 번 적용해야 하며, `Presentation` 객체가 생성되기 전에 적용해야 합니다 — 이후에 만든 프레젠테이션은 평가 워터마크가 유지됩니다.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense`는 `Stream`도 허용합니다. 이는 라이선스가 파일 대신 임베디드 리소스로 제공될 때 더 좋은 옵션입니다. 경로가 잘못되었거나 파일이 만료된 경우 호출이 예외를 발생시키며, 따라서 시작 시 즉시 실패가 드러나 평가 모드로 조용히 전환되는 것을 방지합니다.

라이선스가 적용되면 워터마크가 사라지고 한 슬라이드 텍스트 추출 제한이 해제됩니다.

## **자주 묻는 질문**

### 평가 모드에서 서로 다른 스레드에서 여러 프레젠테이션을 동시에 테스트할 수 있나요?

예. 서로 다른 문서를 병렬로 처리할 수 있습니다; 동일한 프레젠테이션 객체를 [스레드 간에 공유](/slides/ko/net/multithreading/)하지 않아야 합니다. 평가 모드가 이것에 영향을 주지는 않습니다.

### 서버나 CI 환경에서 라이브러리를 평가하려면 Microsoft PowerPoint를 설치해야 하나요?

아니요. Aspose.Slides는 독립형 엔진으로, 평가든 제품이든 PowerPoint를 설치할 필요가 없습니다.

### 평가 모드에서 PPT/PPTX를 PDF 및 이미지로 변환하는 전체 테스트를 할 수 있나요?

예. [컨버터](/slides/ko/net/convert-presentation/)가 정상적으로 동작하지만, 출력물에 워터마크가 포함됩니다.

### 로드 테스트 시 워터마크 없이 임시 라이선스를 사용할 수 있나요?

예. 30일 임시 라이선스를 사용하면 평가 모드 제한이 해제되어 워터마크 없이 테스트할 수 있습니다.
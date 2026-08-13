---
title: Aspose.Slides 평가
type: docs
weight: 120
url: /ko/net/evaluate-aspose-slides/
keywords:
- Aspose.Slides 평가하기
- Aspose.Slides 평가
- 평가 버전
- 전체 기능
- 평가 워터마크
- Aspose.Slides 구매
- 제한 사항
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET용 Aspose.Slides를 평가하고 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션을 위한 API 기능을 살펴보세요—무료 체험을 시작하세요."
---
## **Aspose.Slides 평가**

Aspose.Slides 평가판을 쉽게 다운로드할 수 있습니다. 평가 패키지는 구매한 패키지와 동일합니다. 평가 버전은 라이선스를 적용하는 몇 줄의 코드를 추가하면 라이선스가 적용된 버전으로 전환됩니다. 

Aspose.Slides 평가 버전(라이선스가 지정되지 않은 경우)은 전체 제품 기능을 제공하지만, 문서를 열거나 저장할 때 문서 상단에 평가 워터마크를 삽입합니다. 또한 프레젠테이션 슬라이드에서 텍스트를 추출할 경우 한 슬라이드로 제한됩니다.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 

평가 버전의 제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [임시 라이선스를 받는 방법?](https://purchase.aspose.com/temporary-license) 을 참조하십시오.

{{% /alert %}}

## **평가 패키지 설치**

```bash
dotnet add package Aspose.Slides.NET
```

## **라이선스 적용**

이것이 평가 패키지를 라이선스가 적용된 패키지로 전환하는 “몇 줄의 코드”입니다. 애플리케이션 시작 시점에 라이선스를 한 번 적용하십시오. `Presentation` 객체가 생성되기 전에 적용해야 합니다 — 이전에 생성된 프레젠테이션은 평가 워터마크를 유지합니다.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense`는 `Stream`도 받을 수 있으며, 라이선스가 파일이 아니라 임베디드 리소스로 제공될 때 더 좋은 옵션입니다. 경로가 잘못되었거나 파일이 만료된 경우 예외가 발생하므로, 시작 시점에 실패가 즉시 나타나 평가 모드로 조용히 전환되는 것을 방지합니다.

라이선스를 적용하면 워터마크가 사라지고 한 슬라이드 텍스트 추출 제한이 해제됩니다.

## **FAQ**

### 평가 모드에서 여러 스레드에 걸쳐 여러 프레젠테이션을 동시에 테스트할 수 있나요?

예. 서로 다른 문서를 병렬로 처리할 수 있습니다; 동일한 프레젠테이션 객체를 [스레드 간에 공유](/slides/ko/net/multithreading/)해서는 안 됩니다. 평가 모드는 이에 영향을 주지 않습니다.

### 서버나 CI에서 라이브러리를 평가하기 위해 Microsoft PowerPoint를 설치해야 합니까?

아니요. Aspose.Slides는 독립 실행형 엔진으로 평가이든 생산이든 PowerPoint 설치가 필요하지 않습니다.

### 평가 모드에서 PPT/PPTX를 PDF 및 이미지로 변환하는 전체 테스트를 할 수 있나요?

예. [변환기](/slides/ko/net/convert-presentation/)가 작동하며, 출력에 워터마크가 포함됩니다.

### 워터마크 없이 부하 테스트를 위해 임시 라이선스를 사용할 수 있나요?

예. 30일 임시 라이선스를 사용하면 평가 모드 제한이 해제되어 워터마크 없이 테스트할 수 있습니다.
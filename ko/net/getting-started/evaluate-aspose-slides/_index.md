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
description: ".NET용 Aspose.Slides를 평가하고 PowerPoint(PPT, PPTX)와 OpenDocument(ODP) 프레젠테이션을 위한 API 기능을 탐색하세요—무료 평가판을 시작하십시오."
---
## **Aspose.Slides 평가**

Aspose.Slides를 평가용으로 다운로드할 수 있습니다. 평가 패키지는 구매한 패키지와 동일하며, 라이선스를 적용하는 몇 줄의 코드를 추가하면 라이선스가 적용됩니다.

라이선스가 없을 경우, Aspose.Slides는 평가 모드에서 전체 기능을 제공하지만 두 가지 제한이 있습니다: 저장하는 모든 프레젠테이션의 각 슬라이드에 평가 워터마크 텍스트 상자가 추가되고, 프레젠테이션에서 코드를 통해 읽어오는 텍스트는 처음 몇 문자만 표시되고 평가 제한 안내가 뒤에 붙습니다. 코드를 통해 쓰는 텍스트는 전체가 저장됩니다.

![평가 워터마크가 있는 슬라이드](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
평가 버전 제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [임시 라이선스를 얻는 방법?](https://purchase.aspose.com/temporary-license) 를 참고하세요.
{{% /alert %}}

## **평가 패키지 설치**

```bash
dotnet add package Aspose.Slides.NET
```

Linux 및 macOS에서는 Aspose.Slides.NET6.CrossPlatform 패키지를 대신 사용할 수 있습니다; 자세한 내용은 [설치](/slides/ko/net/installation/) 를 참조하십시오.

## **라이선스 적용**

평가 패키지를 라이선스가 적용된 패키지로 전환하는 "몇 줄의 코드"입니다. `Presentation` 객체가 생성되기 전에 애플리케이션 시작 시 한 번 라이선스를 적용하십시오 — 이전에 만든 프레젠테이션은 평가 워터마크를 유지합니다.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense`는 `Stream`도 받아들입니다. 이는 라이선스가 파일이 아니라 포함된 리소스로 제공될 때 더 좋은 옵션입니다. 경로가 잘못되었거나 파일이 만료된 경우 호출이 예외를 발생시키므로, 실패가 즉시 시작 시점에 드러나 평가 모드로 조용히 전환되는 것을 방지합니다.

라이선스를 적용하면 저장된 프레젠테이션에 더 이상 워터마크가 표시되지 않으며, 텍스트가 전체로 읽혀집니다.

## **FAQ**

### 평가 모드에서 여러 스레드에 걸쳐 여러 프레젠테이션을 병렬로 테스트할 수 있나요?

예. 서로 다른 문서를 병렬로 처리할 수 있지만 동일한 프레젠테이션 객체를 [스레드 간](/slides/ko/net/multithreading/)에 공유해서는 안 됩니다. 평가 모드가 이를 제한하지는 않습니다.

### 서버나 CI에서 라이브러리를 평가하기 위해 Microsoft PowerPoint를 설치해야 하나요?

아니요. Aspose.Slides는 독립형 엔진이며 평가든 프로덕션이든 PowerPoint 설치가 필요하지 않습니다.

### 평가 모드에서 PPT/PPTX를 PDF 및 이미지로 변환하는 기능을 완전히 테스트할 수 있나요?

예. [컨버터](/slides/ko/net/convert-presentation/)가 작동하며, 출력물에 워터마크가 포함됩니다.

### 워터마크 없이 부하 테스트를 위해 임시 라이선스를 사용할 수 있나요?

예. 30일 임시 라이선스는 평가 모드 제한을 제거하고 워터마크 없이 테스트할 수 있게 해줍니다.
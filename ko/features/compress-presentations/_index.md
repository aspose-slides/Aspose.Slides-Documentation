---
title: 프레젠테이션 압축
description: 이미지를 압축하고 사용되지 않은 콘텐츠를 제거하여 프레젠테이션 크기를 줄입니다.
type: docs
url: /ko/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: 작업
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **개요**

그림을 압축하고, 더 이상 필요하지 않은 경우 잘린 이미지 영역을 제거하며, 저장하기 전에 프레젠테이션 압축 설정을 선택합니다. 대용량 사진이나 반복되는 미디어가 포함된 프레젠테이션에 유용합니다. 절감량은 내용과 선택한 설정에 따라 다릅니다.

## **사용 예시**

이 C# 예제는 `input.pptx`를 로드하고, 프레젠테이션을 압축한 뒤 `compressed.pptx`로 저장합니다.

Aspose.Slides for .NET 26.11 이상을 사용하십시오. 설정 방법은 [Aspose.Slides for .NET 설치](/slides/ko/net/installation/)를 참조하세요.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **이것은 단일 전체 파일 최적화 스위치인가요?**

Aspose.Slides for .NET 26.11은 [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/)을 추가하여 사용되지 않는 레이아웃/마스터 제거, 임베디드 폰트 서브세팅 및 150‑DPI 이미지 압축을 결합합니다. 잘린 이미지 영역을 영구적으로 제거합니다. 이미지만 처리하려면 [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/)를 사용하고, 보다 세밀한 제어를 원하면 [개별 이미지 압축 예제](/slides/ko/net/examples/optimization-batch/compression/)를 참조하십시오. 이러한 새로운 도우미는 명시된 .NET 버전에만 해당되며, 다른 SDK에 대해서는 해당 가이드를 확인하십시오.

### **이미지 압축이 편집 가능한 텍스트나 차트에 영향을 줍니까?**

이미지 압축은 이미지 데이터에만 적용되며, 편집 가능한 텍스트나 차트 데이터에는 영향을 주지 않습니다. 리사이징이나 재압축으로 인해 이미지 세부 정보가 감소할 수 있으므로 이미지를 검토하십시오.

### **프레젠테이션 이미지 해상도는 어떻게 선택해야 하나요?**

표시되는 이미지 크기와 사용할 화면 또는 인쇄 용도를 기준으로 목표 해상도를 선택하십시오. 대형 디스플레이, 인쇄 및 상세한 도면에는 높은 해상도를 유지하고, 원본을 삭제하기 전에 렌더링된 출력을 비교하십시오.

## **가이드**

- [전체 프레젠테이션 압축 (.NET)](/slides/ko/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [.NET에서 프레젠테이션 이미지 관리 최적화](/slides/ko/net/image/)

관련 기능: [사용되지 않는 마스터, 레이아웃 및 미디어 제거](/slides/ko/features/remove-unused-content/).

## 실행 가능한 .NET 예제

- [프레젠테이션 크기 감소](/slides/ko/net/examples/optimization-batch/compression/)
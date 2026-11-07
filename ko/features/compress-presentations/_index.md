---
title: 프레젠테이션 압축
description: 이미지 압축과 저장 설정으로 프레젠테이션 크기를 줄입니다.
type: docs
url: /ko/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **개요**

그림을 압축하고 더 이상 필요하지 않은 경우 잘라낸 이미지 영역을 제거하며, 저장하기 전에 프레젠테이션 압축 설정을 선택합니다. 이는 대형 사진이나 반복되는 미디어가 포함된 데크에 유용합니다. 절감되는 양은 콘텐츠와 선택한 설정에 따라 달라집니다.

## **사용 예시**

이 C# 예제는 Aspose.Slides for .NET을 사용합니다. 1600 × 900 픽셀 그라디언트 PNG를 눈에 보이게 생성하고, 이를 작은 그림 프레임에 삽입한 뒤 *before.pptx* 로 저장합니다. 그런 다음 해당 그림을 96 DPI 목표 해상도로 압축하고 *compressed.pptx* 로 저장합니다. 두 파일 크기와 미리보기를 비교해 보세요. 절감 효과는 입력 그림과 표시 크기에 따라 달라집니다.

For setup, see [Aspose.Slides for .NET 설치](/slides/ko/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **자주 묻는 질문**

### **전체 파일에 대한 단일 최적화 스위치인가요?**

Aspose.Slides for .NET 26.11에서는 [Compress.CompressPresentation](/slides/ko/net/low-code-presentation-operations/#compress-the-whole-presentation) 기능이 추가되어 사용되지 않은 레이아웃/마스터 제거, 임베디드 폰트 서브셋팅 및 150-DPI 이미지 압축을 결합합니다. 잘라낸 이미지 영역을 영구적으로 삭제합니다. 이미지 전용 처리를 위해서는 Compress.CompressImages를 사용하고, 보다 세밀한 제어가 필요하면 위의 그림별 작업 흐름을 유지하십시오. 이러한 새로운 도우미는 명시된 .NET 버전에만 해당되며, 다른 SDK에 대해서는 해당 가이드를 확인하십시오.

### **이미지 압축이 편집 가능한 텍스트나 차트에 영향을 줍니까?**

그림 압축은 그림 데이터만을 대상으로 하며, 편집 가능한 텍스트나 차트 데이터는 영향을 받지 않습니다. 크기 조정이나 재압축으로 인해 세부 사항이 감소할 수 있으므로 이미지를 검토하십시오.

### **프레젠테이션 이미지의 해상도를 어떻게 선택해야 하나요?**

표시되는 그림 크기와 목표 화면 또는 인쇄 용도를 기준으로 목표 해상도를 선택하십시오. 대형 디스플레이, 인쇄, 상세한 다이어그램의 경우 더 높은 해상도를 유지하고, 원본을 삭제하기 전에 렌더링된 출력을 비교하십시오.

## **가이드**

- [.NET에서 프레젠테이션 이미지 관리 최적화](/slides/ko/net/image/)

Related feature: [사용되지 않는 마스터, 레이아웃 및 미디어 제거](/slides/ko/features/remove-unused-content/).

## 실행 가능한 .NET 예제

- [프레젠테이션 크기 축소](/slides/ko/net/examples/optimization-batch/compression/)
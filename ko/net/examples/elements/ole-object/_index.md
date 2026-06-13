---
title: OLE 개체
type: docs
weight: 210
url: /ko/net/examples/elements/ole-object/
keywords:
- OLE 개체
- OLE 개체 추가
- OLE 개체 액세스
- OLE 개체 제거
- OLE 개체 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 OLE 개체를 처리합니다: C#를 사용하여 PPT, PPTX 및 ODP 프레젠테이션에 삽입, 링크, 업데이트 및 포함된 콘텐츠를 추출합니다."
---
이 문서에서는 파일을 OLE 개체로 삽입하고 **Aspose.Slides for .NET**을 사용하여 해당 데이터를 업데이트하는 방법을 보여줍니다.

## **OLE 개체 추가**

PDF 파일을 프레젠테이션에 삽입합니다.

```csharp
static void AddOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
}
```

## **OLE 개체 액세스**

슬라이드에서 첫 번째 OLE 개체 프레임을 가져옵니다.

```csharp
static void AccessOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## **OLE 개체 제거**

슬라이드에서 삽입된 OLE 개체를 삭제합니다.

```csharp
static void RemoveOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide.Shapes.Remove(oleFrame);
}
```

## **OLE 개체 데이터 업데이트**

기존 OLE 개체에 삽입된 데이터를 교체합니다.

```csharp
static void UpdateOleObjectData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var newData = File.ReadAllBytes("Picture.png");
    var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
    oleFrame.SetEmbeddedData(newDataInfo);
}
```
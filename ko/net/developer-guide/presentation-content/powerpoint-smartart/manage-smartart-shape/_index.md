---
title: ".NET에서 프레젠테이션의 SmartArt 그래픽 관리"
linktitle: "SmartArt 그래픽"
type: docs
weight: 20
url: /ko/net/manage-smartart-shape/
keywords:
- "SmartArt 개체"
- "SmartArt 그래픽"
- "SmartArt 스타일"
- "SmartArt 색상"
- "SmartArt 만들기"
- "SmartArt 추가"
- "SmartArt 편집"
- "SmartArt 변경"
- "SmartArt 접근"
- "SmartArt 레이아웃 유형"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: " .NET에서 Aspose.Slides를 사용하여 PowerPoint SmartArt 생성, 편집 및 스타일링을 자동화하며, 간결한 코드 예제와 성능 중심 가이드를 제공합니다."
---
## **개요**

Aspose.Slides는 프로그래밍 방식으로 PowerPoint 프레젠테이션에서 SmartArt 그래픽을 생성하고 관리할 수 있게 해줍니다. 이 문서에서는 슬라이드에 SmartArt 도형을 추가하고, 기존 SmartArt 도형에 액세스하며, 특정 레이아웃 유형으로 SmartArt를 찾고, SmartArt 스타일이나 색상 스타일을 변경하여 시각적 모양을 업데이트하는 방법을 설명합니다.

예제에서는 프레젠테이션 슬라이드의 도형 컬렉션을 통해 SmartArt 도형을 작업하고, 도형이 SmartArt인지 확인한 후 해당 속성을 수정하거나 검사하는 방법을 보여줍니다.

## **SmartArt 도형 만들기**
Aspose.Slides for .NET은 이제 처음부터 슬라이드에 사용자 정의 SmartArt 도형을 추가할 수 있도록 지원합니다. Aspose.Slides for .NET은 가장 간단한 방법으로 SmartArt 도형을 생성할 수 있는 API를 제공했습니다. 슬라이드에 SmartArt 도형을 만들려면 아래 단계에 따라 진행하십시오:

- [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
- LayoutType을 설정하여 SmartArt 도형을 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
// 프레젠테이션 인스턴스화
using (Presentation pres = new Presentation())
{

    // 프레젠테이션 슬라이드에 액세스
    ISlide slide = pres.Slides[0];

    // Smart Art 도형 추가
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // 프레젠테이션 저장
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **슬라이드에서 SmartArt 도형에 액세스하기**
다음 코드는 프레젠테이션 슬라이드에 추가된 SmartArt 도형에 액세스하는 데 사용됩니다. 샘플 코드에서는 슬라이드 내 모든 도형을 순회하며 해당 도형이 SmartArt인지 확인합니다. 도형이 SmartArt 유형이면 SmartArt 인스턴스로 형변환합니다.

```c#
 // 원하는 프레젠테이션 로드
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // 첫 번째 슬라이드 내부의 모든 도형 순회
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // 도형이 SmartArt 유형인지 확인
        if (shape is ISmartArt)
        {
            // 도형을 SmartArtEx로 형변환
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```

## **특정 Layout Type을 가진 SmartArt 도형에 액세스하기**
다음 샘플 코드는 특정 LayoutType을 가진 SmartArt 도형에 액세스하는 데 도움이 됩니다. SmartArt의 LayoutType은 읽기 전용이며 SmartArt 도형이 추가될 때만 설정되므로 변경할 수 없다는 점에 유의하세요.

- `Presentation` 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.
- 첫 번째 슬라이드 내 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고 SmartArt인 경우 선택한 도형을 SmartArt로 형변환합니다.
- 특정 LayoutType을 가진 SmartArt 도형을 확인하고 이후에 필요한 작업을 수행합니다.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 첫 번째 슬라이드 내부의 모든 도형 순회
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 도형이 SmartArt 유형인지 확인
        if (shape is ISmartArt)
        {
            // 도형을 SmartArtEx로 형변환
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt 레이아웃 확인
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```

## **SmartArt 도형 스타일 변경**
다음 샘플 코드는 특정 LayoutType을 가진 SmartArt 도형에 액세스하는 데 도움이 됩니다.

- `Presentation` 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.
- 첫 번째 슬라이드 내 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고 SmartArt인 경우 선택한 도형을 SmartArt로 형변환합니다.
- 특정 스타일을 가진 SmartArt 도형을 찾습니다.
- SmartArt 도형에 새 스타일을 설정합니다.
- 프레젠테이션을 저장합니다.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 첫 번째 슬라이드 내부의 모든 도형을 순회
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 도형이 SmartArt 유형인지 확인
        if (shape is ISmartArt)
        {
            // 도형을 SmartArtEx로 형변환
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt 스타일 확인
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // SmartArt 스타일 변경
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // 프레젠테이션 저장
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```

## **SmartArt 도형 색상 스타일 변경**
이 예제에서는 任意의 SmartArt 도형에 대해 색상 스타일을 변경하는 방법을 배웁니다. 다음 샘플 코드는 특정 색상 스타일을 가진 SmartArt 도형에 액세스하고 해당 스타일을 변경합니다.

- `Presentation` 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.
- 첫 번째 슬라이드 내 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고 SmartArt인 경우 선택한 도형을 SmartArt로 형변환합니다.
- 특정 색상 스타일을 가진 SmartArt 도형을 찾습니다.
- SmartArt 도형에 새 색상 스타일을 설정합니다.
- 프레젠테이션을 저장합니다.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // 첫 번째 슬라이드 내부의 모든 도형을 순회
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 도형이 SmartArt 유형인지 확인
        if (shape is ISmartArt)
        {
            // 도형을 SmartArtEx로 형변환
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt 색상 유형 확인
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // SmartArt 색상 유형 변경
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // 프레젠테이션 저장
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **자주 묻는 질문**

**SmartArt를 단일 객체로 애니메이션할 수 있나요?**

예. SmartArt는 도형이므로 다른 도형과 마찬가지로 애니메이션 API(입장, 퇴장, 강조, 움직임 경로)를 사용해 [standard animations](/slides/ko/net/powerpoint-animation/)을 적용할 수 있습니다.

**슬라이드에서 내부 ID를 모를 경우 특정 SmartArt를 어떻게 찾을 수 있나요?**

대체 텍스트(AltText)를 설정하고 해당 값을 사용해 도형을 검색하면 됩니다—이 방법이 대상 도형을 찾는 권장 방법입니다.

**SmartArt를 다른 도형과 그룹화할 수 있나요?**

예. SmartArt를 다른 도형(그림, 표 등)과 그룹화한 다음 [manipulate the group](/slides/ko/net/group/)을 사용할 수 있습니다.

**특정 SmartArt의 이미지(예: 미리보기 또는 보고서)를 어떻게 얻나요?**

도형의 썸네일/이미지를 내보냅니다; 라이브러리는 [render individual shapes](/slides/ko/net/create-shape-thumbnails/)을 사용해 래스터 파일(PNG/JPG/TIFF)로 변환할 수 있습니다.

**전체 프레젠테이션을 PDF로 변환할 때 SmartArt 모양이 유지되나요?**

예. 렌더링 엔진은 [PDF export](/slides/ko/net/convert-powerpoint-to-pdf/) 시 높은 충실도를 목표로 하며, 다양한 품질 및 호환성 옵션을 제공합니다.
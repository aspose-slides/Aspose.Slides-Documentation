---
title: ".NET에서 프레젠테이션 도형 관리"
linktitle: "도형 조작"
type: docs
weight: 40
url: /ko/net/shape-manipulations/
keywords:
- "PowerPoint 도형"
- "프레젠테이션 도형"
- "슬라이드의 도형"
- "도형 찾기"
- "도형 복제"
- "도형 삭제"
- "도형 숨기기"
- "도형 순서 변경"
- "Interop 도형 ID 가져오기"
- "도형 대체 텍스트"
- "도형 레이아웃 형식"
- "SVG 형식 도형"
- "도형을 SVG로"
- "도형 정렬"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET에서 도형을 만들고, 편집하고, 최적화하여 고성능 PowerPoint 프레젠테이션을 제공하는 방법을 배웁니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션에서 도형을 처리하는 방법을 설명합니다. 슬라이드에서 도형을 찾고, 복제하고, 삭제하고, 숨기고, 순서를 변경하고, Interop 도형 ID를 가져오며, 식별 및 추가 처리를 위해 대체 텍스트를 설정하는 방법을 보여줍니다.

또한 도형의 레이아웃 형식에 접근하고, 도형을 SVG로 렌더링하며, 슬라이드에서 도형을 정렬하고, 수평·수직 뒤집기 속성을 사용하는 방법도 다룹니다. 마지막으로 도형 결합, 쌓기 순서, 도형 잠금에 관한 짧은 FAQ도 포함되어 있습니다.

## **슬라이드에서 도형 찾기**
이 항목에서는 개발자가 내부 Id를 사용하지 않고 슬라이드에서 특정 도형을 쉽게 찾을 수 있는 간단한 기술을 설명합니다. PowerPoint 프레젠테이션 파일에는 내부 고유 Id 외에 슬라이드에 있는 도형을 식별하는 방법이 없습니다. 개발자가 내부 고유 Id로 도형을 찾는 것은 어려울 수 있습니다. 모든 도형에는 일부 대체 텍스트가 포함됩니다. 특정 도형을 찾기 위해 대체 텍스트를 사용할 것을 권장합니다. 향후 변경할 객체에 대한 대체 텍스트는 MS PowerPoint에서 정의할 수 있습니다.

원하는 도형의 대체 텍스트를 설정한 후 Aspose.Slides for .NET으로 해당 프레젠테이션을 열고 슬라이드에 추가된 모든 도형을 순회할 수 있습니다. 순회 중에 도형의 대체 텍스트를 확인하고 일치하는 텍스트를 가진 도형이 필요한 도형이 됩니다. 이 기술을 보다 명확히 보여주기 위해, 슬라이드에서 특정 도형을 찾아 반환하는 메서드 [FindShape](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/findshape/#findshape_1)를 만들었습니다.

```c#
public static void Run()
{
    // 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // 찾고자 하는 도형의 대체 텍스트
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// 대체 텍스트를 사용하여 슬라이드에서 도형을 찾는 메서드 구현
public static IShape FindShape(ISlide slide, string alttext)
{
    // 슬라이드 내부의 모든 도형을 순회합니다
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // 슬라이드의 대체 텍스트가 요구되는 텍스트와 일치하면
        // 도형을 반환합니다
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```

## **도형 복제**
Aspose.Slides for .NET을 사용하여 슬라이드에 도형을 복제하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
1. 원본 슬라이드의 도형 컬렉션에 접근합니다.
1. 프레젠테이션에 새 슬라이드를 추가합니다.
1. 원본 슬라이드 도형 컬렉션에서 새 슬라이드로 도형을 복제합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 슬라이드에 그룹 도형을 추가합니다.

```c#
// Presentation 클래스를 인스턴스화합니다
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// PPTX 파일을 디스크에 저장합니다
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```

## **도형 삭제**
Aspose.Slides for .NET을 사용하면 개발자가 모든 도형을 삭제할 수 있습니다. 슬라이드에서 도형을 삭제하려면 다음 단계를 따르십시오:

1. `Presentation` 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 특정 AlternativeText를 가진 도형을 찾습니다.
1. 도형을 삭제합니다.
1. 파일을 디스크에 저장합니다.

```c#
// Presentation 객체를 생성합니다
Presentation pres = new Presentation();

// 첫 번째 슬라이드를 가져옵니다
ISlide sld = pres.Slides[0];

// 사각형 유형의 자동 도형을 추가합니다
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// 프레젠테이션을 디스크에 저장합니다
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```

## **도형 숨기기**
Aspose.Slides for .NET을 사용하면 개발자가 모든 도형을 숨길 수 있습니다. 슬라이드에서 도형을 숨기려면 다음 단계를 따르십시오:

1. `Presentation` 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 특정 AlternativeText를 가진 도형을 찾습니다.
1. 도형을 숨깁니다.
1. 파일을 디스크에 저장합니다.

```c#
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();

// 첫 번째 슬라이드를 가져옵니다
ISlide sld = pres.Slides[0];

// 사각형 유형의 자동 도형을 추가합니다
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// 프레젠테이션을 디스크에 저장합니다
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```

## **도형 순서 변경**
Aspose.Slides for .NET을 사용하면 개발자가 도형의 순서를 재배열할 수 있습니다. 순서를 재배열하면 어떤 도형이 앞에, 어떤 도형이 뒤에 표시될지 지정할 수 있습니다. 슬라이드에서 도형 순서를 변경하려면 다음 단계를 따르십시오:

1. `Presentation` 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 도형을 추가합니다.
1. 도형 텍스트 프레임에 텍스트를 입력합니다.
1. 동일한 좌표에 또 다른 도형을 추가합니다.
1. 도형들의 순서를 재배열합니다.
1. 파일을 디스크에 저장합니다.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```

## **Interop 도형 ID 가져오기**
Aspose.Slides for .NET을 사용하면 슬라이드 범위에서 고유한 도형 식별자를 가져올 수 있습니다. 이는 프레젠테이션 범위에서 고유 식별자를 제공하는 UniqueId 속성과 대조됩니다. IShape 인터페이스와 Shape 클래스에 OfficeInteropShapeId 속성이 추가되었습니다. OfficeInteropShapeId 속성이 반환하는 값은 Microsoft.Office.Interop.PowerPoint.Shape 객체의 Id 값과 동일합니다. 아래에 샘플 코드가 제공됩니다.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// 슬라이드 범위에서 고유한 도형 식별자 가져오기
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```

## **도형에 대체 텍스트 설정**
Aspose.Slides for .NET을 사용하면 개발자가 모든 도형의 AlternateText를 설정할 수 있습니다. 프레젠테이션의 도형은 AlternativeText 또는 Shape Name 속성을 통해 구분할 수 있습니다. AlternativeText 속성은 Aspose.Slides와 Microsoft PowerPoint 모두에서 읽고 쓸 수 있습니다. 이 속성을 사용하면 도형에 태그를 지정하고 도형 삭제, 도형 숨기기, 슬라이드에서 도형 재정렬과 같은 다양한 작업을 수행할 수 있습니다. 도형의 AlternateText를 설정하려면 다음 단계를 따르십시오:

1. `Presentation` 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 슬라이드에 임의의 도형을 추가합니다.
1. 새로 추가한 도형으로 작업을 수행합니다.
1. 도형을 순회하며 원하는 도형을 찾습니다.
1. AlternativeText를 설정합니다.
1. 파일을 디스크에 저장합니다.

```c#
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();

// 첫 번째 슬라이드를 가져옵니다
ISlide sld = pres.Slides[0];

// 사각형 유형의 자동 도형을 추가합니다
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// 프레젠테이션을 디스크에 저장합니다
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```

## **도형에 대한 레이아웃 형식 접근**
Aspose.Slides for .NET은 도형에 대한 레이아웃 형식에 접근하기 위한 간단한 API를 제공합니다. 이 문서는 레이아웃 형식에 접근하는 방법을 보여줍니다.

아래에 샘플 코드가 제공됩니다.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **도형을 SVG로 렌더링**
이제 Aspose.Slides for .NET은 도형을 SVG로 렌더링하는 기능을 지원합니다. Shape 클래스를 비롯해 IShape 인터페이스에 WriteAsSvg 메서드(및 오버로드)가 추가되었습니다. 이 메서드를 사용하면 도형의 내용을 SVG 파일로 저장할 수 있습니다. 아래 코드 조각은 슬라이드의 도형을 SVG 파일로 내보내는 방법을 보여줍니다.

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **도형 정렬**

[SlidesUtil.AlignShape()](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/methods/alignshapes/index) 오버로드 메서드를 통해 다음을 수행할 수 있습니다

* 슬라이드 여백을 기준으로 도형을 정렬합니다. 예제 1을 참고하십시오.
* 서로를 기준으로 도형을 정렬합니다. 예제 2를 참고하십시오.

[ShapesAlignmentType](https://reference.aspose.com/slides/ko/net/aspose.slides/shapesalignmenttype) 열거형은 사용 가능한 정렬 옵션을 정의합니다.

**예제 1**

다음 C# 코드는 인덱스 1, 2, 4인 도형을 슬라이드 상단 경계에 맞춰 정렬하는 방법을 보여줍니다.
아래 소스 코드는 인덱스 1, 2, 4인 도형을 슬라이드 상단 경계에 정렬합니다.

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**예제 2**

다음 C# 코드는 컬렉션에 포함된 모든 도형을 컬렉션 안의 가장 아래 도형을 기준으로 정렬하는 방법을 보여줍니다:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **뒤집기 속성**

Aspose.Slides에서 [ShapeFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/shapeframe/) 클래스는 `FlipH`와 `FlipV` 속성을 통해 도형의 수평 및 수직 미러링을 제어합니다. 두 속성은 [NullableBool](https://reference.aspose.com/slides/ko/net/aspose.slides/nullablebool/) 타입이며, `True`는 뒤집기, `False`는 그대로, `NotDefined`는 기본 동작을 의미합니다. 이러한 값은 도형의 [Frame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/frame/)에서 접근할 수 있습니다.

뒤집기 설정을 변경하려면 현재 위치와 크기, 원하는 `FlipH`·`FlipV` 값 및 회전 각도를 사용하여 새로운 [ShapeFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/shapeframe/) 인스턴스를 만든 뒤, 해당 인스턴스를 도형의 [Frame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/frame/)에 할당하고 프레젠테이션을 저장하면 미러 변환이 적용됩니다.

예를 들어, 첫 번째 슬라이드에 기본 뒤집기 설정을 가진 단일 도형이 포함된 sample.pptx 파일이 있다고 가정합니다.

![The shape to be flipped](shape_to_be_flipped.png)

다음 코드 예제는 도형의 현재 뒤집기 속성을 가져와 수평·수직 모두 뒤집습니다.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // 도형의 수평 뒤집기 속성을 가져옵니다.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // 도형의 수직 뒤집기 속성을 가져옵니다.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Flip horizontally.
    NullableBool flipV = NullableBool.True; // Flip vertically.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

결과:

![The flipped shape](flipped_shape.png)

## **FAQ**

**슬라이드에서 도형을 (union/intersect/subtract)와 같이 결합할 수 있나요?**

내장된 Boolean 연산 API는 없습니다. 원하는 외곽선을 직접 구성하여 근사화할 수 있습니다—예를 들어 [GeometryPath](https://reference.aspose.com/slides/ko/net/aspose.slides/geometrypath/)를 사용해 결과 기하를 계산하고 해당 윤곽으로 새 도형을 만든 뒤 원본을 삭제하는 방식입니다.

**도형이 항상 “위에” 있게 하려면 z‑order를 어떻게 제어하나요?**

슬라이드의 [shapes](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslide/shapes/) 컬렉션 내 삽입/이동 순서를 변경합니다. 예측 가능한 결과를 위해 다른 슬라이드 수정이 모두 끝난 후 z‑order를 최종 지정하십시오.

**PowerPoint에서 사용자가 도형을 편집하지 못하도록 “잠그는” 방법이 있나요?**

예. [shape-level protection flags](/slides/ko/net/applying-protection-to-presentation/)를 설정하면 선택, 이동, 크기 조절, 텍스트 편집 등을 잠글 수 있습니다. 필요에 따라 마스터 또는 레이아웃에 제한을 적용할 수도 있습니다. 이는 UI 수준 보호이며 보안 기능은 아닙니다; 더 강력한 보호가 필요하면 [read‑only 권고 또는 비밀번호](/slides/ko/net/password-protected-presentation/)와 같은 파일 수준 제한과 결합하십시오.
---
title: 프레젠테이션 잠금
type: docs
weight: 110
url: /ko/net/presentation-locking/
---
## **프레젠테이션 잠금**
자동화된 워크플로의 일환으로 Microsoft PowerPoint 2007 (PPTX) 프레젠테이션을 만들고, 업데이트하고, 저장하는 것이 **Aspose.Slides**의 일반적인 사용 사례입니다. 이렇게 Aspose.Slides를 사용하는 애플리케이션의 사용자는 출력 프레젠테이션에 접근할 수 있습니다. 편집으로부터 보호하는 것이 일반적인 고민입니다. 자동 생성된 프레젠테이션이 원래 형식과 내용을 유지하는 것이 중요합니다.

이 문서는 프레젠테이션과 슬라이드가 어떻게 구성되는지, 그리고 Aspose.Slides for .NET이 프레젠테이션에 보호를 적용하고 제거하는 방법을 설명합니다. 이 기능은 Aspose.Slides만의 고유 기능이며 작성 시점에서는 Microsoft PowerPoint에서 제공되지 않습니다. 이를 통해 개발자는 애플리케이션이 생성한 프레젠테이션이 사용되는 방식을 제어할 수 있습니다.
## **슬라이드 구성**
PPTX 슬라이드는 자동 도형, 표, OLE 객체, 그룹화된 도형, 그림 프레임, 비디오 프레임, 연결선 및 프레젠테이션을 구성하는 데 사용되는 다양한 요소 등 여러 구성요소로 이루어집니다.

Aspose.Slides for .NET에서는 슬라이드의 각 요소가 Shape 객체로 변환됩니다. 다시 말해, 슬라이드의 각 요소는 Shape 객체이거나 Shape 객체에서 파생된 객체입니다.

PPTX의 구조는 복잡하기 때문에, 모든 종류의 도형에 일반 잠금을 사용할 수 있는 PPT와 달리, 도형 유형에 따라 서로 다른 잠금 유형이 존재합니다. BaseShapeLock 클래스는 일반 PPTX 잠금 클래스입니다. Aspose.Slides for .NET에서 PPTX에 지원되는 잠금 유형은 다음과 같습니다.

- AutoShapeLock은 자동 도형을 잠급니다.
- ConnectorLock은 연결선 도형을 잠급니다.
- GraphicalObjectLock은 그래픽 객체를 잠급니다.
- GroupshapeLock은 그룹 도형을 잠급니다.
- PictureFrameLock은 그림 프레임을 잠급니다.

Presentation 객체 내의 모든 Shape 객체에 수행된 작업은 전체 프레젠테이션에 적용됩니다.
## **보호 적용 및 제거**
보호를 적용하면 프레젠테이션을 편집할 수 없게 됩니다. 이는 프레젠테이션 내용 보호에 유용한 기술입니다.

**PPTX 도형에 보호 적용**

Aspose.Slides for .NET은 슬라이드의 도형을 처리하기 위해 Shape 클래스를 제공합니다.

앞서 언급했듯이, 각 도형 클래스에는 보호를 위한 관련 Shape lock 클래스가 있습니다. 이 문서에서는 NoSelect, NoMove 및 NoResize 잠금에 중점을 둡니다. 이러한 잠금은 도형을 선택할 수 없게(마우스 클릭이나 기타 선택 방법을 통해) 하며, 이동하거나 크기를 조정할 수도 없게 합니다.

다음 코드 샘플은 프레젠테이션의 모든 도형 유형에 보호를 적용합니다.

``` csharp

 //PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다


 //프레젠테이션의 슬라이드에 접근하기 위한 ISlide 객체

SlideEx slide = pTemplate.Slides[0];

//임시 도형을 보관하기 위한 IShape 객체

ShapeEx shape;

//프레젠테이션의 모든 슬라이드를 순회합니다

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	 //슬라이드의 모든 도형을 순회합니다

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//도형이 자동 도형인 경우

		if (shape is AutoShapeEx)

		{

			//자동 도형으로 형 변환하고 자동 도형 잠금을 가져옵니다

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//도형 잠금을 적용합니다

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//도형이 그룹 도형인 경우

		else if (shape is GroupShapeEx)

		{

			//그룹 도형으로 형 변환하고 그룹 도형 잠금을 가져옵니다

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//도형 잠금을 적용합니다

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//도형이 연결선인 경우

		else if (shape is ConnectorEx)

		{

			//연결선 도형으로 형 변환하고 연결선 도형 잠금을 가져옵니다

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//도형 잠금을 적용합니다

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//도형이 그림 프레임인 경우

		else if (shape is PictureFrameEx)

		{

			//그림 프레임 도형으로 형 변환하고 그림 프레임 도형 잠금을 가져옵니다

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//도형 잠금을 적용합니다

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//프레젠테이션 파일을 저장합니다

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**보호 제거**

Aspose.Slides for .NET을 사용하여 적용된 보호는 Aspose.Slides for .NET으로만 제거할 수 있습니다. 도형의 잠금을 해제하려면 적용된 잠금 값을 false로 설정하면 됩니다. 다음 코드 샘플은 잠긴 프레젠테이션에서 도형을 해제하는 방법을 보여줍니다.

``` csharp

 //원하는 프레젠테이션을 엽니다
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//프레젠테이션의 슬라이드에 접근하기 위한 ISlide 객체
SlideEx slide = pTemplate.Slides[0];

//임시 도형을 보관하기 위한 IShape 객체
ShapeEx shape;

//프레젠테이션의 모든 슬라이드를 순회합니다
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
		//슬라이드의 모든 도형을 순회합니다
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//도형이 자동 도형인 경우
		if (shape is AutoShapeEx)
		{
			//자동 도형으로 형 변환하고 자동 도형 잠금을 가져옵니다
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//도형 잠금을 적용합니다
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//도형이 그룹 도형인 경우
		else if (shape is GroupShapeEx)
		{
			//그룹 도형으로 형 변환하고 그룹 도형 잠금을 가져옵니다
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//도형 잠금을 적용합니다
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//도형이 연결선인 경우
		else if (shape is ConnectorEx)
		{
			//연결선 도형으로 형 변환하고 연결선 도형 잠금을 가져옵니다
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//도형 잠금을 적용합니다
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//도형이 그림 프레임인 경우
		else if (shape is PictureFrameEx)
		{
			//그림 프레임 도형으로 형 변환하고 그림 프레임 도형 잠금을 가져옵니다
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//도형 잠금을 적용합니다
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//프레젠테이션 파일을 저장합니다
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **샘플 코드 다운로드**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)
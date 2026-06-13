---
title: .NET에서 프레젠테이션의 SmartArt 도형 노드 관리
linktitle: SmartArt 도형 노드
type: docs
weight: 30
url: /ko/net/manage-smartart-shape-node/
keywords:
- SmartArt 노드
- 자식 노드
- 노드 추가
- 노드 위치
- 노드 접근
- 노드 제거
- 사용자 정의 위치
- 보조 노드
- 채우기 형식
- 노드 렌더링
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PPT 및 PPTX의 SmartArt 도형 노드를 관리합니다. 프레젠테이션을 효율화할 수 있는 명확한 코드 샘플과 팁을 제공합니다."
---
## **개요**

PowerPoint 프레젠테이션의 SmartArt 그래픽은 텍스트를 포함하고 다이어그램 구조를 정의하는 노드로 구성됩니다. Aspose.Slides를 사용하면 이러한 SmartArt 노드를 프로그래밍 방식으로 작업할 수 있습니다: 새 노드와 자식 노드 추가, 특정 위치에 자식 노드 삽입, 기존 노드 접근, 그리고 텍스트, 레벨, 위치를 읽을 수 있습니다.

이 문서는 SmartArt 도형 노드를 관리하는 방법을 설명합니다. 노드 제거, 인덱스 또는 위치 기반 자식 노드 작업, 보조 노드를 일반 노드로 변경, SmartArt 노드 도형의 위치·크기·회전 조정, 노드 채우기 형식 설정, SmartArt 자식 노드에 대한 썸네일 이미지 생성 방법을 보여줍니다.

## **SmartArt 노드 추가**
Aspose.Slides for .NET은 SmartArt 도형을 가장 쉽게 관리할 수 있는 가장 단순한 API를 제공합니다. 다음 샘플 코드는 SmartArt 도형에 노드와 자식 노드를 추가하는 방법을 보여줍니다.

- SmartArt Shape가 포함된 프레젠테이션을 로드하고 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
- 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.  
- 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.  
- 도형이 SmartArt 유형인지 확인하고 SmartArt인 경우 선택된 도형을 SmartArt으로 형변환합니다.  
- SmartArt 도형의 NodeCollection에 새 Node를 추가하고 TextFrame에 텍스트를 설정합니다.  
- 이제 새로 추가된 SmartArt Node에 자식 Node를 추가하고 TextFrame에 텍스트를 설정합니다.  
- 프레젠테이션을 저장합니다.

```c#
 // 원하는 프레젠테이션 로드
 Presentation pres = new Presentation("AddNodes.pptx");

 // 첫 번째 슬라이드의 모든 도형 순회
 foreach (IShape shape in pres.Slides[0].Shapes)
 {
 
     // 도형이 SmartArt 유형인지 확인
     if (shape is Aspose.Slides.SmartArt.SmartArt)
     {
 
         // 도형을 SmartArt으로 형변환
         Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
 
         // 새로운 SmartArt 노드 추가
         Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();
 
         // 텍스트 추가
         TemNode.TextFrame.Text = "Test";
 
         // 부모 노드에 새로운 자식 노드 추가. 컬렉션 끝에 추가됩니다
         Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();
 
         // 텍스트 추가
         newNode.TextFrame.Text = "New Node Added";
 
     }
 }
 
 // 프레젠테이션 저장
 pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **특정 위치에 SmartArt 노드 추가**
다음 샘플 코드는 SmartArt 도형의 해당 노드에 속한 자식 노드를 특정 위치에 추가하는 방법을 설명합니다.

- `Presentation` 클래스의 인스턴스를 생성합니다.  
- 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.  
- 접근한 슬라이드에 StackedList 유형 SmartArt 도형을 추가합니다.  
- 추가된 SmartArt 도형에서 첫 번째 Node에 접근합니다.  
- 이제 선택된 Node에 대해 위치 2에 자식 Node를 추가하고 텍스트를 설정합니다.  
- 프레젠테이션을 저장합니다.

```c#
 // 프레젠테이션 인스턴스 생성
 Presentation pres = new Presentation();

 // 프레젠테이션 슬라이드에 접근
 ISlide slide = pres.Slides[0];

 // Smart Art IShape 추가
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // 인덱스 0에서 SmartArt 노드에 접근
 ISmartArtNode node = smart.AllNodes[0];

 // 부모 노드에서 위치 2에 새 자식 노드 추가
 SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

 // 텍스트 추가
 chNode.TextFrame.Text = "Sample Text Added";

 // 프레젠테이션 저장
 pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **SmartArt 노드 접근**
다음 샘플 코드는 SmartArt 도형 내부의 노드에 접근하는 방법을 보여줍니다. SmartArt의 LayoutType은 읽기 전용이며 SmartArt 도형이 추가될 때만 설정된다는 점에 유의하십시오.

- `Presentation` 클래스의 인스턴스를 생성하고 SmartArt Shape가 포함된 프레젠테이션을 로드합니다.  
- 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.  
- 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.  
- 도형이 SmartArt 유형인지 확인하고 SmartArt인 경우 선택된 도형을 SmartArt으로 형변환합니다.  
- SmartArt Shape 내부의 모든 Node를 순회합니다.  
- SmartArt Node 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```c#
  // 원하는 프레젠테이션 로드
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // 첫 번째 슬라이드의 모든 도형 순회
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // 도형이 SmartArt 유형인지 확인
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // 도형을 SmartArt으로 형변환
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // SmartArt 내부의 모든 노드 순회
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // 인덱스 i에 있는 SmartArt 노드에 접근
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // SmartArt 노드 매개변수 출력
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

## **SmartArt 자식 노드 접근**
다음 샘플 코드는 SmartArt 도형의 해당 노드에 속한 자식 노드에 접근하는 방법을 보여줍니다.

- `PresentationEx` 클래스의 인스턴스를 생성하고 SmartArt Shape가 포함된 프레젠테이션을 로드합니다.  
- 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.  
- 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.  
- 도형이 SmartArt 유형인지 확인하고 SmartArt인 경우 선택된 도형을 SmartArtEx로 형변환합니다.  
- SmartArt Shape 내부의 모든 Node를 순회합니다.  
- 선택된 SmartArt 도형 Node마다 특정 Node 내부의 모든 자식 Node를 순회합니다.  
- 자식 Node 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```c#
 // 원하는 프레젠테이션 로드
 Presentation pres = new Presentation("AccessChildNodes.pptx");
 
 // 첫 번째 슬라이드 내부의 모든 도형 순회
 foreach (IShape shape in pres.Slides[0].Shapes)
 {
 
     // 도형이 SmartArt 유형인지 확인
     if (shape is Aspose.Slides.SmartArt.SmartArt)
     {
 
         // 도형을 SmartArt으로 형변환
         Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
 
         // SmartArt 내부의 모든 노드 순회
         for (int i = 0; i < smart.AllNodes.Count; i++)
         {
             // 인덱스 i에 있는 SmartArt 노드에 접근
             Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
 
             // 인덱스 i에 있는 SmartArt 노드의 자식 노드 순회
             for (int j = 0; j < node0.ChildNodes.Count; j++)
             {
                 // SmartArt 노드의 자식 노드에 접근
                 Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];
 
                 // SmartArt 자식 노드 매개변수 출력
                 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                 Console.WriteLine(outString);
             }
         }
     }
 }
```

## **특정 위치에 SmartArt 자식 노드 접근**
이 예제에서는 SmartArt 도형의 해당 노드에 속한 특정 위치의 자식 노드에 접근하는 방법을 배웁니다.

- `Presentation` 클래스의 인스턴스를 생성합니다.  
- 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.  
- StackedList 유형 SmartArt 도형을 추가합니다.  
- 추가된 SmartArt 도형에 접근합니다.  
- 인덱스 0에 해당하는 Node에 접근합니다.  
- 이제 GetNodeByPosition() 메서드를 사용하여 해당 SmartArt Node의 위치 1에 있는 자식 Node에 접근합니다.  
- 자식 Node 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```c#
// 프레젠테이션 인스턴스화
Presentation pres = new Presentation();

// 첫 번째 슬라이드에 접근
ISlide slide = pres.Slides[0];

// 첫 번째 슬라이드에 SmartArt 도형 추가
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// SmartArt 노드 인덱스 0에 접근
ISmartArtNode node = smart.AllNodes[0];

// 부모 노드에서 위치 1에 있는 자식 노드에 접근
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// SmartArt 자식 노드 매개변수 출력
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```

## **SmartArt 노드 제거**
이 예제에서는 SmartArt 도형 내부의 노드를 제거하는 방법을 배웁니다.

- `Presentation` 클래스의 인스턴스를 생성하고 SmartArt Shape가 포함된 프레젠테이션을 로드합니다.  
- 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.  
- 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.  
- 도형이 SmartArt 유형인지 확인하고 SmartArt인 경우 선택된 도형을 SmartArt으로 형변환합니다.  
- SmartArt에 0개 이상의 Node가 있는지 확인합니다.  
- 삭제할 SmartArt Node를 선택합니다.  
- 이제 RemoveNode() 메서드를 사용하여 선택된 Node를 제거하고 프레젠테이션을 저장합니다.

```c#
// 원하는 프레젠테이션 로드
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{
 
    // 첫 번째 슬라이드 내부의 모든 도형 순회
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
 
        // 도형이 SmartArt 유형인지 확인
        if (shape is ISmartArt)
        {
            // 도형을 SmartArtEx로 형변환
            ISmartArt smart = (ISmartArt)shape;
 
            if (smart.AllNodes.Count > 0)
            {
                // 인덱스 0에 있는 SmartArt 노드에 접근
                ISmartArtNode node = smart.AllNodes[0];
 
                // 선택된 노드 제거
                smart.AllNodes.RemoveNode(node);
 
            }
        }
    }
 
    // 프레젠테이션 저장
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **특정 위치에 SmartArt 노드 제거**
이 예제에서는 특정 위치에서 SmartArt 도형 내부의 노드를 제거하는 방법을 배웁니다.

- `Presentation` 클래스의 인스턴스를 생성하고 SmartArt Shape가 포함된 프레젠테이션을 로드합니다.  
- 인덱스를 사용하여 첫 번째 슬라이드에 대한 참조를 가져옵니다.  
- 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.  
- 도형이 SmartArt 유형인지 확인하고 SmartArt인 경우 선택된 도형을 SmartArt으로 형변환합니다.  
- 인덱스 0에 해당하는 SmartArt 도형 Node를 선택합니다.  
- 이제 선택된 SmartArt Node에 2개 이상의 자식 Node가 있는지 확인합니다.  
- RemoveNodeByPosition() 메서드를 사용하여 위치 1에 있는 Node를 제거합니다.  
- 프레젠테이션을 저장합니다.

```c#
// 원하는 프레젠테이션 로드             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// 첫 번째 슬라이드 내부의 모든 도형 순회
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // 도형이 SmartArt 유형인지 확인
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // 도형을 SmartArt으로 형변환
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // 인덱스 0에 있는 SmartArt 노드에 접근
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // 위치 1에 있는 자식 노드 제거
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// 프레젠테이션 저장
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **SmartArt 객체에서 자식 Node에 사용자 정의 위치 지정**
이제 Aspose.Slides for .NET은 SmartArtShape의 X 및 Y 속성 설정을 지원합니다. 아래 코드 스니펫은 사용자 정의 SmartArtShape 위치, 크기 및 회전을 설정하는 방법을 보여주며, 새 노드를 추가하면 모든 노드의 위치와 크기가 다시 계산된다는 점에 유의하세요.

```c#
// 원하는 프레젠테이션 로드
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// SmartArt 도형을 새 위치로 이동
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// SmartArt 도형의 너비 변경
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// SmartArt 도형의 높이 변경
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// SmartArt 도형의 회전 변경
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```

## **보조 노드 확인**
다음 샘플 코드는 SmartArt 노드 컬렉션에서 보조 노드를 식별하고 이를 변경하는 방법을 조사합니다.

- `PresentationEx` 클래스의 인스턴스를 생성하고 SmartArt Shape가 포함된 프레젠테이션을 로드합니다.  
- 인덱스를 사용하여 두 번째 슬라이드에 대한 참조를 가져옵니다.  
- 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.  
- 도형이 SmartArt 유형인지 확인하고 SmartArt인 경우 선택된 도형을 SmartArtEx로 형변환합니다.  
- SmartArt Shape 내부의 모든 Node를 순회하면서 보조 노드인지 확인합니다.  
- 보조 노드의 상태를 일반 노드로 변경합니다.  
- 프레젠테이션을 저장합니다.

```c#
// 프레젠테이션 인스턴스 생성
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // 첫 번째 슬라이드 내부의 모든 도형 순회
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // 도형이 SmartArt 유형인지 확인
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // 도형을 SmartArtEx로 형변환
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // SmartArt 도형의 모든 노드 순회

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // 노드가 보조 노드인지 확인
                if (node.IsAssistant)
                {
                    // 보조 노드를 false로 설정하고 일반 노드로 변경
                    node.IsAssistant = false;
                }
            }
        }
    }
    // 프레젠테이션 저장
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Node의 채우기 형식 설정**
Aspose.Slides for .NET을 사용하면 사용자 지정 SmartArt 도형을 추가하고 채우기 형식을 설정할 수 있습니다. 이 문서는 SmartArt 도형을 만들고 접근하여 채우기 형식을 설정하는 방법을 설명합니다.

아래 단계를 따르세요:

- `Presentation` 클래스의 인스턴스를 생성합니다.  
- 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.  
- LayoutType을 설정하여 SmartArt 도형을 추가합니다.  
- SmartArt 도형 Node에 대한 FillFormat을 설정합니다.  
- 수정된 프레젠테이션을 PPTX 파일로 기록합니다.

```c#
using (Presentation presentation = new Presentation())
{
    // 슬라이드에 접근
    ISlide slide = presentation.Slides[0];

    // SmartArt 도형과 노드 추가
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // 노드 채우기 색상 설정
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // 프레젠테이션 저장
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```

## **SmartArt 자식 Node 썸네일 생성**
아래 단계에 따라 SmartArt 자식 Node의 썸네일을 생성할 수 있습니다.

1. PPTX 파일을 나타내는 `Presentation` 클래스를 인스턴스화합니다.  
2. SmartArt를 추가합니다.  
3. 인덱스를 사용하여 Node에 대한 참조를 가져옵니다.  
4. 썸네일 이미지를 가져옵니다.  
5. 원하는 이미지 형식으로 썸네일을 저장합니다.

아래 예제는 SmartArt 자식 Node의 썸네일을 생성합니다.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **FAQ**

**SmartArt 애니메이션이 지원되나요?**

네. SmartArt는 일반 도형으로 취급되므로 [표준 애니메이션](/slides/ko/net/shape-animation/) (입장, 퇴장, 강조, 움직임 경로)을 적용하고 타이밍을 조정할 수 있습니다. 필요에 따라 SmartArt 노드 내부의 도형을 애니메이션화할 수도 있습니다.

**슬라이드에서 내부 ID를 모를 경우 특정 SmartArt를 안정적으로 찾는 방법은?**

[대체 텍스트](/slides/ko/net/shape-alternate-text/)를 사용하여 지정하고 검색합니다. SmartArt에 고유한 AltText를 설정하면 내부 식별자에 의존하지 않고 프로그래밍 방식으로 찾을 수 있습니다.

**프레젠테이션을 PDF로 변환할 때 SmartArt 모양이 유지되나요?**

네. Aspose.Slides는 [PDF 내보내기](/slides/ko/net/convert-powerpoint-to-pdf/) 동안 SmartArt를 높은 시각적 정확도로 렌더링하여 레이아웃, 색상 및 효과를 보존합니다.

**전체 SmartArt의 이미지를 추출하여 미리보기나 보고서에 사용할 수 있나요?**

네. SmartArt 도형을 [래스터 형식](/slides/ko/net/shape-getimage/)이나 [SVG](/slides/ko/net/shape-writeassvg/)로 렌더링할 수 있어 썸네일, 보고서 또는 웹 사용에 적합한 확장 가능한 벡터 출력이 가능합니다.
---
title: 도형 잠금으로 프레젠테이션 편집 방지
linktitle: 프레젠테이션 편집 방지
type: docs
weight: 10
url: /ko/cpp/applying-protection-to-presentation/
keywords:
- 편집 방지
- 편집으로부터 보호
- 도형 잠금
- 위치 잠금
- 선택 잠금
- 크기 잠금
- 그룹화 잠금
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++가 PPT, PPTX 및 ODP 파일에서 도형을 잠그거나 잠금 해제하는 방법을 알아보고, 프레젠테이션을 안전하게 보호하면서 제어된 편집과 빠른 전달을 가능하게 합니다."
---
## **배경**

Aspose.Slides의 일반적인 사용 사례는 자동화된 워크플로의 일부로 Microsoft PowerPoint(PPTX) 프레젠테이션을 만들고, 업데이트하고, 저장하는 것입니다. 이렇게 Aspose.Slides를 사용하는 애플리케이션의 사용자는 생성된 프레젠테이션에 접근할 수 있으므로 편집으로부터 보호하는 것이 일반적인 관심사입니다. 자동으로 생성된 프레젠테이션이 원래의 서식과 내용을 유지하는 것이 중요합니다.

이 문서에서는 프레젠테이션과 슬라이드가 어떻게 구성되는지, 그리고 Aspose.Slides for C++가 프레젠테이션에 보호를 적용하고 이후에 제거하는 방법을 설명합니다. 이를 통해 개발자는 애플리케이션이 생성하는 프레젠테이션의 사용 방식을 제어할 수 있습니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동도형, 표, OLE 개체, 그룹형 도형, 그림 프레임, 비디오 프레임, 커넥터 및 프레젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성 요소로 이루어집니다. Aspose.Slides for C++에서는 슬라이드의 각 요소가 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 인터페이스를 구현하거나 해당 클래스를 상속하는 객체로 표현됩니다.

PPTX 구조는 복잡하기 때문에, 모든 도형 유형에 일반 잠금을 사용할 수 있는 PPT와 달리, 도형 유형마다 다른 잠금이 필요합니다. [IBaseShapeLock](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseshapelock/) 인터페이스는 PPTX용 일반 잠금 클래스입니다. Aspose.Slides for C++에서 PPTX에 대해 지원되는 잠금 유형은 다음과 같습니다:

- [IAutoShapeLock](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshapelock/) 자동도형을 잠급니다.  
- [IConnectorLock](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iconnectorlock/) 커넥터 도형을 잠급니다.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/ko/cpp/aspose.slides/igraphicalobjectlock/) 그래픽 개체를 잠급니다.  
- [IGroupShapeLock](https://reference.aspose.com/slides/ko/cpp/aspose.slides/igroupshapelock/) 그룹 도형을 잠급니다.  
- [IPictureFrameLock](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframelock/) 그림 프레임을 잠급니다.   

[Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 객체의 모든 도형 개체에 수행된 모든 작업은 전체 프레젠테이션에 적용됩니다.

## **보호 적용 및 제거**

보호를 적용하면 프레젠테이션을 편집할 수 없게 됩니다. 이는 프레젠테이션의 내용을 보호하는 유용한 기술입니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for C++는 슬라이드의 도형을 다루기 위해 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 인터페이스를 제공합니다.

앞서 언급했듯이 각 도형 클래스는 보호를 위한 관련 도형 잠금 클래스를 가지고 있습니다. 이 문서에서는 NoSelect, NoMove, NoResize 잠금에 중점을 둡니다. 이러한 잠금은 도형이 선택(마우스 클릭 또는 기타 선택 방법)될 수 없으며 이동하거나 크기를 조정할 수 없도록 보장합니다.

다음 코드 샘플은 프레젠테이션의 모든 도형 유형에 보호를 적용합니다.

```cpp
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// 프레젠테이션의 모든 슬라이드를 순회합니다.
for (auto&& slide : presentation->get_Slides())	{

	// 슬라이드의 모든 도형을 순회합니다.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// 도형을 자동도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// 도형을 그룹 도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// 도형을 커넥터 도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// 도형을 그림 프레임으로 형변환하고 해당 도형 잠금을 가져옵니다.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// 프레젠테이션 파일을 저장합니다.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **보호 제거**

도형의 잠금을 해제하려면 적용된 잠금 값을 `false`로 설정합니다. 다음 코드 샘플은 잠긴 프레젠테이션에서 도형 잠금을 해제하는 방법을 보여줍니다.

```cpp
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// 프레젠테이션의 모든 슬라이드를 순회합니다.
for (auto&& slide : presentation->get_Slides())	{

	// 슬라이드의 모든 도형을 순회합니다.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// 도형을 자동도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// 도형을 그룹 도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// 도형을 커넥터 도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// 도형을 그림 프레임으로 형변환하고 해당 도형 잠금을 가져옵니다.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// 프레젠테이션 파일을 저장합니다.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **결론**

Aspose.Slides는 프레젠테이션에서 도형을 보호하기 위한 여러 옵션을 제공합니다. 개별 도형을 잠그거나 프레젠테이션의 모든 도형을 반복하면서 각각을 잠가 전체 파일을 효과적으로 보호할 수 있습니다. 잠금 값을 `false`로 설정하면 보호를 제거할 수 있습니다.

## **FAQ**

**같은 프레젠테이션에서 도형 잠금과 암호 보호를 결합할 수 있나요?**

예. 잠금은 파일 내부 개체의 편집을 제한하고, [암호 보호](/slides/ko/cpp/password-protected-presentation/)는 열기 및/또는 저장 변경에 대한 접근을 제어합니다. 이러한 메커니즘은 서로 보완하며 함께 작동합니다.

**특정 슬라이드만 편집을 제한하고 다른 슬라이드에는 영향을 주지 않을 수 있나요?**

예. 선택한 슬라이드의 도형에 잠금을 적용하면, 나머지 슬라이드는 편집 가능 상태를 유지합니다.

**도형 잠금이 그룹 객체와 커넥터에도 적용되나요?**

예. 그룹, 커넥터, 그래픽 개체 및 기타 도형 유형에 대해 전용 잠금 유형이 지원됩니다.
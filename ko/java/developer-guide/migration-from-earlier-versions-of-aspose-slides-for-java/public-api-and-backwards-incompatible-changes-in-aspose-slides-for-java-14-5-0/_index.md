---
title: Aspose.Slides for Java 14.5.0의 공용 API 및 되돌릴 수 없는 변경 사항
linktitle: Aspose.Slides for Java 14.5.0
type: docs
weight: 40
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- 마이그레이션
- 레거시 코드
- 최신 코드
- 레거시 접근 방식
- 최신 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 공용 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="primary" %}} 
이 페이지에서는 Aspose.Slides for Java 14.5.0 API로 도입된 모든 [추가된](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 클래스, 메서드, 속성 등과 새로운 [제한 사항](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 및 기타 [변경 사항](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)을 나열합니다.
{{% /alert %}} 
## **공용 API 및 되돌릴 수 없는 변경 사항**
### **추가된 클래스 및 메서드**
#### **Aspose.Slides.IPresentationInfo 인터페이스 및 PresentationInfo 클래스 추가**
프레젠테이션에 대한 정보를 나타냅니다.

Method Boolean isEncrypted()는 프레젠테이션이 암호화된 경우 True를 반환하고, 그렇지 않으면 False를 반환합니다.

Method LoadFormat getLoadFormat()는 프레젠테이션 유형을 반환합니다.
#### **Aspose.Slides.IShape.isGrouped() 메서드 추가**
이 메서드는 해당 도형이 그룹화되어 있는지 여부를 판단합니다.
#### **Aspose.Slides.IShape.getParentGroup() 메서드 추가**
이 메서드는 도형이 그룹화된 경우 상위 GroupShape 객체를 반환하고, 그렇지 않으면 null을 반환합니다.
#### **Aspose.Slides.IShapeCollection.addGroupShape() 메서드 추가**
이 메서드는 새 GroupShape을 생성하고 컬렉션 끝에 추가합니다.

새 도형이 GroupShape에 추가될 때 GroupShape의 프레임 크기와 위치가 내용에 맞게 조정됩니다.
#### **Aspose.Slides.IShapeCollection.clear() 메서드 추가**
이 메서드는 컬렉션에서 모든 도형을 제거합니다.
#### **Aspose.Slides.IShapeCollection.insertGroupShape(int) 메서드 추가**
이 메서드는 새 GroupShape을 생성하고 지정된 인덱스에 컬렉션에 삽입합니다.

새 도형이 GroupShape에 추가될 때 GroupShape의 프레임 크기와 위치가 내용에 맞게 조정됩니다.
#### **IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream) 메서드 추가**
이 메서드들을 사용하면 전체 프레젠테이션을 로드하지 않고도 프레젠테이션 파일/스트림에 대한 정보를 얻을 수 있습니다.
#### **IPresentationFactory PresentationFactory.getInstance() 메서드 추가**
인스턴스를 생성하지 않고도 팩터리 기능을 사용할 수 있습니다.
### **제한 사항**
#### **IShape.getFrame()에 대해 정의되지 않은 값을 사용하는 경우에 대한 제한 사항이 추가되었습니다**
IShape.setFrame(IShapeFrame)에 정의되지 않은 프레임을 할당하려는 코드는 일반적인 경우에 의미가 없으며(특히 상위 GroupShape이 다른 {{GroupShape}}들에 여러 번 중첩된 경우) 그렇습니다. 예시:
``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

or
``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

이러한 코드는 불명확한 상황을 초래할 수 있습니다. 따라서 IShape.Frame에 정의되지 않은 값을 사용하는 경우에 대한 제한이 추가되었습니다. x, y, width, height, flipH, flipV 및 rotationAngle 값은 정의되어 있어야 하며(Float.NaN 또는 NullableBool.NotDefined가 아니어야 함) 그렇지 않을 경우 예제 코드가 ArgumentException 예외를 발생합니다.
이러한 사용 사례에 적용됩니다:
``` java

 IShape shape = ...;

shape.setFrame(...); // 정의되지 않을 수 없습니다

IShapeCollection shapes = ...;

// x, y, width, height 매개변수는 Float.NaN일 수 없습니다:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

하지만 IShape.getRawFrame() 프레임은 정의되지 않을 수 있습니다. 이는 도형이 플레이스홀더에 연결된 경우에 의미가 있습니다. 이 경우 정의되지 않은 도형 프레임 값은 상위 플레이스홀더 도형에서 대체됩니다. 해당 도형에 상위 플레이스홀더 도형이 없으면 IShape.getRawFrame()을 기반으로 유효 프레임을 평가할 때 기본값을 사용합니다. 기본값은 x, y, width, height, flipH, flipV 및 rotationAngle에 대해 0 및 NullableBool.False 입니다. 예시:
``` java

 IShape shape = ...; // shape은 플레이스홀더에 연결되어 있습니다

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// 이제 shape은 플레이스홀더로부터 x, y, height, flipH, flipV 값을 상속받고 width=100 및 rotationAngle=0을 덮어씁니다.

```
### **변경된 속성**
#### **Aspose.Slides.IShapeCollection.getParent() 메서드의 타입 및 이름 변경**
Aspose.Slides.IShapeCollection.Parent 속성의 타입이 ISlideComponent에서 새 IGroupShape 인터페이스로 변경되었습니다. IGroupShape 인터페이스는 ISlideComponent의 파생 인터페이스이므로 기존 코드를 수정할 필요가 없습니다.

Aspose.Slides.IShapeCollection.getParent() 메서드의 이름이 getParent에서 getParentGroup()으로 변경되었습니다.
#### **Aspose.Slides.IShapeFrame.getFlipH() 및 .getFlipV() 메서드의 타입 변경**
Aspose.Slides.IShapeFrame.getFlipH() 메서드의 타입이 bool에서 NullableBool로 변경되었습니다.

IShape.getFrame() 메서드는 모든 속성이 정의된 유효 값을 가진 IShapeFrame 인스턴스를 반환합니다.

IShape.getRawFrame() 메서드는 각 속성이 정의되지 않을 수 있는 IShapeFrame 인스턴스를 반환합니다(특히 FlipH 또는 FlipV는 NullableBool.NotDefined 값을 가질 수 있음).
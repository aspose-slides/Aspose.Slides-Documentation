---
title: Aspose.Slides for Java 14.5.0의 공개 API 및 이전과 호환되지 않는 변경 사항
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
description: "Aspose.Slides for Java의 공개 API 업데이트 및 호환성 깨지는 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="info" %}} 

이 페이지는 Aspose.Slides for Java 14.5.0 API와 함께 도입된 모든 [추가된](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 클래스, 메서드, 속성 등을 나열하고, 새로운 [제한](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 및 기타 [변경 사항](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)을 소개합니다.

{{% /alert %}} 
## **공개 API 및 이전과 호환되지 않는 변경 사항**
### **추가된 클래스 및 메서드**
#### **Aspose.Slides.IPresentationInfo 인터페이스와 PresentationInfo 클래스 추가**
프레젠테이션에 대한 정보를 나타냅니다.

Method Boolean isEncrypted()는 프레젠테이션이 암호화된 경우 True를 반환하고, 그렇지 않은 경우 False를 반환합니다.

Method LoadFormat getLoadFormat()는 프레젠테이션 유형을 반환합니다.
#### **Aspose.Slides.IShape.isGrouped() 메서드 추가**
Aspose.Slides.IShape.isGrouped() 메서드는 해당 도형이 그룹화되어 있는지 여부를 판단합니다.
#### **Aspose.Slides.IShape.getParentGroup() 메서드 추가**
Aspose.Slides.IShape.getParentGroup() 메서드는 도형이 그룹화된 경우 상위 GroupShape 개체를 반환합니다. 그렇지 않으면 null을 반환합니다.
#### **Aspose.Slides.IShapeCollection.addGroupShape() 메서드 추가**
Aspose.Slides.IShapeCollection.addGroupShape() 메서드는 새로운 GroupShape을 생성하고 컬렉션 끝에 추가합니다.

새로운 도형이 GroupShape에 추가될 때 GroupShape의 프레임 크기와 위치가 내용에 맞게 조정됩니다.
#### **Aspose.Slides.IShapeCollection.clear() 메서드 추가**
Aspose.Slides.IShapeCollection.clear() 메서드는 컬렉션에서 모든 도형을 제거합니다.
#### **Aspose.Slides.IShapeCollection.insertGroupShape(int) 메서드 추가**
Aspose.Slides.IShapeCollection.insertGroupShape(int) 메서드는 새로운 GroupShape을 생성하고 지정된 인덱스에 삽입합니다.
새로운 도형이 GroupShape에 추가될 때 GroupShape의 프레임 크기와 위치가 내용에 맞게 조정됩니다.
#### **IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream) 메서드 추가**
이 메서드들을 사용하면 전체 프레젠테이션을 로드하지 않고도 프레젠테이션 파일/스트림에 대한 정보를 얻을 수 있습니다.
#### **IPresentationFactory PresentationFactory.getInstance() 메서드 추가**
인스턴스를 생성하지 않아도 팩터리 기능을 사용할 수 있습니다.
### **제한 사항**
#### **IShape.getFrame()에 정의되지 않은 값을 사용하는 경우에 제한이 추가됨**
IShape.setFrame(IShapeFrame) 에 정의되지 않은 프레임을 할당하려는 코드는 일반적인 경우(특히 상위 GroupShape이 여러 중첩 {{GroupShape}}에 포함된 경우) 의미가 없습니다. 예:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // ArgumentException이 발생합니다: 프레임 값은 정의되어야 합니다.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

또는

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // ArgumentException이 발생합니다: x, y, width 및 height 값은 정의되어야 합니다.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

이러한 코드는 불명확한 상황을 초래할 수 있습니다. 따라서 IShape.Frame에 정의되지 않은 값을 사용하는 경우에 제한이 추가되었습니다. x, y, width, height, flipH, flipV 및 rotationAngle 값은 반드시 정의되어 있어야 하며(Float.NaN 또는 NullableBool.NotDefined 허용 안 함) 위의 예제 코드는 이제 ArgumentException을 발생시킵니다.
다음 사용 사례에 적용됩니다:

``` java
// IShape.setFrame(IShapeFrame)에 전달되는 프레임은 정의되지 않은 값을 포함할 수 없습니다.

// 다음 IShapeCollection 메서드의 x, y, width 및 height 매개변수는
// Float.NaN이 될 수 없습니다:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

하지만 IShape.getRawFrame() 프레임은 정의되지 않을 수 있습니다. 이는 도형이 플레이스홀더에 연결된 경우에 의미가 있습니다. 정의되지 않은 도형 프레임 값은 상위 플레이스홀더 도형에서 대체됩니다. 해당 도형에 상위 플레이스홀더가 없을 경우 IShape.getRawFrame()을 기반으로 유효 프레임을 평가할 때 기본값이 사용됩니다. 기본값은 x, y, width, height, flipH, flipV 및 rotationAngle에 대해 각각 0과 NullableBool.False입니다. 예:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // 도형이 플레이스홀더에 연결되어 있습니다.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // 이제 도형은 플레이스홀더에서 x, y, height, flipH 및 flipV 값을 상속받습니다
    // 그리고 width = 100 및 rotationAngle = 0을 재정의합니다.
} finally {
    if (pres != null) pres.dispose();
}
```
### **변경된 속성**
#### **Aspose.Slides.IShapeCollection.getParent() 메서드의 반환 타입 및 이름 변경**
Aspose.Slides.IShapeCollection.Parent 속성의 타입이 ISlideComponent에서 새 인터페이스 IGroupShape으로 변경되었습니다. IGroupShape 인터페이스는 ISlideComponent의 파생 인터페이스이므로 기존 코드는 수정이 필요 없습니다.

Aspose.Slides.IShapeCollection.getParent() 메서드의 이름이 getParent에서 getParentGroup()으로 변경되었습니다.
#### **Aspose.Slides.IShapeFrame.getFlipH() 및 .getFlipV() 메서드의 반환 타입 변경**
Aspose.Slides.IShapeFrame.getFlipH() 메서드의 반환 타입이 bool에서 NullableBool으로 변경되었습니다.

IShape.getFrame() 메서드는 모든 속성이 정의된 유효한 IShapeFrame 인스턴스를 반환합니다.

IShape.getRawFrame() 메서드는 각 속성이 정의되지 않을 수 있는 IShapeFrame 인스턴스를 반환합니다(특히 FlipH 또는 FlipV가 NullableBool.NotDefined일 수 있음).
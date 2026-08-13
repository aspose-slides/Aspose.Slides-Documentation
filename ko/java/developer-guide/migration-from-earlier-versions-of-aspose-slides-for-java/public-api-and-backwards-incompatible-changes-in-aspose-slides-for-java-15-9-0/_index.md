---
title: Aspose.Slides for Java 15.9.0의 공용 API 및 이전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
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
description: "Aspose.Slides for Java의 공용 API 업데이트와 파괴적인 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}} 

이 페이지에서는 Aspose.Slides for Java 15.8.0 API와 함께 도입된 추가되거나 제거된 클래스, 메서드, 속성 등 및 기타 변경 사항을 모두 나열합니다. [추가됨](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) 또는 [제거됨](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) 클래스, 메서드, 속성 등을 확인하세요.

{{% /alert %}} 
## **공용 API 변경 사항**
#### **renderToGraphics 메서드가 com.aspose.slides.ISlide, Slide에 추가되었습니다**
다음 메서드가 추가되었습니다:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
were added to com.aspose.slides.ISlide interface and to com.aspose.slides.Slide class. These methods allow render a slide to specified Graphics2D object.

com.aspose.slides.ISlide 인터페이스와 com.aspose.slides.Slide 클래스에 추가되었습니다. 이러한 메서드를 사용하면 지정된 Graphics2D 객체에 슬라이드를 렌더링할 수 있습니다.

`renderToGraphics` 메서드는 이후 공용 API에서 제거되었습니다. 현재 버전에서는 아래 예제와 같이 [ISlide.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)을 사용하여 슬라이드를 렌더링합니다:

``` java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("SomePresentation.pptx");

try {

	IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

	try {

		slideImage.save("slide.png", ImageFormat.Png);

	} finally {

		slideImage.dispose();

	}

} finally {

	if (pres != null) pres.dispose();

}

```
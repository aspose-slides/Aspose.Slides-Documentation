---
title: Aspose.Slides for Java 15.9.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- 마이그레이션
- 레거시 코드
- 모던 코드
- 레거시 접근 방식
- 모던 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 공개 API 업데이트 및 중단되는 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="primary" %}} 

이 페이지는 Aspose.Slides for Java 15.8.0 API와 함께 도입된 [added](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) 또는 [removed](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) 클래스, 메서드, 속성 등 및 기타 변경 사항을 모두 나열합니다.

{{% /alert %}} 
## **Public API Changes**
#### **renderToGraphics 메서드가 com.aspose.slides.ISlide, Slide에 추가됨**
다음 메서드가 추가되었습니다:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
이 메서드들은 com.aspose.slides.ISlide 인터페이스와 com.aspose.slides.Slide 클래스에 추가되었습니다. 이 메서드들을 사용하면 지정된 Graphics2D 객체에 슬라이드를 렌더링할 수 있습니다.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```
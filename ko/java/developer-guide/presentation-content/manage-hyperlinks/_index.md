---
title: Java에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/java/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 만들기
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 비디오 하이퍼링크
- 가변 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 하이퍼링크를 손쉽게 관리하고, 몇 분 만에 상호 작용 및 워크플로를 향상시킵니다."
---
## **소개**

하이퍼링크는 객체, 데이터 또는 특정 위치에 대한 참조입니다. 다음은 PowerPoint 프레젠테이션에서 일반적으로 사용되는 하이퍼링크입니다:

* 텍스트, 도형 또는 미디어 안의 웹사이트 링크
* 슬라이드 링크

Aspose.Slides for Java 를 사용하면 프레젠테이션의 하이퍼링크와 관련된 다양한 작업을 수행할 수 있습니다. 

{{% alert color="primary" %}} 

Aspose 간편한 [무료 온라인 PowerPoint 편집기](https://products.aspose.app/slides/ko/editor)를 확인해 보세요.

{{% /alert %}} 

## **URL 하이퍼링크 추가**

### **텍스트에 URL 하이퍼링크 추가**

다음 Java 코드는 텍스트에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **도형이나 프레임에 URL 하이퍼링크 추가**

다음 Java 샘플 코드는 도형에 웹사이트 하이퍼링크를 추가하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **미디어에 URL 하이퍼링크 추가**

Aspose.Slides 를 사용하면 이미지, 오디오 및 비디오 파일에 하이퍼링크를 추가할 수 있습니다. 

다음 샘플 코드는 **이미지**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	// 프레젠테이션에 이미지를 추가합니다
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// 이전에 추가한 이미지를 기반으로 슬라이드 1에 그림 프레임을 생성합니다
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

다음 샘플 코드는 **오디오 파일**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

다음 샘플 코드는 **비디오**에 하이퍼링크를 추가하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="팁"  color="primary"  %}} 

다음 내용을 확인해 보세요 *[OLE 관리](/slides/ko/java/manage-ole/)*.

{{% /alert %}}

## **목차 만들기에 하이퍼링크 사용**

하이퍼링크를 사용하면 객체나 위치에 대한 참조를 추가할 수 있으므로 이를 이용해 목차를 만들 수 있습니다. 

다음 샘플 코드는 하이퍼링크가 포함된 목차를 만드는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **하이퍼링크 서식 지정**

### **색상**

[IHyperlink](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlink) 인터페이스의 [ColorSource](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Hyperlink#setColorSource-int-) 속성을 사용하면 하이퍼링크의 색상을 설정하고 색상 정보를 가져올 수 있습니다. 이 기능은 PowerPoint 2019에서 처음 도입되었으며, 해당 속성과 관련된 변경 사항은 이전 버전의 PowerPoint에는 적용되지 않습니다.

다음 샘플 코드는 같은 슬라이드에 서로 다른 색상의 하이퍼링크가 추가되는 예를 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **프레젠테이션에서 하이퍼링크 제거**

### **텍스트에서 하이퍼링크 제거**

다음 Java 코드는 프레젠테이션 슬라이드의 텍스트에서 하이퍼링크를 제거하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		IAutoShape autoShape = (IAutoShape)shape;
		if (autoShape != null)
		{
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **도형이나 프레임에서 하이퍼링크 제거**

다음 Java 코드는 프레젠테이션 슬라이드의 도형에서 하이퍼링크를 제거하는 방법을 보여줍니다: 

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **가변 하이퍼링크**

[Hyperlink](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Hyperlink) 클래스는 가변입니다. 이 클래스를 사용하면 다음 속성 값을 변경할 수 있습니다:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

다음 코드 조각은 슬라이드에 하이퍼링크를 추가하고 나중에 툴팁을 편집하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **IHyperlinkQueries에서 지원되는 속성**

프레젠테이션, 슬라이드 또는 텍스트에서 정의된 하이퍼링크에 대해 [IHyperlinkQueries](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlinkQueries)를 접근할 수 있습니다. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

[IHyperlinkQueries](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlinkQueries) 클래스는 다음 메서드와 속성을 지원합니다: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**슬라이드가 아니라 "섹션"이나 섹션의 첫 번째 슬라이드로 이동하는 내부 내비게이션을 만들려면 어떻게 해야 하나요?**

PowerPoint에서 섹션은 슬라이드 그룹이며, 내비게이션은 기술적으로 특정 슬라이드를 대상으로 합니다. "섹션으로 이동"하려면 보통 해당 섹션의 첫 번째 슬라이드에 링크를 연결합니다.

**마스터 슬라이드 요소에 하이퍼링크를 첨부하면 모든 슬라이드에서 작동하나요?**

네. 마스터 슬라이드 및 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 링크는 자식 슬라이드에 표시되며 슬라이드 쇼 중에 클릭할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지되나요?**

[PDF](/slides/ko/java/convert-powerpoint-to-pdf/)와 [HTML](/slides/ko/java/convert-powerpoint-to-html/)에서는 일반적으로 링크가 유지됩니다. 그러나 [이미지](/slides/ko/java/convert-powerpoint-to-png/)와 [비디오](/slides/ko/java/convert-powerpoint-to-video/)로 내보낼 경우, 래스터 프레임/비디오는 하이퍼링크를 지원하지 않으므로 클릭 가능성이 유지되지 않습니다.
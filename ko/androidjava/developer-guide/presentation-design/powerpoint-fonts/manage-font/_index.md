---
title: Android에서 프레젠테이션의 글꼴 관리
linktitle: 글꼴 관리
type: docs
weight: 10
url: /ko/androidjava/manage-fonts/
keywords:
- 글꼴 관리
- 글꼴 속성
- 문단
- 텍스트 서식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 Java에서 글꼴을 제어합니다: 맞춤 글꼴을 삽입하고, 대체하며, 로드하여 PPT, PPTX 및 ODP 프레젠테이션을 명확하고, 브랜드에 안전하며, 일관되게 유지합니다."
---
## **개요**

Aspose.Slides를 사용하면 코드에서 직접 프레젠테이션 텍스트의 글꼴 속성을 관리할 수 있습니다. 도형, 텍스트 프레임, 문단, 그리고 부분을 통해 슬라이드의 텍스트에 접근하고 선택한 텍스트에 서식을 적용할 수 있습니다.

이 문서에서는 프레젠테이션의 기존 텍스트에 대한 글꼴 패밀리, 굵게 및 기울임 스타일, 문단 정렬, 글꼴 색상 등 글꼴 관련 속성을 구성하는 방법을 설명합니다. 또한 텍스트 상자를 만들고 텍스트를 추가한 뒤, 글꼴 패밀리, 굵게, 기울임, 밑줄, 글꼴 크기 및 색상과 같은 글꼴 속성을 설정하고 결과를 PPTX 파일로 저장하는 방법을 보여줍니다.

## **글꼴 관련 속성 관리**
{{% alert color="primary" %}} 

프레젠테이션에는 일반적으로 텍스트와 이미지가 모두 포함됩니다. 텍스트는 특정 섹션이나 단어를 강조하거나 기업 스타일에 맞추기 위해 다양한 방식으로 서식이 지정될 수 있습니다. 텍스트 서식은 사용자가 프레젠테이션 내용의 외형을 다양하게 만들 수 있도록 도와줍니다. 이 문서에서는 Aspose.Slides for Android via Java를 사용하여 슬라이드의 텍스트 문단에 대한 글꼴 속성을 구성하는 방법을 보여줍니다.

{{% /alert %}} 

문단의 글꼴 속성을 관리하려면 Aspose.Slides for Android via Java를 사용하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
1. 슬라이드에서 [Placeholder](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholder/) 도형에 접근하고 이를 [AutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/autoshape/)으로 형변환합니다.
1. [AutoShape]에서 노출되는 [TextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textframe/)으로부터 [Paragraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/paragraph/)를 가져옵니다.
1. 문단을 양쪽 정렬합니다.
1. [Paragraph]의 텍스트 [Portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portion/)에 접근합니다.
1. [FontData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontdata/)를 사용하여 글꼴을 정의하고 텍스트 [Portion]의 **Font**를 해당대로 설정합니다.
   1. 글꼴을 굵게 설정합니다.
   1. 글꼴을 기울임으로 설정합니다.
1. [Portion] 객체에서 노출되는 [FillFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fillformat/)을 사용하여 글꼴 색상을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현 예는 아래에 제시됩니다. 이 예제는 꾸밈 없는 프레젠테이션을 가져와 슬라이드 중 하나의 글꼴을 포맷합니다. 다음 스크린샷은 입력 파일과 코드 조각이 그것을 어떻게 변경하는지를 보여줍니다. 코드는 글꼴, 색상 및 글꼴 스타일을 변경합니다.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**그림: 입력 파일의 텍스트**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**그림: 업데이트된 서식이 적용된 동일한 텍스트**|

```java
// PPTX 파일을 나타내는 Presentation 객체를 생성합니다
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// 슬라이드 위치를 사용하여 슬라이드에 접근합니다
	ISlide slide = pres.getSlides().get_Item(0);

	// 슬라이드에서 첫 번째와 두 번째 플레이스홀더에 접근하고 AutoShape로 형변환합니다
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// 첫 번째 문단에 접근합니다
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// 문단을 양쪽 정렬합니다
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// 첫 번째 부분에 접근합니다
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// 새 글꼴을 정의합니다
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// 부분에 새 글꼴을 할당합니다
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// 글꼴을 굵게 설정합니다
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// 글꼴을 기울임으로 설정합니다
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// 글꼴 색상을 설정합니다
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// PPTX 파일을 디스크에 저장합니다
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **텍스트 글꼴 속성 설정**
{{% alert color="primary" %}} 

**글꼴 관련 속성 관리**에서 언급했듯이, [Portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portion/)은 문단 내에서 유사한 서식 스타일을 가진 텍스트를 보관하는 데 사용됩니다. 이 문서에서는 Aspose.Slides for Android via Java를 사용하여 텍스트가 포함된 텍스트 상자를 만들고 특정 글꼴 및 글꼴 패밀리 범주의 다양한 속성을 정의하는 방법을 보여줍니다.

{{% /alert %}} 

텍스트 상자를 만들고 그 안의 텍스트에 글꼴 속성을 설정하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 얻습니다.
1. 슬라이드에 **Rectangle** 유형의 [AutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/autoshape/)을 추가합니다.
1. [AutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/autoshape/)에 연결된 채우기 스타일을 제거합니다.
1. [AutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/autoshape/)의 [TextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textframe/)에 접근합니다.
1. [TextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textframe/)에 텍스트를 추가합니다.
1. [TextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textframe/)에 연결된 [Portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portion/) 객체에 접근합니다.
1. [Portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/portion/)에 사용할 글꼴을 정의합니다.
1. [Portion] 객체에서 노출되는 관련 속성을 사용하여 굵게, 기울임, 밑줄, 색상 및 높이와 같은 기타 글꼴 속성을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현 예는 아래에 제시됩니다.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**그림: Aspose.Slides for Android via Java에 의해 일부 글꼴 속성이 설정된 텍스트**|

```java
// PPTX 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation();
try {
	// 첫 번째 슬라이드를 가져옵니다
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle 유형의 AutoShape를 추가합니다
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape에 연결된 모든 채우기 스타일을 제거합니다
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShape와 연결된 TextFrame에 접근합니다
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrame과 연결된 Portion에 접근합니다
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portion의 Font를 설정합니다
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Font의 Bold 속성을 설정합니다
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Font의 Italic 속성을 설정합니다
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Font의 Underline 속성을 설정합니다
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Font의 Height를 설정합니다
	port.getPortionFormat().setFontHeight(25);
	
	// Font의 색상을 설정합니다
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// 프레젠테이션을 디스크에 저장합니다
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
---
title: Java에서 프레젠테이션 플레이스홀더 관리
linktitle: 플레이스홀더 관리
type: docs
weight: 10
url: /ko/java/manage-placeholder/
keywords:
- 플레이스홀더
- 텍스트 플레이스홀더
- 이미지 플레이스홀더
- 차트 플레이스홀더
- 프롬프트 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 플레이스홀더를 손쉽게 관리하세요: 텍스트 교체, 프롬프트 맞춤 설정 및 PowerPoint와 OpenDocument에서 이미지 투명도 설정."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 플레이스홀더를 프로그래밍 방식으로 관리할 수 있습니다. 이 문서에서는 슬라이드에서 플레이스홀더를 찾고 텍스트를 변경하는 방법, 플레이스홀더 레이아웃에 사용자 지정 프롬프트 텍스트를 설정하는 방법, 그리고 플레이스홀더 배경으로 사용되는 이미지의 투명도를 조정하는 방법을 설명합니다. 또한 기본 플레이스홀더와 로컬 도형의 차이점을 명확히 하고, 레이아웃 또는 마스터를 통해 플레이스홀더 변경을 적용하는 방법을 설명하며, 헤더 및 푸터 플레이스홀더 관리에 대한 정보를 제공하는 간단한 FAQ도 포함되어 있습니다.

## **플레이스홀더의 텍스트 변경**
[Aspose.Slides for Java](/slides/ko/java/)를 사용하면 프레젠테이션의 슬라이드에서 플레이스홀더를 찾고 수정할 수 있습니다. Aspose.Slides를 사용하면 플레이스홀더의 텍스트를 변경할 수 있습니다.

**Prerequisite**: 플레이스홀더가 포함된 프레젠테이션이 필요합니다. 이러한 프레젠테이션은 일반 Microsoft PowerPoint 앱에서 만들 수 있습니다.

다음은 Aspose.Slides를 사용하여 해당 프레젠테이션의 플레이스홀더 텍스트를 교체하는 방법입니다:

1. [`Presentation`](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스를 인스턴스화하고 프레젠테이션을 인수로 전달합니다.
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
3. 도형들을 반복해서 플레이스홀더를 찾습니다.
4. 플레이스홀더 도형을 [`AutoShape`](https://reference.aspose.com/slides/ko/java/com.aspose.slides/AutoShape)으로 타입캐스트하고, 해당 [`AutoShape`](https://reference.aspose.com/slides/ko/java/com.aspose.slides/AutoShape)와 연결된 [`TextFrame`](https://reference.aspose.com/slides/ko/java/com.aspose.slides/TextFrame)을 사용하여 텍스트를 변경합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 Java 코드는 플레이스홀더의 텍스트를 변경하는 방법을 보여줍니다:

```java
// 프레젠테이션 클래스를 인스턴스화합니다
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // 첫 번째 슬라이드에 접근합니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 플레이스홀더를 찾기 위해 도형들을 반복합니다
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // 각 플레이스홀더의 텍스트를 변경합니다
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // 프레젠테이션을 디스크에 저장합니다
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **플레이스홀더에 프롬프트 텍스트 설정**
표준 및 사전 구축된 레이아웃에는 ***Click to add a title*** 또는 ***Click to add a subtitle***와 같은 플레이스홀더 프롬프트 텍스트가 포함되어 있습니다. Aspose.Slides를 사용하면 원하는 프롬프트 텍스트를 플레이스홀더 레이아웃에 삽입할 수 있습니다.

다음 Java 코드는 플레이스홀더에 프롬프트 텍스트를 설정하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // 슬라이드를 반복합니다
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint는 "Click to add title"을 표시합니다
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // 자막을 추가합니다
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **플레이스홀더 이미지 투명도 설정**
Aspose.Slides를 사용하면 텍스트 플레이스홀더의 배경 이미지 투명도를 설정할 수 있습니다. 해당 프레임의 이미지 투명도를 조정하면 텍스트나 이미지가 돋보이게 만들 수 있습니다(텍스트와 이미지 색상에 따라 다름).

다음 Java 코드는 도형 내부에 있는 그림 배경의 투명도를 설정하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**기본 플레이스홀더가 무엇이며 슬라이드의 로컬 도형과 어떻게 다른가요?**  
기본 플레이스홀더는 레이아웃 또는 마스터에 존재하는 원본 도형으로, 슬라이드의 도형이 유형, 위치 및 일부 서식을 상속받습니다. 로컬 도형은 독립적이며, 기본 플레이스홀더가 없을 경우 상속이 적용되지 않습니다.

**전체 프레젠테이션의 모든 제목이나 캡션을 각 슬라이드를 순회하지 않고 업데이트하려면 어떻게 해야 하나요?**  
레이아웃이나 마스터에 있는 해당 플레이스홀더를 수정합니다. 해당 레이아웃/마스터를 기반으로 하는 슬라이드는 자동으로 변경 사항을 상속합니다.

**표준 헤더/푸터 플레이스홀더(날짜 및 시간, 슬라이드 번호, 푸터 텍스트)를 어떻게 제어하나요?**  
적절한 범위(일반 슬라이드, 레이아웃, 마스터, 노트/핸드아웃)에서 HeaderFooter 관리자를 사용하여 해당 플레이스홀더를 켜거나 끄고 내용을 설정합니다.
---
title: Android에서 프레젠테이션 자리표시자 관리
linktitle: 자리표시자 관리
type: docs
weight: 10
url: /ko/androidjava/manage-placeholder/
keywords:
- 자리표시자
- 텍스트 자리표시자
- 이미지 자리표시자
- 차트 자리표시자
- 프롬프트 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java에서 자리표시자를 손쉽게 관리합니다: 텍스트 교체, 프롬프트 사용자 지정 및 PowerPoint와 OpenDocument에서 이미지 투명도 설정."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 자리표시자를 프로그래밍 방식으로 관리할 수 있습니다. 이 문서에서는 슬라이드에서 자리표시자를 찾고 텍스트를 변경하는 방법, 자리표시자 레이아웃에 사용자 지정 프롬프트 텍스트를 설정하는 방법, 그리고 자리표시자 배경으로 사용되는 그림의 투명도를 조정하는 방법을 설명합니다. 또한 기본 자리표시자와 로컬 도형 간의 차이를 명확히 하고, 레이아웃 또는 마스터를 통해 자리표시자 변경을 적용하는 방법을 설명하며, 머리글 및 바닥글 자리표시자 관리에 대한 짧은 FAQ도 포함합니다.

## **자리표시자 텍스트 변경**
[Aspose.Slides for Android via Java](/slides/ko/androidjava/)를 사용하면 프레젠테이션의 슬라이드에서 자리표시자를 찾고 수정할 수 있습니다. Aspose.Slides를 사용하면 자리표시자의 텍스트를 변경할 수 있습니다.

**Prerequisite**: 자리표시자를 포함한 프레젠테이션이 필요합니다. 이러한 프레젠테이션은 표준 Microsoft PowerPoint 앱에서 만들 수 있습니다.

1. [`Presentation`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스를 인스턴스화하고 프레젠테이션을 인수로 전달합니다.
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.
3. 도형들을 순회하여 자리표시자를 찾습니다.
4. 자리표시자 도형을 [`AutoShape`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AutoShape)으로 형변환하고, 해당 [`AutoShape`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AutoShape)와 연결된 [`TextFrame`](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/TextFrame)을 사용하여 텍스트를 변경합니다.
5. 수정된 프레젠테이션을 저장합니다.

```java
// Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // 첫 번째 슬라이드에 접근합니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 자리표시자를 찾기 위해 도형들을 순회합니다
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // 각 자리표시자의 텍스트를 변경합니다
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // 프레젠테이션을 디스크에 저장합니다
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **자리표시자 프롬프트 텍스트 설정**
표준 및 사전 제작된 레이아웃에는 ***Click to add a title*** 또는 ***Click to add a subtitle***와 같은 자리표시자 프롬프트 텍스트가 포함되어 있습니다. Aspose.Slides를 사용하면 원하는 프롬프트 텍스트를 자리표시자 레이아웃에 삽입할 수 있습니다.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // 슬라이드를 순회합니다
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

## **자리표시자 이미지 투명도 설정**
Aspose.Slides를 사용하면 텍스트 자리표시자 배경 이미지의 투명도를 설정할 수 있습니다. 해당 프레임의 그림 투명도를 조정하면 텍스트와 이미지 중 어느 쪽이든 돋보이게 할 수 있습니다(텍스트와 그림 색상에 따라 다름).

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

**베이스 자리표시자란 무엇이며 슬라이드의 로컬 도형과 어떻게 다른가요?**  
베이스 자리표시자는 레이아웃이나 마스터에 있는 원본 도형으로, 슬라이드의 도형이 유형, 위치 및 일부 서식을 상속받습니다. 로컬 도형은 독립적이며, 베이스 자리표시자가 없으면 상속이 적용되지 않습니다.

**프레젠테이션 전체의 모든 제목 또는 캡션을 각 슬라이드를 순회하지 않고 업데이트하려면 어떻게 해야 하나요?**  
레이아웃 또는 마스터의 해당 자리표시자를 편집하십시오. 해당 레이아웃/마스터를 기반으로 하는 슬라이드는 자동으로 변경 사항을 상속받습니다.

**표준 머리글/바닥글 자리표시자(날짜 및 시간, 슬라이드 번호, 바닥글 텍스트)를 어떻게 제어합니까?**  
적절한 범위(일반 슬라이드, 레이아웃, 마스터, 노트/핸드아웃)에서 HeaderFooter 관리자를 사용하여 해당 자리표시자를 켜거나 끄고 내용을 설정합니다.
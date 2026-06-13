---
title: Android에서 PowerPoint 슬라이드를 PNG로 변환
linktitle: PowerPoint를 PNG로
type: docs
weight: 30
url: /ko/androidjava/convert-powerpoint-to-png/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 PNG로
- 프레젠테이션을 PNG로
- 슬라이드를 PNG로
- PPT를 PNG로
- PPTX를 PNG로
- PPT를 PNG로 저장
- PPTX를 PNG로 저장
- PPT를 PNG로 내보내기
- PPTX를 PNG로 내보내기
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides로 PowerPoint 프레젠테이션을 고품질 PNG 이미지로 빠르게 변환하여 정확하고 자동화된 결과를 보장합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX 및 ODP와 같은 형식의 프레젠테이션 파일을 로드하고, 슬라이드를 이미지로 렌더링하며, 결과를 PNG 형식으로 저장하는 방법을 보여줍니다.

이 문서에서는 또한 스케일 값을 설정하거나 원하는 너비와 높이를 지정하여 생성된 PNG 이미지를 사용자 지정하는 방법을 보여줍니다.

## **PowerPoint를 PNG로 변환**

다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스를 인스턴스화합니다.
2. [Presentation.getSlides()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) 컬렉션에서 [ISlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlide) 인터페이스 아래의 슬라이드 객체를 가져옵니다.
3. [ISlide.getImage()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlide) 메서드를 사용하여 각 슬라이드의 썸네일을 가져옵니다.
4. [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 메서드를 사용하여 슬라이드 썸네일을 PNG 형식으로 저장합니다.

다음 Java 코드는 PowerPoint 프레젠테이션을 PNG로 변환하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **맞춤형 차원으로 PowerPoint를 PNG로 변환**

특정 스케일에 맞는 PNG 파일을 얻고자 하는 경우, 결과 썸네일의 차원을 결정하는 `desiredX`와 `desiredY` 값을 설정할 수 있습니다.

다음 Java 코드는 위에서 설명한 작업을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **맞춤형 크기로 PowerPoint를 PNG로 변환**

특정 크기에 맞는 PNG 파일을 얻고자 하는 경우, `ImageSize`에 원하는 `width`와 `height` 인수를 전달할 수 있습니다.

다음 코드는 이미지 크기를 지정하면서 PowerPoint를 PNG로 변환하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**전체 슬라이드가 아니라 특정 도형(예: 차트 또는 그림)만 내보내려면 어떻게 해야 합니까?**

Aspose.Slides는 [개별 도형에 대한 썸네일 생성](/slides/ko/androidjava/create-shape-thumbnails/)을 지원하므로, 도형을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환이 지원되나요?**

예, 하지만 단일 프레젠테이션 인스턴스를 여러 스레드에서 [공유하지 마십시오](/slides/ko/androidjava/multithreading/). 스레드 또는 프로세스당 별도의 인스턴스를 사용하십시오.

**PNG로 내보낼 때 평가판 버전의 제한 사항은 무엇인가요?**

평가 모드에서는 출력 이미지에 워터마크가 추가되고, 라이선스를 적용할 때까지 [다른 제한](/slides/ko/androidjava/licensing/)이 적용됩니다.
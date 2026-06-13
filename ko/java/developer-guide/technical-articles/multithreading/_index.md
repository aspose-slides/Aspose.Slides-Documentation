---
title: Java용 Aspose.Slides에서 멀티스레딩
linktitle: 멀티스레딩
type: docs
weight: 310
url: /ko/java/multithreading/
keywords:
- 멀티스레딩
- 다중 스레드
- 병렬 작업
- 슬라이드 변환
- 슬라이드 이미지 변환
- 파워포인트
- 오픈도큐먼트
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 멀티스레딩은 PowerPoint 및 OpenDocument 처리 속도를 높입니다. 효율적인 프레젠테이션 워크플로를 위한 모범 사례를 알아보세요."
---
## **소개**

프레젠테이션을 이용한 병렬 작업은 (구문 분석/로드/복제 제외) 가능하고 대부분 잘 작동하지만, 라이브러리를 여러 스레드에서 사용할 경우 잘못된 결과가 나올 가능성이 조금 있습니다.

멀티스레드 환경에서 단일 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 인스턴스를 사용하는 것은 예측할 수 없는 오류나 쉽게 감지되지 않는 실패를 초래할 수 있으므로 **사용하지 말 것**을 강력히 권장합니다.  

`Presentation` 클래스의 인스턴스를 여러 스레드에서 로드, 저장 및/또는 복제하는 것은 **안전하지 않습니다**. 이러한 작업은 **지원되지 않습니다**. 이러한 작업이 필요하면 여러 개의 단일 스레드 프로세스를 사용해 작업을 병렬화하고, 각 프로세스는 자체 프레젠테이션 인스턴스를 사용해야 합니다.  

## **프레젠테이션 슬라이드를 이미지로 병렬 변환**

PowerPoint 프레젠테이션의 모든 슬라이드를 PNG 이미지로 병렬 변환하고 싶다고 가정해 보겠습니다. 여러 스레드에서 단일 `Presentation` 인스턴스를 사용하는 것은 안전하지 않으므로, 프레젠테이션 슬라이드를 별도의 프레젠테이션으로 나누고 각 슬라이드를 별도 스레드에서 이미지로 변환합니다. 다음 코드 예제는 이를 수행하는 방법을 보여줍니다.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // 슬라이드 i를 별도의 프레젠테이션으로 추출합니다.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // 별도의 작업에서 슬라이드를 이미지로 변환합니다.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// 모든 작업이 완료될 때까지 기다립니다.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **FAQ**

**모든 스레드에서 라이선스 설정을 호출해야 하나요?**

아니오. 스레드가 시작되기 전에 프로세스/앱 도메인당 한 번만 수행하면 충분합니다. [라이선스 설정](/slides/ko/java/licensing/)이 동시에 호출될 수 있는 경우(예: 지연 초기화 중) 해당 호출을 동기화하십시오. 라이선스 설정 메서드 자체는 스레드에 안전하지 않기 때문입니다.

**`Presentation` 또는 `Slide` 객체를 스레드 간에 전달할 수 있나요?**

"활성" 프레젠테이션 객체를 스레드 간에 전달하는 것은 권장되지 않습니다. 스레드당 독립적인 인스턴스를 사용하거나 각 스레드용으로 별도의 프레젠테이션/슬라이드 컨테이너를 미리 생성하십시오. 이는 단일 프레젠테이션 인스턴스를 스레드 간에 공유하지 말라는 일반 권고에 부합합니다.

**각 스레드가 자체 `Presentation` 인스턴스를 가지고 있다면 PDF, HTML, 이미지 등 다양한 형식으로의 내보내기를 병렬화해도 안전한가요?**

네. 독립적인 인스턴스와 별도 출력 경로를 사용한다면 이러한 작업은 일반적으로 올바르게 병렬화됩니다. 공유 프레젠테이션 객체나 공유 I/O 스트림은 사용하지 마십시오.

**멀티스레드 환경에서 전역 폰트 설정(폴더, 대체)은 어떻게 해야 하나요?**

스레드를 시작하기 전에 모든 전역 [폰트 설정](/slides/ko/java/powerpoint-fonts/)을 초기화하고, 병렬 작업 중에는 변경하지 마십시오. 이렇게 하면 공유 폰트 리소스에 대한 경쟁 조건을 방지할 수 있습니다.
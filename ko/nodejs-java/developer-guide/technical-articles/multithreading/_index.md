---
title: Node.js via Java용 Aspose.Slides에서 멀티스레딩
linktitle: 멀티스레딩
type: docs
weight: 310
url: /ko/nodejs-java/multithreading/
keywords:
- 멀티스레딩
- 다중 스레드
- 병렬 작업
- 슬라이드 변환
- 슬라이드 이미지 변환
- 파워포인트
- 오픈도큐먼트
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java 멀티스레딩은 PowerPoint 및 OpenDocument 처리를 가속화합니다. 효율적인 프레젠테이션 워크플로를 위한 모범 사례를 확인하세요."
---
## **소개**

프레젠테이션에 대한 병렬 작업이 가능하지만(구문 분석/로드/클론 제외) 대부분의 경우 정상적으로 동작하더라도, 라이브러리를 여러 스레드에서 사용할 경우 잘못된 결과가 나올 가능성이 있습니다.

멀티스레드 환경에서 단일 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 인스턴스를 **사용하지 말 것**을 강력히 권장합니다. 이는 예측할 수 없는 오류나 쉽게 감지되지 않는 실패를 일으킬 수 있기 때문입니다.

여러 스레드에서 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스를 로드, 저장 또는 클론하는 것은 **안전하지 않습니다**. 이러한 작업은 **지원되지** 않습니다. 해당 작업이 필요하다면 여러 개의 단일 스레드 프로세스를 사용해 작업을 병렬화하고, 각 프로세스가 자체 프레젠테이션 인스턴스를 사용하도록 해야 합니다.

## **프레젠테이션 슬라이드를 병렬로 이미지로 변환하기**

PowerPoint 프레젠테이션의 모든 슬라이드를 PNG 이미지로 병렬 변환한다고 가정해 보겠습니다. 단일 `Presentation` 인스턴스를 여러 스레드에서 사용하는 것은 안전하지 않으므로, 슬라이드를 개별 프레젠테이션으로 분할하고 각각을 별도 스레드에서 이미지로 변환합니다. 아래 코드 예제가 이를 보여줍니다.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // 슬라이드 i를 별도의 프레젠테이션으로 추출합니다.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // 모든 작업이 완료될 때까지 기다립니다.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **FAQ**

**모든 스레드에서 라이선스 설정을 호출해야 하나요?**

아니오. 스레드가 시작되기 전에 프로세스/앱 도메인당 한 번만 하면 충분합니다. [라이선스 설정](/slides/ko/nodejs-java/licensing/)이 동시에 호출될 가능성이 있는 경우(예: 지연 초기화 중) 해당 호출을 동기화하세요. 라이선스 설정 메서드 자체는 스레드에 안전하지 않기 때문입니다.

**`Presentation` 또는 `Slide` 객체를 스레드 간에 전달할 수 있나요?**

“실시간” 프레젠테이션 객체를 스레드 간에 전달하는 것은 권장되지 않습니다. 스레드당 독립적인 인스턴스를 사용하거나 각 스레드용 별도 프레젠테이션/슬라이드 컨테이너를 미리 생성하세요. 이는 단일 프레젠테이션 인스턴스를 스레드 간에 공유하지 말라는 일반 권고와 일치합니다.

**각 스레드가 자체 `Presentation` 인스턴스를 가지고 있다면 PDF, HTML, 이미지 등 다양한 형식으로의 병렬 내보내기가 안전한가요?**

예. 독립적인 인스턴스와 별도의 출력 경로를 사용하면 이러한 작업은 일반적으로 올바르게 병렬화됩니다. 공유 프레젠테이션 객체와 공유 I/O 스트림은 피하세요.

**멀티스레드 환경에서 글로벌 폰트 설정(폴더, 대체 등)은 어떻게 해야 하나요?**

스레드를 시작하기 전에 모든 글로벌 폰트 설정을 초기화하고, 병렬 작업 중에는 변경하지 마세요. 이렇게 하면 공유 폰트 리소스에 대한 경쟁 상태를 방지할 수 있습니다.
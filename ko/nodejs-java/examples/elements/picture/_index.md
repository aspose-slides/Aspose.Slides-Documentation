---
title: 그림
type: docs
weight: 50
url: /ko/nodejs-java/examples/elements/picture/
keywords:
- 코드 예제
- 그림
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 그림을 작업합니다: 삽입, 자르기, 압축, 색상 변경 및 이미지 내보내기를 수행하며 PPT, PPTX 및 ODP 프레젠테이션 예제를 제공합니다."
---
이 문서는 **Aspose.Slides for Node.js via Java**를 사용하여 그림을 삽입하고 액세스하는 방법을 보여줍니다. 아래 예제는 파일에서 이미지를 읽어 슬라이드에 배치한 다음 가져옵니다.

## **그림 추가**

이 코드는 파일에서 이미지를 읽어 첫 번째 슬라이드에 그림 프레임으로 삽입합니다.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // 첫 번째 슬라이드에 이미지를 표시하는 그림 프레임을 삽입합니다.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **그림 액세스**

이 예제는 슬라이드에 그림 프레임이 포함되어 있는지 확인한 다음, 찾은 첫 번째 프레임에 접근합니다.

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```
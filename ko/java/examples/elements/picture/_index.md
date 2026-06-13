---
title: 그림
type: docs
weight: 50
url: /ko/java/examples/elements/picture/
keywords:
- 코드 예제
- 그림
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 그림을 사용합니다: 삽입, 자르기, 압축, 색상 변경 및 PPT, PPTX 및 ODP 프레젠테이션에 대한 Java 예제로 이미지를 내보냅니다."
---
이 문서에서는 **Aspose.Slides for Java**를 사용하여 메모리 내 이미지에서 그림을 삽입하고 액세스하는 방법을 보여줍니다. 아래 예제는 메모리에서 이미지를 생성하고 슬라이드에 배치한 다음 해당 이미지를 검색합니다.

## **그림 추가**
이 코드는 작은 비트맵을 생성하고 이를 스트림으로 변환한 다음 첫 번째 슬라이드에 그림 프레임으로 삽입합니다.

```java
public static void addPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 간단한 메모리 내 이미지를 생성합니다.
        BufferedImage bitmap = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
        Graphics2D graphics = bitmap.createGraphics();
        try {
            graphics.setPaint(new Color(144, 238, 144));
            graphics.fillRect(0, 0, 100, 100);
        } finally {
            graphics.dispose();
        }

        // 비트맵을 바이트 배열로 변환합니다.
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        // 이미지를 프레젠테이션에 추가합니다.
        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

        // 첫 번째 슬라이드에 이미지를 표시하는 그림 프레임을 삽입합니다.
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

        presentation.save("picture.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **그림 액세스**
이 예제는 슬라이드에 그림 프레임이 포함되어 있는지 확인하고, 찾아진 첫 번째 프레임에 접근합니다.

```java
public static void accessPicture() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        BufferedImage bitmap = new BufferedImage(40, 40, BufferedImage.TYPE_INT_ARGB);
        ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
        ImageIO.write(bitmap, "png", bitmapStream);
        byte[] pngBytes = bitmapStream.toByteArray();

        IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

        IPictureFrame pictureFrame = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IPictureFrame) {
                pictureFrame = (IPictureFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```
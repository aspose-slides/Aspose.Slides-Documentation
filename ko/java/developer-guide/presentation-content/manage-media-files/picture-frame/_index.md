---
title: Java를 사용하여 프레젠테이션에서 그림 프레임 관리
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/java/picture-frame/
keywords:
- 그림 프레임
- 그림 프레임 추가
- 그림 프레임 만들기
- 이미지 추가
- 이미지 만들기
- 이미지 추출
- 래스터 이미지
- 벡터 이미지
- 이미지 자르기
- 잘린 영역
- StretchOff 속성
- 그림 프레임 서식 지정
- 그림 프레임 속성
- 상대 스케일
- 이미지 효과
- 종횡비
- 이미지 투명도
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 그림 프레임을 추가하세요. 작업 흐름을 효율화하고 슬라이드 디자인을 향상시킵니다."
---
## **소개**

그림 프레임은 이미지를 포함하는 도형으로, 프레임 안의 사진과 같습니다.

그림 프레임을 통해 슬라이드에 이미지를 추가할 수 있습니다. 이렇게 하면 그림 프레임을 포맷함으로써 이미지를 포맷할 수 있습니다.

{{% alert  title="팁" color="info" %}} 
Aspose는 무료 컨버터—[JPEG를 PowerPoint로](https://products.aspose.app/slides/ko/import/jpg-to-ppt)와 [PNG를 PowerPoint로](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 사용자가 이미지를 빠르게 프레젠테이션으로 만들 수 있도록 합니다. 
{{% /alert %}} 

## **그림 프레임 만들기**

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
3. Presentation 객체와 연결된 [IImageCollection]에 이미지를 추가하여 [IPPImage]() 객체를 생성합니다.
4. 이미지의 너비와 높이를 지정합니다.
5. 참조된 슬라이드와 연결된 shape 객체가 제공하는 `AddPictureFrame` 메서드를 사용하여 이미지의 너비와 높이를 기반으로 [PictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/PictureFrame)을 생성합니다.
6. 그림을 포함하는 그림 프레임을 슬라이드에 추가합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드는 그림 프레임을 만드는 방법을 보여줍니다:
```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image 클래스를 인스턴스화합니다
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 그림과 동일한 높이와 너비를 가진 그림 프레임을 추가합니다
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX 파일을 디스크에 저장합니다
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
그림 프레임을 사용하면 이미지를 기반으로 프레젠테이션 슬라이드를 신속하게 만들 수 있습니다. 그림 프레임을 Aspose.Slides의 저장 옵션과 결합하면 이미지 형식 간 변환을 위한 입출력 작업을 조작할 수 있습니다. 다음 페이지들을 참고하십시오: [이미지를 JPG로 변환](https://products.aspose.com/slides/ko/java/conversion/image-to-jpg/); [JPG를 이미지로 변환](https://products.aspose.com/slides/ko/java/conversion/jpg-to-image/); [JPG를 PNG로 변환](https://products.aspose.com/slides/ko/java/conversion/jpg-to-png/), [PNG를 JPG로 변환](https://products.aspose.com/slides/ko/java/conversion/png-to-jpg/); [PNG를 SVG로 변환](https://products.aspose.com/slides/ko/java/conversion/png-to-svg/), [SVG를 PNG로 변환](https://products.aspose.com/slides/ko/java/conversion/svg-to-png/). 
{{% /alert %}}

## **상대 스케일이 적용된 그림 프레임 만들기**

이미지의 상대 스케일을 변경하면 보다 복잡한 그림 프레임을 만들 수 있습니다. 

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
3. 프레젠테이션 이미지 컬렉션에 이미지를 추가합니다.
4. Presentation 객체와 연결된 [IImageCollection]에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPPImage) 객체를 생성합니다.
5. 그림 프레임에서 이미지의 상대적인 너비와 높이를 지정합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드는 상대 스케일이 적용된 그림 프레임을 만드는 방법을 보여줍니다:
```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image 클래스를 인스턴스화합니다
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 그림과 동일한 높이와 너비를 가진 그림 프레임을 추가합니다
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 상대 스케일 너비와 높이 설정
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // PPTX 파일을 디스크에 저장합니다
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **그림 프레임에서 래스터 이미지 추출**

PictureFrame 객체에서 래스터 이미지를 추출하여 PNG, JPG 등 다양한 형식으로 저장할 수 있습니다. 아래 코드 예제는 문서 "sample.pptx"에서 이미지를 추출하고 PNG 형식으로 저장하는 방법을 보여줍니다.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;

        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **그림 프레임에서 SVG 이미지 추출**

프레젠테이션에 SVG 그래픽이 [PictureFrame] 도형 안에 포함된 경우, Aspose.Slides for Java를 사용하면 원본 벡터 이미지를 완전한 정밀도로 가져올 수 있습니다. 슬라이드의 도형 컬렉션을 순회하면서 각 [PictureFrame]을 식별하고, 해당 [IPPImage]가 SVG 콘텐츠를 포함하고 있는지 확인한 뒤, 원본 SVG 형식으로 디스크나 스트림에 저장할 수 있습니다.

다음 코드 예제는 그림 프레임에서 SVG 이미지를 추출하는 방법을 보여줍니다:
```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        // getSvgImage는 그림이 래스터 이미지인 경우 null을 반환합니다.
        if (svgImage != null) {
            FileOutputStream fos = new FileOutputStream("output.svg");
            fos.write(svgImage.getSvgData());
            fos.close();
        }
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **이미지 투명도 가져오기**

Aspose.Slides를 사용하면 이미지에 적용된 투명도 효과를 가져올 수 있습니다. 다음 Java 코드는 해당 작업을 보여줍니다:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **이미지 밝기 및 대비 가져오기**

Aspose.Slides를 사용하면 이미지에 적용된 밝기와 대비 효과를 가져올 수 있습니다. [ILuminance] 인터페이스는 이러한 이미지 변환 효과를 나타냅니다.

다음 Java 코드는 그림 프레임에서 밝기와 대비 설정을 가져오는 방법을 보여줍니다:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **그림 프레임 서식 지정**

Aspose.Slides는 그림 프레임에 적용할 수 있는 다양한 서식 옵션을 제공합니다. 이러한 옵션을 사용하면 특정 요구 사항에 맞게 그림 프레임을 조정할 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
3. Presentation 객체와 연결된 [IImageCollection]에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPPImage) 객체를 생성합니다.
4. 이미지의 너비와 높이를 지정합니다.
5. 참조된 슬라이드와 연결된 [IShapes] 객체가 제공하는 [AddPictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 메서드를 사용하여 이미지의 너비와 높이를 기반으로 `PictureFrame`을 생성합니다.
6. 그림을 포함하는 그림 프레임을 슬라이드에 추가합니다.
7. 그림 프레임의 선 색상을 설정합니다.
8. 그림 프레임의 선 두께를 설정합니다.
9. 양수 또는 음수 값을 지정하여 그림 프레임을 회전합니다.
   * 양수 값은 이미지를 시계 방향으로 회전시킵니다. 
   * 음수 값은 이미지를 반시계 방향으로 회전시킵니다.
10. 그림을 포함하는 그림 프레임을 슬라이드에 추가합니다.
11. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드는 그림 프레임 서식 지정 과정을 보여줍니다:
```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image 클래스를 인스턴스화합니다
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 그림과 동일한 높이와 너비를 가진 그림 프레임을 추가합니다
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PictureFrameEx에 일부 서식을 적용합니다
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // PPTX 파일을 디스크에 저장합니다
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="팁" color="info" %}}
Aspose가 최근에 무료 Collage Maker를 개발했습니다. JPG/JPEG 또는 PNG 이미지를 병합하거나 사진으로 그리드를 만들고 싶을 때 이 서비스를 사용할 수 있습니다. 
{{% /alert %}}

## **이미지를 링크로 추가**

프레젠테이션 크기를 크게 줄이기 위해 파일을 직접 삽입하는 대신 링크를 통해 이미지(또는 비디오)를 추가할 수 있습니다. 다음 Java 코드는 이미지와 비디오를 자리 표시자에 추가하는 방법을 보여줍니다:
```java
import com.aspose.slides.*;
import java.util.ArrayList;

Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **이미지 자르기**

다음 Java 코드는 슬라이드에 있는 기존 이미지를 자르는 방법을 보여줍니다:
```java
import com.aspose.slides.*;

String imagePath = "image.png";
String outPptxFile = "CroppedImage_out.pptx";

Presentation pres = new Presentation();
// 새 이미지 객체를 생성합니다
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 슬라이드에 PictureFrame을 추가합니다
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // 이미지를 자릅니다 (백분율 값)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // 결과를 저장합니다
    pres.save(outPptxFile, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **그림 프레임의 잘린 영역 삭제**

프레임에 포함된 이미지의 잘린 영역을 삭제하려면 [deletePictureCroppedAreas()] 메서드를 사용할 수 있습니다. 이 메서드는 잘린 이미지를 반환하거나, 자르기가 필요 없을 경우 원본 이미지를 반환합니다.

다음 Java 코드는 해당 작업을 보여줍니다:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 첫 번째 슬라이드에서 PictureFrame을 가져옵니다
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // PictureFrame 이미지의 잘린 영역을 삭제하고 잘린 이미지를 반환합니다
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 결과를 저장합니다
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="참고" color="warning" %}} 
[deletePictureCroppedAreas()] 메서드는 잘린 이미지를 프레젠테이션 이미지 컬렉션에 추가합니다. 이미지가 처리된 [PictureFrame]에서만 사용되는 경우, 이 설정으로 프레젠테이션 크기를 줄일 수 있습니다. 그렇지 않으면 결과 프레젠테이션의 이미지 수가 증가합니다.

이 메서드는 잘라내기 작업 중 WMF/EMF 메타파일을 래스터 PNG 이미지로 변환합니다. 
{{% /alert %}}

## **이미지 압축**

프레젠테이션의 그림을 [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 메서드를 사용하여 압축할 수 있습니다. 이 메서드는 도형 크기와 지정된 해상도를 기준으로 이미지 크기를 줄이고, 잘린 영역을 삭제할 옵션을 제공합니다.

PowerPoint의 **Picture Format -> Compress Pictures -> Resolution** 기능과 유사하게 그림의 크기와 해상도를 조정합니다.

다음 Java 예제는 대상 해상도를 지정하고 선택적으로 잘린 영역을 제거하여 프레젠테이션에서 이미지를 압축하는 방법을 보여줍니다:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 150 DPI(웹 해상도)의 목표 해상도로 이미지를 압축하고 잘린 영역을 제거합니다.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // 압축 결과를 확인합니다.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

또는 직접 사용자 정의 DPI 값을 사용하여:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 이미지를 150 DPI(웹 해상도)로 압축하고 잘린 영역을 제거합니다.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="참고" color="warning" %}} 
이 메서드는 도형의 크기와 제공된 DPI를 기준으로 이미지를 낮은 해상도로 변환합니다. 파일 크기를 최적화하기 위해 잘린 영역도 삭제할 수 있습니다.  
이미지가 메타파일(WMF/EMF)이나 SVG인 경우 압축이 적용되지 않습니다. 또한 JPEG의 경우 해상도에 따라 품질이 유지되거나 약간 낮아지며, 이는 PowerPoint가 고해상도 JPEG를 처리하는 방식과 유사합니다. 
{{% /alert %}}

## **종횡비 고정**

이미지를 포함하는 도형의 이미지 크기를 변경하더라도 종횡비를 유지하려면 [setAspectRatioLocked](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 메서드를 사용하여 *Lock Aspect Ratio* 설정을 적용할 수 있습니다. 

다음 Java 코드는 도형의 종횡비를 고정하는 방법을 보여줍니다:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // 크기 조정 시 종횡비를 유지하도록 도형을 설정합니다
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="참고" color="warning" %}} 
이 *Lock Aspect Ratio* 설정은 도형의 종횡비만 유지하고, 도형에 포함된 이미지 자체의 종횡비는 유지하지 않습니다. 
{{% /alert %}}

## **StretchOff 속성 사용**

[IPictureFillFormat] 인터페이스와 [PictureFillFormat] 클래스의 [StretchOffsetLeft](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--), [StretchOffsetBottom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) 속성을 사용하여 채우기 사각형을 지정할 수 있습니다. 

이미지에 스트레칭이 지정되면, 원본 사각형이 지정된 채우기 사각형에 맞게 스케일됩니다. 채우기 사각형의 각 변은 도형 경계 상자의 해당 변으로부터 백분율 오프셋으로 정의됩니다. 양의 백분율은 안쪽 오프셋을, 음의 백분율은 바깥쪽 오프셋을 나타냅니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
3. 사각형 `AutoShape`을 추가합니다.
4. 이미지를 생성합니다.
5. 도형의 채우기 유형을 설정합니다.
6. 도형의 이미지 채우기 모드를 설정합니다.
7. 도형을 채우기 위해 이미지를 설정합니다.
8. 도형 경계 상자의 해당 변으로부터 이미지 오프셋을 지정합니다.
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Java 코드는 StretchOff 속성을 사용하는 과정을 보여줍니다:
```java
import com.aspose.slides.*;

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);

    // ImageEx 클래스를 인스턴스화합니다
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 사각형으로 설정된 AutoShape를 추가합니다
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 도형의 채우기 유형을 설정합니다
    aShape.getFillFormat().setFillType(FillType.Picture);

    // 도형의 그림 채우기 모드를 설정합니다
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // 도형을 채우기 위해 이미지를 설정합니다
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 도형 경계 상자의 해당 가장자리로부터 이미지 오프셋을 지정합니다
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // PPTX 파일을 디스크에 저장합니다
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### PictureFrame에서 지원되는 이미지 형식은 어떻게 확인할 수 있나요?

Aspose.Slides는 [PictureFrame]에 할당된 이미지 객체를 통해 래스터 이미지(PNG, JPEG, BMP, GIF 등)와 벡터 이미지(예: SVG)를 모두 지원합니다. 지원되는 형식 목록은 일반적으로 슬라이드 및 이미지 변환 엔진의 기능과 겹칩니다.

### 수십 개의 대용량 이미지를 추가하면 PPTX 크기와 성능에 어떤 영향을 미칩니까?

대용량 이미지를 삽입하면 파일 크기와 메모리 사용량이 증가합니다. 이미지를 링크로 추가하면 프레젠테이션 크기를 줄일 수 있지만 외부 파일이 계속 접근 가능해야 합니다. Aspose.Slides는 파일 크기를 줄이기 위해 이미지를 링크로 추가하는 기능을 제공합니다.

### 이미지 객체가 실수로 이동하거나 크기 조정되는 것을 어떻게 방지할 수 있나요?

이미지 객체가 실수로 이동하거나 크기가 조정되는 것을 방지하려면 [shape locks](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pictureframe/#getPictureFrameLock--)를 사용하여 [PictureFrame]에 대한 잠금을 적용하세요(예: 이동 또는 크기 조정 비활성화). 잠금 메커니즘은 별도의 [보호 문서](/slides/ko/java/applying-protection-to-presentation/)에서 도형에 대해 설명되어 있으며, [PictureFrame]을 포함한 다양한 도형 유형에서 지원됩니다.

### 프레젠테이션을 PDF/이미지로 내보낼 때 SVG 벡터 정밀도가 유지됩니까?

Aspose.Slides는 [PictureFrame]에서 원본 벡터인 SVG를 추출할 수 있습니다. [PDF로 내보내기](/slides/ko/java/convert-powerpoint-to-pdf/) 또는 [래스터 형식으로 내보내기](/slides/ko/java/convert-powerpoint-to-png/) 시, 내보내기 설정에 따라 결과가 래스터화될 수 있으며, 원본 SVG가 벡터로 저장된 것은 추출 동작을 통해 확인됩니다.
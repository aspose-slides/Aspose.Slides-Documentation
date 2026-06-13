---
title: Android에서 프레젠테이션의 그림 프레임 관리
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/androidjava/picture-frame/
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
- 가로세로 비율
- 이미지 투명도
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 그림 프레임을 추가하십시오. 작업 흐름을 간소화하고 슬라이드 디자인을 향상시킵니다."
---
## **소개**

그림 프레임은 이미지를 포함하는 형태이며, 프레임 안에 그림이 있는 것과 같습니다.  

그림 프레임을 통해 슬라이드에 이미지를 추가할 수 있습니다. 이렇게 하면 그림 프레임을 형식화하여 이미지를 형식화할 수 있습니다.  

{{% alert  title="Tip" color="primary" %}} 
Aspose는 무료 변환기—[JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 사용자가 이미지를 빠르게 프레젠테이션으로 만들 수 있도록 합니다. 
{{% /alert %}} 

## **그림 프레임 만들기**

1. Presentation 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 객체와 연결된 [IImagescollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IImageCollection)에 이미지를 추가하여 [IPPImage]() 객체를 생성하고 이를 도형 채우기에 사용합니다.  
4. 이미지의 너비와 높이를 지정합니다.  
5. 참조된 슬라이드와 연결된 도형 객체가 제공하는 `AddPictureFrame` 메서드를 사용하여 이미지의 너비와 높이를 기준으로 [PictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/PictureFrame)을 생성합니다.  
6. 그림을 포함한 그림 프레임을 슬라이드에 추가합니다.  
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 Java 코드는 그림 프레임을 만드는 방법을 보여줍니다:  

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image 클래스를 인스턴스화합니다
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 그림의 동일한 높이와 너비로 그림 프레임을 추가합니다
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX 파일을 디스크에 저장합니다
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **상대 스케일이 적용된 그림 프레임 만들기**

이미지의 상대 스케일을 변경하여 보다 복잡한 그림 프레임을 만들 수 있습니다.  

1. Presentation 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 이미지 컬렉션에 이미지를 추가합니다.  
4. 프레젠테이션 객체와 연결된 [IImagescollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IImageCollection)에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPPImage) 객체를 생성하고 이를 도형 채우기에 사용합니다.  
5. 그림 프레임에서 이미지의 상대적인 너비와 높이를 지정합니다.  
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 Java 코드는 상대 스케일이 적용된 그림 프레임을 만드는 방법을 보여줍니다:  

```java
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image 클래스를 인스턴스화합니다
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 그림과 동일한 높이와 너비로 그림 프레임을 추가합니다
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 상대 스케일 높이와 너비를 설정합니다
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

[PictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/PictureFrame) 객체에서 래스터 이미지를 추출하여 PNG, JPG 등 다양한 형식으로 저장할 수 있습니다. 아래 코드 예제는 문서 “sample.pptx”에서 이미지를 추출하고 PNG 형식으로 저장하는 방법을 보여줍니다.  

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **그림 프레임에서 SVG 이미지 추출**

프레젠테이션에 [PictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pictureframe/) 형태에 삽입된 SVG 그래픽이 포함된 경우, Aspose.Slides for Android via Java를 사용하면 원본 벡터 이미지를 손실 없이 가져올 수 있습니다. 슬라이드의 도형 컬렉션을 순회하면서 각 [PictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pictureframe/)을 확인하고, 기본 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/)이 SVG 콘텐츠를 보유하고 있는지 확인한 뒤, 해당 이미지를 디스크나 스트림에 원본 SVG 형식으로 저장할 수 있습니다.  

다음 코드 예제는 그림 프레임에서 SVG 이미지를 추출하는 방법을 보여줍니다:  

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **이미지 투명도 가져오기**

Aspose.Slides를 사용하면 이미지에 적용된 투명도 효과를 가져올 수 있습니다. 이 Java 코드는 해당 작업을 시연합니다:  

```java
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

## **그림 프레임 서식 지정**

Aspose.Slides는 그림 프레임에 적용할 수 있는 다양한 서식 옵션을 제공합니다. 이러한 옵션을 사용하면 특정 요구 사항에 맞게 그림 프레임을 조정할 수 있습니다.  

1. Presentation 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 객체와 연결된 [IImagescollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IImageCollection)에 이미지를 추가하여 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPPImage) 객체를 생성하고 이를 도형 채우기에 사용합니다.  
4. 이미지의 너비와 높이를 지정합니다.  
5. [AddPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 메서드를 통해 이미지의 너비와 높이를 기반으로 `PictureFrame`을 생성합니다.  
6. 그림을 포함한 그림 프레임을 슬라이드에 추가합니다.  
7. 그림 프레임의 선 색상을 설정합니다.  
8. 그림 프레임의 선 두께를 설정합니다.  
9. 양수 또는 음수 값을 지정하여 그림 프레임을 회전시킵니다.  
   * 양수 값은 이미지를 시계 방향으로 회전시킵니다.  
   * 음수 값은 이미지를 반시계 방향으로 회전시킵니다.  
10. 그림 프레임(그림 포함)을 슬라이드에 추가합니다.  
11. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 Java 코드는 그림 프레임 서식 지정 프로세스를 보여줍니다:  

```java
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image 클래스를 인스턴스화합니다
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 그림과 동일한 높이와 너비로 그림 프레임을 추가합니다
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

{{% alert title="Tip" color="primary" %}} 
Aspose는 최근에 무료 Collage Maker를 개발했습니다. JPG/JPEG([merge JPG/JPEG](https://products.aspose.app/slides/ko/collage/jpg)) 또는 PNG 이미지를 병합하거나 사진에서 그리드를 만들고 싶다면 이 서비스를 사용할 수 있습니다. 
{{% /alert %}}

## **링크로 이미지 추가**

프레젠테이션 파일 크기를 줄이기 위해 파일을 직접 삽입하는 대신 링크를 통해 이미지(또는 비디오)를 추가할 수 있습니다. 이 Java 코드는 플레이스홀더에 이미지와 비디오를 추가하는 방법을 보여줍니다:  

```java
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

    // 이미지 자르기 (백분율 값)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // 결과를 저장합니다
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **그림 프레임에서 자른 영역 삭제**

프레임에 포함된 이미지의 잘린 영역을 삭제하려면 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 메서드를 사용할 수 있습니다. 이 메서드는 잘린 이미지를 반환하거나, 자르기가 필요 없을 경우 원본 이미지를 반환합니다.  

```java
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

{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 메서드는 잘린 이미지를 프레젠테이션 이미지 컬렉션에 추가합니다. 이미지가 처리된 [PictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pictureframe/)에만 사용되는 경우 이 설정으로 프레젠테이션 크기를 줄일 수 있습니다. 그렇지 않으면 최종 프레젠테이션의 이미지 수가 증가합니다.  

이 메서드는 잘라내기 작업에서 WMF/EMF 메타파일을 래스터 PNG 이미지로 변환합니다. 
{{% /alert %}}

## **이미지 압축**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 메서드를 사용하여 프레젠테이션의 그림을 압축할 수 있습니다. 이 메서드는 도형 크기와 지정된 해상도에 따라 이미지 크기를 줄이며, 잘린 영역을 삭제하는 옵션도 제공합니다.  

이는 PowerPoint의 **Picture Format > Compress Pictures > Resolution** 기능과 유사하게 그림의 크기와 해상도를 조정합니다.  

다음 Java 예제는 목표 해상도를 지정하고 선택적으로 잘린 영역을 제거하여 프레젠테이션의 이미지를 압축하는 방법을 보여줍니다:  

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 이미지를 목표 해상도 150 DPI(웹 해상도)로 압축하고 잘린 영역을 제거합니다.
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

또는 직접 사용자 정의 DPI 값을 사용하는 방법:  

```java
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

{{% alert title="NOTE" color="warning" %}} 
이 메서드는 도형의 크기와 제공된 DPI를 기준으로 이미지를 낮은 해상도로 변환합니다. 파일 크기 최적화를 위해 잘린 영역을 삭제할 수도 있습니다.  
이미지가 메타파일(WMF/EMF) 또는 SVG인 경우 압축이 적용되지 않습니다. 또한 JPEG 품질은 해상도에 따라 보존되거나 약간 감소합니다(PowerPoint가 고해상도 JPEG를 처리하는 방식과 유사). 
{{% /alert %}}

## **가로세로 비율 잠금**

이미지를 포함한 도형의 가로세로 비율을 이미지 크기를 변경한 후에도 유지하려면 [setAspectRatioLocked](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 메서드를 사용하여 *Lock Aspect Ratio* 설정을 할 수 있습니다.  

다음 Java 코드는 도형의 가로세로 비율을 잠그는 방법을 보여줍니다:  

```java
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
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // 크기 조정 시 가로세로 비율을 유지하도록 도형을 설정합니다
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
이 *Lock Aspect Ratio* 설정은 도형 자체의 비율만 유지하고, 도형에 포함된 이미지는 영향을 받지 않습니다. 
{{% /alert %}}

## **StretchOff 속성 사용**

[IPictureFillFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPictureFillFormat) 인터페이스와 [PictureFillFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPictureFillFormat) 클래스의 [StretchOffsetLeft](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) 및 [StretchOffsetBottom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) 속성을 사용하면 채우기 사각형을 지정할 수 있습니다.  

이미지에 스트레칭이 지정되면 소스 사각형이 지정된 채우기 사각형에 맞게 확대/축소됩니다. 채우기 사각형의 각 가장자리는 도형 경계 상자의 해당 가장자리로부터 백분율 오프셋으로 정의됩니다. 양수 백분율은 내부 여백을, 음수 백분율은 외부 여백을 의미합니다.  

1. Presentation 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 사각형 `AutoShape`을 추가합니다.  
4. 이미지를 생성합니다.  
5. 도형의 채우기 유형을 설정합니다.  
6. 도형의 그림 채우기 모드를 설정합니다.  
7. 도형을 채우기 위해 이미지를 설정합니다.  
8. 이미지 오프셋을 도형 경계 상자의 해당 가장자리부터 지정합니다.  
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 Java 코드는 StretchOff 속성을 사용하는 과정을 보여줍니다:  

```java
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

    // Rectangle로 설정된 AutoShape을 추가합니다
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 도형의 채우기 유형을 설정합니다
    aShape.getFillFormat().setFillType(FillType.Picture);

    // 도형의 그림 채우기 모드를 설정합니다
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // 도형을 채우도록 이미지를 설정합니다
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 도형 경계 상자의 해당 가장자리로부터 이미지 오프셋을 지정합니다
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // PPTX 파일을 디스크에 저장합니다
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**PictureFrame에서 지원되는 이미지 형식을 어떻게 확인할 수 있나요?**  
Aspose.Slides는 래스터 이미지(PNG, JPEG, BMP, GIF 등)와 벡터 이미지(예: SVG)를 [PictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pictureframe/)에 할당된 이미지 객체를 통해 지원합니다. 지원되는 형식 목록은 슬라이드 및 이미지 변환 엔진의 기능과 대부분 겹칩니다.  

**수십 개의 대형 이미지를 추가하면 PPTX 크기와 성능에 어떤 영향을 줍니까?**  
큰 이미지를 직접 삽입하면 파일 크기와 메모리 사용량이 증가합니다. 이미지를 링크로 연결하면 프레젠테이션 크기를 줄일 수 있지만 외부 파일이 계속 접근 가능해야 합니다. Aspose.Slides는 파일 크기를 줄이기 위해 링크로 이미지를 추가하는 기능을 제공합니다.  

**이미지 객체가 실수로 이동/크기 조정되는 것을 어떻게 방지할 수 있나요?**  
[PictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pictureframe/)에 대해 [shape locks](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--)를 사용하여 이동 또는 크기 조정을 비활성화할 수 있습니다. 잠금 메커니즘은 다양한 도형 유형에 대해 지원되며, 여기에는 [PictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pictureframe/)도 포함됩니다.  

**프레젠테이션을 PDF/이미지로 내보낼 때 SVG 벡터 정확도가 보존되나요?**  
Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pictureframe/)에서 SVG를 원본 벡터 형태로 추출할 수 있게 합니다. PDF([exporting to PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/)) 또는 래스터 형식([exporting to PNG](/slides/ko/androidjava/convert-powerpoint-to-png/))으로 내보낼 때는 내보내기 설정에 따라 결과가 래스터화될 수 있습니다; 원본 SVG가 벡터로 저장된다는 사실은 추출 동작을 통해 확인할 수 있습니다.
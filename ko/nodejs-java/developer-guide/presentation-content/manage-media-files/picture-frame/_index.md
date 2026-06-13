---
title: JavaScript를 사용하여 프레젠테이션에서 그림 프레임 관리
linktitle: 그림 프레임
type: docs
weight: 10
url: /ko/nodejs-java/picture-frame/
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
- 가로 세로 비율
- 이미지 투명도
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 그림 프레임을 추가합니다. 작업 흐름을 간소화하고 슬라이드 디자인을 향상시킵니다."
---
## **소개**

그림 프레임은 이미지를 포함하는 도형입니다—프레임 안에 사진이 있는 것과 같습니다.  

그림 프레임을 통해 슬라이드에 이미지를 추가할 수 있습니다. 이렇게 하면 그림 프레임을 서식 지정함으로써 이미지를 서식 지정할 수 있습니다.

{{% alert title="Tip" color="primary" %}} 
Aspose는 무료 변환기—[JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 이미지로부터 빠르게 프레젠테이션을 만들 수 있게 합니다. 
{{% /alert %}} 

## **그림 프레임 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 객체와 연결된 [ImagesCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ImageCollection)에 이미지를 추가하여 `PPImage` 객체를 생성합니다.  
4. 이미지의 너비와 높이를 지정합니다.  
5. 참조된 슬라이드와 연결된 Shape 객체가 제공하는 `addPictureFrame` 메서드를 사용해 이미지의 너비와 높이를 기반으로 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PictureFrame)을 생성합니다.  
6. 슬라이드에 그림 프레임(그 안에 포함된 사진)을 추가합니다.  
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

이 JavaScript 코드는 그림 프레임을 만드는 방법을 보여줍니다:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // Image 클래스를 인스턴스화합니다
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 그림의 높이와 너비에 해당하는 그림 프레임을 추가합니다
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

그림 프레임을 사용하면 이미지를 기반으로 프레젠테이션 슬라이드를 빠르게 만들 수 있습니다. 그림 프레임을 Aspose.Slides의 저장 옵션과 결합하면 입력/출력 작업을 조작하여 이미지를 다른 형식으로 변환할 수 있습니다.

## **상대 스케일을 사용한 그림 프레임 만들기**

이미지의 상대적 스케일을 변경하여 보다 복잡한 그림 프레임을 만들 수 있습니다.  

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 이미지 컬렉션에 이미지를 추가합니다.  
4. 프레젠테이션 객체와 연결된 [ImagesCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ImageCollection)에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PPImage) 객체를 생성합니다.  
5. 그림 프레임 내에서 이미지의 상대적 너비와 높이를 지정합니다.  
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

이 JavaScript 코드는 상대 스케일을 사용한 그림 프레임 생성 방법을 보여줍니다:

```javascript
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // Image 클래스를 인스턴스화합니다
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 그림과 동일한 높이와 너비를 갖는 그림 프레임을 추가합니다
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 상대 스케일 너비와 높이 설정
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **그림 프레임에서 래스터 이미지 추출**

[PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PictureFrame) 객체에서 래스터 이미지를 추출하여 PNG, JPG 등 다양한 형식으로 저장할 수 있습니다. 아래 예제 코드는 문서 “sample.pptx”에서 이미지를 추출하고 PNG 형식으로 저장하는 방법을 보여줍니다.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **그림 프레임에서 SVG 이미지 추출**

프레젠테이션에 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/) 도형 안에 SVG 그래픽이 포함된 경우, Aspose.Slides for Node.js via Java를 사용하면 원본 벡터 이미지를 완전한 정밀도로 가져올 수 있습니다. 슬라이드의 Shape 컬렉션을 순회하면서 각 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/)을 확인하고, 해당 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/)가 SVG 콘텐츠를 보유하고 있는지 판단한 뒤, 해당 이미지를 원본 SVG 형식으로 디스크나 스트림에 저장할 수 있습니다.

다음 예제 코드는 그림 프레임에서 SVG 이미지를 추출하는 방법을 보여줍니다:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **이미지 투명도 가져오기**

Aspose.Slides를 사용하면 이미지에 적용된 투명도 효과를 가져올 수 있습니다. 이 JavaScript 코드는 해당 작업을 시연합니다:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **그림 프레임 서식 지정**

Aspose.Slides는 그림 프레임에 적용할 수 있는 다양한 서식 옵션을 제공합니다. 이러한 옵션을 사용하면 특정 요구 사항에 맞게 그림 프레임을 조정할 수 있습니다.  

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 프레젠테이션 객체와 연결된 [ImagesCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ImageCollection)에 이미지를 추가하여 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PPImage) 객체를 생성합니다.  
4. 이미지의 너비와 높이를 지정합니다.  
5. [addPictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 메서드를 통해 이미지의 너비와 높이를 기반으로 `PictureFrame`을 생성합니다.  
6. 슬라이드에 그림 프레임(그 안에 포함된 사진)을 추가합니다.  
7. 그림 프레임의 선 색상을 설정합니다.  
8. 그림 프레임의 선 두께를 설정합니다.  
9. 양수 혹은 음수 값을 지정하여 그림 프레임을 회전합니다.  
   * 양수 값은 이미지를 시계 방향으로 회전시킵니다.  
   * 음수 값은 이미지를 반시계 방향으로 회전시킵니다.  
10. 그림 프레임(그 안에 포함된 사진)을 슬라이드에 다시 추가합니다.  
11. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

이 JavaScript 코드는 그림 프레임 서식 지정 과정을 시연합니다:

```javascript
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // Image 클래스를 인스턴스화합니다
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 그림과 동일한 높이와 너비를 갖는 그림 프레임을 추가합니다
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // PictureFrameEx에 일부 서식을 적용합니다
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}} 
Aspose는 최근에 무료 **Collage Maker**([https://products.aspose.app/slides/ko/collage](https://products.aspose.app/slides/ko/collage))를 출시했습니다. JPG/JPEG([https://products.aspose.app/slides/ko/collage/jpg](https://products.aspose.app/slides/ko/collage/jpg))이나 PNG 이미지를 병합하거나([https://products.aspose.app/slides/ko/collage/photo-grid](https://products.aspose.app/slides/ko/collage/photo-grid)) 사진을 격자 형태로 만들고 싶을 때 이 서비스를 활용할 수 있습니다. 
{{% /alert %}} 

## **링크로 이미지 추가**

프레젠테이션 파일 크기를 줄이기 위해 파일을 직접 삽입하는 대신 링크를 통해 이미지(또는 비디오)를 추가할 수 있습니다. 이 JavaScript 코드는 자리표시자에 이미지와 비디오를 추가하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **이미지 자르기**

이 JavaScript 코드는 슬라이드에 있는 기존 이미지를 자르는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
// 새 이미지 객체를 생성합니다
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 슬라이드에 PictureFrame을 추가합니다
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // 이미지를 자릅니다 (백분율 값)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // 결과를 저장합니다
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **그림의 잘린 영역 삭제**

프레임에 포함된 이미지의 잘린 영역을 삭제하려면 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 메서드를 사용할 수 있습니다. 이 메서드는 잘린 이미지를 반환하거나, 잘라낼 필요가 없을 경우 원본 이미지를 반환합니다.

이 JavaScript 코드는 해당 작업을 시연합니다:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // 첫 번째 슬라이드에서 PictureFrame을 가져옵니다
    var picFrame = slide.getShapes().get_Item(0);
    // PictureFrame 이미지의 잘린 영역을 삭제하고 잘린 이미지를 반환합니다
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // 결과를 저장합니다
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 메서드는 잘린 이미지를 프레젠테이션 이미지 컬렉션에 추가합니다. 해당 이미지가 처리된 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/)에만 사용된다면 프레젠테이션 크기를 줄일 수 있습니다. 반대로 사용되는 이미지가 여러 개라면 결과 프레젠테이션의 이미지 수가 증가할 수 있습니다.  

이 메서드는 잘라내기 작업 중 WMF/EMF 메타파일을 래스터 PNG 이미지로 변환합니다. 
{{% /alert %}} 

## **이미지 압축**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) 메서드를 사용하면 프레젠테이션 내 이미지의 크기를 도형 크기와 지정된 해상도에 따라 줄이면서, 선택적으로 잘린 영역을 삭제할 수 있습니다.  

이 메서드는 PowerPoint의 **그림 서식 → 그림 압축 → 해상도** 기능과 유사하게 이미지의 크기와 해상도를 조정합니다.  

다음 JavaScript 예제는 목표 해상도를 지정하고 필요에 따라 잘린 영역을 제거하여 프레젠테이션에서 이미지를 압축하는 방법을 보여줍니다:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // 이미지를 150 DPI(웹 해상도) 목표 해상도로 압축하고 잘린 영역을 제거합니다.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // 압축 결과를 확인합니다.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

또는 다른 사전 정의된 DPI 값을 사용하는 경우:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // 이미지를 96 DPI(이메일 해상도)로 압축하고, 잘린 영역을 제거합니다.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
이 메서드는 도형 크기와 제공된 DPI에 따라 이미지를 낮은 해상도로 변환합니다. 파일 크기 최적화를 위해 잘린 영역을 삭제할 수도 있습니다. 이미지가 메타파일(WMF/EMF)이나 SVG인 경우 압축이 적용되지 않습니다. JPEG의 경우 해상도에 따라 품질이 유지되거나 약간 감소합니다(이는 PowerPoint가 고해상도 JPEG를 처리하는 방식과 유사합니다). 
{{% /alert %}} 

## **가로 세로 비율 고정**

이미지 크기를 변경해도 이미지가 포함된 도형의 가로 세로 비율을 유지하려면 [setAspectRatioLocked](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) 메서드를 사용해 *Lock Aspect Ratio* 설정을 활성화합니다.

이 JavaScript 코드는 도형의 가로 세로 비율을 고정하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // 크기 조정 시 가로 세로 비율을 유지하도록 도형을 설정합니다
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
*Lock Aspect Ratio* 설정은 도형 자체의 비율만 보존하며, 도형에 포함된 이미지의 비율은 영향을 받지 않습니다. 
{{% /alert %}} 

## **StretchOff 속성 사용**

[PictureFillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PictureFillFormat) 클래스의 [setStretchOffsetLeft](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) 및 [setStretchOffsetBottom](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) 메서드를 사용하면 채우기 사각형을 지정할 수 있습니다.  

이미지에 스트레칭을 지정하면 소스 사각형이 지정된 채우기 사각형에 맞게 스케일됩니다. 채우기 사각형의 각 가장자리는 도형 경계 상자의 해당 가장자리로부터 백분율 오프셋으로 정의됩니다. 양수 백분율은 안쪽 여백을, 음수 백분율은 바깥쪽 여백을 의미합니다.  

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 사각형 `AutoShape`을 추가합니다.  
4. 이미지를 생성합니다.  
5. 도형의 채우기 유형을 설정합니다.  
6. 도형의 그림 채우기 모드를 설정합니다.  
7. 도형을 채우기 위해 이미지를 설정합니다.  
8. 도형 경계 상자의 해당 가장자리로부터 이미지 오프셋을 지정합니다.  
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

이 JavaScript 코드는 StretchOff 속성을 사용하는 과정을 시연합니다:

```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var slide = pres.getSlides().get_Item(0);
    // ImageEx 클래스를 인스턴스화합니다
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Rectangle 모양으로 AutoShape을 추가합니다
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // 도형의 채우기 유형을 설정합니다
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // 도형의 그림 채우기 모드를 설정합니다
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // 도형을 채우는 이미지를 설정합니다
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // 도형 경계 상자의 해당 가장자리로부터 이미지 오프셋을 지정합니다
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**그림 프레임에서 지원되는 이미지 형식은 어떻게 확인할 수 있나요?**  
Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/)에 할당된 이미지 객체를 통해 래스터 이미지(PNG, JPEG, BMP, GIF 등)와 벡터 이미지(SVG 등)를 모두 지원합니다. 지원 형식 목록은 슬라이드 및 이미지 변환 엔진의 기능과 대체로 일치합니다.  

**수십 개의 대용량 이미지를 추가하면 PPTX 크기와 성능에 어떤 영향을 미치나요?**  
대용량 이미지를 삽입하면 파일 크기와 메모리 사용량이 증가합니다. 이미지에 링크를 사용하면 프레젠테이션 크기를 줄일 수 있지만 외부 파일이 계속 접근 가능해야 합니다. Aspose.Slides는 파일 크기 감소를 위해 링크로 이미지를 추가하는 기능을 제공합니다.  

**이미지 객체가 실수로 이동하거나 크기가 조정되는 것을 방지하려면 어떻게 해야 하나요?**  
[PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/)에 대해 [shape locks](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/getpictureframelock/)를 사용하면 이동 또는 크기 조정을 비활성화하는 등 잠금 기능을 적용할 수 있습니다. 이 잠금 메커니즘은 다양한 도형 유형에 대해 지원됩니다.  

**SVG 벡터 정확성이 PDF/이미지로 내보낼 때 유지되나요?**  
Aspose.Slides는 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/)에서 원본 SVG 벡터를 추출할 수 있게 합니다. [/slides/ko/nodejs-java/convert-powerpoint-to-pdf/](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/) 또는 [/slides/ko/nodejs-java/convert-powerpoint-to-png/](/slides/ko/nodejs-java/convert-powerpoint-to-png/) 로 내보낼 때, 내보내기 설정에 따라 결과가 래스터화될 수 있지만, 원본 SVG가 벡터로 저장된다는 사실은 추출 동작을 통해 확인됩니다.
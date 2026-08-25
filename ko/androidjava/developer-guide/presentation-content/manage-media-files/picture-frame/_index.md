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
- 삽입된 이미지
- 링크된 이미지
- 이미지 추출
- 래스터 이미지
- SVG 이미지
- 이미지 자르기
- 잘린 영역 삭제
- 이미지 압축
- StretchOffset
- 그림 프레임 서식
- 상대 스케일
- 이미지 효과
- 종횡비
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android(Java)를 사용하여 프레젠테이션에서 그림 프레임을 만들고, 서식 지정하고, 링크하고, 자르고, 추출하고, 압축합니다."
---
## **개요**

그림 프레임은 이미지를 표시하는 슬라이드 도형입니다. Aspose.Slides에서는 이미지 리소스와 이를 표시하는 도형이 별개의 객체로 존재합니다. [프레젠테이션](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/)은 [IImageCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagecollection/)을 통해 삽입된 이미지 리소스를 소유하고, [IPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/)은 이미지의 위치, 크기, 선 서식, 회전, 자르기, 그림 효과 및 기타 프레임 수준 설정을 제어합니다.

이러한 분리는 동일한 이미지를 여러 번 표시할 때 유용합니다. 이미지를 프레젠테이션에 한 번 추가하고 반환된 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/)을 보관한 뒤, 그림 프레임을 만들 때 해당 이미지 리소스를 사용합니다.

그림 프레임은 PNG 또는 JPEG와 같은 래스터 이미지와 SVG와 같은 벡터 이미지를 포함할 수 있습니다. 또한 이미지를 프레젠테이션에 저장하지 않고 링크된 이미지로 참조할 수도 있습니다. 선택에 따라 이식성, 파일 크기, 추출 및 내보내기 동작이 달라지므로, 서식 지정이나 최적화를 적용하기 전에 이미지가 어떻게 저장될지 결정하는 것이 좋습니다.

## **삽입된 이미지 추가 및 서식 지정**

삽입된 이미지의 경우, 이미지 데이터를 프레젠테이션에 추가하고 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)으로 그림 프레임을 만들면 됩니다. 이미지는 프레젠테이션 패키지의 일부가 되므로, 프레젠테이션을 다른 컴퓨터로 이동해도 자체 포함됩니다.

다음 예제는 JPEG 이미지를 추가하고, 이미지의 원본 차원으로 프레임을 만든 뒤, 선 서식과 회전을 적용합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

그림 프레임은 표시되는 기하학을 제어합니다; 프레임 크기를 변경해도 삽입된 이미지 리소스에 저장된 원본 픽셀 차원은 바뀌지 않습니다. 이 구분은 나중에 이미지를 자르거나 압축할 때 중요합니다.

## **상대 스케일 사용**

[IPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/)은 [setRelativeScaleWidth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-)와 [setRelativeScaleHeight](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-)을 통해 프레임의 상대 너비와 높이 스케일을 제공합니다. `1.0` 값은 원본 그림 크기의 100%에 해당합니다. 상대 스케일은 최종 차원을 수동으로 계산하기보다 원본 이미지 크기와의 비율을 보존해야 할 때 유용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

상대 스케일은 프레임의 스케일 설정만 변경하며, 삽입된 이미지를 재샘플링하거나 압축하지는 않습니다.

## **삽입 및 링크된 이미지**

삽입된 그림은 이미지 데이터를 프레젠테이션 내부에 저장하므로 이식성과 예측 가능한 렌더링을 위해 가장 안전한 선택입니다. 링크된 그림은 [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) 메서드를 사용해 외부 위치를 지정하며, 이미지 데이터를 동일한 방식으로 삽입하지 않습니다.

링크된 이미지는 PPTX에 저장되는 이미지 데이터 양을 줄일 수 있지만 외부 의존성을 초래합니다. 링크된 파일은 프레젠테이션을 열거나 렌더링하는 애플리케이션이 접근할 수 있는 상태여야 합니다. 경로가 변경되거나 파일이 이동되거나 리소스를 사용할 수 없게 되면 링크된 그림이 기대대로 표시되지 않을 수 있습니다. 이메일 전송, 보관 또는 격리된 환경에서 렌더링이 필요한 프레젠테이션은 보통 삽입된 이미지를 사용하는 것이 더 신뢰성이 높습니다.

### **링크된 이미지 추가**

다음 예제는 그림 프레임을 만들고 로컬 이미지 파일을 가리키도록 설정합니다. 이 예제는 이미지 링크만 다루며, 비디오 링크는 별도의 미디어 워크플로우이며 의도적으로 포함되지 않았습니다.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

외부 파일 관리가 의도된 경우에만 링크를 사용하십시오. 압축을 대신하는 용도로 사용하지 마세요. 깨진 이미지 종속성을 가진 작은 PPTX는 일반적으로 자체 포함된 큰 프레젠테이션보다 유용하지 않습니다.

## **그림 프레임에서 이미지 추출**

기존 프레젠테이션에서 이미지를 추출하기 전에 해당 도형이 실제로 [IPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/)인지, 그리고 삽입된 이미지를 포함하고 있는지 확인하십시오. 링크된 그림 프레임은 동일한 방식으로 추출할 수 있는 이미지 바이트를 포함하지 않을 수 있습니다.

### **래스터 이미지 추출**

최신 이미지 API는 [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/)를 직접 사용하며, 이전 Java 이미지 래퍼를 필요로 하지 않습니다. 다음 예제는 슬라이드에서 첫 번째 삽입된 래스터 그림을 찾아 PNG로 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

[IImage.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)을 통해 저장하면 추출된 이미지를 원하는 출력 형식으로 변환합니다. 프레젠테이션에 저장된 인코딩된 바이트가 필요하다면 변환된 래스터 파일 대신 이미지 리소스의 바이너리 데이터를 사용하십시오.

### **SVG 이미지 추출**

SVG 그림의 경우, [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/)가 [ISvgImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgimage/) 객체를 노출합니다. 이를 통해 SVG 데이터를 직접 가져올 수 있어, 먼저 그림을 래스터화할 필요가 없습니다.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

SVG 내용을 SVG 그대로 유지하면 프레젠테이션 내부에 벡터 소스가 보존됩니다. PNG나 JPEG와 같은 래스터 내보내기는 해당 벡터 내용을 픽셀로 렌더링합니다. PDF 또는 SVG 슬라이드 내보내기도 렌더링 작업이므로, 내보낸 그래픽을 원본 삽입된 SVG와 바이트 단위로 동일하게 취급해서는 안 됩니다; 원본 벡터 리소스 자체가 필요할 때는 삽입된 [ISvgImage.getSvgData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgimage/#getSvgData--) 데이터를 사용하십시오.

## **이미지 자르기**

자르기는 프레임 안에서 이미지의 어느 부분이 보일지를 변경합니다. [IPictureFillFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipicturefillformat/)의 자르기 값은 원본 이미지 차원의 백분율입니다. 자르기는 처음에 숨겨진 픽셀을 삽입된 이미지에서 삭제하지 않으며, 보이는 영역만 변경합니다.

다음 예제는 그림 프레임을 안전하게 찾고 자르기 값을 적용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

숨겨진 이미지 데이터가 그대로 남아 있기 때문에, 원본 픽셀을 잃지 않고 나중에 자르기 값을 변경할 수 있습니다. 파일 크기가 더 중요하고 복원 가능성이 필요 없을 경우, 다음 섹션에서 설명하는 대로 자른 영역을 물리적으로 제거할 수 있습니다.

## **잘린 이미지 데이터 제거**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)은 현재 자르기 사각형 밖의 이미지 데이터를 제거하고 결과 이미지 리소스를 반환합니다. 이는 파일 크기를 줄일 수 있지만 파괴적인 최적화이며, 프레젠테이션을 저장한 이후에는 제거된 픽셀을 다시 복구할 수 없습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

이 메서드는 프레젠테이션에 새 이미지 리소스를 추가할 수 있습니다. 원본 이미지가 다른 그림 프레임에서도 사용된다면 해당 프레임은 기존 리소스를 계속 사용해야 하므로, 자른 영역을 삭제해도 전체 이미지 수가 반드시 감소하는 것은 아닙니다. WMF 또는 EMF 콘텐츠를 이 메서드로 자를 경우 결과가 PNG로 래스터화됩니다.

## **래스터 이미지 압축**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-)은 그림이 표시되는 크기에 비해 래스터 이미지 해상도를 낮춥니다. 또한 동일 작업에서 잘린 영역을 제거할 수 있습니다. 메서드는 이미지가 리사이즈되거나 잘렸을 때 `true`를, 변경이 필요 없을 때 `false`를 반환합니다.

표준 목표 해상도가 충분한 경우, 미리 정의된 [PicturesCompression](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/picturescompression/) 값을 사용할 수 있습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

특정 목표 해상도가 필요한 경우, 사전 정의값 대신 사용자 정의 양의 DPI 값을 전달할 수 있습니다.

압축은 래스터 이미지에만 적용됩니다. SVG 및 메타파일 콘텐츠는 이 래스터 압축 워크플로우로 축소되지 않습니다. 또한 낮은 해상도와 삭제된 잘린 영역은 최적화된 프레젠테이션에서 복구할 수 없음을 기억하십시오. 전체적으로 가장 낮은 DPI를 적용하기보다 실제로 화면에 표시하거나 내보낼 가장 큰 크기를 기준으로 목표 해상도를 선택하십시오.

## **이미지 변환 효과 관리**

밝기, 대비, 색상 변환, 흐림, 알파 효과, 순서 체인, 검사, 제거 및 왕복 검증을 포함한 전체 워크플로우는 [이미지 변환 효과](/slides/ko/androidjava/image-transform-effects/)를 참고하십시오.

## **그림 프레임 기하학 잠금**

[IPictureFrameLock](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframelock/) 설정은 그림 프레임에 대해 어떤 편집 작업이 비활성화될지를 제어합니다. 예를 들어, [setAspectRatioLocked](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-)은 크기를 조정할 때 도형 비율을 유지합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

잠금은 그림 프레임 도형에만 적용되며, 원본 이미지를 재샘플링하거나 영구적으로 같은 종횡비로 변경하도록 강제하지는 않습니다.

## **StretchOffset 값 조정**

그림 채우기 모드가 stretch인 경우, [IPictureFillFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipicturefillformat/)의 stretch‑offset 값은 그림 프레임 경계 상자에 대한 채우기 사각형을 정의합니다. 양수 백분율은 가장자리에서 안쪽으로 inset을 만들고, 음수 백분율은 바깥쪽으로 outset을 만듭니다.

이는 자르기와 다릅니다. 자르기 값은 원본 이미지의 어느 부분을 표시할지를 선택하고, stretch offset은 표시되는 그림 채우기가 늘어나는 사각형을 변경합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

채우기 위치를 지정하려면 stretch offset을 사용하고, 원본 이미지 가장자리를 숨기고 싶다면 자르기 속성을 사용하십시오.

## **스토리지, 파일 크기 및 내보내기 고려 사항**

이미지 스토리지와 그림‑프레임 서식을 별도로 관리하면 주요 트레이드오프를 더 쉽게 파악할 수 있습니다:

- **삽입된 이미지**는 프레젠테이션을 자체 포함하게 하며, 공유 및 서버‑사이드 렌더링에 가장 안정적입니다. 하지만 큰 래스터 이미지는 PPTX 크기와 메모리 사용량을 증가시킵니다.
- **링크된 이미지**는 패키지를 작게 유지할 수 있지만, 프레젠테이션은 외부 파일이 지정된 경로나 위치에 계속 존재해야 합니다.
- **자르기**는 초기에는 비파괴적이며, 숨겨진 픽셀은 명시적으로 삭제하거나 압축 중에 제거될 때까지 삽입된 채로 남아 있습니다.
- **압축**은 과도한 래스터 이미지의 파일 크기를 크게 줄일 수 있지만 원본 해상도를 포기합니다. 슬라이드에 표시될 최종 크기가 확정된 후 적용해야 합니다.
- **SVG 이미지**는 벡터 보존이 중요한 경우 SVG 그대로 유지해야 합니다. 벡터 리소스 자체가 필요할 때는 삽입된 SVG를 직접 추출하십시오. 래스터 슬라이드 내보내기는 항상 렌더링된 슬라이드를 픽셀로 변환합니다.
- **반복 이미지**는 가능한 경우 동일한 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/) 리소스를 재사용하고, 동일 파일을 프레젠테이션 워크플로우에 여러 번 로드하지 않도록 하십시오.

대규모 프레젠테이션에서는 이미지 최적화를 선택적으로 수행하는 것이 가장 효과적입니다: 로고와 다이어그램은 벡터 콘텐츠로 유지하고, 사진은 실제 표시 크기에 맞게 압축하며, 나중에 편집이 필요 없을 경우에만 잘린 픽셀을 제거하고, 외부 링크는 의존성 관리가 배포 설계의 일부가 아닌 한 피하십시오.

## **FAQ**

**그림 프레임과 이미지 리소스의 차이는 무엇인가요?**

[IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/)는 프레젠테이션에 연결된 이미지 리소스를 나타냅니다. [IPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/)은 슬라이드에 배치된 도형으로, 이미지를 표시하고 크기, 회전, 잘라내기 값, 효과 및 잠금과 같은 프레임 수준의 기하학 및 서식을 저장합니다.

**이미지를 삽입해야 할지 링크해야 할지 어떻게 결정하나요?**

프레젠테이션을 이식 가능하게 하거나, 보관하거나, 외부 리소스 없이 렌더링해야 한다면 이미지를 삽입하십시오. 외부 파일을 PPTX 외부에 유지하고 그 위치를 안정적으로 관리할 수 있는 경우에만 이미지를 링크하십시오.

**자르기가 PPTX 파일 크기를 줄이나요?**

그 자체로는 줄어들지 않습니다. 일반적인 자르기 설정은 이미지의 일부를 숨기지만 기본 픽셀은 그대로 유지합니다. 숨긴 픽셀을 영구적으로 제거하려면 [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)를 사용하거나, 잘린 영역 제거와 함께 이미지 압축을 적용하십시오.

**압축 후에 이미지 품질을 복구할 수 있나요?**

아닙니다. 압축은 저장된 래스터 해상도를 낮추고, 잘린 영역을 제거하면 이미지 데이터가 사라집니다. 나중에 고해상도 편집이 필요할 경우 원본 이미지를 프레젠테이션 외부에 별도로 보관하십시오.

**SVG 이미지는 어떻게 다루어야 하나요?**

벡터 정확성이 중요한 경우 SVG 내용을 SVG 그대로 유지하십시오. 삽입된 [ISvgImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgimage/)를 직접 추출할 수 있습니다. PNG나 JPEG와 같은 래스터 형식으로 슬라이드를 내보내면 SVG가 슬라이드 이미지의 일부로 래스터화됩니다.

**기존 슬라이드를 읽을 때 안전하지 않은 형 변환을 어떻게 피할 수 있나요?**

도형 유형을 확인한 후에 그림‑프레임 전용 멤버를 사용하십시오. [IPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/)에 대한 `instanceof` 검사는 잘못된 형 변환을 방지하고, 그림 프레임이 포함되지 않은 슬라이드도 안전하게 처리할 수 있게 해줍니다.
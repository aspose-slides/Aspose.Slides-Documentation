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
- 임베디드 이미지
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
- 가로 세로 비율
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 프레젠테이션에서 그림 프레임을 만들고, 서식 지정하고, 연결하고, 자르고, 추출하고, 압축합니다."
---
## **개요**

그림 프레임은 이미지를 표시하는 슬라이드 도형입니다. Aspose.Slides에서는 이미지 리소스와 이를 표시하는 도형이 별개의 객체로 존재합니다: [Presentation]은 [IImageCollection]을 통해 임베디드 이미지 리소스를 소유하고, [IPictureFrame]은 이미지의 위치, 크기, 선 서식, 회전, 자르기, 그림 효과 및 기타 프레임 수준 설정을 제어합니다.

이러한 분리 방식은 동일한 이미지를 여러 번 표시할 때 유용합니다. 이미지를 프레젠테이션에 한 번 추가하고 반환된 [IPPImage]를 유지한 뒤, 그림 프레임을 만들 때 해당 이미지 리소스를 사용합니다.

그림 프레임은 PNG 또는 JPEG와 같은 래스터 이미지와 벡터 SVG 이미지를 모두 포함할 수 있습니다. 또한 이미지 바이트를 프레젠테이션에 저장하는 대신 연결된 이미지를 참조할 수도 있습니다. 선택에 따라 이동성, 파일 크기, 추출 및 내보내기 동작이 달라지므로 서식 지정이나 최적화를 적용하기 전에 이미지 저장 방식을 결정하는 것이 유용합니다.

## **임베디드 이미지 추가 및 서식 지정**

임베디드 이미지를 사용하려면 이미지 데이터를 프레젠테이션에 추가하고 [IShapeCollection.addPictureFrame]을 사용하여 그림 프레임을 생성합니다. 이미지가 프레젠테이션 패키지의 일부가 되므로 다른 컴퓨터로 옮겨도 프레젠테이션이 자체 포함된 상태를 유지합니다.

다음 예제는 JPEG 이미지를 추가하고, 이미지의 원본 크기로 프레임을 생성하며, 선 서식과 회전을 적용합니다:
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

그림 프레임은 표시되는 형상을 제어합니다; 프레임 크기를 변경해도 임베디드 이미지 리소스에 저장된 원본 픽셀 차원은 변경되지 않습니다. 이 구분은 나중에 이미지를 자르거나 압축할 때 중요해집니다.

## **상대 스케일 사용**

[IPictureFrame]은 [setRelativeScaleWidth]와 [setRelativeScaleHeight]를 통해 프레임의 상대적인 너비와 높이 스케일링을 노출합니다. 값 `1.0`은 원본 그림 크기의 100%에 해당합니다. 상대 스케일은 최종 차원을 수동으로 계산하는 대신 원본 이미지 크기와의 관계를 유지해야 할 때 유용합니다.
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

상대 스케일은 프레임의 스케일 설정을 변경하지만, 임베디드 이미지를 재샘플링하거나 압축하지는 않습니다.

## **임베디드 이미지와 링크된 이미지**

임베디드 그림은 이미지 데이터를 프레젠테이션 내부에 저장하므로 이동성과 예측 가능한 렌더링을 위해 가장 안전한 선택입니다. 링크된 그림은 [ISlidesPicture.setLinkPathLong] 메서드를 통해 외부 위치를 저장하며, 이미지 데이터를 동일하게 임베드하지 않습니다.

링크된 이미지는 PPTX에 저장되는 이미지 데이터 양을 줄일 수 있지만 외부 의존성을 초래합니다. 링크된 파일은 프레젠테이션을 열거나 렌더링하는 애플리케이션이 접근할 수 있어야 합니다. 경로가 변경되거나 파일이 이동되거나 리소스를 사용할 수 없게 되면 링크된 그림이 기대대로 표시되지 않을 수 있습니다. 이메일 전송, 보관 또는 격리된 환경에서 렌더링해야 하는 프레젠테이션의 경우 임베디드 이미지가 일반적으로 더 신뢰할 수 있습니다.

### **링크된 이미지 추가**

다음 예제는 그림 프레임을 생성하고 로컬 이미지 파일을 가리키도록 합니다. 이 예제는 이미지 연결만 다루며, 비디오 연결은 별도의 미디어 워크플로우이며 의도적으로 포함되지 않았습니다.
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

외부 파일 관리를 의도할 경우에만 링크를 사용하십시오. 압축을 대신하기 위해 링크를 사용하지 마세요: 이미지 종속성이 끊어진 작은 PPTX는 일반적으로 크기가 큰 자체 포함 프레젠테이션보다 덜 유용합니다.

## **그림 프레임에서 이미지 추출**

기존 프레젠테이션에서 이미지를 추출하기 전에 해당 도형이 실제로 [IPictureFrame]인지 그리고 임베디드 이미지를 포함하고 있는지 확인하십시오. 링크된 그림 프레임은 동일한 방식으로 추출할 수 있는 이미지 바이트를 포함하지 않을 수 있습니다.

### **래스터 이미지 추출**

최신 이미지 API는 [IImage]를 직접 사용하며, 오래된 Java 이미지 래퍼가 필요하지 않습니다. 다음 예제는 슬라이드에서 첫 번째 임베디드 래스터 그림을 찾아 PNG로 저장합니다:
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

[IImage.save]를 통해 저장하면 추출된 이미지를 요청된 출력 형식으로 변환합니다. 변환된 래스터 파일이 아니라 프레젠테이션에 저장된 인코딩된 바이트가 필요하면 이미지 리소스의 바이너리 데이터를 사용하십시오.

### **SVG 이미지 추출**

SVG 그림의 경우 [IPPImage]가 [ISvgImage] 객체를 노출합니다. 이를 통해 그림을 먼저 래스터화하지 않고 SVG 데이터를 직접 가져올 수 있습니다.
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

SVG 콘텐츠를 SVG 그대로 유지하면 프레젠테이션 내부에 벡터 소스를 보존합니다. PNG 또는 JPEG와 같은 래스터 내보내기는 해당 벡터 콘텐츠를 픽셀로 렌더링해야 합니다. PDF 또는 SVG 슬라이드 내보내기도 렌더링 작업이므로, 내보낸 그래픽을 원본 임베디드 SVG의 바이트-대-바이트 복사본으로 취급하지 말고 원본 벡터 리소스 자체가 필요할 때는 임베디드 [ISvgImage.getSvgData] 데이터를 사용하십시오.

## **이미지 자르기**

자르기는 프레임 안에서 이미지의 어느 부분이 보일지를 변경합니다. [IPictureFillFormat]의 자르기 값은 원본 이미지 차원의 백분율입니다. 자르기는 처음에 숨겨진 픽셀을 임베디드 이미지에서 삭제하지 않고, 보이는 영역만 변경합니다.

다음 예제는 그림 프레임을 안전하게 찾아 자르기 값을 적용합니다:
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

숨겨진 이미지 데이터가 여전히 존재하므로, 나중에 원본 픽셀을 잃지 않고 자르기를 변경할 수 있습니다. 파일 크기가 복구 가능성보다 중요하다면, 다음 섹션에 설명된 대로 잘린 영역을 물리적으로 제거할 수 있습니다.

## **잘린 이미지 데이터 제거**

[IPictureFillFormat.deletePictureCroppedAreas]는 현재 자르기 사각형 외부의 이미지 데이터를 제거하고 결과 이미지 리소스를 반환합니다. 이는 파일 크기를 줄일 수 있지만 파괴적인 최적화입니다: 프레젠테이션을 저장한 후에는 제거된 픽셀을 나중에 복구할 수 없습니다.
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

이 메서드는 프레젠테이션에 새로운 이미지 리소스를 추가할 수 있습니다. 원본 이미지가 다른 그림 프레임에서도 사용되는 경우, 해당 프레임은 기존 리소스를 계속 필요로 하므로 잘린 영역을 삭제해도 전체 이미지 수가 반드시 감소하는 것은 아닙니다. 이 방법으로 WMF 또는 EMF 콘텐츠를 자르면 잘린 결과가 PNG로 래스터화됩니다.

## **래스터 이미지 압축**

[IPictureFillFormat.compressImage]은 그림이 표시되는 크기에 비례하여 래스터 이미지 해상도를 낮춥니다. 또한 같은 작업에서 잘린 영역을 제거할 수 있습니다. 메서드는 이미지가 크기 조정 또는 자르기가 되었을 때 `true`를 반환하고, 변화가 필요 없을 때 `false`를 반환합니다.

표준 목표 해상도가 충분한 경우 미리 정의된 [PicturesCompression] 값을 사용하십시오:
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

특정 목표가 필요할 경우 미리 정의된 값 대신 사용자 지정 양의 DPI 값을 전달할 수 있습니다.

압축은 래스터 이미지를 대상으로 합니다. SVG 및 메타파일 콘텐츠는 이 래스터 압축 워크플로우로 감소되지 않습니다. 또한 낮은 해상도와 삭제된 잘린 영역은 최적화된 프레젠테이션에서 복구할 수 없음을 기억하십시오. 전역적으로 가장 낮은 DPI를 적용하기보다 이미지가 실제로 표시되거나 내보내지는 가장 큰 크기를 기준으로 목표 해상도를 선택하십시오.

## **이미지 효과 검사**

그림 효과는 프레임이 사용하는 그림에 저장됩니다. 이미지 변환 컬렉션에는 투명도를 위한 고정 알파 변조와 밝기 및 대비를 위한 광도와 같은 효과가 포함될 수 있습니다. 아래 예제는 슬라이드의 첫 번째 그림 프레임에서 두 종류의 효과를 안전하게 읽어옵니다:
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
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

이러한 효과는 프레임 내에서 이미지가 렌더링되는 방식을 변경하지만, 원본 임베디드 이미지 바이트를 다시 쓰지는 않습니다.

## **그림 프레임 형상 잠금**

[IPictureFrameLock] 설정은 그림 프레임에 대해 어떤 편집 작업이 비활성화되는지를 제어합니다. 예를 들어, [setAspectRatioLocked]은 크기 조정 시 도형의 비율을 유지합니다.
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

잠금은 그림 프레임 도형에 적용됩니다. 이는 원본 이미지를 재샘플링하거나 영구적으로 동일한 종횡비로 변경하도록 강제하지는 않습니다.

## **StretchOffset 값 조정**

그림 채우기 모드가 스트레치인 경우, [IPictureFillFormat]의 stretch-offset 값은 그림 프레임 경계 상자에 상대적인 채우기 사각형을 정의합니다. 양수 비율은 가장자리에서 안쪽으로 들어가게 하고, 음수 비율은 바깥쪽으로 나오게 합니다.

이는 자르기와 다릅니다. 자르기 값은 원본 이미지 중 어느 부분을 표시할지 선택하고, stretch offset은 표시되는 그림 채우기가 스트레치되는 사각형을 변경합니다.
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

채우기 위치 지정에는 stretch offset을 사용하십시오. 원본 이미지 가장자리를 숨기는 것이 목표라면 자르기 속성을 사용하십시오.

## **저장, 파일 크기 및 내보내기 고려 사항**

이미지 저장과 그림 프레임 서식을 별도로 관리하면 주요 트레이드오프를 더 쉽게 관리할 수 있습니다:

- **임베디드 이미지**는 프레젠테이션을 자체 포함하게 하며 공유 및 서버 측 렌더링에 가장 신뢰할 수 있지만, 큰 래스터 이미지는 PPTX 크기와 메모리 사용량을 증가시킵니다.
- **링크된 이미지**는 패키지 크기를 줄일 수 있지만, 프레젠테이션은 저장된 경로나 위치에 외부 파일이 유지되는지에 의존합니다.
- **자르기**는 초기에는 비파괴적입니다. 숨겨진 픽셀은 잘린 영역을 명시적으로 삭제하거나 압축 중에 제거하기 전까지는 임베디드된 상태로 남아 있습니다.
- **압축**은 과도한 크기의 래스터 이미지에 대해 파일 크기를 크게 줄일 수 있지만, 원본 해상도를 포기하게 됩니다. 슬라이드 내에서 의도된 크기를 알게 된 후 적용해야 합니다.
- **SVG 이미지**는 벡터 보존이 중요한 경우 SVG 그대로 유지해야 합니다. 벡터 리소스 자체가 필요할 때는 임베디드 SVG를 직접 추출하십시오. 래스터 슬라이드 내보내기는 항상 렌더링된 슬라이드를 픽셀로 변환합니다.
- **중복 이미지**는 가능한 경우 동일한 파일을 반복해서 로드하는 대신 기존 [IPPImage] 리소스를 재사용해야 합니다.

대형 프레젠테이션의 경우 이미지 최적화는 선택적으로 수행할 때 가장 효과적입니다: 로고와 다이어그램은 벡터 콘텐츠로 유지하고, 사진은 실제 표시 크기에 따라 압축하며, 이후 편집이 필요하지 않을 때만 잘린 픽셀을 제거하고, 의존성 관리가 배포 설계의 일부가 아닌 한 외부 링크는 피하십시오.

## **FAQ**

**그림 프레임과 이미지 리소스의 차이점은 무엇인가요?**

[IPPImage]은 프레젠테이션에 연결된 이미지 리소스를 나타냅니다. [IPictureFrame]은 슬라이드에 있는 도형으로 이미지를 표시하고 크기, 회전, 자르기 값, 효과 및 잠금과 같은 프레임 수준의 형상 및 서식을 저장합니다.

**이미지를 임베드해야 하나요, 링크해야 하나요?**

프레젠테이션이 이동 가능하고, 보관되거나 외부 리소스 없이 렌더링되어야 할 경우 이미지를 임베드하십시오. 이미지 파일을 PPTX 외부에 두는 것이 의도된 경우이며 외부 위치를 신뢰성 있게 유지할 수 있는 경우에만 이미지를 링크하십시오.

**자르기가 PPTX 파일 크기를 줄이나요?**

단독으로는 줄어들지 않습니다. 일반적인 자르기 설정은 원본 이미지의 일부를 숨기지만 기본 픽셀은 유지합니다. 해당 픽셀을 영구적으로 삭제할 수 있을 때는 [IPictureFillFormat.deletePictureCroppedAreas] 또는 잘린 영역 제거와 함께 이미지 압축을 사용하십시오.

**압축 후에 이미지 품질을 복구할 수 있나요?**

아니요. 압축은 저장된 래스터 해상도를 낮추며, 잘린 영역을 제거하면 이미지 데이터가 사라집니다. 나중에 고해상도 편집이 필요할 수 있다면 원본 이미지를 프레젠테이션 외부에 보관하십시오.

**SVG 이미지는 어떻게 처리해야 하나요?**

벡터 충실도가 중요할 경우 SVG 콘텐츠를 SVG 그대로 유지하십시오. 임베디드 [ISvgImage]는 직접 추출할 수 있습니다. PNG 또는 JPEG와 같은 래스터 형식으로 슬라이드를 렌더링하면 SVG가 슬라이드 이미지의 일부로 래스터화됩니다.

**기존 슬라이드를 읽을 때 안전하지 않은 형변환을 피하려면 어떻게 해야 하나요?**

그림 프레임 전용 멤버를 사용하기 전에 도형 유형을 확인하십시오. [IPictureFrame]에 대한 `instanceof` 검사는 잘못된 형변환을 방지하고, 그림 프레임이 포함되지 않은 슬라이드를 코드가 처리하도록 합니다.
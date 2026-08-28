---
title: Java에서 프레젠테이션 슬라이드를 이미지로 변환
linktitle: 슬라이드 이미지 변환
type: docs
weight: 35
url: /ko/java/convert-slide/
keywords:
- 슬라이드 변환
- 슬라이드 내보내기
- 슬라이드 이미지 변환
- 슬라이드 이미지 저장
- 슬라이드 EMF 변환
- 슬라이드 PNG 변환
- 슬라이드 JPEG 변환
- 슬라이드 비트맵 변환
- 슬라이드 TIFF 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PPT, PPTX 및 ODP 프레젠테이션의 슬라이드를 PNG, JPEG, GIF, TIFF, EMF 및 기타 이미지 형식으로 변환합니다."
---
## **소개**

Aspose.Slides for Java는 PowerPoint 및 OpenDocument 프레젠테이션의 개별 슬라이드를 PNG, JPEG, GIF, TIFF 및 기타 이미지 형식으로 렌더링할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계를 따르세요:

1. 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스으로 로드합니다.
2. 렌더링하려는 슬라이드를 선택합니다.
3. 필요한 경우 [RenderingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/renderingoptions/) 또는 [TiffOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/) 클래스를 사용하여 렌더링을 구성합니다.
4. 메서드 [ISlide.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/#getImage--)를 호출합니다. 이 메서드는 [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/) 객체를 반환합니다.
5. 메서드 [IImage.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/#save-java.lang.String-int-)를 호출하고 [ImageFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imageformat/) 값을 사용하여 출력 형식을 지정합니다.

## **슬라이드를 PNG 이미지로 변환**

가장 간단한 변환은 기본 렌더링 설정을 사용합니다. 결과 [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/) 객체는 메모리에서 처리하거나 파일로 저장할 수 있습니다.

다음 Java 예제는 첫 번째 슬라이드를 렌더링하고 PNG 이미지로 저장합니다:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **맞춤 크기로 슬라이드를 이미지로 변환**

[Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) 값을 허용하는 [ISlide.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) 오버로드를 사용하여 정확한 픽셀 크기로 슬라이드를 렌더링합니다.

다음 예제는 1820 × 1040 JPEG 이미지를 생성합니다:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **노트 및 주석이 포함된 슬라이드를 이미지로 변환**

기본적으로 슬라이드 이미지는 노트나 주석을 포함하지 않습니다. [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notescommentslayoutingoptions/) 객체를 [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 메서드에 전달하여 노트와 주석이 표시되는 위치를 제어합니다.

다음 예제는 잘린 노트를 슬라이드 아래에, 주석을 오른쪽에 배치합니다:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
슬라이드-이미지 변환 시, [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) 메서드에 [BottomFull](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notespositions/)을 전달하지 마세요. 노트에는 고정 이미지 크기보다 더 많은 텍스트가 들어갈 수 있습니다. 대신 [BottomTruncated](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notespositions/)를 사용하십시오.
{{% /alert %}}

## **TIFF 옵션을 사용해 슬라이드를 이미지로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/) 클래스를 사용하면 렌더링된 TIFF 이미지의 크기, 해상도 및 기타 속성을 제어할 수 있습니다.

다음 예제는 첫 번째 슬라이드를 300 DPI에서 2160 × 2880 TIFF 이미지로 렌더링합니다:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
JDK 9 이전 Java 버전에서는 TIFF 지원이 보장되지 않습니다.
{{% /alert %}}

## **모든 슬라이드를 이미지로 변환**

슬라이드 컬렉션을 반복하여 전체 프레젠테이션을 일련의 이미지로 변환합니다. 별도로 건너뛰지 않는 한 숨김 슬라이드도 포함됩니다.

다음 예제는 모든 슬라이드를 가로 및 세로 스케일 팩터 2인 JPEG 이미지로 렌더링합니다:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **향상된 메타파일(EMF) 출력 생성**

Enhanced Metafile (EMF)은 벡터 기반 그래픽을 Microsoft Office 또는 Windows 메타파일을 지원하는 다른 Windows 응용 프로그램과 교환해야 할 때 유용합니다. 픽셀 기반 이미지와 달리 EMF는 벡터 그리기 작업을 보존하여 크기 조정 시 선명도가 동일하게 유지됩니다. 그러나 EMF는 Windows 메타파일 지원 응용 프로그램을 위한 호환성 형식이며 보편적인 교환 형식은 아닙니다. 또한 복잡한 슬라이드 내용(비트맵 이미지 및 일부 효과 등)은 벡터 메타파일 컨테이너 내부에 래스터화된 요소로 저장될 수 있습니다.

### **슬라이드를 EMF로 내보내기**

[ISlide.writeAsEmf](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) 메서드는 [ISlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/)을 EMF 형식의 대상 스트림에 기록합니다. 다음 예제는 프레젠테이션을 로드하고 첫 번째 슬라이드를 선택한 후 EMF 파일 스트림에 기록합니다:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

호출자는 [ISlide.writeAsEmf](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-)에 전달된 스트림을 소유하며, 위와 같이 스트림을 닫는 책임이 있습니다.

### **SVG 이미지를 EMF로 변환하고 프레젠테이션에 추가**

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-)을 사용하여 SVG 콘텐츠를 EMF로 변환합니다. 결과 바이트는 [IImageCollection.addImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimagecollection/#addImage-byte:A-)을 통해 프레젠테이션에 추가할 수 있으며, [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)을 사용하여 슬라이드에 배치합니다.

다음 예제는 SVG 마크업에서 [SvgImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/svgimage/)을 생성하고, 이를 메모리 내 EMF로 변환한 뒤, 첫 번째 슬라이드에 메타파일을 삽입하고 프레젠테이션을 저장합니다:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-)은 대상 스트림의 소유권을 갖지 않습니다. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html)은 모든 생성 데이터를 메모리에 저장하므로 `toByteArray`를 호출하기 전에 위치를 재설정할 필요가 없습니다. 반환된 바이트 배열은 스트림을 닫은 후에도 유효합니다.

선택된 Aspose.Slides for Java 및 JDK 구성에서 지원하는 운영 체제에서 EMF 생성이 가능하지만, 폰트나 그래픽 종속성이 없을 경우 플랫폼마다 렌더링이 달라질 수 있습니다. 원본 내용에 사용된 폰트를 설치하거나 적절한 대체 폰트를 구성하고, Aspose.Slides for Java에 대한 [platform requirements](/slides/ko/java/system-requirements/)를 따른 뒤, 대상 EMF 사용 애플리케이션에서 결과를 검증하세요. Linux 및 macOS 애플리케이션은 Windows 메타파일을 표시·편집하는 지원이 제한적이거나 일관되지 않을 수 있습니다.

## **컬러 이모지 렌더링**

{{% alert title="Note" color="info" %}}
프레젠테이션 슬라이드를 이미지로 변환할 때 컬러 이모지를 올바르게 렌더링하려면, 프레젠테이션에 사용된 이모지 폰트가 변환을 수행하는 시스템에 설치되어 있어야 합니다. 예를 들어, 프레젠테이션이 **Segoe UI Emoji**를 사용하고 해당 폰트가 없으면 출력 이미지에서 이모지가 단색으로 표시될 수 있습니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides가 애니메이션이 포함된 슬라이드 렌더링을 지원합니까?**

아니요. [ISlide.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/#getImage--) 메서드는 슬라이드의 정적 이미지를 렌더링하며 애니메이션을 내보내지 않습니다.

**숨김 슬라이드를 이미지로 내보낼 수 있습니까?**

예. 숨김 슬라이드는 일반 슬라이드처럼 렌더링할 수 있습니다. 위 예제와 같이 처리 루프에 포함하면 됩니다.

**슬라이드 이미지에 그림자 및 기타 효과가 보존됩니까?**

예. Aspose.Slides는 슬라이드 이미지에 그림자, 투명도 및 기타 지원되는 그래픽 효과를 렌더링합니다.
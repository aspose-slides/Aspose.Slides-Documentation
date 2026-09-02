---
title: Java를 사용한 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/java/image/
keywords:
- 이미지 추가
- 그림 추가
- 이미지 교체
- 이미지 컬렉션
- 그림 프레임
- 링크된 이미지
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- SVG를 도형으로 변환
- 외부 SVG 리소스
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 래스터 및 SVG 이미지를 추가, 재사용, 링크, 교체 및 관리하는 방법을 배우세요."
---
## **소개**

Aspose.Slides for Java는 이미지 작업을 위한 여러 방법을 제공하며, 각각은 다른 목적을 가집니다. 이미지를 프레젠테이션에 저장하고, 그림 프레임에 표시하고, 슬라이드 배경으로 사용하고, 외부 이미지에 링크하고, 공유 이미지 리소스를 교체하거나, SVG 콘텐츠를 편집 가능한 도형으로 변환할 수 있습니다.

이 문서는 이미지 리소스와 프레젠테이션 전체에서의 사용 방법에 초점을 맞춥니다. 개별 그림 프레임에 적용되는 잘라내기, 투명도, 효과, 스트레칭 및 기타 형식 지정에 대해서는 [그림 프레임](/slides/ko/java/picture-frame/)을 참조하십시오.

## **이미지 모델 이해**

다음 API 개념은 서로 밀접하게 연관되어 있지만 교환할 수는 없습니다:

- 프레젠테이션 이미지 컬렉션([프레젠테이션 이미지 컬렉션](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimagecollection/))은 프레젠테이션에서 사용되는 이미지 리소스를 저장합니다. 이미지 데이터를 추가하고 [IPPImage] 리소스를 얻으려면 [ImageCollection.addImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imagecollection/)을 사용하십시오.
- [그림 프레임](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipictureframe/)은 슬라이드, 레이아웃 또는 마스터에 이미지를 표시하는 도형입니다. 슬라이드에 이미지 리소스를 배치하려면 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/)을 사용하십시오.
- 슬라이드 배경은 도형이 아니라 슬라이드 채우기의 일부로 이미지를 사용합니다. 따라서 그림 프레임처럼 동작하지 않습니다.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/)은 이미지 리소스를 교체합니다. 여러 프레젠테이션 요소가 해당 리소스를 사용하면 모두 교체된 리소스를 사용하게 됩니다.
- SVG를 도형으로 변환하면 편집 가능한 슬라이드 도형이 생성됩니다. 변환 후에는 해당 내용이 하나의 이미지 리소스로 관리되지 않습니다.

따라서 일반적인 작업 흐름은 다음과 같습니다: 이미지 데이터를 이미지 컬렉션에 추가하고, [IPPImage]를 받아서, 해당 리소스를 하나 이상의 그림 프레임이나 채우기에서 사용합니다.

## **임베드된 이미지 추가**

로컬 이미지를 삽입하려면 파일을 로드하고, 이미지 컬렉션에 추가한 뒤, 반환된 `IPPImage`를 사용하는 그림 프레임을 생성합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이렇게 추가된 이미지는 프레젠테이션에 임베드되므로, 결과 파일은 원본 이미지 파일이 계속 존재할 필요가 없습니다.

### **웹에서 이미지 추가**

이미지가 HTTP 또는 HTTPS를 통해 제공되는 경우, 바이트를 다운로드하고, 프레젠테이션 이미지 컬렉션에 추가한 뒤, 반환된 이미지 리소스를 로컬 이미지와 동일한 방식으로 사용합니다.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

장기간 실행되는 애플리케이션에서는 불필요한 네트워킹 인프라를 반복해서 생성하는 대신 애플리케이션에 적합한 HTTP 클라이언트 또는 연결 관리 전략을 재사용하십시오. 또한 소스가 신뢰되지 않을 경우 원격 URL, 응답 크기 및 콘텐츠 유형을 검증해야 합니다.

## **슬라이드 간 이미지 재사용**

같은 이미지가 여러 번 필요하면 프레젠테이션에 한 번만 추가하고, 추가 그림 프레임을 만들 때 반환된 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/)를 재사용하십시오. 이렇게 하면 동일한 원본 데이터를 반복적으로 로드하는 것을 방지하고, 공유 이미지 리소스와 사용 간의 관계가 명확해집니다.

회사 로고와 같이 여러 슬라이드에 자동으로 나타나야 하는 그래픽의 경우, 각 슬라이드에 동일한 도형을 추가하는 대신 [슬라이드 마스터](/slides/ko/java/slide-master/) 또는 레이아웃에 그림 프레임을 배치하는 것을 고려하십시오.

## **이미지를 슬라이드 배경으로 사용하기**

배경 이미지는 슬라이드 채우기에 할당되며, 그림 프레임 도형으로 추가되지 않습니다. 그림이 슬라이드 배경을 전체적으로 덮고 일반 슬라이드 객체처럼 조작되지 않아야 할 때 유용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

마스터 및 레이아웃 배경을 포함한 추가 배경 옵션은 [프레젠테이션 배경](/slides/ko/java/presentation-background/)을 참조하십시오.

## **임베드된 이미지와 링크된 이미지**

임베드된 이미지와 링크된 이미지는 휴대성 및 파일 크기 측면에서 서로 다른 장단점이 있습니다:

- **임베드된 이미지:** 이미지 데이터가 프레젠테이션 내부에 저장됩니다. 프레젠테이션은 자체 포함되지만 파일 크기에 이미지 데이터가 포함됩니다.
- **링크된 이미지:** 프레젠테이션은 외부 이미지에 대한 경로나 URL을 저장합니다. 이렇게 하면 프레젠테이션 크기를 줄일 수 있지만, 프레젠테이션을 열거나 렌더링할 때 외부 리소스에 접근할 수 있어야 합니다.

이미지 데이터를 임베드하는 대신 [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islidespicture/)을 통해 외부 경로나 URL을 지정함으로써 링크된 그림을 만들 수 있습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

배포 환경에서 외부 리소스에 안정적으로 접근할 수 있는 경우에만 링크된 이미지를 사용하십시오. 오프라인에서 작동하거나 시스템 간에 이동해야 하는 프레젠테이션의 경우, 일반적으로 임베드된 이미지가 더 안전합니다.

## **SVG 이미지 작업**

SVG는 벡터 형식이므로 아이콘, 다이어그램 및 래스터 이미지와 달리 상세도가 손실되지 않고 확대/축소가 가능한 그래픽에 유용합니다. Aspose.Slides는 SVG를 이미지 리소스로뿐만 아니라 편집 가능한 슬라이드 도형의 소스로도 지원합니다.

### **SVG를 이미지로 추가**

먼저 [SvgImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/svgimage/)을 생성하고, 이미지 컬렉션에 추가한 뒤, 결과 이미지 리소스를 그림 프레임에 배치합니다.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **외부 리소스를 포함하는 SVG 파일**

SVG는 외부 이미지, 스타일시트 또는 폰트를 참조할 수 있습니다. 이러한 경우를 위해 [SvgImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/svgimage/)는 [IExternalResourceResolver](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iexternalresourceresolver/)와 기본 URI를 받아들이는 생성자를 제공합니다. 리졸버는 상대 URI를 허용된 절대 URI로 매핑하고, 요청된 리소스에 대한 스트림을 반환할 수 있습니다.

리졸버는 Aspose.Slides가 SVG를 처리하는 동안 외부 리소스를 사용할 수 있게 하지만, SVG를 자체 포함 문서로 재작성하지는 않습니다. SVG가 휴대성을 유지해야 하는 경우, 예를 들어 링크된 이미지에 `data:` URI를 사용하여 필요한 리소스를 SVG 자체에 임베드하십시오.

SVG 파일이 신뢰되지 않은 출처에서 제공되는 경우, 리졸버가 접근할 수 있는 스킴, 파일 위치 및 호스트를 제한하십시오. 네트워크 리졸버는 또한 타임아웃, 응답 크기 제한 및 콘텐츠 검증을 적용해야 합니다.

### **SVG를 편집 가능한 도형으로 변환**

Aspose.Slides는 SVG를 편집 가능한 슬라이드 도형 그룹으로 변환할 수 있으며, 이는 해당 PowerPoint 명령과 유사합니다.

![PowerPoint 팝업 메뉴](img_01_01.png)

변환을 수행하려면 [ISvgImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isvgimage/)을 받아들이는 [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/) 오버로드를 사용하십시오.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

개별 벡터 요소를 PowerPoint 도형으로 편집해야 할 때 SVG를 도형으로 변환하십시오. SVG를 단순히 표시만 하면 된다면 이미지를 유지하는 것이 더 간단하고 많은 개별 도형을 생성하는 것을 방지합니다.

## **기존 이미지 리소스 교체**

기존 이미지 리소스를 교체하려면 [IPPImage.replaceImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/)을 사용하십시오. 로고와 같은 공유 그래픽에 특히 유용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

여러 그림 프레임, 배경, 마스터 또는 레이아웃이 동일한 이미지 리소스를 사용할 경우, 해당 리소스를 교체하면 모든 사용이 업데이트됩니다. 하나의 그림 프레임만 변경해야 한다면, 공유 리소스를 교체하는 대신 해당 프레임에 다른 이미지를 할당하십시오.

`replaceImage`는 바이트 배열이나 다른 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/)을 받는 오버로드도 제공합니다.

## **실용적인 이미지 관리 지침**

### **프레젠테이션 크기 제어**

큰 래스터 이미지는 프레젠테이션을 불필요하게 크게 만들 수 있습니다. 의도된 표시 크기에 맞는 해상도의 원본 이미지를 사용하고, 가능한 경우 공유 이미지 리소스를 재사용하며, 동일한 고해상도 그래픽의 반복 복제본을 임베드하지 않도록 하십시오.

이미 그림 프레임에 배치된 래스터 사진의 경우, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipicturefillformat/)을 사용하여 선택된 해상도와 잘라내기 설정에 따라 이미지 데이터를 줄일 수 있습니다. 이는 이미지 컬렉션 관리가 아니라 그림 프레임 처리이므로 관련 형식 지정 작업은 [그림 프레임](/slides/ko/java/picture-frame/)을 참고하십시오.

### **임베드된 콘텐츠와 링크된 콘텐츠 선택**

임베드하면 모든 필요한 이미지 데이터가 파일에 포함되므로 프레젠테이션이 휴대 가능해집니다. 링크는 파일 크기를 줄일 수 있지만 외부 의존성을 도입합니다. 해당 의존성이 허용 가능하고 안정적일 때만 링크를 사용하십시오.

### **공유 브랜딩 재사용**

반복되는 로고, 워터마크 또는 장식 그래픽의 경우 하나의 이미지 리소스를 사용하고 재사용하십시오. 그래픽이 슬라이드 내용이 아니라 프레젠테이션 디자인에 해당한다면 마스터나 레이아웃에 배치하여 해당 슬라이드에 상속되도록 하십시오.

### **SVG 리소스 휴대성 유지**

자체 포함 SVG는 외부 파일이나 네트워크 리소스에 의존하는 SVG보다 이동 및 일관된 렌더링이 용이합니다. 가능한 경우 SVG를 가져오기 전에 필요한 리소스를 임베드하십시오. 개별 벡터 요소를 편집해야 할 때만 SVG를 도형으로 변환하십시오.

### **모던 크로스 플랫폼 이미지 API 사용**

새 Java 코드에서는 레거시 `java.awt.image.BufferedImage` 기반 공개 API 대신 Aspose.Slides [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/) 및 [Images](https://reference.aspose.com/slides/ko/java/com.aspose.slides/images/) API를 사용하십시오. 마이그레이션 가이드는 [모던 API](/slides/ko/java/modern-api/)를 참고하십시오.

WMF와 EMF는 특별한 고려가 필요합니다. 이러한 포맷을 [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/)를 통해 전달할 때, [ImageCollection.addImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imagecollection/)은 삽입 전에 메타파일을 래스터 PNG 형태로 변환합니다. 메타파일 데이터를 유지하는 것이 중요하면 스트림 기반 [ImageCollection.addImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imagecollection/) 오버로드를 사용하십시오. 스프레드시트나 기타 제품에서 EMF 콘텐츠를 생성하는 것은 별도 통합 워크플로이며 이 문서 범위에 포함되지 않습니다.

## **FAQ**

**이미지 컬렉션과 그림 프레임의 차이점은 무엇입니까?**

이미지 컬렉션은 재사용 가능한 이미지 리소스를 저장합니다. 그림 프레임은 해당 리소스 중 하나를 표시하고, 잘라내기 및 효과와 같은 그림 전용 형식 지정 기능을 제공하는 슬라이드 도형입니다.

**모든 곳에서 동일한 로고를 교체하는 가장 좋은 방법은 무엇입니까?**

로고가 이미 하나의 이미지 리소스로 공유되어 있다면, 해당 리소스를 [IPPImage.replaceImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/)으로 교체하십시오. 프레젠테이션 전체 브랜딩을 위해서는 로고를 마스터나 레이아웃에 배치하면 중복된 슬라이드 내용을 줄일 수 있습니다.

**다른 컴퓨터에서 링크된 이미지가 사라지는 이유는 무엇입니까?**

링크된 그림은 외부 파일이나 URL에 의존합니다. 해당 리소스에 다른 컴퓨터에서 접근할 수 없으면 링크된 이미지가 표시되지 않을 수 있습니다. 프레젠테이션이 자체 포함되어야 할 경우 이미지를 임베드하십시오.

**삽입된 SVG를 PowerPoint 도형으로 편집할 수 있습니까?**

예. [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/)을 사용해 SVG를 변환하면, 결과 그룹에는 하나의 SVG 이미지 대신 편집 가능한 슬라이드 도형이 포함됩니다.

**이미지가 많은 프레젠테이션을 어떻게 작게 유지할 수 있나요?**

공유 이미지 리소스를 재사용하고, 불필요하게 큰 래스터 소스를 피하며, 적절한 경우 래스터 사진을 압축하고, 반복되는 브랜딩은 마스터나 레이아웃에 유지하며, 외부 의존성이 허용될 때만 링크된 이미지를 사용하십시오.
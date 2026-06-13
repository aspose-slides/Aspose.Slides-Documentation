---
title: Java를 사용한 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/java/image/
keywords:
- 이미지 추가
- 그림 추가
- 비트맵 추가
- 이미지 교체
- 그림 교체
- 웹에서
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- EMF 추가
- WMF 추가
- TIFF 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- EMF
- SVG
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument에서 이미지 관리를 간소화하고 성능을 최적화하며 작업 흐름을 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 더 매력적이고 흥미롭게 만듭니다. Microsoft PowerPoint에서는 파일, 인터넷 또는 기타 위치에서 사진을 슬라이드에 삽입할 수 있습니다. 마찬가지로 Aspose.Slides를 사용하면 다양한 방법으로 프레젠테이션 슬라이드에 이미지를 추가할 수 있습니다.

{{% alert  title="Tip" color="primary" %}} 

Aspose는 무료 변환기—[JPEG를 PowerPoint로](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG를 PowerPoint로](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 사용자가 이미지를 신속하게 프레젠테이션으로 만들 수 있게 합니다. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

이미지를 프레임 개체로 추가하려는 경우—특히 표준 서식 옵션을 사용해 크기를 변경하거나 효과를 추가하려는 경우—[그림 프레임](https://docs.aspose.com/slides/ko/java/picture-frame/)을 참조하십시오. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

이미지와 PowerPoint 프레젠테이션 간의 입출력 작업을 조작하여 이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 다음 페이지를 확인하십시오: 변환 [image to JPG](https://products.aspose.com/slides/ko/java/conversion/image-to-jpg/); 변환 [JPG to image](https://products.aspose.com/slides/ko/java/conversion/jpg-to-image/); 변환 [JPG to PNG](https://products.aspose.com/slides/ko/java/conversion/jpg-to-png/), 변환 [PNG to JPG](https://products.aspose.com/slides/ko/java/conversion/png-to-jpg/); 변환 [PNG to SVG](https://products.aspose.com/slides/ko/java/conversion/png-to-svg/), 변환 [SVG to PNG](https://products.aspose.com/slides/ko/java/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides는 JPEG, PNG, GIF 등 인기 있는 형식의 이미지 작업을 지원합니다. 

## **로컬에 저장된 이미지 슬라이드에 추가**

컴퓨터에 있는 하나 이상의 이미지를 프레젠테이션의 슬라이드에 추가할 수 있습니다. 다음 Java 샘플 코드는 슬라이드에 이미지를 추가하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **웹에서 이미지 슬라이드에 추가**

컴퓨터에 이미지가 없는 경우 웹에서 직접 이미지를 가져와 슬라이드에 추가할 수 있습니다. 

다음 샘플 코드는 웹에서 이미지를 가져와 Java 슬라이드에 추가하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **슬라이드 마스터에 이미지 추가**

슬라이드 마스터는 모든 하위 슬라이드에 대한 테마, 레이아웃 등을 저장하고 제어하는 상위 슬라이드입니다. 따라서 슬라이드 마스터에 이미지를 추가하면 해당 마스터 아래 모든 슬라이드에 이미지가 표시됩니다. 

다음 Java 샘플 코드는 슬라이드 마스터에 이미지를 추가하는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **슬라이드 배경으로 이미지 추가**

특정 슬라이드 또는 여러 슬라이드의 배경으로 사진을 사용하려는 경우 *[슬라이드 배경에 이미지 설정](https://docs.aspose.com/slides/ko/java/presentation-background/#setting-images-as-background-for-slides)*을 확인하십시오.

## **프레젠테이션에 SVG 추가**
[addPictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 메서드를 사용하여 [IShapeCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection) 인터페이스에 SVG 이미지를 삽입할 수 있습니다.

SVG 이미지를 기반으로 이미지 개체를 생성하려면 다음과 같이 하면 됩니다:

1. SvgImage 개체를 생성하여 ImageShapeCollection에 삽입
2. ISvgImage에서 PPImage 개체를 생성
3. IPPImage 인터페이스를 사용하여 PictureFrame 개체 생성

다음 샘플 코드는 위 단계를 구현하여 SVG 이미지를 프레젠테이션에 추가하는 방법을 보여줍니다:
```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
            ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SVG를 도형 집합으로 변환**
Aspose.Slides의 SVG를 도형 집합으로 변환하는 기능은 PowerPoint에서 SVG 이미지를 다루는 기능과 유사합니다:

![PowerPoint 팝업 메뉴](img_01_01.png)

이 기능은 [IShapeCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection) 인터페이스의 [addGroupShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) 메서드 중 하나의 오버로드를 통해 제공되며, 첫 번째 인수로 [ISvgImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISvgImage) 개체를 받습니다.

다음 샘플 코드는 해당 메서드를 사용해 SVG 파일을 도형 집합으로 변환하는 방법을 보여줍니다:

```java
// 새 프레젠테이션 생성
IPresentation presentation = new Presentation();
try {
    // SVG 파일 내용 읽기
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // SvgImage 객체 생성
    ISvgImage svgImage = new SvgImage(svgContent);

    // 슬라이드 크기 가져오기
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG 이미지를 슬라이드 크기에 맞게 확대하여 도형 그룹으로 변환
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // 프레젠테이션을 PPTX 형식으로 저장
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **이미지를 EMF로 슬라이드에 추가**
Aspose.Slides for Java는 Excel 시트에서 EMF 이미지를 생성하고 Aspose.Cells와 함께 슬라이드에 EMF 이미지로 추가할 수 있게 합니다.  

다음 샘플 코드는 해당 작업을 수행하는 방법을 보여줍니다:

```java
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//워크북을 스트림에 저장
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **이미지 컬렉션의 이미지 교체**

Aspose.Slides는 프레젠테이션의 이미지 컬렉션(슬라이드 도형이 사용하는 이미지 포함)에 저장된 이미지를 교체할 수 있게 합니다. 이 섹션에서는 컬렉션의 이미지를 업데이트하는 여러 접근 방식을 보여줍니다. API는 원시 바이트 데이터, [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/) 인스턴스 또는 컬렉션에 이미 존재하는 다른 이미지를 사용해 이미지를 교체하는 간단한 메서드를 제공합니다.

다음 단계를 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스를 사용해 이미지가 포함된 프레젠테이션 파일을 로드합니다.
1. 파일에서 새 이미지를 바이트 배열로 로드합니다.
1. 바이트 배열을 사용해 대상 이미지를 새 이미지로 교체합니다.
1. 두 번째 접근 방식에서는 이미지를 [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/) 객체로 로드하고 해당 객체로 대상 이미지를 교체합니다.
1. 세 번째 접근 방식에서는 프레젠테이션 이미지 컬렉션에 이미 존재하는 이미지를 사용해 대상 이미지를 교체합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation("sample.pptx");
try {
    // 첫 번째 방법.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // 두 번째 방법.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // 세 번째 방법.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // 프레젠테이션을 파일에 저장합니다.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 사용하면 텍스트를 애니메이션화하거나 텍스트에서 GIF를 손쉽게 만들 수 있습니다. 

{{% /alert %}}

## **FAQ**

**삽입 후 원본 이미지 해상도가 유지되나요?**

네. 원본 픽셀은 보존되지만 최종 모습은 슬라이드에서 [picture](/slides/ko/java/picture-frame/)가 어떻게 스케일링되는지와 저장 시 적용되는 압축에 따라 달라집니다.

**여러 슬라이드에 걸쳐 동일한 로고를 한 번에 교체하려면 가장 좋은 방법은 무엇인가요?**

마스터 슬라이드 또는 레이아웃에 로고를 배치하고 프레젠테이션 이미지 컬렉션에서 교체하면 해당 리소스를 사용하는 모든 요소에 업데이트가 전파됩니다.

**삽입된 SVG를 편집 가능한 도형으로 변환할 수 있나요?**

네. SVG를 도형 그룹으로 변환하면 개별 파트를 표준 도형 속성을 사용해 편집할 수 있습니다.

**여러 슬라이드에 동시에 배경 그림을 설정하려면 어떻게 해야 하나요?**

마스터 슬라이드 또는 해당 레이아웃에서 [이미지를 배경으로 지정](/slides/ko/java/presentation-background/)하면 해당 마스터/레이아웃을 사용하는 모든 슬라이드가 배경을 상속합니다.

**많은 사진으로 인해 프레젠테이션 파일 크기가 급증하는 것을 방지하려면 어떻게 해야 하나요?**

이미지 중복을 피하고 하나의 이미지 리소스를 재사용하며 적절한 해상도를 선택하고 저장 시 압축을 적용하고, 가능한 경우 마스터에 반복 그래픽을 두어 크기를 관리합니다.
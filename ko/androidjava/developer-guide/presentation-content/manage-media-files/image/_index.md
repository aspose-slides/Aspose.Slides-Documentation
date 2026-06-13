---
title: Android에서 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/androidjava/image/
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
- Android
- Java
- Aspose.Slides
description: "Java를 통한 Android용 Aspose.Slides로 PowerPoint 및 OpenDocument의 이미지 관리를 간소화하여 성능을 최적화하고 작업 흐름을 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 보다 매력적이고 흥미롭게 만듭니다. Microsoft PowerPoint에서는 파일, 인터넷 또는 기타 위치에서 사진을 슬라이드에 삽입할 수 있습니다. 마찬가지로 Aspose.Slides를 사용하면 다양한 방법으로 프레젠테이션의 슬라이드에 이미지를 추가할 수 있습니다.

{{% alert  title="Tip" color="primary" %}} 

Aspose는 무료 변환기—[JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 사용자가 이미지를 빠르게 프레젠테이션으로 만들 수 있도록 합니다. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

이미지를 프레임 객체로 추가하고 싶다면—특히 크기 변경, 효과 추가 등 표준 서식 옵션을 사용할 계획이라면—[Picture Frame](https://docs.aspose.com/slides/ko/androidjava/picture-frame/)를 참조하십시오.

{{% /alert %}} 

Aspose.Slides는 JPEG, PNG, GIF 등과 같은 일반적인 이미지 형식에 대한 작업을 지원합니다. 

## **로컬에 저장된 이미지를 슬라이드에 추가**

컴퓨터에 있는 하나 이상의 이미지를 프레젠테이션 슬라이드에 추가할 수 있습니다. 다음 Java 샘플 코드는 이미지을 슬라이드에 추가하는 방법을 보여줍니다:

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

슬라이드에 추가하려는 이미지가 컴퓨터에 없을 경우 웹에서 직접 이미지를 추가할 수 있습니다. 

다음 Java 샘플 코드는 웹에서 이미지를 슬라이드에 추가하는 방법을 보여줍니다:

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

슬라이드 마스터는 해당 슬라이드 아래 모든 슬라이드에 대한 정보(테마, 레이아웃 등)를 저장하고 제어하는 최상위 슬라이드입니다. 따라서 슬라이드 마스터에 이미지를 추가하면 해당 이미지가 마스터 아래 모든 슬라이드에 나타납니다. 

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

특정 슬라이드 또는 여러 슬라이드의 배경으로 그림을 사용할 수 있습니다. 이 경우 *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/ko/androidjava/presentation-background/#setting-images-as-background-for-slides)* 를 참고하십시오.

## **프레젠테이션에 SVG 추가**

프레젠테이션에 이미지를 추가하거나 삽입하려면 [IShapeCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShapeCollection) 인터페이스에 속한 [addPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 메서드를 사용할 수 있습니다.

SVG 이미지를 기반으로 이미지 객체를 만들려면 다음과 같이 할 수 있습니다:

1. SvgImage 객체를 생성하여 ImageShapeCollection에 삽입합니다
2. ISvgImage에서 PPImage 객체를 생성합니다
3. IPPImage 인터페이스를 사용하여 PictureFrame 객체를 생성합니다

다음 Java 샘플 코드는 위 단계를 구현하여 SVG 이미지를 프레젠테이션에 추가하는 방법을 보여줍니다:

```java 
// PPTX 파일을 나타내는 Presentation 클래스 인스턴스 생성
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

Aspose.Slides의 SVG를 도형 집합으로 변환하는 기능은 SVG 이미지 작업에 사용되는 PowerPoint 기능과 유사합니다:

![PowerPoint Popup Menu](img_01_01.png)

이 기능은 [IShapeCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShapeCollection) 인터페이스의 [addGroupShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) 메서드 중 하나의 오버로드에 의해 제공되며, 첫 번째 인수로 [ISvgImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISvgImage) 객체를 받습니다.

다음 샘플 코드는 설명된 메서드를 사용하여 SVG 파일을 도형 집합으로 변환하는 방법을 보여줍니다:

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

    // SVG 이미지를 슬라이드 크기에 맞게 도형 그룹으로 변환
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // 프레젠테이션을 PPTX 형식으로 저장
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **EMF로 이미지 슬라이드에 추가**

Aspose.Slides for Android via Java를 사용하면 Excel 시트에서 EMF 이미지를 생성하고 Aspose.Cells를 사용하여 해당 이미지를 슬라이드에 EMF 형식으로 추가할 수 있습니다. 

다음 샘플 코드는 설명된 작업을 수행하는 방법을 보여줍니다:

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

## **이미지 컬렉션에서 이미지 교체**

Aspose.Slides를 사용하면 프레젠테이션의 이미지 컬렉션(슬라이드 모양에서 사용되는 이미지 포함)에 저장된 이미지를 교체할 수 있습니다. 이 섹션에서는 컬렉션의 이미지를 업데이트하는 여러 접근 방식을 보여줍니다. API는 원시 바이트 데이터, [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/) 인스턴스, 또는 컬렉션에 이미 존재하는 다른 이미지를 사용하여 이미지를 교체하는 간단한 메서드를 제공합니다.

다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스를 사용하여 이미지가 포함된 프레젠테이션 파일을 로드합니다.
2. 파일에서 새 이미지를 읽어 바이트 배열에 로드합니다.
3. 바이트 배열을 사용하여 대상 이미지를 새 이미지로 교체합니다.
4. 두 번째 접근 방식에서는 이미지를 [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/) 객체에 로드한 뒤 해당 객체를 사용하여 대상 이미지를 교체합니다.
5. 세 번째 접근 방식에서는 프레젠테이션 이미지 컬렉션에 이미 존재하는 이미지를 사용하여 대상 이미지를 교체합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation("sample.pptx");
try {
    // 첫 번째 방법.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
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

Aspose FREE [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 사용하면 텍스트를 손쉽게 애니메이션화하고, 텍스트에서 GIF를 만들 수 있습니다. 

{{% /alert %}}

## **FAQ**

**삽입 후 원본 이미지 해상도가 그대로 유지됩니까?**

예. 원본 픽셀은 보존되지만 최종 표시 형태는 슬라이드에서 [picture](/slides/ko/androidjava/picture-frame/)가 어떻게 확대·축소되는지와 저장 시 적용되는 압축에 따라 달라집니다.

**수십 개의 슬라이드에서 동일한 로고를 한 번에 교체하는 가장 좋은 방법은 무엇인가요?**

마스터 슬라이드 또는 레이아웃에 로고를 배치하고 프레젠테이션의 이미지 컬렉션에서 교체하면 해당 리소스를 사용하는 모든 요소에 업데이트가 전파됩니다.

**삽입된 SVG를 편집 가능한 도형으로 변환할 수 있나요?**

예. SVG를 도형 그룹으로 변환하면 개별 부분을 표준 도형 속성으로 편집할 수 있습니다.

**여러 슬라이드에 동시에 사진을 배경으로 설정하려면 어떻게 해야 하나요?**

마스터 슬라이드나 해당 레이아웃에서 이미지를 [배경으로 지정](/slides/ko/androidjava/presentation-background/)하면 해당 마스터/레이아웃을 사용하는 모든 슬라이드가 배경을 상속받습니다.

**많은 사진으로 인해 프레젠테이션 크기가 크게 늘어나는 것을 어떻게 방지할 수 있나요?**

중복된 이미지를 재사용하고, 적절한 해상도를 선택하며, 저장 시 압축을 적용하고, 반복되는 그래픽은 가능한 경우 마스터에 보관하여 크기 증가를 방지합니다.
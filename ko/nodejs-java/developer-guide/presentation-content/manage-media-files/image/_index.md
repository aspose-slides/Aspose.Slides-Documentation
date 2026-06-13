---
title: JavaScript를 사용한 프레젠테이션 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/nodejs-java/image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint와 OpenDocument의 이미지 관리를 간소화하고, 성능을 최적화하며 워크플로를 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 더 매력적이고 흥미롭게 만듭니다. Microsoft PowerPoint에서 파일, 인터넷 또는 기타 위치에서 사진을 슬라이드에 삽입할 수 있습니다. 마찬가지로 Aspose.Slides를 사용하면 다양한 방법으로 프레젠테이션의 슬라이드에 이미지를 추가할 수 있습니다.

{{% alert  title="Tip" color="primary" %}} 

Aspose는 무료 변환기—[JPEG를 PowerPoint로](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG를 PowerPoint로](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 사용자가 이미지를 통해 빠르게 프레젠테이션을 만들 수 있도록 합니다. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

이미지를 프레임 객체로 추가하고 싶다면—특히 크기 조정, 효과 추가 등 표준 서식 옵션을 사용할 계획이라면—[그림 프레임](/slides/ko/nodejs-java/picture-frame/)을 참조하십시오.

{{% /alert %}} 

Aspose.Slides는 JPEG, PNG, GIF 등 이러한 일반적인 형식의 이미지 작업을 지원합니다. 

## **슬라이드에 로컬에 저장된 이미지 추가**

컴퓨터에 있는 하나 이상의 이미지를 프레젠테이션의 슬라이드에 추가할 수 있습니다. 아래 JavaScript 샘플 코드는 슬라이드에 이미지를 추가하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **스트림에서 슬라이드로 이미지 추가**

슬라이드에 추가하려는 이미지가 컴퓨터에 없을 경우 웹에서 직접 이미지를 추가할 수 있습니다.

아래 JavaScript 샘플 코드는 웹에서 이미지를 가져와 슬라이드에 추가하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // Excel 파일을 스트림으로 로드합니다
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // 임베딩을 위한 데이터 객체를 생성합니다
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Ole 객체 프레임 형태를 추가합니다
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **슬라이드 마스터에 이미지 추가**

슬라이드 마스터는 해당 마스터 아래에 있는 모든 슬라이드에 대한 정보(테마, 레이아웃 등)를 저장하고 제어하는 최상위 슬라이드입니다. 따라서 슬라이드 마스터에 이미지를 추가하면 해당 마스터 아래의 모든 슬라이드에 그 이미지가 표시됩니다.

아래 JavaScript 샘플 코드는 슬라이드 마스터에 이미지를 추가하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **슬라이드 배경으로 이미지 추가**

특정 슬라이드 또는 여러 슬라이드의 배경으로 그림을 사용하고 싶을 때는 *[슬라이드 배경으로 이미지 설정](https://docs.aspose.com/slides/ko/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*을 참고하십시오.

## **프레젠테이션에 SVG 추가**

프레젠테이션에 이미지를 추가하거나 삽입하려면 [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection) 클래스에 속한 [addPictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 메서드를 사용할 수 있습니다.

SVG 이미지를 기반으로 이미지 객체를 만들려면 다음과 같이 하면 됩니다:

1. SvgImage 객체를 생성하여 ImageShapeCollection에 삽입합니다
2. ISvgImage에서 PPImage 객체를 생성합니다
3. PPImage 클래스를 사용하여 PictureFrame 객체를 생성합니다

아래 샘플 코드는 위 단계를 구현하여 SVG 이미지를 프레젠테이션에 추가하는 방법을 보여줍니다:
```javascript
// PPTX 파일을 나타내는 Presentation 클래스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SVG를 도형 집합으로 변환**

Aspose.Slides의 SVG를 도형 집합으로 변환하는 기능은 SVG 이미지를 다루는 PowerPoint 기능과 유사합니다:

![PowerPoint 팝업 메뉴](img_01_01.png)

이 기능은 첫 번째 인수로 [SvgImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SvgImage) 객체를 받는 [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection) 클래스의 [addGroupShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) 메서드 중 하나의 오버로드를 통해 제공됩니다.

아래 샘플 코드는 해당 메서드를 사용하여 SVG 파일을 도형 집합으로 변환하는 방법을 보여줍니다:

```javascript
// 새 프레젠테이션을 생성합니다
var presentation = new aspose.slides.Presentation();
try {
    // SVG 파일 내용을 읽습니다
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // SvgImage 객체를 생성합니다
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // 슬라이드 크기를 가져옵니다
    var slideSize = presentation.getSlideSize().getSize();
    // SVG 이미지를 슬라이드 크기에 맞게 스케일링하여 도형 그룹으로 변환합니다
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // 프레젠테이션을 PPTX 형식으로 저장합니다
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **슬라이드에 EMF 이미지로 추가**

Aspose.Slides for Node.js via Java를 사용하면 Excel 시트에서 EMF 이미지를 생성하고 Aspose.Cells와 함께 슬라이드에 EMF 이미지로 추가할 수 있습니다. 

아래 샘플 코드는 이 작업을 수행하는 방법을 보여줍니다:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **이미지 컬렉션에서 이미지 교체**

Aspose.Slides를 사용하면 프레젠테이션의 이미지 컬렉션에 저장된 이미지(슬라이드 도형에서 사용되는 이미지 포함)를 교체할 수 있습니다. 이 섹션에서는 컬렉션의 이미지를 업데이트하는 여러 방법을 보여줍니다. API는 원시 바이트 데이터, [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/) 인스턴스 또는 컬렉션에 이미 존재하는 다른 이미지를 사용하여 이미지를 교체하는 간단한 메서드를 제공합니다.

아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스를 사용하여 이미지가 포함된 프레젠테이션 파일을 로드합니다.
2. 파일에서 새 이미지를 바이트 배열로 로드합니다.
3. 바이트 배열을 사용하여 대상 이미지를 새 이미지로 교체합니다.
4. 두 번째 방법에서는 이미지를 [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/) 객체로 로드하고 해당 객체로 대상 이미지를 교체합니다.
5. 세 번째 방법에서는 프레젠테이션 이미지 컬렉션에 이미 존재하는 이미지를 사용하여 대상 이미지를 교체합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```js
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 첫 번째 방법.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // 두 번째 방법.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // 세 번째 방법.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // 프레젠테이션을 파일에 저장합니다.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 사용하면 텍스트를 손쉽게 애니메이션화하고, 텍스트에서 GIF를 만들 수 있습니다. 

{{% /alert %}}

## **FAQ**

**삽입 후 원본 이미지 해상도가 유지됩니까?**

예. 원본 픽셀은 보존되지만 최종 모습은 슬라이드에서 [picture](/slides/ko/nodejs-java/picture-frame/)가 어떻게 스케일링되는지와 저장 시 적용되는 압축에 따라 달라집니다.

**수십 개 슬라이드에 동일한 로고를 한 번에 교체하는 최선의 방법은 무엇인가요?**

로고를 마스터 슬라이드 또는 레이아웃에 배치하고 프레젠테이션 이미지 컬렉션에서 교체하면 해당 리소스를 사용하는 모든 요소에 업데이트가 전파됩니다.

**삽입된 SVG를 편집 가능한 도형으로 변환할 수 있나요?**

예. SVG를 도형 그룹으로 변환하면 개별 파트가 표준 도형 속성을 사용해 편집 가능해집니다.

**여러 슬라이드에 한 번에 그림을 배경으로 설정하려면 어떻게 해야 하나요?**

[이미지를 배경으로 지정](/slides/ko/nodejs-java/presentation-background/)을 마스터 슬라이드 또는 해당 레이아웃에 적용하면 해당 마스터/레이아웃을 사용하는 모든 슬라이드가 배경을 상속합니다.

**많은 그림 때문에 프레젠테이션 파일 크기가 급증하는 것을 어떻게 방지할 수 있나요?**

중복 대신 단일 이미지 리소스를 재사용하고, 적절한 해상도를 선택하며, 저장 시 압축을 적용하고, 반복되는 그래픽은 가능한 마스터에 배치하십시오.
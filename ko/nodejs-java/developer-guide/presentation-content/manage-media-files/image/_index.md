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
- 외부 SVG 리소스
- SVG 해결자
- 연결된 SVG 이미지
- SVG 글꼴
- EMF 추가
- WMF 추가
- TIFF 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument에서 이미지 관리를 간소화하고 성능을 최적화하며 워크플로를 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 보다 매력적이고 시각적으로 돋보이게 합니다. Microsoft PowerPoint에서 파일, 인터넷 또는 기타 소스에서 사진을 슬라이드에 삽입할 수 있습니다. 마찬가지로 Aspose.Slides를 사용하면 여러 방법으로 프레젠테이션 슬라이드에 이미지를 추가할 수 있습니다.

{{% alert  title="Tip" color="primary" %}} 

Aspose는 무료 변환기—[JPEG to PowerPoint](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG to PowerPoint](https://products.aspose.app/slides/ko/import/png-to-ppt)—를 제공하여 이미지에서 빠르게 프레젠테이션을 만들 수 있습니다. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

이미지를 사진 프레임으로 추가하고 싶다면—특히 크기 조정, 효과 적용 또는 기타 표준 서식 옵션을 사용할 계획이라면—[Picture Frame](/slides/ko/nodejs-java/picture-frame/)을 참조하십시오. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 다음 페이지를 참조하십시오: 변환 [image to JPG](https://products.aspose.com/slides/ko/nodejs-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/ko/nodejs-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/ko/nodejs-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/ko/nodejs-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/ko/nodejs-java/conversion/png-to-svg/), 및 [SVG to PNG](https://products.aspose.com/slides/ko/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides는 JPEG, PNG, BMP, GIF 등과 같은 일반적인 형식의 이미지를 지원합니다. 

## **로컬에 저장된 이미지를 슬라이드에 추가**

컴퓨터에 저장된 하나 이상의 이미지를 프레젠테이션 슬라이드에 추가할 수 있습니다. 다음 JavaScript 샘플 코드는 슬라이드에 이미지를 추가하는 방법을 보여 줍니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **웹에서 이미지를 슬라이드에 추가**

슬라이드에 추가하려는 이미지가 컴퓨터에 저장되지 않은 경우 웹에서 직접 추가할 수 있습니다. 

다음 JavaScript 샘플 코드는 웹에서 이미지를 슬라이드에 추가하는 방법을 보여 줍니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **슬라이드 마스터에 이미지 추가**

슬라이드 마스터는 해당 마스터를 사용하는 슬라이드의 테마와 레이아웃과 같은 정보를 저장하고 제어합니다. 슬라이드 마스터에 이미지를 추가하면 해당 마스터를 기반으로 하는 모든 슬라이드에 이미지가 나타납니다. 

다음 JavaScript 샘플 코드는 슬라이드 마스터에 이미지를 추가하는 방법을 보여 줍니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **슬라이드 배경에 이미지 추가**

하나 이상의 슬라이드 배경으로 그림을 사용할 수 있습니다. 자세한 내용은 *[Setting Images as Backgrounds for Slides](/slides/ko/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*을 참조하십시오.

## **프레젠테이션에 SVG 추가**

SVG 콘텐츠는 [SvgImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgimage/) 클래스를 사용하여 프레젠테이션에 추가할 수 있습니다. 결과 SVG 이미지 객체는 프레젠테이션 이미지 컬렉션에 추가된 후 사진 프레임을 만드는 데 사용할 수 있습니다.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **외부 리소스가 있는 SVG 콘텐츠 가져오기**

디자인 툴, 다이어그램 편집기, 아이콘 시스템 및 웹 파이프라인에서 내보낸 SVG 파일은 SVG 문서 외부에 저장된 리소스를 참조할 수 있습니다. 예를 들어 SVG에 `images/photo.png`와 같은 이미지 링크, CSS `url(...)` 값 또는 글꼴 URL이 포함될 수 있습니다.

이러한 SVG 콘텐츠를 가져오려면 외부 리소스 해결자를 제공하고 이를 기본 URI와 함께 적절한 [SvgImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgimage/) 생성자에 전달합니다. 기본 URI는 SVG 문서의 위치를 식별하며 상대 링크를 해결하는 데 사용됩니다.

`SvgImage` 클래스는 가져온 SVG에 대한 정보를 제공한다:

- `getSvgContent()`는 SVG 마크업을 문자열로 반환합니다.
- `getSvgData()`는 SVG 콘텐츠를 바이트 배열로 반환합니다.
- `getBaseUri()`는 상대 링크에 사용된 기본 URI를 반환합니다.
- `getExternalResourceResolver()`는 SVG 이미지에 할당된 해결자를 반환합니다.

### **외부 리소스 해결자 구현**

해결자에는 두 개의 메서드가 있습니다:

- `resolveUri`는 기본 URI와 상대 리소스 링크를 결합하여 절대 URI를 반환합니다. 링크를 해결할 수 없거나 허용되지 않으면 `null`을 반환합니다.
- `getEntity`는 절대 리소스 URI에 대한 읽기 가능한 Java 스트림을 반환합니다. 리소스가 없거나 차단되었거나 사용 불가능하면 `null`을 반환합니다. 필요한 경우 대체 스트림을 반환할 수도 있습니다.

다음 도우미는 허용된 로컬 디렉터리에서만 연결된 리소스를 로드하는 해결자를 생성합니다. 네트워크 리소스와 허용된 디렉터리 외부 경로는 차단됩니다. 해결되지 않은 이미지 링크에 대해 선택적 대체 이미지가 반환됩니다.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // 이 해결자는 의도적으로 로컬 파일만 허용합니다.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // 이미지 리소스에만 대체를 사용합니다. 이미지 스트림을 반환
                // 누락된 폰트 또는 스타일시트에 대해 반환하는 것은 유효하지 않습니다.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **SVG 가져오기 중 연결된 리소스 해결**

`assets/diagram.svg`에 다음과 같은 상대 참조가 포함되어 있다고 가정합니다:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

다음 JavaScript 예제는 SVG 파일 URI를 기본 URI로 전달하고 사용자 지정 해결자를 제공합니다. 해결자는 상대 이미지 링크를 절대 URI로 변환하고 Aspose.Slides가 SVG를 처리하는 동안 연결된 리소스를 포함하는 스트림을 반환합니다.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// 기본 URI는 SVG 문서의 위치를 나타냅니다.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage는 원본 콘텐츠, 바이너리 데이터, 기본 URI 및 해결자를 노출합니다.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`SvgImage` 클래스는 또한 SVG 데이터를 바이트 배열로 받아들이는 오버로드와 스트림 기반 팩터리 메서드, 외부 리소스 해결자 및 기본 URI를 함께 사용할 수 있는 옵션을 제공합니다.

{{% alert title="Important" color="warning" %}}

리소스 해결자는 Aspose.Slides가 SVG를 처리하고 렌더링하는 동안 외부 리소스를 사용할 수 있게 합니다. 원본 SVG 마크업을 수정하거나 해결된 리소스를 자동으로 삽입하지는 않습니다.

SVG 이미지가 프레젠테이션 이미지 컬렉션에 추가될 때 PPTX 파일은 원본 SVG 표현과 래스터 대체 이미지를 모두 포함할 수 있습니다. 연결된 리소스는 생성된 대체 이미지에 표시될 수 있지만 `images/photo.png`와 같은 상대 링크는 저장된 SVG에 그대로 남아 있습니다. 원본 외부 리소스를 사용할 수 없는 경우 네이티브 SVG 표현을 렌더링하는 애플리케이션은 해당 연결된 콘텐츠를 생략할 수 있습니다.

{{% /alert %}}

### **휴대용 SVG 그림 만들기**

외부 파일에 의존하지 않는 SVG 그림을 만들려면 `SvgImage`를 생성하기 전에 SVG를 자체 포함형으로 만들어야 합니다. 예를 들어 연결된 이미지 URL을 이미지 데이터를 포함하는 `data:` URI로 교체합니다:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

필요한 모든 리소스를 SVG 콘텐츠에 삽입한 후 `SvgImage`를 만들고 프레젠테이션 이미지 컬렉션에 추가한 다음 이전 예제와 같이 사진 프레임에 삽입합니다.

### **누락되거나 차단된 리소스 처리**

`resolveUri`에서 리소스 URI가 잘못되었거나 금지되었거나 해결할 수 없는 경우 `null`을 반환합니다. `getEntity`에서 리소스를 읽을 수 없는 경우 `null`을 반환합니다. 가능한 경우 Aspose.Slides는 해당 리소스 없이 SVG 처리를 계속합니다.

누락된 리소스에 대해 대체 스트림을 반환할 수 있지만, 그 내용은 요청된 리소스 유형과 호환되어야 합니다. 예를 들어 폰트나 스타일시트가 아닌 이미지가 누락된 경우에만 이미지 스트림을 반환해야 합니다.

{{% alert title="Security" color="warning" %}}

신뢰할 수 없는 SVG 파일에서 임의의 파일 경로나 제한되지 않은 네트워크 URL을 해결하지 마십시오. 허용된 스킴, 디렉터리 및 호스트를 제한하십시오. 네트워크 리소스의 경우 연결 시간 초과, 응답 크기 제한 및 콘텐츠 검증도 적용하십시오.

{{% /alert %}}

## **SVG를 도형 집합으로 변환**

Aspose.Slides는 PowerPoint의 해당 기능과 유사하게 SVG를 도형 집합으로 변환할 수 있습니다:

![PowerPoint Popup Menu](img_01_01.png)

이 기능은 SVG 이미지 객체를 첫 번째 인수로 받는 [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection) 클래스의 [addGroupShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) 메서드 오버로드를 통해 제공됩니다.

다음 JavaScript 샘플 코드는 이 메서드를 사용하여 SVG 파일을 도형 집합으로 변환하는 방법을 보여 줍니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// 소스 SVG 파일 이름.
const svgFileName = "sample.svg";

// 출력 프레젠테이션 파일 이름.
const outPptxPath = "presentation.pptx";

// 새 프레젠테이션을 생성합니다.
const presentation = new aspose.slides.Presentation();
try {
    // SVG 파일 내용을 읽습니다.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // SvgImage 객체를 생성합니다.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // 슬라이드 크기를 가져옵니다.
    const slideSize = presentation.getSlideSize().getSize();

    // SVG 이미지를 도형 그룹으로 변환하고 슬라이드 크기에 맞게 스케일합니다.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // 프레젠테이션을 PPTX 형식으로 저장합니다.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **EMF 형식 이미지 슬라이드에 추가**

Aspose.Slides for Node.js via Java를 사용하면 Aspose.Cells를 통해 Excel 워크시트에서 EMF 이미지를 생성하고 이를 프레젠테이션 슬라이드에 추가할 수 있습니다.

다음 JavaScript 샘플 코드는 이를 수행하는 방법을 보여 줍니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// 워크북을 스트림에 저장합니다.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // 파일을 그대로 추가하여 그림이 벡터 EMF 형태로 유지되도록 하고 래스터화되지 않게 합니다.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **이미지 컬렉션에서 이미지 교체**

Aspose.Slides를 사용하면 슬라이드 도형에서 사용되는 이미지를 포함하여 프레젠테이션 이미지 컬렉션에 저장된 이미지를 교체할 수 있습니다. 이 섹션에서는 컬렉션의 이미지를 업데이트하는 여러 방법을 설명합니다. 원시 바이트 데이터, [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/) 인스턴스 또는 컬렉션에 이미 존재하는 다른 이미지를 사용하여 이미지를 교체할 수 있습니다.

아래 단계대로 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스를 사용하여 이미지를 포함한 프레젠테이션 파일을 로드합니다.
2. 파일에서 새 이미지를 바이트 배열로 로드합니다.
3. 바이트 배열을 사용하여 대상 이미지를 새 이미지로 교체합니다.
4. 두 번째 방법에서는 이미지를 [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/) 객체로 로드하고 해당 객체를 사용하여 대상 이미지를 교체합니다.
5. 세 번째 방법에서는 프레젠테이션 이미지 컬렉션에 이미 존재하는 이미지를 사용하여 대상 이미지를 교체합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // 첫 번째 방법.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // 두 번째 방법.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

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

Aspose의 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 사용하면 텍스트를 애니메이션화하고 GIF를 쉽게 만들 수 있습니다. 

{{% /alert %}}

## **FAQ**

**삽입 후 원본 이미지 해상도가 유지됩니까?**

네. 원본 픽셀은 보존되지만 최종 모양은 슬라이드에서 [picture](/slides/ko/nodejs-java/picture-frame/)가 어떻게 스케일링되는지와 저장 시 적용된 압축에 따라 달라집니다.

**수십 개 슬라이드에서 같은 로고를 한 번에 교체하려면 가장 좋은 방법은 무엇입니까?**

마스터 슬라이드 또는 레이아웃에 로고를 배치하고 프레젠테이션 이미지 컬렉션에서 교체하면 해당 리소스를 사용하는 모든 요소에 업데이트가 전파됩니다.

**삽입된 SVG를 편집 가능한 도형으로 변환할 수 있습니까?**

네. SVG를 도형 그룹으로 변환하면 개별 부분을 표준 도형 속성을 사용해 편집할 수 있습니다.

**여러 슬라이드에 한 번에 사진을 배경으로 설정하려면 어떻게 해야 합니까?**

마스터 슬라이드나 해당 레이아웃에서 이미지를 배경으로 지정하면 그 마스터/레이아웃을 사용하는 모든 슬라이드가 배경을 상속합니다.

**많은 사진 때문에 프레젠테이션 파일이 너무 커지는 것을 방지하려면 어떻게 해야 합니까?**

중복 대신 단일 이미지 리소스를 재사용하고, 적절한 해상도를 선택하며, 저장 시 압축을 적용하고, 가능한 경우 마스터에 반복 그래픽을 유지하십시오.
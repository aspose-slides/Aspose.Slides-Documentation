---
title: JavaScript를 사용한 프레젠테이션 OLE 관리
linktitle: OLE 관리
type: docs
weight: 40
url: /ko/nodejs-java/manage-ole/
keywords:
- OLE 객체
- 객체 연결 및 임베딩
- OLE 추가
- OLE 임베드
- 객체 추가
- 객체 임베드
- 파일 추가
- 파일 임베드
- 연결된 객체
- 연결된 파일
- OLE 변경
- OLE 아이콘
- OLE 제목
- OLE 추출
- 객체 추출
- 파일 추출
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 파일의 OLE 객체 관리를 최적화합니다. OLE 콘텐츠를 손쉽게 임베드하고, 업데이트하며, 내보낼 수 있습니다.
---
## **소개**

{{% alert color="info" title="참고" %}}
OLE (Object Linking & Embedding)은 하나의 애플리케이션에서 만든 데이터와 객체를 링크 또는 임베딩을 통해 다른 애플리케이션에 배치할 수 있게 하는 Microsoft 기술입니다. 
{{% /alert %}} 

MS Excel에서 만든 차트를 고려해 보십시오. 차트를 PowerPoint 슬라이드에 배치합니다. 해당 Excel 차트는 OLE 객체로 간주됩니다. 

- OLE 객체는 아이콘으로 표시될 수 있습니다. 이 경우 아이콘을 더블 클릭하면 차트가 연결된 애플리케이션(Excel)에서 열리거나, 객체를 열거나 편집할 애플리케이션 선택을 요청받습니다.
- OLE 객체는 차트 내용과 같이 실제 내용을 표시할 수 있습니다. 이 경우 차트가 PowerPoint에서 활성화되고 차트 인터페이스가 로드되어 PowerPoint 내에서 차트 데이터를 수정할 수 있습니다.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/)은 OLE 객체를 OLE 객체 프레임([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame))으로 슬라이드에 삽입할 수 있게 합니다.

## **슬라이드에 OLE 객체 프레임 추가**

Microsoft Excel에서 차트를 이미 만든 상태이고 Aspose.Slides for Node.js via Java를 사용하여 OLE 객체 프레임으로 슬라이드에 임베드하려는 경우, 다음과 같이 할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드의 인덱스를 통해 해당 슬라이드에 대한 참조를 가져옵니다.
1. Excel 파일을 바이트 배열로 읽습니다.
1. [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)을 슬라이드에 추가하고 바이트 배열 및 OLE 객체에 대한 기타 정보를 포함합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 Excel 파일의 차트를 Aspose.Slides for Node.js via Java를 사용하여 OLE 객체 프레임으로 슬라이드에 추가했습니다. **참고**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) 생성자는 두 번째 매개변수로 임베드 가능한 객체 확장자를 받습니다. 이 확장자는 PowerPoint가 파일 유형을 올바르게 해석하고 해당 OLE 객체를 열 적절한 애플리케이션을 선택하도록 합니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **링크된 OLE 객체 프레임 추가**

Aspose.Slides for Node.js via Java를 사용하면 데이터를 임베드하지 않고 파일에 대한 링크만으로 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)을 추가할 수 있습니다.

다음 JavaScript 코드는 링크된 Excel 파일을 사용하여 슬라이드에 [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)을 추가하는 방법을 보여줍니다:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// OLE 객체 프레임을 링크된 Excel 파일과 함께 추가합니다.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE 객체 프레임 접근**

OLE 객체가 이미 슬라이드에 임베드된 경우, 다음과 같이 쉽게 찾거나 접근할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성하여 OLE 객체가 임베드된 프레젠테이션을 로드합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) 도형에 접근합니다. 예제에서는 첫 번째 슬라이드에 하나의 도형만 있는 이전에 만든 PPTX를 사용했습니다.
4. OLE 객체 프레임에 접근하면 원하는 작업을 수행할 수 있습니다.

아래 예제에서는 OLE 객체 프레임(슬라이드에 임베드된 Excel 차트 객체)과 해당 파일 데이터를 접근합니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // 임베드된 파일 데이터를 가져옵니다.
    // 임베드된 파일의 확장자를 가져옵니다.
    // ...
}
```

### **링크된 OLE 객체 프레임 속성 접근**

Aspose.Slides를 사용하면 링크된 OLE 객체 프레임 속성에 접근할 수 있습니다.

다음 JavaScript 코드는 OLE 객체가 링크되어 있는지 확인하고 링크된 파일의 경로를 얻는 방법을 보여줍니다:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // OLE 객체가 연결되어 있는지 확인합니다.
    if (oleFrame.isObjectLink()) {
        // 연결된 파일의 전체 경로를 출력합니다.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // 연결된 파일이 존재하는 경우 상대 경로를 출력합니다.
        // PPT 프레젠테이션만 상대 경로를 포함할 수 있습니다.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE 객체 데이터 변경**

{{% alert color="info" title="참고" %}}
이 섹션에서는 아래 코드 예제가 [Aspose.Cells for Java](https://docs.aspose.com/cells/java/)를 사용합니다.
{{% /alert %}}

OLE 객체가 이미 슬라이드에 임베드된 경우, 다음과 같이 해당 객체에 접근하고 데이터를 수정할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성하여 OLE 객체가 임베드된 프레젠테이션을 로드합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. OLE 객체 프레임 도형에 접근합니다. 예제에서는 첫 번째 슬라이드에 하나의 도형만 있는 이전에 만든 PPTX를 사용했습니다.
4. OLE 객체 프레임에 접근하면 원하는 작업을 수행할 수 있습니다.
5. `Workbook` 객체를 생성하고 OLE 데이터를 접근합니다.
6. 원하는 `Worksheet`에 접근하고 데이터를 수정합니다.
7. 업데이트된 `Workbook`을 스트림에 저장합니다.
8. 스트림에서 OLE 객체 데이터를 변경합니다.

아래 예제에서는 OLE 객체 프레임(슬라이드에 임베드된 Excel 차트 객체)에 접근하고, 차트 데이터를 업데이트하기 위해 파일 데이터를 수정합니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // OLE 객체 데이터를 Workbook 객체로 읽습니다.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // 워크북 데이터를 수정합니다.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // OLE 프레임 객체 데이터를 변경합니다.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **슬라이드에 다른 파일 유형 임베드**

Excel 차트 외에도 Aspose.Slides for Node.js via Java를 사용하면 슬라이드에 다른 유형의 파일을 임베드할 수 있습니다. 예를 들어 HTML, PDF, ZIP 파일을 객체로 삽입할 수 있습니다. 사용자가 삽입된 객체를 더블 클릭하면 해당 프로그램에서 자동으로 열리거나, 적절한 프로그램을 선택하라는 프롬프트가 표시됩니다.

다음 JavaScript 코드는 HTML과 ZIP을 슬라이드에 임베드하는 방법을 보여줍니다:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **임베드된 객체의 파일 유형 설정**

프레젠테이션 작업 시, 기존 OLE 객체를 새 것으로 교체하거나 지원되지 않는 OLE 객체를 지원되는 것으로 교체해야 할 수 있습니다. Aspose.Slides for Node.js via Java를 사용하면 임베드된 객체의 파일 유형을 설정하여 OLE 프레임 데이터 또는 확장자를 업데이트할 수 있습니다.

다음 JavaScript 코드는 임베드된 OLE 객체의 파일 유형을 `zip`으로 설정하는 방법을 보여줍니다:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// 파일 유형을 ZIP으로 변경합니다.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **임베드된 객체의 아이콘 이미지 및 제목 설정**

OLE 객체를 임베드하면 아이콘 이미지로 구성된 미리보기가 자동으로 추가됩니다. 이 미리보기는 사용자가 OLE 객체에 접근하거나 열기 전에 보는 것입니다. 특정 이미지와 텍스트를 미리보기 요소로 사용하려면 Aspose.Slides for Node.js via Java를 사용하여 아이콘 이미지와 제목을 설정할 수 있습니다.

다음 JavaScript 코드는 임베드된 객체의 아이콘 이미지와 제목을 설정하는 방법을 보여줍니다:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// 프레젠테이션 리소스에 이미지를 추가합니다.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// OLE 미리보기를 위한 제목과 이미지를 설정합니다.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE 객체 프레임이 크기 조정 및 위치 변경되는 것을 방지**

링크된 OLE 객체를 프레젠테이션 슬라이드에 추가한 후 PowerPoint에서 프레젠테이션을 열면 링크 업데이트를 묻는 메시지가 표시될 수 있습니다. "Update Links" 버튼을 클릭하면 PowerPoint가 링크된 OLE 객체의 데이터를 업데이트하고 객체 미리보기를 새로 고쳐 OLE 객체 프레임의 크기와 위치가 변경될 수 있습니다. PowerPoint가 객체 데이터를 업데이트하라는 프롬프트를 표시하지 않도록 하려면, [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) 클래스의 [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) 메서드를 `false`로 호출합니다:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **임베드된 파일 추출**

다음과 같이 Aspose.Slides for Node.js via Java를 사용하면 슬라이드에 OLE 객체로 임베드된 파일을 추출할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성하여 추출하려는 OLE 객체를 포함합니다.
2. 프레젠테이션의 모든 도형을 순회하며 [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe) 도형에 접근합니다.
3. OLE 객체 프레임에서 임베드된 파일 데이터를 접근하고 디스크에 기록합니다.

다음 JavaScript 코드는 슬라이드에 OLE 객체로 임베드된 파일을 추출하는 방법을 보여줍니다:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **FAQ**

**슬라이드를 PDF/이미지로 내보낼 때 OLE 콘텐츠가 렌더링됩니까?**

슬라이드에 표시되는 부분이 렌더링됩니다—아이콘/대체 이미지(미리보기)입니다. "실시간" OLE 콘텐츠는 렌더링 중에 실행되지 않습니다. 필요하면 직접 미리보기 이미지를 설정하여 내보낸 PDF에서 기대하는 모습을 보장할 수 있습니다. 임베드된 파일을 PDF 첨부 파일로도 보존하려면 [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData)를 `true`로 호출합니다. 이 옵션은 기본적으로 비활성화되어 있습니다. 예제와 첨부 파일 확인 방법은 [Preserve Embedded OLE Files as PDF Attachments](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)를 참조하십시오.

**슬라이드의 OLE 객체를 잠궈 사용자가 PowerPoint에서 이동/편집하지 못하게 하려면 어떻게 해야 하나요?**

도형을 잠급니다: Aspose.Slides는 도형 수준의 잠금을 제공합니다. 이는 암호화가 아니지만 실수로 인한 편집 및 이동을 효과적으로 방지합니다.

**링크된 OLE 객체의 상대 경로가 PPTX 형식에서 보존됩니까?**

PPTX에서는 "relative path" 정보가 제공되지 않고 전체 경로만 사용됩니다. 상대 경로는 오래된 PPT 형식에만 존재합니다. 휴대성을 위해 신뢰할 수 있는 절대 경로/접근 가능한 URI 또는 임베드를 사용하는 것이 좋습니다.
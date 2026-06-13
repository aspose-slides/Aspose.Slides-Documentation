---
title: OLE 개체
type: docs
weight: 210
url: /ko/nodejs-java/examples/elements/ole-object/
keywords:
- 코드 예제
- OLE 개체
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 OLE 개체를 처리합니다: 삽입, 연결, 업데이트 및 JavaScript를 사용하여 PPT, PPTX 및 ODP 프레젠테이션에서 삽입된 콘텐츠를 추출합니다."
---
이 문서는 파일을 OLE 개체로 삽입하고 **Aspose.Slides for Node.js via Java**를 사용하여 해당 데이터를 업데이트하는 방법을 보여줍니다.

## **OLE 개체 추가**

PDF 파일을 프레젠테이션에 삽입합니다.

```js
function addOleObject() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pdfStream = fs.readFileSync("doc.pdf");
        let pdfData = java.newArray("byte", Array.from(pdfStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(pdfData, "pdf");
        let oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

        presentation.save("ole_object.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE 개체 액세스**

슬라이드에서 첫 번째 OLE 개체 프레임을 가져옵니다.

```js
function accessOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstOleFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IOleObjectFrame")) {
                firstOleFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **OLE 개체 제거**

슬라이드에서 삽입된 OLE 개체를 삭제합니다.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 모양이 OLE 개체 프레임이라고 가정합니다.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE 개체 데이터 업데이트**

기존 OLE 개체에 삽입된 데이터를 교체합니다.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 모양이 OLE 개체 프레임이라고 가정합니다.
        let oleFrame = slide.getShapes().get_Item(0);

        let dataStream = fs.readFileSync("picture.png");
        let newData = java.newArray("byte", Array.from(dataStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(newData, "png");
        oleFrame.setEmbeddedData(dataInfo);

        presentation.save("ole_object_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```
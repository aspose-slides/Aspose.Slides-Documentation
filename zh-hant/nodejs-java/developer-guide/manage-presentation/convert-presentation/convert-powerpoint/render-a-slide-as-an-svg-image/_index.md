---
title: 在 JavaScript 中將簡報投影片渲染為 SVG 圖片
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 轉 SVG
- 簡報 轉 SVG
- 投影片 轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- SVG 匯出選項
- 互動式 SVG
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中將 PowerPoint 投影片匯出為 SVG 圖片，並使用 Aspose.Slides 控制字型、文字、影像、ID 與事件。"
---
## **概覽**

SVG 是一種可伸縮的基於 XML 的影像格式，適用於網路發佈、投影片檢視器、無障礙工作流程，以及自動後處理。Aspose.Slides for Node.js via Java 將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片與 SVG 元素的寫入方式。

當匯出的 SVG 必須緊湊、在不同瀏覽器間可預測，或需用於互動時，請使用 [SVGOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/)。

## **將投影片匯出為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)，選取投影片，然後使用 [Slide.writeAsSvg](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/writeassvg/) 將其寫入串流。以下範例將簡報中的每張投影片匯出為單獨的 SVG 檔案。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

檔名使用 [Slide.getSlideNumber](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/getslidenumber/) 而非迴圈索引。當投影片檢視器或網頁只需要特定形狀時，也可以使用 [Shape.writeAsSvg](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/writeassvg/) 匯出單一形狀。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/) 控制 SVG 的呈現方式。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/setuseframesize/) 會將文字框納入繪製區域，而 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) 決定是否套用框的旋轉。若文字必須在不使用連字的情況下呈現，請將 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) 設為 `true`。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **控制文字與字型**

### **向量化全部文字**

將 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) 設為 `true`，即可將所有投影片文字寫為向量圖形。這樣可消除字型相依性，並使視覺結果在各瀏覽器間更一致，但文字將不再可作為 SVG 文字被選取或搜尋。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **選擇外部字型的處理方式**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) 會針對外部載入的字型使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgexternalfontshandling/) 的值。選擇 `AddLinksToFontFiles` 以參照獨立的字型檔案，`Embed` 則將字型資料嵌入 SVG，或 `Vectorize` 只將使用外部字型的文字轉為圖形。嵌入字型前請先確認字型授權。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **縮小內嵌圖片大小**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) 可降低內嵌圖片的解析度，使用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) 可省略裁剪過的來源區域，並透過 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/setjpegquality/) 來控制 JPEG 編碼品質。這些設定會以影像品質或保留的影像資料為代價，減少檔案大小。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **為形狀與文字指派穩定的 ID**

將格式化控制器傳遞給 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/)，即可為每個 SVG 形狀設定 [SvgShape.setId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgshape/setid/)。若控制器同時處理文字跨度，則可為文字 `tspan` 元素設定 [SvgTSpan.setId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgtspan/setid/) 值。

以下控制器使用 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/)，在形狀生命週期內保持穩定，並使用可重複的計數器來處理其文字跨度。這使得產生的 ID 能適用於未變更簡報的後處理。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **新增 SVG 事件處理程式**

在格式化控制器中，使用 [SvgShape.setEventHandler](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgshape/seteventhandler/) 並傳入 [SvgEvent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgevent/) 值，即可為匯出的形狀新增 JavaScript 事件處理程式。透過 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) 指定控制器，並在承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

主機頁面可以定義處理器所參照的 JavaScript 函式。指派 ID 與事件處理程式可支援投影片檢視器、無障礙增強以及其他互動式 SVG 工作流程。

## **常見問題**

**何時應使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) 而非 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

當所有文字必須與字型無關時，使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/setvectorizetext/)。若僅需將使用外部字型的文字轉換為圖形，則使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgexternalfontshandling/)。

**如何將 SVG 檔案縮小到最小？**

首先壓縮內嵌圖片、刪除裁剪過的影像區域，並在目標環境能提供字型檔時選擇連結字型檔案。請測試結果，因為降低影像解析度、降低 JPEG 品質以及向量化文字皆會在品質與大小之間產生不同的取捨。

**匯出後，我可以修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，之後即可在後處理工具或瀏覽器腳本中選取對應的 SVG 元素。
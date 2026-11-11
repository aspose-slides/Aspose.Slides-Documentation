---
title: 在 JavaScript 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 轉 SVG
- 簡報轉 SVG
- 投影片轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- SVG 匯出選項
- 互動式 SVG
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字、影像、ID 以及事件。"
---
## **概觀**

SVG 是一種可伸縮的 XML 為基礎的圖像格式，適用於 Web 發佈、投影片檢視器、無障礙工作流程以及自動後處理。Aspose.Slides for Node.js via Java 會將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片和 SVG 元素的寫入方式。

當匯出的 SVG 必須小巧、在不同瀏覽器間具有可預測性或已準備好供互動使用時，請使用[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/)。

## **匯出投影片為 SVG**

建立一個[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)，選取投影片，並使用[Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/)將其寫入串流。以下範例會將簡報中的每張投影片匯出為單獨的 SVG 檔案。

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

檔名使用[Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/)而非迴圈索引。您也可以使用[Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/)匯出單一圖形，當投影片檢視器或網頁僅需該圖形時。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) 控制 SVG 的呈現。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) 會將文字框納入渲染區域，而[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) 決定是否套用框的旋轉。當文字必須在不使用連字的情況下呈現時，將[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) 設為 `true`。

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

## **控制箭頭端點的線段裁剪**

SVG 1.1 沒有標記內縮設定可指定線條在箭頭下方的停止位置。預設情況下，Aspose.Slides 會縮短匯出的線條，使其筆畫不會穿透標記。呼叫[SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) 並傳入 `true`，即可將筆畫繪製至線條原始端點。此設定僅影響 SVG 輸出，線條在投影片上的位置與長度保持不變。

範例在寬度為 2 點與 10 點的線條上繪製三角形與菱形箭頭，並以不同的裁剪選項匯出同一張投影片兩次。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

比較顯示 10 點線條的三角形箭頭。啟用裁剪時，箭頭尖端銳利；停用裁剪時，筆畫會穿透斜側標記，留下平坦的尾端。

![放大 10 點三角形，啟用裁剪時尖端銳利，停用裁剪時尾端平坦](line-end-cropping.png)

在範例的其他線條中，2 點三角形的突出筆畫不太明顯。實心菱形在兩種寬度下都覆蓋了筆畫的末端。

## **控制文字與字型**

匯出投影片為 SVG 時，您可以控制文字是保留為文字還是轉換為向量圖形，以及外部字型的包含或引用方式。以下選項有助於在匯出 SVG 時平衡視覺一致性、文字可選取性與字型相依性。

### **將所有文字向量化**

將[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) 設為 `true`，可將所有投影片文字寫入為向量圖形。這樣可消除字型相依性，使視覺結果在不同瀏覽器間更一致，但文字將無法作為 SVG 文字被選取或搜尋。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) 使用[SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) 的值來處理外部載入的字型。選擇 `AddLinksToFontFiles` 以參考獨立的字型檔案，`Embed` 以在 SVG 中嵌入字型資料，或 `Vectorize` 只將使用外部字型的文字轉為圖形。嵌入字型前請先確認字型授權。

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

## **縮小內嵌影像大小**

使用[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) 以降低內嵌圖片的解析度，使用[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) 省略裁切過的來源區域，並使用[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) 控制 JPEG 編碼品質。這些設定會在降低檔案大小的同時犧牲影像忠實度或保留的影像資料。

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

## **控制中繼檔點陣化解析度**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) 設定在 SVG 匯出時對中繼檔點陣化的最低解析度上限。使用它可在 EMF 或 WMF 圖像點陣化時平衡細節與檔案大小。它不會為整個 SVG 定義全域 DPI，也不會強制投影片上的每個物件皆轉為點陣圖。

下載[metafile-rasterization.pptx](metafile-rasterization.pptx)，該簡報包含一個具有緊密對角線的 EMF 圖像。以下範例透過[Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) 以三種點陣化解析度匯出其第一張投影片。所有其他匯出設定保持相同，以便比較結果。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

在輸出中，EMF 會以內嵌 PNG 形式出現在每個 SVG 中。下表列出了此簡報的測量值；它不是將 DPI 轉換為像素尺寸的通用公式。

| 中繼檔點陣化 DPI | 內嵌 PNG 尺寸 | SVG 檔案大小（位元組） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下圖比較了相同區域在相同放大顯示尺寸下的點陣化結果。對角線在 72 DPI 時顯示明顯的像素化，而在較高解析度下邊緣更平滑，且 SVG 檔案大小隨之增長。提升 DPI 並不一定能改善所有細節或改變每個匯出圖像。

![放大對角線細節，分別在 72、150、300 DPI 下的比較](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) 控制影像解析度降低，可能會掩蓋變更中繼檔點陣化解析度的效果。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) 控制 JPEG 編碼品質，而非中繼檔點陣化解析度。

## **為形狀與文字指定穩定的 ID**

將格式化控制器傳遞給[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/)，以為每個 SVG 形狀設定[SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/)。同時處理文字跨度的控制器可以對文字 `tspan` 元素設定[SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/)。

以下控制器使用[Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/)，此 ID 在形狀生命週期內保持穩定，並使用可重複的計數器為其文字跨度產生 ID。這使得產生的 ID 適合於對未變更的簡報進行後處理。

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

## **新增 SVG 事件處理程序**

在格式化控制器中，呼叫[SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) 並傳入[SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) 值，即可為匯出的形狀加入 JavaScript 事件處理程序。使用[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) 指定控制器，並在承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

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

宿主頁面可以定義 JavaScript 函式供處理程序呼叫。指派 ID 與事件處理程序可支援投影片檢視器、無障礙增強功能以及其他互動式 SVG 工作流程。

## **常見問題**

**何時應使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) 而不是[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

當所有文字必須脫離字型相依性時，請使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/)。如果只希望將使用外部字型的文字轉換為圖形，則使用[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)。

**縮小 SVG 檔案的最佳方法是什麼?**

先壓縮內嵌圖片、刪除裁切的圖像區域，並在目標環境能提供時選擇連結的字型檔案。請測試結果，因為降低影像解析度、降低 JPEG 品質以及向量化文字各自都有不同的品質與大小取捨。

**匯出後我可以修改 SVG 元素嗎?**

可以。透過格式化控制器指派 ID，之後即可在後處理工具或瀏覽器腳本中選取匹配的 SVG 元素。
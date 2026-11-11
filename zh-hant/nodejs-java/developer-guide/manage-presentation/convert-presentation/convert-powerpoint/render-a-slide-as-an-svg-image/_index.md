---
title: 在 JavaScript 中將簡報投影片渲染為 SVG 圖像
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
description: "在 JavaScript 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字、圖片、ID 與事件。"
---
## **概覽**

SVG 是一種可伸縮的基於 XML 的影像格式，適用於網路發佈、投影片檢視器、無障礙工作流程以及自動化後處理。Aspose.Slides for Node.js via Java 可將每張投影片匯出為單獨的 SVG 檔案，並讓您自行控制文字、字型、圖片與 SVG 元素的寫入方式。

當匯出的 SVG 必須保持緊湊、在不同瀏覽器間具有可預測性，或是要用於互動用途時，請使用[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/)。

## **將投影片匯出為 SVG**

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

檔名使用[Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/)而非迴圈索引。若投影片檢視器或網頁只需要特定圖形，也可以使用[Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/)匯出單一圖形。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) 控制 SVG 的呈現。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) 會將文字框納入渲染區域，而[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) 決定是否套用框的旋轉。若必須在不使用連字的情況下呈現文字，請將[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) 設為 `true`。

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

在將投影片匯出為 SVG 時，您可以控制文字是保留為文字還是轉換為向量圖形，以及外部字型的包含或參照方式。以下選項可協助您在視覺一致性、文字可選取性與字型相依性之間取得平衡。

### **將所有文字向量化**

將[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) 設為 `true`，即可將所有投影片文字寫入為向量圖形。此做法消除字型相依性，使視覺結果在不同瀏覽器間更一致，但文字將無法在 SVG 中被選取或搜尋。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) 會使用[SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) 的值來處理外部載入的字型。選擇 `AddLinksToFontFiles` 以參照獨立的字型檔案，`Embed` 以將字型資料嵌入 SVG，或 `Vectorize` 只將使用外部字型的文字轉為圖形。嵌入字型前請確認字型授權。

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

## **縮小嵌入圖片大小**

使用[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) 以降低嵌入圖片的解析度，使用[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) 省略被裁切的來源區域，並使用[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) 來控制 JPEG 編碼品質。這些設定會在降低檔案大小的同時犧牲影像保真度或保留的影像資料。

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

## **控制圖形檔光柵化解析度**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) 設定在 SVG 匯出過程中光柵化圖形檔的最低解析度上限。可利用此設定在光柵化 EMF 或 WMF 圖片時平衡細節與檔案大小。它不會為 SVG 定義全域 DPI，也不會迫使投影片上的每個物件皆成為光柵圖像。

下載[metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含一個具有緊密對角線的 EMF 圖片。以下範例透過[Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/)，以三種不同的光柵化解析度匯出其第一張投影片。所有其他匯出設定保持相同，以便比較結果。

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

在輸出結果中，EMF 會在每個 SVG 中變成一個嵌入的 PNG。下表顯示了此簡報的測量值；並非將 DPI 轉換為像素尺寸的一般公式。

| 圖形檔光柵化 DPI | 嵌入 PNG 尺寸 | SVG 檔案大小 (位元組) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下比較顯示了在相同放大顯示尺寸下，嵌入光柵的相同區域。對角線在 72 DPI 時可見像素化，在較高解析度下則邊緣更平滑，而 SVG 檔案大小會隨之增長。提高此值不一定會改善每個細節或改變每張匯出影像。

![放大後的對角線細節，分別為 72、150 與 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) 控制影像解析度降低，可能掩蓋改變圖形檔光柵化解析度的效果。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) 控制 JPEG 編碼品質，而非圖形檔光柵化解析度。

## **為圖形與文字指派穩定 ID**

將格式化控制器傳遞給[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/)，以為每個 SVG 圖形設定[SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/)。同時處理文字跨度的控制器可為文字 `tspan` 元素設定[SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) 值。

以下控制器使用[Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/)，該 ID 在圖形的生命週期內保持穩定，並使用可重複的計數器為文字跨度產生 ID。這使得產生的 ID 可用於未變更的簡報後處理。

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

## **加入 SVG 事件處理程序**

在格式化控制器中，呼叫[SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/)，並傳入[SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) 值，即可為匯出的圖形添加 JavaScript 事件處理程序。使用[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) 指定該控制器，並在承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

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

宿主頁面可以定義由處理程序參考的 JavaScript 函式。指派 ID 與事件處理程序可支援投影片檢視器、無障礙增強功能以及其他互動式 SVG 工作流程。

## **常見問題**

**何時應使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) 而非[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

當所有文字必須脫離字型相依時，請使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/)。若僅需將使用外部字型的文字轉為圖形，則使用[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)。

**縮小 SVG 的最佳方法是什麼？**

首先壓縮嵌入圖片、刪除裁切的圖像區域，並在目標環境能提供字型檔時選擇連結字型檔。請測試結果，因為降低影像解析度、降低 JPEG 品質以及向量化文字各自都有不同的品質與大小權衡。

**匯出後我可以修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，之後在後處理工具或瀏覽器腳本中選取相符的 SVG 元素。

---
title: 在 JavaScript 中將簡報投影片渲染為 SVG 圖像
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
description: "在 JavaScript 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字、圖片、ID 與事件。"
---
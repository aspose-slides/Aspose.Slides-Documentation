---
title: 在 Java 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "在 Java 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字、影像、ID 與事件。"
---
## **概述**

SVG 是一種可縮放的基於 XML 的影像格式，適用於網站發佈、投影片檢視器、無障礙工作流程以及自動化後處理。Aspose.Slides 會將每張投影片匯出為單獨的 SVG 檔案，讓您自行控制文字、字型、圖片以及 SVG 元素的寫入方式。

當匯出的 SVG 必須保持緊湊、在不同瀏覽器間具可預測性，或需要用於互動時，請使用[SVGOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/)。

## **匯出投影片為 SVG**

建立一個[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)，選取投影片，並使用[ISlide.writeAsSvg](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-)將其寫入串流。以下範例會將簡報中的每張投影片匯出為單獨的 SVG 檔案。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

檔名使用[ISlide.getSlideNumber](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#getSlideNumber--)而非迴圈索引。當投影片檢視器或網頁僅需要特定形狀時，也可以使用[IShape.writeAsSvg](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-)匯出單一形狀。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/) 控制 SVG 渲染。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) 會將文字框納入繪製區域，而[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-)則決定是否套用框的旋轉。若文字必須在不使用連寫字形的情況下繪製，請將[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) 設為 `true`。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **控制文字與字型**

### **向量化所有文字**

將[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) 設為 `true`，即可將所有投影片文字以向量圖形寫入。此做法會消除字型相依性，讓視覺結果在各瀏覽器間更一致，但文字將不再可作為 SVG 文字被選取或搜尋。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **選擇外部字型的處理方式**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) 會針對外部載入的字型使用[SvgExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgexternalfontshandling/)的值。可選擇 `AddLinksToFontFiles` 以參照個別字型檔案、`Embed` 以將字型資料嵌入 SVG，或 `Vectorize` 以將使用外部字型的文字渲染為圖形。嵌入字型前請確認字型授權。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **縮減嵌入影像大小**

使用[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) 可降低嵌入圖片的解析度，使用[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) 可省略被裁切的來源區域，並使用[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) 來控制 JPEG 編碼品質。這些設定會在犧牲影像細節或保留的影像資料下減少檔案大小。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **為形狀與文字指派穩定 ID**

使用[ISvgShapeFormattingController](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgshapeformattingcontroller/) 為每個 SVG 形狀設定[ISvgShape.setId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgshape/#setId-java.lang.String-)。若亦要為文字 `tspan` 元素設定[ISvgTSpan.setId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-)，請實作[ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgshapeandtextformattingcontroller/)。透過[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) 指派任一控制器。

下列控制器使用[IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--)，其在形狀生命週期內保持穩定，並以可重複的計數器處理其文字跨度。這使得產生的 ID 適合用於對未變更的簡報進行後處理。

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **新增 SVG 事件處理程式**

在[ISvgShapeFormattingController](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgshapeformattingcontroller/) 中，呼叫[ISvgShape.setEventHandler](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) 並傳入 [SvgEvent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgevent/) 值，即可為匯出的形狀新增 JavaScript 事件處理程式。使用[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) 指派此控制器，並在承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

宿主頁面可以定義由處理程式參考的 JavaScript 函式。指派 ID 與事件處理程式可支援投影片檢視器、無障礙功能增強以及其他互動式 SVG 工作流程。

## **常見問題**

**何時應該使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)而非[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgexternalfontshandling/)?**

當所有文字必須與字型無關時，請使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)。若僅需將使用外部字型的文字轉換為圖形，則使用[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgexternalfontshandling/)。

**如何讓 SVG 變得更小？**

首先壓縮嵌入的圖片、刪除被裁切的影像區域，並在目標環境能提供字型檔案時選擇連結字型檔。請測試最終結果，因為降低影像解析度、降低 JPEG 品質以及向量化文字會各自產生不同的品質與大小權衡。

**匯出後我可以修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，之後在後處理工具或瀏覽器腳本中選取相對應的 SVG 元素。
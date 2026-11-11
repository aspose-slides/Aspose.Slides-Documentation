---
title: 在 Java 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "在 Java 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字體、文字、圖像、ID 與事件。"
---
## **概觀**

SVG 是一種可伸縮的基於 XML 的圖像格式，適用於網路發布、投影片檢視器、可及性工作流程以及自動後處理。Aspose.Slides 將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字體、圖片和 SVG 元素的寫入方式。

當匯出的 SVG 必須保持緊湊、在各瀏覽器間具有可預測性，或適合互動使用時，請使用 [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/)。

## **將投影片匯出為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)，選取投影片，並使用 [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) 將其寫入串流。以下範例會將簡報中的每張投影片匯出為單獨的 SVG 檔案。

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

檔名使用 [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) 而非迴圈索引。當投影片檢視器或網頁僅需要特定圖形時，也可以使用 [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 匯出單一圖形。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) 控制 SVG 的渲染。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) 會將文字框納入渲染區域，而 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) 決定是否套用框架旋轉。當文字必須在不使用連字的情況下渲染時，將 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) 設為 `true`。

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

## **控制箭頭端的線端裁剪**

SVG 1.1 沒有標記內縮設定可指定線條在箭頭下方應停止的位置。預設情況下，Aspose.Slides 會縮短匯出的線條，使其筆畫不會突出於標記之外。將 [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) 設為 `true` 可將筆畫畫到線條原始端點。此設定僅影響 SVG 輸出。線條在投影片上的位置和長度保持不變。

此範例在寬度為 2 點與 10 點的線條上繪製三角形與菱形箭頭。它會匯出同一投影片兩次，僅更改裁剪選項。

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

比較圖顯示 10 點線條上的三角形箭頭。啟用裁剪時，箭頭尖端尖銳；停用裁剪時，筆畫會突出於標記的斜側，形成平坦的末端。

![在啟用裁剪時呈現尖銳頂端、停用裁剪時呈平坦末端的放大 10 點三角形](line-end-cropping.png)

在範例的其他線條中，2 點三角形的突出筆畫較不明顯。實心菱形在兩種寬度下都覆蓋了筆畫的末端。

## **控制文字與字體**

將投影片匯出為 SVG 時，您可以控制文字是保留為文字還是轉換為向量圖形，以及外部字體的包含或參考方式。以下選項可協助您在匯出 SVG 時平衡視覺一致性、文字選取性與字體依賴性。

### **向量化所有文字**

將 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) 設為 `true`，即可將所有投影片文字寫入為向量圖形。此做法可消除字體依賴，並讓視覺結果在各瀏覽器間更一致，但文字將不再可作為 SVG 文字被選取或搜尋。

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

### **選擇外部字體的處理方式**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) 會對外部載入的字體使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) 值。選擇 `AddLinksToFontFiles` 以參考獨立的字體檔案，`Embed` 以在 SVG 中嵌入字體資料，或 `Vectorize` 只將使用外部字體的文字渲染為圖形。嵌入字體前請先確認字體授權。

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

## **縮小嵌入圖像大小**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) 降低嵌入圖片的解析度，使用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) 省略裁剪過的來源區域，並使用 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) 控制 JPEG 編碼品質。這些設定會以影像忠實度或保留的圖像資料為代價減少檔案大小。

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

## **控制圖形檔光柵化解析度**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) 設定在 SVG 匯出期間光柵化圖形檔的最低解析度上限。當 EMF 或 WMF 圖像被光柵化時，可使用它來平衡細節與檔案大小。它不會為 SVG 定義全域 DPI，也不會強制投影片上的每個物件都變成光柵圖像。

下載 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含具有密集對角線的 EMF 圖像。以下範例透過 [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) 以三種光柵化解析度匯出其第一張投影片。其他匯出設定保持相同，以便比較結果。

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

在輸出結果中，EMF 會在每個 SVG 中變為一個嵌入的 PNG。以下測量值僅針對提供的簡報；它們並非將 DPI 轉換為像素尺寸的一般公式。

| 圖形檔光柵化 DPI | 嵌入 PNG 尺寸 | SVG 檔案大小（位元組） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下比較顯示相同區域的嵌入光柵圖在相同放大顯示尺寸下的情況。對角線在 72 DPI 時呈現明顯的像素化，而在更高解析度下邊緣較平滑，同時 SVG 檔案尺寸會變大。提升該值未必能改善所有細節或改變每個匯出的圖像。

![在 72、150 與 300 DPI 下放大的對角線細節](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) 控制圖像解析度的降低，可能會掩蓋變更圖形檔光柵化解析度的效果。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) 控制 JPEG 編碼品質，而非圖形檔光柵化解析度。

## **為圖形與文字分配穩定的 ID**

使用 [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) 為每個 SVG 圖形設定 [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-)。若要同時為文字 `tspan` 元素設定 [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-)，請實作 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/)。可透過 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) 指派任一控制器。

以下控制器使用 [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--)，該 ID 在圖形生命週期內保持穩定，並使用可重複的計數器為其文字跨度產生 ID。這使生成的 ID 適合於對未變更的簡報進行後處理。

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

## **新增 SVG 事件處理程序**

在 [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) 中，使用 [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) 並提供 [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) 值，即可為匯出的圖形新增 JavaScript 事件處理程序。透過 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) 指派該控制器，並在承載結果的頁面或 SVG 文件中定義 JavaScript 函式。

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

宿主頁面可定義由處理程序所參考的 JavaScript 函式。指派 ID 與事件處理程序可支援投影片檢視器、可及性增強以及其他互動式 SVG 工作流程。

## **常見問題**

**什麼時候應該使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) 而非 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

當所有文字必須脫離字體依賴時，請使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)。僅在需要將使用外部字體的文字轉換為圖形時，才使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)。

**如何最有效地縮小 SVG 大小？**

首先壓縮嵌入的圖片、刪除裁剪的圖像區域，並在目標環境能夠提供字體檔案時選擇連結字體檔。請測試結果，因為降低圖像解析度、降低 JPEG 品質以及向量化文字各自會帶來不同的品質與大小權衡。

**匯出後我可以修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，然後在後處理工具或瀏覽器腳本中選取相符的 SVG 元素。
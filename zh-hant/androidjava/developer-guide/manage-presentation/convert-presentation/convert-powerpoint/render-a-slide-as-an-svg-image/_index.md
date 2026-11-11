---
title: 在 Android 上將簡報投影片呈現為 SVG 圖片
linktitle: 投影片至 SVG
type: docs
weight: 50
url: /zh-hant/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "在 Android 上將 PowerPoint 投影片匯出為 SVG 圖片，並使用 Aspose.Slides 控制字型、文字、圖像、ID 與事件。"
---
## **概述**

SVG 是一種可縮放的 XML 為基礎的影像格式，適合用於網站出版、投影片檢視器、無障礙工作流程以及自動化後處理。Aspose.Slides for Android via Java 會將每張投影片匯出為單一 SVG 檔，並讓您控制文字、字型、圖片以及 SVG 元素的寫入方式。

在匯出的 SVG 必須緊湊、在不同瀏覽器間具備可預期行為，或需要即時互動時，請使用 [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/)。

## **匯出投影片為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)，選取投影片，並使用 [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) 將其寫入串流。以下範例將簡報中的每張投影片匯出為個別的 SVG 檔案。

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

檔名使用 [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) 而非迴圈索引。若投影片檢視器或網頁只需要特定圖形，亦可使用 [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 匯出單一圖形。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) 控制 SVG 的呈現方式。對於文字框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) 會將文字框納入繪製範圍，而 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) 則決定是否套用框的旋轉。若文字必須在不使用連字的情況下呈現，請將 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) 設為 `true`。

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

## **控制箭頭端點的線段裁切**

SVG 1.1 沒有標記內縮設定可指定線條在箭頭下方的停止位置。預設情況下，Aspose.Slides 會縮短匯出線段，使其筆畫不會超出標記。將 [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) 設為 `true`，即可將筆畫畫到線條原始端點。此設定僅影響 SVG 輸出，線條在投影片上的位置與長度保持不變。

範例在第 2 與第 10 點寬的線條上分別繪製三角形與菱形箭頭，並兩次匯出相同投影片，只變更裁切選項。

```java
import com.aspose.slides.*;
import android.graphics.Color;
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
            format.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

比較圖顯示 10 點寬線條的三角形箭頭。開啟裁切時，尖端尖銳；關閉裁切時，筆畫會穿過斜側標記，形成平坦的末端。

![放大 10 點寬的三角形，啟用裁切時尖端尖銳，停用裁切時呈平坦末端](line-end-cropping.png)

在範例的其他線條中，2 點寬的三角形因筆畫突出的情況較不明顯。填充的菱形在兩種寬度下都會覆蓋筆畫的末端。

## **控制文字與字型**

匯出投影片為 SVG 時，您可以決定文字是保留為文字還是轉換為向量圖形，以及外部字型的包含或參照方式。以下選項可幫助您在視覺一致性、文字可選取性與字型依賴性之間取得平衡。

### **向量化全部文字**

將 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) 設為 `true`，即可將所有投影片文字寫成向量圖形。這可消除字型依賴，使視覺結果在各瀏覽器間更一致，但文字將無法在 SVG 中被選取或搜尋。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) 會使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) 的值來處理外部載入的字型。選擇 [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) 以參照單獨的字型檔案、[SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) 以將字型資料嵌入 SVG，或 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) 只將使用外部字型的文字渲染為圖形。嵌入字型前請確認字型授權。

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

## **減少嵌入圖像的大小**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) 以降低嵌入圖片的解析度，使用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) 省略被裁切的來源區域，並使用 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) 來控制 JPEG 壓縮品質。這些設定會以影像品質或保留的圖像資料為代價減少檔案大小。

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) 設定在 SVG 匯出過程中光柵化圖形檔的最低解析度上限。可用於在光柵化 EMF 或 WMF 圖片時取得細節與檔案大小之間的平衡。此設定不會為整個 SVG 定義全域 DPI，也不會強制投影片上的每個物件皆轉為光柵圖像。

下載 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含一張具有密集對角線的 EMF 圖片。以下範例使用 [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) 於三種光柵化解析度匯出其第一張投影片。所有其他匯出設定保持相同，以便比較結果。

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

在輸出中，EMF 會變成每個 SVG 內嵌的一個 PNG。以下測量值僅針對提供的簡報；並非將 DPI 轉換為像素尺寸的通用公式。

| 圖形檔光柵化 DPI | 內嵌 PNG 尺寸 | SVG 檔案大小 (位元組) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下方比較顯示相同區域的光柵圖在相同放大顯示尺寸下的差異。對角線在 72 DPI 時可見像素化，在較高解析度下邊緣更平滑，而 SVG 檔案則隨之增大。提升此值未必能改善每個細節或改變每個匯出圖像。

![放大 72、150、300 DPI 下的對角線細節](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) 控制圖像解析度降低，可能會掩蓋變更圖形檔光柵化解析度的效果。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) 控制 JPEG 編碼品質，而非圖形檔光柵化解析度。

## **為圖形與文字指派穩定的 ID**

使用 [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) 為每個 SVG 圖形設定 [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-)。若也要在文字 `tspan` 元素上設定 [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-)，請實作 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/)。將任一控制器指派給 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-)

以下控制器使用 [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--)（在圖形生命週期內穩定）以及可重複使用的計數器為其文字跨度產生 ID，適合在未變更的簡報上進行後處理。

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

## **加入 SVG 事件處理程序**

在 [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) 中，呼叫 [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) 並傳入 [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) 值，即可為匯出的圖形新增 JavaScript 事件處理程序。使用 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) 指派控制器，並在承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

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

主頁面可以定義被處理器引用的 JavaScript 函式。指派 ID 與事件處理程序可支援投影片檢視器、無障礙增強及其他互動式 SVG 工作流程。

## **FAQ**

**何時應使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) 而非 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

當所有文字必須與字型無關時，使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)。若僅需將使用外部字型的文字轉換為圖形，則使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)。

**讓 SVG 更小的最佳方法是什麼？**

先壓縮嵌入圖片、刪除裁切的圖像區域，並在目標環境能提供字型檔時選擇連結字型檔。請測試結果，因為降低圖像解析度、降低 JPEG 品質以及向量化文字皆有不同的品質與大小取捨。

**匯出後可以修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，然後在後處理工具或瀏覽器腳本中選取相應的 SVG 元素。
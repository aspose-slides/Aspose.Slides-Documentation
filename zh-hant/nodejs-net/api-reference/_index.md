---
title: API 參考
type: docs
weight: 50
url: /zh-hant/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET 的文件由 Aspose.Slides for .NET API 參考提供。看看 .NET 類別與成員名稱如何映射到 JavaScript。"
---
## **概觀**

Aspose.Slides for Node.js via .NET 沒有自己的 API 參考文件。此套件以相同的名稱將 Aspose.Slides for .NET 的類別以 camelCase 成員名稱公開給 JavaScript，因此 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/zh-hant/net/) 會說明其類別、成員與列舉。

## **將 .NET 名稱對映至 JavaScript**

若要使用在 .NET API 參考中找到的成員，請依照以下規則：

- **類別與列舉保留 .NET 名稱**，列舉值亦同：`Presentation`、`ShapeType.Rectangle`、`SaveFormat.Pdf`。從套件中匯入它們：`const { Presentation, SaveFormat } = require("aspose.slides.via.net");`。
- **屬性與方法以小寫字母開頭**。`Presentation.Slides` 變為 `presentation.slides`，`ShapeCollection.AddAutoShape` 變為 `shapes.addAutoShape`。屬性仍為屬性：讀取與指派時不需要加上括號。
- **集合項目使用 `get(index)` 讀取**，項目數量使用 `count`：`presentation.slides.get(0)` 取代 `presentation.Slides[0]`。
- **某些重載會取得不同的名稱**。例如，`Slide.GetImage(Size)` 重載的名稱為 `slide.getImageWithImageSize({ width, height })`。其他則以可選的尾隨參數共用同一個方法：`presentation.save(path, format, options, slides)` 包含多個 `Presentation.Save` 重載，`new Presentation(null, buffer)` 會從 `Buffer` 開啟簡報。每個類別皆位於套件 `lib` 資料夾下的一個檔案中（例如 `node_modules/aspose.slides.via.net/lib/Slide.js`），可在此處查找精確名稱。
- **使用 `dispose` 釋放簡報**，完成後必須這樣做；JavaScript 沒有 `using` 陳述式。

此套件不會包裝每一個 .NET 成員。若在 .NET API 參考中找到的成員在類別檔案中缺失，則在 JavaScript 中無法使用。

## **範例**

以下腳本使用上述規則。每行註解說明其對應的 .NET 呼叫。它會在第一張投影片上加入帶文字的矩形，將投影片渲染為 960 × 540 像素的 PNG 圖片，並將簡報另存為 PDF。請在已依照 [Installation](/slides/zh-hant/nodejs-net/installation/) 安裝套件的專案資料夾中執行。

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

此腳本會在目前資料夾寫入 `slide.png` 與 `slide.pdf`，兩者皆會顯示帶文字的矩形。若未授權，檔案亦會顯示評估水印；詳情請參閱 [Licensing](/slides/zh-hant/nodejs-net/licensing/)。

欲了解此處使用的成員，請參閱 Aspose.Slides for .NET API 參考中的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/)、[ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapecollection/addautoshape/)、[TextFrame.Text](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/text/) 以及 [Slide.GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage/)。
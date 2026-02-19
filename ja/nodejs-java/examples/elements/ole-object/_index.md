---
title: OLE オブジェクト
type: docs
weight: 210
url: /ja/nodejs-java/examples/elements/ole-object/
keywords:
- コード例
- OLE オブジェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js で OLE オブジェクトを操作します。JavaScript を使用して PPT、PPTX、ODP プレゼンテーション内の埋め込みコンテンツを挿入、リンク、更新、抽出できます。"
---
本記事では、ファイルを OLE オブジェクトとして埋め込み、そのデータを **Aspose.Slides for Node.js via Java** を使用して更新する方法を示します。

## **OLE オブジェクトの追加**

PDF ファイルをプレゼンテーションに埋め込みます。

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

## **OLE オブジェクトへのアクセス**

スライド上の最初の OLE オブジェクト フレームを取得します。

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

## **OLE オブジェクトの削除**

スライドから埋め込まれた OLE オブジェクトを削除します。

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプが OLE オブジェクト フレームであると仮定しています。
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE オブジェクト データの更新**

既存の OLE オブジェクトに埋め込まれたデータを置き換えます。

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 最初のシェイプが OLE オブジェクト フレームであると仮定しています。
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
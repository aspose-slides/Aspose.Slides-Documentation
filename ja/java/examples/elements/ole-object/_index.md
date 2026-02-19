---
title: OLE オブジェクト
type: docs
weight: 210
url: /ja/java/examples/elements/ole-object/
keywords:
- コード例
- OLE オブジェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java で OLE オブジェクトを処理します: 挿入、リンク、更新、埋め込みコンテンツの抽出を Java で PPT、PPTX、ODP プレゼンテーションに対して行います。"
---
この記事では、ファイルをOLEオブジェクトとして埋め込み、そのデータを **Aspose.Slides for Java** を使用して更新する方法を示します。

## **OLE オブジェクトの追加**
PDF ファイルをプレゼンテーションに埋め込みます。

```java
static void addOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = Files.readAllBytes(Paths.get("doc.pdf"));
        IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE オブジェクトにアクセスする**
スライド上の最初の OLE オブジェクト フレームを取得します。

```java
static void accessOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = Files.readAllBytes(Paths.get("doc.pdf"));
        IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

        IOleObjectFrame firstOleFrame = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IOleObjectFrame) {
                firstOleFrame = (IOleObjectFrame) shape;
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

```java
static void removeOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = Files.readAllBytes(Paths.get("doc.pdf"));
        IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);
        
        slide.getShapes().remove(oleFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **OLE オブジェクト データの更新**
既存の OLE オブジェクトに埋め込まれたデータを置き換えます。

```java
static void updateOleObjectData() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        byte[] pdfData = Files.readAllBytes(Paths.get("doc.pdf"));
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

        byte[] newData = Files.readAllBytes(Paths.get("Picture.png"));
        OleEmbeddedDataInfo newDataInfo = new OleEmbeddedDataInfo(newData, "png");
        oleFrame.setEmbeddedData(newDataInfo);
    } finally {
        presentation.dispose();
    }
}
```
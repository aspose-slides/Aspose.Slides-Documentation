---
title: Đối tượng OLE
type: docs
weight: 210
url: /vi/java/examples/elements/ole-object/
keywords:
- ví dụ mã
- đối tượng OLE
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xử lý các đối tượng OLE trong Aspose.Slides for Java: chèn, liên kết, cập nhật và trích xuất nội dung được nhúng bằng Java trong các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách nhúng tệp dưới dạng đối tượng OLE và cập nhật dữ liệu của nó bằng cách sử dụng **Aspose.Slides for Java**.

## **Thêm đối tượng OLE**

Nhúng tệp PDF vào bản trình chiếu.

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

## **Truy cập đối tượng OLE**

Lấy khung đối tượng OLE đầu tiên trên một slide.

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

## **Xóa đối tượng OLE**

Xóa một đối tượng OLE đã nhúng khỏi slide.

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

## **Cập nhật dữ liệu đối tượng OLE**

Thay thế dữ liệu đã nhúng trong một đối tượng OLE hiện có.

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
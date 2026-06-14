---
title: Đối tượng OLE
type: docs
weight: 210
url: /vi/androidjava/examples/elements/ole-object/
keywords:
- ví dụ mã
- đối tượng OLE
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Xử lý các đối tượng OLE trong Aspose.Slides for Android: chèn, liên kết, cập nhật và trích xuất nội dung được nhúng bằng Java trong các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách nhúng tệp dưới dạng OLE object và cập nhật dữ liệu của nó bằng **Aspose.Slides for Android via Java**.

## **Thêm OLE Object**

Nhúng tệp PDF vào bản trình chiếu.

```java
static void addOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = readAllBytes("doc.pdf");
        IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập OLE Object**

Lấy khung OLE object đầu tiên trên một slide.

```java
static void accessOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = readAllBytes("doc.pdf");
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

## **Xóa OLE Object**

Xóa một OLE object đã nhúng khỏi slide.

```java
static void removeOleObject() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        byte[] pdfData = readAllBytes("doc.pdf");
        IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);
        
        slide.getShapes().remove(oleFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Cập nhật dữ liệu OLE Object**

Thay thế dữ liệu được nhúng trong một OLE object hiện có.

```java
static void updateOleObjectData() throws IOException {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        byte[] pdfData = readAllBytes("doc.pdf");
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

### **Phương thức readAllBytes**

```java
public static byte[] readAllBytes(String file) throws IOException {
    FileInputStream fis = new FileInputStream(new File(file));
    byte[] data = new byte[(int) file.length()];
    fis.read(data);
    fis.close();
    return data;
}
```
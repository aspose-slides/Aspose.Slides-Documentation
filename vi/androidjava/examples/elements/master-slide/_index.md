---
title: Slide Chủ
type: docs
weight: 30
url: /vi/androidjava/examples/elements/master-slide/
keywords:
- ví dụ mã
- slide chủ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Khám phá các ví dụ về slide chủ trong Aspose.Slides cho Android: tạo, chỉnh sửa và tạo kiểu cho master, placeholder và chủ đề trong PPT, PPTX và ODP với mã Java rõ ràng."
---
Các slide chủ tạo thành cấp cao nhất của hệ thống kế thừa slide trong PowerPoint. Một **master slide** định nghĩa các yếu tố thiết kế chung như nền, logo và định dạng văn bản. **Layout slides** kế thừa từ master slides, và **normal slides** kế thừa từ layout slides.

Bài viết này trình bày cách tạo, sửa đổi và quản lý master slides bằng Aspose.Slides cho Android thông qua Java.

## **Thêm Master Slide**

Ví dụ này cho thấy cách tạo một master slide mới bằng cách sao chép (clone) slide mặc định. Sau đó nó thêm một biểu ngữ tên công ty vào tất cả các slide thông qua kế thừa layout.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Sao chép slide chủ mặc định.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Thêm biểu ngữ với tên công ty ở phần trên của slide chủ.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Gán slide chủ mới cho một layout slide.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Gán layout slide cho slide đầu tiên trong bản trình bày.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Lưu ý 1:** Master slides cung cấp cách để áp dụng thương hiệu nhất quán hoặc các yếu tố thiết kế chung trên mọi slide. Bất kỳ thay đổi nào được thực hiện trên master sẽ tự động phản ánh trên các layout và normal slide phụ thuộc.  
> 
> 💡 **Lưu ý 2:** Bất kỳ hình dạng hoặc định dạng nào được thêm vào master slide sẽ được layout slide kế thừa và, do đó, tất cả các normal slide sử dụng các layout đó cũng sẽ kế thừa. Hình ảnh dưới đây minh họa cách một hộp văn bản được thêm vào master slide sẽ tự động hiển thị trên slide cuối cùng.

![Ví dụ Kế thừa Master](master-slide-banner.png)

## **Truy cập Master Slide**

Bạn có thể truy cập master slides bằng cách sử dụng bộ sưu tập master của bản trình bày. Đây là cách lấy và làm việc với chúng:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Thay đổi loại nền.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa Master Slide**

Master slides có thể được xóa bằng cách chỉ mục hoặc bằng tham chiếu.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Xóa một slide chủ theo chỉ mục.
        presentation.getMasters().removeAt(0);

        // Xóa một slide chủ theo tham chiếu.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa các Master Slide không dùng**

Một số bản trình bày chứa các master slides không được sử dụng. Việc xóa các slide này có thể giúp giảm kích thước tệp.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Xóa tất cả các slide chủ không dùng (ngay cả những slide được đánh dấu Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```
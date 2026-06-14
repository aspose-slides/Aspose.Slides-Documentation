---
title: Slide Master
type: docs
weight: 30
url: /vi/java/examples/elements/master-slide/
keywords:
- ví dụ mã
- slide master
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Khám phá các ví dụ về slide master của Aspose.Slides cho Java: tạo, chỉnh sửa và thiết kế master, placeholder và theme trong PPT, PPTX và ODP bằng mã Java rõ ràng."
---
Các slide master tạo thành cấp cao nhất của cây kế thừa slide trong PowerPoint. Một **master slide** định nghĩa các yếu tố thiết kế chung như nền, logo và định dạng văn bản. **Layout slides** kế thừa từ master slide, và **normal slides** kế thừa từ layout slide.

Bài viết này trình bày cách tạo, chỉnh sửa và quản lý các master slide bằng Aspose.Slides cho Java.

## **Thêm Master Slide**

Ví dụ này cho thấy cách tạo một master slide mới bằng cách sao chép slide mặc định. Sau đó nó thêm một biểu ngữ tên công ty vào tất cả các slide thông qua kế thừa layout.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Sao chép slide master mặc định.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Thêm biểu ngữ tên công ty vào phía trên của slide master.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Gán slide master mới cho một layout slide.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Gán layout slide cho slide đầu tiên trong bản trình chiếu.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Lưu ý 1:** Các master slide cung cấp cách áp dụng thương hiệu nhất quán hoặc các yếu tố thiết kế chung trên tất cả các slide. Bất kỳ thay đổi nào được thực hiện trên master sẽ tự động phản ánh trên các layout và normal slide phụ thuộc.

> 💡 **Lưu ý 2:** Bất kỳ hình dạng hoặc định dạng nào được thêm vào một master slide đều được kế thừa bởi các layout slide và, theo đó, tất cả các normal slide sử dụng những layout đó.  
> Hình ảnh dưới đây minh họa cách một hộp văn bản được thêm vào master slide sẽ tự động hiển thị trên slide cuối cùng.

![Ví dụ Kế thừa Master](master-slide-banner.png)

## **Truy cập Master Slide**

Bạn có thể truy cập các master slide bằng cách sử dụng bộ sưu tập master của bản trình chiếu. Dưới đây là cách lấy và làm việc với chúng:

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

Các master slide có thể bị xóa bằng chỉ mục hoặc bằng tham chiếu.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Xóa một slide master theo chỉ mục.
        presentation.getMasters().removeAt(0);

        // Xóa một slide master theo tham chiếu.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa các Master Slide không sử dụng**

Một số bản trình chiếu chứa các master slide không được sử dụng. Việc xóa các slide này có thể giúp giảm kích thước tệp.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Xóa tất cả các slide master không được sử dụng (kể cả những slide được đánh dấu Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```
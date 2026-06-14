---
title: Slide Chủ Đề
type: docs
weight: 30
url: /vi/nodejs-java/examples/elements/master-slide/
keywords:
- ví dụ mã
- slide chủ đề
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá các ví dụ về slide chủ đề trong Aspose.Slides cho Node.js: tạo, chỉnh sửa và định dạng các master, placeholder và theme trong PPT, PPTX và ODP với mã nguồn rõ ràng."
---
Các slide chủ đề tạo thành cấp cao nhất của phân cấp kế thừa slide trong PowerPoint. Một **master slide** định nghĩa các yếu tố thiết kế chung như nền, logo và định dạng văn bản. **Layout slides** kế thừa từ master slides, và **normal slides** kế thừa từ layout slides.

Bài viết này trình bày cách tạo, chỉnh sửa và quản lý các master slide bằng Aspose.Slides cho Node.js thông qua Java.

## **Thêm slide chủ đề**

Ví dụ này cho thấy cách tạo một slide chủ đề mới bằng cách sao chép slide mặc định. Sau đó nó thêm một banner tên công ty vào tất cả các slide thông qua kế thừa layout.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Sao chép slide chủ đề mặc định.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Thêm banner tên công ty vào phần trên cùng của slide chủ đề.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Gán slide chủ đề mới cho một layout slide.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Gán layout slide cho slide đầu tiên trong bản trình chiếu.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Ghi chú 1:** Các slide chủ đề cung cấp cách để áp dụng thương hiệu nhất quán hoặc các yếu tố thiết kế chung trên toàn bộ slide. Bất kỳ thay đổi nào được thực hiện trên master sẽ tự động phản ánh trên các layout và slide bình thường phụ thuộc.

> 💡 **Ghi chú 2:** Bất kỳ hình dạng hoặc định dạng nào được thêm vào một master slide sẽ được kế thừa bởi các layout slide và, theo đó, tất cả các slide bình thường sử dụng các layout đó.  
> Hình ảnh dưới đây minh họa cách một hộp văn bản được thêm vào master slide sẽ tự động được hiển thị trên slide cuối cùng.

![Ví dụ kế thừa master](master-slide-banner.png)

## **Truy cập slide chủ đề**

Bạn có thể truy cập các slide chủ đề bằng cách sử dụng bộ sưu tập master của bản trình chiếu. Dưới đây là cách lấy và làm việc với chúng:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Thay đổi loại nền.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa slide chủ đề**

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Xóa một slide chủ đề theo chỉ mục.
        presentation.getMasters().removeAt(0);

        // Xóa một slide chủ đề theo tham chiếu.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa các slide chủ đề không sử dụng**

Một số bản trình chiếu chứa các slide chủ đề không được sử dụng. Việc xóa các slide này có thể giúp giảm kích thước tệp.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Xóa tất cả các slide chủ đề không sử dụng (ngay cả những slide được đánh dấu là Preserve).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```
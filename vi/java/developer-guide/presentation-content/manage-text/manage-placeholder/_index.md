---
title: Quản lý Trình giữ chỗ trong Bản thuyết trình bằng Java
linktitle: Quản lý Trình giữ chỗ
type: docs
weight: 10
url: /vi/java/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ hình ảnh
- trình giữ chỗ biểu đồ
- văn bản nhắc
- PowerPoint
- OpenDocument
- bản thuyết trình
- Java
- Aspose.Slides
description: "Quản lý trình giữ chỗ một cách dễ dàng trong Aspose.Slides cho Java: thay thế văn bản, tùy chỉnh thông báo & đặt độ trong suốt hình ảnh trong PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các trình giữ chỗ (placeholder) trong bản thuyết trình một cách lập trình. Bài viết này giải thích cách tìm trình giữ chỗ trên các slide và thay đổi văn bản của chúng, thiết lập văn bản nhắc tùy chỉnh cho các bố cục trình giữ chỗ, và điều chỉnh độ trong suốt của hình ảnh được sử dụng làm nền cho trình giữ chỗ. Ngoài ra còn có phần FAQ ngắn gọn làm rõ sự khác nhau giữa trình giữ chỗ cơ sở và hình dạng cục bộ, giải thích cách thay đổi trình giữ chỗ có thể được áp dụng thông qua bố cục hoặc master, và chỉ dẫn cách quản lý trình giữ chỗ tiêu đề và chân trang.

## **Thay đổi văn bản trong trình giữ chỗ**
Sử dụng [Aspose.Slides for Java](/slides/vi/java/), bạn có thể tìm và sửa đổi các trình giữ chỗ trên các slide trong bản thuyết trình. Aspose.Slides cho phép bạn thay đổi văn bản trong một trình giữ chỗ.

**Điều kiện tiên quyết**: Bạn cần một bản thuyết trình chứa trình giữ chỗ. Bạn có thể tạo bản thuyết trình như vậy trong ứng dụng Microsoft PowerPoint tiêu chuẩn.

Đây là cách bạn dùng Aspose.Slides để thay thế văn bản trong trình giữ chỗ của bản thuyết trình đó:

1. Tạo một thể hiện của lớp [`Presentation`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) và truyền bản thuyết trình làm tham số.
2. Lấy tham chiếu đến một slide thông qua chỉ mục của nó.
3. Duyệt qua các shape để tìm trình giữ chỗ.
4. Ép kiểu shape trình giữ chỗ sang một [`AutoShape`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/AutoShape) và thay đổi văn bản bằng cách sử dụng [`TextFrame`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrame) liên kết với [`AutoShape`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/AutoShape).
5. Lưu bản thuyết trình đã sửa đổi.

Mã Java này cho thấy cách thay đổi văn bản trong một trình giữ chỗ:

```java
// Tạo một đối tượng lớp Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Truy cập slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Duyệt qua các shape để tìm trình giữ chỗ
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Thay đổi văn bản trong mỗi trình giữ chỗ
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Lưu bản thuyết trình vào đĩa
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt văn bản nhắc trong trình giữ chỗ**
Các bố cục tiêu chuẩn và đã được tạo sẵn chứa các văn bản nhắc cho trình giữ chỗ như ***Click to add a title*** hoặc ***Click to add a subtitle***. Sử dụng Aspose.Slides, bạn có thể chèn các văn bản nhắc tùy ý của mình vào các bố cục trình giữ chỗ.

Mã Java này cho thấy cách đặt văn bản nhắc trong một trình giữ chỗ:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Duyệt qua slide
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint hiển thị "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Thêm phụ đề
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt độ trong suốt hình ảnh cho trình giữ chỗ**

Aspose.Slides cho phép bạn thiết lập độ trong suốt của hình ảnh nền trong một trình giữ chỗ văn bản. Bằng cách điều chỉnh độ trong suốt của ảnh trong khung này, bạn có thể làm nổi bật văn bản hoặc hình ảnh (tùy thuộc vào màu sắc của văn bản và hình ảnh).

Mã Java này cho thấy cách đặt độ trong suốt cho nền ảnh (bên trong một shape):

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```

## **Câu hỏi thường gặp**

**Trình giữ chỗ cơ sở là gì và nó khác gì so với shape cục bộ trên slide?**

Trình giữ chỗ cơ sở là shape gốc trên một bố cục hoặc master mà shape của slide kế thừa—kiểu, vị trí và một số định dạng được lấy từ nó. Shape cục bộ là độc lập; nếu không có trình giữ chỗ cơ sở, việc kế thừa sẽ không áp dụng.

**Làm sao tôi có thể cập nhật tất cả tiêu đề hoặc chú thích trên toàn bộ bản thuyết trình mà không phải duyệt qua từng slide?**

Chỉnh sửa trình giữ chỗ tương ứng trên bố cục hoặc master. Các slide dựa trên những bố cục/master đó sẽ tự động kế thừa thay đổi.

**Làm thế nào để tôi kiểm soát các trình giữ chỗ tiêu đề/chân trang tiêu chuẩn—ngày & giờ, số slide và văn bản chân trang?**

Sử dụng các trình quản lý HeaderFooter ở phạm vi phù hợp (slide bình thường, bố cục, master, ghi chú/bản phát tay) để bật hoặc tắt các trình giữ chỗ này và đặt nội dung của chúng.
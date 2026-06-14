---
title: Quản lý Trình giữ chỗ Bài thuyết trình trên Android
linktitle: Quản lý Trình giữ chỗ
type: docs
weight: 10
url: /vi/androidjava/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ hình ảnh
- trình giữ chỗ biểu đồ
- văn bản gợi ý
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Quản lý trình giữ chỗ trong Aspose.Slides cho Android qua Java một cách dễ dàng: thay thế văn bản, tùy chỉnh lời nhắc và thiết lập độ trong suốt hình ảnh trong PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các trình giữ chỗ trong bài thuyết trình một cách lập trình. Bài viết này giải thích cách tìm trình giữ chỗ trên các slide và thay đổi văn bản của chúng, đặt văn bản gợi ý tùy chỉnh cho các bố cục trình giữ chỗ, và điều chỉnh độ trong suốt của hình ảnh được sử dụng làm nền cho trình giữ chỗ. Nó cũng bao gồm một phần Câu hỏi thường gặp ngắn gọn làm rõ sự khác biệt giữa trình giữ chỗ cơ sở và hình dạng cục bộ, giải thích cách các thay đổi trình giữ chỗ có thể được áp dụng thông qua bố cục hoặc master, và chỉ dẫn quản lý các trình giữ chỗ tiêu đề và chân trang.

## **Thay đổi văn bản trong Trình giữ chỗ**
Sử dụng [Aspose.Slides for Android via Java](/slides/vi/androidjava/), bạn có thể tìm và sửa đổi các trình giữ chỗ trên các slide trong bài thuyết trình. Aspose.Slides cho phép bạn thực hiện các thay đổi đối với văn bản trong một trình giữ chỗ.

**Yêu cầu trước**: Bạn cần một bài thuyết trình chứa trình giữ chỗ. Bạn có thể tạo một bài thuyết trình như vậy bằng ứng dụng Microsoft PowerPoint tiêu chuẩn.

Đây là cách bạn sử dụng Aspose.Slides để thay thế văn bản trong trình giữ chỗ của bài thuyết trình đó:

1. Khởi tạo lớp [`Presentation`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) và truyền bài thuyết trình làm đối số.
2. Lấy một tham chiếu slide thông qua chỉ mục của nó.
3. Duyệt qua các shape để tìm trình giữ chỗ.
4. Chuyển kiểu shape trình giữ chỗ sang một [`AutoShape`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AutoShape) và thay đổi văn bản bằng cách sử dụng [`TextFrame`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrame) liên kết với [`AutoShape`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AutoShape).
5. Lưu bài thuyết trình đã sửa đổi.

Đoạn mã Java này cho thấy cách thay đổi văn bản trong một trình giữ chỗ:

```java
// Khởi tạo một lớp Presentation
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

    // Lưu bài thuyết trình vào đĩa
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt văn bản gợi ý trong Trình giữ chỗ**
Các bố cục tiêu chuẩn và được xây dựng sẵn chứa các văn bản gợi ý cho trình giữ chỗ như ***Click to add a title*** hoặc ***Click to add a subtitle***. Sử dụng Aspose.Slides, bạn có thể chèn các văn bản gợi ý ưa thích của mình vào các bố cục trình giữ chỗ.

Đoạn mã Java này cho bạn biết cách đặt văn bản gợi ý trong một trình giữ chỗ:

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

## **Đặt độ trong suốt cho hình ảnh Trình giữ chỗ**

Aspose.Slides cho phép bạn đặt độ trong suốt của hình ảnh nền trong một trình giữ chỗ văn bản. Bằng cách điều chỉnh độ trong suốt của hình ảnh trong khung này, bạn có thể làm cho văn bản hoặc hình ảnh nổi bật hơn (tùy thuộc vào màu sắc của văn bản và hình ảnh).

Đoạn mã Java này cho bạn biết cách thiết lập độ trong suốt cho nền hình ảnh (bên trong một shape):

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

**Trình giữ chỗ cơ sở là gì, và nó khác gì so với shape cục bộ trên một slide?**

Trình giữ chỗ cơ sở là shape gốc trên một layout hoặc master mà shape của slide kế thừa—loại, vị trí và một số định dạng được lấy từ nó. Shape cục bộ là độc lập; nếu không có trình giữ chỗ cơ sở, việc kế thừa sẽ không áp dụng.

**Làm thế nào để cập nhật tất cả tiêu đề hoặc chú thích trong toàn bộ bài thuyết trình mà không phải duyệt từng slide?**

Chỉnh sửa trình giữ chỗ tương ứng trên layout hoặc master. Các slide dựa trên những layout/master đó sẽ tự động kế thừa thay đổi.

**Làm sao tôi có thể kiểm soát các trình giữ chỗ tiêu đề/chân trang tiêu chuẩn—ngày & giờ, số slide và văn bản chân trang?**

Sử dụng các trình quản lý HeaderFooter ở phạm vi thích hợp (slide thường, layout, master, ghi chú/bản phát tay) để bật hoặc tắt các trình giữ chỗ đó và để đặt nội dung của chúng.
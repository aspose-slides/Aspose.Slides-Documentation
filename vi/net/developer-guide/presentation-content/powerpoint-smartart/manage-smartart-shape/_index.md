---
title: Quản lý Đồ họa SmartArt trong Bản trình bày bằng .NET
linktitle: Đồ họa SmartArt
type: docs
weight: 20
url: /vi/net/manage-smartart-shape/
keywords:
- đối tượng SmartArt
- đồ họa SmartArt
- kiểu dáng SmartArt
- màu SmartArt
- tạo SmartArt
- thêm SmartArt
- chỉnh sửa SmartArt
- thay đổi SmartArt
- truy cập SmartArt
- kiểu bố trí SmartArt
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tự động tạo, chỉnh sửa và định dạng SmartArt trong PowerPoint bằng .NET sử dụng Aspose.Slides, với các ví dụ mã ngắn gọn và hướng dẫn tập trung vào hiệu suất."
---
## **Tổng quan**

Aspose.Slides cho phép bạn tạo và quản lý đồ họa SmartArt trong các bài thuyết trình PowerPoint một cách lập trình. Bài viết này giải thích cách thêm một hình SmartArt vào slide, truy cập các hình SmartArt hiện có, tìm SmartArt theo một kiểu bố trí cụ thể, và cập nhật giao diện của nó bằng cách thay đổi kiểu dáng SmartArt hoặc kiểu màu.

Các ví dụ minh họa cách làm việc với các hình SmartArt qua bộ sưu tập hình dạng của slide trong bản trình bày, kiểm tra xem một hình có phải là SmartArt hay không và sau đó chỉnh sửa hoặc kiểm tra các thuộc tính của nó.

## **Tạo một hình SmartArt**
Aspose.Slides cho .NET hiện cho phép thêm các hình SmartArt tùy chỉnh vào slide từ đầu. Aspose.Slides cho .NET đã cung cấp API đơn giản nhất để tạo các hình SmartArt một cách dễ dàng nhất. Để tạo một hình SmartArt trong slide, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục (Index) của nó.
- Thêm một hình SmartArt bằng cách đặt LayoutType cho nó.
- Ghi bản trình bày đã chỉnh sửa ra thành file PPTX.

```c#
// Khởi tạo bản trình bày
using (Presentation pres = new Presentation())
{

    // Truy cập slide của bản trình bày
    ISlide slide = pres.Slides[0];

    // Thêm hình Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Lưu bản trình bày
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Truy cập một hình SmartArt trên Slide**
Mã sau sẽ được sử dụng để truy cập các hình SmartArt đã thêm vào slide của bản trình bày. Trong mã mẫu, chúng ta sẽ duyệt qua mọi hình trong slide và kiểm tra xem nó có phải là hình SmartArt không. Nếu hình là kiểu SmartArt thì chúng ta sẽ ép kiểu nó thành thể hiện SmartArt.

```c#
 // Tải bản trình bày mong muốn
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Duyệt qua mọi hình trong slide đầu tiên
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Kiểm tra xem hình có phải là kiểu SmartArt không
        if (shape is ISmartArt)
        {
            // Ép kiểu hình sang SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```

## **Truy cập một hình SmartArt với Kiểu Bố Trí Cụ Thể**
Mã mẫu sau sẽ giúp truy cập hình SmartArt với LayoutType cụ thể. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc và chỉ được đặt khi hình SmartArt được thêm vào.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình bày có chứa hình SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục (Index) của nó.
- Duyệt qua mọi hình trong slide đầu tiên.
- Kiểm tra xem hình có phải là kiểu SmartArt và nếu đúng, ép kiểu hình đã chọn thành SmartArt.
- Kiểm tra hình SmartArt với LayoutType cụ thể và thực hiện những gì cần làm tiếp theo.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Duyệt qua mọi hình trong slide đầu tiên
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Kiểm tra xem hình có phải là kiểu SmartArt không
        if (shape is ISmartArt)
        {
            // Ép kiểu hình sang SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Kiểm tra bố cục SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```

## **Thay đổi Kiểu Dáng của Hình SmartArt**
Mã mẫu sau sẽ giúp truy cập hình SmartArt với LayoutType cụ thể.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình bày có chứa hình SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục (Index) của nó.
- Duyệt qua mọi hình trong slide đầu tiên.
- Kiểm tra xem hình có phải là kiểu SmartArt và nếu đúng, ép kiểu hình đã chọn thành SmartArt.
- Tìm hình SmartArt với Kiểu Dáng (Style) cụ thể.
- Đặt Kiểu Dáng mới cho hình SmartArt.
- Lưu bản trình bày.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Duyệt qua mọi hình trong slide đầu tiên
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Kiểm tra xem hình có phải là kiểu SmartArt không
        if (shape is ISmartArt)
        {
            // Ép kiểu hình sang SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Kiểm tra kiểu SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Thay đổi Kiểu SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Lưu Bản trình bày
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```

## **Thay đổi Kiểu Màu của Hình SmartArt**
Trong ví dụ này, chúng ta sẽ học cách thay đổi kiểu màu cho bất kỳ hình SmartArt nào. Mã mẫu sau sẽ truy cập hình SmartArt với kiểu màu cụ thể và sẽ thay đổi kiểu của nó.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình bày có chứa hình SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục (Index) của nó.
- Duyệt qua mọi hình trong slide đầu tiên.
- Kiểm tra xem hình có phải là kiểu SmartArt và nếu đúng, ép kiểu hình đã chọn thành SmartArt.
- Tìm hình SmartArt với Kiểu Màu (Color Style) cụ thể.
- Đặt Kiểu Màu mới cho hình SmartArt.
- Lưu bản trình bày.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Duyệt qua mọi hình trong slide đầu tiên
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Kiểm tra xem hình có phải là kiểu SmartArt không
        if (shape is ISmartArt)
        {
            // Ép kiểu hình sang SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Kiểm tra kiểu màu SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Thay đổi kiểu màu SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Lưu Bản trình bày
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Can I animate SmartArt as a single object?**  
Có. SmartArt là một hình dạng, vì vậy bạn có thể áp dụng [hoạt ảnh chuẩn](/slides/vi/net/powerpoint-animation/) thông qua API hoạt ảnh (đầu vào, thoát, nhấn mạnh, đường di chuyển) giống như với các hình dạng khác.

**How can I find a specific SmartArt on a slide if I don’t know its internal ID?**  
Thiết lập và sử dụng Văn bản thay thế (AltText) và tìm kiếm hình bằng giá trị đó — đây là cách được khuyến nghị để xác định vị trí hình mục tiêu.

**Can I group SmartArt with other shapes?**  
Có. Bạn có thể nhóm SmartArt với các hình dạng khác (hình ảnh, bảng, v.v.) và sau đó [điều chỉnh nhóm](/slides/vi/net/group/).

**How do I get an image of a specific SmartArt (e.g., for a preview or report)?**  
Xuất một ảnh thu nhỏ/hình ảnh của hình; thư viện có thể [kết xuất các hình riêng lẻ](/slides/vi/net/create-shape-thumbnails/) thành các file raster (PNG/JPG/TIFF).

**Will the SmartArt appearance be preserved when converting the whole presentation to PDF?**  
Có. Engine kết xuất nhằm đạt độ trung thực cao cho [xuất PDF](/slides/vi/net/convert-powerpoint-to-pdf/), với nhiều tùy chọn về chất lượng và tính tương thích.
---
title: Chuyển đổi PPT và PPTX sang JPG trong C++
linktitle: PowerPoint sang JPG
type: docs
weight: 60
url: /vi/cpp/convert-powerpoint-to-jpg/
keywords: 
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang JPG
- bài thuyết trình sang JPG
- slide sang JPG
- PPT sang JPG
- PPTX sang JPG
- lưu PowerPoint dưới dạng JPG
- lưu bài thuyết trình dưới dạng JPG
- lưu slide dưới dạng JPG
- lưu PPT dưới dạng JPG
- lưu PPTX dưới dạng JPG
- xuất PPT sang JPG
- xuất PPTX sang JPG
- C++
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint (PPT, PPTX) sang hình ảnh JPG chất lượng cao trong C++ với Aspose.Slides bằng các ví dụ mã nhanh chóng và đáng tin cậy."
---
## **Giới thiệu**

Việc chuyển đổi các bài thuyết trình PowerPoint và OpenDocument sang ảnh JPG giúp việc chia sẻ slide, tối ưu hiệu suất và nhúng nội dung vào trang web hoặc ứng dụng. Aspose.Slides for C++ cho phép bạn chuyển đổi các tệp PPTX, PPT và ODP thành hình ảnh JPEG chất lượng cao. Hướng dẫn này giải thích các phương pháp chuyển đổi khác nhau.

Với các tính năng này, bạn dễ dàng triển khai trình xem bài thuyết trình của riêng mình và tạo ảnh thu nhỏ cho mỗi slide. Điều này có thể hữu ích nếu bạn muốn bảo vệ slide khỏi việc sao chép hoặc trình chiếu bài thuyết trình ở chế độ chỉ đọc. Aspose.Slides cho phép bạn chuyển đổi toàn bộ bài thuyết trình hoặc một slide cụ thể sang các định dạng hình ảnh.

## **Chuyển đổi slide bài thuyết trình sang ảnh JPG**

Dưới đây là các bước để chuyển đổi tệp PPT, PPTX hoặc ODP sang JPG:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Lấy đối tượng slide có kiểu [ISlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/) từ bộ sưu tập slide của bài thuyết trình.
1. Tạo hình ảnh của slide bằng phương thức [ISlide.GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/) .
1. Gọi phương thức [IImage.Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/save/) trên đối tượng hình ảnh. Truyền tên tệp đầu ra và định dạng ảnh làm đối số.

{{% alert color="primary" %}} 

**Lưu ý:** Việc chuyển đổi PPT, PPTX hoặc ODP sang JPG khác với chuyển đổi sang các định dạng khác trong API Aspose.Slides for C++. Đối với các định dạng khác, bạn thường dùng phương thức [IPresentation.Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/save/) . Tuy nhiên, đối với chuyển đổi sang JPG, bạn cần sử dụng phương thức [IImage.Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/save/) .

{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Tạo ảnh slide với tỷ lệ đã chỉ định.
    auto image = slide->GetImage(scaleX, scaleY);

    // Lưu ảnh ra đĩa ở định dạng JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Chuyển đổi slide sang JPG với kích thước tùy chỉnh**

Để thay đổi kích thước của các ảnh JPG đầu ra, bạn có thể đặt kích thước ảnh bằng cách truyền vào phương thức [ISlide.GetImage(Size)](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) . Điều này cho phép bạn tạo ra các ảnh với chiều rộng và chiều cao cụ thể, đảm bảo đầu ra đáp ứng yêu cầu về độ phân giải và tỷ lệ khung hình. Tính linh hoạt này đặc biệt hữu ích khi tạo ảnh cho các ứng dụng web, báo cáo hoặc tài liệu, nơi yêu cầu kích thước ảnh chính xác.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Tạo ảnh slide với kích thước đã chỉ định.
    auto image = slide->GetImage(imageSize);

    // Lưu ảnh ra đĩa ở định dạng JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Hiển thị bình luận khi lưu slide dưới dạng ảnh**

Aspose.Slides for C++ cung cấp tính năng cho phép bạn hiển thị bình luận trên các slide của bài thuyết trình khi chuyển đổi chúng thành ảnh JPG. Tính năng này đặc biệt hữu ích để bảo tồn các chú thích, phản hồi hoặc thảo luận do cộng tác viên thêm vào trong các bài thuyết trình PowerPoint. Bằng cách bật tùy chọn này, bạn đảm bảo các bình luận hiển thị trong các ảnh được tạo, giúp dễ dàng xem lại và chia sẻ phản hồi mà không cần mở tệp bài thuyết trình gốc.

Giả sử chúng ta có một tệp bài thuyết trình, "sample.pptx", với một slide chứa bình luận:

![Slide có bình luận](slide_with_comments.png)

Đoạn mã C++ dưới đây chuyển đổi slide thành ảnh JPG đồng thời giữ lại các bình luận:

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Đặt tùy chọn cho bình luận của slide.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Chuyển đổi slide đầu tiên thành ảnh.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Kết quả:

![Ảnh JPG có bình luận](image_with_comments.png)

## **Xem thêm**

Xem các tùy chọn khác để chuyển đổi PPT, PPTX hoặc ODP sang hình ảnh, chẳng hạn:

- [Chuyển đổi PowerPoint sang GIF](/slides/vi/cpp/convert-powerpoint-to-animated-gif/)
- [Chuyển đổi PowerPoint sang PNG](/slides/vi/cpp/convert-powerpoint-to-png/)
- [Chuyển đổi PowerPoint sang TIFF](/slides/vi/cpp/convert-powerpoint-to-tiff/)
- [Chuyển đổi PowerPoint sang SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Để xem cách Aspose.Slides chuyển đổi PowerPoint sang ảnh JPG, hãy thử các công cụ chuyển đổi trực tuyến miễn phí sau: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/vi/conversion/pptx-to-jpg) và [PPT to JPG](https://products.aspose.app/slides/vi/conversion/ppt-to-jpg) .

{{% /alert %}}

![Trình chuyển đổi PPTX sang JPG trực tuyến miễn phí](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose cung cấp một [ứng dụng web Collage MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể ghép nối [JPG to JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG to PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và nhiều hơn nữa. 

Bằng cách áp dụng các nguyên tắc tương tự như trong bài viết này, bạn có thể chuyển đổi ảnh từ định dạng này sang định dạng khác. Để biết thêm thông tin, hãy xem các trang sau: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/cpp/conversion/image-to-jpg/); chuyển đổi [JPG to image](https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-image/); chuyển đổi [JPG to PNG](https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-png/), chuyển đổi [PNG to JPG](https://products.aspose.com/slides/vi/cpp/conversion/png-to-jpg/); chuyển đổi [PNG to SVG](https://products.aspose.com/slides/vi/cpp/conversion/png-to-svg/), chuyển đổi [SVG to PNG](https://products.aspose.com/slides/vi/cpp/conversion/svg-to-png/) .

{{% /alert %}}

## **Câu hỏi thường gặp**

**Phương pháp này có hỗ trợ chuyển đổi hàng loạt không?**

Có, Aspose.Slides cho phép chuyển đổi hàng loạt nhiều slide sang JPG trong một lần thao tác.

**Việc chuyển đổi có hỗ trợ SmartArt, biểu đồ và các đối tượng phức tạp khác không?**

Có, Aspose.Slides hiển thị toàn bộ nội dung, bao gồm SmartArt, biểu đồ, bảng, hình dạng và hơn thế nữa. Tuy nhiên, độ chính xác khi hiển thị có thể hơi khác so với PowerPoint, đặc biệt khi sử dụng phông chữ tùy chỉnh hoặc thiếu.

**Có bất kỳ giới hạn nào về số slide có thể xử lý không?**

Aspose.Slides tự nó không đặt ra bất kỳ giới hạn nghiêm ngặt nào về số slide bạn có thể xử lý. Tuy nhiên, bạn có thể gặp lỗi hết bộ nhớ khi làm việc với các bài thuyết trình lớn hoặc hình ảnh độ phân giải cao.
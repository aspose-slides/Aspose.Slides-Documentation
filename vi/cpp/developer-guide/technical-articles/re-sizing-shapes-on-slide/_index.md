---
title: Thay đổi kích thước các hình dạng trên slide trình chiếu
type: docs
weight: 100
url: /vi/cpp/re-sizing-shapes-on-slide/
keywords:
- thay đổi kích thước hình dạng
- thay đổi kích thước hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Dễ dàng thay đổi kích thước các hình dạng trên slide PowerPoint và OpenDocument bằng Aspose.Slides cho C++—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Tổng quan**

Một trong những câu hỏi phổ biến nhất của khách hàng sử dụng Aspose.Slides for C++ là cách thay đổi kích thước các hình dạng sao cho khi kích thước slide thay đổi, dữ liệu không bị cắt bỏ. Bài viết kỹ thuật ngắn này hướng dẫn cách thực hiện.

## **Thay đổi kích thước Hình dạng**

Để ngăn các hình dạng bị lệch khi kích thước slide thay đổi, hãy cập nhật vị trí và kích thước của từng hình dạng sao cho chúng phù hợp với bố cục slide mới.

```cpp
// Tải tệp trình chiếu.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Lấy kích thước slide gốc.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Thay đổi kích thước slide mà không tỉ lệ các hình dạng hiện có.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Lấy kích thước slide mới.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Điều chỉnh kích thước hình dạng.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Điều chỉnh vị trí hình dạng.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
Nếu một slide chứa bảng, đoạn mã trên sẽ không hoạt động đúng. Trong trường hợp này, mỗi ô trong bảng phải được thay đổi kích thước.
{{% /alert %}} 

Sử dụng đoạn mã sau đây để thay đổi kích thước các slide có chứa bảng. Đối với bảng, việc đặt chiều rộng hoặc chiều cao là một trường hợp đặc biệt: bạn phải điều chỉnh chiều cao của từng hàng và chiều rộng của từng cột để thay đổi kích thước tổng thể của bảng.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Lấy kích thước slide gốc.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Thay đổi kích thước slide mà không tỉ lệ các hình dạng hiện có.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Lấy kích thước slide mới.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Điều chỉnh kích thước hình dạng.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Điều chỉnh vị trí hình dạng.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Điều chỉnh kích thước hình dạng.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Điều chỉnh vị trí hình dạng.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Điều chỉnh kích thước hình dạng.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Điều chỉnh vị trí hình dạng.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Tại sao các hình dạng bị méo hoặc bị cắt bỏ sau khi thay đổi kích thước slide?**

Khi thay đổi kích thước slide, các hình dạng giữ nguyên vị trí và kích thước ban đầu trừ khi tỉ lệ được thay đổi một cách rõ ràng. Điều này có thể dẫn đến việc nội dung bị cắt bỏ hoặc các hình dạng bị lệch.

**Mã được cung cấp có hoạt động với mọi loại hình dạng không?**

Ví dụ cơ bản hoạt động với hầu hết các loại hình dạng (hộp văn bản, hình ảnh, biểu đồ, v.v.). Tuy nhiên, đối với bảng, bạn cần xử lý riêng từng hàng và cột, vì chiều cao và chiều rộng của bảng được xác định bởi kích thước của các ô riêng lẻ.

**Làm thế nào để thay đổi kích thước bảng khi thay đổi kích thước slide?**

Bạn cần duyệt qua tất cả các hàng và cột của bảng và thay đổi chiều cao và chiều rộng của chúng một cách tỷ lệ, như được minh họa trong ví dụ mã thứ hai.

**Việc thay đổi kích thước này có hoạt động cho các slide master và slide layout không?**

Có, nhưng bạn cũng nên duyệt qua [Masters](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_masters/) và [Layout slides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_layoutslides/) và áp dụng cùng một logic tỉ lệ cho các hình dạng của chúng để đảm bảo sự nhất quán trong toàn bộ bản trình bày.

**Tôi có thể thay đổi hướng của slide (dọc/ngang) cùng với việc thay đổi kích thước không?**

Có. Bạn có thể sử dụng [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidesize/set_orientation/) để thay đổi hướng. Hãy chắc chắn rằng bạn thiết lập logic tỉ lệ cho phù hợp để giữ nguyên bố cục.

**Có giới hạn nào cho kích thước slide mà tôi có thể đặt không?**

Aspose.Slides hỗ trợ kích thước tùy chỉnh, nhưng kích thước quá lớn có thể ảnh hưởng đến hiệu suất hoặc khả năng tương thích với một số phiên bản PowerPoint.

**Làm sao để ngăn các hình dạng có tỷ lệ khung cố định bị méo?**

Bạn có thể kiểm tra phương thức `get_AspectRatioLocked` của hình dạng trước khi thực hiện tỉ lệ. Nếu nó bị khóa, hãy điều chỉnh chiều rộng hoặc chiều cao một cách tỷ lệ thay vì tỉ lệ riêng lẻ.
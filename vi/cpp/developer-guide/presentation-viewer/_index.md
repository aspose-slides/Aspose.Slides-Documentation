---
title: Tạo Trình xem Trình chiếu bằng C++
linktitle: Trình xem Trình chiếu
type: docs
weight: 50
url: /vi/cpp/presentation-viewer/
keywords:
- xem trình chiếu
- trình xem trình chiếu
- tạo trình xem trình chiếu
- xem PPT
- xem PPTX
- xem ODP
- PowerPoint
- OpenDocument
- trình chiếu
- C++
- Aspose.Slides
description: "Tạo một trình xem trình chiếu tùy chỉnh bằng C++ sử dụng Aspose.Slides. Dễ dàng hiển thị các tệp PowerPoint và OpenDocument mà không cần Microsoft PowerPoint."
---
## **Giới thiệu**

Aspose.Slides for C++ được sử dụng để tạo các tệp trình chiếu với các slide. Các slide này có thể được xem bằng cách mở trình chiếu trong Microsoft PowerPoint, ví dụ. Tuy nhiên, đôi khi các nhà phát triển cần xem slide dưới dạng hình ảnh trong trình xem ảnh ưa thích hoặc tạo trình xem trình chiếu riêng. Trong những trường hợp này, Aspose.Slides cho phép xuất một slide riêng lẻ dưới dạng hình ảnh. Bài viết này mô tả cách thực hiện.

## **Tạo hình ảnh SVG từ một Slide**

Để tạo hình ảnh SVG từ một slide trong trình chiếu bằng Aspose.Slides, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Lấy tham chiếu slide theo chỉ mục của nó.
1. Mở một luồng tệp.
1. Lưu slide dưới dạng hình ảnh SVG vào luồng tệp.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **Tạo SVG với ID Hình dạng tùy chỉnh**

Aspose.Slides có thể được sử dụng để tạo một [SVG](https://docs.fileformat.com/page-description-language/svg/) từ một slide với ID hình dạng tùy chỉnh. Để thực hiện, sử dụng phương thức `set_Id` từ [ISvgShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/isvgshape/). `CustomSvgShapeFormattingController` có thể được dùng để đặt ID hình dạng.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **Tạo hình ảnh Thu nhỏ (Thumbnail) cho Slide**

Aspose.Slides giúp bạn tạo hình ảnh thu nhỏ của các slide. Để tạo thu nhỏ của một slide bằng Aspose.Slides, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Lấy tham chiếu slide theo chỉ mục của nó.
1. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với tỷ lệ định sẵn.
1. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Tạo Thu nhỏ Slide với Kích thước Được Người dùng Định nghĩa**

Để tạo hình ảnh thu nhỏ cho slide với kích thước do người dùng định nghĩa, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Lấy tham chiếu slide theo chỉ mục của nó.
1. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với kích thước đã định.
1. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Tạo Thu nhỏ Slide kèm Ghi chú Người thuyết trình**

Để tạo thu nhỏ của một slide có ghi chú người thuyết trình bằng Aspose.Slides, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [RenderingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/renderingoptions/) .
1. Sử dụng phương thức `RenderingOptions.set_SlidesLayoutOptions` để đặt vị trí của ghi chú người thuyết trình.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Lấy tham chiếu slide theo chỉ mục của nó.
1. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với các tùy chọn render.
1. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Ví dụ Trực tiếp**

Bạn có thể dùng ứng dụng miễn phí [**Aspose.Slides Viewer**](https://products.aspose.app/slides/vi/viewer/) để trải nghiệm các tính năng bạn có thể triển khai với API Aspose.Slides:

![Trình xem PowerPoint trực tuyến](online-PowerPoint-viewer.png)

## **Câu hỏi Thường gặp**

**Tôi có thể nhúng trình xem trình chiếu vào một ứng dụng web không?**

Có. Bạn có thể sử dụng Aspose.Slides ở phía máy chủ để render slide thành hình ảnh hoặc HTML và hiển thị chúng trong trình duyệt. Các tính năng điều hướng và thu phóng có thể được triển khai bằng JavaScript để có trải nghiệm tương tác.

**Cách tốt nhất để hiển thị slide trong một trình xem tùy chỉnh là gì?**

Cách được khuyến nghị là render mỗi slide thành một hình ảnh (ví dụ: PNG hoặc SVG) hoặc chuyển đổi sang HTML bằng Aspose.Slides, sau đó hiển thị kết quả trong một hộp ảnh (đối với desktop) hoặc một container HTML (đối với web).

**Làm sao để xử lý các trình chiếu lớn có nhiều slide?**

Đối với các bộ slide lớn, xem xét việc tải lười (lazy-loading) hoặc render slide theo yêu cầu. Điều này có nghĩa là chỉ tạo nội dung của slide khi người dùng chuyển đến slide đó, giúp giảm bộ nhớ và thời gian tải.
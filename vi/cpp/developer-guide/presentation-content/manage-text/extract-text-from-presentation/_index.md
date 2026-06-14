---
title: Trích xuất Văn bản Nâng cao từ Bản trình chiếu trong C++
linktitle: Trích xuất Văn bản
type: docs
weight: 90
url: /vi/cpp/extract-text-from-presentation/
keywords:
- trích xuất văn bản
- trích xuất văn bản từ slide
- trích xuất văn bản từ bản trình chiếu
- trích xuất văn bản từ PowerPoint
- trích xuất văn bản từ OpenDocument
- trích xuất văn bản từ PPT
- trích xuất văn bản từ PPTX
- trích xuất văn bản từ ODP
- lấy văn bản
- lấy văn bản từ slide
- lấy văn bản từ bản trình chiếu
- lấy văn bản từ PowerPoint
- lấy văn bản từ OpenDocument
- lấy văn bản từ PPT
- lấy văn bản từ PPTX
- lấy văn bản từ ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Nhanh chóng trích xuất văn bản từ các bản trình chiếu PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho C++. Hãy làm theo hướng dẫn đơn giản, từng bước của chúng tôi để tiết kiệm thời gian."
---
## **Tổng quan**

Trích xuất văn bản từ các bản trình chiếu là một nhiệm vụ phổ biến nhưng quan trọng đối với các nhà phát triển làm việc với nội dung slide. Dù bạn đang xử lý các tệp Microsoft PowerPoint ở định dạng PPT hoặc PPTX, hay các bản trình chiếu OpenDocument (ODP), việc truy cập và lấy dữ liệu văn bản có thể là yếu tố then chốt cho việc phân tích, tự động hóa, lập chỉ mục hoặc di chuyển nội dung.

Bài viết này cung cấp hướng dẫn toàn diện về cách hiệu quả trích xuất văn bản từ các định dạng bản trình chiếu khác nhau, bao gồm PPT, PPTX và ODP, bằng cách sử dụng Aspose.Slides for C++. Bạn sẽ học cách duyệt qua các thành phần của bản trình chiếu một cách có hệ thống để lấy đúng nội dung văn bản cần thiết.

## **Trích xuất văn bản từ một slide**

Aspose.Slides for C++ cung cấp không gian tên [Aspose.Slides.Util](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/) chứa lớp [SlideUtil](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/). Lớp này công bố một số phương thức tĩnh nạp chồng để trích xuất toàn bộ văn bản từ một bản trình chiếu hoặc một slide. Để trích xuất văn bản từ một slide trong bản trình chiếu, sử dụng phương thức [GetAllTextBoxes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/getalltextboxes/). Phương thức này nhận một đối tượng kiểu [IBaseSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseslide/) làm tham số. Khi được thực thi, phương thức sẽ quét toàn bộ slide để tìm văn bản và trả về một mảng các đối tượng kiểu [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/), giữ nguyên mọi định dạng văn bản.

Đoạn mã sau trích xuất toàn bộ văn bản từ slide đầu tiên của bản trình chiếu:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Trích xuất văn bản từ một bản trình chiếu**

Để quét văn bản từ toàn bộ bản trình chiếu, sử dụng phương thức tĩnh [GetAllTextFrames](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/getalltextframes/) được khai báo trong lớp [SlideUtil](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/). Phương thức này nhận hai tham số:

1. Đầu tiên, một đối tượng [IPresentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/) đại diện cho bản trình chiếu PowerPoint hoặc OpenDocument mà từ đó văn bản sẽ được trích xuất.
2. Thứ hai, một giá trị `Boolean` cho biết có nên bao gồm các slide master khi quét văn bản từ bản trình chiếu hay không.

Phương thức trả về một mảng các đối tượng kiểu [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/), bao gồm thông tin định dạng văn bản. Đoạn mã dưới đây quét văn bản và chi tiết định dạng từ một bản trình chiếu, bao gồm cả các slide master.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Trích xuất văn bản có phân loại và nhanh chóng**

Lớp [PresentationFactory](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentationfactory/) cũng cung cấp các phương thức để trích xuất toàn bộ văn bản từ các bản trình chiếu:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

Tham số enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textextractionarrangingmode/) chỉ ra chế độ sắp xếp kết quả trích xuất văn bản và có thể được đặt thành các giá trị sau:
- `Unarranged` - Văn bản thô mà không quan tâm đến vị trí của nó trên slide.
- `Arranged` - Văn bản được sắp xếp theo cùng thứ tự như trên slide.

Chế độ không sắp xếp (`Unarranged`) có thể được sử dụng khi tốc độ là yếu tố quan trọng; nó nhanh hơn so với chế độ sắp xếp (`Arranged`).

[IPresentationText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentationtext/) đại diện cho văn bản thô được trích xuất từ bản trình chiếu. Phương thức `get_SlidesText()` của nó trả về một mảng các đối tượng kiểu [ISlideText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidetext/). Mỗi đối tượng đại diện cho văn bản trên slide tương ứng. Đối tượng kiểu [ISlideText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidetext/) có các phương thức sau:

- `get_Text()` - Văn bản trong các hình dạng của slide.
- `get_MasterText()` - Văn bản trong các hình dạng của slide master liên quan đến slide này.
- `get_LayoutText()` - Văn bản trong các hình dạng của slide layout liên quan đến slide này.
- `get_NotesText()` - Văn bản trong các hình dạng của slide ghi chú liên quan đến slide này.
- `get_CommentsText()` - Văn bản trong các nhận xét liên quan đến slide này.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**Aspose.Slides xử lý các bản trình chiếu lớn trong quá trình trích xuất văn bản nhanh như thế nào?**

Aspose.Slides được tối ưu cho hiệu năng cao và có thể xử lý ngay cả [các bản trình chiếu lớn](/slides/vi/cpp/open-presentation/), phù hợp cho các kịch bản xử lý thời gian thực hoặc hàng loạt.

**Aspose.Slides có thể trích xuất văn bản từ bảng và biểu đồ trong bản trình chiếu không?**

Có. Aspose.Slides có thể trích xuất văn bản từ nhiều yếu tố slide, bao gồm bảng và các đối tượng liên quan đến biểu đồ, cho phép bạn truy cập và phân tích nội dung văn bản trong các cấu trúc trình chiếu phổ biến.

**Tôi có cần giấy phép đặc biệt của Aspose.Slides để trích xuất văn bản từ bản trình chiếu không?**

Bạn có thể trích xuất văn bản bằng phiên bản dùng thử miễn phí của Aspose.Slides, mặc dù nó sẽ có [một số hạn chế](/slides/vi/cpp/licensing/), chẳng hạn như chỉ xử lý được số lượng slide giới hạn. Đối với việc sử dụng không giới hạn và để xử lý các bản trình chiếu lớn hơn, việc mua giấy phép đầy đủ được khuyến nghị.
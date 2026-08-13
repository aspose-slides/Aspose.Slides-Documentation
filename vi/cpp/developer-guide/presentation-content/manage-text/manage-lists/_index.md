---
title: "Quản lý danh sách có dấu đầu dòng và đánh số trong bản trình bày bằng C++"
linktitle: "Quản lý danh sách"
type: docs
weight: 70
url: /vi/cpp/manage-lists/
keywords:
- "dấu đầu dòng"
- "danh sách có dấu đầu dòng"
- "danh sách đánh số"
- "dấu đầu dòng ký hiệu"
- "dấu đầu dòng hình ảnh"
- "dấu đầu dòng tùy chỉnh"
- "danh sách đa cấp"
- "tạo dấu đầu dòng"
- "thêm dấu đầu dòng"
- "thêm danh sách"
- "PowerPoint"
- "OpenDocument"
- "bản trình bày"
- "C++"
- "Aspose.Slides"
description: "Tìm hiểu cách tạo và định dạng các danh sách có dấu đầu dòng, hình ảnh, đa cấp và đánh số trong bản trình bày PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho C++."
---
## **Overview**

Aspose.Slides cho C++ cho phép bạn tạo và định dạng các danh sách có dấu đầu dòng và đánh số trong các bản trình bày PowerPoint và OpenDocument. Một mục danh sách là một đoạn văn mà các cài đặt dấu đầu dòng được kiểm soát thông qua định dạng đoạn văn của nó.

Sử dụng phương thức [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/get_paragraphformat/) để truy cập các cài đặt danh sách ở mức đoạn văn. Điểm vào chính là [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/get_bullet/), nó trả về một đối tượng [IBulletFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/). Với đối tượng này, bạn có thể đặt kiểu dấu đầu dòng, ký hiệu, hình ảnh, màu, kích thước, kiểu đánh số và số bắt đầu.

Bài viết này hướng dẫn cách:

- tạo danh sách có dấu đầu dòng bằng ký hiệu tùy chỉnh
- tạo dấu đầu dòng hình ảnh
- tạo danh sách đa cấp bằng cách đặt độ sâu đoạn văn
- tạo danh sách đánh số
- kiểm tra và thay đổi định dạng danh sách trong một bản trình bày hiện có

## **Tạo danh sách có dấu đầu dòng**

Để tạo danh sách có dấu đầu dòng, thêm các đối tượng [Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraph/) vào một [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) và đặt [IBulletFormat::set_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_type/) thành [BulletType::Symbol](https://reference.aspose.com/slides/vi/cpp/aspose.slides/bullettype/). Sau đó bạn có thể đặt [IBulletFormat::set_Char](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/get_color/) và [IBulletFormat::set_Height](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_height/) để kiểm soát ngoại hình của dấu đầu dòng.

Mã C++ sau đây minh họa cách tạo danh sách có dấu đầu dòng trong một slide:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các dấu đầu dòng biểu tượng](symbol_bullets.png)

## **Tạo danh sách đánh số**

Sử dụng danh sách đánh số khi thứ tự các mục quan trọng. Đặt [IBulletFormat::set_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_type/) thành [BulletType::Numbered](https://reference.aspose.com/slides/vi/cpp/aspose.slides/bullettype/). Bạn cũng có thể chọn định dạng đánh số bằng [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) hoặc đặt [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) khi danh sách cần bắt đầu từ một giá trị khác 1.

Mã C++ sau đây cho thấy cách tạo danh sách đánh số trong một slide:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các dấu đầu dòng đã đánh số](numbered_bullets.png)

## **Tạo dấu đầu dòng hình ảnh**

Aspose.Slides cho phép bạn thay thế ký hiệu dấu đầu dòng thông thường bằng một hình ảnh. Dấu đầu dòng hình ảnh hoạt động tốt nhất với các hình ảnh đơn giản vẫn còn đọc được ở kích thước nhỏ, chẳng hạn như biểu tượng hoặc tệp PNG trong suốt nhỏ.

{{% alert color="info" %}}
Lý tưởng, nếu bạn dự định thay thế ký hiệu dấu đầu dòng thông thường bằng một hình ảnh, tốt nhất là chọn một đồ họa đơn giản với nền trong suốt. Những hình ảnh như vậy hoạt động hiệu quả như các ký hiệu dấu đầu dòng tùy chỉnh.
{{% /alert %}}

Để tạo dấu đầu dòng hình ảnh, thêm một hình ảnh vào [IPresentation::get_Images](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_images/) và gán đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) trả về cho [IBulletFormat::get_Picture](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/get_picture/). Đặt [IBulletFormat::set_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_type/) thành [BulletType::Picture](https://reference.aspose.com/slides/vi/cpp/aspose.slides/bullettype/) trước khi gán hình ảnh.

Giả sử chúng ta có một "image.png":

![Hình ảnh cho các dấu đầu dòng](picture_for_bullets.png)

Mã C++ sau đây cho thấy cách tạo dấu đầu dòng hình ảnh trong một slide:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các dấu đầu dòng hình ảnh](picture_bullets.png)

## **Tạo danh sách đa cấp**

Sử dụng [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_depth/) để đặt các mục danh sách ở các cấp độ khác nhau. Cấp độ 0 là cấp cao nhất, cấp độ 1 là cấp con bên dưới, và cứ tiếp tục như vậy.

Mã C++ sau đây cho thấy cách tạo danh sách có dấu đầu dòng đa cấp:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Danh sách đa cấp](multilevel_list.png)

## **Thay đổi danh sách hiện có**

Để thay đổi định dạng danh sách trong một bản trình bày hiện có, truy cập đoạn văn mục tiêu và cập nhật các cài đặt [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/get_bullet/) của nó. Các thuộc tính giống như khi tạo danh sách có thể được sử dụng để kiểm tra hoặc sửa đổi các danh sách đã được tải từ tệp PPT, PPTX hoặc ODP.

Mã C++ sau đây thay đổi đoạn văn đầu tiên trong một khung văn bản để sử dụng kiểu danh sách đánh số:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

### Có thể xuất danh sách có dấu đầu dòng và đánh số ra PDF hoặc hình ảnh không?

Có. Aspose.Slides giữ nguyên định dạng danh sách khi định dạng đích hỗ trợ bố cục văn bản và tính năng dấu đầu dòng tương ứng.

### Tôi có thể chỉnh sửa danh sách trong các bản trình bày hiện có không?

Có. Tải bản trình bày, truy cập đoạn văn mục tiêu, kiểm tra hoặc cập nhật các cài đặt [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/get_bullet/) của nó và lưu lại bản trình bày.

### Danh sách có thể chứa văn bản không phải Latin không?

Có. Văn bản các mục danh sách có thể chứa ký tự Unicode, vì vậy bạn có thể tạo danh sách trong các bản trình bày đa ngôn ngữ. Đảm bảo các phông chữ được sử dụng trong bản trình bày hỗ trợ các ký tự bạn cần.
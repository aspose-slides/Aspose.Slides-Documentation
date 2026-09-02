---
title: Quản lý các đoạn văn bản PowerPoint trong C++
linktitle: Quản lý Đoạn Văn
type: docs
weight: 40
url: /vi/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- thêm văn bản
- thêm đoạn văn
- quản lý văn bản
- quản lý đoạn văn
- quản lý gạch đầu
- thụt lề đoạn
- thụt lề treo
- gạch đầu đoạn
- danh sách đánh số
- danh sách gạch đầu
- thuộc tính đoạn văn
- nhập HTML
- văn bản sang HTML
- đoạn văn sang HTML
- đoạn văn sang hình ảnh
- văn bản sang hình ảnh
- xuất đoạn văn
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng đoạn, phần, gạch đầu, danh sách đánh số, thụt lề, nội dung HTML và hình ảnh đoạn với Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides for C++ đại diện cho văn bản dưới dạng một hệ thống cấp bậc của các khung văn bản, đoạn văn và phần:

* [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) đại diện cho container văn bản trong một shape và cung cấp quyền truy cập vào bộ sưu tập đoạn văn của nó.
* [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/) đại diện cho một đoạn văn trong một khung văn bản và cung cấp quyền truy cập vào các phần và định dạng cấp độ đoạn.
* [IPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/) đại diện cho một đoạn chạy văn bản trong một đoạn. Mỗi phần có thể có văn bản và định dạng ký tự riêng.

Do đó một đoạn có thể chứa văn bản với các phông chữ, màu sắc, kích thước và các định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn Văn**

### **Tạo Đoạn Văn với Nhiều Phần**

Các bước sau tạo một khung văn bản với ba đoạn, mỗi đoạn chứa ba phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập tham chiếu slide liên quan thông qua chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) hình chữ nhật vào slide.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của shape.
5. Sử dụng đoạn mặc định và thêm hai đối tượng [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/) nữa vào khung văn bản.
6. Thêm đủ đối tượng [IPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/) cho mỗi đoạn để chứa ba phần. Đoạn mặc định đã chứa một phần rỗng.
7. Đặt văn bản cho mỗi phần.
8. Áp dụng định dạng cấp ký tự thông qua [IPortion::get_PortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/get_portionformat/).
9. Lưu bản trình bày đã chỉnh sửa.

Ví dụ C++ sau triển khai các bước:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tạo Danh Sách Gạch Đầu và Đánh Số**

### **Tạo Danh Sách Gạch Đầu hoặc Đánh Số**

Gạch đầu và đánh số giúp người đọc nhanh chóng quét các mục liên quan. Trong Aspose.Slides, cài đặt danh sách được xác định thông qua [IBulletFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/).

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập tham chiếu slide liên quan thông qua chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide đã chọn.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của shape.
5. Xóa đoạn mặc định khỏi khung văn bản.
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraph/) cho một gạch đầu ký hiệu.
7. Đặt [IBulletFormat::set_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_type/) thành [BulletType::Symbol](https://reference.aspose.com/slides/vi/cpp/aspose.slides/bullettype/) và chỉ định ký tự gạch đầu.
8. Đặt văn bản đoạn, thụt lề, màu gạch đầu và chiều cao gạch đầu.
9. Thêm đoạn vào khung văn bản.
10. Tạo một đoạn thứ hai và đặt [IBulletFormat::set_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_type/) thành [BulletType::Numbered](https://reference.aspose.com/slides/vi/cpp/aspose.slides/bullettype/).
11. Cấu hình kiểu gạch đầu đánh số và thêm đoạn vào khung văn bản.
12. Lưu bản trình bày.

Ví dụ C++ sau tạo một gạch đầu ký hiệu và một gạch đầu đánh số:

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Sử Dụng Gạch Đầu Hình Ảnh**

Gạch đầu hình ảnh cho phép bạn sử dụng một hình tùy chỉnh thay vì ký hiệu hoặc số.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập tham chiếu slide liên quan thông qua chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) và truy cập [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của nó.
4. Xóa đoạn mặc định khỏi khung văn bản.
5. Tải hình ảnh gạch đầu và thêm nó vào bộ sưu tập hình ảnh của bản trình bày dưới dạng một [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/).
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraph/) và đặt văn bản cho nó.
7. Đặt [IBulletFormat::set_Type](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_type/) thành [BulletType::Picture](https://reference.aspose.com/slides/vi/cpp/aspose.slides/bullettype/).
8. Gán hình ảnh thông qua [ISlidesPicture::set_Image](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidespicture/set_image/) và đặt chiều cao gạch đầu.
9. Thêm đoạn vào khung văn bản.
10. Lưu bản trình bày đã chỉnh sửa.

Ví dụ C++ sau tạo một gạch đầu hình ảnh:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **Tạo Danh Sách Đa Cấp**

Đặt [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_depth/) để đặt các đoạn ở các cấp độ khác nhau của danh sách. Cấp cao nhất có độ sâu `0`.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) và xóa đoạn mặc định khỏi khung văn bản của nó.
3. Tạo bốn đoạn và cấu hình các ký hiệu gạch đầu cho chúng.
4. Đặt giá trị [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_depth/) thành `0`, `1`, `2` và `3`.
5. Thêm các đoạn vào khung văn bản và lưu bản trình bày.

Ví dụ C++ sau tạo một danh sách gạch đầu bốn cấp:

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Bắt Đầu Các Mục Đánh Số Với Giá Trị Tùy Chỉnh**

Sử dụng [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) để đặt số khởi đầu hiển thị cho một đoạn đánh số.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào một slide.
2. Xóa đoạn mặc định khỏi khung văn bản của shape.
3. Tạo ba đoạn đánh số.
4. Đặt [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) thành `2`, `3` và `7` cho các đoạn tương ứng.
5. Thêm các đoạn vào khung văn bản và lưu bản trình bày.

Ví dụ C++ sau gán số bắt đầu tùy chỉnh cho mỗi đoạn:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kiểm Soát Bố Cục Đoạn Văn và Thuộc Tính Kết Thúc**

### **Đặt Thụt Lề Dòng Đầu**

Sử dụng [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/) để điều khiển thụt lề dòng đầu của một đoạn. Phương thức này chỉ di chuyển dòng đầu so với lề trái của đoạn. Giá trị dương đẩy dòng đầu sang phải, trong khi các dòng còn lại vẫn căn chỉnh với thân đoạn.

Sử dụng [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_marginleft/) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/) khi bạn chỉ cần di chuyển dòng đầu.

Ví dụ dưới tạo một số đoạn và áp dụng các giá trị khác nhau của [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/) để minh họa cách thụt lề dòng đầu ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập slide đích.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) hình chữ nhật vào slide.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của shape và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/) khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình bày đã chỉnh sửa.

Đoạn mã này cho bạn thấy cách đặt thụt lề cho một đoạn:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Thụt lề dòng đầu của các đoạn](first_line_indent.png)

### **Đặt Thụt Lề Treo**

Thụt lề treo là bố cục đoạn trong đó dòng đầu bắt đầu ở phía trái của các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/). Đặt thụt lề thành giá trị âm để di chuyển dòng đầu sang trái so với thân đoạn.

Thực tế, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_marginleft/) xác định vị trí trái của thân đoạn, và [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/) xác định vị trí của dòng đầu so với lề đó. Để tạo thụt lề treo, đặt giá trị margin-left dương và giá trị indent âm.

Định dạng này hữu ích cho thư mục, tài liệu tham khảo, mục từ điển và các đoạn khác mà các dòng gập phải căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập slide đích.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) hình chữ nhật vào slide.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của shape và xóa đoạn mặc định.
5. Tạo các đoạn và đặt một giá trị [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_marginleft/) dương cho mỗi đoạn.
6. Đặt một giá trị [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/) âm để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình bày đã chỉnh sửa.

Đoạn mã này cho bạn thấy cách đặt thụt lề treo cho một đoạn:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Thụt lề treo của các đoạn](hanging_indent.png)

### **Đặt Thuộc Tính Kết Thúc Đoạn Văn**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) kiểm soát định dạng của ký hiệu kết thúc đoạn. Ví dụ sau gán kích thước phông chữ và phông Latin cho ký hiệu kết thúc của đoạn thứ hai:

1. Tải một [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) và xóa đoạn mặc định của nó.
3. Tạo hai đoạn và thêm các phần văn bản vào chúng.
4. Tạo một [PortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/portionformat/) cho ký hiệu kết thúc của đoạn thứ hai.
5. Đặt [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_fontheight/) và [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_latinfont/).
6. Gán định dạng bằng [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) và lưu bản trình bày.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nhập và Xuất Nội Dung Đoạn Văn**

### **Nhập Văn Bản HTML Vào Các Đoạn Văn**

Sử dụng [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphcollection/addfromhtml/) để chuyển đổi mã HTML thành các đoạn và phần trong một khung văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập một slide và thêm một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/).
3. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của shape và xóa đoạn mặc định.
4. Đọc tệp HTML nguồn.
5. Gửi chuỗi HTML tới [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
6. Lưu bản trình bày đã chỉnh sửa.

Ví dụ C++ sau nhập HTML vào một khung văn bản:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Xuất Văn Bản Đoạn Sang HTML**

Sử dụng [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphcollection/exporttohtml/) để xuất một phạm vi đoạn đã chọn thành HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và tải bản trình bày mong muốn.
2. Truy cập slide và tìm [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) chứa văn bản.
3. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của shape.
4. Gọi [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphcollection/exporttohtml/) với chỉ mục đoạn bắt đầu và số lượng đoạn cần xuất.
5. Ghi chuỗi HTML trả về vào tệp.

Ví dụ C++ sau xuất tất cả các đoạn từ shape văn bản đầu tiên:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **Kết Xuất Đoạn Thành Hình Ảnh**

[IParagraph::GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/getimage/) kết xuất trực tiếp một đoạn duy nhất và trả về một [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/). Lưu kết quả thành tệp hoặc luồng bằng [IImage::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/save/). Bạn không cần phải kết xuất shape chứa hoặc cắt ảnh bitmap thủ công.

[IParagraph::GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/getimage/) có thể trả về `nullptr` nếu đoạn không tồn tại trong bộ sưu tập cha, không có giới hạn kết xuất hợp lệ, hoặc không thể được kết xuất. Kiểm tra kết quả trước khi lưu và giải phóng ảnh trả về sau khi sử dụng.

#### **Kết Xuất Đoạn Với Tỷ Lệ Mặc Định**

Giả sử chúng ta có một tệp trình chiếu có tên sample.pptx với một slide, trong đó shape đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản có ba đoạn](paragraph_to_image_input.png)

Ví dụ dưới kết xuất đoạn thứ hai trong một shape văn bản thường tại tỷ lệ mặc định và lưu ảnh trả về dưới định dạng PNG.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

Kết quả:

![Hình ảnh đoạn văn](paragraph_to_image_output.png)

#### **Kết Xuất Đoản Trong Ô Bảng Với Tỷ Lệ Mở Rộng**

Sử dụng phương thức [IParagraph::GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/getimage/) có tham số `float scaleX` và `float scaleY` để đặt hệ số tỷ lệ chiều ngang và chiều dọc. Ví dụ sau tạo một bảng, kết xuất đoạn trong ô đầu tiên với độ rộng và chiều cao gấp đôi mặc định, và lưu kết quả dưới dạng PNG.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

Hệ số `1` giữ trục tương ứng ở kích thước pixel mặc định. Ví dụ, `2` cho cả hai hệ số tạo ra một ảnh có chiều rộng và chiều cao khoảng gấp đôi kích thước mặc định, dẫn tới bốn lần số pixel. Các hệ số lớn hơn thường tạo ra văn bản sắc nét hơn cho việc phóng to hoặc xuất độ phân giải cao, nhưng chúng cũng làm tăng bộ nhớ và kích thước tệp. Các hệ số dưới `1` tạo ra ảnh nhỏ hơn với ít chi tiết hơn. Sử dụng các hệ số bằng nhau để giữ tỷ lệ khung hình của đoạn; các hệ số ngang và vertic​al khác nhau sẽ kéo dài đầu ra một cách độc lập.

Kết xuất toàn bộ shape bằng [IShape::GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/getimage/) vẫn hữu ích khi đầu ra cần bao gồm nền, viền hoặc ngữ cảnh hình ảnh khác của shape. Đối với ảnh chỉ chứa đoạn, hãy sử dụng [IParagraph::GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/getimage/).

## **Câu hỏi thường gặp**

**Có thể tắt hoàn toàn việc ngắt dòng trong khung văn bản không?**

Có. Sử dụng [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/set_wraptext/) để tắt việc ngắt dòng, vì vậy các dòng sẽ không bị cắt ở các cạnh của khung văn bản.

**Làm sao để lấy kích thước chính xác trên slide của một đoạn cụ thể?**

Sử dụng [IParagraph::GetRect](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/getrect/) để lấy hình chữ nhật bao quanh đoạn. [IPortion::GetRect](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/getrect/) cung cấp kích thước của một phần riêng lẻ.

**Định dạng căn chỉnh đoạn (trái, phải, giữa hoặc canh đều) được kiểm soát ở đâu?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_alignment/) là cài đặt cấp đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng riêng của các phần.

**Có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn không?**

Có. Sử dụng [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_languageid/) cho các phần riêng lẻ, vì vậy một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.
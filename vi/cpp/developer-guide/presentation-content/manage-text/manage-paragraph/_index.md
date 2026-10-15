---
title: Quản lý Đoạn văn PowerPoint trong C++
linktitle: Quản lý Đoạn
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
  - quản lý dấu đầu dòng
  - thụt lề đoạn
  - thụt lề treo
  - dấu đầu dòng đoạn
  - danh sách đánh số
  - danh sách dấu đầu dòng
  - thuộc tính đoạn văn
  - nhập HTML
  - văn bản sang HTML
  - đoạn văn sang HTML
  - đoạn văn sang hình ảnh
  - văn bản sang hình ảnh
  - xuất đoạn văn
  - PowerPoint
  - bản trình chiếu
  - C++
  - Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng các đoạn văn, phần, dấu đầu dòng, danh sách đánh số, thụt lề, nội dung HTML và hình ảnh đoạn với Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides for C++ biểu diễn văn bản dưới dạng một phân cấp của khung văn bản, đoạn văn và phần:

* [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) đại diện cho vùng chứa văn bản trong một hình dạng và cung cấp quyền truy cập vào bộ sưu tập các đoạn văn của nó.
* [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) đại diện cho một đoạn văn trong khung văn bản và cung cấp quyền truy cập vào các phần và định dạng ở mức đoạn.
* [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) đại diện cho một đoạn chạy văn bản trong một đoạn văn. Mỗi phần có thể có văn bản và định dạng ký tự riêng.

Do đó, một đoạn văn có thể chứa văn bản với các phông chữ, màu sắc, kích thước và các định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn văn**

Tạo các đoạn văn trong khung văn bản của một hình dạng và sử dụng các phần để định dạng các đoạn chạy văn bản riêng lẻ. Phần này cho thấy cách kết hợp nhiều phần trong mỗi đoạn và áp dụng các màu, kích thước phông và kiểu khác nhau.

### **Tạo Đoạn văn với Nhiều Phần**

Ví dụ C++ sau tạo ba đoạn, mỗi đoạn chứa ba đoạn chạy văn bản trong bộ sưu tập [IParagraph::get_Portions](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_portions/) của nó. Nó tái sử dụng đoạn mặc định và phần rỗng, sau đó thêm các đoạn và phần còn lại. Định dạng được áp dụng qua [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/): phần đầu tiên trong mỗi đoạn có màu đỏ, in đậm và kích thước 15 điểm; phần thứ hai có màu xanh dương, in nghiêng và kích thước 18 điểm. Phần thứ ba giữ nguyên định dạng mặc định:

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
for (auto paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (auto portionIndex = 0; portionIndex < portionCount; portionIndex++)
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

## **Tạo Danh sách Đánh dấu và Đánh số**

Sắp xếp văn bản của đoạn thành các danh sách với ký hiệu, số hoặc hình ảnh tùy chỉnh. Các ví dụ trong phần này bao gồm định dạng dấu đầu dòng, danh sách đa cấp và các số bắt đầu tùy chỉnh.

### **Tạo Danh sách Đánh dấu hoặc Đánh số**

Dấu đầu dòng và đánh số giúp các mục liên quan dễ quét hơn. Trong Aspose.Slides, cài đặt danh sách được xác định thông qua [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/).

Ví dụ C++ này thêm một dấu đầu dòng ký hiệu và một mục đánh số vào cùng một khung văn bản. [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) chọn loại dấu đầu dòng, trong khi [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) cung cấp ký hiệu và [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) chọn kiểu đánh số. Cả hai mục đều sử dụng dấu đầu dòng màu đen với chiều cao bằng 100% và thụt lề đoạn là 25 điểm:

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

### **Sử dụng Đánh dấu Hình ảnh**

Đánh dấu hình ảnh cho phép bạn sử dụng một hình ảnh tùy chỉnh thay vì ký hiệu hoặc số.

Ví dụ yêu cầu `bullets.png` trong thư mục làm việc. Ví dụ C++ này thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình bày dưới dạng [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) và sử dụng nó làm dấu đầu dòng cho đoạn. Nó đặt [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) để sử dụng dấu đầu dòng hình ảnh và gán hình ảnh qua [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/). [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) được đặt thành 100% để kích thước dấu đầu dòng tương đối với văn bản đoạn:

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

### **Tạo Danh sách Đa cấp**

Đặt [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) để đặt các đoạn ở các mức độ khác nhau của một danh sách. Cấp cao nhất có độ sâu `0`.

Ví dụ C++ này gán các giá trị [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) từ 0 đến 3 cho bốn đoạn, tạo ra một phân cấp trong một khung văn bản. Mỗi đoạn sử dụng dấu đầu dòng ký hiệu, với [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) luân phiên giữa dấu đầu dòng tròn và dấu gạch nối để phân biệt các cấp liền kề:

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

### **Bắt đầu các mục danh sách có đánh số với Giá trị Tùy chỉnh**

Sử dụng [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) để đặt số đầu tiên hiển thị cho một đoạn có đánh số.

Ví dụ C++ này đặt [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) để sử dụng đánh số cho ba đoạn và gán các giá trị [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) là 2, 3 và 7. Giá trị bắt đầu được cấu hình riêng cho mỗi đoạn, cho phép các số hiển thị bỏ qua các giá trị:

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

## **Kiểm soát Bố cục Đoạn văn và Thuộc tính Kết thúc**

Điều chỉnh lề và thụt lề của đoạn để kiểm soát vị trí của dòng đầu và các dòng gói. Bạn cũng có thể định dạng dấu kết thúc đoạn riêng biệt so với các phần văn bản hiển thị.

### **Đặt Thụt Lề Dòng Đầu**

Sử dụng phương thức [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) để kiểm soát thụt lề dòng đầu của một đoạn. Phương thức này chỉ di chuyển dòng đầu so với lề trái của đoạn. Giá trị dương đẩy dòng đầu sang phải, trong khi các dòng còn lại vẫn căn chỉnh với thân đoạn.

Sử dụng [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) khi bạn cần di chuyển toàn bộ đoạn. Dùng [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) khi bạn chỉ muốn di chuyển dòng đầu.

Ví dụ dưới đây đặt ba đoạn cùng một giá trị [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) là 20 điểm và các giá trị [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) là 0, 20 và 40 điểm. Các dòng đầu bắt đầu ở các vị trí lệch dần lớn hơn, trong khi các dòng gói giữ nguyên lề trái:

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

![Thụt lề dòng đầu của các đoạn văn](first_line_indent.png)

### **Đặt Thụt Lề Treo**

Thụt lề treo là bố cục đoạn trong đó dòng đầu bắt đầu ở bên trái của các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng phương thức [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/). Truyền một giá trị âm để di chuyển dòng đầu sang trái so với thân đoạn.

Trong thực tế, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) xác định vị trí trái của thân đoạn, và [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) xác định vị trí của dòng đầu so với lề đó. Để tạo thụt lề treo, đặt giá trị `MarginLeft` dương và giá trị `Indent` âm.

Định dạng này hữu ích cho thư mục, tham chiếu, mục từ vựng và các đoạn khác nơi các dòng gói phải căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

Ví dụ C++ sau ghép các giá trị [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) là 40 và 60 điểm với các giá trị [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) là -20 và -30 điểm. Trong mỗi đoạn, dòng đầu bắt đầu ở bên trái của các dòng gói; đoạn thứ hai có thụt lề treo sâu hơn:

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

presentation->Save(u"hhang_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Thụt lề treo của các đoạn văn](hanging_indent.png)

### **Đặt Thuộc tính Chạy Đoạn Văn Kết Thúc**

Phương thức [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) kiểm soát định dạng của dấu kết thúc đoạn. Ví dụ tải `Test.pptx`, phải chứa ít nhất một slide. Ví dụ dưới đây tạo một [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) với [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_fontheight/) đặt thành 48 điểm và [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_latinfont/) đặt thành Times New Roman. Nó gán định dạng này cho dấu kết thúc của đoạn thứ hai, để lại các phần văn bản hiển thị không thay đổi:

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

## **Đếm Các Dòng Được Render**

Đối với các quy tắc đoạn ảnh hưởng đến việc gói tự động và dấu câu ở cuối dòng, hãy xem [Control Line Breaking](/slides/vi/cpp/text-formatting/#control-line-breaking) và [Control Hanging Punctuation](/slides/vi/cpp/text-formatting/#control-hanging-punctuation).

Sử dụng [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/) để đếm số dòng mà một đoạn chiếm sau khi bố trí văn bản, bao gồm cả gói tự động. Điều này hữu ích khi kiểm tra độ dài và bố cục văn bản trong các mẫu bản trình chiếu.

Một đoạn là một mục trong [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_paragraphs/), và nó có thể chiếm nhiều dòng đã render. Một ngắt dòng rõ ràng bên trong một đoạn buộc tạo dòng mới mà không tạo đoạn mới. Gói tự động tạo các dòng dựa trên chiều rộng khả dụng mà không chèn ký tự ngắt dòng vào văn bản. Do đó, việc đếm các đoạn hoặc ký tự ngắt dòng không cho số dòng đã render.

Ví dụ dưới đây tạo một hình dạng văn bản, đếm các dòng của nó, thu hẹp hình dạng, sau đó thay thế văn bản bằng một chuỗi ngắn hơn. Ví dụ bật [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) và tắt [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) để chiều rộng hình dạng kiểm soát gói mà không tự động thu nhỏ văn bản hoặc thay đổi kích thước hình dạng. Mỗi phép đo sử dụng [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/). Kích thước hình dạng tính bằng điểm. Cuối cùng, ví dụ thêm một đoạn nữa và tổng hợp số dòng trên toàn bộ khung văn bản.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

Với văn bản và các kích thước này, việc thu hẹp hình dạng làm tăng số dòng, trong khi thay thế văn bản bằng chuỗi ngắn làm giảm số dòng. Số lượng chính xác có thể thay đổi tùy thuộc vào khả năng có sẵn của phông chữ và việc thay thế, kích thước phông, lề, thụt lề, gói và cài đặt tự động vừa. Sử dụng các phông và cài đặt bố cục dành cho môi trường đích khi kiểm tra mẫu.

Chỉ số dòng không quyết định liệu văn bản có tràn khỏi vùng chứa hay không. Chiều cao khả dụng, chiều cao dòng, khoảng cách đoạn và dòng, và hành vi tự động vừa cũng quan trọng; ngay cả một dòng duy nhất cũng có thể vượt quá chiều rộng khả dụng khi tắt gói.

## **Nhập và Xuất Nội dung Đoạn văn**

Sử dụng HTML để đưa văn bản vào bản trình chiếu hoặc xuất các đoạn hiện có để sử dụng bên ngoài. Phần này cũng cho thấy cách render các đoạn riêng lẻ dưới dạng hình ảnh, bao gồm các đoạn trong ô bảng.

### **Nhập Văn bản HTML vào Đoạn văn**

Sử dụng [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/) để chuyển đổi markup HTML thành các đoạn và phần trong một khung văn bản.

Ví dụ C++ này đọc HTML từ một tệp và truyền markup cho [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/). Nó xóa đoạn mặc định của khung văn bản để khung chỉ chứa nội dung đã nhập. Hình chữ nhật để lại lề 10 điểm ở mỗi phía của slide:

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

### **Xuất Văn bản Đoạn văn thành HTML**

Sử dụng [ParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/exporttohtml/) để xuất một phạm vi đoạn được chọn dưới dạng HTML. Khi tái sử dụng văn bản bản trình chiếu trên một trang web, bạn có thể muốn giữ nguyên các nhấn mạnh cục bộ mà không mang theo phông, kích thước hoặc kiểu hộp văn bản của bản trình chiếu. Đặt [TextToHtmlConversionOptions::set_TextInheritanceLimit](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/set_textinheritancelimit/) để kiểm soát mức độ mà bộ xuất tuân theo kế thừa định dạng.

Tải về [bản trình chiếu mẫu](text-inheritance.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Slide đầu tiên của nó chứa một hình dạng văn bản với văn bản "Inherited text; explicit red 18pt". Đầu vào cố ý sử dụng nhiều cấp định dạng:

- Kiểu văn bản mặc định của bản trình chiếu cung cấp Calibri và kích thước 28 pt.
- Kiểu văn bản cấp một của khung văn bản cung cấp văn bản màu xanh và in nghiêng.
- Đoạn văn đặt in đậm một cách rõ ràng.
- Phần thứ hai, "explicit red 18pt", đặt màu đỏ và kích thước 18 pt một cách rõ ràng.

Ví dụ sau xuất cùng các đoạn ba lần. Nó truyền [TextToHtmlConversionOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/) cho phương thức xuất và ghi mỗi kết quả thành một tệp HTML UTF-8 riêng:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <Export/TextInheritanceLimit.h>
#include <Export/TextToHtmlConversionOptions.h>
#include <system/array.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"text-inheritance.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto modes = MakeArray<TextInheritanceLimit>({TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly});
    auto fileNames = MakeArray<String>({u"All.html", u"TextBox.html", u"ParagraphOnly.html"});

    for (auto i = 0; i < modes->get_Length(); i++)
    {
        auto options = MakeObject<TextToHtmlConversionOptions>();
        options->set_TextInheritanceLimit(modes[i]);

        auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), options);
        File::WriteAllText(fileNames[i], html, Encoding::get_UTF8());
    }
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

HTML được tạo chứa CSS sau cho phần đầu tiên, "Inherited text; ". Bảng liệt kê các khai báo liên quan; các thuộc tính được tạo khác được bỏ qua để rõ ràng.

| Đầu ra | CSS liên quan cho phần đầu tiên | Hiển thị |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Văn bản màu xanh, in đậm, in nghiêng kích thước 28 pt trong Calibri, nếu phông chữ đó có sẵn. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Văn bản màu xanh, in đậm, in nghiêng; trang hoặc trình duyệt bao quanh cung cấp họ phông và kích thước. |
| `ParagraphOnly.html` | `font-weight:bold` | Văn bản in đậm; trang hoặc trình duyệt bao quanh cung cấp họ phông, kích thước, màu và kiểu nghiêng. |

Phần thứ hai giữ nguyên `color:#ff0000`, `font-size:18pt` và `font-weight:bold` trong cả ba đầu ra. Nó cũng giữ lại kiểu in nghiêng với `All` và `TextBox`, nhưng không với `ParagraphOnly`. Hạn chế kế thừa do đó không loại bỏ định dạng được gán trực tiếp cho một đoạn hoặc phần.

Mở các tệp trong cùng một trình duyệt để so sánh chúng. Trong hai chế độ bị hạn chế, các thuộc tính CSS bị bỏ qua sẽ được giải quyết bởi stylesheet của trang đích hoặc giá trị mặc định của trình duyệt, vì vậy diện mạo cuối cùng phụ thuộc vào nơi HTML được sử dụng.

### **Kết xuất Đoạn văn thành Hình ảnh**

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) render một đoạn riêng lẻ trực tiếp và trả về một [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/). Lưu kết quả vào tệp hoặc stream bằng [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Bạn không cần render hình dạng chứa hoặc cắt bitmap thủ công.

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) có thể trả về `nullptr` nếu không tìm thấy đoạn trong bộ sưu tập cha, không có giới hạn render hợp lệ, hoặc không thể render. Kiểm tra kết quả trước khi lưu và giải phóng hình ảnh đã trả về sau khi sử dụng.

#### **Kết xuất Đoạn văn ở Tỷ lệ Mặc định**

Ví dụ dùng `sample.pptx`, một bản trình chiếu với một slide mà hình dạng đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn văn](paragraph_to_image_input.png)

Ví dụ sau chọn đoạn thứ hai ở chỉ mục 1 và gọi [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) mà không có tham số tỷ lệ. Nó kiểm tra xem hình dạng có chứa đoạn cần thiết và render trả về một hình ảnh trước khi gọi [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) để lưu dưới dạng PNG. Ví dụ giải phóng hình ảnh sau khi lưu.

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

#### **Kết xuất Đoạn văn trong Ô Bảng với Tỷ lệ**

Sử dụng overload của [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) cho phép truyền các tham số `float scaleX` và `float scaleY` để đặt hệ số tỷ lệ ngang và dọc. Ví dụ sau tạo một bảng, render đoạn trong ô đầu tiên với độ rộng và chiều cao gấp đôi so với mặc định, và lưu kết quả dưới dạng PNG.

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

Hệ số tỷ lệ `1` giữ trục đó ở kích thước pixel mặc định. Ví dụ, `2` cho cả hai hệ số tạo ra một hình ảnh có chiều rộng và chiều cao khoảng gấp đôi kích thước mặc định, dẫn đến bốn lần số pixel. Các hệ số lớn hơn thường tạo ra văn bản sắc nét hơn cho việc phóng to hoặc xuất ảnh độ phân giải cao, nhưng chúng cũng tăng sử dụng bộ nhớ và kích thước tệp. Các hệ số dưới `1` tạo ra hình ảnh nhỏ hơn với ít chi tiết hơn. Sử dụng các hệ số bằng nhau để duy trì tỉ lệ khung của đoạn; các hệ số ngang và dọc khác nhau sẽ kéo dài đầu ra một cách độc lập.

Render toàn bộ hình dạng bằng [IShape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getimage/) vẫn hữu ích khi đầu ra cần bao gồm màu nền, viền hoặc các ngữ cảnh hình ảnh khác của hình dạng. Đối với hình ảnh chỉ có đoạn, sử dụng [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/).

## **Câu hỏi thường gặp**

**Tôi có thể hoàn toàn tắt việc ngắt dòng trong một khung văn bản không?**

Có. Sử dụng [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) để tắt gói, vì vậy các dòng sẽ không ngắt ở các cạnh của khung văn bản.

**Làm sao tôi có thể lấy chính xác giới hạn trên slide của một đoạn cụ thể?**

Sử dụng [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/) để lấy hình chữ nhật bao quanh của đoạn. [IPortion::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getrect/) cung cấp giới hạn của một phần riêng lẻ.

**Thuộc tính căn chỉnh đoạn (trái, phải, trung tâm hoặc cân đều) được kiểm soát ở đâu?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) là cài đặt ở mức đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng của các phần riêng lẻ.

Để căn chỉnh dọc các phần có kích thước phông khác nhau trong mỗi dòng, xem [Align Fonts Within a Line](/slides/vi/cpp/text-formatting/#align-fonts-within-a-line).

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn không?**

Có. Sử dụng [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) cho các phần riêng lẻ, để một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.
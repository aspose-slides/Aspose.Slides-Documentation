---
title: Thêm Dấu Bản Quyền vào Bản Trình Chiếu trong C++
linktitle: Dấu Bản Quyền
type: docs
weight: 40
url: /vi/cpp/watermark/
keywords:
- dấu bản quyền
- dấu bản quyền văn bản
- dấu bản quyền hình ảnh
- thêm dấu bản quyền
- thay đổi dấu bản quyền
- gỡ bỏ dấu bản quyền
- xoá dấu bản quyền
- thêm dấu bản quyền vào PPT
- thêm dấu bản quyền vào PPTX
- thêm dấu bản quyền vào ODP
- gỡ bỏ dấu bản quyền khỏi PPT
- gỡ bỏ dấu bản quyền khỏi PPTX
- gỡ bỏ dấu bản quyền khỏi ODP
- xoá dấu bản quyền khỏi PPT
- xoá dấu bản quyền khỏi PPTX
- xoá dấu bản quyền khỏi ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Quản lý các dấu bản quyền văn bản và hình ảnh trong các bản trình chiếu PowerPoint và OpenDocument bằng C++ để chỉ ra bản nháp, thông tin mật, bản quyền và hơn nữa."
---
## **Giới thiệu**

**Một watermark** trong bản trình chiếu là một dấu văn bản hoặc hình ảnh được đặt trên một slide hoặc trên toàn bộ các slide của bản trình chiếu. Thông thường, watermark được dùng để chỉ ra rằng bản trình chiếu là bản nháp (ví dụ, watermark “Draft”), chứa thông tin mật (ví dụ, watermark “Confidential”), để chỉ định công ty sở hữu (ví dụ, watermark “Company Name”), xác định tác giả bản trình chiếu, v.v. Watermark giúp ngăn vi phạm bản quyền bằng cách thông báo rằng bản trình chiếu không được sao chép. Watermark được sử dụng trong cả định dạng PowerPoint và OpenOffice. Trong Aspose.Slides, bạn có thể thêm watermark vào các định dạng tệp PowerPoint PPT, PPTX và OpenOffice ODP.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/cpp/), có nhiều cách để tạo watermark trong tài liệu PowerPoint hoặc OpenOffice và chỉnh sửa thiết kế cũng như hành vi của chúng. Điểm chung là để thêm watermark dạng văn bản, bạn nên sử dụng giao diện [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/), và để thêm watermark dạng hình ảnh, sử dụng lớp [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/) hoặc lấp đầy một shape watermark bằng hình ảnh. `PictureFrame` thực thi giao diện [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/), cho phép bạn sử dụng tất cả các thiết lập linh hoạt của đối tượng shape. Vì `ITextFrame` không phải là một shape và các thiết lập của nó bị hạn chế, nó được bọc trong một đối tượng [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/).

Có hai cách áp dụng watermark: vào một slide duy nhất hoặc vào tất cả các slide của bản trình chiếu. Slide Master được dùng để áp dụng watermark cho toàn bộ slide — watermark được thêm vào Slide Master, thiết kế hoàn chỉnh ở đó và áp dụng cho mọi slide mà không ảnh hưởng đến quyền sửa đổi watermark trên từng slide riêng lẻ.

Watermark thường được coi là không thể chỉnh sửa bởi người dùng khác. Để ngăn watermark (hoặc shape cha của watermark) bị chỉnh sửa, Aspose.Slides cung cấp chức năng khóa shape. Một shape cụ thể có thể được khóa trên một slide bình thường hoặc trên Slide Master. Khi shape watermark bị khóa trên Slide Master, nó sẽ bị khóa trên tất cả các slide của bản trình chiếu.

Bạn có thể đặt tên cho watermark để trong tương lai, nếu muốn xóa, bạn có thể tìm nó trong danh sách shape của slide bằng tên.

Bạn có thể thiết kế watermark theo bất kỳ cách nào; tuy nhiên, thường có một số đặc điểm chung như căn giữa, xoay, vị trí phía trước, v.v. Chúng ta sẽ xem cách sử dụng các đặc điểm này trong các ví dụ dưới đây.

## **Watermark dạng Văn bản**

### **Thêm Watermark Văn bản vào một Slide**

Để thêm watermark văn bản trong PPT, PPTX hoặc ODP, bạn có thể đầu tiên thêm một shape vào slide, sau đó thêm một text frame vào shape này. Text frame được biểu diễn bởi giao diện [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/). Kiểu này không kế thừa từ [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/), nên không có nhiều thuộc tính để định vị watermark linh hoạt. Do đó, đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) được bọc trong một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/). Để thêm văn bản watermark vào shape, sử dụng phương thức [AddTextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/addtextframe/) như dưới đây.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Xem thêm" %}} 
- [Cách sử dụng lớp TextFrame](/slides/vi/cpp/text-formatting/)
{{% /alert %}}

### **Thêm Watermark Văn bản vào Toàn bộ Bản trình chiếu**

Nếu bạn muốn thêm watermark văn bản cho toàn bộ bản trình chiếu (tức là tất cả các slide cùng một lúc), hãy thêm nó vào [MasterSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/masterslide/). Phần còn lại của logic giống như khi thêm watermark vào một slide riêng lẻ — tạo một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) và sau đó thêm watermark vào nó bằng phương thức [AddTextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Xem thêm" %}} 
- [Cách sử dụng Slide Master](/slides/vi/cpp/slide-master/)
{{% /alert %}}

### **Đặt Độ Trong Suốt cho Shape Watermark**

Mặc định, shape hình chữ nhật được định dạng với màu fill và line. Các dòng mã sau sẽ làm cho shape trong suốt.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Đặt Phông chữ cho Watermark Văn bản**

Bạn có thể thay đổi phông chữ của watermark văn bản như dưới đây.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Đặt Màu cho Văn bản Watermark**

Để đặt màu cho văn bản watermark, sử dụng đoạn mã này:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Căn Giữa Watermark Văn bản**

Có thể căn trung tâm watermark trên slide, thực hiện như sau:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

Hình ảnh dưới đây cho thấy kết quả cuối cùng.

![Watermark văn bản](text_watermark.png)

## **Watermark dạng Hình ảnh**

### **Thêm Watermark Hình ảnh vào Bản trình chiếu**

Để thêm watermark hình ảnh vào một slide của bản trình chiếu, bạn có thể thực hiện các bước sau:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Khóa Watermark khỏi Việc Chỉnh sửa**

Nếu cần ngăn watermark bị chỉnh sửa, hãy sử dụng phương thức [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/get_autoshapelock/) trên shape. Với thuộc tính này, bạn có thể bảo vệ shape khỏi việc chọn, thay đổi kích thước, di chuyển lại vị trí, nhóm với các yếu tố khác, khóa văn bản khỏi việc chỉnh sửa, và nhiều hơn nữa:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Khóa shape watermark khỏi việc chỉnh sửa
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Đưa Watermark lên phía Trước**

Trong Aspose.Slides, thứ tự Z của các shape có thể được thiết lập qua phương thức [IShapeCollection::Reorder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/reorder/). Để thực hiện, bạn cần gọi phương thức này từ danh sách các slide của bản trình chiếu và truyền vào tham chiếu shape cùng với số thứ tự mong muốn. Cách này cho phép đưa một shape lên phía trước hoặc đưa nó ra phía sau slide. Tính năng này đặc biệt hữu ích khi bạn muốn đặt watermark ở phía trước của bản trình chiếu:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Đặt Góc Xoay cho Watermark**

Dưới đây là ví dụ mã để điều chỉnh góc xoay của watermark sao cho nó nằm chéo trên slide:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Đặt Tên cho Watermark**

Aspose.Slides cho phép bạn đặt tên cho một shape. Bằng cách sử dụng tên shape, bạn có thể truy cập nó trong tương lai để sửa đổi hoặc xóa. Để đặt tên cho shape watermark, gán giá trị cho phương thức [IAutoShape::set_Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_name/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Xóa Watermark**

Để xóa shape watermark, sử dụng phương thức [IAutoShape::get_Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_name/) để tìm nó trong danh sách shape của slide. Sau đó, truyền shape watermark vào phương thức [IShapeCollection::Remove](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/remove/):

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Ví dụ Thực tế**

Bạn có thể thử công cụ **Aspose.Slides miễn phí** [Thêm Watermark](https://products.aspose.app/slides/vi/watermark) và [Xóa Watermark](https://products.aspose.app/slides/vi/watermark/remove-watermark) trực tuyến.

![Công cụ trực tuyến để thêm và xóa watermark](online_tools.png)

## **Câu hỏi Thường gặp**

### Watermark là gì và tại sao nên sử dụng?

Watermark là một lớp phủ văn bản hoặc hình ảnh được áp dụng lên các slide, giúp bảo vệ sở hữu trí tuệ, tăng nhận diện thương hiệu, hoặc ngăn việc sử dụng trái phép bản trình chiếu.

### Tôi có thể thêm watermark vào tất cả các slide trong bản trình chiếu không?

Có, Aspose.Slides cho phép bạn lập trình thêm watermark vào mọi slide trong một bản trình chiếu. Bạn có thể duyệt qua tất cả các slide và áp dụng cài đặt watermark cho từng slide.

### Làm thế nào để điều chỉnh độ trong suốt của watermark?

Bạn có thể điều chỉnh độ trong suốt của watermark bằng cách thay đổi cài đặt fill ([FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/get_fillformat/)) của shape. Điều này giúp watermark trở nên nhẹ nhàng và không làm phân tâm người xem.

### Các định dạng hình ảnh nào được hỗ trợ cho watermark?

Aspose.Slides hỗ trợ nhiều định dạng hình ảnh như PNG, JPEG, GIF, BMP, SVG và nhiều định dạng khác.

### Tôi có thể tùy chỉnh phông chữ và kiểu dáng của watermark văn bản không?

Có, bạn có thể chọn bất kỳ phông chữ, kích thước và kiểu dáng nào để phù hợp với thiết kế của bản trình chiếu và duy trì tính nhất quán thương hiệu.

### Làm sao thay đổi vị trí hoặc hướng của watermark?

Bạn có thể thay đổi vị trí và hướng của watermark bằng cách lập trình điều chỉnh tọa độ, kích thước và thuộc tính xoay của shape.
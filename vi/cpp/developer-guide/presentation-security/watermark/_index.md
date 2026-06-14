---
title: Thêm Watermark vào Bản Trình Chiếu trong C++
linktitle: Dấu Nước
type: docs
weight: 40
url: /vi/cpp/watermark/
keywords:
- dấu nước
- dấu nước văn bản
- dấu nước hình ảnh
- thêm dấu nước
- thay đổi dấu nước
- xóa dấu nước
- xóa dấu nước
- thêm dấu nước vào PPT
- thêm dấu nước vào PPTX
- thêm dấu nước vào ODP
- xóa dấu nước khỏi PPT
- xóa dấu nước khỏi PPTX
- xóa dấu nước khỏi ODP
- xóa dấu nước khỏi PPT
- xóa dấu nước khỏi PPTX
- xóa dấu nước khỏi ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Quản lý các dấu nước văn bản và hình ảnh trong các bản trình chiếu PowerPoint và OpenDocument bằng C++ để chỉ ra bản nháp, thông tin mật, bản quyền và hơn nữa."
---
## **Giới thiệu**

**A watermark** trong một bản trình chiếu là một con tem văn bản hoặc hình ảnh được sử dụng trên một slide hoặc trên toàn bộ các slide của bản trình chiếu. Thông thường, watermark được dùng để chỉ ra rằng bản trình chiếu đang là bản nháp (ví dụ, watermark "Draft"), rằng nó chứa thông tin bí mật (ví dụ, watermark "Confidential"), để xác định công ty sở hữu (ví dụ, watermark "Company Name"), để nhận dạng tác giả của bản trình chiếu, v.v. Watermark giúp ngăn việc vi phạm bản quyền bằng cách chỉ ra rằng bản trình chiếu không được sao chép. Watermark được sử dụng trong cả định dạng bản trình chiếu PowerPoint và OpenOffice. Trong Aspose.Slides, bạn có thể thêm watermark vào các định dạng file PowerPoint PPT, PPTX và OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/vi/cpp/), có nhiều cách để bạn tạo watermark trong tài liệu PowerPoint hoặc OpenOffice và chỉnh sửa thiết kế và hành vi của chúng. Điểm chung là để thêm watermark văn bản, bạn nên sử dụng giao diện [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/), và để thêm watermark hình ảnh, sử dụng lớp [PictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pictureframe/) hoặc lấp đầy một hình watermark bằng hình ảnh. `PictureFrame` triển khai giao diện [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/), cho phép bạn sử dụng tất cả các cài đặt linh hoạt của đối tượng shape. Vì `ITextFrame` không phải là shape và các cài đặt của nó hạn chế, nên nó được bao bọc trong một đối tượng [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/).

Có hai cách để áp dụng watermark: cho một slide riêng lẻ hoặc cho tất cả các slide của bản trình chiếu. Slide Master được dùng để áp dụng watermark cho toàn bộ slide — watermark được thêm vào Slide Master, thiết kế đầy đủ ở đó, và được áp dụng cho tất cả các slide mà không ảnh hưởng tới quyền chỉnh sửa watermark trên từng slide riêng.

Watermark thường được coi là không thể chỉnh sửa bởi người dùng khác. Để ngăn watermark (hoặc shape cha của watermark) bị chỉnh sửa, Aspose.Slides cung cấp chức năng khóa shape. Một shape cụ thể có thể được khóa trên một slide bình thường hoặc trên Slide Master. Khi shape watermark được khóa trên Slide Master, nó sẽ được khóa trên tất cả các slide của bản trình chiếu.

Bạn có thể đặt tên cho watermark để trong tương lai, nếu muốn xóa, bạn có thể tìm nó trong các shape của slide bằng tên.

Bạn có thể thiết kế watermark theo bất kỳ cách nào; tuy nhiên, thường có các đặc điểm chung của watermark, như căn giữa, xoay, vị trí phía trước, v.v. Chúng tôi sẽ xem cách sử dụng chúng trong các ví dụ dưới đây.

## **Watermark Văn bản**

### **Thêm Watermark Văn bản vào Slide**

Để thêm watermark văn bản vào PPT, PPTX hoặc ODP, bạn có thể đầu tiên thêm một shape vào slide, rồi thêm một text frame vào shape này. Text frame được đại diện bởi giao diện [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/). Kiểu này không kế thừa từ [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/), vốn có một tập hợp rộng các thuộc tính để định vị watermark một cách linh hoạt. Do đó, đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) được bao bọc trong một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/). Để thêm văn bản watermark vào shape, sử dụng phương thức [AddTextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/addtextframe/) như dưới đây.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Xem thêm" %}} 
- [Cách sử dụng lớp TextFrame](/slides/vi/cpp/text-formatting/)
{{% /alert %}}

### **Thêm Watermark Văn bản vào Bản Trình Chiếu**

Nếu bạn muốn thêm watermark văn bản cho toàn bộ bản trình chiếu (tức là tất cả các slide cùng một lúc), hãy thêm nó vào [MasterSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/masterslide/). Phần còn lại của logic giống như khi thêm watermark vào một slide riêng — tạo một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) và sau đó thêm watermark vào nó bằng phương thức [AddTextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Xem thêm" %}} 
- [Cách sử dụng Slide Master](/slides/vi/cpp/slide-master/)
{{% /alert %}}

### **Đặt Độ Trong Suốt cho Shape Watermark**

Mặc định, shape hình chữ nhật được định dạng với màu nền và màu viền. Những dòng mã sau sẽ làm cho shape trong suốt.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Đặt Phông Chữ cho Watermark Văn bản**

Bạn có thể thay đổi phông chữ của watermark văn bản như dưới đây.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Đặt Màu Văn Bản Watermark**

Để đặt màu cho văn bản watermark, sử dụng đoạn mã sau:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Căn Giữa Watermark Văn bản**

Có thể căn giữa watermark trên một slide, và để làm điều đó, bạn có thể thực hiện như sau:

```cpp
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

## **Watermark Hình ảnh**

### **Thêm Watermark Hình ảnh vào Bản Trình Chiếu**

Để thêm watermark hình ảnh vào một slide của bản trình chiếu, bạn có thể thực hiện như sau:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Khóa Watermark khỏi Việc Chỉnh sửa**

Nếu cần ngăn watermark bị chỉnh sửa, sử dụng phương thức [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/get_autoshapelock/) trên shape. Với thuộc tính này, bạn có thể bảo vệ shape khỏi việc được chọn, đổi kích thước, di chuyển, nhóm với các phần tử khác, khóa văn bản của nó khỏi chỉnh sửa, và nhiều hơn nữa:

```cpp
// Khóa shape watermark để không thể chỉnh sửa
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Đưa Watermark lên phía trước**

Trong Aspose.Slides, thứ tự Z của các shape có thể được thiết lập thông qua phương thức [IShapeCollection::Reorder](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/reorder/). Để làm điều này, bạn cần gọi phương thức này từ danh sách các slide của bản trình chiếu và truyền tham chiếu shape cùng số thứ tự vào phương thức. Nhờ vậy, có thể đưa một shape lên phía trước hoặc gửi nó ra phía sau slide. Tính năng này đặc biệt hữu ích khi bạn cần đặt watermark ở phía trước bản trình chiếu:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Đặt Góc Xoay cho Watermark**

Dưới đây là ví dụ mã về cách điều chỉnh góc xoay của watermark sao cho nó đặt chéo trên slide:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Đặt Tên cho Watermark**

Aspose.Slides cho phép bạn đặt tên cho một shape. Bằng cách sử dụng tên shape, bạn có thể truy cập vào nó trong tương lai để sửa đổi hoặc xóa. Để đặt tên cho shape watermark, gán nó cho phương thức [IAutoShape::set_Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_name/):

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Xóa Watermark**

Để xóa shape watermark, sử dụng phương thức [IAutoShape::get_Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/get_name/) để tìm nó trong các shape của slide. Sau đó, truyền shape watermark vào phương thức [IShapeCollection::Remove](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/remove/):

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Ví dụ Thực tế**

Bạn có thể muốn xem các công cụ trực tuyến **Aspose.Slides miễn phí** [Thêm Watermark](https://products.aspose.app/slides/vi/watermark) và [Xóa Watermark](https://products.aspose.app/slides/vi/watermark/remove-watermark).

![Công cụ trực tuyến để thêm và xóa watermarks](online_tools.png)

## **Câu hỏi thường gặp**

**Watermark là gì và tại sao tôi nên sử dụng nó?**

Watermark là một lớp phủ văn bản hoặc hình ảnh được áp dụng lên các slide giúp bảo vệ tài sản trí tuệ, tăng nhận diện thương hiệu, hoặc ngăn việc sử dụng trái phép bản trình chiếu.

**Tôi có thể thêm watermark vào tất cả các slide trong một bản trình chiếu không?**

Có, Aspose.Slides cho phép bạn thêm watermark vào mỗi slide trong bản trình chiếu một cách lập trình. Bạn có thể duyệt qua tất cả các slide và áp dụng cài đặt watermark cho từng slide.

**Làm sao tôi có thể điều chỉnh độ trong suốt của watermark?**

Bạn có thể điều chỉnh độ trong suốt của watermark bằng cách sửa đổi cài đặt tô (fill) ([FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/get_fillformat/)) của shape. Điều này đảm bảo watermark mỏng manh và không làm mất tập trung khỏi nội dung slide.

**Các định dạng hình ảnh nào được hỗ trợ cho watermark?**

Aspose.Slides hỗ trợ nhiều định dạng hình ảnh như PNG, JPEG, GIF, BMP, SVG, và nhiều hơn nữa.

**Tôi có thể tùy chỉnh phông chữ và kiểu dáng của watermark văn bản không?**

Có, bạn có thể chọn bất kỳ phông chữ, kích thước và kiểu nào để phù hợp với thiết kế bản trình chiếu và duy trì tính nhất quán thương hiệu.

**Làm sao tôi thay đổi vị trí hoặc hướng của watermark?**

Bạn có thể điều chỉnh vị trí và hướng của watermark một cách lập trình bằng cách sửa đổi tọa độ, kích thước và thuộc tính xoay của shape.
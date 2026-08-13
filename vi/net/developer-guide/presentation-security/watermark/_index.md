---
title: Thêm Dấu Nước vào Bản Trình chiếu trong .NET
linktitle: Dấu Nước
type: docs
weight: 40
url: /vi/net/watermark/
keywords:
- dấu nước
- dấu nước văn bản
- dấu nước hình ảnh
- thêm dấu nước
- thay đổi dấu nước
- xóa dấu nước
- xoá dấu nước
- thêm dấu nước vào PPT
- thêm dấu nước vào PPTX
- thêm dấu nước vào ODP
- gỡ dấu nước khỏi PPT
- gỡ dấu nước khỏi PPTX
- gỡ dấu nước khỏi ODP
- xoá dấu nước khỏi PPT
- xoá dấu nước khỏi PPTX
- xoá dấu nước khỏi ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Quản lý dấu nước văn bản và hình ảnh trong các bản trình chiếu PowerPoint và OpenDocument trên .NET để chỉ ra bản nháp, thông tin mật, bản quyền và các mục khác."
---
## **Giới thiệu**

**Mạ nền** trong một bài thuyết trình là một dấu văn bản hoặc hình ảnh được sử dụng trên một slide hoặc trên tất cả các slide của bài thuyết trình. Thông thường, mạ nền được dùng để chỉ ra rằng bài thuyết trình là bản nháp (ví dụ, mạ nền "Draft"), rằng nó chứa thông tin mật (ví dụ, mạ nền "Confidential"), để xác định công ty sở hữu (ví dụ, mạ nền "Company Name"), để nhận dạng tác giả của bài thuyết trình, v.v. Mạ nền giúp ngăn chặn vi phạm bản quyền bằng cách chỉ ra rằng bài thuyết trình không nên được sao chép. Mạ nền được sử dụng cả trong định dạng PowerPoint và OpenDocument. Trong Aspose.Slides, bạn có thể thêm mạ nền vào các định dạng tệp PowerPoint PPT, PPTX và OpenDocument ODP.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/net/), có nhiều cách để tạo mạ nền trong tài liệu PowerPoint hoặc OpenDocument và điều chỉnh thiết kế và hành vi của chúng. Điểm chung là để thêm mạ nền văn bản, bạn nên sử dụng giao diện [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/), và để thêm mạ nền hình ảnh, sử dụng lớp [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/) hoặc đổ màu cho một hình mạ nền bằng hình ảnh. `PictureFrame` triển khai giao diện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape) cho phép bạn sử dụng tất cả các cài đặt linh hoạt của đối tượng hình dạng. Vì `ITextFrame` không phải là một hình dạng và các cài đặt của nó bị giới hạn, nó được bao bọc trong một đối tượng [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape).

Có hai cách để áp dụng mạ nền: cho một slide duy nhất hoặc cho tất cả các slide của bài thuyết trình. Slide Master được sử dụng để áp dụng mạ nền cho tất cả các slide — mạ nền được thêm vào Slide Master, thiết kế đầy đủ ở đó, và áp dụng cho mọi slide mà không ảnh hưởng đến quyền chỉnh sửa mạ nền trên các slide riêng lẻ.

Mạ nền thường được coi là không khả dụng để người dùng khác chỉnh sửa. Để ngăn mạ nền (hoặc chính hình dạng cha của mạ nền) bị chỉnh sửa, Aspose.Slides cung cấp chức năng khóa hình dạng. Một hình dạng cụ thể có thể được khóa trên một slide bình thường hoặc trên Slide Master. Khi hình dạng mạ nền được khóa trên Slide Master, nó sẽ bị khóa trên tất cả các slide của bài thuyết trình.

Bạn có thể đặt tên cho mạ nền để trong tương lai, nếu muốn xóa nó, có thể tìm thấy bằng tên trong các hình dạng của slide.

Bạn có thể thiết kế mạ nền theo bất kỳ cách nào; tuy nhiên, thường có một số đặc điểm chung trong mạ nền, như căn giữa, quay, vị trí phía trước, v.v. Chúng tôi sẽ xem cách sử dụng chúng trong các ví dụ dưới đây.

## **Mạ nền Văn bản**

### **Thêm Mạ nền Văn bản vào Slide**

Để thêm mạ nền văn bản vào PPT, PPTX hoặc ODP, bạn có thể đầu tiên thêm một hình dạng vào slide, sau đó thêm một khung văn bản vào hình dạng này. Khung văn bản được đại diện bởi giao diện [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe). Kiểu này không kế thừa từ [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/), vốn có bộ thuộc tính rộng để định vị mạ nền một cách linh hoạt. Do đó, đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe) được bao bọc trong một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) . Để thêm văn bản mạ nền vào hình dạng, sử dụng phương thức [AddTextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/methods/addtextframe) như dưới đây.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Thêm dấu nước vào slide.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="See also" %}} 
- [How to Use the TextFrame Class?](/slides/vi/net/text-formatting/)
{{% /alert %}}

### **Thêm Mạ nền Văn bản vào Bài Thuyết Trình**

Nếu bạn muốn thêm mạ nền văn bản cho toàn bộ bài thuyết trình (tức là tất cả các slide cùng lúc), hãy thêm nó vào [MasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/masterslide/). Phần còn lại của logic tương tự như khi thêm mạ nền vào một slide đơn — tạo một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) và sau đó thêm mạ nền vào đó bằng phương thức [AddTextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Thêm dấu nước vào slide master.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="See also" %}} 
- [How to Use the Slide Master?](/slides/vi/net/slide-master/)
{{% /alert %}}

### **Đặt Độ Trong Suốt Cho Hình Mạ nền**

Mặc định, hình chữ nhật được định dạng với màu nền và màu viền. Điều này có nghĩa là khi mạ nền được thêm vào, nó có thể xuất hiện với nền hoặc viền đặc có thể gây phân tâm cho nội dung slide. Để đảm bảo mạ nền vẫn nhẹ nhàng và không can thiệp vào thiết kế hình ảnh của bài thuyết trình, bạn có thể làm cho hình dạng hoàn toàn trong suốt.

Các dòng mã sau làm cho hình dạng trong suốt bằng cách loại bỏ cả màu nền và màu viền:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Đặt Phông chữ cho Mạ nền Văn bản**

Trước khi áp dụng mạ nền văn bản vào slide, việc tùy chỉnh giao diện của nó là quan trọng để nó hòa hợp với thiết kế chung. Bạn có thể thay đổi kiểu và kích thước phông chữ để đảm bảo mạ nền vừa dễ đọc vừa thẩm mỹ. Tùy chỉnh phông chữ cũng có thể giúp củng cố nhận diện thương hiệu hoặc chỉ đơn giản là phù hợp với phong cách của bài thuyết trình.

Đoạn mã dưới đây minh họa cách điều chỉnh cài đặt phông chữ của mạ nền bằng cách chọn một phông chữ Latin cụ thể và đặt chiều cao phông chữ phù hợp:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Đặt Màu Văn bản cho Mạ nền**

Trước khi áp dụng mạ nền, cần đảm bảo rằng màu văn bản được đặt hợp lý để nó hòa hợp với nội dung slide mà không làm nó nổi bật quá mức. Điều chỉnh độ trong suốt màu (alpha) cùng với các thành phần đỏ, xanh lá và xanh dương cho phép bạn tạo ra một mạ nền nhẹ nhàng, bán trong suốt, vừa hiện ra vừa không gây rối. Cách tiếp cận này giúp duy trì sự tập trung vào nội dung chính của bài thuyết trình đồng thời vẫn bảo vệ nội dung của bạn.

Để đặt màu cho văn bản mạ nền, sử dụng đoạn mã sau:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Căn giữa Mạ nền Văn bản**

Việc căn giữa đúng cách mạ nền văn bản có thể cải thiện đáng kể tính thẩm mỹ tổng thể của bài thuyết trình bằng cách đảm bảo mạ nền được đặt đối xứng, bất kể kích thước slide. Cách này không chỉ mang lại vẻ chuyên nghiệp cho slide mà còn đảm bảo mạ nền không cản trở nội dung chính.

Đoạn mã dưới đây minh họa cách tính vị trí trung tâm của slide và đặt mạ nền văn bản tương ứng:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Hình ảnh dưới đây hiển thị kết quả cuối cùng.

![The text watermark](text_watermark.png)

## **Mạ nền Hình ảnh**

### **Thêm Mạ nền Hình ảnh vào Bài Thuyết Trình**

Trong nhiều trường hợp, mạ nền hình ảnh có thể cung cấp một yếu tố thương hiệu độc đáo hoặc là một lựa chọn trực quan hấp dẫn hơn so với mạ nền văn bản. Trước khi thêm mạ nền, hãy chắc chắn rằng tệp hình ảnh đã sẵn sàng (ví dụ, PNG để hỗ trợ trong suốt). Ví dụ dưới đây minh họa cách tải một hình ảnh từ hệ thống tệp của bạn, thêm nó vào bài thuyết trình và sau đó áp dụng nó làm mạ nền bằng các thuộc tính đổ màu của hình dạng.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Khóa Mạ nền khỏi Việc chỉnh sửa**

Nếu cần ngăn mạ nền bị chỉnh sửa, sử dụng thuộc tính [IAutoShape.ShapeLock](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/properties/shapelock) trên hình dạng. Với thuộc tính này, bạn có thể bảo vệ hình dạng khỏi việc được chọn, thay đổi kích thước, di chuyển, nhóm với các phần tử khác, khóa văn bản khỏi chỉnh sửa, và nhiều hơn nữa:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Khóa hình dạng dấu nước khỏi việc sửa đổi.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Đưa Mạ nền lên phía trước**

Trong Aspose.Slides, thứ tự Z của các hình dạng có thể được đặt qua phương thức [IShapeCollection.Reorder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/reorder/#reorder). Để thực hiện, bạn cần gọi phương thức này từ danh sách slide của bài thuyết trình và truyền tham chiếu hình dạng cùng số thứ tự vào phương thức. Bằng cách này, có thể đưa một hình dạng lên phía trước hoặc đưa nó về phía sau slide. Tính năng này đặc biệt hữu ích khi bạn cần đặt mạ nền ở phía trước của bài thuyết trình:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Đặt Góc Xoay cho Mạ nền**

Điều chỉnh góc xoay của mạ nền có thể tăng đáng kể tác động hình ảnh và sự tinh tế của bài thuyết trình. Một mạ nền chéo, ví dụ, có thể ít gây phiền nhiễu hơn trong khi vẫn cung cấp bảo vệ mạnh mẽ chống việc sử dụng trái phép. Ví dụ dưới đây tính góc thích hợp dựa trên kích thước slide để mạ nền được đặt chéo qua slide. Phép tính động này đảm bảo mạ nền vẫn hiệu quả bất kể kích thước slide thay đổi.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Đặt Tên cho Mạ nền**

Aspose.Slides cho phép bạn đặt tên cho một hình dạng. Bằng cách sử dụng tên hình dạng, bạn có thể truy cập nó trong tương lai để chỉnh sửa hoặc xóa. Để đặt tên cho hình dạng mạ nền, gán nó cho thuộc tính [IAutoShape.Name](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/properties/name):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Xóa Mạ nền**

Để xóa hình dạng mạ nền, sử dụng thuộc tính [IAutoShape.Name](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/properties/name) để tìm nó trong các hình dạng của slide. Sau đó, truyền hình dạng mạ nền vào phương thức [IShapeCollection.Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/remove/) :

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Một Ví dụ Trực tiếp**

Bạn có thể muốn kiểm tra các công cụ trực tuyến **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/vi/watermark) và [Remove Watermark](https://products.aspose.app/slides/vi/watermark/remove-watermark).

![Online tools to add and remove watermarks](online_tools.png)

## **Câu hỏi thường gặp**

### Mạ nền là gì và tại sao tôi nên sử dụng nó?

Mạ nền là một lớp phủ văn bản hoặc hình ảnh được áp dụng lên các slide giúp bảo vệ sở hữu trí tuệ, tăng nhận diện thương hiệu hoặc ngăn chặn việc sử dụng trái phép các bài thuyết trình.

### Tôi có thể thêm mạ nền vào tất cả các slide trong một bài thuyết trình không?

Có, Aspose.Slides cho phép bạn bổ sung mạ nền cho mọi slide trong bài thuyết trình một cách lập trình. Bạn có thể duyệt qua tất cả các slide và áp dụng cài đặt mạ nền cho từng slide.

### Làm sao tôi có thể điều chỉnh độ trong suốt của mạ nền?

Bạn có thể điều chỉnh độ trong suốt của mạ nền bằng cách sửa đổi cài đặt fill ([FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/fillformat/)) của hình dạng. Điều này đảm bảo mạ nền nhẹ nhàng và không làm mất tập trung vào nội dung slide.

### Các định dạng hình ảnh nào được hỗ trợ cho mạ nền?

Aspose.Slides hỗ trợ nhiều định dạng hình ảnh như PNG, JPEG, GIF, BMP, SVG và các định dạng khác.

### Tôi có thể tùy chỉnh phông chữ và kiểu dáng của mạ nền văn bản không?

Có, bạn có thể chọn bất kỳ phông chữ, kích thước và kiểu dáng nào để phù hợp với thiết kế của bài thuyết trình và duy trì tính nhất quán thương hiệu.

### Làm sao tôi thay đổi vị trí hoặc hướng của mạ nền?

Bạn có thể điều chỉnh vị trí và hướng của mạ nền một cách lập trình bằng cách thay đổi tọa độ, kích thước và các thuộc tính xoay của hình dạng.
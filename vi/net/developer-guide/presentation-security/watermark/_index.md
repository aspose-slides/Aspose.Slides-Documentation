---
title: Thêm Đánh dấu nước vào Bản trình chiếu trong .NET
linktitle: Đánh dấu nước
type: docs
weight: 40
url: /vi/net/watermark/
keywords:
- đánh dấu nước
- đánh dấu nước văn bản
- đánh dấu nước hình ảnh
- thêm đánh dấu nước
- thay đổi đánh dấu nước
- gỡ bỏ đánh dấu nước
- xóa đánh dấu nước
- thêm đánh dấu nước vào PPT
- thêm đánh dấu nước vào PPTX
- thêm đánh dấu nước vào ODP
- gỡ bỏ đánh dấu nước khỏi PPT
- gỡ bỏ đánh dấu nước khỏi PPTX
- gỡ bỏ đánh dấu nước khỏi ODP
- xóa đánh dấu nước khỏi PPT
- xóa đánh dấu nước khỏi PPTX
- xóa đánh dấu nước khỏi ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Quản lý các đánh dấu nước văn bản và hình ảnh trong các bản trình chiếu PowerPoint và OpenDocument trên .NET để chỉ ra bản nháp, thông tin mật, bản quyền và nhiều hơn nữa."
---
## **Giới thiệu**

**Đánh dấu nước** trong một bản trình chiếu là một dấu văn bản hoặc hình ảnh được sử dụng trên một slide hoặc trên toàn bộ các slide của bản trình chiếu. Thông thường, đánh dấu nước được dùng để chỉ ra rằng bản trình chiếu là bản nháp (ví dụ: đánh dấu nước “Draft”), chứa thông tin mật (ví dụ: đánh dấu nước “Confidential”), xác định công ty sở hữu (ví dụ: đánh dấu nước “Company Name”), nhận dạng tác giả của bản trình chiếu, v.v. Đánh dấu nước giúp ngăn chặn vi phạm bản quyền bằng cách cho biết rằng bản trình chiếu không được sao chép. Đánh dấu nước được sử dụng trong cả định dạng PowerPoint và OpenDocument. Trong Aspose.Slides, bạn có thể thêm đánh dấu nước vào các định dạng tệp PowerPoint PPT, PPTX và OpenDocument ODP.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/net/), có nhiều cách để tạo đánh dấu nước trong tài liệu PowerPoint hoặc OpenDocument và sửa đổi thiết kế cũng như hành vi của chúng. Điểm chung là để thêm đánh dấu nước bằng văn bản, bạn nên sử dụng giao diện [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/), còn để thêm đánh dấu nước bằng hình ảnh, hãy sử dụng lớp [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/) hoặc đắp một hình ảnh vào hình dạng đánh dấu nước. `PictureFrame` triển khai giao diện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape) cho phép bạn sử dụng tất cả các cài đặt linh hoạt của đối tượng shape. Vì `ITextFrame` không phải là một shape và các cài đặt của nó hạn chế, nên nó được gói trong một đối tượng [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape).

Có hai cách để áp dụng đánh dấu nước: cho một slide riêng lẻ hoặc cho tất cả các slide của bản trình chiếu. Slide Master được dùng để áp dụng đánh dấu nước cho toàn bộ các slide — đánh dấu nước được thêm vào Slide Master, được thiết kế đầy đủ ở đó và áp dụng cho tất cả các slide mà không ảnh hưởng đến quyền chỉnh sửa đánh dấu nước trên các slide riêng lẻ.

Đánh dấu nước thường được coi là không thể chỉnh sửa bởi người dùng khác. Để ngăn đánh dấu nước (hoặc chính shape cha của nó) bị chỉnh sửa, Aspose.Slides cung cấp tính năng khóa shape. Một shape cụ thể có thể được khóa trên một slide bình thường hoặc trên Slide Master. Khi shape đánh dấu nước được khóa trên Slide Master, nó sẽ bị khóa trên tất cả các slide của bản trình chiếu.

Bạn có thể đặt tên cho đánh dấu nước để trong tương lai, nếu muốn xóa nó, bạn có thể tìm thấy nó trong danh sách shape của slide bằng tên.

Bạn có thể thiết kế đánh dấu nước theo bất kỳ cách nào; tuy nhiên, thường có một số đặc điểm chung như căn giữa, xoay, nằm phía trước, v.v. Chúng tôi sẽ xem xét cách sử dụng các đặc điểm này trong các ví dụ dưới đây.

## **Đánh dấu nước bằng Văn bản**

### **Thêm Đánh dấu nước Văn bản vào một Slide**

Để thêm đánh dấu nước bằng văn bản trong PPT, PPTX hoặc ODP, bạn có thể đầu tiên thêm một shape vào slide, sau đó thêm một khung văn bản vào shape này. Khung văn bản được biểu diễn bằng giao diện [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe). Kiểu này không kế thừa từ [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/), vốn có một tập hợp rộng các thuộc tính để định vị đánh dấu nước một cách linh hoạt. Do đó, đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe) được gói trong một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) . Để thêm văn bản đánh dấu nước vào shape, sử dụng phương thức [AddTextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/methods/addtextframe) như dưới đây.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Thêm đánh dấu nước vào slide.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class?](/slides/vi/net/text-formatting/)
{{% /alert %}}

### **Thêm Đánh dấu nước Văn bản vào toàn bộ Bản trình chiếu**

Nếu bạn muốn thêm đánh dấu nước bằng văn bản cho toàn bộ bản trình chiếu (tức là tất cả các slide cùng một lúc), hãy thêm nó vào [MasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/masterslide/). Phần còn lại của logic tương tự như khi thêm đánh dấu nước vào một slide riêng lẻ — tạo một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) và sau đó thêm đánh dấu nước vào nó bằng phương thức [AddTextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Thêm đánh dấu nước vào slide master.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master?](/slides/vi/net/slide-master/)
{{% /alert %}}

### **Đặt Độ trong suốt cho Shape Đánh dấu nước**

Mặc định, shape hình chữ nhật được thiết lập màu nền và đường viền. Điều này có nghĩa là khi đánh dấu nước được thêm vào, nó có thể hiển thị với nền hoặc viền đặc, gây phân tán sự chú ý khỏi nội dung slide. Để đảm bảo đánh dấu nước được giữ ở mức nhẹ nhàng và không can thiệp vào thiết kế trực quan của bản trình chiếu, bạn có thể làm cho shape hoàn toàn trong suốt.

Các dòng mã sau làm cho shape trong suốt bằng cách loại bỏ cả màu nền và màu viền:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Đặt Phông chữ cho Đánh dấu nước Văn bản**

Trước khi áp dụng đánh dấu nước văn bản vào slide, bạn nên tùy chỉnh giao diện của nó sao cho hài hòa với thiết kế tổng thể. Bạn có thể thay đổi kiểu và kích thước phông chữ để đảm bảo đánh dấu nước vừa dễ đọc vừa thẩm mỹ. Tùy chỉnh phông chữ cũng giúp củng cố nhận diện thương hiệu hoặc chỉ đơn giản là phù hợp với phong cách của bản trình chiếu.

Đoạn mã dưới đây cho thấy cách điều chỉnh các thiết lập phông chữ của đánh dấu nước bằng cách chọn một phông Latin cụ thể và đặt chiều cao phông phù hợp:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Đặt Màu cho Văn bản Đánh dấu nước**

Trước khi áp dụng đánh dấu nước, bạn cần chắc chắn rằng màu văn bản được đặt hợp lý để hòa hợp với nội dung slide mà không làm nó bị lấn át. Điều chỉnh độ trong suốt (alpha) của màu cùng với các thành phần đỏ, xanh lá và xanh dương cho phép bạn tạo ra một đánh dấu nước mờ, bán trong suốt, vừa thấy được vừa không gây phiền nhiễu. Cách tiếp cận này giúp duy trì sự tập trung vào nội dung chính của bản trình chiếu đồng thời bảo vệ nội dung của bạn.

Để đặt màu cho văn bản đánh dấu nước, sử dụng đoạn mã sau:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Căn giữa Đánh dấu nước Văn bản**

Căn giữa đúng vị trí cho đánh dấu nước văn bản có thể nâng cao đáng kể thẩm mỹ tổng thể của bản trình chiếu bằng cách đảm bảo rằng đánh dấu nước được đặt đối xứng, bất kể kích thước slide. Cách này không chỉ mang lại vẻ chuyên nghiệp cho slide mà còn đảm bảo đánh dấu nước không cản trở nội dung chính.

Đoạn mã dưới đây minh họa cách tính vị trí trung tâm của slide và đặt đánh dấu nước văn bản tương ứng:

```cs
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

## **Đánh dấu nước bằng Hình ảnh**

### **Thêm Đánh dấu nước Hình ảnh vào Bản trình chiếu**

Trong nhiều trường hợp, đánh dấu nước bằng hình ảnh có thể cung cấp một yếu tố thương hiệu độc đáo hoặc là lựa chọn trực quan hơn so với đánh dấu nước văn bản. Trước khi thêm đánh dấu nước, hãy chắc chắn rằng tệp hình ảnh có sẵn (ví dụ: PNG cho nền trong suốt). Ví dụ dưới đây minh họa cách tải một hình ảnh từ hệ thống tập tin, thêm nó vào bản trình chiếu và sau đó áp dụng nó làm đánh dấu nước bằng các thuộc tính đổ màu của shape.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Khóa Đánh dấu nước khỏi Việc Chỉnh sửa**

Nếu cần ngăn một đánh dấu nước bị chỉnh sửa, hãy sử dụng thuộc tính [IAutoShape.ShapeLock](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/properties/shapelock) trên shape. Với thuộc tính này, bạn có thể bảo vệ shape khỏi việc được chọn, thay đổi kích thước, di chuyển lại vị trí, nhóm với các yếu tố khác, khóa văn bản khỏi chỉnh sửa, và nhiều hơn nữa:

```cs
// Khóa shape đánh dấu nước khỏi việc sửa đổi.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Đưa Đánh dấu nước lên phía Trước**

Trong Aspose.Slides, thứ tự Z của các shape có thể được đặt qua phương thức [IShapeCollection.Reorder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/reorder/#reorder). Để thực hiện, bạn cần gọi phương thức này từ danh sách các slide của bản trình chiếu và truyền vào tham chiếu shape cùng số thứ tự mong muốn. Cách này cho phép đưa một shape lên phía trước hoặc đưa nó xuống phía sau của slide. Tính năng này đặc biệt hữu ích khi bạn muốn đặt đánh dấu nước ở phía trước bản trình chiếu:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Đặt Góc Xoay cho Đánh dấu nước**

Điều chỉnh góc xoay của đánh dấu nước có thể tăng đáng kể hiệu quả thị giác và độ tinh tế của bản trình chiếu. Một đánh dấu nước chéo, ví dụ, có thể ít gây phiền nhiễu hơn trong khi vẫn cung cấp bảo vệ mạnh mẽ chống việc sử dụng trái phép. Ví dụ dưới đây tính toán góc phù hợp dựa trên kích thước slide để đánh dấu nước được đặt chéo xuyên qua slide. Phép tính động này đảm bảo đánh dấu nước vẫn hiệu quả bất kể kích thước slide thay đổi.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Đặt Tên cho Đánh dấu nước**

Aspose.Slides cho phép bạn đặt tên cho một shape. Bằng cách sử dụng tên shape, bạn có thể truy cập vào nó trong tương lai để sửa đổi hoặc xóa. Để đặt tên cho shape của đánh dấu nước, gán giá trị cho thuộc tính [IAutoShape.Name](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/properties/name):

```cs
watermarkShape.Name = "watermark";
```

## **Xóa Đánh dấu nước**

Để xóa shape đánh dấu nước, sử dụng thuộc tính [IAutoShape.Name](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/properties/name) để tìm nó trong danh sách shape của slide. Sau đó, truyền shape đánh dấu nước vào phương thức [IShapeCollection.Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/remove/) :

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Ví dụ Thực tế**

Bạn có thể thử công cụ **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/vi/watermark) và [Remove Watermark](https://products.aspose.app/slides/vi/watermark/remove-watermark) trực tuyến.

![Online tools to add and remove watermarks](online_tools.png)

## **Câu hỏi thường gặp**

**Đánh dấu nước là gì và tại sao tôi nên sử dụng?**

Đánh dấu nước là một lớp phủ văn bản hoặc hình ảnh được áp dụng lên các slide, giúp bảo vệ tài sản trí tuệ, tăng nhận diện thương hiệu hoặc ngăn việc sử dụng trái phép bản trình chiếu.

**Tôi có thể thêm đánh dấu nước cho tất cả các slide trong bản trình chiếu không?**

Có, Aspose.Slides cho phép bạn lập trình để thêm đánh dấu nước vào mọi slide của bản trình chiếu. Bạn có thể duyệt qua tất cả các slide và áp dụng cài đặt đánh dấu nước cho từng slide.

**Làm thế nào để điều chỉnh độ trong suốt của đánh dấu nước?**

Bạn có thể điều chỉnh độ trong suốt của đánh dấu nước bằng cách sửa đổi các cài đặt đổ màu ([FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/fillformat/)) của shape. Điều này giúp đánh dấu nước nhẹ nhàng và không gây xao lãng nội dung slide.

**Các định dạng hình ảnh nào được hỗ trợ cho đánh dấu nước?**

Aspose.Slides hỗ trợ nhiều định dạng hình ảnh như PNG, JPEG, GIF, BMP, SVG và nhiều định dạng khác.

**Tôi có thể tùy chỉnh phông chữ và kiểu dáng của đánh dấu nước văn bản không?**

Có, bạn có thể chọn bất kỳ phông chữ, kích thước và kiểu dáng nào để phù hợp với thiết kế của bản trình chiếu và duy trì sự nhất quán thương hiệu.

**Làm sao để thay đổi vị trí hoặc hướng của đánh dấu nước?**

Bạn có thể điều chỉnh vị trí và hướng của đánh dấu nước một cách lập trình bằng cách sửa đổi các thuộc tính tọa độ, kích thước và góc xoay của shape.
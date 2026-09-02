---
title: Quản lý Hộp Văn Bản trong Bản Trình Chiếu bằng .NET
linktitle: Quản lý Hộp Văn Bản
type: docs
weight: 20
url: /vi/net/manage-textbox/
keywords:
- hộp văn bản
- khung văn bản
- thêm văn bản
- cập nhật văn bản
- tạo hộp văn bản
- kiểm tra hộp văn bản
- thêm cột văn bản
- thêm siêu liên kết
- PowerPoint
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides cho .NET giúp bạn dễ dàng tạo, chỉnh sửa và sao chép các hộp văn bản trong các tệp PowerPoint và OpenDocument, nâng cao khả năng tự động hoá bản trình chiếu của bạn."
---
## **Giới thiệu**

Văn bản trên các slide thường tồn tại trong hộp văn bản hoặc hình dạng. Do đó, để thêm văn bản vào một slide, bạn phải thêm một hộp văn bản trước và sau đó đặt một số văn bản vào bên trong hộp văn bản. 

Để cho phép bạn thêm một hình dạng có thể chứa văn bản, Aspose.Slides cho .NET cung cấp giao diện [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape). 

{{% alert title="Lưu ý" color="warning" %}} 

Aspose.Slides cũng cung cấp giao diện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape) để cho phép bạn thêm các hình dạng vào slide. Tuy nhiên, không phải tất cả các hình dạng được thêm thông qua giao diện `IShape` đều có thể chứa văn bản. Các hình dạng được thêm thông qua giao diện [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape) thường chứa văn bản. 

Do đó, khi làm việc với một hình dạng hiện có mà bạn muốn thêm văn bản, bạn có thể muốn kiểm tra và xác nhận rằng nó đã được ép kiểu qua giao diện `IAutoShape`. Chỉ khi đó bạn mới có thể làm việc với [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/properties/textframe), đó là một thuộc tính của `IAutoShape`. Xem phần [Update Text](https://docs.aspose.com/slides/vi/net/manage-textbox/#update-text) trên trang này. 

{{% /alert %}}

## **Tạo một Hộp Văn Bản trên Slide**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation). 
2. Lấy tham chiếu của slide đầu tiên thông qua chỉ mục của nó. 
3. Thêm một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape) với [ShapeType](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometryshape/properties/shapetype) được đặt là `Rectangle` tại vị trí xác định trên slide và lấy tham chiếu cho đối tượng `IAutoShape` vừa được thêm. 
4. Thêm thuộc tính `TextFrame` vào đối tượng `IAutoShape` sẽ chứa một đoạn văn bản. Trong ví dụ dưới đây, chúng tôi đã thêm đoạn văn bản này: *Aspose TextBox* 
5. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Mã C# này—một triển khai các bước trên—cho bạn thấy cách thêm văn bản vào slide:

```c#
using Aspose.Slides;

// Tạo một đối tượng PresentationEx
using (Presentation pres = new Presentation())
{

    // Lấy slide đầu tiên trong bản trình chiếu
    ISlide sld = pres.Slides[0];

    // Thêm một AutoShape với loại được đặt là Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Thêm TextFrame vào Rectangle
    ashp.AddTextFrame(" ");

    // Truy cập khung văn bản
    ITextFrame txtFrame = ashp.TextFrame;

    // Tạo đối tượng Paragraph cho khung văn bản
    IParagraph para = txtFrame.Paragraphs[0];

    // Tạo đối tượng Portion cho đoạn văn
    IPortion portion = para.Portions[0];

    // Đặt văn bản
    portion.Text = "Aspose TextBox";

    // Lưu bản trình chiếu vào đĩa
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Kiểm tra Hình dạng Hộp Văn Bản**

Aspose.Slides cung cấp thuộc tính [IsTextBox](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/istextbox/) từ giao diện [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) , cho phép bạn kiểm tra các hình dạng và xác định hộp văn bản.

![Hộp văn bản và hình dạng](istextbox.png)

Mã C# này cho bạn thấy cách kiểm tra xem một hình dạng có được tạo dưới dạng hộp văn bản hay không: 

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

Lưu ý rằng nếu bạn chỉ thêm một autoshape bằng phương thức `AddAutoShape` từ giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/), thuộc tính `IsTextBox` của autoshape sẽ trả về `false`. Tuy nhiên, sau khi bạn thêm văn bản vào autoshape bằng phương thức `AddTextFrame` hoặc thuộc tính `Text`, thuộc tính `IsTextBox` sẽ trả về `true`.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox là false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox là true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox là false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox là true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox là false
    shape3.AddTextFrame("");
    // shape3.IsTextBox là false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox là false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox là false
}
```

## **Tìm Hình dạng Sở hữu Khung Văn Bản**

Trong mã xử lý văn bản tổng quát, bạn có thể nhận được một [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) mà chưa biết đối tượng trình chiếu nào chứa nó. Sử dụng thuộc tính [ITextFrame.ParentShape](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentshape/) để điều hướng trở lại [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) sở hữu.

Đối với một khung văn bản thuộc về một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) hoặc một hình dạng chứa văn bản khác, [ITextFrame.ParentShape](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentshape/) được đặt và [ITextFrame.ParentCell](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/parentcell/) là `null`. Cả hai thuộc tính đều là thuộc tính chỉ đọc, vì vậy việc đọc chúng không làm thay đổi quyền sở hữu. Luôn kiểm tra giá trị trả về xem có phải `null` trước khi truy cập vào hình dạng.

Đối với một ví dụ hoàn chỉnh xác định chủ sở hữu hình dạng và ô bảng, bao gồm các hình dạng liên kết với nút SmartArt, xem [Search and Replace Text](/slides/vi/net/search-and-replace-text/).

## **Thêm Cột vào Hộp Văn Bản**

Aspose.Slides cung cấp các thuộc tính [ColumnCount](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/properties/columncount) và [ColumnSpacing](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat/properties/columnspacing) (từ giao diện [ITextFrameFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat) và lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat)) để cho phép bạn thêm cột vào hộp văn bản. Bạn có thể chỉ định số cột trong hộp văn bản và sau đó chỉ định khoảng cách (đơn vị điểm) giữa các cột. 

Mã C# này minh họa hoạt động đã mô tả: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// Lấy slide đầu tiên trong bản trình chiếu
	ISlide slide = presentation.Slides[0];

	// Thêm một AutoShape với loại được đặt là Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Thêm TextFrame vào Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Lấy định dạng văn bản của TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Xác định số cột trong TextFrame
	format.ColumnCount = 3;

	// Xác định khoảng cách giữa các cột
	format.ColumnSpacing = 10;

	// Lưu bản trình chiếu
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Thêm Cột vào Khung Văn Bản**

Aspose.Slides cho .NET cung cấp thuộc tính [ColumnCount](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat/properties/columncount) (từ giao diện [ITextFrameFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframeformat)) cho phép bạn thêm cột trong khung văn bản. Thông qua thuộc tính này, bạn có thể chỉ định số cột mong muốn trong một khung văn bản. 

Mã C# này cho bạn thấy cách thêm một cột vào khung văn bản:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **Cập nhật Văn bản**

Aspose.Slides cho phép bạn thay đổi hoặc cập nhật văn bản có trong một hộp văn bản hoặc tất cả các văn bản có trong một trình chiếu. 

Mã C# này trình bày một thao tác trong đó tất cả các văn bản trong một trình chiếu được cập nhật hoặc thay đổi:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Kiểm tra xem hình dạng có hỗ trợ khung văn bản (IAutoShape) hay không. 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Duyệt qua các đoạn trong khung văn bản
               {
                   foreach (IPortion portion in paragraph.Portions) //Duyệt qua từng phần trong đoạn
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Thay đổi văn bản
                       portion.PortionFormat.FontBold = NullableBool.True; //Thay đổi định dạng
                   }
               }
           }
       }
   }
  
   //Lưu bản trình chiếu đã sửa đổi
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Thêm Hộp Văn Bản với Siêu liên kết** 

Bạn có thể chèn một liên kết bên trong hộp văn bản. Khi hộp văn bản được nhấp, người dùng sẽ được chuyển hướng mở liên kết. 

1. Tạo một thể hiện của lớp `Presentation`. 
2. Lấy tham chiếu của slide đầu tiên thông qua chỉ mục của nó.  
3. Thêm một đối tượng `AutoShape` với `ShapeType` được đặt là `Rectangle` tại vị trí xác định trên slide và lấy tham chiếu của đối tượng AutoShape vừa được thêm. 
4. Thêm một `TextFrame` vào đối tượng `AutoShape` chứa *Aspose TextBox* làm văn bản mặc định. 
5. Tạo một thể hiện của lớp `IHyperlinkManager`. 
6. Gán đối tượng `IHyperlinkManager` cho thuộc tính [HyperlinkClick](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/properties/hyperlinkclick) liên kết với phần bạn muốn trong `TextFrame`. 
7. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Mã C# này—một triển khai các bước trên—cho bạn thấy cách thêm một hộp văn bản có siêu liên kết vào slide:

```c#
using Aspose.Slides;

// Tạo một đối tượng Presentation đại diện cho một tệp PPTX
Presentation pptxPresentation = new Presentation();

// Lấy slide đầu tiên trong bản trình chiếu
ISlide slide = pptxPresentation.Slides[0];

// Thêm một đối tượng AutoShape với loại được đặt là Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Ép hình dạng sang AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Truy cập thuộc tính ITextFrame liên kết với AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Thêm một số văn bản vào khung
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Đặt siêu liên kết cho đoạn văn bản
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Lưu bản trình chiếu PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Sự khác biệt giữa hộp văn bản và trình giữ chỗ văn bản khi làm việc với các slide mẫu là gì?**

Một [placeholder](/slides/vi/net/manage-placeholder/) kế thừa kiểu/dựng hình từ [master](https://reference.aspose.com/slides/vi/net/aspose.slides/masterslide/) và có thể được ghi đè trên [layouts](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutslide/), trong khi một hộp văn bản thông thường là một đối tượng độc lập trên một slide cụ thể và không thay đổi khi bạn chuyển đổi layout.

**Làm thế nào để thực hiện việc thay thế văn bản hàng loạt trên toàn bộ trình chiếu mà không ảnh hưởng đến văn bản trong biểu đồ, bảng và SmartArt?**

Hạn chế việc duyệt qua các tự động hình dạng có khung văn bản và loại trừ các đối tượng nhúng ([charts](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/vi/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/vi/net/aspose.slides.smartart/smartart/)) bằng cách duyệt các bộ sưu tập của chúng riêng biệt hoặc bỏ qua các kiểu đối tượng đó.
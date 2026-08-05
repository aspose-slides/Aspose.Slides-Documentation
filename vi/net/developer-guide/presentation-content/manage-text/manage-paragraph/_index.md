---
title: Quản lý các đoạn văn bản PowerPoint trong .NET
linktitle: Quản lý Đoạn Văn
type: docs
weight: 40
url: /vi/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- thêm văn bản
- thêm đoạn văn
- quản lý văn bản
- quản lý đoạn văn
- quản lý dấu đầu dòng
- thụt lề đoạn
- thụt lề treo
- đánh dấu đoạn
- danh sách đánh số
- danh sách có dấu đầu dòng
- thuộc tính đoạn
- nhập HTML
- văn bản sang HTML
- đoạn sang HTML
- đoạn sang ảnh
- văn bản sang ảnh
- xuất đoạn
- PowerPoint
- bản thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Thành thạo định dạng đoạn với Aspose.Slides cho .NET—tối ưu căn chỉnh, khoảng cách và kiểu trong các bản thuyết trình PPT, PPTX và ODP bằng C#."
---
## **Giới thiệu**

Aspose.Slides cung cấp tất cả các giao diện và lớp cần thiết để làm việc với văn bản, đoạn văn và phần trong PowerPoint bằng C#.

* Aspose.Slides cung cấp giao diện [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) cho phép bạn thêm các đối tượng đại diện cho một đoạn văn. Một đối tượng `ITextFame` có thể chứa một hoặc nhiều đoạn (mỗi đoạn được tạo bằng cách nhập ký tự xuống dòng).
* Aspose.Slides cung cấp giao diện [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) cho phép bạn thêm các đối tượng đại diện cho các phần. Một đối tượng `IParagraph` có thể chứa một hoặc nhiều phần (tập hợp các đối tượng iPortions).
* Aspose.Slides cung cấp giao diện [IPortion](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/) cho phép bạn thêm các đối tượng đại diện cho văn bản và các thuộc tính định dạng của chúng. 

Một đối tượng `IParagraph` có khả năng xử lý văn bản với các thuộc tính định dạng khác nhau thông qua các đối tượng `IPortion` bên dưới.

## **Thêm Nhiều Đoạn Văn Chứa Nhiều Phần**

Các bước sau cho bạn biết cách thêm một khung văn bản chứa 3 đoạn và mỗi đoạn chứa 3 phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Truy cập tham chiếu slide tương ứng qua chỉ mục của nó.
3. Thêm một hình chữ nhật [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
4. Lấy `ITextFrame` liên kết với [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/).
5. Tạo hai đối tượng [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) và thêm chúng vào bộ sưu tập `IParagraphs` của [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/).
6. Tạo ba đối tượng [IPortion](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/) cho mỗi `IParagraph` mới (hai đối tượng Portion cho đoạn mặc định) và thêm mỗi đối tượng `IPortion` vào bộ sưu tập IPortion của từng `IParagraph`.
7. Đặt một số văn bản cho mỗi phần.
8. Áp dụng các tính năng định dạng mong muốn cho mỗi phần bằng các thuộc tính định dạng của đối tượng `IPortion`.
9. Lưu bản thuyết trình đã chỉnh sửa.

Mã C# dưới đây là một triển khai các bước để thêm các đoạn chứa các phần:

```c#
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{
    // Truy cập slide đầu tiên
    ISlide slide = pres.Slides[0];

    // Thêm một IAutoShape dạng hình chữ nhật
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Truy cập TextFrame của AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Tạo các Paragraph và Portion với các định dạng văn bản khác nhau
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Lưu bản thuyết trình đã chỉnh sửa
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```


## **Quản Lý Đánh Dấu Đầu Dòng Cho Đoạn Văn**

Danh sách dạng dấu đầu dòng giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Các đoạn có dấu đầu dòng luôn dễ đọc và hiểu hơn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Truy cập tham chiếu slide tương ứng qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide được chọn.
4. Truy cập `TextFrame` của autoshape. 
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đối tượng đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/).
8. Đặt `Type` dấu đầu dòng cho đoạn là `Symbol` và chỉ định ký tự dấu đầu dòng.
9. Đặt `Text` cho đoạn.
10. Đặt `Indent` cho dấu đầu dòng.
11. Đặt màu cho dấu đầu dòng.
12. Đặt chiều cao cho dấu đầu dòng.
13. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
14. Thêm đoạn thứ hai và lặp lại các bước từ 7 đến 13.
15. Lưu bản thuyết trình.

Mã C# dưới đây cho bạn thấy cách thêm một dấu đầu dòng cho đoạn:

```c#
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{

    // Truy cập slide đầu tiên
    ISlide slide = pres.Slides[0];


    // Thêm và truy cập Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Truy cập khung văn bản của autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Xóa đoạn mặc định
    txtFrm.Paragraphs.RemoveAt(0);

    // Tạo một đoạn
    Paragraph para = new Paragraph();

    // Đặt kiểu dấu đầu dòng và ký hiệu cho đoạn
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Đặt văn bản cho đoạn
    para.Text = "Welcome to Aspose.Slides";

    // Đặt thụt lề dấu đầu dòng
    para.ParagraphFormat.Indent = 25;

    // Đặt màu dấu đầu dòng
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // đặt IsBulletHardColor thành true để sử dụng màu dấu đầu dòng tùy chỉnh

    // Đặt chiều cao dấu đầu dòng
    para.ParagraphFormat.Bullet.Height = 100;

    // Thêm đoạn vào khung văn bản
    txtFrm.Paragraphs.Add(para);

    // Tạo đoạn thứ hai
    Paragraph para2 = new Paragraph();

    // Đặt loại và kiểu dấu đầu dòng cho đoạn
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Thêm văn bản cho đoạn
    para2.Text = "This is numbered bullet";

    // Đặt thụt lề dấu đầu dòng
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // đặt IsBulletHardColor thành true để sử dụng màu dấu đầu dòng tùy chỉnh

    // Đặt chiều cao dấu đầu dòng
    para2.ParagraphFormat.Bullet.Height = 100;

    // Thêm đoạn vào khung văn bản
    txtFrm.Paragraphs.Add(para2);


    // Lưu bản thuyết trình đã chỉnh sửa
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **Quản Lý Đánh Dấu Hình Ảnh Cho Đoạn Văn**

Danh sách dạng dấu đầu dòng giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Các đoạn hình ảnh dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Truy cập tham chiếu slide tương ứng qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
4. Truy cập `TextFrame` của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đối tượng đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/).
7. Tải ảnh bằng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/).
8. Đặt loại dấu đầu dòng là [Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) và chỉ định hình ảnh.
9. Đặt `Text` cho đoạn.
10. Đặt `Indent` cho dấu đầu dòng.
11. Đặt màu cho dấu đầu dòng.
12. Đặt chiều cao cho dấu đầu dòng.
13. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
14. Thêm đoạn thứ hai và lặp lại quy trình dựa trên các bước trước.
15. Lưu bản thuyết trình đã chỉnh sửa.

Mã C# dưới đây cho bạn thấy cách thêm và quản lý dấu đầu dòng dạng hình ảnh:

```c#
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
Presentation presentation = new Presentation();

// Truy cập slide đầu tiên
ISlide slide = presentation.Slides[0];

// Khởi tạo hình ảnh cho dấu đầu dòng
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Thêm và truy cập Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Truy cập khung văn bản của autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Xóa đoạn mặc định
textFrame.Paragraphs.RemoveAt(0);

// Tạo một đoạn mới
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Đặt kiểu dấu đầu dòng và hình ảnh cho đoạn
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Đặt chiều cao dấu đầu dòng
paragraph.ParagraphFormat.Bullet.Height = 100;

// Thêm đoạn vào khung văn bản
textFrame.Paragraphs.Add(paragraph);

// Ghi bản thuyết trình dưới dạng tệp PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Ghi bản thuyết trình dưới dạng tệp PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **Quản Lý Đánh Dấu Đa Cấp**

Danh sách dạng dấu đầu dòng giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Các dấu đầu dòng đa cấp dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)class.
2. Truy cập tham chiếu slide tương ứng qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide mới.
4. Truy cập `TextFrame` của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đoạn đầu tiên qua lớp [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/) và đặt độ sâu thành 0.
7. Tạo đoạn thứ hai qua lớp `Paragraph` và đặt độ sâu thành 1.
8. Tạo đoạn thứ ba qua lớp `Paragraph` và đặt độ sâu thành 2.
9. Tạo đoạn thứ tư qua lớp `Paragraph` và đặt độ sâu thành 3.
10. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
11. Lưu bản thuyết trình đã chỉnh sửa.

Mã C# dưới đây cho bạn thấy cách thêm và quản lý các dấu đầu dòng đa cấp:

```c#
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{

    // Truy cập slide đầu tiên
    ISlide slide = pres.Slides[0];
    
    // Thêm và truy cập Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Truy cập khung văn bản của autoshape đã tạo
    ITextFrame text = aShp.AddTextFrame("");
    
    // Xóa đoạn mặc định
    text.Paragraphs.Clear();

    // Thêm đoạn đầu tiên
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Đặt mức độ dấu đầu dòng
    para1.ParagraphFormat.Depth = 0;

    // Thêm đoạn thứ hai
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Đặt mức độ dấu đầu dòng
    para2.ParagraphFormat.Depth = 1;

    // Thêm đoạn thứ ba
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Đặt mức độ dấu đầu dòng
    para3.ParagraphFormat.Depth = 2;

    // Thêm đoạn thứ tư
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Đặt mức độ dấu đầu dòng
    para4.ParagraphFormat.Depth = 3;

    // Thêm các đoạn vào bộ sưu tập
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Ghi bản thuyết trình dưới dạng tệp PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Quản Lý Đoạn Văn Với Danh Sách Đánh Số Tùy Chỉnh**

Giao diện [IBulletFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/) cung cấp thuộc tính [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/numberedbulletstartwith) và những thuộc tính khác cho phép bạn quản lý các đoạn với việc đánh số hoặc định dạng tùy chỉnh. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)class.
2. Truy cập slide chứa đoạn văn.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
4. Truy cập `TextFrame` của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đoạn đầu tiên qua lớp [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/) và đặt [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/numberedbulletstartwith) bằng 2.
7. Tạo đoạn thứ hai qua lớp `Paragraph` và đặt `NumberedBulletStartWith` bằng 3.
8. Tạo đoạn thứ ba qua lớp `Paragraph` và đặt `NumberedBulletStartWith` bằng 7.
9. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
10. Lưu bản thuyết trình đã chỉnh sửa.

Mã C# dưới đây cho bạn thấy cách thêm và quản lý các đoạn với đánh số hoặc định dạng tùy chỉnh:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Truy cập khung văn bản của autoshape đã tạo
	ITextFrame textFrame = shape.TextFrame;

	// Xóa đoạn mặc định hiện có
	textFrame.Paragraphs.RemoveAt(0);

	// Danh sách đầu tiên
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Đặt Thụt Lề Dòng Đầu Cho Đoạn Văn**

Sử dụng thuộc tính [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) để kiểm soát thụt lề dòng đầu của một đoạn. Thuộc tính này chỉ di chuyển dòng đầu so với lề trái của đoạn. Giá trị dương đẩy dòng đầu sang phải, trong khi các dòng còn lại vẫn được căn chỉnh với phần thân đoạn.

Sử dụng [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginleft/) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) khi bạn chỉ muốn di chuyển dòng đầu.

Ví dụ dưới đây tạo một số đoạn và áp dụng các giá trị `Indent` khác nhau để minh họa cách thụt lề dòng đầu ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) dạng hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) trống vào hình và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị [Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản thuyết trình đã chỉnh sửa.

Mã này cho bạn thấy cách đặt thụt lề cho đoạn:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Đặt Thụt Lề Treo Cho Đoạn Văn**

Thụt lề treo là bố cục đoạn trong đó dòng đầu bắt đầu ở bên trái so với các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng thuộc tính [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/). Đặt `Indent` thành giá trị âm để di chuyển dòng đầu sang trái so với phần thân đoạn.

Thực tế, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginleft/) xác định vị trí trái của phần thân đoạn, và [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) xác định vị trí dòng đầu so với lề đó. Để tạo thụt lề treo, đặt giá trị `MarginLeft` dương và giá trị `Indent` âm.

Định dạng này hữu ích cho thư mục, tài liệu tham khảo, mục từ điển và các đoạn khác mà các dòng gập phải căn dưới phần thân đoạn thay vì dưới ký tự đầu của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) dạng hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) trống vào hình và xóa đoạn mặc định.
5. Tạo các đoạn và đặt giá trị [MarginLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginleft/) dương cho mỗi đoạn.
6. Đặt giá trị [Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) âm để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản thuyết trình đã chỉnh sửa.

Mã này cho bạn thấy cách đặt thụt lề treo cho đoạn:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

Kết quả:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Quản Lý Thuộc Tính Kết Thúc Đoạn Văn (End Paragraph Run Properties)**

1. Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) class.
2. Lấy tham chiếu cho slide chứa đoạn qua vị trí của nó.
3. Thêm một hình chữ nhật [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) có hai đoạn vào hình chữ nhật.
5. Đặt `FontHeight` và kiểu Font cho các đoạn.
6. Đặt các thuộc tính End cho các đoạn.
7. Ghi bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Mã C# này cho bạn thấy cách đặt các thuộc tính End cho các đoạn trong PowerPoint:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Nhập Văn Bản HTML Vào Các Đoạn Văn**
Aspose.Slides cung cấp hỗ trợ nâng cao cho việc nhập văn bản HTML vào các đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Truy cập tham chiếu slide tương ứng qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) vào slide.
4. Thêm và truy cập `ITextFrame` của `autoshape` [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/).
5. Xóa đoạn mặc định trong `ITextFrame`.
6. Đọc tệp HTML nguồn bằng một `TextReader`.
7. Tạo đoạn đầu tiên qua lớp [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/).
8. Thêm nội dung tệp HTML đã đọc vào `ParagraphCollection` của `TextFrame`.
9. Lưu bản thuyết trình đã chỉnh sửa.

Mã C# dưới đây là một triển khai các bước để nhập văn bản HTML vào các đoạn:

```c#
// Tạo một thể hiện trống của Presentation
using (Presentation pres = new Presentation())
{
    // Truy cập slide đầu tiên mặc định của bản thuyết trình
    ISlide slide = pres.Slides[0];

    // Thêm AutoShape để chứa nội dung HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Thêm khung văn bản vào hình
    ashape.AddTextFrame("");

    // Xóa tất cả các đoạn trong khung văn bản đã thêm
    ashape.TextFrame.Paragraphs.Clear();

    // Tải tệp HTML bằng StreamReader
    TextReader tr = new StreamReader("file.html");

    // Thêm văn bản từ StreamReader HTML vào khung văn bản
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Lưu bản thuyết trình
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Xuất Văn Bản Đoạn Sang HTML**
Aspose.Slides cung cấp hỗ trợ nâng cao cho việc xuất văn bản (nằm trong các đoạn) ra HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) và tải bản thuyết trình mong muốn.
2. Truy cập tham chiếu slide tương ứng qua chỉ mục của nó.
3. Truy cập hình chứa văn bản sẽ được xuất ra HTML.
4. Truy cập `TextFrame` của hình.
5. Tạo một thể hiện của `StreamWriter` và thêm tệp HTML mới.
6. Cung cấp chỉ mục bắt đầu cho `StreamWriter` và xuất các đoạn bạn muốn.

Mã C# này cho bạn thấy cách xuất văn bản các đoạn PowerPoint sang HTML:

```c#
// Tải tệp bản thuyết trình
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Truy cập slide đầu tiên mặc định của bản thuyết trình
    ISlide slide = pres.Slides[0];

    // Truy cập chỉ mục cần thiết
    int index = 0;

    // Truy cập hình đã thêm
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Ghi dữ liệu các đoạn vào HTML bằng cách chỉ định chỉ mục bắt đầu của đoạn và số lượng đoạn sẽ được sao chép
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Lưu Đoạn Văn Dưới Dạng Ảnh**

Trong phần này, chúng ta sẽ khám phá hai ví dụ minh họa cách lưu một đoạn văn bản, được biểu diễn bằng giao diện [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/), dưới dạng ảnh. Cả hai ví dụ đều bao gồm việc lấy ảnh của một hình chứa đoạn bằng các phương thức `GetImage` của giao diện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/), tính toán giới hạn của đoạn trong hình và xuất nó dưới dạng ảnh bitmap. Các phương pháp này cho phép bạn trích xuất các phần văn bản cụ thể từ bản thuyết trình PowerPoint và lưu chúng dưới dạng ảnh riêng, hữu ích cho nhiều kịch bản khác nhau.

Giả sử chúng ta có một tệp presentation tên là sample.pptx với một slide, trong đó hình đầu tiên là một hộp văn bản chứa ba đoạn.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Ví dụ 1**

Trong ví dụ này, chúng ta lấy đoạn thứ hai dưới dạng ảnh. Để làm điều này, chúng ta trích xuất ảnh của hình từ slide đầu tiên của bản thuyết trình, sau đó tính toán giới hạn của đoạn thứ hai trong `TextFrame` của hình. Đoạn sau đó được vẽ lại lên một ảnh bitmap mới và lưu ở định dạng PNG. Phương pháp này đặc biệt hữu ích khi bạn cần lưu một đoạn cụ thể dưới dạng ảnh riêng mà vẫn giữ nguyên kích thước và định dạng của văn bản.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

Kết quả:

![The paragraph image](paragraph_to_image_output.png)

**Ví dụ 2**

Trong ví dụ này, chúng ta mở rộng cách tiếp cận trước bằng cách thêm các hệ số tỉ lệ cho ảnh đoạn. Hình được trích xuất từ bản thuyết trình và lưu dưới dạng ảnh với hệ số tỉ lệ `2`. Điều này cho phép đầu ra có độ phân giải cao hơn khi xuất đoạn. Giới hạn đoạn sau đó được tính lại với yếu tố tỉ lệ. Việc tỉ lệ có thể đặc biệt hữu ích khi cần ảnh chi tiết hơn, ví dụ cho tài liệu in chất lượng cao.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Lưu shape vào bộ nhớ dưới dạng bitmap có tỉ lệ phóng đại.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Tạo bitmap cho shape từ bộ nhớ.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Tính giới hạn của đoạn thứ hai.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Tính kích thước cho ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Chuẩn bị bitmap cho đoạn.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Vẽ lại đoạn từ bitmap của shape sang bitmap của đoạn.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **Câu Hỏi Thường Gặp (FAQ)**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong một khung văn bản không?**

Có. Sử dụng cài đặt ngắt dòng của khung văn bản ([WrapText](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat/wraptext/)) để tắt ngắt dòng, vì vậy các dòng sẽ không bị cắt ở cạnh khung.

**Làm thế nào để tôi lấy vị trí chính xác của một đoạn cụ thể trên slide?**

Bạn có thể truy xuất hình chữ nhật bao quanh của đoạn (hoặc thậm chí của một phần) để biết vị trí và kích thước chính xác của nó trên slide.

**Vị trí căn chỉnh đoạn (trái/phải/giữa/đều) được điều khiển ở đâu?**

[Alignment](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraphformat/alignment/) là một cài đặt cấp độ đoạn trong [ParagraphFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraphformat/); nó áp dụng cho toàn bộ đoạn bất kể định dạng của các phần riêng lẻ.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả chỉ cho một phần của đoạn (ví dụ, một từ) không?**

Có. Ngôn ngữ được đặt ở cấp độ phần ([PortionFormat.LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/languageid/)), vì vậy nhiều ngôn ngữ có thể tồn tại đồng thời trong cùng một đoạn.
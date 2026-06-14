---
title: Quản lý các đoạn văn bản PowerPoint trong .NET
linktitle: Quản lý Đoạn văn
type: docs
weight: 40
url: /vi/net/manage-paragraph/
keywords:
- thêm văn bản
- thêm đoạn
- quản lý văn bản
- quản lý đoạn
- quản lý dấu đầu dòng
- thụt lề đoạn
- thụt lề treo
- đánh dấu đoạn
- danh sách đánh số
- danh sách có dấu đầu
- thuộc tính đoạn
- nhập HTML
- văn bản sang HTML
- đoạn sang HTML
- đoạn sang hình ảnh
- văn bản sang hình ảnh
- xuất đoạn
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Thành thạo định dạng đoạn văn với Aspose.Slides cho .NET — tối ưu căn chỉnh, khoảng cách và kiểu dáng trong các bản trình chiếu PPT, PPTX và ODP bằng C#."
---
## **Giới thiệu**

Aspose.Slides cung cấp tất cả các giao diện và lớp bạn cần để làm việc với văn bản, đoạn văn và phần trong PowerPoint bằng C#.

* Aspose.Slides cung cấp giao diện [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) cho phép bạn thêm các đối tượng đại diện cho một đoạn văn. Một đối tượng `ITextFame` có thể có một hoặc nhiều đoạn văn (mỗi đoạn được tạo bằng ký tự xuống dòng).
* Aspose.Slides cung cấp giao diện [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) cho phép bạn thêm các đối tượng đại diện cho các phần. Một đối tượng `IParagraph` có thể có một hoặc nhiều phần (tập hợp các đối tượng iPortions).
* Aspose.Slides cung cấp giao diện [IPortion](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/) cho phép bạn thêm các đối tượng đại diện cho văn bản và các thuộc tính định dạng của chúng.

Một đối tượng `IParagraph` có khả năng xử lý văn bản với các thuộc tính định dạng khác nhau thông qua các đối tượng `IPortion` nền tảng của nó.

## **Thêm Nhiều Đoạn Văn Chứa Nhiều Phần**

Các bước sau cho bạn cách thêm một khung văn bản chứa 3 đoạn và mỗi đoạn chứa 3 phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Thêm một hình chữ nhật [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
4. Lấy ITextFrame liên kết với [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/).
5. Tạo hai đối tượng [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) và thêm chúng vào bộ sưu tập `IParagraphs` của [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/).
6. Tạo ba đối tượng [IPortion](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/) cho mỗi `IParagraph` mới (hai đối tượng Portion cho đoạn văn mặc định) và thêm mỗi đối tượng `IPortion` vào bộ sưu tập IPortion của từng `IParagraph`.
7. Đặt một số văn bản cho mỗi phần.
8. Áp dụng các tính năng định dạng ưa thích của bạn cho mỗi phần bằng cách sử dụng các thuộc tính định dạng được cung cấp bởi đối tượng `IPortion`.
9. Lưu bản trình chiếu đã sửa đổi.

```c#
// Tạo một đối tượng lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{
    // Truy cập slide đầu tiên
    ISlide slide = pres.Slides[0];

    // Thêm một IAutoShape hình chữ nhật
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
    // Lưu bản trình chiếu đã sửa đổi
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **Quản Lý Dấu Đầu Đoạn**

Danh sách dấu đầu dòng giúp bạn tổ chức và trình bày thông tin nhanh chóng và hiệu quả. Các đoạn có dấu đầu dòng luôn dễ đọc và hiểu hơn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide đã chọn.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) của autoshape. 
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đối tượng đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/) .
8. Đặt `Type` dấu đầu cho đoạn là `Symbol` và đặt ký tự dấu đầu.
9. Đặt `Text` cho đoạn.
10. Đặt `Indent` cho đoạn để điều chỉnh dấu đầu.
11. Đặt màu cho dấu đầu.
12. Đặt độ cao cho dấu đầu.
13. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
14. Thêm đoạn thứ hai và lặp lại quy trình từ bước 7 đến 13.
15. Lưu bản trình chiếu.

```c#
// Tạo một đối tượng lớp Presentation đại diện cho tệp PPTX
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

    // Đặt thụt lề dấu đầu
    para.ParagraphFormat.Indent = 25;

    // Đặt màu dấu đầu
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // đặt IsBulletHardColor thành true để sử dụng màu dấu đầu riêng

    // Đặt chiều cao dấu đầu
    para.ParagraphFormat.Bullet.Height = 100;

    // Thêm Đoạn vào khung văn bản
    txtFrm.Paragraphs.Add(para);

    // Tạo đoạn thứ hai
    Paragraph para2 = new Paragraph();

    // Đặt loại và kiểu dấu đầu dòng cho đoạn
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Thêm văn bản cho đoạn
    para2.Text = "This is numbered bullet";

    // Đặt thụt lề dấu đầu
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // đặt IsBulletHardColor thành true để sử dụng màu dấu đầu riêng

    // Đặt chiều cao dấu đầu
    para2.ParagraphFormat.Bullet.Height = 100;

    // Thêm Đoạn vào khung văn bản
    txtFrm.Paragraphs.Add(para2);


    // Lưu bản trình chiếu đã sửa đổi
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Quản Lý Dấu Đầu Đoạn Hình Ảnh**

Danh sách dấu đầu dòng giúp bạn tổ chức và trình bày thông tin nhanh chóng và hiệu quả. Các đoạn có hình ảnh dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đối tượng đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/) .
7. Tải hình ảnh trong [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) .
8. Đặt loại dấu đầu thành [Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) và đặt hình ảnh.
9. Đặt `Text` cho Paragraph.
10. Đặt `Indent` cho Paragraph để điều chỉnh dấu đầu.
11. Đặt màu cho dấu đầu.
12. Đặt độ cao cho dấu đầu.
13. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
14. Thêm đoạn thứ hai và lặp lại quy trình dựa trên các bước trước.
15. Lưu bản trình chiếu đã sửa đổi.

```c#
// Tạo một đối tượng lớp Presentation đại diện cho tệp PPTX
Presentation presentation = new Presentation();

// Truy cập slide đầu tiên
ISlide slide = presentation.Slides[0];

// Tạo đối tượng hình ảnh cho dấu đầu dòng
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

// Đặt chiều cao dấu đầu
paragraph.ParagraphFormat.Bullet.Height = 100;

// Thêm đoạn vào khung văn bản
textFrame.Paragraphs.Add(paragraph);

// Ghi bản trình chiếu dưới dạng tệp PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Ghi bản trình chiếu dưới dạng tệp PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Quản Lý Dấu Đầu Đoạn Đa Cấp**

Danh sách dấu đầu dòng giúp bạn tổ chức và trình bày thông tin nhanh chóng và hiệu quả. Dấu đầu đa cấp dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)class.
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide mới.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đối tượng đoạn đầu tiên thông qua lớp [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/) và đặt độ sâu (depth) là 0.
7. Tạo đối tượng đoạn thứ hai thông qua lớp `Paragraph` và đặt độ sâu là 1.
8. Tạo đối tượng đoạn thứ ba thông qua lớp `Paragraph` và đặt độ sâu là 2.
9. Tạo đối tượng đoạn thứ tư thông qua lớp `Paragraph` và đặt độ sâu là 3.
10. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
11. Lưu bản trình chiếu đã sửa đổi.

```c#
// Tạo một đối tượng lớp Presentation đại diện cho tệp PPTX
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
    // Đặt mức độ dấu đầu
    para1.ParagraphFormat.Depth = 0;

    // Thêm đoạn thứ hai
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Đặt mức độ dấu đầu
    para2.ParagraphFormat.Depth = 1;

    // Thêm đoạn thứ ba
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Đặt mức độ dấu đầu
    para3.ParagraphFormat.Depth = 2;

    // Thêm đoạn thứ tư
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Đặt mức độ dấu đầu
    para4.ParagraphFormat.Depth = 3;

    // Thêm các đoạn vào bộ sưu tập
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Ghi bản trình chiếu dưới dạng tệp PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Quản Lý Đoạn Văn Bằng Danh Sách Đánh Số Tùy Chỉnh**

Giao diện [IBulletFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/) cung cấp thuộc tính [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/numberedbulletstartwith) và các thuộc tính khác cho phép bạn quản lý các đoạn với đánh số hoặc định dạng tùy chỉnh.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)class.
2. Truy cập slide chứa đoạn văn.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đối tượng đoạn đầu tiên qua lớp [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/) và đặt [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/net/aspose.slides/ibulletformat/numberedbulletstartwith) thành 2.
7. Tạo đối tượng đoạn thứ hai qua lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 3.
8. Tạo đối tượng đoạn thứ ba qua lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 7.
9. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
10. Lưu bản trình chiếu đã sửa đổi.

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

## **Đặt Thụt Lề Dòng Đầu cho Đoạn Văn**

Sử dụng thuộc tính [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) để kiểm soát thụt lề dòng đầu của một đoạn. Thuộc tính này chỉ di chuyển dòng đầu so với lề trái của đoạn. Giá trị dương dịch dòng đầu sang phải, trong khi các dòng còn lại vẫn căn chỉnh với thân đoạn.

Sử dụng [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginleft/) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) khi bạn chỉ cần di chuyển dòng đầu.

Ví dụ dưới đây tạo một số đoạn và áp dụng các giá trị `Indent` khác nhau để minh họa cách thụt lề dòng đầu ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) rỗng vào hình dạng và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị [Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình chiếu đã sửa đổi.

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

![Thụt lề dòng đầu của các đoạn](first_line_indent.png)

## **Đặt Thụt Lề Treo cho Đoạn Văn**

Thụt lề treo là bố cục đoạn mà dòng đầu bắt đầu ở phía bên trái của các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng thuộc tính [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/). Đặt `Indent` thành giá trị âm để di chuyển dòng đầu sang trái so với thân đoạn.

Trong thực tế, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginleft/) xác định vị trí trái của thân đoạn, và [IParagraphFormat.Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) xác định vị trí của dòng đầu so với lề đó. Để tạo thụt lề treo, đặt giá trị [MarginLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginleft/) dương và giá trị [Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) âm.

Định dạng này hữu ích cho thư mục, tham khảo, mục từ điển, và các đoạn khác nơi các dòng gói phải căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) rỗng vào hình dạng và xóa đoạn mặc định.
5. Tạo các đoạn và đặt giá trị [MarginLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/marginleft/) dương cho mỗi đoạn.
6. Đặt giá trị [Indent](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraphformat/indent/) âm để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình chiếu đã sửa đổi.

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

![Thụt lề treo của các đoạn](hanging_indent.png)

## **Quản Lý Thuộc Tính Cuối Đoạn**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Lấy tham chiếu cho slide chứa đoạn văn thông qua vị trí của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) có hai đoạn vào hình chữ nhật.
5. Đặt `FontHeight` và kiểu Font cho các đoạn.
6. Đặt các thuộc tính End cho các đoạn.
7. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

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

## **Nhập Văn Bản HTML vào Đoạn Văn**

Aspose.Slides cung cấp hỗ trợ nâng cao cho việc nhập văn bản HTML vào các đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) vào slide.
4. Thêm và truy cập `autoshape` [ITextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/) .
5. Xóa đoạn mặc định trong `ITextFrame`.
6. Đọc tệp HTML nguồn bằng một TextReader.
7. Tạo đối tượng đoạn đầu tiên qua lớp [Paragraph](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraph/) .
8. Thêm nội dung tệp HTML đã đọc từ TextReader vào [ParagraphCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraphcollection/) của TextFrame.
9. Lưu bản trình chiếu đã sửa đổi.

```c#
// Tạo một thể hiện trống của bản trình chiếu
using (Presentation pres = new Presentation())
{
    // Truy cập slide đầu tiên mặc định của bản trình chiếu
    ISlide slide = pres.Slides[0];

    // Thêm AutoShape để chứa nội dung HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Thêm khung văn bản vào hình dạng
    ashape.AddTextFrame("");

    // Xóa toàn bộ các đoạn trong khung văn bản đã thêm
    ashape.TextFrame.Paragraphs.Clear();

    // Tải tệp HTML bằng StreamReader
    TextReader tr = new StreamReader("file.html");

    // Thêm văn bản từ StreamReader HTML vào khung văn bản
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Lưu bản trình chiếu
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Xuất Văn Bản Đoạn ra HTML**

Aspose.Slides cung cấp hỗ trợ nâng cao cho việc xuất văn bản (có trong các đoạn) ra HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) và tải bản trình chiếu mong muốn.
2. Truy cập tham chiếu slide tương ứng thông qua chỉ mục của nó.
3. Truy cập hình dạng chứa văn bản sẽ được xuất ra HTML.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/textframe/) của hình dạng.
5. Tạo một thể hiện của `StreamWriter` và thêm tệp HTML mới.
6. Cung cấp chỉ mục bắt đầu cho StreamWriter và xuất các đoạn ưa thích của bạn.

```c#
// Tải tệp bản trình chiếu
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Truy cập slide đầu tiên mặc định của bản trình chiếu
    ISlide slide = pres.Slides[0];

    // Truy cập chỉ mục cần thiết
    int index = 0;

    // Truy cập hình dạng đã thêm
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Ghi dữ liệu các đoạn vào HTML bằng cách chỉ định chỉ mục bắt đầu của đoạn và số lượng đoạn sẽ được sao chép
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Lưu Đoạn Văn dưới dạng Hình Ảnh**

Trong phần này, chúng ta sẽ khám phá hai ví dụ minh họa cách lưu một đoạn văn bản, được đại diện bởi giao diện [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) , dưới dạng hình ảnh. Cả hai ví dụ đều bao gồm việc lấy hình ảnh của một hình dạng chứa đoạn bằng các phương pháp `GetImage` từ giao diện [IShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/) , tính toán giới hạn của đoạn trong hình dạng và xuất ra dưới dạng hình bitmap. Những cách tiếp cận này cho phép bạn trích xuất các phần cụ thể của văn bản từ bản trình chiếu PowerPoint và lưu chúng dưới dạng hình ảnh riêng, hữu ích cho các tình huống sử dụng khác nhau.

Giả sử chúng ta có một tệp bản trình chiếu tên sample.pptx với một slide, trong đó hình dạng đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

**Example 1**

Trong ví dụ này, chúng ta lấy đoạn thứ hai dưới dạng hình ảnh. Để làm điều này, chúng ta trích xuất hình ảnh của hình dạng từ slide đầu tiên của bản trình chiếu, sau đó tính toán giới hạn của đoạn thứ hai trong khung văn bản của hình dạng. Đoạn sau đó được vẽ lại lên một hình bitmap mới, được lưu ở định dạng PNG. Phương pháp này đặc biệt hữu ích khi bạn cần lưu một đoạn cụ thể dưới dạng hình ảnh riêng while preserving the exact dimensions and formatting of the text.

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

![Hình ảnh đoạn](paragraph_to_image_output.png)

**Example 2**

Trong ví dụ này, chúng ta mở rộng cách tiếp cận trước đó bằng cách thêm các hệ số tỷ lệ vào hình ảnh đoạn. Hình dạng được trích xuất từ bản trình chiếu và lưu dưới dạng hình ảnh với hệ số tỷ lệ `2`. Điều này cho phép xuất ra độ phân giải cao hơn khi xuất đoạn. Giới hạn của đoạn sau đó được tính toán có xét đến tỷ lệ. Tăng tỷ lệ có thể đặc biệt hữu ích khi cần một hình ảnh chi tiết hơn, ví dụ để sử dụng trong tài liệu in chất lượng cao.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Lưu hình dạng trong bộ nhớ dưới dạng bitmap với tỷ lệ.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Tạo một bitmap hình dạng từ bộ nhớ.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Tính toán giới hạn của đoạn thứ hai.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Tính kích thước cho hình ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Chuẩn bị một bitmap cho đoạn văn.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Vẽ lại đoạn văn từ bitmap hình dạng sang bitmap đoạn.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong khung văn bản không?**

Có. Sử dụng cài đặt ngắt dòng của khung văn bản ([WrapText](https://reference.aspose.com/slides/vi/net/aspose.slides/textframeformat/wraptext/)) để tắt tính năng ngắt dòng, vì vậy các dòng sẽ không bị cắt ở các cạnh của khung.

**Làm sao tôi có thể lấy giới hạn chính xác trên slide của một đoạn cụ thể?**

Bạn có thể lấy hình chữ nhật bao quanh của đoạn (hoặc thậm chí của một phần riêng lẻ) để biết vị trí và kích thước chính xác của nó trên slide.

**Căn chỉnh đoạn (trái/phải/giữa/đều) được điều khiển ở đâu?**

[Alignment](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraphformat/alignment/) là cài đặt cấp đoạn trong [ParagraphFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/paragraphformat/); nó áp dụng cho toàn bộ đoạn bất kể định dạng của các phần riêng lẻ.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn (ví dụ, một từ) không?**

Có. Ngôn ngữ được đặt ở mức phần ([PortionFormat.LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/languageid/)), vì vậy nhiều ngôn ngữ có thể tồn tại trong cùng một đoạn.
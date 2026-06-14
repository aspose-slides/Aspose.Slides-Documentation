---
title: Quản lý các điều khiển ActiveX trong bản trình bày bằng .NET
linktitle: ActiveX
type: docs
weight: 80
url: /vi/net/activex/
keywords:
- ActiveX
- điều khiển ActiveX
- quản lý ActiveX
- thêm ActiveX
- sửa đổi ActiveX
- trình phát media
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách Aspose.Slides for .NET tận dụng ActiveX để tự động hóa và cải thiện các bản trình bày PowerPoint, cung cấp cho các nhà phát triển khả năng kiểm soát mạnh mẽ đối với các slide."
---
## **Giới thiệu**

Các điều khiển ActiveX được sử dụng trong các bản trình bày. Aspose.Slides for .NET cho phép bạn quản lý các điều khiển ActiveX, nhưng việc quản lý chúng hơi phức tạp hơn và khác so với các hình dạng thông thường trong bản trình bày. Từ Aspose.Slides for .NET 6.9.0, thành phần này hỗ trợ quản lý các điều khiển ActiveX. Hiện tại, bạn có thể truy cập các điều khiển ActiveX đã được thêm vào bản trình bày và sửa đổi hoặc xóa chúng bằng cách sử dụng các thuộc tính khác nhau. Lưu ý, các điều khiển ActiveX không phải là hình dạng và không thuộc IShapeCollection của bản trình bày mà nằm trong IControlCollection riêng biệt. Bài viết này giới thiệu cách làm việc với chúng.
## **Sửa đổi các điều khiển ActiveX**
Để quản lý một điều khiển ActiveX đơn giản như hộp văn bản và nút lệnh đơn giản trên một slide:

1. Tạo một thể hiện của lớp Presentation và tải bản trình bày có chứa các điều khiển ActiveX.
2. Lấy tham chiếu slide theo chỉ mục của nó.
3. Truy cập các điều khiển ActiveX trong slide bằng cách truy xuất IControlCollection.
4. Truy cập điều khiển ActiveX TextBox1 bằng đối tượng ControlEx.
5. Thay đổi các thuộc tính khác nhau của điều khiển ActiveX TextBox1 bao gồm văn bản, phông chữ, chiều cao phông và vị trí khung.
6. Truy cập điều khiển thứ hai có tên CommandButton1.
7. Thay đổi chú thích nút, phông chữ và vị trí.
8. Di chuyển vị trí của các khung điều khiển ActiveX.
9. Ghi bản trình bày đã sửa đổi vào tệp PPTX.

Đoạn mã dưới đây cập nhật các điều khiển ActiveX trên các slide của bản trình bày như được hiển thị bên dưới.

```c#
// Truy cập bản trình bày có các điều khiển ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Truy cập slide đầu tiên trong bản trình bày
ISlide slide = presentation.Slides[0];

// thay đổi văn bản TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // thay đổi hình ảnh thay thế. Powerpoint sẽ thay thế hình ảnh này khi kích hoạt ActiveX, vì vậy đôi khi có thể để nguyên hình ảnh.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// thay đổi chú thích nút
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // thay đổi hình ảnh thay thế
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Di chuyển khung ActiveX xuống 100 điểm
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Lưu bản trình bày với các điều khiển ActiveX đã chỉnh sửa
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Bây giờ loại bỏ các điều khiển
slide.Controls.Clear();

// Lưu bản trình bày với các điều khiển ActiveX đã xóa
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **Thêm một điều khiển Media Player ActiveX**
Để thêm điều khiển Media Player ActiveX, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp Presentation và tải bản mẫu có chứa các điều khiển Media Player ActiveX.
2. Tạo một thể hiện của lớp Presentation đích và tạo một bản trình bày trống.
3. Sao chép slide chứa điều khiển Media Player ActiveX từ bản mẫu sang Presentation đích.
4. Truy cập slide đã sao chép trong Presentation đích.
5. Truy cập các điều khiển ActiveX trong slide bằng cách truy xuất IControlCollection.
6. Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video bằng cách sử dụng các thuộc tính của nó.
7. Lưu bản trình bày vào tệp PPTX.

```c#
// Tạo thể hiện lớp Presentation đại diện cho tệp PPTX
Presentation presentation = new Presentation("template.pptx");

// Tạo một bản trình bày trống
Presentation newPresentation = new Presentation();

// Xóa slide mặc định
newPresentation.Slides.RemoveAt(0);

// Sao chép slide có điều khiển Media Player ActiveX
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Lưu bản trình bày
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Câu hỏi thường gặp**

**Aspose.Slides có giữ lại các điều khiển ActiveX khi đọc và lưu lại nếu chúng không thể được thực thi trong môi trường .NET không?**

Có. Aspose.Slides coi chúng là một phần của bản trình bày và có thể đọc/sửa đổi các thuộc tính và khung của chúng; không cần thực thi các điều khiển để giữ chúng lại.

**Các điều khiển ActiveX khác gì so với đối tượng OLE trong bản trình bày?**

Các điều khiển ActiveX là các điều khiển quản lý tương tác (nút, ô văn bản, media player), trong khi [OLE](/slides/vi/net/manage-ole/) đề cập đến các đối tượng ứng dụng nhúng (ví dụ: một bảng tính Excel). Chúng được lưu trữ và xử lý khác nhau và có mô hình thuộc tính riêng.

**Các sự kiện ActiveX và macro VBA có hoạt động nếu tệp đã được Aspose.Slides chỉnh sửa không?**

Aspose.Slides giữ nguyên markup và metadata hiện có; tuy nhiên, các sự kiện và macro chỉ chạy trong PowerPoint trên Windows khi bảo mật cho phép. Thư viện không thực thi VBA.
---
title: Quản lý các điều khiển ActiveX trong bản trình chiếu .NET
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
- trình phát phương tiện
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Chỉnh sửa hộp văn bản và nút ActiveX, cập nhật ảnh xem trước của điều khiển, và tái sử dụng một điều khiển Windows Media Player trong các bản trình chiếu PowerPoint bằng Aspose.Slides cho .NET."
---
## **Giới thiệu**

Các điều khiển ActiveX cung cấp cho một slide PowerPoint các yếu tố tương tác như hộp văn bản, nút lệnh và trình phát phương tiện. Aspose.Slides for .NET cung cấp các điều khiển của slide thông qua [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Sử dụng bộ sưu tập này để chỉnh sửa một điều khiển, di chuyển nó trên slide hoặc xóa nó.

## **Liệt kê các điều khiển ActiveX và các thuộc tính đã lưu**

Để kiểm tra một mẫu chưa quen, mở nó để đọc và duyệt qua các điều khiển trên mỗi slide. Ví dụ báo cáo số slide, tên điều khiển, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), và mỗi cặp khóa-giá trị trong [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Nó đọc bản trình chiếu mà không kích hoạt các điều khiển, gọi sự kiện hoặc macro, thay đổi giá trị, hoặc lưu tệp.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

Đầu ra đã chọn từ `ActiveX.pptm` hiển thị một hộp văn bản và một nút lệnh.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Một bộ sưu tập thuộc tính trống xuất hiện dưới dạng `[]`. Đối với các điều khiển sử dụng lưu trữ nhị phân, `Properties` có thể trả về `null`, được hiển thị dưới dạng `Properties unavailable`. Nếu bạn chỉ cần tên, hãy sử dụng [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) sau khi kiểm tra null. Báo cáo liệt kê các thuộc tính có sẵn trong bản trình chiếu. Một điều khiển có thể hỗ trợ các thuộc tính bổ sung tại thời gian chạy.

## **Chỉnh sửa các điều khiển ActiveX**

Ví dụ yêu cầu một bản trình chiếu có macro với một hộp văn bản có tên `TextBox1` và một nút lệnh có tên `CommandButton1` trên slide đầu tiên. Nó sử dụng [control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) để thay đổi giá trị hộp văn bản và chú thích nút. Mỗi điều khiển cũng có một bản xem trước tĩnh mà PowerPoint có thể hiển thị trước khi kích hoạt. Cung cấp một tệp PNG cho mỗi điều khiển hiển thị văn bản và giao diện đã cập nhật. Ví dụ gán các hình ảnh này thông qua [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

Ví dụ di chuyển mọi điều khiển trên slide đầu tiên xuống 100 điểm bằng cách thay đổi [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). Nó lưu bản trình chiếu đã chỉnh sửa ở định dạng PPTM, sau đó sử dụng [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) để lưu một bản sao thứ hai với toàn bộ các điều khiển ActiveX bị xóa khỏi slide đó.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```
## **Thêm điều khiển Media Player ActiveX**

Để tái sử dụng một điều khiển Windows Media Player đã cấu hình, bắt đầu với một mẫu mà slide đầu tiên chứa một trình phát có tên `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) sao chép toàn bộ slide vào một bản trình chiếu mới. Ví dụ đặt `URL` của trình phát trong [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) và lưu slide đã sao chép làm slide duy nhất trong đầu ra. Video vẫn ở ngoài, vì vậy chọn một đường dẫn mà trình phát có thể truy cập trong quá trình phát.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```
## **Câu hỏi thường gặp**

**Aspose.Slides có thể giữ nguyên các điều khiển ActiveX mà không chạy chúng không?**

Có. Aspose.Slides có thể đọc và lưu các điều khiển, bao gồm cả thuộc tính và vị trí của chúng, mà không kích hoạt chúng.

**Các điều khiển ActiveX khác biệt như thế nào so với đối tượng OLE?**

Các điều khiển ActiveX cho phép người dùng tương tác với slide, ví dụ nhập văn bản hoặc nhấp nút. Một [OLE object](/slides/vi/net/manage-ole/) cho phép slide chứa hoặc liên kết tới nội dung được quản lý bởi ứng dụng khác, như một bảng tính Excel.

**Các sự kiện ActiveX vẫn sẽ kích hoạt macro VBA sau khi tôi lưu bản trình chiếu bằng Aspose.Slides không?**

Lưu bản trình chiếu ở định dạng hỗ trợ macro như PPTM để giữ lại dự án VBA. PowerPoint cho Windows có thể chạy các trình xử lý sự kiện hiện có khi cài đặt bảo mật cho phép cả điều khiển ActiveX và macro.
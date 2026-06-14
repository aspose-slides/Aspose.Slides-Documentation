---
title: Quản lý các đối tượng OLE trong bài thuyết trình trên .NET
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/net/manage-ole/
keywords:
- đối tượng OLE
- Liên kết & Nhúng Đối tượng
- thêm OLE
- nhúng OLE
- thêm đối tượng
- nhúng đối tượng
- thêm tệp
- nhúng tệp
- đối tượng liên kết
- tệp liên kết
- thay đổi OLE
- biểu tượng OLE
- tiêu đề OLE
- trích xuất OLE
- trích xuất đối tượng
- trích xuất tệp
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tối ưu hóa việc quản lý đối tượng OLE trong các tệp PowerPoint và OpenDocument với Aspose.Slides cho .NET. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được đặt trong một ứng dụng khác thông qua liên kết hoặc nhúng. 

{{% /alert %}} 

Xem xét một biểu đồ được tạo trong MS Excel. Biểu đồ sau đó được đặt trong một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE. 

- Một đối tượng OLE có thể xuất hiện dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp vào biểu tượng, biểu đồ sẽ được mở trong ứng dụng liên quan (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng. 
- Một đối tượng OLE có thể hiển thị nội dung thực tế của nó, chẳng hạn như nội dung của một biểu đồ. Trong trường hợp này, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ tải lên và bạn có thể chỉnh sửa dữ liệu của biểu đồ ngay trong PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/vi/net/) cho phép bạn chèn OLE Objects vào slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe)).

## **Thêm Khung Đối Tượng OLE Vào Các Slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for .NET, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Đọc tệp Excel dưới dạng mảng byte.
4. Thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe) vào slide kèm theo mảng byte và các thông tin khác về đối tượng OLE.
5. Ghi bài trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ bên dưới, chúng tôi đã thêm một biểu đồ từ tệp Excel vào slide dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe) bằng Aspose.Slides for .NET.  
**Lưu ý** rằng hàm khởi tạo [OleEmbeddedDataInfo](https://reference.aspose.com/slides/vi/net/aspose.slides.dom.ole/oleembeddeddatainfo/) nhận một phần mở rộng đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint giải thích đúng loại tệp và chọn ứng dụng phù hợp để mở đối tượng OLE này.

```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Chuẩn bị dữ liệu cho đối tượng OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Thêm khung đối tượng OLE vào slide.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Thêm Khung Đối Tượng OLE Liên Kết**

Aspose.Slides for .NET cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe) mà không nhúng dữ liệu mà chỉ có liên kết tới tệp.

Mã C# này cho bạn thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe) với tệp Excel được liên kết vào slide:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Thêm khung đối tượng OLE với tệp Excel được liên kết.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Truy Cập Khung Đối Tượng OLE**

Nếu một đối tượng OLE đã được nhúng trong slide, bạn có thể dễ dàng tìm hoặc truy cập nó theo cách sau:

1. Tải một bài trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Lấy tham chiếu của slide bằng cách sử dụng chỉ số của nó.
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe). 
   Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước đó có chỉ một hình dạng trên slide đầu tiên. Sau đó chúng tôi *ép kiểu* đối tượng đó thành [IOleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe). Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập vào khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) và dữ liệu tệp của nó được truy cập.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lấy hình dạng đầu tiên dưới dạng khung đối tượng OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Lấy dữ liệu tệp được nhúng.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Lấy phần mở rộng của tệp được nhúng.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Truy Cập Thuộc Tính Khung Đối Tượng OLE Liên Kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE liên kết.

Mã C# này cho bạn thấy cách kiểm tra xem một đối tượng OLE có được liên kết không và sau đó lấy đường dẫn tới tệp được liên kết:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Lấy hình dạng đầu tiên dưới dạng khung đối tượng OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Kiểm tra xem đối tượng OLE có được liên kết hay không.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // In ra đường dẫn đầy đủ tới tệp được liên kết.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // In ra đường dẫn tương đối tới tệp được liên kết nếu có.
        // Chỉ các bản trình chiếu PPT mới có thể chứa đường dẫn tương đối.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Thay Đổi Dữ Liệu Đối Tượng OLE**

{{% alert color="primary" %}} 

Trong phần này, ví dụ mã bên dưới sử dụng [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó theo cách sau:

1. Tải một bài trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Truy cập hình dạng [OLEObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe). 
   Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước đó có một hình dạng trên slide đầu tiên. Sau đó chúng tôi *ép kiểu* đối tượng đó thành [IOleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe). Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập vào khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.
5. Tạo một đối tượng `Workbook` và truy cập dữ liệu OLE.
6. Truy cập `Worksheet` mong muốn và sửa đổi dữ liệu.
7. Lưu `Workbook` đã cập nhật vào một luồng.
8. Thay đổi dữ liệu đối tượng OLE từ luồng.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) được truy cập và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lấy hình dạng đầu tiên dưới dạng khung đối tượng OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Đọc dữ liệu đối tượng OLE dưới dạng đối tượng Workbook.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Sửa đổi dữ liệu workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Thay đổi dữ liệu đối tượng khung OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Nhúng Các Loại Tệp Khác Vào Slide**

Ngoài các biểu đồ Excel, Aspose.Slides for .NET cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được nhắc chọn chương trình phù hợp để mở.

Mã C# này cho bạn thấy cách nhúng HTML và ZIP vào slide:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Đặt Loại Tệp Cho Các Đối Tượng Được Nhúng**

Khi làm việc với các bài trình chiếu, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không hỗ trợ bằng một đối tượng hỗ trợ. Aspose.Slides for .NET cho phép bạn đặt loại tệp cho một đối tượng đã nhúng, giúp bạn cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Thay đổi loại tệp thành ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Đặt Hình Ảnh Icon và Tiêu Đề cho Các Đối Tượng Được Nhúng**

Sau khi nhúng một đối tượng OLE, một bản xem trước gồm hình ảnh biểu tượng sẽ được tự động thêm. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng hình ảnh và văn bản cụ thể làm phần tử trong bản xem trước, bạn có thể đặt hình ảnh biểu tượng và tiêu đề bằng Aspose.Slides for .NET.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Thêm hình ảnh vào tài nguyên của bài trình chiếu.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Đặt tiêu đề và hình ảnh cho bản xem trước OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ngăn Không Để Khung Đối Tượng OLE Bị Thay Đổi Kích Thước và Vị Trí**

Sau khi bạn thêm một đối tượng OLE liên kết vào slide, khi mở bài trình chiếu trong PowerPoint, bạn có thể thấy thông báo yêu cầu cập nhật liên kết. Nhấn nút "Update Links" có thể làm thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE liên kết và làm mới bản xem trước. Để ngăn PowerPoint yêu cầu cập nhật dữ liệu của đối tượng, đặt thuộc tính `UpdateAutomatic` của giao diện [IOleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe/) thành `false`:

```cs
oleFrame.UpdateAutomatic = false;
```

## **Trích Xuất Các Tệp Được Nhúng**

Aspose.Slides for .NET cho phép bạn trích xuất các tệp được nhúng trong slide dưới dạng đối tượng OLE theo cách sau:
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa các đối tượng OLE bạn muốn trích xuất.
2. Duyệt qua tất cả các hình dạng trong bài trình chiếu và truy cập các hình dạng [OLEObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe).
3. Truy cập dữ liệu của các tệp được nhúng từ khung đối tượng OLE và ghi chúng ra đĩa.

Mã C# này cho bạn thấy cách trích xuất các tệp được nhúng trong slide dưới dạng đối tượng OLE:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **Câu Hỏi Thường Gặp**

**Nội dung OLE có được hiển thị khi xuất slide sang PDF/hình ảnh không?**

Những gì hiển thị trên slide sẽ được render — biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE “sống” không được thực thi trong quá trình render. Nếu cần, hãy đặt hình ảnh preview riêng để đảm bảo giao diện mong muốn trong PDF xuất ra.

**Làm thế nào để khóa một đối tượng OLE trên slide để người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?**

Khóa hình dạng: Aspose.Slides cung cấp [shape-level locks](/slides/vi/net/applying-protection-to-presentation/). Đây không phải là mã hoá, nhưng thực sự ngăn ngừa việc chỉnh sửa và di chuyển vô tình.

**Tại sao đối tượng Excel liên kết lại “nhảy” hoặc thay đổi kích thước khi tôi mở bài trình chiếu?**

PowerPoint có thể làm mới bản xem trước của OLE liên kết. Để có giao diện ổn định, hãy thực hiện các thực hành trong [Working Solution for Worksheet Resizing](/slides/vi/net/working-solution-for-worksheet-resizing/) — hoặc vừa khít khung với phạm vi, hoặc tỷ lệ phạm vi vào khung cố định và đặt hình ảnh thay thế phù hợp.

**Các đường dẫn tương đối cho các đối tượng OLE liên kết có được giữ lại trong định dạng PPTX không?**

Trong PPTX, thông tin “đường dẫn tương đối” không tồn tại — chỉ có đường dẫn đầy đủ. Các đường dẫn tương đối chỉ có trong định dạng PPT cũ. Để di động, nên sử dụng đường dẫn tuyệt đối tin cậy/URI có thể truy cập hoặc nhúng.
---
title: Quản lý Đối tượng OLE trong Bản trình chiếu bằng .NET
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/net/manage-ole/
keywords:
- đối tượng OLE
- Liên kết & Nhúng đối tượng
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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tối ưu hóa quản lý đối tượng OLE trong các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được đưa vào ứng dụng khác thông qua việc liên kết hoặc nhúng. 

{{% /alert %}} 

Hãy xét một biểu đồ được tạo trong MS Excel. Biểu đồ này sau đó được đặt vào một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE. 

- Đối tượng OLE có thể hiển thị dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp vào biểu tượng, biểu đồ sẽ được mở trong ứng dụng liên kết (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng. 
- Đối tượng OLE có thể hiển thị nội dung thực tế của nó, chẳng hạn như nội dung của một biểu đồ. Khi đó, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ tải lên và bạn có thể chỉnh sửa dữ liệu biểu đồ ngay trong PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/vi/net/) cho phép bạn chèn các Đối tượng OLE vào slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe)).

## **Thêm Khung Đối Tượng OLE Vào Slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for .NET, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation). 
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó. 
3. Đọc tệp Excel dưới dạng mảng byte. 
4. Thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe) vào slide, bao gồm mảng byte và các thông tin khác về đối tượng OLE. 
5. Ghi bản trình chiếu đã sửa đổi thành tệp PPTX. 

Trong ví dụ dưới đây, chúng tôi đã thêm một biểu đồ từ tệp Excel vào slide dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe) bằng Aspose.Slides for .NET.  
**Lưu ý** rằng constructor của [OleEmbeddedDataInfo](https://reference.aspose.com/slides/vi/net/aspose.slides.dom.ole/oleembeddeddatainfo/) nhận phần mở rộng của đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này giúp PowerPoint giải thích đúng loại tệp và chọn ứng dụng phù hợp để mở đối tượng OLE này.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

Mã C# dưới đây cho thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe) với tệp Excel được liên kết vào một slide:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Thêm khung đối tượng OLE với tệp Excel được liên kết.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Truy Cập Khung Đối Tượng OLE**

Nếu một đối tượng OLE đã được nhúng vào slide, bạn có thể dễ dàng tìm hoặc truy cập nó bằng cách:

1. Tải bản trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation). 
2. Lấy tham chiếu tới slide bằng chỉ mục của nó. 
3. Truy cập shape [OleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe).  
   Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước có chỉ một shape trên slide đầu tiên. Sau đó *cast* đối tượng đó thành [IOleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe). Đây là khung đối tượng OLE mong muốn để truy cập. 
4. Khi đã truy cập được khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó. 

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) và dữ liệu tệp của nó được truy cập.

```csharp 
using Aspose.Slides;

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

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE được liên kết.

Mã C# dưới đây cho thấy cách kiểm tra xem một đối tượng OLE có được liên kết hay không và sau đó lấy đường dẫn tới tệp liên kết:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Lấy hình dạng đầu tiên dưới dạng khung đối tượng OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Kiểm tra xem đối tượng OLE có được liên kết hay không.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // In ra đường dẫn đầy đủ đến tệp được liên kết.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // In ra đường dẫn tương đối đến tệp được liên kết nếu có.
        // Chỉ các bản trình chiếu PPT mới có thể chứa đường dẫn tương đối.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Thay Đổi Dữ Liệu Đối Tượng OLE**

{{% alert color="info" %}} 

Trong phần này, ví dụ mã dưới đây sử dụng [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng vào slide, bạn có thể dễ dàng truy cập và sửa đổi dữ liệu của đối tượng đó như sau:

1. Tải bản trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation). 
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó. 
3. Truy cập shape [OLEObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe).  
   Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước có một shape trên slide đầu tiên. Sau đó *cast* đối tượng đó thành [IOleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe). Đây là khung đối tượng OLE mong muốn để truy cập. 
4. Khi đã truy cập được khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó. 
5. Tạo một đối tượng `Workbook` và truy cập dữ liệu OLE. 
6. Truy cập `Worksheet` mong muốn và sửa đổi dữ liệu. 
7. Lưu `Workbook` đã cập nhật vào một stream. 
8. Thay đổi dữ liệu đối tượng OLE từ stream. 

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) được truy cập và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Sửa đổi dữ liệu workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
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

Ngoài biểu đồ Excel, Aspose.Slides for .NET cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được nhắc chọn chương trình thích hợp để mở.

Mã C# dưới đây cho thấy cách nhúng HTML và ZIP vào một slide:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

## **Đặt Kiểu Tệp Cho Các Đối Tượng Được Nhúng**

Khi làm việc với bản trình chiếu, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không được hỗ trợ bằng một đối tượng được hỗ trợ. Aspose.Slides for .NET cho phép bạn đặt kiểu tệp cho một đối tượng được nhúng, giúp bạn cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Mã C# dưới đây cho thấy cách đặt kiểu tệp cho một đối tượng OLE được nhúng thành `zip`:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

## **Đặt Hình Ảnh Biểu Tượng và Tiêu Đề Cho Các Đối Tượng Được Nhúng**

Sau khi nhúng một đối tượng OLE, một bản xem trước gồm hình ảnh biểu tượng được thêm tự động. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng hình ảnh và văn bản cụ thể làm các yếu tố trong bản xem trước, bạn có thể đặt hình ảnh biểu tượng và tiêu đề bằng Aspose.Slides for .NET.

Mã C# dưới đây cho thấy cách đặt hình ảnh biểu tượng và tiêu đề cho một đối tượng đã nhúng: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Thêm một hình ảnh vào tài nguyên của bản trình chiếu.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Đặt tiêu đề và hình ảnh cho bản xem trước OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Ngăn Khung Đối Tượng OLE Bị Thay Đổi Kích Thước và Vị Trí**

Sau khi bạn thêm một đối tượng OLE được liên kết vào slide của bản trình chiếu, khi mở bản trình chiếu trong PowerPoint, bạn có thể thấy thông báo yêu cầu cập nhật liên kết. Nhấn nút "Update Links" có thể làm thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE được liên kết và làm mới bản xem trước của đối tượng. Để ngăn PowerPoint nhắc cập nhật dữ liệu của đối tượng, đặt thuộc tính `UpdateAutomatic` của giao diện [IOleObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleobjectframe/) thành `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Giữ nguyên kích thước và vị trí của khung đối tượng OLE khi PowerPoint cập nhật liên kết.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Trích Xuất Các Tệp Được Nhúng**

Aspose.Slides for .NET cho phép bạn trích xuất các tệp được nhúng trong slide dưới dạng đối tượng OLE như sau:
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) chứa các đối tượng OLE bạn muốn trích xuất. 
2. Duyệt qua tất cả các shape trong bản trình chiếu và truy cập các shape [OLEObjectFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/oleobjectframe). 
3. Truy cập dữ liệu của các tệp được nhúng từ khung đối tượng OLE và ghi chúng ra đĩa. 

Mã C# dưới đây cho thấy cách trích xuất các tệp được nhúng trong một slide dưới dạng đối tượng OLE:

```c#
using Aspose.Slides;

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

### Nội dung OLE có được hiển thị khi xuất slide sang PDF/hình ảnh không?

Những gì hiển thị trên slide sẽ được render — tức là biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE “sống” không được thực thi trong quá trình render. Nếu cần, hãy đặt hình ảnh xem trước riêng để đảm bảo hiển thị mong muốn trong PDF đã xuất.

### Làm sao để khóa một đối tượng OLE trên slide để người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?

Khóa shape: Aspose.Slides cung cấp [khóa ở mức shape](/slides/vi/net/applying-protection-to-presentation/). Đây không phải là mã hoá, nhưng thực sự ngăn việc chỉnh sửa hoặc di chuyển không mong muốn.

### Tại sao một đối tượng Excel được liên kết “nhảy” hoặc thay đổi kích thước khi tôi mở bản trình chiếu?

PowerPoint có thể làm mới bản xem trước của OLE được liên kết. Để có giao diện ổn định, hãy tuân thủ các thực hành trong [Giải Pháp Làm Việc cho Việc Thay Đổi Kích Thước Worksheet](/slides/vi/net/working-solution-for-worksheet-resizing/) — hoặc điều chỉnh khung cho phù hợp với vùng, hoặc tỷ lệ vùng vào khung cố định và đặt một hình ảnh thay thế phù hợp.

### Các đường dẫn tương đối cho các đối tượng OLE được liên kết có được giữ lại trong định dạng PPTX không?

Trong PPTX, thông tin “đường dẫn tương đối” không tồn tại — chỉ có đường dẫn đầy đủ. Các đường dẫn tương đối chỉ có trong định dạng PPT cũ. Để di động, nên sử dụng đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng trực tiếp.
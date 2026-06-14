---
title: "Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX"
type: docs
weight: 60
url: /vi/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- "thay đổi kích thước biểu đồ"
- "biểu đồ Excel"
- "đối tượng OLE"
- "nhúng biểu đồ"
- PowerPoint
- "bản trình chiếu"
- .NET
- C#
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng đối tượng OLE Excel được nhúng với Aspose.Slides cho .NET. Tìm hiểu hai phương pháp có mã nguồn để giữ kích thước nhất quán."
---
## **Bối cảnh**

Đã được ghi nhận rằng các biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint thông qua các thành phần Aspose bị thay đổi kích thước theo một tỷ lệ không xác định sau lần kích hoạt đầu tiên. Điều này gây ra sự khác biệt về hình ảnh đáng chú ý trong bản trình chiếu giữa trạng thái trước và sau khi kích hoạt biểu đồ. Đội ngũ Aspose đã khảo sát chi tiết vấn đề và tìm ra giải pháp. Bài viết này mô tả nguyên nhân của vấn đề và cách khắc phục tương ứng.

Trong [bài viết trước](/slides/vi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo biểu đồ Excel bằng Aspose.Cells cho .NET và nhúng nó trong bản trình chiếu PowerPoint bằng Aspose.Slides cho .NET. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/net/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán hình ảnh biểu đồ cho khung đối tượng OLE của biểu đồ. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh biểu đồ, biểu đồ Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trong workbook Excel nền và sau đó quay lại slide tương ứng bằng cách nhấp ra ngoài workbook đã kích hoạt. Kích thước của khung đối tượng OLE thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước khác nhau tùy thuộc vào kích thước gốc của cả khung OLE và workbook Excel được nhúng.

## **Nguyên nhân gây thay đổi kích thước**

Vì workbook Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước gốc khi được kích hoạt lần đầu. Tuy nhiên, khung đối tượng OLE có kích thước riêng của nó. Theo Microsoft, khi workbook Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước và duy trì tỉ lệ đúng như một phần của quá trình nhúng. Tùy thuộc vào sự chênh lệch giữa kích thước cửa sổ Excel và kích thước hoặc vị trí của khung đối tượng OLE, việc thay đổi kích thước sẽ xảy ra.

## **Giải pháp hoạt động**

Có hai kịch bản khả thi để tạo bản trình chiếu PowerPoint bằng Aspose.Slides cho .NET.

**Kịch bản 1:** Tạo bản trình chiếu dựa trên mẫu có sẵn.

**Kịch bản 2:** Tạo bản trình chiếu từ đầu.

Giải pháp chúng tôi cung cấp ở đây áp dụng cho cả hai kịch bản. Cơ sở của tất cả các cách tiếp cận giải pháp là như nhau: **kích thước cửa sổ của đối tượng OLE được nhúng phải khớp với khung OLE trong slide PowerPoint**. Tiếp theo, chúng tôi sẽ thảo luận hai cách tiếp cận cho giải pháp này.

## **Cách tiếp cận đầu tiên**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước cửa sổ của workbook Excel được nhúng sao cho khớp với kích thước của khung OLE trong slide PowerPoint.

**Kịch bản 1**

Giả sử chúng ta đã định nghĩa một mẫu và muốn tạo bản trình chiếu dựa trên nó. Giả định có một hình dạng ở chỉ mục 2 trong mẫu mà chúng ta muốn đặt một khung OLE chứa workbook Excel được nhúng. Trong kịch bản này, kích thước của khung đối tượng OLE được định sẵn — nó khớp với kích thước của hình dạng ở chỉ mục 2 trong mẫu. Tất cả chúng ta cần làm là đặt kích thước cửa sổ của workbook bằng với kích thước của hình dạng đó. Đoạn mã sau thực hiện mục đích này:

```cs
// Xác định kích thước biểu đồ bằng một cửa sổ. 
// Đặt chiều rộng cửa sổ của workbook tính bằng inch (chia cho 72 vì PowerPoint sử dụng 72 pixel mỗi inch).
// Đặt chiều cao cửa sổ của workbook tính bằng inch.
// Lưu workbook vào một luồng bộ nhớ.
chart.SizeWithWindow = true;

// Set the window width of the workbook in inches (divided by 72 as PowerPoint uses 72 pixels per inch).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Set the window height of the workbook in inches.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Save the workbook to a memory stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Create an OLE object frame with the embedded Excel data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Kịch bản 2**

Giả sử chúng ta muốn tạo một bản trình chiếu từ đầu và bao gồm một khung OLE có kích thước bất kỳ với workbook Excel được nhúng. Trong đoạn mã sau, chúng ta tạo một khung đối tượng OLE cao 4 inch và rộng 9.5 inch tại x = 0.5 inch và y = 1 inch trên slide. Sau đó chúng ta đặt cửa sổ workbook Excel cùng kích thước — cao 4 inch và rộng 9.5 inch.

```cs
// Chiều cao mong muốn của chúng tôi.
int desiredHeight = 288; // 4 inch (4 * 72)

// Chiều rộng mong muốn của chúng tôi.
int desiredWidth = 684;//9.5 inch (9.5 * 72)

// Xác định kích thước biểu đồ bằng một cửa sổ.
chart.SizeWithWindow = true;

// Đặt chiều rộng cửa sổ của workbook tính bằng inch.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Đặt chiều cao cửa sổ của workbook tính bằng inch.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Lưu workbook vào một luồng bộ nhớ.
MemoryStream workbookStream = workbook.SaveToStream();

// Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Cách tiếp cận thứ hai**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước của biểu đồ trong workbook Excel sao cho khớp với kích thước của khung OLE trong slide PowerPoint. Cách tiếp cận này hữu ích khi kích thước biểu đồ đã biết trước và sẽ không thay đổi.

**Kịch bản 1**

Giả sử chúng ta đã định nghĩa một mẫu và muốn tạo bản trình chiếu dựa trên nó. Giả định có một hình dạng ở chỉ mục 2 trong mẫu mà chúng ta dự định đặt một khung OLE chứa workbook Excel được nhúng. Trong kịch bản này, kích thước khung OLE được định sẵn — khớp với kích thước của hình dạng ở chỉ mục 2 trong mẫu. Tất cả chúng ta cần làm là đặt kích thước biểu đồ trong workbook bằng với kích thước của hình dạng đó. Đoạn mã sau thực hiện mục đích này:

```cs
// Xác định kích thước biểu đồ mà không có cửa sổ. 
chart.SizeWithWindow = false;

// Đặt chiều rộng biểu đồ tính bằng pixel (nhân với 96 vì Excel sử dụng 96 pixel mỗi inch).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Đặt chiều cao biểu đồ tính bằng pixel.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Xác định kích thước in của biểu đồ.
chart.PrintSize = PrintSizeType.Custom;

// Lưu workbook vào một luồng bộ nhớ.
MemoryStream workbookStream = workbook.SaveToStream();

// Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Kịch bản 2**

Giả sử chúng ta muốn tạo một bản trình chiếu từ đầu và bao gồm một khung OLE có kích thước bất kỳ với workbook Excel được nhúng. Trong đoạn mã sau, chúng ta tạo một khung đối tượng OLE cao 4 inch và rộng 9.5 inch trên slide tại x = 0.5 inch và y = 1 inch. Chúng ta cũng đặt kích thước biểu đồ tương ứng cùng kích thước: cao 4 inch và rộng 9.5 inch.

```cs
 // Chiều cao mong muốn.
int desiredHeight = 288; // 4 inch (4 * 576)

// Chiều rộng mong muốn.
int desiredWidth = 684; // 9.5 inch (9.5 * 576)

// Xác định kích thước biểu đồ mà không có cửa sổ. 
chart.SizeWithWindow = false;

// Đặt chiều rộng biểu đồ tính bằng pixel.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Đặt chiều cao biểu đồ tính bằng pixel.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Lưu workbook vào một luồng bộ nhớ.
MemoryStream workbookStream = workbook.SaveToStream();

// Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Kết luận**

Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước biểu đồ. Lựa chọn cách tiếp cận phụ thuộc vào yêu cầu và trường hợp sử dụng. Cả hai cách đều hoạt động tương tự cho dù bản trình chiếu được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào đối với kích thước của khung OLE trong giải pháp này.

## **Câu hỏi thường gặp**

**Tại sao biểu đồ Excel được nhúng của tôi lại thay đổi kích thước sau khi kích hoạt trong PowerPoint?**  
Điều này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ gốc khi được kích hoạt lần đầu, trong khi khung OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỉ lệ, điều này có thể gây ra việc thay đổi kích thước.

**Có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**  
Có. Bằng cách khớp kích thước cửa sổ workbook Excel hoặc kích thước biểu đồ với kích thước khung OLE trước khi nhúng, bạn có thể giữ cho kích thước biểu đồ luôn nhất quán.

**Tôi nên chọn cách tiếp cận nào, thiết lập kích thước cửa sổ workbook hay thiết lập kích thước biểu đồ?**  
Sử dụng **Approach 1 (window size)** nếu bạn muốn duy trì tỉ lệ của workbook và có khả năng cho phép thay đổi kích thước sau này.  
Sử dụng **Approach 2 (chart size)** nếu kích thước biểu đồ đã cố định và sẽ không thay đổi sau khi nhúng.

**Các phương pháp này có hoạt động với cả bản trình chiếu dựa trên mẫu và bản trình chiếu mới không?**  
Có. Cả hai cách tiếp cận đều hoạt động tương tự cho bản trình chiếu được tạo từ mẫu và từ đầu.

**Có giới hạn nào cho kích thước của khung đối tượng OLE không?**  
Không. Bạn có thể đặt khung OLE ở bất kỳ kích thước nào miễn là nó được tỷ lệ hợp lý với kích thước workbook hoặc biểu đồ.

**Tôi có thể sử dụng các phương pháp này với biểu đồ được tạo trong các chương trình bảng tính khác không?**  
Các ví dụ được thiết kế cho biểu đồ Excel tạo bằng Aspose.Cells, nhưng nguyên tắc áp dụng cho các chương trình bảng tính tương thích OLE khác miễn là chúng hỗ trợ các tùy chọn kích thước tương tự.

## **Các phần liên quan**

- [Tạo biểu đồ Excel và nhúng chúng dưới dạng OLE trong bản trình chiếu](/slides/vi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Cập nhật đối tượng OLE tự động bằng Add-In PowerPoint](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
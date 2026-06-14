---
title: Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX
type: docs
weight: 40
url: /vi/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- thay đổi kích thước biểu đồ
- biểu đồ Excel
- đối tượng OLE
- nhúng biểu đồ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Sửa lỗi thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng các đối tượng OLE Excel được nhúng với Aspose.Slides cho Java. Tìm hiểu hai phương pháp với mã để giữ kích thước nhất quán."
---
## **Bối cảnh**

Đã được nhận thấy rằng các biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint thông qua các thành phần Aspose bị thay đổi kích thước thành tỉ lệ không xác định sau khi kích hoạt lần đầu. Hành vi này gây ra sự khác biệt trực quan đáng chú ý trong bản trình chiếu giữa trạng thái trước và sau khi kích hoạt biểu đồ. Nhóm Aspose đã điều tra vấn đề chi tiết và đã tìm ra giải pháp. Bài viết này mô tả nguyên nhân của vấn đề và cách khắc phục tương ứng.

Trong [bài viết trước](/slides/vi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo biểu đồ Excel với Aspose.Cells cho Java và nhúng nó vào bản trình chiếu PowerPoint bằng Aspose.Slides cho Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán hình ảnh biểu đồ cho khung đối tượng OLE của biểu đồ. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh biểu đồ, biểu đồ Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trong sổ làm việc Excel nền và sau đó quay lại slide tương ứng bằng cách nhấp ra ngoài sổ làm việc đã kích hoạt. Kích thước của khung đối tượng OLE thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước phụ thuộc vào kích thước ban đầu của cả khung đối tượng OLE và sổ làm việc Excel được nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ lại kích thước gốc khi kích hoạt lần đầu. Tuy nhiên, khung đối tượng OLE có kích thước riêng của nó. Theo Microsoft, khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thỏa thuận về kích thước và duy trì tỉ lệ đúng như một phần của quá trình nhúng. Tùy thuộc vào sự khác biệt giữa kích thước cửa sổ Excel và kích thước hoặc vị trí của khung đối tượng OLE, việc thay đổi kích thước sẽ xảy ra.

## **Giải pháp**

Có hai kịch bản có thể cho việc tạo bản trình chiếu PowerPoint bằng Aspose.Slides cho Java.

**Scenario 1:** Tạo bản trình chiếu dựa trên mẫu hiện có.

**Scenario 2:** Tạo bản trình chiếu từ đầu.

Giải pháp chúng tôi cung cấp ở đây áp dụng cho cả hai kịch bản. Cơ sở của tất cả các cách tiếp cận giải pháp là giống nhau: **kích thước cửa sổ của đối tượng OLE được nhúng phải khớp với khung đối tượng OLE trong slide PowerPoint**. Tiếp theo, chúng tôi sẽ thảo luận về hai cách tiếp cận cho giải pháp này.

## **Cách tiếp cận thứ nhất**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước cửa sổ của sổ làm việc Excel được nhúng sao cho nó khớp với kích thước của khung đối tượng OLE trong slide PowerPoint.

**Scenario 1**

Giả sử chúng ta đã xác định một mẫu và muốn tạo bản trình chiếu dựa trên nó. Giả định có một hình dạng ở chỉ mục 2 trong mẫu nơi chúng ta muốn đặt khung OLE chứa sổ làm việc Excel được nhúng. Trong kịch bản này, kích thước của khung đối tượng OLE đã được định trước — nó khớp với kích thước của hình dạng ở chỉ mục 2 trong mẫu. Tất cả những gì chúng ta cần làm là đặt kích thước cửa sổ của sổ làm việc bằng kích thước của hình dạng đó. Đoạn mã sau thực hiện mục đích này:

```java
// Đặt chiều rộng cửa sổ của sổ làm việc tính bằng inch (chia cho 576 vì PowerPoint sử dụng 576 pixel mỗi inch).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Đặt chiều cao cửa sổ của sổ làm việc tính bằng inch.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Lưu sổ làm việc vào một luồng bộ nhớ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**

Giả sử chúng ta muốn tạo một bản trình chiếu từ đầu và bao gồm một khung đối tượng OLE có kích thước bất kỳ kèm theo sổ làm việc Excel được nhúng. Trong đoạn mã sau, chúng ta tạo một khung đối tượng OLE cao 4 inch và rộng 9.5 inch tại x = 0.5 inch và y = 1 inch trên slide. Sau đó chúng ta đặt cửa sổ sổ làm việc Excel cùng kích thước — cao 4 inch và rộng 9.5 inch.

```java
// Chiều cao mong muốn.
int desiredHeight = 288; // 4 inch (4 * 72)
 
// Chiều rộng mong muốn.
int desiredWidth = 684; // 9.5 inch (9.5 * 72)
 
// Định nghĩa kích thước biểu đồ với cửa sổ.
chart.setSizeWithWindow(true);
 
// Đặt chiều rộng cửa sổ của sổ làm việc tính bằng inch (chia cho 576 vì PowerPoint sử dụng 576 pixel mỗi inch).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Đặt chiều cao cửa sổ của sổ làm việc tính bằng inch.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Lưu sổ làm việc vào một luồng bộ nhớ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Cách tiếp cận thứ hai**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước của biểu đồ trong sổ làm việc Excel được nhúng sao cho nó khớp với kích thước của khung đối tượng OLE trong slide PowerPoint. Cách tiếp cận này hữu ích khi kích thước biểu đồ đã biết trước và sẽ không bao giờ thay đổi.

**Scenario 1**

Giả sử chúng ta đã xác định một mẫu và muốn tạo bản trình chiếu dựa trên nó. Giả định có một hình dạng ở chỉ mục 2 trong mẫu nơi chúng ta dự định đặt khung OLE chứa sổ làm việc Excel được nhúng. Trong kịch bản này, kích thước khung OLE đã được định trước — khớp với kích thước của hình dạng ở chỉ mục 2 trong mẫu. Tất cả những gì chúng ta cần làm là đặt kích thước biểu đồ trong sổ làm việc bằng kích thước của hình dạng đó. Đoạn mã sau thực hiện mục đích này:

```java
// Định nghĩa kích thước biểu đồ mà không có cửa sổ.
chart.setSizeWithWindow(false);
 
// Đặt chiều rộng biểu đồ tính bằng pixel (nhân với 96 vì Excel sử dụng 96 pixel mỗi inch).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Đặt chiều cao biểu đồ tính bằng pixel.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Định nghĩa kích thước in của biểu đồ.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Lưu sổ làm việc vào một luồng bộ nhớ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**

Giả sử chúng ta muốn tạo một bản trình chiếu từ đầu và bao gồm một khung đối tượng OLE có kích thước bất kỳ kèm theo sổ làm việc Excel được nhúng. Trong đoạn mã sau, chúng ta tạo một khung đối tượng OLE có chiều cao 4 inch và chiều rộng 9.5 inch trên slide tại x = 0.5 inch và y = 1 inch. Chúng ta cũng đặt kích thước biểu đồ tương ứng cùng kích thước: chiều cao 4 inch và chiều rộng 9.5 inch.

```java
// Chiều cao mong muốn.
int desiredHeight = 288; // 4 inch (4 * 72)
 
// Chiều rộng mong muốn.
int desiredWidth = 684; // 9.5 inch (9.5 * 72)
 
// Định nghĩa kích thước biểu đồ mà không có cửa sổ.
chart.setSizeWithWindow(false);
 
// Đặt chiều rộng biểu đồ tính bằng pixel (nhân với 96 vì Excel sử dụng 96 pixel mỗi inch).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Đặt chiều cao biểu đồ tính bằng pixel.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Lưu sổ làm việc vào một luồng bộ nhớ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Kết luận**

Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước biểu đồ. Lựa chọn cách tiếp cận phụ thuộc vào yêu cầu và trường hợp sử dụng. Cả hai cách đều hoạt động tương tự cho dù bản trình chiếu được tạo từ mẫu hay tạo từ đầu. Ngoài ra, không có giới hạn nào cho kích thước của khung đối tượng OLE trong giải pháp này.

## **FAQ**

**Tại sao biểu đồ Excel được nhúng của tôi lại thay đổi kích thước sau khi kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ gốc khi được kích hoạt lần đầu, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel sẽ thỏa thuận kích thước để duy trì tỉ lệ, điều này có thể gây ra việc thay đổi kích thước.

**Có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**

Có. Bằng cách khớp kích thước cửa sổ sổ làm việc Excel hoặc kích thước biểu đồ với kích thước khung đối tượng OLE trước khi nhúng, bạn có thể giữ cho kích thước biểu đồ nhất quán.

**Tôi nên chọn cách nào, đặt kích thước cửa sổ sổ làm việc hay đặt kích thước biểu đồ?**

Sử dụng **Approach 1 (window size)** nếu bạn muốn duy trì tỉ lệ của sổ làm việc và có thể cho phép thay đổi kích thước sau này.  
Sử dụng **Approach 2 (chart size)** nếu kích thước biểu đồ cố định và sẽ không thay đổi sau khi nhúng.

**Các phương pháp này có hoạt động với cả bản trình chiếu dựa trên mẫu và bản trình chiếu mới không?**

Có. Cả hai cách tiếp cận đều hoạt động tương tự cho các bản trình chiếu được tạo từ mẫu và từ đầu.

**Có giới hạn nào cho kích thước khung đối tượng OLE không?**

Không. Bạn có thể đặt khung OLE ở bất kỳ kích thước nào miễn là nó tỷ lệ phù hợp với kích thước của sổ làm việc hoặc biểu đồ.

**Tôi có thể sử dụng các phương pháp này với biểu đồ tạo bằng các chương trình bảng tính khác không?**

Các ví dụ được thiết kế cho biểu đồ Excel tạo bằng Aspose.Cells, nhưng nguyên tắc áp dụng cho các chương trình bảng tính tương thích OLE khác miễn là chúng hỗ trợ các tùy chọn kích thước tương tự.

## **Phần liên quan**

- [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình chiếu](/slides/vi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Cập nhật đối tượng OLE tự động bằng Add-In PowerPoint](/slides/vi/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
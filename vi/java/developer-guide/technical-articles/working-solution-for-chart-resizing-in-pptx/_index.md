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
description: "Sửa lỗi thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng các đối tượng OLE Excel nhúng với Aspose.Slides cho Java. Tìm hiểu hai phương pháp với mã để giữ kích thước nhất quán."
---
## **Bối cảnh**

Đã được ghi nhận rằng các biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint thông qua các thành phần Aspose sẽ bị thay đổi tỷ lệ kích thước sau lần kích hoạt đầu tiên. Hành vi này gây ra sự khác biệt về hình ảnh đáng chú ý trong bản trình chiếu giữa trạng thái trước và sau khi kích hoạt biểu đồ. Nhóm Aspose đã điều tra chi tiết vấn đề và tìm ra giải pháp. Bài viết này mô tả nguyên nhân của vấn đề và cách khắc phục tương ứng.

Trong [bài viết trước](/slides/vi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo biểu đồ Excel bằng Aspose.Cells for Java và nhúng nó vào bản trình chiếu PowerPoint bằng Aspose.Slides for Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán hình ảnh biểu đồ cho khung đối tượng OLE của biểu đồ. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh biểu đồ, biểu đồ Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trong sổ làm việc Excel nền và sau đó quay lại slide tương ứng bằng cách nhấp ra ngoài sổ làm việc đã kích hoạt. Kích thước của khung đối tượng OLE thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước phụ thuộc vào kích thước gốc của cả khung đối tượng OLE và sổ làm việc Excel được nhúng.

## **Nguyên nhân gây ra việc thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước ban đầu khi lần kích hoạt đầu tiên. Tuy nhiên, khung đối tượng OLE cũng có kích thước riêng. Theo Microsoft, khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước và duy trì tỷ lệ đúng như một phần của quá trình nhúng. Tùy thuộc vào sự khác biệt giữa kích thước cửa sổ Excel và kích thước hoặc vị trí của khung đối tượng OLE, việc thay đổi kích thước sẽ xảy ra.

## **Giải pháp hoạt động**

Có hai kịch bản khả thi để tạo bản trình chiếu PowerPoint bằng Aspose.Slides for Java.

**Kịch bản 1:** Tạo bản trình chiếu dựa trên mẫu hiện có.

**Kịch bản 2:** Tạo bản trình chiếu từ đầu.

Giải pháp chúng tôi cung cấp ở đây áp dụng cho cả hai kịch bản. Cơ sở của mọi cách tiếp cận giải pháp đều giống nhau: **kích thước cửa sổ của đối tượng OLE được nhúng phải khớp với khung đối tượng OLE trong slide PowerPoint**. Bây giờ chúng ta sẽ thảo luận hai cách tiếp cận cho giải pháp này.

## **Cách tiếp cận thứ nhất**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước cửa sổ của sổ làm việc Excel được nhúng sao cho nó khớp với kích thước của khung đối tượng OLE trong slide PowerPoint.

**Kịch bản 1**

Giả sử chúng ta đã định nghĩa một mẫu và muốn tạo bản trình chiếu dựa trên nó. Giả sử có một hình dạng tại chỉ mục 2 trong mẫu nơi chúng ta muốn đặt một khung OLE chứa sổ làm việc Excel được nhúng. Trong kịch bản này, kích thước của khung đối tượng OLE đã được xác định trước—nó khớp với kích thước của hình dạng tại chỉ mục 2 trong mẫu. Điều chúng ta cần làm là đặt kích thước cửa sổ của sổ làm việc bằng kích thước của hình dạng đó. Đoạn mã sau thực hiện mục đích này:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Đặt độ rộng cửa sổ của sổ làm việc bằng inch (chia cho 72 vì PowerPoint sử dụng 72 điểm mỗi inch).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Đặt độ cao cửa sổ của sổ làm việc bằng inch.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Lưu sổ làm việc vào một luồng bộ nhớ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Kịch bản 2**

Giả sử chúng ta muốn tạo một bản trình chiếu từ đầu và bao gồm một khung đối tượng OLE có kích thước bất kỳ với sổ làm việc Excel được nhúng. Trong đoạn mã sau, chúng ta tạo một khung đối tượng OLE cao 4 inch và rộng 9.5 inch tại x = 0.5 inch và y = 1 inch trên slide. Sau đó chúng ta đặt cửa sổ sổ làm việc Excel cùng kích thước—cao 4 inch và rộng 9.5 inch.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Chiều cao mong muốn của chúng tôi.
int desiredHeight = 288; // 4 inch (4 * 72)

// Chiều rộng mong muốn của chúng tôi.
int desiredWidth = 684; // 9.5 inch (9.5 * 72)

// Xác định kích thước biểu đồ với cửa sổ.
chart.setSizeWithWindow(true);

// Đặt độ rộng cửa sổ của sổ làm việc bằng inch (chia cho 72 vì PowerPoint sử dụng 72 điểm mỗi inch).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);

// Đặt độ cao cửa sổ của sổ làm việc bằng inch.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);

// Lưu sổ làm việc vào một luồng bộ nhớ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 inch (0.5 * 72)
    72,  // y = 1 inch (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Cách tiếp cận thứ hai**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước biểu đồ trong sổ làm việc Excel được nhúng sao cho nó khớp với kích thước của khung đối tượng OLE trong slide PowerPoint. Cách tiếp cận này hữu ích khi kích thước biểu đồ đã được biết trước và sẽ không thay đổi.

**Kịch bản 1**

Giả sử chúng ta đã định nghĩa một mẫu và muốn tạo bản trình chiếu dựa trên nó. Giả sử có một hình dạng tại chỉ mục 2 trong mẫu nơi chúng ta dự định đặt một khung OLE chứa sổ làm việc Excel được nhúng. Trong kịch bản này, kích thước khung OLE đã được xác định trước—khớp với kích thước của hình dạng tại chỉ mục 2 trong mẫu. Điều chúng ta cần làm là đặt kích thước biểu đồ trong sổ làm việc bằng kích thước của hình dạng đó. Đoạn mã sau thực hiện mục đích này:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Xác định kích thước biểu đồ mà không có cửa sổ.
chart.setSizeWithWindow(false);
 
// Đặt độ rộng của biểu đồ tính bằng pixel (nhân với 96 vì Excel sử dụng 96 pixel mỗi inch).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Đặt độ cao của biểu đồ tính bằng pixel.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Xác định kích thước in của biểu đồ.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Lưu sổ làm việc vào một luồng bộ nhớ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Kịch bản 2**:

Giả sử chúng ta muốn tạo một bản trình chiếu từ đầu và bao gồm một khung đối tượng OLE có kích thước bất kỳ với sổ làm việc Excel được nhúng. Trong đoạn mã sau, chúng ta tạo một khung đối tượng OLE có chiều cao 4 inch và chiều rộng 9.5 inch trên slide tại x = 0.5 inch và y = 1 inch. Chúng ta cũng đặt kích thước biểu đồ tương ứng cùng kích thước: chiều cao 4 inch và chiều rộng 9.5 inch.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Chiều cao mong muốn của chúng tôi.
int desiredHeight = 288; // 4 inch (4 * 72)
 
// Chiều rộng mong muốn của chúng tôi.
int desiredWidth = 684; // 9.5 inch (9.5 * 72)
 
// Xác định kích thước biểu đồ mà không có cửa sổ.
chart.setSizeWithWindow(false);
 
// Đặt độ rộng của biểu đồ tính bằng pixel (chia cho 72 để lấy inch, nhân với 96 vì Excel sử dụng 96 pixel mỗi inch).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Đặt độ cao của biểu đồ tính bằng pixel.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Lưu sổ làm việc vào một luồng bộ nhớ.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Tạo khung đối tượng OLE với dữ liệu Excel được nhúng.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 inch (0.5 * 72)
    72,  // y = 1 inch (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Kết luận**

Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước biểu đồ. Lựa chọn cách tiếp cận phụ thuộc vào yêu cầu và trường hợp sử dụng. Cả hai cách đều hoạt động tương tự bất kể bản trình chiếu được tạo từ mẫu hay tạo mới. Ngoài ra, không có giới hạn nào về kích thước của khung đối tượng OLE trong giải pháp này.

## **Câu hỏi thường gặp**

### Tại sao biểu đồ Excel được nhúng của tôi lại thay đổi kích thước sau khi kích hoạt trong PowerPoint?

Điều này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ ban đầu khi kích hoạt lần đầu, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỷ lệ nguyên tỉ, dẫn đến việc thay đổi kích thước.

### Liệu có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?

Có. Bằng cách khớp kích thước cửa sổ sổ làm việc Excel hoặc kích thước biểu đồ với kích thước khung đối tượng OLE trước khi nhúng, bạn có thể giữ cho kích thước biểu đồ nhất quán.

### Nên chọn cách tiếp cận nào, đặt kích thước cửa sổ sổ làm việc hay đặt kích thước biểu đồ?

Sử dụng **Cách tiếp cận 1 (kích thước cửa sổ)** nếu bạn muốn duy trì tỷ lệ của sổ làm việc và có thể cho phép thay đổi kích thước sau này.
Sử dụng **Cách tiếp cận 2 (kích thước biểu đồ)** nếu kích thước biểu đồ là cố định và sẽ không thay đổi sau khi nhúng.

### Các phương pháp này có hoạt động với cả bản trình chiếu dựa trên mẫu và bản trình chiếu mới không?

Có. Cả hai cách tiếp cận đều hoạt động tương tự cho các bản trình chiếu được tạo từ mẫu và từ đầu.

### Có giới hạn nào về kích thước của khung đối tượng OLE không?

Không. Bạn có thể đặt khung OLE ở bất kỳ kích thước nào miễn là nó tỷ lệ phù hợp với kích thước sổ làm việc hoặc biểu đồ.

### Tôi có thể sử dụng các phương pháp này với biểu đồ được tạo trong các chương trình bảng tính khác không?

Các ví dụ được thiết kế cho biểu đồ Excel tạo bằng Aspose.Cells, nhưng nguyên tắc vẫn áp dụng cho các chương trình bảng tính tương thích OLE khác miễn là chúng hỗ trợ các tùy chọn kích thước tương tự.

## **Các phần liên quan**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/vi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
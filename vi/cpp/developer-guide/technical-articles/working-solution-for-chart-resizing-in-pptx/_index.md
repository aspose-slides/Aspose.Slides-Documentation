---
title: Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX
type: docs
weight: 60
url: /vi/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- thay đổi kích thước biểu đồ
- biểu đồ Excel
- đối tượng OLE
- nhúng biểu đồ
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng đối tượng OLE Excel nhúng với Aspose.Slides cho C++. Tìm hiểu hai phương pháp với mã để giữ kích thước nhất quán."
---
## **Bối cảnh**

Đã được ghi nhận rằng các biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong bản trình bày PowerPoint thông qua các thành phần Aspose bị thay đổi kích thước đến một tỉ lệ không xác định sau lần kích hoạt đầu tiên. Hành vi này gây ra sự khác biệt về hình ảnh đáng chú ý trong bản trình bày giữa trạng thái trước và sau khi kích hoạt biểu đồ. Nhóm Aspose đã điều tra vấn đề chi tiết và đã tìm ra giải pháp. Bài viết này mô tả nguyên nhân của vấn đề và cách khắc phục tương ứng.

Trong [bài viết trước](/slides/vi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo biểu đồ Excel bằng Aspose.Cells cho C++ và nhúng nó vào bản trình bày PowerPoint bằng Aspose.Slides cho C++. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/cpp/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán hình ảnh biểu đồ vào khung đối tượng OLE của biểu đồ. Trong bản trình bày đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh biểu đồ, biểu đồ Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trong sổ làm việc Excel cơ bản và sau đó quay lại slide tương ứng bằng cách nhấp ra ngoài sổ làm việc đã kích hoạt. Kích thước của khung đối tượng OLE thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước khác nhau tùy thuộc vào kích thước ban đầu của cả khung đối tượng OLE và sổ làm việc Excel đã nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước ban đầu khi được kích hoạt lần đầu. Tuy nhiên, khung đối tượng OLE có kích thước riêng của nó. Theo Microsoft, khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước và duy trì tỉ lệ đúng như một phần của quá trình nhúng. Tùy thuộc vào sự khác nhau giữa kích thước cửa sổ Excel và kích thước hoặc vị trí của khung đối tượng OLE, việc thay đổi kích thước sẽ xảy ra.

## **Giải pháp hoạt động**

Có hai kịch bản có thể cho việc tạo bản trình bày PowerPoint bằng Aspose.Slides cho C++.

**Kịch bản 1:** Tạo bản trình bày dựa trên mẫu hiện có.

**Kịch bản 2:** Tạo bản trình bày từ đầu.

Giải pháp chúng tôi đưa ra ở đây áp dụng cho cả hai kịch bản. Cơ sở của mọi cách giải quyết là giống nhau: **kích thước cửa sổ của đối tượng OLE được nhúng phải khớp với khung đối tượng OLE trong slide PowerPoint**. Bây giờ chúng tôi sẽ thảo luận về hai cách tiếp cận cho giải pháp này.

## **Cách tiếp cận thứ nhất**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước cửa sổ của sổ làm việc Excel được nhúng sao cho nó khớp với kích thước của khung đối tượng OLE trong slide PowerPoint.

**Kịch bản 1**

Giả sử chúng ta đã định nghĩa một mẫu và muốn tạo bản trình bày dựa trên nó. Giả sử có một hình dạng tại chỉ mục 2 trong mẫu, nơi chúng ta muốn đặt một khung OLE chứa sổ làm việc Excel được nhúng. Trong kịch bản này, kích thước của khung đối tượng OLE đã được xác định trước — nó khớp với kích thước của hình dạng tại chỉ mục 2 trong mẫu. Tất cả những gì chúng ta cần làm là đặt kích thước cửa sổ của sổ làm việc bằng kích thước của hình dạng đó. Đoạn mã sau thực hiện mục đích này:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Định nghĩa kích thước biểu đồ với cửa sổ. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Đặt độ rộng cửa sổ của sổ làm việc tính bằng inch (chia cho 72 vì PowerPoint sử dụng 72 pixel mỗi inch).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Đặt độ cao cửa sổ của sổ làm việc tính bằng inch.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Lưu sổ làm việc vào một luồng bộ nhớ.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Tạo khung đối tượng OLE với dữ liệu Excel đã nhúng.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Kịch bản 2**

Giả sử chúng ta muốn tạo một bản trình bày từ đầu và bao gồm một khung đối tượng OLE có kích thước bất kỳ với sổ làm việc Excel được nhúng. Trong đoạn mã sau, chúng ta tạo một khung đối tượng OLE cao 4 inch và rộng 9,5 inch tại x = 0,5 inch và y = 1 inch trên slide. Sau đó chúng ta đặt cửa sổ sổ làm việc Excel cùng kích thước — cao 4 inch và rộng 9,5 inch.

```cpp
// Chiều cao mong muốn.
int32_t desiredHeight = 288; // 4 inch (4 * 72)

// Chiều rộng mong muốn.
int32_t desiredWidth = 684; // 9.5 inch (9.5 * 72)

// Xác định kích thước biểu đồ với cửa sổ. 
chart->SetSizeWithWindow(true);

// Đặt độ rộng cửa sổ của sổ làm việc tính bằng inch.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Đặt độ cao cửa sổ của sổ làm việc tính bằng inch.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Lưu sổ làm việc vào một luồng bộ nhớ.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Tạo khung đối tượng OLE với dữ liệu Excel đã nhúng.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Cách tiếp cận thứ hai**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước biểu đồ trong sổ làm việc Excel được nhúng sao cho nó khớp với kích thước của khung đối tượng OLE trong slide PowerPoint. Cách tiếp cận này hữu ích khi kích thước biểu đồ đã biết từ trước và sẽ không thay đổi.

**Kịch bản 1**

Giả sử chúng ta đã định nghĩa một mẫu và muốn tạo bản trình bày dựa trên nó. Giả sử có một hình dạng tại chỉ mục 2 trong mẫu, nơi chúng ta dự định đặt một khung OLE chứa sổ làm việc Excel được nhúng. Trong kịch bản này, kích thước khung OLE đã được xác định trước — khớp với kích thước của hình dạng tại chỉ mục 2 trong mẫu. Tất cả những gì chúng ta cần làm là đặt kích thước biểu đồ trong sổ làm việc bằng kích thước của hình dạng. Đoạn mã sau thực hiện mục đích này:

```cpp
// Xác định kích thước biểu đồ mà không có cửa sổ. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Đặt độ rộng biểu đồ tính bằng pixel (nhân với 96 vì Excel sử dụng 96 pixel mỗi inch).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Đặt độ cao biểu đồ tính bằng pixel.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Xác định kích thước in của biểu đồ.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Lưu sổ làm việc vào một luồng bộ nhớ.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Tạo khung đối tượng OLE với dữ liệu Excel đã nhúng.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Kịch bản 2**

Giả sử chúng ta muốn tạo một bản trình bày từ đầu và bao gồm một khung đối tượng OLE có kích thước bất kỳ với sổ làm việc Excel được nhúng. Trong đoạn mã sau, chúng ta tạo một khung đối tượng OLE có chiều cao 4 inch và chiều rộng 9,5 inch trên slide ở x = 0,5 inch và y = 1 inch. Chúng ta cũng đặt kích thước biểu đồ tương ứng cùng kích thước: chiều cao 4 inch và chiều rộng 9,5 inch.

```cpp
// Chiều cao mong muốn của chúng ta.
int32_t desiredHeight = 288; // 4 inch (4 * 576)

// Chiều rộng mong muốn của chúng ta.
int32_t desiredWidth = 684; // 9.5 inch (9.5 * 576)

// Xác định kích thước biểu đồ mà không có cửa sổ. 
chart->SetSizeWithWindow(false);

// Đặt độ rộng biểu đồ tính bằng pixel.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Đặt độ cao biểu đồ tính bằng pixel.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Lưu sổ làm việc vào một luồng bộ nhớ.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Tạo khung đối tượng OLE với dữ liệu Excel đã nhúng.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Kết luận**

Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước biểu đồ. Lựa chọn cách tiếp cận phụ thuộc vào yêu cầu và trường hợp sử dụng. Cả hai cách đều hoạt động tương tự cho dù bản trình bày được tạo từ mẫu hay được tạo mới từ đầu. Ngoài ra, không có giới hạn nào đối với kích thước của khung đối tượng OLE trong giải pháp này.

## **Câu hỏi thường gặp**

**Tại sao biểu đồ Excel được nhúng của tôi lại thay đổi kích thước sau khi kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ ban đầu khi lần đầu được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỉ lệ, điều này có thể gây ra việc thay đổi kích thước.

**Liệu có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**

Có. Bằng cách đồng bộ kích thước cửa sổ sổ làm việc Excel hoặc kích thước biểu đồ với kích thước khung đối tượng OLE trước khi nhúng, bạn có thể giữ cho kích thước biểu đồ nhất quán.

**Tôi nên chọn cách tiếp cận nào, đặt kích thước cửa sổ sổ làm việc hay đặt kích thước biểu đồ?**

Sử dụng **Cách tiếp cận 1 (kích thước cửa sổ)** nếu bạn muốn duy trì tỉ lệ của sổ làm việc và có thể cho phép thay đổi kích thước sau này.  
Sử dụng **Cách tiếp cận 2 (kích thước biểu đồ)** nếu kích thước biểu đồ cố định và sẽ không thay đổi sau khi nhúng.

**Các phương pháp này có hoạt động với cả bản trình bày dựa trên mẫu và bản trình bày mới không?**

Có. Cả hai cách đều hoạt động tương tự cho các bản trình bày được tạo từ mẫu và được tạo mới từ đầu.

**Có giới hạn nào cho kích thước của khung đối tượng OLE không?**

Không. Bạn có thể đặt khung OLE ở bất kỳ kích thước nào miễn là nó được tỷ lệ phù hợp với kích thước của sổ làm việc hoặc biểu đồ.

**Tôi có thể sử dụng các phương pháp này với biểu đồ được tạo trong các chương trình bảng tính khác không?**

Các ví dụ được thiết kế cho biểu đồ Excel tạo bằng Aspose.Cells, nhưng nguyên tắc này áp dụng cho các chương trình bảng tính khác hỗ trợ OLE miễn là chúng hỗ trợ các tùy chọn kích thước tương tự.

## **Phần liên quan**

- [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình bày](/slides/vi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
---
title: Quản lý Dấu dữ liệu biểu đồ trong các bản trình bày bằng C++
linktitle: Dấu dữ liệu
type: docs
url: /vi/cpp/chart-data-marker/
keywords:
- biểu đồ
- điểm dữ liệu
- dấu
- tùy chọn dấu
- kích thước dấu
- kiểu nền
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách tùy chỉnh dấu dữ liệu biểu đồ trong Aspose.Slides cho C++, nâng cao hiệu quả của bản trình bày trên các định dạng PPT và PPTX với các ví dụ mã C++ rõ ràng."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với dấu dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách tạo biểu đồ, truy cập một series và các điểm dữ liệu của nó, áp dụng phủ ảnh vào dấu ở mức điểm dữ liệu, điều chỉnh kích thước dấu và lưu bản trình bày đã cập nhật. Ngoài ra còn lưu ý rằng các hình dạng dấu chuẩn có sẵn thông qua enumeration `MarkerStyleType` và rằng giao diện dấu sẽ được giữ nguyên khi xuất biểu đồ ra định dạng raster hoặc SVG.

## **Thiết lập Dấu hiệu Biểu đồ**
Aspose.Slides cho C++ cung cấp một API đơn giản để thiết lập dấu series biểu đồ một cách tự động. Trong tính năng sau, mỗi series biểu đồ sẽ nhận được biểu tượng dấu mặc định khác nhau một cách tự động.

Ví dụ mã dưới đây cho thấy cách thiết lập dấu series biểu đồ một cách tự động.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}


## **Thiết lập tùy chọn Dấu hiệu Biểu đồ**
Các dấu có thể được đặt trên các điểm dữ liệu của biểu đồ trong một series cụ thể. Để thiết lập tùy chọn dấu biểu đồ, vui lòng thực hiện các bước sau:

- Khởi tạo [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) class.
- Tạo biểu đồ mặc định.
- Đặt hình ảnh.
- Lấy series biểu đồ đầu tiên.
- Thêm một điểm dữ liệu mới.
- Ghi bài thuyết trình ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã thiết lập các tùy chọn dấu biểu đồ ở mức điểm dữ liệu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}


## **Thiết lập Dấu hiệu Biểu đồ ở mức Điểm dữ liệu của Series**
Bây giờ, các dấu có thể được đặt trên các điểm dữ liệu của biểu đồ trong một series cụ thể. Để thiết lập tùy chọn dấu biểu đồ, vui lòng thực hiện các bước sau:

- Khởi tạo Presentation class.
- Tạo biểu đồ mặc định.
- Đặt hình ảnh.
- Lấy series biểu đồ đầu tiên.
- Thêm một điểm dữ liệu mới.
- Ghi bài thuyết trình ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã thiết lập các tùy chọn dấu biểu đồ ở mức điểm dữ liệu.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//Tránh tạo lớp Presentation đại diện cho file PPTX
//Access first slide
//Truy cập slide đầu tiên
// Add chart with default data
// Thêm biểu đồ với dữ liệu mặc định
// Setting the index of chart data sheet
// Đặt chỉ mục của trang tính dữ liệu biểu đồ
// Getting the chart data worksheet
// Lấy trang tính dữ liệu biểu đồ
// Delete default generated series and categories
// Xóa series và danh mục được tạo mặc định
// Now, Adding a new series
// Bây giờ, Thêm một series mới
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
// Lấy hình ảnh
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
// Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình bày
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
 // Thêm điểm mới (1:3) ở đó.
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Changing the chart series marker
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Áp dụng màu sắc cho Điểm dữ liệu**
Bạn có thể áp dụng màu sắc cho các điểm dữ liệu trong biểu đồ bằng Aspose.Slides cho C++. Các lớp **[IChartDataPointLevelsManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)** và **[IChartDataPointLevel](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/)** đã được thêm vào để truy cập các thuộc tính của mức điểm dữ liệu. Bài viết này trình bày cách bạn có thể truy cập và áp dụng màu sắc cho các điểm dữ liệu trong một biểu đồ.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **Câu hỏi thường gặp**

**Các hình dạng dấu nào có sẵn ngay khi sử dụng?**

Các hình dạng chuẩn có sẵn (hình tròn, hình vuông, hình thoi, hình tam giác, v.v.); danh sách được xác định bởi enumeration [MarkerStyleType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/markerstyletype/). Nếu bạn cần một hình dạng không chuẩn, hãy sử dụng dấu có phủ ảnh để mô phỏng hình ảnh tùy chỉnh.

**Các dấu có được giữ nguyên khi xuất biểu đồ ra ảnh hoặc SVG không?**

Có. Khi render biểu đồ sang [định dạng raster](/slides/vi/cpp/convert-powerpoint-to-png/) hoặc lưu [hình dạng dưới dạng SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/), các dấu sẽ giữ nguyên giao diện và cài đặt, bao gồm kích thước, màu nền và viền.
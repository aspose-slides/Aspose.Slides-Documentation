---
title: Quản lý Dấu dữ liệu Biểu đồ trong Bản trình chiếu bằng С++
linktitle: Dấu dữ liệu
type: docs
url: /vi/cpp/chart-data-marker/
keywords:
- biểu đồ
- điểm dữ liệu
- dấu
- tùy chọn dấu
- kích thước dấu
- loại nền
- PowerPoint
- bản trình chiếu
- С++
- Aspose.Slides
description: "Tìm hiểu cách tùy chỉnh dấu dữ liệu biểu đồ trong Aspose.Slides cho С++, nâng cao hiệu quả bản trình chiếu trên các định dạng PPT và PPTX với các ví dụ mã С++ rõ ràng."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với dấu đánh dấu dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách tạo biểu đồ, truy cập một chuỗi và các điểm dữ liệu của nó, áp dụng tô ảnh cho dấu đánh dấu ở mức điểm dữ liệu, điều chỉnh kích thước dấu đánh dấu và lưu bản trình chiếu đã cập nhật. Ngoài ra còn lưu ý rằng các hình dạng dấu đánh dấu tiêu chuẩn có sẵn qua enumeration `MarkerStyleType` và giao diện dấu đánh dấu được giữ nguyên khi xuất biểu đồ sang định dạng raster hoặc SVG.

## **Đặt dấu đánh dấu biểu đồ**
Aspose.Slides for C++ cung cấp API đơn giản để tự động đặt dấu đánh dấu cho chuỗi biểu đồ. Trong tính năng sau, mỗi chuỗi biểu đồ sẽ nhận được biểu tượng dấu mặc định khác nhau một cách tự động.

Ví dụ mã dưới đây cho thấy cách tự động đặt dấu đánh dấu cho chuỗi biểu đồ.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Đặt tùy chọn dấu đánh dấu biểu đồ**
Các dấu đánh dấu có thể được đặt trên các điểm dữ liệu của biểu đồ trong một chuỗi cụ thể. Để đặt các tùy chọn dấu đánh dấu biểu đồ, hãy thực hiện các bước sau:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
- Tạo biểu đồ mặc định.
- Đặt hình ảnh.
- Lấy chuỗi biểu đồ đầu tiên.
- Thêm một điểm dữ liệu mới.
- Ghi bài thuyết trình ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt các tùy chọn dấu đánh dấu biểu đồ ở mức điểm dữ liệu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Đặt dấu đánh dấu trên mức điểm dữ liệu của chuỗi**
Bây giờ, các dấu đánh dấu có thể được đặt trên các điểm dữ liệu của biểu đồ trong một chuỗi cụ thể. Để đặt các tùy chọn dấu đánh dấu biểu đồ, hãy thực hiện các bước sau:

- Khởi tạo lớp Presentation.
- Tạo biểu đồ mặc định.
- Đặt hình ảnh.
- Lấy chuỗi biểu đồ đầu tiên.
- Thêm một điểm dữ liệu mới.
- Ghi bài thuyết trình ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt các tùy chọn dấu đánh dấu biểu đồ ở mức điểm dữ liệu.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Khởi tạo lớp Presentation đại diện cho tệp PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Truy cập slide đầu tiên
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Thêm biểu đồ với dữ liệu mặc định
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Đặt chỉ mục của sheet dữ liệu biểu đồ
int defaultWorksheetIndex = 0;

// Lấy worksheet dữ liệu biểu đồ
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Delete default generated series and categories
chart->get_ChartData()->get_Series()->Clear();

// Now, Adding a new series
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
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

## **Áp dụng màu cho các điểm dữ liệu**
Bạn có thể áp dụng màu cho các điểm dữ liệu trong biểu đồ bằng Aspose.Slides for C++. Các lớp [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) và **[IChartDataPointLevel](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/)** đã được thêm vào để truy cập các thuộc tính của mức điểm dữ liệu. Bài viết này minh họa cách bạn có thể truy cập và áp dụng màu cho các điểm dữ liệu trong biểu đồ.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **Câu hỏi thường gặp**

**Những hình dạng dấu đánh dấu nào có sẵn mặc định?**

Các hình dạng tiêu chuẩn có sẵn (hình tròn, hình vuông, hình thoi, hình tam giác, v.v.); danh sách được định nghĩa bởi enumeration [MarkerStyleType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/markerstyletype/). Nếu bạn cần một hình dạng không chuẩn, hãy sử dụng dấu đánh dấu với nền ảnh để mô phỏng hình ảnh tùy chỉnh.

**Các dấu đánh dấu có được giữ lại khi xuất biểu đồ ra hình ảnh hoặc SVG không?**

Có. Khi render biểu đồ sang [raster formats](/slides/vi/cpp/convert-powerpoint-to-png/) hoặc lưu [shapes as SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/), các dấu đánh dấu giữ nguyên giao diện và cài đặt, bao gồm kích thước, nền và viền.
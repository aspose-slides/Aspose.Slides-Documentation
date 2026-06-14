---
title: "Tự động tạo PowerPoint trong C++: Tạo bản trình bày động dễ dàng"
linktitle: Tự động tạo PowerPoint
type: docs
weight: 20
url: /vi/cpp/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- nền tảng đám mây
- tự động tạo PowerPoint
- tạo bản trình bày bằng chương trình
- tự động hoá PowerPoint
- tạo slide động
- báo cáo kinh doanh tự động
- tự động hoá PPT
- C++ presentation
- C++
- Aspose.Slides
description: "Tự động tạo slide trên các nền tảng đám mây với Aspose.Slides cho C++—tạo, chỉnh sửa và chuyển đổi tệp PowerPoint và OpenDocument nhanh chóng và đáng tin cậy."
---
## **Giới thiệu**

Việc tạo các bài thuyết trình PowerPoint một cách thủ công có thể tốn thời gian và lặp đi lặp lại—đặc biệt khi nội dung dựa trên dữ liệu động thường xuyên thay đổi. Dù là tạo báo cáo kinh doanh hàng tuần, biên soạn tài liệu giáo dục, hay sản xuất các bộ sưu tập bán hàng cho khách hàng, tự động hóa có thể tiết kiệm vô số giờ và đảm bảo tính nhất quán giữa các nhóm.

Đối với các nhà phát triển C++, việc tự động tạo các bài thuyết trình PowerPoint mở ra những khả năng mạnh mẽ. Bạn có thể tích hợp việc tạo slide vào các cổng thông tin web, công cụ desktop, dịch vụ backend, hoặc nền tảng đám mây để chuyển đổi dữ liệu thành các bài thuyết trình chuyên nghiệp, có thương hiệu—theo yêu cầu.

Trong bài viết này, chúng tôi sẽ khám phá các trường hợp sử dụng phổ biến cho việc tạo PowerPoint tự động trong các ứng dụng C++ (bao gồm triển khai trên các nền tảng đám mây) và lý do tại sao nó đang trở thành một tính năng thiết yếu trong các giải pháp hiện đại. Từ việc lấy dữ liệu kinh doanh thời gian thực đến chuyển đổi văn bản hoặc hình ảnh thành slide, mục tiêu là biến nội dung thô thành các định dạng trực quan, cấu trúc mà khán giả có thể hiểu ngay lập tức.

## **Các trường hợp sử dụng phổ biến cho tự động PowerPoint trong C++**

Tự động tạo PowerPoint đặc biệt hữu ích trong các kịch bản mà nội dung bài thuyết trình cần được lắp ráp động, cá nhân hoá, hoặc cập nhật thường xuyên. Một số trường hợp thực tế phổ biến nhất bao gồm:

- **Báo cáo Kinh doanh & Bảng điều khiển**
  Tạo tóm tắt doanh số, KPI hoặc báo cáo hiệu suất tài chính bằng cách kéo dữ liệu sống từ cơ sở dữ liệu hoặc API.

- **Bộ sưu tập Bán hàng & Marketing Cá nhân hoá**
  Tự động tạo các bộ pitch cho khách hàng dựa trên dữ liệu CRM hoặc biểu mẫu, đảm bảo thời gian phản hồi nhanh và duy trì thương hiệu.

- **Nội dung Giáo dục**
  Chuyển đổi tài liệu học tập, câu hỏi trắc nghiệm hoặc tóm tắt khóa học thành các slide có cấu trúc cho nền tảng e‑learning.

- **Thông tin Chiết xuất Dữ liệu & AI**
  Sử dụng xử lý ngôn ngữ tự nhiên hoặc công cụ phân tích để biến dữ liệu thô hoặc văn bản dài thành các bài thuyết trình tóm tắt.

- **Slide Dựa trên Phương tiện**
  Tập hợp các bài thuyết trình từ hình ảnh tải lên, ảnh chụp màn hình có chú thích hoặc khung video kèm mô tả hỗ trợ.

- **Chuyển Đổi Tài liệu**
  Tự động chuyển đổi tài liệu Word, PDF hoặc đầu vào biểu mẫu thành các bản trình bày trực quan với ít công sức thủ công.

- **Công cụ Phát triển và Kỹ thuật**
  Tạo demo kỹ thuật, tổng quan tài liệu, hoặc nhật ký thay đổi ở định dạng slide trực tiếp từ mã nguồn hoặc nội dung markdown.

Bằng cách tự động hóa những quy trình này, các tổ chức có thể mở rộng việc tạo nội dung, duy trì tính nhất quán và giải phóng thời gian cho công việc chiến lược hơn.

## **Hãy viết mã**

Trong ví dụ này, chúng tôi đã chọn **[Aspose.Slides for C++](https://products.aspose.com/slides/vi/cpp/)** để trình bày tự động PowerPoint nhờ vào bộ tính năng toàn diện và cách sử dụng dễ dàng khi làm việc với các bài thuyết trình một cách lập trình.

Không giống như các thư viện cấp thấp, yêu cầu nhà phát triển phải làm việc trực tiếp với cấu trúc Open XML (thường dẫn đến mã dài dòng và khó đọc), Aspose.Slides cung cấp một API cấp cao hơn. Nó ẩn đi sự phức tạp, cho phép nhà phát triển tập trung vào logic trình bày—như bố cục, định dạng và ràng buộc dữ liệu—mà không cần hiểu chi tiết định dạng tệp PowerPoint.

Mặc dù Aspose.Slides là một thư viện thương mại, nó cung cấp một [bản dùng thử](https://releases.aspose.com/slides/vi/cpp/) đầy đủ khả năng chạy các ví dụ trong bài viết này. Đối với mục đích minh họa ý tưởng, thử nghiệm tính năng, hoặc xây dựng bằng chứng khái niệm như chúng tôi đang làm, bản dùng thử hoàn toàn đủ. Điều này làm cho nó trở thành một lựa chọn tiện lợi để thử nghiệm tự động tạo PowerPoint mà không cần cam kết mua bản quyền ngay lập tức.

Được rồi, hãy cùng đi qua quy trình xây dựng một bài thuyết trình mẫu bằng nội dung thực tế.

### **Tạo Slide Tiêu đề**

Chúng ta sẽ bắt đầu bằng việc tạo một bài thuyết trình mới và thêm một slide tiêu đề với tiêu đề chính và phụ đề.

```cpp
auto presentation = MakeObject<Presentation>();

auto slide0 = presentation->get_Slide(0);

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Title);
slide0->set_LayoutSlide(layoutSlide);

auto titleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(0));
auto subtitleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(1));

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review – Q1 2025");
subtitleShape->get_TextFrame()->set_Text(u"Prepared for Executive Team");
```

![Slide tiêu đề](slide_0.png)

### **Thêm Slide với Biểu Đồ Cột**

Tiếp theo, chúng ta sẽ tạo một slide hiển thị hiệu suất bán hàng khu vực dưới dạng biểu đồ cột.

```cpp
auto layoutSlide1 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide1 = presentation->get_Slides()->AddEmptySlide(layoutSlide1);

auto chart = slide1->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 350, false);
chart->get_Legend()->set_Position(LegendPositionType::Bottom);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Data from January – March 2025");
chart->get_ChartTitle()->set_Overlay(false);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"North America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Europe")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Asia Pacific")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Latin America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 5, 0, ObjectExt::Box<String>(u"Middle East")));

auto series = chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Sales ($K)")), chart->get_Type());
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(480)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(365)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(290)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<int32_t>(150)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 5, 1, ObjectExt::Box<int32_t>(120)));
```

![Slide với biểu đồ](slide_1.png)

### **Thêm Slide với Bảng**

Bây giờ chúng ta sẽ thêm một slide trình bày các chỉ số hiệu suất chính ở dạng bảng.

```cpp
auto layoutSlide2 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide2 = presentation->get_Slides()->AddEmptySlide(layoutSlide2);

auto columnWidths = MakeArray<double>({ 200, 100 });
auto rowHeights = MakeArray<double>({ 40, 40, 40, 40, 40 });

auto table = slide2->get_Shapes()->AddTable(200, 200, columnWidths, rowHeights);
table->get_Column(0)->idx_get(0)->get_TextFrame()->set_Text(u"Metric");
table->get_Column(1)->idx_get(0)->get_TextFrame()->set_Text(u"Value");
table->get_Column(0)->idx_get(1)->get_TextFrame()->set_Text(u"Total Revenue");
table->get_Column(1)->idx_get(1)->get_TextFrame()->set_Text(u"$1.4M");
table->get_Column(0)->idx_get(2)->get_TextFrame()->set_Text(u"Gross Margin");
table->get_Column(1)->idx_get(2)->get_TextFrame()->set_Text(u"54%");
table->get_Column(0)->idx_get(3)->get_TextFrame()->set_Text(u"New Customers");
table->get_Column(1)->idx_get(3)->get_TextFrame()->set_Text(u"340");
table->get_Column(0)->idx_get(4)->get_TextFrame()->set_Text(u"Customer Retention");
table->get_Column(1)->idx_get(4)->get_TextFrame()->set_Text(u"87%");
```

![Slide với bảng](slide_2.png)

### **Thêm Slide Tổng kết với Điểm Gạch Đầu Dòng**

Cuối cùng, chúng ta sẽ đưa vào một bản tổng kết và kế hoạch hành động bằng danh sách gạch đầu dòng đơn giản.

```cpp
static SharedPtr<IParagraph> CreateBulletParagraph(String text) {
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
    paragraph->get_ParagraphFormat()->set_Indent(15);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    paragraph->set_Text(text);
    return paragraph;
}
```
```cpp
auto layoutSlide3 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide3 = presentation->get_Slides()->AddEmptySlide(layoutSlide3);

auto bulletList = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 50, 600, 200);
bulletList->get_FillFormat()->set_FillType(FillType::NoFill);
bulletList->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

bulletList->get_TextFrame()->get_Paragraphs()->Clear();
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Strong performance in North America; growth opportunity in Asia Pacific"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Improve marketing outreach in underperforming regions"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Prepare new campaign strategy for Q2"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Schedule follow-up review in early July"));
```

![Slide với văn bản](slide_3.png)

### **Lưu Bài Thuyết Trình**

Cuối cùng, chúng ta lưu bài thuyết trình vào đĩa:

```java
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Kết luận**

Tự động tạo PowerPoint trong các ứng dụng C++ mang lại lợi ích rõ ràng về tiết kiệm thời gian và giảm công sức thủ công. Bằng cách tích hợp nội dung động như biểu đồ, bảng và văn bản, các nhà phát triển có thể nhanh chóng tạo ra các bài thuyết trình nhất quán, chuyên nghiệp—lý tưởng cho báo cáo kinh doanh, cuộc họp khách hàng hoặc nội dung giáo dục.

Trong bài viết này, chúng tôi đã minh họa cách tự động tạo một bài thuyết trình từ đầu, bao gồm việc thêm slide tiêu đề, biểu đồ và bảng. Phương pháp này có thể áp dụng cho nhiều trường hợp sử dụng khác nhau nơi cần các bài thuyết trình dựa trên dữ liệu tự động.

Bằng việc tận dụng các công cụ phù hợp, các nhà phát triển C++ có thể tự động hoá việc tạo PowerPoint một cách hiệu quả, nâng cao năng suất và đảm bảo tính nhất quán trong mọi bài thuyết trình.
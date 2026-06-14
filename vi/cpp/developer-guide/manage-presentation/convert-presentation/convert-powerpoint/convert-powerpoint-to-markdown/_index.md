---
title: Chuyển đổi các bản trình chiếu PowerPoint sang Markdown trong C++
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/cpp/convert-powerpoint-to-markdown/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang MD
- bản trình chiếu sang MD
- slide sang MD
- PPT sang MD
- PPTX sang MD
- lưu PowerPoint dưới dạng Markdown
- lưu bản trình chiếu dưới dạng Markdown
- lưu slide dưới dạng Markdown
- lưu PPT dưới dạng MD
- lưu PPTX dưới dạng MD
- xuất PPT sang MD
- xuất PPTX sang MD
- PowerPoint
- bản trình chiếu
- Markdown
- C++
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint—PPT, PPTX—sang Markdown sạch với Aspose.Slides cho C++, tự động hoá tài liệu và giữ nguyên định dạng."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn chuyển đổi các bản thuyết trình PowerPoint sang Markdown, điều này có thể hữu ích cho quy trình làm tài liệu, tạo trang tĩnh, di chuyển nội dung và xuất bản văn bản được kiểm soát phiên bản. API hỗ trợ xuất trực tiếp từ các bản PPT và PPTX sang tệp MD và cung cấp các tùy chọn bổ sung để kiểm soát cách nội dung slide được biểu diễn trong tài liệu Markdown kết quả.

Bạn có thể xuất bản trình chiếu dưới dạng Markdown thuần, chọn từ nhiều loại Markdown như CommonMark và GitHub Flavored Markdown, và cấu hình cách xử lý hình ảnh trong quá trình xuất. Đối với các bản thuyết trình chứa nội dung hình ảnh, Aspose.Slides cũng cho phép bạn lưu hình ảnh vào một thư mục riêng và tham chiếu chúng từ tệp Markdown được tạo.

{{% alert color="warning" %}} 

Xuất PowerPoint sang markdown **không có hình ảnh** theo mặc định. Nếu bạn muốn xuất tài liệu PowerPoint có chứa hình ảnh, bạn cần đặt `SaveOptions::MarkdownExportType::Visual)` và cũng phải đặt `BasePath` nơi các hình ảnh được tham chiếu trong tài liệu markdown sẽ được lưu.

{{% /alert %}} 

## **Chuyển đổi PowerPoint sang Markdown**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) để đại diện cho một đối tượng trình chiếu.  
2. Sử dụng [Save ](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)method để lưu đối tượng dưới dạng tệp markdown.

Đoạn mã C++ sau đây cho bạn thấy cách chuyển đổi PowerPoint sang markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **Chuyển đổi PowerPoint sang Kiểu Markdown**

Aspose.Slides cho phép bạn chuyển đổi PowerPoint sang markdown (chứa cú pháp cơ bản), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab và 17 kiểu markdown khác.

Đoạn mã C++ sau đây cho bạn thấy cách chuyển đổi PowerPoint sang CommonMark: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

23 kiểu markdown được hỗ trợ được [liệt kê dưới enumeration Flavor](https://reference.aspose.com/slides/vi/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) từ lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Chuyển đổi bản trình chiếu có chứa hình ảnh sang Markdown**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) cung cấp các thuộc tính và enumeration cho phép bạn sử dụng một số tùy chọn hoặc cài đặt cho tệp markdown kết quả. Enum [MarkdownExportType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) có thể được đặt thành các giá trị xác định cách hình ảnh được hiển thị hoặc xử lý: `Sequential`, `TextOnly`, `Visual`.

### **Chuyển đổi Hình ảnh Theo thứ tự**

Nếu bạn muốn các hình ảnh xuất hiện riêng lẻ, lần lượt trong markdown kết quả, bạn phải chọn tùy chọn sequential. Đoạn mã C++ sau đây cho bạn thấy cách chuyển đổi bản trình chiếu có chứa hình ảnh sang markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **Chuyển đổi Hình ảnh Theo dạng Trực quan**

Nếu bạn muốn các hình ảnh xuất hiện cùng nhau trong markdown kết quả, bạn phải chọn tùy chọn visual. Trong trường hợp này, hình ảnh sẽ được lưu vào thư mục hiện tại của ứng dụng (và một đường dẫn tương đối sẽ được tạo cho chúng trong tài liệu markdown), hoặc bạn có thể chỉ định đường dẫn và tên thư mục ưa thích của mình.

Đoạn mã C++ sau đây minh họa thao tác:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **Câu hỏi thường gặp**

**Liệu các siêu liên kết có được giữ lại khi xuất sang Markdown không?**

Có. Văn bản [hyperlinks](/slides/vi/cpp/manage-hyperlinks/) được giữ nguyên dưới dạng liên kết Markdown tiêu chuẩn. Các [transitions](/slides/vi/cpp/slide-transition/) và [animations](/slides/vi/cpp/powerpoint-animation/) của slide không được chuyển đổi.

**Tôi có thể tăng tốc quá trình chuyển đổi bằng cách chạy đa luồng không?**

Bạn có thể thực hiện song song trên các tệp, nhưng [don’t share](/slides/vi/cpp/multithreading/) cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) giữa các luồng. Sử dụng các thể hiện/tiến trình riêng cho mỗi tệp để tránh tranh chấp.

**Điều gì xảy ra với hình ảnh — chúng được lưu ở đâu, và các đường dẫn có phải là tương đối không?**

[Images](/slides/vi/cpp/image/) được xuất ra một thư mục riêng, và tệp Markdown tham chiếu chúng bằng các đường dẫn tương đối theo mặc định. Bạn có thể cấu hình đường dẫn đầu ra cơ sở và tên thư mục tài sản để duy trì cấu trúc kho dự đoán được.
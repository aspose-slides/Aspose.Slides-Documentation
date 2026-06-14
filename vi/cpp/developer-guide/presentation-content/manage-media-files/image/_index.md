---
title: Tối ưu hóa quản lý hình ảnh trong bài thuyết trình bằng C++
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/cpp/image/
keywords:
- thêm hình ảnh
- thêm ảnh
- thêm bitmap
- thay thế hình ảnh
- thay thế ảnh
- từ web
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- thêm EMF
- thêm WMF
- thêm TIFF
- PowerPoint
- OpenDocument
- bài thuyết trình
- EMF
- SVG
- C++
- Aspose.Slides
description: "Tinh giản quy trình quản lý hình ảnh trong PowerPoint và OpenDocument với Aspose.Slides cho C++, tối ưu hiệu năng và tự động hóa quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh làm cho bài thuyết trình trở nên thu hút và thú vị hơn. Trong Microsoft PowerPoint, bạn có thể chèn hình ảnh từ tệp, internet hoặc các vị trí khác vào các slide. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào các slide trong bài thuyết trình của mình thông qua các cách thức khác nhau. 

{{% alert title="Tip" color="primary" %}} 

Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bài thuyết trình nhanh chóng từ hình ảnh. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Nếu bạn muốn thêm hình ảnh dưới dạng đối tượng khung—đặc biệt nếu bạn dự định sử dụng các tùy chọn định dạng chuẩn để thay đổi kích thước, thêm hiệu ứng, v.v.—hãy xem [Picture Frame](/slides/vi/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Bạn có thể thao tác các hoạt động nhập/xuất liên quan đến hình ảnh và bài thuyết trình PowerPoint để chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Xem các trang sau: chuyển đổi [hình ảnh sang JPG] (https://products.aspose.com/slides/vi/cpp/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh] (https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG] (https://products.aspose.com/slides/vi/cpp/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG] (https://products.aspose.com/slides/vi/cpp/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG] (https://products.aspose.com/slides/vi/cpp/conversion/png-to-svg/), chuyển đổi [SVG sang PNG] (https://products.aspose.com/slides/vi/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides hỗ trợ các thao tác với hình ảnh trong các định dạng phổ biến này: JPEG, PNG, GIF và các định dạng khác. 

## **Thêm Hình Ảnh Được Lưu Trên Máy Vào Slide**

Bạn có thể thêm một hoặc nhiều hình ảnh trên máy tính vào một slide trong bài thuyết trình. Đoạn mã mẫu bằng C++ dưới đây cho bạn cách thêm hình ảnh vào một slide:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Thêm Hình Ảnh Từ Web Vào Slide**

Nếu hình ảnh bạn muốn thêm vào slide không có trên máy tính, bạn có thể thêm hình ảnh trực tiếp từ web. 

Đoạn mã mẫu dưới đây cho bạn cách thêm hình ảnh từ web vào một slide bằng C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Thêm Hình Ảnh Vào Slide Master**

Slide master là slide cấp cao nhất lưu trữ và kiểm soát thông tin (chủ đề, bố cục, v.v.) cho tất cả các slide dưới nó. Vì vậy, khi bạn thêm một hình ảnh vào slide master, hình ảnh đó sẽ xuất hiện trên mọi slide thuộc slide master đó. 

Đoạn mã mẫu C++ dưới đây cho bạn cách thêm hình ảnh vào slide master:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Thêm Hình Ảnh Là Nền Cho Slide**

Bạn có thể muốn sử dụng một bức ảnh làm nền cho một slide cụ thể hoặc nhiều slide. Trong trường hợp đó, bạn cần xem *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/vi/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Thêm SVG Vào Bài Thuyết Trình**
Bạn có thể thêm hoặc chèn bất kỳ hình ảnh nào vào một bài thuyết trình bằng cách sử dụng phương thức [AddPictureFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) thuộc giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_shape_collection).

Để tạo một đối tượng hình ảnh dựa trên SVG, bạn có thể làm như sau:

1. Tạo đối tượng SvgImage để chèn vào ImageShapeCollection
2. Tạo đối tượng PPImage từ ISvgImage
3. Tạo đối tượng PictureFrame bằng giao diện IPPImage

Đoạn mã mẫu dưới đây cho bạn cách thực hiện các bước trên để thêm hình ảnh SVG vào một bài thuyết trình:
``` cpp 
// Đường dẫn tới thư mục tài liệu
System::String dataDir = u"D:\\Documents\\";

// Tên tệp SVG nguồn
System::String svgFileName = dataDir + u"sample.svg";

// Tên tệp bài thuyết trình đầu ra
System::String outPptxPath = dataDir + u"presentation.pptx";

// Tạo bài thuyết trình mới
auto p = System::MakeObject<Presentation>();

// Đọc nội dung tệp SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Tạo đối tượng SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Tạo đối tượng PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Tạo một PictureFrame mới 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Lưu bài thuyết trình ở định dạng PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Chuyển Đổi SVG Thành Một Tập Hình Dạng**
Quá trình chuyển đổi SVG thành một tập hợp các hình dạng của Aspose.Slides tương tự như chức năng trong PowerPoint được dùng để làm việc với hình ảnh SVG:

![PowerPoint Popup Menu](img_01_01.png)

Chức năng này được cung cấp bởi một trong các overload của phương thức [AddGroupShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) của giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_shape_collection), phương thức này nhận một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_svg_image) làm đối số đầu tiên.

Đoạn mã mẫu dưới đây cho bạn cách sử dụng phương pháp đã mô tả để chuyển đổi tệp SVG thành một tập hợp các hình dạng:

``` cpp 
// Đường dẫn tới thư mục tài liệu
System::String dataDir = u"D:\\Documents\\";

// Tên tệp SVG nguồn
System::String svgFileName = dataDir + u"sample.svg";

// Tên tệp bài thuyết trình đầu ra
System::String outPptxPath = dataDir + u"presentation.pptx";

// Tạo bài thuyết trình mới
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Đọc nội dung tệp SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Tạo đối tượng SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Lấy kích thước slide
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Chuyển đổi ảnh SVG thành nhóm hình dạng, co giãn theo kích thước slide
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Lưu bài thuyết trình ở định dạng PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Thêm Hình Ảnh Dưới Dạng EMF Vào Slide**
Aspose.Slides cho C++ cho phép bạn tạo hình ảnh EMF từ các trang tính Excel và thêm các hình ảnh dưới dạng EMF vào slide bằng Aspose.Cells. 

Đoạn mã mẫu dưới đây cho bạn cách thực hiện tác vụ đã mô tả:

``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Save the workbook to stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

## **Thay Thế Hình Ảnh Trong Bộ Sưu Tập Hình Ảnh**

Aspose.Slides cho phép bạn thay thế các hình ảnh được lưu trong bộ sưu tập hình ảnh của một bài thuyết trình (bao gồm những hình được sử dụng bởi các hình dạng slide). Phần này trình bày một số cách tiếp cận để cập nhật hình ảnh trong bộ sưu tập. API cung cấp các phương thức đơn giản để thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) , hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

Thực hiện các bước sau:

1. Tải tệp bài thuyết trình chứa hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Tải một hình ảnh mới từ tệp vào một mảng byte.
1. Thay thế hình ảnh mục tiêu bằng hình ảnh mới sử dụng mảng byte.
1. Trong cách tiếp cận thứ hai, tải hình ảnh vào một đối tượng [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) , rồi thay thế hình ảnh mục tiêu bằng đối tượng đó.
1. Trong cách thứ ba, thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập hình ảnh của bài thuyết trình.
1. Ghi lại bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```cpp
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Cách đầu tiên.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Cách thứ hai.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Cách thứ ba.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Lưu bài thuyết trình vào tệp.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Sử dụng công cụ chuyển đổi Aspose FREE [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) , bạn có thể dễ dàng hoạt hình hóa văn bản, tạo GIF từ văn bản, v.v. 

{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Độ phân giải hình ảnh gốc có giữ nguyên sau khi chèn không?**

Có. Các pixel nguồn được giữ lại, nhưng diện mạo cuối cùng phụ thuộc vào cách [picture](/slides/vi/cpp/picture-frame/) được phóng to/thu nhỏ trên slide và bất kỳ mức nén nào được áp dụng khi lưu.

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide cùng một lúc là gì?**

Đặt logo trên slide master hoặc một layout và thay thế nó trong bộ sưu tập hình ảnh của bài thuyết trình — các cập nhật sẽ lan tới tất cả các yếu tố sử dụng tài nguyên đó.

**Hình SVG chèn vào có thể chuyển đổi thành các hình dạng có thể chỉnh sửa không?**

Có. Bạn có thể chuyển đổi SVG thành một nhóm các hình dạng, sau đó mỗi phần riêng lẻ có thể chỉnh sửa bằng các thuộc tính hình dạng tiêu chuẩn.

**Làm sao để đặt một bức ảnh làm nền cho nhiều slide cùng một lúc?**

[Gán hình ảnh làm nền](/slides/vi/cpp/presentation-background/) trên slide master hoặc layout liên quan — bất kỳ slide nào sử dụng master/layout đó sẽ kế thừa nền.

**Làm sao để ngăn bài thuyết trình "phình to" kích thước do có quá nhiều hình ảnh?**

Tái sử dụng một tài nguyên hình ảnh duy nhất thay vì nhân bản, chọn độ phân giải hợp lý, áp dụng nén khi lưu, và giữ các đồ họa lặp lại trên master khi cần.
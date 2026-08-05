---
title: Quản lý các đoạn văn bản PowerPoint bằng C++
linktitle: Quản lý Đoạn
type: docs
weight: 40
url: /vi/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- thêm văn bản
- thêm đoạn
- quản lý văn bản
- quản lý đoạn
- quản lý dấu đầu dòng
- thụt lề đoạn
- thụt lề treo
- đánh dấu đoạn
- danh sách đánh số
- danh sách dấu đầu dòng
- thuộc tính đoạn
- nhập HTML
- văn bản sang HTML
- đoạn sang HTML
- đoạn sang hình ảnh
- văn bản sang hình ảnh
- xuất đoạn
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Thành thạo định dạng đoạn văn với Aspose.Slides cho C++ — tối ưu căn chỉnh, khoảng cách và kiểu dáng trong các bản trình bày PPT, PPTX và ODP bằng C++."
---
## **Giới thiệu**

Aspose.Slides cung cấp mọi giao diện và lớp bạn cần để làm việc với văn bản, đoạn văn và các phần trong PowerPoint bằng C++.

* Aspose.Slides cung cấp giao diện [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) cho phép bạn thêm các đối tượng đại diện cho một đoạn văn. Một đối tượng `ITextFame` có thể chứa một hoặc nhiều đoạn văn (mỗi đoạn được tạo bằng phím Return).
* Aspose.Slides cung cấp giao diện [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/) cho phép bạn thêm các đối tượng đại diện cho các phần. Một đối tượng `IParagraph` có thể chứa một hoặc nhiều phần (tập hợp các đối tượng iPortions).
* Aspose.Slides cung cấp giao diện [IPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/) cho phép bạn thêm các đối tượng đại diện cho văn bản và các thuộc tính định dạng của chúng.

Một đối tượng `IParagraph` có khả năng xử lý văn bản với các thuộc tính định dạng khác nhau thông qua các đối tượng `IPortion` nền tảng của nó.

## **Thêm Nhiều Đoạn Văn Chứa Nhiều Phần**

Những bước sau cho bạn cách thêm một khung văn bản chứa 3 đoạn và mỗi đoạn chứa 3 phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập tham chiếu của slide liên quan thông qua chỉ số của nó.
3. Thêm một hình chữ nhật [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
4. Lấy ITextFrame liên kết với [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/).
5. Tạo hai đối tượng [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/) và thêm chúng vào bộ sưu tập `IParagraphs` của [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/).
6. Tạo ba đối tượng [IPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportion/) cho mỗi `IParagraph` mới (hai đối tượng Portion cho Đoạn Văn mặc định) và thêm mỗi đối tượng `IPortion` vào bộ sưu tập IPortion của từng `IParagraph`.
7. Đặt một số văn bản cho mỗi phần.
8. Áp dụng các tính năng định dạng mong muốn cho mỗi phần bằng cách sử dụng các thuộc tính định dạng được cung cấp bởi đối tượng `IPortion`.
9. Lưu bản trình bày đã chỉnh sửa.

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Thêm một AutoShape dạng Hình chữ nhật
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Thêm TextFrame vào Hình chữ nhật
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Truy cập đoạn đầu tiên
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Thêm đoạn thứ hai
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Thêm đoạn thứ ba
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// Lưu PPTX vào đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Quản Lý Dấu Chấm Đầu Đoạn**

Danh sách dấu chấm đầu đoạn giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Các đoạn có dấu chấm đầu luôn dễ đọc và hiểu hơn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập tham chiếu của slide liên quan thông qua chỉ số của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide được chọn.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của autoshape. 
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraph/).
7. Đặt `Type` dấu chấm đầu cho đoạn thành `Symbol` và thiết lập ký tự dấu chấm.
8. Đặt `Text` cho đoạn.
9. Đặt `Indent` cho đoạn để định vị dấu chấm.
10. Đặt màu cho dấu chấm.
11. Đặt chiều cao cho dấu chấm.
12. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
13. Thêm đoạn thứ hai và lặp lại quy trình từ bước 7 đến 13.
14. Lưu bản trình bày.

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Thêm một AutoShape dạng Hình chữ nhật
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Thêm TextFrame vào Hình chữ nhật
ashp->AddTextFrame(u"");

// Truy cập khung văn bản
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Tạo đối tượng Paragraph cho khung văn bản
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Đặt văn bản
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Đặt thụt lề dấu đầu dòng
paragraph->get_ParagraphFormat()->set_Indent (25);

// Đặt màu dấu đầu dòng
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// đặt IsBulletHardColor thành true để sử dụng màu dấu đầu dòng tự định
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Đặt chiều cao dấu đầu dòng
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Thêm Paragraph vào khung văn bản
txtFrame->get_Paragraphs()->Add(paragraph);

// Tạo đoạn thứ hai
// Tạo đối tượng Paragraph cho khung văn bản
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// Đặt văn bản
paragraph2->set_Text(u"This is numbered bullet");

// Đặt loại và kiểu dấu đầu dòng cho đoạn
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Đặt thụt lề dấu đầu dòng
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Đặt màu dấu đầu dòng
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// đặt IsBulletHardColor thành true để sử dụng màu dấu đầu dòng tự định
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Đặt chiều cao dấu đầu dòng
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Thêm Paragraph vào khung văn bản
txtFrame->get_Paragraphs()->Add(paragraph2);


// Lưu PPTX vào đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Quản Lý Dấu Chấm Đầu Hình Ảnh**

Danh sách dấu chấm đầu giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Các đoạn có dấu chấm đầu hình ảnh dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập tham chiếu của slide liên quan thông qua chỉ số của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của autoshape. 
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraph/).
7. Tải hình ảnh bằng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/).
8. Đặt loại dấu chấm đầu thành [Picture](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) và thiết lập hình ảnh.
9. Đặt `Text` cho Đoạn.
10. Đặt `Indent` cho Đoạn để định vị dấu chấm.
11. Đặt màu cho dấu chấm.
12. Đặt chiều cao cho dấu chấm.
13. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
14. Thêm đoạn thứ hai và lặp lại quy trình dựa trên các bước trước.
15. Lưu bản trình bày đã chỉnh sửa.

```c++
// Tạo một đối tượng Presentation đại diện cho tệp PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Truy cập slide đầu tiên
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Tạo hình ảnh cho các dấu đầu dòng
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Thêm và truy cập Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Truy cập TextFrame của autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Xóa đoạn mặc định
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Tạo một đoạn mới
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Đặt kiểu và hình ảnh dấu đầu dòng cho đoạn
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Đặt chiều cao dấu đầu dòng
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Thêm đoạn vào TextFrame
paragraphs->Add(paragraph);

// Ghi bản trình bày dưới dạng tệp PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Ghi bản trình bày dưới dạng tệp PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Quản Lý Dấu Chấm Đầu Đa Cấp**

Danh sách dấu chấm đầu giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Dấu chấm đầu đa cấp dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập tham chiếu của slide liên quan thông qua chỉ số của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide mới.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của autoshape. 
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn đầu tiên thông qua lớp [Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraph/) và đặt mức độ (depth) là 0.
7. Tạo đoạn thứ hai thông qua lớp `Paragraph` và đặt mức độ là 1.
8. Tạo đoạn thứ ba thông qua lớp `Paragraph` và đặt mức độ là 2.
9. Tạo đoạn thứ tư thông qua lớp `Paragraph` và đặt mức độ là 3.
10. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
11. Lưu bản trình bày đã chỉnh sửa.

```c++
// Tạo một đối tượng Presentation đại diện cho tệp PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Truy cập slide đầu tiên
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Thêm và truy cập Autoshape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Truy cập khung văn bản của autoshape đã tạo
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Xóa đoạn mặc định
text->get_Paragraphs()->Clear();

// Thêm đoạn đầu tiên
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Đặt mức độ dấu đầu dòng
para1Format->set_Depth(0);

// Thêm đoạn thứ hai
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Đặt mức độ dấu đầu dòng
para2Format->set_Depth(1);

// Thêm đoạn thứ ba
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Đặt mức độ dấu đầu dòng
para3Format->set_Depth(2);

// Thêm đoạn thứ tư
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Đặt mức độ dấu đầu dòng
para4Format->set_Depth(3);

// Thêm các đoạn vào bộ sưu tập
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Ghi bản trình bày dưới dạng tệp PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Quản Lý Đoạn Văn Với Danh Sách Đánh Số Tùy Chỉnh**

Giao diện [IBulletFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/) cung cấp thuộc tính [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) và các thuộc tính khác cho phép bạn quản lý các đoạn văn với đánh số hoặc định dạng tùy chỉnh. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập slide chứa đoạn văn.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của autoshape. 
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn đầu tiên thông qua lớp [Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraph/) và đặt [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) thành 2.
7. Tạo đoạn thứ hai thông qua lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 3.
8. Tạo đoạn thứ ba thông qua lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 7.
9. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
10. Lưu bản trình bày đã chỉnh sửa.

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Truy cập khung văn bản của autoshape đã tạo
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Xóa đoạn mặc định hiện có
textFrame->get_Paragraphs()->RemoveAt(0);

// Danh sách đầu tiên
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **Đặt Thụt Lề Dòng Đầu Cho Đoạn Văn**

Sử dụng phương thức [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/) để điều khiển thụt lề dòng đầu của một đoạn. Phương thức này chỉ di chuyển dòng đầu so với lề trái của đoạn. Giá trị dương sẽ đẩy dòng đầu sang phải, trong khi các dòng còn lại vẫn giữ căn chỉnh với nội dung đoạn.

Sử dụng [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_marginleft/) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/) khi bạn chỉ muốn di chuyển dòng đầu.

Ví dụ dưới đây tạo một số đoạn và áp dụng các giá trị `Indent` khác nhau để minh họa cách thụt lề dòng đầu ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframe/) trống vào hình và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị [Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/) khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình bày đã chỉnh sửa.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Thụt lề dòng đầu của các đoạn](first_line_indent.png)

## **Đặt Thụt Lề Treo Cho Đoạn Văn**

Thụt lề treo là bố cục đoạn mà dòng đầu bắt đầu ở phía trái hơn các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng phương thức [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/). Đặt thụt lề thành giá trị âm để di chuyển dòng đầu sang trái so với thân đoạn.

Thực tế, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_marginleft/) xác định vị trí trái của thân đoạn, và [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/) xác định vị trí của dòng đầu so với lề đó. Để tạo thụt lề treo, đặt giá trị `MarginLeft` dương và giá trị `Indent` âm.

Định dạng này hữu ích cho các mục thư mục, tham khảo, mục bách khoa và các đoạn khác mà các dòng được gói cần căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframe/) trống vào hình và xóa đoạn mặc định.
5. Tạo các đoạn và đặt giá trị [MarginLeft](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_marginleft/) dương cho mỗi đoạn.
6. Đặt giá trị [Indent](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_indent/) âm để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình bày đã chỉnh sửa.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Thụt lề treo của các đoạn](hanging_indent.png)

## **Quản Lý Thuộc Tính Chạy Cuối Đoạn**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Lấy tham chiếu cho slide chứa đoạn qua vị trí của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) có hai đoạn vào hình chữ nhật.
5. Đặt `FontHeight` và loại Phông chữ cho các đoạn.
6. Đặt các thuộc tính End cho các đoạn.
7. Ghi bản trình bày đã chỉnh sửa dưới dạng file PPTX.

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Tải bản trình bày mong muốn.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên.
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Thêm một AutoShape dạng Hình chữ nhật.
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Thêm TextFrame vào Hình chữ nhật.
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Thêm đoạn đầu tiên.
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Thêm đoạn thứ hai.
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);


// Lưu PPTX vào đĩa.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Nhập Văn Bản HTML Vào Đoạn**

Aspose.Slides cung cấp hỗ trợ nâng cao cho việc nhập văn bản HTML vào các đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Truy cập tham chiếu của slide liên quan thông qua chỉ số của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) vào slide.
4. Thêm và truy cập `autoshape` [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) 
5. Xóa đoạn mặc định trong `ITextFrame`.
6. Đọc file HTML nguồn bằng TextReader.
7. Tạo thể hiện đoạn đầu tiên thông qua lớp [Paragraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraph/).
8. Thêm nội dung file HTML đã đọc từ TextReader vào [ParagraphCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraphcollection/) của TextFrame.
9. Lưu bản trình bày đã chỉnh sửa.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Tải bản trình bày mong muốn.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên.
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Thêm một AutoShape dạng Hình chữ nhật.
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Đặt lại màu nền mặc định.
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Thêm TextFrame vào Hình chữ nhật.
ashp->AddTextFrame(u" ");

// Truy cập khung văn bản.
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//GetParagraphs collection
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

//Clearing all paragraphs in added text frame
ParaCollection->Clear();

// Loading the HTML file using stream reader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Adding text from HTML stream reader in text frame
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Create the Paragraph object for text frame
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Create Portion object for paragraph
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Get portion format
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Set the Font for the Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Set Bold property of the Font
pf->set_FontBold(NullableBool::True);

// Set Italic property of the Font
pf->set_FontItalic(NullableBool::True);

// Set Underline property of the Font
pf->set_FontUnderline(TextUnderlineType::Single);

// Set the Height of the Font
pf->set_FontHeight(25);

// Set the color of the Font
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Xuất Văn Bản Đoạn Sang HTML**

Aspose.Slides cung cấp hỗ trợ nâng cao cho việc xuất văn bản (các đoạn) sang HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và tải bản trình bày mong muốn.
2. Truy cập tham chiếu của slide liên quan thông qua chỉ số của nó.
3. Truy cập hình chứa văn bản sẽ được xuất sang HTML.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) của hình.
5. Tạo một thể hiện của `StreamWriter` và thêm file HTML mới.
6. Cung cấp chỉ mục bắt đầu cho StreamWriter và xuất các đoạn mong muốn.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Acesss the default first slide of presentation
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Desired index
int index = 0;

// Accessing the added shape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extracting first paragraph as HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

//Writing Paragraphs data to HTML by providing paragraph starting index, total paragraphs to be copied
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **Lưu Đoạn Văn Dưới Dạng Hình Ảnh**

Trong phần này, chúng tôi sẽ khám phá hai ví dụ minh họa cách lưu một đoạn văn bản, được đại diện bởi giao diện [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/), dưới dạng hình ảnh. Cả hai ví dụ đều bao gồm việc lấy hình ảnh của một hình chứa đoạn bằng các phương thức `GetImage` từ giao diện [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/), tính toán giới hạn của đoạn trong hình và xuất nó dưới dạng ảnh bitmap. Các phương pháp này cho phép bạn trích xuất các phần cụ thể của văn bản từ bản trình bày PowerPoint và lưu chúng dưới dạng hình ảnh riêng, hữu ích cho các kịch bản sử dụng khác nhau.

Giả sử chúng ta có một file bản trình bày gọi là sample.pptx với một slide, trong đó hình đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

**Ví dụ 1**

Trong ví dụ này, chúng ta lấy đoạn thứ hai dưới dạng hình ảnh. Để làm điều này, chúng ta trích xuất hình ảnh của hình từ slide đầu tiên của bản trình bày, sau đó tính toán giới hạn của đoạn thứ hai trong khung văn bản của hình. Đoạn sau đó được vẽ lại lên một bitmap mới, sau đó lưu dưới định dạng PNG. Phương pháp này đặc biệt hữu ích khi bạn cần lưu một đoạn cụ thể dưới dạng hình ảnh riêng trong khi bảo toàn kích thước và định dạng chính xác của văn bản.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

![Hình ảnh đoạn văn](paragraph_to_image_output.png)

**Ví dụ 2**

Trong ví dụ này, chúng ta mở rộng cách tiếp cận trước bằng cách thêm hệ số tỷ lệ vào hình ảnh đoạn. Hình được trích xuất từ bản trình bày và lưu dưới dạng hình ảnh với hệ số tỷ lệ `2`. Điều này cho phép xuất ra độ phân giải cao hơn khi xuất đoạn. Các giới hạn của đoạn sau đó được tính toán có tính đến tỷ lệ. Việc tỷ lệ có thể đặc biệt hữu ích khi cần một hình ảnh chi tiết hơn, ví dụ để sử dụng trong tài liệu in chất lượng cao.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Lưu hình dạng trong bộ nhớ dưới dạng bitmap với tỷ lệ.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **Câu Hỏi Thường Gặp**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong khung văn bản không?**

Đúng. Sử dụng phương thức gói văn bản của khung văn bản ([set_WrapText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframeformat/set_wraptext/)) để tắt việc gói, vì vậy các dòng sẽ không bị ngắt ở mép khung.

**Làm thế nào để tôi có thể lấy giới hạn chính xác trên slide của một đoạn cụ thể?**

Bạn có thể lấy hình chữ nhật bao quanh của đoạn (hoặc thậm chí của một phần riêng) để biết vị trí và kích thước chính xác của nó trên slide.

**Căn chỉnh đoạn (trái/phải/giữa/điều chỉnh) được kiểm soát ở đâu?**

[Alignment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraphformat/set_alignment/) là cài đặt ở mức độ đoạn trong [ParagraphFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraphformat/); nó áp dụng cho toàn bộ đoạn bất kể định dạng của các phần riêng lẻ.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn (ví dụ, một từ) không?**

Đúng. Ngôn ngữ được đặt ở mức độ phần bằng cách sử dụng ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_languageid/)), do đó có thể có nhiều ngôn ngữ đồng thời trong cùng một đoạn.
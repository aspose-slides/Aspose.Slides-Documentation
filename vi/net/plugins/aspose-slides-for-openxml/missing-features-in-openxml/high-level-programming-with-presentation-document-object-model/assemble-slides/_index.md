---
title: Ghép Slides
type: docs
weight: 10
url: /vi/net/assemble-slides/
---
## **Thêm một Slide vào Bản trình chiếu**
Trước khi nói về việc thêm slide vào các tệp bản trình chiếu, hãy cùng thảo luận một số thông tin về các slide. Mỗi tệp PowerPoint chứa slide Master / Layout và các slide Normal khác. Điều này có nghĩa là một tệp bản trình chiếu chứa ít nhất một hoặc nhiều slide. Cần lưu ý rằng các tệp bản trình chiếu không có slide không được Aspose.Slides cho .NET hỗ trợ. Mỗi slide có Id duy nhất và tất cả các slide Normal được sắp xếp theo thứ tự được chỉ định bằng chỉ mục bắt đầu từ 0.

Aspose.Slides cho .NET cho phép nhà phát triển thêm slide trống vào bản trình chiếu của họ. Để thêm một slide trống vào bản trình chiếu, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp **Presentation** 
- Khởi tạo lớp **SlideCollection** bằng cách thiết lập một tham chiếu tới thuộc tính Slides (tập hợp các đối tượng Slide nội dung) được cung cấp bởi đối tượng Presentation. 
- Thêm một slide trống vào bản trình chiếu ở cuối tập hợp các slide nội dung bằng cách gọi phương thức **AddEmptySlide** được cung cấp bởi đối tượng **SlideCollection**. 
- Thực hiện một số công việc với slide trống vừa được thêm. 
- Cuối cùng, ghi tệp bản trình chiếu bằng cách sử dụng đối tượng **Presentation** 

``` csharp

 PresentationEx pres = new PresentationEx();

//Khởi tạo lớp SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Thêm một slide trống vào bộ sưu tập Slides

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Lưu tệp PPTX vào đĩa

pres.Write("EmptySlide.pptx");

``` 
## **Truy cập các Slide của Bản trình chiếu**
Aspose.Slides cho .NET cung cấp lớp Presentation có thể được sử dụng để tìm và truy cập bất kỳ slide nào mong muốn có trong bản trình chiếu.

**Sử dụng Slides Collection**

Lớp **Presentation** đại diện cho một tệp bản trình chiếu và cung cấp tất cả các slide trong đó dưới dạng một bộ sưu tập **SlideCollection** (là một tập hợp các đối tượng **Slide**). Tất cả các slide này có thể được truy cập từ bộ sưu tập **Slides** này bằng cách sử dụng chỉ mục slide.

``` csharp

 //Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Truy cập một slide bằng chỉ mục slide của nó
SlideEx slide = pres.Slides[0];

``` 
## **Xóa Slide**
Chúng ta biết rằng lớp Presentation trong **Aspose.Slides cho .NET** đại diện cho một tệp bản trình chiếu. Lớp Presentation bao gồm một **SlideCollection** đóng vai trò là kho lưu trữ của tất cả các slide là một phần của bản trình chiếu. Các nhà phát triển có thể xóa một slide khỏi bộ sưu tập Slides này theo hai cách:

- Sử dụng Tham chiếu Slide
- Sử dụng Chỉ mục Slide

**Sử dụng Tham chiếu Slide**

Để xóa một slide bằng cách sử dụng tham chiếu của nó, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp Presentation 
- Lấy tham chiếu của một slide bằng cách sử dụng Id hoặc Index của nó 
- Xóa slide đã tham chiếu khỏi bản trình chiếu 
- Ghi tệp bản trình chiếu đã sửa đổi 

``` csharp

 //Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Truy cập một slide bằng chỉ mục trong bộ sưu tập slides
SlideEx slide = pres.Slides[0];

//Xóa một slide bằng tham chiếu của nó
pres.Slides.Remove(slide);

//Ghi tệp bản trình chiếu
pres.Write("modified.pptx");

``` 
## **Thay đổi Vị trí của Slide**
Thay đổi vị trí của một slide trong bản trình chiếu rất đơn giản. Chỉ cần thực hiện các bước sau:

- Tạo một thể hiện của lớp Presentation 
- Lấy tham chiếu của một slide bằng cách sử dụng Index của nó 
- Thay đổi SlideNumber của slide đã tham chiếu 
- Ghi tệp bản trình chiếu đã sửa đổi 

Trong ví dụ dưới đây, chúng tôi đã thay đổi vị trí của một slide (nằm ở vị trí chỉ mục 0 (vị trí 1)) của bản trình chiếu sang chỉ mục 1 (Vị trí 2).

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//Khởi tạo lớp SlideCollection

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Thêm một slide trống vào bộ sưu tập Slides

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Lưu tệp PPTX vào đĩa

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Truy cập một slide bằng chỉ mục slide của nó

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Truy cập một slide bằng chỉ mục trong bộ sưu tập slides

ISlide slide = pres.Slides[0];

//Xóa một slide bằng tham chiếu của nó

pres.Slides.Remove(slide);

//Ghi tệp bản trình chiếu

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Lấy slide có vị trí cần thay đổi

    ISlide sld = pres.Slides[0];

    //Đặt vị trí mới cho slide

    sld.SlideNumber = 2;

    //Ghi bản trình chiếu vào đĩa

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)
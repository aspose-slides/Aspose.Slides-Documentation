---
title: Áp dụng giao diện cho bài thuyết trình
type: docs
weight: 30
url: /vi/net/apply-a-theme-to-a-presentation/
---
## **OpenXML Bài thuyết trình**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Áp dụng giao diện mới cho bài thuyết trình. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Áp dụng giao diện mới cho bài thuyết trình. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Lấy phần trình bày của tài liệu trình bày.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Lấy phần slide master hiện có.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Lấy phần slide master mới.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Xóa phần giao diện hiện có.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Xóa phần slide master cũ.

    presentationPart.DeletePart(slideMasterPart);

    // Nhập phần slide master mới và tái sử dụng ID quan hệ cũ.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Chuyển sang phần giao diện mới.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Chèn mã cho bố cục trong ví dụ này.

    string defaultLayoutType = "Title and Content";

    // Xóa quan hệ bố cục slide trên tất cả các slide. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Xác định loại bố cục slide cho mỗi slide.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Xóa phần bố cục cũ.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Áp dụng phần bố cục mới.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Áp dụng phần bố cục mặc định mới.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Lấy loại bố cục slide.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Ghi chú: Nếu đoạn này được sử dụng trong mã thực tế, hãy kiểm tra tham chiếu null.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Để áp dụng giao diện, chúng ta cần sao chép slide cùng với master, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp Presentation chứa bài thuyết trình nguồn mà slide sẽ được sao chép từ.
- Tạo một thể hiện của lớp Presentation chứa bài thuyết trình đích mà slide sẽ được sao chép tới.
- Truy cập slide cần sao chép cùng với slide master.
- Khởi tạo lớp IMasterSlideCollection bằng cách tham chiếu tới bộ sưu tập Masters được cung cấp bởi đối tượng Presentation của bài thuyết trình đích.
- Gọi phương thức AddClone được cung cấp bởi đối tượng IMasterSlideCollection và truyền master từ PPTX nguồn cần sao chép làm tham số cho phương thức AddClone.
- Khởi tạo lớp ISlideCollection bằng cách đặt tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng Presentation của bài thuyết trình đích.
- Gọi phương thức AddClone được cung cấp bởi đối tượng ISlideCollection và truyền slide từ bài thuyết trình nguồn cần sao chép và slide master làm tham số cho phương thức AddClone.
- Ghi file bài thuyết trình đích đã được sửa đổi.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Khởi tạo lớp Presentation để tải tệp bài thuyết trình nguồn

    Presentation srcPres = new Presentation(presentationFile);

    //Khởi tạo lớp Presentation cho bài thuyết trình đích (nơi slide sẽ được sao chép)

    Presentation destPres = new Presentation(outputFile);

    //Khởi tạo ISlide từ bộ sưu tập các slide trong bài thuyết trình nguồn cùng với

    //slide master

    ISlide SourceSlide = srcPres.Slides[0];

    //Sao chép master slide mong muốn từ bài thuyết trình nguồn vào bộ sưu tập master trong

    //bài thuyết trình đích

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //Sao chép master slide mong muốn từ bài thuyết trình nguồn vào bộ sưu tập master trong

    //bài thuyết trình đích

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //Sao chép slide mong muốn từ bài thuyết trình nguồn với master mong muốn đến cuối

    //bộ sưu tập các slide trong bài thuyết trình đích

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //Sao chép master slide mong muốn từ bài thuyết trình nguồn vào bộ sưu tập master trong //bài thuyết trình đích

    //Lưu bài thuyết trình đích vào đĩa

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **Tải ví dụ mã chạy**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)
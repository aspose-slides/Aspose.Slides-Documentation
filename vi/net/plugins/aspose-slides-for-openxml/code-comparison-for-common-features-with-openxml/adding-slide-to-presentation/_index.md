---
title: Thêm slide vào bản trình chiếu
type: docs
weight: 20
url: /vi/net/adding-slide-to-presentation/
---
## **OpenXML Presentation**
Trong chức năng dưới đây, mặc định một slide được thêm vào bản trình chiếu. Ở đây chúng ta đang thêm một slide mới ở vị trí 2 có một số văn bản bên trong.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Chèn một slide vào bản trình chiếu đã chỉ định.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Mở tài liệu nguồn ở chế độ đọc/ghi. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Truyền tài liệu nguồn và vị trí, tiêu đề của slide sẽ chèn tới phương thức tiếp theo.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Chèn slide đã chỉ định vào bản trình chiếu tại vị trí đã cho.

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Xác minh rằng bản trình chiếu không rỗng.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Khai báo và tạo một slide mới.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Xây dựng nội dung của slide.            

    // Xác định các thuộc tính không hiển thị của slide mới.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Xác định các thuộc tính hình dạng nhóm của slide mới.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Khai báo và tạo hình dạng tiêu đề của slide mới.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Xác định các thuộc tính hình dạng cần thiết cho hình dạng tiêu đề. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Xác định văn bản của hình dạng tiêu đề.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Khai báo và tạo hình dạng nội dung của slide mới.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Xác định các thuộc tính hình dạng cần thiết cho hình dạng nội dung.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Xác định văn bản của hình dạng nội dung.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Tạo phần slide cho slide mới.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Lưu phần slide mới.

    slide.Save(slidePart);

    // Sửa đổi danh sách ID slide trong phần bản trình chiếu.

    // Danh sách ID slide không được null.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Tìm ID slide cao nhất trong danh sách hiện tại.

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // Lấy ID của slide trước.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Sử dụng cùng bố cục slide như slide trước.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Chèn slide mới vào danh sách slide sau slide trước.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Lưu bản trình chiếu đã sửa đổi.

    presentationPart.Presentation.Save();

}

}
```
## **Aspose.Slides**
Mỗi tệp PowerPoint chứa một **Main Master slide** và các **Normal slides** khác. Điều này có nghĩa là một tệp bản trình chiếu chứa ít nhất một hoặc nhiều slide. Cần lưu ý rằng các tệp bản trình chiếu không có slide không được hỗ trợ bởi Aspose.Slides for .NET. Mỗi slide có vị trí cụ thể và một **unique Id**. **slide Id** có thể nằm trong khoảng từ 0 đến 255 cho các master slide và từ 256 đến 65535 cho các normal slide.

Aspose.Slides for .NET cho phép các nhà phát triển thêm các slide trống vào bản trình chiếu bằng phương thức **AddEmptySlide** được cung cấp bởi đối tượng **Presentation**. Để thêm một slide trống vào bản trình chiếu, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp Presentation
- Gọi phương thức AddEmptySlide được cung cấp bởi đối tượng Presentation
- Thực hiện một số thao tác với slide trống mới được thêm
- Thêm một slide khác và chèn văn bản vào nó.
- Cuối cùng, ghi tệp PPT bằng phương thức Write được cung cấp bởi đối tượng Presentation

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//Khởi tạo lớp PresentationEx đại diện cho tệp PPT
Presentation pres = new Presentation();
//Slide trống được thêm mặc định khi bạn tạo
//bản trình chiếu từ hàm khởi tạo mặc định
//Thêm một slide trống vào bản trình chiếu và lấy tham chiếu tới
//slide trống đó
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
//Ghi kết quả ra đĩa
pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

```
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)
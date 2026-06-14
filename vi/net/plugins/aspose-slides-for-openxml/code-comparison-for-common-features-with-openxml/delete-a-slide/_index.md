---
title: Xóa một slide
type: docs
weight: 80
url: /vi/net/delete-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

// Lấy đối tượng presentation và truyền nó tới phương thức DeleteSlide tiếp theo.

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    // Mở tài liệu nguồn ở chế độ đọc/ghi.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Truyền tài liệu nguồn và chỉ số của slide cần xóa tới phương thức DeleteSlide tiếp theo.

        DeleteSlide(presentationDocument, slideIndex);

    }

}

// Xóa slide được chỉ định khỏi bài thuyết trình.

public static void DeleteSlide(PresentationDocument presentationDocument, int slideIndex)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Sử dụng mẫu CountSlides để lấy số lượng slide trong bài thuyết trình.

    int slidesCount = CountSlides(presentationDocument);

    if (slideIndex < 0 || slideIndex >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Lấy phần presentation từ tài liệu presentation.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Lấy đối tượng presentation từ phần presentation.

    Presentation presentation = presentationPart.Presentation;

    // Lấy danh sách ID của các slide trong bài thuyết trình.

    SlideIdList slideIdList = presentation.SlideIdList;

    // Lấy ID của slide được chỉ định

    SlideId slideId = slideIdList.ChildElements[slideIndex] as SlideId;

    // Lấy ID mối quan hệ của slide.

    string slideRelId = slideId.RelationshipId;

    // Xóa slide khỏi danh sách slide.

    slideIdList.RemoveChild(slideId);

    //

    // Xóa các tham chiếu tới slide khỏi tất cả các custom show.

    if (presentation.CustomShowList != null)

    {

        // Duyệt qua danh sách các custom show.

        foreach (var customShow in presentation.CustomShowList.Elements<CustomShow>())

        {

            if (customShow.SlideList != null)

            {

                // Khai báo danh sách liên kết của các mục slide list.

                LinkedList<SlideListEntry> slideListEntries = new LinkedList<SlideListEntry>();

                foreach (SlideListEntry slideListEntry in customShow.SlideList.Elements())

                {

                    // Tìm tham chiếu slide cần xóa khỏi custom show.

                    if (slideListEntry.Id != null && slideListEntry.Id == slideRelId)

                    {

                        slideListEntries.AddLast(slideListEntry);

                    }

                }

                // Xóa tất cả các tham chiếu tới slide khỏi custom show.

                foreach (SlideListEntry slideListEntry in slideListEntries)

                {

                    customShow.SlideList.RemoveChild(slideListEntry);

                }

            }

        }

    }

    // Lưu bài thuyết trình đã sửa đổi.

    presentation.Save();

    // Lấy phần slide cho slide được chỉ định.

    SlidePart slidePart = presentationPart.GetPartById(slideRelId) as SlidePart;

    // Xóa phần slide.

    presentationPart.DeletePart(slidePart);

}

// Lấy đối tượng presentation và truyền nó tới phương thức CountSlides tiếp theo.

public static int CountSlides(string presentationFile)

{

    // Mở bài thuyết trình ở chế độ chỉ đọc.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Truyền presentation tới phương thức CountSlide tiếp theo

        // và trả về số lượng slide.

        return CountSlides(presentationDocument);

    }

}

// Đếm số slide trong bài thuyết trình.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Kiểm tra đối tượng tài liệu null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Lấy phần presentation của tài liệu.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Lấy số lượng slide từ SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Trả về số lượng slide cho phương thức trước.

    return slidesCount;

}   

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Delete a slide.pptx";

DeleteSlide(FileName, 1);

public static void DeleteSlide(string presentationFile, int slideIndex)

{

    //Tạo một đối tượng PresentationEx đại diện cho tệp PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        //Truy cập một slide bằng chỉ mục trong bộ sưu tập slides

        ISlide slide = pres.Slides[slideIndex];


        //Xóa một slide bằng tham chiếu của nó

        pres.Slides.Remove(slide);


        //Ghi bài thuyết trình ra tệp PPTX

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **Tải mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Delete%20a%20slide/)
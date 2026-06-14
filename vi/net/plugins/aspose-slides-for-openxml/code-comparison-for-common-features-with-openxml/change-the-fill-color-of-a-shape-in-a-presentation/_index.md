---
title: Thay đổi màu tô của một hình trong bản trình chiếu
type: docs
weight: 40
url: /vi/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **OpenXML Presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Thay đổi màu tô của một hình.

// Tệp thử nghiệm phải có một hình đã tô màu là hình đầu tiên trên slide đầu tiên.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Lấy ID quan hệ của slide đầu tiên.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Lấy phần slide từ ID quan hệ.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Lấy cây hình dạng chứa hình cần thay đổi.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Lấy hình đầu tiên trong cây hình dạng.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Lấy kiểu dáng của hình.

                ShapeStyle style = shape.ShapeStyle;

                // Lấy tham chiếu tô màu.

                Drawing.FillReference fillRef = style.FillReference;

                // Đặt màu tô thành SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Lưu slide đã chỉnh sửa.

                slide.Slide.Save();

            }

        }

    }

}

```
## **Aspose.Slides**
Chúng ta cần thực hiện các bước sau để điền màu cho các hình trong bài thuyết trình:

- Tạo một thể hiện của lớp Presentation.
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một IShape vào slide.
- Đặt Loại Đổ màu của Shape thành Đơn sắc.
- Đặt màu của Shape.
- Ghi bài thuyết trình đã chỉnh sửa thành tệp PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//Khởi tạo lớp PrseetationEx đại diện cho PPTX 

using (Presentation pres = new Presentation())

{

    //Lấy slide đầu tiên

    ISlide sld = pres.Slides[0];

    //Thêm autoshape loại hình chữ nhật

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Đặt loại tô màu thành Đơn sắc

    shp.FillFormat.FillType = FillType.Solid;

    //Đặt màu của hình chữ nhật

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Ghi tệp PPTX ra đĩa

    pres.Save(FileName, SaveFormat.Pptx);

}

```
## **Download Running Code Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)
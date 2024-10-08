---
title: تغيير لون التعبئة لشكل في عرض تقديمي
type: docs
weight: 40
url: /ar/net/change-the-fill-color-of-a-shape-in-a-presentation/
---

## **عرض تقديمي OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "لون تعبئة الشكل.pptx";

SetPPTShapeColor(FileName);

// تغيير لون التعبئة لشكل.

// يجب أن يحتوي ملف الاختبار على شكل مملوء كأول شكل في الشريحة الأولى.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // الحصول على معرف العلاقة للشريحة الأولى.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // الحصول على جزء الشريحة من معرف العلاقة.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // الحصول على شجرة الشكل التي تحتوي على الشكل المراد تغييره.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // الحصول على أول شكل في شجرة الشكل.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // الحصول على نمط الشكل.

                ShapeStyle style = shape.ShapeStyle;

                // الحصول على مرجع التعبئة.

                Drawing.FillReference fillRef = style.FillReference;

                // تعيين لون التعبئة إلى SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // حفظ الشريحة المعدلة.

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
نحتاج إلى اتباع الخطوات التالية لتعبئة الأشكال في العرض التقديمي:

- إنشاء نسخة من فئة Presentation.
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة IShape إلى الشريحة.
- تعيين نوع التعبئة للشكل إلى صلب.
- تعيين لون الشكل.
- كتابة العرض المعدل كملف PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "لون تعبئة الشكل.pptx";

//Instantiate PrseetationEx class that represents the PPTX 

using (Presentation pres = new Presentation())

{

    //Get the first slide

    ISlide sld = pres.Slides[0];

    //Add autoshape of rectangle type

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Set the fill type to Solid

    shp.FillFormat.FillType = FillType.Solid;

    //Set the color of the rectangle

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Write the PPTX file to disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **تنزيل مثال الشيفرة التشغيلية**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **مثال على الشيفرة**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Apply Theme to Presentation/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)
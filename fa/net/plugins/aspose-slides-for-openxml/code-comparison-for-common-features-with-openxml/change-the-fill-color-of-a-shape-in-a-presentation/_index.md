---
title: تغییر رنگ پر کردن شکل در ارائه
type: docs
weight: 40
url: /fa/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **ارائه OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// رنگ پر کردن یک شکل را تغییر دهید.

// فایل تست باید یک شکل پر شده به عنوان اولین شکل در اولین اسلاید داشته باشد.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // شناسه رابطه (relationship ID) اولین اسلاید را دریافت کنید.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // بخش اسلاید را از شناسه رابطه دریافت کنید.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // درخت شکل (shape tree) که شامل شکل مورد تغییر است را دریافت کنید.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // اولین شکل در درخت شکل را دریافت کنید.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // استایل (style) شکل را دریافت کنید.

                ShapeStyle style = shape.ShapeStyle;

                // مرجع پر (fill reference) را دریافت کنید.

                Drawing.FillReference fillRef = style.FillReference;

                // رنگ پر را به SchemeColor Accent 6 تنظیم کنید؛

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // اسلاید اصلاح شده را ذخیره کنید.

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
ما باید برای پر کردن اشکال در ارائه، این مراحل را دنبال کنیم:

- یک نمونه از کلاس Presentation ایجاد کنید.
- با استفاده از ایندکس آن، مرجع یک اسلاید را به دست آورید.
- یک IShape به اسلاید اضافه کنید.
- نوع پر (Fill Type) شکل را به Solid تنظیم کنید.
- رنگ شکل را تنظیم کنید.
- ارائه‌ی تغییر یافته را به عنوان فایل PPTX بنویسید.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//نمادسازی کلاس PrseetationEx که نمایانگر فایل PPTX است
using (Presentation pres = new Presentation())

{
    //دریافت اولین اسلاید
    ISlide sld = pres.Slides[0];
    //اضافه کردن یک شکل خودکار از نوع مستطیل
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    //تنظیم نوع پر به Solid
    shp.FillFormat.FillType = FillType.Solid;
    //تنظیم رنگ مستطیل
    shp.FillFormat.SolidFillColor.Color = Color.Yellow;
    //نوشتن فایل PPTX به دیسک
    pres.Save(FileName, SaveFormat.Pptx);
}
``` 
## **دانلود مثال کد اجرا شده**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **کد نمونه**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)
---
title: Bir sunumda bir şeklin dolgu rengini değiştirme
type: docs
weight: 40
url: /tr/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **OpenXML Sunumu**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// Bir şeklin dolgu rengini değiştir.

// Test dosyası, ilk slayttaki ilk şekil olarak doldurulmuş bir şekil içermelidir.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // İlk slaydın ilişki kimliğini al.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // İlişki kimliğinden slayt parçasını al.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Değiştirilecek şekli içeren şekil ağacını al.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Şekil ağacındaki ilk şekli al.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Şeklin stilini al.

                ShapeStyle style = shape.ShapeStyle;

                // Doldurma referansını al.

                Drawing.FillReference fillRef = style.FillReference;

                // Dolgu rengini SchemeColor Accent 6 olarak ayarla;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Değiştirilen slaytı kaydet.

                slide.Slide.Save();

            }

        }

    }

}
``` 
## **Aspose.Slides**
Sunumu doldurmak için aşağıdaki adımları izlememiz gerekir:

- Presentation sınıfının bir örneğini oluşturun.
- Slide'ı, Index'ini kullanarak referans alın.
- Slide'a bir IShape ekleyin.
- Şeklin Dolgu Türünü Solid olarak ayarlayın.
- Şeklin rengini ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//PPTX'i temsil eden PresentationEx sınıfını örnekleyin 

using (Presentation pres = new Presentation())
{
    //İlk slaytı al
    ISlide sld = pres.Slides[0];
    //Dikdörtgen tipinde otomatik şekil ekle
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    //Dolgu tipini Katı olarak ayarla
    shp.FillFormat.FillType = FillType.Solid;
    //Dikdörtgenin rengini ayarla
    shp.FillFormat.SolidFillColor.Color = Color.Yellow;
    //PPTX dosyasını diske yaz
    pres.Save(FileName, SaveFormat.Pptx);
}
``` 
## **Çalışan Kod Örneğini İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Örnek Kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)
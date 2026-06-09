---
title: Bir sunumdan başka bir sunuma paragraf taşıma
type: docs
weight: 130
url: /tr/net/move-a-paragraph-from-one-presentation-to-another/
---
## **OpenXML Sunumu**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Kaynak belgedeki bir TextBody şeklinin paragraf aralığını taşır
// hedef belgedeki başka bir TextBody şekline.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// Kaynak dosyayı okuma/yazma olarak aç.
using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // Hedef dosyayı okuma/yazma olarak aç.
    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // Kaynak sunumdaki ilk slaytı al.
        SlidePart slide1 = GetFirstSlide(sourceDoc);
        // İçindeki ilk TextBody şeklini al.
        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();
        // TextBody şeklinin ilk paragrafını al.
        // Not: "Drawing", DocumentFormat.OpenXml.Drawing ad alanının takma adıdır
        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

        // Hedef sunumdaki ilk slaytı al.
        SlidePart slide2 = GetFirstSlide(targetDoc);
        // İçindeki ilk TextBody şeklini al.
        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

        // Kaynak paragrafı kopyala ve kopyalanan paragrafı hedef TextBody şekline ekle.
        // "true" parametresi derin bir kopya oluşturur, bu da
        // Paragraf nesnesinin ve o nesne tarafından doğrudan ya da dolaylı olarak referans verilen tüm öğelerin bir kopyasını oluşturur.
        textBody2.Append(p1.CloneNode(true));

        // Kaynak paragrafı kaynak dosyadan kaldır.
        textBody1.RemoveChild<Drawing.Paragraph>(p1);

        // Kaldırılan paragrafı bir yer tutucu ile değiştir.
        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

        // Kaynak dosyadaki slaytı kaydet.
        slide1.Slide.Save();

        // Hedef dosyadaki slaytı kaydet.
        slide2.Slide.Save();

    }

}

}

// İlk slaydın ilişki kimliğini al
public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

PresentationPart part = presentationDocument.PresentationPart;
SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();
string relId = slideId.RelationshipId;

// İlişki kimliğine göre slayt parçasını al.
SlidePart slidePart = (SlidePart)part.GetPartById(relId);
return slidePart;

}
``` 
## **Aspose.Slides**
Geliştiricilerin bir sunumdan metin çıkarmaları nadir bir durum değildir. Bunu yapmak için, bir sunumdaki tüm slaytlardaki tüm şekillerden metin çıkarmanız gerekir. Bu makale, Microsoft PowerPoint PPTX sunumlarından Aspose.Slides kullanarak metin çıkarmanın nasıl yapılacağını açıklar. Metni tek bir slayttan ya da tüm bir sunumdan çıkarmanız fark etmeksizin, Aspose.Slides PresentationScanner Sınıfını ve sunduğu statik yöntemleri kullanır. Tümü, [Aspose.Slides.Util](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil) ad alanı altında paketlenmiştir.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Kaynak belgedeki bir TextBody şeklinin paragraf aralığını taşır
// hedef belgedeki başka bir TextBody şekline.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //PPTX'i temsil eden Presentation sınıfını örnekle//PPTX'i temsil eden Presentation sınıfını örnekle

    Presentation sourcePres = new Presentation(sourceFile);

    //İlk slayttaki ilk şekle eriş

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Yer tutucudan metni al

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //İlk slayttaki ilk şekle eriş

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Yer tutucudan metni al

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **Çalışan Kod Örneğini İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Örnek Kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)
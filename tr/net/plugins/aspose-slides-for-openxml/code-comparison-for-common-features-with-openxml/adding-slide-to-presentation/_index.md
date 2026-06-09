---
title: Sunuma Slayt Ekleme
type: docs
weight: 20
url: /tr/net/adding-slide-to-presentation/
---
## **OpenXML Sunumu**
Aşağıdaki işlevde varsayılan olarak bir slayt sunuma eklenir. Burada indeks 2'de bazı metinler içeren yeni bir slayt ekliyoruz.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Belirtilen sunuma bir slayt ekle.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Kaynak belgeyi okuma/yazma olarak aç. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Kaynak belgeyi, eklenecek slaytın konumunu ve başlığını bir sonraki metoda geçir.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Belirtilen slaytı sunuma belirtilen konumda ekle.

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

    // Sunumun boş olmadığını doğrula.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Yeni bir slayt bildir ve örnekle.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Slayt içeriğini oluştur.            

    // Yeni slaytın görsel olmayan özelliklerini belirt.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Yeni slaytın grup şekil özelliklerini belirt.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Yeni slaytın başlık şekilini bildir ve örnekle.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Başlık şekli için gerekli şekil özelliklerini belirt. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Başlık şeklinin metnini belirt.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Yeni slaytın gövde şekilini bildir ve örnekle.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // G��vde şekli için gerekli şekil özelliklerini belirt.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // G��vde şeklinin metnini belirt.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Yeni slayt için slayt bölümünü oluştur.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Yeni slayt bölümünü kaydet.

    slide.Save(slidePart);

    // Sunum bölümündeki slayt ID listesini değiştir.

    // Slayt ID listesi null olmamalıdır.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Mevcut listedeki en yüksek slayt ID'sini bul.

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

    // Önceki slaytın ID'sini al.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Önceki slaytın aynı slayt düzenini kullan.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Yeni slaytı önceki slayttan sonra slayt listesine ekle.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Değiştirilmiş sunumu kaydet.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
Her PowerPoint sunum dosyası bir **Main Master slide** ve diğer **Normal slides** içerir. Bu, bir sunum dosyasının en az bir veya daha fazla slayt içerdiği anlamına gelir. Slaytı olmayan sunum dosyalarının Aspose.Slides for .NET tarafından desteklenmediğini bilmek önemlidir. Her slayt belirli bir konuma ve **benzersiz bir Id**'ye sahiptir. **Slide Id** değerleri ana slaytlar için 0'dan 255'e, normal slaytlar için 256'dan 65535'e kadar değişebilir.

Aspose.Slides for .NET, geliştiricilerin **Presentation** nesnesi tarafından sunulan **AddEmptySlide** metodunu kullanarak sunulara boş slayt eklemesine olanak tanır. Sunuya boş bir slayt eklemek için, lütfen aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Presentation nesnesi tarafından sunulan AddEmptySlide metodunu çağırın
- Yeni eklenen boş slayt ile bazı işlemler yapın
- Başka bir slayt ekleyin ve üzerine metin yerleştirin.
- Son olarak, PPT dosyasını Presentation nesnesi tarafından sunulan Write metodu ile yazın

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//PPT dosyasını temsil eden PresentationEx sınıfını örnekle

Presentation pres = new Presentation();

//Bir sunum oluşturduğunuzda varsayılan olarak boş bir slayt eklenir

//varsayılan yapıcıdan sunum

//Sunuma boş bir slayt ekleyip

//bu boş slaytın

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Çıktıyı diske kaydet

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)
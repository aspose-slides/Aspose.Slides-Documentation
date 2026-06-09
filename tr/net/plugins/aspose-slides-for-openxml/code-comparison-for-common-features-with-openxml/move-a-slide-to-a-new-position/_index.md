---
title: Bir slaytı yeni bir konuma taşıma
type: docs
weight: 140
url: /tr/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Sunumdaki slaytları sayma.

public static int CountSlides(string presentationFile)

{

    // Sunumu yalnızca okunur olarak aç.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Sunumu bir sonraki CountSlides yöntemine geçir

        // ve slayt sayısını döndür.

        return CountSlides(presentationDocument);

    }

}

// Sunumdaki slaytları say.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Boş bir belge nesnesi olup olmadığını kontrol et.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Belgenin sunum bölümünü al.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts'tan slayt sayısını al.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Slayt sayısını önceki yönteme döndür.

    return slidesCount;

}

// Sunumdaki slayt sırasındaki slaytı farklı bir konuma taşı.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Sunumdaki slayt sırasındaki slaytı farklı bir konuma taşı.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Sunumdaki slayt sayısını almak için CountSlides yöntemini çağır.

    int slidesCount = CountSlides(presentationDocument);

    // Hem from hem de to konumlarının aralık içinde ve birbirinden farklı olduğundan emin ol.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Sunum belgesinden sunum bölümünü al.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Slayt sayısı sıfır değil, bu yüzden sunumda slayt bulunmalı.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Kaynak slaydın ID'sini al.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Kaynak slaytı taşımak için hedef slaydın konumunu belirle.

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // Kaynak slaytı mevcut konumundan kaldır.

    sourceSlide.Remove();

    // Kaynak slaytı hedef slayttan sonra yeni konumuna ekle.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Değiştirilen sunumu kaydet.

    presentation.Save();

} 
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Sunumda slayt sırasındaki slaytı farklı bir konuma taşı.

public static void MoveSlide(string presentationFile, int from, int to)

{

    // PresentationEx sınıfını örnekleyerek kaynak PPTX dosyasını yükle

    using (Presentation pres = new Presentation(presentationFile))

    {

        // Konumu değiştirilecek slaytı al

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // Slayt için yeni konumu ayarla

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // PPTX'i diske yaz

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **Örnek Kod İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)
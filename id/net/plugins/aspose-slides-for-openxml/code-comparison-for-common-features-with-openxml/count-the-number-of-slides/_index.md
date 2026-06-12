---
title: Hitung Jumlah Slide
type: docs
weight: 50
url: /id/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// Dapatkan objek presentasi dan berikan ke metode CountSlides berikutnya.

public static int CountSlides(string presentationFile)

{

    // Buka presentasi dalam mode baca-saja.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Berikan presentasi ke metode CountSlide berikutnya

        // dan kembalikan jumlah slide.

        return CountSlides(presentationDocument);

    }

}

// Hitung slide dalam presentasi.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Periksa apakah objek dokumen null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Dapatkan bagian presentasi dari dokumen.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Dapatkan jumlah slide dari SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Kembalikan jumlah slide ke metode sebelumnya.

    return slidesCount;

} 

```
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //Instansiasi objek PresentationEx yang mewakili file PPTX

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

```
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)
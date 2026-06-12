---
title: Pindahkan sebuah paragraf dari satu presentasi ke presentasi lain
type: docs
weight: 130
url: /id/net/move-a-paragraph-from-one-presentation-to-another/
---
## **Presentasi OpenXML**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Memindahkan rentang paragraf dalam bentuk TextBody di dokumen sumber
// ke bentuk TextBody lain di dokumen target.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// Buka file sumber untuk membaca/menulis.
using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))
{

    // Buka file target untuk membaca/menulis.
    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))
    {

        // Dapatkan slide pertama dalam presentasi sumber.
        SlidePart slide1 = GetFirstSlide(sourceDoc);
        // Dapatkan bentuk TextBody pertama di dalamnya.
        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();
        // Dapatkan paragraf pertama dalam bentuk TextBody.
        // Catatan: "Drawing" adalah alias dari namespace DocumentFormat.OpenXml.Drawing
        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();
        // Dapatkan slide pertama dalam presentasi target.
        SlidePart slide2 = GetFirstSlide(targetDoc);
        // Dapatkan bentuk TextBody pertama di dalamnya.
        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();
        // Kloning paragraf sumber dan sisipkan paragraf yang telah diklon ke dalam bentuk TextBody target.
        // Menyertakan "true" menghasilkan klon mendalam, yang membuat salinan dari 
        // objek Paragraph dan semua yang secara langsung atau tidak langsung direferensikan oleh objek tersebut.
        textBody2.Append(p1.CloneNode(true));
        // Hapus paragraf sumber dari file sumber.
        textBody1.RemoveChild<Drawing.Paragraph>(p1);
        // Ganti paragraf yang dihapus dengan placeholder.
        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());
        // Simpan slide di file sumber.
        slide1.Slide.Save();
        // Simpan slide di file target.
        slide2.Slide.Save();
    }
}
}

// Dapatkan bagian slide dari slide pertama dalam dokumen presentasi.
public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)
{

// Dapatkan ID hubungan (relationship ID) dari slide pertama
PresentationPart part = presentationDocument.PresentationPart;
SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();
string relId = slideId.RelationshipId;

// Dapatkan bagian slide berdasarkan ID hubungan tersebut.
SlidePart slidePart = (SlidePart)part.GetPartById(relId);
return slidePart;

}
```
## **Aspose.Slides**
Tidak jarang pengembang perlu mengekstrak teks dari sebuah presentasi. Untuk melakukannya, Anda harus mengekstrak teks dari semua bentuk pada semua slide dalam presentasi. Artikel ini menjelaskan cara mengekstrak teks dari presentasi Microsoft PowerPoint PPTX menggunakan Aspose.Slides. Baik mengekstrak teks dari satu slide maupun seluruh presentasi, Aspose.Slides menggunakan kelas PresentationScanner dan metode statis yang disediakannya. Semua itu berada di bawah ruang nama [Aspose.Slides.Util](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Memindahkan rentang paragraf dalam bentuk TextBody di dokumen sumber
// ke bentuk TextBody lain di dokumen target.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Instansiasi kelas Presentation yang mewakili PPTX//Instansiasi kelas Presentation yang mewakili PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    //Akses bentuk pertama di slide pertama

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Dapatkan teks dari placeholder

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Akses bentuk pertama di slide pertama

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Dapatkan teks dari placeholder

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
```
## **Unduh Contoh Kode yang Berjalan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)
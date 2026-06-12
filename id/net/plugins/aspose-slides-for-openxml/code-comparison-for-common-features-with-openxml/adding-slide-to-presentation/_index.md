---
title: Menambahkan Slide ke Presentasi
type: docs
weight: 20
url: /id/net/adding-slide-to-presentation/
---
## **OpenXML Presentation**
Dalam fungsionalitas di bawah ini, secara default satu slide ditambahkan ke presentasi. Di sini kami menambahkan slide baru pada indeks 2 dengan beberapa teks di dalamnya.

```csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// Masukkan slide ke dalam presentasi yang ditentukan.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Buka dokumen sumber untuk membaca/menulis. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Berikan dokumen sumber serta posisi dan judul slide yang akan disisipkan ke metode berikutnya.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Sisipkan slide yang ditentukan ke dalam presentasi pada posisi yang ditentukan.

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

    // Verifikasi bahwa presentasi tidak kosong.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // Deklarasikan dan buat instance slide baru.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Bangun konten slide.            

    // Tentukan properti non-visual dari slide baru.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Tentukan properti grup shape dari slide baru.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Deklarasikan dan buat instance shape judul dari slide baru.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Tentukan properti shape yang diperlukan untuk shape judul. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Tentukan teks dari shape judul.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Deklarasikan dan buat instance shape isi dari slide baru.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Tentukan properti shape yang diperlukan untuk shape isi.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Tentukan teks dari shape isi.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Buat bagian slide untuk slide baru.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Simpan bagian slide baru.

    slide.Save(slidePart);

    // Modifikasi daftar ID slide dalam bagian presentasi.

    // Daftar ID slide tidak boleh null.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Temukan ID slide tertinggi dalam daftar saat ini.

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

    // Dapatkan ID slide sebelumnya.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Gunakan tata letak slide yang sama dengan slide sebelumnya.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Sisipkan slide baru ke dalam daftar slide setelah slide sebelumnya.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Simpan presentasi yang telah dimodifikasi.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
Setiap file presentasi PowerPoint berisi satu **Main Master slide** dan **Normal slides** lainnya. Ini berarti bahwa file presentasi berisi setidaknya satu atau lebih slide. Penting untuk diketahui bahwa file presentasi tanpa slide tidak didukung oleh Aspose.Slides untuk .NET. Setiap slide memiliki posisi spesifik dan **Id unik**. **Id slide** dapat berkisar dari 0 hingga 255 untuk master slide dan dari 256 hingga 65535 untuk slide normal.

Aspose.Slides untuk .NET memungkinkan pengembang menambahkan slide kosong ke presentasi menggunakan metode **AddEmptySlide** yang disediakan oleh objek **Presentation**. Untuk menambahkan slide kosong dalam presentasi, ikuti langkah-langkah berikut:

- Buat instance dari kelas Presentation
- Panggil metode AddEmptySlide yang disediakan oleh objek Presentation
- Lakukan beberapa pekerjaan dengan slide kosong yang baru ditambahkan
- Tambahkan slide lain dan sisipkan teks di dalamnya.
- Terakhir, tulis file PPT menggunakan metode Write yang disediakan oleh objek Presentation

```csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//Instansiasi kelas PresentationEx yang merepresentasikan file PPT

Presentation pres = new Presentation();

//Slide kosong ditambahkan secara default, saat Anda membuat

//presentasi dari konstruktor default

//Menambahkan slide kosong ke presentasi dan mendapatkan referensi dari

//slide kosong tersebut

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Tulis output ke disk

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)
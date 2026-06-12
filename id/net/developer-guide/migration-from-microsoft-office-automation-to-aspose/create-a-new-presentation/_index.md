---
title: Membuat Presentasi Baru Menggunakan VSTO dan Aspose.Slides untuk .NET
linktitle: Membuat Presentasi Baru
type: docs
weight: 10
url: /id/net/create-a-new-presentation/
keywords:
- membuat presentasi
- presentasi baru
- migrasi
- VSTO
- otomasi Office
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Migrasikan dari otomasi Microsoft Office ke Aspose.Slides untuk .NET dan buat presentasi PowerPoint (PPT, PPTX) baru dalam C# dengan kode yang bersih dan dapat diandalkan."
---
{{% alert color="primary" %}} 

VSTO dikembangkan untuk memungkinkan pengembang membuat aplikasi yang dapat berjalan di dalam Microsoft Office. VSTO berbasis COM tetapi dibungkus dalam objek .NET sehingga dapat digunakan dalam aplikasi .NET. VSTO membutuhkan dukungan .NET Framework serta runtime berbasis CLR Microsoft Office. Meskipun dapat digunakan untuk membuat add‑in Microsoft Office, hampir tidak mungkin menggunakannya sebagai komponen sisi server. Ia juga memiliki masalah penyebaran yang serius.

Aspose.Slides untuk .NET adalah komponen yang dapat digunakan untuk memanipulasi presentasi Microsoft PowerPoint, seperti VSTO, tetapi memiliki beberapa keunggulan:

- Aspose.Slides hanya berisi kode terkelola dan tidak memerlukan runtime Microsoft Office untuk diinstal.
- Dapat digunakan sebagai komponen sisi klien atau sebagai komponen sisi server.
- Penyebaran mudah karena Aspose.Slides terkandung dalam satu file DLL.

{{% /alert %}} 
## **Membuat Presentasi**
Berikut dua contoh kode yang mengilustrasikan bagaimana VSTO dan Aspose.Slides for .NET dapat digunakan untuk mencapai tujuan yang sama. Contoh pertama adalah [VSTO](/slides/id/net/create-a-new-presentation/); [contoh kedua](/slides/id/net/create-a-new-presentation/) menggunakan Aspose.Slides.
### **Contoh VSTO**
**Output VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Catatan: PowerPoint adalah namespace yang telah didefinisikan di atas seperti ini
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Buat sebuah presentasi
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Dapatkan tata letak slide judul
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Tambahkan slide judul.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Atur teks judul
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Atur teks sub judul
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Tulis output ke disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Contoh Aspose.Slides for .NET**
**Output dari Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//Buat presentasi
Presentation pres = new Presentation();

//Tambahkan slide judul
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Atur teks judul
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Atur teks sub judul
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Tulis output ke disk
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
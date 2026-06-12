---
title: Bekerja dengan Ukuran dan Tata Letak Presentasi
type: docs
weight: 90
url: /id/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** dan **SlideSize.Size** adalah properti dari kelas presentasi yang dapat diatur atau diambil seperti ditunjukkan di bawah dalam contoh.
## **Contoh**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Membuat objek Presentation yang mewakili file presentasi 
Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Set ukuran slide presentasi yang dihasilkan ke ukuran sumber
auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Simpan Presentation ke disk
auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Unduh Contoh yang Dijalankan**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 

Untuk detail lebih lanjut, kunjungi [Ubah Ukuran Slide Presentasi di .NET](/slides/id/net/slide-size/).

{{% /alert %}}
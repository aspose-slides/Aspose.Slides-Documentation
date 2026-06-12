---
title: Transisi Slide
type: docs
weight: 80
url: /id/net/slide-transitions/
---
Untuk mempermudah pemahaman, kami telah mendemonstrasikan penggunaan Aspose.Slides untuk .NET dalam mengelola transisi slide sederhana. Pengembang tidak hanya dapat menerapkan berbagai efek transisi slide pada slide, tetapi juga menyesuaikan perilaku efek transisi tersebut. Untuk membuat efek transisi slide sederhana, ikuti langkah-langkah berikut:

- Buat instance dari kelas Presentation
- Terapkan Slide Transition Type pada slide dari salah satu efek transisi yang disediakan oleh Aspose.Slides untuk .NET melalui enum **TransitionType**
- Tulis file presentasi yang telah dimodifikasi.
## **Contoh**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instansiasi kelas Presentation yang mewakili file presentasi

using (Presentation pres = new Presentation(FileName))

{
    //Terapkan transisi tipe lingkaran pada slide 1

    //Terapkan transisi tipe sisir pada slide 2

    //Terapkan transisi tipe zoom pada slide 3

    //Simpan presentasi ke disk

    pres.Save(FileName, SaveFormat.Pptx);
}
``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Unduh Contoh yang Berjalan**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 

Untuk detail lebih lanjut, kunjungi [Mengelola Transisi Slide](/slides/id/net/slide-transition/).

{{% /alert %}}
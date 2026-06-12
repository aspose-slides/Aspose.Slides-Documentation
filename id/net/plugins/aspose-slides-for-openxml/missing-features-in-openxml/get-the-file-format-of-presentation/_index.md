---
title: Dapatkan Format File Presentasi
type: docs
weight: 50
url: /id/net/get-the-file-format-of-presentation/
---
Untuk mendapatkan format file, ikuti langkah‑langkah berikut:

- Buat instance dari kelas **IPresentationInfo**
- Dapatkan informasi tentang presentasi

Pada contoh di bawah ini, kami memperoleh format file.
## **Contoh**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Unduh Contoh yang Dijalankan**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)
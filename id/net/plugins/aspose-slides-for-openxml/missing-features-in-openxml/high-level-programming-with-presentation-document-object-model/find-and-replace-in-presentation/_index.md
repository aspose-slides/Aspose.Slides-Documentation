---
title: Cari dan Ganti dalam Presentasi
type: docs
weight: 20
url: /id/net/find-and-replace-in-presentation/
---
Berikut adalah langkah-langkah yang harus diikuti:

1. Buka presentasi.
1. Cari teks.
1. Ganti teks.
1. Tuliskan presentasi.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Buka presentasi

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Dapatkan semua kotak teks dalam presentasi

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Cari teks yang akan diganti

        if (port.Text.Contains(strToFind))

        //Ganti teks yang ada dengan teks baru

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)
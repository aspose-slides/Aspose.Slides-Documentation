---
title: Sunumda Bul ve Değiştir
type: docs
weight: 20
url: /tr/net/find-and-replace-in-presentation/
---
Aşağıda izlenmesi gereken adımlar yer almaktadır:

1. Bir sunumu açın.
1. Metni ara.
1. Metni değiştirin.
1. Sunumu yazın.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Sunumu aç

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Sunumdaki tüm metin kutularını al

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Değiştirilecek metni bul

        if (port.Text.Contains(strToFind))

        //Mevcut metni yeni metinle değiştir

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)
---
title: PPT'den PPTX formatına dönüşüm
type: docs
weight: 20
url: /tr/net/conversion-from-ppt-to-pptx-format/
---
Aspose.Slides'in benzersiz özelliği, çalışma üzerindeki etkisini azaltmadan sürüm dönüştürmelerinde esneklik sağlar.
SaveFormat, belgeleri aşağıdaki tabloda verilen uzantılara dönüştürebilen bir enumerasyondur.

|**Üye Adı**|**Değer**|**Açıklama**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |
Aşağıda PPT'den PPTX'e dönüşümü gösteren bir kod parçacığı bulunmaktadır; aynı şekilde tersine de dönüştürebilirsiniz.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Bir PPTX dosyasını temsil eden Presentation nesnesini oluşturun

Presentation pres = new Presentation(srcFileName);

//PPTX sunumunu PPTX formatında kaydedin

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)
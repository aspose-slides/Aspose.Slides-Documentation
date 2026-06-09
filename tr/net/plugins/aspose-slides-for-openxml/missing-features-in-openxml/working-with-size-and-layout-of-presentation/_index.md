---
title: Sunumun Boyutu ve Düzeniyle Çalışma
type: docs
weight: 90
url: /tr/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** ve **SlideSize.Size**, aşağıdaki örnekte gösterildiği gibi ayarlanabilir veya alınabilir olan presentation sınıfının özellikleridir.
## **Örnek**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Bir sunum dosyasını temsil eden bir Presentation nesnesi oluşturun 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Oluşturulan sunumların slayt boyutunu kaynağın boyutuna ayarlayın

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Save Presentation to disk

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 
Daha fazla ayrıntı için, [Sunum Slayt Boyutunu .NET'te Değiştir](/slides/tr/net/slide-size/) adresini ziyaret edin.
{{% /alert %}}
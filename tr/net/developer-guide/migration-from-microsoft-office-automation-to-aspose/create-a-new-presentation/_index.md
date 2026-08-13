---
title: VSTO ve Aspose.Slides for .NET Kullanarak Yeni Sunumlar Oluşturma
linktitle: Yeni Sunum Oluştur
type: docs
weight: 10
url: /tr/net/create-a-new-presentation/
keywords:
- sunum oluştur
- yeni sunum
- geçiş
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office otomasyonundan Aspose.Slides for .NET'e geçiş yapın ve C# ile temiz, güvenilir kod kullanarak yeni PowerPoint (PPT, PPTX) sunumları oluşturun."
---
{{% alert color="info" %}} 

VSTO, geliştiricilerin Microsoft Office içinde çalışabilen uygulamalar oluşturmasına olanak sağlamak için geliştirildi. VSTO, COM tabanlıdır ancak .NET uygulamalarında kullanılabilmesi için bir .NET nesnesi içinde paketlenmiştir. VSTO, .NET framework desteği ve Microsoft Office CLR tabanlı çalışma zamanına ihtiyaç duyar. Microsoft Office eklentileri oluşturmak için kullanılabilmesine rağmen sunucu tarafı bir bileşen olarak kullanılması neredeyse imkansızdır. Ayrıca ciddi dağıtım sorunları vardır.

Aspose.Slides for .NET, Microsoft PowerPoint sunumlarını manipüle etmek için kullanılabilen bir bileşen olup, VSTO gibi, ancak birkaç avantajı vardır:

- Aspose.Slides yalnızca yönetilen kod içerir ve Microsoft Office çalışma zamanının yüklü olmasını gerektirmez.
- İstemci tarafı bir bileşen veya sunucu tarafı bir bileşen olarak kullanılabilir.
- Dağıtım kolaydır, çünkü Aspose.Slides tek bir DLL içinde bulunur.

{{% /alert %}} 
## **Sunum Oluşturma**
Aşağıda, VSTO ve Aspose.Slides for .NET'in aynı hedefe nasıl ulaşılabileceğini gösteren iki kod örneği bulunmaktadır. İlk örnek [VSTO](/slides/tr/net/create-a-new-presentation/); [ikinci örnek](/slides/tr/net/create-a-new-presentation/) Aspose.Slides kullanmaktadır.
### **VSTO Örneği**
**VSTO çıktısı** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Not: PowerPoint, yukarıda bu şekilde tanımlanmış bir ad alanıdır
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Yeni bir sunum oluştur
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Set the title text
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET Örneği**
**Aspose.Slides çıktısı** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Bir sunum oluştur
Presentation pres = new Presentation();

//Başlık slaytını ekle
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Başlık metnini ayarla
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Alt başlık metnini ayarla
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Çıktıyı diske yaz
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```
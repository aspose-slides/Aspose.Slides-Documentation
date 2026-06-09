---
title: Sunum Yakınlaştırmasını .NET'te Yönet
linktitle: Yakınlaştırmayı Yönet
type: docs
weight: 60
url: /tr/net/manage-zoom/
keywords:
- yakınlaştırma
- yakınlaştırma çerçevesi
- slayt yakınlaştırması
- bölüm yakınlaştırması
- özet yakınlaştırması
- yakınlaştırma ekle
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile Zoom oluşturun ve özelleştirin — bölümler arasında geçiş yapın, PPT, PPTX ve ODP sunumları arasında küçük resimler ve geçişler ekleyin."
---
## **Giriş**

PowerPoint'teki Zooms, bir sunumun belirli slaytlarına, bölümlerine ve bölümlerine atlamanızı sağlar. Sunum yaparken, içerik arasında hızlıca gezinme yeteneği çok yararlı olabilir. 

![overview_image](overview.png)

* Tek bir slaytta tüm sunumu özetlemek için bir [Summary Zoom](#Summary-Zoom) kullanın.
* Yalnızca seçilen slaytları göstermek için bir [Slide Zoom](#Slide-Zoom) kullanın.
* Yalnızca tek bir bölümü göstermek için bir [Section Zoom](#Section-Zoom) kullanın.

## **Slayt Yakınlaştırma**
Slayt yakınlaştırması, sunumunuzu daha dinamik hâle getirebilir, istediğiniz sırada slaytlar arasında kesintisiz bir şekilde gezinmenizi sağlar. Slayt yakınlaştırmaları, çok bölümlü olmayan kısa sunumlar için harikadır, ancak farklı sunum senaryolarında da kullanılabilir.

Slayt yakınlaştırmaları, tek bir tuvaldeymiş gibi hissederken birden fazla bilgi parçasına derinlemenizi sağlar. 

![overview_image](slidezoomsel.png)

For slide zoom objects, Aspose.Slides provides the [ZoomImageType](https://reference.aspose.com/slides/tr/net/aspose.slides/zoomimagetype) enumeration, the [IZoomFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/izoomframe) interface, and some methods under the [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection) interface.

### **Yakınlaştırma Çerçeveleri Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Yakınlaştırma çerçevelerini bağlamayı planladığınız yeni slaytlar oluşturun.  
3. Oluşturulan slaytlara bir tanımlama metni ve arka plan ekleyin.  
4. İlk slayta, oluşturulan slaytlara referanslar içeren yakınlaştırma çerçevelerini ekleyin.  
5. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.  

``` csharp 
using (Presentation pres = new Presentation())
{
    //Sunuma yeni slaytlar ekler
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // İkinci slayt için bir arka plan oluşturur
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // İkinci slayt için bir metin kutusu oluşturur
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Üçüncü slayt için bir arka plan oluşturur
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Üçüncü slayt için bir metin kutusu oluşturur
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //ZoomFrame nesneleri ekler
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Sunumu kaydeder
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Özel Görsellerle Yakınlaştırma Çerçeveleri Oluşturma**
With Aspose.Slides for .NET, you can create a zoom frame with a different slide preview image this way: 
1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Yakınlaştırma çerçevesini bağlamayı planladığınız yeni bir slayt oluşturun.  
3. Slayta bir tanımlama metni ve arka plan ekleyin.  
4. Çerçeveyi doldurmak için kullanılacak bir görüntüyü, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) nesnesine bağlı Images koleksiyonuna ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesi oluşturun.  
5. İlk slayta, oluşturulan slayta referans içeren yakınlaştırma çerçevelerini ekleyin.  
6. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.  

``` csharp 
using (Presentation pres = new Presentation())
{
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // İkinci slayt için bir arka plan oluşturur
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Üçüncü slayt için bir metin kutusu oluşturur
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Yakınlaştırma nesnesi için yeni bir görüntü oluşturur
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //ZoomFrame nesnesini ekler
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Sunumu kaydeder
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Yakınlaştırma Çerçevelerini Biçimlendirme**
Önceki bölümlerde basit yakınlaştırma çerçevelerinin nasıl oluşturulacağını gösterdik. Daha karmaşık yakınlaştırma çerçeveleri oluşturmak için basit bir çerçevenin biçimini değiştirmeniz gerekir. Yakınlaştırma çerçevesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır. 

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Yakınlaştırma çerçevesini bağlamayı planladığınız yeni slaytlar oluşturun.  
3. Oluşturulan slaytlara bazı tanımlama metinleri ve arka plan ekleyin.  
4. İlk slayta, oluşturulan slaytlara referanslar içeren yakınlaştırma çerçevelerini ekleyin.  
5. [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesini, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) nesnesine bağlı Images koleksiyonuna bir görüntü ekleyerek oluşturun.  
6. İlk yakınlaştırma çerçevesi nesnesi için özel bir görüntü ayarlayın.  
7. İkinci yakınlaştırma çerçevesi nesnesi için çizgi biçimini değiştirin.  
8. İkinci yakınlaştırma çerçevesi nesnesinin görüntüsünden arka planı kaldırın.  
9. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.  

``` csharp 
using (Presentation pres = new Presentation())
{
    //Sunuma yeni slaytlar ekler
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // İkinci slayt için bir arka plan oluşturur
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // İkinci slayt için bir metin kutusu oluşturur
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Üçüncü slayt için bir arka plan oluşturur
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Üçüncü slayt için bir metin kutusu oluşturur
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //ZoomFrame nesnelerini ekler
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Yakınlaştırma nesnesi için yeni bir görüntü oluşturur
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // zoomFrame1 nesnesi için özel görüntü ayarlar
    zoomFrame1.ZoomImage = ppImage;

    // zoomFrame2 nesnesi için bir zoom çerçeve biçimi ayarlar
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // zoomFrame2 nesnesi için arka plan gösterilmesin ayarı
    zoomFrame2.ShowBackground = false;

    // Sunumu kaydeder
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Bölüm Yakınlaştırma**

Bölüm yakınlaştırması, sunumunuzdaki bir bölüme bağlantıdır. Gerçekten vurgulamak istediğiniz bölümlere geri dönmek için bölüm yakınlaştırmalarını kullanabilirsiniz. Ya da sunumunuzun belirli bölümlerinin nasıl bağlandığını göstermek için kullanabilirsiniz. 

![overview_image](seczoomsel.png)

For section zoom objects, Aspose.Slides provides the [ISectionZoomFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/isectionzoomframe) interface and some methods under the [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection) interface.

### **Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Yeni bir slayt oluşturun.  
3. Oluşturulan slayta bir tanımlama arka planı ekleyin.  
4. Yakınlaştırma çerçevesini bağlamayı planladığınız yeni bir bölüm oluşturun.  
5. İlk slayta, oluşturulan bölüme referanslar içeren bir bölüm yakınlaştırma çerçevesi ekleyin.  
6. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.  

``` csharp 
using (Presentation pres = new Presentation())
{
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    pres.Sections.AddSection("Section 1", slide);

    // SectionZoomFrame nesnesi ekler
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Sunumu kaydeder
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Özel Görsellerle Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

Using Aspose.Slides for .NET, you can create a section zoom frame with a different slide preview image this way: 

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Yeni bir slayt oluşturun.  
3. Oluşturulan slayta bir tanımlama arka planı ekleyin.  
4. Yakınlaştırma çerçevesini bağlamayı planladığınız yeni bir bölüm oluşturun.  
5. [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesini, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) nesnesine bağlı Images koleksiyonuna bir görüntü ekleyerek oluşturun.  
5. İlk slayta, oluşturulan bölüme referans içeren bir bölüm yakınlaştırma çerçevesi ekleyin.  
6. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.  

``` csharp 
using (Presentation pres = new Presentation())
{
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    pres.Sections.AddSection("Section 1", slide);

    // Yakınlaştırma nesnesi için yeni bir görüntü oluşturur
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // SectionZoomFrame nesnesi ekler
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Sunumu kaydeder
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Bölüm Yakınlaştırma Çerçevelerini Biçimlendirme**

Bir slaytta bölüm yakınlaştırma çerçevesinin biçimini şu şekilde kontrol edebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Yeni bir slayt oluşturun.  
3. Oluşturulan slayta tanımlama arka planı ekleyin.  
4. Yakınlaştırma çerçevesini bağlamayı planladığınız yeni bir bölüm oluşturun.  
5. İlk slayta, oluşturulan bölüme referanslar içeren bir bölüm yakınlaştırma çerçevesi ekleyin.  
6. Oluşturulan bölüm yakınlaştırma nesnesinin boyutunu ve konumunu değiştirin.  
7. [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesini, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) nesnesine bağlı images koleksiyonuna bir görüntü ekleyerek oluşturun.  
8. Oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir görüntü ayarlayın.  
9. *Bağlantılı bölümden orijinal slayta geri dön* yeteneğini ayarlayın.  
10. Bölüm yakınlaştırma çerçevesi nesnesinin bir görüntüsünden arka planı kaldırın.  
11. İkinci yakınlaştırma çerçevesi nesnesi için çizgi biçimini değiştirin.  
12. Geçiş süresini değiştirin.  
13. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.  

``` csharp 
using (Presentation pres = new Presentation())
{
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    pres.Sections.AddSection("Section 1", slide);

    // SectionZoomFrame nesnesi ekler
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // SectionZoomFrame için biçimlendirme
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Sunumu kaydeder
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Özet Yakınlaştırma**

Özet yakınlaştırma, sunumunuzun tüm parçalarının aynı anda gösterildiği bir açılış sayfası gibidir. Sunum yaparken, yakınlaştırmayı istediğiniz sırayla bir yerden diğerine giderek kullanabilirsiniz. Yaratıcı olabilir, ileri atlayabilir veya slayt gösterinizin bölümlerini akışı kesmeden tekrar ziyaret edebilirsiniz.

![overview_image](sumzoomsel.png)

For summary zoom objects, Aspose.Slides provides the [ISummaryZoomFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/tr/net/aspose.slides/isummaryzoomsection), and [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/isummaryzoomsectioncollection) interfaces and some methods under the [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection) interface.

### **Özet Yakınlaştırma Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümler içeren yeni slaytlar oluşturun.  
3. İlk slayta özet yakınlaştırma çerçevesini ekleyin.  
4. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.  

``` csharp 
using (Presentation pres = new Presentation())
{
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    pres.Sections.AddSection("Section 1", slide);

    //Sunuma yeni bir slayt ekler
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    pres.Sections.AddSection("Section 2", slide);

    //Sunuma yeni bir slayt ekler
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    pres.Sections.AddSection("Section 3", slide);

    //Sunuma yeni bir slayt ekler
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    pres.Sections.AddSection("Section 4", slide);

    // SummaryZoomFrame nesnesi ekler
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Sunumu kaydeder
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Bir Özet Yakınlaştırma Bölümü Ekleme ve Kaldırma**

All sections in a summary zoom frame are represented by [ISummaryZoomFrameSection](https://reference.aspose.com/slides/tr/net/aspose.slides/isummaryzoomsection) objects, which are stored in the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/isummaryzoomsectioncollection) object. You can add or remove a summary zoom section object through the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/isummaryzoomsectioncollection) interface this way:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümler içeren yeni slaytlar oluşturun.  
3. İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.  
4. Sunuma yeni bir slayt ve bölüm ekleyin.  
5. Oluşturulan bölümü özet yakınlaştırma çerçevesine ekleyin.  
6. İlk bölümü özet yakınlaştırma çerçevesinden kaldırın.  
7. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.  

``` csharp 
using (Presentation pres = new Presentation())
{
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    pres.Sections.AddSection("Section 1", slide);

    //Sunuma yeni bir slayt ekler
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    pres.Sections.AddSection("Section 2", slide);

    // SummaryZoomFrame nesnesi ekler
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Sunuma yeni bir slayt ekler
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Summary Zoom'a bir bölüm ekler
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Summary Zoom'dan bölümü kaldırır
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Sunumu kaydeder
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Özet Yakınlaştırma Bölümlerini Biçimlendirme**

Bir özet yakınlaştırma çerçevesindeki özet yakınlaştırma bölüm nesnesinin biçimini şu şekilde kontrol edebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümler içeren yeni slaytlar oluşturun.  
3. İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.  
4. `ISummaryZoomSectionCollection` içinden ilk nesne için bir özet yakınlaştırma bölüm nesnesi alın.  
7. [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage) nesnesini, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) nesnesine bağlı images koleksiyonuna bir görüntü ekleyerek oluşturun.  
8. Oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir görüntü ayarlayın.  
9. *Bağlantılı bölümden orijinal slayta geri dön* yeteneğini ayarlayın.  
11. İkinci yakınlaştırma çerçevesi nesnesi için çizgi biçimini değiştirin.  
12. Geçiş süresini değiştirin.  
13. Değiştirilen sunumu bir PPTX dosyası olarak kaydedin.  

``` csharp 
using (Presentation pres = new Presentation())
{
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    pres.Sections.AddSection("Section 1", slide);

    //Sunuma yeni bir slayt ekler
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Sunuma yeni bir bölüm ekler
    pres.Sections.AddSection("Section 2", slide);

    // SummaryZoomFrame nesnesi ekler
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // İlk SummaryZoomSection nesnesini alır
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // SummaryZoomSection nesnesi için biçimlendirme
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Sunumu kaydeder
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Hedefi gösterdikten sonra 'ana' slayta dönmeyi kontrol edebilir miyim?**

Evet. [Zoom frame](https://reference.aspose.com/slides/tr/net/aspose.slides/zoomframe/) veya [section](https://reference.aspose.com/slides/tr/net/aspose.slides/sectionzoomframe/) nesnesinin etkinleştirildiğinde izleyicileri hedef içeriği ziyaret ettikten sonra orijinal slayta geri gönderen bir `ReturnToParent` davranışı vardır.

**Zoom geçişinin 'hızını' veya süresini ayarlayabilir miyim?**

Evet. Zoom, bir `TransitionDuration` ayarlamayı destekler, böylece atlama animasyonunun ne kadar süreceğini kontrol edebilirsiniz.

**Bir sunumda kaç Zoom nesnesi bulunabileceği konusunda sınırlamalar var mı?**

Belgelendirilmiş katı bir API sınırı yoktur. Pratik sınırlamalar, sunumun genel karmaşıklığına ve izleyicinin performansına bağlıdır. Çok sayıda Zoom çerçevesi ekleyebilirsiniz, ancak dosya boyutu ve render süresini göz önünde bulundurun.
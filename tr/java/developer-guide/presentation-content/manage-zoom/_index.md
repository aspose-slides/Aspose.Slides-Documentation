---
title: Java’da Sunum Yakınlaştırmasını Yönet
linktitle: Yakınlaştırmayı Yönet
type: docs
weight: 60
url: /tr/java/manage-zoom/
keywords:
- yakınlaştırma
- yakınlaştırma çerçevesi
- slayt yakınlaştırması
- bölüm yakınlaştırması
- özet yakınlaştırma
- yakınlaştırma ekle
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile Yakınlaştırma oluşturun ve özelleştirin — bölümler arasında atlayın, PPT, PPTX ve ODP sunumları içinde küçük resimler ve geçişler ekleyin."
---
## **Giriş**

PowerPoint'teki Zoom'lar, bir sunumun belirli slaytlarına, bölümlerine ve kısımlarına atlamanızı ve bu slaytlardan geri dönmenizi sağlar. Sunum yaparken, içeriği hızlı bir şekilde gezme yeteneği çok faydalı olabilir. 

![overview_image](overview.png)

* Tek bir slaytta tüm sunumu özetlemek için bir [Summary Zoom](#Summary-Zoom) kullanın.
* Yalnızca seçili slaytları göstermek için bir [Slide Zoom](#Slide-Zoom) kullanın.
* Yalnızca tek bir bölümü göstermek için bir [Section Zoom](#Section-Zoom) kullanın.

## **Slayt Yakınlaştırması**
Bir slayt yakınlaştırması, sunumunuzu daha dinamik hâle getirebilir; istediğiniz sırayla slaytlar arasında serbestçe gezmenizi sağlar ve sunum akışını kesintiye uğratmaz. Slayt yakınlaştırmaları, çok bölümü olmayan kısa sunumlar için harikadır, ancak farklı sunum senaryolarında da kullanılabilir.

Slayt yakınlaştırmaları, tek bir tuvaldeymiş gibi hissederken birden fazla bilgi parçasına derinlemenizi sağlar. 

![overview_image](slidezoomsel.png)

Slayt yakınlaştırma nesneleri için Aspose.Slides, [ZoomImageType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ZoomImageType) numaralandırmasını, [IZoomFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IZoomFrame) arayüzünü ve [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) arayüzünün altında bulunan bazı yöntemleri sağlar.

### **Yakınlaştırma Çerçeveleri Oluşturma**

Bir slayta yakınlaştırma çerçevesi şu şekilde eklenebilir:

1.	[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2.	Yakınlaştırma çerçevelerine bağlamayı planladığınız yeni slaytları oluşturun. 
3.	Oluşturulan slaytlara tanımlama metni ve arka plan ekleyin.
4.	İlk slayta (oluşturulan slaytlara referansları içeren) yakınlaştırma çerçeveleri ekleyin.
5.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir slayta yakınlaştırma çerçevesi oluşturmayı gösterir:

``` java
Presentation pres = new Presentation();
try {
    //Sunuma yeni slaytlar ekler
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // İkinci slayt için bir arka plan oluşturur
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // İkinci slayt için bir metin kutusu oluşturur
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Üçüncü slayt için bir arka plan oluşturur
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Üçüncü slayt için bir metin kutusu oluşturur
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //ZoomFrame nesneleri ekler
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Sunumu kaydeder
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Özel Görsellerle Yakınlaştırma Çerçeveleri Oluşturma**
Aspose.Slides for Java ile, farklı bir slayt önizleme görseli kullanarak yakınlaştırma çerçevesi şu şekilde oluşturulabilir: 
1.	[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2.	Yakınlaştırma çerçevesine bağlamayı planladığınız yeni bir slayt oluşturun. 
3.	Slayta tanımlama metni ve arka plan ekleyin.
4.	[IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPImage) nesnesini, çerçeveyi doldurmak için kullanılacak görüntüyü [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesine bağlı Images koleksiyonuna ekleyerek oluşturun.
5.	İlk slayta (oluşturulan slayta referans içeren) yakınlaştırma çerçeveleri ekleyin.
6.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, farklı bir görsel ile yakınlaştırma çerçevesi oluşturmayı gösterir:

``` java
Presentation pres = new Presentation();
try {
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // İkinci slayt için bir arka plan oluşturur
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Üçüncü slayt için bir metin kutusu oluşturur
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Yakınlaştırma nesnesi için yeni bir görüntü oluşturur
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Adds the ZoomFrame object
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Sunumu kaydeder
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Yakınlaştırma Çerçevelerini Biçimlendirme**
Önceki bölümlerde basit yakınlaştırma çerçevelerinin nasıl oluşturulacağını gösterdik. Daha karmaşık yakınlaştırma çerçeveleri oluşturmak için basit bir çerçevenin biçimini değiştirmeniz gerekir. Yakınlaştırma çerçevesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır. 

Bir slaytta yakınlaştırma çerçevesinin biçimini şu şekilde kontrol edebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2.	Yakınlaştırma çerçevesine bağlamayı planladığınız yeni slaytlar oluşturun. 
3.	Oluşturulan slaytlara bazı tanımlama metinleri ve arka plan ekleyin.
4.	İlk slayta (oluşturulan slaytlara referansları içeren) yakınlaştırma çerçeveleri ekleyin.
5.	Çerçeveyi doldurmak için kullanılacak bir görüntüyü [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesine bağlı Images koleksiyonuna ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPImage) nesnesi oluşturun.
6.	İlk yakınlaştırma çerçevesi nesnesi için özel bir görüntü ayarlayın.
7.	İkinci yakınlaştırma çerçevesi nesnesinin çizgi biçimini değiştirin.
8.	İkinci yakınlaştırma çerçevesi nesnesinin görüntüsünden arka planı kaldırın.
5.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir slaytta yakınlaştırma çerçevesinin biçimini değiştirmeyi gösterir: 

``` java 
Presentation pres = new Presentation();
try {
    //Sunuma yeni slaytlar ekler
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // İkinci slayt için bir arka plan oluşturur
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // İkinci slayt için bir metin kutusu oluşturur
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Üçüncü slayt için bir arka plan oluşturur
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Üçüncü slayt için bir metin kutusu oluşturur
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //ZoomFrame nesneleri ekler
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Yakınlaştırma nesnesi için yeni bir görüntü oluşturur
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // zoomFrame1 nesnesi için özel görüntü ayarlar
    zoomFrame1.setImage(picture);

    // zoomFrame2 nesnesi için bir zoom çerçevesi biçimi ayarlar
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // zoomFrame2 nesnesi için arka planı gösterme ayarı
    zoomFrame2.setShowBackground(false);

    // Sunumu kaydeder
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bölüm Yakınlaştırması**

Bölüm yakınlaştırması, sunumunuzda bir bölüme bağlanan bir bağlantıdır. Bölüm yakınlaştırmalarını, gerçekten vurgulamak istediğiniz bölümlere geri dönmek için kullanabilirsiniz. Ya da sunumunuzun belirli parçalarının nasıl bağlandığını göstermek için kullanabilirsiniz. 

![overview_image](seczoomsel.png)

Bölüm yakınlaştırma nesneleri için Aspose.Slides, [ISectionZoomFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISectionZoomFrame) arayüzünü ve [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) arayüzünün altında bulunan bazı yöntemleri sağlar.

### **Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

Bir slayta bölüm yakınlaştırma çerçevesi şu şekilde eklenebilir:

1.	[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2.	Yeni bir slayt oluşturun. 
3.	Oluşturulan slayta tanımlama arka planı ekleyin.
4.	Yakınlaştırma çerçevesine bağlamayı planladığınız yeni bir bölüm oluşturun. 
5.	İlk slayta (oluşturulan bölüme referansları içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.
6.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir slayta yakınlaştırma çerçevesi oluşturmayı gösterir:

``` java
Presentation pres = new Presentation();
try {
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Yeni bir Bölüm ekler
    pres.getSections().addSection("Section 1", slide);

    // Bir SectionZoomFrame nesnesi ekler
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Sunumu kaydeder
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Özel Görsellerle Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

Aspose.Slides for Java kullanarak, farklı bir slayt önizleme görüntüsüyle bölüm yakınlaştırma çerçevesi şu şekilde oluşturulabilir: 

1.	[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2.	Yeni bir slayt oluşturun.
3.	Oluşturulan slayta tanımlama arka planı ekleyin.
4.	Yakınlaştırma çerçevesine bağlamayı planladığınız yeni bir bölüm oluşturun. 
5.	[IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPImage) nesnesini, çerçeveyi doldurmak için kullanılacak bir görüntüyü [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesine bağlı Images koleksiyonuna ekleyerek oluşturun.
5.	İlk slayta (oluşturulan bölüme referans içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.
6.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, farklı bir görsel ile yakınlaştırma çerçevesi oluşturmayı gösterir:

``` java 
Presentation pres = new Presentation();
try {
    //Sunuma yeni slayt ekler
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Yeni bir Bölüm ekler
    pres.getSections().addSection("Section 1", slide);

    // Yakınlaştırma nesnesi için yeni bir görüntü oluşturur
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // SectionZoomFrame nesnesi ekler
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Sunumu kaydeder
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Bölüm Yakınlaştırma Çerçevelerini Biçimlendirme**

Daha karmaşık bölüm yakınlaştırma çerçeveleri oluşturmak için basit bir çerçevenin biçimini değiştirmeniz gerekir. Bölüm yakınlaştırma çerçevesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır. 

Bir slaytta bölüm yakınlaştırma çerçevesinin biçimini şu şekilde kontrol edebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2.	Yeni bir slayt oluşturun.
3.	Oluşturulan slayta tanımlama arka planı ekleyin.
4.	Yakınlaştırma çerçevesine bağlamayı planladığınız yeni bir bölüm oluşturun. 
5.	İlk slayta (oluşturulan bölüme referansları içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.
6.	Oluşturulan bölüm yakınlaştırma nesnesinin boyutunu ve konumunu değiştirin.
7.	[IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPImage) nesnesini, çerçeveyi doldurmak için kullanılacak bir görüntüyü [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesine bağlı images koleksiyonuna ekleyerek oluşturun.
8.	Oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir görüntü ayarlayın.
9.	*Bağlı bölümden orijinal slayta dönüş* özelliğini etkinleştirin. 
10.	Bölüm yakınlaştırma çerçevesi nesnesinin görüntüsünden arka planı kaldırın.
11.	İkinci yakınlaştırma çerçevesi nesnesinin çizgi biçimini değiştirin.
12.	Geçiş süresini değiştirin.
13.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir bölüm yakınlaştırma çerçevesinin biçimini değiştirmeyi gösterir:

``` java
Presentation pres = new Presentation();
try {
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Yeni bir Bölüm ekler
    pres.getSections().addSection("Section 1", slide);

    //SectionZoomFrame nesnesi ekle
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //SectionZoomFrame için biçimlendirme
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Sunumu kaydeder
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Özet Yakınlaştırması**

Özet yakınlaştırması, sunumunuzun tüm parçalarının bir kerede gösterildiği bir açılış sayfası gibidir. Sunum yaparken, yakınlaştırmayı kullanarak sunumunuzdaki bir yerden başka bir yere istediğiniz sırayla geçiş yapabilirsiniz. Yaratıcı olabilir, ileri atlayabilir veya slayt gösterinizin parçalarına geri dönebilirsiniz; bu da sunum akışını kesintiye uğratmaz.

![overview_image](sumzoomsel.png)

Özet yakınlaştırma nesneleri için Aspose.Slides, [ISummaryZoomFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISummaryZoomSection) ve [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISummaryZoomSectionCollection) arayüzlerini ve [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) arayüzünün altında bulunan bazı yöntemleri sağlar.

### **Özet Yakınlaştırması Oluşturma**

Bir slayta özet yakınlaştırma çerçevesi şu şekilde eklenebilir:

1.	[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2.	Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümler ekleyerek yeni slaytlar oluşturun.
3.	İlk slayta özet yakınlaştırma çerçevesi ekleyin.
4.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir slayta özet yakınlaştırma çerçevesi oluşturmayı gösterir:

``` java 
Presentation pres = new Presentation();
try {
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 1", slide);

    //Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 2", slide);

    //Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 3", slide);

    //Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 4", slide);

    // Bir SummaryZoomFrame nesnesi ekler
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Sunumu kaydeder
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Özet Yakınlaştırma Bölümü Ekleme ve Kaldırma**

Bir özet yakınlaştırma çerçevesindeki tüm bölümler, [ISummaryZoomSection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISummaryZoomSection) nesneleriyle temsil edilir ve [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISummaryZoomSectionCollection) nesnesinde depolanır. Bir özet yakınlaştırma bölüm nesnesini, [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISummaryZoomSectionCollection) arayüzü üzerinden şu şekilde ekleyebilir veya kaldırabilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2.	Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümler ekleyerek yeni slaytlar oluşturun.
3.	İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.
4.	Sunuma yeni bir slayt ve bölüm ekleyin.
5.	Oluşturulan bölümü özet yakınlaştırma çerçevesine ekleyin.
6.	İlk bölümü özet yakınlaştırma çerçevesinden kaldırın.
7.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir özet yakınlaştırma çerçevesine bölüm ekleme ve kaldırmayı gösterir:

``` java
Presentation pres = new Presentation();
try {
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 1", slide);

    //Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 2", slide);

    // SummaryZoomFrame nesnesi ekler
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Sunuma yeni bir bölüm ekler
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Summary Zoom'a bir bölüm ekler
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Summary Zoom'dan bölümü kaldırır
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Sunumu kaydeder
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Özet Yakınlaştırma Bölümlerini Biçimlendirme**

Daha karmaşık özet yakınlaştırma bölüm nesneleri oluşturmak için basit bir çerçevenin biçimini değiştirmeniz gerekir. Bir özet yakınlaştırma bölüm nesnesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır. 

Bir özet yakınlaştırma çerçevesindeki özet yakınlaştırma bölümü nesnesinin biçimini şu şekilde kontrol edebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2.	Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümler ekleyerek yeni slaytlar oluşturun.
3.	İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.
4.	`ISummaryZoomSectionCollection` nesnesinden ilk nesneye ait bir özet yakınlaştırma bölüm nesnesi alın.
7.	[IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPPImage) nesnesini, çerçeveyi doldurmak için kullanılacak bir görüntüyü [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesine bağlı images koleksiyonuna ekleyerek oluşturun.
8.	Oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir görüntü ayarlayın.
9.	*Bağlı bölümden orijinal slayta dönüş* özelliğini etkinleştirin. 
11.	İkinci yakınlaştırma çerçevesi nesnesinin çizgi biçimini değiştirin.
12.	Geçiş süresini değiştirin.
13.	Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir özet yakınlaştırma bölüm nesnesinin biçimini değiştirmeyi gösterir:

``` java
Presentation pres = new Presentation();
try {
    //Sunuma yeni bir slayt ekler
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 1", slide);

    //Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 2", slide);

    // SummaryZoomFrame nesnesi ekler
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // İlk SummaryZoomSection nesnesini alır
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // SummaryZoomSection nesnesi için biçimlendirme
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Sunumu kaydeder
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Hedef gösterildikten sonra 'ana' slayta geri dönmeyi kontrol edebilir miyim?**

Evet. [Zoom frame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/zoomframe/) veya [section](https://reference.aspose.com/slides/tr/java/com.aspose.slides/sectionzoomframe/) nesnesinin `ReturnToParent` davranışı, etkinleştirildiğinde izleyicileri hedef içeriğe gittikten sonra orijinal slayta geri gönderir.

**Zoom geçişinin 'hızını' veya süresini ayarlayabilir miyim?**

Evet. Zoom, `TransitionDuration` ayarlanarak atlama animasyonunun ne kadar süreceği kontrol edilebilir.

**Bir sunum kaç Zoom nesnesi içerebilir konusunda sınırlamalar var mı?**

Belirtilen bir API sınırı yoktur. Pratik limitler, sunumun genel karmaşıklığı ve izleyicinin performansına bağlıdır. Çok sayıda Zoom çerçevesi ekleyebilirsiniz, ancak dosya boyutu ve render süresini göz önünde bulundurun.
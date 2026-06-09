---
title: JavaScript'te Sunum Yakınlaştırmasını Yönet
linktitle: Yakınlaştırmayı Yönet
type: docs
weight: 60
url: /tr/nodejs-java/manage-zoom/
keywords:
- yakınlaştırma
- zoom çerçevesi
- slayt yakınlaştırma
- bölüm yakınlaştırma
- özet yakınlaştırma
- yakınlaştırma ekle
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile Yakınlaştırma oluşturun ve özelleştirin — bölümler arasında atlayın, PPT, PPTX ve ODP sunumları içinde küçük resimler ve geçişler ekleyin."
---
## **Giriş**

PowerPoint'teki Yakınlaştırmalar, bir sunumun belirli slaytlarına, bölümlerine ve bölümlerine atlamanızı sağlar. Sunum yaparken, içeriği hızlıca gezme yeteneği çok faydalı olabilir. 

![overview_image](overview.png)

* Tüm bir sunumu tek bir slaytta özetlemek için [Özet Yakınlaştırma](#Summary-Zoom) kullanın.
* Sadece seçili slaytları göstermek için [Slayt Yakınlaştırma](#Slide-Zoom) kullanın.
* Sadece tek bir bölümü göstermek için [Bölüm Yakınlaştırma](#Section-Zoom) kullanın.

## **Slayt Yakınlaştırma**

Bir slayt yakınlaştırma, sunumunuzu daha dinamik hâle getirebilir; istediğiniz sırada slaytlar arasında serbestçe gezmenizi sağlar ve sunum akışını kesmez. Slayt yakınlaştırmalar, çok bölümü olmayan kısa sunumlar için harikadır, ancak farklı sunum senaryolarında da kullanılabilir.

Slayt yakınlaştırmalar, tek bir tuvaldeymiş gibi birden fazla bilgi parçasını derinlemesine incelemenizi sağlar. 

![overview_image](slidezoomsel.png)

Slayt yakınlaştırma nesneleri için, Aspose.Slides [ZoomImageType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ZoomImageType) enum'ını, [ZoomFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ZoomFrame) sınıfını ve [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) sınıfı altında bazı yöntemleri sağlar.

### **Zoom Çerçeveleri Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Yakınlaştırma çerçevelerini bağlamak istediğiniz yeni slaytları oluşturun.  
3. Oluşturulan slaytlara bir tanımlama metni ve arka plan ekleyin.  
4. İlk slayta (oluşturulan slaytlara yapılan referansları içeren) yakınlaştırma çerçeveleri ekleyin.  
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Sunuma yeni slaytlar ekler
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // İkinci slayt için bir arka plan oluşturur
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // İkinci slayt için bir metin kutusu oluşturur
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Üçüncü slayt için bir arka plan oluşturur
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Üçüncü slayt için bir metin kutusu oluşturur
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // ZoomFrame nesnelerini ekler
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Sunumu kaydeder
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Özel Görsellerle Zoom Çerçeveleri Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Yakınlaştırma çerçevesini bağlamak istediğiniz yeni bir slayt oluşturun.  
3. Slayta bir tanımlama metni ve arka plan ekleyin.  
4. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) nesnesine bağlı Images koleksiyonuna bir görsel ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PPImage) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacaktır.  
5. İlk slayta (oluşturulan slayta yapılan referansı içeren) yakınlaştırma çerçeveleri ekleyin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Sunuma yeni bir slayt ekler
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // İkinci slayt için bir arka plan oluşturur
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Üçüncü slayt için bir metin kutusu oluşturur
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Zoom nesnesi için yeni bir görsel oluşturur
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // ZoomFrame nesnesini ekler
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Sunumu kaydeder
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Zoom Çerçevelerini Biçimlendirme**

Önceki bölümlerde basit zoom çerçeveleri oluşturmayı gösterdik. Daha karmaşık zoom çerçeveleri oluşturmak için basit bir çerçevenin biçimlendirmesini değiştirmeniz gerekir. Bir zoom çerçevesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır. 

Bir slayttaki zoom çerçevesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Yakınlaştırma çerçevesini bağlamak istediğiniz yeni slaytları oluşturun.  
3. Oluşturulan slaytlara bazı tanımlama metinleri ve arka plan ekleyin.  
4. İlk slayta (oluşturulan slaytlara yapılan referansları içeren) yakınlaştırma çerçeveleri ekleyin.  
5. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) nesnesine bağlı Images koleksiyonuna bir görsel ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PPImage) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacaktır.  
6. İlk zoom çerçevesi nesnesi için özel bir görsel ayarlayın.  
7. İkinci zoom çerçevesi nesnesinin çizgi biçimini değiştirin.  
8. İkinci zoom çerçevesi nesnesinin görselinin arka planını kaldırın.  
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Sunuma yeni slaytlar ekler
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // İkinci slayt için bir arka plan oluşturur
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // İkinci slayt için bir metin kutusu oluşturur
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Üçüncü slayt için bir arka plan oluşturur
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Üçüncü slayt için bir metin kutusu oluşturur
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // ZoomFrame nesnelerini ekler
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Zoom nesnesi için yeni bir görsel oluşturur
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // zoomFrame1 nesnesi için özel görsel ayarlar
    zoomFrame1.setImage(picture);
    // zoomFrame2 nesnesi için bir zoom çerçeve biçimi ayarlar
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // zoomFrame2 nesnesi için arka planı gösterme ayarı
    zoomFrame2.setShowBackground(false);
    // Sunumu kaydeder
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bölüm Yakınlaştırma**

Bölüm yakınlaştırması, sunumunuzdaki bir bölüme bağlantıdır. Bölüm yakınlaştırmalarını, gerçekten vurgulamak istediğiniz bölümlere geri dönmek için kullanabilirsiniz. Ya da sunumunuzun belirli parçalarının nasıl bağlandığını göstermek için kullanabilirsiniz. 

![overview_image](seczoomsel.png)

Bölüm yakınlaştırma nesneleri için, Aspose.Slides [SectionZoomFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SectionZoomFrame) sınıfını ve [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) sınıfı altında bazı yöntemleri sağlar.

### **Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Yeni bir slayt oluşturun.  
3. Oluşturulan slayta bir tanımlama arka planı ekleyin.  
4. Yakınlaştırma çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun.  
5. İlk slayta (oluşturulan bölüme yapılan referansları içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Sunuma yeni bir slayt ekler
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir Bölüm ekler
    pres.getSections().addSection("Section 1", slide);
    // SectionZoomFrame nesnesi ekler
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Sunumu kaydeder
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Özel Görsellerle Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

Aspose.Slides for Node.js via Java kullanarak, farklı bir slayt ön izleme görseliyle bir bölüm yakınlaştırma çerçevesi şu şekilde oluşturabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Yeni bir slayt oluşturun.  
3. Oluşturulan slayta bir tanımlama arka planı ekleyin.  
4. Yakınlaştırma çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun.  
5. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) nesnesine bağlı Images koleksiyonuna bir görsel ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PPImage) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacaktır.  
5. İlk slayta (oluşturulan bölüme yapılan referansı içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Sunuma yeni slayt ekler
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir Bölüm ekler
    pres.getSections().addSection("Section 1", slide);
    // Zoom nesnesi için yeni bir görsel oluşturur
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // SectionZoomFrame nesnesi ekler
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Sunumu kaydeder
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Bölüm Yakınlaştırma Çerçevelerini Biçimlendirme**

Daha karmaşık bölüm yakınlaştırma çerçeveleri oluşturmak için basit bir çerçevenin biçimlendirmesini değiştirmeniz gerekir. Bir bölüm yakınlaştırma çerçevesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır. 

Bir slayttaki bölüm yakınlaştırma çerçevesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Yeni bir slayt oluşturun.  
3. Oluşturulan slayta tanımlama arka planı ekleyin.  
4. Yakınlaştırma çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun.  
5. İlk slayta (oluşturulan bölüme yapılan referansları içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.  
6. Oluşturulan bölüm yakınlaştırma nesnesinin boyutunu ve konumunu değiştirin.  
7. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) nesnesine bağlı Images koleksiyonuna bir görsel ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PPImage) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacaktır.  
8. Oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir görsel ayarlayın.  
9. *Bağlantılı bölümden orijinal slayta geri dönme* yeteneğini ayarlayın.  
10. Bölüm yakınlaştırma çerçevesi nesnesinin görselinin arka planını kaldırın.  
11. İkinci zoom çerçevesi nesnesinin çizgi biçimini değiştirin.  
12. Geçiş süresini değiştirin.  
13. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Sunuma yeni bir slayt ekler
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir Bölüm ekler
    pres.getSections().addSection("Section 1", slide);
    // SectionZoomFrame nesnesi ekle
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // SectionZoomFrame için biçimlendirme
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Sunumu kaydeder
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Özet Yakınlaştırma**

Özet yakınlaştırma, sunumunuzun tüm parçalarının bir kerede gösterildiği bir açılış sayfası gibidir. Sunum yaparken, yakınlaştırmayı kullanarak istediğiniz sırayla bir yerden başka bir yere geçiş yapabilirsiniz. Yaratıcı olabilirsiniz, ilerleyebilir veya slayt gösterinizin parçalarını kesintisiz olarak yeniden ziyaret edebilirsiniz.

![overview_image](sumzoomsel.png)

Özet yakınlaştırma nesneleri için, Aspose.Slides [SummaryZoomFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SummaryZoomSection) ve [SummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SummaryZoomSectionCollection) sınıflarını ve [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) sınıfı altında bazı yöntemleri sağlar.

### **Özet Yakınlaştırma Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümler içeren yeni slaytlar oluşturun.  
3. İlk slayta özet yakınlaştırma çerçevesi ekleyin.  
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Sunuma yeni bir slayt ekler
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 1", slide);
    // Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 2", slide);
    // Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 3", slide);
    // Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 4", slide);
    // SummaryZoomFrame nesnesi ekler
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Sunumu kaydeder
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Özet Yakınlaştırma Bölümü Ekleme ve Kaldırma**

Özet yakınlaştırma çerçevesindeki tüm bölümler, [SummaryZoomSection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SummaryZoomSection) nesneleriyle temsil edilir ve [SummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SummaryZoomSectionCollection) nesnesinde depolanır. Bir özet yakınlaştırma bölümü nesnesini [SummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SummaryZoomSectionCollection) sınıfı aracılığıyla şu şekilde ekleyebilir veya kaldırabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümler içeren yeni slaytlar oluşturun.  
3. İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.  
4. Sunuma yeni bir slayt ve bölüm ekleyin.  
5. Oluşturulan bölümü özet yakınlaştırma çerçevesine ekleyin.  
6. İlk bölümü özet yakınlaştırma çerçevesinden kaldırın.  
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Sunuma yeni bir slayt ekler
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 1", slide);
    // Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 2", slide);
    // SummaryZoomFrame nesnesi ekler
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir bölüm ekler
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Summary Zoom'a bir bölüm ekler
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Summary Zoom'dan bölümü kaldırır
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Sunumu kaydeder
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Özet Yakınlaştırma Bölümlerini Biçimlendirme**

Daha karmaşık özet yakınlaştırma bölümü nesneleri oluşturmak için basit bir çerçevenin biçimlendirmesini değiştirmeniz gerekir. Bir özet yakınlaştırma bölümü nesnesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır. 

Bir özet yakınlaştırma çerçevesindeki özet yakınlaştırma bölümü nesnesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Oluşturulan slaytlar için tanımlama arka planı ve yeni bölümler içeren yeni slaytlar oluşturun.  
3. İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.  
4. `ISummaryZoomSectionCollection` üzerinden ilk nesne için bir özet yakınlaştırma bölümü nesnesi alın.  
7. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) nesnesine bağlı Images koleksiyonuna bir görsel ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PPImage) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacaktır.  
8. Oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir görsel ayarlayın.  
9. *Bağlantılı bölümden orijinal slayta geri dönme* yeteneğini ayarlayın.  
11. İkinci zoom çerçevesi nesnesinin çizgi biçimini değiştirin.  
12. Geçiş süresini değiştirin.  
13. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Sunuma yeni bir slayt ekler
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 1", slide);
    // Sunuma yeni bir slayt ekler
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Sunuma yeni bir bölüm ekler
    pres.getSections().addSection("Section 2", slide);
    // SummaryZoomFrame nesnesi ekler
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // İlk SummaryZoomSection nesnesini alır
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // SummaryZoomSection nesnesi için biçimlendirme
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Sunumu kaydeder
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Hedef gösterildikten sonra 'üst' slayta dönmeyi kontrol edebilir miyim?**

Evet. [Zoom frame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zoomframe/) veya [section](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sectionzoomframe/) nesnesinin `setReturnToParent` yöntemi etkinleştirildiğinde, izleyicileri hedef içeriği ziyaret ettikten sonra orijinal slayta geri gönderir.

**Zoom geçişinin 'hızını' veya süresini ayarlayabilir miyim?**

Evet. Zoom, atlama animasyonunun ne kadar süreceğini kontrol etmenizi sağlayan bir `setTransitionDuration` yöntemi sunar.

**Bir sunum kaç Zoom nesnesi içerebilir konusunda sınırlamalar var mı?**

Belirtilen kesin bir API sınırı bulunmamaktadır. Pratik sınırlamalar, sunumun genel karmaşıklığı ve izleyicinin performansına bağlıdır. Çok sayıda Zoom çerçevesi ekleyebilirsiniz, ancak dosya boyutu ve render süresini göz önünde bulundurun.
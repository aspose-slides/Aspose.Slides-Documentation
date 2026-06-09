---
title: C++ ile Sunum Yakınlaştırmasını Yönet
linktitle: Yakınlaştırmayı Yönet
type: docs
weight: 60
url: /tr/cpp/manage-zoom/
keywords:
- yakınlaştırma
- yakınlaştırma çerçevesi
- slayt yakınlaştırması
- bölüm yakınlaştırması
- özet yakınlaştırması
- yakınlaştırma ekle
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile Yakınlaştırma oluşturun ve özelleştirin — PPT, PPTX ve ODP sunumları arasında bölümler arasında geçiş yapın, küçük resimler ve geçişler ekleyin."
---
## **Giriş**

PowerPoint yakınlaştırmaları, belirli slaytlara, bölümlere ve bir sunumun bölümlerine atlamanızı sağlar. Sunum yaparken, içeriği hızlıca dolaşma yeteneği çok faydalı olabilir. 

![overview_image](Overview.png)

* Tek bir slayt üzerinde tüm sunumu özetlemek için bir [Summary Zoom](#Summary-Zoom) kullanın.
* Sadece seçili slaytları göstermek için bir [Slide Zoom](#Slide-Zoom) kullanın.
* Sadece tek bir bölümü göstermek için bir [Section Zoom](#Section-Zoom) kullanın.

## **Slayt Yakınlaştırma**
Bir slayt yakınlaştırması, sunumunuzu daha dinamik hâle getirebilir; istediğiniz sırayla slaytlar arasında kesintisiz olarak dolaşmanızı sağlar. Slayt yakınlaştırmaları, çok sayıda bölümü olmayan kısa sunumlar için harikadır, ancak farklı sunum senaryolarında da kullanılabilir.

Slayt yakınlaştırmaları, tek bir tuval üzerindeymiş gibi birden fazla bilgi parçasına derinlemesine bakmanıza olanak tanır. 

![overview_image](slidezoomsel.png)

Slayt yakınlaştırma nesneleri için Aspose.Slides, [ZoomImageType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/zoomimagetype/) enum değerini, [IZoomFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/izoomframe/) arayüzünü ve [IShapeCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/) arayüzü altındaki bazı yöntemleri sunar.

### **Yakınlaştırma Çerçeveleri Oluşturma**

Bir slayta yakınlaştırma çerçevesi şu şekilde eklenebilir:

1.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Yakınlaştırma çerçevelerini bağlamak istediğiniz yeni slaytları oluşturun. 
3.	Oluşturulan slaytlara bir kimlik metni ve arka plan ekleyin.
4.	İlk slayta (oluşturulan slaytlara referanslar içeren) yakınlaştırma çerçeveleri ekleyin.
5.	Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu C++ kodu, bir slayta yakınlaştırma çerçevesi oluşturmayı gösterir:

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Sunuma yeni slaytlar ekler
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

//İkinci slayt için arka plan oluşturur
SetSlideBackground(slide2, Color::get_Cyan());

//İkinci slayt için bir metin kutusu oluşturur
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Üçüncü slayt için arka plan oluşturur
SetSlideBackground(slide3, Color::get_DarkKhaki());

//Üçüncü slayt için bir metin kutusu oluşturur
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//ZoomFrame nesnelerini ekler
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

//Sunumu kaydeder
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Özel Görsellerle Yakınlaştırma Çerçeveleri Oluşturma**
Aspose.Slides for C++ ile farklı bir slayt önizleme görseli kullanarak bir yakınlaştırma çerçevesi şu şekilde oluşturabilirsiniz: 
1.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Yakınlaştırma çerçevesini bağlamak istediğiniz yeni bir slayt oluşturun. 
3.	Slayta bir kimlik metni ve arka plan ekleyin.
4.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesine ilişkin Images koleksiyonuna bir görsel ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacak.
5.	İlk slayta (oluşturulan slayta referans içeren) yakınlaştırma çerçeveleri ekleyin.
6.	Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu C++ kodu, farklı bir görsel ile bir yakınlaştırma çerçevesi oluşturmayı gösterir:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Sunuma yeni bir slayt ekler
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// İkinci slayt için arka plan oluşturur
SetSlideBackground(slide, Color::get_Cyan());

// Üçüncü slayt için bir metin kutusu oluşturur
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Yakınlaştırma nesnesi için yeni bir görsel oluşturur
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//ZoomFrame nesnesini ekler
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Sunumu kaydeder
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Yakınlaştırma Çerçevelerini Biçimlendirme**
Önceki bölümlerde basit yakınlaştırma çerçevelerinin nasıl oluşturulacağını gösterdik. Daha karmaşık yakınlaştırma çerçeveleri oluşturmak için basit bir çerçevenin biçimlendirmesini değiştirmeniz gerekir. Bir yakınlaştırma çerçevesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır. 

Bir slaytta bir yakınlaştırma çerçevesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Yakınlaştırma çerçevesini bağlamak istediğiniz yeni slaytları oluşturun. 
3.	Oluşturulan slaytlara bazı kimlik metinleri ve arka plan ekleyin.
4.	İlk slayta (oluşturulan slaytlara referanslar içeren) yakınlaştırma çerçeveleri ekleyin.
5.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesine ilişkin Images koleksiyonuna bir görsel ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacak.
6.	İlk yakınlaştırma çerçevesi nesnesi için özel bir görsel ayarlayın.
7.	İkinci yakınlaştırma çerçevesi nesnesinin çizgi biçimini değiştirin.
8.	İkinci yakınlaştırma çerçevesi nesnesinin görselinden arka planı kaldırın.
5.	Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu C++ kodu, bir slaytta bir yakınlaştırma çerçevesinin biçimlendirmesini değiştirmeyi gösterir: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Sunuma yeni slaytlar ekler
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

//İkinci slayt için arka plan oluşturur
SetSlideBackground(slide2, Color::get_Cyan());

//İkinci slayt için bir metin kutusu oluşturur
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Üçüncü slayt için arka plan oluşturur
SetSlideBackground(slide3, Color::get_DarkKhaki());

//Üçüncü slayt için bir metin kutusu oluşturur
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//ZoomFrame nesnelerini ekler
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

//Yakınlaştırma nesnesi için yeni bir görsel oluşturur
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
//zoomFrame1 nesnesi için özel görsel ayarlar
zoomFrame1->set_Image(image);

//zoomFrame2 nesnesi için bir yakınlaştırma çerçevesi biçimi ayarlar
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

//zoomFrame2 nesnesi için arka plan gösterme ayarı
zoomFrame2->set_ShowBackground(false);

//Sunumu kaydeder
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Bölüm Yakınlaştırma**

Bölüm yakınlaştırması, sunumunuzdaki bir bölüme bağlantıdır. Bölüm yakınlaştırmalarını, gerçekten vurgulamak istediğiniz bölümlere geri dönmek için kullanabilirsiniz. Ya da sunumunuzun belirli parçalarının nasıl bağlandığını göstermek amacıyla kullanabilirsiniz. 

![overview_image](seczoomsel.png)

Bölüm yakınlaştırma nesneleri için Aspose.Slides, [ISectionZoomFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isectionzoomframe/) arayüzünü ve [IShapeCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/) arayüzü altındaki bazı yöntemleri sağlar.

### **Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

Bir slayta bölüm yakınlaştırma çerçevesi şu şekilde eklenebilir:

1.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Yeni bir slayt oluşturun. 
3.	Oluşturulan slayta bir kimlik arka planı ekleyin.
4.	Yakınlaştırma çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun. 
5.	İlk slayta (oluşturulan bölüme referanslar içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.
6.	Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu C++ kodu, bir slayta bir yakınlaştırma çerçevesi oluşturmayı gösterir:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Sunuma yeni bir slayt ekler
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Sunuma yeni bir Bölüm ekler
pres->get_Sections()->AddSection(u"Section 1", slide);

// Bir SectionZoomFrame nesnesi ekler
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Sunumu kaydeder
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Özel Görsellerle Bölüm Yakınlaştırma Çerçeveleri Oluşturma**

Aspose.Slides for C++ ile farklı bir slayt önizleme görseli kullanarak bir bölüm yakınlaştırma çerçevesi şu şekilde oluşturabilirsiniz: 

1.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Yeni bir slayt oluşturun.
3.	Oluşturulan slayta bir kimlik arka planı ekleyin.
4.	Yakınlaştırma çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun. 
5.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesine ilişkin Images koleksiyonuna bir görsel ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacak.
5.	İlk slayta (oluşturulan bölüme referans içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.
6.	Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu C++ kodu, farklı bir görsel ile bir yakınlaştırma çerçevesi oluşturmayı gösterir:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Sunuma yeni bir slayt ekler
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Sunuma yeni bir Bölüm ekler
pres->get_Sections()->AddSection(u"Section 1", slide);

// Yakınlaştırma nesnesi için yeni bir görsel oluşturur
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// SectionZoomFrame nesnesi ekler
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Sunumu kaydeder
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Bölüm Yakınlaştırma Çerçevelerini Biçimlendirme**

Daha karmaşık bölüm yakınlaştırma çerçeveleri oluşturmak için basit bir çerçevenin biçimlendirmesini değiştirmeniz gerekir. Bir bölüm yakınlaştırma çerçevesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır. 

Bir slaytta bir bölüm yakınlaştırma çerçevesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Yeni bir slayt oluşturun.
3.	Oluşturulan slayta kimlik arka planı ekleyin.
4.	Yakınlaştırma çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun. 
5.	İlk slayta (oluşturulan bölüme referanslar içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.
6.	​Oluşturulan bölüm yakınlaştırma nesnesinin boyut ve konumunu değiştirin.
7.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesine ilişkin Images koleksiyonuna bir görsel ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacak.
8.	​Oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir görsel ayarlayın.
9.	​“Bağlantılı bölümlerden orijinal slayta dönme” özelliğini etkinleştirin. 
10.	​Bölüm yakınlaştırma çerçevesi nesnesinin görselinden arka planı kaldırın.
11.	​İkinci yakınlaştırma çerçevesi nesnesinin çizgi biçimini değiştirin.
12.	​Geçiş süresini değiştirin.
13.	Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu C++ kodu, bir bölüm yakınlaştırma çerçevesinin biçimlendirmesini değiştirmenizi gösterir:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Sunuma yeni bir slayt ekler
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Sunuma yeni bir Bölüm ekler
pres->get_Sections()->AddSection(u"Section 1", slide);

// SectionZoomFrame nesnesi ekler
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// SectionZoomFrame için biçimlendirme
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Sunumu kaydeder
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Özet Yakınlaştırma**

Özet yakınlaştırma, sunumunuzun tüm parçalarının aynı anda gösterildiği bir açılış sayfası gibidir. Sunum yaparken, yakınlaştırmayı kullanarak sunumunuzdaki bir yerden başka bir yere istediğiniz sırada gidebilirsiniz. Yaratıcı olabilir, ileri atlayabilir veya slayt gösterinizin parçalarını akışı bozmadan yeniden ziyaret edebilirsiniz.

![overview_image](sumzoomsel.png)

Özet yakınlaştırma nesneleri için Aspose.Slides, [ISummaryZoomFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isummaryzoomsection/) ve [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isummaryzoomsectioncollection/) arayüzlerini ve [IShapeCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/) arayüzü altındaki bazı yöntemleri sağlar.

### **Özet Yakınlaştırma Oluşturma**

Bir slayta özet yakınlaştırma çerçevesi şu şekilde eklenebilir:

1.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Kimlik arka planı ve yeni bölümleri olan yeni slaytlar oluşturun.
3.	İlk slayta özet yakınlaştırma çerçevesi ekleyin.
4.	Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu C++ kodu, bir slayta bir özet yakınlaştırma çerçevesi oluşturmayı gösterir:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Sunuma yeni bir slayt ekler
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Sunuma yeni bir bölüm ekler
pres->get_Sections()->AddSection(u"Section 1", slide);

// Sunuma yeni bir slayt ekler
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Sunuma yeni bir bölüm ekler
pres->get_Sections()->AddSection(u"Section 2", slide);

// Sunuma yeni bir slayt ekler
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Sunuma yeni bir bölüm ekler
pres->get_Sections()->AddSection(u"Section 3", slide);

// Sunuma yeni bir slayt ekler
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Sunuma yeni bir bölüm ekler
pres->get_Sections()->AddSection(u"Section 4", slide);

// SummaryZoomFrame nesnesi ekler
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Sunumu kaydeder
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Özet Yakınlaştırma Bölümü Ekleme ve Kaldırma**

Bir özet yakınlaştırma çerçevesindeki tüm bölümler, [ISummaryZoomSection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isummaryzoomsection/) nesneleriyle temsil edilir ve [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isummaryzoomsectioncollection/) nesnesinde depolanır. Bir özet yakınlaştırma bölüm nesnesini ekleyebilir veya kaldırabilirsiniz; bunun için [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isummaryzoomsectioncollection/) arayüzü şu şekilde kullanılır:

1.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Kimlik arka planı ve yeni bölümleri olan yeni slaytlar oluşturun.
3.	İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.
4.	Sunuma yeni bir slayt ve bölüm ekleyin.
5.	​Oluşturulan bölümü özet yakınlaştırma çerçevesine ekleyin.
6.	​İlk bölümü özet yakınlaştırma çerçevesinden kaldırın.
7.	Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu C++ kodu, bir özet yakınlaştırma çerçevesine bölüm ekleme ve kaldırma işlemlerini gösterir:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Sunuma yeni bir slayt ekler
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Sunuma yeni bir bölüm ekler
pres->get_Sections()->AddSection(u"Section 1", slide);

//Sunuma yeni bir slayt ekler
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Sunuma yeni bir bölüm ekler
pres->get_Sections()->AddSection(u"Section 2", slide);

// SummaryZoomFrame nesnesi ekler
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Sunuma yeni bir slayt ekler
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Sunuma yeni bir bölüm ekler
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Summary Zoom'a bir bölüm ekler
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Summary Zoom'dan bölümü kaldırır
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Sunumu kaydeder
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Özet Yakınlaştırma Bölümlerini Biçimlendirme**

Daha karmaşık özet yakınlaştırma bölüm nesneleri oluşturmak için basit bir çerçevenin biçimlendirmesini değiştirmeniz gerekir. Bir özet yakınlaştırma bölüm nesnesine uygulayabileceğiniz çeşitli biçimlendirme seçenekleri vardır. 

Özet yakınlaştırma çerçevesindeki bir bölüm nesnesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Kimlik arka planı ve yeni bölümleri olan yeni slaytlar oluşturun.
3.	İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.
4.	`ISummaryZoomSectionCollection` üzerinden ilk nesne için bir özet yakınlaştırma bölüm nesnesi alın.
7.	[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesine ilişkin Images koleksiyonuna bir görsel ekleyerek bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacak.
8.	​Oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir görsel ayarlayın.
9.	​“Bağlantılı bölümlerden orijinal slayta dönme” özelliğini etkinleştirin. 
11.	​İkinci yakınlaştırma çerçevesi nesnesinin çizgi biçimini değiştirin.
12.	​Geçiş süresini değiştirin.
13.	Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu C++ kodu, bir özet yakınlaştırma bölüm nesnesinin biçimlendirmesini değiştirmeyi gösterir:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Sunuma yeni bir slayt ekler
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Sunuma yeni bir bölüm ekler
pres->get_Sections()->AddSection(u"Section 1", slide);

//Sunuma yeni bir slayt ekler
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Sunuma yeni bir bölüm ekler
pres->get_Sections()->AddSection(u"Section 2", slide);

// SummaryZoomFrame nesnesi ekler
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// İlk SummaryZoomSection nesnesini alır
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// SummaryZoomSection nesnesi için biçimlendirme
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Sunumu kaydeder
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **SSS**

**Hedef gösterildikten sonra 'üst' slayta dönmeyi kontrol edebilir miyim?**

Evet. [Zoom frame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/zoomframe/) veya [section](https://reference.aspose.com/slides/tr/cpp/aspose.slides/sectionzoomframe/) nesnesinin `set_ReturnToParent` yöntemi, izleyicileri hedef içeriği ziyaret ettikten sonra orijinal slayta geri gönderir.

**Zoom geçişinin 'hızını' veya süresini ayarlayabilir miyim?**

Evet. Zoom, geçiş süresini ayarlamayı destekler; böylece atlama animasyonunun ne kadar süreceğini kontrol edebilirsiniz.

**Bir sunumda kaç tane Zoom nesnesi bulunabileceği konusunda sınırlamalar var mı?**

Belirtilen bir API sınırı yoktur. Pratik sınırlamalar, sunumun genel karmaşıklığı ve izleyicinin performansına bağlıdır. Çok sayıda Zoom çerçevesi ekleyebilirsiniz, ancak dosya boyutu ve işleme süresini göz önünde bulundurun.
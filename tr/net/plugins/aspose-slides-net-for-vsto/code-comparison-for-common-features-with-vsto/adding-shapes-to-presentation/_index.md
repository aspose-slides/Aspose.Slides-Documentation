---
title: Sunuma Şekil Ekleme
type: docs
weight: 30
url: /tr/net/adding-shapes-to-presentation/
---
## **VSTO**
Aşağıda, çizgi şekli eklemek için kod parçacığı bulunmaktadır:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Sunumun seçilen slaytına basit bir düz çizgi eklemek için lütfen aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Bir slaytın referansını, indeksini kullanarak alın
- Shapes nesnesi tarafından verilen AddAutoShape yöntemi ile Çizgi tipinde bir AutoShape ekleyin
- Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin

Aşağıda verilen örnekte, sunumun ilk slaytına bir çizgi ekledik.

``` csharp

   //PPTX'i temsil eden Presentation sınıfının bir örneğini oluştur

  Presentation pres = new Presentation();

  //İlk slaytı al

  ISlide slide = pres.Slides[0];

  //Çizgi tipinde bir autoshape ekle

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Çalışan Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)
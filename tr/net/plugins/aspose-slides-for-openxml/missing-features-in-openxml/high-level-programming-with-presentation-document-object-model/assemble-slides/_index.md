---
title: Slaytları Birleştir
type: docs
weight: 10
url: /tr/net/assemble-slides/
---
## **Sunuma Bir Slayt Ekleme**
Sunum dosyalarına slayt eklemeden önce, slaytlar hakkında bazı gerçekleri tartışalım. Her PowerPoint sunum dosyası, Master / Layout slaytı ve diğer Normal slaytları içerir. Bu, bir sunum dosyasının en az bir veya daha fazla slayt içerdiği anlamına gelir. Slaytsız sunum dosyalarının Aspose.Slides for .NET tarafından desteklenmediğini bilmek önemlidir. Her slayt benzersiz bir Id'ye sahiptir ve tüm Normal Slaytlar, sıfır tabanlı indeksle belirtilen bir sırada düzenlenir.

Aspose.Slides for .NET, geliştiricilerin sunumlarına boş slayt eklemelerine olanak tanır. Sunuma bir boş slayt eklemek için lütfen aşağıdaki adımları izleyin:

- **Presentation** sınıfının bir örneğini oluşturun
- **SlideCollection** sınıfını, Presentation nesnesi tarafından sunulan Slides (içerik Slide nesnelerinin koleksiyonu) özelliğine bir referans ayarlayarak örnekleyin
- **SlideCollection** nesnesi tarafından sunulan **AddEmptySlide** metodunu çağırarak içerik slaytları koleksiyonunun sonuna bir boş slayt ekleyin
- Yeni eklenen boş slayt ile bazı işlemler yapın
- Son olarak, **Presentation** nesnesini kullanarak sunum dosyasını kaydedin

``` csharp

 PresentationEx pres = new PresentationEx();
//SlideCollection sınıfını örnekle
SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)
{

	//Slides koleksiyonuna bir boş slayt ekle
	slds.AddEmptySlide(pres.LayoutSlides[i]);
}

//PPTX dosyasını diske kaydet
pres.Write("EmptySlide.pptx");
``` 
## **Sunumdaki Slaytlara Erişme**
Aspose.Slides for .NET, sunum içinde bulunan istenen herhangi bir slaytı bulmak ve erişmek için kullanılabilen Presentation sınıfını sağlar.

**Slides Koleksiyonunu Kullanma**

**Presentation** sınıfı bir sunum dosyasını temsil eder ve içindeki tüm slaytları **SlideCollection** koleksiyonu (yani **Slide** nesnelerinin bir koleksiyonu) olarak sunar. Bu slaytlara, bir slayt indeksi kullanılarak **Slides** koleksiyonundan erişilebilir.

``` csharp

 //Bir sunum dosyasını temsil eden Presentation nesnesini örnekle
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Bir slaytı slayt indeksi kullanarak erişme
SlideEx slide = pres.Slides[0];

``` 
## **Slaytları Kaldırma**
**Aspose.Slides for .NET**'deki Presentation sınıfının bir sunum dosyasını temsil ettiğini biliyoruz. Presentation sınıfı, sunumun bir parçası olan tüm slaytların deposu olarak işlev gören bir **SlideCollection**'ı kapsüller. Geliştiriciler bu Slides koleksiyonundan bir slaytı iki şekilde kaldırabilirler:

- Slayt Referansını Kullanarak
- Slayt İndeksini Kullanarak

**Slayt Referansını Kullanarak**

Bir slaytı referansını kullanarak kaldırmak için lütfen aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Bir slaytın referansını Id'si veya İndeksi ile elde edin
- Referans alınan slaytı sunumdan kaldırın
- Değiştirilmiş sunum dosyasını kaydedin

``` csharp

 //Bir sunum dosyasını temsil eden Presentation nesnesini örnekle
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Slaytlar koleksiyonundaki indeksini kullanarak bir slayta erişme
SlideEx slide = pres.Slides[0];

//Bir slaytı referansını kullanarak kaldırma
pres.Slides.Remove(slide);

//Sunum dosyasını yazma
pres.Write("modified.pptx");

``` 
## **Bir Slaytın Konumunu Değiştirme**
Sunumda bir slaytın konumunu değiştirmek çok basittir. Sadece aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Bir slaytın referansını İndeksi ile elde edin
- Referans alınan slaytın SlideNumber değerini değiştirin
- Değiştirilmiş sunum dosyasını kaydedin

Aşağıdaki örnekte, sunumun (sıfır indeksindeki 1. pozisyonda bulunan) bir slaytının konumunu indeks 1 (Pozisyon 2) olarak değiştirdik.

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//SlideCollection sınıfını örnekle

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Slides koleksiyonuna bir boş slayt ekle

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//PPTX dosyasını diske kaydet

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Bir sunum dosyasını temsil eden Presentation nesnesini örnekle

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Bir slaytı slayt indeksi kullanarak erişme

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Bir sunum dosyasını temsil eden Presentation nesnesini örnekle

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Slaytlar koleksiyonundaki indeksini kullanarak bir slayta erişme

ISlide slide = pres.Slides[0];

//Bir slaytı referansını kullanarak kaldırma

pres.Slides.Remove(slide);

//Sunum dosyasını yazma

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Pozisyonu değiştirilecek slaytı al

    ISlide sld = pres.Slides[0];

    //Slayt için yeni pozisyonu ayarla

    sld.SlideNumber = 2;

    //Sunumu diske kaydet

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)
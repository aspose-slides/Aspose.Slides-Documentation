---
title: Aspose.Slides for .NET 14.4.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 14.4.0
type: docs
weight: 60
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
## **Genel API ve Geriye Uyumsuz Değişiklikler**
### **Eklenen Arayüzler, Sınıflar, Metodlar ve Özellikler**
#### **Aspose.Slides.ILayoutSlide.HasDependingSlides Özelliği Eklendi**
Aspose.Slides.ILayoutSlide.HasDependingSlides özelliği, bu yerleşim slaytına bağlı en az bir slayt bulunuyorsa true döner. Örneğin:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() Metodu**
Aspose.Slides.ILayoutSlide.Remove() metodu, bir sunumdan yerleşimi en az kodla kaldırmanıza olanak tanır. Örneğin:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) Metodu**
Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) metodu, koleksiyondan bir yerleşim kaldırmanıza izin verir. Kod örnekleri:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

veya

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Aspose.Slides.ILayoutSlideCollection.RemoveUnused() metodu, kullanılmayan yerleşim slaytlarını (HasDependingSlides özelliği false olan yerleşim slaytları) kaldırmanıza olanak tanır. Kod örnekleri:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

veya

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides Özelliği**
Aspose.Slides.IMasterSlide.HasDependingSlides özelliği, bu master slayta bağlı en az bir slayt bulunuyorsa true döner. Örneğin:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() Metodu**
Aspose.Slides.ISlide.Remove() metodu, bir sunumdan bir slaytı en az kodla kaldırmanıza olanak tanır. Örneğin:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat özelliği, yerleşim noktaları (bullets) sağlıyorsa bir SmartArt düğmesi için IFillFormat döndürür. Bu özellik, madde işareti resmini ayarlamak için kullanılabilir.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level Özelliği**
Aspose.Slides.SmartArt.ISmartArtNode.Level özelliği, SmartArt düğümlerinin iç içe geçmiş seviyesini döndürür.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position Özelliği**
Aspose.Slides.SmartArt.ISmartArtNode.Position özelliği, bir düğümün kardeşleri arasındaki konumunu döndürür.

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Remove() Metodu Eklendi**
Aspose.Slides.SmartArt.ISmartArtNode.Remove() metodu, bir diyagramdan bir düğümün kaldırılmasını sağlar.

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection Arayüzü ve GlobalLayoutSlideCollection Sınıfı**
IGlobalLayoutSlideCollection arayüzü ve GlobalLayoutSlideCollection sınıfı Aspose.Slides ad alanına eklenmiştir.

GlobalLayoutSlideCollection sınıfı IGlobalLayoutSlideCollection arayüzünü uygular.

IGlobalLayoutSlideCollection arayüzü, bir sunumdaki tüm yerleşim slaytlarının koleksiyonunu temsil eder. IPresentation.LayoutSlides özelliği IGlobalLayoutSlideCollection tipindedir. IGlobalLayoutSlideCollection, bireysel master yerleşim slayt koleksiyonlarını birleştirme bağlamında yerleşim slaytları ekleme ve kopyalama metodlarıyla ILayoutSlideCollection arayüzünü genişletir:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Belirli bir yerleşim slaytının bir kopyasını sunuma eklemek için kullanılabilir. Bu metod kaynak biçimlendirmesini korur (farklı sunumlar arasında yerleşim kopyalanırken master da kopyalanabilir. Aynı master slaytının birden fazla kopyasının oluşturulmasını önlemek için iç kayıt defteri otomatik olarak kopyalanan master’ları izler.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Belirli bir yerleşim slaytının bir kopyasını bir sunuma eklemek için kullanılır. Yeni yerleşim, hedef sunumdaki tanımlı master’a bağlanır. Bu seçenek, Microsoft PowerPoint’te **Use Destination Theme** seçeneğiyle kopyalama veya yapıştırmaya benzer.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Bir sunuma yeni bir yerleşim slaytı eklemek için kullanılır. Desteklenen yerleşim türleri: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Yerleşim adı otomatik olarak üretilebilir. SlideLayoutType.Custom türündeki eklenen yerleşim hiçbir yer tutucu ve şekil içermez. Bu metodun analoğu, IMasterSlide.LayoutSlides özelliğiyle erişilen IMasterLayoutSlideCollection.Add(SlideLayoutType, string) metodudur.
#### **Interface IMasterLayoutSlideCollection ve Class MasterLayoutSlideCollection**
IMasterLayoutSlideCollection arayüzü ve MasterLayoutSlideCollection sınıfı Aspose.Slides ad alanına eklenmiştir. MasterLayoutSlideCollection sınıfı IMasterLayoutSlideCollection arayüzünü uygular.

IMasterLayoutSlideCollection arayüzü, tanımlı bir master slaytın tüm yerleşim slaytlarının koleksiyonunu temsil eder. Bu arayüz, bir master’ın yerleşim slayt koleksiyonları bağlamında yerleşim slaytlarını ekleme, ekleme konumuna yerleştirme, kaldırma veya kopyalama metodlarıyla ILayoutSlideCollection arayüzünü genişletir:

``` csharp

 // Yöntem imzası:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Kaynak yerleşimin bir kopyasını destMasterSlide'e ekleyen kod örneği:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);
``` 

Bu metod, belirtilen yerleşim slaytının bir kopyasını koleksiyonun sonuna eklemek için kullanılabilir. Yeni yerleşim, bu yerleşim slaytları koleksiyonu için üst master slaytla bağlantılı olur. Bu, PowerPoint’te **Use Destination Theme** seçeneğiyle kopyalama veya yapıştırmaya benzer. Bu metodun analoğu, IPresentation.LayoutSlides özelliğiyle erişilen IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) metodudur.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Belirli bir yerleşim slaytının bir kopyasını koleksiyondaki belirtilen konuma eklemek için kullanılır. Yeni yerleşim, bu yerleşim slaytları koleksiyonu için üst master slaytla bağlantılı olur. Bu, PowerPoint’te **Use Destination Theme** seçeneğiyle kopyalama ve yapıştırmaya benzer.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Yeni bir yerleşim slaytı eklemek veya eklemek için kullanılır. Desteklenen yerleşim türleri: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Yerleşim adı otomatik olarak üretilebilir. SlideLayoutType.Custom türündeki eklenen yerleşim hiçbir yer tutucu ve şekil içermez. Bu metodun analoğu, IPresentation.LayoutSlides özelliğiyle erişilen IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) metodudur.
- void RemoveAt(int index); – Belirtilen indeksteki yerleşimi koleksiyondan kaldırmak için kullanılır.
- void Reorder(int index, ILayoutSlide layoutSlide); – Yerleşim slaytını koleksiyondan belirtilen konuma taşımak için kullanılır.
### **Değiştirilen Metodlar ve Özellikler**
#### **Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) Metodunun İmzası**
ISlideCollection metodunun imzası:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

artık eski olup aşağıdaki imza ile değiştirilmiştir:

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

allowCloneMissingLayout parametresi, yeni (kopyalanmış) slayt için destMaster’da uygun bir yerleşim bulunmadığında ne yapılacağını belirtir. Uygun yerleşim, kaynak slaydın yerleşim tipi veya adıyla aynı olan yerleşimdir. Belirtilen master’da uygun bir yerleşim yoksa, kaynak slaydın yerleşimi (allowCloneMissingLayout true ise) kopyalanır veya (allowCloneMissingLayout false ise) bir PptxEditException fırlatılır.

Eski metod şu şekilde çağrıldığında:

AddClone(sourceSlide, destMaster);

allowCloneMissingLayout parametresi false kabul edilir (yani uygun yerleşim yoksa PptxEditException fırlatılır). Yeni imza ile aynı işlevi gören çağrı şu şekildedir:
AddClone(sourceSlide, destMaster, false);

Eksik yerleşimlerin otomatik olarak kopyalanmasını, PptxEditException fırlatılması yerine istiyorsanız, allowCloneMissingLayout parametresini true olarak geçirin.

Aşağıdaki ISlideCollection metodu da aynı şekilde:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

artık eski olup aşağıdaki imza ile değiştirilmiştir:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Aspose.Slides.IMasterSlide.LayoutSlides Özelliğinin Türü**
Aspose.Slides.IMasterSlide.LayoutSlides özelliğinin türü ILayoutSlideCollection’dan yeni IMasterLayoutSlideCollection arayüzüne değiştirilmiştir. IMasterLayoutSlideCollection arayüzü ILayoutSlideCollection’ın bir türevidir, bu yüzden mevcut kodun uyarlamaya ihtiyacı yoktur.
#### **Aspose.Slides.IPresentation.LayoutSlides Özelliğinin Türü Değiştirildi**
Aspose.Slides.IPresentation.LayoutSlides özelliğinin türü ILayoutSlideCollection’dan yeni IGlobalLayoutSlideCollection arayüzüne değiştirilmiştir. IGlobalLayoutSlideCollection arayüzü ILayoutSlideCollection’ın bir türevidir, bu yüzden mevcut kodun uyarlamaya ihtiyacı yoktur.
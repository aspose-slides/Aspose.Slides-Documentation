---
title: .NET'te Sunumlarda Görüntü Yönetimini Optimize Et
linktitle: Görüntüleri Yönet
type: docs
weight: 10
url: /tr/net/image/
keywords:
- görüntü ekle
- resim ekle
- bitmap ekle
- görüntüyü değiştir
- resmi değiştir
- web'den
- arka plan
- PNG ekle
- JPG ekle
- SVG ekle
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument'te görüntü yönetimini basitleştirerek, performansı artırın ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller sunumları daha çekici ve ilgi çekici hâle getirir. Microsoft PowerPoint'te bir dosyadan, internetteki bir kaynaktan ya da diğer konumlardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides sunumlarınızdaki slaytlara çeşitli prosedürler aracılığıyla resim eklemenizi sağlar.

{{% alert  title="Tip" color="primary" %}} 

Aspose, insanlara görüntülerden hızlı bir şekilde sunum oluşturma imkanı sunan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Bir resmi çerçeve nesnesi olarak eklemek istiyorsanız—özellikle boyutunu değiştirmek, efekt eklemek vb. için standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Picture Frame](https://docs.aspose.com/slides/tr/net/picture-frame/) bölümüne bakın. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Görüntüler ve PowerPoint sunumlarıyla ilgili giriş/çıkış işlemlerini manipüle ederek bir resmi bir formattan başka bir formata dönüştürebilirsiniz. Bu sayfalara bakın: dönüştür [image to JPG](https://products.aspose.com/slides/tr/net/conversion/image-to-jpg/); dönüştür [JPG to image](https://products.aspose.com/slides/tr/net/conversion/jpg-to-image/); dönüştür [JPG to PNG](https://products.aspose.com/slides/tr/net/conversion/jpg-to-png/), dönüştür [PNG to JPG](https://products.aspose.com/slides/tr/net/conversion/png-to-jpg/); dönüştür [PNG to SVG](https://products.aspose.com/slides/tr/net/conversion/png-to-svg/), dönüştür [SVG to PNG](https://products.aspose.com/slides/tr/net/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF ve diğer popüler formatlardaki görüntülerle ilgili işlemleri destekler. 

## **Yerel Olarak Depolanan Görüntüleri Slaytlara Ekle**

Bilgisayarınızdaki bir veya birkaç görüntüyü bir sunumdaki slayta ekleyebilirsiniz. C# örnek kodu bir resmi slayta nasıl ekleyeceğinizi gösterir:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Web'den Görüntüleri Slaytlara Ekle**

Bir slayta eklemek istediğiniz görüntü bilgisayarınızda bulunmuyorsa, görüntüyü doğrudan web'den ekleyebilirsiniz. 

Bu örnek kod, C# ile web'den bir resmi slayta nasıl ekleyeceğinizi gösterir:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Slide Master'lara Görüntü Ekle**

Slide master, altındaki tüm slaytların (tema, düzen vb.) bilgilerini depolayan ve kontrol eden üst slayttır. Bu nedenle, bir slide master'a bir görüntü eklediğinizde, o görüntü o master altındaki tüm slaytlarda görünür. 

Bu C# örnek kod, bir slide master'a nasıl görüntü ekleyeceğinizi gösterir:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Görüntüleri Slayt Arkaplanı Olarak Ekle**

Belirli bir slayt ya da birden fazla slayt için resmi arka plan olarak kullanmaya karar verebilirsiniz. Bu durumda, *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/tr/net/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakmanız gerekir.

## **Sunumlara SVG Ekle**

Sunuma herhangi bir görüntüyü, [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection) arabirimine ait olan [AddPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/methods/addpictureframe) yöntemini kullanarak ekleyebilir ya da yerleştirebilirsiniz.

SVG görüntüsüne dayalı bir görüntü nesnesi oluşturmak için aşağıdaki adımları izleyebilirsiniz:

1. SvgImage nesnesi oluşturup ImageShapeCollection'a ekleyin
2. ISvgImage'den PPImage nesnesi oluşturun
3. IPPImage arabirimini kullanarak PictureFrame nesnesi oluşturun

Bu örnek kod, yukarıdaki adımları uygulayarak bir SVG görüntüsünü sunuma nasıl ekleyeceğinizi gösterir:
``` csharp 
// Belgeler dizinine yol
string dataDir = @"D:\Documents\";

// SVG kaynak dosya adı
string svgFileName = dataDir + "sample.svg";

// Çıktı sunum dosya adı
string outPptxPath = dataDir + "presentation.pptx";

// Yeni sunum oluştur
using (var p = new Presentation())
{
    // SVG dosya içeriğini oku
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage nesnesi oluştur
    ISvgImage svgImage = new SvgImage(svgContent);

    // PPImage nesnesi oluştur
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Yeni bir PictureFrame oluştur 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Sunumu PPTX formatında kaydet
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **SVG'yi Şekil Setine Dönüştür**

Aspose.Slides'in SVG'yi bir dizi şekle dönüştürme işlemi, SVG görüntüleriyle çalışmak için kullanılan PowerPoint işlevselliğine benzer:

![PowerPoint Açılır Menü](img_01_01.png)

Bu işlevsellik, ilk argüman olarak bir [ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage) nesnesi alan [IShapeCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection) arabiriminin [AddGroupShape](https://reference.aspose.com/slides/tr/net/aspose.slides.ishapecollection/addgroupshape/methods/1) metodunun bir aşırı yüklemesi tarafından sağlanır.

Bu örnek kod, açıklanan yöntemi kullanarak bir SVG dosyasını şekil setine nasıl dönüştüreceğinizi gösterir:

``` csharp 
// Belgeler dizinine yol
string dataDir = @"D:\Documents\";

// SVG kaynak dosya adı
string svgFileName = dataDir + "sample.svg";

// Çıktı sunum dosya adı
string outPptxPath = dataDir + "presentation.pptx";

// Yeni sunum oluştur
using (IPresentation presentation = new Presentation())
{
    // SVG dosya içeriğini oku
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage nesnesi oluştur
    ISvgImage svgImage = new SvgImage(svgContent);

    // Slayt boyutunu al
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG görüntüsünü slayt boyutuna ölçekleyerek şekil grubuna dönüştür
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Sunumu PPTX formatında kaydet
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Görüntüleri EMF Olarak Slaytlara Ekle**

Aspose.Slides for .NET, Excel sayfalarından EMF görüntüleri oluşturmanıza ve bu görüntüleri Aspose.Cells ile slaytlara EMF olarak eklemenize olanak tanır.

Bu örnek kod, belirtilen görevi nasıl yerine getireceğinizi gösterir:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Çalışma kitabını akışa kaydet
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Görüntü Koleksiyonundaki Görüntüleri Değiştir**

Aspose.Slides, bir sunumun görüntü koleksiyonunda depolanan (slayt şekilleri tarafından da kullanılan) görüntüleri değiştirmenize olanak tanır. Bu bölüm, koleksiyondaki görüntüleri güncellemenin birkaç yolunu gösterir. API, ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) örneği veya koleksiyonda zaten var olan başka bir görüntü kullanarak bir görüntüyü değiştirmek için basit yöntemler sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfını kullanarak görüntü içeren sunum dosyasını yükleyin.
2. Yeni bir görüntüyü dosyadan okuyarak bayt dizisine yükleyin.
3. Hedef görüntüyü, bayt dizisini kullanarak yeni görüntü ile değiştirin.
4. İkinci yaklaşımda, görüntüyü bir [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) nesnesine yükleyin ve hedef görüntüyü bu nesneyle değiştirin.
5. Üçüncü yaklaşımda, hedef görüntüyü sunumun görüntü koleksiyonunda zaten mevcut olan bir görüntüyle değiştirin.
6. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```cs
// Sunum dosyasını temsil eden Presentation sınıfını örnekle.
using Presentation presentation = new Presentation("sample.pptx");

// İlk yöntem.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// İkinci yöntem.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Üçüncü yöntem.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Sunumu bir dosyaya kaydet.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Aspose ÜCRETSİZ [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsünü kullanarak metinleri kolayca animasyon haline getirebilir, metinlerden GIF oluşturabilir vb. yapabilirsiniz. 

{{% /alert %}}

## **SSS**

**Ekleme işleminden sonra orijinal görüntü çözünürlüğü aynı kalır mı?**

Evet. Kaynak pikseller korunur, ancak son görünüm slaytta [picture](/slides/tr/net/picture-frame/) nasıl ölçeklendirildiğine ve kaydedilirken uygulanan sıkıştırmaya bağlıdır.

**Yüzlerce slaytta aynı logoyu aynı anda değiştirmek için en iyi yol nedir?**

Logoyu master slayta veya bir düzen üzerine yerleştirin ve sunumun görüntü koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. Bir SVG'yi şekil grubuna dönüştürebilirsiniz; ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Bir resmi aynı anda birden fazla slaytın arka planı olarak nasıl ayarlayabilirim?**

[Resmi arka plan olarak ata](/slides/tr/net/presentation-background/) master slayta veya ilgili düzene—bu master/duzen'i kullanan tüm slaytlar arka planı devralır.

**Birçok resim nedeniyle sunumun boyutu 'balon gibi' büyümesini nasıl önleyebilirim?**

Tek bir görüntü kaynağını tekrar kullanın, kopyalar yerine, makul çözünürlükler seçin, kaydederken sıkıştırma uygulayın ve tekrar eden grafikleri gerektiğinde master üzerinde tutun.
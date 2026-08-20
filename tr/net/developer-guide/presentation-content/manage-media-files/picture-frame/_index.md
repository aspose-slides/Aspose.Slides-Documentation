---
title: ".NET'te Sunumlarda Resim Çerçevelerini Yönetme"
linktitle: "Resim Çerçevesi"
type: docs
weight: 10
url: /tr/net/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- gömülü görüntü
- bağlantılı görüntü
- görüntü çıkar
- raster görüntü
- SVG görüntü
- görüntüyü kırp
- kırpılmış alanları sil
- görüntüyü sıkıştır
- StretchOffset
- resim çerçevesi biçimlendirme
- göreli ölçek
- görüntü efekti
- en-boy oranı
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile sunumlarda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir görüntüyü gösteren bir slayt şeklidir. Aspose.Slides'te, görüntü kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) gömülü görüntü kaynaklarını [Images](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/images/) koleksiyonu aracılığıyla sahiplenirken, bir [IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) görüntünün konumunu, boyutunu, kenar biçimlendirmesini, döndürülmesini, kırpılmasını, resim efektlerini ve diğer çerçeve düzeyindeki ayarları kontrol eder.

Bu ayrım, aynı görüntünün birden fazla kez gösterilmesi gerektiğinde faydalıdır. Görüntüyü sunuma bir kez ekleyin, döndürülen [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesnesini koruyun ve resim çerçeveleri oluştururken bu görüntü kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntüleri ve SVG gibi vektör görüntüleri içerebilir. Ayrıca görüntü baytlarını sunuma depolamak yerine bağlanmış (linked) görüntülere de referans verebilirler. Seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görüntünün nasıl depolanacağına karar vermek faydalıdır.

## **Gömülü Bir Görüntü Ekleme ve Biçimlendirme**

Gömülü bir görüntü için, görüntü verilerini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addpictureframe/) kullanın. Görüntü, sunum paketinin bir parçası haline gelir, böylece sunum başka bir bilgisayara taşındığında kendi kendine yeterli kalır.

Aşağıdaki örnek bir JPEG görüntüsü ekler, görüntünün yerel boyutlarında bir çerçeve oluşturur ve kenar biçimlendirmesi ile döndürmeyi uygular:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Resim çerçevesi gösterilen geometriyi kontrol eder; çerçeve boyutunu değiştirmek, gömülü görüntü kaynağında depolanan özgün piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir görüntüyü kırpma veya sıkıştırma yaparken önem kazanır.

## **Göreli Ölçeği Kullanma**

[IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) çerçeve için göreli genişlik ve yükseklik ölçeklemesini ortaya çıkarır. `1.0` değeri, özgün resim boyutunun %100'üne eşittir. Göreli ölçek, bir iş akışının son boyutları manuel olarak hesaplamak yerine kaynak görüntü boyutuyla ilişkisini koruması gerektiğinde faydalıdır.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

Göreli ölçek, çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlantılı Görüntüler**

Gömülü bir resim, görüntü verilerini sunum içinde depolar ve bu nedenle taşınabilirlik ve öngörülebilir renderleme için en güvenli seçimdir. Bağlantılı bir resim, görüntü verilerini aynı şekilde gömmek yerine [ISlidesPicture](https://reference.aspose.com/slides/tr/net/aspose.slides/islidespicture/) bağlantı yolu aracılığıyla harici bir konumu saklar.

Bağlantılı görüntüler, PPTX içinde depolanan görüntü verisi miktarını azaltabilir, ancak bir dış bağımlılık getirir. Bağlantılı dosya, sunumu açan veya renderlayan uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak kullanılmaz hâle gelirse, bağlantılı resim beklenildiği gibi görüntülenmeyebilir. E‑posta ile gönderilmesi, arşivlenmesi veya izole ortamlarda renderlenmesi gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlantılı Bir Görüntü Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve onu yerel bir görüntü dosyasına yönlendirir. Sadece görüntü bağlamayı ele alır; video bağlama ayrı bir medya iş akışıdır ve kasıtlı olarak bu örneğe karıştırılmamıştır.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Harici dosya yönetimi amaçlı olduğunda bağlantıları kullanın. Bunları sadece sıkıştırma yerine geçmek için kullanmayın: bozuk görüntü bağımlılıkları olan küçük bir PPTX, genellikle daha büyük ve kendi kendine yeten bir sunumdan daha az yararlıdır.

## **Resim Çerçevelerinden Görüntüleri Çıkarma**

Mevcut bir sunumdan görüntü çıkarmadan önce, bir şeklin gerçekten bir [IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) olduğundan ve gömülü bir görüntü içerdiğinden emin olun. Bağlantılı resim çerçeveleri aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API'si, eski sistem‑görüntü sarmalayıcısına ihtiyaç duymadan [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) doğrudan kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

[IImage] üzerinden kaydetmek, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunumda depolanan kodlanmış baytlara, dönüştürülmüş raster dosya yerine ihtiyacınız varsa, bunun yerine görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntüsü Çıkarma**

Bir SVG resmi için, [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) bir [ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/) nesnesi sunar. Bu, resmi önce rasterleştirmeden doğrudan SVG verisini almanızı sağlar.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarımlar, bu vektör içeriğini zorunlu olarak piksellere dönüştürür. PDF veya SVG slayt dışa aktarma da bir renderleme işlemidir, bu yüzden dışa aktarılan grafikler orijinal gömülü SVG'nin bayt‑bayt kopyası gibi ele alınmamalıdır; orijinal vektör kaynağı gerektiğinde gömülü [ISvgImage] verisini kullanın.

## **Bir Görüntüyü Kırpma**

Kırpma, bir çerçeve içinde görüntünün hangi kısmının görüleceğini değiştirir. [IPictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/) üzerindeki kırpma değerleri, kaynak görüntünün boyutlarının yüzdesidir. Kırpma, başlangıçta gömülü görüntüden gizli pikselleri silmez; sadece görünen bölgeyi değiştirir.

Aşağıdaki örnek güvenli bir şekilde bir resim çerçevesi bulur ve kırpma değerlerini uygular:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Gizli görüntü verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu geri dönüşümden daha önemliyse, kırpılmış bölgeler bir sonraki bölümde açıklandığı gibi fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldırma**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) mevcut kırpma dikdörtgeninin dışındaki görüntü verilerini kaldırır ve ortaya çıkan görüntü kaynağını döndürür. Bu dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra, kaldırılan pikseller daha sonraki bir kırpma geri alma işlemi için artık mevcut değildir.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

Yöntem, sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü başka resim çerçeveleri tarafından da kullanılıyorsa, bu çerçeveler hâlâ mevcut kaynaklarına ihtiyaç duyar, bu yüzden kırpılmış alanların silinmesi mutlaka toplam görüntü sayısını azaltmaz. Bu yöntemle WMF veya EMF içeriğini kırpmak, kırpılmış sonucu PNG'ye rasterleştirir.

## **Raster Görüntüleri Sıkıştırma**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/compressimage/) resmin gösterildiği boyuta göre raster görüntü çözünürlüğünü azaltır. Aynı işlemde kırpılmış bölgeleri de kaldırabilir. Yöntem, görüntü yeniden boyutlandırıldığında veya kırpıldığında `true`, değişiklik gerekmediğinde `false` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda önceden tanımlı bir [PicturesCompression](https://reference.aspose.com/slides/tr/net/aspose.slides.export/picturescompression/) değeri kullanın:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Belirli bir hedef gerektiğinde, enum değeri yerine özel bir pozitif DPI değeri geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca, daha düşük çözünürlük ve silinen kırpılmış bölgeler optimize edilmiş sunumdan geri getirilemez. En düşük DPI'yi global olarak uygulamak yerine, görüntünün aslında görüntülenecek veya dışa aktarılacak en büyük boyutuna göre bir hedef çözünürlük seçin.

## **Görüntü Efektlerini İnceleme**

Resim efektleri, çerçeve tarafından kullanılan resimde depolanır. Görüntü dönüşüm koleksiyonu, şeffaflık için sabit alfa modülasyonu ve parlaklık ve kontrast için luminans gibi efektleri içerebilir. Aşağıdaki örnek, bir slaydın ilk resim çerçevesinden her iki tür efekti güvenli bir şekilde okur:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

Bu efektler, görüntünün çerçevede nasıl renderlendiğini değiştirir; orijinal gömülü görüntü baytlarını yeniden yazmazlar.

## **Resim Çerçevesi Geometrisini Kilitleme**

[IPictureFrameLock](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, en‑boy oranı kilidi, şeklin boyutu değiştirilirken oranını korur.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

Kilitleme, resim çerçevesi şekline uygulanır. Kaynak görüntünün yeniden örneklenmesini veya kalıcı olarak aynı en‑boy oranına değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu stretch olduğunda, [IPictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerler, kenardan bir içe çekme oluştururken, negatif yüzde değerler dışa çıkma oluşturur.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynak görüntünün hangi kısmının görüleceğini seçer; stretch offset değerleri ise görünen resim doldurmasının uzatılacağı dikdörtgeni değiştirir.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Doldurma konumlandırması için stretch offsetleri kullanın. Kaynak görüntü kenarlarını gizlemek hedefiyse kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarım Hususları**

Görüntü depolama ve resim‑çerçeve biçimlendirmesi ayrı‑ ayrı ele alındığında temel ödünleşimler daha kolay yönetilir:

- **Embedded images** sunumu kendi içinde tutar ve paylaşım ve sunucu tarafı renderleme için en güvenilir olanlardır, ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Linked images** paketi daha küçük tutabilir, fakat sunum, saklanan yol veya konumlardaki dış dosyaların erişilebilir olmasına bağımlıdır.
- **Cropping** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene veya sıkıştırma sırasında kaldırılana kadar gömülü kalır.
- **Compression** aşırı büyük raster görüntülerde dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Bu, slayt üzerindeki hedef boyut bilinince uygulanmalıdır.
- **SVG images** vektör korumanın önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağına doğrudan ihtiyacınız olduğunda gömülü SVG'yi doğrudan çıkarın. Raster slayt dışa aktarımları her zaman render edilen slaytı piksel'e dönüştürür.
- **Repeated images** mümkün olduğunda aynı dosyayı sunum iş akışına tekrar tekrar yüklemek yerine mevcut bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) kaynağını yeniden kullanmalıdır.

Büyük sunumlar için, görüntü optimizasyonu genellikle seçici olarak yapıldığında daha etkilidir: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutlarına göre sıkıştırın, kırpılmış pikselleri yalnızca sonradan düzenleme gerekmediğinde kaldırın ve dış bağlantılardan kaçının, aksi takdirde bağımlılık yönetimi dağıtım tasarımının bir parçası olmalıdır.

## **SSS**

**Resim çerçevesi ile görüntü kaynağı arasındaki fark nedir?**

[IPPImage] sunuma bağlı bir görüntü kaynağını temsil eder. [IPictureFrame] ise bir slaytta görüntüyü gösteren ve çerçeve düzeyindeki geometriyi ve biçimlendirmeyi (boyut, döndürme, kırpma değerleri, efektler ve kilitler) depolayan bir şekildir.

**Görüntüleri gömmeli miyim yoksa bağlamalı mıyım?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerektiğinde görüntüleri gömmelisiniz. Görüntü dosyalarını PPTX dışına tutmak kasıtlı ve dış konumlar güvenilir bir şekilde sürdürülebilir olduğunda yalnızca bağlamalısınız.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden değil. Normal kırpma ayarları, kaynak görüntünün bölümlerini gizler ancak altındaki pikselleri tutar. Bu pikseller kalıcı olarak atılabilir olduğunda [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) veya kırpılmış alanların kaldırıldığı görüntü sıkıştırmasını kullanın.

**Sıkıştırmadan sonra görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma, depolanan raster çözünürlüğü azaltabilir ve kırpılmış bölgelerin kaldırılması görüntü verisini yok eder. Daha sonraki yüksek çözünürlükte düzenleme gerekebilecekse, orijinal kaynak görüntüyü sunum dışına tutun.

**SVG görüntüleri nasıl ele alınmalı?**

Vektör doğruluğunun önemli olduğu durumlarda SVG içeriğini SVG olarak tutun. Gömülü [ISvgImage] doğrudan çıkarılabilir. Bir slaytı PNG veya JPEG gibi raster bir formata renderlemek, SVG'yi slayt görüntüsünün bir parçası olarak rasterleştirir.

**Mevcut slaytları okurken güvenli olmayan tip dönüşümlerinden nasıl kaçınabilirim?**

Resim‑çerçevesi‑özelliği üyelerini kullanmadan önce şekil tipini kontrol edin. [IPictureFrame] ile desen eşlemesi yapmak veya şekil koleksiyonunu bu arayüze göre filtrelemek, geçersiz tip dönüşümlerinden kaçınır ve kodun resim çerçevesi içermeyen slaytları yönetmesini sağlar.
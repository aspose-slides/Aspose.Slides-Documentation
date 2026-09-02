---
title: ".NET'te Sunumlarda Resim Çerçevelerini Yönetme"
linktitle: "Resim Çerçevesi"
type: docs
weight: 10
url: /tr/net/picture-frame/
keywords:
- "resim çerçevesi"
- "resim çerçevesi ekle"
- "resim çerçevesi oluştur"
- "gömülü görüntü"
- "bağlantılı görüntü"
- "görüntüyü çıkar"
- "raster görüntü"
- "SVG görüntü"
- "görüntüyü kırp"
- "kırpılmış alanları sil"
- "görüntüyü sıkıştır"
- "StretchOffset"
- "resim çerçevesi biçimlendirme"
- "göreli ölçek"
- "görüntü efekti"
- "en‑boy oranı"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET ile sunumlardaki resim çerçevelerini oluşturma, biçimlendirme, bağlama, kırpma, çıkarma ve sıkıştırma."
---
## **Genel Bakış**

Bir resim çerçevesi, bir görüntüyü gösteren bir slayt şeklidir. Aspose.Slides'de, görüntü kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) gömülü görüntü kaynaklarını [Görüntüler](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/images/) koleksiyonu aracılığıyla sahiplenirken, bir [IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) görüntünün konumunu, boyutunu, çizgi biçimlendirmesini, döndürülmesini, kırpılmasını, resim efektlerini ve diğer çerçeve düzeyindeki ayarları kontrol eder.

Bu ayrım, aynı görüntünün birden fazla kez gösterildiği durumlarda faydalıdır. Görüntüyü sunuma bir kez ekleyin, döndürülen [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu görüntü kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntüleri ve SVG gibi vektör görüntüleri içerebilir. Ayrıca görüntü baytlarını sunumda saklamak yerine bağlantılı (linked) görüntülere referans verebilirler. Bu seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görüntünün nasıl saklanacağına karar vermek faydalıdır.

## **Gömülü Görüntü Ekleme ve Biçimlendirme**

Gömülü bir görüntü için, görüntü verilerini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addpictureframe/) yöntemini kullanın. Görüntü, sunum paketinin bir parçası haline gelir, bu sayede sunum başka bir bilgisayara taşındığında da kendine yeterli kalır.

Aşağıdaki örnek bir JPEG görüntüsü ekler, görüntünün yerel boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile döndürme uygular:

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

Resim çerçevesi, görüntünün gösterilen geometrisini kontrol eder; çerçeve boyutunu değiştirmek, gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir görüntüyü kırpma veya sıkıştırma yaptığınızda önem kazanır.

## **Göreli Ölçeği Kullan**

[IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) çerçeve için göreli genişlik ve yükseklik ölçeklendirmesini ortaya koyar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Göreli ölçek, bir iş akışının son boyutları manuel olarak hesaplamak yerine kaynağın boyutu ile bir ilişki koruması gerektiğinde işe yarar.

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

Göreli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlantılı Görüntüler**

Gömülü bir resim, görüntü verilerini sunum içinde saklar ve bu nedenle taşınabilirlik ve öngörülebilir görüntüleme açısından en güvenli tercihtir. Bağlantılı bir resim ise görüntü verilerini aynı şekilde gömmek yerine [ISlidesPicture](https://reference.aspose.com/slides/tr/net/aspose.slides/islidespicture/) bağlantı yolu aracılığıyla harici bir konuma işaret eder.

Bağlantılı görüntüler PPTX içinde saklanan veri miktarını azaltabilir, ancak harici bir bağımlılık getirir. Bağlantılı dosya, sunumu açan veya render eden uygulama için erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa ya da kaynak kullanılamaz olursa, bağlantılı resim beklendiği gibi gösterilemez. Sunumun e-posta ile gönderilmesi, arşivlenmesi veya izole ortamda render edilmesi gerekiyorsa, gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlantılı Görüntü Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve onu yerel bir görüntü dosyasına yönlendirir. Sadece görüntü bağlamayı gösterir; video bağlama ayrı bir medya iş akışıdır ve bu örneğe bilinçli olarak dahil edilmemiştir.

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

Dış dosya yönetimi kasıtlıysa bağlantıları kullanın. Sıkıştırma yerine yalnızca bir alternatif olarak kullanmayın: kırık görüntü bağımlılıklarına sahip küçük bir PPTX, genellikle büyük, kendi kendine yeten bir sunumdan daha az kullanışlıdır.

## **Resim Çerçevelerinden Görüntü Çıkarma**

Mevcut bir sunumdan görüntü çıkarmadan önce, bir şeklin gerçekten bir [IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) olup olmadığını ve gömülü bir görüntü içerip içermediğini kontrol edin. Bağlantılı resim çerçeveleri, aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API'si, eski sistem-görüntü sarmalayıcısına ihtiyaç duymadan doğrudan [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

[IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) üzerinden kaydetmek, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunum içinde saklanan kodlanmış baytlara (dönüştürülmüş raster dosyası yerine) ihtiyacınız varsa, görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntüsü Çıkarma**

Bir SVG resmi için, [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) bir [ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/) nesnesi sağlar. Bu sayede SVG verisini doğrudan alabilir, resmi önce rasterlaştırmadan elde edebilirsiniz.

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

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarımlar bu vektör içeriği piksellere dönüştürür. PDF veya SVG slayt dışa aktarımı da bir render işlemi olduğundan, dışa aktarılan grafikler özgün gömülü SVG'nin bayt‑bayt bir kopyası olarak değerlendirilmemeli; orijinal vektör kaynağı gerektiğinde gömülü [ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/) verisi kullanılmalıdır.

## **Görüntüyü Kırpma**

Kırpma, çerçeve içinde hangi görüntü bölümünün görüneceğini değiştirir. [IPictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/) üzerindeki kırpma değerleri, kaynak görüntünün boyutlarının yüzdesi olarak verilir. Kırpma, gizli pikselleri gömülü görüntüden hemen silmez; yalnızca görünür bölgeyi değiştirir.

Aşağıdaki örnek bir resim çerçevesini güvenli bir şekilde bulur ve kırpma değerlerini uygular:

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

Gizli görüntü verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu geri dönüşümden daha önemliyse, sonraki bölümde açıklanan gibi kırpılmış bölgeler fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldırma**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) mevcut kırpma dikdörtgeninin dışındaki görüntü verisini kaldırır ve sonuçtaki görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir “uncrop” işleminde artık mevcut değildir.

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

Yöntem sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü başka resim çerçeveleri tarafından da kullanılıyorsa, bu çerçeveler hâlâ mevcut kaynağa ihtiyaç duyar; bu nedenle kırpılmış alanların silinmesi mutlaka toplam görüntü sayısını azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterlaştırır.

## **Raster Görüntüleri Sıkıştırma**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/compressimage/) raster görüntünün çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, görüntü yeniden boyutlandırıldıysa veya kırpıldıysa `true`, hiçbir değişiklik gerekmediyse `false` döndürür.

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

Belirli bir hedef gerektiğinde enum değeri yerine pozitif bir DPI değeri de geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca düşük çözünürlük ve silinmiş kırpılmış bölgeler, optimize edilmiş sunumdan geri getirilemez. Hedef çözünürlüğü, görüntünün gerçekte görüntülenecek veya dışa aktarılacak en büyük boyutuna göre seçin; tüm sunumda en düşük DPI’yı uygulamaktan kaçının.

## **Görüntü Dönüşüm Efektlerini Yönetme**

Parlaklık, kontrast, renk dönüşümleri, bulanıklaştırma, alfa efektleri, sıralı zincirler, denetleme, kaldırma ve çift yönlü doğrulama gibi tam bir iş akışı için **[Görüntü Dönüşüm Efektleri](/slides/tr/net/image-transform-effects/)** bölümüne bakın.

## **Resim Çerçevesi Geometrisini Kilitleme**

[IPictureFrameLock](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, en‑boy oranı kilidi, şekil yeniden boyutlandırılırken orantıların korunmasını sağlar.

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

Kilitleme, sadece resim çerçevesi şekline uygulanır. Kaynak görüntünün aynı en‑boy oranına yeniden örneklenmesi veya kalıcı olarak değiştirilmesi zorunlu kılmaz.

## **StretchOffset Değerlerini Ayarlama**

Dolgu modu “stretch” olduğunda, [IPictureFillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/) üzerindeki stretch‑offset değerleri, dolgu dikdörtgenini resim çerçevesinin sınır kutusuna göre tanımlar. Pozitif yüzdeler kenardan içeriye bir girinti oluştururken, negatif yüzdeler dışarıya bir çıkıntı yaratır.

Bu, kırpma işleminden farklıdır. Kırpma değerleri, kaynak görüntünün hangi kısmının görüneceğini seçerken; stretch offset değerleri, görünen resim dolgusunun hangi dikdörtgene uzatılacağını değiştirir.

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

Dolgu yerleşimi için stretch offset kullanın. Kaynak görüntünün kenarlarını gizlemek istiyorsanız kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Görüntü depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel denge noktaları daha net yönetilir:

- **Gömülü görüntüler** sunumu kendi içinde tutar ve paylaşım ile sunucu tarafı render için en güvenilir seçenektir; ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlantılı görüntüler** paket boyutunu küçültür, fakat sunumun harici dosyaların belirtilen yollarda mevcut olmasına bağımlı olmasını getirir.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene ya da sıkıştırma sırasında kaldırılana kadar gömülü kalır.
- **Sıkıştırma**, aşırı büyük raster görüntülerin dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Hedef slayt boyutu bilindikten sonra uygulanmalıdır.
- **SVG görüntüler**, vektör korunumu önemliyse SVG olarak tutulmalıdır. Vektör kaynağına ihtiyaç duyduğunuzda gömülü SVG’yi doğrudan çıkarın. Raster slayt dışa aktarımları her zaman slaytı piksellere dönüştürür.
- **Tekrarlanan görüntüler**, mümkün olduğunca aynı [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) kaynağını yeniden kullanmalı, aynı dosyayı sunuma defalarca yüklemekten kaçınmalıdır.

Büyük sunumlarda, görüntü optimizasyonu seçici olarak yapıldığında daha etkilidir: logolar ve diyagramlar vektör içerik olarak kalmalı, fotoğraflar gerçek gösterim boyutuna göre sıkıştırılmalı, kırpılmış pikseller yalnızca daha sonraki düzenleme gerekmiyorsa kaldırılmalı ve dış bağlantılar, bağımlılık yönetimi dağıtım tasarımının bir parçası değilse kullanılmamalıdır.

## **SSS**

**Resim çerçevesi ile görüntü kaynağı arasındaki fark nedir?**

Bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) sunuma bağlı bir görüntü kaynağını temsil eder. Bir [IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) ise bir slayttaki resmi gösteren, çerçeve‑düzeyinde boyut, döndürme, kırpma, efekt ve kilit gibi biçimlendirmeleri depolayan şekildir.

**Görüntüleri gömmeli mi yoksa bağlamalı mıyım?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa görüntüleri gömün. Görüntü dosyalarını PPTX dışına tutmak ve dış konumları güvenilir bir şekilde yönetebileceğiniz durumlarda ise bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Tek başına azaltmaz. Normal kırpma ayarları, kaynak görüntünün bir kısmını gizler ancak altındaki pikselleri tutar. Kırpılmış alanları kalıcı olarak kaldırmak için [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) veya kırpılmış‑alan kaldırmalı sıkıştırma kullanılmalıdır.

**Sıkıştırma sonrası görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma depolanan raster çözünürlüğü düşürür ve kırpılmış bölgelerin kaldırılması görüntü verisini siler. Daha sonraki yüksek çözünürlüklü düzenleme ihtiyacı olabilecekse orijinal kaynağı sunum dışına saklayın.

**SVG görüntüler nasıl ele alınmalı?**

Vektör bütünlüğünün önemli olduğu durumlarda SVG içeriği SVG olarak tutun. Gömülü [ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/) doğrudan çıkarılabilir. PNG veya JPEG gibi raster bir formata slayt renderlamak, SVG’yi piksellere dönüştürür.

**Mevcut slaytları okurken güvenli olmayan tip dönüşümlerinden nasıl kaçınabilirim?**

Resim‑çerçevesi‑özel üyeleri kullanmadan önce şekil tipini kontrol edin. [IPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) ile desen eşlemesi yaparak ya da şekil koleksiyonunu bu arabirime göre filtreleyerek geçersiz tip dönüşümlerinden kaçınıp, resim çerçevesi içermeyen slaytları sorunsuz işleyebilirsiniz.
---
title: .NET'te Sunumlarda Görüntü Yönetimini Optimize Et
linktitle: Görüntüleri Yönet
type: docs
weight: 10
url: /tr/net/image/
keywords:
- görsel ekle
- resim ekle
- görüntüyü değiştir
- görüntü koleksiyonu
- resim çerçevesi
- bağlantılı görüntü
- arkaplan
- PNG ekle
- JPG ekle
- SVG ekle
- SVG'den şekillere
- harici SVG kaynakları
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument sunumlarında raster ve SVG görüntülerini eklemeyi, yeniden kullanmayı, bağlamayı, değiştirmeyi ve yönetmeyi öğrenin."
---
## **Giriş**

Aspose.Slides for .NET, görüntülerle çalışmanın birkaç yolunu sunar ve her biri farklı bir amaca hizmet eder. Bir görüntüyü bir sunuda depolayabilir, bir resim çerçevesinde görüntüleyebilir, bir slayt arka planı olarak kullanabilir, harici bir görüntüye bağlayabilir, paylaşılan bir görüntü kaynağını değiştirebilir veya SVG içeriğini düzenlenebilir şekillere dönüştürebilirsiniz.

Bu makale, görüntü kaynaklarına ve bunların bir sunu içinde nasıl kullanıldığına odaklanır. Bireysel bir resim çerçevesine uygulanan kırpma, şeffaflık, efektler, uzatma ve diğer biçimlendirmeler için [Picture Frame](/slides/tr/net/picture-frame/) bölümüne bakın.

## **Görüntü Modelini Anlayın**

Aşağıdaki API kavramları yakından ilişkili ancak birbirinin yerine kullanılmaz:

- Sunum görüntü koleksiyonu([presentation image collection](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection/)) sunumda kullanılan görüntü kaynaklarını saklar. Görüntü verisini eklemek ve bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) kaynağı elde etmek için [ImageCollection.AddImage](https://reference.aspose.com/slides/tr/net/aspose.slides/imagecollection/addimage/) kullanın.
- Bir [picture frame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe/) bir slayt, düzen veya master üzerinde bir görüntüyü gösteren bir şekildir. Bir görüntü kaynağını slayta yerleştirmek için [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addpictureframe/) kullanın.
- Bir slayt arka planı, bir şekil olarak değil, slayt dolgusunun bir parçası olarak görüntüyü kullanır. Bu nedenle bir resim çerçevesi gibi davranmaz.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/replaceimage/) bir görüntü kaynağını değiştirir. Bu kaynağı kullanan tüm sunum öğeleri değişikliği görür.
- SVG'yi şekillere dönüştürmek, düzenlenebilir slayt şekilleri oluşturur. Dönüştürmeden sonra içerik artık tek bir resim kaynağı olarak yönetilmez.

Tipik bir iş akışı şudur: görüntü verisini görüntü koleksiyonuna ekleyin, bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) alın ve ardından bu kaynağı bir veya daha fazla resim çerçevesinde veya dolgu içinde kullanın.

## **Gömülü Görüntü Ekle**

Yerel bir görüntüyü eklemek için dosyayı okuyun, verisini görüntü koleksiyonuna ekleyin ve döndürülen `IPPImage`ı kullanan bir resim çerçevesi oluşturun.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Bu şekilde eklenen görüntü sunuya gömülür, bu nedenle ortaya çıkan dosya orijinal görüntü dosyasının mevcut olmasına bağlı değildir.

### **Web'den Görüntü Ekle**

Bir görüntü HTTP veya HTTPS üzerinden mevcutsa, baytlarını `HttpClient` ile indirin, sunum görüntü koleksiyonuna ekleyin ve döndürülen görüntü kaynağını yerel bir görüntü gibi aynı şekilde kullanın.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

Uzun süren uygulamalarda her istek için yeni bir örnek oluşturmak yerine `HttpClient`i yeniden kullanın. Ayrıca kaynak güvenilir değilse uzak URL'leri, yanıt boyutlarını ve içerik türlerini doğrulayın.

## **Slaytlar Arasında Görüntüleri Yeniden Kullan**

Aynı görüntü birden fazla kez gerekiyorsa, onu sunuya bir kez ekleyin ve ek resim çerçeveleri oluştururken döndürülen [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/)ı yeniden kullanın. Bu, aynı kaynak verisinin tekrar tekrar yüklenmesini önler ve paylaşılan görüntü kaynağı ile kullanımları arasındaki ilişkiyi açık hâle getirir.

Birçok slaytta otomatik olarak görünmesi gereken grafikler (ör. şirket logosu) için her slayta aynı şekli eklemek yerine bir [slide master](/slides/tr/net/slide-master/) veya düzen üzerine resim çerçevesi yerleştirmenizi öneririz.

## **Görüntüyü Slayt Arka Planı Olarak Kullan**

Arka plan görüntüsü slayt dolgusuna atanır; bir resim‑çerçevesi şekli olarak eklenmez. Bu, görüntünün slayt arka planını kaplaması ve normal bir slayt nesnesi gibi işlenmemesi gerektiğinde kullanışlıdır.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

Ek arka plan seçenekleri, master ve düzen arka planları dahil, için [Presentation Background](/slides/tr/net/presentation-background/) bölümüne bakın.

## **Gömülü Görüntüler ve Bağlantılı Görüntüler**

Gömülü ve bağlantılı görüntülerin taşınabilirlik ve dosya‑boyutu açısından farklı avantajları vardır:

- **Gömülü görüntü:** görüntü verisi sununun içinde depolanır. Sunu kendine yeterli olur, ancak dosya boyutu görüntü verisini içerir.
- **Bağlantılı görüntü:** sunu harici bir görüntünün yolunu veya URL'sini saklar. Bu, sunu boyutunu azaltabilir, ancak dış kaynak erişilebilir olmalıdır.

Harici yolu veya URL'yi [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/tr/net/aspose.slides/islidespicture/linkpathlong/) aracılığıyla atayarak bir bağlantılı resim oluşturulabilir; görüntü verisi gömülmez.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Bağlantılı görüntüleri yalnızca dağıtım ortamı dış kaynağa güvenilir bir şekilde erişebildiğinde kullanın. Çevrimdışı çalışması veya sistemler arasında taşınması gereken sunular için gömülü görüntüler genellikle daha güvenlidir.

## **SVG Görüntülerle Çalışma**

SVG bir vektör formatıdır; bu, ikonlar, diyagramlar ve raster görüntülerdeki detay kaybı olmadan ölçeklenebilen grafikler için faydalı olabilir. Aspose.Slides, SVG'yi hem bir görüntü kaynağı hem de düzenlenebilir slayt şekilleri için bir kaynak olarak destekler.

### **SVG'yi Görüntü Olarak Ekle**

Bir [SvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/svgimage/) oluşturun, görüntü koleksiyonuna ekleyin ve ortaya çıkan görüntü kaynağını bir resim çerçevesine yerleştirin.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **Harici Kaynakları Olan SVG Dosyaları**

Bir SVG harici görüntüler, stil sayfaları veya yazı tipleri referans gösterebilir. Bu durumlar için [SvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/svgimage/) bir [IExternalResourceResolver](https://reference.aspose.com/slides/tr/net/aspose.slides.import/iexternalresourceresolver/) ve temel URI kabul eden yapıcılar sağlar. Çözücü, göreli URI'yi izin verilen mutlak bir URI'ye eşleyebilir ve istenen kaynağın akışını döndürebilir.

Çözücü, Aspose.Slides SVG'yi işlerken harici kaynakları kullanılabilir kılar, ancak SVG'yi kendine yeterli bir belge haline getirmez. SVG'nin taşınabilir olması gerekiyorsa, bağlantılı görüntüler için `data:` URI'leri gibi yöntemlerle gerekli kaynakları SVG içinde gömün.

Güvenilmeyen kaynaklardan gelen SVG dosyalarına gelince, çözücünün erişebileceği şema, dosya konumu ve hostları sınırlayın. Ağ çözücüleri zaman aşımı, yanıt‑boyutu sınırları ve içerik doğrulaması da uygulamalıdır.

### **SVG'yi Düzenlenebilir Şekillere Dönüştür**

Aspose.Slides, bir SVG'yi PowerPoint'teki ilgili komuta benzer şekilde düzenlenebilir slayt şekilleri grubuna dönüştürebilir.

![PowerPoint Popup Menu](img_01_01.png)

Dönüştürmeyi gerçekleştirmek için [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addgroupshape/) overload'ını bir [ISvgImage](https://reference.aspose.com/slides/tr/net/aspose.slides/isvgimage/) alacak biçimde kullanın.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

SVG'yi şekillere dönüştürün, bireysel vektör elemanlarının PowerPoint şekilleri olarak düzenlenmesi gerektiğinde. SVG yalnızca görüntülenmesi gerekiyorsa, görüntü olarak tutmak daha basittir ve çok sayıda ayrı şekil oluşturmayı önler.

## **Mevcut Bir Görüntü Kaynağını Değiştir**

Bir görüntü kaynağını değiştirmek istediğinizde [IPPImage.ReplaceImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/replaceimage/) kullanın. Bu, logolar gibi paylaşılan grafikler için özellikle kullanışlıdır.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Aynı görüntü kaynağını birden çok resim çerçevesi, arka plan, master veya düzen kullanıyorsa, kaynağın değiştirilmesi bu tüm kullanımları günceller. Sadece bir resim çerçevesinin değişmesi gerekiyorsa, ortak kaynağı değiştirmek yerine o çerçeveye farklı bir görüntü atayın.

`ReplaceImage` ayrıca bir [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) veya başka bir [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) kabul eden overload'lar sunar.

## **Pratik Görüntü Yönetimi Rehberi**

### **Sunum Boyutunu Kontrol Et**

Büyük raster görüntüler sunuyu gereksiz yere şişirebilir. Kaynak görüntüleri, hedef gösterim boyutuna uygun ölçülerde seçin, mümkün olduğunda paylaşılan görüntü kaynaklarını yeniden kullanın ve aynı tam çözünürlüklü grafiğin tekrarlı kopyalarını gömmekten kaçının.

Resim çerçevelerine zaten yerleştirilmiş raster fotoğraflar için [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ipicturefillformat/compressimage/) seçili çözünürlük ve kırpma ayarlarına göre görüntü verisini azaltabilir. Bu, görüntü‑koleksiyon yönetimi değil, resim‑çerçevesi işleme olduğundan ilgili biçimlendirme işlemleri için [Picture Frame](/slides/tr/net/picture-frame/) bölümüne bakın.

### **Gömülü ve Bağlantılı İçerik Arasındaki Seçim**

Gömme, tüm gerekli görüntü verisinin dosyayla birlikte gelmesi sayesinde sunuyu taşınabilir kılar. Bağlantı dosya boyutunu azaltabilir, ancak dış bağımlılık oluşturur. Bağlantıyı yalnızca bu bağımlılığın kabul edilebilir ve istikrarlı olduğu durumlarda kullanın.

### **Paylaşılan Marka Öğelerini Yeniden Kullan**

Tekrarlanan logolar, filigranlar veya süsleme grafikleri için tek bir görüntü kaynağı oluşturun ve yeniden kullanın. Grafik sunu tasarımına aitse (slayt içeriği yerine), ilgili slaytlar tarafından devralınması için bir master veya düzen üzerine yerleştirin.

### **SVG Kaynaklarını Taşınabilir Tut**

Kendine yeterli bir SVG, harici dosyalara veya ağ kaynaklarına bağımlı bir SVG'den daha kolay taşınır ve tutarlı şekilde işler. Mümkün olduğunca SVG'yi içe aktarmadan önce gerekli kaynakları gömün. SVG'yi şekillere yalnızca bireysel vektör elemanlarının düzenlenmesi gerektiğinde dönüştürün.

### **Modern Çapraz Platform Görüntü API'sını Kullan**

Yeni .NET kodu için `System.Drawing.Image` veya `Bitmap` yerine Aspose.Slides [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) ve [Images](https://reference.aspose.com/slides/tr/net/aspose.slides/images/) API'lerini kullanın. Geçiş rehberi için [Modern API](/slides/tr/net/modern-api/) bölümüne bakın.

WMF ve EMF özel bir dikkate ihtiyaç duyar. Bu formatlar bir [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) üzerinden geçerken, [ImageCollection.AddImage](https://reference.aspose.com/slides/tr/net/aspose.slides/imagecollection/addimage/) metafili PNG raster temsiline dönüştürür. Metafili verisini korumak istiyorsanız, akış‑tabanlı bir [ImageCollection.AddImage](https://reference.aspose.com/slides/tr/net/aspose.slides/imagecollection/addimage/) overload'ı kullanın. Elektronik tablo veya diğer ürünlerden EMF içeriği oluşturmak ayrı bir entegrasyon iş akışıdır ve bu makalenin kapsamı dışındadır.

## **SSS**

**Görüntü koleksiyonu ile resim çerçevesi arasındaki fark nedir?**

Görüntü koleksiyonu, yeniden kullanılabilir görüntü kaynaklarını saklar. Resim çerçevesi, bu kaynaklardan birini gösteren ve kırpma, efekt gibi resme özgü biçimlendirmeler sunan bir slayt şeklidir.

**Aynı logoyu her yerde değiştirmek için en iyi yol nedir?**

Logo zaten tek bir görüntü kaynağı olarak paylaşılıyorsa, o kaynağı [IPPImage.ReplaceImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/replaceimage/) ile değiştirin. Sunu genelinde marka tutarlılığı için logoyu bir master veya düzen üzerine yerleştirmek de tekrarlanan slayt içeriğini azaltır.

**Bağlantılı bir görüntü başka bir bilgisayarda neden kaybolur?**

Bağlantılı resim, dış dosya veya URL'ye dayanır. Bu kaynak başka bir bilgisayardan erişilemezse, bağlantılı görüntü mevcut olmayabilir. Sununun kendine yeterli olması gerekiyorsa görüntüyü gömün.

**Eklemiş olduğum bir SVG, PowerPoint şekilleri olarak düzenlenebilir mi?**

Evet. SVG'yi [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addgroupshape/) ile dönüştürün; ortaya çıkan grup, tek bir SVG resmi yerine düzenlenebilir slayt şekilleri içerir.

**Birçok görüntülü sunuyu nasıl daha küçük tutabilirim?**

Paylaşılan görüntü kaynaklarını yeniden kullanın, gereksiz büyük raster kaynaklardan kaçının, uygun olduğunda raster fotoğrafları sıkıştırın, tekrarlanan marka öğelerini master veya düzenlerde tutun ve dış bağımlılık kabul edilebilir olduğunda yalnızca bağlantılı görüntüleri kullanın.
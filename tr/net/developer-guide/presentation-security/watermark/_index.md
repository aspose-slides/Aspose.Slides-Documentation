---
title: .NET'te Sunumlara Su İşareti Ekleme
linktitle: Su İşareti
type: docs
weight: 40
url: /tr/net/watermark/
keywords:
- su işareti
- metin su işareti
- resim su işareti
- su işareti ekle
- su işaretini değiştir
- su işaretini kaldır
- su işaretini sil
- PPT'ye su işareti ekle
- PPTX'e su işareti ekle
- ODP'ye su işareti ekle
- PPT'den su işaretini kaldır
- PPTX'den su işaretini kaldır
- ODP'den su işaretini kaldır
- PPT'den su işaretini sil
- PPTX'den su işaretini sil
- ODP'den su işaretini sil
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: ".NET'te PowerPoint ve OpenDocument sunumlarında taslak, gizli bilgi, telif hakkı ve daha fazlasını göstermek için metin ve resim su işaretlerini yönetin."
---
## **Giriş**

**Su işareti**, bir sunumda bir slaytta veya tüm sunum slaytlarında kullanılan metin ya da resim damgasıdır. Genellikle bir su işareti, sunumun taslak olduğunu (ör. "Draft" su işareti), gizli bilgi içerdiğini (ör. "Confidential" su işareti), hangi şirkete ait olduğunu (ör. "Company Name" su işareti), sunum yazarını tanımlamak vb. belirtmek için kullanılır. Su işareti, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Su işaretleri hem PowerPoint hem de OpenDocument sunum formatlarında kullanılır. Aspose.Slides içinde PowerPoint PPT, PPTX ve OpenDocument ODP dosya formatlarına su işareti ekleyebilirsiniz.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/net/) içinde PowerPoint veya OpenDocument belgelerinde su işareti oluşturmanın ve tasarımını, davranışını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin su işareti eklemek için [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) arayüzünü, resim su işareti eklemek için ise [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) sınıfını veya bir su işareti şekline resmi doldurmayı kullanmanızdır. `PictureFrame` [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape) arayüzünü uygular, bu sayede şekil nesnesinin tüm esnek ayarlarını kullanabilirsiniz. `ITextFrame` bir şekil olmadığı ve ayarları sınırlı olduğu için bir [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape) nesnesine sarılır.

Su işareti iki şekilde uygulanabilir: tek bir slayta ya da tüm sunum slaytlarına. Tüm sunum slaytlarına su işareti uygulamak için Slide Master kullanılır — su işareti Slide Master’a eklenir, tamamen orada tasarlanır ve bireysel slaytlardaki su işareti düzenleme iznini etkilemeden tüm slaytlara uygulanır.

Su işareti genellikle diğer kullanıcılar tarafından düzenlenemez kabul edilir. Su işareti (ya da daha doğrusu su işareti ebeveyn şekli) düzenlenmesin diye, Aspose.Slides şekil kilitleme işlevi sağlar. Belirli bir şekil normal bir slaytta ya da Slide Master’da kilitlenebilir. Su işareti şekli Slide Master’da kilitlenirse, tüm sunum slaytlarında kilitli olur.

Su işaretine bir ad atayabilirsiniz; böylece gelecekte silmek istediğinizde, slayt şekilleri içinde adıyla bulabilirsiniz.

Su işaretini istediğiniz gibi tasarlayabilirsiniz; ancak genellikle ortak özellikleri vardır; örneğin merkez hizalama, döndürme, ön konum vb. Aşağıdaki örneklerde bunların nasıl kullanılacağını inceleyeceğiz.

## **Metin Su İşareti**

### **Bir Slayta Metin Su İşareti Ekleme**

PPT, PPTX veya ODP içinde bir metin su işareti eklemek için önce slayta bir şekil ekleyip bu şekle bir metin çerçevesi ekleyebilirsiniz. Metin çerçevesi [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe) arayüzüyle temsil edilir. Bu tip, su işaretini esnek bir şekilde konumlandırmak için geniş özellik setine sahip [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/)‘den türetilmemiştir. Bu nedenle, [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe) nesnesi bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) nesnesine sarılır. Şekle su işareti metni eklemek için aşağıda gösterildiği gibi [AddTextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/methods/addtextframe) metodunu kullanın.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Su işaretini slayta ekle.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [TextFrame Sınıfı Nasıl Kullanılır?](/slides/tr/net/text-formatting/)
{{% /alert %}}

### **Bir Sunuma Metin Su İşareti Ekleme**

Metin su işaretini tüm sunuma (yani tüm slaytlara tek seferde) eklemek istiyorsanız, [MasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/masterslide/)‘a ekleyin. Geri kalan mantık, tek bir slayda su işareti eklemekle aynıdır — bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) nesnesi oluşturun ve ardından [AddTextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/methods/addtextframe) metodunu kullanarak su işaretini ekleyin.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Su işaretini ana slayta ekle.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [Slide Master Nasıl Kullanılır?](/slides/tr/net/slide-master/)
{{% /alert %}}

### **Su İşareti Şeklinin Şeffaflığını Ayarlama**

Varsayılan olarak, dikdörtgen şekli dolgu ve hat renkleriyle biçimlendirilir. Bu, su işareti eklendiğinde, slayt içeriğinden dikkat çeken katı bir arka plan veya kenarlıkla görünebileceği anlamına gelir. Su işaretinin ince kalmasını ve sunumun görsel tasarımını etkilememesini sağlamak için şekli tamamen şeffaf yapabilirsiniz.

Aşağıdaki kod satırları, hem dolgu hem de kenarlık renklerini kaldırarak şekli şeffaf hâle getirir:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Metin Su İşareti İçin Yazı Tipi Ayarlama**

Metin su işaretini slayta uygulamadan önce, görünümünü özelleştirerek genel tasarımla uyumlu olmasını sağlamak önemlidir. Yazı tipi türünü ve boyutunu değiştirerek su işaretinin okunaklı ve estetik olmasını sağlayabilirsiniz. Yazı tipi özelleştirmesi, marka kimliğini pekiştirmeye ya da sadece sunum stiline uymaya yardımcı olur.

Aşağıdaki kod örneği, belirli bir Latin yazı tipini seçerek ve uygun bir yazı yüksekliği ayarlayarak su işaretinin yazı tipi ayarlarını nasıl yapacağınızı gösterir:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Su İşareti Metin Rengini Ayarlama**

Su işaretinizi uygulamadan önce, metin renginin slayt içeriğiyle iyi bir şekilde uyum sağlaması ve fazla göze çarpmaması gerekir. Renk bileşenlerine (kırmızı, yeşil, mavi) ek olarak alfa (şeffaflık) değerini ayarlayarak hafif, yarı şeffaf bir su işareti yaratabilirsiniz. Bu yaklaşım, ana sunumunuzu korurken içeriğinizi korur.

Su işareti metninin rengini ayarlamak için aşağıdaki kodu kullanın:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Metin Su İşaretini Ortalamak**

Metin su işaretinizi doğru bir şekilde ortalamak, slayt boyutlarından bağımsız olarak su işaretinin simetrik bir konumda olmasını sağlar; bu da sunumunuzun genel estetiğini önemli ölçüde artırır. Bu yaklaşım, slaytlarınıza profesyonel bir görünüm kazandırır ve su işaretinin ana içeriği rahatsız etmemesini sağlar.

Aşağıdaki kod parçacığı, bir slaytın merkez konumunu hesaplayıp metin su işaretini bu konuma yerleştirir:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Aşağıdaki resim son sonucu gösterir.

![The text watermark](text_watermark.png)

## **Resim Su İşareti**

### **Bir Sunuya Resim Su İşareti Ekleme**

Çoğu durumda, bir resim su işareti benzersiz bir marka öğesi sunabilir veya metin su işaretine göre daha görsel açıdan çekici bir alternatif olabilir. Su işaretini eklemeden önce, görüntü dosyasının hazır olduğundan emin olun (ör. şeffaflık için PNG). Aşağıdaki örnek, dosya sisteminden bir resmi yükleyip sunuma eklemenizi ve ardından şeklin dolgu özelliklerini kullanarak su işareti olarak uygulamanızı gösterir.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Su İşaretini Düzenlemeden Kilitleme**

Bir su işaretinin düzenlenmesini önlemek gerekiyorsa, şeklin [IAutoShape.ShapeLock](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/properties/shapelock) özelliğini kullanın. Bu özellik sayesinde şekli seçilmekten, yeniden boyutlandırılmaktan, konumu değiştirilmeye, diğer öğelerle gruplanmaya, metni düzenlemeden kilitlenmeye ve daha fazlasına karşı koruyabilirsiniz:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Su işareti şeklinin değiştirilmesini kilitle.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Su İşaretini Ön Tarafa Getirme**

Aspose.Slides içinde şekillerin Z-sırası, [IShapeCollection.Reorder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/reorder/#reorder) metodu ile ayarlanabilir. Bunu yapmak için, sunum slaytları listesinden bu metodu çağırıp şekil referansını ve sıralama numarasını metoda geçmeniz gerekir. Böylece bir şekli slaytın önüne getirebilir ya da arkasına gönderebilirsiniz. Bu özellik, su işaretini sunumun önüne koymanız gerektiğinde özellikle faydalıdır:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Su İşareti Döndürme**

Su işaretinizin döndürülmesi, sunumunuzun görsel etkisini ve inceliğini önemli ölçüde artırabilir. Örneğin, diyagonal bir su işareti daha az müdahaleci olurken hâlâ yetkisiz kullanım karşısında güçlü koruma sağlar. Aşağıdaki örnek, su işaretini slayt boyunca diyagonal konumlandırmak için slayt boyutlarına göre uygun açıyı hesaplar. Bu dinamik hesaplama, farklı slayt boyutlarında su işaretinin etkili kalmasını sağlar.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Su İşaretine İsim Verme**

Aspose.Slides, bir şeklin adını ayarlamanıza izin verir. Şekil adını kullanarak ileride şekli değiştirmek ya da silmek için ona erişebilirsiniz. Su işareti şeklinin adını ayarlamak için [IAutoShape.Name](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/properties/name) özelliğine atayın:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Su İşaretini Kaldırma**

Su işareti şekli kaldırmak için, [IAutoShape.Name](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/properties/name) özelliğini kullanarak slayt şekilleri içinde bulun. Ardından su işareti şekline [IShapeCollection.Remove](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/remove/) metodunu uygulayın:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Canlı Bir Örnek**

**Aspose.Slides ücretsiz** [Su İşareti Ekle](https://products.aspose.app/slides/tr/watermark) ve [Su İşareti Kaldır](https://products.aspose.app/slides/tr/watermark/remove-watermark) çevrim içi araçlarını inceleyebilirsiniz.

![Online tools to add and remove watermarks](online_tools.png)

## **SSS**

### Su işareti nedir ve neden kullanmalıyım?

Su işareti, slaytlara uygulanan bir metin ya da resim katmanıdır; fikri mülkiyeti korur, marka bilinirliğini artırır veya sunumların izinsiz kullanılmasını engeller.

### Sunumdaki tüm slaytlara su işareti ekleyebilir miyim?

Evet, Aspose.Slides programatik olarak bir sunumdaki her slayta su işareti eklemenizi sağlar. Tüm slaytları döngüye alıp su işareti ayarlarını tek tek uygulayabilirsiniz.

### Su işaretinin şeffaflığını nasıl ayarlayabilirim?

Şeklin dolgu ayarlarını ([FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/fillformat/)) değiştirerek su işaretinin şeffaflığını ayarlayabilirsiniz. Bu, su işaretinin ince kalmasını ve slayt içeriğinden dikkat çekmemesini sağlar.

### Hangi resim formatları su işareti için destekleniyor?

Aspose.Slides PNG, JPEG, GIF, BMP, SVG ve daha fazlası gibi çeşitli resim formatlarını destekler.

### Metin su işareti için yazı tipi ve stili özelleştirebilir miyim?

Evet, sunum tasarımınıza ve marka tutarlılığına uyacak şekilde istediğiniz yazı tipi, boyut ve stili seçebilirsiniz.

### Su işaretinin konumunu ya da yönünü nasıl değiştirebilirim?

Şeklin koordinatlarını, boyutlarını ve döndürme özelliklerini programatik olarak değiştirerek su işaretinin konumunu ve yönünü ayarlayabilirsiniz.
---
title: PowerPoint Sunumlarına .NET'te Filigran Ekleme
linktitle: Filigran
type: docs
weight: 40
url: /tr/net/watermark/
keywords:
- filigran
- metin filigranı
- resim filigranı
- filigran ekle
- filigranı değiştir
- filigranı kaldır
- filigranı sil
- PPT'ye filigran ekle
- PPTX'e filigran ekle
- ODP'ye filigran ekle
- PPT'den filigranı kaldır
- PPTX'den filigranı kaldır
- ODP'den filigranı kaldır
- PPT'den filigranı sil
- PPTX'den filigranı sil
- ODP'den filigranı sil
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında .NET ile metin ve resim filigranlarını yöneterek taslak, gizli bilgi, telif hakkı ve daha fazlasını belirtebilirsiniz."
---
## **Giriş**

**Bir filigran**, bir slaytta ya da tüm sunum slaytlarında kullanılan metin veya resim damgasıdır. Genellikle bir filigran, sunumun taslak olduğunu belirtmek (ör. “Taslak” filigranı), gizli bilgi içerdiğini göstermek (ör. “Gizli” filigranı), hangi şirkete ait olduğunu belirtmek (ör. “Şirket Adı” filigranı), sunum yazarını tanımlamak vb. amaçlarla kullanılır. Filigran, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Filigranlar, PowerPoint ve OpenDocument sunum formatlarında kullanılır. Aspose.Slides içinde PowerPoint PPT, PPTX ve OpenDocument ODP dosya formatlarına filigran ekleyebilirsiniz.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/net/) içinde PowerPoint veya OpenDocument belgelerinde filigran oluşturmanın ve tasarım‑davranışlarını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin filigranı eklemek için [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) arayüzünü, resim filigranı eklemek için ise [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/pictureframe/) sınıfını ya da bir filigran şekline resmi doldurmayı kullanmanızdır. `PictureFrame`, tüm esnek şekil ayarlarını kullanmanıza olanak tanıyan [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape) arayüzünü uygular. `ITextFrame` bir şekil olmadığı ve ayarları sınırlı olduğu için bir [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape) nesnesine sarılır.

Filigran iki şekilde uygulanabilir: tek bir slayta ya da tüm sunum slaytlarına. Tüm slaytlara filigran eklemek için Slide Master kullanılır — filigran Slide Master’a eklenir, orada tamamen tasarlanır ve bireysel slaytlardaki filigranı düzenleme iznine etki etmeden tüm slaytlara uygulanır.

Filigran genellikle diğer kullanıcılar tarafından düzenlenemez olarak kabul edilir. Filigranın (ya da aslen filigranın üst şeklinin) düzenlenmesini önlemek için Aspose.Slides şekil kilitleme işlevi sağlar. Belirli bir şekil normal bir slaytta ya da Slide Master’da kilitlenebilir. Filigran şekli Slide Master’da kilitlenirse, tüm sunum slaytlarında kilitli olur.

Filigrana bir ad atayabilirsiniz; böylece gelecekte silmek istediğinizde slaytın şekilleri arasında adla bulabilirsiniz.

Filigranı istediğiniz gibi tasarlayabilirsiniz; ancak genellikle merkez hizalama, döndürme, ön konum gibi ortak özellikler bulunur. Aşağıdaki örneklerde bunların nasıl kullanılacağını inceleyeceğiz.

## **Metin Filigranı**

### **Bir Slayta Metin Filigranı Ekleme**

PPT, PPTX veya ODP içinde metin filigranı eklemek için önce slayta bir şekil ekleyin, ardından bu şekle bir metin çerçevesi ekleyin. Metin çerçevesi, [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe) arayüzüyle temsil edilir. Bu tür, konumlandırma için geniş özellik setine sahip [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) arayüzünden türetilmediği için [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) nesnesine sarılır. Şekle filigran metni eklemek için aşağıdaki gibi [AddTextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/methods/addtextframe) metodunu kullanın.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Slayta filigranı ekle.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [TextFrame Sınıfı Nasıl Kullanılır?](/slides/tr/net/text-formatting/)
{{% /alert %}}

### **Bir Sunuma Metin Filigranı Ekleme**

Metin filigranını tüm sunuma (yani tüm slaytlara aynı anda) eklemek istiyorsanız, [MasterSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/masterslide/) üzerine ekleyin. Geri kalan mantık tek bir slayta filigran eklemekle aynıdır — bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) nesnesi oluşturun ve ardından [AddTextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/methods/addtextframe) metodunu kullanarak filigranı ekleyin.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Filigranı ana slayta ekle.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Slide Master Nasıl Kullanılır?](/slides/tr/net/slide-master/)
{{% /alert %}}

### **Filigran Şekli Şeffaflığını Ayarlama**

Varsayılan olarak dikdörtgen şekil doldurma ve kenar rengiyle stilize edilir. Bu, filigran eklendiğinde düz bir arka plan ya da kenar ile görünebilir ve slayt içeriğinden dikkat dağıtabilir. Filigranın ince kalması ve sunumun görsel tasarımına müdahale etmemesi için şekli tamamen şeffaf yapabilirsiniz.

Aşağıdaki kod satırları, doldurma ve kenar renklerini kaldırarak şekli şeffaf hâle getirir:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Metin Filigranı İçin Font Ayarlama**

Metin filigranını slayda uygulamadan önce görünümünü özelleştirerek sunumun genel tasarımıyla uyumlu olmasını sağlamalısınız. Font tipini ve boyutunu değiştirerek filigranın okunaklı ve estetik olmasını sağlayabilirsiniz. Font özelleştirmesi, marka kimliğini pekiştirmeye ya da sadece sunum stiline uymaya yardımcı olur.

Aşağıdaki kod örneği, belirli bir Latin fontu seçerek ve uygun bir font yüksekliği ayarlayarak filigranın font ayarlarını nasıl düzenleyeceğinizi gösterir:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Filigran Metin Rengini Ayarlama**

Filigranı uygulamadan önce metin renginin slayt içeriğiyle iyi uyum sağlayacak şekilde ayarlandığından emin olun. Renk şeffaflığı (alfa) ile kırmızı, yeşil ve mavi bileşenlerini ayarlayarak görünür ama göz yormayan bir yarı şeffaf filigran oluşturabilirsiniz. Bu yaklaşım, ana sunumun odak noktasını korurken içeriğinizi korur.

Filigran metin rengini ayarlamak için aşağıdaki kodu kullanın:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Metin Filigranını Ortalamak**

Metin filigranını düzgün bir şekilde ortalamak, slayt boyutlarından bağımsız olarak simetrik bir konumda bulunmasını sağlayarak sunumun estetiğini büyük ölçüde artırır. Bu yaklaşım, slaytlarınıza profesyonel bir görünüm kazandırır ve filigranın ana içeriği engellemesini önler.

Aşağıdaki kod örneği, slaytın merkez konumunu hesaplayıp metin filigranını ona göre yerleştirir:

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Aşağıdaki görsel, son sonucu göstermektedir.

![Metin filigranı](text_watermark.png)

## **Resim Filigranı**

### **Bir Sunuma Resim Filigranı Ekleme**

Birçok durumda, resim filigranı metin filigranına göre daha benzersiz bir marka öğesi ya da daha görsel bir alternatif sunar. Filigranı eklemeden önce resim dosyasının (ör. şeffaflık için PNG) hazır olduğundan emin olun. Aşağıdaki örnek, dosya sisteminizden bir resmi yükleyip sunuma ekleyerek şeklin doldurma özellikleri aracılığıyla filigran olarak uygulamayı gösterir.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Filigranı Düzenlemeden Kilitleme**

Filigranın düzenlenmesini engellemek gerekiyorsa, şekil üzerindeki [IAutoShape.ShapeLock](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/properties/shapelock) özelliğini kullanın. Bu özellik sayesinde şeklin seçilmesi, yeniden boyutlandırılması, konumlandırılması, diğer öğelerle gruplanması, metninin düzenlenmesinin kilitlenmesi ve daha fazlası korunur:

```cs
// Filigran şeklini değiştirmeye karşı kilitle.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Filigranı Öne Getirme**

Aspose.Slides içinde şekillerin Z‑order’ı, [IShapeCollection.Reorder](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/reorder/#reorder) metodu ile ayarlanabilir. Bunun için sunum slaytları listesinden bu metodu çağırıp şekil referansını ve sıralama numarasını metoda geçmeniz gerekir. Böylece bir şekli slaytın önüne getirip arkasına gönderebilirsiniz. Bu özellik, filigranı sunumun önüne yerleştirmeniz gerektiğinde özellikle faydalıdır:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Filigran Döndürme Ayarı**

Filigran döndürmesini ayarlamak, sunumunuzun görsel etkisini ve inceliğini önemli ölçüde artırabilir. Örneğin, köşegen bir filigran daha az müdahaleci olurken yine de yetkisiz kullanım karşısında güçlü bir koruma sağlar. Aşağıdaki örnek, slayt boyutlarına göre uygun bir açı hesaplayarak filigranı slayt boyunca köşegen konumlandırır. Bu dinamik hesaplama, slayt boyutları değişse bile filigranın etkili kalmasını sağlar.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Filigrana Bir İsim Verme**

Aspose.Slides, bir şeklin adını ayarlamanıza izin verir. Şekil adını kullanarak gelecekte ona erişebilir, değiştirebilir ya da silebilirsiniz. Filigran şeklinin adını ayarlamak için [IAutoShape.Name](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/properties/name) özelliğine değer atayın:

```cs
watermarkShape.Name = "watermark";
```

## **Filigranı Kaldırma**

Filigran şekli silmek için slayt şekilleri arasında [IAutoShape.Name](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/properties/name) özelliğiyle bulun ve ardından [IShapeCollection.Remove](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/remove/) metoduna aktarın:

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Canlı Bir Örnek**

Aspose.Slides ücretsiz **Add Watermark** ve **Remove Watermark** çevrimiçi araçlarını inceleyebilirsiniz:

- **Filigran Ekle**: https://products.aspose.app/slides/tr/watermark  
- **Filigran Kaldır**: https://products.aspose.app/slides/tr/watermark/remove-watermark

![Filigran ekleme ve kaldırma çevrimiçi araçları](online_tools.png)

## **SSS**

**Filigran nedir ve neden kullanmalıyım?**  
Filigran, slaytlara uygulanan bir metin ya da resim üst katmanıdır; fikri mülkiyeti korur, marka tanınırlığını artırır veya sunumların yetkisiz kullanılmasını engeller.

**Tüm slaytlara filigran ekleyebilir miyim?**  
Evet, Aspose.Slides programatik olarak bir sunumdaki her slayta filigran eklemenizi sağlar. Tüm slaytları döngüyle gezerek filigran ayarlarını bireysel olarak uygulayabilirsiniz.

**Filigranın şeffaflığını nasıl ayarlarım?**  
Şeklin doldurma ayarlarını ([FillFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/fillformat/)) değiştirerek filigranın şeffaflığını ayarlayabilirsiniz. Bu, filigranın ince olmasını ve slayt içeriğinden dikkat dağıtmamasını sağlar.

**Hangi resim formatları filigran için destekleniyor?**  
Aspose.Slides PNG, JPEG, GIF, BMP, SVG vb. çeşitli resim formatlarını destekler.

**Metin filigranının font ve stilini özelleştirebilir miyim?**  
Evet, istediğiniz herhangi bir font, boyut ve stili seçerek sunum tasarımınızla uyumlu hâle getirebilir ve marka tutarlılığını koruyabilirsiniz.

**Filigranın konumunu veya yönelimini nasıl değiştiririm?**  
Şeklin koordinatlarını, boyutunu ve döndürme özelliklerini programatik olarak değiştirerek filigranın konumunu ve yönelimini ayarlayabilirsiniz.
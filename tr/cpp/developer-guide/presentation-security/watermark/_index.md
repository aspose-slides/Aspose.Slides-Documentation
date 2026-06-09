---
title: C++'ta Sunumlara Filigran Ekleme
linktitle: Filigran
type: docs
weight: 40
url: /tr/cpp/watermark/
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
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında C++ kullanarak metin ve resim filigranlarını yöneterek taslak, gizli bilgi, telif hakkı ve daha fazlasını belirtin."
---
## **Giriş**

**Filigran**, bir sunumda bir slaytta ya da tüm sunum slaytlarında kullanılan bir metin veya resim damgasıdır. Genellikle bir filigran, sunumun taslak olduğunu göstermek (ör. “Taslak” filigranı), gizli bilgi içerdiğini göstermek (ör. “Gizli” filigranı), hangi şirkete ait olduğunu belirtmek (ör. “Şirket Adı” filigranı), sunum yazarını tanımlamak vb. amaçlarla kullanılır. Filigran, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Filigranlar hem PowerPoint hem de OpenOffice sunum formatlarında kullanılır. Aspose.Slides içinde PowerPoint PPT, PPTX ve OpenOffice ODP dosya formatlarına filigran ekleyebilirsiniz.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/cpp/) içinde PowerPoint ya da OpenOffice belgelerinde filigran oluşturmanın ve tasarımını, davranışını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin filigranı eklemek için [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) arayüzünü, resim filigranı eklemek için ise [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) sınıfını veya bir filigran şekline resmi doldurmayı kullanmanızdır. `PictureFrame`, şekil nesnesinin tüm esnek ayarlarını kullanmanıza olanak tanıyan [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) arayüzünü uygular. `ITextFrame` bir şekil olmadığından ve ayarları sınırlı olduğundan, bir [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) nesnesine sarılır.

Bir filigran iki şekilde uygulanabilir: tek bir slayta ya da tüm sunum slaytlarına. Tüm sunum slaytlarına filigran uygulamak için Slide Master kullanılır — filigran Slide Master’a eklenir, orada tam olarak tasarlanır ve bireysel slaytlardaki filigranı düzenleme iznini etkilemeden tüm slaytlara uygulanır.

Filigran genellikle diğer kullanıcılar tarafından düzenlenemez kabul edilir. Filigranın (ya da daha doğrusu filigranın üst şeklinin) düzenlenmesini önlemek için Aspose.Slides şekil kilitleme işlevselliği sunar. Belirli bir şekil normal bir slaytta ya da Slide Master’da kilitlenebilir. Filigran şekli Slide Master’da kilitlenirse, tüm sunum slaytlarındaki filigran da kilitlenir.

Gelecekte filigranı silmek isterseniz, adını slaytın şekilleri içinde isimle bulabilmeniz için filigrana bir isim atayabilirsiniz.

Filigranı istediğiniz gibi tasarlayabilirsiniz; ancak filigranlarda genellikle merkez hizalama, döndürme, ön konum gibi ortak özellikler bulunur. Aşağıdaki örneklerde bunların nasıl kullanılacağını inceleyeceğiz.

## **Metin Filigranı**

### **Bir Slayta Metin Filigranı Ekleme**

PPT, PPTX veya ODP dosyalarına bir metin filigranı eklemek için önce slayta bir şekil ekleyin, ardından bu şekle bir metin çerçevesi ekleyin. Metin çerçevesi, [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) arayüzü tarafından temsil edilir. Bu tür, konumlandırmayı esnek bir şekilde yapabilen geniş özellik setine sahip [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) üzerinden türetilmediği için, [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) nesnesi bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) nesnesine sarılır. Şekle filigran metni eklemek için aşağıda gösterildiği gibi [AddTextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/addtextframe/) metodunu kullanın.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Metin Çerçevesi Sınıfının Nasıl Kullanılacağını](/slides/tr/cpp/text-formatting/)
{{% /alert %}}

### **Bir Sunuma Metin Filigranı Ekleme**

Metin filigranını tüm sunuma (yani tüm slaytlara aynı anda) eklemek isterseniz, bunu [MasterSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/masterslide/) üzerine ekleyin. Geri kalan mantık, tek bir slayta filigran eklerken olduğu gibidir — bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) nesnesi oluşturun ve ardından [AddTextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/addtextframe/) metodunu kullanarak filigranı ekleyin.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Slide Master Nasıl Kullanılır](/slides/tr/cpp/slide-master/)
{{% /alert %}}

### **Filigran Şekli Şeffaflığını Ayarlama**

Varsayılan olarak, dikdörtgen şekil dolgu ve kenar renkleriyle stilize edilmiştir. Aşağıdaki kod satırları şekli şeffaf hale getirir.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Metin Filigranı İçin Yazı Tipi Ayarlama**

Aşağıdaki gibi metin filigranının yazı tipini değiştirebilirsiniz.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Filigran Metin Rengini Ayarlama**

Filigran metninin rengini ayarlamak için şu kodu kullanın:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Metin Filigranını Ortalamak**

Filigranı bir slaytta ortalamak mümkündür; bunun için aşağıdaki işlemleri yapabilirsiniz:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

Aşağıdaki resim son sonucu gösterir.

![Metin filigranı](text_watermark.png)

## **Resim Filigranı**

### **Bir Sunuma Resim Filigranı Ekleme**

Bir sunum slaytına resim filigranı eklemek için şu adımları izleyebilirsiniz:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Filigranı Düzenlemeden Kilitleme**

Filigranın düzenlenmesini önlemek gerekirse, şekil üzerinde [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/get_autoshapelock/) metodunu kullanın. Bu özellik sayesinde şeklin seçilmesi, yeniden boyutlandırılması, konumunun değiştirilmesi, diğer öğelerle gruplanması, metninin düzenlenmesinin kilitlenmesi ve daha fazlası korunabilir:

```cpp
// Filigran şeklinin değiştirilmesini kilitle
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Filigranı Öne Getirme**

Aspose.Slides içinde şekillerin Z-sırası, [IShapeCollection::Reorder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/reorder/) metodu ile ayarlanabilir. Bunu yapmak için sunum slaytları listesinden bu metodu çağırıp şekil referansını ve sırasını metoda geçirmeniz gerekir. Böylece bir şekli slaytın önüne getirebilir ya da arkasına gönderebilirsiniz. Bu özellik, filigranı sunumun önüne yerleştirmeniz gerektiğinde özellikle faydalıdır:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Filigran Döndürmesini Ayarlama**

Filigranı slayt boyunca çapraz konumlandırmak için döndürmeyi nasıl ayarlayacağınıza dair bir kod örneği:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Filigran İçin Bir İsim Belirleme**

Aspose.Slides, bir şeklin adını ayarlamanıza izin verir. Şekil adını kullanarak gelecekte şekle erişebilir, değiştirebilir veya silebilirsiniz. Filigran şeklinin adını ayarlamak için [IAutoShape::set_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_name/) metoduna atayın:

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Filigranı Kaldırma**

Filigran şeklini kaldırmak için [IAutoShape::get_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_name/) metodunu kullanarak slayt şekilleri arasında bulun. Ardından filigran şeklini [IShapeCollection::Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/remove/) metoduna geçirin:

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Canlı Bir Örnek**

**Aspose.Slides ücretsiz** [Filigran Ekle] (https://products.aspose.app/slides/tr/watermark) ve [Filigran Kaldır] (https://products.aspose.app/slides/tr/watermark/remove-watermark) çevrimiçi araçlarını inceleyebilirsiniz.

![Filigran ekleme ve kaldırma için çevrimiçi araçlar](online_tools.png)

## **SSS**

**Filigran nedir ve neden kullanmalıyım?**

Filigran, slaytlara uygulanan bir metin veya resim üst katmanıdır; fikri mülkiyeti korumaya, marka tanınırlığını artırmaya veya sunumların yetkisiz kullanılmasını engellemeye yardımcı olur.

**Bir sunumdaki tüm slaytlara filigran ekleyebilir miyim?**

Evet, Aspose.Slides, bir sunumdaki her slayta programatik olarak filigran eklemenizi sağlar. Tüm slaytlar üzerinden döngü oluşturarak filigran ayarlarını ayrı ayrı uygulayabilirsiniz.

**Filigranın şeffaflığını nasıl ayarlayabilirim?**

Şeklin doldurma ayarlarını ([FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/get_fillformat/)) değiştirerek filigranın şeffaflığını ayarlayabilirsiniz. Bu sayede filigran göze çarpmadan slayt içeriğinden ayrılır.

**Filigran için hangi resim formatları destekleniyor?**

Aspose.Slides, PNG, JPEG, GIF, BMP, SVG ve daha fazlası dahil olmak üzere çeşitli resim formatlarını destekler.

**Metin filigranının yazı tipi ve stilini özelleştirebilir miyim?**

Evet, sunum tasarımınızla uyumlu ve marka tutarlılığı sağlayacak herhangi bir yazı tipi, boyut ve stil seçebilirsiniz.

**Filigranın konumunu veya yönünü nasıl değiştiririm?**

Şeklin koordinatlarını, boyutunu ve dönüş (rotation) özelliklerini programatik olarak değiştirerek filigranın konum ve yönünü ayarlayabilirsiniz.
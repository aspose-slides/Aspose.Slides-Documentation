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
- PPTX'ye filigran ekle
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
description: "C++'ta PowerPoint ve OpenDocument sunumlarında metin ve resim filigranlarını, taslak, gizli bilgi, telif hakkı ve daha fazlasını belirtmek için yönetin."
---
## **Giriş**

**Bir filigran**, bir sunumda kullanılan metin veya resim damgasıdır ve bir slaytta ya da tüm sunum slaytlarında kullanılır. Genellikle bir filigran, sunumun taslak olduğunu (örnek: "Taslak" filigranı), gizli bilgi içerdiğini (örnek: "Gizli" filigranı), hangi şirkete ait olduğunu (örnek: "Şirket Adı" filigranı), sunum yazarını belirlemek amacıyla vb. göstermek için kullanılır. Bir filigran, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Filigranlar hem PowerPoint hem de OpenOffice sunum formatlarında kullanılır. Aspose.Slides içinde PowerPoint PPT, PPTX ve OpenOffice ODP dosya formatlarına filigran ekleyebilirsiniz.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/cpp/) içinde PowerPoint veya OpenOffice belgelerinde filigran oluşturmanın ve tasarımını ve davranışını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin filigranı eklemek için [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) arabirimini, resim filigranı eklemek için ise [PictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pictureframe/) sınıfını veya bir filigran şekline resim doldurmayı kullanmanızdır. `PictureFrame` [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) arabirimini uygular, böylece şekil nesnesinin tüm esnek ayarlarını kullanabilirsiniz. `ITextFrame` bir şekil olmadığından ve ayarları sınırlı olduğundan, bir [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) nesnesine sarılır.

Filigran iki şekilde uygulanabilir: tek bir slayta veya tüm sunum slaytlarına. Tüm sunum slaytlarına filigran uygulamak için Slayt Ana Şablonu (Slide Master) kullanılır — filigran Slayt Ana Şablonuna eklenir, orada tam olarak tasarlanır ve bireysel slaytlardaki filigranı düzenleme iznini etkilemeden tüm slaytlara uygulanır.

Filigran genellikle diğer kullanıcılar tarafından düzenlenemez olarak kabul edilir. Filigranın (ya da daha doğrusu filigranın üst şeklinin) düzenlenmesini önlemek için Aspose.Slides şekil kilitleme işlevi sağlar. Belirli bir şekil normal bir slaytta veya bir Slayt Ana Şablonunda kilitlenebilir. Filigran şekli Slayt Ana Şablonunda kilitlenirse, tüm sunum slaytlarında kilitli olur.

Filigrana bir ad atayabilirsiniz; böylece gelecekte silmek istediğinizde slaytın şekilleri arasından adını kullanarak bulabilirsiniz.

Filigranı istediğiniz gibi tasarlayabilirsiniz; ancak genellikle filigranlarda ortak özellikler bulunur: ortalanmış hizalama, döndürme, ön konum gibi. Aşağıdaki örneklerde bunların nasıl kullanılacağını inceleyeceğiz.

## **Metin Filigranı**

### **Bir Slayta Metin Filigranı Ekleme**

PPT, PPTX veya ODP dosyalarına metin filigranı eklemek için önce slayta bir şekil ekleyip ardından bu şekle bir metin çerçevesi ekleyebilirsiniz. Metin çerçevesi [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) arabirimiyle temsil edilir. Bu tip [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) arabiriminden türetilmediği için, şeklin konumlandırılması gibi esnek özelliklere sahip değildir. Bu nedenle [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) nesnesi bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) nesnesine sarılır. Şekle filigran metni eklemek için aşağıdaki gibi [AddTextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/addtextframe/) metodunu kullanın.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [TextFrame Sınıfının Nasıl Kullanılacağını Öğrenin](/slides/tr/cpp/text-formatting/)
{{% /alert %}}

### **Bir Sunuma Metin Filigranı Ekleme**

Metin filigranını tüm sunuma (yani tüm slaytlara birden) eklemek isterseniz, [MasterSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/masterslide/) üzerine ekleyin. Tek bir slayta filigran ekleme mantığı aynı kalır — bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) nesnesi oluşturun ve ardından [AddTextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/addtextframe/) metoduyla filigranı ekleyin.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [Slayt Ana Şablonunun Nasıl Kullanılacağını Öğrenin](/slides/tr/cpp/slide-master/)
{{% /alert %}}

### **Filigran Şekil Şeffaflığını Ayarlama**

Varsayılan olarak dikdörtgen şekil dolgu ve kenar renkleriyle stilize edilir. Aşağıdaki kod satırları şekli şeffaf hale getirir.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Metin Filigranı İçin Yazı Tipini Ayarlama**

Aşağıdaki gibi metin filigranının yazı tipini değiştirebilirsiniz.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Filigran Metin Rengini Ayarlama**

Filigran metninin rengini ayarlamak için şu kodu kullanın:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Metin Filigranını Ortalamak**

Filigranı slayt ortasına yerleştirmek mümkündür; bunun için şu adımları izleyin:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

Aşağıdaki görüntü sonuç örneğini gösterir.

![Metin filigranı](text_watermark.png)

## **Resim Filigranı**

### **Bir Sunuma Resim Filigranı Ekleme**

Sunumdaki bir slayta resim filigranı eklemek için aşağıdaki adımları izleyebilirsiniz:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Filigranı Düzenlemeden Kilitleme**

Filigranın düzenlenmesini önlemek gerekiyorsa, şekil üzerinde [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/get_autoshapelock/) metodunu kullanın. Bu özellik sayesinde şekli seçilmekten, yeniden boyutlandırılmaktan, konumu değiştirilmektan, diğer öğelerle gruplamaktan, metni düzenlenmekten ve daha birçok işlemden koruyabilirsiniz:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Filigran şeklinin değiştirilmesini kilitle
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Filigranı Öne Getirme**

Aspose.Slides içinde şekillerin Z‑sırası, [IShapeCollection::Reorder](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/reorder/) metodu ile ayarlanabilir. Bunu yapmak için sunumun slayt listesinden bu metodu çağırıp şekil referansını ve sırasını parametre olarak geçirmeniz gerekir. Böylece bir şekli slaytın önüne getirebilir veya arkasına gönderebilirsiniz. Bu özellik, filigranı sunumun önüne yerleştirmeniz gerektiğinde özellikle yararlıdır:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Filigran Döndürmesini Ayarlama**

Aşağıdaki kod örneği, filigranı slayt boyunca çapraz konumlandırmak için döndürmenin nasıl ayarlanacağını gösterir:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Filigran İçin Bir İsim Belirleme**

Aspose.Slides, bir şeklin ismini ayarlamanıza izin verir. Şekil adını kullandığınızda gelecekte bu şekle erişip değiştirebilir veya silebilirsiniz. Filigran şeklinin ismini ayarlamak için [IAutoShape::set_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_name/) metodunu kullanın:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Filigranı Kaldırma**

Filigran şeklini kaldırmak için önce [IAutoShape::get_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_name/) metodu ile slayt şekilleri arasından bulun. Sonra filigran şekilini [IShapeCollection::Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/remove/) metoduna geçirin:

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Canlı Bir Örnek**

**Aspose.Slides ücretsiz** [Filigran Ekle](https://products.aspose.app/slides/tr/watermark) ve [Filigran Kaldır](https://products.aspose.app/slides/tr/watermark/remove-watermark) çevrimiçi araçlarını kontrol etmek isteyebilirsiniz.

![Filigran ekleme ve kaldırma için çevrimiçi araçlar](online_tools.png)

## **SSS**

### **Filigran nedir ve neden kullanmalıyım?**

Filigran, slaytlara uygulanan bir metin veya resim örtüsüdür; zihinsel mülkiyeti korur, marka tanınırlığını artırır veya sunumların yetkisiz kullanımını önler.

### **Bir sunumdaki tüm slaytlara filigran ekleyebilir miyim?**

Evet, Aspose.Slides programatik olarak her slayta filigran eklemenizi sağlar. Tüm slaytlar üzerinden döngü kurarak filigran ayarlarını ayrı ayrı uygulayabilirsiniz.

### **Filigranın şeffaflığını nasıl ayarlayabilirim?**

Filigranın şeffaflığını, şeklin doldurma ayarlarını ([FillFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/get_fillformat/)) değiştirerek ayarlayabilirsiniz. Bu sayede filigran göze çarpmadan içerikle uyumlu olur.

### **Filigranlar için hangi görüntü formatları destekleniyor?**

Aspose.Slides PNG, JPEG, GIF, BMP, SVG ve daha birçok görüntü formatını destekler.

### **Metin filigranının yazı tipini ve stilini özelleştirebilir miyim?**

Evet, sunum tasarımınıza ve marka tutarlılığına uygun olarak istediğiniz yazı tipi, boyut ve stili seçebilirsiniz.

### **Filigranın konumunu veya yönünü nasıl değiştiririm?**

Şeklin koordinatlarını, boyutunu ve döndürme özelliklerini programatik olarak değiştirerek filigranın konumunu ve yönünü ayarlayabilirsiniz.
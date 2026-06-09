---
title: PHP'de Sunumlara Filigran Ekleme
linktitle: Filigran
type: docs
weight: 40
url: /tr/php-java/watermark/
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
- PHP
- Aspose.Slides
description: "PHP'de PowerPoint ve OpenDocument sunumlarında taslak, gizli bilgi, telif hakkı ve benzeri durumları belirtmek için metin ve resim filigranlarını yönetin."
---
## **Giriş**

**Bir filigran**, bir sunumda slayt üzerinde veya tüm sunum slaytları boyunca kullanılan bir metin veya resim damgasıdır. Genellikle, bir filigran sunumun taslak olduğunu (ör. “Draft” filigranı), gizli bilgiler içerdiğini (ör. “Confidential” filigranı), hangi şirkete ait olduğunu (ör. “Company Name” filigranı), sunum yazarını tanımlamak vb. göstermek için kullanılır. Filigran, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Filigranlar hem PowerPoint hem de OpenOffice sunum formatlarında kullanılır. Aspose.Slides ile PowerPoint PPT, PPTX ve OpenOffice ODP dosya formatlarına filigran ekleyebilirsiniz.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/php-java/)’de PowerPoint veya OpenOffice belgelerinde filigran oluşturmanın ve tasarımını ve davranışını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin filigranı eklemek için [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) sınıfını, resim filigranı eklemek için ise [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) sınıfını veya bir filigran şekline resmi doldurmayı kullanmanız gerektiğidir. `PictureFrame` [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfını uygular, bu sayede şekil nesnesinin tüm esnek ayarlarını kullanabilirsiniz. `ITextFrame` bir şekil olmadığından ve ayarları sınırlı olduğundan bir [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) nesnesine sarılır.

Filigranın uygulanabileceği iki yol vardır: tek bir slayta ya da tüm sunum slaytlarına. Tüm slaytlara filigran uygulamak için Slide Master kullanılır — filigran Slide Master’a eklenir, orada tam tasarlanır ve bireysel slaytlardaki filigranı düzenleme iznini etkilemeden tüm slaytlara uygulanır.

Filigran genellikle diğer kullanıcılar tarafından düzenlenemez olarak kabul edilir. Filigranın (ya da daha doğrusu filigranın üst şeklinin) düzenlenmesini engellemek için Aspose.Slides şekil kilitleme işlevi sağlar. Belirli bir şekil normal bir slaytta ya da Slide Master’da kilitlenebilir. Filigran şekli Slide Master’da kilitlendiğinde, tüm sunum slaytlarında kilitli olur.

Filigrana bir ad verebilir ve gelecekte silmek istediğinizde slaytın şekilleri içinde ad ile bulabilirsiniz.

Filigranı istediğiniz gibi tasarlayabilirsiniz; ancak genellikle ortalanma, döndürme, ön konum gibi ortak özellikler bulunur. Aşağıdaki örneklerde bunların nasıl kullanılacağını inceleyeceğiz.

## **Metin Filigranı**

### **Bir Slayta Metin Filigranı Ekleme**

PPT, PPTX veya ODP içinde metin filigranı eklemek için önce slayta bir şekil ekleyip bu şekle bir metin çerçevesi ekleyebilirsiniz. Metin çerçevesi [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) sınıfı ile temsil edilir. Bu tür [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfından türetilmediği için, şeklin konumlandırması için geniş bir özellik seti sunmaz. Bu yüzden [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) nesnesi bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) nesnesine sarılır. Şekle filigran metni eklemek için aşağıda gösterildiği gibi [addTextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/#addTextFrame) yöntemini kullanın.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/tr/php-java/text-formatting/)
{{% /alert %}}

### **Bir Sunuma Metin Filigranı Ekleme**

Tüm sunuma (yani tüm slaytlara) bir metin filigranı eklemek istiyorsanız, filigranı [MasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) üzerine ekleyin. Tek bir slayta filigran eklerken kullanılan mantık aynı kalır — bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) nesnesi oluşturun ve ardından [addTextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/#addTextFrame) yöntemiyle filigranı ekleyin.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/tr/php-java/slide-master/)
{{% /alert %}}

### **Filigran Şeklinin Şeffaflığını Ayarlama**

Varsayılan olarak dikdörtgen şekil dolgu ve çizgi renkleriyle stilize edilir. Aşağıdaki kod satırları şekli şeffaf hale getirir.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Metin Filigranı İçin Yazı Tipi Ayarlama**

Aşağıdaki gibi metin filigranının yazı tipini değiştirebilirsiniz.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Filigran Metin Rengini Ayarlama**

Filigran metninin rengini ayarlamak için şu kodu kullanın:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **Metin Filigranını Ortalamak**

Filigranı bir slaytta ortalamak mümkündür ve bunun için şu adımları izleyebilirsiniz:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

Aşağıdaki resim son sonucu gösterir.

![Metin filigranı](text_watermark.png)

## **Resim Filigranı**

### **Bir Sunuma Resim Filigranı Ekleme**

Bir sunum slaytı üzerine resim filigranı eklemek için şu adımları izleyebilirsiniz:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Filigranı Düzenlemeden Kilitleme**

Filigranın düzenlenmesini önlemek gerekiyorsa, şekil üzerinde [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/#getAutoShapeLock) yöntemini kullanın. Bu özellik sayesinde şekli seçilmeye, yeniden boyutlandırılmaya, yeniden konumlandırılmaya, diğer öğelerle gruplandırılmaya, metni düzenlemeden kilitlemeye ve daha fazlasına karşı koruyabilirsiniz:

```php
// Filigran şeklinin değiştirilmesini kilitle
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Filigranı Ön Tarafa Getirme**

Aspose.Slides’de şekillerin Z-sırası, [ShapeCollection.reorder](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#reorder) yöntemi ile ayarlanabilir. Bunu yapmak için sunum slaytları listesinden bu yöntemi çağırıp şekil referansını ve sıra numarasını metoda geçmeniz gerekir. Böylece bir şekli slaytın önüne ya da arkasına taşıyabilirsiniz. Bu özellik, filigranı sunumun önünde konumlandırmanız gerektiğinde özellikle faydalıdır:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **Filigran Döndürme Ayarı**

Filigranı slayt boyunca çapraz konumlandırmak için dönüş ayarını nasıl yapacağınıza dair bir kod örneği:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **Filigrana İsim Verme**

Aspose.Slides, bir şeklin adını ayarlamanıza izin verir. Şekil adını kullanarak gelecekte ona erişebilir, değiştirebilir veya silebilirsiniz. Filigran şeklinin adını ayarlamak için [AutoShape.setName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#setName) yöntemine atayın:

```php
$watermarkShape->setName("watermark");
```

### **Filigranı Kaldırma**

Filigran şeklini kaldırmak için önce slayt şekilleri içinde [AutoShape.getName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getName) yöntemiyle bulun, ardından [ShapeCollection.remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#remove) yöntemine geçirin:

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **SSS**

**Filigran nedir ve neden kullanmalıyım?**

Filigran, slaytlara uygulanan bir metin veya resim üst katmanıdır ve fikri mülkiyeti korumaya, marka tanınırlığını artırmaya veya sunumların izinsiz kullanılmasını önlemeye yardımcı olur.

**Tüm slaytlara filigran ekleyebilir miyim?**

Evet, Aspose.Slides programlı olarak bir sunumdaki her slayta filigran eklemenizi sağlar. Tüm slaytlar üzerinden döngü kurarak filigran ayarlarını ayrı ayrı uygulayabilirsiniz.

**Filigranın şeffaflığını nasıl ayarlarım?**

Şeklin dolgu ayarlarını ([getFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getfillformat/)) değiştirerek filigranın şeffaflığını ayarlayabilirsiniz. Bu sayede filigran hafif olur ve slayt içeriğinden dikkat çekmez.

**Filigran için hangi resim formatları desteklenir?**

Aspose.Slides PNG, JPEG, GIF, BMP, SVG ve daha fazlası dahil olmak üzere çeşitli resim formatlarını destekler.

**Metin filigranının yazı tipini ve stilini özelleştirebilir miyim?**

Evet, sunum tasarımınıza ve marka tutarlılığına uygun herhangi bir yazı tipi, boyut ve stil seçebilirsiniz.

**Filigranın konumunu veya yönünü nasıl değiştiririm?**

Şeklin koordinatlarını, boyutlarını ve döndürme özelliklerini programlı olarak değiştirerek filigranın konumunu ve yönünü ayarlayabilirsiniz.
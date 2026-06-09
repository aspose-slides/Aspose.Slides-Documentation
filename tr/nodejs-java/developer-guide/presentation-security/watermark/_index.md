---
title: JavaScript'te Sunumlara Filigran Ekle
linktitle: Filigran
type: docs
weight: 40
url: /tr/nodejs-java/watermark/
keywords:
- filigran
- metin filigranı
- görsel filigran
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js'te PowerPoint ve OpenDocument sunumlarında metin ve görsel filigranları yöneterek taslak, gizli bilgi, telif hakkı ve daha fazlasını gösterebilirsiniz."
---
## **Giriş**

**Filigran**, bir sunumda bir slayt üzerinde ya da tüm sunum slaytları boyunca kullanılan metin ya da resim damgasıdır. Genellikle, bir filigran sunumun taslak olduğunu (ör. "Draft" filigranı), gizli bilgi içerdiğini (ör. "Confidential" filigranı), hangi şirkete ait olduğunu (ör. "Company Name" filigranı) belirtmek, sunum yazarını tanımlamak vb. amaçlarla kullanılır. Filigran, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Filigranlar hem PowerPoint hem de OpenOffice sunum formatlarında kullanılır. Aspose.Slides içinde PowerPoint PPT, PPTX ve OpenOffice ODP dosya formatlarına filigran ekleyebilirsiniz.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/nodejs-java/) içinde PowerPoint veya OpenOffice belgelerinde filigran oluşturmanın ve tasarımını ile davranışını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin filigranları eklemek için [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) tipini, görüntü filigranları eklemek için ise [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) sınıfını ya da bir filigran şekline görüntü doldurmayı kullanmanız gerektiğidir. `PictureFrame`, [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) tipini uygular ve şekil nesnesinin tüm esnek ayarlarını kullanmanıza izin verir. `TextFrame` bir şekil olmadığından ve ayarları sınırlı olduğundan, bir [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) nesnesine sarılır.

Filigranın uygulanma şeklinin iki yolu vardır: tek bir slayta ya da tüm sunum slaytlarına. Slide Master, filigranı tüm sunum slaytlarına uygulamak için kullanılır — filigran Slide Master'a eklenir, tamamen orada tasarlanır ve bireysel slaytlardaki filigranı değiştirme iznini etkilemeden tüm slaytlara uygulanır.

Filigran genellikle diğer kullanıcılar tarafından düzenlenemez olarak kabul edilir. Filigranın (ya da aslen filigranın ebeveyn şeklinin) düzenlenmesini önlemek için Aspose.Slides şekil kilitleme işlevi sunar. Belirli bir şekil normal bir slaytta ya da Slide Master'da kilitlenebilir. Filigran şekli Slide Master'da kilitlendiğinde, tüm sunum slaytlarında kilitli olur.

Filigran için bir ad belirleyebilirsiniz; böylece gelecekte silmek istediğinizde slaytın şekilleri içinde adıyla bulabilirsiniz.

Filigranı istediğiniz şekilde tasarlayabilirsiniz; ancak genellikle filigranlarda ortak özellikler bulunur; örneğin merkez hizalama, döndürme, ön konum vb. Aşağıdaki örneklerde bunların nasıl kullanılacağını inceleyeceğiz.

## **Metin Filigranı**

### **Slayta Metin Filigranı Ekle**

PPT, PPTX veya ODP'de metin filigranı eklemek için önce slayta bir şekil ekleyebilir, ardından bu şekle bir metin çerçevesi ekleyebilirsiniz. Metin çerçevesi [**TextFrame**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrame) tipiyle temsil edilir. Bu tip, filigranı esnek bir şekilde konumlandırmak için geniş bir özellik setine sahip [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape) tipinden türetilmez. Bu nedenle, [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TextFrame) nesnesi bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) nesnesine sarılır. Şekle filigran metni eklemek için, metni parametre olarak alan [**addTextFrame**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) yöntemini kullanın:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- Nasıl kullanılır [TextFrame](/slides/tr/nodejs-java/text-formatting/).
{{% /alert %}}

### **Sunuma Metin Filigranı Ekle**

Tüm sunuma (yani tüm slaytlara bir anda) metin filigranı eklemek istiyorsanız, bunu [**MasterSlide**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/MasterSlide) üzerine ekleyin. Geri kalan mantık tek bir slayta filigran eklemeye benzer — bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape) nesnesi oluşturun ve ardından [**addTextFrame**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) yöntemiyle filigranı ekleyin:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Nasıl kullanılır ](/slides/tr/nodejs-java/slide-master/)[Slide Master](/slides/tr/nodejs-java/slide-master/)
{{% /alert %}}

### **Filigran Şekil Şeffaflığını Ayarla**

Varsayılan olarak, dikdörtgen şekil dolgu ve çizgi renkleriyle biçimlendirilir. Aşağıdaki kod satırları şekli şeffaf hâle getirir.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **Metin Filigranı İçin Yazı Tipi Ayarla**

Aşağıda gösterildiği gibi metin filigranının yazı tipini değiştirebilirsiniz.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Filigran Metin Rengini Ayarla**

Filigran metninin rengini ayarlamak için bu kodu kullanın:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **Metin Filigranını Ortala**
Filigranı bir slaytta ortalamak mümkündür ve bunun için aşağıdakileri yapabilirsiniz:


```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Aşağıdaki resim son sonucu gösterir.

![Metin filigranı](text_watermark.png)

## **Görsel Filigran**

### **Sunuma Görsel Filigran Ekle**

Tüm sunum slaytlarına görsel filigran eklemek için aşağıdakileri yapabilirsiniz:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **Filigranı Düzenlemeden Koru**

Filigranın düzenlenmesini önlemek gerekiyorsa, şekil üzerinde [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape#getShapeLock--) yöntemini kullanın. Bu özellik sayesinde şekli seçilmekten, yeniden boyutlandırılmaktan, konumu değiştirilmekten, diğer öğelerle gruplamaktan, metni düzenlemeden kilitlemekten ve daha birçok şeyden koruyabilirsiniz:

```javascript
// Filigran şeklinin değiştirilmesinden kilitle
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **Filigranı Öne Getir**

Aspose.Slides içinde şekillerin Z-sırası, [**SlideCollection.reorder**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) yöntemiyle ayarlanabilir. Bunu yapmak için bu yöntemi sunum slaytları listesinden çağırmalı ve şekil referansını ve sırasını metoda geçirmelisiniz. Böylece bir şekli slaytın önüne getirebilir ya da arkasına gönderebilirsiniz. Bu özellik, özellikle filigranı sunumun önüne yerleştirmeniz gerektiğinde faydalıdır:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Filigran Döndürmesini Ayarla**

Filigranın slayt boyunca çapraz şekilde konumlanması için döndürmesini ayarlamaya yönelik bir kod örneği aşağıdadır:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **Filigran İçin Bir Ad Ayarla**

Aspose.Slides bir şeklin adını ayarlamanıza izin verir. Şekil adını kullanarak gelecekte onu değiştirebilir ya da silebilirsiniz. Filigran şeklinin adını ayarlamak için [**AutoShape.getName**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getName--) yöntemine atayın:

```javascript
watermarkShape.setName("watermark");
```

### **Filigranı Kaldır**

Filigran şekli kaldırmak için [AutoShape.getName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getName--) yöntemini kullanarak slayt şekilleri içinde bulun. Ardından, filigran şeklini [**ShapeCollection.remove**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) yöntemine geçirin:

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **SSS**

**Filigran nedir ve neden kullanmalıyım?**

Filigran, slaytlara uygulanan bir metin ya da görüntü örtüsüdür; fikri mülkiyeti korumaya, marka bilinirliğini artırmaya ya da sunumların izinsiz kullanılmasını önlemeye yardımcı olur.

**Bir sunumdaki tüm slaytlara filigran ekleyebilir miyim?**

Evet, Aspose.Slides tüm sunum slaytlarına filigran eklemenize izin verir. Tüm slaytları döngüye alabilir ve filigran ayarlarını ayrı ayrı uygulayabilirsiniz.

**Filigranın şeffaflığını nasıl ayarlayabilirim?**

Filigranın şeffaflığını, şeklin [dolgu ayarlarını](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getfillformat/) değiştirerek ayarlayabilirsiniz. Bu, filigranın hafif olmasını ve slayt içeriğinden dikkat dağıtmayacak şekilde olmasını sağlar.

**Filigranlar için hangi görüntü formatları destekleniyor?**

Aspose.Slides PNG, JPEG, GIF, BMP, SVG ve daha fazlası gibi çeşitli görüntü formatlarını destekler.

**Metin filigranının yazı tipini ve stilini özelleştirebilir miyim?**

Evet, sunumunuzun tasarımına ve marka tutarlılığına uyması için istediğiniz yazı tipi, boyut ve stili seçebilirsiniz.

**Filigranın konumunu veya yönünü nasıl değiştirebilirim?**

Filigranın konumunu ve yönünü, şeklin koordinatlarını, boyutunu ve döndürme özelliklerini değiştirerek ayarlayabilirsiniz.
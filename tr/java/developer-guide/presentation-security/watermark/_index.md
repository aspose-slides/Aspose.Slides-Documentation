---
title: "Java'da Sunumlara Filigran Eklemek"
linktitle: "Filigran"
type: docs
weight: 40
url: /tr/java/watermark/
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
- Java
- Aspose.Slides
description: "Java'da PowerPoint ve OpenDocument sunumlarında metin ve görsel filigranları yöneterek taslak, gizli bilgi, telif hakkı ve daha fazlasını belirtebilirsiniz."
---
## **Giriş**

**Bir filigran**, bir sunumda slayt üzerinde ya da tüm sunum slaytlarında kullanılan metin veya resim damgasıdır. Genellikle bir filigran, sunumun taslak olduğunu (örn. “Taslak” filigranı), gizli bilgi içerdiğini (örn. “Gizli” filigranı), hangi şirkete ait olduğunu (örn. “Şirket Adı” filigranı), sunum yazarını tanımlamak vb. göstermek için kullanılır. Filigran, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Filigranlar hem PowerPoint hem de OpenOffice sunum formatlarında kullanılır. Aspose.Slides ile PowerPoint PPT, PPTX ve OpenOffice ODP dosya formatlarına filigran ekleyebilirsiniz.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/java/) içinde PowerPoint veya OpenOffice belgelerinde filigran oluşturmanın ve tasarımını‑davranışını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin filigranı eklemek için [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) arabirimini, resim filigranı eklemek için ise [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) sınıfını ya da bir filigran şekline resmi doldurmayı kullanmanızdır. `PictureFrame`, tüm esnek şekil ayarlarını kullanmanıza olanak tanıyan [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) arabirimini uygular. `ITextFrame` bir şekil olmadığından ve ayarları sınırlı olduğundan, bir [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) nesnesine sarılır.

Filigran iki şekilde uygulanabilir: tek bir slayta veya tüm sunum slaytlarına. Tüm slaytlara filigran uygulamak için Slide Master kullanılır — filigran Slide Master’a eklenir, burada tamamen tasarlanır ve tüm slaytlara uygulanır; bireysel slaytlarda filigranı düzenleme izini etkilemez.

Filigran genellikle diğer kullanıcılar tarafından düzenlenemez olarak kabul edilir. Filigranın (ya da filigranın ebeveyn şeklinin) düzenlenmesini önlemek için Aspose.Slides şekil kilitleme işlevi sunar. Belirli bir şekil normal bir slaytta ya da Slide Master’da kilitlenebilir. Filigran şekli Slide Master’da kilitlenirse, tüm sunum slaytlarında kilitli olur.

Filigran için bir ad belirleyebilirsiniz; böylece gelecekte silmek istediğinizde slaytın şekillerinde adıyla bulabilirsiniz.

Filigranı istediğiniz gibi tasarlayabilirsiniz; ancak genellikle ortalanma, dönüş, ön konum gibi ortak özellikler bulunur. Aşağıdaki örneklerde bunların nasıl kullanılacağını göreceksiniz.

## **Metin Filigranı**

### **Bir Slayta Metin Filigranı Eklemek**

PPT, PPTX veya ODP içinde metin filigranı eklemek için önce slayta bir şekil ekleyin, ardından bu şekle bir metin çerçevesi ekleyin. Metin çerçevesi, [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) arabirimiyle temsil edilir. Bu tip, filigranı esnek bir şekilde konumlandırmak için geniş bir özellik kümesine sahip olan [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) sınıfından türetilmemiştir. Bu nedenle, [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) nesnesi bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) nesnesine sarılır. Şekle filigran metni eklemek için aşağıda gösterildiği gibi [addTextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) yöntemini kullanın.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [TextFrame Sınıfını Nasıl Kullanılır](/slides/tr/java/text-formatting/)
{{% /alert %}}

### **Bir Sunuma Metin Filigranı Eklemek**

Tüm sunuma (yani bütün slaytlara) bir metin filigranı eklemek istiyorsanız, bunu [MasterSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/masterslide/) üzerine ekleyin. Geri kalan mantık, tek bir slayta filigran eklemekle aynıdır — bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) nesnesi oluşturun ve ardından [addTextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) yöntemiyle filigranı ekleyin.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Slide Master Nasıl Kullanılır](/slides/tr/java/slide-master/)
{{% /alert %}}

### **Filigran Şeklinin Şeffaflığını Ayarlamak**

Varsayılan olarak dikdörtgen şekli doldurma ve kenar renkleriyle stilize edilir. Aşağıdaki kod satırları şekli şeffaf yapar.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Metin Filigranı İçin Yazı Tipi Ayarlamak**

Aşağıdaki gibi metin filigranının yazı tipini değiştirebilirsiniz.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Filigran Metin Rengini Ayarlamak**

Filigran metninin rengini ayarlamak için bu kodu kullanın:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Metin Filigranını Ortalamak**

Filigranı bir slaytta ortalamak mümkündür; bunun için aşağıdaki adımları izleyin:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Aşağıdaki görsel son sonucu göstermektedir.

![The text watermark](text_watermark.png)

## **Resim Filigranı**

### **Bir Sunuma Resim Filigranı Eklemek**

Bir sunum slaytına resim filigranı eklemek için aşağıdakileri yapabilirsiniz:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Filigranı Düzenlemeden Kilitlemek**

Filigranın düzenlenmesini önlemek gerekiyorsa, şekil üzerinde [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) yöntemini kullanın. Bu özellik sayesinde şekli seçilemez, yeniden boyutlandırılamaz, konumu değiştirilemez, diğer öğelerle gruplanamaz, metni düzenlenemez hâle getirilebilir ve daha fazlası yapılabilir:

```java
// Filigran şeklinin değiştirilmesini kilitle
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Filigranı Öne Getirmek**

Aspose.Slides içinde şekillerin Z‑sırası, [IShapeCollection.reorder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) yöntemiyle ayarlanabilir. Bunun için sunum slaytları listesinden bu yöntemi çağırıp şekil referansını ve sıra numarasını geçmeniz gerekir. Böylece bir şekli slaytın önüne getirebilir veya arkasına gönderebilirsiniz. Bu özellik, filigranı sunumun önüne yerleştirmeniz gerektiğinde özellikle yararlıdır:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Filigran Döndürmesini Ayarlamak**

Aşağıdaki örnek, filigranı slayt boyunca çapraz konumlandırmak için döndürmenin nasıl ayarlanacağını gösterir:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Filigrana Bir İsim Vermek**

Aspose.Slides, bir şeklin ismini ayarlamanıza olanak tanır. Şekil ismini kullanarak gelecekte ona erişebilir, değiştirebilir veya silebilirsiniz. Filigran şeklinin adını ayarlamak için [IAutoShape.setName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setName-java.lang.String-) yöntemini kullanın:

```java
watermarkShape.setName("watermark");
```

### **Filigranı Kaldırmak**

Filigran şekli kaldırmak için önce [IAutoShape.getName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getName--) yöntemiyle slayt şekilleri içinde bulun, ardından bu şekli [IShapeCollection.remove](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) yöntemine aktarın:

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **SSS**

**Filigran nedir ve neden kullanmalıyım?**

Filigran, slaytlara uygulanan bir metin veya resim üst katmanıdır; fikri mülkiyeti korur, marka tanınırlığını artırır veya sunumların yetkisiz kullanımını engeller.

**Tüm slaytlara bir filigran ekleyebilir miyim?**

Evet, Aspose.Slides programmatically her slayta filigran eklemenize izin verir. Tüm slaytları döngüye alıp filigran ayarlarını ayrı ayrı uygulayabilirsiniz.

**Filigranın şeffaflığını nasıl ayarlayabilirim?**

Şeklin doldurma ayarlarını ([getFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getFillFormat--)) değiştirerek filigranın şeffaflığını ayarlayabilirsiniz. Bu sayede filigran nazik bir şekilde görünür ve slayt içeriğini gölgelemez.

**Filigran için hangi resim formatları destekleniyor?**

Aspose.Slides PNG, JPEG, GIF, BMP, SVG ve daha birçok resim formatını destekler.

**Metin filigranının yazı tipi ve stilini özelleştirebilir miyim?**

Evet, sunum tasarımınıza ve marka tutarlılığınıza uygun herhangi bir yazı tipi, boyut ve stil seçebilirsiniz.

**Filigranın konumunu ya da yönünü nasıl değiştirebilirim?**

Şeklin koordinatlarını, boyutunu ve döndürme özelliklerini programmatically değiştirerek filigranın konumunu ve yönünü ayarlayabilirsiniz.
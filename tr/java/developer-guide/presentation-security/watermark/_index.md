---
title: Sunumlara Java'da Filigran Ekle
linktitle: Filigran
type: docs
weight: 40
url: /tr/java/watermark/
keywords:
- filigran
- metin filigranı
- görüntü filigranı
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
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında Java kullanarak taslak, gizli bilgi, telif hakkı vb. göstermek için metin ve görüntü filigranlarını yönetin."
---
## **Giriş**

**Bir filigran**, bir sunumda slayt üzerinde ya da tüm sunum slaytları boyunca kullanılan metin ya da görüntü damgasıdır. Genellikle, bir filigran sunumun taslak olduğunu (ör. “Taslak” filigranı), gizli bilgi içerdiğini (ör. “Gizli” filigranı), hangi şirkete ait olduğunu (ör. “Şirket Adı” filigranı), sunum yazarını tanımlamak vb. göstermek için kullanılır. Filigran, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Filigranlar hem PowerPoint hem de OpenOffice sunum formatlarında kullanılır. Aspose.Slides ile PowerPoint PPT, PPTX ve OpenOffice ODP dosya formatlarına filigran ekleyebilirsiniz.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/java/) içinde PowerPoint ya da OpenOffice belgelerinde filigran oluşturmanın ve tasarımını, davranışını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin filigranı eklerken [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) arayüzünü, görüntü filigranı eklerken ise [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe/) sınıfını ya da bir filigran şekline resim doldurmayı kullanmanız gerektiğidir. `PictureFrame`, şekil nesnesinin tüm esnek ayarlarını kullanmanıza olanak tanıyan [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) arayüzünü uygular. `ITextFrame` bir şekil olmadığı ve ayarları sınırlı olduğu için bir [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) nesnesine sarılır.

Filigran iki şekilde uygulanabilir: tek bir slayta ya da tüm sunum slaytlarına. Tüm slaytlara filigran eklemek için Slide Master kullanılır — filigran Slide Master’a eklenir, orada tam olarak tasarlanır ve bireysel slaytlarda filigranı düzenleme iznini etkilemeden tüm slaytlara uygulanır.

Filigranın diğer kullanıcılar tarafından düzenlenemeyeceği varsayılır. Filigranı (aslen filigranın üst şekli) düzenlenemez kılmak için Aspose.Slides şekil kilitleme işlevi sunar. Belirli bir şekil normal bir slaytta ya da Slide Master’da kilitlenebilir. Filigran şekli Slide Master’da kilitli olduğunda, tüm sunum slaytlarında kilitli olacaktır.

Filigrana bir ad vererek, gelecekte silmek istediğinizde slaytın şekilleri içinde isme göre bulabilirsiniz.

Filigranı istediğiniz gibi tasarlayabilirsiniz; ancak genellikle ortalanmış hizalama, dönüş, ön konum gibi ortak özellikler bulunur. Aşağıdaki örneklerde bu özelliklerin nasıl kullanılacağını inceleyeceğiz.

## **Metin Filigranı**

### **Bir Slayta Metin Filigranı Ekle**

PPT, PPTX veya ODP’de metin filigranı eklemek için önce slayta bir şekil ekleyip bu şekle bir metin çerçevesi ekleyebilirsiniz. Metin çerçevesi, [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) arayüzüyle temsil edilir. Bu tip, esnek konumlandırma için çok sayıda özelliğe sahip [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) arayüzünden türetilmemiştir. Bu nedenle, [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) nesnesi bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) nesnesine sarılır. Şekle filigran metni eklemek için aşağıdaki gibi [addTextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metodunu kullanın.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [TextFrame Sınıfının Nasıl Kullanılacağını Görün](/slides/tr/java/text-formatting/)
{{% /alert %}}

### **Bir Sunuma Metin Filigranı Ekle**

Tüm sunuma (yani tüm slaytlara aynı anda) bir metin filigranı eklemek istiyorsanız, [MasterSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/masterslide/) üzerine ekleyin. Tek bir slayta filigran eklerken kullanılan mantık aynı kalır — bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) nesnesi oluşturun ve ardından [addTextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metoduyla filigranı ekleyin.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Ayrıca bakınız" %}} 
- [Slide Master Nasıl Kullanılır](/slides/tr/java/slide-master/)
{{% /alert %}}

### **Filigran Şekli Şeffaflığını Ayarlama**

Varsayılan olarak, dikdörtgen şekli dolgu ve çizgi renkleriyle stilize edilmiştir. Aşağıdaki kod satırları şekli şeffaf yapar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Metin Filigranı İçin Yazı Tipi Ayarlama**

Aşağıdaki gibi metin filigranının yazı tipini değiştirebilirsiniz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Filigran Metin Rengini Ayarlama**

Filigran metninin rengini ayarlamak için bu kodu kullanın:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Metin Filigranını Ortala**

Filigranı bir slaytta ortalamak mümkündür; bunun için aşağıdakileri yapabilirsiniz:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

Aşağıdaki resim son sonucu gösterir.

![The text watermark](text_watermark.png)

## **Görüntü Filigranı**

### **Bir Sunuma Görüntü Filigranı Ekle**

Bir sunum slaytına görüntü filigranı eklemek için aşağıdakileri yapabilirsiniz:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Filigranı Düzenlemeden Kilitleme**

Filigranın düzenlenmesini engellemek gerekiyorsa, şekil üzerinde [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) metodunu kullanın. Bu özellik sayesinde şeklin seçilmesi, yeniden boyutlandırılması, konumlandırılması, diğer öğelerle gruplanması, metninin düzenlenmesinin kilitlenmesi vb. korunabilir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Filigran şeklinin değiştirilmesini engelle
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Filigranı Öne Getirme**

Aspose.Slides içinde şekillerin Z-sırası [IShapeCollection.reorder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) metodu ile ayarlanabilir. Bunu yapmak için bu metodu sunum slaytları listesinden çağırıp şekil referansını ve sırasını metoda geçirmeniz gerekir. Böylece bir şekli slaytın önüne getirebilir ya da arkasına gönderebilirsiniz. Bu özellik, bir filigranı sunumun önüne yerleştirmeniz gerektiğinde özellikle yararlıdır:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Filigran Döndürme Ayarı**

Aşağıdaki kod örneği, filigranın slayt boyunca diyagonal konumlanması için dönüşünü nasıl ayarlayabileceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Filigrana İsim Verme**

Aspose.Slides, bir şeklin ismini ayarlamanıza izin verir. Şekil ismini kullanarak gelecekte ona ulaşabilir, değiştirebilir ya da silebilirsiniz. Filigran şeklinin ismini ayarlamak için [IAutoShape.setName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setName-java.lang.String-) metoduna atayın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Filigranı Kaldırma**

Filigran şeklinin kaldırılması için önce [IAutoShape.getName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getName--) metoduyla slayt şekilleri içinde bulun. Ardından filigran şekli, [IShapeCollection.remove](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) metoduna gönderin:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **SSS**

### Filigran nedir ve neden kullanılmalıdır?

Filigran, slaytlara uygulanan bir metin ya da görüntü üst katmanıdır; fikri mülkiyeti korur, marka tanınırlığını artırır ya da sunumların yetkisiz kullanılmasını önler.

### Sunumdaki tüm slaytlara filigran ekleyebilir miyim?

Evet, Aspose.Slides programlı olarak bir sunumdaki her slayta filigran eklemenizi sağlar. Tüm slaytları döngüyle gezerek filigran ayarlarını tek tek uygulayabilirsiniz.

### Filigranın şeffaflığını nasıl ayarlayabilirim?

Şeffaflığı, şeklin dolgu ayarlarını ([getFillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getFillFormat--)) değiştirerek ayarlayabilirsiniz. Bu, filigranın zarif olmasını ve slayt içeriğinden dikkat çekmemesini sağlar.

### Hangi görüntü formatları filigran için desteklenir?

Aspose.Slides PNG, JPEG, GIF, BMP, SVG ve daha fazlası gibi çeşitli görüntü formatlarını destekler.

### Metin filigranının yazı tipi ve stilini özelleştirebilir miyim?

Evet, sunumunuzun tasarımına ve marka tutarlılığına uygun herhangi bir yazı tipi, boyut ve stil seçebilirsiniz.

### Filigranın konumunu ya da yönünü nasıl değiştiririm?

Şeklin koordinatlarını, boyutlarını ve döndürme özelliklerini programlı olarak değiştirerek filigranın konumunu ve yönünü ayarlayabilirsiniz.
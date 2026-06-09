---
title: Android'de Sunumlara Filigran Ekle
linktitle: Filigran
type: docs
weight: 40
url: /tr/androidjava/watermark/
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
- PPT'den filigran kaldır
- PPTX'den filigran kaldır
- ODP'den filigran kaldır
- PPT'den filigran sil
- PPTX'den filigran sil
- ODP'den filigran sil
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Android'de Java kullanarak PowerPoint ve OpenDocument sunumlarında taslak, gizli bilgi vb. göstermek için metin ve resim filigranlarını yönetin."
---
## **Giriş**

**Bir filigran**, bir slaytta ya da tüm sunum slaytlarında kullanılan bir metin veya resim damgasıdır. Genellikle bir filigran, sunumun taslak olduğunu (ör. “Taslak” filigranı), gizli bilgi içerdiğini (ör. “Gizli” filigranı), hangi şirkete ait olduğunu (ör. “Şirket Adı” filigranı), sunumu hazırlayanı tanımlamak gibi amaçlarla kullanılır. Filigran, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Filigranlar, PowerPoint ve OpenOffice sunum formatlarında kullanılabilir. Aspose.Slides ile PowerPoint PPT, PPTX ve OpenOffice ODP dosya formatlarına filigran ekleyebilirsiniz.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/android-java/) içinde PowerPoint ya da OpenOffice belgelerinde filigran oluşturmanın ve tasarımını, davranışını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin filigranı eklemek için [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) arayüzünün, resim filigranı eklemek için ise [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) sınıfının veya bir filigran şekline resim doldurmanın kullanılmasıdır. `PictureFrame`, [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) arayüzünü uygular; bu sayede şekil nesnesinin tüm esnek ayarlarını kullanabilirsiniz. `ITextFrame` bir şekil olmadığından ve ayarları sınırlı olduğundan, bir [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) nesnesine sarılır.

Filigran iki şekilde uygulanabilir: tek bir slayta ya da tüm sunum slaytlarına. Tüm slaytlara filigran uygulamak için Slayt Üst Bilgisi (Slide Master) kullanılır — filigran Slayt Üst Bilgisine eklenir, orada tam olarak tasarlanır ve bireysel slaytlarda filigranı düzenleme iznini etkilemeden tüm slaytlara uygulanır.

Filigran genellikle diğer kullanıcılar tarafından düzenlenemez kabul edilir. Filigranın (ya da aslen filigranın üst şeklinin) düzenlenmesini önlemek için Aspose.Slides şekil kilitleme işlevi sunar. Belirli bir şekil normal bir slaytta ya da Slayt Üst Bilgisinde kilitlenebilir. Filigran şekli Slayt Üst Bilgisinde kilitlenirse, tüm sunum slaytlarında kilitli olur.

Filigrana bir ad verebilirsiniz; böylece ileride silmek istediğinizde, slayttaki şekiller arasında adıyla bulabilirsiniz.

Filigranı istediğiniz gibi tasarlayabilirsiniz; ancak genellikle merkez hizalama, döndürme, ön konum gibi ortak özellikler bulunur. Aşağıdaki örneklerde bunların nasıl kullanılacağını göstereceğiz.

## **Metin Filigranı**

### **Bir Slayta Metin Filigranı Ekle**

PPT, PPTX veya ODP içinde metin filigranı eklemek için önce slayta bir şekil ekleyebilir, ardından bu şekle bir metin çerçevesi ekleyebilirsiniz. Metin çerçevesi, [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) arayüzüyle temsil edilir. Bu tür, [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) arayüzünden türetilmediği için konumlandırma açısından geniş bir özellik setine sahip değildir. Bu nedenle, [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) nesnesi bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) nesnesine sarılır. Şekle filigran metni eklemek için aşağıdaki gibi [addTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) yöntemi kullanılır.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Metin Çerçevesi Sınıfını Nasıl Kullanılır](/slides/tr/androidjava/text-formatting/)
{{% /alert %}}

### **Bir Sunuma Metin Filigranı Ekle**

Tüm sunuma (yani tüm slaytlara aynı anda) bir metin filigranı eklemek istiyorsanız, bunu [MasterSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/masterslide/) üzerine ekleyin. Geri kalan mantık, tek bir slayta filigran ekleme ile aynıdır — bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) nesnesi oluşturun ve ardından [addTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) yöntemiyle filigranı ekleyin.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [Slayt Üst Bilgisini Nasıl Kullanılır](/slides/tr/androidjava/slide-master/)
{{% /alert %}}

### **Filigran Şeklinin Şeffaflığını Ayarla**

Varsayılan olarak, dikdörtgen şekil dolgu ve çizgi renkleriyle biçimlendirilir. Aşağıdaki kod satırları şekli şeffaf hâle getirir.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Metin Filigranı İçin Yazı Tipini Ayarla**

Aşağıdaki gibi metin filigranının yazı tipini değiştirebilirsiniz.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Filigran Metin Rengini Ayarla**

Filigran metninin rengini ayarlamak için şu kodu kullanın:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Metin Filigranını Ortala**

Filigranı slayt üzerinde ortalamak mümkündür; bunun için aşağıdakileri yapabilirsiniz:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Aşağıdaki görsel son sonucu göstermektedir.

![Metin filigranı](text_watermark.png)

## **Resim Filigranı**

### **Bir Sunuma Resim Filigranı Ekle**

Sunum slaytına bir resim filigranı eklemek için aşağıdaki adımları izleyin:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Filigranı Düzenlemeden Kilitle**

Filigranın düzenlenmesini engellemek gerekiyorsa, şekil üzerinde [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) yöntemini kullanın. Bu özellik sayesinde şeklin seçilmesi, yeniden boyutlandırılması, konumlandırılması, diğer öğelerle gruplanması, metninin düzenlenmesinin kilitlenmesi ve daha fazlası korunabilir:

```java
// Filigran şeklinin değiştirilmesini kilitle
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Filigranı Ön Tarafa Getir**

Aspose.Slides içinde şekillerin Z-sırası, [IShapeCollection.reorder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) yöntemiyle ayarlanabilir. Bunu yapmak için sunum slaytları listesinden bu yöntemi çağırıp şekil referansını ve sıra numarasını metoda geçirin. Bu sayede bir şekli slaydın önüne getirebilir ya da arkasına gönderebilirsiniz. Özellikle bir filigranı sunumun önüne yerleştirmeniz gerektiğinde bu özellik yararlıdır:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Filigran Döndürmesini Ayarla**

Filigranı slayt boyunca çapraz konumlandırmak için döndürmeyi ayarlayan bir kod örneği aşağıdadır:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Filigrana Bir İsim Ata**

Aspose.Slides, bir şeklin adını ayarlamanıza izin verir. Şekil adını kullanarak gelecekte ona erişebilir, değiştirebilir veya silebilirsiniz. Filigran şeklinin adını ayarlamak için [IAutoShape.setName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) yöntemini kullanın:

```java
watermarkShape.setName("watermark");
```

### **Filigranı Kaldır**

Filigran şeklini kaldırmak için önce [IAutoShape.getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getName--) yöntemiyle slayt şekilleri içinde bulun. Ardından bu şekli [IShapeCollection.remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) yöntemine geçirin:

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

Filigran, slaytlara uygulanan bir metin veya resim üst katmanıdır; fikri mülkiyeti korumaya, marka tanınırlığını artırmaya veya sunumların izinsiz kullanılmasını engellemeye yardımcı olur.

**Bir sunumdaki tüm slaytlara filigran ekleyebilir miyim?**

Evet, Aspose.Slides programatik olarak her slayta filigran eklemenizi sağlar. Tüm slaytlar üzerinde döngü kurarak filigran ayarlarını tek tek uygulayabilirsiniz.

**Filigranın şeffaflığını nasıl ayarlayabilirim?**

Şeklin dolgu ayarlarını ([getFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getFillFormat--)) değiştirerek filigranın şeffaflığını ayarlayabilirsiniz. Bu sayede filigran göze çarpmadan slayt içeriğini boğmaz.

**Filigranlar için hangi görüntü formatları destekleniyor?**

Aspose.Slides PNG, JPEG, GIF, BMP, SVG ve daha fazlası dahil olmak üzere çeşitli görüntü formatlarını destekler.

**Metin filigranının yazı tipi ve stilini özelleştirebilir miyim?**

Evet, sunum tasarımınıza ve marka tutarlılığına uyması için istediğiniz yazı tipi, boyut ve stili seçebilirsiniz.

**Filigranın konumunu veya yönünü nasıl değiştiririm?**

Şeklin koordinatlarını, boyutunu ve döndürme özelliklerini programatik olarak değiştirerek filigranın konumunu ve yönünü ayarlayabilirsiniz.
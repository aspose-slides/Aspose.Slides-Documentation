---
title: Android'de Sunumlara Filigran Ekleyin
linktitle: Filigran
type: docs
weight: 40
url: /tr/androidjava/watermark/
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
- PPTX'ten filigranı kaldır
- ODP'den filigranı kaldır
- PPT'den filigranı sil
- PPTX'ten filigranı sil
- ODP'den filigranı sil
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Android üzerinde Java ile PowerPoint ve OpenDocument sunumlarında taslak, gizli bilgi vb. göstermek için metin ve görüntü filigranlarını yönetin."
---
## **Giriş**

Bir sunumdaki filigran, bir slaytta veya tüm sunum slaytlarında kullanılan bir metin veya görüntü damgasıdır. Genellikle, filigran sunumun bir taslak olduğunu (ör. “Draft” filigranı), gizli bilgiler içerdiğini (ör. “Confidential” filigranı), hangi şirkete ait olduğunu (ör. “Company Name” filigranı), sunum yazarını tanımladığını vb. göstermek için kullanılır. Filigran, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Filigranlar hem PowerPoint hem de OpenOffice sunum formatlarında kullanılır. Aspose.Slides ile PowerPoint PPT, PPTX ve OpenOffice ODP dosya formatlarına filigran ekleyebilirsiniz.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/android-java/) içinde, PowerPoint veya OpenOffice belgelerinde filigran oluşturmanın ve tasarımını ve davranışını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin filigranları eklemek için [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) arayüzünü, görüntü filigranları eklemek için ise [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe/) sınıfını veya bir filigran şekline görüntü doldurmayı kullanmanız gerektiğidir. `PictureFrame`, şekil nesnesinin tüm esnek ayarlarını kullanmanıza izin veren [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) arayüzünü uygular. `ITextFrame` bir şekil olmadığı ve ayarları sınırlı olduğundan, bir [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) nesnesine sarılır.

Bir filigranı uygulamanın iki yolu vardır: tek bir slayta ya da tüm sunum slaytlarına. Slide Master, filigranı tüm sunum slaytlarına uygulamak için kullanılır — filigran Slide Master'a eklenir, orada tamamen tasarlanır ve tüm slaytlara uygulanır; bu, bireysel slaytlardaki filigranı düzenleme iznini etkilemez.

Filigran genellikle diğer kullanıcılar tarafından düzenlenemez olarak kabul edilir. Filigranın (ya da daha doğrusu filigranın üst şeklinin) düzenlenmesini önlemek için Aspose.Slides şekil kilitleme işlevi sağlar. Belirli bir şekil normal bir slaytta ya da Slide Master'da kilitlenebilir. Filigran şekli Slide Master'da kilitlendiğinde, tüm sunum slaytlarında kilitlenir.

Filigrana bir ad verebilirsiniz; böylece gelecekte silmek istediğinizde, slayttaki şekiller arasında ada göre bulabilirsiniz.

Filigranı istediğiniz şekilde tasarlayabilirsiniz; ancak genellikle merkez hizalama, döndürme, ön konum gibi ortak özellikler bulunur. Aşağıdaki örneklerde bunların nasıl kullanılacağını inceleyeceğiz.

## **Metin Filigranı**

### **Slayta Metin Filigranı Ekleme**

Bir PPT, PPTX veya ODP dosyasında metin filigranı eklemek için öncelikle slayta bir şekil ekleyip, bu şekle bir metin çerçevesi ekleyebilirsiniz. Metin çerçevesi [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) arayüzüyle temsil edilir. Bu tür, filigranı esnek bir şekilde konumlandırmak için geniş bir özellik setine sahip [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) arayüzünden türetilmez. Bu nedenle, [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) nesnesi bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) nesnesine sarılır. Şekle filigran metni eklemek için aşağıdaki gibi [addTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metodunu kullanın.

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
- [TextFrame Sınıfının Nasıl Kullanılacağını](/slides/tr/androidjava/text-formatting/)
{{% /alert %}}

### **Sunuma Metin Filigranı Ekleme**

Eğer tüm sunuma (yani tüm slaytlara aynı anda) metin filigranı eklemek istiyorsanız, bunu [MasterSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/masterslide/) üzerine ekleyin. Geri kalan mantık, tek bir slayta filigran eklerkenkiyle aynıdır — bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) nesnesi oluşturun ve ardından [addTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metodunu kullanarak filigranı ona ekleyin.

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
- [Slide Master'ın Nasıl Kullanılacağını](/slides/tr/androidjava/slide-master/)
{{% /alert %}}

### **Filigran Şeklinin Şeffaflığını Ayarlama**

Varsayılan olarak, dikdörtgen şekil dolgu ve çizgi renkleriyle stilizedir. Aşağıdaki kod satırları şekli şeffaf yapar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Metin Filigranı için Yazı Tipi Ayarlama**

Metin filigranı için yazı tipini aşağıdaki gibi değiştirebilirsiniz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Filigran Metin Rengini Ayarlama**

Filigran metninin rengini ayarlamak için şu kodu kullanın:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Metin Filigranını Ortala**

Filigranı slaytta ortalamak mümkündür; bunun için aşağıdakileri yapabilirsiniz:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

![Metin filigranı](text_watermark.png)

## **Görüntü Filigranı**

### **Sunuma Görüntü Filigranı Ekleme**

Bir sunum slaytına görüntü filigranı eklemek için aşağıdakileri yapabilirsiniz:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Filigranı Düzenlemeden Kilitleme**

Filigranın düzenlenmesini önlemek gerekiyorsa, şekil üzerinde [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) metodunu kullanın. Bu özellik sayesinde şekli seçilmekten, yeniden boyutlandırılmaktan, konumu değiştirilememekten, diğer öğelerle gruplamaktan, metninin düzenlenmesinden ve daha fazlasından koruyabilirsiniz:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Filigran şeklinin değiştirilmesini kilitle
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Filigranı Öne Getirme**

Aspose.Slides'da şekillerin Z-sırası, [IShapeCollection.reorder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) metodu ile ayarlanabilir. Bunu yapmak için, sunum slaytları listesinden bu metodu çağırıp şekil referansını ve sırasını metoda geçmelisiniz. Böylece bir şekli slaytın önüne getirmek ya da arkasına göndermek mümkün olur. Bu özellik, filigranı sunumun önüne yerleştirmeniz gerektiğinde özellikle faydalıdır:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Filigran Döndürmesini Ayarlama**

Filigranı slayt boyunca diyagonal konumlandırmak için döndürmeyi ayarlayan bir kod örneği aşağıdadır:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Filigrana Bir İsim Verme**

Aspose.Slides bir şeklin adını belirlemenize olanak tanır. Şekil adını kullanarak gelecekte onu değiştirebilir veya silebilirsiniz. Filigran şeklinin adını ayarlamak için, [IAutoShape.setName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) metoduna atayın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Filigranı Kaldırma**

Filigran şekli kaldırmak için, slayt şekillerinde bulmak üzere [IAutoShape.getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getName--) metodunu kullanın. Ardından, filigran şekli [IShapeCollection.remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) metoduna geçirin:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **SSS**

### Filigran nedir ve neden kullanmalıyım?

Filigran, slaytlara uygulanan bir metin veya görüntü kaplamasıdır; fikri mülkiyeti korumaya, marka tanınırlığını artırmaya veya sunumların izinsiz kullanımını önlemeye yardımcı olur.

### Sunumdaki tüm slaytlara filigran ekleyebilir miyim?

Evet, Aspose.Slides, bir sunumdaki her slayta programlı olarak filigran eklemenizi sağlar. Tüm slaytları döngüyle gezerek filigran ayarlarını ayrı ayrı uygulayabilirsiniz.

### Filigranın şeffaflığını nasıl ayarlayabilirim?

Filigranın şeffaflığını, şeklin dolgu ayarlarını ([getFillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getFillFormat--)) değiştirerek ayarlayabilirsiniz. Bu, filigranın hafif olmasını ve slayt içeriğini dağıtmamasını sağlar.

### Hangi görüntü formatları filigran için destekleniyor?

Aspose.Slides, PNG, JPEG, GIF, BMP, SVG gibi çeşitli görüntü formatlarını destekler.

### Metin filigranı için yazı tipi ve stil özelleştirilebilir mi?

Evet, sunum tasarımınıza ve marka tutarlılığına uyması için istediğiniz yazı tipini, boyutunu ve stilini seçebilirsiniz.

### Filigranın konumunu veya yönünü nasıl değiştirebilirim?

Filigranın konumunu ve yönünü, şeklin koordinatlarını, boyutunu ve döndürme özelliklerini programlı olarak değiştirerek ayarlayabilirsiniz.
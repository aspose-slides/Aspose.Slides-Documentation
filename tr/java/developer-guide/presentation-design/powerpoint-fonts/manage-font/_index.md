---
title: Java Kullanarak Sunumlarda Yazı Tiplerini Yönetme
linktitle: Yazı Tiplerini Yönet
type: docs
weight: 10
url: /tr/java/manage-fonts/
keywords:
- yazı tiplerini yönet
- yazı tipi özellikleri
- paragraf
- metin biçimlendirme
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java ile Aspose.Slides kullanarak yazı tiplerini kontrol edin: gömün, değiştirin ve özel yazı tiplerini yükleyin, PPT, PPTX ve ODP sunumlarını net, marka güvenli ve tutarlı tutun."
---
## **Genel Bakış**

Aspose.Slides, sunum metnindeki yazı tipi özelliklerini doğrudan kodunuzdan yönetmenizi sağlar. Metne, şekiller, metin çerçeveleri, paragraflar ve bölümler aracılığıyla erişebilir ve ardından seçili metne biçimlendirme uygulayabilirsiniz.

Bu makale, bir sunumdaki mevcut metin için yazı tipi ailesi, kalın ve italik stiller, paragraf hizalaması ve yazı tipi rengi gibi yazı tipiyle ilgili özelliklerin nasıl yapılandırılacağını açıklar. Ayrıca bir metin kutusu oluşturmayı, içine metin eklemeyi ve sonucu PPTX dosyası olarak kaydetmeden önce yazı tipi ailesi, kalın, italik, altı çizili, yazı tipi boyutu ve rengi gibi özellikleri ayarlamayı gösterir.

## **Yazı Tipiyle İlgili Özellikleri Yönetme**
{{% alert color="info" %}} 

Sunumlar genellikle hem metin hem de resim içerir. Metin, belirli bölümleri ve kelimeleri vurgulamak ya da kurumsal stillere uyum sağlamak amacıyla çeşitli şekillerde biçimlendirilebilir. Metin biçimlendirme, kullanıcıların sunum içeriğinin görünümünü çeşitlendirmelerine yardımcı olur. Bu makale, Aspose.Slides for Java kullanarak slaytlardaki paragraf metinlerinin yazı tipi özelliklerini nasıl yapılandıracağınızı gösterir.

{{% /alert %}} 

Aspose.Slides for Java kullanarak bir paragrafın yazı tipi özelliklerini yönetmek için:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Slaytın dizinini kullanarak slaytın referansını alın.
1. Slayttaki [Placeholder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholder/) şekillerine erişin ve bunları [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/) tipine dönüştürün.
1. [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/) tarafından sağlanan [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) üzerinden [Paragraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraph/) alın.
1. Paragrafı iki yana yaslayın.
1. Bir [Paragraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraph/) metninin [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) öğesine erişin.
1. [FontData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontdata/) kullanarak yazı tipini tanımlayın ve metin [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) öğesinin **Font** özelliğini buna göre ayarlayın.
   1. Yazı tipini kalın olarak ayarlayın.
   1. Yazı tipini italik olarak ayarlayın.
1. [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) nesnesi tarafından sağlanan [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) ile yazı tipi rengini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımların uygulanması aşağıda verilmiştir. Bu örnek, süssüz bir sunumu alır ve bir slayttaki yazı tiplerini biçimlendirir. Aşağıdaki ekran görüntüleri giriş dosyasını ve kod parçacıklarının nasıl değiştiğini gösterir. Kod, yazı tipi, renk ve yazı tipi stilini değiştirir.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Şekil: Giriş dosyasındaki metin**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Şekil: Güncellenmiş biçimlendirme ile aynı metin**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Bir PPTX dosyasını temsil eden Presentation nesnesini oluştur
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Slayt konumunu kullanarak bir slayta erişme
	ISlide slide = pres.getSlides().get_Item(0);

	// Slayttaki birinci ve ikinci yer tutucusuna erişme ve AutoShape olarak tip dönüşümü
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// İlk paragrafı erişme
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Paragrafı iki yana yasla
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// İlk bölüme (portion) erişme
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Yeni yazı tiplerini tanımla
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Yeni yazı tiplerini bölüme ata
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Yazı tipini kalın yap
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Yazı tipini italik yap
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Yazı tipi rengini ayarla
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// PPTX dosyasını diske kaydet
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Metin Yazı Tipi Özelliklerini Ayarlama**
{{% alert color="info" %}} 

**Yazı Tipiyle İlgili Özellikleri Yönetme** bölümünde belirtildiği gibi, bir [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) paragrafta benzer biçimlendirme stiline sahip metni tutmak için kullanılır. Bu makale, Aspose.Slides for Java kullanarak bir metin kutusu oluşturmayı, içine metin eklemeyi ve ardından yazı tipi ailesi kategorisinin belirli bir yazı tipini ve çeşitli diğer özelliklerini tanımlamayı gösterir.

{{% /alert %}} 

Bir metin kutusu oluşturmak ve içindeki metnin yazı tipi özelliklerini ayarlamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Slaytın dizinini kullanarak slayt referansını alın.
1. Slayta **Rectangle** tipinde bir [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/) ekleyin.
1. [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/) ile ilişkili doldurma stilini kaldırın.
1. [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/) nesnesinin [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) öğesine erişin.
1. [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) öğesine bazı metinler ekleyin.
1. [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) ile ilişkili [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) nesnesine erişin.
1. [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) için kullanılacak yazı tipini tanımlayın.
1. [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) nesnesi tarafından sağlanan ilgili özellikleri kullanarak kalın, italik, altı çizili, renk ve yükseklik gibi diğer yazı tipi özelliklerini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak yazın.

Yukarıdaki adımların uygulanması aşağıda verilmiştir.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Şekil: Aspose.Slides for Java ile ayarlanmış bazı yazı tipi özelliklerine sahip metin**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Bir PPTX dosyasını temsil eden Presentation nesnesini oluştur
Presentation pres = new Presentation();
try {
	// İlk slaytı al
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Dikdörtgen tipinde bir AutoShape ekle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape ile ilişkili tüm doldurma stilini kaldır
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShape ile ilişkili TextFrame'e eriş
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrame ile ilişkili Portion'a eriş
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portion için Yazı tipini ayarla
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Yazı tipinin Kalın özelliğini ayarla
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Yazı tipinin İtalik özelliğini ayarla
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Yazı tipinin Altı Çizili özelliğini ayarla
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Yazı tipinin Boyutunu ayarla
	port.getPortionFormat().setFontHeight(25);
	
	// Yazı tipinin rengini ayarla
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Sunumu diske kaydet
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
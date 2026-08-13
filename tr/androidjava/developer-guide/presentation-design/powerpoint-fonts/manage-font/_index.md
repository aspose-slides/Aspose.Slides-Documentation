---
title: Android'de Sunumlarda Yazı Tiplerini Yönetme
linktitle: Yazı Tiplerini Yönet
type: docs
weight: 10
url: /tr/androidjava/manage-fonts/
keywords:
- yazı tiplerini yönet
- yazı tipi özellikleri
- paragraf
- metin biçimlendirme
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java'da yazı tiplerini kontrol edin: özel yazı tiplerini gömün, değiştirin ve yükleyin; PPT, PPTX ve ODP sunumlarının net, marka güvenli ve tutarlı olmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum metnindeki yazı tipi özelliklerini doğrudan kodunuzdan yönetmenizi sağlar. Metni slaytlarda şekiller, metin çerçeveleri, paragraflar ve bölümler aracılığıyla erişebilir ve ardından seçilen metne biçimlendirme uygulayabilirsiniz.

Bu makale, bir sunumdaki mevcut metin için yazı tipi ailesi, kalın ve italik stiller, paragraf hizalaması ve yazı tipi rengi gibi yazı tipiyle ilgili özelliklerin nasıl yapılandırılacağını açıklar. Ayrıca bir metin kutusu oluşturmayı, içine metin eklemeyi ve sonucu PPTX dosyası olarak kaydetmeden önce yazı tipi ailesi, kalın, italik, altı çizili, yazı tipi boyutu ve renk gibi yazı tipi özelliklerini ayarlamayı gösterir.

## **Yazı Tipi İle İlgili Özellikleri Yönetme**
{{% alert color="info" %}} 

Sunumlar genellikle hem metin hem de görseller içerir. Metin, belirli bölümleri ve kelimeleri vurgulamak ya da kurumsal stillere uymak amacıyla çeşitli şekillerde biçimlendirilebilir. Metin biçimlendirme, kullanıcıların sunum içeriğinin görünüm ve hissini çeşitlendirmesine yardımcı olur. Bu makale, slaytlardaki metin paragraflarının yazı tipi özelliklerini yapılandırmak için Aspose.Slides for Android via Java kullanımını gösterir.

{{% /alert %}} 

Aspose.Slides for Android via Java kullanarak bir paragrafın yazı tipi özelliklerini yönetmek için:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeksini kullanarak alın.
3. Slayttaki [Yer tutucu](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholder/) şekillerine erişin ve bunları [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/) tipine dönüştürün.
4. [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/) tarafından sağlanan [Metin Çerçevesi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) üzerinden [Paragraf](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraph/) alın.
5. Paragrafı iki yana hizalayın.
6. Bir [Paragraf](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraph/)'ın metin [Bölümü](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) erişin.
7. [FontData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontdata/) kullanarak yazı tipini tanımlayın ve metin [Bölümü](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) için **Yazı Tipi**'ni buna göre ayarlayın.
   1. Yazı tipini kalın olarak ayarlayın.
   2. Yazı tipini italik olarak ayarlayın.
8. [Bölüm](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) nesnesi tarafından sağlanan [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) kullanarak yazı tipi rengini ayarlayın.
9. Değiştirilmiş sunumu bir PPTX dosyasına kaydedin.

Yukarıdaki adımların uygulanması aşağıda verilmiştir. Süslenmemiş bir sunumu alır ve bir slayttaki yazı tiplerini biçimlendirir. Aşağıdaki ekran görüntüleri giriş dosyasını ve kod parçacıklarının nasıl değiştirdiğini gösterir. Kod, yazı tipini, rengi ve yazı tipi stilini değiştirir.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Şekil: Giriş dosyasındaki metin**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Şekil: Güncellenmiş biçimlendirme ile aynı metin**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX dosyasını temsil eden bir Presentation nesnesi oluşturma
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Slayt konumunu kullanarak slayta erişme
	ISlide slide = pres.getSlides().get_Item(0);

	// Slayttaki birinci ve ikinci yer tutucuya erişme ve AutoShape olarak tip dönüştürme
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// İlk Paragrafa erişme
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Paragrafı iki yana hizalama
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// İlk bölüme (portion) erişme
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Yeni yazı tiplerini tanımlama
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Yeni yazı tiplerini bölüme atama
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Yazı tipini Kalın ayarlama
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Yazı tipini İtalik ayarlama
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Yazı tipi rengini ayarlama
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// PPTX'i diske kaydetme
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Metin Yazı Tipi Özelliklerini Ayarlama**
{{% alert color="info" %}} 

**Yazı Tipi İle İlgili Özellikleri Yönetme** bölümünde belirtildiği gibi, bir paragrafta benzer biçimlendirme stiline sahip metni tutmak için bir [Bölüm](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) kullanılır. Bu makale, Aspose.Slides for Android via Java kullanarak bazı metin içeren bir metin kutusu oluşturmayı ve ardından belirli bir yazı tipi ve yazı tipi ailesi kategorisinin çeşitli diğer özelliklerini tanımlamayı gösterir.

{{% /alert %}} 

Bir metin kutusu oluşturmak ve içindeki metnin yazı tipi özelliklerini ayarlamak için:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeksini kullanarak elde edin.
3. Slayta **Rectangle** tipinde bir [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/) ekleyin.
4. [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/) ile ilişkili doldurma stilini kaldırın.
5. [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/)'ın [Metin Çerçevesi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) erişin.
6. [Metin Çerçevesi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/)'ne bazı metin ekleyin.
7. [Metin Çerçevesi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) ile ilişkili [Bölüm](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) nesnesine erişin.
8. [Bölüm](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) için kullanılacak yazı tipini tanımlayın.
9. [Bölüm](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) nesnesi tarafından sağlanan ilgili özellikleri kullanarak kalın, italik, altı çizili, renk ve yükseklik gibi diğer yazı tipi özelliklerini ayarlayın.
10. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Yukarıdaki adımların uygulanması aşağıda verilmiştir.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Şekil: Aspose.Slides for Android via Java tarafından ayarlanan bazı yazı tipi özelliklerine sahip metin**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX dosyasını temsil eden bir Presentation nesnesi oluşturma
Presentation pres = new Presentation();
try {
	// İlk slaytı al
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle tipinde bir AutoShape ekle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape ile ilişkili doldurma stilini kaldır
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShape ile ilişkili TextFrame'e eriş
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrame ile ilişkili Portion'a eriş
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portion için Yazı Tipini ayarla
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Yazı Tipinin Kalın özelliğini ayarla
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Yazı Tipinin İtalik özelliğini ayarla
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Yazı Tipinin Altı Çizili özelliğini ayarla
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Yazı Tipinin Yüksekliğini ayarla
	port.getPortionFormat().setFontHeight(25);
	
	// Yazı Tipinin rengini ayarla
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Sunumu diske kaydet
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
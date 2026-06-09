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
description: "Java'da Aspose.Slides for Android ile yazı tiplerini kontrol edin: gömün, değiştirin ve özel yazı tiplerini yükleyin; PPT, PPTX ve ODP sunumlarının net, marka güvenli ve tutarlı kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, kodunuzdan doğrudan sunum metnindeki yazı tipi özelliklerini yönetmenizi sağlar. Metne şekiller, metin çerçeveleri, paragraf ve kısımlar (portion) aracılığıyla erişebilir ve seçili metne biçimlendirme uygulayabilirsiniz.

Bu makale, bir sunumdaki mevcut metin için yazı tipi ailesi, kalın ve italik stiller, paragraf hizalaması ve yazı tipi rengi gibi yazı tipiyle ilgili özellikleri nasıl yapılandıracağınızı açıklar. Ayrıca bir metin kutusu oluşturma, içine metin ekleme ve sonucu PPTX dosyası olarak kaydetmeden önce yazı tipi ailesi, kalın, italik, alt çizgi, yazı tipi boyutu ve renk gibi özellikleri ayarlama sürecini gösterir.

## **Yazı Tipi İle İlgili Özellikleri Yönetme**
{{% alert color="primary" %}} 

Sunumlar genellikle hem metin hem de görsel içerir. Metin, belirli bölümleri ve kelimeleri vurgulamak veya kurumsal stillere uymak amacıyla çeşitli şekillerde biçimlendirilebilir. Metin biçimlendirme, kullanıcıların sunum içeriğinin görünümünü çeşitlendirmesine yardımcı olur. Bu makale, Aspose.Slides for Android via Java kullanarak slaytların paragraf metinlerinin yazı tipi özelliklerini nasıl yapılandıracağınızı gösterir.

{{% /alert %}} 

Aspose.Slides for Android via Java kullanarak bir paragrafın yazı tipi özelliklerini yönetmek için:

1. [Sunum](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slaydın referansını elde edin.
1. Slayttaki [Yer Tutucu](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/placeholder/) şekillerine erişin ve bunları [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/) tipine dönüştürün.
1. [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/) tarafından sunulan [Metin Çerçevesi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) içinden [Paragraf](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraph/) alın.
1. Paragrafı iki yana yaslayın.
1. Bir [Paragraf](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/paragraph/) içindeki metin [Kısmını](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) (Portion) erişin.
1. [FontData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontdata/) kullanarak yazı tipini tanımlayın ve metin [Kısmının](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) **Yazı Tipini** buna göre ayarlayın.
   1. Yazı tipini kalın yapın.
   1. Yazı tipini italik yapın.
1. [Kısmı](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) nesnesi tarafından sunulan [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fillformat/) ile yazı tipi rengini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına kaydedin.

Yukarıdaki adımların uygulanması aşağıda verilmiştir. Bu kod, sade bir sunumu alır ve slaytlardan birindeki yazı tiplerini biçimlendirir. Aşağıdaki ekran görüntüleri giriş dosyasını ve kod snippet'lerinin onu nasıl değiştirdiğini gösterir. Kod, yazı tipini, rengini ve stilini değiştirir.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Şekil: Giriş dosyasındaki metin**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Şekil: Güncellenmiş biçimlendirme ile aynı metin**|

```java
	// PPTX dosyasını temsil eden bir Presentation nesnesi oluşturma
	Presentation pres = new Presentation("FontProperties.pptx");
	try {
		// Slayt konumunu kullanarak bir slayta erişme
		ISlide slide = pres.getSlides().get_Item(0);

		// Slaydın birinci ve ikinci yer tutucusuna erişme ve AutoShape olarak tip dönüştürme
		ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
		ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

		// İlk paragrafı erişme
		IParagraph para1 = tf1.getParagraphs().get_Item(0);
		IParagraph para2 = tf2.getParagraphs().get_Item(0);

		// Paragrafı iki yana yaslama
		para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

		// İlk kısmı (portion) erişme
		IPortion port1 = para1.getPortions().get_Item(0);
		IPortion port2 = para2.getPortions().get_Item(0);

		// Yeni yazı tiplerini tanımlama
		FontData fd1 = new FontData("Elephant");
		FontData fd2 = new FontData("Castellar");

		// Yeni yazı tiplerini kısma atama
		port1.getPortionFormat().setLatinFont(fd1);
		port2.getPortionFormat().setLatinFont(fd2);

		// Yazı tipini kalın yapma
		port1.getPortionFormat().setFontBold(NullableBool.True);
		port2.getPortionFormat().setFontBold(NullableBool.True);

		// Yazı tipini italik yapma
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
{{% alert color="primary" %}} 

**Yazı Tipi İle İlgili Özellikleri Yönetme** bölümünde belirtildiği gibi, bir [Kısım](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) bir paragrafta benzer biçimlendirme stiline sahip metni tutmak için kullanılır. Bu makale, Aspose.Slides for Android via Java kullanarak bir metin kutusu oluşturmayı, içine metin eklemeyi ve ardından belirli bir yazı tipini ve yazı tipi ailesi kategorisinin çeşitli diğer özelliklerini tanımlamayı gösterir.

{{% /alert %}} 

Bir metin kutusu oluşturmak ve içindeki metnin yazı tipi özelliklerini ayarlamak için:

1. [Sunum](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slaydın referansını elde edin.
1. Slayda **Rectangle** türünde bir [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/) ekleyin.
1. [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/) ile ilişkili dolgu stilini kaldırın.
1. [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/) nin [Metin Çerçevesi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/)ne erişin.
1. [Metin Çerçevesi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) ne bir miktar metin ekleyin.
1. [Metin Çerçevesi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) ile ilişkili [Kısım](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) nesnesine erişin.
1. [Kısım](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) için kullanılacak yazı tipini tanımlayın.
1. [Kısım](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/portion/) nesnesi tarafından sunulan ilgili özellikleri kullanarak kalın, italik, alt çizgi, renk ve yükseklik gibi diğer yazı tipi özelliklerini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Yukarıdaki adımların uygulanması aşağıda verilmiştir.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Şekil: Aspose.Slides for Android via Java ile ayarlanmış bazı yazı tipi özelliklerine sahip metin**|

```java
// PPTX dosyasını temsil eden bir Presentation nesnesi oluşturma
Presentation pres = new Presentation();
try {
	// İlk slaytı al
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle türünde bir AutoShape ekle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// AutoShape ile ilişkili dolgu stilini kaldır
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// AutoShape ile ilişkili TextFrame'e eriş
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// TextFrame ile ilişkili Portion'a eriş
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Portion için Yazı Tipini ayarla
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Yazı tipinin Kalın özelliğini ayarla
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Yazı tipinin İtalik özelliğini ayarla
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Yazı tipinin Alt Çizgi özelliğini ayarla
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Yazı tipinin Yüksekliğini ayarla
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
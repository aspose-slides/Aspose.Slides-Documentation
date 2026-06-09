---
title: Java Kullanarak Sunumlarda Yazı Tipi Yönetimi
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
description: "Aspose.Slides ile Java'da yazı tiplerini kontrol edin: gömün, değiştirin ve özel yazı tiplerini yükleyin, böylece PPT, PPTX ve ODP sunumları net, marka güvenli ve tutarlı olur."
---
## **Genel Bakış**

Aspose.Slides, sunum metnindeki yazı tipi özelliklerini doğrudan kodunuzdan yönetmenizi sağlar. Metni şekiller, metin çerçeveleri, paragraflar ve bölümler aracılığıyla slaytlarda erişebilir ve ardından seçilen metne biçimlendirme uygulayabilirsiniz.

Bu makale, bir sunumdaki mevcut metin için yazı tipi ailesi, kalın ve italik stiller, paragraf hizalaması ve yazı tipi rengi gibi yazı tipiyle ilgili özellikleri nasıl yapılandıracağınızı açıklar. Ayrıca bir metin kutusu oluşturmayı, içine metin eklemeyi ve sonuç dosyasını PPTX olarak kaydetmeden önce yazı tipi ailesi, kalın, italik, altı çizili, yazı tipi boyutu ve rengi gibi özellikleri ayarlamayı gösterir.

## **Yazı Tipi İlgili Özellikleri Yönet**

{{% alert color="primary" %}} 

Sunumlar genellikle hem metin hem de görüntü içerir. Metin, belirli bölümleri ve kelimeleri vurgulamak ya da kurumsal stillere uymak için çeşitli şekillerde biçimlendirilebilir. Metin biçimlendirme, kullanıcıların sunum içeriğinin görünümünü ve hissini çeşitlendirmesine yardımcı olur. Bu makale, Aspose.Slides for Java kullanarak slaytlardaki paragraf metinlerinin yazı tipi özelliklerini nasıl yapılandıracağınızı gösterir.

{{% /alert %}} 

Bir paragrafın yazı tipi özelliklerini Aspose.Slides for Java ile yönetmek için:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slaytın referansını alın.
1. Slayttaki [Yer Tutucu](https://reference.aspose.com/slides/tr/java/com.aspose.slides/placeholder/) şekillerine erişin ve bunları [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/) tipine dönüştürün.
1. [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/) tarafından sağlanan [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) üzerinden [Paragraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraph/) alın.
1. Paragrafı iki yana yaslayın.
1. Bir [Paragraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/paragraph/)'ın metin [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) öğesine erişin.
1. Yazı tipini [FontData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontdata/) kullanarak tanımlayın ve metin [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/)'un **Font** özelliğini buna göre ayarlayın.
   1. Yazı tipini kalın yapın.
   1. Yazı tipini italik yapın.
1. [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) nesnesi tarafından sağlanan [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fillformat/) ile yazı tipi rengini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına kaydedin.

Yukarıdaki adımların uygulanması aşağıda verilmiştir. Çıplak bir sunumu alır ve bir slayd üzerindeki yazı tiplerini biçimlendirir. Aşağıdaki ekran görüntüleri giriş dosyasını ve kod parçacıklarının nasıl değiştiğini gösterir. Kod, yazı tipini, rengini ve yazı tipi stilini değiştirir.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Şekil: Giriş dosyasındaki metin**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Şekil: Güncellenmiş biçimlendirme ile aynı metin**|

```java
// PPTX dosyasını temsil eden bir Presentation nesnesi oluşturun
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Slayt konumunu kullanarak bir slayta erişme
	ISlide slide = pres.getSlides().get_Item(0);

	// Slayttaki birinci ve ikinci yer tutucuya erişip AutoShape olarak tip dönüştürme
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// İlk Paragrafa erişme
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

	// Yeni yazı tiplerini bölüme (portion) ata
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Yazı tipini kalın ayarla
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Yazı tipini italik ayarla
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Yazı tipi rengini ayarla
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// PPTX'i diske kaydet
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Metin Yazı Tipi Özelliklerini Ayarla**

{{% alert color="primary" %}} 

**Yazı Tipi İlgili Özellikleri Yönet** bölümünde belirtildiği gibi, bir [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) paragrafta benzer biçimlendirme stiline sahip metni tutmak için kullanılır. Bu makale, Aspose.Slides for Java kullanarak bir metin kutusu oluşturmayı, içine metin eklemeyi ve ardından belirli bir yazı tipi ve yazı tipi ailesi kategorisinin çeşitli diğer özelliklerini tanımlamayı gösterir.

{{% /alert %}} 

Bir metin kutusu oluşturmak ve içindeki metnin yazı tipi özelliklerini ayarlamak için:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slaytın referansını alın.
1. Slayta **Rectangle** türünde bir [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/) ekleyin.
1. [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/) ile ilişkili doldurma stilini kaldırın.
1. [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/)'ın [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) öğesine erişin.
1. [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/)'e bir metin ekleyin.
1. [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) ile ilişkili [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) nesnesine erişin.
1. [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) için kullanılacak yazı tipini tanımlayın.
1. Kalın, italik, altı çizili, renk ve yükseklik gibi diğer yazı tipi özelliklerini [Portion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/portion/) nesnesi aracılığıyla ilgili özellikleri kullanarak ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Yukarıdaki adımların uygulanması aşağıda verilmiştir.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Şekil: Aspose.Slides for Java tarafından ayarlanan bazı yazı tipi özelliklerine sahip metin**|

```java
// PPTX dosyasını temsil eden bir Presentation nesnesi oluştur
Presentation pres = new Presentation();
try {
	// İlk slaytı al
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Rectangle (dikdörtgen) tipinde bir AutoShape ekle
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
	
	// Yazı tipinin Kalın özelliğini ayarla
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Yazı tipinin İtalik özelliğini ayarla
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Yazı tipinin Altı Çizili özelliğini ayarla
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
---
title: Android'de Sunumlarda Görsel Yönetimini Optimize Edin
linktitle: Görselleri Yönet
type: docs
weight: 10
url: /tr/androidjava/image/
keywords:
- görsel ekle
- resim ekle
- bitmap ekle
- görsel değiştir
- resim değiştir
- webden
- arkaplan
- PNG ekle
- JPG ekle
- SVG ekle
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument'te görsel yönetimini hızlandırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller, sunumları daha çekici ve ilgi çekici hâle getirir. Microsoft PowerPoint’te, bir dosyadan, internetten veya diğer konumlardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides sunumlarınızdaki slaytlara görüntü eklemenizi farklı prosedürler aracılığıyla sağlar. 

{{% alert  title="İpucu" color="primary" %}} 

Aspose, [JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt) gibi ücretsiz dönüştürücüler sağlar; bu sayede kullanıcılar görüntülerden hızlıca sunum oluşturabilir. 

{{% /alert %}} 

{{% alert title="Bilgi" color="info" %}}

Bir resmi çerçeve nesnesi olarak eklemek istiyorsanız—özellikle boyutunu değiştirmek, efekt eklemek vb. için standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Picture Frame](https://docs.aspose.com/slides/tr/androidjava/picture-frame/) sayfasına bakın. 

{{% /alert %}} 

Aspose.Slides, JPEG, PNG, GIF ve diğer popüler formatlarda görüntülerle işlemleri destekler. 

## **Slaytlara Yerel Olarak Depolanan Görselleri Ekle**

Bilgisayarınızdaki bir veya birden fazla görüntüyü bir sunumdaki slayta ekleyebilirsiniz. Java’daki bu örnek kod, bir görüntüyü slayta nasıl ekleyeceğinizi gösterir:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Web'den Slaytlara Görsel Ekle**

Bir slayta eklemek istediğiniz görüntü bilgisayarınızda bulunmuyorsa, görüntüyü doğrudan web üzerinden ekleyebilirsiniz. 

Bu örnek kod, web’den bir görüntüyü Java’daki bir slayta nasıl ekleyeceğinizi gösterir:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Slayt Üstlerine Görseller Ekle**

Bir slide master, altında bulunan tüm slaytların (tema, düzen vb.) bilgilerini depolayan ve kontrol eden en üst slayttır. Bu nedenle, bir slide master’a görüntü eklediğinizde, o görüntü ilgili slide master altındaki her slaytta görünür. 

Bu Java örnek kodu, bir slide master’a nasıl görüntü ekleyeceğinizi gösterir:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Görselleri Slayt Arka Planı Olarak Ekle**

Belirli bir slayt ya da birden fazla slayt için resmi arka plan olarak kullanmaya karar verebilirsiniz. Bu durumda *[Slaytlar İçin Görselleri Arka Plan Olarak Ayarlama](https://docs.aspose.com/slides/tr/androidjava/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakmanız gerekir.

## **Sunumlara SVG Ekle**

Herhangi bir görüntüyü, [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) arayüzüne ait olan ve [addPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metodunu kullanarak bir sunuma ekleyebilirsiniz. 

SVG görüntüsü temelinde bir görüntü nesnesi oluşturmak için şu adımları izleyebilirsiniz: 

1. ImageShapeCollection’a eklemek için SvgImage nesnesi oluşturun  
2. ISvgImage’den PPImage nesnesi oluşturun  
3. IPPImage arayüzünü kullanarak PictureFrame nesnesi oluşturun  

Bu örnek kod, yukarıdaki adımları uygulayarak bir SVG görüntüsünü sunuma nasıl ekleyeceğinizi gösterir:
```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SVG'yi Şekiller Kümesine Dönüştür**

Aspose.Slides’ın SVG’yi şekiller kümesine dönüştürmesi, SVG görüntüleriyle çalışmak için PowerPoint işlevselliğine benzer: 

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) arayüzünün, ilk parametre olarak bir [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISvgImage) nesnesi alan [addGroupShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) metodunun bir aşırı yüklemesi tarafından sağlanır. 

Bu örnek kod, belirtilen yöntemi kullanarak bir SVG dosyasını şekiller kümesine nasıl dönüştüreceğinizi gösterir:

```java 
// Yeni bir sunum oluştur
IPresentation presentation = new Presentation();
try {
    // SVG dosya içeriğini oku
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // SvgImage nesnesi oluştur
    ISvgImage svgImage = new SvgImage(svgContent);

    // Slayt boyutunu al
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG görüntüsünü slayt boyutuna ölçeklendirerek şekil grubuna dönüştür
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Sunumu PPTX formatında kaydet
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Görselleri EMF Olarak Slaytlara Ekle**

Aspose.Slides for Android via Java, Excel sayfalarından EMF görüntüleri oluşturmanıza ve bu görüntüleri Aspose.Cells ile slaytlara EMF olarak eklemenize olanak tanır.  

Bu örnek kod, belirtilen görevi nasıl gerçekleştireceğinizi gösterir:

```java
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Çalışma kitabını akışa kaydet
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Görsel Koleksiyonundaki Görselleri Değiştir**

Aspose.Slides, bir sunumun görsel koleksiyonunda (slayt şekilleri tarafından kullanılanlar dahil) depolanan görüntüleri değiştirmenize olanak tanır. Bu bölüm, koleksiyondaki görüntüleri güncellemenin çeşitli yaklaşımlarını gösterir. API, ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) örneği veya koleksiyonda zaten bulunan başka bir görüntü kullanarak bir resmi değiştirmek için doğrudan yöntemler sunar.  

Aşağıdaki adımları izleyin: 

1. Görüntü içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı ile yükleyin.  
2. Yeni bir görüntüyü dosyadan bayt dizisine yükleyin.  
3. Hedef görüntüyü bayt dizisini kullanarak yeni görüntüyle değiştirin.  
4. İkinci yaklaşımlarda, görüntüyü bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) nesnesine yükleyin ve hedef görüntüyü bu nesneyle değiştirin.  
5. Üçüncü yaklaşımlarda, hedef görüntüyü sunumun görsel koleksiyonunda zaten mevcut olan bir görüntüyle değiştirin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("sample.pptx");
try {
    // İlk yöntem.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // İkinci yöntem.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Üçüncü yöntem.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Sunumu bir dosyaya kaydet.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Bilgi" color="info" %}}

Aspose ÜCRETSİZ [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü sayesinde metinleri kolayca canlandırabilir, metinlerden GIF oluşturabilir vb. işlemleri yapabilirsiniz. 

{{% /alert %}}

## **SSS**

**Eklemeden sonra orijinal görüntü çözünürlüğü korunur mu?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm, slayt üzerindeki [picture](/slides/tr/androidjava/picture-frame/) nasıl ölçeklendirildiğine ve kaydedilirken uygulanan sıkıştırmaya bağlıdır.

**Yüzlerce slaytta aynı logoyu aynı anda değiştirmek için en iyi yöntem nedir?**

Logoyu master slayta veya bir düzene yerleştirin ve sunumun görsel koleksiyonunda değiştirin—güncellemeler, bu kaynağı kullanan tüm öğelere yayılır.

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. Bir SVG’yi bir grup şekle dönüştürebilirsiniz; ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Bir resmi birden fazla slaytın arka planı olarak aynı anda nasıl ayarlayabilirim?**

[Görseli arka plan olarak ata](/slides/tr/androidjava/presentation-background/) komutunu master slayta veya ilgili düzene uygulayın—bu master/duzen’i kullanan tüm slaytlar arka planı devralır.

**Birçok resim nedeniyle sunumun boyutunun “şişmesi” nasıl önlenir?**

Tek bir görüntü kaynağını tekrar kullanın, makul çözünürlükler seçin, kaydederken sıkıştırma uygulayın ve gerektiğinde yinelenen grafikleri master’da tutun.
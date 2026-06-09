---
title: Java Kullanarak Sunumlarda Görsel Yönetimini Optimize Etme
linktitle: Görselleri Yönet
type: docs
weight: 10
url: /tr/java/image/
keywords:
- görsel ekle
- resim ekle
- bitmap ekle
- görsel değiştir
- resim değiştir
- web'den
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
- EMF
- SVG
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument’te görsel yönetimini kolaylaştırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller sunumları daha etkileyici ve ilgi çekici hâle getirir. Microsoft PowerPoint’te bir dosyadan, internetten veya başka konumlardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides, sunumlarınıza slaytlara görsel eklemenize farklı prosedürler aracılığıyla izin verir.

{{% alert  title="İpucu" color="primary" %}} 
Aspose, insanlara görüntülerden hızlı bir şekilde sunum oluşturma imkanı sağlayan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sunar. 
{{% /alert %}} 

{{% alert title="Bilgi" color="info" %}}
Bir resmi çerçeve nesnesi olarak eklemek istiyorsanız—özellikle boyutunu değiştirmek, efekt eklemek vb. için standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Picture Frame](https://docs.aspose.com/slides/tr/java/picture-frame/) sayfasına bakın. 
{{% /alert %}} 

{{% alert title="Not" color="warning" %}}
Görseller ve PowerPoint sunumlarıyla ilgili giriş/çıkış işlemlerini, bir görseli bir formattan diğerine dönüştürmek için manipüle edebilirsiniz. Bu sayfalara bakın: [görseli JPG’ye dönüştürme](https://products.aspose.com/slides/tr/java/conversion/image-to-jpg/); [JPG’yi görsele dönüştürme](https://products.aspose.com/slides/tr/java/conversion/jpg-to-image/); [JPG’yi PNG’ye dönüştürme](https://products.aspose.com/slides/tr/java/conversion/jpg-to-png/), [PNG’yi JPG’ye dönüştürme](https://products.aspose.com/slides/tr/java/conversion/png-to-jpg/); [PNG’yi SVG’ye dönüştürme](https://products.aspose.com/slides/tr/java/conversion/png-to-svg/), [SVG’yi PNG’ye dönüştürme](https://products.aspose.com/slides/tr/java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides, JPEG, PNG, GIF ve diğer popüler formatlardaki görsellerle işlemleri destekler. 

## **Yerel Olarak Depolanan Görselleri Slaytlara Ekleme**

Bilgisayarınızda bulunan bir veya birden fazla görseli bir sunumdaki slayta ekleyebilirsiniz. Java’da bu örnek kod bir görseli slayta nasıl ekleyeceğinizi gösterir:

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

## **Web'den Görselleri Slaytlara Ekleme**

Eklemek istediğiniz görsel bilgisayarınızda bulunmuyorsa, görseli doğrudan web üzerinden ekleyebilirsiniz. 

Java’da bu örnek kod web üzerindeki bir görseli slayta nasıl ekleyeceğinizi gösterir:

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

## **Slayt Üstlerine Görseller Ekleme**

Bir slayt üstü, altındaki tüm slaytların temasını, düzenini vb. kontrol eden üst slayttır. Bu yüzden bir görseli slayt üstüne eklediğinizde, o görsel o slayt üstüne bağlı tüm slaytlarda görünür. 

Java’da bu örnek kod bir slayt üstüne görsel eklemeyi gösterir:

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

## **Görselleri Slayt Arkaplanı Olarak Ekleme**

Belirli bir slayt veya birden fazla slayt için bir resmi arka plan olarak kullanmak isteyebilirsiniz. Bu durumda *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/tr/java/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakmalısınız.

## **Sunumlara SVG Ekleme**
Bir görseli sunuma eklemek veya eklemek için, [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) arayüzüne ait olan ve [addPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metodunu kullanabilirsiniz.

SVG görseline dayalı bir görüntü nesnesi oluşturmak için aşağıdaki şekilde ilerleyebilirsiniz:

1. SvgImage nesnesi oluşturup ImageShapeCollection’a ekleyin  
2. ISvgImage’den PPImage nesnesi oluşturun  
3. IPPImage arayüzünü kullanarak PictureFrame nesnesi oluşturun  

Bu örnek kod, yukarıdaki adımları uygulayarak bir SVG görselini sunuma nasıl ekleyeceğinizi gösterir:
```java 
// PPTX dosyasını temsil eden Presentation sınıfını örnekle
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

## **SVG'yi Bir Dizi Şekle Dönüştürme**
Aspose.Slides’ın SVG’yi şekil kümesine dönüştürmesi, PowerPoint’in SVG görselleriyle çalışmak için sunduğu işlevselliğe benzer:

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) arayüzünün, ilk parametre olarak bir [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISvgImage) nesnesi alan [addGroupShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) metodunun bir aşırı yüklenmesi tarafından sağlanır.

Bu örnek kod, bahsedilen yöntemi kullanarak bir SVG dosyasını şekil kümesine nasıl dönüştüreceğinizi gösterir:

```java 
// Yeni sunum oluştur
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

## **EMF Olarak Görselleri Slaytlara Ekleme**
Aspose.Slides for Java, Excel sayfalarından EMF görselleri oluşturmanıza ve bu görselleri Aspose.Cells ile slaytlara EMF olarak eklemenize olanak tanır.  

Bu örnek kod, tanımlanan görevi nasıl gerçekleştireceğinizi gösterir:

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

## **Görüntü Koleksiyonundaki Görselleri Değiştirme**

Aspose.Slides, bir sunumun görüntü koleksiyonunda (slayt şekilleri tarafından kullanılanlar dahil) depolanan görselleri değiştirmenize izin verir. Bu bölüm, koleksiyondaki görselleri güncellemenin çeşitli yollarını gösterir. API, ham bayt verileri, bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) örneği veya koleksiyonda zaten mevcut olan başka bir görsel kullanarak bir görseli değiştirmek için doğrudan yöntemler sunar.

Aşağıdaki adımları izleyin:

1. Görselleri içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı ile yükleyin.  
2. Yeni bir görseli dosyadan bayt dizisine yükleyin.  
3. Hedef görseli bayt dizisini kullanarak yeni görsel ile değiştirin.  
4. İkinci yöntemle, görseli bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) nesnesine yükleyin ve hedef görseli bu nesneyle değiştirin.  
5. Üçüncü yöntemle, hedef görseli sunumun görüntü koleksiyonunda zaten var olan bir görsel ile değiştirin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

```java
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation("sample.pptx");
try {
    // İlk yöntem.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
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
Aspose ÜCRETSİZ [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü ile metinleri kolayca canlandırabilir, metinlerden GIF oluşturabilirsiniz vb. 
{{% /alert %}}

## **SSS**

**Eklemeden sonra orijinal görüntü çözünürlüğü aynı kalır mı?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm, slayttaki [picture](/slides/tr/java/picture-frame/) ölçeklendirmesine ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır.

**Yüzlerce slaytta aynı logoyu tek seferde değiştirmek için en iyi yöntem nedir?**

Logoyu master slayta veya bir yerleşime koyun ve sunumun görüntü koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. SVG’yi bir şekil grubuna dönüştürebilir ve ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Birden fazla slayt için resmi aynı anda arka plan olarak ayarlamak nasıl yapılır?**

[Resmi arka plan olarak atayın](/slides/tr/java/presentation-background/) master slaytta veya ilgili yerleşimde—bu master/yerleşimi kullanan tüm slaytlar arka planı miras alır.

**Sunum, çok sayıda görsel nedeniyle boyutu “şişmekten” nasıl korunur?**

Tek bir görsel kaynağını tekrar tekrar kullanın, makul çözünürlükler seçin, kaydederken sıkıştırma uygulayın ve gerektiğinde tekrarlanan grafikleri master’da tutun.
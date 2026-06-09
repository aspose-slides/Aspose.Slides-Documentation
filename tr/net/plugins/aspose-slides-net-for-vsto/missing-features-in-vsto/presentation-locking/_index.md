---
title: Sunum Kilitleme
type: docs
weight: 110
url: /tr/net/presentation-locking/
---
## **Sunum Kilitleme**
**Aspose.Slides**'in yaygın bir kullanımı, otomatik bir iş akışının parçası olarak Microsoft PowerPoint 2007 (PPTX) sunumlarını oluşturmak, güncellemek ve kaydetmektir. Bu şekilde Aspose.Slides kullanan uygulamanın kullanıcıları, çıktı sunumlarına erişir. Bu sunumları düzenlemeden korumak yaygın bir endişedir. Otomatik oluşturulan sunumların orijinal biçimlendirme ve içeriklerini koruması önemlidir.

Bu bölüm, sunumların ve slaytların nasıl oluşturulduğunu ve Aspose.Slides for .NET'in bir sunuma nasıl koruma uygulayıp ardından kaldırabileceğini açıklar. Bu özellik Aspose.Slides'e özgüdür ve yazının yazıldığı tarihte Microsoft PowerPoint'te bulunmamaktadır. Geliştiricilere, uygulamalarının oluşturduğu sunumların nasıl kullanılacağını kontrol etme olanağı sağlar.
## **Bir Slaytın Bileşimi**
Bir PPTX slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve sunum oluşturmak için mevcut olan çeşitli diğer öğeler gibi birçok bileşenden oluşur.

Aspose.Slides for .NET içinde, bir slayttaki her öğe bir Shape nesnesine dönüşür. Başka bir deyişle, slayttaki her öğe ya bir Shape nesnesi ya da Shape nesnesinden türetilen bir nesnedir.

PPTX yapısı karmaşıktır, bu nedenle PPT'de tüm şekil tipleri için genel bir kilit kullanılabilmesine karşılık, farklı şekil tipleri için farklı kilit türleri bulunur. BaseShapeLock sınıfı genel PPTX kilitleme sınıfıdır. Aspose.Slides for .NET PPTX için aşağıdaki kilit türlerini destekler.

- AutoShapeLock otomatik şekilleri kilitler.
- ConnectorLock bağlayıcı şekilleri kilitler.
- GraphicalObjectLock grafik nesneleri kilitler.
- GroupshapeLock grup şekilleri kilitler.
- PictureFrameLock resim çerçevelerini kilitler.

Bir Presentation nesnesindeki tüm Shape nesneleri üzerinde yapılan herhangi bir işlem bütün sunuma uygulanır.
## **Koruma Uygulama ve Kaldırma**
Koruma uygulamak, bir sunumun düzenlenememesini sağlar. Sunum içeriğini korumak için yararlı bir tekniktir.

**PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for .NET, slayttaki bir şekli yönetmek için Shape sınıfını sunar.

Daha önce belirtildiği gibi, her şekil sınıfının koruma için ilişkili bir şekil kilidi sınıfı vardır. Bu makale NoSelect, NoMove ve NoResize kilitlerine odaklanmaktadır. Bu kilitler, şekillerin seçilememesini (fare tıklamaları veya diğer seçim yöntemleriyle) ve taşınamamasını ya da yeniden boyutlandırılamamasını sağlar.

Aşağıdaki kod örnekleri, bir sunumda bulunan tüm şekil türlerine koruma uygular.

``` csharp

 //PPTX dosyasını temsil eden Presentation sınıfını başlat

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//PPTX dosyasını temsil eden Presentation sınıfını başlat


//Sunumdaki slaytlara erişmek için ISlide nesnesi

SlideEx slide = pTemplate.Slides[0];

//Geçici şekilleri tutmak için IShape nesnesi

ShapeEx shape;

//Sunumdaki tüm slaytlar arasında gezinme

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Slaytlardaki tüm şekiller arasında gezinme

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//eğer şekil otomatik şekil ise

		if (shape is AutoShapeEx)

		{

			//Auto shape'e tip dönüşümü ve otomatik şekil kilidi alınması

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Şekil kilitleri uygulanıyor

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//eğer şekil grup şekli ise

		else if (shape is GroupShapeEx)

		{

			//Group shape'e tip dönüşümü ve grup şekil kilidi alınması

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Şekil kilitleri uygulanıyor

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//eğer şekil bir bağlayıcı ise

		else if (shape is ConnectorEx)

		{

			//Connector şekline tip dönüşümü ve bağlayıcı şekil kilidi alınması

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Şekil kilitleri uygulanıyor

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//eğer şekil resim çerçevesi ise

		else if (shape is PictureFrameEx)

		{

			//Picture frame şekline tip dönüşümü ve resim çerçevesi şekil kilidi alınması

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Şekil kilitleri uygulanıyor

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Sunum dosyası kaydediliyor

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**Koruma Kaldırma**

Aspose.Slides for .NET kullanılarak uygulanan koruma yalnızca Aspose.Slides for .NET ile kaldırılabilir. Bir şeklin kilidini kaldırmak için uygulanan kilidin değerini false olarak ayarlayın. Aşağıdaki kod örneği, kilitli bir sunumda şekillerin nasıl kilidinin açılacağını gösterir.

``` csharp

 //İstenen sunumu aç
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//Sunumdaki slaytlara erişmek için ISlide nesnesi
SlideEx slide = pTemplate.Slides[0];

//Geçici şekilleri tutmak için IShape nesnesi
ShapeEx shape;

//Sunumdaki tüm slaytlar arasında gezinme
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	//Slaytlardaki tüm şekiller arasında gezinme
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//eğer şekil otomatik şekil ise
		if (shape is AutoShapeEx)
		{
			//Auto shape'e tip dönüşümü ve otomatik şekil kilidi alınması
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//Şekil kilitleri uygulanıyor
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//eğer şekil grup şekli ise
		else if (shape is GroupShapeEx)
		{
			//Grup şekline tip dönüşümü ve grup şekil kilidi alınması
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//Şekil kilitleri uygulanıyor
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//eğer şekil bağlayıcı şekli ise
		else if (shape is ConnectorEx)
		{
			//Bağlayıcı şekle tip dönüşümü ve bağlayıcı şekil kilidi alınması
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//Şekil kilitleri uygulanıyor
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//eğer şekil resim çerçevesi ise
		else if (shape is PictureFrameEx)
		{
			//Resim çerçevesi şekline tip dönüşümü ve resim çerçevesi şekil kilidi alınması
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//Şekil kilitleri uygulanıyor
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//Sunum dosyası kaydediliyor
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Örnek Kodu İndir**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)
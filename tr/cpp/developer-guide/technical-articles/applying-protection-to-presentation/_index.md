---
title: Şekil Kilitleriyle Sunum Düzenlemelerini Önleyin
linktitle: Sunum Düzenlemelerini Önleyin
type: docs
weight: 10
url: /tr/cpp/applying-protection-to-presentation/
keywords:
- düzenlemeleri önle
- düzenlemeye karşı koruma
- şekli kilitle
- konumu kilitle
- seçimi kilitle
- boyutu kilitle
- gruplamayı kilitle
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ın PPT, PPTX ve ODP dosyalarındaki şekilleri nasıl kilitlediğini veya kilidini açtığını keşfedin; sunumları güvence altına alırken kontrollü düzenlemelere ve daha hızlı teslimata izin verir."
---
## **Arka Plan**

Aspose.Slides'ın yaygın bir kullanımı, otomatik bir iş akışının parçası olarak Microsoft PowerPoint (PPTX) sunumlarını oluşturmak, güncellemek ve kaydetmektir. Aspose.Slides'ı bu şekilde kullanan uygulamaların kullanıcıları oluşturulan sunumlara erişir, bu nedenle sunumların düzenlenmeden korunması yaygın bir endişedir. Otomatik olarak oluşturulan sunumların özgün biçimlendirmelerini ve içeriklerini koruması önemlidir.

Bu makale, sunumların ve slaytların nasıl yapılandırıldığını ve Aspose.Slides for C++'ın bir sunuma koruma uygulayıp daha sonra nasıl kaldırabileceğini açıklar. Geliştiricilere, uygulamalarının oluşturduğu sunumların nasıl kullanılacağını kontrol etme yolu sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for C++'da, bir slayttaki her öğe, [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) arayüzünü uygulayan veya bu arayüzü miras alan bir nesne tarafından temsil edilir.

PPTX yapısı karmaşıktır, bu nedenle PPT'de tüm şekil türleri için kullanılan genel bir kilit, PPTX'te farklı şekil türleri için farklı kilitler gerektirir. [IBaseShapeLock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseshapelock/) arayüzü PPTX için genel kilitleme sınıfıdır. Aspose.Slides for C++'da PPTX için aşağıdaki kilit türleri desteklenir:

- [IAutoShapeLock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshapelock/) autoshape'leri kilitler.  
- [IConnectorLock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iconnectorlock/) bağlayıcı şekilleri kilitler.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igraphicalobjectlock/) grafik nesneleri kilitler.  
- [IGroupShapeLock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igroupshapelock/) grup şekilleri kilitler.  
- [IPictureFrameLock](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframelock/) resim çerçevelerini kilitler.   

[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesindeki tüm şekil nesneleri üzerinde yapılan herhangi bir eylem, tüm sunuma uygulanır.

## **Koruma Uygulama ve Kaldırma**

Koruma uygulamak, bir sunumun düzenlenememesini sağlar. Sunum içeriğini korumak için yararlı bir tekniktir.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for C++, slayttaki şekillerle çalışmak için [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) arayüzünü sağlar.

Daha önce bahsedildiği gibi, her şekil sınıfının korunma için ilişkili bir şekil‑kilit sınıfı vardır. Bu makale NoSelect, NoMove ve NoResize kilitlerine odaklanır. Bu kilitler, şekillerin (fare tıklamaları veya diğer seçim yöntemleriyle) seçilememesini ve hareket ettirilememesini veya yeniden boyutlandırılamamasını sağlar.

Aşağıdaki kod örneği bir sunumdaki tüm şekil türlerine koruma uygular.

```cpp
// PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Sunumdaki tüm slaytları dolaşıyor.
for (auto&& slide : presentation->get_Slides())	{

	// Slayttaki tüm şekilleri dolaşıyor.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Şekli bir autoshape'e tip dönüşümü yapıyor ve şekil kilidini elde ediyor.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Şekli bir grup şekline tip dönüşümü yapıyor ve şekil kilidini elde ediyor.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Şekli bir bağlayıcı şekline tip dönüşümü yapıyor ve şekil kilidini elde ediyor.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Şekli bir resim çerçevesine tip dönüşümü yapıyor ve şekil kilidini elde ediyor.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Sunum dosyasını kaydediyor.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Koruma Kaldırma**

Bir şeklin kilidini kaldırmak için, uygulanan kilidin değerini `false` olarak ayarlayın. Aşağıdaki kod örneği, kilitli bir sunumdaki şekillerin nasıl kilidinin açılacağını gösterir.

```cpp
// PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Sunumdaki tüm slaytları dolaşıyor.
for (auto&& slide : presentation->get_Slides())	{

	// Slayttaki tüm şekilleri dolaşıyor.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Şekli bir autoshape'e tip dönüşümü yapıyor ve şekil kilidini elde ediyor.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Şekli bir grup şekline tip dönüşümü yapıyor ve şekil kilidini elde ediyor.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Şekli bir bağlayıcı şekline tip dönüşümü yapıyor ve şekil kilidini elde ediyor.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Şekli bir resim çerçevesine tip dönüşümü yapıyor ve şekil kilidini elde ediyor.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Sunum dosyasını kaydediyor.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Sonuç**

Aspose.Slides, bir sunumdaki şekilleri korumak için çeşitli seçenekler sunar. Tek bir şekli kilitleyebilir veya bir sunumdaki tüm şekiller üzerinden döngü yaparak her birini kilitleyebilir, böylece dosyanın tamamını etkili bir şekilde güvence altına alabilirsiniz. Kilidi `false` değerine ayarlayarak korumayı kaldırabilirsiniz.

## **SSS**

**Aynı sunumda şekil kilitlerini ve şifre korumasını birleştirebilir miyim?**

Evet. Kilitler dosya içindeki nesnelerin düzenlenmesini sınırlandırırken, [şifre koruması](/slides/tr/cpp/password-protected-presentation/) sunumun açılmasını ve/veya kaydedilmesini kontrol eder. Bu mekanizmalar birbirini tamamlar ve birlikte çalışır.

**Belirli slaytlarda düzenlemeyi kısıtlayabilir, diğerlerini etkilemeden bırakabilir miyim?**

Evet. Seçilen slaytlardaki şekillere kilit uygulayın; kalan slaytlar düzenlenebilir kalır.

**Şekil kilitleri gruplanmış nesnelere ve bağlayıcılara uygulanıyor mu?**

Evet. Gruplar, bağlayıcılar, grafik nesneler ve diğer şekil türleri için özel kilit tipleri desteklenir.
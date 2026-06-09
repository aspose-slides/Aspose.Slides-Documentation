---
title: Sunum BLOB'larını .NET'te Verimli Bellek Kullanımı İçin Yönetme
linktitle: BLOB Yönetimi
type: docs
weight: 10
url: /tr/net/manage-blob/
keywords:
- büyük nesne
- büyük öğe
- büyük dosya
- BLOB ekle
- BLOB dışa aktar
- görseli BLOB olarak ekle
- belleği azalt
- bellek tüketimi
- büyük sunum
- geçici dosya
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te BLOB verilerini yöneterek PowerPoint ve OpenDocument dosya işlemlerini optimize edin ve sunumları verimli bir şekilde işleyin."
---
## **Genel Bakış**

Aspose.Slides, sunumlardaki büyük ikili verileri (görüntüler, ses, video ve sunum dosyaları) BLOB tabanlı işleyerek büyük görüntüler, ses, video ve sunum dosyalarıyla çalışırken bellek tüketimini azaltmaya yardımcı olur.

Bu makale, BLOB tabanlı işleme kullanarak bir sunuma büyük medya eklemeyi, bir sunumdan büyük medya dışa aktarmayı ve büyük sunumları daha verimli yüklemeyi gösterir. Ayrıca işleme sırasında geçici dosyaların nasıl kullanılacağını ve bunları saklamak için kullanılan klasörün nasıl değiştirileceğini açıklar.

## **BLOB Hakkında**

**BLOB** (**Binary Large Object**) genellikle ikili formatlarda kaydedilen büyük bir öğedir (fotoğraf, sunum, belge veya medya).

Aspose.Slides for .NET, büyük dosyalar söz konusu olduğunda bellek tüketimini azaltacak şekilde nesneler için BLOB'ları kullanmanıza olanak tanır.

## **Bellek Tüketimini Azaltmak İçin BLOB Kullanımı**

### **Bir Sunuma BLOB Üzerinden Büyük Dosya Ekleme**

[Aspose.Slides](/slides/tr/net/) for .NET, bellek tüketimini azaltmak için BLOB'ları içeren bir süreçle büyük dosyaları (bu örnekte büyük bir video dosyası) bir sunuma eklemenizi sağlar.

Bu C# kodu, BLOB süreciyle büyük bir video dosyasını bir sunuma nasıl ekleyeceğinizi gösterir:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Videonun ekleneceği yeni bir sunum oluşturur
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Videoyu sunuma ekleyelim - KeepLocked davranışını seçtik çünkü
        // "veryLargeVideo.avi" dosyasına erişmeyi planlamıyoruz.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Sunumu kaydeder. Büyük bir sunum çıktı alınırken, bellek tüketimi
        // pres nesnesinin yaşam döngüsü boyunca düşük kalır 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Bir Sunumdan BLOB Üzerinden Büyük Dosya Dışa Aktarma**
Aspose.Slides for .NET, sunumlardan BLOB'ları içeren bir süreçle büyük dosyaları (bu örnekte bir ses veya video dosyası) dışa aktarmanıza olanak tanır. Örneğin, bir sunumdan büyük bir medya dosyasını çıkarmanız gerekebilir ancak dosyanın bilgisayarınızın belleğine yüklenmesini istemezsiniz. Dosyayı BLOB süreciyle dışa aktararak bellek tüketimini düşük tutabilirsiniz.

Bu C# kodu, açıklanan işlemi göstermektedir:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Kaynak dosyayı kilitler ve belleğe YÜKLEMEZ
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Bir Presentation nesnesi oluşturur, "hugePresentationWithAudiosAndVideos.pptx" dosyasını kilitler.
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Her videoyu bir dosyaya kaydedelim. Yüksek bellek kullanımını önlemek için kullanılacak bir tampon gerekir
	// veri akışını sunumun video akışından yeni oluşturulan video dosyası için bir akışa aktarmak.
	byte[] buffer = new byte[8 * 1024];

	// Videolar arasında iterasyon yapar
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Sunumun video akışını açar. Lütfen, özelliklere erişmekten kasıtlı olarak kaçındığımızı unutmayın
		// video.BinaryData gibi - çünkü bu özellik tam video içeren bir bayt dizisi döndürür, bu da
		// baytların belleğe yüklenmesine neden olur. video.GetStream kullanıyoruz, bu bir Stream döndürür - ve YÜKLEMEZ
		//  bütün videoyu belleğe yüklememizi gerektirmez.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// Bellek tüketimi, video veya sunumun boyutundan bağımsız olarak düşük kalacaktır,
	}

	// Gerekirse, aynı adımları ses dosyaları için de uygulayabilirsiniz. 
}
```

### **Bir Resmi BLOB Olarak Sunuma Ekleme**
[**IImageCollection**](https://reference.aspose.com/slides/tr/net/aspose.slides/iimagecollection) arabirimi ve [**ImageCollection**](https://reference.aspose.com/slides/tr/net/aspose.slides/imagecollection) sınıfının yöntemleriyle, bir akış olarak büyük bir resmi ekleyerek BLOB olarak işlenmesini sağlayabilirsiniz.

Bu C# kodu, BLOB süreciyle büyük bir resmi nasıl ekleyeceğinizi gösterir:

```c#
string pathToLargeImage = "large_image.jpg";

// görüntünün ekleneceği yeni bir sunum oluşturur.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// Görüntüyü sunuma ekleyelim - KeepLocked davranışını seçiyoruz çünkü
		// "largeImage.png" dosyasına erişmeyi amaçlamıyoruz.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Sunumu kaydeder. Büyük bir sunum çıktılanırken, bellek tüketimi 
		// pres nesnesinin yaşam döngüsü boyunca düşük kalır
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Bellek ve Büyük Sunumlar**

Genellikle, büyük bir sunumu yüklemek için bilgisayarlar çok miktarda geçici bellek gerektirir. Sunumun tüm içeriği belleğe yüklenir ve sunumun yüklendiği dosya kullanılmaz hale gelir.

1,5 GB video dosyası içeren büyük bir PowerPoint sunumu (large.pptx) düşünün. Sunumu yüklemenin standart yöntemi bu C# kodunda açıklanmıştır:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Ancak bu yöntem yaklaşık 1,6 GB geçici bellek tüketir.

### **BLOB Olarak Büyük Bir Sunumu Yükleme**

BLOB içeren bir süreçle, az bellek kullanarak büyük bir sunumu yükleyebilirsiniz. Bu C# kodu, BLOB süreci kullanılarak büyük bir sunum dosyasının (large.pptx) nasıl yükleneceğini açıklamaktadır:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **Geçici Dosyalar İçin Klasörü Değiştirme**

BLOB süreci kullanıldığında, bilgisayarınız geçici dosyaları varsayılan geçici dosya klasöründe oluşturur. Geçici dosyaların farklı bir klasörde tutulmasını isterseniz, `TempFilesRootPath` kullanarak depolama ayarlarını değiştirebilirsiniz:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
`TempFilesRootPath` kullandığınızda, Aspose.Slides geçici dosyaları saklamak için bir klasör oluşturmaz. Klasörü manuel olarak oluşturmanız gerekir.
{{% /alert %}}

### **Belleği Serbest Bırakmak İçin Sunum Nesnelerini Dispose Etme**

Büyük sunumları işlerken, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneğinin düzgün bir şekilde dispose edildiğinden emin olun, böylece kapladığı bellek serbest olur. Önerilen yöntem, yukarıdaki örneklerde gösterildiği gibi bir `using` ifadesi veya bildirimi kullanmaktır; bu, blok sona erdiğinde sunumu otomatik olarak dispose eder ve yönetilmeyen kaynakları serbest bırakır.

`using` bloğu olmadan bir sunum oluşturursanız, kullanımını tamamladıktan sonra `Dispose()`'ı açıkça çağırın.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...sunumu işleyin...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Kaynakları açıkça serbest bırakın.
presentation.Dispose();
```

## **SSS**

**Aspose.Slides sunumunda hangi veriler BLOB olarak işlenir ve BLOB seçenekleri tarafından kontrol edilir?**

Görüntüler, ses ve video gibi büyük ikili nesneler BLOB olarak işlenir. Sunumun tamamı da yüklendiğinde veya kaydedildiğinde BLOB işleme dahil olur. Bu nesneler, bellek kullanımını yönetmenizi ve gerektiğinde geçici dosyalara geçiş yapmanızı sağlayan BLOB politikaları tarafından kontrol edilir.

**Sunum yüklenirken BLOB işleme kurallarını nerede yapılandırırım?**

[LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) ile [BlobManagementOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/blobmanagementoptions/) kullanın. Burada BLOB için bellek içi sınırını ayarlayabilir, geçici dosyaları izin verip vermemeyi belirleyebilir, geçici dosyalar için kök yolu seçebilir ve kaynak kilitleme davranışını seçebilirsiniz.

**BLOB ayarları performansı etkiler mi ve hız ile bellek arasında nasıl bir denge kurarım?**

Evet. BLOB'u bellek içinde tutmak hızı maksimize eder ancak RAM tüketimini artırır; bellek sınırını düşürmek daha fazla işi geçici dosyalara kaydırır, RAM'i azaltır ancak ek I/O maliyeti getirir. İş yükünüz ve ortamınız için doğru dengeyi sağlamak üzere [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/tr/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) eşik değerini ayarlayın.

**BLOB seçenekleri, çok büyük sunumları (ör. gigabaytlar) açarken yardımcı olur mu?**

Evet. [BlobManagementOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/blobmanagementoptions/) bu senaryolar için tasarlanmıştır: geçici dosyaları etkinleştirmek ve kaynak kilitlemeyi kullanmak, tepe RAM kullanımını önemli ölçüde azaltabilir ve çok büyük slayt desteleri için işlemi istikrarlı hale getirebilir.

**Disk dosyaları yerine akışlardan (streams) yüklerken BLOB politikalarını kullanabilir miyim?**

Evet. Aynı kurallar akışlara da uygulanır: sunum örneği giriş akışını sahiplenebilir ve kilitleyebilir (seçilen kilitleme moduna bağlı olarak), ve izin verildiğinde geçici dosyalar kullanılarak işlem sırasında bellek kullanımı öngörülebilir şekilde tutulur.
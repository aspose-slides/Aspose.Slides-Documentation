---
title: C++'ta Sunum BLOB'larını Yöneterek Bellek Kullanımını Verimli Hale Getirin
linktitle: BLOB Yönetimi
type: docs
weight: 10
url: /tr/cpp/manage-blob/
keywords:
- büyük nesne
- büyük öğe
- büyük dosya
- BLOB ekle
- BLOB dışa aktar
- görüntüyü BLOB olarak ekle
- belleği azalt
- bellek tüketimi
- büyük sunum
- geçici dosya
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta BLOB verilerini yöneterek PowerPoint ve OpenDocument dosya işlemlerini verimli sunum yönetimi için kolaylaştırın."
---
## **Genel Bakış**

Aspose.Slides, büyük resimler, ses, video ve sunum dosyalarıyla çalışırken bellek tüketimini azaltmak için sunumlarda büyük ikili verileri (BLOB) temel alan bir işlem sunar.

Bu makale, BLOB tabanlı işleme kullanarak bir sunuma büyük medya ekleme, bir sunumdan büyük medya dışa aktarma ve büyük sunumları daha verimli yükleme yöntemlerini gösterir. Ayrıca işlem sırasında geçici dosyaların nasıl kullanılacağını ve bunların saklanacağı klasörün nasıl değiştirileceğini açıklar.

## **BLOB Hakkında**

**BLOB** (**Binary Large Object**) genellikle ikili formatta kaydedilmiş büyük bir öğedir (fotoğraf, sunum, belge veya medya).  

Aspose.Slides for C++ büyük dosyalar söz konusu olduğunda bellek tüketimini azaltan bir şekilde nesneler için BLOB kullanılmasına olanak tanır.  

## **Bellek Tüketimini Azaltmak İçin BLOB Kullanımı**

### **Bir Sunuma BLOB Üzerinden Büyük Dosya Ekleme**

[Aspose.Slides](/slides/tr/cpp/) for C++ büyük dosyaları (bu örnekte büyük bir video dosyasını) BLOB süreciyle ekleyerek bellek tüketimini azaltmanıza olanak tanır.

Bu C++ kodu, BLOB süreciyle bir sunuma büyük bir video dosyasının nasıl ekleneceğini gösterir:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Video eklenecek yeni bir sunum oluşturur
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Videoyu sunuma ekleyelim - KeepLocked davranışını seçtik çünkü
// "veryLargeVideo.avi" dosyasına erişmeyi planlamıyoruz.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Sunumu kaydeder. Büyük bir sunum çıktısı alınırken, bellek tüketimi
// pres nesnesinin yaşam döngüsü boyunca düşük kalır
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Bir Sunumdan BLOB Üzerinden Büyük Dosya Dışa Aktarma**
Aspose.Slides for C++ sunumlardan büyük dosyaları (örneğin bir ses veya video dosyasını) BLOB süreciyle dışa aktarmanıza olanak tanır. Örneğin, bir sunumdan büyük bir medya dosyasını çıkarmanız gerekebilir ancak dosyanın bilgisayarınızın belleğine yüklenmesini istemeyebilirsiniz. Dosyayı BLOB süreciyle dışa aktararak bellek tüketimini düşük tutarsınız.

Bu C++ kodu, açıklanan işlemi göstermektedir:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Bir Presentation örneği oluşturur ve "hugePresentationWithAudiosAndVideos.pptx" dosyasını kilitler.

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Her videoyu bir dosyaya kaydedelim. Yüksek bellek kullanımını önlemek için kullanılacak bir tampon gerekli.
// sunumun video akışından yeni oluşturulan video dosyası için bir akışa veriyi aktarmak amacıyla.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Sunumun video akışını açar. Lütfen, özellikle metodlara erişimden kaçındığımızı unutmayın.
	// video->get_BinaryData gibi - çünkü bu metod tam bir video içeren bir bayt dizisi döndürür ve bu da
	// baytların belleğe yüklenmesine neden olur. video->GetStream metodunu kullanıyoruz; bu bir Stream döndürür ve
	// bütün videoyu belleğe yüklememizi gerektirmez.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
		// Bellek tüketimi, videonun veya sunumun boyutuna bakılmaksızın düşük kalacaktır,
}

// Gerekirse, aynı adımları ses dosyaları için de uygulayabilirsiniz.
```

### **Bir Görüntüyü BLOB Olarak Sunuma Ekleme**
[IImageCollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_image_collection) arayüzü ve [ImageCollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.image_collection) sınıfının yöntemleriyle büyük bir resmi akış olarak ekleyerek BLOB olarak işleyebilirsiniz.

Bu C++ kodu, büyük bir resmi BLOB süreciyle nasıl ekleyeceğinizi gösterir:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// görüntünün ekleneceği yeni bir sunum oluşturur.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Görüntüyü sunuma ekleyelim - KeepLocked davranışını seçiyoruz çünkü
// "largeImage.png" dosyasına erişmeyi niyet etmiyoruz.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Sunumu kaydeder. Büyük bir sunum çıktısı alınırken, bellek tüketimi 
// pres nesnesinin yaşam döngüsü boyunca düşük kalır
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Bellek ve Büyük Sunumlar**

Genellikle büyük bir sunumu yüklemek için bilgisayarlar çok fazla geçici bellek gerektirir. Sunumun tüm içeriği belleğe yüklenir ve sunumun yüklendiği dosya kullanım dışı kalır.

1,5 GB video dosyası içeren büyük bir PowerPoint sunumu (large.pptx) düşünün. Sunumu yüklemenin standart yöntemi aşağıdaki C++ kodunda açıklanmıştır:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Ancak bu yöntem yaklaşık 1,6 GB geçici bellek tüketir.  

### **Büyük Sunumu BLOB Olarak Yükleme**

BLOB sürecini kullanarak büyük bir sunumu çok az bellek harcayarak yükleyebilirsiniz. Aşağıdaki C++ kodu, BLOB süreciyle büyük bir sunum dosyasını (large.pptx) nasıl yükleyeceğinizi anlatır:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Geçici Dosyalar İçin Klasörü Değiştirme**

BLOB süreci kullanıldığında bilgisayarınız geçici dosyaları varsayılan geçici dosya klasöründe oluşturur. Geçici dosyaların farklı bir klasörde tutulmasını istiyorsanız `TempFilesRootPath` ayarını değiştirebilirsiniz:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
`TempFilesRootPath` kullandığınızda Aspose.Slides geçici dosyaları saklamak için otomatik olarak bir klasör oluşturmaz. Klasörü elle oluşturmanız gerekir.  
{{% /alert %}}

### **Belleği Serbest Bırakmak İçin Sunum Nesnelerini Yok Etme**

Büyük sunumları işlerken, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğinin uygun şekilde yok edildiğinden emin olun; böylece kapladığı bellek serbest bırakılır. Sunumu kullandıktan sonra `Dispose()` metodunu çağırarak yönetilmeyen kaynakları serbest bırakın.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...sunumu işleyin...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Kaynakları açıkça serbest bırakın.
presentation->Dispose();
```

## **SSS**

**Bir Aspose.Slides sunumunda hangi veriler BLOB olarak ele alınır ve BLOB seçenekleri tarafından kontrol edilir?**  
Resimler, ses ve video gibi büyük ikili nesneler BLOB olarak ele alınır. Sunum dosyasının tamamı da yüklendiğinde veya kaydedildiğinde BLOB işleme dahil olur. Bu nesneler, bellek kullanımını yönetmenizi ve gerektiğinde geçici dosyalara dökülmesini sağlayan BLOB politikalarıyla kontrol edilir.

**Sunum yüklenirken BLOB işleme kurallarını nerede yapılandırırım?**  
[LoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/) ile [BlobManagementOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/blobmanagementoptions/) kullanın. Burada BLOB için bellek limiti, geçici dosyaların izin verilip verilmemesi, geçici dosyalar için kök yol ve kaynak kilitleme davranışı gibi ayarları yapabilirsiniz.

**BLOB ayarları performansı etkiler mi ve hız ile bellek arasındaki dengeyi nasıl sağlarım?**  
Evet. BLOB’un bellekte tutulması hızı maksimize eder ancak RAM tüketimini artırır; bellek limitini düşürmek daha fazla işi geçici dosyalara yönlendirir, RAM’i azaltır fakat ek I/O maliyeti getirir. İş yükünüz ve ortamınız için doğru dengeyi sağlamak amacıyla [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/tr/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) metodunu kullanın.

**BLOB seçenekleri, çok büyük (ör. gigabayt seviyesinde) sunumları açarken yardımcı olur mu?**  
Evet. [BlobManagementOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/blobmanagementoptions/) bu senaryolar için tasarlanmıştır: geçici dosyaları etkinleştirmek ve kaynak kilitlemesini kullanmak, tepe RAM kullanımını önemli ölçüde azaltır ve çok büyük sunumların işlenmesini kararlı hale getirir.

**Disk dosyaları yerine akışlardan yüklerken BLOB politikalarını kullanabilir miyim?**  
Evet. Aynı kurallar akışlar için de geçerlidir: sunum örneği giriş akışını (seçilen kilitleme moduna bağlı olarak) sahiplenebilir ve kilitleyebilir; izin verilmişse geçici dosyalar kullanılır, bu da işlem sırasında bellek kullanımının öngörülebilir olmasını sağlar.
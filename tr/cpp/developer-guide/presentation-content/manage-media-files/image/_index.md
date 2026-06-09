---
title: Sunumlarda Görsel Yönetimini C++ Kullanarak Optimize Edin
linktitle: Görselleri Yönet
type: docs
weight: 10
url: /tr/cpp/image/
keywords:
- görsel ekle
- resim ekle
- bit eşlem ekle
- görsel değiştir
- resim değiştir
- webden
- arka plan
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument'te görsel yönetimini kolaylaştırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller sunumları daha etkileyici ve ilgi çekici hale getirir. Microsoft PowerPoint'te bir dosyadan, internetten veya diğer konumlardan resimler ekleyerek slaytlara yerleştirebilirsiniz. Benzer şekilde, Aspose.Slides sunumlarınızdaki slaytlara farklı yöntemlerle görseller eklemenizi sağlar.

{{% alert title="İpucu" color="primary" %}} 
Aspose, ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sunar; bu sayede kullanıcılar görsellerden hızlıca sunum oluşturabilir. 
{{% /alert %}} 

{{% alert title="Bilgi" color="info" %}}
Bir resmi çerçeve nesnesi olarak eklemek istiyorsanız—özellikle boyutunu değiştirmek, efekt eklemek vb. için standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Picture Frame](/slides/tr/cpp/picture-frame/) bölümüne bakın. 
{{% /alert %}} 

{{% alert title="Not" color="warning" %}}
Resim ve PowerPoint sunumlarıyla ilgili giriş/çıkış işlemlerini manipüle ederek bir resmi bir formattan diğerine dönüştürebilirsiniz. Bu sayfalara bakın: convert [image to JPG](https://products.aspose.com/slides/tr/cpp/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/tr/cpp/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/tr/cpp/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/tr/cpp/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides bu popüler formatlardaki görsellerle işlemleri destekler: JPEG, PNG, GIF ve diğerleri. 

## **Yerel Olarak Depolanan Görselleri Slaytlara Ekleyin**

Bilgisayarınızdaki bir ya da birden fazla görseli bir sunum slaytına ekleyebilirsiniz. C++ örnek kodu bir görseli slayta nasıl ekleyeceğinizi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Web'den Görselleri Slaytlara Ekleyin**

Bir slayta eklemek istediğiniz görsel bilgisayarınızda bulunmuyorsa, görseli doğrudan web'den ekleyebilirsiniz. 

Bu örnek kod, C++'ta web'den bir görseli slayta nasıl ekleyeceğinizi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Görselleri Slayt Ustlerine (Master) Ekleyin**

Bir slayt ustası (slide master), altındaki tüm slaytlara ait bilgileri (tema, düzen vb.) depolayan ve kontrol eden üst slayttır. Bu yüzden bir görseli slayt ustasına eklediğinizde, o görsel o ustanın altındaki tüm slaytlarda görünür. 

Bu C++ örnek kod bir görseli slayt ustasına nasıl ekleyeceğinizi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Görselleri Slayt Arka Planı Olarak Ekleyin**

Belirli bir slayt ya da birden çok slayt için bir resmi arka plan olarak kullanmaya karar verebilirsiniz. Bu durumda *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/tr/cpp/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakmanız gerekir.

## **Sunumlara SVG Ekleme**
Bir sunuma herhangi bir görseli, [IShapeCollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection) arayüzüne ait olan [AddPictureFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) metodunu kullanarak ekleyebilir ya da ekletebilirsiniz.

SVG görüntüsüne dayalı bir görsel nesnesi oluşturmak için şu şekilde yapabilirsiniz:

1. ImageShapeCollection içine eklemek için SvgImage nesnesi oluşturun
2. ISvgImage'den PPImage nesnesi oluşturun
3. IPPImage arayüzünü kullanarak PictureFrame nesnesi oluşturun

Bu örnek kod, yukarıdaki adımları uygulayarak bir SVG görselini sunuma nasıl ekleyeceğinizi gösterir:
``` cpp 
// Belgeler dizininin yolu
System::String dataDir = u"D:\\Documents\\";

// Kaynak SVG dosya adı
System::String svgFileName = dataDir + u"sample.svg";

// Çıktı sunum dosya adı
System::String outPptxPath = dataDir + u"presentation.pptx";

// Yeni bir sunum oluştur
auto p = System::MakeObject<Presentation>();

// SVG dosya içeriğini oku
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage nesnesi oluştur
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// PPImage nesnesi oluştur
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Yeni bir PictureFrame oluşturur 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Sunumu PPTX formatında kaydet
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **SVG'yi Şekil Setine Dönüştürme**
Aspose.Slides'in SVG'yi şekil setine dönüştürmesi, SVG görselleriyle çalışmak için kullanılan PowerPoint işlevine benzer:

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, ilk parametre olarak bir [ISvgImage](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_svg_image) nesnesi alan [IShapeCollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection) arayüzünün [AddGroupShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) metodunun bir aşırı yüklemesi ile sağlanır.

Bu örnek kod, bir SVG dosyasını şekil setine dönüştürmek için açıklanan metodu nasıl kullanacağınızı gösterir:

``` cpp 
// Belgeler dizininin yolu
System::String dataDir = u"D:\\Documents\\";

// Kaynak SVG dosya adı
System::String svgFileName = dataDir + u"sample.svg";

// Çıktı sunum dosya adı
System::String outPptxPath = dataDir + u"presentation.pptx";

// Yeni bir sunum oluştur
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// SVG dosya içeriğini oku
System::String svgContent = File::ReadAllText(svgFileName);

// SvgImage nesnesi oluştur
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Slayt boyutunu al
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// SVG görüntüsünü slayt boyutuna ölçeklendirerek şekil grubuna dönüştür
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Sunumu PPTX formatında kaydet
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Görselleri EMF Olarak Slaytlara Ekleyin**
Aspose.Slides for C++ ile Excel sayfalarından EMF görselleri oluşturabilir ve bu görselleri Aspose.Cells kullanarak slaytlara EMF olarak ekleyebilirsiniz. 

Bu örnek kod, açıklanan görevi nasıl yerine getireceğinizi gösterir:

``` cpp 
System::String dataDir = u"D:\\Documents\\";
 
StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);
 
intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());
 
// Çalışma kitabını akışa kaydet
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);
 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
 
pres->get_Slides()->RemoveAt(0);
 
System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));
 
    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);
 
    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}
 
pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

## **Görsel Koleksiyonundaki Görselleri Değiştirin**

Aspose.Slides, bir sunumun görsel koleksiyonunda (slayt şekilleri tarafından kullanılanlar dahil) depolanan görselleri değiştirmenize izin verir. Bu bölüm, koleksiyondaki görselleri güncellemenin çeşitli yaklaşımlarını gösterir. API, bir görseli ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) örneği ya da koleksiyonda zaten mevcut başka bir görsel kullanarak değiştirmek için doğrudan yöntemler sunar.

Aşağıdaki adımları izleyin:

1. Görselleri içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı ile yükleyin.
2. Yeni bir görseli dosyadan okuyarak bir bayt dizisine yükleyin.
3. Hedef görseli, bayt dizisini kullanarak yeni görsel ile değiştirin.
4. İkinci yöntemde, görseli bir [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) nesnesine yükleyin ve hedef görseli bu nesne ile değiştirin.
5. Üçüncü yöntemde, hedef görseli sunumun görsel koleksiyonunda zaten bulunan bir görsel ile değiştirin.
6. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```cpp
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// İlk yol.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// İkinci yol.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Üçüncü yol.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Sunumu bir dosyaya kaydedin.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Bilgi" color="info" %}}
Aspose FREE [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsünü kullanarak metinleri kolayca hareketlendirebilir, metinlerden GIF oluşturabilir vb.
{{% /alert %}}

## **SSS**

**Ekleme sonrasında orijinal görsel çözünürlüğü korunur mu?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm slayttaki [picture](/slides/tr/cpp/picture-frame/) ölçeklendirmesine ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır.

**Yüzlerce slaytta aynı logoyu aynı anda değiştirmek için en iyi yol nedir?**

Logoyu master slayta veya bir yerleşime yerleştirin ve sunumun görsel koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.

**Eklenmiş bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. Bir SVG'yi şekil grubuna dönüştürebilir, ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hale gelir.

**Bir resmi birden fazla slaytın arka planı olarak aynı anda nasıl ayarlarım?**

Resmi [Assign the image as the background](/slides/tr/cpp/presentation-background/) master slayta veya ilgili yerleşime atayarak—o master/yerleşimi kullanan tüm slaytlar arka planı devralır.

**Birçok görsel nedeniyle sunumun boyutu “şişmesinden” nasıl kaçınırım?**

Tek bir görsel kaynağını tekrar kullanın, kopyalar yerine, makul çözünürlükler seçin, kaydederken sıkıştırma uygulayın ve tekrarlanan grafikleri gerektiğinde masterda tutun.
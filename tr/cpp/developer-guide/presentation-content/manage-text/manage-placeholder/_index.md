---
title: C++'ta Sunum Yer Tutucularını Yönetin
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/cpp/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu 
- görsel yer tutucu
- grafik yer tutucu
- istem metni
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde yer tutucuları zahmetsizce yönetin: metni değiştirin, istemleri özelleştirin ve PowerPoint ile OpenDocument'ta resim saydamlığını ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum yer tutucularını programlı olarak yönetmenizi sağlar. Bu makale, slaytlardaki yer tutucuları bulma ve metinlerini değiştirme, yer tutucu düzenleri için özel istem metni ayarlama ve yer tutucu arka planı olarak kullanılan bir resmin saydamlığını ayarlama konularını açıklar. Ayrıca, temel yer tutucular ile yerel şekiller arasındaki farkı netleştiren, yer tutucu değişikliklerinin düzenler veya ana sayfalar aracılığıyla nasıl uygulanabileceğini açıklayan ve üstbilgi ve altbilgi yer tutucu yönetimine işaret eden kısa bir SSS içerir.

## **Yer Tutucuda Metni Değiştirme**
Aspose.Slides for C++](/slides/tr/cpp/) kullanarak, sunumlardaki slaytlarda yer tutucuları bulabilir ve değiştirebilirsiniz. Aspose.Slides, bir yer tutucudaki metni değiştirmenize olanak tanır.

**Önkoşul**: Yer tutucu içeren bir sunuma ihtiyacınız var. Böyle bir sunumu standart Microsoft PowerPoint uygulamasında oluşturabilirsiniz.

Aspose.Slides'ı kullanarak bu sunumdaki yer tutucunun metnini nasıl değiştireceğiniz aşağıdadır:

1. [`Presentation`](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation/) sınıfının bir örneğini oluşturun ve sunumu parametre olarak geçin.
2. Slayt referansını indeks üzerinden alın.
3. Şekilleri döngüyle gezerek yer tutucuyu bulun.
4. Yer tutucu şekli bir [`AutoShape`](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.auto_shape/) tipine dönüştürün ve bu [`AutoShape`](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.auto_shape/) ile ilişkili [`TextFrame`](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame/) kullanarak metni değiştirin.
5. Değiştirilmiş sunumu kaydedin.

Bu C++ kodu, bir yer tutucudaki metnin nasıl değiştirileceğini gösterir:

```c++
// Belgeler dizinine giden yol.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// İstenen sunumu yükler
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// İlk slayta erişir
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Slayttaki birinci ve ikinci yer tutucuya erişir ve bunları AutoShape olarak tip dönüştürür
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Sunumu diske kaydeder
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Yer Tutucuda İstem Metni Ayarlama**
Standart ve önceden oluşturulmuş düzenler, ***Click to add a title*** veya ***Click to add a subtitle*** gibi yer tutucu istem metinleri içerir. Aspose.Slides kullanarak, tercih ettiğiniz istem metinlerini yer tutucu düzenlerine ekleyebilirsiniz.

Bu C++ kodu, bir yer tutucuda istem metninin nasıl ayarlanacağını gösterir:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Metin olmadığında, PowerPoint "Click to add title" mesajını gösterir. 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Altyazı için de aynı işlemi yapar.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Yer Tutucu Resim Saydamlığını Ayarlama**

Aspose.Slides, bir metin yer tutucusundaki arka plan resminin saydamlığını ayarlamanıza olanak tanır. Böyle bir çerçevedeki resmin saydamlığını ayarlayarak, metnin veya resmin öne çıkmasını sağlayabilirsiniz (metin ve resim renklerine bağlı olarak).

Bu C++ kodu, bir şekil içindeki resim arka planının saydamlığını nasıl ayarlayacağınızı gösterir:

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **SSS**

**Temel yer tutucu nedir ve bir slayttaki yerel şekilden nasıl farklıdır?**

Temel yer tutucu, slaytın şeklinin miras aldığı bir düzen veya ana sayfadaki orijinal şekildir—tip, konum ve bazı biçimlendirmeler ondan gelir. Yerel şekil bağımsızdır; eğer temel bir yer tutucu yoksa, miras uygulanmaz.

**Bir sunumdaki tüm başlıkları veya alt yazıları her slaytı döngüye sokmadan nasıl güncelleyebilirim?**

İlgili yer tutucuyu düzen içinde veya ana sayfada düzenleyin. Bu düzenlere/ana sayfaya dayanan slaytlar değişikliği otomatik olarak miras alır.

**Standart üstbilgi/altbilgi yer tutucularını—tarih & saat, slayt numarası ve altbilgi metni—nasıl kontrol edebilirim?**

Bu yer tutucuları açıp kapatmak ve içeriklerini ayarlamak için uygun kapsamda (normal slaytlar, düzenler, ana sayfa, notlar/dağıtımlar) HeaderFooter yöneticilerini kullanın.
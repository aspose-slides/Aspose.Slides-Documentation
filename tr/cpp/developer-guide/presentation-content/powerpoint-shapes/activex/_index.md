---
title: C++ Kullanarak Sunumlarda ActiveX Denetimlerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/cpp/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönetimi
- ActiveX ekleme
- ActiveX değiştirme
- medya oynatıcı
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'nin ActiveX'i nasıl kullandığını, PowerPoint sunumlarını otomatikleştirip geliştirdiğini öğrenin; geliştiricilere slaytlar üzerinde güçlü kontrol sağlar."
---
## **Giriş**

ActiveX denetimleri sunumlarda kullanılır. Aspose.Slides for C++ ActiveX denetimlerini yönetmenizi sağlar, ancak bunları yönetmek biraz daha zor ve normal sunum şekillerinden farklıdır. Aspose.Slides for C++ 18.1 sürümünden itibaren bileşen ActiveX denetimlerini yönetmeyi desteklemektedir. Şu anda, sunumunuzda daha önce eklenmiş bir ActiveX denetimine erişebilir ve çeşitli özelliklerini kullanarak değiştirebilir veya silebilirsiniz. Unutmayın, ActiveX denetimleri şekil değildir ve sunumun IShapeCollection'ının bir parçası değil, ayrı bir IControlCollection'dadır. Bu makale onlarla nasıl çalışılacağını gösterir.

## **ActiveX Denetimini Değiştirme**
Basit bir metin kutusu ve basit bir komut düğmesi gibi bir ActiveX denetimini bir slaytta yönetmek için:

1. Presentation sınıfının bir örneğini oluşturun ve içinde ActiveX denetimleri bulunan sunumu yükleyin.
1. İndeksine göre bir slayt referansı edinin.
1. IControlCollection'ı erişerek slayttaki ActiveX denetimlerine erişin.
1. ControlEx nesnesini kullanarak TextBox1 ActiveX denetimine erişin.
1. TextBox1 ActiveX denetiminin metin, yazı tipi, yazı tipi yüksekliği ve çerçeve konumu dahil olmak üzere çeşitli özelliklerini değiştirin.
1. CommandButton1 adlı ikinci erişim denetimine erişin.
1. Düğme başlığını, yazı tipini ve konumunu değiştirin.
1. ActiveX denetim çerçevelerinin konumunu kaydırın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Aşağıdaki kod parçacığı, sunum slaytlarındaki ActiveX denetimlerini aşağıdaki gibi günceller.

``` cpp
// ActiveX denetimlerine sahip sunuma erişme
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Sunumdaki ilk slayta erişme
auto slide = presentation->get_Slides()->idx_get(0);

// Metin kutusunun metnini değiştiriyor
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // Yerine geçen resmi değiştiriyor. PowerPoint bu resmi ActiveX etkinleştirmesi sırasında değiştirecek, bu yüzden bazen resmi değiştirmeden bırakmak kabul edilebilir.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Düğme başlığını değiştiriyor
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // Yerine geçen resmi değiştiriyor
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// ActiveX çerçevelerini 100 puan aşağı hareket ettiriyor
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Düzenlenmiş ActiveX denetimleriyle sunumu kaydet
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Şimdi denetimler kaldırılıyor
slide->get_Controls()->Clear();

// Temizlenmiş ActiveX denetimleriyle sunumu kaydetme
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Bir Medya Oynatıcı ActiveX Denetimi Ekleme**
ActiveX denetimleri sunumlarda kullanılır. Aspose.Slides for C++ ActiveX denetimlerini eklemenize ve yönetmenize olanak tanır, ancak bunları yönetmek biraz daha zor ve normal sunum şekillerinden farklıdır. Aspose.Slides for C++ 18.1 sürümünden itibaren, Aspose.Slides içinde Medya Oynatıcı ActiveX denetimi ekleme desteği eklenmiştir. Unutmayın, ActiveX denetimleri şekil değildir ve sunumun IShapeCollection'ının bir parçası değil, ayrı bir IControlExCollection'dadır. Bu makale onlarla nasıl çalışılacağını gösterir. Bir Medya Oynatıcı ActiveX denetimini yönetmek için aşağıdaki adımları uygulayın:

1. Presentation sınıfının bir örneğini oluşturun ve içinde Medya Oynatıcı ActiveX denetimleri bulunan örnek sunumu yükleyin.
1. Hedef Presentation sınıfının bir örneğini oluşturun ve boş bir sunum örneği oluşturun.
1. Şablon sunumundaki Medya Oynatıcı ActiveX denetimli slaytı hedef Presentation'a kopyalayın.
1. Hedef Presentation'daki kopyalanmış slayta erişin.
1. IControlCollection'ı erişerek slayttaki ActiveX denetimlerine erişin.
1. Medya Oynatıcı ActiveX denetimine erişin ve özelliklerini kullanarak video yolunu ayarlayın.
1. Sunumu bir PPTX dosyasına kaydedin.

``` cpp
// PPTX dosyasını temsil eden Presentation sınıfını örnekle
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Boş sunum örneği oluştur
auto newPresentation = System::MakeObject<Presentation>();

// Varsayılan slaytı kaldır
newPresentation->get_Slides()->RemoveAt(0);

// Medya Oynatıcı ActiveX Denetimiyle slaytı kopyala
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Medya Oynatıcı ActiveX denetimine eriş ve video yolunu ayarla
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Sunumu kaydet
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **SSS**

**Aspose.Slides, C++ çalışma zamanında çalıştırılamadıkları durumda ActiveX denetimlerini okurken ve yeniden kaydederken korur mu?**  
**Evet.** Aspose.Slides, bunları sunumun bir parçası olarak kabul eder ve özelliklerini ve çerçevelerini okuyup değiştirebilir; denetimlerin kendilerini çalıştırmak, onları korumak için gerekli değildir.

**ActiveX denetimleri bir sunumdaki OLE nesnelerinden nasıl farklıdır?**  
ActiveX denetimleri etkileşimli yönetilen denetimlerdir (düğmeler, metin kutuları, medya oynatıcı), oysa [OLE](/slides/tr/cpp/manage-ole/) gömülü uygulama nesnelerini (örneğin bir Excel çalışma sayfası) ifade eder. Bunlar farklı şekilde depolanır ve işlenir ve farklı özellik modellerine sahiptir.

**ActiveX olayları ve VBA makroları, dosya Aspose.Slides tarafından değiştirilmişse çalışır mı?**  
Aspose.Slides mevcut işaretlemeyi ve meta verileri korur; ancak, olaylar ve makrolar yalnızca güvenlik izin verdiğinde Windows üzerindeki PowerPoint içinde çalışır. Kütüphane VBA çalıştırmaz.
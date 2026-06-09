---
title: C++'ta AutoFit ile Sunumlarınızı Geliştirin
linktitle: Autofit Ayarları
type: docs
weight: 30
url: /tr/cpp/manage-autofit-settings/
keywords:
- metin kutusu
- otomatik sığdırma
- otomatik sığdırma yapma
- metni sığdır
- metni küçült
- metni kaydır
- şekli yeniden boyutlandır
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta AutoFit ayarlarını yöneterek PowerPoint ve OpenDocument sunumlarınızda metin gösterimini optimize edin ve içerik okunabilirliğini artırın."
---
## **Giriş**

Varsayılan olarak, bir metin kutusu eklediğinizde Microsoft PowerPoint, metin kutusu için **Metni düzeltmek üzere şekli yeniden boyutlandır** ayarını kullanır—metnin her zaman kutuya sığmasını sağlamak için metin kutusunun boyutunu otomatik olarak değiştirir. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Metin kutusundaki metin daha uzun ya da daha büyük olduğunda, PowerPoint metin kutusunun yüksekliğini artırarak otomatik olarak büyütür ve daha fazla metin almasını sağlar.  
* Metin kutusundaki metin daha kısa ya da daha küçük olduğunda, PowerPoint gereksiz boşluğu kaldırmak için metin kutusunun yüksekliğini azaltarak otomatik olarak küçültür.  

PowerPoint'te, bir metin kutusunun otomatik sığdırma davranışını kontrol eden 4 önemli parametre ya da seçenek şunlardır:

* **Otomatik sığdırma yapma**
* **Taşkınlıkta metni küçült**
* **Metni sığdırmak için şekli yeniden boyutlandır**
* **Şekilde metni kaydır.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ , sunumlarda metin kutularının otomatik sığdırma davranışını kontrol etmenizi sağlayan benzer seçenekler—[TextFrameFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame_format) sınıfındaki bazı yöntemler—sunar. 

## **Metni Sığdırmak için Şekli Yeniden Boyutlandır**

Metnin, kutuya yapılan değişikliklerden sonra her zaman kutuya sığmasını istiyorsanız **Metni düzeltmek üzere şekli yeniden boyutlandır** seçeneğini kullanmalısınız. Bu ayarı belirlemek için [TextFrameFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame_format) sınıfındaki [AutofitType](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) özelliğini `Shape` olarak ayarlayın.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Aşağıdaki C++ kodu, PowerPoint sunumunda bir metnin her zaman kutusuna sığdırılması gerektiğini nasıl belirteceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Metin daha uzun ya da daha büyük olduğunda, metin kutusu otomatik olarak (yüksekliği artırılarak) yeniden boyutlandırılır ve tüm metin kutuya sığdırılır. Metin daha kısa olduğunda ise tersine gerçekleşir. 

## **Otomatik Sığdırma Yapma**

Metin kutusunun ya da şeklinin, içinde bulunan metindeki değişikliklerden bağımsız olarak boyutlarını korumasını istiyorsanız **Otomatik sığdırma yapma** seçeneğini kullanmalısınız. Bu ayarı belirlemek için [TextFrameFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame_format) sınıfındaki [AutofitType](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) özelliğini `None` olarak ayarlayın. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Aşağıdaki C++ kodu, PowerPoint sunumunda bir metin kutusunun boyutlarını her zaman koruması gerektiğini nasıl belirteceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Metin kutusunun kutusuna sığamayacak kadar uzun olması durumunda metin dışarı taşar. 

## **Taşkınlıkta Metni Küçült**

Metin kutusunun kutusuna sığamayacak kadar uzun olması durumunda, **Taşkınlıkta metni küçült** seçeneği sayesinde metnin boyutu ve satır aralığı azaltılarak kutuya sığdırılabilir. Bu ayarı belirlemek için [TextFrameFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame_format) sınıfındaki [AutofitType](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) özelliğini `Normal` olarak ayarlayın. 

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Aşağıdaki C++ kodu, PowerPoint sunumunda bir metnin taşkınlıkta küçültülmesi gerektiğini nasıl belirteceğinizi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}
**Taşkınlıkta metni küçült** seçeneği kullanıldığında, ayar yalnızca metin kutusuna sığamayacak kadar uzun olduğunda uygulanır.  
{{% /alert %}}

## **Metni Kaydır**

Metnin, şeklin sınırlarının (sadece genişlik) dışına çıktığında şekil içinde kaydırılmasını istiyorsanız **Şekilde metni kaydır** parametresini kullanmalısınız. Bu ayarı belirlemek için [TextFrameFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame_format) sınıfındaki [WrapText](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) özelliğini `true` olarak ayarlayın. 

Aşağıdaki C++ kodu, PowerPoint sunumunda Metni Kaydır ayarını nasıl kullanacağınızı gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Bir şekil için `WrapText` özelliğini `False` olarak ayarlarsanız, metin şeklin genişliğinden uzun olduğunda tek satır halinde şeklin kenarlarının dışına uzanır. 
{{% /alert %}}

## **SSS**

**Metin çerçevesinin iç kenar boşlukları AutoFit'i etkiler mi?**

Evet. Dolgu (iç kenar boşlukları) metin için kullanılabilir alanı azaltır, bu nedenle AutoFit daha erken devreye girer—yazı tipini küçültür ya da şekli daha erken yeniden boyutlandırır. AutoFit’i ayarlamadan önce kenar boşluklarını kontrol edip gerekirse ayarlayın.

**AutoFit manuel ve yumuşak satır sonlarıyla nasıl etkileşir?**

Zorunlu satır sonları yerinde kalır ve AutoFit bu satır sonları etrafında yazı tipi boyutunu ve satır aralığını ayarlar. Gereksiz satır sonlarını kaldırmak, AutoFit’in metni ne kadar küçülteceğini azaltabilir.

**Tema yazı tipini değiştirmek ya da yazı tipi ikamesi yapmak AutoFit sonuçlarını etkiler mi?**

Evet. Farklı glif ölçüleri olan bir yazı tipine ikame etmek, metnin genişlik/yüksekliğini değiştirir ve bu da son yazı tipi boyutunu ve satır kaydırmayı etkileyebilir. Herhangi bir yazı tipi değişikliği veya ikamesi sonrası slaytları yeniden kontrol edin.
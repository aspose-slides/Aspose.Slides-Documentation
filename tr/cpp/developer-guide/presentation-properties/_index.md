---
title: C++'ta Sunum Özelliklerini Yönet
linktitle: Sunum Özellikleri
type: docs
weight: 70
url: /tr/cpp/presentation-properties/
keywords:
- PowerPoint özellikleri
- sunum özellikleri
- belge özellikleri
- yerleşik özellikler
- özel özellikler
- gelişmiş özellikler
- özellikleri yönet
- özellikleri değiştir
- belge meta verileri
- meta verileri düzenle
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'de sunum özelliklerini yöneterek PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaştırmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türlerinin her ikisi de Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_document_properties) arabirimi aracılığıyla çalışmanıza olanak tanır. Bu arabirimin bir örneği, [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_documentproperties/) yöntemi tarafından döndürülür. Aşağıdaki örnekler bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="primary" %}} 
Lütfen **Application** ve **Producer** alanlarına değer atayamayacağınızı unutmayın, çünkü Aspose Ltd. ve Aspose.Slides for C++ x.x.x bu alanlarda görüntülenecektir.
{{% /alert %}} 

## **Sunum Özelliklerini Yönet**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sağlar. Bu belge özellikleri, belgeler (sunum dosyaları) ile birlikte bazı faydalı bilgilerin depolanmasına izin verir. Aşağıdaki gibi iki tür belge özelliği vardır

- Sistem Tanımlı (Yerleşik) Özellikler
- Kullanıcı Tanımlı (Özel) Özellikler

**Yerleşik** özellikler, belge başlığı, yazarın adı, belge istatistikleri gibi genel bilgileri içerir. **Özel** özellikler, kullanıcılar tarafından **Ad/Değer** çiftleri şeklinde tanımlanan özelliklerdir; burada hem ad hem de değer kullanıcı tarafından belirlenir. Aspose.Slides for C++ kullanarak geliştiriciler, yerleşik özelliklerin yanı sıra özel özelliklerin değerlerine de erişebilir ve bunları değiştirebilir. Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye olanak tanır. Tek yapmanız gereken Office simgesine tıklayıp Microsoft PowerPoint 2007’de **Hazırla | Özellikler | Gelişmiş Özellikler** menü öğesini seçmektir. **Gelişmiş Özellikler** menü öğesini seçtikten sonra, PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır. **Özellikler İletişim Kutusu** içinde **Genel, Özet, İstatistikler, İçindekiler ve Özel** gibi birçok sekme sayfası olduğunu görebilirsiniz. Bu sekme sayfaları, PowerPoint dosyalarıyla ilgili farklı bilgi türlerini yapılandırmanıza izin verir. **Özel** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

## **Yerleşik Özelliklere Erişim**

Bu özellikler, **IDocumentProperties** nesnesi tarafından ortaya çıkarılan: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Oluşturma Tarihi), **Modified** (Değiştirme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **Keywords**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Yerleşik Özellikleri Değiştir**

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe bir dize değeri atayabilir ve özellik değeri değiştirilebilir. Aşağıda verilen örnekte, sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Özel Sunum Özellikleri Ekle**

Aspose.Slides for C++ ayrıca geliştiricilerin sunum belge özellikleri için özel değerler eklemesine izin verir. Aşağıda bir sunum için özel özelliklerin nasıl ayarlanacağını gösteren bir örnek verilmiştir.

``` cpp
// Presentation sınıfını örnekleyin
auto presentation = System::MakeObject<Presentation>();

// Belge özelliklerini alıyor
auto documentProperties = presentation->get_DocumentProperties();

// Özel özellikler ekleniyor
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Belirli bir indeksteki özellik adını alıyor
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Seçili özelliği kaldırıyor
documentProperties->RemoveCustomProperty(getPropertyName);

// Sunumu kaydediyor
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Özel Özelliklere Eriş ve Değiştir**

Aspose.Slides for C++ ayrıca geliştiricilerin özel özelliklerin değerlerine erişmesine olanak tanır. Aşağıda bir sunum için bu özel özelliklerin tümüne nasıl erişileceği ve değiştirileceği gösteren bir örnek bulunmaktadır.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Düzeltme Dili Ayarla**

Aspose.Slides, bir PowerPoint belgesi için düzeltme dili ayarlamanıza olanak tanıyan [LanguageId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_languageid/) özelliğini ([PortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/portionformat/) sınıfı tarafından ortaya çıkarılan) sağlar. Düzeltme dili, PowerPoint’te yazım ve dilbilgisi denetiminin yapılacağı dildir.

Bu C++ kodu, bir PowerPoint için düzeltme dilinin nasıl ayarlanacağını gösterir:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// düzeltme dilinin kimliğini ayarla

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Varsayılan Dil Ayarla**

Bu C++ kodu, bir PowerPoint sunumunun tümü için varsayılan dilin nasıl ayarlanacağını gösterir:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Metin içeren yeni bir dikdörtgen şekil ekler
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// İlk bölümün dilini kontrol eder
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Canlı Örnek**

Belge özellikleriyle Aspose.Slides API üzerinden nasıl çalışılacağını görmek için online uygulama olan [**Aspose.Slides Metadata**](https://products.aspose.app/slides/tr/metadata) deneyin:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## ***SSS**

**Bir yerleşik özelliği bir sunumdan nasıl kaldırabilirim?**

Yerleşik özellikler sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, ilgili özellik izin veriyorsa değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten mevcut bir özel özellik eklerseniz ne olur?**

Zaten mevcut bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet, sunumu tamamen yüklemeden sunum özelliklerine, [PresentationFactory](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationfactory/) sınıfının `GetPresentationInfo` yöntemiyle erişebilirsiniz. Ardından, [IPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/) arabiriminin `ReadDocumentProperties` yöntemini kullanarak özellikleri verimli bir şekilde okuyabilir, belleği tasarruf edebilir ve performansı artırabilirsiniz.
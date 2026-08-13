---
title: C++'da Sunum Özelliklerini Yönet
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
description: "Aspose.Slides for C++'da sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Yerleşik** ve **Özel**. Bu özellik türleri, Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_document_properties) arabirimi üzerinden çalışmanıza olanak tanır. Bu arabirimin bir örneği, [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_documentproperties/) yöntemiyle döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" %}} 

Lütfen **Application** ve **Producer** alanlarına değer atayamayacağınızı unutmayın, çünkü Aspose Ltd. ve Aspose.Slides for C++ x.x.x bu alanlarda görüntülenecektir.

{{% /alert %}} 

## **Sunum Özelliklerini Yönet**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sunar. Bu belge özellikleri, belgelerle (sunum dosyaları) birlikte bazı faydalı bilgilerin depolanmasını sağlar. Aşağıdaki gibi iki tür belge özelliği vardır

- Sistem Tanımlı (Yerleşik) Özellikler
- Kullanıcı Tanımlı (Özel) Özellikler

**Yerleşik** özellikler, belge başlığı, yazarın adı, belge istatistikleri vb. gibi belgeyle ilgili genel bilgileri içerir. **Özel** özellikler ise kullanıcılar tarafından **Name/Value** çiftleri olarak tanımlanan, hem adın hem de değerin kullanıcı tarafından belirlenmiş özelliklerdir. Aspose.Slides for C++ kullanarak geliştiriciler, yerleşik ve özel özelliklerin değerlerine erişebilir ve bu değerleri değiştirebilir. Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye olanak tanır. Tek yapmanız gereken Office simgesine tıklamak ve ardından Microsoft PowerPoint 2007'de **Prepare | Properties | Advanced Properties** menü öğesini seçmektir. **Advanced Properties** menü öğesini seçtikten sonra, PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır. **Properties Dialog** içinde **General, Summary, Statistics, Contents ve Custom** gibi birçok sekme gördüğünüzü göreceksiniz. Bu sekmeler, PowerPoint dosyalarıyla ilgili farklı bilgi türlerini yapılandırmanıza izin verir. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

## **Yerleşik Özelliklere Erişim**

Bu özellikler, **IDocumentProperties** nesnesi tarafından sunulmaktadır ve şunları içerir: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Oluşturma Tarihi), **Modified** (Değiştirme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **Keywords**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Yerleşik Özellikleri Değiştirme**

Sunum dosyalarının yerleşik özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe bir dize değeri atayabilir ve özellik değeri değiştirilebilir. Aşağıdaki örnekte, sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Özel Sunum Özellikleri Ekleme**

Aspose.Slides for C++, geliştiricilerin sunum belge özellikleri için özel değerler eklemelerine de olanak tanır. Aşağıda, bir sunum için özel özelliklerin nasıl ayarlanacağını gösteren bir örnek yer almaktadır.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation sınıfını oluştur
auto presentation = System::MakeObject<Presentation>();

// Belge Özelliklerini Alıyor
auto documentProperties = presentation->get_DocumentProperties();

// Özel özellikler ekleniyor
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Belirli indeksteki özellik adını alıyor
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Seçilen özellik kaldırılıyor
documentProperties->RemoveCustomProperty(getPropertyName);

// Sunumu kaydediyor
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for C++, geliştiricilerin özel özelliklerin değerlerine erişmesine de olanak tanır. Aşağıda, bir sunum için bu özel özelliklerin tümüne nasıl erişileceğini ve değiştirileceğini gösteren bir örnek bulunmaktadır.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Düzeltme Dilini Ayarlama**

Aspose.Slides, bir PowerPoint belgesi için düzeltme dilini ayarlamanızı sağlayan [LanguageId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_languageid/) özelliğini ([PortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/portionformat/) sınıfı tarafından sunulur) sağlar. Düzeltme dili, PowerPoint'te yazım ve dilbilgisi denetiminin yapılacağı dildir.

Bu C++ kodu, bir PowerPoint için düzeltme dilinin nasıl ayarlanacağını gösterir:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
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

## **Varsayılan Dili Ayarlama**

Bu C++ kodu, tüm bir PowerPoint sunumu için varsayılan dilin nasıl ayarlanacağını gösterir:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Metinli yeni bir dikdörtgen şekil ekler
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// İlk bölümün dilini kontrol eder
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Canlı Örnek**

Belge özellikleriyle Aspose.Slides API'si aracılığıyla nasıl çalışılacağını görmek için çevrimiçi [**Aspose.Slides Metadata**](https://products.aspose.app/slides/tr/metadata) uygulamasını deneyin:

[![PowerPoint Metadatasını Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## ***SSS**

### Sunumdan bir yerleşik özelliği nasıl kaldırabilirim?

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, değerlerini değiştirebilir veya ilgili özellik izin veriyorsa boş olarak ayarlayabilirsiniz.

### Zaten var olan bir özel özellik eklersem ne olur?

Zaten var olan bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides özelliğin değerini otomatik olarak günceller.

### Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?

Evet, sunumu tamamen yüklemeden sunum özelliklerine, [PresentationFactory](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationfactory/) sınıfının `GetPresentationInfo` yöntemini kullanarak erişebilirsiniz. Ardından, özellikleri verimli bir şekilde okuyup bellek tasarrufu sağlayan ve performansı artıran [IPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/) arabiriminin `ReadDocumentProperties` yöntemini kullanın.
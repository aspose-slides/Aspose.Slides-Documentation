---
title: PowerPoint Sunumlarında C++ ile Metin Alanlarını Yönetme
linktitle: Metin Alanları
type: docs
weight: 52
url: /tr/cpp/text-fields/
keywords:
- metin alanı
- otomatik metin
- slayt numarası
- tarih ve saat
- üstbilgi
- altbilgi
- metin bölümü
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarında metin alanlarını oluşturun, inceleyin, değiştirin ve kaldırın. Biçimlendirmeyi koruyun ve kaydedilmiş PPTX ve PPT dosyalarını kontrol edin."
---
## **Genel Bakış**

Bir metin paragrafı bölümlerden oluşur. Standart bir [IPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/) gerçek metin içerir; bir alan bölümü ayrıca bir [IField](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifield/) içerir ve türü, slayt numarası veya tarih gibi otomatik olarak güncellenen bir değeri tanımlar. İki bölüm aynı karakterleri gösterebilir ancak sadece biri alan içerir.

Bunları ayırt etmek için [IPortion::get_Field](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/get_field/) kullanın: standart metin için `nullptr` döndürür. [IPortion::AddField](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/addfield/) mevcut bir bölümü alana dönüştürür. Etiketi ve dinamik değerini ayrı bölümlerde tutun, böylece değeri dönüştürmek etiketin de değiştirilmesini engeller.

Bu kılavuz, metin içindeki alanları, bunların biçimlendirmesini ve PPTX ve PPT olarak kaydetmeyi kapsar. Metin çerçeveleri ve paragraflar için [Manage Text](/slides/tr/cpp/manage-text/) bölümüne bakın.

## **Slayt Numarası Alanı Oluşturma**

Aşağıdaki örnek, bir `Slide ` etiketi ve ardından otomatik olarak güncellenen bir sayı içeren bir metin kutusu oluşturur. Sayının boyutunu, kalınlığını ve rengini alanı eklemeden önce ayarlar, ardından kaydedilen sunumu yeniden açar ve alan türünü, metni ve biçimlendirmesini kontrol eder. Girdi dosyası gerektirmez.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

Yeni sunum 1 numaralı slaytla başlar, bu nedenle beklenen metin `Slide 1` olur ve her iki kontrol de `True` yazdırmalıdır. Sayı yeniden açıldıktan sonra da bir alan olarak kalır; gerçek bir `1` değildir. Doğrulamadaki dönüşüm ve indeksler bu örnek tarafından oluşturulan şekil ve bölümlere atıfta bulunur.

## **Bir Alan Türü Seçme**

[FieldType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fieldtype/) [IFieldType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifieldtype/) uygular ve aşağıdaki önceden tanımlanmış değerleri sağlar. Uygun değeri [AddField](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/addfield/) yöntemiyle iletin.

| Accessor | Purpose |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fieldtype/get_slidenumber/) | Geçerli slayt numarası. |
| [get_DateTime](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fieldtype/get_datetime/) | İşleme uygulamasının varsayılan formatındaki tarih/saat. |
| [get_DateTime1](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fieldtype/get_datetime9/) | Önceden tanımlanmış tarih ya da birleştirilmiş tarih/saat formatları. |
| [get_DateTime10](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fieldtype/get_datetime13/) | Önceden tanımlanmış zaman formatları, saniye ve 12 saatlik saat seçenekleriyle. |
| [get_Header](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fieldtype/get_header/) | Üstbilgi alanı; aşağıdaki yer tutucu ve format sınırlamalarına bakın. |
| [get_Footer](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fieldtype/get_footer/) | Altbilgi alanı. |

Örneğin, [get_DateTime3](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fieldtype/get_datetime3/) İngilizce olarak gün, tam ay adı ve yılı sağlar. Bunlar önceden tanımlanmış alan formatlarıdır, rastgele tarih‑format dizesi değildir. Bölümün dili, [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/set_languageid/) ile ayarlandığında ve sunumu işleyen uygulama, gösterilen sonucu etkileyebilir.

## **Dahili Dizeyle Bir Alan Oluşturma**

[AddField](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/addfield/) metodunun dize aşırı yüklemesi dahili bir alan tanımlayıcısı kabul eder. Başka bir uygulama tarafından sağlanan ve önceden tanımlı bir değeri olmayan tanımlayıcıyı korurken bu yöntemi kullanın. Ayrıca bir [FieldType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fieldtype/fieldtype/) nesnesi tanımlayıcıdan oluşturulabilir. [IFieldType::get_InternalString](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifieldtype/get_internalstring/) bu tanımlayıcıyı denetim amacıyla ortaya çıkarır.

Bu örnek, `custom-report-id` adlı uygulamaya özgü bir alanı geri dönüş metni `Report-042` olarak saklar. Girdi dosyası gerektirmez. Tanımlayıcı bir hesaplama kaydetmez: Aspose.Slides bilinmeyen bir tür için rapor kimliği üretmez. Bu tanımlayıcıyı anlayan uygulama, anlamını sağlamalı ve değerini güncellemelidir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

Bu PPTX dönüşümünden sonra beklenen tür `custom-report-id` ve beklenen metin `Report-042` olur. `yyyy-MM-dd` gibi bir dize geçirmek bir alan türü adı verir; özel bir tarih formatı yapılandırmaz. Rastgele bir formatta sabit bir tarih için standart metin kullanın.

## **Tarih/Saat Alanlarını İnceleme, Değiştirme ve Kaldırma**

Mevcut bir alan türünü [IField::get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifield/get_type/) ile okuyun ve [IField::set_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifield/set_type/) ile değiştirin. Türüne erişmeden önce alanın var olduğunu kontrol edin. Otomatik güncellemeleri durdurmak için [IPortion::RemoveField](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/removefield/) yöntemini çağırın. Bu, alan ilişkilendirmesini kaldırırken bölümü ve mevcut metni korur. Belirli bir sabit değer gerekiyorsa, alanı kaldırdıktan sonra o metni atayın.

Tarih/saat alanı işleme ile ilişkili API ayarı için [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/set_currentdatetime/) bölümüne bakın. Aşağıdaki örnek, bir alanı standart metne dönüştürürken açık bir onay tarihi kullanır.

[sample.pptx](sample.pptx) dosyasını indirin ve çalışma dizinine koyun. Dosya, `UpdatedAt` ve `ApprovedDate` adlarında iki adlandırılmış metin şekli içerir; her biri bir tarih/saat alanı ve ayrıca standart metin etiketleri taşır. Aşağıdaki örnek, normal slaytlardaki üst‑seviye metin şekillerini dolaşır. Tarih/saat alanlarını uzun tarih formatına çevirir ve eğik yapar, diğer biçimlendirmelerini korur. Yalnızca `ApprovedDate` içindeki alanlar sabit metne dönüşür.

Örnek, yerleşik dahili tanımlayıcılar `datetime` ve `datetime1`‑`datetime13` tanır. Gruplar, tablolar, notlar, yerleşimler ve ana taslaklar kendi metin kapsayıcılarının gezilmesini gerektirir ve bu örnek kapsamının dışındadır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Yeniden açıldıktan sonra `UpdatedAt` türü `datetime3` olmalı ve dinamik kalmalıdır. `ApprovedDate` alanı olmamalı ve `05 April 2030` içermelidir. Her iki tarih bölümü de eğik olmalı ve orijinal yazı tipi boyutu, kalınlık ve renk korunmalıdır. Standart metin etiketleri değişmez. Doğrulama, sağlanan örnek dosyasındaki iki bilinen şeklin ilk bölümünü okur.

## **Metin Biçimlendirmesini Korumak**

Bir alan eklerken, türünü değiştirirken veya kaldırırken mevcut bölümü kullanın. Bu işlemler bölümü biçimlendirmesini korur. Gerekli özellikleri değiştirmek için [IPortion::get_PortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/get_portionformat/) kullanın; örneklerde renk veya eğiklik gibi ayarlar gösterildiği gibi yapılır.

Tek bir alanı güncellemek için tüm bir metin çerçevesini yeniden oluşturmaktan kaçının: bu, orijinal bölüm sınırlarını ve bireysel biçimlendirmelerini kaybetmenize yol açabilir. Ayrıca doğrudan ayarlanmış biçimlendirme ile paragraf, yerleşim veya tema tarafından miras alınan biçimlendirmeyi ayırın. Daha geniş biçimlendirme seçenekleri için [Text Formatting](/slides/tr/cpp/text-formatting/) bölümüne bakın.

## **Alanlar ve Üstbilgi/Altbilgi Yer Tutucuları**

Bir alan bir metin bölümünün parçasıdır. Bir yer tutucu, altbilgi veya slayt numarası gibi bir sunum rolüne sahip şekildir. Standart bir metin kutusuna alan eklemek, o şekli bir yer tutucuya dönüştürmez.

Üstbilgi/altbilgi yöneticileri, slaytlar, yerleşimler ve ana taslaklar üzerindeki yer tutucu metni ve görünürlüğü kontrol eder; bunlar bağımlı slaytlara da yayılır. Özel bir metin kutusundaki sayı alanı, slayt‑numarası yer tutucusunu kullanmasanız bile yararlı olabilir. Öte yandan, yer tutucu görünürlüğünü değiştirmek, bağımsız bir metin kutusundaki alanı kaldırmaz.

Önceden tanımlı üstbilgi ve altbilgi türleri, karşılık gelen yer tutucuları oluşturmaz veya içeriklerini sağlamaz. Özellikle, normal bir PowerPoint slaytında üstbilgi yer tutucusu yoktur; üstbilgiler not sayfalarına ve el kitabına aittir. Rastgele bir şekildeki üstbilgi veya altbilgi alanının, yer tutucu yöneticisi aracılığıyla yapılandırılan metni otomatik olarak alacağını varsamayın. Bu iş akışı için [Presentation Headers and Footers](/slides/tr/cpp/presentation-header-and-footer/) bölümüne bakın.

## **PPTX ve PPT Sınırlamaları**

Kaydedip yeniden açtıktan sonra hem alan türünü hem de ortaya çıkan metni kontrol edin. Bir tanımlayıcının korunması, bir uygulamanın değerini hesaplayabileceğini veya görüntüleyebileceğini kanıtlamaz.

| Format | Field behavior and limitations |
|---|---|
| PPTX | İç alan tanımlayıcılarını alan metniyle birlikte saklar. Önceden tanımlı türleri ve özel tanımlayıcıları kaydedip yeniden açtıktan sonra kontrol etmek için yukarıdaki örnekleri kullanın. Bilinmeyen bir özel tür otomatik hesaplama mantığı edinmez. Başka bir uygulama, desteklenmeyen tanımlayıcıları farklı şekilde işleyebilir. |
| PPT | Eski alan temsillerini kullanır ve uyumluluğu daha sınırlıdır. Slayt‑numarası ve önceden tanımlı tarih/saat alanları eski temsillere sahiptir. Standart bir slayt metin kutusundaki desteklenmeyen özel alanlar veya üstbilgi alanları metin olarak `*` üretebilir. Görünür metnin korunacağını varsaymayın. |

Taşınabilir, sabit çıktı için, desteklenmeyen alanları standart metne dönüştürün ve kaydetmeden önce istediğiniz değeri açıkça atayın. Bu, seçilen metni korur ancak otomatik güncellemeleri kasıtlı olarak durdurur. Çalışma akışınızın bir parçası olarak hedef uygulamanın kendi alan yeniden hesaplamasını da test edin.

## **SSS**

**Bir görüntülenen sayı ya da tarihin bir alan olup olmadığını nasıl anlayabilirim?**  
[IPortion::get_Field](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/get_field/) özelliğini inceleyin. Null olmayan bir değer alanı gösterir; yalnızca görüntülenen metin tek başına bunu söylemez.

**Bir alanı kaldırmak metnini veya biçimlendirmesini kaldırır mı?**  
Hayır. [RemoveField](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/removefield/) mevcut bölümü standart metne çevirir. Belirli bir sabit tarih veya yedek değer gerekiyorsa, alanı kaldırdıktan sonra o değeri atayın.

**Bir dahili dize yeni bir tarih formatı ya da formül tanımlayabilir mi?**  
Hayır. Bu sadece bir alan türünü tanımlar. Bilinmeyen bir tanımlayıcı, bir değerlendirme motoru veya tarih‑format kalıbı sağlamaz. Desteklenen önceden tanımlı türlerden birini kullanın ya da değeri kendiniz standart metin olarak biçimlendirin.

**Bir sunumu kaydettikten sonra tekrar kontrol etmek neden önemlidir?**  
Alan tanımlayıcıları, hesaplanan metin ve biçimlendirme ayrı ayrı doğrulanması gereken öğelerdir. Format dönüşümü, alan tanımlayıcısı hâlâ mevcut olsa bile görünür sonucu değiştirebilir.